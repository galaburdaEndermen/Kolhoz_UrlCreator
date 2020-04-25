using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Kolhoz_UrlCreator
{
    static class HtmlRequester
    {

        private static string getResponse(string uri)
        {
            WebClient wc = new WebClient();
            return wc.DownloadString(uri);
        }
        public static string getTitle(string adress) // акуратніше написать
        {
            string res;
            res = getResponse(adress);
            string title = Regex.Match(res, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
            byte[] bytes = Encoding.Default.GetBytes(title);
            title = Encoding.UTF8.GetString(bytes);

            return title;
        }
        private static void Filtre(string fileName)
        {
            //удалить недопустимы символи 
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
        public static bool isExist(string href)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(href) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return false;
            }
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
                jammer.Suspend();
            }
        }

        private static void jamming()
        {
            DisableAdapter("Hamachi");
            Thread.Sleep(10000);
        }
    }
}
