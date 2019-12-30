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
        public static void AddPalette(PaletteCategory data, bool save = false) { Instance.IAddPalette(data, save); }
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
            AddPalette(new PaletteCategory() { data = data.ToArray(), DbName = "Flat Palette" });


            data = new List<PaletteItem>()
            {
                new PaletteItem("Bar", ColorTranslator.FromHtml("#FE3E75")),
                new PaletteItem("BG", ColorTranslator.FromHtml("#010F1C")),
                new PaletteItem("BG2", ColorTranslator.FromHtml("#142634")),
                new PaletteItem("Panel BG", ColorTranslator.FromHtml("#1E3E53")),
                new PaletteItem("Btn1 BG", ColorTranslator.FromHtml("#1D3A48")),
                new PaletteItem("Btn1 Border", ColorTranslator.FromHtml("#953A63")),
                new PaletteItem("Btn2 BG", ColorTranslator.FromHtml("#0E704A")),
                new PaletteItem("Btn2 Border", ColorTranslator.FromHtml("#18A572")),
                new PaletteItem("#1D3A48", ColorTranslator.FromHtml("#1D3A48")),
                new PaletteItem("#99C9D4", ColorTranslator.FromHtml("#99C9D4")),
                new PaletteItem("#344F5D", ColorTranslator.FromHtml("#344F5D")),
                new PaletteItem("#111111", ColorTranslator.FromHtml("#111111")),

            };
            AddPalette(new PaletteCategory() { data = data.ToArray(), DbName = "Sci Fi" });
            data = new List<PaletteItem>()
            {
                new PaletteItem("#333333", ColorTranslator.FromHtml("#333333")),
                new PaletteItem("#F40D12", ColorTranslator.FromHtml("#F40D12")),
                new PaletteItem("#FFFFFF", ColorTranslator.FromHtml("#FFFFFF")),
                new PaletteItem("#111111", ColorTranslator.FromHtml("#111111")),
                new PaletteItem("#86B34D", ColorTranslator.FromHtml("#86B34D")),
            };
            AddPalette(new PaletteCategory() { data = data.ToArray(), DbName = "Ad Block" });
            data = new List<PaletteItem>() 
            {
                new PaletteItem("cornsilk", ColorTranslator.FromHtml("#FFF8DC")),
                new PaletteItem("blanchedalmond", ColorTranslator.FromHtml("#FFEBCD")),
                new PaletteItem("bisque", ColorTranslator.FromHtml("#FFE4C4")),
                new PaletteItem("navajowhite", ColorTranslator.FromHtml("#FFDEAD")),
                new PaletteItem("wheat", ColorTranslator.FromHtml("#F5DEB3")),
                new PaletteItem("burlywood", ColorTranslator.FromHtml("#DEB887")),
                new PaletteItem("tan", ColorTranslator.FromHtml("#D2B48C")),
                new PaletteItem("rosybrown", ColorTranslator.FromHtml("#BC8F8F")),
                new PaletteItem("sandybrown", ColorTranslator.FromHtml("#F4A460")),
                new PaletteItem("goldenrod", ColorTranslator.FromHtml("#DAA520")),
                new PaletteItem("peru", ColorTranslator.FromHtml("#CD853F")),
                new PaletteItem("chocolate", ColorTranslator.FromHtml("#D2691E")),
                new PaletteItem("saddlebrown", ColorTranslator.FromHtml("#8B4513")),
                new PaletteItem("sienna", ColorTranslator.FromHtml("#A0522D")),
                new PaletteItem("brown", ColorTranslator.FromHtml("#A52A2A")),
                new PaletteItem("maroon", ColorTranslator.FromHtml("#800000")), 
            };
            AddPalette(new PaletteCategory() { data = data.ToArray(), DbName = "Brown colors" });
            data = new List<PaletteItem>()
            {
                new PaletteItem("gainsboro", ColorTranslator.FromHtml("#DCDCDC")),
                new PaletteItem("lightgray", ColorTranslator.FromHtml("#D3D3D3")),
                new PaletteItem("silver", ColorTranslator.FromHtml("#C0C0C0")),
                new PaletteItem("darkgray", ColorTranslator.FromHtml("#A9A9A9")),
                new PaletteItem("gray", ColorTranslator.FromHtml("#808080")),
                new PaletteItem("dimgray", ColorTranslator.FromHtml("#696969")),
                new PaletteItem("lightslategray", ColorTranslator.FromHtml("#778899")),
                new PaletteItem("slategray", ColorTranslator.FromHtml("#708090")),
                new PaletteItem("darkslategray", ColorTranslator.FromHtml("#2F4F4F")),
                new PaletteItem("black", ColorTranslator.FromHtml("#000000")),
            };
            AddPalette(new PaletteCategory() { data = data.ToArray(), DbName = "Gray colors" });
            data = new List<PaletteItem>()
            {
                new PaletteItem("white", ColorTranslator.FromHtml("#FFFFFF")),
                new PaletteItem("snow", ColorTranslator.FromHtml("#FFFAFA")),
                new PaletteItem("honeydew", ColorTranslator.FromHtml("#F0FFF0")),
                new PaletteItem("mintcream", ColorTranslator.FromHtml("#F5FFFA")),
                new PaletteItem("azure", ColorTranslator.FromHtml("#F0FFFF")),
                new PaletteItem("aliceblue", ColorTranslator.FromHtml("#F0F8FF")),
                new PaletteItem("ghostwhite", ColorTranslator.FromHtml("#F8F8FF")),
                new PaletteItem("whitesmoke", ColorTranslator.FromHtml("#F5F5F5")),
                new PaletteItem("seashell", ColorTranslator.FromHtml("#FFF5EE")),
                new PaletteItem("beige", ColorTranslator.FromHtml("#F5F5DC")),
                new PaletteItem("oldlace", ColorTranslator.FromHtml("#FDF5E6")),
                new PaletteItem("floralwhite", ColorTranslator.FromHtml("#FFFAF0")),
                new PaletteItem("ivory", ColorTranslator.FromHtml("#FFFFF0")),
                new PaletteItem("antiquewhite", ColorTranslator.FromHtml("#FAEBD7")),
                new PaletteItem("linen", ColorTranslator.FromHtml("#FAF0E6")),
                new PaletteItem("lavenderblush", ColorTranslator.FromHtml("#FFF0F5")),
                new PaletteItem("mistyrose", ColorTranslator.FromHtml("#FFE4E1")),
            };
            AddPalette(new PaletteCategory() { data = data.ToArray(), DbName = "White colors" });
            data = new List<PaletteItem>()
            {
                new PaletteItem("pink", ColorTranslator.FromHtml("#FFC0CB")),
                new PaletteItem("lightpink", ColorTranslator.FromHtml("#FFB6C1")),
                new PaletteItem("hotpink", ColorTranslator.FromHtml("#FF69B4")),
                new PaletteItem("deeppink", ColorTranslator.FromHtml("#FF1493")),
                new PaletteItem("palevioletred", ColorTranslator.FromHtml("#DB7093")),
                new PaletteItem("mediumvioletred", ColorTranslator.FromHtml("#C71585")),
            };
            AddPalette(new PaletteCategory() { data = data.ToArray(), DbName = "Pink colors" });
            data = new List<PaletteItem>()
            {
                new PaletteItem("lavender", ColorTranslator.FromHtml("#E6E6FA")),
                new PaletteItem("thistle", ColorTranslator.FromHtml("#D8BFD8")),
                new PaletteItem("plum", ColorTranslator.FromHtml("#DDA0DD")),
                new PaletteItem("violet", ColorTranslator.FromHtml("#EE82EE")),
                new PaletteItem("orchid", ColorTranslator.FromHtml("#DA70D6")),
                new PaletteItem("fuchsia", ColorTranslator.FromHtml("#FF00FF")),
                new PaletteItem("magenta", ColorTranslator.FromHtml("#FF00FF")),
                new PaletteItem("mediumorchid", ColorTranslator.FromHtml("#BA55D3")),
                new PaletteItem("mediumpurple", ColorTranslator.FromHtml("#9370DB")),
                new PaletteItem("blueviolet", ColorTranslator.FromHtml("#8A2BE2")),
                new PaletteItem("darkviolet", ColorTranslator.FromHtml("#9400D3")),
                new PaletteItem("darkorchid", ColorTranslator.FromHtml("#9932CC")),
                new PaletteItem("darkmagenta", ColorTranslator.FromHtml("#8B008B")),
                new PaletteItem("purple", ColorTranslator.FromHtml("#800080")),
                new PaletteItem("indigo", ColorTranslator.FromHtml("#4B0082")),
            };
            AddPalette(new PaletteCategory() { data = data.ToArray(), DbName = "Purple colors" });
            data = new List<PaletteItem>()
            {
                new PaletteItem("powderblue", ColorTranslator.FromHtml("#B0E0E6")),
                new PaletteItem("lightblue", ColorTranslator.FromHtml("#ADD8E6")),
                new PaletteItem("lightskyblue", ColorTranslator.FromHtml("#87CEFA")),
                new PaletteItem("skyblue", ColorTranslator.FromHtml("#87CEEB")),
                new PaletteItem("deepskyblue", ColorTranslator.FromHtml("#00BFFF")),
                new PaletteItem("lightsteelblue", ColorTranslator.FromHtml("#B0C4DE")),
                new PaletteItem("dodgerblue", ColorTranslator.FromHtml("#1E90FF")),
                new PaletteItem("cornflowerblue", ColorTranslator.FromHtml("#6495ED")),
                new PaletteItem("steelblue", ColorTranslator.FromHtml("#4682B4")),
                new PaletteItem("royalblue", ColorTranslator.FromHtml("#4169E1")),
                new PaletteItem("blue", ColorTranslator.FromHtml("#0000FF")),
                new PaletteItem("mediumblue", ColorTranslator.FromHtml("#0000CD")),
                new PaletteItem("darkblue", ColorTranslator.FromHtml("#00008B")),
                new PaletteItem("navy", ColorTranslator.FromHtml("#000080")),
                new PaletteItem("midnightblue", ColorTranslator.FromHtml("#191970")),
                new PaletteItem("mediumslateblue", ColorTranslator.FromHtml("#7B68EE")),
                new PaletteItem("slateblue", ColorTranslator.FromHtml("#6A5ACD")),
                new PaletteItem("darkslateblue", ColorTranslator.FromHtml("#483D8B")),
            };
            AddPalette(new PaletteCategory() { data = data.ToArray(), DbName = "Blue colors" });
            data = new List<PaletteItem>()
            {
                    new PaletteItem("lightcyan", ColorTranslator.FromHtml("#E0FFFF")),
                    new PaletteItem("cyan", ColorTranslator.FromHtml("#00FFFF")),
                    new PaletteItem("aqua", ColorTranslator.FromHtml("#00FFFF")),
                    new PaletteItem("aquamarine", ColorTranslator.FromHtml("#7FFFD4")),
                    new PaletteItem("mediumaquamarine", ColorTranslator.FromHtml("#66CDAA")),
                    new PaletteItem("paleturquoise", ColorTranslator.FromHtml("#AFEEEE")),
                    new PaletteItem("turquoise", ColorTranslator.FromHtml("#40E0D0")),
                    new PaletteItem("mediumturquoise", ColorTranslator.FromHtml("#48D1CC")),
                    new PaletteItem("darkturquoise", ColorTranslator.FromHtml("#00CED1")),
                    new PaletteItem("lightseagreen", ColorTranslator.FromHtml("#20B2AA")),
                    new PaletteItem("cadetblue", ColorTranslator.FromHtml("#5F9EA0")),
                    new PaletteItem("darkcyan", ColorTranslator.FromHtml("#008B8B")),
                    new PaletteItem("teal", ColorTranslator.FromHtml("#008080")),
            };
            AddPalette(new PaletteCategory() { data = data.ToArray(), DbName = "Cyan colors" });
            data = new List<PaletteItem>()
            {
                new PaletteItem("lawngreen", ColorTranslator.FromHtml("#7CFC00")),
                new PaletteItem("chartreuse", ColorTranslator.FromHtml("#7FFF00")),
                new PaletteItem("limegreen", ColorTranslator.FromHtml("#32CD32")),
                new PaletteItem("lime", ColorTranslator.FromHtml("#00FF00")),
                new PaletteItem("forestgreen", ColorTranslator.FromHtml("#228B22")),
                new PaletteItem("green", ColorTranslator.FromHtml("#008000")),
                new PaletteItem("darkgreen", ColorTranslator.FromHtml("#006400")),
                new PaletteItem("greenyellow", ColorTranslator.FromHtml("#ADFF2F")),
                new PaletteItem("yellowgreen", ColorTranslator.FromHtml("#9ACD32")),
                new PaletteItem("springgreen", ColorTranslator.FromHtml("#00FF7F")),
                new PaletteItem("mediumspringgreen", ColorTranslator.FromHtml("#00FA9A")),
                new PaletteItem("lightgreen", ColorTranslator.FromHtml("#90EE90")),
                new PaletteItem("palegreen", ColorTranslator.FromHtml("#98FB98")),
                new PaletteItem("darkseagreen", ColorTranslator.FromHtml("#8FBC8F")),
                new PaletteItem("mediumseagreen", ColorTranslator.FromHtml("#3CB371")),
                new PaletteItem("seagreen", ColorTranslator.FromHtml("#2E8B57")),
                new PaletteItem("olive", ColorTranslator.FromHtml("#808000")),
                new PaletteItem("darkolivegreen", ColorTranslator.FromHtml("#556B2F")),
                new PaletteItem("olivedrab", ColorTranslator.FromHtml("#6B8E23")),
            };
            AddPalette(new PaletteCategory() { data = data.ToArray(), DbName = "Green colors" });
            data = new List<PaletteItem>()
            {
                new PaletteItem("lightyellow", ColorTranslator.FromHtml("#FFFFE0")),
                new PaletteItem("lemonchiffon", ColorTranslator.FromHtml("#FFFACD")),
                new PaletteItem("lightgoldenrodyellow", ColorTranslator.FromHtml("#FAFAD2")),
                new PaletteItem("papayawhip", ColorTranslator.FromHtml("#FFEFD5")),
                new PaletteItem("moccasin", ColorTranslator.FromHtml("#FFE4B5")),
                new PaletteItem("peachpuff", ColorTranslator.FromHtml("#FFDAB9")),
                new PaletteItem("palegoldenrod", ColorTranslator.FromHtml("#EEE8AA")),
                new PaletteItem("khaki", ColorTranslator.FromHtml("#F0E68C")),
                new PaletteItem("darkkhaki", ColorTranslator.FromHtml("#BDB76B")),
                new PaletteItem("yellow", ColorTranslator.FromHtml("#FFFF00")),
            };
            AddPalette(new PaletteCategory() { data = data.ToArray(), DbName = "Yellow colors" });
            data = new List<PaletteItem>()
            {
                new PaletteItem("coral", ColorTranslator.FromHtml("#FF7F50")),
                new PaletteItem("tomato", ColorTranslator.FromHtml("#FF6347")),
                new PaletteItem("orangered", ColorTranslator.FromHtml("#FF4500")),
                new PaletteItem("gold", ColorTranslator.FromHtml("#FFD700")),
                new PaletteItem("orange", ColorTranslator.FromHtml("#FFA500")),
                new PaletteItem("darkorange", ColorTranslator.FromHtml("#FF8C00")),
            };
            AddPalette(new PaletteCategory() { data = data.ToArray(), DbName = "Orange colors" });
            data = new List<PaletteItem>()
            {
                new PaletteItem("lightsalmon", ColorTranslator.FromHtml("#FFA07A")),
                new PaletteItem("salmon", ColorTranslator.FromHtml("#FA8072")),
                new PaletteItem("darksalmon", ColorTranslator.FromHtml("#E9967A")),
                new PaletteItem("lightcoral", ColorTranslator.FromHtml("#F08080")),
                new PaletteItem("indianred", ColorTranslator.FromHtml("#CD5C5C")),
                new PaletteItem("crimson", ColorTranslator.FromHtml("#DC143C")),
                new PaletteItem("firebrick", ColorTranslator.FromHtml("#B22222")),
                new PaletteItem("red", ColorTranslator.FromHtml("#FF0000")),
                new PaletteItem("darkred", ColorTranslator.FromHtml("#8B0000")),
            };
            AddPalette(new PaletteCategory() { data = data.ToArray(), DbName = "Red colors" });

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

        void IAddPalette(PaletteCategory data, bool save = true)
        {
            lock (database)
            {
                database.index += 1;
                database.paletts.Add(database.index, data);
            }
            if(save)
                Save();
        }

        void ISetPaletteItems(int PaletIndex, PaletteItem[] Items)
        {
            lock (database)
            {
                if (database.paletts.TryGetValue(PaletIndex, out PaletteCategory palette))
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
