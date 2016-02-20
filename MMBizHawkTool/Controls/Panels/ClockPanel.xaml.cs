using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BizHawk.Client.Common;

namespace MMBizHawkTool.Controls.Panels
{
	/// <summary>
	/// Interaction logic for ClockPanel.xaml
	/// </summary>
	public partial class ClockPanel : BasePanel
	{
		private const double OneGameSecond = 86400d / 65535d; //Number of real seconds / IG seconds.FF FF (65535) is midnight

		public ClockPanel()
		{
			InitializeComponent();
		}

		public override void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			if (itemsAdresses.Any())
			{
				ushort time = (ushort)itemsAdresses.ToArray()[0].Value;
				double hour = Math.Floor(time * OneGameSecond / 3600d);
				double minute = Math.Floor((time * OneGameSecond / 3600d - hour) * 60);
				double second = Math.Floor(((((time * OneGameSecond / 3600d) - hour) * 60) - minute) * 60);
				Clock.Time = string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);
			}
		}
	}
}
