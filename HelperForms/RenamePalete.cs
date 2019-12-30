﻿using JHUI.Forms;
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
    public partial class RenamePalette : JForm
    {
        public static string ResultText = "";
        public RenamePalette()
        {
            InitializeComponent();
        }
        public RenamePalette(string value)
        {
            InitializeComponent();
            this.jTextBox1.Text = value;
        }
        private void jButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void jPictureBox5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void jTextBox1_TextChanged(object sender, EventArgs e)
        {
            ResultText = jTextBox1.Text;
        }
    }
}
