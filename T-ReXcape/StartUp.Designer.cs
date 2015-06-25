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
            this.components = new System.ComponentModel.Container();
            this.btnMapEditor = new System.Windows.Forms.Button();
            this.btnLoadLevel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbFullscreen = new System.Windows.Forms.CheckBox();
            this.cbSoundtrack = new System.Windows.Forms.CheckBox();
            this.mapStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.durchsuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mapStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMapEditor
            // 
            this.btnMapEditor.Location = new System.Drawing.Point(601, 215);
            this.btnMapEditor.Name = "btnMapEditor";
            this.btnMapEditor.Size = new System.Drawing.Size(162, 58);
            this.btnMapEditor.TabIndex = 1;
            this.btnMapEditor.Text = "Start Map Editor";
            this.btnMapEditor.UseVisualStyleBackColor = true;
            this.btnMapEditor.Click += new System.EventHandler(this.btnMapEditor_Click);
            // 
            // btnLoadLevel
            // 
            this.btnLoadLevel.Location = new System.Drawing.Point(601, 147);
            this.btnLoadLevel.Name = "btnLoadLevel";
            this.btnLoadLevel.Size = new System.Drawing.Size(162, 62);
            this.btnLoadLevel.TabIndex = 0;
            this.btnLoadLevel.Text = "Level Laden / starten";
            this.btnLoadLevel.UseVisualStyleBackColor = true;
            this.btnLoadLevel.Click += new System.EventHandler(this.btnLoadLevel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(601, 279);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(162, 58);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Beenden";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbFullscreen
            // 
            this.cbFullscreen.AutoSize = true;
            this.cbFullscreen.BackColor = System.Drawing.Color.Transparent;
            this.cbFullscreen.Location = new System.Drawing.Point(765, 571);
            this.cbFullscreen.Name = "cbFullscreen";
            this.cbFullscreen.Size = new System.Drawing.Size(74, 17);
            this.cbFullscreen.TabIndex = 3;
            this.cbFullscreen.Text = "Fullscreen";
            this.cbFullscreen.UseVisualStyleBackColor = false;
            this.cbFullscreen.CheckedChanged += new System.EventHandler(this.cbFullscreen_CheckedChanged);
            // 
            // cbSoundtrack
            // 
            this.cbSoundtrack.AutoSize = true;
            this.cbSoundtrack.BackColor = System.Drawing.Color.Transparent;
            this.cbSoundtrack.Location = new System.Drawing.Point(676, 571);
            this.cbSoundtrack.Name = "cbSoundtrack";
            this.cbSoundtrack.Size = new System.Drawing.Size(81, 17);
            this.cbSoundtrack.TabIndex = 5;
            this.cbSoundtrack.Text = "Soundtrack";
            this.cbSoundtrack.UseVisualStyleBackColor = false;
            this.cbSoundtrack.CheckedChanged += new System.EventHandler(this.cbSoundtrack_CheckedChanged);
            // 
            // mapStrip
            // 
            this.mapStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.durchsuchenToolStripMenuItem,
            this.toolStripSeparator1});
            this.mapStrip.Name = "mapStrip";
            this.mapStrip.Size = new System.Drawing.Size(157, 32);
            this.mapStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mapStrip_ItemClicked);
            // 
            // durchsuchenToolStripMenuItem
            // 
            this.durchsuchenToolStripMenuItem.Name = "durchsuchenToolStripMenuItem";
            this.durchsuchenToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.durchsuchenToolStripMenuItem.Tag = "browse";
            this.durchsuchenToolStripMenuItem.Text = "Durchsuchen ...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // StartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::T_ReXcape.Properties.Resources.bgtest;
            this.ClientSize = new System.Drawing.Size(851, 600);
            this.Controls.Add(this.cbSoundtrack);
            this.Controls.Add(this.cbFullscreen);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLoadLevel);
            this.Controls.Add(this.btnMapEditor);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartUp";
            this.Load += new System.EventHandler(this.StartUp_Load);
            this.mapStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMapEditor;
        private System.Windows.Forms.Button btnLoadLevel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox cbFullscreen;
        private System.Windows.Forms.CheckBox cbSoundtrack;
        private System.Windows.Forms.ContextMenuStrip mapStrip;
        private System.Windows.Forms.ToolStripMenuItem durchsuchenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}