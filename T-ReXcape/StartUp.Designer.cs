﻿namespace T_ReXcape
{
    partial class StartUp
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.goFullscreenCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(88, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Map Editor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(88, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 62);
            this.button2.TabIndex = 1;
            this.button2.Text = "Level Laden";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // goFullscreenCheck
            // 
            this.goFullscreenCheck.AutoSize = true;
            this.goFullscreenCheck.Checked = true;
            this.goFullscreenCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.goFullscreenCheck.Location = new System.Drawing.Point(128, 132);
            this.goFullscreenCheck.Name = "goFullscreenCheck";
            this.goFullscreenCheck.Size = new System.Drawing.Size(74, 17);
            this.goFullscreenCheck.TabIndex = 2;
            this.goFullscreenCheck.Text = "Fullscreen";
            this.goFullscreenCheck.UseVisualStyleBackColor = true;
            // 
            // StartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 336);
            this.Controls.Add(this.goFullscreenCheck);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "StartUp";
            this.Text = "StartUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox goFullscreenCheck;
    }
}