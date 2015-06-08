using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T_ReXcape
{
    class GarbageCollector
    {
        public static Panel mapPanel;

        /// <summary>
        /// init garbage collector
        /// removes unnecessary objects from map
        /// </summary>
        /// <param name="map">Map Panel</param>
        /// <param name="interval">Interval</param>
        public static void init(Panel map, int interval = 1000)
        {
            mapPanel = map;
            Timer timer = new Timer();
            timer.Interval = interval;
            timer.Tick += new EventHandler(garbageTick);
            timer.Start();
        }

        /// <summary>
        /// garbage collector tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void garbageTick(object sender, EventArgs e)
        {
            foreach (PictureBox ctn in mapPanel.Controls)
            {
                if (ctn != null && ctn is PictureBox)
                {
                    if (ctn.Image == null)
                    {
                        mapPanel.Controls.Remove(ctn);
                    }
                }
            }
        }
    }
}
