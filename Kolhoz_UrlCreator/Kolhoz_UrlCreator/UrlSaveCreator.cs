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
            Thread.Sleep(10);
            GlobalKeySender.SendCtrlCtoSystem();
            string selectedText = Clipboard.GetText();

            HtmlRequester.startJamming();
            Thread.Sleep(10);//возможен баг

            //var test = new Uri(selectedText);
            if (Uri.TryCreate(selectedText, UriKind.RelativeOrAbsolute, out var test))
            {
                string title = HtmlRequester.getTitle(selectedText);
                if (title != "" && HtmlRequester.IsExist)
                {
                    // це ссилка реальна
                    Save(selectedText, title);

                }
                else
                {
                    //це ссилка, но запрос не пройшов
                    string tmp = selectedText;
                    tmp = tmp.Filtre("https://", "http://", "://", "/", @"\", ":", "*", "?", "\"", ">", "<", "|", "www", " ");
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
            else
            {
                 //мусор, може тут в тхт сохранять?
            }

            HtmlRequester.stopJamming();
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
