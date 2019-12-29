using jColorPicker.Classes;
using JCommon.FileDatabase;
using JCommon.FileDatabase.IO;
using JHUI.Controls.ColorPicker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jColorPicker
{
    public class PaletteDatabase : DataFile
    {
        public int index;
        public Dictionary<int, PaletteCategory> paletts = new Dictionary<int, PaletteCategory>();

        public override void Serialize(DataWriter writer)
        {
            var data = paletts.Values;
            writer.WritePackedUInt32((uint)data.Count);
            foreach (PaletteCategory palette in data)
            {
                writer.Write(palette.DbName);
                writer.WritePackedUInt32((uint)palette.data.Length);
                foreach(PaleteItem item in palette.data)
                {
                    writer.Write(item.ColorName);
                    writer.Write(item.Color.A);
                    writer.Write(item.Color.R);
                    writer.Write(item.Color.G);
                    writer.Write(item.Color.B);
                }
            }
        }
        public override void Deserialize(DataReader reader)
        {
            paletts = new Dictionary<int, PaletteCategory>();
            uint count = reader.ReadPackedUInt32();
            for (index = 0; index < count; index++)
            {
                paletts.Add(index, new PaletteCategory()
                {
                    DbName = reader.ReadString(),
                });
                uint itemcount = reader.ReadPackedUInt32();
                paletts[index].data = new PaleteItem[itemcount];
                for (var i = 0; i < itemcount; i++)
                {
                    paletts[index].data[i] = new PaleteItem()
                    {
                        ColorName = reader.ReadString(),
                        Color = Color.FromArgb(reader.ReadByte(), reader.ReadByte(), reader.ReadByte(), reader.ReadByte())
                    };
                }
            }
        }

    }
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
        public static void SetPaletteItems(int PaletIndex, PaleteItem[] Items) { Instance.ISetPaletteItems(PaletIndex, Items); }
        public static void DeletePalette(int PaletIndex) { Instance.IDeletePalette(PaletIndex); }
        public static void RenamePalette(int PaletIndex, string Name) { Instance.IRenamePalette(PaletIndex, Name); }
        public static PaleteItem[] GetPalette(int Index) { return Instance.IGetPalette(Index); }
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
            List<PaleteItem> data = new List<PaleteItem>
            {
                new PaleteItem("Turquoise", ColorTranslator.FromHtml("#1abc9c")),
                new PaleteItem("Elmerald", ColorTranslator.FromHtml("#2ecc71")),
                new PaleteItem("Peter River", ColorTranslator.FromHtml("#3498db")),
                new PaleteItem("Amethyst", ColorTranslator.FromHtml("#9b59b6")),
                new PaleteItem("Wet Asphalt", ColorTranslator.FromHtml("#34495e")),
                new PaleteItem("Grean Sea", ColorTranslator.FromHtml("#16a085")),
                new PaleteItem("Nephritis", ColorTranslator.FromHtml("#27ae60")),
                new PaleteItem("Belize Hole", ColorTranslator.FromHtml("#2980b9")),
                new PaleteItem("Wisteria", ColorTranslator.FromHtml("#8e44ad")),
                new PaleteItem("Midnight Blue", ColorTranslator.FromHtml("#2c3e50")),
                new PaleteItem("Sun Flower", ColorTranslator.FromHtml("#f1c40f")),
                new PaleteItem("Carrot", ColorTranslator.FromHtml("#e67e22")),
                new PaleteItem("Alizarin", ColorTranslator.FromHtml("#e74c3c")),
                new PaleteItem("Clouds", ColorTranslator.FromHtml("#ecf0f1")),
                new PaleteItem("Concrete", ColorTranslator.FromHtml("#95a5a6")),
                new PaleteItem("Oranage", ColorTranslator.FromHtml("#f39c12")),
                new PaleteItem("Pumpkin", ColorTranslator.FromHtml("#d35400")),
                new PaleteItem("Pomegranate", ColorTranslator.FromHtml("#c0392b")),
                new PaleteItem("Silver", ColorTranslator.FromHtml("#bdc3c7")),
                new PaleteItem("Asbestos", ColorTranslator.FromHtml("#7f8c8d"))
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

        PaleteItem[] IGetPalette(int index)
        {
            var output = new PaleteItem[0];
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

        void ISetPaletteItems(int PaletIndex, PaleteItem[] Items)
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
