namespace jColorPicker
{
    partial class RenamePalette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenamePalette));
            this.jPictureBox5 = new JHUI.Controls.JPictureBox();
            this.jTextBox1 = new JHUI.Controls.JTextBox();
            this.jButton1 = new JHUI.Controls.JButton();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // jPictureBox5
            // 
            this.jPictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jPictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox5.BackgroundImage")));
            this.jPictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox5.Location = new System.Drawing.Point(244, -1);
            this.jPictureBox5.Name = "jPictureBox5";
            this.jPictureBox5.Size = new System.Drawing.Size(25, 25);
            this.jPictureBox5.Style = JHUI.JColorStyle.White;
            this.jPictureBox5.TabIndex = 24;
            this.jPictureBox5.TabStop = false;
            this.jPictureBox5.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox5.Click += new System.EventHandler(this.jPictureBox5_Click);
            // 
            // jTextBox1
            // 
            this.jTextBox1.BorderBottomLineSize = 5;
            this.jTextBox1.BorderColor = System.Drawing.Color.Black;
            this.jTextBox1.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.jTextBox1.CustomButton.Image = null;
            this.jTextBox1.CustomButton.Location = new System.Drawing.Point(232, 1);
            this.jTextBox1.CustomButton.Name = "";
            this.jTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.jTextBox1.CustomButton.Style = JHUI.JColorStyle.White;
            this.jTextBox1.CustomButton.TabIndex = 1;
            this.jTextBox1.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.CustomButton.UseSelectable = true;
            this.jTextBox1.CustomButton.Visible = false;
            this.jTextBox1.DrawBorder = true;
            this.jTextBox1.DrawBorderBottomLine = false;
            this.jTextBox1.Lines = new string[0];
            this.jTextBox1.Location = new System.Drawing.Point(8, 28);
            this.jTextBox1.MaxLength = 32767;
            this.jTextBox1.Name = "jTextBox1";
            this.jTextBox1.PasswordChar = '\0';
            this.jTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jTextBox1.SelectedText = "";
            this.jTextBox1.SelectionLength = 0;
            this.jTextBox1.SelectionStart = 0;
            this.jTextBox1.ShortcutsEnabled = true;
            this.jTextBox1.Size = new System.Drawing.Size(254, 23);
            this.jTextBox1.Style = JHUI.JColorStyle.White;
            this.jTextBox1.TabIndex = 25;
            this.jTextBox1.TextWaterMark = "Enter New Color Name";
            this.jTextBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.UseSelectable = true;
            this.jTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.jTextBox1.TextChanged += new System.EventHandler(this.jTextBox1_TextChanged);
            // 
            // jButton1
            // 
            this.jButton1.Location = new System.Drawing.Point(8, 57);
            this.jButton1.Name = "jButton1";
            this.jButton1.Size = new System.Drawing.Size(254, 23);
            this.jButton1.Style = JHUI.JColorStyle.White;
            this.jButton1.TabIndex = 26;
            this.jButton1.Text = "Save";
            this.jButton1.Theme = JHUI.JThemeStyle.Dark;
            this.jButton1.UseSelectable = true;
            this.jButton1.Click += new System.EventHandler(this.jButton1_Click);
            // 
            // RenamePalette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 90);
            this.ControlBox = false;
            this.Controls.Add(this.jButton1);
            this.Controls.Add(this.jTextBox1);
            this.Controls.Add(this.jPictureBox5);
            this.DisplayHeader = false;
            this.JControlBoxShow = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PalettePalete";
            this.PaddingTop = 0;
            this.PaintTopBorder = false;
            this.Resizable = false;
            this.Text = "AddPalette";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JHUI.Controls.JPictureBox jPictureBox5;
        private JHUI.Controls.JTextBox jTextBox1;
        private JHUI.Controls.JButton jButton1;
    }
}