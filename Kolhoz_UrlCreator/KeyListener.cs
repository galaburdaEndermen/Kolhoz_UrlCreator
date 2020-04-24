using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolhoz_UrlCreator
{
    class KeyListener
    {
        public KeyListener()
        {
            List<Keys> C1 = new List<Keys> { Keys.LControlKey, Keys.N };
            Combinaison Combinaison = new Combinaison(C1, Action);
        }

        public void Action(List<Keys> keys)
        {
            string Keys = "";
            foreach (var key in keys)
            {
                Keys += key.ToString() + " ";
            }
            MessageBox.Show(Keys);
        }
    }
}
