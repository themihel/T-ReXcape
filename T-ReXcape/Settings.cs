using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T_ReXcape
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (Config.getFullscreen())
                fullscreenCheck.Checked = true;

            if (Config.getPlayMusic())
                musicCheck.Checked = true;

            if (Config.getPlaySoundEffects())
                soundeffectCheck.Checked = true;
        }

        private void fullscreenCheck_CheckedChanged(object sender, EventArgs e)
        {
            Config.setFullscreen(((CheckBox)sender).Checked);
        }

        private void musicCheck_CheckedChanged(object sender, EventArgs e)
        {
            Config.setPlayMusic(((CheckBox)sender).Checked);
        }

        private void soundeffectCheck_CheckedChanged(object sender, EventArgs e)
        {
            Config.setPlaySoundEffects(((CheckBox)sender).Checked);
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Config.saveSettings();
        }
    }
}
