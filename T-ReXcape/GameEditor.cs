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
            map.redrawBackground();
            map.registerControlClickEventHandler(new System.EventHandler(dragDropMouseClick));
            map.registerControlDoubleClickEventHandler(new System.EventHandler(removeClick));

            // init garbage collector
            GarbageCollector.init(mapPanel);
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

        /// <summary>
        /// onclick drag will be activated, on second click deactivated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dragDropMouseClick(Object sender, EventArgs e)
        {
            // check sender type
            if (sender.GetType().IsSubclassOf(typeof(Control)))
            {
                // check if object targeted
                if (map.getDragObject() == null)
                {
                    map.setDragObject((Control)sender);
                    map.getDragObject().BackColor = Config.getActiveColor();
                }
                else
                {
                    // reset everything on second click
                    map.getDragObject().BackColor = Color.Transparent;
                    map.setDragObject(null);
                }
            }
        }

        /// <summary>
        /// double click removes object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeClick(Object sender, EventArgs e)
        {
            // check target object
            if (map.getDragObject() == null)
                return;

            DialogResult result = MessageBox.Show("Möchten Sie dieses Objekt sicher entfernen?", "Objekt entfernen?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Animation anim = new Animation(mapPanel);
                PictureBox obj = sender as PictureBox;

                anim.eraseObject(obj);

                obj.Image = null;
                obj.BackColor = Color.Transparent;

                map.setDragObject(null);
            }
        }

        /// <summary>
        /// moves locked object with mouse move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// opens context rightclick on map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mousePosition = new Point(e.X, e.Y);
                editorContextMenu.Show(Cursor.Position);
            }
        }
        
        /// <summary>
        /// update info page on select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// toggle grid on map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rasterUmschaltenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rasterUmschaltenToolStripMenuItem.Checked = map.getGridStatus();
        }

        /// <summary>
        /// create new map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// load map file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                map.setAllObjectsOnMap();
            }
        }

        /// <summary>
        /// save map file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// set status text wich disapears after delay
        /// </summary>
        /// <param name="text"></param>
        /// <param name="seconds"></param>
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

        private void speichernUnterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
