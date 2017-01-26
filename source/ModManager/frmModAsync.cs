using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Civ6Mod;

namespace ModManager
{
    public partial class frmModAsync : Form
    {
        public delegate void DelModAsync();

        private Thread WatchThread;
        
        public static bool Display(DelModAsync del, string strStatus = "Please wait...", string strTitle = "Please Wait...")
        {
            using (var frm = new frmModAsync(del))
            {
                Mod.OnModProgressMessage = frm.ProgressMessage;
                try
                {
                    return DialogResult.OK == frm.ShowDialog();
                }
                finally
                {
                    Interlocked.Exchange(ref Mod.OnModProgressMessage, null);
                }
            }
        }

        private void RunThread(DelModAsync del)
        {
            Thread th = new Thread(new ThreadStart(del));

            try
            {
                th.Start();
                th.Join();
            }
            catch
            {

            }
            finally
            {
                if (th.IsAlive)
                {
                    th.Abort();
                    while (th.IsAlive)
                        Thread.Yield();
                    Invoke((Action)(() => DialogResult = DialogResult.Abort));
                }
                else
                    Invoke((Action)(() => DialogResult = DialogResult.OK));
            }
        }

        public void ProgressMessage(string strProgressMessage)
        {
            Invoke((Action)(() => lblProgress.Text = strProgressMessage));
        }

        public frmModAsync(DelModAsync del, string strStatus = "Please wait...", string strTitle = "Please Wait...") : this()
        {
            Text = strTitle;
            lblProgress.Text = strStatus;
            WatchThread = new Thread(() => RunThread(del));
        }

        private frmModAsync()
        {
            InitializeComponent();
        }

        private void frmModAsync_Shown(object sender, EventArgs e)
        {
            WatchThread.Start();
        }

        private void frmModAsync_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && WatchThread.IsAlive)
            {
                WatchThread.Abort();
                while (WatchThread.IsAlive)
                    Thread.Yield();
            }
        }
    }
}
