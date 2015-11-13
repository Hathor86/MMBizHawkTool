namespace BizHawk.Client.EmuHawk
{
    partial class CustomMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panelLoaderButton1 = new MMBizHawkTool.Controls.Buttons.PanelLoaderButton();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(521, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// panelLoaderButton1
			// 
			this.panelLoaderButton1.Appearance = System.Windows.Forms.Appearance.Button;
			this.panelLoaderButton1.AutoSize = true;
			this.panelLoaderButton1.Location = new System.Drawing.Point(12, 27);
			this.panelLoaderButton1.Name = "panelLoaderButton1";
			this.panelLoaderButton1.Size = new System.Drawing.Size(113, 23);
			this.panelLoaderButton1.TabIndex = 1;
			this.panelLoaderButton1.Text = "panelLoaderButton1";
			this.panelLoaderButton1.UseVisualStyleBackColor = true;
			// 
			// CustomMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(521, 413);
			this.Controls.Add(this.panelLoaderButton1);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "CustomMainForm";
			this.Text = "CustomMainForm";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private MMBizHawkTool.Controls.Buttons.PanelLoaderButton panelLoaderButton1;
	}
}