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

        public Form1()
        {
            InitializeComponent();
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
            Panel panel = new Panel();
            panel.Width = 20;
            panel.Height = 20;
            panel.BackColor = Color.Red;
            panel.Location = mousePosition;
            panel.Name = "player1.start";
            panel.Click += new System.EventHandler(dragDropMouseClick);
            mapPanel.Controls.Add(panel);
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
    }
}
