namespace T_ReXcape
{
    partial class Settings
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
            this.fullscreenCheck = new System.Windows.Forms.CheckBox();
            this.musicCheck = new System.Windows.Forms.CheckBox();
            this.soundeffectCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // fullscreenCheck
            // 
            this.fullscreenCheck.AutoSize = true;
            this.fullscreenCheck.Location = new System.Drawing.Point(12, 39);
            this.fullscreenCheck.Name = "fullscreenCheck";
            this.fullscreenCheck.Size = new System.Drawing.Size(74, 17);
            this.fullscreenCheck.TabIndex = 1;
            this.fullscreenCheck.Text = "Fullscreen";
            this.fullscreenCheck.UseVisualStyleBackColor = true;
            this.fullscreenCheck.CheckedChanged += new System.EventHandler(this.fullscreenCheck_CheckedChanged);
            // 
            // musicCheck
            // 
            this.musicCheck.AutoSize = true;
            this.musicCheck.Location = new System.Drawing.Point(12, 62);
            this.musicCheck.Name = "musicCheck";
            this.musicCheck.Size = new System.Drawing.Size(102, 17);
            this.musicCheck.TabIndex = 1;
            this.musicCheck.Text = "Musik abspielen";
            this.musicCheck.UseVisualStyleBackColor = true;
            this.musicCheck.CheckedChanged += new System.EventHandler(this.musicCheck_CheckedChanged);
            // 
            // soundeffectCheck
            // 
            this.soundeffectCheck.AutoSize = true;
            this.soundeffectCheck.Location = new System.Drawing.Point(12, 85);
            this.soundeffectCheck.Name = "soundeffectCheck";
            this.soundeffectCheck.Size = new System.Drawing.Size(138, 17);
            this.soundeffectCheck.TabIndex = 1;
            this.soundeffectCheck.Text = "Soundeffekte abspielen";
            this.soundeffectCheck.UseVisualStyleBackColor = true;
            this.soundeffectCheck.CheckedChanged += new System.EventHandler(this.soundeffectCheck_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 347);
            this.Controls.Add(this.soundeffectCheck);
            this.Controls.Add(this.musicCheck);
            this.Controls.Add(this.fullscreenCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Einstellungen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox fullscreenCheck;
        private System.Windows.Forms.CheckBox musicCheck;
        private System.Windows.Forms.CheckBox soundeffectCheck;
    }
}