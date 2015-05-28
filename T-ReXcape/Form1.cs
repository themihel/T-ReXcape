using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

// only for debug
using System.Diagnostics;

namespace T_ReXcape
{
    public partial class Form1 : Form
    {
        // settings 
        int blockSize = 50;
        Color activeColor = Color.Red;

        Point mousePosition;
        Control dragDropObject = null;

        Bitmap newMagicPic;

        // save all posible objects on ma in this Dictionary
        Dictionary<string, Dictionary<string, string>> objects;

        public Form1()
        {
            InitializeComponent();
            objects = new Dictionary<string, Dictionary<string, string>>();
            // init all posible objects
            objects["player1start"] = new Dictionary<string, string>();
            objects["player1start"]["backGround"] = "dino1";
            objects["player1start"]["width"] = "150";
            objects["player1start"]["height"] = "150";
            objects["player1start"]["maxOnPanel"] = "1";
            objects["player1start"]["name"] = "Spieler 1 Start";

            objects["player1destination"] = new Dictionary<string, string>();
            objects["player1destination"]["backGround"] = "rocket1";
            objects["player1destination"]["width"] = "150";
            objects["player1destination"]["height"] = "180";
            objects["player1destination"]["maxOnPanel"] = "1";
            objects["player1destination"]["name"] = "Spieler 1 Ziel";

            objects["wallv"] = new Dictionary<string, string>();
            objects["wallv"]["backGround"] = "wallv";
            objects["wallv"]["width"] = "50";
            objects["wallv"]["height"] = "80";
            objects["wallv"]["maxOnPanel"] = "99";
            objects["wallv"]["name"] = "Mauer vertical";

            objects["wallh"] = new Dictionary<string, string>();
            objects["wallh"]["backGround"] = "wallh";
            objects["wallh"]["width"] = "80";
            objects["wallh"]["height"] = "50";
            objects["wallh"]["maxOnPanel"] = "99";
            objects["wallh"]["name"] = "Mauer horizontal";


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
            String type = "player1start";
            if (Convert.ToInt16(objects[type]["maxOnPanel"]) > countObjectOnPanel(type))
            {
                mapPanel.Controls.Add(preparePanelObject(type));
            }
        }

        private void zielToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            String type = "player1destination";
            if (Convert.ToInt16(objects[type]["maxOnPanel"]) > countObjectOnPanel(type))
            {
                mapPanel.Controls.Add(preparePanelObject(type));
            }
        }

        private void mauerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String type = "wallv";
            if (Convert.ToInt16(objects[type]["maxOnPanel"]) > countObjectOnPanel(type))
            {
                mapPanel.Controls.Add(preparePanelObject(type));
            }
        }

        private void grubbeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String type = "wallh";
            if (Convert.ToInt16(objects[type]["maxOnPanel"]) > countObjectOnPanel(type))
            {
                mapPanel.Controls.Add(preparePanelObject(type));
            }
        }

        // prepares object to add to panel
        private PictureBox preparePanelObject(String type)
        {
            PictureBox img = new PictureBox();
            img.Width = Convert.ToInt16(objects[type]["width"]);
            img.Height = Convert.ToInt16(objects[type]["height"]);
            img.BackColor = Color.Transparent;
            img.Image = (Image)Properties.Resources.ResourceManager.GetObject(objects[type]["backGround"]);
            img.SizeMode = PictureBoxSizeMode.Zoom;
            img.Location = getAccuratePosition(mousePosition);
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
                }
                else
                {
                    dragDropObject.BackColor = Color.Transparent;
                    dragDropObject = null;
                }
            }
        }

        // on double click removes object
        private void removeClick(Object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Möchten Sie dieses Objekt sicher entfernen?", "Objekt entfernen?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                mapPanel.Controls.Remove((Control)sender);
            }
        }

        // moves locked object with mouse move
        private void mapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragDropObject != null)
            {
                dragDropObject.Location = getAccuratePosition(e.Location);
                // @TODO remove after develop
                Debug.WriteLine("X:" + dragDropObject.Location.X + " Y:" + dragDropObject.Location.Y);
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

        /* @TODO remove after testing
         * saves all objects positions in ini file
         */
        private void speichernToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (!saveFileDialog1.FileName.Equals(""))
            {
                IniFile file = new IniFile(saveFileDialog1.FileName);

                file.IniWriteValue("config", "height", mapPanel.Height.ToString());
                file.IniWriteValue("config", "width", mapPanel.Width.ToString());

                foreach (Control child in mapPanel.Controls)
                {
                    String name = child.Name;
                    file.IniWriteValue("map", name + ".x", child.Location.X.ToString());
                    file.IniWriteValue("map", name + ".y", child.Location.Y.ToString());
                }
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
                if (Regex.Replace(child.Name, @"\d$", "").Equals(name))
                {
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// Draw grid on panel
        /// </summary>
        /// <param name="color">Gridlines color</param>
        private void drawGrid(Color color)
        {
            // @TODO evtl auslagern?
            Image bg = Properties.Resources.grass;
            Pen pen = new Pen(new SolidBrush(color));
            int width = (bg.Size.Width / blockSize) * blockSize;
            int height = (bg.Size.Height / blockSize) * blockSize;

            newMagicPic = new Bitmap(bg, width, height);
            Graphics gr = Graphics.FromImage(newMagicPic);
            for (int i = 0; i <= blockSize; i++)
            {
                for (int j = 0; j <= blockSize; j++)
                {
                    gr.DrawRectangle(pen, i * blockSize, j * blockSize, blockSize, blockSize);
                }
            }
            mapPanel.BackgroundImage = newMagicPic;
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            // set map size
            labelMapHeight.Text = mapPanel.Height.ToString();
            labelMapWidth.Text = mapPanel.Width.ToString();

            dataGridView1.Rows.Clear();
            foreach (KeyValuePair<string, Dictionary<string, string>> entry in objects)
            {
                dataGridView1.Rows.Add(entry.Value["name"], entry.Value["maxOnPanel"], countObjectOnPanel(entry.Key));
            }
        }

        private void rasterZeichnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rasterUmschaltenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle grid
            if (rasterUmschaltenToolStripMenuItem.Checked)
            {
                // Toggle checked state
                rasterUmschaltenToolStripMenuItem.Checked = false;

                // set normal background
                mapPanel.BackgroundImage = Properties.Resources.grass;
            }
            else
            {
                // Toggle checked state
                rasterUmschaltenToolStripMenuItem.Checked = true;

                // draw grid
                drawGrid(Color.Gray);
            }
        }
    }
}
