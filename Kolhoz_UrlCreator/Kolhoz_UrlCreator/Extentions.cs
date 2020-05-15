using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolhoz_UrlCreator
{
    namespace Extentions
    {
        static class StringExentions
        {
            public static string Filtre(this string str, params string[] toDelete)
            {
                string tmp = str;
                foreach (string del in toDelete)
                {
                    tmp = tmp.Replace(del, "");
                }
                return tmp;
            }
        }


    }
}
