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
        /// <summary>
        /// Initialize form and configs
        /// </summary>
        public StartUp()
        {
            // inti components
            InitializeComponent();

            // set map filter
            openFileDialog1.Filter = Config.getMapFileFilter();

            // music config
            if (Config.getPlayMusic())
            {
                // play soundtrack
                Sound.playSoundtrack();
            }
            else
            {
                // user feedback
                soundtrack_panelbutton.BackgroundImage = Util.getToggleBackground(soundtrack_panelbutton.Width, soundtrack_panelbutton.Height); ;
            }

            // fullscreen config
            if (!Config.getFullscreen())
            {
                fullscreen_panelbutton.BackgroundImage = Util.getToggleBackground(fullscreen_panelbutton.Width, fullscreen_panelbutton.Height); ;
            }

            // soundeffect config
            if (!Config.getPlaySoundEffects())
            {
                soundeffect_panelbutton.BackgroundImage = Util.getToggleBackground(soundeffect_panelbutton.Width, soundeffect_panelbutton.Height); ;
            }
        }

        /// <summary>
        /// Load event
        /// </summary>
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
        /// Add new path to map file properties
        /// </summary>
        /// <param name="path">Filepath to map</param>
        private void addNewMapPath(String path)
        {
            if (!Properties.Settings.Default.files.Contains(path))
            {
                Properties.Settings.Default.files.Add(path);
                Properties.Settings.Default.Save();
                mapStrip.Items.Add(path);
            }
        }

        /// <summary>
        /// Load selected map if possible
        /// </summary>
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

        /// <summary>
        /// Open map loader menu strip
        /// </summary>
        private void load_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            Panel btn = sender as Panel;
            Point pnt = new Point(0, btn.Height);
            pnt = btn.PointToScreen(pnt);
            mapStrip.Show(pnt);
        }

        /// <summary>
        /// open editor
        /// </summary>
        private void editor_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            Config.setDefaultBlockSize();
            ItemCollection.disposeAllItems();
            GameEditor editor = new GameEditor();
            // when editor closed, close main (StartUp) form to close programm
            editor.FormClosed += (s, args) => this.Show();
            editor.Show();
        }

        /// <summary>
        /// Exit game
        /// </summary>
        private void exit_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Toggle soundeffects
        /// </summary>
        private void soundeffect_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            // set config depending on state
            if (Config.getPlaySoundEffects())
            {
                // set config
                Config.setPlaySoundEffects(false);
                // user feedback
                soundeffect_panelbutton.BackgroundImage = Util.getToggleBackground(soundeffect_panelbutton.Width, soundeffect_panelbutton.Height); ;
            }
            else
            {
                // set config
                Config.setPlaySoundEffects(true);
                // user feedback
                soundeffect_panelbutton.BackgroundImage = null;
            }

            // save config
            Config.saveSettings();
        }

        /// <summary>
        /// toggle soundtrack
        /// </summary>
        private void soundtrack_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            // set config depending on current state
            if (Config.getPlayMusic())
            {
                // set config
                Config.setPlayMusic(false);
                // stop music
                Sound.stopSoundtrack();
                // user feedback
                soundtrack_panelbutton.BackgroundImage = Util.getToggleBackground(soundtrack_panelbutton.Width, soundtrack_panelbutton.Height); ;
            }
            else
            {
                // set config
                Config.setPlayMusic(true);
                // start music
                Sound.playSoundtrack();
                // user feedback
                soundtrack_panelbutton.BackgroundImage = null;
            }

            // save config
            Config.saveSettings();
        }

        /// <summary>
        /// toggle fullscreen
        /// </summary>
        private void fullscreen_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            // set config depending on current state
            if (Config.getFullscreen())
            {
                // set config
                Config.setFullscreen(false);
                // user feedback
                fullscreen_panelbutton.BackgroundImage = Util.getToggleBackground(fullscreen_panelbutton.Width, fullscreen_panelbutton.Height); ;
            }
            else
            {
                // set config
                Config.setFullscreen(true);
                // user feedback
                fullscreen_panelbutton.BackgroundImage = null;
            }

            // save config
            Config.saveSettings();
        }

        /// <summary>
        /// Form activated / renew setting toggles (catch ingame changes)
        /// </summary>
        private void StartUp_Activated(object sender, EventArgs e)
        {
            // music config
            if (!Config.getPlayMusic())
            {
                // user feedback
                soundtrack_panelbutton.BackgroundImage = Util.getToggleBackground(soundtrack_panelbutton.Width, soundtrack_panelbutton.Height); ;
            }

            // fullscreen config
            if (!Config.getFullscreen())
            {
                fullscreen_panelbutton.BackgroundImage = Util.getToggleBackground(fullscreen_panelbutton.Width, fullscreen_panelbutton.Height); ;
            }

            // soundeffect config
            if (!Config.getPlaySoundEffects())
            {
                soundeffect_panelbutton.BackgroundImage = Util.getToggleBackground(soundeffect_panelbutton.Width, soundeffect_panelbutton.Height); ;
            }
        }

        private void credits_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            Credits credits = new Credits();
            credits.ShowDialog();
        }
    }
}
