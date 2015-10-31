using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MMBizHawkTool.Controls.Panels
{
	public abstract class BasePanel : UserControl
	{
		#region Fields

		public static Dictionary<string, long> CommonAdresses = new Dictionary<string, long>();

		private Dictionary<long, Control> handledItems = new Dictionary<long, Control>();

		#endregion
	}
}
