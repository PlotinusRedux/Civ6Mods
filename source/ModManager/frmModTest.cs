using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLite;
using Civ6Mod;
using FileDiffWindow;
using System.IO;
using SynchrotronNet;
using System.Threading;

namespace ModManager
{
    public partial class ModTestWindow : Form
    {
        Civ6Mod.ModHandler mm = new Civ6Mod.ModHandler();

        public ModTestWindow()
        {
            InitializeComponent();
        }

        private class SQLModInfo
        {
            public int ModRowId { get; set; }
            public string ModId { get; set; }
            public bool Enabled { get; set; }
            public string Path { get; set; }
            public string ModName { get; set; }
            public override string ToString()
            {
                return string.Format( "Row: {0} ModId: {1} Enabled: {2} Path: {3} ModName: {4}", ModRowId, ModId, Enabled, Path, ModName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SQLiteConnection con = new SQLiteConnection(@"C:\Users\jaydb\Documents\My Games\Sid Meier's Civilization VI\Mods.sqlite");
            //con.Execute( "INSERT INTO SettingProperties (SettingRowID, Name, Value) VALUES (52, \"Test\", \"1\")" );
            List<SQLModInfo> lst = con.Query<SQLModInfo>(
                    "SELECT m.ModRowId, ModId, Enabled, Path, COALESCE(Text, Value, ModId) AS ModName " +
                    "FROM Mods m " +
                    "INNER JOIN ScannedFiles f on m.ScannedFileRowId = f.ScannedFileRowID " +
                    "LEFT OUTER JOIN ModProperties p ON p.ModRowId = m.ModRowId AND p.Name = 'Name' " +
                    "LEFT OUTER JOIN LocalizedText t ON t.ModRowId = p.ModRowId AND t.Tag = p.Value and t.Locale = 'en_US' " +
                    "LIMIT 3");

            foreach (SQLModInfo mi in lst)
                MessageBox.Show(mi.ToString());


            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModPaths.AssignPaths();

            mm.LoadMods();

            grdMods.SuspendLayout();

            foreach (Mod m in mm.Mods.Values)
            {
                int i = grdMods.Rows.Add();
                grdMods.Rows[i].Cells["colModName"].Value = m.Title;
                grdMods.Rows[i].Cells["colID"].Value = m.Id;
                grdMods.Rows[i].Cells["colVersion"].Value = m.Version.ToString();
                grdMods.Rows[i].Cells["colAuthor"].Value = m.Properties.GetLocalized(ModPropertyType.Authors);
                grdMods.Rows[i].Cells["colTeaser"].Value = m.Properties.GetLocalized(ModPropertyType.Teaser);
            }

            grdMods.ResumeLayout();
        }

        private void grdMods_SelectionChanged(object sender, EventArgs e)
        {
            tvFiles.Nodes.Clear();
            tvComponents.Nodes.Clear();

            if (grdMods.SelectedRows.Count > 0 && grdMods.SelectedRows[0].Cells["colID"].Value != null)
            {
                Mod m = mm.Mods[grdMods.SelectedRows[0].Cells["colID"].Value.ToString()];
                
                tvFiles.BeginUpdate();
                foreach(ModFile mf in m.Files)
                    tvFiles.Nodes.Add(mf.FileNameAndRelPath);
                if (tvFiles.Nodes.Count > 0)
                    tvFiles.TopNode = tvFiles.Nodes[0];
                tvFiles.EndUpdate();
                
                tvComponents.BeginUpdate();

                var nodeProperties = new TreeNode("Properties", 1, 1);
                tvComponents.Nodes.Add(nodeProperties);
                
                foreach (KeyValuePair<string, string> kvProperty in m.Properties.Items)
                    nodeProperties.Nodes.Add(new TreeNode(kvProperty.Key + ": " + m.Properties.GetLocalized(kvProperty.Key), 3, 3));


                foreach (var oContainer in m.Containers)
                {
                    if (oContainer.Elements.Count > 0)
                    {
                        var nodeSettings = new TreeNode(oContainer.ContainerName, 1, 1);
                        tvComponents.Nodes.Add(nodeSettings);

                        foreach (ModElement c in oContainer.Elements)
                        {
                            var nodeComponent = new TreeNode(c.GetDescription(), 1, 1);
                            nodeSettings.Nodes.Add(nodeComponent);

                            foreach (KeyValuePair<string, string> kvProperty in c.Properties.Items)
                                nodeComponent.Nodes.Add(new TreeNode(kvProperty.Key + ": " + c.Properties.GetLocalized(kvProperty.Value), 3, 3));

                            foreach (ModElementFile f in c.Files)
                            {
                                var nodeFile = new TreeNode(f.FileName, 2, 2);
                                nodeComponent.Nodes.Add(nodeFile);
                                foreach (string strImplied in f.ImplicitFiles)
                                    nodeComponent.Nodes.Add(new TreeNode(strImplied, 2, 2));
                            }
                        }
                    }

                }

                tvComponents.ExpandAll();

                tvComponents.TopNode = tvComponents.Nodes[0];

                tvComponents.EndUpdate();

            }
        }

        private void grdMods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tvComponents_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;
        }

        private void tvComponents_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmFileDiff(@"C:\Steam\steamapps\common\Sid Meier's Civilization VI\Base\Assets\UI\DiplomacyActionView.xml", @"C:\Users\jaydb\Documents\My Games\Sid Meier's Civilization VI\Mods\Show Diplomatic Deals\UI\DiplomacyActionView.xml");
        }

        private void MergeFiles(string strOFileName, string strAFileName, string strBFileName, string strOutFileName)
        {
            string[] astrO = File.ReadAllLines(strOFileName);
            string[] astrA = File.ReadAllLines(strAFileName);
            string[] astrB = File.ReadAllLines(strBFileName);

            List<Diff.IMergeResultBlock> merged = Diff.diff3_merge(astrA, astrO, astrB, true);
            List<string> lstOut = new List<string>();


            foreach (Diff.IMergeResultBlock block in merged)
            {
                if (block is Diff.MergeOKResultBlock)
                {
                    lstOut.AddRange((block as Diff.MergeOKResultBlock).ContentLines);
                    Diff.MergeOKResultBlock ok = (block as Diff.MergeOKResultBlock);
                }
                else if (block is Diff.MergeConflictResultBlock)
                {
                    Diff.MergeConflictResultBlock conflicts = (block as Diff.MergeConflictResultBlock);
                    MessageBox.Show("Conflicts");
                }

            }

            File.WriteAllLines(strOutFileName, lstOut.ToArray());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MergeFiles(@"C:\Steam\steamapps\common\Sid Meier's Civilization VI\Base\Assets\UI\DiplomacyActionView.xml",
                @"C:\Users\jaydb\Documents\My Games\Sid Meier's Civilization VI\Mods\Show Diplomatic Deals\UI\DiplomacyActionView.xml",
                @"C:\Users\jaydb\Documents\My Games\Sid Meier's Civilization VI\Mods\Diplomatic Total 20161202\UI\DiplomacyActionView.xml",
                @"F:\temp\DiplomacyActionView.xml");

            new frmFileDiff(@"C:\Steam\steamapps\common\Sid Meier's Civilization VI\Base\Assets\UI\DiplomacyActionView.xml", @"F:\temp\DiplomacyActionView.xml");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mod m = new Mod(ModPaths.ModsPath, "testmerge", "testmerge.modinfo", true);
            m.Id = "testmerge";

            var m1 = new ModChildRef();
            m1.Id = "54d473dc-7810-4576-a4ce-cb5eda23a5f4";
            m1.Title = "Show Diplomatic Deals";
            m1.mod = mm.Mods[m1.Id];
            m.ModSet.ChildModRefs.Add(m1);

            var m2 = new ModChildRef();
            m2.Id = "Diplomatic_Total_kavisgo";
            m2.Title = "Diplomatic Total";
            m2.mod = mm.Mods[m2.Id];
            m.ModSet.ChildModRefs.Add(m2);

            Thread t = new Thread(() => m.BuildModSet(mm));
            try
            {
                t.Start();
                while (t.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(50);
                }
            }
            finally
            {
                if (t.IsAlive)
                    t.Abort();
            }

            MessageBox.Show("Done.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var frm = new frmFileDiff(@"C:\Steam\steamapps\common\Sid Meier's Civilization VI\Base\Assets\UI\DiplomacyActionView.xml", @"C:\Users\jaydb\Documents\My Games\Sid Meier's Civilization VI\Mods\Show Diplomatic Deals\UI\DiplomacyActionView.xml");
            frm.Visible = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            this.IsMdiContainer = true;
            frm.MdiParent = this;
            frm.Parent = panel1;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
