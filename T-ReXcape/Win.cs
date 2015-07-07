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
    public partial class Win : Form
    {
        public Win()
        {
            InitializeComponent();
        }

        public Win(Color color)
        {
            InitializeComponent();
            BackColor = color;
        }
    }
}
