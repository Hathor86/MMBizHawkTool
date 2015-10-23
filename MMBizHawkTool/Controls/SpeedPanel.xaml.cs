using MMBizHawkTool.Tools.Interfaces;
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

namespace MMBizHawkTool.Controls
{
	/// <summary>
	/// Interaction logic for SpeedPanel.xaml
	/// </summary>
	public partial class SpeedPanel : UserControl, IMMPanel
	{
		private long address;

		public SpeedPanel()
		{
			InitializeComponent();
		}

		public void AddToDictionnary(long address, string imageName)
		{
			this.address = address;
		}

		public void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			RotateTransform r = ((TransformGroup)arrow.RenderTransform).Children[0] as RotateTransform;
			if(r != null)
			{

			}
			
		}
	}
}
