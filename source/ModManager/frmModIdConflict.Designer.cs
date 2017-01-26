namespace ModManager
{
    partial class frmModIdConflict
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
            this.lblWarning = new System.Windows.Forms.Label();
            this.gbMod1 = new System.Windows.Forms.GroupBox();
            this.btnDelete1 = new System.Windows.Forms.Button();
            this.btnNewGUID1 = new System.Windows.Forms.Button();
            this.txtId1 = new System.Windows.Forms.TextBox();
            this.lblId1 = new System.Windows.Forms.Label();
            this.gbMod2 = new System.Windows.Forms.GroupBox();
            this.btnDelete2 = new System.Windows.Forms.Button();
            this.btnNewGUID2 = new System.Windows.Forms.Button();
            this.txtId2 = new System.Windows.Forms.TextBox();
            this.lblId2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.gbMod1.SuspendLayout();
            this.gbMod2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarning.Location = new System.Drawing.Point(12, 12);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(458, 44);
            this.lblWarning.TabIndex = 0;
            this.lblWarning.Text = "WARNING!!!  Two mods detected with the same mod ID.  Civ 6 uses this as a unique " +
    "key for mods and it cannot be duplicated.  One mod with have to be deleted or ha" +
    "ve its ID changed.";
            // 
            // gbMod1
            // 
            this.gbMod1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMod1.Controls.Add(this.btnDelete1);
            this.gbMod1.Controls.Add(this.btnNewGUID1);
            this.gbMod1.Controls.Add(this.txtId1);
            this.gbMod1.Controls.Add(this.lblId1);
            this.gbMod1.Location = new System.Drawing.Point(12, 56);
            this.gbMod1.Name = "gbMod1";
            this.gbMod1.Size = new System.Drawing.Size(458, 75);
            this.gbMod1.TabIndex = 1;
            this.gbMod1.TabStop = false;
            this.gbMod1.Text = "Mod 1";
            // 
            // btnDelete1
            // 
            this.btnDelete1.Location = new System.Drawing.Point(32, 46);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(72, 21);
            this.btnDelete1.TabIndex = 3;
            this.btnDelete1.Text = "Delete Mod";
            this.btnDelete1.UseVisualStyleBackColor = true;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // btnNewGUID1
            // 
            this.btnNewGUID1.Location = new System.Drawing.Point(375, 19);
            this.btnNewGUID1.Name = "btnNewGUID1";
            this.btnNewGUID1.Size = new System.Drawing.Size(72, 21);
            this.btnNewGUID1.TabIndex = 2;
            this.btnNewGUID1.Text = "New GUID";
            this.btnNewGUID1.UseVisualStyleBackColor = true;
            this.btnNewGUID1.Click += new System.EventHandler(this.btnNewGUID1_Click);
            // 
            // txtId1
            // 
            this.txtId1.Location = new System.Drawing.Point(32, 20);
            this.txtId1.Name = "txtId1";
            this.txtId1.Size = new System.Drawing.Size(337, 20);
            this.txtId1.TabIndex = 1;
            this.txtId1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtId1_KeyPress);
            // 
            // lblId1
            // 
            this.lblId1.AutoSize = true;
            this.lblId1.Location = new System.Drawing.Point(8, 23);
            this.lblId1.Name = "lblId1";
            this.lblId1.Size = new System.Drawing.Size(18, 13);
            this.lblId1.TabIndex = 0;
            this.lblId1.Text = "ID";
            // 
            // gbMod2
            // 
            this.gbMod2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMod2.Controls.Add(this.btnDelete2);
            this.gbMod2.Controls.Add(this.btnNewGUID2);
            this.gbMod2.Controls.Add(this.txtId2);
            this.gbMod2.Controls.Add(this.lblId2);
            this.gbMod2.Location = new System.Drawing.Point(12, 152);
            this.gbMod2.Name = "gbMod2";
            this.gbMod2.Size = new System.Drawing.Size(458, 75);
            this.gbMod2.TabIndex = 2;
            this.gbMod2.TabStop = false;
            this.gbMod2.Text = "Mod 2";
            // 
            // btnDelete2
            // 
            this.btnDelete2.Location = new System.Drawing.Point(32, 46);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(72, 21);
            this.btnDelete2.TabIndex = 3;
            this.btnDelete2.Text = "Delete Mod";
            this.btnDelete2.UseVisualStyleBackColor = true;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // btnNewGUID2
            // 
            this.btnNewGUID2.Location = new System.Drawing.Point(375, 19);
            this.btnNewGUID2.Name = "btnNewGUID2";
            this.btnNewGUID2.Size = new System.Drawing.Size(72, 21);
            this.btnNewGUID2.TabIndex = 2;
            this.btnNewGUID2.Text = "New GUID";
            this.btnNewGUID2.UseVisualStyleBackColor = true;
            this.btnNewGUID2.Click += new System.EventHandler(this.btnNewGUID1_Click);
            // 
            // txtId2
            // 
            this.txtId2.Location = new System.Drawing.Point(32, 20);
            this.txtId2.Name = "txtId2";
            this.txtId2.Size = new System.Drawing.Size(337, 20);
            this.txtId2.TabIndex = 1;
            this.txtId2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtId1_KeyPress);
            // 
            // lblId2
            // 
            this.lblId2.AutoSize = true;
            this.lblId2.Location = new System.Drawing.Point(8, 23);
            this.lblId2.Name = "lblId2";
            this.lblId2.Size = new System.Drawing.Size(18, 13);
            this.lblId2.TabIndex = 0;
            this.lblId2.Text = "ID";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(482, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbort.Location = new System.Drawing.Point(482, 49);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 31);
            this.btnAbort.TabIndex = 4;
            this.btnAbort.Text = "&Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            // 
            // frmModIdConflict
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAbort;
            this.ClientSize = new System.Drawing.Size(569, 237);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbMod2);
            this.Controls.Add(this.gbMod1);
            this.Controls.Add(this.lblWarning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmModIdConflict";
            this.Text = "Mod Id Conflict";
            this.gbMod1.ResumeLayout(false);
            this.gbMod1.PerformLayout();
            this.gbMod2.ResumeLayout(false);
            this.gbMod2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.GroupBox gbMod1;
        private System.Windows.Forms.Button btnDelete1;
        private System.Windows.Forms.Button btnNewGUID1;
        private System.Windows.Forms.TextBox txtId1;
        private System.Windows.Forms.Label lblId1;
        private System.Windows.Forms.GroupBox gbMod2;
        private System.Windows.Forms.Button btnDelete2;
        private System.Windows.Forms.Button btnNewGUID2;
        private System.Windows.Forms.TextBox txtId2;
        private System.Windows.Forms.Label lblId2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAbort;
    }
}