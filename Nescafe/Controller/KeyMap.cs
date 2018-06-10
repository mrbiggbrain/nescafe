using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nescafe
{
    class KeyMap
    {
        public List<KeyMapItem> Map
        {
            get;
            set;
        }


        public void Default()
        {
            this.Map = new List<KeyMapItem>()
            {
                new KeyMapItem(Keys.Z, Controller.Button.A),
                new KeyMapItem(Keys.X, Controller.Button.B),
                new KeyMapItem(Keys.Left, Controller.Button.Left),
                new KeyMapItem(Keys.Right, Controller.Button.Right),
                new KeyMapItem(Keys.Up, Controller.Button.Up),
                new KeyMapItem(Keys.Down, Controller.Button.Down),
                new KeyMapItem(Keys.Q, Controller.Button.Start),
                new KeyMapItem(Keys.W, Controller.Button.Select)
            };
        }

        public void Load(String path)
        {

        }

        public void Save(String path)
        {

        }
    }
}
