using BizHawk.Client.EmuHawk;
using MMBizHawkTool.Controls.Panels;
using MMBizHawkTool.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMBizHawkTool.Controls.Buttons
{
	/// <summary>
	/// Just an extend button
	/// In holds a type of panel
	/// </summary>
	public class PanelLoaderButton : CheckBox
	{
		#region Fields

		private PanelHolder panelHolder;

		#endregion

		#region cTor(s)

		/// <summary>
		/// Initialize a new instance of PanelLoader
		/// </summary>
		public PanelLoaderButton()
			: base()
		{
			Appearance = Appearance.Button;
		}
		#endregion

		#region Methods

		protected override void OnClick(EventArgs e)
		{
			if (CheckState == CheckState.Unchecked)
			{
				panelHolder = new PanelHolder(PanelType, (CustomMainForm)this.Parent);
				panelHolder.FormClosed += delegate { this.CheckState = CheckState.Unchecked; };
				panelHolder.Show();
			}
			else
			{
				panelHolder.Dispose();
				panelHolder = null;
			}
			base.OnClick(e);
		}

		#endregion

		#region Properties

		public string PanelType
		{ get; set; }

		#endregion
	}
}
