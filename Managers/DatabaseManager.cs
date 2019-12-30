using jColorPicker.Classes;
using JCommon.FileDatabase;
using JHUI.Controls.ColorPicker;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace jColorPicker
{
    public class DatabaseManager
    {
        #region SINGLETON
        static volatile DatabaseManager s_Instance;
        private static object s_Sync = new object();

        public static DatabaseManager Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_Sync)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new DatabaseManager();
                        }
                    }
                }
                return s_Instance;
            }
        }
        #endregion

        #region VARS
        string databasePath;
        PaletteDatabase database = new PaletteDatabase();
        #endregion

        #region External Access
        public static PaletteCategory[] GetPalets() { return Instance.IGetPalets(); }
        public static void Start() { Instance.IStart(); }
        public static void AddPalette(PaletteCategory data) { Instance.IAddPalette(data); }
        public static void SetPaletteItems(int PaletIndex, PaletteItem[] Items) { Instance.ISetPaletteItems(PaletIndex, Items); }
        public static void DeletePalette(int PaletIndex) { Instance.IDeletePalette(PaletIndex); }
        public static void RenamePalette(int PaletIndex, string Name) { Instance.IRenamePalette(PaletIndex, Name); }
        public static PaletteItem[] GetPalette(int Index) { return Instance.IGetPalette(Index); }
        #endregion

        #region Internal Access
        void IStart()
        {
            databasePath = Path.Combine(Application.StartupPath, "PaletDatabase.bin");
            if (File.Exists(databasePath))
            {
                database = FileDatabase.ReadFile<PaletteDatabase>(databasePath);
                if (database == null)
                    LoadDefault();
            }
            else
            {
                LoadDefault();
            }
        }
        
        void LoadDefault()
        {
            database = new PaletteDatabase
            {
                Path = databasePath
            };
            List<PaletteItem> data = new List<PaletteItem>
            {
                new PaletteItem("Turquoise", ColorTranslator.FromHtml("#1abc9c")),
                new PaletteItem("Elmerald", ColorTranslator.FromHtml("#2ecc71")),
                new PaletteItem("Peter River", ColorTranslator.FromHtml("#3498db")),
                new PaletteItem("Amethyst", ColorTranslator.FromHtml("#9b59b6")),
                new PaletteItem("Wet Asphalt", ColorTranslator.FromHtml("#34495e")),
                new PaletteItem("Grean Sea", ColorTranslator.FromHtml("#16a085")),
                new PaletteItem("Nephritis", ColorTranslator.FromHtml("#27ae60")),
                new PaletteItem("Belize Hole", ColorTranslator.FromHtml("#2980b9")),
                new PaletteItem("Wisteria", ColorTranslator.FromHtml("#8e44ad")),
                new PaletteItem("Midnight Blue", ColorTranslator.FromHtml("#2c3e50")),
                new PaletteItem("Sun Flower", ColorTranslator.FromHtml("#f1c40f")),
                new PaletteItem("Carrot", ColorTranslator.FromHtml("#e67e22")),
                new PaletteItem("Alizarin", ColorTranslator.FromHtml("#e74c3c")),
                new PaletteItem("Clouds", ColorTranslator.FromHtml("#ecf0f1")),
                new PaletteItem("Concrete", ColorTranslator.FromHtml("#95a5a6")),
                new PaletteItem("Oranage", ColorTranslator.FromHtml("#f39c12")),
                new PaletteItem("Pumpkin", ColorTranslator.FromHtml("#d35400")),
                new PaletteItem("Pomegranate", ColorTranslator.FromHtml("#c0392b")),
                new PaletteItem("Silver", ColorTranslator.FromHtml("#bdc3c7")),
                new PaletteItem("Asbestos", ColorTranslator.FromHtml("#7f8c8d"))
            };
            database.paletts.Add(0, new PaletteCategory() { data = data.ToArray(), DbName = "Flat Palette" });
            Save();
        }

        void Save()
        {
            lock (database)
                FileDatabase.WriteFile(database);
        }

        PaletteCategory[] IGetPalets()
        {
            var output = new PaletteCategory[0];
            lock (database)
            {
                output = database.paletts.Values.ToArray();
            }
            return output;
        }

        PaletteItem[] IGetPalette(int index)
        {
            var output = new PaletteItem[0];
            lock (database)
            {
                if (database.paletts.TryGetValue(index, out PaletteCategory p))
                {
                    output = p.data;
                }
            }
            return output;
        }

        void IAddPalette(PaletteCategory data)
        {
            lock (database)
            {
                database.index+=1;
                database.paletts.Add(database.index, data);
            }
            Save();
        }

        void ISetPaletteItems(int PaletIndex, PaletteItem[] Items)
        {
            lock (database)
            {
                if(database.paletts.TryGetValue(PaletIndex, out PaletteCategory palette))
                {
                    database.paletts[PaletIndex].data = Items;
                }
            }
            Save();
        }

        void IDeletePalette(int PaletIndex)
        {
            lock (database)
            {
                database.paletts.Remove(PaletIndex);
            }
            Save();
        }

        void IRenamePalette(int PaletIndex, string name)
        {
            lock (database)
            {
                if (database.paletts.TryGetValue(PaletIndex, out PaletteCategory palette))
                {
                    database.paletts[PaletIndex].DbName = name;
                }
            }
            Save();
        }
        #endregion
    }
}
