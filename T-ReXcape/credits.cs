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
    public partial class Credits : Form
    {
        /// <summary>
        /// Constructor / init components
        /// </summary>
        public Credits()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close panel
        /// </summary>
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}
