﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace T_ReXcape
{
    static class Config
    {
        // blockSize
        static private Int32 defaultBlockSize = 20;
        static private Int32 blockSize = defaultBlockSize;

        // fileFilters
        static private String mapFileFilter = "T-ReXcape Map files (.xmap)|*.xmap";

        // colors
        static private Color activeColor = Color.Red;
        static private Color gridColor = Color.Gray;


        /// <summary>
        /// sets block size
        /// </summary>
        /// <param name="size"></param>
        static public void setBlockSize(int size)
        {
            blockSize = size;
        }

        /// <summary>
        /// sets block size to default value
        /// </summary>
        static public void setDefaultBlockSize()
        {
            blockSize = defaultBlockSize;
        }

        /// <summary>
        /// Init all set items to Itemcollection
        /// </summary>
        static public void initItems()
        {
            Item player1start = new Item("player1start", 3 * blockSize, 3 * blockSize);
            player1start.setImageLeft(Properties.Resources.dino_left);
            player1start.setImageRight(Properties.Resources.dino_right);
            player1start.setImageTop(Properties.Resources.dino_up);
            player1start.setImageBottom(Properties.Resources.dino_down);
            player1start.setMaxOnPanel(1);
            player1start.setName("Spieler 1 Start");
            player1start.setHookPosition(Item.positionCenter, Item.positionBottom);
            ItemCollection.addItem(player1start);

            Item player1destination = new Item("player1destination", 3 * blockSize, 4 * blockSize);
            player1start.setImageAllDirections(Properties.Resources.rocket1);
            player1destination.setMaxOnPanel(1);
            player1destination.setName("Spieler 1 Ziel");
            player1destination.setHookPosition(Item.positionCenter, Item.positionBottom);
            ItemCollection.addItem(player1destination);

            Item player2start = new Item("player2start", 3 * blockSize, 3 * blockSize);
            player1start.setImageLeft(Properties.Resources.dino_left);
            player1start.setImageRight(Properties.Resources.dino_right);
            player1start.setImageTop(Properties.Resources.dino_up);
            player1start.setImageBottom(Properties.Resources.dino_down);
            player2start.setMaxOnPanel(1);
            player2start.setName("Spieler 2 Start");
            player2start.setHookPosition(Item.positionCenter, Item.positionBottom);
            ItemCollection.addItem(player2start);

            Item player2destination = new Item("player2destination", 3 * blockSize, 4 * blockSize);
            player2destination.setImageAllDirections(Properties.Resources.rocket1);
            player2destination.setMaxOnPanel(1);
            player2destination.setName("Spieler 2 Ziel");
            player2destination.setHookPosition(Item.positionCenter, Item.positionBottom);
            ItemCollection.addItem(player2destination);

            Item wallv = new Item("wallv", 2 * blockSize, 4 * blockSize);
            wallv.setImageLeft(Properties.Resources.wallv);
            wallv.setImageRight(Properties.Resources.wallv);
            wallv.setImageTop(Properties.Resources.wallh);
            wallv.setImageBottom(Properties.Resources.wallh);
            wallv.setMaxOnPanel(99);
            wallv.setName("Mauer vertikal");
            ItemCollection.addItem(wallv);
            
            Item goright = new Item("goright", blockSize, blockSize);
            goright.setImageLeft(Properties.Resources.goleft);
            goright.setImageRight(Properties.Resources.goright);
            goright.setImageTop(Properties.Resources.gotop);
            goright.setImageBottom(Properties.Resources.gobottom);
            goright.setMaxOnPanel(99);
            goright.setName("Bewegung - rechts");
            ItemCollection.addItem(goright);

            Item hole = new Item("hole", blockSize * 4, blockSize * 4);
            hole.setImageAllDirections(Properties.Resources.moat);
            hole.setMaxOnPanel(99);
            hole.setName("Loch");
            ItemCollection.addItem(hole);
        }


        /// <summary>
        /// reset all items
        /// </summary>
        static public void disposeAllItems()
        {
            ItemCollection.disposeAllItems();
        }

        /// <summary>
        /// returns size of width/height of a map block
        /// </summary>
        /// <returns>block size</returns>
        static public Int32 getBlockSize()
        {
            return blockSize;
        }

        /// <summary>
        /// returns file filters (map files) for file-dialogs
        /// </summary>
        /// <returns>map file filters</returns>
        static public String getMapFileFilter()
        {
            return mapFileFilter;
        }

        /// <summary>
        /// returns background color of active elements
        /// </summary>
        /// <returns>backgroundcolor of active element</returns>
        static public Color getActiveColor()
        {
            return activeColor;
        }

        /// <summary>
        /// Returns grid-color
        /// </summary>
        /// <returns>Color of grid</returns>
        static public Color getGridColor()
        {
            return gridColor;
        }

        /// <summary>
        /// sets fullscreen setting
        /// </summary>
        /// <param name="value"></param>
        static public void setFullscreen(bool value)
        {
            Properties.Settings.Default.fullscreen = value;
        }

        /// <summary>
        /// get fullscreen setting
        /// </summary>
        /// <returns>boolean</returns>
        static public bool getFullscreen()
        {
            return Properties.Settings.Default.fullscreen;
        }

        /// <summary>
        /// set music setting
        /// </summary>
        /// <param name="value"></param>
        static public void setPlayMusic(bool value)
        {
            Properties.Settings.Default.playMusic = value;
        }

        /// <summary>
        /// get music setting
        /// </summary>
        /// <returns>boolean</returns>
        static public bool getPlayMusic()
        {
            return Properties.Settings.Default.playMusic;
        }

        /// <summary>
        /// set soudeffects settings
        /// </summary>
        /// <param name="value"></param>
        static public void setPlaySoundEffects(bool value)
        {
            Properties.Settings.Default.playSoundEffects = value;
        }

        /// <summary>
        /// get soundeffects setting
        /// </summary>
        /// <returns>boolean</returns>
        static public bool getPlaySoundEffects()
        {
            return Properties.Settings.Default.playSoundEffects;
        }

        /// <summary>
        /// save settings permanent. keep it to next start
        /// </summary>
        static public void saveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}
