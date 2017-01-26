using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Civ6Mod;
using System.IO;

namespace ModManager
{
    public partial class frmModSetEdit : Form
    {
        private ModHandler Handler;
        private Mod ModSet;
        private bool IsNew;


        private string m_strLastName;

        public static bool Display(ModHandler mh, Mod ms)
        {
            using (var frm = new frmModSetEdit(mh, ms))
                return frm.ShowDialog() == DialogResult.OK;
        }

        public frmModSetEdit(ModHandler mh, Mod ms) : this()
        {
            Handler = mh;
            ModSet = ms;

            IsNew = string.IsNullOrEmpty(ms.Id);

            if (IsNew)
                txtId.Text = Guid.NewGuid().ToString();
            else
            {
                txtId.Text = ms.Id;
                txtId.Enabled = false;
                txtName.Text = (ms.Title.StartsWith("<ModSet> ", StringComparison.OrdinalIgnoreCase)) ? ms.Title.Substring("<ModSet> ".Length) : ms.Title;
                txtFileName.Text = ms.RelPath;
                txtFileName.Enabled = false;
            }

            foreach (var mr in ms.ModSet.ChildModRefs)
            {
                lstIncluded.Items.Add(mr);
            }

            foreach (var kv in mh.Mods)
            {
                if (kv.Value == ms)
                    continue;

                bool fFound = false;
                foreach (var mr in ms.ModSet.ChildModRefs)
                {
                    if (kv.Value.Id.Equals(mr.Id))
                    {
                        fFound = true;
                        break;
                    }
                }

                if (!fFound)
                    lstExcluded.Items.Add(new ModChildRef(kv.Value));
            }

            m_strLastName = txtName.Text;

            IsValid();
        }

        private frmModSetEdit()
        {
            InitializeComponent();
        }

        private void panChildren_Layout(object sender, LayoutEventArgs e)
        {
            Rectangle r = panChildren.ClientRectangle;
            int w = r.Width;

            r.Width = (w - panChildrenButtons.Width) / 2;
            panAddedChildren.Bounds = r;

            r.X = r.Width;
            r.Width = panChildrenButtons.Width;
            panChildrenButtons.Bounds = r;

            r.X += r.Width;

            r.Width = panChildren.ClientRectangle.Right - r.X;
            panExcludedChildren.Bounds = r;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                ModSet.Title = txtName.Text;
                if (!ModSet.Title.StartsWith("<ModSet> "))
                    ModSet.Title = "<ModSet> " + ModSet.Title;
                ModSet.Id = txtId.Text;
                ModSet.RelPath = txtFileName.Text;
                if (!ModSet.RelPath.StartsWith("_ModSet_"))
                    ModSet.RelPath = "_ModSet_" + ModSet.RelPath;

                ModSet.FileName = txtFileName.Text + ".modinfo";
                ModSet.ModSet.ChildModRefs.Clear();

                foreach (ModChildRef mr in lstIncluded.Items)
                    ModSet.ModSet.ChildModRefs.Add(mr);

                ModSet.ModSetBuilt = false;

                try
                {
                    if (!frmModAsync.Display(() => ModSet.BuildModSet(Handler), "Building " + ModSet.Title) || !ModSet.ModSetBuilt )                       
                        return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                if (!IsNew)
                    Handler.RemoveMod(ModSet);
                Handler.AddMod(ModSet);

                DialogResult = DialogResult.OK;
            }

        }

        private void txtFileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !IsValidChar(sender, e.KeyChar))
                e.Handled = true;
        }

        public bool IsValidChar(object sender, char c)
        {
            if (sender == txtFileName || sender == txtId)
                return char.IsLetterOrDigit(c) || 0 <= " _-".IndexOf(c);
            else
                return 0 > "\"\\/".IndexOf(c);
        }

        public bool IsValid(object sender = null)
        {
            bool fAllValid = true;

            bool fValid = true;

            string s = txtFileName.Text;

            if (string.IsNullOrWhiteSpace(s))
            {
                errInvalid.SetError(txtFileName, "Filename required.");
                fValid = false;
            }
            else if (!char.IsLetterOrDigit(s[0]) && s[0] != '_')
            {
                errInvalid.SetError(txtFileName, "Filename must start with a letter, number, or underscore.");
                fValid = false;
            }
            else if (!char.IsLetterOrDigit(s.Last()) && s.Last() != '_')
            {
                errInvalid.SetError(txtFileName, "FileName must end with a letter, number, or underscore.");
                fValid = false;
            }
            else
            {
                foreach (char c in s)
                {
                    if (!IsValidChar(txtFileName, c))
                    {
                        errInvalid.SetError(txtFileName, "Invalid character: " + c);
                        fValid = false;
                    }
                }
            }

            if (fValid)
            {
                try
                {
                    if (IsNew && (Directory.Exists(Path.Combine(ModPaths.ModsPath, s)) || Directory.Exists(Path.Combine(ModPaths.ModsPath, "_ModSet_" + s))))
                    {
                        errInvalid.SetError(txtFileName, "Path already in use.");
                        fValid = false;
                    }
                }
                catch (Exception ex)
                {
                    errInvalid.SetError(txtFileName, ex.Message);
                    fValid = false;
                }
            }

            if (fValid)
                errInvalid.SetError(txtFileName, null);
            else
                fAllValid = false;



            fValid = true;

            s = txtId.Text;

            if (string.IsNullOrWhiteSpace(s))
            {
                errInvalid.SetError(txtId, "Id required.");
                fValid = false;
            }
            else if (!char.IsLetterOrDigit(s[0]) && s[0] != '_')
            {
                errInvalid.SetError(txtId, "Id must start with a letter, number, or underscore.");
                fValid = false;
            }
            else if (!char.IsLetterOrDigit(s.Last()) && s.Last() != '_')
            {
                errInvalid.SetError(txtId, "Id must end with a letter, number, or underscore.");
                fValid = false;
            }
            else if (Handler.Mods.ContainsKey(s) && IsNew)
            {
                errInvalid.SetError(txtId, "Id already in use");
                fValid = false;
            }
            else
            {
                foreach (char c in s)
                {
                    if (!IsValidChar(txtId, c))
                    {
                        errInvalid.SetError(txtId, "Invalid character: " + c);
                        fValid = false;
                    }
                }
            }

            if (fValid)
                errInvalid.SetError(txtId, null);
            else
                fAllValid = false;


            fValid = true;

            s = txtName.Text;

            if (string.IsNullOrWhiteSpace(s))
            {
                errInvalid.SetError(txtName, "Name required.");
                fValid = false;
            }
            else if (!char.IsLetterOrDigit(s[0]) && s[0] != '_')
            {
                errInvalid.SetError(txtName, "Name must start with a letter, number, or underscore.");
                fValid = false;
            }
            else if (!char.IsLetterOrDigit(s.Last()) && s.Last() != '_')
            {
                errInvalid.SetError(txtName, "Name must end with a letter, number, or underscore.");
                fValid = false;
            }
            else
            {
                foreach (char c in s)
                {
                    if (!IsValidChar(txtName, c))
                    {
                        errInvalid.SetError(txtName, "Invalid character: " + c);
                        fValid = false;
                    }
                }
            }

            if (fValid && IsNew)
                foreach (KeyValuePair<string, Mod> kv in Handler.Mods)
                    if (kv.Value.Title.Equals(s, StringComparison.OrdinalIgnoreCase) || kv.Value.Title.Equals("<ModSet> " + s, StringComparison.OrdinalIgnoreCase))
                    {
                        errInvalid.SetError(txtName, "Name already in use.");
                        fValid = false;
                    }

            if (fValid)
                errInvalid.SetError(txtName, null);
            else
                fAllValid = false;

            fAllValid = fAllValid && lstIncluded.Items.Count > 0;

            btnOK.Enabled = fAllValid;

            return fAllValid;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (sender == txtName && IsNew)
            {
                if (string.IsNullOrWhiteSpace(txtFileName.Text) || txtFileName.Text.Equals(Mod.NameToFileName(m_strLastName)))
                    txtFileName.Text = Mod.NameToFileName(txtName.Text);
                m_strLastName = txtName.Text;
            }

            IsValid(sender);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (Object o in lstExcluded.SelectedItems)
                lstIncluded.Items.Add(o);

            for (int i = lstExcluded.Items.Count - 1; i >= 0; i--)
                if (lstExcluded.GetSelected(i))
                    lstExcluded.Items.RemoveAt(i);

            IsValid();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (object o in lstIncluded.SelectedItems)
                lstExcluded.Items.Add(o);

            for (int i = lstIncluded.Items.Count - 1; i >= 0; i--)
                if (lstIncluded.GetSelected(i))
                    lstIncluded.Items.RemoveAt(i);

            IsValid();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < lstIncluded.Items.Count; i++)
                if (lstIncluded.GetSelected(i) && !lstIncluded.GetSelected(i - 1))
                {
                    object o = lstIncluded.Items[i - 1];
                    lstIncluded.Items.RemoveAt(i - 1);
                    lstIncluded.Items.Insert(i, o);
                }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            for (int i = lstIncluded.Items.Count - 2; i >= 0; i--)
                if (lstIncluded.GetSelected(i) && !lstIncluded.GetSelected(i + 1))
                {
                    object o = lstIncluded.Items[i + 1];
                    lstIncluded.Items.RemoveAt(i + 1);
                    lstIncluded.Items.Insert(i, o);
                }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            frmModSetOptions.Display();
        }

        private void lstExcluded_DoubleClick(object sender, EventArgs e)
        {
            btnAdd.PerformClick();
        }

        private void lstIncluded_DoubleClick(object sender, EventArgs e)
        {
            btnRemove.PerformClick();
        }
    }
}
