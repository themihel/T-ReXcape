using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

// only for debug
using System.Diagnostics;
using System.Threading;
using System.Timers;

namespace T_ReXcape
{
    public partial class Form1 : Form
    {
        // settings 
        int blockSize = 20;
        Color activeColor = Color.Red;
        Color gridColor = Color.Gray;

        // variables
        Point mousePosition;
        Control dragDropObject = null;
        Bitmap bgWithGrid;
        bool isGridShown = false;

        // save all posible objects on ma in this Dictionary
        // Dictionary<string, Dictionary<string, string>> objects;

        public Form1()
        {
            InitializeComponent();
            //objects = new Dictionary<string, Dictionary<string, string>>();
            // init all posible objects

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

            Item wallv = new Item("wallv", 3 * blockSize, 4 * blockSize);
            wallv.setBackground("wallv");
            wallv.setMaxOnPanel(99);
            wallv.setName("Mauer vertikal");
            ItemCollection.addItem(wallv);

            Item wallh = new Item("wallh", 4 * blockSize, 3 * blockSize);
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
           
            // set file filters
            openFileDialog1.Filter = "T-ReXcape Map files (.xmap)|*.xmap";
            saveFileDialog1.Filter = "T-ReXcape Map files (.xmap)|*.xmap";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // @TODO
            Map map = new Map();
            // open file dialog to select map file
            //openFileDialog1.ShowDialog();
            // set map path
            //map.setMapFileName(openFileDialog1.FileName);
        }
                
        // add object
        private void addPlayer1Start(object sender, EventArgs e)
        {
            setObjectOnMap("player1start", mousePosition);
        }

        private void zielToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            setObjectOnMap("player1destination", mousePosition);
        }

        private void mauerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setObjectOnMap("wallv", mousePosition);
        }

        private void grubbeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            setObjectOnMap("wallh", mousePosition);
        }
        
        private void rechtsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setObjectOnMap("goright", mousePosition);
        }

        private void linksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setObjectOnMap("goleft", mousePosition);
        }

        private void obenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setObjectOnMap("gotop", mousePosition);
        }

        private void untenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setObjectOnMap("gobottom", mousePosition);
        }

        private void lochToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setObjectOnMap("hole", mousePosition);
        }

        private void setObjectOnMap(String key, Point position)
        {
            if (!ItemCollection.isItemSet(key) || ItemCollection.getItemByKey(key).getMaxOnPanel() > countObjectOnPanel(key))
            {
                mapPanel.Controls.Add(preparePanelObject(key, position));
            }
        }

        // prepares object to add to panel
        private PictureBox preparePanelObject(String type, Point position)
        {
            Item item = ItemCollection.getItemByKey(type);

            // add offset to position
            position = getAccuratePosition(position);
            position.X = position.X + item.getPositionOffsetX() + item.getBlockOffsetX(blockSize);
            position.Y = position.Y + item.getPositionOffsetY() + item.getBlockOffsetY(blockSize);

            Debug.WriteLine(type);
            PictureBox img = new PictureBox();
            img.Width = item.getWidth();
            img.Height = item.getHeight();
            img.BackColor = Color.Transparent;
            img.Image = (Image)Properties.Resources.ResourceManager.GetObject(item.getBackground());
            img.SizeMode = PictureBoxSizeMode.Zoom;
            img.Location = position;
            img.Name = type + countObjectOnPanel(type);
            img.Cursor = Cursors.Hand;
            img.Click += new System.EventHandler(dragDropMouseClick);
            img.DoubleClick += new System.EventHandler(removeClick);
            return img;
        }

        // onclick drag will be activated, on second click deactivated
        private void dragDropMouseClick(Object sender, EventArgs e)
        {
            if (sender.GetType().IsSubclassOf(typeof(Control)))
            {
                if (dragDropObject == null)
                {
                    dragDropObject = (Control)sender;
                    dragDropObject.BackColor = activeColor;

                    // @TODO discuss this option with teammates
                    // if grid not activated in settings, show it on moved object
                    if (!isGridShown)
                        setGridStatus(true);
                }
                else
                {
                    dragDropObject.BackColor = Color.Transparent;
                    dragDropObject = null;

                    if (!isGridShown)
                        setGridStatus(false);
                }
            }
        }

        // on double click removes object
        private void removeClick(Object sender, EventArgs e)
        {
            if (dragDropObject == null)
                return;

            DialogResult result = MessageBox.Show("Möchten Sie dieses Objekt sicher entfernen?", "Objekt entfernen?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int offset = 10;
                
                int boomSize = (((Control)sender).Width > ((Control)sender).Height) ? ((Control)sender).Width : ((Control)sender).Height;
                int minSize = (((Control)sender).Width < ((Control)sender).Height) ? ((Control)sender).Width : ((Control)sender).Height;
                
                boomSize += offset;
                
                Point position = dragDropObject.Location;
                position.X -= offset;
                position.Y -= ((boomSize - minSize) / 2) + offset;

                PictureBox img = new PictureBox();
                img.Width = boomSize;
                img.Height = boomSize;
                img.BackColor = Color.Transparent;
                img.Image = (Image)Properties.Resources.ResourceManager.GetObject("spideyblast");
                img.SizeMode = PictureBoxSizeMode.Zoom;
                img.Location = position;
                img.Name = "boom";

                mapPanel.Controls.Add(img);
                img.BringToFront();

                ((Control)sender).Tag = "remove";

                dragDropObject = null;

                if (!isGridShown)
                    setGridStatus(false);


                EasyTimer.SetTimeout(() =>
                {
                    img.Tag = "remove";
                }, 1200);
            }
        }

        // moves locked object with mouse move
        private void mapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragDropObject != null)
            {
                Point position = getAccuratePosition(e.Location);
                Item item = ItemCollection.getItemByKey(getNameWOCounter(dragDropObject.Name));
                // @TODO tidy up a little =)
                Debug.WriteLine(item.getBlockOffsetX(blockSize));
                position.X = position.X + item.getPositionOffsetX() + item.getBlockOffsetX(blockSize);
                position.Y = position.Y + item.getPositionOffsetY() + item.getBlockOffsetY(blockSize);

                dragDropObject.Location = position;
            }
        }

        // gets position depends on blocksize. position should be allways in one block
        private Point getAccuratePosition(Point p)
        {
            int x = (p.X / blockSize) * blockSize;
            int y = (p.Y / blockSize) * blockSize;
            return new Point(x, y);
        }


        // opens context rightclick on map
        private void mapPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mousePosition = new Point(e.X, e.Y);
                mapAddStuff.Show(Cursor.Position);
            }
        }

        /**
         * counts all objects on panel with same name
         */
        private int countObjectOnPanel(String name)
        {
            int result = 0;
            foreach (Control child in mapPanel.Controls)
            {
                // remove last diggit to count all with same name
                if (getNameWOCounter(child.Name).Equals(name))
                {
                    result++;
                }
            }
            return result;
        }

        // returns name without last diggets
        private String getNameWOCounter(String name)
        {
            return Regex.Replace(name, @"\d$", "");
        }

        /// <summary>
        /// Return background / optional with grid
        /// </summary>
        /// <param name="withGrid">Optional with grid</param>
        /// <returns>Bitmap Background</returns>
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

        // draws and removes grid from background
        private void setGridStatus(bool activate)
        {
            if (activate)
            {
                mapPanel.BackgroundImage = getBackground(true);
            }
            else
            {
                mapPanel.BackgroundImage = getBackground();
            }
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            // set map size
            labelMapHeight.Text = mapPanel.Height.ToString();
            labelMapWidth.Text = mapPanel.Width.ToString();

            dataGridView1.Rows.Clear();
            foreach (Item item in ItemCollection.getAllItems())
            {
                dataGridView1.Rows.Add(item.getName(), item.getMaxOnPanel(), countObjectOnPanel(item.getKey()));
            }
        }

        private void rasterUmschaltenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle grid
            if (isGridShown)
            {
                // Toggle checked state
                isGridShown = false;

                // set normal background
                setGridStatus(false);

                rasterUmschaltenToolStripMenuItem.Checked = false;
            }
            else
            {
                // Toggle checked state
                isGridShown = true;

                // draw grid
                setGridStatus(true);

                rasterUmschaltenToolStripMenuItem.Checked = true;
            }
        }

        // @TODO save method still in development
        private void saveMap(String filename)
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
                Item item = ItemCollection.getItemByKey(getNameWOCounter(name));
                position.X = position.X - item.getPositionOffsetX() - item.getBlockOffsetX(blockSize);
                position.Y = position.Y - item.getPositionOffsetY() - item.getBlockOffsetY(blockSize);

                mapFile.IniWriteValue("map", name + ".x", position.X.ToString());
                mapFile.IniWriteValue("map", name + ".y", position.Y.ToString());
            }
        }

        // @TODO not completed yet!
        private void loadMap(String filename)
        {
            if (!File.Exists(filename))
                throw new IOException("File not exists");

            // clear map panel
            mapPanel.Controls.Clear();

            IniFile mapFile = new IniFile(filename);

            // load all known objects
            foreach (Item item in ItemCollection.getAllItems())
            {
                int i = 0;
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
        
        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapPanel.Controls.Count > 0)
            {
                // if anything is set ask for permission
                DialogResult result = MessageBox.Show("Alle nicht gespeicherten Änderungen gehen verloren. Sind Sie sicher?", "Neue Map laden?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Remove all object from panel
                    mapPanel.Controls.Clear();
                }
            }
        }

        // removes grid when resizing (removes flickering)
        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            if (isGridShown)
            {
                setGridStatus(false);
            }
        }

        // set grid back to current status
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (isGridShown)
            {
                setGridStatus(true);
            }
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool itemsOnMap = false;
            if (mapPanel.Controls.Count > 0)
            {
                itemsOnMap = true;
                DialogResult result = MessageBox.Show("Möchten Sie alle vorhanden Objekte auf dem Feld vor dem Laden entfernen?", "Es befinden sich noch Objekte auf dem Feld!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    itemsOnMap = false;
            }

            if (!itemsOnMap && openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadMap(openFileDialog1.FileName);
            }
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkMapPanel())
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        saveMap(saveFileDialog1.FileName);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        // check all possible params before save
        private bool checkMapPanel()
        {
            if (mapPanel.Controls.Count == 0)
                throw new Exception("Es sind keine Objekte auf dem Feld.");

            return true;
        }

        private void garbageCollector_Tick(object sender, EventArgs e)
        {
            foreach (Control ctn in mapPanel.Controls)
            {
                if (ctn != null && ctn.Tag != null)
                {
                    if (ctn.Tag.Equals("remove"))
                    {
                        mapPanel.Controls.Remove(ctn);
                    }
                }
            }
        }
    }
}
