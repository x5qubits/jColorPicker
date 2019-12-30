using jColorPicker.Utils;
using JHUI;
using JHUI.Forms;
using JHUI.Utils;
using JHUI.Utils.HotKey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jColorPicker
{
    public partial class Settings : JForm
    {
        private bool locked;
        private JColorStyle color;
        private JThemeStyle theme;

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            locked = true;

            string[] colors = Enum.GetNames(typeof(JColorStyle));
            sThemeColor.Items.Clear();
            foreach (string str in colors)
            {
                if (!str.Equals("Default") && !str.Equals("Custom"))
                    sThemeColor.Items.Add(str.Replace("_", " "));
            }
            color = PreferenceManager.Database.ThemeColor;
            theme = PreferenceManager.Database.Theme;
            sThemeColor.SelectedItem = color.ToString();
            jTheme.SelectedItem = theme.ToString();
            jColorSize.SelectedIndex = PreferenceManager.Database.ColorSize;

            string[] keys = Enum.GetNames(typeof(Keys));
            KeyCaptureCombo.Items.Clear();
            KeyCopyToClipboard.Items.Clear();

            foreach (string str in keys)
            {
                KeyCaptureCombo.Items.Add(str);
                KeyCopyToClipboard.Items.Add(str);
            }

            string[] keysmid = Enum.GetNames(typeof(JKeyModifiers));
            KeyModCaptureCombo.Items.Clear();
            KeyModCopyToClipboard.Items.Clear();
            foreach (string str in keysmid)
            {
                KeyModCaptureCombo.Items.Add(str);
                KeyModCopyToClipboard.Items.Add(str);
            }
            KeyModCaptureCombo.SelectedIndex = KeyCodeConverter.GetAltIndex(PreferenceManager.Database.ScreenCopyColorKeyModifier);
            KeyModCopyToClipboard.SelectedIndex = KeyCodeConverter.GetAltIndex(PreferenceManager.Database.CopyToClipboardKeyModifier);


            KeyCaptureCombo.SelectedIndex = KeyCodeConverter.GetIndex(PreferenceManager.Database.ScreenCopyColorKey);
            KeyCopyToClipboard.SelectedIndex = KeyCodeConverter.GetIndex(PreferenceManager.Database.CopyToClipboardKey);
            ClipboardFormatingTypeCombo.SelectedIndex = PreferenceManager.Database.ClipboardFormatingType;
            FormatingTextBox.Text = PreferenceManager.Database.FormatTemplate;

            FormatingTextBox.Visible = ClipboardFormatingTypeCombo.SelectedIndex == 5;
            ToggleAutoCopyToClipboard.Checked = PreferenceManager.Database.AutoCopyToClipboard;
            StayOnTop.Checked = PreferenceManager.Database.StayOnTop;
            locked = false;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            PreferenceManager.Database.FormatTemplate = FormatingTextBox.Text;
            PreferenceManager.Save();
            this.DialogResult = DialogResult.OK;
        }

        private void styleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!locked && sThemeColor.SelectedIndex != -1)
            {
                color = (JColorStyle)Enum.Parse(typeof(JColorStyle), sThemeColor.Items[sThemeColor.SelectedIndex].ToString());
                PreferenceManager.Database.ThemeColor = color;
                SetStyle(color, theme, 255);
            }
        }

        private void jTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!locked && jTheme.SelectedIndex != -1)
            {
                theme = (JThemeStyle)Enum.Parse(typeof(JThemeStyle), jTheme.Items[jTheme.SelectedIndex].ToString());
                PreferenceManager.Database.Theme = theme;
                SetStyle(color, theme, 255);
            }
        }

        public void SetStyle(JColorStyle style, JThemeStyle thme, int alpha)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    SetStyle(style, thme, alpha);
                }));
                return;
            }
            this.components.SetStyle(this, style, thme, alpha);
        }

        private void jColorSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!locked && jColorSize.SelectedIndex != -1)
            {
                PreferenceManager.Database.ColorSize = jColorSize.SelectedIndex;
                SetStyle(color, theme, 255);
            }
        }

        private void ToggleAutoCopyToClipboard_CheckedChanged(object sender, EventArgs e)
        {
            if (locked) return;
            PreferenceManager.Database.AutoCopyToClipboard = ToggleAutoCopyToClipboard.Checked;
        }

        private void KeyCaptureCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locked) return;
            PreferenceManager.Database.ScreenCopyColorKey = KeyCodeConverter.GetKey(KeyCaptureCombo.SelectedIndex);
        }

        private void CopyToClipboardCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locked) return;

            PreferenceManager.Database.CopyToClipboardKey = KeyCodeConverter.GetKey(KeyCopyToClipboard.SelectedIndex);
        }

        private void KeyModCaptureCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locked) return;
            PreferenceManager.Database.ScreenCopyColorKeyModifier = KeyCodeConverter.GetAltKey(KeyModCaptureCombo.SelectedIndex);
        }

        private void KeyModCopyToClipboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locked) return;
            PreferenceManager.Database.CopyToClipboardKeyModifier = KeyCodeConverter.GetAltKey(KeyModCopyToClipboard.SelectedIndex);
        }

        private void jComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locked) return;
            PreferenceManager.Database.ClipboardFormatingType = ClipboardFormatingTypeCombo.SelectedIndex;
            FormatingTextBox.Visible = ClipboardFormatingTypeCombo.SelectedIndex == 5;
            if(ClipboardFormatingTypeCombo.SelectedIndex == 5)
            {
                JMessageBox.Show(this, "Example \"rbg(@R,@G,@B);\".\n\nReplace Map:\n@R= red, @G= green, @B = blue, @A = alpha, @H= hue, @S = saturation, @L = lightness, @DA=alpha (0.x)", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 211);
            }
        }

        private void StayOnTop_CheckedChanged(object sender, EventArgs e)
        {
            if (locked) return;
            PreferenceManager.Database.StayOnTop = StayOnTop.Checked;
        }
    }
}
