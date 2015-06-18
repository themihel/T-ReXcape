using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace T_ReXcape
{
    class Animation
    {
        public int offset = 10;
        public Panel mapPanel;

        /// <summary>
        /// load animation
        /// </summary>
        /// <param name="panel">Map Panel</param>
        public Animation(Panel panel)
        {
            mapPanel = panel;
        }

        /// <summary>
        /// creates an explosion over given object
        /// </summary>
        /// <param name="obj"></param>
        public void explodeOnObject(PictureBox obj)
        {
            // calculate Sizes
            int boomSize = (obj.Width > obj.Height) ? obj.Width : obj.Height;
            int minSize = (obj.Width < obj.Height) ? obj.Width : obj.Height;

            // add offset to cover object properly
            boomSize += offset;

            // calculate animation position
            Point position = obj.Location;
            position.X -= offset;
            position.Y -= ((boomSize - minSize) / 2) + offset;

            // create new picture box with animation
            PictureBox img = new PictureBox();
            img.Width = boomSize;
            img.Height = boomSize;
            img.BackColor = Color.Transparent;
            img.Image = (Image)Properties.Resources.ResourceManager.GetObject("spideyblast");
            img.SizeMode = PictureBoxSizeMode.Zoom;
            img.Location = position;
            img.Name = "boom";

            // add animation to map panel
            mapPanel.Controls.Add(img);
            img.BringToFront();

            // play boom sound
            Sound.playBoom();

            // remove image after delay so garbage collector can remove it later on
            EasyTimer.SetTimeout(() =>
            {
                img.Image = null;
            }, 1200);
        }


        public void eraseObject(PictureBox obj)
        {
            // calculate animation position
            Point position = obj.Location;

            // create new picture box with animation
            PictureBox img = new PictureBox();
            img.Width = obj.Width;
            img.Height = obj.Height;
            img.BackColor = Color.Transparent;
            img.Image = (Image)Properties.Resources.ResourceManager.GetObject("erase");
            img.SizeMode = PictureBoxSizeMode.Zoom;
            img.Location = position;
            img.Name = "erase";

            // add animation to map panel
            mapPanel.Controls.Add(img);
            img.BringToFront();

            // play sound
            Sound.playErase();

            // remove image after delay so garbage collector can remove it later on
            EasyTimer.SetTimeout(() =>
            {
                img.Image = null;
            }, 1000);
        }
    }
}
