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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernUnterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plazierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spielerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zielToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spieler2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zielToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hindernissToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mauerVertikalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mauerHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grubbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapPanel = new System.Windows.Forms.Panel();
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
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.settingsResetButton = new System.Windows.Forms.Button();
            this.settingsSaveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mapwidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mapheight = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            this.mapAddStuff.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.mapTab.SuspendLayout();
            this.settingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapwidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapheight)).BeginInit();
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
            this.plazierenToolStripMenuItem});
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
            // plazierenToolStripMenuItem
            // 
            this.plazierenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spielerToolStripMenuItem,
            this.spieler2ToolStripMenuItem,
            this.hindernissToolStripMenuItem});
            this.plazierenToolStripMenuItem.Name = "plazierenToolStripMenuItem";
            this.plazierenToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.plazierenToolStripMenuItem.Text = "&Plazieren";
            // 
            // spielerToolStripMenuItem
            // 
            this.spielerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.zielToolStripMenuItem});
            this.spielerToolStripMenuItem.Name = "spielerToolStripMenuItem";
            this.spielerToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.spielerToolStripMenuItem.Text = "Spieler 1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // zielToolStripMenuItem
            // 
            this.zielToolStripMenuItem.Name = "zielToolStripMenuItem";
            this.zielToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.zielToolStripMenuItem.Text = "Ziel";
            // 
            // spieler2ToolStripMenuItem
            // 
            this.spieler2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem1,
            this.zielToolStripMenuItem1});
            this.spieler2ToolStripMenuItem.Name = "spieler2ToolStripMenuItem";
            this.spieler2ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.spieler2ToolStripMenuItem.Text = "Spieler 2";
            // 
            // startToolStripMenuItem1
            // 
            this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
            this.startToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem1.Text = "Start";
            // 
            // zielToolStripMenuItem1
            // 
            this.zielToolStripMenuItem1.Name = "zielToolStripMenuItem1";
            this.zielToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.zielToolStripMenuItem1.Text = "Ziel";
            // 
            // hindernissToolStripMenuItem
            // 
            this.hindernissToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mauerVertikalToolStripMenuItem,
            this.mauerHorizontalToolStripMenuItem,
            this.grubbeToolStripMenuItem});
            this.hindernissToolStripMenuItem.Name = "hindernissToolStripMenuItem";
            this.hindernissToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.hindernissToolStripMenuItem.Text = "Hindernis";
            // 
            // mauerVertikalToolStripMenuItem
            // 
            this.mauerVertikalToolStripMenuItem.Name = "mauerVertikalToolStripMenuItem";
            this.mauerVertikalToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.mauerVertikalToolStripMenuItem.Text = "Mauer vertikal";
            // 
            // mauerHorizontalToolStripMenuItem
            // 
            this.mauerHorizontalToolStripMenuItem.Name = "mauerHorizontalToolStripMenuItem";
            this.mauerHorizontalToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.mauerHorizontalToolStripMenuItem.Text = "Mauer horizontal";
            // 
            // grubbeToolStripMenuItem
            // 
            this.grubbeToolStripMenuItem.Name = "grubbeToolStripMenuItem";
            this.grubbeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.grubbeToolStripMenuItem.Text = "Grubbe";
            // 
            // mapPanel
            // 
            this.mapPanel.BackColor = System.Drawing.Color.Green;
            this.mapPanel.Location = new System.Drawing.Point(0, 0);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(543, 418);
            this.mapPanel.TabIndex = 2;
            this.mapPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseClick);
            this.mapPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseMove);
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
            this.startToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.startToolStripMenuItem2.Text = "Start";
            this.startToolStripMenuItem2.Click += new System.EventHandler(this.addPlayer1Start);
            // 
            // zielToolStripMenuItem2
            // 
            this.zielToolStripMenuItem2.Name = "zielToolStripMenuItem2";
            this.zielToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.zielToolStripMenuItem2.Text = "Ziel";
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
            this.mauerToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.mauerToolStripMenuItem.Text = "Mauer";
            // 
            // grubbeToolStripMenuItem1
            // 
            this.grubbeToolStripMenuItem1.Name = "grubbeToolStripMenuItem1";
            this.grubbeToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.grubbeToolStripMenuItem1.Text = "Grube";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.mapTab);
            this.tabControl.Controls.Add(this.settingsTab);
            this.tabControl.Location = new System.Drawing.Point(0, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(624, 486);
            this.tabControl.TabIndex = 3;
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
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.settingsResetButton);
            this.settingsTab.Controls.Add(this.settingsSaveButton);
            this.settingsTab.Controls.Add(this.label3);
            this.settingsTab.Controls.Add(this.label4);
            this.settingsTab.Controls.Add(this.mapwidth);
            this.settingsTab.Controls.Add(this.label2);
            this.settingsTab.Controls.Add(this.label1);
            this.settingsTab.Controls.Add(this.mapheight);
            this.settingsTab.Location = new System.Drawing.Point(4, 22);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(616, 460);
            this.settingsTab.TabIndex = 1;
            this.settingsTab.Text = "Einstellungen";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // settingsResetButton
            // 
            this.settingsResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsResetButton.Location = new System.Drawing.Point(441, 431);
            this.settingsResetButton.Name = "settingsResetButton";
            this.settingsResetButton.Size = new System.Drawing.Size(86, 23);
            this.settingsResetButton.TabIndex = 12;
            this.settingsResetButton.Text = "Zurücksetzen";
            this.settingsResetButton.UseVisualStyleBackColor = true;
            // 
            // settingsSaveButton
            // 
            this.settingsSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsSaveButton.Location = new System.Drawing.Point(533, 431);
            this.settingsSaveButton.Name = "settingsSaveButton";
            this.settingsSaveButton.Size = new System.Drawing.Size(75, 23);
            this.settingsSaveButton.TabIndex = 12;
            this.settingsSaveButton.Text = "Speichern";
            this.settingsSaveButton.UseVisualStyleBackColor = true;
            this.settingsSaveButton.Click += new System.EventHandler(this.settingsSaveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Blöcke";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Breite";
            // 
            // mapwidth
            // 
            this.mapwidth.Location = new System.Drawing.Point(119, 66);
            this.mapwidth.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.mapwidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mapwidth.Name = "mapwidth";
            this.mapwidth.Size = new System.Drawing.Size(81, 20);
            this.mapwidth.TabIndex = 9;
            this.mapwidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Blöcke";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Höhe";
            // 
            // mapheight
            // 
            this.mapheight.Location = new System.Drawing.Point(119, 39);
            this.mapheight.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.mapheight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mapheight.Name = "mapheight";
            this.mapheight.Size = new System.Drawing.Size(81, 20);
            this.mapheight.TabIndex = 6;
            this.mapheight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
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
            this.Name = "Form1";
            this.Text = "Map Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mapAddStuff.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.mapTab.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            this.settingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapwidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapheight)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem plazierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spielerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zielToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spieler2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zielToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hindernissToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mauerVertikalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mauerHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grubbeToolStripMenuItem;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage mapTab;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown mapwidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown mapheight;
        private System.Windows.Forms.Button settingsResetButton;
        private System.Windows.Forms.Button settingsSaveButton;
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
    }
}

