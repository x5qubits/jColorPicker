using System;
using System.Drawing;
using System.Windows.Forms;
using JHUI.Utils;
using JHUI.Utils.HotKey;
using JHUI.Forms;
using System.Collections.Generic;
using JHUI.Controls.ColorPicker;
using System.IO;
using System.Text.RegularExpressions;

using JHUI;
using System.Threading.Tasks;
using JHUI.Controls;
using jColorPicker.Classes;

namespace jColorPicker
{
    public partial class MainForm : JForm
    {
        public class Anim
        {
            public float nextAnim { get; set; }
            public string text { get; set; }
            public Control[] control { get; set; }
            public Control hide { get; set; }
            public bool exit { get; set; }
            public bool showHeder { get; set; }
            public Anim(float nextAnim, string text, Control[] control = null, Control hide = null, bool showHeder = false, bool exit = false)
            {
                this.nextAnim = nextAnim;
                this.text = text;
                this.control = control;
                this.hide = hide;
                this.exit = exit;
                this.showHeder = showHeder;
            }
        }
        private Anim[] messages;
        private readonly string AppName = "J Color Picker";
        private readonly bool ShowGuide = false;
        #region VARS
        private readonly JBehavor ThisAnimator = null;


        #endregion

        #region CONSTRUCTOR
        public MainForm()
        {

            InitializeComponent();
            SetupHotyKeys();
            if (PreferenceManager.Database.FirstTime || ShowGuide)
            {
                jLabel1.Text = "HI!";
                jLabel2.Visible = ColorValue.Visible = PictureBox_MyLogo.Visible = PictureBox_JHUILogo.Visible = jColorEditor1.Visible = DeletePalette.Visible = AddNewPalette.Visible = SettingsImage.Visible = AddColorImage.Visible = jColorPalette1.Visible = ColorNow.Visible = PaletteSelector.Visible = jScreenColorPicker1.Visible = false;
                this.Text = "";
                messages = new Anim[]
                {
                    new Anim( 1, "HI!"),
                    new Anim( 4, "My name is J Color Picker, J is the initial of my maker Johnny.", new Control[]{ PictureBox_MyLogo }),
                    new Anim( 4, "I started out as a demo for the Johnny Hex UI Framework or JHUI for short.", new Control[] { PictureBox_JHUILogo }, PictureBox_MyLogo),
                    new Anim( 3, "I am a grown color utility now,",new Control[]{ PictureBox_MyLogo }, null),
                    new Anim( 3, "I can copy and store any color just like physical color palette.",null, null),
                    new Anim( 4, "Let's begin!",null, PictureBox_MyLogo),
                    new Anim( 4, "This is the color picker.", new Control[] { jScreenColorPicker1 }, null),
                    new Anim( 10, "Hold down your mouse over the grid to pick a color,",null, null),
                    new Anim( 3, "or you can press ALT + C .",null, null),
                    new Anim( 4, "The color will be displayed here.", new Control[] {ColorValue, jLabel2, ColorNow, jColorEditor1  }, null),
                    new Anim( 6, "The color is auto-saved to your clipboard,", null, null),
                    new Anim( 4, "so you can press CTRL + V to paste.", null, null),
                    new Anim( 6, "Put your mouse over the other controls for help", null, null),
                    new Anim( 3f, "Happy Designing!",  new Control[] { DeletePalette, AddNewPalette , SettingsImage, AddColorImage, jColorPalette1,PaletteSelector }, PictureBox_JHUILogo, true),
                    new Anim( 0, "",  null, jLabel1, false, true),
                };
                ColorValue.BringToFront();
                ThisAnimator = new JBehavor();
                ThisAnimator.InvokeRepeating(TypText, 0.1f);
                PreferenceManager.Database.FirstTime = false;
                PreferenceManager.Save();
                canAnimate = true;
            }
            else
            {
                canAnimate = false;
                PictureBox_MyLogo.Visible = PictureBox_JHUILogo.Visible = jLabel1.Visible = false;
            }
            this.TopMost = PreferenceManager.Database.StayOnTop;
        }
        #endregion

        #region FORM LOAD
        private void Form1_Shown(object sender, EventArgs e)
        {
            new Task(() =>
            {
                try
                {
                    PaletteSelector.Invoke(new MethodInvoker(delegate
                    {
                        PaletteSelector.Items.Clear();
                        var d = DatabaseManager.GetPalets();
                        foreach (PaletteCategory ddd in d)
                            PaletteSelector.Items.Add(ddd.DbName);

                        PaletteSelector.SelectedIndex = 0;
                        var c = ColorTranslator.FromHtml(ColorValue.Text);
                        jScreenColorPicker1.Color = c;
                        ColorValue.Text = ColorTranslator.ToHtml(Color.FromArgb(Color.BlueViolet.ToArgb()));
                        jScreenColorPicker1.Color = ColorTranslator.FromHtml(ColorValue.Text);
                        

                    }));
                }
                catch { }

            }).Start();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            JColorStyle color = PreferenceManager.Database.ThemeColor;
            JThemeStyle theme = PreferenceManager.Database.Theme;
            this.SetStyle(color, theme, 255);
            jColorPalette1.SetColorItemSize(PreferenceManager.Database.ColorSize);
        }
        #endregion

        #region FUNCTIONS
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

        private void HotKeyManager_HotKeyPressed(object sender, JHotKeyEventArgs e)
        {
            if (e.Key == PreferenceManager.Database.ScreenCopyColorKey)
            {
                jScreenColorPicker1.RecordColor();
            }
            else if (e.Key == PreferenceManager.Database.CopyToClipboardKey)
            {
                CopyToClipboard(jColorEditor1.Color, true);
            }

        }

        private void JScreenColorPicker1_ColorChanged(object sender, EventArgs e)
        {
            jColorEditor1.Color = jScreenColorPicker1.Color;
            ColorNow.BackColor = jColorEditor1.Color;
            AddColorImage.BackColor = jColorEditor1.Color;
            CopyToClipboard(jColorEditor1.Color);
        }

        private void JColorEditor1_ColorChanged(object sender, EventArgs e)
        {
            ColorNow.BackColor = jColorEditor1.Color;
            AddColorImage.BackColor = jColorEditor1.Color;
            CopyToClipboard(jColorEditor1.Color);
        }

        private void CopyToClipboard(Color color, bool force = false)
        {
            var v = "";
            var t = PreferenceManager.Database.ClipboardFormatingType;
            switch (t)
            {
                case 0: //Hexadecimal
                    v = ColorTranslator.ToHtml(Color.FromArgb(color.ToArgb()));
                    break;
                case 1: //RGB
                    v = "rgb(" + color.R + ", " + color.G + ", " + color.B + ")";
                    break;
                case 2://RGBA

                    v = "rgba(" + color.R + ", " + color.G + ", " + color.B + ", " + ((double)color.A / 255D).ToString("F1") + ")";
                    break;
                case 3://HSL 
                case 4://HSLA
                case 5://CUSTOM
                    if (PreferenceManager.Database.ClipboardFormatingType == 3)
                    {
                        v = "hsl(" + color.GetHue().ToString("F0") + ", " + color.GetSaturation().ToString("F0") + "%, " + color.GetBrightness().ToString("F1") + "%)";
                    }
                    else if (PreferenceManager.Database.ClipboardFormatingType == 4)
                    {
                        v = "hsla(" + color.GetHue().ToString("F0") + ", " + color.GetSaturation().ToString("F0") + "%, " + color.GetBrightness().ToString("F1") + "%, " + ((double)color.A / 255D).ToString("F1") + ")";
                    }
                    else if (PreferenceManager.Database.ClipboardFormatingType == 5)
                    {
                        v = PreferenceManager.Database.FormatTemplate.
                            Replace("@R", color.R.ToString()).
                            Replace("@G", color.G.ToString()).
                            Replace("@B", color.B.ToString()).
                            Replace("@A", color.A.ToString()).
                            Replace("@H", color.GetHue().ToString("F0")).
                            Replace("@S", color.GetSaturation().ToString("F0")).
                            Replace("@L", color.GetBrightness().ToString("F1")).
                            Replace("@DA", ((double)color.A / 255D).ToString("F1"));
                    }
                    break;


            }
            ColorValue.Text = v;
            if (!force && !PreferenceManager.Database.AutoCopyToClipboard)
                Clipboard.SetText(v);
        }

        private void SetupHotyKeys()
        {
            JHotKeyManager.Instance.RegisterHotKey(PreferenceManager.Database.ScreenCopyColorKey, (JKeyModifiers)PreferenceManager.Database.ScreenCopyColorKeyModifier);
            JHotKeyManager.Instance.RegisterHotKey(PreferenceManager.Database.CopyToClipboardKey, (JKeyModifiers)PreferenceManager.Database.CopyToClipboardKeyModifier);
            JHotKeyManager.Instance.HotKeyPressed += new EventHandler<JHotKeyEventArgs>(HotKeyManager_HotKeyPressed);
        }

        private void ColorValue_ButtonClick(object sender, EventArgs e)
        {
            int index = PaletteSelector.SelectedIndex;
            if (index > -1)
            {
                if (Regex.Match(ColorValue.Text, "^#(?:[0-9a-fA-F]{3}){1,2}$").Success && index > -1)
                {
                    var c = ColorTranslator.FromHtml(ColorValue.Text);
                    jScreenColorPicker1.Color = c;
                }
            }
        }

        private void SaveColor_BTN(object sender, EventArgs e)
        {
            int index = PaletteSelector.SelectedIndex;
            if (index > -1)
            {
                bool exist = false;
                var c = Color.FromArgb(jScreenColorPicker1.Color.ToArgb());
                foreach (PaletteItem p in jColorPalette1.PaletteData)
                {
                    if (p.Color.Equals(c))
                    {
                        exist = true;
                        break;
                    }
                }
                if (exist)
                {
                    JMessageBox.Show(this, "You already have this color.");
                    return;
                }
                jColorPalette1.AddItem(ColorTranslator.ToHtml(c));
                DatabaseManager.SetPaletteItems(index, jColorPalette1.PaletteData);
            }
        }

        int lastSElected = -1;
        private void JComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = PaletteSelector.SelectedIndex;
            if (index > -1)
            {
                if (lastSElected == index) return;
                lastSElected = index;
                jColorPalette1.PaletteData = DatabaseManager.GetPalette(index);
            }
        }

        private void OpenSettings_BTN(object sender, EventArgs e)
        {
            JHotKeyManager.Instance.UnregisterHotKey(PreferenceManager.Database.ScreenCopyColorKey, PreferenceManager.Database.ScreenCopyColorKeyModifier);
            JHotKeyManager.Instance.UnregisterHotKey(PreferenceManager.Database.CopyToClipboardKey, PreferenceManager.Database.CopyToClipboardKeyModifier);
            JHotKeyManager.Instance.HotKeyPressed -= new EventHandler<JHotKeyEventArgs>(HotKeyManager_HotKeyPressed);
            Settings set = new Settings
            {
                StartPosition = FormStartPosition.CenterParent
            };
            DialogResult settings = set.ShowDialog(this);
            if (settings == DialogResult.OK)
            {
                SetupHotyKeys();
                JColorStyle color = PreferenceManager.Database.ThemeColor;
                JThemeStyle theme = PreferenceManager.Database.Theme;
                this.SetStyle(color, theme, 255);
                jColorPalette1.SetColorItemSize(PreferenceManager.Database.ColorSize);
                CopyToClipboard(jColorEditor1.Color);
                this.TopMost = PreferenceManager.Database.StayOnTop;
            }
        }

        private void AddNewPalette_BTN(object sender, EventArgs e)
        {
            DialogResult dialog = new AddPalette().ShowDialog(this);
            if (dialog == DialogResult.OK)
            {
                if (AddPalette.ResultText.Length > 0)
                {
                    PaletteCategory n = new PaletteCategory
                    {
                        DbName = AddPalette.ResultText,
                        data = new PaletteItem[0]
                    };
                    DatabaseManager.AddPalette(n);
                    AddPalette.ResultText = "";
                    PaletteSelector.Items.Add(n.DbName);

                }
            }
        }

        private void DeletePalette_BTN(object sender, EventArgs e)
        {
            int selectedIndex = PaletteSelector.SelectedIndex;
            if (selectedIndex > -1)
            {
                var name = PaletteSelector.Items[selectedIndex].ToString();
                DatabaseManager.DeletePalette(selectedIndex);
                PaletteSelector.Items.RemoveAt(selectedIndex);
                try
                {
                    PaletteSelector.SelectedIndex = 0;
                }
                catch { }
                JMessageBox.Show(this, "Deleted " + name);
            }
        }

        private void Form1_OnWindowMinimized(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                this.ShowInTaskbar = false;
        }
        private void MainForm_OnWindowMaximized(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
                this.ShowInTaskbar = true;
        }
        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Focus();
        }

        private void RenamePalette_BTN(object sender, EventArgs e)
        {
            int selectedIndex = PaletteSelector.SelectedIndex;
            if (selectedIndex > -1)
            {
                DialogResult dialog = new RenamePalette().ShowDialog(this);
                if (dialog == DialogResult.OK)
                {
                    if (RenamePalette.ResultText.Length > 0)
                    {
                        DatabaseManager.RenamePalette(selectedIndex, RenamePalette.ResultText);

                        PaletteSelector.Items.Clear();
                        var d = DatabaseManager.GetPalets();
                        foreach (PaletteCategory ddd in d)
                            PaletteSelector.Items.Add(ddd.DbName);

                        PaletteSelector.Text = RenamePalette.ResultText;
                        PaletteSelector.SelectedIndex = selectedIndex;
                    }
                }
            }
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = this.ShowIcon = true;
            this.Show();
            this.Focus();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettings_BTN(sender, e);
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            try
            {
                Application.Exit();
            }
            catch
            {
                Environment.Exit(0);
            }
        }

        private void JPictureBox6_VisibleChanged(object sender, EventArgs e)
        {
            PictureBox_JHUILogo.Image = Properties.Resources.JHUI_LOGOX;
            PictureBox_JHUILogo.Refresh();
        }
        private void PictureBox_MyLogo_VisibleChanged(object sender, EventArgs e)
        {
            PictureBox_MyLogo.Image = Properties.Resources.jColorPickerLogo;
            PictureBox_MyLogo.Refresh();
        }

        private void JColorPalete1_OnColorAction(object sender, ColorEvent e)
        {
            if (jColorPalette1.Selected != null)
            {
                int selectedIndex = PaletteSelector.SelectedIndex;
                if (selectedIndex > -1)
                {
                    DialogResult dialog = new RenamePalette(e.Item.ColorName).ShowDialog(this);
                    if (dialog == DialogResult.OK)
                    {
                        if (RenamePalette.ResultText.Length > 0)
                        {
                            jColorPalette1.Selected.ColorName = RenamePalette.ResultText;
                            DatabaseManager.SetPaletteItems(selectedIndex, jColorPalette1.PaletteData);
                            jColorPalette1.PaletteData = DatabaseManager.GetPalette(selectedIndex);
                        }
                    }
                }
            }
            else
            {
                JMessageBox.Show(this, "Please select the Palete first.");
            }
        }

        private void JColorPalete1_OnColorDeleted(object sender, JHUI.Controls.ColorEvent e)
        {
            int index = PaletteSelector.SelectedIndex;
            if (index > -1)
            {
                List<PaletteItem> nd = new List<PaletteItem>();
                
                foreach(PaletteItem p in jColorPalette1.PaletteData)
                {
                    if(!p.Color.Equals(e.Item.Color))
                        nd.Add(p);
                }
                DatabaseManager.SetPaletteItems(index, nd.ToArray());
                jColorPalette1.PaletteData = DatabaseManager.GetPalette(index);
            }
        }

        private void JColorPalette_OnColorChanged(object sender, JHUI.Controls.ColorEvent e)
        {
            jColorEditor1.Color = e.Item.Color;
            ColorNow.BackColor = e.Item.Color;
            AddColorImage.BackColor = e.Item.Color;
            CopyToClipboard(e.Item.Color);
        }
        #endregion

        #region GUIDE
        private int Gindex = 0;
        private bool canAnimate = false;
        private float nextTime = 0;
        private void TypText()
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        TypText();
                    }));
                }
                catch { }
                return;
            }
            if (!canAnimate)
                return;
            if (Gindex <= messages.Length - 1)
            {
                Anim Animation = messages[Gindex];

                if (nextTime < Time.time)
                {
                    if (Animation.hide != null)
                    {
                        jAnimator1.BeginUpdate(Animation.hide, true, JAnimation.Leaf);
                        Animation.hide.Visible = false;
                        jAnimator1.EndUpdateSync(Animation.hide);
                    }

                    jAnimator1.BeginUpdate(jLabel1, true);
                    jLabel1.Text = Animation.text;
                    jAnimator1.EndUpdateSync(jLabel1);

                    if (Animation.control != null)
                    {
                        if (Animation.control.Length > 3)
                        {
                            jAnimator1.BeginUpdate(this, true, JAnimation.ScaleAndRotate);
                            foreach (Control control in Animation.control)
                            {
                                control.Visible = true;
                                // control.Refresh();
                            }
                            jAnimator1.EndUpdateSync(this);
                        }
                        else
                        {
                            foreach (Control control in Animation.control)
                            {
                                jAnimator1.BeginUpdate(control, true, Animation.control.Length > 3 ? JAnimation.Transparent : JAnimation.Mosaic);
                                control.Visible = true;
                                jAnimator1.EndUpdateSync(control);
                                control.Refresh();
                            }
                        }
                    }
                    if (Animation.showHeder)
                    {
                        this.Text = AppName;
                    }
                    if (Animation.exit)
                    {
                        canAnimate = false;
                        this.jAnimator1.Dispose();
                        this.ThisAnimator.Dispose();
                        this.Movable = true;
                        this.Invalidate();
                        this.Refresh();
                        jColorPalette1.SetColorItemSize(PreferenceManager.Database.ColorSize);
                    }
                    nextTime = Time.time + Animation.nextAnim;
                    Gindex++;
                }
                else
                {
                    if (nextTime == 0)
                        nextTime = Time.time + Animation.nextAnim;
                }
            }
        }

        #endregion

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                int index = PaletteSelector.SelectedIndex;
                if (index > -1)
                {
                    var text = Clipboard.GetText();
                    if (Regex.Match(text, "^#(?:[0-9a-fA-F]{3}){1,2}$").Success && index > -1)
                    {
                        ColorValue.Text = text;
                        var c = ColorTranslator.FromHtml(text);
                        jScreenColorPicker1.Color = c;
                        jColorEditor1.Color = c;
                        ColorNow.BackColor = c;
                        AddColorImage.BackColor = c;
                    }
                }
            }
        }
    }
}
