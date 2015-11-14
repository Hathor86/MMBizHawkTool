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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.aboutText = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label_Description = new System.Windows.Forms.Label();
			this.label_Name = new System.Windows.Forms.Label();
			this.label_Version = new System.Windows.Forms.Label();
			this.label_Copyright = new System.Windows.Forms.Label();
			this.textBox = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// aboutText
			// 
			this.aboutText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.aboutText.Location = new System.Drawing.Point(3, 128);
			this.aboutText.Multiline = true;
			this.aboutText.Name = "aboutText";
			this.aboutText.ReadOnly = true;
			this.aboutText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.aboutText.Size = new System.Drawing.Size(300, 130);
			this.aboutText.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.aboutText, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(306, 261);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.textBox);
			this.panel1.Controls.Add(this.label_Copyright);
			this.panel1.Controls.Add(this.label_Version);
			this.panel1.Controls.Add(this.label_Name);
			this.panel1.Controls.Add(this.label_Description);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(300, 119);
			this.panel1.TabIndex = 1;
			// 
			// label_Description
			// 
			this.label_Description.AutoSize = true;
			this.label_Description.Location = new System.Drawing.Point(3, 19);
			this.label_Description.Name = "label_Description";
			this.label_Description.Size = new System.Drawing.Size(60, 13);
			this.label_Description.TabIndex = 0;
			this.label_Description.Text = "Description";
			// 
			// label_Name
			// 
			this.label_Name.AutoSize = true;
			this.label_Name.Location = new System.Drawing.Point(3, 6);
			this.label_Name.Name = "label_Name";
			this.label_Name.Size = new System.Drawing.Size(35, 13);
			this.label_Name.TabIndex = 1;
			this.label_Name.Text = "Name";
			// 
			// label_Version
			// 
			this.label_Version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_Version.AutoSize = true;
			this.label_Version.Location = new System.Drawing.Point(125, 6);
			this.label_Version.Name = "label_Version";
			this.label_Version.Size = new System.Drawing.Size(42, 13);
			this.label_Version.TabIndex = 2;
			this.label_Version.Text = "Version";
			// 
			// label_Copyright
			// 
			this.label_Copyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_Copyright.AutoSize = true;
			this.label_Copyright.Location = new System.Drawing.Point(125, 19);
			this.label_Copyright.Name = "label_Copyright";
			this.label_Copyright.Size = new System.Drawing.Size(51, 13);
			this.label_Copyright.TabIndex = 3;
			this.label_Copyright.Text = "Copyright";
			// 
			// textBox
			// 
			this.textBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.textBox.Location = new System.Drawing.Point(0, 35);
			this.textBox.Multiline = true;
			this.textBox.Name = "textBox";
			this.textBox.ReadOnly = true;
			this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox.Size = new System.Drawing.Size(300, 84);
			this.textBox.TabIndex = 4;
			this.textBox.Text = resources.GetString("textBox.Text");
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(306, 261);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(322, 300);
			this.Name = "AboutForm";
			this.Text = "About";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.TextBox aboutText;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label_Name;
		private System.Windows.Forms.Label label_Description;
		private System.Windows.Forms.Label label_Copyright;
		private System.Windows.Forms.Label label_Version;
		private System.Windows.Forms.TextBox textBox;
	}
}