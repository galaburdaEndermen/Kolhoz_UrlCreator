using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolhoz_UrlCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            notifyIcon1.BalloonTipTitle = "Url Creator";
            notifyIcon1.BalloonTipText = "Hiden";
            notifyIcon1.Text = "Url Creator";

            ////this.Hide();
            //this.ShowInTaskbar = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HotKey h = RegisterHotKey(Keys.N, HotKey.KeyModifiers.Control); // Crtl + 1
        }

        public HotKey RegisterHotKey(Keys key, HotKey.KeyModifiers modifiers)
        {
            HotKey hk = new HotKey(this.Handle);
            hk.KeyModifier = modifiers;
            hk.Key = key;
            hk.HotKeyPressed += new KeyEventHandler(KeyHandler);
            if (!hk.isKeyRegistered)
            {
                hk.Dispose();
                hk = null;
            }
            return hk;
        }

        public void UnRegisterHotkey(HotKey hotkey)
        {
            hotkey?.Dispose();
        }

        private void KeyHandler(object sender, KeyEventArgs e)
        {
            UrlSaveCreator.Create();
        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);

            }
            else
            {
                notifyIcon1.Visible = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            this.Hide();
        }
    }

}
