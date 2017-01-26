namespace ModManager
{
    partial class frmModView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModView));
            this.imgComponents = new System.Windows.Forms.ImageList(this.components);
            this.tvComponents = new System.Windows.Forms.TreeView();
            this.tvFiles = new System.Windows.Forms.TreeView();
            this.tcOverview = new System.Windows.Forms.TabControl();
            this.tabComponents = new System.Windows.Forms.TabPage();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.spltMain = new System.Windows.Forms.SplitContainer();
            this.tcFile = new System.Windows.Forms.TabControl();
            this.tabFile = new System.Windows.Forms.TabPage();
            this.sciFile = new ScintillaNET.Scintilla();
            this.lblFile = new System.Windows.Forms.Label();
            this.tabDifference = new System.Windows.Forms.TabPage();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUnified = new System.Windows.Forms.ToolStripButton();
            this.btnSplit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCollpaseAll = new System.Windows.Forms.ToolStripButton();
            this.btnCollapse = new System.Windows.Forms.ToolStripButton();
            this.btnExpand = new System.Windows.Forms.ToolStripButton();
            this.btnExpandAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.splitView = new System.Windows.Forms.SplitContainer();
            this.lblFile1 = new System.Windows.Forms.Label();
            this.sciFile1 = new ScintillaNET.Scintilla();
            this.lblFile2 = new System.Windows.Forms.Label();
            this.sciFile2 = new ScintillaNET.Scintilla();
            this.panUnified = new System.Windows.Forms.Panel();
            this.lblDiff = new System.Windows.Forms.Label();
            this.sciUnified = new ScintillaNET.Scintilla();
            this.tcOverview.SuspendLayout();
            this.tabComponents.SuspendLayout();
            this.tabFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).BeginInit();
            this.spltMain.Panel1.SuspendLayout();
            this.spltMain.Panel2.SuspendLayout();
            this.spltMain.SuspendLayout();
            this.tcFile.SuspendLayout();
            this.tabFile.SuspendLayout();
            this.tabDifference.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitView)).BeginInit();
            this.splitView.Panel1.SuspendLayout();
            this.splitView.Panel2.SuspendLayout();
            this.splitView.SuspendLayout();
            this.panUnified.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgComponents
            // 
            this.imgComponents.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgComponents.ImageStream")));
            this.imgComponents.TransparentColor = System.Drawing.Color.Transparent;
            this.imgComponents.Images.SetKeyName(0, "Folder.ico");
            this.imgComponents.Images.SetKeyName(1, "FolderOpen.ico");
            this.imgComponents.Images.SetKeyName(2, "Document.ico");
            this.imgComponents.Images.SetKeyName(3, "Property.ico");
            // 
            // tvComponents
            // 
            this.tvComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvComponents.ImageIndex = 0;
            this.tvComponents.ImageList = this.imgComponents;
            this.tvComponents.Location = new System.Drawing.Point(3, 3);
            this.tvComponents.Name = "tvComponents";
            this.tvComponents.SelectedImageIndex = 0;
            this.tvComponents.ShowPlusMinus = false;
            this.tvComponents.ShowRootLines = false;
            this.tvComponents.Size = new System.Drawing.Size(273, 647);
            this.tvComponents.StateImageList = this.imgComponents;
            this.tvComponents.TabIndex = 8;
            this.tvComponents.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvComponents_AfterCollapse);
            this.tvComponents.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvComponents_AfterExpand);
            this.tvComponents.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvComponents_NodeMouseClick);
            // 
            // tvFiles
            // 
            this.tvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFiles.ImageIndex = 2;
            this.tvFiles.ImageList = this.imgComponents;
            this.tvFiles.Location = new System.Drawing.Point(3, 3);
            this.tvFiles.Name = "tvFiles";
            this.tvFiles.SelectedImageIndex = 2;
            this.tvFiles.ShowPlusMinus = false;
            this.tvFiles.ShowRootLines = false;
            this.tvFiles.Size = new System.Drawing.Size(273, 647);
            this.tvFiles.StateImageList = this.imgComponents;
            this.tvFiles.TabIndex = 10;
            this.tvFiles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvComponents_NodeMouseClick);
            // 
            // tcOverview
            // 
            this.tcOverview.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tcOverview.Controls.Add(this.tabComponents);
            this.tcOverview.Controls.Add(this.tabFiles);
            this.tcOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcOverview.Location = new System.Drawing.Point(0, 0);
            this.tcOverview.Name = "tcOverview";
            this.tcOverview.SelectedIndex = 0;
            this.tcOverview.Size = new System.Drawing.Size(287, 679);
            this.tcOverview.TabIndex = 12;
            // 
            // tabComponents
            // 
            this.tabComponents.Controls.Add(this.tvComponents);
            this.tabComponents.Location = new System.Drawing.Point(4, 4);
            this.tabComponents.Name = "tabComponents";
            this.tabComponents.Padding = new System.Windows.Forms.Padding(3);
            this.tabComponents.Size = new System.Drawing.Size(279, 653);
            this.tabComponents.TabIndex = 0;
            this.tabComponents.Text = "Components";
            this.tabComponents.UseVisualStyleBackColor = true;
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add(this.tvFiles);
            this.tabFiles.Location = new System.Drawing.Point(4, 4);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiles.Size = new System.Drawing.Size(279, 653);
            this.tabFiles.TabIndex = 1;
            this.tabFiles.Text = "Files";
            this.tabFiles.UseVisualStyleBackColor = true;
            // 
            // spltMain
            // 
            this.spltMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltMain.Location = new System.Drawing.Point(0, 0);
            this.spltMain.Name = "spltMain";
            // 
            // spltMain.Panel1
            // 
            this.spltMain.Panel1.Controls.Add(this.tcOverview);
            this.spltMain.Panel1MinSize = 200;
            // 
            // spltMain.Panel2
            // 
            this.spltMain.Panel2.Controls.Add(this.tcFile);
            this.spltMain.Panel2MinSize = 800;
            this.spltMain.Size = new System.Drawing.Size(1334, 679);
            this.spltMain.SplitterDistance = 287;
            this.spltMain.TabIndex = 13;
            // 
            // tcFile
            // 
            this.tcFile.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tcFile.Controls.Add(this.tabFile);
            this.tcFile.Controls.Add(this.tabDifference);
            this.tcFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcFile.Location = new System.Drawing.Point(0, 0);
            this.tcFile.Name = "tcFile";
            this.tcFile.SelectedIndex = 0;
            this.tcFile.Size = new System.Drawing.Size(1043, 679);
            this.tcFile.TabIndex = 0;
            // 
            // tabFile
            // 
            this.tabFile.Controls.Add(this.sciFile);
            this.tabFile.Controls.Add(this.lblFile);
            this.tabFile.Location = new System.Drawing.Point(4, 4);
            this.tabFile.Name = "tabFile";
            this.tabFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabFile.Size = new System.Drawing.Size(1035, 653);
            this.tabFile.TabIndex = 0;
            this.tabFile.Text = "File View";
            this.tabFile.UseVisualStyleBackColor = true;
            // 
            // sciFile
            // 
            this.sciFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sciFile.IdleStyling = ScintillaNET.IdleStyling.All;
            this.sciFile.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.sciFile.IndentWidth = 2;
            this.sciFile.Lexer = ScintillaNET.Lexer.Null;
            this.sciFile.Location = new System.Drawing.Point(0, 27);
            this.sciFile.Name = "sciFile";
            this.sciFile.ReadOnly = true;
            this.sciFile.Size = new System.Drawing.Size(1033, 626);
            this.sciFile.TabIndex = 6;
            this.sciFile.TabWidth = 2;
            // 
            // lblFile
            // 
            this.lblFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFile.Location = new System.Drawing.Point(0, 0);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(1033, 23);
            this.lblFile.TabIndex = 5;
            this.lblFile.Text = "File 1";
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabDifference
            // 
            this.tabDifference.Controls.Add(this.tsMain);
            this.tabDifference.Controls.Add(this.splitView);
            this.tabDifference.Controls.Add(this.panUnified);
            this.tabDifference.Location = new System.Drawing.Point(4, 4);
            this.tabDifference.Name = "tabDifference";
            this.tabDifference.Padding = new System.Windows.Forms.Padding(3);
            this.tabDifference.Size = new System.Drawing.Size(1035, 653);
            this.tabDifference.TabIndex = 1;
            this.tabDifference.Text = "Difference View";
            this.tabDifference.UseVisualStyleBackColor = true;
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnUnified,
            this.btnSplit,
            this.toolStripSeparator2,
            this.btnFirst,
            this.btnPrevious,
            this.btnNext,
            this.btnLast,
            this.toolStripSeparator3,
            this.btnCollpaseAll,
            this.btnCollapse,
            this.btnExpand,
            this.btnExpandAll,
            this.toolStripSeparator4,
            this.btnSearch});
            this.tsMain.Location = new System.Drawing.Point(3, 3);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1029, 25);
            this.tsMain.TabIndex = 10;
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUnified
            // 
            this.btnUnified.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnified.Image = ((System.Drawing.Image)(resources.GetObject("btnUnified.Image")));
            this.btnUnified.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnified.Name = "btnUnified";
            this.btnUnified.Size = new System.Drawing.Size(23, 22);
            this.btnUnified.Text = "Unified view";
            this.btnUnified.ToolTipText = "Unified view";
            this.btnUnified.Click += new System.EventHandler(this.btnUnified_Click);
            // 
            // btnSplit
            // 
            this.btnSplit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSplit.Image = ((System.Drawing.Image)(resources.GetObject("btnSplit.Image")));
            this.btnSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(23, 22);
            this.btnSplit.Text = "Split view";
            this.btnSplit.ToolTipText = "Split view";
            this.btnSplit.Click += new System.EventHandler(this.btnUnified_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFirst
            // 
            this.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(23, 22);
            this.btnFirst.Text = "First difference";
            this.btnFirst.ToolTipText = "First difference";
            this.btnFirst.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(23, 22);
            this.btnPrevious.Text = "Previous difference <F3>";
            this.btnPrevious.ToolTipText = "Previous difference";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 22);
            this.btnNext.Text = "Next difference";
            this.btnNext.ToolTipText = "Next difference <F2>";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
            this.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(23, 22);
            this.btnLast.Text = "Last difference";
            this.btnLast.ToolTipText = "Last difference";
            this.btnLast.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCollpaseAll
            // 
            this.btnCollpaseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCollpaseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCollpaseAll.Image")));
            this.btnCollpaseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCollpaseAll.Name = "btnCollpaseAll";
            this.btnCollpaseAll.Size = new System.Drawing.Size(23, 22);
            this.btnCollpaseAll.Text = "Collapse All";
            this.btnCollpaseAll.Click += new System.EventHandler(this.btnCollpaseAll_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(23, 22);
            this.btnCollapse.Text = "Collapse";
            this.btnCollapse.Click += new System.EventHandler(this.btnCollpaseAll_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(23, 22);
            this.btnExpand.Text = "Expand";
            this.btnExpand.Click += new System.EventHandler(this.btnCollpaseAll_Click);
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("btnExpandAll.Image")));
            this.btnExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(23, 22);
            this.btnExpandAll.Text = "Expand All";
            this.btnExpandAll.Click += new System.EventHandler(this.btnCollpaseAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator4.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 22);
            this.btnSearch.Text = "Search";
            this.btnSearch.Visible = false;
            // 
            // splitView
            // 
            this.splitView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitView.Location = new System.Drawing.Point(0, 25);
            this.splitView.Name = "splitView";
            // 
            // splitView.Panel1
            // 
            this.splitView.Panel1.Controls.Add(this.lblFile1);
            this.splitView.Panel1.Controls.Add(this.sciFile1);
            // 
            // splitView.Panel2
            // 
            this.splitView.Panel2.Controls.Add(this.lblFile2);
            this.splitView.Panel2.Controls.Add(this.sciFile2);
            this.splitView.Size = new System.Drawing.Size(1035, 627);
            this.splitView.SplitterDistance = 516;
            this.splitView.TabIndex = 8;
            // 
            // lblFile1
            // 
            this.lblFile1.Location = new System.Drawing.Point(0, 0);
            this.lblFile1.Name = "lblFile1";
            this.lblFile1.Size = new System.Drawing.Size(513, 23);
            this.lblFile1.TabIndex = 4;
            this.lblFile1.Text = "File 1";
            this.lblFile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sciFile1
            // 
            this.sciFile1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sciFile1.IdleStyling = ScintillaNET.IdleStyling.All;
            this.sciFile1.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.sciFile1.IndentWidth = 2;
            this.sciFile1.Lexer = ScintillaNET.Lexer.Null;
            this.sciFile1.Location = new System.Drawing.Point(0, 29);
            this.sciFile1.Name = "sciFile1";
            this.sciFile1.ReadOnly = true;
            this.sciFile1.Size = new System.Drawing.Size(513, 598);
            this.sciFile1.TabIndex = 3;
            this.sciFile1.TabWidth = 2;
            this.sciFile1.MarginClick += new System.EventHandler<ScintillaNET.MarginClickEventArgs>(this.sciUnified_MarginClick);
            this.sciFile1.Painted += new System.EventHandler<System.EventArgs>(this.sciFile1_Painted);
            // 
            // lblFile2
            // 
            this.lblFile2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFile2.Location = new System.Drawing.Point(0, 0);
            this.lblFile2.Name = "lblFile2";
            this.lblFile2.Size = new System.Drawing.Size(512, 23);
            this.lblFile2.TabIndex = 6;
            this.lblFile2.Text = "File 2";
            this.lblFile2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sciFile2
            // 
            this.sciFile2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sciFile2.IdleStyling = ScintillaNET.IdleStyling.All;
            this.sciFile2.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.sciFile2.IndentWidth = 2;
            this.sciFile2.Lexer = ScintillaNET.Lexer.Null;
            this.sciFile2.Location = new System.Drawing.Point(0, 29);
            this.sciFile2.Name = "sciFile2";
            this.sciFile2.ReadOnly = true;
            this.sciFile2.Size = new System.Drawing.Size(510, 598);
            this.sciFile2.TabIndex = 5;
            this.sciFile2.TabWidth = 2;
            this.sciFile2.MarginClick += new System.EventHandler<ScintillaNET.MarginClickEventArgs>(this.sciUnified_MarginClick);
            this.sciFile2.Painted += new System.EventHandler<System.EventArgs>(this.sciFile1_Painted);
            // 
            // panUnified
            // 
            this.panUnified.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panUnified.Controls.Add(this.lblDiff);
            this.panUnified.Controls.Add(this.sciUnified);
            this.panUnified.Location = new System.Drawing.Point(0, 25);
            this.panUnified.Name = "panUnified";
            this.panUnified.Size = new System.Drawing.Size(1035, 627);
            this.panUnified.TabIndex = 9;
            // 
            // lblDiff
            // 
            this.lblDiff.Location = new System.Drawing.Point(3, 3);
            this.lblDiff.Name = "lblDiff";
            this.lblDiff.Size = new System.Drawing.Size(1029, 23);
            this.lblDiff.TabIndex = 5;
            this.lblDiff.Text = "File 1";
            this.lblDiff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sciUnified
            // 
            this.sciUnified.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sciUnified.IdleStyling = ScintillaNET.IdleStyling.All;
            this.sciUnified.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.sciUnified.IndentWidth = 2;
            this.sciUnified.Lexer = ScintillaNET.Lexer.Null;
            this.sciUnified.Location = new System.Drawing.Point(3, 29);
            this.sciUnified.Name = "sciUnified";
            this.sciUnified.ReadOnly = true;
            this.sciUnified.Size = new System.Drawing.Size(1029, 595);
            this.sciUnified.TabIndex = 1;
            this.sciUnified.TabWidth = 2;
            this.sciUnified.MarginClick += new System.EventHandler<ScintillaNET.MarginClickEventArgs>(this.sciUnified_MarginClick);
            // 
            // frmModView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 679);
            this.Controls.Add(this.spltMain);
            this.Name = "frmModView";
            this.Text = "Mod View";
            this.tcOverview.ResumeLayout(false);
            this.tabComponents.ResumeLayout(false);
            this.tabFiles.ResumeLayout(false);
            this.spltMain.Panel1.ResumeLayout(false);
            this.spltMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).EndInit();
            this.spltMain.ResumeLayout(false);
            this.tcFile.ResumeLayout(false);
            this.tabFile.ResumeLayout(false);
            this.tabDifference.ResumeLayout(false);
            this.tabDifference.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.splitView.Panel1.ResumeLayout(false);
            this.splitView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitView)).EndInit();
            this.splitView.ResumeLayout(false);
            this.panUnified.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgComponents;
        private System.Windows.Forms.TreeView tvComponents;
        private System.Windows.Forms.TreeView tvFiles;
        private System.Windows.Forms.TabControl tcOverview;
        private System.Windows.Forms.TabPage tabComponents;
        private System.Windows.Forms.TabPage tabFiles;
        private System.Windows.Forms.SplitContainer spltMain;
        private System.Windows.Forms.TabControl tcFile;
        private System.Windows.Forms.TabPage tabFile;
        private System.Windows.Forms.TabPage tabDifference;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnUnified;
        private System.Windows.Forms.ToolStripButton btnSplit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnFirst;
        private System.Windows.Forms.ToolStripButton btnPrevious;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCollpaseAll;
        private System.Windows.Forms.ToolStripButton btnCollapse;
        private System.Windows.Forms.ToolStripButton btnExpand;
        private System.Windows.Forms.ToolStripButton btnExpandAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.SplitContainer splitView;
        private System.Windows.Forms.Label lblFile1;
        private ScintillaNET.Scintilla sciFile1;
        private System.Windows.Forms.Label lblFile2;
        private ScintillaNET.Scintilla sciFile2;
        private System.Windows.Forms.Panel panUnified;
        private ScintillaNET.Scintilla sciUnified;
        private ScintillaNET.Scintilla sciFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblDiff;
    }
}