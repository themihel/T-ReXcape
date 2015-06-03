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

        // colors
        private Color activeColor;
        private Color gridColor;

        // bitmaps
        private Bitmap bgWithGrid;

        // status grid
        private Boolean isGridShown = false;

        // mapEditor
        private Boolean isMapEditor = false;

        // EventHandler
        private System.EventHandler dragDropMouseClick;
        private System.EventHandler removeClick;

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
        /// initialise Map with panel / loads configs from config class / mapEditor option
        /// </summary>
        /// <param name="mapPanel">Form Panel (Map)</param>
        /// <param name="isMapEditor">sets mapEditor option</param>
        public Map(Panel mapPanel, Boolean isMapEditor, System.EventHandler dragDropMouseClick, System.EventHandler removeClick)
        {
            // set panel
            this.mapPanel = mapPanel;

            // set mapEditorOptions
            this.isMapEditor = isMapEditor;

            // set eventHandler
            this.dragDropMouseClick = dragDropMouseClick;
            this.removeClick = removeClick;

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
        /// counts all elements on mapPanel
        /// </summary>
        /// <returns>returns number of all items</returns>
        public Int32 getItemsCount()
        {
            return mapPanel.Controls.Count;
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
            IniFile mapFile = new IniFile(filename);

            if (File.Exists(filename))
            {
                // clear file content if exists
                System.IO.File.WriteAllText(filename, string.Empty);
            }

            // write map config
            mapFile.IniWriteValue("config", "height", mapPanel.Height.ToString());
            mapFile.IniWriteValue("config", "width", mapPanel.Width.ToString());

            // write all objects on map
            foreach (Control child in mapPanel.Controls)
            {
                String name = child.Name;
                Point position = child.Location;
                Item item = ItemCollection.getItemByKey(Util.removeDigitsFromString(name));
                position.X = position.X - item.getPositionOffsetX() - item.getBlockOffsetX(blockSize);
                position.Y = position.Y - item.getPositionOffsetY() - item.getBlockOffsetY(blockSize);

                mapFile.IniWriteValue("map", name + ".x", position.X.ToString());
                mapFile.IniWriteValue("map", name + ".y", position.Y.ToString());
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

            IniFile mapFile = new IniFile(filename);

            // load all known objects
            foreach (Item item in ItemCollection.getAllItems())
            {
                int i = 0;
                // @TODO add validation
                // get position X as default check value
                while (mapFile.IniReadValue("map", item.getKey() + i + ".x").Length > 0)
                {
                    int posX = Convert.ToInt32(mapFile.IniReadValue("map", item.getKey() + i + ".x"));
                    int posY = Convert.ToInt32(mapFile.IniReadValue("map", item.getKey() + i + ".y"));

                    setObjectOnMap(item.getKey(), new Point(posX, posY));

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
        public void setObjectOnMap(String key, Point position)
        {
            if (!ItemCollection.isItemSet(key) || ItemCollection.getItemByKey(key).getMaxOnPanel() > getItemCount(key))
            {
                mapPanel.Controls.Add(prepareMapItem(key, position));
            }
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

            Debug.WriteLine(name);
            PictureBox img = new PictureBox();
            img.Width = item.getWidth();
            img.Height = item.getHeight();
            img.BackColor = Color.Transparent;
            img.Image = (Image)Properties.Resources.ResourceManager.GetObject(item.getBackground());
            img.SizeMode = PictureBoxSizeMode.Zoom;
            img.Location = position;
            img.Name = name + getItemCount(name);
            img.Cursor = Cursors.Hand;
            if (isMapEditor)
            {
                img.Click += dragDropMouseClick;
                img.DoubleClick += removeClick;
            }
            return img;
        }

        

        

        

        

        

       

        

        

        
    }
}
