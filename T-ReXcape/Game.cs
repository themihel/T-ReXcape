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
    public partial class Game : Form
    {
        public Game(bool fullscreen = false)
        {
            InitializeComponent();
            if (fullscreen)
                goFullscreen();
        }

        public void goFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
