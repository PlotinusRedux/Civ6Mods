namespace ModManager
{
    partial class frmModSetEdit
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
            this.panProperties = new System.Windows.Forms.Panel();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panChildren = new System.Windows.Forms.Panel();
            this.panChildrenButtons = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panAddedChildren = new System.Windows.Forms.Panel();
            this.lstIncluded = new System.Windows.Forms.ListBox();
            this.panExcludedChildren = new System.Windows.Forms.Panel();
            this.lstExcluded = new System.Windows.Forms.ListBox();
            this.panMainButtons = new System.Windows.Forms.Panel();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.errInvalid = new System.Windows.Forms.ErrorProvider(this.components);
            this.panProperties.SuspendLayout();
            this.panChildren.SuspendLayout();
            this.panChildrenButtons.SuspendLayout();
            this.panAddedChildren.SuspendLayout();
            this.panExcludedChildren.SuspendLayout();
            this.panMainButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errInvalid)).BeginInit();
            this.SuspendLayout();
            // 
            // panProperties
            // 
            this.panProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panProperties.Controls.Add(this.txtFileName);
            this.panProperties.Controls.Add(this.lblFileName);
            this.panProperties.Controls.Add(this.txtId);
            this.panProperties.Controls.Add(this.lblId);
            this.panProperties.Controls.Add(this.txtName);
            this.panProperties.Controls.Add(this.lblName);
            this.panProperties.Location = new System.Drawing.Point(0, 0);
            this.panProperties.Name = "panProperties";
            this.panProperties.Size = new System.Drawing.Size(743, 64);
            this.panProperties.TabIndex = 0;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(426, 6);
            this.txtFileName.MaxLength = 50;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(287, 20);
            this.txtFileName.TabIndex = 4;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtFileName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFileName_KeyPress);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(369, 9);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(51, 13);
            this.lblFileName.TabIndex = 5;
            this.lblFileName.Text = "FileName";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(53, 32);
            this.txtId.MaxLength = 50;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(287, 20);
            this.txtId.TabIndex = 3;
            this.txtId.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFileName_KeyPress);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 35);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "Id";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(53, 6);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(287, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFileName_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // panChildren
            // 
            this.panChildren.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panChildren.Controls.Add(this.panChildrenButtons);
            this.panChildren.Controls.Add(this.panAddedChildren);
            this.panChildren.Controls.Add(this.panExcludedChildren);
            this.panChildren.Location = new System.Drawing.Point(12, 70);
            this.panChildren.Name = "panChildren";
            this.panChildren.Size = new System.Drawing.Size(731, 250);
            this.panChildren.TabIndex = 1;
            this.panChildren.Layout += new System.Windows.Forms.LayoutEventHandler(this.panChildren_Layout);
            // 
            // panChildrenButtons
            // 
            this.panChildrenButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panChildrenButtons.Controls.Add(this.btnDown);
            this.panChildrenButtons.Controls.Add(this.btnUp);
            this.panChildrenButtons.Controls.Add(this.btnRemove);
            this.panChildrenButtons.Controls.Add(this.btnAdd);
            this.panChildrenButtons.Location = new System.Drawing.Point(320, 0);
            this.panChildrenButtons.Name = "panChildrenButtons";
            this.panChildrenButtons.Size = new System.Drawing.Size(119, 250);
            this.panChildrenButtons.TabIndex = 3;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Location = new System.Drawing.Point(13, 116);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(95, 24);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "Move &Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Location = new System.Drawing.Point(13, 86);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(95, 24);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "Move &Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(13, 42);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(95, 24);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "&Remove >>";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(13, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "<< &Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panAddedChildren
            // 
            this.panAddedChildren.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panAddedChildren.Controls.Add(this.lstIncluded);
            this.panAddedChildren.Location = new System.Drawing.Point(0, 0);
            this.panAddedChildren.Name = "panAddedChildren";
            this.panAddedChildren.Size = new System.Drawing.Size(314, 250);
            this.panAddedChildren.TabIndex = 0;
            // 
            // lstIncluded
            // 
            this.lstIncluded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstIncluded.IntegralHeight = false;
            this.lstIncluded.Location = new System.Drawing.Point(0, 0);
            this.lstIncluded.Name = "lstIncluded";
            this.lstIncluded.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstIncluded.Size = new System.Drawing.Size(314, 250);
            this.lstIncluded.TabIndex = 0;
            this.lstIncluded.DoubleClick += new System.EventHandler(this.lstIncluded_DoubleClick);
            // 
            // panExcludedChildren
            // 
            this.panExcludedChildren.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panExcludedChildren.Controls.Add(this.lstExcluded);
            this.panExcludedChildren.Location = new System.Drawing.Point(445, 0);
            this.panExcludedChildren.Name = "panExcludedChildren";
            this.panExcludedChildren.Size = new System.Drawing.Size(286, 250);
            this.panExcludedChildren.TabIndex = 0;
            // 
            // lstExcluded
            // 
            this.lstExcluded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstExcluded.IntegralHeight = false;
            this.lstExcluded.Location = new System.Drawing.Point(0, 0);
            this.lstExcluded.Name = "lstExcluded";
            this.lstExcluded.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstExcluded.Size = new System.Drawing.Size(286, 250);
            this.lstExcluded.Sorted = true;
            this.lstExcluded.TabIndex = 1;
            this.lstExcluded.DoubleClick += new System.EventHandler(this.lstExcluded_DoubleClick);
            // 
            // panMainButtons
            // 
            this.panMainButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panMainButtons.Controls.Add(this.btnOptions);
            this.panMainButtons.Controls.Add(this.btnCancel);
            this.panMainButtons.Controls.Add(this.btnOK);
            this.panMainButtons.Location = new System.Drawing.Point(749, 0);
            this.panMainButtons.Name = "panMainButtons";
            this.panMainButtons.Size = new System.Drawing.Size(119, 332);
            this.panMainButtons.TabIndex = 2;
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.Location = new System.Drawing.Point(13, 103);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(95, 33);
            this.btnOptions.TabIndex = 2;
            this.btnOptions.Text = "O&ptions";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(13, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 33);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(13, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 33);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errInvalid
            // 
            this.errInvalid.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errInvalid.ContainerControl = this;
            // 
            // frmModSetEdit
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(869, 332);
            this.Controls.Add(this.panMainButtons);
            this.Controls.Add(this.panChildren);
            this.Controls.Add(this.panProperties);
            this.MinimumSize = new System.Drawing.Size(885, 371);
            this.Name = "frmModSetEdit";
            this.Text = "Edit Mod Set";
            this.panProperties.ResumeLayout(false);
            this.panProperties.PerformLayout();
            this.panChildren.ResumeLayout(false);
            this.panChildrenButtons.ResumeLayout(false);
            this.panAddedChildren.ResumeLayout(false);
            this.panExcludedChildren.ResumeLayout(false);
            this.panMainButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errInvalid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panProperties;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panChildren;
        private System.Windows.Forms.Panel panChildrenButtons;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panAddedChildren;
        private System.Windows.Forms.Panel panMainButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panExcludedChildren;
        private System.Windows.Forms.ListBox lstIncluded;
        private System.Windows.Forms.ListBox lstExcluded;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.ErrorProvider errInvalid;
        private System.Windows.Forms.Button btnOptions;
    }
}