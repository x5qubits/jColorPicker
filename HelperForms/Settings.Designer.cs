namespace jColorPicker
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.jGroupBox1 = new JHUI.Controls.JGroupBox();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.jToggle1 = new JHUI.Controls.JToggle();
            this.jColorSize = new JHUI.Controls.JComboBox();
            this.jLabel2 = new JHUI.Controls.JLabel();
            this.jGroupBox2 = new JHUI.Controls.JGroupBox();
            this.jLabel3 = new JHUI.Controls.JLabel();
            this.jTheme = new JHUI.Controls.JComboBox();
            this.sThemeColor = new JHUI.Controls.JComboBox();
            this.jGroupBox3 = new JHUI.Controls.JGroupBox();
            this.jComboBox1 = new JHUI.Controls.JComboBox();
            this.jGroupBox1.SuspendLayout();
            this.jGroupBox2.SuspendLayout();
            this.jGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // jGroupBox1
            // 
            this.jGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.jGroupBox1.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.jGroupBox1.Controls.Add(this.jLabel1);
            this.jGroupBox1.Controls.Add(this.jToggle1);
            this.jGroupBox1.DrawBottomLine = false;
            this.jGroupBox1.DrawShadows = false;
            this.jGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.jGroupBox1.FontSize = JHUI.JLabelSize.Small;
            this.jGroupBox1.FontWeight = JHUI.JLabelWeight.Light;
            this.jGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.jGroupBox1.Location = new System.Drawing.Point(8, 150);
            this.jGroupBox1.Name = "jGroupBox1";
            this.jGroupBox1.PaintDefault = false;
            this.jGroupBox1.Size = new System.Drawing.Size(397, 57);
            this.jGroupBox1.Style = JHUI.JColorStyle.White;
            this.jGroupBox1.StyleManager = null;
            this.jGroupBox1.TabIndex = 3;
            this.jGroupBox1.TabStop = false;
            this.jGroupBox1.Text = "Record Color HotKey : ALT + C";
            this.jGroupBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jGroupBox1.UseStyleColors = false;
            // 
            // jLabel1
            // 
            this.jLabel1.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel1.FontSize = JHUI.JLabelSize.Small;
            this.jLabel1.Location = new System.Drawing.Point(6, 23);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(100, 23);
            this.jLabel1.Style = JHUI.JColorStyle.White;
            this.jLabel1.TabIndex = 1;
            this.jLabel1.Text = "Record New Key:";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jToggle1
            // 
            this.jToggle1.Location = new System.Drawing.Point(322, 22);
            this.jToggle1.Name = "jToggle1";
            this.jToggle1.OffText = "Off";
            this.jToggle1.OnText = "On";
            this.jToggle1.Size = new System.Drawing.Size(69, 24);
            this.jToggle1.Style = JHUI.JColorStyle.White;
            this.jToggle1.TabIndex = 0;
            this.jToggle1.Text = "Off";
            this.jToggle1.Theme = JHUI.JThemeStyle.Dark;
            this.jToggle1.UseSelectable = true;
            // 
            // jColorSize
            // 
            this.jColorSize.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.jColorSize.FontSize = JHUI.JComboBoxSize.Small;
            this.jColorSize.FormattingEnabled = true;
            this.jColorSize.ItemHeight = 19;
            this.jColorSize.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Large"});
            this.jColorSize.Location = new System.Drawing.Point(315, 22);
            this.jColorSize.Name = "jColorSize";
            this.jColorSize.Size = new System.Drawing.Size(76, 25);
            this.jColorSize.Style = JHUI.JColorStyle.White;
            this.jColorSize.TabIndex = 5;
            this.jColorSize.Theme = JHUI.JThemeStyle.Dark;
            this.jColorSize.UseSelectable = true;
            this.jColorSize.SelectedIndexChanged += new System.EventHandler(this.jColorSize_SelectedIndexChanged);
            // 
            // jLabel2
            // 
            this.jLabel2.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel2.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel2.FontSize = JHUI.JLabelSize.Small;
            this.jLabel2.Location = new System.Drawing.Point(6, 24);
            this.jLabel2.Name = "jLabel2";
            this.jLabel2.Size = new System.Drawing.Size(100, 23);
            this.jLabel2.Style = JHUI.JColorStyle.White;
            this.jLabel2.TabIndex = 2;
            this.jLabel2.Text = "Color Size:";
            this.jLabel2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jGroupBox2
            // 
            this.jGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.jGroupBox2.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.jGroupBox2.Controls.Add(this.jLabel3);
            this.jGroupBox2.Controls.Add(this.jLabel2);
            this.jGroupBox2.Controls.Add(this.jTheme);
            this.jGroupBox2.Controls.Add(this.jColorSize);
            this.jGroupBox2.Controls.Add(this.sThemeColor);
            this.jGroupBox2.DrawBottomLine = false;
            this.jGroupBox2.DrawShadows = false;
            this.jGroupBox2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.jGroupBox2.FontSize = JHUI.JLabelSize.Small;
            this.jGroupBox2.FontWeight = JHUI.JLabelWeight.Light;
            this.jGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.jGroupBox2.Location = new System.Drawing.Point(8, 213);
            this.jGroupBox2.Name = "jGroupBox2";
            this.jGroupBox2.PaintDefault = false;
            this.jGroupBox2.Size = new System.Drawing.Size(397, 83);
            this.jGroupBox2.Style = JHUI.JColorStyle.White;
            this.jGroupBox2.StyleManager = null;
            this.jGroupBox2.TabIndex = 6;
            this.jGroupBox2.TabStop = false;
            this.jGroupBox2.Text = "Apperance";
            this.jGroupBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jGroupBox2.UseStyleColors = false;
            // 
            // jLabel3
            // 
            this.jLabel3.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel3.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel3.FontSize = JHUI.JLabelSize.Small;
            this.jLabel3.Location = new System.Drawing.Point(6, 55);
            this.jLabel3.Name = "jLabel3";
            this.jLabel3.Size = new System.Drawing.Size(75, 23);
            this.jLabel3.Style = JHUI.JColorStyle.White;
            this.jLabel3.TabIndex = 10;
            this.jLabel3.Text = "Theme:";
            this.jLabel3.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jTheme
            // 
            this.jTheme.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.jTheme.FontSize = JHUI.JComboBoxSize.Small;
            this.jTheme.FormattingEnabled = true;
            this.jTheme.ItemHeight = 19;
            this.jTheme.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.jTheme.Location = new System.Drawing.Point(134, 53);
            this.jTheme.Name = "jTheme";
            this.jTheme.PromptText = "Select Template";
            this.jTheme.Size = new System.Drawing.Size(130, 25);
            this.jTheme.Style = JHUI.JColorStyle.White;
            this.jTheme.TabIndex = 8;
            this.jTheme.Theme = JHUI.JThemeStyle.Dark;
            this.jTheme.UseSelectable = true;
            this.jTheme.SelectedIndexChanged += new System.EventHandler(this.jTheme_SelectedIndexChanged);
            // 
            // sThemeColor
            // 
            this.sThemeColor.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.sThemeColor.FontSize = JHUI.JComboBoxSize.Small;
            this.sThemeColor.FormattingEnabled = true;
            this.sThemeColor.ItemHeight = 19;
            this.sThemeColor.Location = new System.Drawing.Point(270, 53);
            this.sThemeColor.Name = "sThemeColor";
            this.sThemeColor.PromptText = "Select Color";
            this.sThemeColor.Size = new System.Drawing.Size(121, 25);
            this.sThemeColor.Style = JHUI.JColorStyle.White;
            this.sThemeColor.TabIndex = 9;
            this.sThemeColor.Theme = JHUI.JThemeStyle.Dark;
            this.sThemeColor.UseSelectable = true;
            this.sThemeColor.SelectedIndexChanged += new System.EventHandler(this.styleListBox_SelectedIndexChanged);
            // 
            // jGroupBox3
            // 
            this.jGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.jGroupBox3.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.jGroupBox3.Controls.Add(this.jComboBox1);
            this.jGroupBox3.DrawBottomLine = false;
            this.jGroupBox3.DrawShadows = false;
            this.jGroupBox3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.jGroupBox3.FontSize = JHUI.JLabelSize.Small;
            this.jGroupBox3.FontWeight = JHUI.JLabelWeight.Light;
            this.jGroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.jGroupBox3.Location = new System.Drawing.Point(8, 63);
            this.jGroupBox3.Name = "jGroupBox3";
            this.jGroupBox3.PaintDefault = false;
            this.jGroupBox3.Size = new System.Drawing.Size(397, 81);
            this.jGroupBox3.Style = JHUI.JColorStyle.White;
            this.jGroupBox3.StyleManager = null;
            this.jGroupBox3.TabIndex = 4;
            this.jGroupBox3.TabStop = false;
            this.jGroupBox3.Text = "Copy As";
            this.jGroupBox3.Theme = JHUI.JThemeStyle.Dark;
            this.jGroupBox3.UseStyleColors = false;
            // 
            // jComboBox1
            // 
            this.jComboBox1.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.jComboBox1.FontSize = JHUI.JComboBoxSize.Small;
            this.jComboBox1.FormattingEnabled = true;
            this.jComboBox1.ItemHeight = 19;
            this.jComboBox1.Items.AddRange(new object[] {
            "HTML Color Code",
            "RGBA Css",
            "RGB Array",
            "RGBA Array"});
            this.jComboBox1.Location = new System.Drawing.Point(6, 28);
            this.jComboBox1.Name = "jComboBox1";
            this.jComboBox1.PromptText = "Select Template";
            this.jComboBox1.Size = new System.Drawing.Size(391, 25);
            this.jComboBox1.Style = JHUI.JColorStyle.White;
            this.jComboBox1.TabIndex = 9;
            this.jComboBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jComboBox1.UseSelectable = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 310);
            this.Controls.Add(this.jGroupBox3);
            this.Controls.Add(this.jGroupBox2);
            this.Controls.Add(this.jGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Settings_KeyDown);
            this.jGroupBox1.ResumeLayout(false);
            this.jGroupBox2.ResumeLayout(false);
            this.jGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private JHUI.Controls.JGroupBox jGroupBox1;
        private JHUI.Controls.JLabel jLabel1;
        private JHUI.Controls.JToggle jToggle1;
        private JHUI.Controls.JComboBox jColorSize;
        private JHUI.Controls.JLabel jLabel2;
        private JHUI.Controls.JGroupBox jGroupBox2;
        private JHUI.Controls.JLabel jLabel3;
        private JHUI.Controls.JComboBox jTheme;
        private JHUI.Controls.JComboBox sThemeColor;
        private JHUI.Controls.JGroupBox jGroupBox3;
        private JHUI.Controls.JComboBox jComboBox1;
    }
}