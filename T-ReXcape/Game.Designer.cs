namespace T_ReXcape
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.mapPanel = new System.Windows.Forms.Panel();
            this.pausePanel = new System.Windows.Forms.Panel();
            this.soundeffect_panelbutton = new System.Windows.Forms.Panel();
            this.soundtrack_panelbutton = new System.Windows.Forms.Panel();
            this.rules_panelbutton = new System.Windows.Forms.Panel();
            this.continue_panelbutton = new System.Windows.Forms.Panel();
            this.close_panelbutton = new System.Windows.Forms.Panel();
            this.btnMenuPause = new System.Windows.Forms.Button();
            this.menuBar = new System.Windows.Forms.Panel();
            this.pausePanel.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapPanel
            // 
            this.mapPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mapPanel.BackgroundImage = global::T_ReXcape.Properties.Resources.grass;
            this.mapPanel.Location = new System.Drawing.Point(40, 109);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(78, 77);
            this.mapPanel.TabIndex = 3;
            // 
            // pausePanel
            // 
            this.pausePanel.BackColor = System.Drawing.SystemColors.Control;
            this.pausePanel.BackgroundImage = global::T_ReXcape.Properties.Resources.menu;
            this.pausePanel.Controls.Add(this.soundeffect_panelbutton);
            this.pausePanel.Controls.Add(this.soundtrack_panelbutton);
            this.pausePanel.Controls.Add(this.rules_panelbutton);
            this.pausePanel.Controls.Add(this.continue_panelbutton);
            this.pausePanel.Controls.Add(this.close_panelbutton);
            this.pausePanel.Location = new System.Drawing.Point(210, 280);
            this.pausePanel.Name = "pausePanel";
            this.pausePanel.Size = new System.Drawing.Size(472, 252);
            this.pausePanel.TabIndex = 0;
            this.pausePanel.Visible = false;
            // 
            // soundeffect_panelbutton
            // 
            this.soundeffect_panelbutton.BackColor = System.Drawing.Color.Transparent;
            this.soundeffect_panelbutton.Cursor = System.Windows.Forms.Cursors.Default;
            this.soundeffect_panelbutton.Location = new System.Drawing.Point(11, 139);
            this.soundeffect_panelbutton.Name = "soundeffect_panelbutton";
            this.soundeffect_panelbutton.Size = new System.Drawing.Size(42, 41);
            this.soundeffect_panelbutton.TabIndex = 12;
            this.soundeffect_panelbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.soundeffect_panelbutton_MouseClick);
            // 
            // soundtrack_panelbutton
            // 
            this.soundtrack_panelbutton.BackColor = System.Drawing.Color.Transparent;
            this.soundtrack_panelbutton.Cursor = System.Windows.Forms.Cursors.Default;
            this.soundtrack_panelbutton.Location = new System.Drawing.Point(12, 193);
            this.soundtrack_panelbutton.Name = "soundtrack_panelbutton";
            this.soundtrack_panelbutton.Size = new System.Drawing.Size(42, 41);
            this.soundtrack_panelbutton.TabIndex = 11;
            this.soundtrack_panelbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.soundtrack_panelbutton_MouseClick);
            // 
            // rules_panelbutton
            // 
            this.rules_panelbutton.BackColor = System.Drawing.Color.Transparent;
            this.rules_panelbutton.Cursor = System.Windows.Forms.Cursors.Default;
            this.rules_panelbutton.Location = new System.Drawing.Point(76, 161);
            this.rules_panelbutton.Name = "rules_panelbutton";
            this.rules_panelbutton.Size = new System.Drawing.Size(160, 60);
            this.rules_panelbutton.TabIndex = 10;
            this.rules_panelbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rules_panelbutton_MouseClick);
            // 
            // continue_panelbutton
            // 
            this.continue_panelbutton.BackColor = System.Drawing.Color.Transparent;
            this.continue_panelbutton.Cursor = System.Windows.Forms.Cursors.Default;
            this.continue_panelbutton.Location = new System.Drawing.Point(260, 161);
            this.continue_panelbutton.Name = "continue_panelbutton";
            this.continue_panelbutton.Size = new System.Drawing.Size(172, 60);
            this.continue_panelbutton.TabIndex = 9;
            this.continue_panelbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.continue_panelbutton_MouseClick);
            // 
            // close_panelbutton
            // 
            this.close_panelbutton.BackColor = System.Drawing.Color.Transparent;
            this.close_panelbutton.Cursor = System.Windows.Forms.Cursors.Default;
            this.close_panelbutton.Location = new System.Drawing.Point(422, 11);
            this.close_panelbutton.Name = "close_panelbutton";
            this.close_panelbutton.Size = new System.Drawing.Size(43, 46);
            this.close_panelbutton.TabIndex = 8;
            this.close_panelbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.close_panelbutton_MouseClick);
            // 
            // btnMenuPause
            // 
            this.btnMenuPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuPause.Location = new System.Drawing.Point(216, 3);
            this.btnMenuPause.Name = "btnMenuPause";
            this.btnMenuPause.Size = new System.Drawing.Size(43, 36);
            this.btnMenuPause.TabIndex = 4;
            this.btnMenuPause.Text = "| |";
            this.btnMenuPause.UseVisualStyleBackColor = true;
            this.btnMenuPause.Click += new System.EventHandler(this.btnMenuPause_Click);
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.Color.DarkGray;
            this.menuBar.Controls.Add(this.btnMenuPause);
            this.menuBar.Location = new System.Drawing.Point(12, 12);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(480, 76);
            this.menuBar.TabIndex = 6;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(716, 565);
            this.Controls.Add(this.menuBar);
            this.Controls.Add(this.pausePanel);
            this.Controls.Add(this.mapPanel);
            this.ForeColor = System.Drawing.Color.CadetBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "T-Re X cape";
            this.Shown += new System.EventHandler(this.Game_Shown);
            this.pausePanel.ResumeLayout(false);
            this.menuBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.Panel pausePanel;
        private System.Windows.Forms.Button btnMenuPause;
        private System.Windows.Forms.Panel menuBar;
        private System.Windows.Forms.Panel close_panelbutton;
        private System.Windows.Forms.Panel continue_panelbutton;
        private System.Windows.Forms.Panel rules_panelbutton;
        private System.Windows.Forms.Panel soundtrack_panelbutton;
        private System.Windows.Forms.Panel soundeffect_panelbutton;
    }
}