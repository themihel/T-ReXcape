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
            this.btnExitGame = new System.Windows.Forms.Button();
            this.cbSoundeffects = new System.Windows.Forms.CheckBox();
            this.cbSoundtrack = new System.Windows.Forms.CheckBox();
            this.btnGameRules = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
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
            this.pausePanel.Controls.Add(this.btnExitGame);
            this.pausePanel.Controls.Add(this.cbSoundeffects);
            this.pausePanel.Controls.Add(this.cbSoundtrack);
            this.pausePanel.Controls.Add(this.btnGameRules);
            this.pausePanel.Controls.Add(this.btnContinue);
            this.pausePanel.Location = new System.Drawing.Point(210, 280);
            this.pausePanel.Name = "pausePanel";
            this.pausePanel.Size = new System.Drawing.Size(472, 252);
            this.pausePanel.TabIndex = 0;
            this.pausePanel.Visible = false;
            // 
            // btnExitGame
            // 
            this.btnExitGame.Location = new System.Drawing.Point(419, 18);
            this.btnExitGame.Name = "btnExitGame";
            this.btnExitGame.Size = new System.Drawing.Size(53, 23);
            this.btnExitGame.TabIndex = 7;
            this.btnExitGame.Text = "Beenden";
            this.btnExitGame.UseVisualStyleBackColor = true;
            this.btnExitGame.Click += new System.EventHandler(this.btnExitGame_Click);
            // 
            // cbSoundeffects
            // 
            this.cbSoundeffects.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbSoundeffects.AutoSize = true;
            this.cbSoundeffects.Location = new System.Drawing.Point(195, 205);
            this.cbSoundeffects.Name = "cbSoundeffects";
            this.cbSoundeffects.Size = new System.Drawing.Size(81, 23);
            this.cbSoundeffects.TabIndex = 6;
            this.cbSoundeffects.Text = "Soundeffekte";
            this.cbSoundeffects.UseVisualStyleBackColor = true;
            this.cbSoundeffects.CheckedChanged += new System.EventHandler(this.cbSoundeffects_CheckedChanged);
            // 
            // cbSoundtrack
            // 
            this.cbSoundtrack.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbSoundtrack.AutoSize = true;
            this.cbSoundtrack.Location = new System.Drawing.Point(3, 148);
            this.cbSoundtrack.Name = "cbSoundtrack";
            this.cbSoundtrack.Size = new System.Drawing.Size(72, 23);
            this.cbSoundtrack.TabIndex = 5;
            this.cbSoundtrack.Text = "Soundtrack";
            this.cbSoundtrack.UseVisualStyleBackColor = true;
            this.cbSoundtrack.CheckedChanged += new System.EventHandler(this.cbSoundtrack_CheckedChanged);
            // 
            // btnGameRules
            // 
            this.btnGameRules.Location = new System.Drawing.Point(92, 176);
            this.btnGameRules.Name = "btnGameRules";
            this.btnGameRules.Size = new System.Drawing.Size(113, 23);
            this.btnGameRules.TabIndex = 4;
            this.btnGameRules.Text = "Spielregeln";
            this.btnGameRules.UseVisualStyleBackColor = true;
            this.btnGameRules.Click += new System.EventHandler(this.btnGameRules_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(293, 176);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(110, 23);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "Weiter";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
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
            this.pausePanel.PerformLayout();
            this.menuBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.Panel pausePanel;
        private System.Windows.Forms.Button btnMenuPause;
        private System.Windows.Forms.Panel menuBar;
        private System.Windows.Forms.Button btnGameRules;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.CheckBox cbSoundtrack;
        private System.Windows.Forms.CheckBox cbSoundeffects;
        private System.Windows.Forms.Button btnExitGame;
    }
}