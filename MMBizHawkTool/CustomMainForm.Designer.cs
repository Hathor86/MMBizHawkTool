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
			this.panelLoader_Items = new MMBizHawkTool.Controls.Buttons.PanelLoaderButton();
			this.panelLoader_Masks = new MMBizHawkTool.Controls.Buttons.PanelLoaderButton();
			this.panelLoader_QuestStatus = new MMBizHawkTool.Controls.Buttons.PanelLoaderButton();
			this.panelLoader_Map = new MMBizHawkTool.Controls.Buttons.PanelLoaderButton();
			this.panelLoader_HiddenQuestStatus = new MMBizHawkTool.Controls.Buttons.PanelLoaderButton();
			this.panelLoader_Speed = new MMBizHawkTool.Controls.Buttons.PanelLoaderButton();
			this.panelLoader_Rotation = new MMBizHawkTool.Controls.Buttons.PanelLoaderButton();
			this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
			this.clock1 = new MMBizHawkTool.Controls.Components.Clock();
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
			// panelLoader_Items
			// 
			this.panelLoader_Items.Appearance = System.Windows.Forms.Appearance.Button;
			this.panelLoader_Items.AutoSize = true;
			this.panelLoader_Items.Location = new System.Drawing.Point(12, 27);
			this.panelLoader_Items.Name = "panelLoader_Items";
			this.panelLoader_Items.PanelType = null;
			this.panelLoader_Items.Size = new System.Drawing.Size(42, 23);
			this.panelLoader_Items.TabIndex = 1;
			this.panelLoader_Items.Text = "Items";
			this.panelLoader_Items.UseVisualStyleBackColor = true;
			// 
			// panelLoader_Masks
			// 
			this.panelLoader_Masks.Appearance = System.Windows.Forms.Appearance.Button;
			this.panelLoader_Masks.Location = new System.Drawing.Point(60, 27);
			this.panelLoader_Masks.Name = "panelLoader_Masks";
			this.panelLoader_Masks.PanelType = null;
			this.panelLoader_Masks.Size = new System.Drawing.Size(42, 23);
			this.panelLoader_Masks.TabIndex = 2;
			this.panelLoader_Masks.Text = "Masks";
			this.panelLoader_Masks.UseVisualStyleBackColor = true;
			// 
			// panelLoader_QuestStatus
			// 
			this.panelLoader_QuestStatus.Appearance = System.Windows.Forms.Appearance.Button;
			this.panelLoader_QuestStatus.AutoSize = true;
			this.panelLoader_QuestStatus.Location = new System.Drawing.Point(12, 56);
			this.panelLoader_QuestStatus.Name = "panelLoader_QuestStatus";
			this.panelLoader_QuestStatus.PanelType = null;
			this.panelLoader_QuestStatus.Size = new System.Drawing.Size(78, 23);
			this.panelLoader_QuestStatus.TabIndex = 3;
			this.panelLoader_QuestStatus.Text = "Quest Status";
			this.panelLoader_QuestStatus.UseVisualStyleBackColor = true;
			// 
			// panelLoader_Map
			// 
			this.panelLoader_Map.Appearance = System.Windows.Forms.Appearance.Button;
			this.panelLoader_Map.AutoSize = true;
			this.panelLoader_Map.Location = new System.Drawing.Point(12, 85);
			this.panelLoader_Map.Name = "panelLoader_Map";
			this.panelLoader_Map.PanelType = null;
			this.panelLoader_Map.Size = new System.Drawing.Size(38, 23);
			this.panelLoader_Map.TabIndex = 4;
			this.panelLoader_Map.Text = "Map";
			this.panelLoader_Map.UseVisualStyleBackColor = true;
			// 
			// panelLoader_HiddenQuestStatus
			// 
			this.panelLoader_HiddenQuestStatus.Appearance = System.Windows.Forms.Appearance.Button;
			this.panelLoader_HiddenQuestStatus.AutoSize = true;
			this.panelLoader_HiddenQuestStatus.Location = new System.Drawing.Point(96, 56);
			this.panelLoader_HiddenQuestStatus.Name = "panelLoader_HiddenQuestStatus";
			this.panelLoader_HiddenQuestStatus.PanelType = null;
			this.panelLoader_HiddenQuestStatus.Size = new System.Drawing.Size(115, 23);
			this.panelLoader_HiddenQuestStatus.TabIndex = 5;
			this.panelLoader_HiddenQuestStatus.Text = "Hidden Quest Status";
			this.panelLoader_HiddenQuestStatus.UseVisualStyleBackColor = true;
			// 
			// panelLoader_Speed
			// 
			this.panelLoader_Speed.Appearance = System.Windows.Forms.Appearance.Button;
			this.panelLoader_Speed.AutoSize = true;
			this.panelLoader_Speed.Location = new System.Drawing.Point(60, 85);
			this.panelLoader_Speed.Name = "panelLoader_Speed";
			this.panelLoader_Speed.PanelType = null;
			this.panelLoader_Speed.Size = new System.Drawing.Size(48, 23);
			this.panelLoader_Speed.TabIndex = 6;
			this.panelLoader_Speed.Text = "Speed";
			this.panelLoader_Speed.UseVisualStyleBackColor = true;
			// 
			// panelLoader_Rotation
			// 
			this.panelLoader_Rotation.Appearance = System.Windows.Forms.Appearance.Button;
			this.panelLoader_Rotation.AutoSize = true;
			this.panelLoader_Rotation.Location = new System.Drawing.Point(115, 84);
			this.panelLoader_Rotation.Name = "panelLoader_Rotation";
			this.panelLoader_Rotation.PanelType = null;
			this.panelLoader_Rotation.Size = new System.Drawing.Size(57, 23);
			this.panelLoader_Rotation.TabIndex = 7;
			this.panelLoader_Rotation.Text = "Rotation";
			this.panelLoader_Rotation.UseVisualStyleBackColor = true;
			// 
			// elementHost1
			// 
			this.elementHost1.Location = new System.Drawing.Point(238, 192);
			this.elementHost1.Name = "elementHost1";
			this.elementHost1.Size = new System.Drawing.Size(180, 154);
			this.elementHost1.TabIndex = 8;
			this.elementHost1.Text = "elementHost1";
			this.elementHost1.Child = this.clock1;
			// 
			// CustomMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(521, 413);
			this.Controls.Add(this.elementHost1);
			this.Controls.Add(this.panelLoader_Rotation);
			this.Controls.Add(this.panelLoader_Speed);
			this.Controls.Add(this.panelLoader_HiddenQuestStatus);
			this.Controls.Add(this.panelLoader_Map);
			this.Controls.Add(this.panelLoader_QuestStatus);
			this.Controls.Add(this.panelLoader_Masks);
			this.Controls.Add(this.panelLoader_Items);
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
		private MMBizHawkTool.Controls.Buttons.PanelLoaderButton panelLoader_Items;
		private MMBizHawkTool.Controls.Buttons.PanelLoaderButton panelLoader_Masks;
		private MMBizHawkTool.Controls.Buttons.PanelLoaderButton panelLoader_QuestStatus;
		private MMBizHawkTool.Controls.Buttons.PanelLoaderButton panelLoader_Map;
		private MMBizHawkTool.Controls.Buttons.PanelLoaderButton panelLoader_HiddenQuestStatus;
		private MMBizHawkTool.Controls.Buttons.PanelLoaderButton panelLoader_Speed;
		private MMBizHawkTool.Controls.Buttons.PanelLoaderButton panelLoader_Rotation;
		private System.Windows.Forms.Integration.ElementHost elementHost1;
		private MMBizHawkTool.Controls.Components.Clock clock1;
	}
}