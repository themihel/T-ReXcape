using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;

namespace T_ReXcape
{
    static class Sound
    {
        // soundtrack
        static private MediaPlayer soundtrackPlayer = new MediaPlayer();
        static private Boolean soundtrackLoaded = false;

        /// <summary>
        /// start playing soundtrack
        /// </summary>
        static public void playSoundtrack()
        {
            // load
            if (!soundtrackLoaded)
            {
                loadSoundtrack();
            }
            // play
            soundtrackPlayer.Play();
        }

        
        static private void loadSoundtrack()
        {
            // generate filename
            Random rand = new Random();
            String tempFileName =  "tmp" + rand.Next() + ".wav";

            // filepath
            String tempFilePath = System.IO.Path.GetTempPath() + tempFileName;
            
            
            
            // write temp file
            using (System.IO.Stream stream = Properties.Resources.trexcape_soundtrack)
            {
                using (System.IO.FileStream fileStream = new System.IO.FileStream(tempFilePath, System.IO.FileMode.Create))
                {
                    try
                    {
                        // write file
                        for (int i = 0; i < stream.Length; i++)
                        {
                            fileStream.WriteByte((byte)stream.ReadByte());
                        }

                        // close filestream
                        fileStream.Close();

                        // add filename to garbage collector
                        GarbageCollector.addTempRemove(tempFileName);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    
                }
            }

            // set filename of player
            soundtrackPlayer.Open(new System.Uri(@tempFilePath));

            // restart event
            soundtrackPlayer.MediaEnded += new EventHandler(Sound.soundtrackEndedEvent);

            // set loaded
            soundtrackLoaded = true;
        }

        /// <summary>
        /// Event when media has ended -> restart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static private void soundtrackEndedEvent(object sender, EventArgs e)
        {
            soundtrackPlayer.Position = TimeSpan.Zero;
            playSoundtrack();
        }

        /// <summary>
        /// stop playing soundtrack
        /// </summary>
        static public void stopSoundtrack()
        {
            soundtrackPlayer.Stop();
        }

        /// <summary>
        /// Play Boom sound once
        /// </summary>
        public static void playBoom()
        {
            playSound(Properties.Resources.blast);
        }

        /// <summary>
        /// Play Erase sound once
        /// </summary>
        public static void playErase()
        {
            playSound(Properties.Resources.erase_sound);
        }

        private static void playSound(System.IO.UnmanagedMemoryStream sound)
        {
            SoundPlayer player = new SoundPlayer();
            player.Stream = sound;
            player.Play();
        }
    }
}
