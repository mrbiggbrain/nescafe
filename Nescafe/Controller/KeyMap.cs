using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nescafe
{
    class KeyMap
    {
        public List<KeyMapItem> Map { get; set; }

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
            this.Map = new List<KeyMapItem>();

            foreach(String line in File.ReadLines(path))
            {
                this.Map.Add(this.ParseLine(line));
            }
        }

        public void Save(String path)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                foreach (KeyMapItem item in this.Map)
                {
                    file.WriteLine(item.Key.ToString() + ":" + item.Button.ToString());
                }
            }        
        }

        private KeyMapItem ParseLine(String line)
        {
            // Split up the line
            String[] lineComponents = line.Split(':');

            // Check Length
            if (lineComponents.Length == 2)
            {
                return new KeyMapItem(this.ParseKey(lineComponents[0]), this.ParseButton(lineComponents[1]));   
            }
            else
            {
                throw new ArgumentException("Invalid KeyMap file. Wrong formatting.");
            }
        }

        private Keys ParseKey(String rawKey)
        {
            Keys key;

            // Try to Parse the Key
            if (Enum.TryParse(rawKey, out key))
            {
                return key;
            }
            else
            {
                throw new ArgumentException("Invalid KeyMap file. " + rawKey + " is not a valid key name.");
            }
        }

        private Controller.Button ParseButton(String rawButton)
        {
            Controller.Button button;

            // Try and Parse the Button
            if (Enum.TryParse(rawButton, out button))
            {
                return button;
            }
            else
            {
                throw new ArgumentException("Invalid KeyMap file. " + rawButton + " is not a valid button name.");
            }
        }
    }
}