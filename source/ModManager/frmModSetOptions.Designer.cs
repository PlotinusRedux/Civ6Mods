namespace ModManager
{
    partial class frmModSetOptions
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
            this.gbMergeOptions = new System.Windows.Forms.GroupBox();
            this.txt3wayCmdline = new System.Windows.Forms.TextBox();
            this.lblExternalCmdLine = new System.Windows.Forms.Label();
            this.chk3wayExternalOnly = new System.Windows.Forms.RadioButton();
            this.chk3wayExternalOnFail = new System.Windows.Forms.RadioButton();
            this.chk3wayAutoOnly = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt2wayCmdline = new System.Windows.Forms.TextBox();
            this.lblExternalCmdLine2 = new System.Windows.Forms.Label();
            this.chk2wayExternalOnly = new System.Windows.Forms.RadioButton();
            this.chk2wayAutoOnly = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkHide = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDefaults = new System.Windows.Forms.Button();
            this.gbMergeOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMergeOptions
            // 
            this.gbMergeOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMergeOptions.Controls.Add(this.txt3wayCmdline);
            this.gbMergeOptions.Controls.Add(this.lblExternalCmdLine);
            this.gbMergeOptions.Controls.Add(this.chk3wayExternalOnly);
            this.gbMergeOptions.Controls.Add(this.chk3wayExternalOnFail);
            this.gbMergeOptions.Controls.Add(this.chk3wayAutoOnly);
            this.gbMergeOptions.Location = new System.Drawing.Point(12, 72);
            this.gbMergeOptions.Name = "gbMergeOptions";
            this.gbMergeOptions.Size = new System.Drawing.Size(706, 100);
            this.gbMergeOptions.TabIndex = 0;
            this.gbMergeOptions.TabStop = false;
            this.gbMergeOptions.Text = "3-Way Merge Options";
            // 
            // txt3wayCmdline
            // 
            this.txt3wayCmdline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt3wayCmdline.Location = new System.Drawing.Point(115, 64);
            this.txt3wayCmdline.Name = "txt3wayCmdline";
            this.txt3wayCmdline.Size = new System.Drawing.Size(570, 20);
            this.txt3wayCmdline.TabIndex = 4;
            // 
            // lblExternalCmdLine
            // 
            this.lblExternalCmdLine.AutoSize = true;
            this.lblExternalCmdLine.Location = new System.Drawing.Point(17, 67);
            this.lblExternalCmdLine.Name = "lblExternalCmdLine";
            this.lblExternalCmdLine.Size = new System.Drawing.Size(92, 13);
            this.lblExternalCmdLine.TabIndex = 3;
            this.lblExternalCmdLine.Text = "External Cmd Line";
            // 
            // chk3wayExternalOnly
            // 
            this.chk3wayExternalOnly.AutoSize = true;
            this.chk3wayExternalOnly.Location = new System.Drawing.Point(400, 30);
            this.chk3wayExternalOnly.Name = "chk3wayExternalOnly";
            this.chk3wayExternalOnly.Size = new System.Drawing.Size(150, 17);
            this.chk3wayExternalOnly.TabIndex = 2;
            this.chk3wayExternalOnly.TabStop = true;
            this.chk3wayExternalOnly.Text = "Always use external merge";
            this.chk3wayExternalOnly.UseVisualStyleBackColor = true;
            // 
            // chk3wayExternalOnFail
            // 
            this.chk3wayExternalOnFail.AutoSize = true;
            this.chk3wayExternalOnFail.Location = new System.Drawing.Point(199, 30);
            this.chk3wayExternalOnFail.Name = "chk3wayExternalOnFail";
            this.chk3wayExternalOnFail.Size = new System.Drawing.Size(182, 17);
            this.chk3wayExternalOnFail.TabIndex = 1;
            this.chk3wayExternalOnFail.TabStop = true;
            this.chk3wayExternalOnFail.Text = "Use external merge if internal fails";
            this.chk3wayExternalOnFail.UseVisualStyleBackColor = true;
            // 
            // chk3wayAutoOnly
            // 
            this.chk3wayAutoOnly.AutoSize = true;
            this.chk3wayAutoOnly.Location = new System.Drawing.Point(17, 30);
            this.chk3wayAutoOnly.Name = "chk3wayAutoOnly";
            this.chk3wayAutoOnly.Size = new System.Drawing.Size(159, 17);
            this.chk3wayAutoOnly.TabIndex = 0;
            this.chk3wayAutoOnly.TabStop = true;
            this.chk3wayAutoOnly.Text = "Use internal auto-merge only";
            this.chk3wayAutoOnly.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txt2wayCmdline);
            this.groupBox1.Controls.Add(this.lblExternalCmdLine2);
            this.groupBox1.Controls.Add(this.chk2wayExternalOnly);
            this.groupBox1.Controls.Add(this.chk2wayAutoOnly);
            this.groupBox1.Location = new System.Drawing.Point(12, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 103);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2-Way Merge Options";
            // 
            // txt2wayCmdline
            // 
            this.txt2wayCmdline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt2wayCmdline.Location = new System.Drawing.Point(115, 64);
            this.txt2wayCmdline.Name = "txt2wayCmdline";
            this.txt2wayCmdline.Size = new System.Drawing.Size(570, 20);
            this.txt2wayCmdline.TabIndex = 4;
            // 
            // lblExternalCmdLine2
            // 
            this.lblExternalCmdLine2.AutoSize = true;
            this.lblExternalCmdLine2.Location = new System.Drawing.Point(17, 67);
            this.lblExternalCmdLine2.Name = "lblExternalCmdLine2";
            this.lblExternalCmdLine2.Size = new System.Drawing.Size(92, 13);
            this.lblExternalCmdLine2.TabIndex = 3;
            this.lblExternalCmdLine2.Text = "External Cmd Line";
            // 
            // chk2wayExternalOnly
            // 
            this.chk2wayExternalOnly.AutoSize = true;
            this.chk2wayExternalOnly.Location = new System.Drawing.Point(199, 30);
            this.chk2wayExternalOnly.Name = "chk2wayExternalOnly";
            this.chk2wayExternalOnly.Size = new System.Drawing.Size(150, 17);
            this.chk2wayExternalOnly.TabIndex = 2;
            this.chk2wayExternalOnly.TabStop = true;
            this.chk2wayExternalOnly.Text = "Always use external merge";
            this.chk2wayExternalOnly.UseVisualStyleBackColor = true;
            // 
            // chk2wayAutoOnly
            // 
            this.chk2wayAutoOnly.AutoSize = true;
            this.chk2wayAutoOnly.Location = new System.Drawing.Point(17, 30);
            this.chk2wayAutoOnly.Name = "chk2wayAutoOnly";
            this.chk2wayAutoOnly.Size = new System.Drawing.Size(159, 17);
            this.chk2wayAutoOnly.TabIndex = 0;
            this.chk2wayAutoOnly.TabStop = true;
            this.chk2wayAutoOnly.Text = "Use internal auto-merge only";
            this.chk2wayAutoOnly.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkHide);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(706, 54);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General Options";
            // 
            // chkHide
            // 
            this.chkHide.AutoSize = true;
            this.chkHide.Location = new System.Drawing.Point(17, 25);
            this.chkHide.Name = "chkHide";
            this.chkHide.Size = new System.Drawing.Size(159, 17);
            this.chkHide.TabIndex = 0;
            this.chkHide.Text = "Hide included mods in game";
            this.chkHide.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(706, 93);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Commandline Parameters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 52);
            this.label3.TabIndex = 0;
            this.label3.Text = "%O = Original file (3-way merge only)\r\n%A = Changed file 1\r\n%B = Changed file 2\r\n" +
    "%OUT = Output file";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(734, 49);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(734, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDefaults
            // 
            this.btnDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefaults.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDefaults.Location = new System.Drawing.Point(734, 102);
            this.btnDefaults.Name = "btnDefaults";
            this.btnDefaults.Size = new System.Drawing.Size(75, 31);
            this.btnDefaults.TabIndex = 7;
            this.btnDefaults.Text = "&Defaults";
            this.btnDefaults.UseVisualStyleBackColor = true;
            this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
            // 
            // frmModSetOptions
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(821, 391);
            this.Controls.Add(this.btnDefaults);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbMergeOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmModSetOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ModSet Options";
            this.gbMergeOptions.ResumeLayout(false);
            this.gbMergeOptions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMergeOptions;
        private System.Windows.Forms.RadioButton chk3wayExternalOnly;
        private System.Windows.Forms.RadioButton chk3wayExternalOnFail;
        private System.Windows.Forms.RadioButton chk3wayAutoOnly;
        private System.Windows.Forms.TextBox txt3wayCmdline;
        private System.Windows.Forms.Label lblExternalCmdLine;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt2wayCmdline;
        private System.Windows.Forms.Label lblExternalCmdLine2;
        private System.Windows.Forms.RadioButton chk2wayExternalOnly;
        private System.Windows.Forms.RadioButton chk2wayAutoOnly;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkHide;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDefaults;
    }
}