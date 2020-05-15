using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Kolhoz_UrlCreator.Extentions;

namespace Kolhoz_UrlCreator
{
    static class HtmlRequester
    {
        public static bool IsExist { get; set; }
        private static string getResponse(string uri)
        {
            try
            {
                WebClient wc = new WebClient();
                string result = wc.DownloadString(uri);
                IsExist = true;
                return result;
            }
            catch (Exception e)
            {
                IsExist = false;
                return null;
            }
          
        }
        public static string getTitle(string adress) 
        {
            string res;
            res = getResponse(adress);
            if (!IsExist)
            {
                return "";
            }
            string title = Regex.Match(res, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
            byte[] bytes = Encoding.Default.GetBytes(title);
            title = Encoding.UTF8.GetString(bytes);

            title = title.Filtre("/", @"\", ":", "*", "?", "\"", ">", "<", "|");
            return title;
        }
      
        public static void DisableAdapter(string interfaceName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            psi.UseShellExecute = true;
            psi.Verb = "runas";
            p.StartInfo = psi;
            p.Start();
        }
        
        private static Thread jammer;

        public static void startJamming()
        {
            if (jammer == null)
            {
                jammer = new Thread(new ThreadStart(jamming));
                jammer.Name = "Jammer";
                jammer.Start();
            }
            else
            {
                if (jammer.ThreadState == ThreadState.Stopped)
                {
                    jammer.Resume();
                }
            }
        }
        public static void stopJamming()
        {
            if (jammer != null)
            {
                if (jammer.IsAlive)
                {
                    jammer.Suspend();
                }
                
            }
        }

        private static void jamming()
        {
            while (true)
            {
                DisableAdapter("Hamachi");
                Thread.Sleep(10000);
            }
            
        }
    }
}
