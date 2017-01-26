namespace ModManager
{
    partial class frmModBlocked
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
            this.chkMod1 = new System.Windows.Forms.RadioButton();
            this.chkMod2 = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarning.Location = new System.Drawing.Point(12, 9);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(458, 20);
            this.lblWarning.TabIndex = 1;
            this.lblWarning.Text = "WARNING!!!  The mods listed below block each.  Please select which mod(s) to enab" +
    "le.";
            // 
            // chkMod1
            // 
            this.chkMod1.AutoSize = true;
            this.chkMod1.Checked = true;
            this.chkMod1.Location = new System.Drawing.Point(12, 32);
            this.chkMod1.Name = "chkMod1";
            this.chkMod1.Size = new System.Drawing.Size(85, 17);
            this.chkMod1.TabIndex = 2;
            this.chkMod1.TabStop = true;
            this.chkMod1.Text = "radioButton1";
            this.chkMod1.UseVisualStyleBackColor = true;
            // 
            // chkMod2
            // 
            this.chkMod2.AutoSize = true;
            this.chkMod2.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkMod2.Location = new System.Drawing.Point(12, 55);
            this.chkMod2.Name = "chkMod2";
            this.chkMod2.Size = new System.Drawing.Size(85, 43);
            this.chkMod2.TabIndex = 3;
            this.chkMod2.TabStop = true;
            this.chkMod2.Text = "radioButton2\r\ntwo\r\nthree";
            this.chkMod2.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(482, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // frmModBlocked
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(569, 237);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkMod2);
            this.Controls.Add(this.chkMod1);
            this.Controls.Add(this.lblWarning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmModBlocked";
            this.Text = "Blocked Mods";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.RadioButton chkMod1;
        private System.Windows.Forms.RadioButton chkMod2;
        private System.Windows.Forms.Button btnOK;
    }
}