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

        // colors
        private Color activeColor;
        private Color gridColor;

        // bitmaps
        private Bitmap bgWithGrid;

        // status grid
        private Boolean isGridShown = false;

        // EventHandler
        private System.EventHandler controlClickEventHandler = null;
        private System.EventHandler controlDoubleClickEventHandler = null;

        // loaded file
        IniFile mapFile;

        // last added item
        private Item lastAddedItem;

        Item walkingItem;
        Timer walkTimer;
        int walkSpeed = 2;
        bool prepareToWalk = false;

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

            walkTimer = new Timer();
            walkTimer.Interval = 10;
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
            if (getDragObject() != null)
            {
                Item item = sender as Item;
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

            // @TODO better key check
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
                item.MouseMove += new MouseEventHandler(itemMouseMove);
            }

            // if set: add remove event
            if (controlDoubleClickEventHandler != null)
                item.DoubleClick += controlDoubleClickEventHandler;

            item.MouseDown += new MouseEventHandler(Item.mouseDown);
            item.MouseUp += new MouseEventHandler(mouseUpItem);
            item.MouseMove += new MouseEventHandler(Item.mouseMove);
        }

        private void mouseUpItem(object sender, MouseEventArgs e)
        {
            Item.mouseUp(sender, e);
            if (prepareToWalk)
            {
                walkingItem = sender as Item;
                pleaseGo();
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

            // check all items on control
            foreach (Item item in mapPanel.Controls)
            {
                // same name / key
                if (item.getKey() == itemName)
                {
                    foundItems.Add(item);
                }
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

        public void setPrepareToWalk(bool val)
        {
            prepareToWalk = val;
        }

        private void pleaseGo()
        {
            if (walkingItem != null)
            {
                walkingItem.setWalking(true);
                walkTimer.Start();
            }
        }

        private void stopWalking()
        {
            if (walkingItem != null)
            {
                walkingItem.setWalking(false);
            }
            walkTimer.Stop();
        }

        private void walkTimer_Tick(object sender, EventArgs e)
        {
            if (mapPanel.Enabled != true)
                return;

            if (walkingItem != null)
            {
                moveToDirection(walkingItem.getDirection());
            }
        }

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

            if (walkingItem.fitInHere(newLocation, mapPanel))
            {
                walkingItem.Location = newLocation;
            }
            else
            {
                stopWalking();
            }
        }
    }
}
