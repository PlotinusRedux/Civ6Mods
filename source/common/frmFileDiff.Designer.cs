namespace FileDiffWindow
{
    partial class frmFileDiff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileDiff));
            this.panUnified = new System.Windows.Forms.Panel();
            this.sciUnified = new ScintillaNET.Scintilla();
            this.splitView = new System.Windows.Forms.SplitContainer();
            this.lblFile1 = new System.Windows.Forms.Label();
            this.sciFile1 = new ScintillaNET.Scintilla();
            this.lblFile2 = new System.Windows.Forms.Label();
            this.sciFile2 = new ScintillaNET.Scintilla();
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
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnCollpaseAll = new System.Windows.Forms.ToolStripButton();
            this.btnCollapse = new System.Windows.Forms.ToolStripButton();
            this.btnExpand = new System.Windows.Forms.ToolStripButton();
            this.btnExpandAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.panUnified.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitView)).BeginInit();
            this.splitView.Panel1.SuspendLayout();
            this.splitView.Panel2.SuspendLayout();
            this.splitView.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panUnified
            // 
            this.panUnified.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panUnified.Controls.Add(this.sciUnified);
            this.panUnified.Location = new System.Drawing.Point(12, 28);
            this.panUnified.Name = "panUnified";
            this.panUnified.Size = new System.Drawing.Size(1323, 627);
            this.panUnified.TabIndex = 2;
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
            this.sciUnified.Location = new System.Drawing.Point(3, 3);
            this.sciUnified.Name = "sciUnified";
            this.sciUnified.ReadOnly = true;
            this.sciUnified.Size = new System.Drawing.Size(1317, 621);
            this.sciUnified.TabIndex = 1;
            this.sciUnified.TabWidth = 2;
            this.sciUnified.MarginClick += new System.EventHandler<ScintillaNET.MarginClickEventArgs>(this.sciUnified_MarginClick);
            // 
            // splitView
            // 
            this.splitView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitView.Location = new System.Drawing.Point(12, 28);
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
            this.splitView.Size = new System.Drawing.Size(1323, 627);
            this.splitView.SplitterDistance = 661;
            this.splitView.TabIndex = 2;
            // 
            // lblFile1
            // 
            this.lblFile1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFile1.Location = new System.Drawing.Point(0, 0);
            this.lblFile1.Name = "lblFile1";
            this.lblFile1.Size = new System.Drawing.Size(658, 23);
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
            this.sciFile1.Location = new System.Drawing.Point(0, 26);
            this.sciFile1.Name = "sciFile1";
            this.sciFile1.ReadOnly = true;
            this.sciFile1.Size = new System.Drawing.Size(658, 598);
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
            this.lblFile2.Size = new System.Drawing.Size(655, 23);
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
            this.sciFile2.Location = new System.Drawing.Point(0, 26);
            this.sciFile2.Name = "sciFile2";
            this.sciFile2.ReadOnly = true;
            this.sciFile2.Size = new System.Drawing.Size(653, 598);
            this.sciFile2.TabIndex = 5;
            this.sciFile2.TabWidth = 2;
            this.sciFile2.MarginClick += new System.EventHandler<ScintillaNET.MarginClickEventArgs>(this.sciUnified_MarginClick);
            this.sciFile2.Painted += new System.EventHandler<System.EventArgs>(this.sciFile1_Painted);
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
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1347, 25);
            this.tsMain.TabIndex = 7;
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
            this.btnFirst.Click += new System.EventHandler(this.btnNext_Click);
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
            this.btnLast.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 22);
            this.btnSearch.Text = "Search";
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
            // 
            // frmFileDiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 667);
            this.Controls.Add(this.splitView);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.panUnified);
            this.KeyPreview = true;
            this.Name = "frmFileDiff";
            this.Text = "File Difference";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFileDiff_KeyDown);
            this.panUnified.ResumeLayout(false);
            this.splitView.Panel1.ResumeLayout(false);
            this.splitView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitView)).EndInit();
            this.splitView.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panUnified;
        private ScintillaNET.Scintilla sciUnified;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnPrevious;
        private System.Windows.Forms.ToolStripButton btnFirst;
        private System.Windows.Forms.ToolStripButton btnLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnUnified;
        private System.Windows.Forms.ToolStripButton btnSplit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.SplitContainer splitView;
        private System.Windows.Forms.Label lblFile1;
        private ScintillaNET.Scintilla sciFile1;
        private System.Windows.Forms.Label lblFile2;
        private ScintillaNET.Scintilla sciFile2;
        private System.Windows.Forms.ToolStripButton btnCollpaseAll;
        private System.Windows.Forms.ToolStripButton btnCollapse;
        private System.Windows.Forms.ToolStripButton btnExpand;
        private System.Windows.Forms.ToolStripButton btnExpandAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

