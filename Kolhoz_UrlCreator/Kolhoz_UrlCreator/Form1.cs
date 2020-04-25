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
            this.FormBorderStyle = FormBorderStyle.None;
            this.Height = 0;
            this.Width = 0;
            this.WindowState = FormWindowState.Minimized;
            //this.Hide();
            this.ShowInTaskbar = false;
        }


        public void Action(List<Keys> keys)
        {
            string Keys = "";
            foreach (var key in keys)
            {
                Keys += key.ToString() + " ";
            }
            MessageBox.Show(Keys);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Keys> C1 = new List<Keys> { Keys.LControlKey, Keys.N };
            Combinaison Combinaison = new Combinaison(C1, Action);
        }
    }
}
