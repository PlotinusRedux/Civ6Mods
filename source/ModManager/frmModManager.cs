using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using Civ6Mod;

namespace ModManager
{
    public partial class frmModManager : Form
    {
        public static string FileVersion {
            get
            {
                string s = Application.ProductVersion;
                int i = s.IndexOf(".");
                if (i > -1)
                {
                    i = s.IndexOf(".", i + 1);
                    if (i > -1)
                        s = s.Substring(0, i);
                }

                return s;
            }
        }

        Civ6Mod.ModHandler Handler;

        private void OnModAdded(Mod m)
        {
            int i = grdMods.Rows.Add();
            grdMods.Rows[i].Cells[colModName.Name].Value = m.Title;
            grdMods.Rows[i].Cells[colID.Name].Value = m.Id;
            grdMods.Rows[i].Cells[colEnabled.Name].Value = m.Enabled;
            grdMods.Rows[i].Cells[colVisible.Name].Value = m.Visible;
            grdMods.Rows[i].Cells[colVersion.Name].Value = m.Version;
            grdMods.Rows[i].Cells[colAuthor.Name].Value = m.Properties.GetLocalized(ModPropertyType.Authors);
            grdMods.Rows[i].Cells[colTeaser.Name].Value = m.Properties.GetLocalized(ModPropertyType.Teaser);
        }

        private void OnModDeleted(Mod m)
        {
            for (int i = grdMods.Rows.Count - 1; i >= 0; i--)
                if (grdMods.Rows[i].Cells[colID.Name].Value.ToString().Equals(m.Id))
                    grdMods.Rows.RemoveAt(i);
        }

        private void ShowError(string strMessage, string strTitle = "Error")
        {
            if (InvokeRequired)
                Invoke((Action)(() => MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)));
            else
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public frmModManager()
        {
            InitializeComponent();

            Text = Text + " v" + FileVersion;

            LoadMods();
        }

        private void LoadMods()
        {
            try
            {
                grdMods.Rows.Clear();

                ModPaths.AssignPaths();
                if (string.IsNullOrEmpty(ModPaths.AppPath))
                    if (string.IsNullOrEmpty(ModManagerSettings.Civ6Path) || !ModPaths.TrySetAppPath(ModManagerSettings.Civ6Path))
                    {
                        while (true)
                        {
                            if (DialogResult.OK != dlgOpenFolder.ShowDialog())
                            {
                                Application.Exit();
                                return;
                            }

                            if (ModPaths.TrySetAppPath(dlgOpenFolder.SelectedPath))
                            {
                                ModManagerSettings.Civ6Path = ModPaths.AppPath;
                                ModManagerSettings.Save();
                                break;
                            }
                        }
                    }                    

                Handler = new ModHandler();
                Handler.OnModAdded += OnModAdded;
                Handler.OnModDeleted += OnModDeleted;
                Handler.OnModIdChanging += (Mod m, string strNewId) => OnModDeleted(m);
                Handler.OnModIdConflict += (Mod m1, Mod m2, ref bool fHandled) => fHandled |= frmModIdConflict.Display(Handler, m1, m2);
                Mod.OnModShowError += ShowError;

                Handler.LoadMods();
            }
            catch (Exception ex)
            {
                ShowError("Error loading mods: " + ex.Message);
                Application.Exit();
            }

            grdMods.Sort(colModName, ListSortDirection.Ascending);

            CheckBlocked();
        }

        private void mnuNewModSet_Click(object sender, EventArgs e)
        {
            Mod m = null;
            if (sender == tbEditModSet && grdMods.SelectedRows.Count > 0)
                m = ModAtRow(grdMods.SelectedRows[0].Index);

            if (m == null)
                m = new Mod(ModPaths.ModsPath, "", "", true);

            if (frmModSetEdit.Display(Handler, m))
            {
                grdMods.SuspendLayout();
                try
                {
                    if (ModSetOptions.HideChildren)
                    {
                        for (int i = 0; i < grdMods.Rows.Count - 1; i++)
                        {
                            Mod m2 = ModAtRow(i);
                            if (m2.Visible)
                            {
                                foreach (var cr in m.ModSet.ChildModRefs)
                                {
                                    if (m2.Id.Equals(cr.Id))
                                    {
                                        m2.Visible = false;
                                        m2.WriteEnabledAndVisible();
                                        break;
                                    }
                                }
                            }
                        }
                        UpdateGrid();
                    }

                    grdMods.Sort(colModName, ListSortDirection.Ascending);

                    for(int i = 0; i < grdMods.Rows.Count; i++)
                        if (ModAtRow(i) == m)
                        {
                            grdMods.Rows[i].Selected = true;
                            break;
                        }
                }
                finally
                {
                    grdMods.ResumeLayout();
                }
            }
        }

        private Mod ModAtRow(int iRow) { return (iRow >= 0 && iRow < grdMods.Rows.Count && grdMods.Rows[iRow].Cells[colID.Name].Value != null) ? Handler.Mods[grdMods.Rows[iRow].Cells[colID.Name].Value.ToString()] : null; }
        private Mod SelectedMod { get { return (grdMods.SelectedRows.Count > 0 && grdMods.SelectedRows[0].Cells[colID.Name].Value != null) ? Handler.Mods[grdMods.SelectedRows[0].Cells[colID.Name].Value.ToString()] : null; } }

        private void mnuDeleteMod_Click(object sender, EventArgs e)
        {
            Mod m = SelectedMod;

            if (m != null && DialogResult.Yes == MessageBox.Show("Really delete mod " + m.Title + "?  This cannot be undone.", "Delete Mod", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                m.Delete();
            }
        }

        private void grdMods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Mod m = ModAtRow(e.RowIndex);

            if (m != null)
            {
                grdMods.EndEdit();

                bool fVisible = (bool)grdMods.Rows[e.RowIndex].Cells[colVisible.Name].Value;
                bool fEnabled = (bool)grdMods.Rows[e.RowIndex].Cells[colEnabled.Name].Value;

                if (fVisible != m.Visible || fEnabled != m.Enabled)
                {
                    m.Visible = fVisible;
                    m.Enabled = fEnabled;

                    m.WriteEnabledAndVisible();
                }

                CheckBlocked(e.RowIndex);
            }
        }

        private void mnuHideAll_Click(object sender, EventArgs e)
        {
            int iTag = -1;

            if (sender is ToolStripMenuItem)
                int.TryParse((string)(sender as ToolStripMenuItem).Tag, out iTag);
            else if (sender is ToolStripButton)
                int.TryParse((string)(sender as ToolStripButton).Tag, out iTag);

            if (iTag > -1)
            {
                bool fValue = (iTag & 1) == 1;
                int iColumn = grdMods.Columns[(((iTag & 2) == 0) ? colVisible : colEnabled).Name].Index;

                for (int i = 0; i < grdMods.Rows.Count; i++)
                {
                    grdMods.Rows[i].Cells[iColumn].Value = fValue;
                    grdMods_CellContentClick(grdMods, new DataGridViewCellEventArgs(iColumn, i));
                }
            }
        }

        private void CheckBlocked(int iRow)
        {
            Mod m = ModAtRow(iRow);
            List<Mod> lstBlocked;

            if (m != null && m.Enabled && Handler.CheckBlockingModsEnabled(m, out lstBlocked))
            {
                if (frmModBlocked.Display(Handler, m, lstBlocked) != 0)
                {
                    m.Enabled = false;
                    m.WriteEnabledAndVisible();
                }
                else
                {
                    foreach (Mod m2 in lstBlocked)
                    {
                        m2.Enabled = false;
                        m2.WriteEnabledAndVisible();
                    }
                }
                UpdateGrid();
            }
        }

        private void CheckBlocked()
        {
            for (int i = 0; i < grdMods.Rows.Count; i++)
                CheckBlocked(i);
        }

        private void UpdateGrid()
        {
            for(int i = grdMods.Rows.Count - 1; i >= 0 ; i--)
            {
                DataGridViewRow r = grdMods.Rows[i];
                Mod m = ModAtRow(i);
                if (m == null)
                    grdMods.Rows.RemoveAt(i);
                else
                {
                    if ((bool)r.Cells[colVisible.Name].Value != m.Visible)
                        r.Cells[colVisible.Name].Value = m.Visible;
                    if ((bool)r.Cells[colEnabled.Name].Value != m.Enabled)
                        r.Cells[colEnabled.Name].Value = m.Enabled;
                    if (!((string)r.Cells[colModName.Name].Value).Equals(m.Title))
                        r.Cells[colModName.Name].Value = m.Title;
                    if (!((string)r.Cells[colVersion.Name].Value).Equals(m.Version))
                        r.Cells[colVersion.Name].Value = m.Version;
                    if (!((string)r.Cells[colAuthor.Name].Value).Equals(m.Properties.GetLocalized(ModPropertyType.Authors)))
                        r.Cells[colAuthor.Name].Value = m.Properties.GetLocalized(ModPropertyType.Authors);
                    if (!((string)r.Cells[colTeaser.Name].Value).Equals(m.Properties.GetLocalized(ModPropertyType.Teaser)))
                        r.Cells[colTeaser.Name].Value = m.Properties.GetLocalized(ModPropertyType.Teaser);
                }
            }
        }

        private void tbRefresh_Click(object sender, EventArgs e)
        {
            LoadMods();
        }

        private void tbViewMod_Click(object sender, EventArgs e)
        {
            Mod m = SelectedMod;

            if (m != null)
            {
                frmModView.Display(Handler, m);
            }
        }

        private void grdMods_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedMod != null && SelectedMod.IsModSet)
                mnuNewModSet_Click(tbEditModSet, e);
            else
                tbViewMod_Click(sender, e);
        }

        private void tbHelp_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "ReadMe.md");
        }

        private void frmModManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.Z)
            {
                e.Handled = true;
                MessageBox.Show("DLC Path: " + ModPaths.DLCPath);
            }
        }
    }
}
