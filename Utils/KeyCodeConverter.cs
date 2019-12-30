using JHUI.Utils.HotKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jColorPicker.Utils
{
    public static class KeyCodeConverter
    {
        static public Dictionary<int, Keys> keysdata = new Dictionary<int, Keys>();
        static public Dictionary<int, JKeyModifiers> keysmoddata = new Dictionary<int, JKeyModifiers>();
        static public Dictionary<Keys, int> rkeysdata = new Dictionary<Keys, int>();
        static public Dictionary<JKeyModifiers, int> rkeysmoddata = new Dictionary<JKeyModifiers, int>();

        public static void Start()
        {
            keysdata = new Dictionary<int, Keys>();
            keysmoddata = new Dictionary<int, JKeyModifiers>();
            rkeysdata = new Dictionary<Keys, int>();
            rkeysmoddata = new Dictionary<JKeyModifiers, int>();
            var i = 0;
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                if (!rkeysdata.ContainsKey(key))
                {
                    keysdata.Add(i, key);
                    rkeysdata.Add(key, i);
                }
                i++;
            }
            i = 0;
            foreach (JKeyModifiers key in Enum.GetValues(typeof(JKeyModifiers)))
            {
                keysmoddata.Add(i, key);
                rkeysmoddata.Add(key, i);
                i++;
            }
        }

        public static Keys GetKey(int index)
        {
            if (keysdata.TryGetValue(index, out Keys k))
                return k;

            return Keys.None;
        }

        public static int GetIndex(Keys key)
        {
            if (rkeysdata.TryGetValue(key, out int k))
                return k;

            return 0;
        }

        public static JKeyModifiers GetAltKey(int index)
        {
            if (keysmoddata.TryGetValue(index, out JKeyModifiers k))
                return k;

            return JKeyModifiers.NoRepeat;
        }

        public static int GetAltIndex(JKeyModifiers key)
        {
            if (rkeysmoddata.TryGetValue(key, out int k))
                return k;

            return 0;
        }

    }
}
