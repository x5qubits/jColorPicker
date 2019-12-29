namespace JHUICOLORPICKER
{
    partial class Form1
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
            JHUI.JAnimation jAnimation1 = new JHUI.JAnimation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.jScreenColorPicker1 = new JHUI.Controls.ColorPicker.JScreenColorPicker();
            this.CollorNow = new JHUI.Controls.JPictureBox();
            this.SettingsImage = new JHUI.Controls.JPictureBox();
            this.AddColorImage = new JHUI.Controls.JPictureBox();
            this.jTextBox1 = new JHUI.Controls.JTextBox();
            this.PaleteSelector = new JHUI.Controls.JComboBox();
            this.jContextMenu2 = new JHUI.Controls.JContextMenu(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewPalete = new JHUI.Controls.JPictureBox();
            this.DeletePalete = new JHUI.Controls.JPictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.jContextMenu3 = new JHUI.Controls.JContextMenu(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.jColorPalete1 = new JHUI.Controls.JColorPalete();
            this.jToolTip1 = new JHUI.Components.JToolTip();
            this.jLink1 = new JHUI.Controls.JLink();
            this.jPictureBox6 = new JHUI.Controls.JPictureBox();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.jAnimator1 = new JHUI.JAnimator(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CollorNow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddColorImage)).BeginInit();
            this.jContextMenu2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddNewPalete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeletePalete)).BeginInit();
            this.jContextMenu3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // jScreenColorPicker1
            // 
            this.jScreenColorPicker1.Color = System.Drawing.Color.Empty;
            this.jAnimator1.SetDecoration(this.jScreenColorPicker1, JHUI.DecorationType.None);
            this.jScreenColorPicker1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.jScreenColorPicker1.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.jScreenColorPicker1.Location = new System.Drawing.Point(32, 167);
            this.jScreenColorPicker1.Name = "jScreenColorPicker1";
            this.jScreenColorPicker1.Size = new System.Drawing.Size(100, 100);
            this.jToolTip1.SetToolTip(this.jScreenColorPicker1, "The Color, Automatically Copied to clipboard.");
            this.jScreenColorPicker1.Zoom = 7;
            this.jScreenColorPicker1.ColorChanged += new System.EventHandler(this.jScreenColorPicker1_ColorChanged);
            // 
            // CollorNow
            // 
            this.CollorNow.BackColor = System.Drawing.Color.Maroon;
            this.jAnimator1.SetDecoration(this.CollorNow, JHUI.DecorationType.None);
            this.CollorNow.Location = new System.Drawing.Point(32, 63);
            this.CollorNow.Name = "CollorNow";
            this.CollorNow.Size = new System.Drawing.Size(100, 100);
            this.CollorNow.Style = JHUI.JColorStyle.White;
            this.CollorNow.TabIndex = 1;
            this.CollorNow.TabStop = false;
            this.CollorNow.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.CollorNow, "Current Selected Color");
            this.CollorNow.UseCustomBackColor = true;
            // 
            // SettingsImage
            // 
            this.SettingsImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SettingsImage.BackColor = System.Drawing.Color.Transparent;
            this.SettingsImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SettingsImage.BackgroundImage")));
            this.SettingsImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jAnimator1.SetDecoration(this.SettingsImage, JHUI.DecorationType.None);
            this.SettingsImage.Location = new System.Drawing.Point(167, 273);
            this.SettingsImage.Name = "SettingsImage";
            this.SettingsImage.Size = new System.Drawing.Size(25, 25);
            this.SettingsImage.Style = JHUI.JColorStyle.White;
            this.SettingsImage.TabIndex = 13;
            this.SettingsImage.TabStop = false;
            this.SettingsImage.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.SettingsImage, "Open Settings");
            this.SettingsImage.UseCustomBackColor = true;
            this.SettingsImage.Click += new System.EventHandler(this.jPictureBox2_Click);
            // 
            // AddColorImage
            // 
            this.AddColorImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddColorImage.BackColor = System.Drawing.Color.Transparent;
            this.AddColorImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddColorImage.BackgroundImage")));
            this.AddColorImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jAnimator1.SetDecoration(this.AddColorImage, JHUI.DecorationType.None);
            this.AddColorImage.Location = new System.Drawing.Point(139, 273);
            this.AddColorImage.Name = "AddColorImage";
            this.AddColorImage.Size = new System.Drawing.Size(25, 25);
            this.AddColorImage.Style = JHUI.JColorStyle.White;
            this.AddColorImage.TabIndex = 17;
            this.AddColorImage.TabStop = false;
            this.AddColorImage.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.AddColorImage, "Save Color");
            this.AddColorImage.Click += new System.EventHandler(this.jPictureBox3_Click);
            // 
            // jTextBox1
            // 
            this.jTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.jTextBox1.BorderBottomLineSize = 5;
            this.jTextBox1.BorderColor = System.Drawing.Color.White;
            this.jTextBox1.BottomLineOffset = new System.Drawing.Size(3, 0);
            // 
            // 
            // 
            this.jTextBox1.CustomButton.Image = null;
            this.jTextBox1.CustomButton.Location = new System.Drawing.Point(79, 1);
            this.jTextBox1.CustomButton.Name = "";
            this.jTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.jTextBox1.CustomButton.Style = JHUI.JColorStyle.White;
            this.jTextBox1.CustomButton.TabIndex = 1;
            this.jTextBox1.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.CustomButton.UseSelectable = true;
            this.jTextBox1.CustomButton.Visible = false;
            this.jAnimator1.SetDecoration(this.jTextBox1, JHUI.DecorationType.None);
            this.jTextBox1.DrawBorder = false;
            this.jTextBox1.DrawBorderBottomLine = true;
            this.jTextBox1.Enabled = false;
            this.jTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jTextBox1.Lines = new string[0];
            this.jTextBox1.Location = new System.Drawing.Point(31, 273);
            this.jTextBox1.MaxLength = 32767;
            this.jTextBox1.Name = "jTextBox1";
            this.jTextBox1.PasswordChar = '\0';
            this.jTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jTextBox1.SelectedText = "";
            this.jTextBox1.SelectionLength = 0;
            this.jTextBox1.SelectionStart = 0;
            this.jTextBox1.ShortcutsEnabled = true;
            this.jTextBox1.Size = new System.Drawing.Size(101, 23);
            this.jTextBox1.Style = JHUI.JColorStyle.White;
            this.jTextBox1.TabIndex = 15;
            this.jTextBox1.TextWaterMark = "The Color";
            this.jTextBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.UseCustomBackColor = true;
            this.jTextBox1.UseCustomBorderColor = true;
            this.jTextBox1.UseCustomForeColor = true;
            this.jTextBox1.UseSelectable = true;
            this.jTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // PaleteSelector
            // 
            this.PaleteSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PaleteSelector.ContextMenuStrip = this.jContextMenu2;
            this.PaleteSelector.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.jAnimator1.SetDecoration(this.PaleteSelector, JHUI.DecorationType.None);
            this.PaleteSelector.FontSize = JHUI.JComboBoxSize.Small;
            this.PaleteSelector.FormattingEnabled = true;
            this.PaleteSelector.ItemHeight = 19;
            this.PaleteSelector.Location = new System.Drawing.Point(553, 32);
            this.PaleteSelector.Name = "PaleteSelector";
            this.PaleteSelector.Size = new System.Drawing.Size(107, 25);
            this.PaleteSelector.Style = JHUI.JColorStyle.White;
            this.PaleteSelector.TabIndex = 19;
            this.PaleteSelector.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.PaleteSelector, "Select Another Palete");
            this.PaleteSelector.UseSelectable = true;
            this.PaleteSelector.SelectedIndexChanged += new System.EventHandler(this.jComboBox1_SelectedIndexChanged);
            // 
            // jContextMenu2
            // 
            this.jAnimator1.SetDecoration(this.jContextMenu2, JHUI.DecorationType.None);
            this.jContextMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.jContextMenu2.Name = "jContextMenu1";
            this.jContextMenu2.Size = new System.Drawing.Size(151, 26);
            this.jContextMenu2.Style = JHUI.JColorStyle.White;
            this.jContextMenu2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::JHUICOLORPICKER.Properties.Resources.Edit;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem1.Text = "Change Name";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // AddNewPalete
            // 
            this.AddNewPalete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNewPalete.BackColor = System.Drawing.Color.Transparent;
            this.AddNewPalete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddNewPalete.BackgroundImage")));
            this.AddNewPalete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jAnimator1.SetDecoration(this.AddNewPalete, JHUI.DecorationType.None);
            this.AddNewPalete.Location = new System.Drawing.Point(491, 32);
            this.AddNewPalete.Name = "AddNewPalete";
            this.AddNewPalete.Size = new System.Drawing.Size(25, 25);
            this.AddNewPalete.Style = JHUI.JColorStyle.White;
            this.AddNewPalete.TabIndex = 21;
            this.AddNewPalete.TabStop = false;
            this.AddNewPalete.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.AddNewPalete, "Add New Color Palete");
            this.AddNewPalete.Click += new System.EventHandler(this.jPictureBox4_Click);
            // 
            // DeletePalete
            // 
            this.DeletePalete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeletePalete.BackColor = System.Drawing.Color.Transparent;
            this.DeletePalete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeletePalete.BackgroundImage")));
            this.DeletePalete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jAnimator1.SetDecoration(this.DeletePalete, JHUI.DecorationType.None);
            this.DeletePalete.Location = new System.Drawing.Point(522, 32);
            this.DeletePalete.Name = "DeletePalete";
            this.DeletePalete.Size = new System.Drawing.Size(25, 25);
            this.DeletePalete.Style = JHUI.JColorStyle.White;
            this.DeletePalete.TabIndex = 23;
            this.DeletePalete.TabStop = false;
            this.DeletePalete.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.DeletePalete, "Delete Selected Color Palete");
            this.DeletePalete.Click += new System.EventHandler(this.jPictureBox5_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.jContextMenu3;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "J Color Picker";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
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
            this.showToolStripMenuItem.Image = global::JHUICOLORPICKER.Properties.Resources.View;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::JHUICOLORPICKER.Properties.Resources.Tools2;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::JHUICOLORPICKER.Properties.Resources.Exit;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem2.Text = "Exit";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // jColorPalete1
            // 
            this.jColorPalete1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jColorPalete1.Animation = JHUI.AnimationType.Transparent;
            this.jColorPalete1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.jAnimator1.SetDecoration(this.jColorPalete1, JHUI.DecorationType.None);
            this.jColorPalete1.ItemBorder = 0;
            this.jColorPalete1.ItemSize = new System.Drawing.Size(104, 110);
            this.jColorPalete1.Location = new System.Drawing.Point(139, 63);
            this.jColorPalete1.Name = "jColorPalete1";
            this.jColorPalete1.PaleteData = null;
            this.jColorPalete1.PaleteItemActionImage = ((System.Drawing.Image)(resources.GetObject("jColorPalete1.PaleteItemActionImage")));
            this.jColorPalete1.Size = new System.Drawing.Size(532, 203);
            this.jColorPalete1.TabIndex = 27;
            this.jColorPalete1.OnColorChanged += new System.EventHandler<JHUI.Controls.ColorEvent>(this.jColorPalete1_OnColorChanged);
            this.jColorPalete1.OnColorDeleted += new System.EventHandler<JHUI.Controls.ColorEvent>(this.jColorPalete1_OnColorDeleted);
            this.jColorPalete1.OnColorAction += new System.EventHandler<JHUI.Controls.ColorEvent>(this.jColorPalete1_OnColorAction);
            // 
            // jToolTip1
            // 
            this.jToolTip1.Style = JHUI.JColorStyle.White;
            this.jToolTip1.StyleManager = null;
            this.jToolTip1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jLink1
            // 
            this.jLink1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.jAnimator1.SetDecoration(this.jLink1, JHUI.DecorationType.None);
            this.jLink1.Location = new System.Drawing.Point(574, 275);
            this.jLink1.Name = "jLink1";
            this.jLink1.Size = new System.Drawing.Size(75, 23);
            this.jLink1.Style = JHUI.JColorStyle.White;
            this.jLink1.TabIndex = 30;
            this.jLink1.Text = "@Maker";
            this.jLink1.Theme = JHUI.JThemeStyle.Dark;
            this.jLink1.UseSelectable = true;
            this.jLink1.UseVisualStyleBackColor = true;
            this.jLink1.Click += new System.EventHandler(this.jLink1_Click);
            // 
            // jPictureBox6
            // 
            this.jPictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jAnimator1.SetDecoration(this.jPictureBox6, JHUI.DecorationType.None);
            this.jPictureBox6.Location = new System.Drawing.Point(295, 72);
            this.jPictureBox6.Name = "jPictureBox6";
            this.jPictureBox6.Size = new System.Drawing.Size(85, 79);
            this.jPictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.jPictureBox6.Style = JHUI.JColorStyle.White;
            this.jPictureBox6.TabIndex = 31;
            this.jPictureBox6.TabStop = false;
            this.jPictureBox6.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox6.VisibleChanged += new System.EventHandler(this.jPictureBox6_VisibleChanged);
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
            this.jLabel1.Location = new System.Drawing.Point(1, 63);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(670, 204);
            this.jLabel1.Style = JHUI.JColorStyle.White;
            this.jLabel1.TabIndex = 34;
            this.jLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            this.jLabel1.UseCustomForeColor = true;
            // 
            // jAnimator1
            // 
            this.jAnimator1.AnimationType = JHUI.AnimationType.Transparent;
            this.jAnimator1.Cursor = null;
            jAnimation1.AnimateOnlyDifferences = true;
            jAnimation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.BlindCoeff")));
            jAnimation1.LeafCoeff = 0F;
            jAnimation1.MaxTime = 1F;
            jAnimation1.MinTime = 0F;
            jAnimation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.MosaicCoeff")));
            jAnimation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.MosaicShift")));
            jAnimation1.MosaicSize = 0;
            jAnimation1.Padding = new System.Windows.Forms.Padding(0);
            jAnimation1.RotateCoeff = 0F;
            jAnimation1.RotateLimit = 0F;
            jAnimation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.ScaleCoeff")));
            jAnimation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.SlideCoeff")));
            jAnimation1.TimeCoeff = 0F;
            jAnimation1.TransparencyCoeff = 1F;
            this.jAnimator1.DefaultAnimation = jAnimation1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 315);
            this.Controls.Add(this.jPictureBox6);
            this.Controls.Add(this.CollorNow);
            this.Controls.Add(this.jScreenColorPicker1);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.jLink1);
            this.Controls.Add(this.jColorPalete1);
            this.Controls.Add(this.DeletePalete);
            this.Controls.Add(this.AddNewPalete);
            this.Controls.Add(this.PaleteSelector);
            this.Controls.Add(this.AddColorImage);
            this.Controls.Add(this.jTextBox1);
            this.Controls.Add(this.SettingsImage);
            this.jAnimator1.SetDecoration(this, JHUI.DecorationType.None);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(672, 315);
            this.Name = "Form1";
            this.ShadowType = JHUI.Forms.JFormShadowType.Flat;
            this.Text = "J Color Picker";
            this.OnWindowMinimized += new System.EventHandler(this.Form1_OnWindowMinimized);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.CollorNow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddColorImage)).EndInit();
            this.jContextMenu2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddNewPalete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeletePalete)).EndInit();
            this.jContextMenu3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JHUI.Controls.ColorPicker.JScreenColorPicker jScreenColorPicker1;
        private JHUI.Controls.JPictureBox CollorNow;
        private JHUI.Controls.JPictureBox SettingsImage;
        private JHUI.Controls.JPictureBox AddColorImage;
        private JHUI.Controls.JTextBox jTextBox1;
        private JHUI.Controls.JComboBox PaleteSelector;
        private JHUI.Controls.JPictureBox AddNewPalete;
        private JHUI.Controls.JPictureBox DeletePalete;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private JHUI.Controls.JContextMenu jContextMenu2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private JHUI.Controls.JContextMenu jContextMenu3;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private JHUI.Controls.JColorPalete jColorPalete1;
        private JHUI.Components.JToolTip jToolTip1;
        private JHUI.Controls.JLink jLink1;
        private JHUI.Controls.JPictureBox jPictureBox6;
        private JHUI.Controls.JLabel jLabel1;
        private JHUI.JAnimator jAnimator1;
    }
}

