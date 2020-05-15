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
            Thread.Sleep(100);


            //string title = HtmlRequester.getTitle(selectedText);
            //if (title != "" && HtmlRequester.IsExist)
            //{
            //    Save(selectedText, title);
            //}
            //else
            //{
            //    string regex = @"_^(?:(?:https?|ftp)://)(?:\S+(?::\S*)?@)?(?:(?!10(?:\.\d{1,3}){3})(?!127(?:\.\d{1,3}){3})(?!169\.254(?:\.\d{1,3}){2})(?!192\.168(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\x{00a1}-\x{ffff}0-9]+-?)*[a-z\x{00a1}-\x{ffff}0-9]+)(?:\.(?:[a-z\x{00a1}-\x{ffff}0-9]+-?)*[a-z\x{00a1}-\x{ffff}0-9]+)*(?:\.(?:[a-z\x{00a1}-\x{ffff}]{2,})))(?::\d{2,5})?(?:/[^\s]*)?$_iuS";

            //    //if (Regex.IsMatch(selectedText, regex, RegexOptions.IgnoreCase))
            //    if (true)
            //    {
            //        string tmp = selectedText;
            //        tmp.Filtre("/", @"\", ":", "*", "?", "\"", ">", "<", "|", "www", " ");
            //        string fileName = "";
            //        for (int i = 0; i < tmp.Length; i++)
            //        {
            //            if (tmp[i] == '/')
            //            {
            //                break;
            //            }
            //            fileName += tmp[i];
            //        }

            //        Save(selectedText, fileName);
            //    }
            //}


            //string regex = @"_^(?:(?:https?|ftp)://)(?:\S+(?::\S*)?@)?(?:(?!10(?:\.\d{1,3}){3})(?!127(?:\.\d{1,3}){3})(?!169\.254(?:\.\d{1,3}){2})(?!192\.168(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\x{00a1}-\x{ffff}0-9]+-?)*[a-z\x{00a1}-\x{ffff}0-9]+)(?:\.(?:[a-z\x{00a1}-\x{ffff}0-9]+-?)*[a-z\x{00a1}-\x{ffff}0-9]+)*(?:\.(?:[a-z\x{00a1}-\x{ffff}]{2,})))(?::\d{2,5})?(?:/[^\s]*)?$_iuS";
            string regex = @"@^(https?|ftp)://[^\s/$.?#].[^\s]*$@iS";
            //string regex = @"/[-a-zA-Z0-9@:%_\+.~#?&//=]{2,256}\.[a-z]{2,4}\b(\/[-a-zA-Z0-9@:%_\+.~#?&//=]*)?/gi ";
            //string regex = "_^(?:(?:https?|ftp)://)(?:\S+(?::\S*)?@)?(?:(?!10(?:\.\d{1,3}){3})(?!127(?:\.\d{1,3}){3})(?!169\.254(?:\.\d{1,3}){2})(?!192\.168(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\x{00a1}-\x{ffff}0-9]+-?)*[a-z\x{00a1}-\x{ffff}0-9]+)(?:\.(?:[a-z\x{00a1}-\x{ffff}0-9]+-?)*[a-z\x{00a1}-\x{ffff}0-9]+)*(?:\.(?:[a-z\x{00a1}-\x{ffff}]{2,})))(?::\d{2,5})?(?:/[^\s]*)?$_iuS";
            //string regex = @"/(?<scheme>http[s]?):\/\/(?<domain>[\w\.-]+)(?<path>[^?$]+)?(?<query>[^#$]+)?[#]?(?<fragment>[^$]+)?/";
            //string regex = @"/^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$/";
            //string regex = "/^(https?:\\/\\/)?([\\w\\.]+)\\.([a-z]{2,6}\\.?)(\\/[\\w\\.]*)*\\/?$/";
            //string regex = @"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}";
            //string regex = @"#([a-z]([a-z]|\d|\+|-|\.)*):(\/\/(((([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?((\[(|(v[\da-f]{1,}\.(([a-z]|\d|-|\.|_|~)|[!\$&'\(\)\*\+,;=]|:)+))\])|((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|(([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=])*)(:\d*)?)(\/(([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*|(\/((([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)|((([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)|((([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)){0})(\?((([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\xE000-\xF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?#iS";
            //string regex = @"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}";
            //if (Regex.IsMatch(selectedText, regex, RegexOptions.IgnoreCase))
            var test = new Uri(selectedText);
            if (Uri.TryCreate(selectedText, UriKind.RelativeOrAbsolute, out test))
            {
                string title = HtmlRequester.getTitle(selectedText);
                if (title != "" && HtmlRequester.IsExist)
                {
                    // це ссилка реальна
                    //string tmp = title;
                    //tmp = tmp.Filtre("/", @"\", ":", "*", "?", "\"", ">", "<", "|", "www", " ", "https://", "http://");
                    //string fileName = "";
                    //for (int i = 0; i < tmp.Length; i++)
                    //{
                    //    if (tmp[i] == '/')
                    //    {
                    //        break;
                    //    }
                    //    fileName += tmp[i];
                    //}

                    Save(selectedText, title);

                }
                else
                {
                    //це ссилка, но запрос не пройшов
                    string tmp = selectedText;
                    tmp = tmp.Filtre("/", @"\", ":", "*", "?", "\"", ">", "<", "|", "www", " ", "https://", "http://", "://");
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
