using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kolhoz_UrlCreator.Extentions;

namespace Kolhoz_UrlCreator
{
    static class UrlSaveCreator
    {
        public static string writePath = @"E:\";

        public static void Create()
        {
            GlobalKeySender.SendCtrlCtoSystem();
            //MessageBox.Show(Clipboard.GetText());
            string selectedText = Clipboard.GetText();

            HtmlRequester.startJamming();
            Thread.Sleep(100);
            //if (HtmlRequester.isExist(selectedText))
            //{
            //    string title = HtmlRequester.getTitle(selectedText);
            //    //MessageBox.Show(title);
            //    Save(selectedText, title);
            //}

            string title = HtmlRequester.getTitle(selectedText);
            if (title != "" && HtmlRequester.IsExist)
            {
                Save(selectedText, title);
            }
            else
            {
                string regex = @"_^(?:(?:https?|ftp)://)(?:\S+(?::\S*)?@)?(?:(?!10(?:\.\d{1,3}){3})(?!127(?:\.\d{1,3}){3})(?!169\.254(?:\.\d{1,3}){2})(?!192\.168(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\x{00a1}-\x{ffff}0-9]+-?)*[a-z\x{00a1}-\x{ffff}0-9]+)(?:\.(?:[a-z\x{00a1}-\x{ffff}0-9]+-?)*[a-z\x{00a1}-\x{ffff}0-9]+)*(?:\.(?:[a-z\x{00a1}-\x{ffff}]{2,})))(?::\d{2,5})?(?:/[^\s]*)?$_iuS";

                if (Regex.IsMatch(selectedText, regex, RegexOptions.IgnoreCase))
                {
                    string tmp = selectedText;
                    tmp.Filtre("/", @"\", ":", "*", "?", "\"", ">", "<", "|", "www", " ");
                    string fileName = "";
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (tmp[i] == '/')
                        {
                            break;
                        }
                        fileName += tmp[i];
                    }

                    Save(selectedText, fileName);
                }
            }
            HtmlRequester.stopJamming();

            //зробить шоб при фейлі запроса воно питалось регуляркою розковирять і зберегти як є, якшо то url


        }



        private static void Save(string url, string title)
        {
            string filename = writePath + title + ".url";
            string text = "[InternetShortcut]\nURL = " + "https://" + url;

            try
            {
                using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }

        }
    }
}
