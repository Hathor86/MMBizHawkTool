using BizHawk.Client.Common;
using MMBizHawkTool.Tools;
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

namespace MMBizHawkTool.Controls
{
	/// <summary>
	/// Interaction logic for ItemsPanel.xaml
	/// </summary>
	public partial class ItemsPanel : UserControl, IMMPanel
	{
		#region Fields

		private Dictionary<long, Image> _HandledItems = new Dictionary<long, Image>();

		private bool editMode = false;

		#endregion

		#region cTor(s)

		public ItemsPanel()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Add address to the panel's dictionnary.
		/// It helps to control the corresponding image behavior
		/// </summary>
		/// <param name="address">Ram adress (it's in fact the unique key)</param>
		/// <param name="imageName">Name of the Image Control</param>
		public void AddToDictionnary(long address, string imageName)
		{
			_HandledItems.Add(address, (Image)FindName(imageName));
		}

		/// <summary>
		/// Switch the panel between edit and read only mode
		/// </summary>
		public void SwitchMode()
		{
			editMode = !editMode;
		}

		/// <summary>
		/// Update items passed in parameters
		/// </summary>
		/// <param name="itemsAdresses"></param>
		public void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			foreach (Watch z in itemsAdresses.Where<Watch>(w => _HandledItems.ContainsKey(w.Address ?? 0)))
			{
				if (DataDictionnary.ResourceIndex.ContainsKey(z.Value ?? 0))
				{
					_HandledItems[z.Address ?? 0].Source = new BitmapImage(new Uri(string.Format(@"pack://application:,,,{0}", DataDictionnary.ResourceIndex[z.Value ?? 0])));
					_HandledItems[z.Address ?? 0].Effect = null;
				}
				else
				{
					_HandledItems[z.Address ?? 0].Source = null;
				}
			}

		}

		#endregion

		#region Properties

		public IEnumerable<long> HandledItems
		{
			get
			{
				return _HandledItems.Keys.AsEnumerable<long>();
			}
		}

		#endregion
	}
}
