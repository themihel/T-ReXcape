﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

// @TODO remove after debug
using System.Diagnostics;

namespace T_ReXcape
{
    class Map
    {
        // mapPanel
        private Panel mapPanel;

        // blockSize
        private Int32 blockSize;

        // drag object temp var
        Item dragDropObject;

        // editor mode
        private Boolean editorMode = false;

        // colors
        private Color activeColor;
        private Color gridColor;

        // bitmaps
        private Bitmap bgWithGrid;

        // EventHandler
        private System.EventHandler controlClickEventHandler = null;
        private System.EventHandler controlDoubleClickEventHandler = null;

        // loaded file
        IniFile mapFile;

        // last added item
        private Item lastAddedItem;

        // variables for walking
        Item walkingItem;
        Timer walkTimer;
        int walkSpeed = 1;
        bool prepareToWalk = false;

        private Int16 playerTurn = 1;

        // init collected items
        private Dictionary<String, Dictionary<String, Int16>> collectedItems = new Dictionary<String, Dictionary<String, Int16>>();

        // data
        private String[] playersKeys = { "player1start", "player2start" };
        private Dictionary<String, Int16> playerCollectables = new Dictionary<String, Int16>{
                {"brick", 0},
                {"eraser", 0},
                {"wall", 0},
                {"goto", 3}
            };

        private List<Item> removeAfterTurn = new List<Item>();

        /// <summary>
        /// initialise Map with panel / loads configs from config class
        /// </summary>
        /// <param name="mapPanel">Form Panel (Map)</param>
        public Map(ref Panel mapPanel)
        {
            // set panel
            this.mapPanel = mapPanel;

            // load configs
            blockSize = Config.getBlockSize();
            activeColor = Config.getActiveColor();
            gridColor = Config.getGridColor();

            // walking configs
            walkTimer = new Timer();
            walkTimer.Interval = 1;
            walkTimer.Tick += new EventHandler(walkTimer_Tick);
        }

        /// <summary>
        /// returns width of mapPanel
        /// </summary>
        /// <returns>panel-width</returns>
        public Int32 getWidth()
        {
            return mapPanel.Width;
        }

        /// <summary>
        /// return height of mapPanel
        /// </summary>
        /// <returns>panel-height</returns>
        public Int32 getHeight()
        {
            return mapPanel.Height;
        }

        /// <summary>
        /// returns width of map in blocks
        /// </summary>
        /// <returns>number of blocks (width)</returns>
        public Int32 getWidthBlocks()
        {
            return pixelToBlock(mapPanel.Width);
        }

        /// <summary>
        /// returns height of map in blocks
        /// </summary>
        /// <returns>number of blocks (height)</returns>
        public Int32 getHeightBlocks()
        {
            return pixelToBlock(mapPanel.Height);
        }

        /// <summary>
        /// counts all elements on mapPanel
        /// </summary>
        /// <returns>returns number of all items</returns>
        public Int32 getItemsCount()
        {
            return mapPanel.Controls.Count;
        }

        /// <summary>
        /// registers control eventhandler for click
        /// </summary>
        /// <param name="controlClickEventHandler">eventhandler for click</param>
        public void registerControlClickEventHandler(System.EventHandler controlClickEventHandler)
        {
            this.controlClickEventHandler = controlClickEventHandler;
        }

        /// <summary>
        /// registers control eventhandler for doubleClick
        /// </summary>
        /// <param name="controlDoubleClickEventHandler">eventhandler for doubleClick</param>
        public void registerControlDoubleClickEventHandler(System.EventHandler controlDoubleClickEventHandler)
        {
            this.controlDoubleClickEventHandler = controlDoubleClickEventHandler;
        }

        /// <summary>
        /// action handler for mouse movement on item
        /// </summary>
        private void itemMouseMove(object sender, MouseEventArgs e)
        {
            Item item = sender as Item;
            if (getDragObject() != null && checkPlayerTurn(item.getBelongsToPlayerId()))
            {
                Point newPos = new Point(item.Location.X + e.X, item.Location.Y + e.Y);
                dragObjectToPoint(newPos);
            }
        }

        /// <summary>
        /// checks if there are any elements on map // otherwise throws exception
        /// </summary>
        /// <returns>returns true if there are map objects</returns>
        public bool checkMapPanel()
        {
            if (getItemsCount() == 0)
                throw new Exception("Es sind keine Objekte auf dem Feld.");

            return true;
        }

        /// <summary>
        /// saves map to specific path/file
        /// </summary>
        /// <param name="filename">path and filename</param>
        public void saveMap(String filename)
        {
            mapFile = new IniFile(filename);

            if (File.Exists(filename))
            {
                // clear file content if exists
                System.IO.File.WriteAllText(filename, string.Empty);
            }

            // write map config
            mapFile.IniWriteValue("config", "height", pixelToBlock(mapPanel.Height).ToString());
            mapFile.IniWriteValue("config", "width", pixelToBlock(mapPanel.Width).ToString());

            Dictionary<string, int> counts = new Dictionary<string, int>();

            // write all objects on map
            foreach (Item child in mapPanel.Controls)
            {
                String name = child.Name;
                Point position = child.Location;
                Item item = child as Item;

                if (counts.Keys.Contains(name))
                    counts[name]++;
                else
                    counts.Add(name, 0);
                
                // calculate actual position back
                position.X = position.X - item.getPositionOffsetX() - item.getBlockOffsetX(blockSize);
                position.Y = position.Y - item.getPositionOffsetY() - item.getBlockOffsetY(blockSize);
                int direction = item.getDirection();
                
                // write position
                mapFile.IniWriteValue("map", name + counts[name] + ".x", pixelToBlock(position.X).ToString());
                mapFile.IniWriteValue("map", name + counts[name] + ".y", pixelToBlock(position.Y).ToString());
                mapFile.IniWriteValue("map", name + counts[name] + ".direction", direction.ToString());
            }
        }

        /// <summary>
        /// loads map from specific path/file
        /// </summary>
        /// <param name="filename">path and filename</param>
        public void loadMap(String filename)
        {
            // set background
            mapPanel.BackgroundImage = getBackground();

            if (!File.Exists(filename))
                throw new IOException("File not exists '" + filename + "'");

            // clear map panel
            clearMap();

            // open file
            mapFile = new IniFile(filename);

            // init validation
            Validate validation = new Validate(mapFile);

            try
            {
                // set config keys
                String[] configKeys = { "width", "height" };

                // validate config keys
                if (validation.validateKeyGroup("config", configKeys))
                {
                    // set size
                    updateMapSizeBlocks(Convert.ToInt32(mapFile.IniReadValue("config", "width")), Convert.ToInt32(mapFile.IniReadValue("config", "height")));
                }
                else
                {
                    // throw exception
                    throw new Exception("Fehler beim Laden der Map!");
                }
            }
            catch (Exception ex)
            {
                // show error message
                MessageBox.Show(ex.Message, "Fehler beim Laden der Map");
            }
        }

        /// <summary>
        /// Adds all items to map
        /// </summary>
        public void setAllObjectsOnMap()
        {
            // init validation
            Validate validation = new Validate(mapFile);

            // set item checkParams
            String[] itemCheckParams = { ".x", ".y", ".direction" };

            // load all known objects
            foreach (Item item in ItemCollection.getAllItems())
            {
                // index
                int i = 0;
                bool check;

                // validate Item
                while (check = validation.validateKeyParams("map", item.getKey(), i, itemCheckParams))
                {
                    // get Item position
                    int posX = blockToPixel(Convert.ToInt32(mapFile.IniReadValue("map", item.getKey() + i + ".x")));
                    int posY = blockToPixel(Convert.ToInt32(mapFile.IniReadValue("map", item.getKey() + i + ".y")));
                    int direction = Convert.ToInt16(mapFile.IniReadValue("map", item.getKey() + i + ".direction"));
                    // set item on map
                    Item addedItem = setObjectOnMap(item.getKey(), new Point(posX, posY));
                    if (addedItem != null)
                    {
                        addedItem.setDirection(direction);
                    }
                    // increment index
                    i++;
                }
            }
        }

        /// <summary>
        /// removes all items from map
        /// </summary>
        public void clearMap()
        {
            mapPanel.Controls.Clear();
        }

        /// <summary>
        /// counts all items with specific name
        /// </summary>
        /// <param name="name">name (key) of item</param>
        /// <returns>returns amount of specific items</returns>
        public Int32 getItemCount(String name)
        {
            return getItemsByName(name).Count;
        }

        /// <summary>
        /// returns background with optional grid
        /// </summary>
        /// <param name="withGrid">grid status</param>
        /// <returns>returns bitmap with / without grid</returns>
        public Bitmap getBackground()
        {
            if (bgWithGrid == null)
            {
                // set pen
                Pen pen = new Pen(new SolidBrush(gridColor));

                int width = blockSize;
                int height = blockSize;

                // create new image
                bgWithGrid = new Bitmap(width, height);
                Graphics gr = Graphics.FromImage(bgWithGrid);
                gr.DrawRectangle(pen, 0, 0, blockSize, blockSize);
                Random rand = new Random();
                String tempFile = Path.GetTempPath() + "T-ReXCape" + rand.NextDouble() + ".jpg";
                bgWithGrid.Save(tempFile);

                Bitmap tmpBitmap = new Bitmap(tempFile);
                bgWithGrid = new Bitmap(tmpBitmap);
                tmpBitmap.Dispose();

                File.Delete(tempFile);
            }

            return bgWithGrid;
        }

        /// <summary>
        /// sets specific item on specific position on map
        /// </summary>
        /// <param name="key">item name / key</param>
        /// <param name="position">item position</param>
        public Item setObjectOnMap(String key, Point position)
        {
            if (!ItemCollection.isItemSet(key) || ItemCollection.getItemByKey(key).getMaxOnPanel() > getItemCount(key))
            {
                Item newItem = prepareMapItem(key, position);
                bool checkPosition = fitInHere(newItem.Location, newItem.Width, newItem.Height);
                if (checkPosition)
                {
                    lastAddedItem = newItem;
                    mapPanel.Controls.Add(newItem);
                    return newItem;
                }
            }
            return null;
        }

        /// <summary>
        /// prepares map item
        /// </summary>
        /// <param name="name">item name/key</param>
        /// <param name="position">item position</param>
        /// <returns>returns prepared pricturebox</returns>
        private Item prepareMapItem(String name, Point position)
        {
            Item item = ItemCollection.getItemByKey(name).clone();

            // add offset to position
            position = Util.getAccuratePosition(position, blockSize);
            position.X = position.X + item.getPositionOffsetX() + item.getBlockOffsetX(blockSize);
            position.Y = position.Y + item.getPositionOffsetY() + item.getBlockOffsetY(blockSize);

            // @TODO remove after debug
            Debug.WriteLine("prepare Item: " + name);

            // prepare item
            item.Width = item.getWidth();
            item.Height = item.getHeight();
            item.BackColor = Color.Transparent;
            item.Image = item.getImage();
            item.SizeMode = PictureBoxSizeMode.Zoom;
            item.Location = position;
            item.Name = name;
            item.Cursor = Cursors.Hand;

            addEvents(ref item);

            // return image
            return item;
        }

        /// <summary>
        /// returns all controls on map
        /// </summary>
        /// <returns>all controls on map</returns>
        public System.Windows.Forms.Control.ControlCollection getAllItemsOnMap()
        {
            return mapPanel.Controls;
        }

        /// <summary>
        /// sets dragged object to specific position if there is enough space
        /// </summary>
        /// <param name="position">new position of dragged object</param>
        /// <returns>returns if object fits or not</returns>
        public bool dragObjectToPoint(Point position)
        {
            Item item = getDragObject();
            Point newPos = Util.getAccuratePosition(position, Config.getBlockSize());

            newPos.X = newPos.X + item.getPositionOffsetX() + item.getBlockOffsetX(Config.getBlockSize());
            newPos.Y = newPos.Y + item.getPositionOffsetY() + item.getBlockOffsetY(Config.getBlockSize());

            bool fit = fitInHere(newPos, item.getWidth(), item.getHeight());

            if (fit)
            {
                item.Location = newPos;
            }
            return fit;
        }

        /// <summary>
        /// sets current dragged item
        /// </summary>
        /// <param name="obj">drag-object</param>
        public void setDragObject(Item obj)
        {
            dragDropObject = obj;
        }

        /// <summary>
        /// returns current dragged item
        /// </summary>
        /// <returns>drag-object</returns>
        public Item getDragObject()
        {
            return dragDropObject;
        }

        /// <summary>
        /// checks if item has enough place to fit in specific position
        /// </summary>
        /// <param name="position">new position of item</param>
        /// <param name="width">width of item</param>
        /// <param name="height">height of item</param>
        /// <returns>return if item fits or not</returns>
        private bool fitInHere(Point position, Int32 width, Int32 height)
        {
            Boolean ok = true;
            // check only if position is on map.
            // otherwise is position valid but garbage collector will delete it
            if (position.X >= 0 && position.X <= mapPanel.Width &&
                position.Y >= 0 && position.Y <= mapPanel.Height)
            {
                foreach (Control itemControl in getAllItemsOnMap())
                {
                    if (getDragObject() == null || !getDragObject().Equals(itemControl))
                    {
                        int distanceLeft = position.X - (itemControl.Location.X + itemControl.Width);
                        int distanceRight = itemControl.Location.X - (position.X + width);
                        int distanceTop = itemControl.Location.Y - (position.Y + height);
                        int distanceBottom = position.Y - (itemControl.Location.Y + itemControl.Height);

                        if (distanceLeft < 0 && distanceRight < 0 && distanceTop < 0 && distanceBottom < 0)
                        {
                            ok = false;
                        }
                    }
                }
            }
            return ok;
        }

        /// <summary>
        /// check if position is on map
        /// </summary>
        /// <param name="position">Position of item</param>
        /// <param name="width">Width of item</param>
        /// <param name="height">Height of items</param>
        /// <returns>Boolean if item is on map</returns>
        private bool isPositionOnMap(Point position, Int32 width, Int32 height)
        {
            return (position.X >= 0 && position.X + width <= mapPanel.Width &&
                position.Y >= 0 && position.Y + height <= mapPanel.Height);
        }

        /// <summary>
        /// updates map size depending on pixels
        /// </summary>
        /// <param name="maxWidth">number of pixels (width)</param>
        /// <param name="maxHeight">number of pixels (height)</param>
        public void updateMapSize(Int32 maxWidth, Int32 maxHeight)
        {
            mapPanel.Width = maxWidth / blockSize * blockSize;
            mapPanel.Height = maxHeight / blockSize * blockSize;
        }

        /// <summary>
        /// updates map size depending on blocks
        /// </summary>
        /// <param name="blockWidth">number of blocks (width)</param>
        /// <param name="blockHeight">number of blocks (height)</param>
        public void updateMapSizeBlocks(Int32 blockWidth, Int32 blockHeight)
        {
            mapPanel.Width = blockToPixel(blockWidth);
            mapPanel.Height = blockToPixel(blockHeight);
        }

        /// <summary>
        /// calculates pixels into blocks
        /// </summary>
        /// <param name="pixel">number of pixels</param>
        /// <returns>number of blocks</returns>
        public Int32 pixelToBlock(Int32 pixel)
        {
            return pixel / blockSize;
        }

        /// <summary>
        /// calculates blocksize into pixels
        /// </summary>
        /// <param name="block">number of blocks</param>
        /// <returns>number of pixels</returns>
        public Int32 blockToPixel(Int32 block)
        {
            return block * blockSize;
        }

        /// <summary>
        /// Redraws background
        /// </summary>
        public void redrawBackground()
        {
            mapPanel.BackgroundImage = getBackground();
        }

        /// <summary>
        /// Add events to item
        /// </summary>
        /// <param name="item">Item</param>
        private void addEvents(ref Item item)
        {
            // if set: add remove event
            if (controlClickEventHandler != null)
            {
                item.Click += controlClickEventHandler;
                if(item.canWalk() || editorMode)
                    item.MouseMove += new MouseEventHandler(itemMouseMove);
            }

            // if set: add remove event
            if (controlDoubleClickEventHandler != null)
                item.DoubleClick += controlDoubleClickEventHandler;

            if (item.canWalk() || editorMode)
            {
                item.MouseDown += new MouseEventHandler(Item.mouseDown);
                item.MouseUp += new MouseEventHandler(mouseUpItem);
                item.MouseMove += new MouseEventHandler(mouseMoveItem);
            }
        }

        /// <summary>
        /// Mouse up event
        /// </summary>
        private void mouseUpItem(object sender, MouseEventArgs e)
        {
            // get item
            Item item = sender as Item;

            // check if item belongs to current player
            if (checkPlayerTurn(item.getBelongsToPlayerId()))
            {
                // start mouse up event of item
                Item.mouseUp(sender, e);

                // check if prepare to walk is active and no player is currently walking
                if (prepareToWalk && !isWalkingItemRunning())
                {
                    // set current walking item
                    walkingItem = sender as Item;

                    // set turn depending on player
                    if (walkingItem.getKey() == getPlayerKeys()[0])
                        nextTurn(2);
                    else
                        nextTurn(1);

                    // start walking
                    pleaseGo();
                }
            }
        }

        /// <summary>
        /// Mouse move event
        /// </summary>
        private void mouseMoveItem(object sender, MouseEventArgs e)
        {
            // get item
            Item item = sender as Item;
            // check this item belongs to current player
            if (checkPlayerTurn(item.getBelongsToPlayerId()))
            {
                // start event
                Item.mouseMove(sender, e);
            }
        }

        /// <summary>
        /// Returns last added item
        /// </summary>
        /// <returns>Item (last added)</returns>
        public Item getLastAddedItem()
        {
            return lastAddedItem;
        }

        /// <summary>
        /// Clones item to specific postion
        /// </summary>
        /// <param name="item">Item to clone</param>
        /// <param name="position">Position of new item</param>
        /// <returns>Returns if item fits (-> added)</returns>
        public bool cloneItem(Item item, Point position)
        {
            // copy item and set position
            Item newItem = item.clone();
            newItem.Location = position;

            // add events
            addEvents(ref newItem);

            // check if item fits
            bool checkPosition = fitInHere(newItem.Location, newItem.Width, newItem.Height);
            if (checkPosition)
            {
                // add item
                lastAddedItem = newItem;
                lastAddedItem.Cursor = Cursors.Hand;
                mapPanel.Controls.Add(newItem);
            }

            // return if item fits
            return checkPosition;
        }

        /// <summary>
        /// Returns all items with specific name
        /// </summary>
        /// <param name="itemName">String of item name</param>
        /// <returns>Array of all found items</returns>
        public List<Item> getItemsByName(String itemName)
        {
            // new list
            List<Item> foundItems = new List<Item>();

            try
            {
                // check all items on control
                foreach (Item item in mapPanel.Controls)
                {
                    // same name / key
                    if (item.getKey() == itemName)
                    {
                        foundItems.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }

            // return
            return foundItems;
        }

        /// <summary>
        /// Disables map functionality
        /// </summary>
        public void disable()
        {
            mapPanel.Enabled = false;
        }

        /// <summary>
        /// Enables map functionality
        /// </summary>
        public void enable()
        {
            mapPanel.Enabled = true;
        }

        /// <summary>
        /// Sets boolean to prepare to walk
        /// </summary>
        /// <param name="val">Boolean prepare to walk</param>
        public void setPrepareToWalk(bool val)
        {
            prepareToWalk = val;
        }

        /// <summary>
        /// Starts walking
        /// </summary>
        private void pleaseGo()
        {
            // check if there isnt currently a walking item
            if (walkingItem != null)
            {
                // start walking item
                walkingItem.setWalking(true);
                walkTimer.Start();
            }
        }

        /// <summary>
        /// stops walking
        /// </summary>
        private void stopWalking()
        {
            if (walkingItem != null)
            {
                walkingItem.setWalking(false);
            }
            walkTimer.Stop();
            
            turnOver();
        }

        /// <summary>
        /// Returns if current walking item is running/walking
        /// </summary>
        /// <returns>Boolean state of walking item</returns>
        public Boolean isWalkingItemRunning()
        {
            if (walkingItem != null)
                return walkingItem.isWalking();
            else
                return false;
        }

        /// <summary>
        /// Walktimer event
        /// </summary>
        private void walkTimer_Tick(object sender, EventArgs e)
        {
            if (mapPanel.Enabled != true)
                return;

            if (walkingItem != null)
            {
                moveToDirection(walkingItem.getDirection());
            }
        }

        /// <summary>
        /// move item to direction
        /// </summary>
        /// <param name="direction">Value of direction</param>
        private void moveToDirection(int direction)
        {
            Point newLocation = new Point(walkingItem.Location.X, walkingItem.Location.Y);
            switch (direction)
            {
                case Item.directionLeft:
                    newLocation.X -= walkSpeed;
                    break;
                case Item.directionRight:
                    newLocation.X += walkSpeed;
                    break;
                case Item.directionTop:
                    newLocation.Y -= walkSpeed;
                    break;
                case Item.directionBottom:
                    newLocation.Y += walkSpeed;
                    break;
            }

            foreach (Item item in walkingItem.collisionObject(newLocation, mapPanel))
            {
                checkForCollisionAction(item);
            }

            foreach (Item item in walkingItem.coverObject(newLocation, mapPanel))
            {
                checkForCoverAction(item);
            }

            if (!isPositionOnMap(newLocation, walkingItem.Width, walkingItem.Height))
                stopWalking();

            if (walkingItem.isWalking())
                walkingItem.Location = newLocation;
        }

        /// <summary>
        /// check item for collision actions
        /// </summary>
        /// <param name="item">Item</param>
        private void checkForCollisionAction(Item item)
        {
            if (item.getCollisionAction() == Item.collisionActions["stop"])
            {
                stopWalking();
            }
            
            if (item.getCollisionAction() == Item.collisionActions["win"])
            {
                stopWalking();

                Game.showWinPanel(getPlayerTurn());
            }
        }

        /// <summary>
        /// check item for cover actions
        /// </summary>
        /// <param name="item">Item</param>
        private void checkForCoverAction(Item item)
        {
            if (item.getCollisionAction() == Item.collisionActions["move"])
            {
                walkingItem.setDirection(item.getDirection());
            }

            if (item.getCollisionAction() == Item.collisionActions["drop"])
            {
                stopWalking();
                walkingItem.resetToStartPosition();
            }

            if (item.getCollisionAction() == Item.collisionActions["addBrick"])
            {
                item.Dispose();
                increaseBrickCount(walkingItem.getKey());
            }

            checkForTransformCollectionItems();
        }

        /// <summary>
        /// creative mode of editor
        /// </summary>
        /// <param name="val">Boolean value of creative mode</param>
        public void setCreativeMode(Boolean val) 
        {
            editorMode = val;
        }

        /// <summary>
        /// Returns dictionary of collected items
        /// </summary>
        /// <returns>Returns dictionary of collected items</returns>
        public Dictionary<String, Dictionary<String, Int16>> getCollectedItems()
        {
            return collectedItems;
        }

        /// <summary>
        /// counts collected items
        /// </summary>
        /// <returns>Returns number of collected items</returns>
        public Int16 getCollectedItemsCount()
        {
            Int16 count = 0;

            foreach (KeyValuePair<string, Dictionary<string, short>> player in collectedItems)
            {
                foreach (KeyValuePair<string, short> topBarInfo in player.Value)
                {
                    count += topBarInfo.Value;
                }
            }

            return count;
        }

        /// <summary>
        /// Returns player keys
        /// </summary>
        /// <returns>Returns player keys</returns>
        public String[] getPlayerKeys()
        {
            return playersKeys;
        }

        /// <summary>
        /// Returns dictionary of player collected items
        /// </summary>
        /// <returns>Returns dictionary of player collected items</returns>
        public Dictionary<String, Int16> getPlayerCollectables()
        {
            return playerCollectables;
        }

        /// <summary>
        /// Increase brick count of player
        /// </summary>
        /// <param name="playerKey">Key of player</param>
        private void increaseBrickCount(String playerKey)
        {
            collectedItems[playerKey]["brick"]++;
        }

        /// <summary>
        /// check if there are collected items which should transform into one complete item
        /// </summary>
        private void checkForTransformCollectionItems()
        {
            foreach (KeyValuePair<string, Dictionary<string, short>> player in collectedItems)
            {
                if (player.Value["brick"] >= 3)
                {
                    player.Value["brick"] = 0;
                    player.Value["wall"]++;
                }
            }
        }

        /// <summary>
        /// Decrease collected item after placement
        /// </summary>
        /// <param name="playerKey">Player key</param>
        /// <param name="item">Placed item</param>
        public void decreaseCollectedItem(String playerKey, String item)
        {
            if (collectedItems[playerKey][item] > 0)
                collectedItems[playerKey][item]--;
        }

        /// <summary>
        /// Get current player turn
        /// </summary>
        /// <returns>Returns id of current player</returns>
        public Int16 getPlayerTurn()
        {
            return playerTurn;
        }

        /// <summary>
        /// Sets player turn by  id
        /// </summary>
        /// <param name="val">Id of current player</param>
        public void setPlayerTurn(Int16 val)
        {
            playerTurn = val;
        }

        /// <summary>
        /// check if player is on turn
        /// </summary>
        /// <param name="playerId">Player id</param>
        /// <returns>returns boolean if player is on turn</returns>
        public Boolean checkPlayerTurn(Int16 playerId)
        {
            return (playerId == getPlayerTurn() || getPlayerTurn().Equals(0) || editorMode);
        }

        /// <summary>
        /// set next turn depending on player id
        /// </summary>
        /// <param name="playerId">Player id</param>
        public void nextTurn(Int16 playerId)
        {
            // set player turn
            setPlayerTurn(playerId);

            // restore amount of gotos
            foreach (KeyValuePair<string, Dictionary<string, short>> player in collectedItems)
            {
                player.Value["goto"] = 3;
            }
        }

        /// <summary>
        /// turn over methid
        /// </summary>
        public void turnOver()
        {
            // removes items after turn (e.g. player placed gotos)
            foreach (Item item in removeAfterTurn)
                mapPanel.Controls.Remove(item);
        }

        /// <summary>
        /// add item to remove after player turn
        /// </summary>
        /// <param name="item"></param>
        public void addedItemToBeRemovedAfterTurn(Item item)
        {
            // add item to list
            removeAfterTurn.Add(item);
        }

    }
}
