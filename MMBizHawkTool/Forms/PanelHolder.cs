using MMBizHawkTool.Controls.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Linq.Expressions;

namespace MMBizHawkTool.Forms
{
	/// <summary>
	/// A form that hold a <see cref="BasePanel"/>
	/// </summary>
	public partial class PanelHolder : Form 
	{
		#region Fields

		private static HashSet<BasePanel> panelList = new HashSet<BasePanel>();

		#endregion

		#region cTors()

		public PanelHolder()
		{
			InitializeComponent();		
		}

		#endregion

		#region Methods	

		protected override void OnClosed(EventArgs e)
		{
			panelList.Remove((BasePanel)panelHost.Child);
			base.OnClosed(e);
		}

		#endregion

		#region Properties

		public BasePanel Panel
		{
			get
			{
				return (BasePanel)panelHost.Child;
			}
			set
			{	
				panelHost.Child = value;
				panelList.Add(value);
            }
		}

		public static IEnumerable<BasePanel> Panels
		{
			get
			{
				return panelList;
            }
		}

		#endregion
	}
}
