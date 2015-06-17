using System;
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
        Control dragDropObject;

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

        /// <summary>
        /// initialise Map with panel / loads configs from config class
        /// </summary>
        /// <param name="mapPanel">Form Panel (Map)</param>
        public Map(Panel mapPanel)
        {
            // set panel
            this.mapPanel = mapPanel;

            // load configs
            blockSize = Config.getBlockSize();
            activeColor = Config.getActiveColor();
            gridColor = Config.getGridColor();
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
        public void registerControlDoubleClickEventHandler(System.EventHandler controlDoubleClickEventHandler) {
            this.controlDoubleClickEventHandler = controlDoubleClickEventHandler;
        }

        /// <summary>
        /// action handler for mouse movement on item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemMouseMove(object sender, MouseEventArgs e)
        {
            if (getDragObject() != null)
            {
                Point newPos = new Point(((Control)sender).Location.X + e.X, ((Control)sender).Location.Y + e.Y);
                dragObjectToPoint(newPos);
            }
        }

        /// <summary>
        /// returns current status of grid
        /// </summary>
        /// <returns>grid-status</returns>
        public Boolean getGridStatus()
        {
            return isGridShown;
        }

        /// <summary>
        /// toggles grid
        /// </summary>
        public void toggleGrid()
        {
            isGridShown = !isGridShown;
            setGrid(isGridShown);
        }

        /// <summary>
        /// sets grid to specific status
        /// </summary>
        /// <param name="activate">grid-status</param>
        public void setGrid(bool activate)
        {
            if (activate)
            {
                mapPanel.BackgroundImage = getBackground(true);
            }
            else
            {
                mapPanel.BackgroundImage = getBackground(false);
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

            // write all objects on map
            foreach (Control child in mapPanel.Controls)
            {
                String name = child.Name;
                Point position = child.Location;
                Item item = ItemCollection.getItemByKey(Util.removeDigitsFromString(name));
                // calculate actual position back
                position.X = position.X - item.getPositionOffsetX() - item.getBlockOffsetX(blockSize);
                position.Y = position.Y - item.getPositionOffsetY() - item.getBlockOffsetY(blockSize);

                // write position
                mapFile.IniWriteValue("map", name + ".x", pixelToBlock(position.X).ToString());
                mapFile.IniWriteValue("map", name + ".y", pixelToBlock(position.Y).ToString());
            }
        }

        /// <summary>
        /// loads map to specific path/file
        /// </summary>
        /// <param name="filename">path and filename</param>
        public void loadMap(String filename)
        {
            if (!File.Exists(filename))
                throw new IOException("File not exists");

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
                if (validation.validateKeyGroup("config", configKeys)) {
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

        public void setAllObjectsOnMap()
        {
            // init validation
            Validate validation = new Validate(mapFile);

            // set item checkParams
            String[] itemCheckParams = { ".x", ".y" };

            // @TODO better key check
            // load all known objects
            foreach (Item item in ItemCollection.getAllItems())
            {
                // index
                int i = 0;

                // validate Item
                while (validation.validateKeyParams("map", item.getKey(), i, itemCheckParams))
                {
                    // get Item position
                    int posX = blockToPixel(Convert.ToInt32(mapFile.IniReadValue("map", item.getKey() + i + ".x")));
                    int posY = blockToPixel(Convert.ToInt32(mapFile.IniReadValue("map", item.getKey() + i + ".y")));
                    // set item on map
                    setObjectOnMap(item.getKey(), new Point(posX, posY));
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
            Int32 result = 0;
            foreach (Control child in mapPanel.Controls)
            {
                // remove last diggit to count all with same name
                if (Util.removeDigitsFromString(child.Name).Equals(name))
                {
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// returns background with optional grid
        /// </summary>
        /// <param name="withGrid">grid status</param>
        /// <returns>returns bitmap with / without grid</returns>
        private Bitmap getBackground(bool withGrid = false)
        {
            Bitmap background;
            if (withGrid)
            {
                // save recourses if created
                if (bgWithGrid == null)
                {
                    // get original image
                    Image bg = Properties.Resources.grass;
                    // set pen
                    Pen pen = new Pen(new SolidBrush(gridColor));
                    // calculate new image size. always multiple size of block
                    int width = (bg.Size.Width / blockSize) * blockSize;
                    int height = (bg.Size.Height / blockSize) * blockSize;

                    // create new image to draw on
                    bgWithGrid = new Bitmap(bg, width, height);
                    Graphics gr = Graphics.FromImage(bgWithGrid);
                    for (int i = 0; i <= blockSize; i++)
                    {
                        for (int j = 0; j <= blockSize; j++)
                        {
                            // draw grid on new image
                            gr.DrawRectangle(pen, i * blockSize, j * blockSize, blockSize, blockSize);
                        }
                    }
                }
                background = bgWithGrid;
            }
            else
            {
                // get original image without any changes
                background = Properties.Resources.grass;
            }
            return background;
        }

        /// <summary>
        /// sets specific item on specific position on map
        /// </summary>
        /// <param name="key">item name / key</param>
        /// <param name="position">item position</param>
        public bool setObjectOnMap(String key, Point position)
        {
            if (!ItemCollection.isItemSet(key) || ItemCollection.getItemByKey(key).getMaxOnPanel() > getItemCount(key))
            {
                PictureBox newItem = prepareMapItem(key, position);
                bool checkPosition = fitInHere(newItem.Location, newItem.Width, newItem.Height);
                if (checkPosition)
                {
                    mapPanel.Controls.Add(newItem);
                }
                else
                {
                    newItem = null;
                }

                return checkPosition;
            }
            return false;
        }

        /// <summary>
        /// prepares map item
        /// </summary>
        /// <param name="name">item name/key</param>
        /// <param name="position">item position</param>
        /// <returns>returns prepared pricturebox</returns>
        private PictureBox prepareMapItem(String name, Point position)
        {
            Item item = ItemCollection.getItemByKey(name);

            // add offset to position
            position = Util.getAccuratePosition(position, blockSize);
            position.X = position.X + item.getPositionOffsetX() + item.getBlockOffsetX(blockSize);
            position.Y = position.Y + item.getPositionOffsetY() + item.getBlockOffsetY(blockSize);

            // @TODO remove after debug
            Debug.WriteLine(name);

            // prepare item
            PictureBox img = new PictureBox();
            img.Width = item.getWidth();
            img.Height = item.getHeight();
            img.BackColor = Color.Transparent;
            img.Image = (Image)Properties.Resources.ResourceManager.GetObject(item.getBackground());
            img.SizeMode = PictureBoxSizeMode.Zoom;
            img.Location = position;
            img.Name = name + getItemCount(name);
            img.Cursor = Cursors.Hand;

            // if set: add remove event
            if (controlClickEventHandler != null)
            {
                img.Click += controlClickEventHandler;
                img.MouseMove += new MouseEventHandler(itemMouseMove);
            }

            // if set: add remove event
            if (controlDoubleClickEventHandler != null)
                img.DoubleClick += controlDoubleClickEventHandler;

            // return image
            return img;
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
            Control obj = getDragObject();
            Point newPos = Util.getAccuratePosition(position, Config.getBlockSize());
            Item item = ItemCollection.getItemByKey(Util.removeDigitsFromString(obj.Name));
            // @TODO tidy up a little =)
            newPos.X = newPos.X + item.getPositionOffsetX() + item.getBlockOffsetX(Config.getBlockSize());
            newPos.Y = newPos.Y + item.getPositionOffsetY() + item.getBlockOffsetY(Config.getBlockSize());

            bool fit = fitInHere(newPos, item.getWidth(), item.getHeight());

            if (fit)
            {
                obj.Location = newPos;
            }
            return fit;
        }

        /// <summary>
        /// sets current dragged item
        /// </summary>
        /// <param name="obj">drag-object</param>
        public void setDragObject(Control obj)
        {
            dragDropObject = obj;
        }

        /// <summary>
        /// returns current dragged item
        /// </summary>
        /// <returns>drag-object</returns>
        public Control getDragObject()
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
            foreach (Control itemControl in getAllItemsOnMap())
            {
                if (getDragObject() == null || !getDragObject().Name.Equals(itemControl.Name))
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

        public Point getLastPointWOCollision(Point currentPoint, Int16 direction)
        {
            // @TODO testing // not tested yet / just an idea
            // could return child to check if it's a direction change

            // init point
            Point destPoint;

            // value
            Int32 lastValue;
            Int32 currentValue;

            // get coordinates
            Int32 xPos = currentPoint.X;
            Int32 yPos = currentPoint.Y;

            if (direction == 0) // top
            {
                lastValue = mapPanel.Height;

                // loop through item with same x coordinates and calculate next object
                foreach (Control child in mapPanel.Controls)
                {
                    if (child.Left == 0Pos)
                    {
                        currentValue = yPos - child.Top;
                        if (currentValue > 0 &&  currentValue < lastValue) {
                            lastValue = currentValue;
                            destPoint = new Point(xPos, (child.Top + blockSize));
                        }
                    }
                }

                if (lastValue == mapPanel.Height)
                {
                    destPoint = new Point(xPos, 0);
                }
            }
            else if (direction == 1) // right
            {
                lastValue = 0;

                // loop through item with same y coordinates and calculate next object
                foreach (Control child in mapPanel.Controls)
                {
                    if (child.Top == yPos)
                    {
                        currentValue = child.Left - xPos;
                        if (currentValue < mapPanel.Width && currentValue < lastValue)
                        {
                            lastValue = currentValue;
                            destPoint = new Point((child.Left - blockSize), yPos);
                        }
                    }
                }

                if (lastValue == 0)
                {
                    destPoint = new Point(mapPanel.Width-blockSize, yPos);
                }
            }
            else if (direction == 2) // down
            {
                lastValue = 0;

                // loop through item with same x coordinates and calculate next object
                foreach (Control child in mapPanel.Controls)
                {
                    if (child.Left == xPos)
                    {
                        currentValue = child.Top - yPos;
                        if (currentValue < mapPanel.Height && currentValue < lastValue)
                        {
                            lastValue = currentValue;
                            destPoint = new Point(xPos, (child.Top - blockSize));
                        }
                    }
                }

                if (lastValue == 0)
                {
                    destPoint = new Point(xPos, mapPanel.Width - blockSize);
                }
            }
            else if (direction == 3) // left
            {
                lastValue = mapPanel.Width;

                // loop through item with same y coordinates and calculate next object
                foreach (Control child in mapPanel.Controls)
                {
                    if (child.Top == yPos)
                    {
                        currentValue = xPos - child.Left;
                        if (currentValue > 0 && currentValue < lastValue)
                        {
                            lastValue = currentValue;
                            destPoint = new Point((child.Left + blockSize), yPos);
                        }
                    }
                }

                if (lastValue == 0)
                {
                    destPoint = new Point(0, yPos);
                }
            }

            // return
            return destPoint;
        }
    }
}
