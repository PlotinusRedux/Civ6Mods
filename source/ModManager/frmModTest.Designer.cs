namespace ModManager
{
    partial class ModTestWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModTestWindow));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.grdMods = new System.Windows.Forms.DataGridView();
            this.colModName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeaser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tvComponents = new System.Windows.Forms.TreeView();
            this.imgComponents = new System.Windows.Forms.ImageList(this.components);
            this.tvFiles = new System.Windows.Forms.TreeView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdMods)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1152, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 69);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1141, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 58);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // grdMods
            // 
            this.grdMods.AllowUserToAddRows = false;
            this.grdMods.AllowUserToDeleteRows = false;
            this.grdMods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colModName,
            this.colID,
            this.colVersion,
            this.colAuthor,
            this.colTeaser});
            this.grdMods.Location = new System.Drawing.Point(12, 2);
            this.grdMods.MultiSelect = false;
            this.grdMods.Name = "grdMods";
            this.grdMods.ReadOnly = true;
            this.grdMods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMods.Size = new System.Drawing.Size(1025, 240);
            this.grdMods.TabIndex = 2;
            this.grdMods.SelectionChanged += new System.EventHandler(this.grdMods_SelectionChanged);
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
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Components";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(410, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(328, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Files";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tvComponents
            // 
            this.tvComponents.ImageIndex = 0;
            this.tvComponents.ImageList = this.imgComponents;
            this.tvComponents.Location = new System.Drawing.Point(12, 272);
            this.tvComponents.Name = "tvComponents";
            this.tvComponents.SelectedImageIndex = 0;
            this.tvComponents.ShowPlusMinus = false;
            this.tvComponents.ShowRootLines = false;
            this.tvComponents.Size = new System.Drawing.Size(374, 316);
            this.tvComponents.StateImageList = this.imgComponents;
            this.tvComponents.TabIndex = 7;
            this.tvComponents.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvComponents_AfterCollapse);
            this.tvComponents.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvComponents_AfterExpand);
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
            // tvFiles
            // 
            this.tvFiles.ImageIndex = 2;
            this.tvFiles.ImageList = this.imgComponents;
            this.tvFiles.Location = new System.Drawing.Point(413, 272);
            this.tvFiles.Name = "tvFiles";
            this.tvFiles.SelectedImageIndex = 2;
            this.tvFiles.ShowPlusMinus = false;
            this.tvFiles.ShowRootLines = false;
            this.tvFiles.Size = new System.Drawing.Size(325, 316);
            this.tvFiles.StateImageList = this.imgComponents;
            this.tvFiles.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(794, 263);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 51);
            this.button3.TabIndex = 9;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1043, 190);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 52);
            this.button4.TabIndex = 10;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1000, 263);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 69);
            this.button5.TabIndex = 11;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(787, 375);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 252);
            this.panel1.TabIndex = 12;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1140, 295);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(68, 36);
            this.button6.TabIndex = 13;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // ModTestWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 642);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tvFiles);
            this.Controls.Add(this.tvComponents);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grdMods);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ModTestWindow";
            this.Text = "Mod Manager";
            ((System.ComponentModel.ISupportInitialize)(this.grdMods)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView grdMods;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeaser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView tvComponents;
        private System.Windows.Forms.ImageList imgComponents;
        private System.Windows.Forms.TreeView tvFiles;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
    }
}

