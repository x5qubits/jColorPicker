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

namespace JHUICOLORPICKER
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
        private string AppName = "J Color Picker";
        private bool ShowGuide = false;
        #region VARS
        private Dictionary<int, PaleteCategory> database = new Dictionary<int, PaleteCategory>();
        private string databasePath = "";
        private Keys defaultkey;
        private JKeyModifiers defaultMod;
        private JBehavor ThisAnimator = null;
        [Serializable]
        public class PaleteCategory
        {
            public PaleteItem[] data { get; set; }
            public string DbName { get; set; }
        }
        #endregion

        #region CONSTRUCTOR
        public Form1()
        {
            databasePath = Path.Combine(Application.StartupPath, "BinaryDatabase.bin");
            InitializeComponent();
            defaultkey = Keys.C;
            defaultMod = JKeyModifiers.Alt;
            int a = Properties.Settings.Default.HotKey;
            int b = Properties.Settings.Default.HotKeyModifier;
            if (a != 0)
            {
                defaultkey = (Keys)a;
            }
            if (Properties.Settings.Default.HotKeyModifier != 0)
            {
                defaultMod = (JKeyModifiers)b;
            }
            JHotKeyManager.Instance.RegisterHotKey(defaultkey, defaultMod);
            JHotKeyManager.Instance.HotKeyPressed += new EventHandler<JHotKeyEventArgs>(HotKeyManager_HotKeyPressed);
            if (Properties.Settings.Default.FirstTime || ShowGuide)
            {
                jPictureBox6.Visible = DeletePalete.Visible = AddNewPalete.Visible = SettingsImage.Visible = AddColorImage.Visible = jLink1.Visible = jColorPalete1.Visible = CollorNow.Visible = PaleteSelector.Visible = jTextBox1.Visible = jScreenColorPicker1.Visible = false;
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
                    new Anim( 3f, "Happy Designing!",  new Control[] { DeletePalete, AddNewPalete , SettingsImage, AddColorImage, jLink1, jColorPalete1,PaleteSelector }, null, true),
                    new Anim( 0, "",  null, jLabel1, false, true),
                };
                ThisAnimator = new JBehavor();
                ThisAnimator.InvokeRepeating(TypText, 0.1f);
                Properties.Settings.Default.FirstTime = false;
                Properties.Settings.Default.Save();
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

                if (File.Exists(databasePath))
                {
                    try
                    {
                        PaleteSelector.Invoke(new MethodInvoker(delegate
                        {
                            PaleteSelector.Items.Clear();
                            database = (Dictionary<int, PaleteCategory>)ObjectSerialize.DeSerialize(File.ReadAllBytes(databasePath));
                            foreach (PaleteCategory ddd in database.Values)
                                PaleteSelector.Items.Add(ddd.DbName);

                            PaleteSelector.SelectedIndex = 0;
                        }));
                    }
                    catch { loadDefault(); }
                }
                else
                {
                    loadDefault();
                }
            }).Start();
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            JColorStyle color = ((JColorStyle)Properties.Settings.Default.ThemeColor);
            JThemeStyle theme = ((JThemeStyle)Properties.Settings.Default.Theme);
            this.SetStyle(color, theme, 255);
            jColorPalete1.SetColorItemSize(Properties.Settings.Default.ColorSize);
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

        private void jColorPalete1_OnColorChanged(object sender, JHUI.Controls.ColorEvent e)
        {
            Clipboard.SetText(ColorTranslator.ToHtml(e.Item.Color));
            jTextBox1.Text = ColorTranslator.ToHtml(e.Item.Color).ToString();
        }

        private void loadDefault()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    loadDefault();
                }));
                return;
            }
            database = new Dictionary<int, PaleteCategory>();
            List<PaleteItem> data = new List<PaleteItem>();
            data.Add(new PaleteItem("Turquoise", ColorTranslator.FromHtml("#1abc9c")));
            data.Add(new PaleteItem("Elmerald", ColorTranslator.FromHtml("#2ecc71")));
            data.Add(new PaleteItem("Peter River", ColorTranslator.FromHtml("#3498db")));
            data.Add(new PaleteItem("Amethyst", ColorTranslator.FromHtml("#9b59b6")));
            data.Add(new PaleteItem("Wet Asphalt", ColorTranslator.FromHtml("#34495e")));
            data.Add(new PaleteItem("Grean Sea", ColorTranslator.FromHtml("#16a085")));
            data.Add(new PaleteItem("Nephritis", ColorTranslator.FromHtml("#27ae60")));
            data.Add(new PaleteItem("Belize Hole", ColorTranslator.FromHtml("#2980b9")));
            data.Add(new PaleteItem("Wisteria", ColorTranslator.FromHtml("#8e44ad")));
            data.Add(new PaleteItem("Midnight Blue", ColorTranslator.FromHtml("#2c3e50")));
            data.Add(new PaleteItem("Sun Flower", ColorTranslator.FromHtml("#f1c40f")));
            data.Add(new PaleteItem("Carrot", ColorTranslator.FromHtml("#e67e22")));
            data.Add(new PaleteItem("Alizarin", ColorTranslator.FromHtml("#e74c3c")));
            data.Add(new PaleteItem("Clouds", ColorTranslator.FromHtml("#ecf0f1")));
            data.Add(new PaleteItem("Concrete", ColorTranslator.FromHtml("#95a5a6")));
            data.Add(new PaleteItem("Oranage", ColorTranslator.FromHtml("#f39c12")));
            data.Add(new PaleteItem("Pumpkin", ColorTranslator.FromHtml("#d35400")));
            data.Add(new PaleteItem("Pomegranate", ColorTranslator.FromHtml("#c0392b")));
            data.Add(new PaleteItem("Silver", ColorTranslator.FromHtml("#bdc3c7")));
            data.Add(new PaleteItem("Asbestos", ColorTranslator.FromHtml("#7f8c8d")));
            PaleteCategory da = new PaleteCategory();
            da.DbName = "Default";
            da.data = data.ToArray();
            jColorPalete1.PaleteData = da.data;
            PaleteSelector.Items.Clear();
            PaleteSelector.Items.Add(da.DbName);
            database.Add(0, da);
            PaleteSelector.SelectedIndex = 0;
            saveDB();
        }

        private void saveDB()
        {
            File.WriteAllBytes(databasePath, ObjectSerialize.Serialize(database));
        }

        private void jPictureBox3_Click(object sender, EventArgs e)
        {
            if (Regex.Match(jTextBox1.Text, "^#(?:[0-9a-fA-F]{3}){1,2}$").Success)
            {
                jColorPalete1.AddItem(jTextBox1.Text);
                if (database != null)
                {
                    int selectedIndex = PaleteSelector.SelectedIndex;
                    if (database.ContainsKey(selectedIndex))
                    {
                        database[selectedIndex].data = jColorPalete1.PaleteData;
                    }
                }
                saveDB();
            }
        }

        private void jComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(database != null)
            {
                int selectedIndex = PaleteSelector.SelectedIndex;
                if(database.ContainsKey(selectedIndex))
                {
                    jColorPalete1.PaleteData = database[selectedIndex].data;
                }
            }
        }

        private void jPictureBox2_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.StartPosition = FormStartPosition.CenterParent;
            DialogResult settings = set.ShowDialog(this);
            if (settings == DialogResult.OK)
            {
                JHotKeyManager.Instance.RegisterHotKey(defaultkey, defaultMod);
                JHotKeyManager.Instance.HotKeyPressed -= new EventHandler<JHotKeyEventArgs>(HotKeyManager_HotKeyPressed);
                int a = Properties.Settings.Default.HotKey;
                int b = Properties.Settings.Default.HotKeyModifier;
                if (a != 0)
                {
                    defaultkey = (Keys)a;
                }
                if (Properties.Settings.Default.HotKeyModifier != 0)
                {
                    defaultMod = (JKeyModifiers)b;
                }
                JHotKeyManager.Instance.RegisterHotKey(defaultkey, defaultMod);
                JHotKeyManager.Instance.HotKeyPressed += new EventHandler<JHotKeyEventArgs>(HotKeyManager_HotKeyPressed);
                JColorStyle color = ((JColorStyle)Properties.Settings.Default.ThemeColor);
                JThemeStyle theme = ((JThemeStyle)Properties.Settings.Default.Theme);
                this.SetStyle(color, theme, 255);
                jColorPalete1.SetColorItemSize(Properties.Settings.Default.ColorSize);
            }
        }

        private void jColorPalete1_OnColorDeleted(object sender, JHUI.Controls.ColorEvent e)
        {
            if (database != null)
            {
                int selectedIndex = PaleteSelector.SelectedIndex;
                if (database.ContainsKey(selectedIndex))
                {
                    database[selectedIndex].data = jColorPalete1.PaleteData;
                    saveDB();
                }
            }
           
        }

        private void jPictureBox4_Click(object sender, EventArgs e)
        {
            if (database != null)
            { 
                DialogResult dialog = new AddPalete().ShowDialog(this);
                if (dialog == DialogResult.OK)
                {
                    if (AddPalete.ResultText.Length > 0)
                    {
                        PaleteCategory n = new PaleteCategory();
                        n.DbName = AddPalete.ResultText;
                        n.data = new PaleteItem[0];
                        database.Add(database.Count, n);
                        AddPalete.ResultText = "";
                        PaleteSelector.Items.Add(n.DbName);
                        saveDB();
                    }
                }
            }
        }

        private void jPictureBox5_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                int selectedIndex = PaleteSelector.SelectedIndex;
                if (database.ContainsKey(selectedIndex))
                {
                    string name = database[selectedIndex].DbName;
                    database.Remove(selectedIndex);
                    Dictionary<int, PaleteCategory> clone = new Dictionary<int, PaleteCategory>(database);
                    Dictionary<int, PaleteCategory> newdata = new Dictionary<int, PaleteCategory>();
                    int x = 0;
                    foreach (KeyValuePair<int, PaleteCategory> data in clone)
                    {
                        newdata[x] = data.Value;
                    }
                    database = newdata;
                    saveDB();
                    PaleteSelector.Items.RemoveAt(selectedIndex);
                    try
                    {
                        PaleteSelector.SelectedIndex = 0;
                    }
                    catch { }
                    JMessageBox.Show(this, "Deleted " + name);
                }
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int selectedIndex = PaleteSelector.SelectedIndex;
            if (database.ContainsKey(selectedIndex))
            {
                DialogResult dialog = new RenamePalete().ShowDialog(this);
                if (dialog == DialogResult.OK)
                {
                    if (RenamePalete.ResultText.Length > 0)
                    {
                        database[selectedIndex].DbName = RenamePalete.ResultText;
                        PaleteSelector.Items[selectedIndex] = database[selectedIndex].DbName;
                        saveDB();
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
                int a = Properties.Settings.Default.HotKey;
                int b = Properties.Settings.Default.HotKeyModifier;
                if (a != 0)
                {
                    defaultkey = (Keys)a;
                }
                if (Properties.Settings.Default.HotKeyModifier != 0)
                {
                    defaultMod = (JKeyModifiers)b;
                }
                JHotKeyManager.Instance.RegisterHotKey(defaultkey, defaultMod);
                JHotKeyManager.Instance.HotKeyPressed += new EventHandler<JHotKeyEventArgs>(HotKeyManager_HotKeyPressed);
                JColorStyle color = ((JColorStyle)Properties.Settings.Default.ThemeColor);
                JThemeStyle theme = ((JThemeStyle)Properties.Settings.Default.Theme);
                this.SetStyle(color, theme, 255);
                jColorPalete1.SetColorItemSize(Properties.Settings.Default.ColorSize);
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
            if (jColorPalete1.Selected != null)
            {
                int selectedIndex = PaleteSelector.SelectedIndex;
                if (database.ContainsKey(selectedIndex))
                {
                    DialogResult dialog = new RenamePalete().ShowDialog(this);
                    if (dialog == DialogResult.OK)
                    {
                        if (RenamePalete.ResultText.Length > 0)
                        {
                            jColorPalete1.Selected.ColorName = RenamePalete.ResultText;
                            database[selectedIndex].data = jColorPalete1.PaleteData;
                            saveDB();
                            jColorPalete1.PaleteData = database[selectedIndex].data;
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
                        jColorPalete1.SetColorItemSize(Properties.Settings.Default.ColorSize);
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
