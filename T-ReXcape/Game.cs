﻿using System;
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

        String[] playerIndicator = {"<<  | |     ", "     | |  >>" };

        static Panel winPanel;
        static PictureBox winPanelPic;

        /// <summary>
        /// Initialise form, set needed configs, calculate form areas
        /// </summary>
        /// <param name="form">Previous form</param>
        /// <param name="fullscreen">Fullscreen setting</param>
        public Game(Form form, bool fullscreen = false)
        {
            formToCloseAfterLoad = form;
            InitializeComponent();
            if (fullscreen)
                goFullscreen();

            // init garbage collector
            GarbageCollector.init(mapPanel, 500);

            // get Soundtrack setting
            if (!Config.getPlayMusic())
            {
                soundtrack_panelbutton.BackgroundImage = Util.getToggleBackground(soundtrack_panelbutton.Width, soundtrack_panelbutton.Height); ;
            }

            // get soundeffect setting
            if (!Config.getPlaySoundEffects())
            {
                soundeffect_panelbutton.BackgroundImage = Util.getToggleBackground(soundeffect_panelbutton.Width, soundeffect_panelbutton.Height); ;
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
            btnMenuPause.Height = 45;

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
            // catch errors
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

            // init topbar infos
            initTopBarInfos();

            // init win panel
            initWinPanel();

            // eventlistener for topbar changes
            Timer checkForTopBarChanges = new Timer();
            checkForTopBarChanges.Interval = 100;
            checkForTopBarChanges.Tick += (s, arg) => { refreshTopBar(); };
            checkForTopBarChanges.Start();
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

        /// <summary>
        /// Place item
        /// </summary>
        private void item_Click(object sender, EventArgs e)
        {
            // if drag object exists
            if (map.getDragObject() != null)
            {
                map.getDragObject().BackColor = Color.Transparent;
                map.setDragObject(null);
            }
        }

        /// <summary>
        /// Pause game and show menu
        /// </summary>
        private void pauseGame()
        {
            // show pause menu
            pausePanel.Visible = true;
            pausePanel.BringToFront();
            // disable map
            map.disable();
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
        /// Enable / disable soundeffects
        /// </summary>
        private void soundeffect_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            // set config depending on state
            if (Config.getPlaySoundEffects())
            {
                // set config
                Config.setPlaySoundEffects(false);
                // user feedback
                soundeffect_panelbutton.BackgroundImage = Util.getToggleBackground(soundeffect_panelbutton.Width, soundeffect_panelbutton.Height);
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
        /// End game
        /// </summary>
        private void close_panelbutton_MouseClick(object sender, MouseEventArgs e)
        {
            if(MessageBox.Show("Wollen Sie wirklich beenden?", "Beenden", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        /// <summary>
        /// Initialise infos of topbar
        /// </summary>
        private void initTopBarInfos()
        {
            // init players
            foreach (String player in map.getPlayerKeys())
            {
                map.getCollectedItems().Add(player, new Dictionary<string, short>());
            }

            // add infos to each player
            foreach (KeyValuePair<string, Int16> info in map.getPlayerCollectables())
            {
                foreach (String player in map.getPlayerKeys())
                {
                    map.getCollectedItems()[player].Add(info.Key, info.Value);
                }
            }
        }

        /// <summary>
        /// Refreshs topbar with current information
        /// </summary>
        private void refreshTopBar()
        {
            // set label for player indication
            btnMenuPause.Text = playerIndicator[map.getPlayerTurn() - 1];

            if (menuBar.Controls.Count != map.getCollectedItemsCount())
            {
                // clear all controls
                menuBar.Controls.Clear();

                // init temp variables
                Point pos = new Point(0, 0);
                int count = 1;
                // loop all players
                foreach (KeyValuePair<string, Dictionary<string, short>> player in map.getCollectedItems())
                {
                    // loop collected items of current player
                    foreach (KeyValuePair<string, short> topBarInfo in player.Value)
                    {
                        for (int i = 0; i < topBarInfo.Value; i++)
                        {
                            // create item
                            Item item = ItemCollection.getItemByKey(topBarInfo.Key).clone();

                            // set direction
                            item.setDirection(Item.directionBottom);

                            // if first item set on first position
                            if (count == 1)
                            {
                                item.Location = pos;
                            }
                            else // create new Point for placement
                            {
                                item.Location = new Point(menuBar.Width - item.Width - pos.X, pos.Y);
                            }

                            // check if valid item and register eventhandler
                            if (item.getKey().Equals("wall") || item.getKey().Equals("goto"))
                            {
                                item.Click += new EventHandler(itemHolderClick);
                            }

                            // check which player owns this item
                            if (player.Key == map.getPlayerKeys()[0])
                                item.setBelongsToPlayerId(1);
                            else
                                item.setBelongsToPlayerId(2);

                            // add item to panel
                            menuBar.Controls.Add(item);

                            // placement
                            pos.X += item.Width;
                        }
                    }
                    // inc counter
                    count++;

                    // reset position
                    pos = new Point(0, 0);
                }
            }
        }

        /// <summary>
        /// Place selected item on map
        /// </summary>
        private void itemHolderClick(object sender, EventArgs e)
        {
            // get current item
            Item item = sender as Item;

            // check if item belongs to current player (player turn)
            if (item.getBelongsToPlayerId() != map.getPlayerTurn())
                return;

            // if item exists
            if (map.getLastAddedItem() != null)
            {
                // get item
                Item lastItem = map.getLastAddedItem();
                // check if item is out of mappanel
                if (
                    lastItem.Location.X < 0 ||
                    lastItem.Location.Y < 0 ||
                    lastItem.Location.X > mapPanel.Width ||
                    lastItem.Location.Y > mapPanel.Height
                    )
                {
                    mapPanel.Controls.Remove(lastItem);
                }
            }

            // remove item from player collected items
            map.decreaseCollectedItem(map.getPlayerKeys()[map.getPlayerTurn() - 1], item.getKey());

            // placement of item
            if (map.setObjectOnMap(item.getKey(), new Point(0 - item.Width, 0 - item.Height)) != null)
            {
                // register events for needed functions
                map.getLastAddedItem().MouseDown += new MouseEventHandler(Item.mouseDown);
                map.getLastAddedItem().MouseUp += new MouseEventHandler(Item.mouseUp);
                map.getLastAddedItem().MouseMove += new MouseEventHandler(Item.mouseMove);
                
                // add goto (playerside) to remove after turn to avoid too much gotos
                if (item.getKey().Equals("goto"))
                    map.addedItemToBeRemovedAfterTurn(map.getLastAddedItem());

                // sets object on map
                map.setDragObject(map.getLastAddedItem());

                // indicator for active item
                map.getDragObject().BackColor = Config.getActiveColor();
            }
        }

        /// <summary>
        /// Drag selected item on map / inidcator if placeable
        /// </summary>
        private void mapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            // if dragitem exists
            if (map.getDragObject() != null)
            {
                if (!map.dragObjectToPoint(e.Location))
                {
                    Debug.Print("Sie können dies nicht hier hin pazieren");
                }
            }
        }

        /// <summary>
        /// Initialize win panel
        /// </summary>
        private void initWinPanel()
        {
            // init panel
            winPanel = new Panel();

            // set location
            winPanel.Location = new Point(0, Config.getMenuBarHeight());

            // set size
            winPanel.Width = this.Width;
            winPanel.Height = this.Height - Config.getMenuBarHeight();

            // set standard color
            winPanel.BackColor = Color.Black;

            // hide panel
            winPanel.Visible = false;

            // add panel to controls
            this.Controls.Add(winPanel);

            // set object in front of all other items
            winPanel.BringToFront();

            // create picturebox
            winPanelPic = new PictureBox();

            // declare image
            winPanelPic.Image = Properties.Resources.winner_pane;

            // set size
            winPanelPic.Width = 500;
            winPanelPic.Height = 300;

            // set location
            winPanelPic.Location = new Point((winPanel.Width - winPanelPic.Width) / 2, (winPanel.Height - winPanelPic.Height) / 2);

            // add picturebox to controls
            winPanel.Controls.Add(winPanelPic);
        }

        /// <summary>
        /// Show win panel with color depending on player
        /// </summary>
        /// <param name="playerId">Player id</param>
        public static void showWinPanel(Int16 playerId)
        {
            // select color depending on winning player
            Color colorA = Color.Red;
            Color colorB = Color.DodgerBlue;

            if (playerId == 1)
            {
                colorA = Color.DodgerBlue;
                colorB = Color.Red;
            }

            // set panel visiable
            winPanel.Visible = true;

            // create back image
            Bitmap b = new Bitmap(winPanelPic.Width, winPanelPic.Height);
            Graphics g = Graphics.FromImage(b);
            g.FillRectangle(new SolidBrush(colorA), 0, 0, winPanelPic.Width / 2, winPanelPic.Height);
            g.FillRectangle(new SolidBrush(colorB), winPanelPic.Width / 2, 0, winPanelPic.Width / 2, winPanelPic.Height);

            // set color
            winPanelPic.BackgroundImage = b;
        }
    }
}
