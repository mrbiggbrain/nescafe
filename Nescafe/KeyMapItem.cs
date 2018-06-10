using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nescafe;

namespace Nescafe
{
    class KeyMapItem
    {
        public Keys Key { get; set; }
        public Controller.Button Button { get; set; }

        public KeyMapItem(Keys Key, Controller.Button Button)
        {
            this.Key = Key;
            this.Button = Button;
        }
    }
}
