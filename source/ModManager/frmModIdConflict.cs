using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Civ6Mod;

namespace ModManager
{
    public partial class frmModIdConflict : Form
    {
        ModHandler Handler;
        Mod Mod1;
        Mod Mod2;

        public static bool Display(ModHandler mh, Mod mod1, Mod mod2)
        {
            using (var frm = new frmModIdConflict(mh, mod1, mod2))
                return DialogResult.OK == frm.ShowDialog();
        }

        public frmModIdConflict(ModHandler mh, Mod mod1, Mod mod2) : this()
        {
            Handler = mh;
            Mod1 = mod1;
            Mod2 = mod2;

            gbMod1.Text = string.Format("{0} -- {1}", mod1.Title, ModFileUtils.CombineLinux(mod1.RelPath, mod1.FileName));
            gbMod2.Text = string.Format("{0} -- {1}", mod2.Title, ModFileUtils.CombineLinux(mod2.RelPath, mod2.FileName));

            txtId1.Text = mod1.Id;
            txtId2.Text = mod2.Id;
        }

        private frmModIdConflict()
        {
            InitializeComponent();
        }

        private void btnNewGUID1_Click(object sender, EventArgs e)
        {
            string strGUID = Guid.NewGuid().ToString();

            if (sender == btnNewGUID1)
                txtId1.Text = strGUID;
            else
                txtId2.Text = strGUID;
        }

        private void txtId1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && 0 > " _-".IndexOf(e.KeyChar))
                e.Handled = true;
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
             if (sender == btnDelete1)
            {
                Mod1.Delete();
                Handler.AddMod(Mod2);
            }
            else
                Mod2.Delete();

            DialogResult = DialogResult.OK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            txtId1.Text = txtId1.Text.Trim();
            txtId2.Text = txtId2.Text.Trim();

            if (txtId1.Text.Equals(txtId2.Text, StringComparison.OrdinalIgnoreCase))
                MessageBox.Show("Mod ID's must be unique.");
            else if (string.IsNullOrWhiteSpace(txtId1.Text) || string.IsNullOrWhiteSpace(txtId2.Text))
                MessageBox.Show("Both mods must have an ID.");
            else if (!txtId1.Text.Equals(Mod1.Id, StringComparison.OrdinalIgnoreCase) && Handler.Mods.ContainsKey(txtId1.Text))
                MessageBox.Show("ID " + txtId1.Text + " is already in use by another mod.");
            else if (!txtId2.Text.Equals(Mod2.Id, StringComparison.OrdinalIgnoreCase) && Handler.Mods.ContainsKey(txtId2.Text))
                MessageBox.Show("ID " + txtId2.Text + " is already in use by another mod.");
            else
            {
                Mod1.Id = txtId1.Text;
                Mod2.Id = txtId2.Text;
                Handler.AddMod(Mod2);
                DialogResult = DialogResult.OK;
            }
        }
    }
}
