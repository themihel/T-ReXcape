using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace T_ReXcape
{
    public partial class Game : Form
    {
        public Game(bool fullscreen = false)
        {
            InitializeComponent();
            if (fullscreen)
                goFullscreen();
        }

        public void goFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.TopLevel = true;
        }

        public void loadFile(String file)
        {
            int maxHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int maxWidth = Screen.PrimaryScreen.WorkingArea.Width;

            Map tmpMap = new Map(new Panel());
            tmpMap.loadMap(file);

            ItemCollection.disposeAllItems();
            if (Config.getFullscreen())
            {
                int newBlockSize = maxWidth / tmpMap.getWidthBlocks();
                Config.setBlockSize(newBlockSize);
            }
            else
            {
                Config.setDefaultBlockSize();
            }

            Config.initItems();

            Map map = new Map(mapPanel);
            map.loadMap(file);

            mapPanel.Location = new Point(0, 0);

            if (Config.getFullscreen())
            {
                // center panel on form
                mapPanel.Location = new Point((mapPanel.Parent.Width - mapPanel.Width) / 2, (mapPanel.Parent.Height - mapPanel.Height) / 2);
            }

            if (!Config.getFullscreen())
            {
                this.Height = map.getHeight();
                this.Width = map.getWidth();
            }

            // center pause menu on form
            pausePanel.Location = new Point((this.Width - pausePanel.Width) / 2, (this.Height - pausePanel.Height) / 2);

            // for debug
            map.setGrid(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pausePanel.Visible)
            {
                pausePanel.Visible = false;
            }
            else 
            {
                pausePanel.Visible = true;
            }
        }
    }
}
