namespace T_ReXcape
{
    partial class GameEditor
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.spieler1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spieler2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.umleitungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.mapTab = new System.Windows.Forms.TabPage();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.infoTab = new System.Windows.Forms.TabPage();
            this.NUD_panelWidth = new System.Windows.Forms.NumericUpDown();
            this.NUD_panelHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.objectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.set = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.itemHolder = new System.Windows.Forms.Panel();
            this.zielToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lochToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.editorContextMenu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.mapTab.SuspendLayout();
            this.infoTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_panelWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_panelHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "T-ReXcape Map|*.xmap";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(625, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(12, 17);
            this.statusLabel.Text = "-";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.ladenToolStripMenuItem,
            this.speichernToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.mapToolStripMenuItem.Text = "&Datei";
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.neuToolStripMenuItem.ShowShortcutKeys = false;
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.neuToolStripMenuItem.Text = "&Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.ladenToolStripMenuItem.ShowShortcutKeys = false;
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ladenToolStripMenuItem.Text = "&Öffnen";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.ladenToolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.speichernToolStripMenuItem.ShowShortcutKeys = false;
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.speichernToolStripMenuItem.Text = "&Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.beendenToolStripMenuItem.Text = "&Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // editorContextMenu
            // 
            this.editorContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spieler1ToolStripMenuItem,
            this.spieler2ToolStripMenuItem1,
            this.zielToolStripMenuItem,
            this.umleitungToolStripMenuItem,
            this.wandToolStripMenuItem,
            this.lochToolStripMenuItem});
            this.editorContextMenu.Name = "mapAddStuff";
            this.editorContextMenu.Size = new System.Drawing.Size(153, 158);
            // 
            // spieler1ToolStripMenuItem
            // 
            this.spieler1ToolStripMenuItem.Name = "spieler1ToolStripMenuItem";
            this.spieler1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.spieler1ToolStripMenuItem.Text = "Start Spieler 1";
            this.spieler1ToolStripMenuItem.Click += new System.EventHandler(this.spieler1ToolStripMenuItem_Click);
            // 
            // spieler2ToolStripMenuItem1
            // 
            this.spieler2ToolStripMenuItem1.Name = "spieler2ToolStripMenuItem1";
            this.spieler2ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.spieler2ToolStripMenuItem1.Text = "Start Spieler 2";
            this.spieler2ToolStripMenuItem1.Click += new System.EventHandler(this.spieler2ToolStripMenuItem1_Click);
            // 
            // umleitungToolStripMenuItem
            // 
            this.umleitungToolStripMenuItem.Name = "umleitungToolStripMenuItem";
            this.umleitungToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.umleitungToolStripMenuItem.Text = "Umleitung";
            this.umleitungToolStripMenuItem.Click += new System.EventHandler(this.umleitungToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.mapTab);
            this.tabControl.Controls.Add(this.infoTab);
            this.tabControl.Location = new System.Drawing.Point(0, 143);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(625, 389);
            this.tabControl.TabIndex = 3;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // mapTab
            // 
            this.mapTab.AutoScroll = true;
            this.mapTab.Controls.Add(this.mapPanel);
            this.mapTab.Location = new System.Drawing.Point(4, 22);
            this.mapTab.Margin = new System.Windows.Forms.Padding(0);
            this.mapTab.Name = "mapTab";
            this.mapTab.Size = new System.Drawing.Size(617, 363);
            this.mapTab.TabIndex = 0;
            this.mapTab.Text = "Map";
            this.mapTab.UseVisualStyleBackColor = true;
            // 
            // mapPanel
            // 
            this.mapPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mapPanel.Location = new System.Drawing.Point(1, 1);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(560, 350);
            this.mapPanel.TabIndex = 2;
            this.mapPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseClick);
            this.mapPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseMove);
            // 
            // infoTab
            // 
            this.infoTab.Controls.Add(this.NUD_panelWidth);
            this.infoTab.Controls.Add(this.NUD_panelHeight);
            this.infoTab.Controls.Add(this.label2);
            this.infoTab.Controls.Add(this.label1);
            this.infoTab.Controls.Add(this.dataGridView1);
            this.infoTab.Location = new System.Drawing.Point(4, 22);
            this.infoTab.Name = "infoTab";
            this.infoTab.Padding = new System.Windows.Forms.Padding(3);
            this.infoTab.Size = new System.Drawing.Size(617, 363);
            this.infoTab.TabIndex = 1;
            this.infoTab.Text = "Infos";
            this.infoTab.UseVisualStyleBackColor = true;
            // 
            // NUD_panelWidth
            // 
            this.NUD_panelWidth.Location = new System.Drawing.Point(61, 44);
            this.NUD_panelWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_panelWidth.Name = "NUD_panelWidth";
            this.NUD_panelWidth.Size = new System.Drawing.Size(45, 20);
            this.NUD_panelWidth.TabIndex = 6;
            this.NUD_panelWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_panelWidth.Leave += new System.EventHandler(this.NUD_panelLeave);
            // 
            // NUD_panelHeight
            // 
            this.NUD_panelHeight.Location = new System.Drawing.Point(61, 70);
            this.NUD_panelHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_panelHeight.Name = "NUD_panelHeight";
            this.NUD_panelHeight.Size = new System.Drawing.Size(45, 20);
            this.NUD_panelHeight.TabIndex = 7;
            this.NUD_panelHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_panelHeight.Leave += new System.EventHandler(this.NUD_panelLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Höhe:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Breite:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.objectName,
            this.max,
            this.set});
            this.dataGridView1.Location = new System.Drawing.Point(8, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridView1.Size = new System.Drawing.Size(602, 353);
            this.dataGridView1.TabIndex = 0;
            // 
            // objectName
            // 
            this.objectName.HeaderText = "Name";
            this.objectName.Name = "objectName";
            this.objectName.ReadOnly = true;
            // 
            // max
            // 
            this.max.HeaderText = "Max. Verfügbar";
            this.max.Name = "max";
            this.max.ReadOnly = true;
            this.max.Width = 150;
            // 
            // set
            // 
            this.set.HeaderText = "Bereits plaziert";
            this.set.Name = "set";
            this.set.ReadOnly = true;
            this.set.Width = 150;
            // 
            // itemHolder
            // 
            this.itemHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemHolder.AutoScroll = true;
            this.itemHolder.BackColor = System.Drawing.Color.Silver;
            this.itemHolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.itemHolder.Location = new System.Drawing.Point(12, 27);
            this.itemHolder.Name = "itemHolder";
            this.itemHolder.Size = new System.Drawing.Size(601, 100);
            this.itemHolder.TabIndex = 4;
            // 
            // zielToolStripMenuItem
            // 
            this.zielToolStripMenuItem.Name = "zielToolStripMenuItem";
            this.zielToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zielToolStripMenuItem.Text = "Ziel";
            this.zielToolStripMenuItem.Click += new System.EventHandler(this.zielToolStripMenuItem_Click);
            // 
            // wandToolStripMenuItem
            // 
            this.wandToolStripMenuItem.Name = "wandToolStripMenuItem";
            this.wandToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.wandToolStripMenuItem.Text = "Wand";
            this.wandToolStripMenuItem.Click += new System.EventHandler(this.wandToolStripMenuItem_Click);
            // 
            // lochToolStripMenuItem
            // 
            this.lochToolStripMenuItem.Name = "lochToolStripMenuItem";
            this.lochToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lochToolStripMenuItem.Text = "Loch";
            this.lochToolStripMenuItem.Click += new System.EventHandler(this.lochToolStripMenuItem_Click_1);
            // 
            // GameEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 557);
            this.Controls.Add(this.itemHolder);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "GameEditor";
            this.Text = "Map Editor";
            this.Load += new System.EventHandler(this.GameEditor_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.editorContextMenu.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.mapTab.ResumeLayout(false);
            this.infoTab.ResumeLayout(false);
            this.infoTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_panelWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_panelHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ladenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage mapTab;
        private System.Windows.Forms.TabPage infoTab;
        private System.Windows.Forms.ContextMenuStrip editorContextMenu;
        private System.Windows.Forms.ToolStripMenuItem spieler1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spieler2ToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn max;
        private System.Windows.Forms.DataGridViewTextBoxColumn set;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem umleitungToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.NumericUpDown NUD_panelWidth;
        private System.Windows.Forms.NumericUpDown NUD_panelHeight;
        private System.Windows.Forms.Panel itemHolder;
        private System.Windows.Forms.ToolStripMenuItem zielToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lochToolStripMenuItem;
    }
}

