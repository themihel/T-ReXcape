using System;
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
                game.Show();
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
            Config.setFullscreen(((CheckBox)sender).Checked);
            Config.saveSettings();
        }
    }
}
