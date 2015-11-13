namespace MMBizHawkTool.Forms
{
	partial class AboutForm
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
			this.aboutText = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// aboutText
			// 
			this.aboutText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.aboutText.Location = new System.Drawing.Point(0, 0);
			this.aboutText.Multiline = true;
			this.aboutText.Name = "aboutText";
			this.aboutText.ReadOnly = true;
			this.aboutText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.aboutText.Size = new System.Drawing.Size(284, 261);
			this.aboutText.TabIndex = 0;
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.aboutText);
			this.Name = "AboutForm";
			this.Text = "About";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.TextBox aboutText;
	}
}