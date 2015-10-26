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

namespace MMBizHawkTool.Controls.Panels
{
	/// <summary>
	/// Interaction logic for ItemsPanel.xaml
	/// </summary>
	public partial class ItemsPanel : UserControl, IMMPanel
	{
		#region Fields

		private Dictionary<long, Image> _HandledItems = new Dictionary<long, Image>();
		private Dictionary<long, TextBox> _AmmoTextBoxes = new Dictionary<long, TextBox>();

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
			object c = FindName(imageName);
			if(c.GetType() == typeof(Image))
			{
				_HandledItems.Add(address, (Image)c);
			}
			else if (c.GetType() == typeof(TextBox))
			{
				_AmmoTextBoxes.Add(address, (TextBox)c);
			}
            
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
		/// <param name="itemsAdresses">RAM watch address</param>
		public void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			foreach (Watch z in itemsAdresses.Where<Watch>(w => _HandledItems.ContainsKey((long)w.Address)))
			{
				if (DataDictionnary.ResourceIndex.ContainsKey((int)z.Value))
				{
					_HandledItems[(long)z.Address].Source = new BitmapImage(new Uri(string.Format(@"pack://application:,,,{0}", DataDictionnary.ResourceIndex[(int)z.Value])));
					_HandledItems[(long)z.Address].Effect = null;
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

			if(itemsAdresses.Any<Watch>(z => z.Address == MagicAmountAddress))
			{
				int magic = (int)itemsAdresses.Where<Watch>(z => z.Address == MagicAmountAddress).First<Watch>().Value;
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

		/// <summary>
		/// The RAM address of Magic
		/// </summary>
		public static long MagicAmountAddress { get; set; }

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
