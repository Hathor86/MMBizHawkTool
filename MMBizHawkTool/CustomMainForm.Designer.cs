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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.elementHost5 = new System.Windows.Forms.Integration.ElementHost();
			this.speedPanel1 = new MMBizHawkTool.Controls.SpeedPanel();
			this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
			this.itemsPanel1 = new MMBizHawkTool.Controls.ItemsPanel();
			this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
			this.questStatusPanel1 = new MMBizHawkTool.Controls.QuestStatusPanel();
			this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
			this.masksPanel1 = new MMBizHawkTool.Controls.MasksPanel();
			this.elementHost4 = new System.Windows.Forms.Integration.ElementHost();
			this.mapPanel1 = new MMBizHawkTool.Controls.MapPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
			this.tableLayoutPanel1.Controls.Add(this.elementHost1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.elementHost2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.elementHost3, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.elementHost4, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.elementHost5, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(521, 413);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// elementHost5
			// 
			this.elementHost5.Location = new System.Drawing.Point(373, 3);
			this.elementHost5.Name = "elementHost5";
			this.elementHost5.Size = new System.Drawing.Size(145, 100);
			this.elementHost5.TabIndex = 4;
			this.elementHost5.Text = "elementHost5";
			this.elementHost5.Child = this.speedPanel1;
			// 
			// elementHost1
			// 
			this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.elementHost1.Location = new System.Drawing.Point(3, 3);
			this.elementHost1.Name = "elementHost1";
			this.elementHost1.Size = new System.Drawing.Size(179, 200);
			this.elementHost1.TabIndex = 0;
			this.elementHost1.Text = "elementHost1";
			this.elementHost1.Child = this.itemsPanel1;
			// 
			// elementHost2
			// 
			this.elementHost2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.elementHost2.Location = new System.Drawing.Point(3, 209);
			this.elementHost2.Name = "elementHost2";
			this.elementHost2.Size = new System.Drawing.Size(179, 201);
			this.elementHost2.TabIndex = 1;
			this.elementHost2.Text = "elementHost2";
			this.elementHost2.Child = this.questStatusPanel1;
			// 
			// elementHost3
			// 
			this.elementHost3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.elementHost3.Location = new System.Drawing.Point(188, 3);
			this.elementHost3.Name = "elementHost3";
			this.elementHost3.Size = new System.Drawing.Size(179, 200);
			this.elementHost3.TabIndex = 2;
			this.elementHost3.Text = "elementHost3";
			this.elementHost3.Child = this.masksPanel1;
			// 
			// elementHost4
			// 
			this.elementHost4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.elementHost4.Location = new System.Drawing.Point(188, 209);
			this.elementHost4.Name = "elementHost4";
			this.elementHost4.Size = new System.Drawing.Size(179, 201);
			this.elementHost4.TabIndex = 3;
			this.elementHost4.Text = "s";
			this.elementHost4.Child = this.mapPanel1;
			// 
			// CustomMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(521, 413);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "CustomMainForm";
			this.Text = "CustomMainForm";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Integration.ElementHost elementHost1;
		private MMBizHawkTool.Controls.ItemsPanel itemsPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Integration.ElementHost elementHost2;
		private MMBizHawkTool.Controls.QuestStatusPanel questStatusPanel1;
		private System.Windows.Forms.Integration.ElementHost elementHost3;
		private MMBizHawkTool.Controls.MasksPanel masksPanel1;
		private System.Windows.Forms.Integration.ElementHost elementHost4;
		private MMBizHawkTool.Controls.MapPanel mapPanel1;
		private System.Windows.Forms.Integration.ElementHost elementHost5;
		private MMBizHawkTool.Controls.SpeedPanel speedPanel1;
	}
}