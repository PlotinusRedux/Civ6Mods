using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using System.IO;
using SynchrotronNet;
using Civ6Mod;

namespace ModManager
{
    public partial class frmModView : Form
    {

        Mod mod;
        ModHandler Handler;

        public static void Display(ModHandler mh, Mod m)
        {
            using (var frm = new frmModView(mh, m))
                frm.ShowDialog();
        }

        public frmModView(ModHandler mh, Mod m) : this()
        {
            Handler = mh;
            mod = m;

            Text = "View Mod " + m.Title;

            tvFiles.BeginUpdate();
            foreach (ModFile mf in m.Files)
            {
                TreeNode n = new TreeNode(mf.FileNameAndRelPath);
                n.Tag = "file";
                tvFiles.Nodes.Add(n);
            }
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
                            nodeComponent.Nodes.Add(new TreeNode(kvProperty.Key + ": " + c.Properties.GetLocalized(kvProperty.Key), 3, 3));

                        foreach (ModElementFile f in c.Files)
                        {
                            var nodeFile = new TreeNode(f.FileName, 2, 2);
                            nodeFile.Tag = "file";
                            nodeComponent.Nodes.Add(nodeFile);
                            foreach (string strImplied in f.ImplicitFiles)
                            {
                                var nodeImplicit = new TreeNode(strImplied, 2, 2);
                                nodeImplicit.Tag = "file";
                                nodeComponent.Nodes.Add(nodeImplicit);
                            }
                        }
                    }
                }

            }

            tvComponents.ExpandAll();

            tvComponents.TopNode = tvComponents.Nodes[0];

            tvComponents.EndUpdate();

            ShowFile(null);
        }

        private frmModView()
        {
            InitializeComponent();

            InitScintilla(sciUnified, true);
            InitScintilla(sciFile1, false);
            InitScintilla(sciFile2, false);
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

        private void tvComponents_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (((e.Node?.Tag as string)?.Equals("file")).GetValueOrDefault())
                ShowFile(e.Node.Text);
        }

        private void ShowFile(string strFileAndRelPath)
        {
            if (string.IsNullOrEmpty(strFileAndRelPath))
            {
                lblFile.Text = "";
                if (tcFile.TabPages.IndexOf(tabDifference) > -1)
                    tcFile.TabPages.Remove(tabDifference);
            }
            else
            {
                ModFile f = mod.Files[strFileAndRelPath];
                if (f != null && File.Exists(f.FileNameAndFullPath))
                {
                    lblFile.Text = ModFileUtils.StandardizePath(f.FileNameAndFullPath);
                    string strContents = File.ReadAllText(f.FileNameAndFullPath);
                    switch (f.FileType)
                    {
                        case ModFileType.Lua:
                            sciFile.ApplyLuaStyle();
                            break;
                        case ModFileType.Sql:
                            sciFile.ApplySqlStyle();
                            break;
                        default:
                            sciFile.ApplyXmlStyle();
                            break;
                    }

                    sciFile.ReadOnly = false;
                    sciFile.Text = strContents;
                    sciFile.ReadOnly = true;

                    if (ModPaths.AssetFiles.ContainsKey(f.FileName))
                    {
                        if (tcFile.TabPages.IndexOf(tabDifference) < 0)
                        {
                            tcFile.TabPages.Add(tabDifference);
                            tcFile.SelectedTab = tabDifference;
                        }
                        ShowDiff(ModFileUtils.StandardizePath(ModPaths.AssetFiles[f.FileName].FileNameAndFullPath), ModFileUtils.StandardizePath(f.FileNameAndFullPath));
                    }
                    else if (tcFile.TabPages.IndexOf(tabDifference) > -1)
                    {
                        tcFile.SelectedTab = tabFile;
                        tcFile.TabPages.Remove(tabDifference);
                    }
                }
            }

        }


        #region FileDiff

        public string File1;
        public string File2;

        private int LastSplitLine = -1;

        public enum ViewType
        {
            Unified,
            Split
        }

        private ViewType m_eView = ViewType.Split;

        private ViewType View
        {
            get { return m_eView; }
            set
            {
                m_eView = value;
                btnUnified.Enabled = m_eView != ViewType.Unified;
                btnSplit.Enabled = m_eView != ViewType.Split;
                panUnified.Visible = m_eView == ViewType.Unified;
                splitView.Visible = m_eView == ViewType.Split;
                GetActiveView().Focus();
            }
        }

        private static class StyleIndex
        {
            public const int AddedLine = 53;
            public const int RemovedLine = 54;
            public const int ChangedLine = 55;
        }

        private static class MarkerIndex
        {
            public const int AddedLine = 1;
            public const int RemovedLine = 2;
            public const int ChangedLine = 3;
        }

        private static class MarginIndex
        {
            public const int LineNumber = 0;
            public const int Symbol = 1;
        }

        private Scintilla GetActiveView()
        {
            if (View == ViewType.Unified)
                return sciUnified;
            else if (sciFile2.Focused)
                return sciFile2;
            else
                return sciFile1;
        }

        public void ShowDiff(string strFile1, string strFile2) 
        {
            View = View;

            File1 = strFile1;
            File2 = strFile2;

            string strFile1Title = File1;
            string strFile2Title = File2;

            int i = strFile1Title.IndexOf("Base", StringComparison.OrdinalIgnoreCase);
            if (-1 < i)
                strFile1Title = strFile1Title.Substring(i);

            i = strFile2Title.IndexOf("Mods", StringComparison.OrdinalIgnoreCase);
            if (-1 < i)
                strFile2Title = strFile2Title.Substring(i);

            lblDiff.Text = "Diff between " + strFile1Title + " and " + strFile2Title;

            RefreshFiles();

            lblFile1.Text = strFile1Title;
            lblFile2.Text = strFile2Title;
        }

        private void InitScintilla(Scintilla sci, bool fIsUnified)
        {
            sci.Lexer = Lexer.Null;
            sci.Styles[Style.Default].Font = "Courier New";
            sci.StyleClearAll();

            sci.Styles[StyleIndex.AddedLine].BackColor = Color.Aqua;
            sci.Styles[StyleIndex.RemovedLine].BackColor = Color.Pink;
            sci.Styles[StyleIndex.ChangedLine].BackColor = Color.LightGreen;

            sci.Styles[Style.LineNumber].Font = "Courier New";
            sci.Margins[MarginIndex.LineNumber].Type = MarginType.Text;
            sci.Margins[MarginIndex.LineNumber].Width = (fIsUnified) ? 90 : 45;

            // Reset folder markers
            for (int i = Marker.FolderEnd; i <= Marker.FolderOpen; i++)
            {
                sci.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                sci.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            sci.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            sci.Markers[Marker.Folder].SetBackColor(SystemColors.ControlText);
            sci.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            sci.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            sci.Markers[Marker.FolderEnd].SetBackColor(SystemColors.ControlText);
            sci.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            sci.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            sci.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            sci.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            sci.Margins[MarginIndex.Symbol].Type = MarginType.Symbol;
            sci.Margins[MarginIndex.Symbol].Mask = Marker.MaskFolders;
            sci.Margins[MarginIndex.Symbol].Sensitive = true;
            sci.Margins[MarginIndex.Symbol].Width = 12;

            var markerPlusBack = sci.Markers[MarkerIndex.AddedLine];
            markerPlusBack.Symbol = MarkerSymbol.Background;
            markerPlusBack.SetBackColor(Color.Aqua);

            var markerMinusBack = sci.Markers[MarkerIndex.RemovedLine];
            markerMinusBack.Symbol = MarkerSymbol.Background;
            markerMinusBack.SetBackColor(Color.Pink);

            var markerChangedBack = sci.Markers[MarkerIndex.ChangedLine];
            markerChangedBack.Symbol = MarkerSymbol.Background;
            markerChangedBack.SetBackColor(Color.LightGreen);

            sci.CaretStyle = CaretStyle.Block;
        }

        private enum DiffType { Removed, Equal, Added, Different }

        private class DiffLine
        {
            public readonly int Line1;
            public readonly int Line2;
            public readonly string Text1;
            public readonly string Text2;
            public readonly DiffType Diff;
            public bool StartsSection;
            public bool IsEqual { get { return Diff == DiffType.Equal; } }
            public DiffLine(int iLine1, int iLine2, string strText1, string strText2)
            {
                Line1 = iLine1;
                Line2 = iLine2;
                Text1 = strText1;
                Text2 = strText2;
                StartsSection = false;
                Diff = (Line1 > -1) ? ((Line2 > -1) ? ((Text1.Equals(Text2)) ? DiffType.Equal : DiffType.Different) : DiffType.Removed) : DiffType.Added;
            }
        }

        public void RefreshFiles()
        {
            Cursor curSaved = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            LastSplitLine = -1;

            string[] s1 = File.ReadAllLines(File1);
            string[] s2 = File.ReadAllLines(File2);

            List<Diff.commonOrDifferentThing> d = Diff.diff_comm(s1, s2);

            List<DiffLine> lstLines = new List<DiffLine>();
            StringBuilder sbText = new StringBuilder();

            int iFile1Line = 1;
            int iFile2Line = 1;

            foreach (Diff.commonOrDifferentThing p in d)
            {
                if (p.common != null)
                    foreach (string strLine in p.common)
                    {
                        lstLines.Add(new DiffLine(iFile1Line, iFile2Line, strLine, strLine));
                        iFile1Line++;
                        iFile2Line++;
                        sbText.AppendLine(strLine);
                    }

                if (p.file1 != null)
                    foreach (string strLine in p.file1)
                    {
                        lstLines.Add(new DiffLine(iFile1Line, -1, strLine, ""));
                        iFile1Line++;
                        sbText.AppendLine(strLine);
                    }

                if (p.file2 != null)
                    foreach (string strLine in p.file2)
                    {
                        lstLines.Add(new DiffLine(-1, iFile2Line, "", strLine));
                        iFile2Line++;
                        sbText.AppendLine(strLine);
                    }
            }

            for (int i = 0; i < lstLines.Count - 1; i++)
                if (i == 0 || lstLines[i].Diff != lstLines[i - 1].Diff)
                    lstLines[i].StartsSection = true;

            sciUnified.ReadOnly = false;
            sciUnified.Text = sbText.ToString();
            sciUnified.ReadOnly = true;

            for (int i = 0; i < lstLines.Count; i++)
            {
                sciUnified.Lines[i].MarginText = String.Format("{0,5} {1,5}",
                    (lstLines[i].Line1 > -1) ? lstLines[i].Line1.ToString() : "+",
                    (lstLines[i].Line2 > -1) ? lstLines[i].Line2.ToString() : "-");

                switch (lstLines[i].Diff)
                {
                    case DiffType.Added:
                        sciUnified.Lines[i].MarginStyle = StyleIndex.AddedLine;
                        sciUnified.Lines[i].MarkerAdd(MarkerIndex.AddedLine);
                        break;
                    case DiffType.Removed:
                        sciUnified.Lines[i].MarginStyle = StyleIndex.RemovedLine;
                        sciUnified.Lines[i].MarkerAdd(MarkerIndex.RemovedLine);
                        break;
                }

                if (lstLines[i].StartsSection)
                {
                    sciUnified.Lines[i].FoldLevelFlags = FoldLevelFlags.Header;// | ((lstLines[i].Text1.Length == 0) ? FoldLevelFlags.White : 0);
                    sciUnified.Lines[i].FoldLevel = 0;
                    if (i + 1 < lstLines.Count && !lstLines[i + 1].StartsSection)
                        sciUnified.Lines[i].MarkerAdd(Marker.FolderOpen);
                }
                else
                {
                    sciUnified.Lines[i].FoldLevel = 1;
                    if (i + 1 == lstLines.Count || lstLines[i + 1].StartsSection)
                        sciUnified.Lines[i].MarkerAdd(Marker.FolderTail);
                    else
                        sciUnified.Lines[i].MarkerAdd(Marker.FolderSub);
                }
            }

            FoldAll(sciUnified, FoldType.Collapse, true);

            List<DiffLine> lstSplitLines = new List<DiffLine>();
            StringBuilder sbLines1 = new StringBuilder();
            StringBuilder sbLines2 = new StringBuilder();

            iFile1Line = 0;
            iFile2Line = 0;

            foreach (Diff.commonOrDifferentThing p in d)
            {
                if (p.common != null)
                    foreach (string strLine in p.common)
                    {
                        lstSplitLines.Add(new DiffLine(iFile1Line, iFile2Line, strLine, strLine));
                        iFile1Line++;
                        iFile2Line++;
                        sbLines1.AppendLine(strLine);
                        sbLines2.AppendLine(strLine);
                    }

                if (p.file1 != null || p.file2 != null)
                {
                    List<string> lstLines1 = new List<string>();
                    List<string> lstLines2 = new List<string>();

                    if (p.file1 != null)
                        lstLines1.AddRange(p.file1);

                    if (p.file2 != null)
                        lstLines2.AddRange(p.file2);

                    for (int i = 0; i < Math.Max(lstLines1.Count, lstLines2.Count); i++)
                    {
                        String strLine1;
                        String strLine2;
                        int iLine1;
                        int iLine2;

                        if (i < lstLines1.Count)
                        {
                            strLine1 = lstLines1[i];
                            iLine1 = iFile1Line;
                            iFile1Line++;
                            sbLines1.AppendLine(strLine1);
                        }
                        else
                        {
                            iLine1 = -1;
                            strLine1 = "";
                            sbLines1.AppendLine();
                        }

                        if (i < lstLines2.Count)
                        {
                            strLine2 = lstLines2[i];
                            iLine2 = iFile2Line;
                            iFile2Line++;
                            sbLines2.AppendLine(strLine2);
                        }
                        else
                        {
                            iLine2 = -1;
                            strLine2 = "";
                            sbLines2.AppendLine();
                        }

                        lstSplitLines.Add(new DiffLine(iLine1, iLine2, strLine1, strLine2));
                    }
                }

            }

            for (int i = 0; i < lstSplitLines.Count - 1; i++)
                if (i == 0 || lstSplitLines[i].Diff != lstSplitLines[i - 1].Diff)
                    lstSplitLines[i].StartsSection = true;

            sciFile1.ReadOnly = false;
            sciFile1.Text = sbLines1.ToString();
            sciFile1.ReadOnly = true;

            sciFile2.ReadOnly = false;
            sciFile2.Text = sbLines2.ToString();
            sciFile2.ReadOnly = true;

            for (int i = 0; i < lstSplitLines.Count; i++)
            {
                DiffLine dl = lstSplitLines[i];

                sciFile1.Lines[i].MarginText = String.Format("{0,5}", (dl.Line1 > -1) ? dl.Line1.ToString() : "");
                sciFile2.Lines[i].MarginText = String.Format("{0,5}", (dl.Line2 > -1) ? dl.Line2.ToString() : "");

                for (int j = 0; j < 2; j++)
                {
                    Scintilla sci = (j == 0) ? sciFile1 : sciFile2;

                    switch (dl.Diff)
                    {
                        case DiffType.Added:
                            sci.Lines[i].MarginStyle = StyleIndex.AddedLine;
                            sci.Lines[i].MarkerAdd(MarkerIndex.AddedLine);
                            break;
                        case DiffType.Removed:
                            sci.Lines[i].MarginStyle = StyleIndex.RemovedLine;
                            sci.Lines[i].MarkerAdd(MarkerIndex.RemovedLine);
                            break;
                        case DiffType.Different:
                            sci.Lines[i].MarginStyle = StyleIndex.ChangedLine;
                            sci.Lines[i].MarkerAdd(MarkerIndex.ChangedLine);
                            break;
                    }

                    if (lstSplitLines[i].StartsSection)
                    {
                        sci.Lines[i].FoldLevelFlags = FoldLevelFlags.Header;// | ((lstLines[i].Text1.Length == 0) ? FoldLevelFlags.White : 0);
                        sci.Lines[i].FoldLevel = 0;
                        if (i + 1 < lstSplitLines.Count && !lstSplitLines[i + 1].StartsSection)
                            sci.Lines[i].MarkerAdd(Marker.FolderOpen);
                    }
                    else
                    {
                        sci.Lines[i].FoldLevel = 1;
                        if (i + 1 == lstSplitLines.Count || lstSplitLines[i + 1].StartsSection)
                            sci.Lines[i].MarkerAdd(Marker.FolderTail);
                        else
                            sci.Lines[i].MarkerAdd(Marker.FolderSub);
                    }
                }
            }

            FoldAll(sciFile1, FoldType.Collapse, true);

            LastSplitLine = 0;

            Cursor.Current = curSaved;
        }

        private DiffType LineDiff(Scintilla sci, int iLine)
        {
            uint iMarkerMask = sci.Lines[iLine].MarkerGet();
            DiffType eDiffType;

            if ((iMarkerMask & (1 << MarkerIndex.AddedLine)) != 0)
                eDiffType = DiffType.Added;
            else if ((iMarkerMask & (1 << MarkerIndex.ChangedLine)) != 0)
                eDiffType = DiffType.Different;
            else if ((iMarkerMask & (1 << MarkerIndex.RemovedLine)) != 0)
                eDiffType = DiffType.Removed;
            else
                eDiffType = DiffType.Equal;

            return eDiffType;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int iLine = 0;
            Scintilla sci = GetActiveView();

            if (sender == btnNext)
            {
                iLine = sci.CurrentLine;

                DiffType eDiff = LineDiff(sci, iLine);

                for (; iLine < sci.Lines.Count && eDiff == LineDiff(sci, iLine); iLine++) ;

                for (; iLine < sci.Lines.Count && LineDiff(sci, iLine) == DiffType.Equal; iLine++) ;
            }

            if (sender != btnNext ||
                 (iLine >= sci.Lines.Count &&
                  DialogResult.Yes == MessageBox.Show("No more differences, continue from start?", "End Reached", MessageBoxButtons.YesNo)))
            {
                for (iLine = 0; iLine < sci.Lines.Count && LineDiff(sci, iLine) == DiffType.Equal; iLine++) ;
            }

            if (iLine < sci.Lines.Count)
            {
                sci.Lines[iLine].Goto();
                //sci.FirstVisibleLine = iLine;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            Scintilla sci = GetActiveView();
            int iLine = sci.CurrentLine;

            if (iLine == 0)
                sender = btnLast;

            if (sender == btnPrevious)
            {
                if (LineDiff(sci, iLine) != LineDiff(sci, iLine - 1))
                    iLine--;

                for (; iLine > -1 && LineDiff(sci, iLine) == DiffType.Equal; iLine--) ;

                if (iLine > -1)
                {
                    DiffType eDiff = LineDiff(sci, iLine);
                    for (; iLine > 0 && LineDiff(sci, iLine - 1) == eDiff; iLine--) ;
                }

            }

            if (sender != btnPrevious ||
                (iLine < 0 &&
                 DialogResult.Yes == MessageBox.Show("No more differences, continue from end?", "Start Reached", MessageBoxButtons.YesNo)))
            {
                for (iLine = sci.Lines.Count - 1; iLine > -1 && LineDiff(sci, iLine) == DiffType.Equal; iLine--) ;

                for (; iLine > 0 && LineDiff(sci, iLine - 1) != DiffType.Equal; iLine--) ;
            }

            if (iLine >= 0)
            {
                sci.Lines[iLine].Goto();
            }
        }

        private void frmFileDiff_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnNext.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F3:
                    btnPrevious.PerformClick();
                    e.Handled = true;
                    break;
            }
        }

        private void btnUnified_Click(object sender, EventArgs e)
        {
            if (sender == btnUnified)
                View = ViewType.Unified;
            else
                View = ViewType.Split;
        }

        private void sciFile1_Painted(object sender, EventArgs e)
        {
            if (sciFile1.FirstVisibleLine != LastSplitLine)
            {
                LastSplitLine = sciFile1.FirstVisibleLine;
                sciFile2.FirstVisibleLine = LastSplitLine;
            }
            else if (sciFile2.FirstVisibleLine != LastSplitLine)
            {
                LastSplitLine = sciFile2.FirstVisibleLine;
                sciFile1.FirstVisibleLine = LastSplitLine;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshFiles();
        }

        private enum FoldType { None, Collapse, Expand, Toggle }

        private void FoldAll(Scintilla sci, FoldType eFoldType, bool fOnlyEqual)
        {
            for (int iLine = 0; iLine < sci.Lines.Count; iLine++)
            {
                if (((sci.Lines[iLine].FoldLevelFlags & FoldLevelFlags.Header) != 0) && (!fOnlyEqual || LineDiff(sci, iLine) == DiffType.Equal))
                    FoldLine(sci, iLine, eFoldType, false);
            }

            if (eFoldType == FoldType.Expand)
                sci.Lines[sci.CurrentLine].Goto();
            else
                sci.Lines[0].Goto();
        }

        private void FoldLine(Scintilla sci, int iLine, FoldType eFoldType, bool fChangeLine = true)
        {
            const uint iFolderOpenMask = (1U << Marker.FolderOpen);
            const uint iFolderMask = (1U << Marker.Folder);

            if (iLine > 0 && ((sci.Lines[iLine].FoldLevelFlags & FoldLevelFlags.Header) == 0))
                iLine = sci.Lines[iLine].FoldParent;

            bool fFolded;

            if ((sci.Lines[iLine].MarkerGet() & iFolderOpenMask) != 0)
                fFolded = false;
            else if ((sci.Lines[iLine].MarkerGet() & iFolderMask) != 0)
                fFolded = true;
            else
                return;

            bool fFold = (eFoldType == FoldType.Collapse) ? true : (eFoldType == FoldType.Expand) ? false : !fFolded;

            if (fFold != fFolded)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (fFold)
                    {
                        sci.Lines[iLine].FoldChildren(FoldAction.Contract);
                        sci.Lines[iLine].MarkerDelete(Marker.FolderOpen);
                        sci.Lines[iLine].MarkerAdd(Marker.Folder);
                    }
                    else
                    {
                        sci.Lines[iLine].FoldChildren(FoldAction.Expand);
                        sci.Lines[iLine].MarkerDelete(Marker.Folder);
                        sci.Lines[iLine].MarkerAdd(Marker.FolderOpen);
                    }

                    if (sci == sciFile1)
                        sci = sciFile2;
                    else if (sci == sciFile2)
                        sci = sciFile1;
                    else
                        break;
                }

                if (fChangeLine)
                    sci.Lines[iLine].Goto();
            }
        }

        private void sciUnified_MarginClick(object sender, MarginClickEventArgs e)
        {
            Scintilla sci = (sender as Scintilla);

            FoldLine(sci, sci.LineFromPosition(e.Position), FoldType.Toggle);
        }

        private void btnCollpaseAll_Click(object sender, EventArgs e)
        {
            Scintilla sci = GetActiveView();

            if (sender == btnCollpaseAll)
                FoldAll(sci, FoldType.Collapse, false);
            else if (sender == btnExpandAll)
                FoldAll(sci, FoldType.Expand, false);
            else if (sender == btnCollapse)
                FoldLine(sci, sci.CurrentLine, FoldType.Collapse);
            else if (sender == btnExpand)
                FoldLine(sci, sci.CurrentLine, FoldType.Expand);
        }

        #endregion


    }
}
