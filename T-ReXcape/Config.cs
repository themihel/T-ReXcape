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
        static private Int32 blockSize = 20;

        // fileFilters
        static private String mapFileFilter = "T-ReXcape Map files (.xmap)|*.xmap";

        // colors
        static private Color activeColor = Color.Red;
        static private Color gridColor = Color.Gray;

        /// <summary>
        /// Init all set items to Itemcollection
        /// </summary>
        static public void initItems()
        {
            Item player1start = new Item("player1start", 3 * blockSize, 3 * blockSize);
            player1start.setBackground("giphy");
            player1start.setMaxOnPanel(1);
            player1start.setName("Spieler 1 Start");
            player1start.setHookPosition(Item.positionCenter, Item.positionBottom);
            ItemCollection.addItem(player1start);

            Item player1destination = new Item("player1destination", 3 * blockSize, 4 * blockSize);
            player1destination.setBackground("rocket1");
            player1destination.setMaxOnPanel(1);
            player1destination.setName("Spieler 1 Ziel");
            player1destination.setHookPosition(Item.positionCenter, Item.positionBottom);
            ItemCollection.addItem(player1destination);

            Item player2start = new Item("player2start", 3 * blockSize, 3 * blockSize);
            player2start.setBackground("giphy");
            player2start.setMaxOnPanel(1);
            player2start.setName("Spieler 2 Start");
            player2start.setHookPosition(Item.positionCenter, Item.positionBottom);
            ItemCollection.addItem(player2start);

            Item player2destination = new Item("player2destination", 3 * blockSize, 4 * blockSize);
            player2destination.setBackground("rocket1");
            player2destination.setMaxOnPanel(1);
            player2destination.setName("Spieler 2 Ziel");
            player2destination.setHookPosition(Item.positionCenter, Item.positionBottom);
            ItemCollection.addItem(player2destination);

            Item wallv = new Item("wallv", 2 * blockSize, 4 * blockSize);
            wallv.setBackground("wallv");
            wallv.setMaxOnPanel(99);
            wallv.setName("Mauer vertikal");
            ItemCollection.addItem(wallv);

            Item wallh = new Item("wallh", 4 * blockSize, 2 * blockSize);
            wallh.setBackground("wallh");
            wallh.setMaxOnPanel(99);
            wallh.setName("Mauer horizontal");
            ItemCollection.addItem(wallh);

            Item goright = new Item("goright", blockSize, blockSize);
            goright.setBackground("goright");
            goright.setMaxOnPanel(99);
            goright.setName("Bewegung - rechts");
            ItemCollection.addItem(goright);

            Item goleft = new Item("goleft", blockSize, blockSize);
            goleft.setBackground("goleft");
            goleft.setMaxOnPanel(99);
            goleft.setName("Bewegung - links");
            ItemCollection.addItem(goleft);

            Item gotop = new Item("gotop", blockSize, blockSize);
            gotop.setBackground("gotop");
            gotop.setMaxOnPanel(99);
            gotop.setName("Bewegung - oben");
            ItemCollection.addItem(gotop);

            Item gobottom = new Item("gobottom", blockSize, blockSize);
            gobottom.setBackground("gobottom");
            gobottom.setMaxOnPanel(99);
            gobottom.setName("Bewegung - unten");
            ItemCollection.addItem(gobottom);

            Item hole = new Item("hole", blockSize * 4, blockSize * 4);
            hole.setBackground("moat");
            hole.setMaxOnPanel(99);
            hole.setName("Loch");
            ItemCollection.addItem(hole);
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
    }
}
