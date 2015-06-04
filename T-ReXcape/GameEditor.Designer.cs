﻿namespace T_ReXcape
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernUnterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rasterUmschaltenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.spieler1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.zielToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.spieler2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.zielToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.hindernisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mauerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grubbeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lochToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.umleitungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechtsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.untenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.mapTab = new System.Windows.Forms.TabPage();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.infoTab = new System.Windows.Forms.TabPage();
            this.labelMapHeight = new System.Windows.Forms.Label();
            this.labelMapWidth = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.objectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.set = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.garbageCollector = new System.Windows.Forms.Timer(this.components);
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.editorContextMenu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.mapTab.SuspendLayout();
            this.infoTab.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 516);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapToolStripMenuItem,
            this.ansichtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.ladenToolStripMenuItem,
            this.speichernToolStripMenuItem,
            this.speichernUnterToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.mapToolStripMenuItem.Text = "&Datei";
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.neuToolStripMenuItem.ShowShortcutKeys = false;
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.neuToolStripMenuItem.Text = "&Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.ladenToolStripMenuItem.ShowShortcutKeys = false;
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ladenToolStripMenuItem.Text = "&Öffnen";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.ladenToolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.speichernToolStripMenuItem.ShowShortcutKeys = false;
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.speichernToolStripMenuItem.Text = "&Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // speichernUnterToolStripMenuItem
            // 
            this.speichernUnterToolStripMenuItem.Name = "speichernUnterToolStripMenuItem";
            this.speichernUnterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.speichernUnterToolStripMenuItem.Text = "&Beenden";
            // 
            // ansichtToolStripMenuItem
            // 
            this.ansichtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rasterUmschaltenToolStripMenuItem});
            this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
            this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ansichtToolStripMenuItem.Text = "Ansicht";
            // 
            // rasterUmschaltenToolStripMenuItem
            // 
            this.rasterUmschaltenToolStripMenuItem.Name = "rasterUmschaltenToolStripMenuItem";
            this.rasterUmschaltenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.rasterUmschaltenToolStripMenuItem.ShowShortcutKeys = false;
            this.rasterUmschaltenToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.rasterUmschaltenToolStripMenuItem.Text = "Raster anzeigen";
            this.rasterUmschaltenToolStripMenuItem.Click += new System.EventHandler(this.rasterUmschaltenToolStripMenuItem_Click);
            // 
            // editorContextMenu
            // 
            this.editorContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spieler1ToolStripMenuItem,
            this.spieler2ToolStripMenuItem1,
            this.hindernisToolStripMenuItem,
            this.umleitungToolStripMenuItem});
            this.editorContextMenu.Name = "mapAddStuff";
            this.editorContextMenu.Size = new System.Drawing.Size(131, 92);
            // 
            // spieler1ToolStripMenuItem
            // 
            this.spieler1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem2,
            this.zielToolStripMenuItem2});
            this.spieler1ToolStripMenuItem.Name = "spieler1ToolStripMenuItem";
            this.spieler1ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.spieler1ToolStripMenuItem.Text = "Spieler 1";
            // 
            // startToolStripMenuItem2
            // 
            this.startToolStripMenuItem2.Name = "startToolStripMenuItem2";
            this.startToolStripMenuItem2.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem2.Text = "Start";
            this.startToolStripMenuItem2.Click += new System.EventHandler(this.addPlayer1Start);
            // 
            // zielToolStripMenuItem2
            // 
            this.zielToolStripMenuItem2.Name = "zielToolStripMenuItem2";
            this.zielToolStripMenuItem2.Size = new System.Drawing.Size(98, 22);
            this.zielToolStripMenuItem2.Text = "Ziel";
            this.zielToolStripMenuItem2.Click += new System.EventHandler(this.zielToolStripMenuItem2_Click);
            // 
            // spieler2ToolStripMenuItem1
            // 
            this.spieler2ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem3,
            this.zielToolStripMenuItem3});
            this.spieler2ToolStripMenuItem1.Name = "spieler2ToolStripMenuItem1";
            this.spieler2ToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.spieler2ToolStripMenuItem1.Text = "Spieler 2";
            // 
            // startToolStripMenuItem3
            // 
            this.startToolStripMenuItem3.Name = "startToolStripMenuItem3";
            this.startToolStripMenuItem3.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem3.Text = "Start";
            this.startToolStripMenuItem3.Click += new System.EventHandler(this.startToolStripMenuItem3_Click);
            // 
            // zielToolStripMenuItem3
            // 
            this.zielToolStripMenuItem3.Name = "zielToolStripMenuItem3";
            this.zielToolStripMenuItem3.Size = new System.Drawing.Size(98, 22);
            this.zielToolStripMenuItem3.Text = "Ziel";
            this.zielToolStripMenuItem3.Click += new System.EventHandler(this.zielToolStripMenuItem3_Click);
            // 
            // hindernisToolStripMenuItem
            // 
            this.hindernisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mauerToolStripMenuItem,
            this.grubbeToolStripMenuItem1,
            this.lochToolStripMenuItem});
            this.hindernisToolStripMenuItem.Name = "hindernisToolStripMenuItem";
            this.hindernisToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.hindernisToolStripMenuItem.Text = "Hindernis";
            // 
            // mauerToolStripMenuItem
            // 
            this.mauerToolStripMenuItem.Name = "mauerToolStripMenuItem";
            this.mauerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.mauerToolStripMenuItem.Text = "Mauer vertikal";
            this.mauerToolStripMenuItem.Click += new System.EventHandler(this.mauerToolStripMenuItem_Click);
            // 
            // grubbeToolStripMenuItem1
            // 
            this.grubbeToolStripMenuItem1.Name = "grubbeToolStripMenuItem1";
            this.grubbeToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.grubbeToolStripMenuItem1.Text = "Mauer horizontal";
            this.grubbeToolStripMenuItem1.Click += new System.EventHandler(this.grubbeToolStripMenuItem1_Click);
            // 
            // lochToolStripMenuItem
            // 
            this.lochToolStripMenuItem.Name = "lochToolStripMenuItem";
            this.lochToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.lochToolStripMenuItem.Text = "Loch";
            this.lochToolStripMenuItem.Click += new System.EventHandler(this.lochToolStripMenuItem_Click);
            // 
            // umleitungToolStripMenuItem
            // 
            this.umleitungToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rechtsToolStripMenuItem,
            this.linksToolStripMenuItem,
            this.obenToolStripMenuItem,
            this.untenToolStripMenuItem});
            this.umleitungToolStripMenuItem.Name = "umleitungToolStripMenuItem";
            this.umleitungToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.umleitungToolStripMenuItem.Text = "Umleitung";
            // 
            // rechtsToolStripMenuItem
            // 
            this.rechtsToolStripMenuItem.Name = "rechtsToolStripMenuItem";
            this.rechtsToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.rechtsToolStripMenuItem.Text = "Rechts";
            this.rechtsToolStripMenuItem.Click += new System.EventHandler(this.rechtsToolStripMenuItem_Click);
            // 
            // linksToolStripMenuItem
            // 
            this.linksToolStripMenuItem.Name = "linksToolStripMenuItem";
            this.linksToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.linksToolStripMenuItem.Text = "Links";
            this.linksToolStripMenuItem.Click += new System.EventHandler(this.linksToolStripMenuItem_Click);
            // 
            // obenToolStripMenuItem
            // 
            this.obenToolStripMenuItem.Name = "obenToolStripMenuItem";
            this.obenToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.obenToolStripMenuItem.Text = "Oben";
            this.obenToolStripMenuItem.Click += new System.EventHandler(this.obenToolStripMenuItem_Click);
            // 
            // untenToolStripMenuItem
            // 
            this.untenToolStripMenuItem.Name = "untenToolStripMenuItem";
            this.untenToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.untenToolStripMenuItem.Text = "Unten";
            this.untenToolStripMenuItem.Click += new System.EventHandler(this.untenToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.mapTab);
            this.tabControl.Controls.Add(this.infoTab);
            this.tabControl.Location = new System.Drawing.Point(0, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(624, 486);
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
            this.mapTab.Size = new System.Drawing.Size(616, 460);
            this.mapTab.TabIndex = 0;
            this.mapTab.Text = "Map";
            this.mapTab.UseVisualStyleBackColor = true;
            // 
            // mapPanel
            // 
            this.mapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mapPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mapPanel.BackgroundImage = global::T_ReXcape.Properties.Resources.grass;
            this.mapPanel.Location = new System.Drawing.Point(1, 1);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(613, 457);
            this.mapPanel.TabIndex = 2;
            this.mapPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseClick);
            this.mapPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseMove);
            // 
            // infoTab
            // 
            this.infoTab.Controls.Add(this.labelMapHeight);
            this.infoTab.Controls.Add(this.labelMapWidth);
            this.infoTab.Controls.Add(this.label2);
            this.infoTab.Controls.Add(this.label1);
            this.infoTab.Controls.Add(this.dataGridView1);
            this.infoTab.Location = new System.Drawing.Point(4, 22);
            this.infoTab.Name = "infoTab";
            this.infoTab.Padding = new System.Windows.Forms.Padding(3);
            this.infoTab.Size = new System.Drawing.Size(616, 460);
            this.infoTab.TabIndex = 1;
            this.infoTab.Text = "Infos";
            this.infoTab.UseVisualStyleBackColor = true;
            // 
            // labelMapHeight
            // 
            this.labelMapHeight.AutoSize = true;
            this.labelMapHeight.Location = new System.Drawing.Point(80, 54);
            this.labelMapHeight.Name = "labelMapHeight";
            this.labelMapHeight.Size = new System.Drawing.Size(13, 13);
            this.labelMapHeight.TabIndex = 4;
            this.labelMapHeight.Text = "0";
            // 
            // labelMapWidth
            // 
            this.labelMapWidth.AutoSize = true;
            this.labelMapWidth.Location = new System.Drawing.Point(80, 72);
            this.labelMapWidth.Name = "labelMapWidth";
            this.labelMapWidth.Size = new System.Drawing.Size(13, 13);
            this.labelMapWidth.TabIndex = 3;
            this.labelMapWidth.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Höhe:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 72);
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.objectName,
            this.max,
            this.set});
            this.dataGridView1.Location = new System.Drawing.Point(8, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle9;
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
            // garbageCollector
            // 
            this.garbageCollector.Enabled = true;
            this.garbageCollector.Interval = 50;
            this.garbageCollector.Tick += new System.EventHandler(this.garbageCollector_Tick);
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(12, 17);
            this.statusLabel.Text = "-";
            // 
            // GameEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 538);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "GameEditor";
            this.Text = "Map Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.editorContextMenu.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.mapTab.ResumeLayout(false);
            this.infoTab.ResumeLayout(false);
            this.infoTab.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem speichernUnterToolStripMenuItem;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage mapTab;
        private System.Windows.Forms.TabPage infoTab;
        private System.Windows.Forms.ContextMenuStrip editorContextMenu;
        private System.Windows.Forms.ToolStripMenuItem spieler1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem zielToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem spieler2ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem zielToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem hindernisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mauerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grubbeToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn max;
        private System.Windows.Forms.DataGridViewTextBoxColumn set;
        private System.Windows.Forms.Label labelMapHeight;
        private System.Windows.Forms.Label labelMapWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rasterUmschaltenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem umleitungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechtsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem untenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lochToolStripMenuItem;
        private System.Windows.Forms.Timer garbageCollector;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}
