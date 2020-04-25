using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolhoz_UrlCreator
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }


        Thread worker;
        protected override void OnStart(string[] args)
        {
            worker = new Thread(Process);
            worker.Start();
        }

        private void Process()
        {
            Application.Run(new Form1());
            //KeyListener kl = new KeyListener();
        }

        protected override void OnStop()
        {
            worker.Abort();
            worker.Join(100);
        }
    }
}
