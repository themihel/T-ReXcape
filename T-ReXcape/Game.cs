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

            // init garbage collector
            GarbageCollector.init(mapPanel, 500);
        }

        /// <summary>
        /// sets form in fullscreen mode
        /// </summary>
        public void goFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.TopLevel = true;
        }
        
        /// <summary>
        /// load map and prepare everything
        /// </summary>
        /// <param name="file">filepath and filename</param>
        public void loadFile(String file)
        {
            // calculate maximum resolution
            int maxHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int maxWidth = Screen.PrimaryScreen.WorkingArea.Width;

            if (Config.getFullscreen())
            {   
                // load map temporary 
                Map tmpMap = new Map(new Panel());
                tmpMap.loadMap(file);

                // calculate new blocksize to zoom map in fullscreen
                int countBlockSizeWidth = maxWidth / tmpMap.getWidthBlocks();
                int countBlockSizeHeight = maxHeight / tmpMap.getHeightBlocks();
                int newBlockSize = (countBlockSizeHeight > countBlockSizeWidth) ? countBlockSizeWidth : countBlockSizeHeight;

                // set new blocksize
                Config.setBlockSize(newBlockSize);
            }
            else
            {
                // reset block size. just to be sure
                Config.setDefaultBlockSize();
            }

            // clean garbage in item collection
            ItemCollection.disposeAllItems();

            // prepare new Items
            Config.initItems();

            // load actual map and draw everything
            Map map = new Map(mapPanel);
            map.registerControlClickEventHandler(item_Click);
            map.loadMap(file);
            map.setAllObjectsOnMap();

            Point mapPosition = new Point(0, 0);

            if (Config.getFullscreen())
            {
                // center panel on form
                mapPosition = new Point((mapPanel.Parent.Width - mapPanel.Width) / 2, (mapPanel.Parent.Height - mapPanel.Height) / 2);
            }

            // set map panel location on form
            mapPanel.Location = mapPosition;

            // set form size to map size (only in window mode)
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

        // @TODO testing only
        private void item_Click(object sender, EventArgs e)
        {
            Animation anim = new Animation(mapPanel);
            PictureBox obj = sender as PictureBox;

            anim.explodeOnObject(obj);

            obj.Image = null;
            obj.BackColor = Color.Transparent;
        }

        /// <summary>
        /// @TODO
        /// only for debug. has to be refactored
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// @TODO
        /// only for debug. has to be refactored
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        Point mousePosition;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Control cntr = sender as Control;
            mousePosition = new Point(cntr.Width / 2, cntr.Height / 2);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mousePosition = default(Point);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mousePosition.Equals(default(Point)))
            {
                int newX = e.X - mousePosition.X;
                int newY = mousePosition.Y - e.Y;
                if (newX < newY && (newX * -1) < newY && newY > 0)
                {
                    // top
                    label2.Text = "⇑";
                }
                else if (newX > newY && (newX * -1) > newY && newY < 0)
                {
                    // bottom
                    label2.Text = "⇓";
                }
                else if (newY < newX && (newY * -1) < newX && newX > 0)
                {
                    // right
                    label2.Text = "⇒";
                }
                else if (newY > newX && (newY * -1) > newX && newX < 0)
                {
                    // left
                    label2.Text = "⇐";
                }
            }
        }
    }
}
