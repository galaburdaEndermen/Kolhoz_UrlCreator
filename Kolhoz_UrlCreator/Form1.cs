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

        private void Form1_Load(object sender, EventArgs e)
        {
            


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Alt)
            {
              
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
