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
using MMBizHawkTool.Controls.Components;

namespace MMBizHawkTool.Controls.Panels
{
	/// <summary>
	/// Interaction logic for RotationPanel.xaml
	/// </summary>
	public partial class RotationPanel : BasePanel
	{
		public RotationPanel()
		{
			InitializeComponent();
		}

		/// <inheritdoc />
		public override void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			IEnumerable<Watch> updatedValues = itemsAdresses.Where<Watch>(w => handledItems.ContainsKey((long)w.Address));
			foreach (Watch w in updatedValues)
			{
				((RotationViewer)handledItems[(long)w.Address]).Angle = double.Parse(w.ValueString) / 65535 * 360;
			}
		}
	}
}
