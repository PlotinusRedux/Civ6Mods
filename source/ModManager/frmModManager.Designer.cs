namespace ModManager
{
    partial class frmModManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModManager));
            this.grdMods = new System.Windows.Forms.DataGridView();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colModName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeaser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewModSet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstallMod = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditMod = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteMod = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEnableAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDisableAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHideAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsContainer = new System.Windows.Forms.ToolStripContainer();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tbNewModSet = new System.Windows.Forms.ToolStripButton();
            this.tbEditModSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbViewMod = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbShowAll = new System.Windows.Forms.ToolStripButton();
            this.tbHideAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbEnableAll = new System.Windows.Forms.ToolStripButton();
            this.tbDisableAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbHelp = new System.Windows.Forms.ToolStripButton();
            this.dlgOpenFolder = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grdMods)).BeginInit();
            this.msMain.SuspendLayout();
            this.tsContainer.ContentPanel.SuspendLayout();
            this.tsContainer.TopToolStripPanel.SuspendLayout();
            this.tsContainer.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdMods
            // 
            this.grdMods.AllowUserToAddRows = false;
            this.grdMods.AllowUserToDeleteRows = false;
            this.grdMods.AllowUserToResizeRows = false;
            this.grdMods.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdMods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEnabled,
            this.colVisible,
            this.colModName,
            this.colID,
            this.colVersion,
            this.colAuthor,
            this.colTeaser});
            this.grdMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMods.Location = new System.Drawing.Point(0, 0);
            this.grdMods.MultiSelect = false;
            this.grdMods.Name = "grdMods";
            this.grdMods.RowHeadersVisible = false;
            this.grdMods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMods.Size = new System.Drawing.Size(1174, 403);
            this.grdMods.TabIndex = 3;
            this.grdMods.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMods_CellContentClick);
            this.grdMods.SelectionChanged += new System.EventHandler(this.grdMods_SelectionChanged);
            this.grdMods.DoubleClick += new System.EventHandler(this.grdMods_DoubleClick);
            // 
            // colEnabled
            // 
            this.colEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colEnabled.HeaderText = "Enabled";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEnabled.Width = 71;
            // 
            // colVisible
            // 
            this.colVisible.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colVisible.HeaderText = "Visible";
            this.colVisible.Name = "colVisible";
            this.colVisible.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colVisible.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colVisible.Width = 62;
            // 
            // colModName
            // 
            this.colModName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colModName.HeaderText = "Name";
            this.colModName.Name = "colModName";
            this.colModName.ReadOnly = true;
            this.colModName.Width = 60;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 43;
            // 
            // colVersion
            // 
            this.colVersion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colVersion.HeaderText = "Version";
            this.colVersion.Name = "colVersion";
            this.colVersion.ReadOnly = true;
            this.colVersion.Width = 67;
            // 
            // colAuthor
            // 
            this.colAuthor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAuthor.HeaderText = "Author(s)";
            this.colAuthor.Name = "colAuthor";
            this.colAuthor.ReadOnly = true;
            this.colAuthor.Width = 74;
            // 
            // colTeaser
            // 
            this.colTeaser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTeaser.HeaderText = "Teaser";
            this.colTeaser.Name = "colTeaser";
            this.colTeaser.ReadOnly = true;
            this.colTeaser.Width = 65;
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.SystemColors.Window;
            this.msMain.Dock = System.Windows.Forms.DockStyle.None;
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(84, 24);
            this.msMain.TabIndex = 4;
            this.msMain.Text = "menuStrip1";
            this.msMain.Visible = false;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewModSet,
            this.mnuInstallMod,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuNewModSet
            // 
            this.mnuNewModSet.Name = "mnuNewModSet";
            this.mnuNewModSet.Size = new System.Drawing.Size(145, 22);
            this.mnuNewModSet.Text = "New Mod Set";
            this.mnuNewModSet.Click += new System.EventHandler(this.mnuNewModSet_Click);
            // 
            // mnuInstallMod
            // 
            this.mnuInstallMod.Name = "mnuInstallMod";
            this.mnuInstallMod.Size = new System.Drawing.Size(145, 22);
            this.mnuInstallMod.Text = "Install Mod";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(145, 22);
            this.mnuExit.Text = "Exit";
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditMod,
            this.mnuDeleteMod,
            this.mnuSep1,
            this.mnuEnableAll,
            this.mnuDisableAll,
            this.mnuSep2,
            this.mnuShowAll,
            this.mnuHideAll});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "Edit";
            // 
            // mnuEditMod
            // 
            this.mnuEditMod.Name = "mnuEditMod";
            this.mnuEditMod.Size = new System.Drawing.Size(135, 22);
            this.mnuEditMod.Text = "Edit Mod";
            // 
            // mnuDeleteMod
            // 
            this.mnuDeleteMod.Name = "mnuDeleteMod";
            this.mnuDeleteMod.Size = new System.Drawing.Size(135, 22);
            this.mnuDeleteMod.Text = "Delete Mod";
            this.mnuDeleteMod.Click += new System.EventHandler(this.mnuDeleteMod_Click);
            // 
            // mnuSep1
            // 
            this.mnuSep1.Name = "mnuSep1";
            this.mnuSep1.Size = new System.Drawing.Size(132, 6);
            // 
            // mnuEnableAll
            // 
            this.mnuEnableAll.Name = "mnuEnableAll";
            this.mnuEnableAll.Size = new System.Drawing.Size(135, 22);
            this.mnuEnableAll.Tag = "3";
            this.mnuEnableAll.Text = "Enable All";
            this.mnuEnableAll.Click += new System.EventHandler(this.mnuHideAll_Click);
            // 
            // mnuDisableAll
            // 
            this.mnuDisableAll.Name = "mnuDisableAll";
            this.mnuDisableAll.Size = new System.Drawing.Size(135, 22);
            this.mnuDisableAll.Tag = "2";
            this.mnuDisableAll.Text = "Disable All";
            this.mnuDisableAll.Click += new System.EventHandler(this.mnuHideAll_Click);
            // 
            // mnuSep2
            // 
            this.mnuSep2.Name = "mnuSep2";
            this.mnuSep2.Size = new System.Drawing.Size(132, 6);
            // 
            // mnuShowAll
            // 
            this.mnuShowAll.Name = "mnuShowAll";
            this.mnuShowAll.Size = new System.Drawing.Size(135, 22);
            this.mnuShowAll.Tag = "1";
            this.mnuShowAll.Text = "Show All";
            this.mnuShowAll.Click += new System.EventHandler(this.mnuHideAll_Click);
            // 
            // mnuHideAll
            // 
            this.mnuHideAll.Name = "mnuHideAll";
            this.mnuHideAll.Size = new System.Drawing.Size(135, 22);
            this.mnuHideAll.Tag = "0";
            this.mnuHideAll.Text = "Hide All";
            this.mnuHideAll.Click += new System.EventHandler(this.mnuHideAll_Click);
            // 
            // tsContainer
            // 
            this.tsContainer.BottomToolStripPanelVisible = false;
            // 
            // tsContainer.ContentPanel
            // 
            this.tsContainer.ContentPanel.Controls.Add(this.grdMods);
            this.tsContainer.ContentPanel.Size = new System.Drawing.Size(1174, 403);
            this.tsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsContainer.LeftToolStripPanelVisible = false;
            this.tsContainer.Location = new System.Drawing.Point(0, 0);
            this.tsContainer.Name = "tsContainer";
            this.tsContainer.RightToolStripPanelVisible = false;
            this.tsContainer.Size = new System.Drawing.Size(1174, 457);
            this.tsContainer.TabIndex = 5;
            this.tsContainer.Text = "toolStripContainer1";
            // 
            // tsContainer.TopToolStripPanel
            // 
            this.tsContainer.TopToolStripPanel.Controls.Add(this.msMain);
            this.tsContainer.TopToolStripPanel.Controls.Add(this.tsMain);
            // 
            // tsMain
            // 
            this.tsMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNewModSet,
            this.tbEditModSet,
            this.toolStripSeparator1,
            this.tbViewMod,
            this.tbDelete,
            this.toolStripSeparator2,
            this.tbShowAll,
            this.tbHideAll,
            this.toolStripSeparator3,
            this.tbEnableAll,
            this.tbDisableAll,
            this.toolStripSeparator4,
            this.tbRefresh,
            this.toolStripSeparator5,
            this.tbHelp});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1174, 54);
            this.tsMain.Stretch = true;
            this.tsMain.TabIndex = 5;
            // 
            // tbNewModSet
            // 
            this.tbNewModSet.Image = ((System.Drawing.Image)(resources.GetObject("tbNewModSet.Image")));
            this.tbNewModSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbNewModSet.Name = "tbNewModSet";
            this.tbNewModSet.Size = new System.Drawing.Size(54, 51);
            this.tbNewModSet.Text = "New Set";
            this.tbNewModSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbNewModSet.Click += new System.EventHandler(this.mnuNewModSet_Click);
            // 
            // tbEditModSet
            // 
            this.tbEditModSet.Image = ((System.Drawing.Image)(resources.GetObject("tbEditModSet.Image")));
            this.tbEditModSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbEditModSet.Name = "tbEditModSet";
            this.tbEditModSet.Size = new System.Drawing.Size(50, 51);
            this.tbEditModSet.Text = "Edit Set";
            this.tbEditModSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbEditModSet.Click += new System.EventHandler(this.mnuNewModSet_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // tbViewMod
            // 
            this.tbViewMod.Image = ((System.Drawing.Image)(resources.GetObject("tbViewMod.Image")));
            this.tbViewMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbViewMod.Name = "tbViewMod";
            this.tbViewMod.Size = new System.Drawing.Size(64, 51);
            this.tbViewMod.Text = "View Mod";
            this.tbViewMod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbViewMod.Click += new System.EventHandler(this.tbViewMod_Click);
            // 
            // tbDelete
            // 
            this.tbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbDelete.Image")));
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(44, 51);
            this.tbDelete.Text = "Delete";
            this.tbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbDelete.Click += new System.EventHandler(this.mnuDeleteMod_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // tbShowAll
            // 
            this.tbShowAll.Image = ((System.Drawing.Image)(resources.GetObject("tbShowAll.Image")));
            this.tbShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbShowAll.Name = "tbShowAll";
            this.tbShowAll.Size = new System.Drawing.Size(57, 51);
            this.tbShowAll.Tag = "1";
            this.tbShowAll.Text = "Show All";
            this.tbShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbShowAll.Click += new System.EventHandler(this.mnuHideAll_Click);
            // 
            // tbHideAll
            // 
            this.tbHideAll.Image = ((System.Drawing.Image)(resources.GetObject("tbHideAll.Image")));
            this.tbHideAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbHideAll.Name = "tbHideAll";
            this.tbHideAll.Size = new System.Drawing.Size(53, 51);
            this.tbHideAll.Tag = "0";
            this.tbHideAll.Text = "Hide All";
            this.tbHideAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbHideAll.Click += new System.EventHandler(this.mnuHideAll_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 54);
            // 
            // tbEnableAll
            // 
            this.tbEnableAll.Image = ((System.Drawing.Image)(resources.GetObject("tbEnableAll.Image")));
            this.tbEnableAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbEnableAll.Name = "tbEnableAll";
            this.tbEnableAll.Size = new System.Drawing.Size(63, 51);
            this.tbEnableAll.Tag = "3";
            this.tbEnableAll.Text = "Enable All";
            this.tbEnableAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbEnableAll.Click += new System.EventHandler(this.mnuHideAll_Click);
            // 
            // tbDisableAll
            // 
            this.tbDisableAll.Image = ((System.Drawing.Image)(resources.GetObject("tbDisableAll.Image")));
            this.tbDisableAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDisableAll.Name = "tbDisableAll";
            this.tbDisableAll.Size = new System.Drawing.Size(66, 51);
            this.tbDisableAll.Tag = "2";
            this.tbDisableAll.Text = "Disable All";
            this.tbDisableAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbDisableAll.Click += new System.EventHandler(this.mnuHideAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 54);
            // 
            // tbRefresh
            // 
            this.tbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tbRefresh.Image")));
            this.tbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRefresh.Name = "tbRefresh";
            this.tbRefresh.Size = new System.Drawing.Size(50, 51);
            this.tbRefresh.Text = "Refresh";
            this.tbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbRefresh.Click += new System.EventHandler(this.tbRefresh_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 54);
            // 
            // tbHelp
            // 
            this.tbHelp.Image = ((System.Drawing.Image)(resources.GetObject("tbHelp.Image")));
            this.tbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbHelp.Name = "tbHelp";
            this.tbHelp.Size = new System.Drawing.Size(48, 51);
            this.tbHelp.Text = "  Help  ";
            this.tbHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbHelp.Click += new System.EventHandler(this.tbHelp_Click);
            // 
            // dlgOpenFolder
            // 
            this.dlgOpenFolder.Description = "Select the root Civilization 6 directory";
            this.dlgOpenFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.dlgOpenFolder.ShowNewFolderButton = false;
            // 
            // frmModManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1174, 457);
            this.Controls.Add(this.tsContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.msMain;
            this.Name = "frmModManager";
            this.Text = "Mod Manager";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmModManager_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdMods)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tsContainer.ContentPanel.ResumeLayout(false);
            this.tsContainer.TopToolStripPanel.ResumeLayout(false);
            this.tsContainer.TopToolStripPanel.PerformLayout();
            this.tsContainer.ResumeLayout(false);
            this.tsContainer.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdMods;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuNewModSet;
        private System.Windows.Forms.ToolStripMenuItem mnuInstallMod;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuEditMod;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteMod;
        private System.Windows.Forms.ToolStripSeparator mnuSep1;
        private System.Windows.Forms.ToolStripMenuItem mnuEnableAll;
        private System.Windows.Forms.ToolStripMenuItem mnuDisableAll;
        private System.Windows.Forms.ToolStripSeparator mnuSep2;
        private System.Windows.Forms.ToolStripMenuItem mnuShowAll;
        private System.Windows.Forms.ToolStripMenuItem mnuHideAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeaser;
        private System.Windows.Forms.ToolStripContainer tsContainer;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tbViewMod;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbShowAll;
        private System.Windows.Forms.ToolStripButton tbHideAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tbEnableAll;
        private System.Windows.Forms.ToolStripButton tbDisableAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tbRefresh;
        private System.Windows.Forms.ToolStripButton tbNewModSet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tbHelp;
        private System.Windows.Forms.FolderBrowserDialog dlgOpenFolder;
        private System.Windows.Forms.ToolStripButton tbEditModSet;
    }
}