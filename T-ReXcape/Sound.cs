using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace T_ReXcape
{
    class Sound
    {
        // variables
        SoundPlayer player;

        /// <summary>
        /// Init player
        /// </summary>
        public Sound()
        {
            player = new SoundPlayer();
        }

        /// <summary>
        /// set track to soundtrack
        /// </summary>
        public void setSoundtrack()
        {
            player.Stream = Properties.Resources.trexcape_soundtrack;
        }

        /// <summary>
        /// Play track once;
        /// </summary>
        public void playOnce()
        {
            
        }

        /// <summary>
        /// Play track in loop
        /// </summary>
        public void playLoop()
        {
            if (isReadyToPlay())
            {
                player.PlayLooping();
            }
        }

        /// <summary>
        /// Stop track
        /// </summary>
        public void stop()
        {
            if (isReadyToPlay())
            {
                player.Stop();
            }
        }

        /// <summary>
        /// checks if player is ready to play
        /// </summary>
        private Boolean isReadyToPlay()
        {
            // @TODO more validation?
            return player.Stream != null ? true : false;
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
