using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Timers;

// only for debug
using System.Diagnostics;

namespace T_ReXcape
{
    public partial class GameEditor : Form
    {
        // variables
        Point mousePosition;
        Map map;

        public GameEditor()
        {
            // init formComponents
            InitializeComponent();

            // init Items
            Config.initItems();
           
            // set file filters
            openFileDialog1.Filter = Config.getMapFileFilter();
            saveFileDialog1.Filter = Config.getMapFileFilter();

            // init Map and register events
            map = new Map(mapPanel);
            map.registerControlClickEventHandler(new System.EventHandler(dragDropMouseClick));
            map.registerControlDoubleClickEventHandler(new System.EventHandler(removeClick));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
                
        // add objects
        private void addPlayer1Start(object sender, EventArgs e)
        {
            if (!map.setObjectOnMap("player1start", mousePosition))
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        private void zielToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!map.setObjectOnMap("player1destination", mousePosition))
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        private void startToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!map.setObjectOnMap("player2start", mousePosition))
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        private void zielToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!map.setObjectOnMap("player2destination", mousePosition))
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        private void mauerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!map.setObjectOnMap("wallv", mousePosition))
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        private void grubbeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!map.setObjectOnMap("wallh", mousePosition))
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }
        
        private void rechtsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!map.setObjectOnMap("goright", mousePosition))
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        private void linksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!map.setObjectOnMap("goleft", mousePosition))
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        private void obenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!map.setObjectOnMap("gotop", mousePosition))
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        private void untenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!map.setObjectOnMap("gobottom", mousePosition))
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        private void lochToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!map.setObjectOnMap("hole", mousePosition))
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        // onclick drag will be activated, on second click deactivated
        private void dragDropMouseClick(Object sender, EventArgs e)
        {
            if (sender.GetType().IsSubclassOf(typeof(Control)))
            {
                if (map.getDragObject() == null)
                {
                    map.setDragObject((Control)sender);
                    map.getDragObject().BackColor = Config.getActiveColor();

                    // if grid not activated in settings, show it on moved object
                    if (!map.getGridStatus())
                        map.setGrid(true);
                }
                else
                {
                    map.getDragObject().BackColor = Color.Transparent;
                    map.setDragObject(null);

                    if (!map.getGridStatus())
                        map.setGrid(false);
                }
            }
        }

        // on double click removes object
        private void removeClick(Object sender, EventArgs e)
        {
            if (map.getDragObject() == null)
                return;

            DialogResult result = MessageBox.Show("Möchten Sie dieses Objekt sicher entfernen?", "Objekt entfernen?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // @TODO eigene Animationklasse?
                int offset = 10;
                
                int boomSize = (((Control)sender).Width > ((Control)sender).Height) ? ((Control)sender).Width : ((Control)sender).Height;
                int minSize = (((Control)sender).Width < ((Control)sender).Height) ? ((Control)sender).Width : ((Control)sender).Height;
                
                boomSize += offset;

                Point position = map.getDragObject().Location;
                position.X -= offset;
                position.Y -= ((boomSize - minSize) / 2) + offset;

                PictureBox img = new PictureBox();
                img.Width = boomSize;
                img.Height = boomSize;
                img.BackColor = Color.Transparent;
                img.Image = (Image)Properties.Resources.ResourceManager.GetObject("spideyblast");
                img.SizeMode = PictureBoxSizeMode.Zoom;
                img.Location = position;
                img.Name = "boom";

                mapPanel.Controls.Add(img);
                img.BringToFront();

                ((Control)sender).Tag = "remove";

                map.setDragObject(null);

                if (!map.getGridStatus())
                    map.setGrid(false);


                EasyTimer.SetTimeout(() =>
                {
                    img.Tag = "remove";
                }, 1200);
            }
        }

        // moves locked object with mouse move
        private void mapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (map.getDragObject() != null)
            {
                if (!map.dragObjectToPoint(e.Location))
                {
                    setStatusLabelWithTimeout("Sie können dies nicht hier hin pazieren");
                }
            }
        }

        // opens context rightclick on map
        private void mapPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mousePosition = new Point(e.X, e.Y);
                editorContextMenu.Show(Cursor.Position);
            }
        }
        

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            // only execute if infos page opened
            if (e.TabPageIndex == 1)
            {
                // set map size
                NUD_panelWidth.Value = map.getWidthBlocks();
                NUD_panelHeight.Value = map.getHeightBlocks();

                // clear grid view
                dataGridView1.Rows.Clear();

                // show map/item information
                foreach (Item item in ItemCollection.getAllItems())
                {
                    dataGridView1.Rows.Add(item.getName(), item.getMaxOnPanel(), map.getItemCount(item.getKey()));
                }
            }
            
        }

        private void rasterUmschaltenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.toggleGrid();
            rasterUmschaltenToolStripMenuItem.Checked = map.getGridStatus();
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map.getItemsCount() > 0)
            {
                // if anything is set ask for permission
                DialogResult result = MessageBox.Show("Alle nicht gespeicherten Änderungen gehen verloren. Sind Sie sicher?", "Neue Map laden?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Remove all object from panel
                    map.clearMap();
                }
            }
        }

        // removes grid when resizing (removes flickering)
        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            if (map.getGridStatus())
            {
                map.setGrid(false);
            }
        }

        // set grid back to current status
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (map.getGridStatus())
            {
                map.setGrid(true);
            }
            
        }

        // auslagern Map Class
        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool itemsOnMap = false;
            if (map.getItemsCount() > 0)
            {
                itemsOnMap = true;
                DialogResult result = MessageBox.Show("Möchten Sie alle vorhanden Objekte auf dem Feld vor dem Laden entfernen?", "Es befinden sich noch Objekte auf dem Feld!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    itemsOnMap = false;
            }

            if (!itemsOnMap && openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                map.loadMap(openFileDialog1.FileName);
            }
        }

        // auslagern Map Class
        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (map.checkMapPanel())
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        map.saveMap(saveFileDialog1.FileName);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        // @TODO save performance !!!
        private void garbageCollector_Tick(object sender, EventArgs e)
        {
            foreach (Control ctn in mapPanel.Controls)
            {
                if (ctn != null && ctn.Tag != null)
                {
                    if (ctn.Tag.Equals("remove"))
                    {
                        mapPanel.Controls.Remove(ctn);
                    }
                }
            }
        }

        private void setStatusLabelWithTimeout(String text, float seconds = 1) 
        {
            if (!text.Equals(statusLabel.Text))
            {
                // set status text
                statusLabel.Text = text;

                // reset after delay
                EasyTimer.SetTimeout(() =>
                {
                    statusLabel.Text = "-";
                }, (int)seconds * 1000);
            }
        }

        private void NUD_panelWidth_Leave(object sender, EventArgs e)
        {
            map.updateMapSizeBlocks(Convert.ToInt32(NUD_panelWidth.Value), Convert.ToInt32(NUD_panelHeight.Value));
        }

        private void NUD_panelHeight_Leave(object sender, EventArgs e)
        {
            map.updateMapSizeBlocks(Convert.ToInt32(NUD_panelWidth.Value), Convert.ToInt32(NUD_panelHeight.Value));
        }
    }
}
