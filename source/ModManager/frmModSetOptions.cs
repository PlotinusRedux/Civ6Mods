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
    public partial class frmModSetOptions : Form
    {
        public static void Display()
        {
            using (var frm = new frmModSetOptions())
                if (DialogResult.OK != frm.ShowDialog())
                    ModSetOptions.Load();
        }

        public frmModSetOptions()
        {
            InitializeComponent();

            ShowSettings();
        }

        private void ShowSettings()
        {
            chkHide.Checked = ModSetOptions.HideChildren;
            if (ModSetOptions.Merge.Shell2Way == ModMergeOptions.ShellWhen.AlwaysShell)
                chk2wayExternalOnly.Checked = true;
            else
                chk2wayAutoOnly.Checked = true;
            if (ModSetOptions.Merge.Shell3Way == ModMergeOptions.ShellWhen.AlwaysShell)
                chk3wayExternalOnly.Checked = true;
            else if (ModSetOptions.Merge.Shell3Way == ModMergeOptions.ShellWhen.ShellOnFail)
                chk3wayExternalOnFail.Checked = true;
            else
                chk3wayAutoOnly.Checked = true;
            txt2wayCmdline.Text = ModSetOptions.Merge.ShellCmd2Way;
            txt3wayCmdline.Text = ModSetOptions.Merge.ShellCmd3Way;
        }

        private void RetrieveSettings()
        {
            ModSetOptions.HideChildren = chkHide.Checked;

            if (chk2wayExternalOnly.Checked)
                ModSetOptions.Merge.Shell2Way = ModMergeOptions.ShellWhen.AlwaysShell;
            else
                ModSetOptions.Merge.Shell2Way = ModMergeOptions.ShellWhen.NeverShell;

            if (chk3wayExternalOnly.Checked)
                ModSetOptions.Merge.Shell3Way = ModMergeOptions.ShellWhen.AlwaysShell;
            else if (chk3wayExternalOnFail.Checked)
                ModSetOptions.Merge.Shell3Way = ModMergeOptions.ShellWhen.ShellOnFail;
            else
                ModSetOptions.Merge.Shell3Way = ModMergeOptions.ShellWhen.NeverShell;

            ModSetOptions.Merge.ShellCmd2Way = txt2wayCmdline.Text;
            ModSetOptions.Merge.ShellCmd3Way = txt3wayCmdline.Text;
        }

        private void btnDefaults_Click(object sender, EventArgs e)
        {
            ModSetOptions.Reset();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            RetrieveSettings();
            ModSetOptions.Save();
            DialogResult = DialogResult.OK;
        }
    }
}
