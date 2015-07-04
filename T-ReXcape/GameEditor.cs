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
        // last mouse position
        Point mousePosition;

        // map
        Map map;

        // copy / paste item
        Item copyItem;

        /// <summary>
        /// Load components / set mapfile filters / init map / init garbagecollector
        /// </summary>
        public GameEditor()
        {
            // init formComponents
            InitializeComponent();
                       
            // set file filters
            openFileDialog1.Filter = Config.getMapFileFilter();
            saveFileDialog1.Filter = Config.getMapFileFilter();

            // init Map and register events
            map = new Map(ref mapPanel);
            map.setCreativeMode(true);
            map.redrawBackground();
            map.registerControlClickEventHandler(new System.EventHandler(dragDropMouseClick));

            // init garbage collector
            GarbageCollector.init(mapPanel);
        }
                
        /// <summary>
        /// Add player1start item
        /// </summary>
        private void spieler1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map.setObjectOnMap("player1start", mousePosition) == null)
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        /// <summary>
        /// Add player2start item
        /// </summary>
        private void spieler2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (map.setObjectOnMap("player2start", mousePosition) == null)
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        /// <summary>
        /// Add destination item
        /// </summary>
        private void zielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map.setObjectOnMap("destination", mousePosition) == null)
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        /// <summary>
        /// Add goto item
        /// </summary>
        private void umleitungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map.setObjectOnMap("goto", mousePosition) == null)
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        /// <summary>
        /// Add wall item
        /// </summary>
        private void wandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map.setObjectOnMap("wall", mousePosition) == null)
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        /// <summary>
        /// Add hole item
        /// </summary>
        private void lochToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (map.setObjectOnMap("hole", mousePosition) == null)
                setStatusLabelWithTimeout("Objekt konnte hier nicht plaziert werden.", 3);
        }

        /// <summary>
        /// onclick drag will be activated, on second click deactivated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dragDropMouseClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                //DialogResult result = MessageBox.Show("Möchten Sie dieses Objekt sicher entfernen?", "Objekt entfernen?", MessageBoxButtons.YesNo);
                if (true) // result == DialogResult.Yes)
                {
                    // init animation and get tagged picture box
                    Animation anim = new Animation(mapPanel);
                    PictureBox obj = sender as PictureBox;

                    // start animation
                    anim.eraseObject(obj);

                    // optical remove picture box until collected from GarbageCollector
                    obj.Image = null;
                    obj.BackColor = Color.Transparent;

                    // remove dragged object
                    map.setDragObject(null);
                }
            }
            else
            {
                // check if object targeted
                if (map.getDragObject() == null)
                {
                    map.setDragObject((Item)sender);
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
        /// moves locked object with mouse move
        /// </summary>
        private void mapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            // check if item
            if (map.getDragObject() != null)
            {
                // check if item is in place - user feedback
                if (!map.dragObjectToPoint(e.Location))
                {
                    setStatusLabelWithTimeout("Sie können dies nicht hier hin pazieren");
                }
            }
        }

        /// <summary>
        /// opens context rightclick on map
        /// </summary>
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
                    dataGridView1.Rows.Add(item.getDescription(), item.getMaxOnPanel(), map.getItemCount(item.getKey()));
                }
            }
            
        }

        /// <summary>
        /// create new map
        /// </summary>
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
        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // init BooleanVarialve
            bool itemsOnMap = false;

            // check if items on map
            if (map.getItemsCount() > 0)
            {
                itemsOnMap = true;
                DialogResult result = MessageBox.Show("Möchten Sie alle vorhanden Objekte auf dem Feld vor dem Laden entfernen?", "Es befinden sich noch Objekte auf dem Feld!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    itemsOnMap = false;
            }

            // no items on map or user clicked ok -> remove old items and load map
            if (!itemsOnMap && openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                map.loadMap(openFileDialog1.FileName);
                map.setAllObjectsOnMap();
            }
        }

        /// <summary>
        /// save map file
        /// </summary>
        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // check if any items on map
                if (map.checkMapPanel())
                {
                    // filedialog
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        // save map
                        map.saveMap(saveFileDialog1.FileName);
                    }
                }
            }
            catch (Exception exception)
            {
                // catch Exception (no items or save error)
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// set status text wich disapears after delay
        /// </summary>
        private void setStatusLabelWithTimeout(String text, float seconds = 1) 
        {
            if (!text.Equals(statusLabel.Text))
            {
                // set status text
                statusLabel.Text = text;

                // reset after delay
                EasyTimer.SetTimeout(() =>
                {
                    try {
                        statusLabel.Text = "-";
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }, (int)seconds * 1000);
            }
        }

        /// <summary>
        /// Update map size on tab change
        /// </summary>
        private void NUD_panelLeave(object sender, EventArgs e)
        {
            map.updateMapSizeBlocks(Convert.ToInt32(NUD_panelWidth.Value), Convert.ToInt32(NUD_panelHeight.Value));
        }

        /// <summary>
        /// Menu beenden
        /// </summary>
        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Load mapeditor
        /// </summary>
        private void GameEditor_Load(object sender, EventArgs e)
        {
            // variables
            int i = 0;

            // init all items
            Config.initItems();

            // store items in top panel
            foreach (Item itemOriginal in ItemCollection.getAllItems())
            {
                Item item = itemOriginal.clone();
                item.Location = new Point(i, 0);
                item.Cursor = Cursors.Hand;
                item.Click += new EventHandler(itemHolderClick);
                itemHolder.Controls.Add(item);

                i += item.getWidth();
            }

            // get number of blocks of mapPanel
            int widthInBlocks = map.pixelToBlock(mapPanel.Width);
            int heightInBlocks = map.pixelToBlock(mapPanel.Height);
            
            // set numeric up down in info panel
            NUD_panelWidth.Value = widthInBlocks;
            NUD_panelHeight.Value = heightInBlocks;

            // update size of maps
            map.updateMapSizeBlocks(widthInBlocks, heightInBlocks);
        }

        /// <summary>
        /// item holder
        /// </summary>
        private void itemHolderClick(object sender, EventArgs e)
        {
            if (map.getLastAddedItem() != null)
            {
                Item lastItem = map.getLastAddedItem();
                if (
                    lastItem.Location.X < 0 ||
                    lastItem.Location.Y < 0 ||
                    lastItem.Location.X > mapPanel.Width ||
                    lastItem.Location.Y > mapPanel.Height
                    )
                {
                    mapPanel.Controls.Remove(lastItem);
                }
            }

            Item item = sender as Item;
            if (map.setObjectOnMap(item.getKey(), new Point(0 - item.Width, 0 - item.Height)) != null)
            {
                map.setDragObject(map.getLastAddedItem());
                map.getDragObject().BackColor = Config.getActiveColor();
            }
        }

        /// <summary>
        /// Add copy/paste functionality for items
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (map.getDragObject() != null && keyData == (Keys.Control | Keys.C))
            {
                copyItem = map.getDragObject();
                return true;
            }
            else if (copyItem != null && keyData == (Keys.Control | Keys.V))
            {
                // check if max on panel is reached
                if (ItemCollection.getItemByKey(copyItem.getKey()).getMaxOnPanel() > map.getItemCount(copyItem.getKey()))
                {
                    // reset drag object
                    if (map.getDragObject() != null)
                        map.getDragObject().BackColor = Color.Transparent;

                    // place item
                    Item pasteItem = copyItem.clone();
                    map.cloneItem(pasteItem, new Point(0 - pasteItem.Width * 2, 0 - pasteItem.Height * 2));
                    map.setDragObject(map.getLastAddedItem());
                    map.getDragObject().BackColor = Config.getActiveColor();
                    return true;
                }
                else
                {
                    // catch error when object was deleted
                    copyItem = null;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
