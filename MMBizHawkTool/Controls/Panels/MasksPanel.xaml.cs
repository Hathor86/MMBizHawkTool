using BizHawk.Client.Common;
using MMBizHawkTool.Controls.Components;
using MMBizHawkTool.Tools;
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

namespace MMBizHawkTool.Controls.Panels
{
	/// <summary>
	/// Interaction logic for ItemsPanel.xaml
	/// </summary>
	public partial class MasksPanel : BasePanel
	{
		#region Fields
		#endregion

		#region cTor(s)

		public MasksPanel()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods			

		/// <inheritdoc />
		public override void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			foreach (Watch z in itemsAdresses.Where<Watch>(w => handledItems.ContainsKey((long)w.Address)))
			{
				if (DataDictionnary.ResourceIndex.ContainsKey((int)z.Value))
				{
					((Item)handledItems[(long)z.Address]).Source = new BitmapImage(new Uri(string.Format(@"pack://application:,,,{0}", DataDictionnary.ResourceIndex[(int)z.Value])));
				}
				else
				{
					((Item)handledItems[(long)z.Address]).Source = null;
				}
			}			
		}

		#endregion

		#region Properties
		#endregion
	}
}
