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
    public partial class frmModBlocked : Form
    {
        private ModHandler Handler;
        private Mod Mod1;
        private List<Mod> BlockedMods;

        public int Selected { get { return (chkMod1.Checked) ? 0 : 1; } }

        public static int Display(ModHandler mh, Mod m, List<Mod> lstBlocked)
        {
            using (var frm = new frmModBlocked(mh, m, lstBlocked))
            {
                frm.ShowDialog();
                return frm.Selected;
            }
        }

        public frmModBlocked(ModHandler mh, Mod m, List<Mod> lstBlocked) : this()
        {
            Handler = mh;
            Mod1 = m;
            BlockedMods = lstBlocked;

            chkMod1.Text = Mod1.Title;

            StringBuilder sb = new StringBuilder();
            foreach (Mod blocked in lstBlocked)
            {
                if (sb.Length > 0)
                    sb.Append(Environment.NewLine);
                sb.Append(blocked.Title);
            }

            chkMod2.Text = sb.ToString();
        }

        private frmModBlocked()
        {
            InitializeComponent();
        }
    }
}
