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

		private Form panelHandeld;

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
			base.OnClick(e);
			if (CheckState == CheckState.Checked)
			{
				panelHandeld = (Form)Activator.CreateInstance(PanelHolderType);
				panelHandeld.FormClosed += delegate { this.CheckState = CheckState.Unchecked; };
				panelHandeld.Show();
			}
			else
			{
				panelHandeld.Dispose();
				panelHandeld = null;
			}
		}

		#endregion

		#region Properties

		public Type PanelHolderType
		{
			get;
			set;
		}
		
		#endregion
	}
}
