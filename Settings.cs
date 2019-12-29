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
        private Keys defaultkeyX;
        private JKeyModifiers defaultModX;
        private bool locked;
        private JColorStyle color;
        private JThemeStyle theme;

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_KeyDown(object sender, KeyEventArgs e)
        {
            if(jToggle1.Checked)
            {
                try
                {
                    foreach(JKeyModifiers ke in Enum.GetValues(typeof(JKeyModifiers)))
                    {
                        string a = ke.ToString();
                        string b = e.Modifiers.ToString();
                        if (a == b)
                        {
                            defaultModX = ke;
                            jGroupBox1.Text = "Record Color HotKey: " + defaultModX.ToString() + "+" + defaultkeyX.ToString();

                            return;
                        }
                    }
                    defaultkeyX = e.KeyCode;
                    jGroupBox1.Text = "Record Color HotKey: " + defaultModX.ToString() + "+" + defaultkeyX.ToString();

                }
                catch { 

                    
                }
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Keys defaultkey = Keys.C;
            JKeyModifiers defaultMod = JKeyModifiers.Alt;
            if (PreferenceManager.Database.HotKey != 0)
            {
                defaultkey = (Keys)PreferenceManager.Database.HotKey;
            }
            if (PreferenceManager.Database.HotKeyModifier != 0)
            {
                defaultMod = (JKeyModifiers)PreferenceManager.Database.HotKeyModifier;
            }
            jGroupBox1.Text = "Record Color HotKey: "+ defaultMod.ToString() +"+"+ defaultkey.ToString();
            defaultkeyX = defaultkey;
            defaultModX = defaultMod;
            locked = true;
            string[] colors = Enum.GetNames(typeof(JColorStyle));
            sThemeColor.Items.Clear();
            foreach (string str in colors)
            {
                if(!str.Equals("Default") && !str.Equals("Custom"))
                    sThemeColor.Items.Add(str.Replace("_", " "));
            }
            color = PreferenceManager.Database.ThemeColor;
            theme = PreferenceManager.Database.Theme;
            sThemeColor.SelectedItem = color.ToString();
            jTheme.SelectedItem = theme.ToString();
            jColorSize.SelectedIndex = PreferenceManager.Database.ColorSize;

            locked = false;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            PreferenceManager.Database.HotKey = (int)defaultkeyX;
            PreferenceManager.Database.HotKeyModifier = (int)defaultModX;
            PreferenceManager.Save();
            this.DialogResult = DialogResult.OK;
        }

        private void styleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!locked && sThemeColor.SelectedIndex != -1)
            {
                color = (JColorStyle)Enum.Parse(typeof(JColorStyle), sThemeColor.Items[sThemeColor.SelectedIndex].ToString());
                PreferenceManager.Database.ThemeColor = color;
                PreferenceManager.Save();
                SetStyle(color, theme, 255);
            }
        }

        private void jTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!locked && jTheme.SelectedIndex != -1)
            {
                theme = (JThemeStyle)Enum.Parse(typeof(JThemeStyle), jTheme.Items[jTheme.SelectedIndex].ToString());
                PreferenceManager.Database.Theme = theme;
                PreferenceManager.Save();
                SetStyle(color, theme, 255);
            }
        }

        public void SetStyle(JColorStyle style, JThemeStyle thme, int alpha)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
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
                PreferenceManager.Save();
                SetStyle(color, theme, 255);
            }
        }
    }
}
