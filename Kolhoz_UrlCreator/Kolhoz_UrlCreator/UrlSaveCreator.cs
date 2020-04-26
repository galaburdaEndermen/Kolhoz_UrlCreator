using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //зробить шоб при фейлі запроса воно питалось регуляркою розковирять і зберегти як є, якшо то url
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
