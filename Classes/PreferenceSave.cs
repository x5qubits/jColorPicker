using jColorPicker.Utils;
using JCommon.FileDatabase.IO;
using JHUI;
using JHUI.Utils.HotKey;
using System.Windows.Forms;

namespace jColorPicker.Classes
{
    public class PreferenceSave : DataFile
    {
        public JKeyModifiers ScreenCopyColorKeyModifier = JKeyModifiers.Alt;
        public Keys ScreenCopyColorKey = Keys.S;
        public Keys CopyToClipboardKey = Keys.C;
        public JKeyModifiers CopyToClipboardKeyModifier = JKeyModifiers.Alt;
        public int ColorSize = 2;
        public JColorStyle ThemeColor = JColorStyle.White;
        public JThemeStyle Theme = JThemeStyle.Dark;
        public bool FirstTime = true;
        public bool AutoCopyToClipboard = true;
        public bool StayOnTop = false;
        public int ClipboardFormatingType = 0;
        public string FormatTemplate = "rbg(@R,@G,@B);";

        public override void Serialize(DataWriter writer)
        {
            writer.Write(KeyCodeConverter.GetAltIndex(ScreenCopyColorKeyModifier));
            writer.Write(KeyCodeConverter.GetIndex(ScreenCopyColorKey));
            writer.Write(KeyCodeConverter.GetIndex(CopyToClipboardKey));
            writer.Write(KeyCodeConverter.GetAltIndex(CopyToClipboardKeyModifier));
            writer.Write(ColorSize);
            writer.Write((int)ThemeColor);
            writer.Write((int)Theme);
            writer.Write(FirstTime);
            writer.Write(AutoCopyToClipboard);
            writer.Write(StayOnTop);
            writer.Write(ClipboardFormatingType);
            writer.Write(FormatTemplate);
        }
        public override void Deserialize(DataReader reader)
        {
            ScreenCopyColorKeyModifier = KeyCodeConverter.GetAltKey(reader.ReadInt32());
            ScreenCopyColorKey = KeyCodeConverter.GetKey(reader.ReadInt32());
            CopyToClipboardKey = KeyCodeConverter.GetKey(reader.ReadInt32());
            CopyToClipboardKeyModifier = KeyCodeConverter.GetAltKey(reader.ReadInt32());
            ColorSize = reader.ReadInt32();
            ThemeColor = (JColorStyle)reader.ReadInt32();
            Theme = (JThemeStyle)reader.ReadInt32();
            FirstTime = reader.ReadBoolean();
            AutoCopyToClipboard = reader.ReadBoolean();
            StayOnTop = reader.ReadBoolean();
            ClipboardFormatingType = reader.ReadInt32();
            FormatTemplate = reader.ReadString();

        }

    }
}
