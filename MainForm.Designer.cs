namespace jColorPicker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            JHUI.JAnimation jAnimation4 = new JHUI.JAnimation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.jScreenColorPicker1 = new JHUI.Controls.ColorPicker.JScreenColorPicker();
            this.ColorNow = new JHUI.Controls.JPictureBox();
            this.SettingsImage = new JHUI.Controls.JPictureBox();
            this.AddColorImage = new JHUI.Controls.JPictureBox();
            this.PaletteSelector = new JHUI.Controls.JComboBox();
            this.jContextMenu2 = new JHUI.Controls.JContextMenu(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewPalette = new JHUI.Controls.JPictureBox();
            this.DeletePalette = new JHUI.Controls.JPictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.jContextMenu3 = new JHUI.Controls.JContextMenu(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.jColorPalette1 = new JHUI.Controls.JColorPalette();
            this.jToolTip1 = new JHUI.Components.JToolTip();
            this.sortImage = new JHUI.Controls.JPictureBox();
            this.PictureBox_JHUILogo = new JHUI.Controls.JPictureBox();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.jColorEditor1 = new JHUI.Controls.ColorPicker.JColorEditor();
            this.PictureBox_MyLogo = new JHUI.Controls.JPictureBox();
            this.ColorValue = new JHUI.Controls.JTextBox();
            this.jLabel2 = new JHUI.Controls.JLabel();
            this.jAnimator1 = new JHUI.JAnimator(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ColorNow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddColorImage)).BeginInit();
            this.jContextMenu2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddNewPalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeletePalette)).BeginInit();
            this.jContextMenu3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sortImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_JHUILogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_MyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // jScreenColorPicker1
            // 
            this.jScreenColorPicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.jScreenColorPicker1.Color = System.Drawing.Color.Empty;
            this.jAnimator1.SetDecoration(this.jScreenColorPicker1, JHUI.DecorationType.None);
            this.jScreenColorPicker1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.jScreenColorPicker1.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.jScreenColorPicker1.Location = new System.Drawing.Point(549, 287);
            this.jScreenColorPicker1.Name = "jScreenColorPicker1";
            this.jScreenColorPicker1.Size = new System.Drawing.Size(90, 90);
            this.jToolTip1.SetToolTip(this.jScreenColorPicker1, "The Color, Automatically Copied to clipboard.");
            this.jScreenColorPicker1.Zoom = 7;
            this.jScreenColorPicker1.ColorChanged += new System.EventHandler(this.JScreenColorPicker1_ColorChanged);
            // 
            // ColorNow
            // 
            this.ColorNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ColorNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.jAnimator1.SetDecoration(this.ColorNow, JHUI.DecorationType.None);
            this.ColorNow.Location = new System.Drawing.Point(13, 287);
            this.ColorNow.Name = "ColorNow";
            this.ColorNow.Size = new System.Drawing.Size(90, 90);
            this.ColorNow.Style = JHUI.JColorStyle.White;
            this.ColorNow.TabIndex = 1;
            this.ColorNow.TabStop = false;
            this.ColorNow.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.ColorNow, "Current Selected Color");
            this.ColorNow.UseCustomBackColor = true;
            // 
            // SettingsImage
            // 
            this.SettingsImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsImage.BackColor = System.Drawing.Color.Transparent;
            this.SettingsImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SettingsImage.BackgroundImage")));
            this.SettingsImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SettingsImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jAnimator1.SetDecoration(this.SettingsImage, JHUI.DecorationType.None);
            this.SettingsImage.Location = new System.Drawing.Point(622, 26);
            this.SettingsImage.Name = "SettingsImage";
            this.SettingsImage.Size = new System.Drawing.Size(25, 25);
            this.SettingsImage.Style = JHUI.JColorStyle.White;
            this.SettingsImage.TabIndex = 13;
            this.SettingsImage.TabStop = false;
            this.SettingsImage.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.SettingsImage, "Open settings");
            this.SettingsImage.UseCustomBackColor = true;
            this.SettingsImage.Click += new System.EventHandler(this.OpenSettings_BTN);
            // 
            // AddColorImage
            // 
            this.AddColorImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddColorImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.AddColorImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddColorImage.BackgroundImage")));
            this.AddColorImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddColorImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jAnimator1.SetDecoration(this.AddColorImage, JHUI.DecorationType.None);
            this.AddColorImage.Location = new System.Drawing.Point(78, 287);
            this.AddColorImage.Name = "AddColorImage";
            this.AddColorImage.Size = new System.Drawing.Size(25, 25);
            this.AddColorImage.Style = JHUI.JColorStyle.White;
            this.AddColorImage.TabIndex = 17;
            this.AddColorImage.TabStop = false;
            this.AddColorImage.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.AddColorImage, "Save color to palette.");
            this.AddColorImage.Click += new System.EventHandler(this.SaveColor_BTN);
            // 
            // PaletteSelector
            // 
            this.PaletteSelector.ContextMenuStrip = this.jContextMenu2;
            this.PaletteSelector.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.jAnimator1.SetDecoration(this.PaletteSelector, JHUI.DecorationType.None);
            this.PaletteSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PaletteSelector.FontSize = JHUI.JComboBoxSize.Small;
            this.PaletteSelector.FormattingEnabled = true;
            this.PaletteSelector.ItemHeight = 19;
            this.PaletteSelector.Location = new System.Drawing.Point(69, 24);
            this.PaletteSelector.Name = "PaletteSelector";
            this.PaletteSelector.Size = new System.Drawing.Size(107, 25);
            this.PaletteSelector.Style = JHUI.JColorStyle.White;
            this.PaletteSelector.TabIndex = 19;
            this.PaletteSelector.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.PaletteSelector, "Select Another Palete");
            this.PaletteSelector.UseSelectable = true;
            this.PaletteSelector.SelectedIndexChanged += new System.EventHandler(this.JComboBox1_SelectedIndexChanged);
            // 
            // jContextMenu2
            // 
            this.jAnimator1.SetDecoration(this.jContextMenu2, JHUI.DecorationType.None);
            this.jContextMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.deleteToolStripMenuItem});
            this.jContextMenu2.Name = "jContextMenu1";
            this.jContextMenu2.Size = new System.Drawing.Size(181, 98);
            this.jContextMenu2.Style = JHUI.JColorStyle.White;
            this.jContextMenu2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::jColorPicker.Properties.Resources.edit_64;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Rename";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.RenamePalette_BTN);
            // 
            // AddNewPalette
            // 
            this.AddNewPalette.BackColor = System.Drawing.Color.Transparent;
            this.AddNewPalette.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddNewPalette.BackgroundImage")));
            this.AddNewPalette.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddNewPalette.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jAnimator1.SetDecoration(this.AddNewPalette, JHUI.DecorationType.None);
            this.AddNewPalette.Location = new System.Drawing.Point(11, 24);
            this.AddNewPalette.Name = "AddNewPalette";
            this.AddNewPalette.Size = new System.Drawing.Size(25, 25);
            this.AddNewPalette.Style = JHUI.JColorStyle.White;
            this.AddNewPalette.TabIndex = 21;
            this.AddNewPalette.TabStop = false;
            this.AddNewPalette.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.AddNewPalette, "Add a new color palette.");
            this.AddNewPalette.Click += new System.EventHandler(this.AddNewPalette_BTN);
            // 
            // DeletePalette
            // 
            this.DeletePalette.BackColor = System.Drawing.Color.Transparent;
            this.DeletePalette.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeletePalette.BackgroundImage")));
            this.DeletePalette.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeletePalette.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jAnimator1.SetDecoration(this.DeletePalette, JHUI.DecorationType.None);
            this.DeletePalette.Location = new System.Drawing.Point(39, 24);
            this.DeletePalette.Name = "DeletePalette";
            this.DeletePalette.Size = new System.Drawing.Size(25, 25);
            this.DeletePalette.Style = JHUI.JColorStyle.White;
            this.DeletePalette.TabIndex = 23;
            this.DeletePalette.TabStop = false;
            this.DeletePalette.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.DeletePalette, "Delete selected color palette");
            this.DeletePalette.Click += new System.EventHandler(this.DeletePalette_BTN);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.jContextMenu3;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "J Color Picker";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // jContextMenu3
            // 
            this.jAnimator1.SetDecoration(this.jContextMenu3, JHUI.DecorationType.None);
            this.jContextMenu3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem2});
            this.jContextMenu3.Name = "jContextMenu1";
            this.jContextMenu3.Size = new System.Drawing.Size(117, 76);
            this.jContextMenu3.Style = JHUI.JColorStyle.White;
            this.jContextMenu3.Theme = JHUI.JThemeStyle.Dark;
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem2.Text = "Exit";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // jColorPalette1
            // 
            this.jColorPalette1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jColorPalette1.Animation = JHUI.AnimationType.Transparent;
            this.jColorPalette1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.jColorPalette1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jAnimator1.SetDecoration(this.jColorPalette1, JHUI.DecorationType.None);
            this.jColorPalette1.ItemBorder = 0;
            this.jColorPalette1.ItemSize = new System.Drawing.Size(104, 110);
            this.jColorPalette1.Location = new System.Drawing.Point(13, 59);
            this.jColorPalette1.Name = "jColorPalette1";
            this.jColorPalette1.PaletteData = null;
            this.jColorPalette1.PaletteItemActionImage = global::jColorPicker.Properties.Resources.pencil_edit_button2;
            this.jColorPalette1.Size = new System.Drawing.Size(637, 222);
            this.jColorPalette1.TabIndex = 47;
            this.jColorPalette1.OnColorChanged += new System.EventHandler<JHUI.Controls.ColorEvent>(this.JColorPalette_OnColorChanged);
            this.jColorPalette1.OnColorDeleted += new System.EventHandler<JHUI.Controls.ColorEvent>(this.JColorPalete1_OnColorDeleted);
            this.jColorPalette1.OnColorAction += new System.EventHandler<JHUI.Controls.ColorEvent>(this.JColorPalete1_OnColorAction);
            // 
            // jToolTip1
            // 
            this.jToolTip1.Style = JHUI.JColorStyle.White;
            this.jToolTip1.StyleManager = null;
            this.jToolTip1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // sortImage
            // 
            this.sortImage.BackColor = System.Drawing.Color.Transparent;
            this.sortImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sortImage.BackgroundImage")));
            this.sortImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sortImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jAnimator1.SetDecoration(this.sortImage, JHUI.DecorationType.None);
            this.sortImage.Location = new System.Drawing.Point(182, 24);
            this.sortImage.Name = "sortImage";
            this.sortImage.Size = new System.Drawing.Size(25, 25);
            this.sortImage.Style = JHUI.JColorStyle.White;
            this.sortImage.TabIndex = 50;
            this.sortImage.TabStop = false;
            this.sortImage.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.sortImage, "Sort palette view.");
            this.sortImage.UseCustomBackColor = true;
            this.sortImage.Click += new System.EventHandler(this.ChangeSotring_BTN);
            // 
            // PictureBox_JHUILogo
            // 
            this.PictureBox_JHUILogo.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox_JHUILogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jAnimator1.SetDecoration(this.PictureBox_JHUILogo, JHUI.DecorationType.None);
            this.PictureBox_JHUILogo.Location = new System.Drawing.Point(281, 109);
            this.PictureBox_JHUILogo.Name = "PictureBox_JHUILogo";
            this.PictureBox_JHUILogo.Size = new System.Drawing.Size(85, 79);
            this.PictureBox_JHUILogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox_JHUILogo.Style = JHUI.JColorStyle.White;
            this.PictureBox_JHUILogo.TabIndex = 31;
            this.PictureBox_JHUILogo.TabStop = false;
            this.PictureBox_JHUILogo.Theme = JHUI.JThemeStyle.Dark;
            this.PictureBox_JHUILogo.VisibleChanged += new System.EventHandler(this.JPictureBox6_VisibleChanged);
            // 
            // jLabel1
            // 
            this.jLabel1.CausesValidation = false;
            this.jAnimator1.SetDecoration(this.jLabel1, JHUI.DecorationType.None);
            this.jLabel1.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel1.Enabled = false;
            this.jLabel1.FontSize = JHUI.JLabelSize.Tall;
            this.jLabel1.ForeColor = System.Drawing.Color.White;
            this.jLabel1.Location = new System.Drawing.Point(0, 24);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(650, 362);
            this.jLabel1.Style = JHUI.JColorStyle.White;
            this.jLabel1.TabIndex = 34;
            this.jLabel1.Text = "Hi!";
            this.jLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            this.jLabel1.UseCustomForeColor = true;
            // 
            // jColorEditor1
            // 
            this.jColorEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jColorEditor1.Color = System.Drawing.Color.BlueViolet;
            this.jAnimator1.SetDecoration(this.jColorEditor1, JHUI.DecorationType.None);
            this.jColorEditor1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jColorEditor1.Location = new System.Drawing.Point(113, 287);
            this.jColorEditor1.Name = "jColorEditor1";
            this.jColorEditor1.RBGASliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.jColorEditor1.ShowColorSpaceLabels = false;
            this.jColorEditor1.ShowHexDropDown = false;
            this.jColorEditor1.ShowHexTextBox = false;
            this.jColorEditor1.Size = new System.Drawing.Size(426, 112);
            this.jColorEditor1.Style = JHUI.JColorStyle.White;
            this.jColorEditor1.TabIndex = 36;
            this.jColorEditor1.Theme = JHUI.JThemeStyle.Dark;
            this.jColorEditor1.UseSelectable = true;
            this.jColorEditor1.ColorChanged += new System.EventHandler(this.JColorEditor1_ColorChanged);
            // 
            // PictureBox_MyLogo
            // 
            this.PictureBox_MyLogo.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox_MyLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jAnimator1.SetDecoration(this.PictureBox_MyLogo, JHUI.DecorationType.None);
            this.PictureBox_MyLogo.Location = new System.Drawing.Point(281, 109);
            this.PictureBox_MyLogo.Name = "PictureBox_MyLogo";
            this.PictureBox_MyLogo.Size = new System.Drawing.Size(85, 79);
            this.PictureBox_MyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox_MyLogo.Style = JHUI.JColorStyle.White;
            this.PictureBox_MyLogo.TabIndex = 40;
            this.PictureBox_MyLogo.TabStop = false;
            this.PictureBox_MyLogo.Theme = JHUI.JThemeStyle.Dark;
            this.PictureBox_MyLogo.VisibleChanged += new System.EventHandler(this.PictureBox_MyLogo_VisibleChanged);
            // 
            // ColorValue
            // 
            this.ColorValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ColorValue.BorderBottomLineSize = 5;
            this.ColorValue.BorderColor = System.Drawing.Color.Black;
            this.ColorValue.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.ColorValue.CustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ColorValue.CustomButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ColorValue.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.ColorValue.CustomButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ColorValue.CustomButton.Location = new System.Drawing.Point(165, 1);
            this.ColorValue.CustomButton.Name = "";
            this.ColorValue.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ColorValue.CustomButton.Style = JHUI.JColorStyle.White;
            this.ColorValue.CustomButton.TabIndex = 1;
            this.ColorValue.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.ColorValue.CustomButton.UseCustomBackColor = true;
            this.ColorValue.CustomButton.UseSelectable = true;
            this.jAnimator1.SetDecoration(this.ColorValue, JHUI.DecorationType.None);
            this.ColorValue.DrawBorder = true;
            this.ColorValue.DrawBorderBottomLine = false;
            this.ColorValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.ColorValue.Lines = new string[0];
            this.ColorValue.Location = new System.Drawing.Point(138, 365);
            this.ColorValue.MaxLength = 32767;
            this.ColorValue.Name = "ColorValue";
            this.ColorValue.PasswordChar = '\0';
            this.ColorValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ColorValue.SelectedText = "";
            this.ColorValue.SelectionLength = 0;
            this.ColorValue.SelectionStart = 0;
            this.ColorValue.ShortcutsEnabled = true;
            this.ColorValue.ShowButton = true;
            this.ColorValue.Size = new System.Drawing.Size(187, 23);
            this.ColorValue.Style = JHUI.JColorStyle.White;
            this.ColorValue.TabIndex = 44;
            this.ColorValue.TextWaterMark = "";
            this.ColorValue.Theme = JHUI.JThemeStyle.Dark;
            this.ColorValue.UseCustomFont = true;
            this.ColorValue.UseSelectable = true;
            this.ColorValue.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ColorValue.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.ColorValue.ButtonClick += new JHUI.Controls.JTextBox.ButClick(this.ColorValue_ButtonClick);
            // 
            // jLabel2
            // 
            this.jLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.jAnimator1.SetDecoration(this.jLabel2, JHUI.DecorationType.None);
            this.jLabel2.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel2.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel2.FontSize = JHUI.JLabelSize.Small;
            this.jLabel2.Location = new System.Drawing.Point(113, 367);
            this.jLabel2.Name = "jLabel2";
            this.jLabel2.Size = new System.Drawing.Size(100, 23);
            this.jLabel2.Style = JHUI.JColorStyle.White;
            this.jLabel2.TabIndex = 46;
            this.jLabel2.Text = "Val:";
            this.jLabel2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jAnimator1
            // 
            this.jAnimator1.AnimationType = JHUI.AnimationType.Transparent;
            this.jAnimator1.Cursor = null;
            jAnimation4.AnimateOnlyDifferences = true;
            jAnimation4.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation4.BlindCoeff")));
            jAnimation4.LeafCoeff = 0F;
            jAnimation4.MaxTime = 1F;
            jAnimation4.MinTime = 0F;
            jAnimation4.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation4.MosaicCoeff")));
            jAnimation4.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("jAnimation4.MosaicShift")));
            jAnimation4.MosaicSize = 0;
            jAnimation4.Padding = new System.Windows.Forms.Padding(0);
            jAnimation4.RotateCoeff = 0F;
            jAnimation4.RotateLimit = 0F;
            jAnimation4.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation4.ScaleCoeff")));
            jAnimation4.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation4.SlideCoeff")));
            jAnimation4.TimeCoeff = 0F;
            jAnimation4.TransparencyCoeff = 1F;
            this.jAnimator1.DefaultAnimation = jAnimation4;
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::jColorPicker.Properties.Resources.Delete_64;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeletePalette_BTN);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::jColorPicker.Properties.Resources.Add_64;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddNewPalette_BTN);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 395);
            this.Controls.Add(this.sortImage);
            this.Controls.Add(this.ColorValue);
            this.Controls.Add(this.jLabel2);
            this.Controls.Add(this.PictureBox_MyLogo);
            this.Controls.Add(this.PictureBox_JHUILogo);
            this.Controls.Add(this.AddColorImage);
            this.Controls.Add(this.jColorEditor1);
            this.Controls.Add(this.ColorNow);
            this.Controls.Add(this.jScreenColorPicker1);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.jColorPalette1);
            this.Controls.Add(this.DeletePalette);
            this.Controls.Add(this.AddNewPalette);
            this.Controls.Add(this.PaletteSelector);
            this.Controls.Add(this.SettingsImage);
            this.jAnimator1.SetDecoration(this, JHUI.DecorationType.None);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.JControlBoxButonSize = new System.Drawing.Size(15, 15);
            this.JControlBoxType = JHUI.Forms.JControlBoxType.CUSTOMIZABLE;
            this.JOrderControlBoxButton1 = JHUI.Forms.JForm.JHUIControlBoxButtons.Close;
            this.JOrderControlBoxButton3 = JHUI.Forms.JForm.JHUIControlBoxButtons.Minimize;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(651, 395);
            this.Name = "MainForm";
            this.ShadowType = JHUI.Forms.JFormShadowType.Flat;
            this.Text = "J Color Picker";
            this.TextAlign = JHUI.Forms.JFormTextAlign.Center;
            this.OnWindowMaximized += new System.EventHandler(this.MainForm_OnWindowMaximized);
            this.OnWindowMinimized += new System.EventHandler(this.Form1_OnWindowMinimized);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ColorNow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddColorImage)).EndInit();
            this.jContextMenu2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddNewPalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeletePalette)).EndInit();
            this.jContextMenu3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sortImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_JHUILogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_MyLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JHUI.Controls.ColorPicker.JScreenColorPicker jScreenColorPicker1;
        private JHUI.Controls.JPictureBox ColorNow;
        private JHUI.Controls.JPictureBox SettingsImage;
        private JHUI.Controls.JPictureBox AddColorImage;
        private JHUI.Controls.JComboBox PaletteSelector;
        private JHUI.Controls.JPictureBox AddNewPalette;
        private JHUI.Controls.JPictureBox DeletePalette;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private JHUI.Controls.JContextMenu jContextMenu2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private JHUI.Controls.JContextMenu jContextMenu3;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private JHUI.Controls.JColorPalette jColorPalette1;
        private JHUI.Components.JToolTip jToolTip1;
        private JHUI.Controls.JPictureBox PictureBox_JHUILogo;
        private JHUI.Controls.JLabel jLabel1;
        private JHUI.JAnimator jAnimator1;
        private JHUI.Controls.ColorPicker.JColorEditor jColorEditor1;
        private JHUI.Controls.JPictureBox PictureBox_MyLogo;
        private JHUI.Controls.JTextBox ColorValue;
        private JHUI.Controls.JLabel jLabel2;
        private JHUI.Controls.JPictureBox sortImage;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

