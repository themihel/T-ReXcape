﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            // inti components
            InitializeComponent();

            // set map filter
            openFileDialog1.Filter = Config.getMapFileFilter();

            // play soundtrack
            if (Config.getPlayMusic())
            {
                Sound.playSoundtrack();
            }

            // get fullscreen settings
            if (Config.getFullscreen())
            {
                cbFullscreen.Checked = true;
            }

            // get Soundtrack setting
            if (Config.getPlayMusic())
            {
                cbSoundtrack.Checked = true;
            }
        }


        /// <summary>
        /// Opens game editor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMapEditor_Click(object sender, EventArgs e)
        {
            this.Hide();
            Config.setDefaultBlockSize();
            ItemCollection.disposeAllItems();
            GameEditor editor = new GameEditor();
            // when editor closed, close main (StartUp) form to close programm
            editor.FormClosed += (s, args) => this.Close();
            editor.Show();
        }

        /// <summary>
        /// Opens level loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadLevel_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && Util.validateMapFilePath(openFileDialog1.FileName))
            {
                this.Hide();
                Game game = new Game(Config.getFullscreen());
                // when editor closed, close main (StartUp) form to close programm
                game.FormClosed += (s, args) => this.Show();
                game.loadFile(openFileDialog1.FileName);
                try
                {
                    game.Show();
                }
                catch (Exception ex)
                {
                    this.Show();
                    Debug.WriteLine(ex.Message);
                }
            }
        }


        /// <summary>
        /// Exit game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Toogle fullscreen mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFullscreen_CheckedChanged(object sender, EventArgs e)
        {
            // set config
            Config.setFullscreen(((CheckBox)sender).Checked);

            // save config
            Config.saveSettings();
        }

        /// <summary>
        /// Toggle music
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSoundtrack_CheckedChanged(object sender, EventArgs e)
        {
            // set config
            Config.setPlayMusic(((CheckBox)sender).Checked);

            // set music status
            if (((CheckBox)sender).Checked)
            {
                Sound.playSoundtrack();
            }
            else
            {
                Sound.stopSoundtrack();
            }

            // save config
            Config.saveSettings();
        }
    }
}
