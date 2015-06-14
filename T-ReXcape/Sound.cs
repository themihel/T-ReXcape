using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

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
            SoundPlayer player = new SoundPlayer();
            player.Stream = Properties.Resources.blast;
            player.Play();
        }
    }
}
