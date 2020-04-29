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
            public static void Filtre(this string str, params string[] toDelete)
            {
                foreach (string del in toDelete)
                {
                    str = str.Replace(del, "");
                }
            }
        }


    }
}
