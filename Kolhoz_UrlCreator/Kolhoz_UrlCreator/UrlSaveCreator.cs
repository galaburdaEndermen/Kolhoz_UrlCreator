using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolhoz_UrlCreator
{
    class UrlSaveCreator
    {
        public static void Create()
        {
            GlobalKeySender.SendCtrlCtoSystem();
            MessageBox.Show(Clipboard.GetText());
        }
    }
}
