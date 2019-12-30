using jColorPicker.Classes;
using JCommon.FileDatabase;
using System.IO;
using System.Windows.Forms;

namespace jColorPicker
{
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
