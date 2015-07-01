using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        private void StartUp_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (String entry in Properties.Settings.Default.files)
                {
                    if (!Util.validateMapFilePath(entry))
                    {
                        Properties.Settings.Default.files.Remove(entry);
                        continue;
                    }
                    mapStrip.Items.Add(entry);
                }
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }


        /// <summary>
        /// Opens game editor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMapEditor_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Opens level loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadLevel_Click(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// Exit game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
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
        
        private void addNewMapPath(String path)
        {
            if (!Properties.Settings.Default.files.Contains(path))
            {
                Properties.Settings.Default.files.Add(path);
                Properties.Settings.Default.Save();
                mapStrip.Items.Add(path);
            }
        }

        private void mapStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            mapStrip.Close();
            ToolStripItem item = e.ClickedItem;
            String path = "";

            if (item.Tag != null && 
                item.Tag.Equals("browse") && 
                openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }
            else
            {
                path = item.Text;
            }

            if(Util.validateMapFilePath(path)) {
                Game game = new Game(this, Config.getFullscreen());
                // when editor closed, close main (StartUp) form to close programm
                game.FormClosed += (s, args) => this.Show();
                game.loadFile(path);
                addNewMapPath(path);

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

        private void load_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            Panel btn = sender as Panel;
            Point pnt = new Point(0, btn.Height);
            pnt = btn.PointToScreen(pnt);
            mapStrip.Show(pnt);
        }

        private void editor_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            Config.setDefaultBlockSize();
            ItemCollection.disposeAllItems();
            GameEditor editor = new GameEditor();
            // when editor closed, close main (StartUp) form to close programm
            editor.FormClosed += (s, args) => this.Close();
            editor.Show();
        }

        private void exit_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
