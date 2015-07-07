namespace T_ReXcape
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartUp));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mapStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.durchsuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.load_panelbutton = new System.Windows.Forms.Panel();
            this.editor_panelbutton = new System.Windows.Forms.Panel();
            this.credits_panelbutton = new System.Windows.Forms.Panel();
            this.exit_panelbutton = new System.Windows.Forms.Panel();
            this.soundeffect_panelbutton = new System.Windows.Forms.Panel();
            this.soundtrack_panelbutton = new System.Windows.Forms.Panel();
            this.fullscreen_panelbutton = new System.Windows.Forms.Panel();
            this.mapStrip.SuspendLayout();
            this.SuspendLayout();
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
            // load_panelbutton
            // 
            this.load_panelbutton.BackColor = System.Drawing.Color.Transparent;
            this.load_panelbutton.Cursor = System.Windows.Forms.Cursors.Default;
            this.load_panelbutton.Location = new System.Drawing.Point(162, 205);
            this.load_panelbutton.Name = "load_panelbutton";
            this.load_panelbutton.Size = new System.Drawing.Size(248, 92);
            this.load_panelbutton.TabIndex = 6;
            this.load_panelbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.load_panelbutton_MouseClick);
            // 
            // editor_panelbutton
            // 
            this.editor_panelbutton.BackColor = System.Drawing.Color.Transparent;
            this.editor_panelbutton.Location = new System.Drawing.Point(89, 303);
            this.editor_panelbutton.Name = "editor_panelbutton";
            this.editor_panelbutton.Size = new System.Drawing.Size(248, 92);
            this.editor_panelbutton.TabIndex = 7;
            this.editor_panelbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.editor_panelbutton_MouseClick);
            // 
            // credits_panelbutton
            // 
            this.credits_panelbutton.BackColor = System.Drawing.Color.Transparent;
            this.credits_panelbutton.Location = new System.Drawing.Point(54, 415);
            this.credits_panelbutton.Name = "credits_panelbutton";
            this.credits_panelbutton.Size = new System.Drawing.Size(248, 64);
            this.credits_panelbutton.TabIndex = 8;
            this.credits_panelbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.credits_panelbutton_MouseClick);
            // 
            // exit_panelbutton
            // 
            this.exit_panelbutton.BackColor = System.Drawing.Color.Transparent;
            this.exit_panelbutton.Location = new System.Drawing.Point(765, 12);
            this.exit_panelbutton.Name = "exit_panelbutton";
            this.exit_panelbutton.Size = new System.Drawing.Size(61, 56);
            this.exit_panelbutton.TabIndex = 9;
            this.exit_panelbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.exit_panelbutton_MouseClick);
            // 
            // soundeffect_panelbutton
            // 
            this.soundeffect_panelbutton.BackColor = System.Drawing.Color.Transparent;
            this.soundeffect_panelbutton.Location = new System.Drawing.Point(30, 537);
            this.soundeffect_panelbutton.Name = "soundeffect_panelbutton";
            this.soundeffect_panelbutton.Size = new System.Drawing.Size(60, 50);
            this.soundeffect_panelbutton.TabIndex = 10;
            this.soundeffect_panelbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.soundeffect_panelbutton_MouseClick);
            // 
            // soundtrack_panelbutton
            // 
            this.soundtrack_panelbutton.BackColor = System.Drawing.Color.Transparent;
            this.soundtrack_panelbutton.Location = new System.Drawing.Point(105, 537);
            this.soundtrack_panelbutton.Name = "soundtrack_panelbutton";
            this.soundtrack_panelbutton.Size = new System.Drawing.Size(66, 50);
            this.soundtrack_panelbutton.TabIndex = 11;
            this.soundtrack_panelbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.soundtrack_panelbutton_MouseClick);
            // 
            // fullscreen_panelbutton
            // 
            this.fullscreen_panelbutton.BackColor = System.Drawing.Color.Transparent;
            this.fullscreen_panelbutton.Location = new System.Drawing.Point(177, 537);
            this.fullscreen_panelbutton.Name = "fullscreen_panelbutton";
            this.fullscreen_panelbutton.Size = new System.Drawing.Size(60, 50);
            this.fullscreen_panelbutton.TabIndex = 12;
            this.fullscreen_panelbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fullscreen_panelbutton_MouseClick);
            // 
            // StartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::T_ReXcape.Properties.Resources.start_screen;
            this.ClientSize = new System.Drawing.Size(851, 600);
            this.Controls.Add(this.fullscreen_panelbutton);
            this.Controls.Add(this.soundtrack_panelbutton);
            this.Controls.Add(this.soundeffect_panelbutton);
            this.Controls.Add(this.exit_panelbutton);
            this.Controls.Add(this.credits_panelbutton);
            this.Controls.Add(this.editor_panelbutton);
            this.Controls.Add(this.load_panelbutton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartUp";
            this.Activated += new System.EventHandler(this.StartUp_Activated);
            this.Load += new System.EventHandler(this.StartUp_Load);
            this.mapStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip mapStrip;
        private System.Windows.Forms.ToolStripMenuItem durchsuchenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel load_panelbutton;
        private System.Windows.Forms.Panel editor_panelbutton;
        private System.Windows.Forms.Panel credits_panelbutton;
        private System.Windows.Forms.Panel exit_panelbutton;
        private System.Windows.Forms.Panel soundeffect_panelbutton;
        private System.Windows.Forms.Panel soundtrack_panelbutton;
        private System.Windows.Forms.Panel fullscreen_panelbutton;
    }
}