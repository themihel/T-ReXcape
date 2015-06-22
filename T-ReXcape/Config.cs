using System;
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

        // size menu bar
        static private Int32 menuBarHeight = 50;


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
            Item player1start = new Item("player1start", 4 * blockSize, 4 * blockSize);
            player1start.setImageLeft(Properties.Resources.dino_left);
            player1start.setImageRight(Properties.Resources.dino_right);
            player1start.setImageTop(Properties.Resources.dino_up);
            player1start.setImageBottom(Properties.Resources.dino_down);
            player1start.setMaxOnPanel(1);
            player1start.setName("Spieler 1");
            player1start.setHookPosition(Item.positionCenter, Item.positionBottom);
            ItemCollection.addItem(player1start);

            Item destination = new Item("destination", 3 * blockSize, 4 * blockSize);
            destination.setImageAllDirections(Properties.Resources.rocket1);
            destination.setMaxOnPanel(1);
            destination.setName("Ziel");
            destination.setHookPosition(Item.positionCenter, Item.positionBottom);
            ItemCollection.addItem(destination);

            Item player2start = new Item("player2start", 4 * blockSize, 4 * blockSize);
            player2start.setImageLeft(Properties.Resources.dino_left);
            player2start.setImageRight(Properties.Resources.dino_right);
            player2start.setImageTop(Properties.Resources.dino_up);
            player2start.setImageBottom(Properties.Resources.dino_down);
            player2start.setMaxOnPanel(1);
            player2start.setName("Spieler 2");
            player2start.setHookPosition(Item.positionCenter, Item.positionBottom);
            ItemCollection.addItem(player2start);

            Item wall = new Item("wall", 2 * blockSize, 4 * blockSize);
            wall.setImageLeft(Properties.Resources.wallv);
            wall.setImageRight(Properties.Resources.wallv);
            wall.setImageTop(Properties.Resources.wallh);
            wall.setImageBottom(Properties.Resources.wallh);
            wall.setMaxOnPanel(99);
            wall.setName("Mauer");
            ItemCollection.addItem(wall);

            Item goTo = new Item("goto", 2 * blockSize, 2 * blockSize);
            goTo.setImageLeft(Properties.Resources.goleft);
            goTo.setImageRight(Properties.Resources.goright);
            goTo.setImageTop(Properties.Resources.gotop);
            goTo.setImageBottom(Properties.Resources.gobottom);
            goTo.setMaxOnPanel(99);
            goTo.setName("Bewegung");
            ItemCollection.addItem(goTo);

            Item hole = new Item("hole", 2 * blockSize, 2 * blockSize);
            hole.setImageAllDirections(Properties.Resources.moat);
            hole.setMaxOnPanel(99);
            hole.setName("Loch");
            ItemCollection.addItem(hole);

            Item bomb = new Item("bomb", 2 * blockSize, 2 * blockSize);
            bomb.setImageAllDirections(Properties.Resources.bomb);
            bomb.setMaxOnPanel(99);
            bomb.setName("Bombe");
            ItemCollection.addItem(bomb);
        }


        /// <summary>
        /// reset all items
        /// </summary>
        static public void disposeAllItems()
        {
            ItemCollection.disposeAllItems();
        }

        /// <summary>
        /// returns height of menu panel
        /// </summary>
        /// <returns></returns>
        static public Int32 getMenuBarHeight()
        {
            return menuBarHeight;
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
