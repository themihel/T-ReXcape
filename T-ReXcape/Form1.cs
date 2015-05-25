using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// only for debug
using System.Diagnostics;

namespace T_ReXcape
{
    public partial class Form1 : Form
    {
        // settings 
        int blockSize = 10;


        Point mousePosition;
        Control dragDropObject = null;

        Dictionary<string, Dictionary<string, string>> objects;

        public Form1()
        {
            InitializeComponent();
            objects = new Dictionary<string, Dictionary<string, string>>();
            objects["player1start"] = new Dictionary<string, string>();
            objects["player1start"]["backGround"] = "Blue";
            objects["player1start"]["width"] = "30";
            objects["player1start"]["height"] = "30";
            objects["player1start"]["maxOnPanel"] = "1";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Map map = new Map();
            // open file dialog to select map file
            //openFileDialog1.ShowDialog();
            // set map path
            //map.setMapFileName(openFileDialog1.FileName);
        }

        private void updateSettings()
        {
            int mapHeight = Convert.ToInt16(mapheight.Value);
            int mapWidth = Convert.ToInt16(mapwidth.Value);

            mapPanel.Height = mapHeight * blockSize;
            mapPanel.Width = mapWidth * blockSize;
        }

        private void settingsSaveButton_Click(object sender, EventArgs e)
        {
            updateSettings();
        }
        
        private void addPlayer1Start(object sender, EventArgs e)
        {
            String type = "player1start";
            if (Convert.ToInt16(objects[type]["maxOnPanel"]) > countObjectOnPanel(type))
            {
                mapPanel.Controls.Add(preparePanelObject(type));
            }
        }

        private Panel preparePanelObject(String type)
        {
            Panel panel = new Panel();
            panel.Width = Convert.ToInt16(objects[type]["width"]);
            panel.Height = Convert.ToInt16(objects[type]["height"]);
            panel.BackColor = Color.FromName(objects[type]["backGround"]);
            panel.Location = mousePosition;
            panel.Name = type;
            panel.Click += new System.EventHandler(dragDropMouseClick);
            return panel;
        }

        private void dragDropMouseClick(Object sender, EventArgs e)
        {
            if (sender.GetType().IsSubclassOf(typeof(Control)))
            {
                if (dragDropObject == null)
                {
                    dragDropObject = (Control)sender;
                }
                else
                {
                    dragDropObject = null;
                }
            }
        }

        private void mapPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mousePosition = new Point(e.X, e.Y);
                mapAddStuff.Show(Cursor.Position);
            }
        }

        private void mapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragDropObject != null)
            {
                dragDropObject.Location = getPosition(e.Location);
                Debug.WriteLine("X:" + dragDropObject.Location.X + " Y:" + dragDropObject.Location.Y);
            }
        }

        private Point getPosition(Point p)
        {
            int x = (p.X / blockSize) * blockSize;
            int y = (p.Y / blockSize) * blockSize;
            return new Point(x, y);
        }

        private void speichernToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Control child in mapPanel.Controls)
            {
                saveFileDialog1.ShowDialog();
                if(!saveFileDialog1.FileName.Equals(""))
                {
                    IniFile file = new IniFile(saveFileDialog1.FileName);
                    file.IniWriteValue("map", child.Name + ".x", child.Location.X.ToString());
                    file.IniWriteValue("map", child.Name + ".y", child.Location.Y.ToString());
                }
            }
        }

        private int countObjectOnPanel(String name)
        {
            int result = 0;
            foreach (Control child in mapPanel.Controls)
            {
                if (child.Name.Equals(name))
                {
                    result++;
                }
            }
            return result;
        }
    }
}
