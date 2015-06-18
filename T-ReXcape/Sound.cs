using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace T_ReXcape
{
    static class Sound
    {
        // soundtrack
        static SoundPlayer soundtrackPlayer = new SoundPlayer();

        /// <summary>
        /// start playing soundtrack
        /// </summary>
        static public void playSoundtrack()
        {
            soundtrackPlayer.Stream = Properties.Resources.trexcape_soundtrack;
            soundtrackPlayer.PlayLooping();
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
