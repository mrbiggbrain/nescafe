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
                // Split up the line
                String[] lineComponents = line.Split(':');

                // Check Length
                if(lineComponents.Length == 2)
                {
                    String rawKey = lineComponents[0];
                    String rawButton = lineComponents[1];

                    Keys key;
                    Controller.Button button;

                    // Try to Parse the Key
                    if(Enum.TryParse(rawKey, out key))
                    {
                        // Try and Parse the Button
                        if (Enum.TryParse(rawButton, out button))
                        {
                            this.Map.Add(new KeyMapItem(key, button));
                        }
                        else
                        {
                            throw new ArgumentException("Invalid KeyMap file. " + rawButton + " is not a valid button name.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Invalid KeyMap file. " + rawKey + " is not a valid key name.");
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid KeyMap file. Wrong formatting.");
                }
            }
        }

        public void Save(String path)
        {

        }
    }
}
