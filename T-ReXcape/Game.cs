using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace T_ReXcape
{
    public partial class Game : Form
    {
        // previous form
        Form formToCloseAfterLoad;
        // Map
        Map map;


        public Game(Form form, bool fullscreen = false)
        {
            formToCloseAfterLoad = form;
            InitializeComponent();
            if (fullscreen)
                goFullscreen();

            // init garbage collector
            GarbageCollector.init(mapPanel, 500);

            // get Soundtrack setting
            if (Config.getPlayMusic())
            {
                //cbSoundtrack.Checked = true;
            }

            // get soundeffect setting
            if (Config.getPlaySoundEffects())
            {
                //cbSoundeffects.Checked = true;
            }
        }

        /// <summary>
        /// sets form in fullscreen mode
        /// </summary>
        public void goFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.TopLevel = true;
        }
        
        /// <summary>
        /// load map and prepare everything
        /// </summary>
        /// <param name="file">filepath and filename</param>
        public void loadFile(String file)
        {
            // calculate maximum resolution
            Int32 maxHeight = Screen.PrimaryScreen.WorkingArea.Height - Config.getMenuBarHeight();
            Int32 maxWidth = Screen.PrimaryScreen.WorkingArea.Width;

            // set pause button size relativ to menuBar
            btnMenuPause.Width = Config.getMenuBarHeight() - 5;
            btnMenuPause.Height = Config.getMenuBarHeight() - 5;

            if (Config.getFullscreen())
            {   
                // load map temporary 
                Panel tmpPanel = new Panel();
                Map tmpMap = new Map(ref tmpPanel);
                tmpMap.loadMap(file);

                // calculate new blocksize to zoom map in fullscreen
                Int32 countBlockSizeWidth = maxWidth / tmpMap.getWidthBlocks();
                Int32 countBlockSizeHeight = maxHeight / tmpMap.getHeightBlocks();
                Int32 newBlockSize = (countBlockSizeHeight > countBlockSizeWidth) ? countBlockSizeWidth : countBlockSizeHeight;

                // set new blocksize
                Config.setBlockSize(newBlockSize);
            }
            else
            {
                // reset block size. just to be sure
                Config.setDefaultBlockSize();
            }

            // clean garbage in item collection
            ItemCollection.disposeAllItems();

            // prepare new Items
            Config.initItems();

            // load actual map and draw everything
            map = new Map(ref mapPanel);
            map.setPrepareToWalk(true);
            map.registerControlClickEventHandler(item_Click);
            map.loadMap(file);
            try
            {
                map.setAllObjectsOnMap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            // set form size to map size (only in window mode)
            if (!Config.getFullscreen())
            {
                Size newSize = new Size(map.getWidth(), map.getHeight() + Config.getMenuBarHeight());
                if (newSize.Width < pausePanel.Width)
                    newSize.Width = pausePanel.Width;

                if (newSize.Height < pausePanel.Height)
                    newSize.Height = pausePanel.Height;

                this.ClientSize = newSize;
            }

            // set menubar
            menuBar.Height = Config.getMenuBarHeight();
            menuBar.Width = this.ClientSize.Width;
            menuBar.Location = new Point(0, 0);

            // set pause button
            btnMenuPause.Location = new Point((this.ClientSize.Width - btnMenuPause.Size.Width) / 2, (Config.getMenuBarHeight() - btnMenuPause.Size.Height) / 2);

            // center pause menu on form
            pausePanel.Location = new Point((this.ClientSize.Width - pausePanel.Width) / 2, (this.ClientSize.Height - pausePanel.Height) / 2);

            // center panel on form
            Point mapPosition = new Point((this.ClientSize.Width - mapPanel.Width) / 2, (this.ClientSize.Height - mapPanel.Height + Config.getMenuBarHeight()) / 2);

            // set map panel location on form
            mapPanel.Location = mapPosition;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenuPause_Click(object sender, EventArgs e)
        {
            // check if pause menu is visiable
            if (pausePanel.Visible)
            {
                continueGame();
            }
            else 
            {
                pauseGame();
            }
        }

        // @TODO testing only
        private void item_Click(object sender, EventArgs e)
        {
            return;

            Animation anim = new Animation(mapPanel);
            PictureBox obj = sender as PictureBox;
            anim.eraseObject(obj);
            obj.Image = null;
            obj.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Pause game and show menu
        /// </summary>
        private void pauseGame()
        {
            // show pause menu
            pausePanel.Visible = true;
            // disable map
            map.disable();
            // @TODO disable timer
        }

        /// <summary>
        /// continue game and hide menu
        /// </summary>
        private void continueGame()
        {
            // hide pause menu
            pausePanel.Visible = false;
            // enable map
            map.enable();
            // @TODO enable timer
        }

        /// <summary>
        /// Hide form after load
        /// </summary>
        private void Game_Shown(object sender, EventArgs e)
        {
            formToCloseAfterLoad.Hide();
        }

        /// <summary>
        /// Click on continue button -> continue Game
        /// </summary>
        private void continue_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            continueGame();
        }

        /// <summary>
        /// Show game rules
        /// </summary>
        private void rules_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            GameRules gr = new GameRules();
            gr.ShowDialog();
        }

        /// <summary>
        /// Enable / disable soundtrack
        /// </summary>
        private void soundtrack_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            // @TODO User feedback

            // set config depending on current state
            if (Config.getPlayMusic())
            {
                Config.setPlayMusic(false);
                Sound.stopSoundtrack();
            }
            else
            {
                Config.setPlayMusic(true);
                Sound.playSoundtrack();
            }

            // save config
            Config.saveSettings();
        }

        /// <summary>
        /// Enable / disable soundeffects
        /// </summary>
        private void soundeffect_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            // @TODO User feedback

            // set config depending on state
            if (Config.getPlaySoundEffects())
            {
                Config.setPlaySoundEffects(false);
            }
            else
            {
                Config.setPlaySoundEffects(true);
            }

            // save config
            Config.saveSettings();
        }

        /// <summary>
        /// End game
        /// </summary>
        private void close_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
