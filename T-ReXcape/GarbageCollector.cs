using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T_ReXcape
{
    class GarbageCollector
    {
        // mapPanel
        public static Panel mapPanel;

        // tempRemove
        static private List<String> tempRemove = new List<String>();

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
                    if (
                        ctn.Image == null ||
                        ctn.Location.X < 0 ||
                        ctn.Location.Y < 0 ||
                        ctn.Location.X > mapPanel.Width ||
                        ctn.Location.Y > mapPanel.Height
                        )
                    {
                        mapPanel.Controls.Remove(ctn);
                    }
                }
            }
        }

        /// <summary>
        /// adds file to remove on close
        /// </summary>
        /// <param name="filename">Filenames in temp directory</param>
        public static void addTempRemove(String filename)
        {
            tempRemove.Add(filename);
        }

        /// <summary>
        /// clears temp directory
        /// </summary>
        public static void clearTempDir()
        {
            // init filepath
            String filePath;

            // loop through tempFiles
            foreach (var filename in tempRemove)
            {
                // generate filePath
                filePath = System.IO.Path.GetTempPath() + filename;
                // check if file exists
                if (File.Exists(filePath))
                {
                    // remove file
                    File.Delete(filePath);
                }
            }

            // clear list
            tempRemove.Clear();
        }
    }
}
