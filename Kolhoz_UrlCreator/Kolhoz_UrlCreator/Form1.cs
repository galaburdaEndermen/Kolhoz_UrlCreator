using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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


        public void Action(List<Keys> keys)
        {
            //string Keys = "";
            //foreach (var key in keys)
            //{
            //    Keys += key.ToString() + " ";
            //}
            //MessageBox.Show(Keys);
            
            UrlSaveCreator.Create();

         
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Keys> C1 = new List<Keys> { Keys.LControlKey, Keys.N };
            Combinaison Combinaison = new Combinaison(C1, Action);
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
