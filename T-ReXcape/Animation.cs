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
        // variables
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
        /// Starts rubber animation on specific object
        /// </summary>
        /// <param name="obj">Picturebox</param>
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
