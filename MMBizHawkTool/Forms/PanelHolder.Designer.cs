namespace MMBizHawkTool.Forms
{
	partial class PanelHolder
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
			this.panelHost = new System.Windows.Forms.Integration.ElementHost();
			this.SuspendLayout();
			// 
			// panelHost
			// 
			this.panelHost.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelHost.Location = new System.Drawing.Point(0, 0);
			this.panelHost.Name = "panelHost";
			this.panelHost.Size = new System.Drawing.Size(284, 261);
			this.panelHost.TabIndex = 0;
			this.panelHost.Text = "panelHost";
			this.panelHost.Child = null;
			// 
			// PanelHolder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.panelHost);
			this.Name = "PanelHolder";
			this.Text = "PanelHolder";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Integration.ElementHost panelHost;
	}
}