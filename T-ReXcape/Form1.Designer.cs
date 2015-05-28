namespace T_ReXcape
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernUnterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rasterUmschaltenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapAddStuff = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.spieler1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.zielToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.spieler2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.zielToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.hindernisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mauerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grubbeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ladenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.mapAddStuff.SuspendLayout();
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
            this.testToolStripMenuItem,
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
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.neuToolStripMenuItem.Text = "&Neu";
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ladenToolStripMenuItem.Text = "&Laden";
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.speichernToolStripMenuItem.Text = "&Speichern";
            // 
            // speichernUnterToolStripMenuItem
            // 
            this.speichernUnterToolStripMenuItem.Name = "speichernUnterToolStripMenuItem";
            this.speichernUnterToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.speichernUnterToolStripMenuItem.Text = "&Beenden";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speichernToolStripMenuItem1,
            this.ladenToolStripMenuItem1});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // speichernToolStripMenuItem1
            // 
            this.speichernToolStripMenuItem1.Name = "speichernToolStripMenuItem1";
            this.speichernToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.speichernToolStripMenuItem1.Text = "Speichern";
            this.speichernToolStripMenuItem1.Click += new System.EventHandler(this.speichernToolStripMenuItem1_Click);
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
            this.rasterUmschaltenToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.rasterUmschaltenToolStripMenuItem.Text = "Raster umschalten";
            this.rasterUmschaltenToolStripMenuItem.Click += new System.EventHandler(this.rasterUmschaltenToolStripMenuItem_Click);
            // 
            // mapAddStuff
            // 
            this.mapAddStuff.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spieler1ToolStripMenuItem,
            this.spieler2ToolStripMenuItem1,
            this.hindernisToolStripMenuItem});
            this.mapAddStuff.Name = "mapAddStuff";
            this.mapAddStuff.Size = new System.Drawing.Size(126, 70);
            // 
            // spieler1ToolStripMenuItem
            // 
            this.spieler1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem2,
            this.zielToolStripMenuItem2});
            this.spieler1ToolStripMenuItem.Name = "spieler1ToolStripMenuItem";
            this.spieler1ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
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
            this.spieler2ToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.spieler2ToolStripMenuItem1.Text = "Spieler 2";
            // 
            // startToolStripMenuItem3
            // 
            this.startToolStripMenuItem3.Name = "startToolStripMenuItem3";
            this.startToolStripMenuItem3.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem3.Text = "Start";
            // 
            // zielToolStripMenuItem3
            // 
            this.zielToolStripMenuItem3.Name = "zielToolStripMenuItem3";
            this.zielToolStripMenuItem3.Size = new System.Drawing.Size(98, 22);
            this.zielToolStripMenuItem3.Text = "Ziel";
            // 
            // hindernisToolStripMenuItem
            // 
            this.hindernisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mauerToolStripMenuItem,
            this.grubbeToolStripMenuItem1});
            this.hindernisToolStripMenuItem.Name = "hindernisToolStripMenuItem";
            this.hindernisToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.objectName,
            this.max,
            this.set});
            this.dataGridView1.Location = new System.Drawing.Point(8, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
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
            // ladenToolStripMenuItem1
            // 
            this.ladenToolStripMenuItem1.Name = "ladenToolStripMenuItem1";
            this.ladenToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.ladenToolStripMenuItem1.Text = "Laden";
            this.ladenToolStripMenuItem1.Click += new System.EventHandler(this.ladenToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 538);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "Form1";
            this.Text = "Map Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mapAddStuff.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip mapAddStuff;
        private System.Windows.Forms.ToolStripMenuItem spieler1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem zielToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem spieler2ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem zielToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem hindernisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mauerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grubbeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem1;
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
        private System.Windows.Forms.ToolStripMenuItem ladenToolStripMenuItem1;
    }
}

