using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace T_ReXcape
{
    class Sound
    {
        public static void playBoom()
        {
            SoundPlayer player = new SoundPlayer();
            player.Stream = Properties.Resources.blast;
            player.Play();
        }
    }
}
