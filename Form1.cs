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
    public partial class Form1 : JForm
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
        private Keys defaultkey;
        private JKeyModifiers defaultMod;
        private JBehavor ThisAnimator = null;


        #endregion

        #region CONSTRUCTOR
        public Form1()
        {
            
            InitializeComponent();
            defaultkey = Keys.C;
            defaultMod = JKeyModifiers.Alt;
            int a = PreferenceManager.Database.HotKey;
            int b = PreferenceManager.Database.HotKeyModifier;
            if (a != 0)
            {
                defaultkey = (Keys)a;
            }
            if (PreferenceManager.Database.HotKeyModifier != 0)
            {
                defaultMod = (JKeyModifiers)b;
            }
            JHotKeyManager.Instance.RegisterHotKey(defaultkey, defaultMod);
            JHotKeyManager.Instance.HotKeyPressed += new EventHandler<JHotKeyEventArgs>(HotKeyManager_HotKeyPressed);
            if (PreferenceManager.Database.FirstTime || ShowGuide)
            {
                jPictureBox6.Visible = DeletePalette.Visible = AddNewPalette.Visible = SettingsImage.Visible = AddColorImage.Visible = jLink1.Visible = jColorPalette1.Visible = CollorNow.Visible = PaletteSelector.Visible = jTextBox1.Visible = jScreenColorPicker1.Visible = false;
                this.Text = "";
                messages = new Anim[]
                {
                    new Anim( 3, "Hello!"),
                    new Anim( 4, "I am 'J Color Picker'."),
                    new Anim( 4, "I am made using JHUI", new Control[] { jPictureBox6 }),
                    new Anim( 6, "I am a simple utility to help you choose colors anywhere on your screen.",null, jPictureBox6),
                    new Anim( 4, "Let's begin!",null, null),
                    new Anim( 4, "This is the color picker.", new Control[] { jScreenColorPicker1 }, null),
                    new Anim( 10, "Hold down your mouse over the grid to pick a color,",null, null),
                    new Anim( 3, "or you can press ALT + C .",null, null),
                    new Anim( 4, "The color will be displayed here.", new Control[] { CollorNow,jTextBox1 }, null),
                    new Anim( 6, "The color is auto-saved to your clipboard,", null, null),
                    new Anim( 4, "so you can press CTRL + V to paste.", null, null),
                    new Anim( 6, "Put your mouse over the other controls for help", null, null),
                    new Anim( 3f, "Happy Designing!",  new Control[] { DeletePalette, AddNewPalette , SettingsImage, AddColorImage, jLink1, jColorPalette1,PaletteSelector }, null, true),
                    new Anim( 0, "",  null, jLabel1, false, true),
                };
                ThisAnimator = new JBehavor();
                ThisAnimator.InvokeRepeating(TypText, 0.1f);
                PreferenceManager.Database.FirstTime = false;
                PreferenceManager.Save();
                canAnimate = true;
            }
            else
            {
                canAnimate = false;
                jPictureBox6.Visible = jLabel1.Visible = false;
            }
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
                        foreach (PaletteCategory ddd in DatabaseManager.GetPalets())
                            PaletteSelector.Items.Add(ddd.DbName);
                        PaletteSelector.SelectedIndex = 0;
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
                this.Invoke(new MethodInvoker(delegate {
                    SetStyle(style, thme, alpha);
                }));
                return;
            }
            this.components.SetStyle(this, style, thme, alpha);
        }

        private void HotKeyManager_HotKeyPressed(object sender, JHotKeyEventArgs e)
        {
                jScreenColorPicker1.RecordColor();
                Clipboard.SetText(ColorTranslator.ToHtml(jScreenColorPicker1.Color));
        }

        private void jScreenColorPicker1_ColorChanged(object sender, EventArgs e)
        {
            CollorNow.BackColor = jScreenColorPicker1.Color;
            jTextBox1.Text = ColorTranslator.ToHtml(jScreenColorPicker1.Color).ToString();
            Clipboard.SetText(ColorTranslator.ToHtml(jScreenColorPicker1.Color));
        }

        private void jColorPalette_OnColorChanged(object sender, JHUI.Controls.ColorEvent e)
        {
            Clipboard.SetText(ColorTranslator.ToHtml(e.Item.Color));
            jTextBox1.Text = ColorTranslator.ToHtml(e.Item.Color).ToString();
        }


        private void jPictureBox3_Click(object sender, EventArgs e)
        {
            int index = PaletteSelector.SelectedIndex;
            if (Regex.Match(jTextBox1.Text, "^#(?:[0-9a-fA-F]{3}){1,2}$").Success && index > -1)
            {
                jColorPalette1.AddItem(jTextBox1.Text);
                DatabaseManager.SetPaletteItems(index, jColorPalette1.PaleteData);
            }
        }

        private void jComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = PaletteSelector.SelectedIndex;
            if(index > -1)
            {
                jColorPalette1.PaleteData = DatabaseManager.GetPalette(index);
            }
        }

        private void jPictureBox2_Click(object sender, EventArgs e)
        {
            Settings set = new Settings
            {
                StartPosition = FormStartPosition.CenterParent
            };
            DialogResult settings = set.ShowDialog(this);
            if (settings == DialogResult.OK)
            {
                JHotKeyManager.Instance.RegisterHotKey(defaultkey, defaultMod);
                JHotKeyManager.Instance.HotKeyPressed -= new EventHandler<JHotKeyEventArgs>(HotKeyManager_HotKeyPressed);
                int a = PreferenceManager.Database.HotKey;
                int b = PreferenceManager.Database.HotKeyModifier;
                if (a != 0)
                {
                    defaultkey = (Keys)a;
                }
                if (PreferenceManager.Database.HotKeyModifier != 0)
                {
                    defaultMod = (JKeyModifiers)b;
                }
                JHotKeyManager.Instance.RegisterHotKey(defaultkey, defaultMod);
                JHotKeyManager.Instance.HotKeyPressed += new EventHandler<JHotKeyEventArgs>(HotKeyManager_HotKeyPressed);
                JColorStyle color = PreferenceManager.Database.ThemeColor;
                JThemeStyle theme = PreferenceManager.Database.Theme;
                this.SetStyle(color, theme, 255);
                jColorPalette1.SetColorItemSize(PreferenceManager.Database.ColorSize);
            }
        }

        private void jColorPalete1_OnColorDeleted(object sender, JHUI.Controls.ColorEvent e)
        {
            int index = PaletteSelector.SelectedIndex;
            if (index > -1)
            {
                DatabaseManager.SetPaletteItems(index, jColorPalette1.PaleteData);

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
                        data = new PaleteItem[0]
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

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
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
                    }
                }
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Focus();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.StartPosition = FormStartPosition.CenterScreen;
            DialogResult settings = set.ShowDialog(this);
            if (settings == DialogResult.OK)
            {
                JHotKeyManager.Instance.RegisterHotKey(defaultkey, defaultMod);
                JHotKeyManager.Instance.HotKeyPressed -= new EventHandler<JHotKeyEventArgs>(HotKeyManager_HotKeyPressed);
                int a = PreferenceManager.Database.HotKey;
                int b = PreferenceManager.Database.HotKeyModifier;
                if (a != 0)
                {
                    defaultkey = (Keys)a;
                }
                if (PreferenceManager.Database.HotKeyModifier != 0)
                {
                    defaultMod = (JKeyModifiers)b;
                }
                JHotKeyManager.Instance.RegisterHotKey(defaultkey, defaultMod);
                JHotKeyManager.Instance.HotKeyPressed += new EventHandler<JHotKeyEventArgs>(HotKeyManager_HotKeyPressed);
                JColorStyle color = PreferenceManager.Database.ThemeColor;
                JThemeStyle theme = PreferenceManager.Database.Theme;
                this.SetStyle(color, theme, 255);
                jColorPalette1.SetColorItemSize(PreferenceManager.Database.ColorSize);
            }
        }

        private bool isClosing = false;
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            isClosing = true;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(canAnimate && !isClosing)
            {
                e.Cancel = true;
                return;
            }
            e.Cancel = !isClosing;
            WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void jLink1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.jhsoftware.xyz/");
        }
        private void jPictureBox6_VisibleChanged(object sender, EventArgs e)
        {
            jPictureBox6.Image = Properties.Resources.JHUI_LOGOX;
            jPictureBox6.Refresh();
        }

        private void jColorPalete1_OnColorAction(object sender, ColorEvent e)
        {
            if (jColorPalette1.Selected != null)
            {
                int selectedIndex = PaletteSelector.SelectedIndex;
                if (selectedIndex > -1)
                {
                    DialogResult dialog = new RenamePalette().ShowDialog(this);
                    if (dialog == DialogResult.OK)
                    {
                        if (RenamePalette.ResultText.Length > 0)
                        {
                            jColorPalette1.Selected.ColorName = RenamePalette.ResultText;
                            DatabaseManager.SetPaletteItems(selectedIndex, jColorPalette1.PaleteData);
                        }
                    }
                }
            }
            else
            {
                JMessageBox.Show(this, "Please select the Palete first.");
            }
        }
        #endregion

        #region GUIDE
        private int index = 0;
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
            if (index <= messages.Length -1)
            {
                Anim Animation = messages[index];
               
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
                    index++;
                }
                else
                {
                    if (nextTime == 0)
                        nextTime = Time.time + Animation.nextAnim;
                }
            }
        }
        #endregion
    }
}
