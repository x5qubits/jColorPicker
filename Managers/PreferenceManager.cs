using jColorPicker.Classes;
using JCommon.FileDatabase;
using JCommon.FileDatabase.IO;
using JHUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jColorPicker
{
    public class PreferenceSave : DataFile
    {
        public int HotKeyModifier = 0;
        public int HotKey = 0;
        public int ColorSize = 2;
        public JColorStyle ThemeColor = JColorStyle.White;
        public JThemeStyle Theme = JThemeStyle.Dark;
        public bool FirstTime = false;

        public override void Serialize(DataWriter writer)
        {
            writer.Write(HotKeyModifier);
            writer.Write(HotKey);
            writer.Write(ColorSize);
            writer.Write((int)ThemeColor);
            writer.Write((int)Theme);
            writer.Write(FirstTime);
        }
        public override void Deserialize(DataReader reader)
        {
            HotKeyModifier = reader.ReadInt32();
            HotKey = reader.ReadInt32();
            ColorSize = reader.ReadInt32();
            ThemeColor = (JColorStyle)reader.ReadInt32();
            Theme = (JThemeStyle)reader.ReadInt32();
            FirstTime = reader.ReadBoolean();
        }

    }

    public class PreferenceManager
    {
        #region SINGLETON
        static volatile PreferenceManager s_Instance;
        private static object s_Sync = new object();

        public static PreferenceManager Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_Sync)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new PreferenceManager();
                        }
                    }
                }
                return s_Instance;
            }
        }
        #endregion

        PreferenceSave database = new PreferenceSave();
        string databasePath;
        public static PreferenceSave Database => Instance.Get();
        public static void Save() { Instance.ISave(); }
        public static void Start() { Instance.IStart(); }

        void IStart()
        {
            databasePath = Path.Combine(Application.StartupPath, "Preferences.bin");
            if (File.Exists(databasePath))
            {
                database = FileDatabase.ReadFile<PreferenceSave>(databasePath);
            }
            else
            {
                database = new PreferenceSave() { Path = databasePath };
                Save();
            }
        }

        void ISave()
        {
            lock (database)
                FileDatabase.WriteFile(database);
        }
        PreferenceSave Get()
        {
            var ret = new PreferenceSave();
            lock (database)
            {
                ret = database;
            }
            return ret;
        }
    }
}
