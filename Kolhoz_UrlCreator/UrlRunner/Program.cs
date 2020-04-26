using System;
using System.Collections.Generic;
using System.IO;
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
            string url = "";
            using (StreamReader sr = new StreamReader(args[0]))
            //using (StreamReader sr = new StreamReader(@"C:\Users\tipa1\Desktop\Новый ярлык Интернета.url"))
            {
                List<string> lines = new List<string>();
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }

                url = (from string l in lines where l.Contains("URL=") select l).ToArray<string>()[0];

                url = url.Replace("URL=", "");
            }

            if (url != null && url != "")
            {
                System.Diagnostics.Process.Start(url);
            }
        }
    }
}
