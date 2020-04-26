using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UrlRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process.Start(args[0]);
            //System.Diagnostics.Process.Start("http://192.168.1.1");
            //Thread.Sleep(1);
        }
    }
}
