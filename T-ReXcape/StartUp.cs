﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T_ReXcape
{
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();
            openFileDialog1.Filter = Config.getMapFileFilter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Config.setDefaultBlockSize();
            ItemCollection.disposeAllItems();
            GameEditor editor = new GameEditor();
            // when editor closed, close main (StartUp) form to close programm
            editor.FormClosed += (s, args) => this.Close();
            editor.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && Util.validateMapFilePath(openFileDialog1.FileName))
            {
                this.Hide();
                Game game = new Game(Config.getFullscreen());
                // when editor closed, close main (StartUp) form to close programm
                game.FormClosed += (s, args) => this.Show();
                game.loadFile(openFileDialog1.FileName);
                game.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void goFullscreenCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = sender as CheckBox;
            Config.setFullscreen(check.Checked);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }
    }
}
