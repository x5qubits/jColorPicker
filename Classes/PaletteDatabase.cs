using JCommon.FileDatabase.IO;
using JHUI.Controls.ColorPicker;
using System.Collections.Generic;
using System.Drawing;

namespace jColorPicker.Classes
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
                foreach (PaletteItem item in palette.data)
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
                paletts[index].data = new PaletteItem[itemcount];
                for (var i = 0; i < itemcount; i++)
                {
                    paletts[index].data[i] = new PaletteItem()
                    {
                        ColorName = reader.ReadString(),
                        Color = Color.FromArgb(reader.ReadByte(), reader.ReadByte(), reader.ReadByte(), reader.ReadByte())
                    };
                }
            }
        }

    }
}
