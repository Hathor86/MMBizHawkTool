using BizHawk.Client.Common;
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
	public partial class ItemsPanel : BasePanel
	{
		#region Fields

		private Dictionary<long, Image> _HandledItems = new Dictionary<long, Image>();
		private Dictionary<long, TextBox> _AmmoTextBoxes = new Dictionary<long, TextBox>();

		#endregion

		#region cTor(s)

		public ItemsPanel()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		/// <inheritdoc />
		public override void AddToDictionnary(long address, string controlName)
		{
			object c = FindName(controlName);
			if (c.GetType() == typeof(Image))
			{
				_HandledItems.Add(address, (Image)c);
			}
			else if (c.GetType() == typeof(TextBox))
			{
				_AmmoTextBoxes.Add(address, (TextBox)c);
			}
		}

		/// <inheritdoc />
		public override void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			foreach (Watch z in itemsAdresses.Where<Watch>(w => _HandledItems.ContainsKey((long)w.Address)))
			{
				if (DataDictionnary.ResourceIndex.ContainsKey((int)z.Value))
				{
					_HandledItems[(long)z.Address].Source = new BitmapImage(new Uri(string.Format(@"pack://application:,,,{0}", DataDictionnary.ResourceIndex[(int)z.Value])));
				}
				else
				{
					_HandledItems[(long)z.Address].Source = null;
				}
			}
			foreach (Watch z in itemsAdresses.Where<Watch>(w => _AmmoTextBoxes.ContainsKey((long)w.Address)))
			{
				_AmmoTextBoxes[(long)z.Address].Text = z.ValueString;
            }

			if(itemsAdresses.Any<Watch>(z => z.Address == CommonAdresses["magicAmount"]))
			{
				int magic = (int)itemsAdresses.Where<Watch>(z => z.Address == CommonAdresses["magicAmount"]).First<Watch>().Value;
				if(magic == 0)
				{
					magic = 1;
				}
				fireArrowsCount.Text = Math.Floor(magic / 4f).ToString();
				iceArrowsCount.Text = Math.Floor(magic / 4f).ToString();
				lightArrowsCount.Text = Math.Floor(magic / 8f).ToString();
			}
        }

		#endregion

		#region Properties
		#endregion
	}
}
