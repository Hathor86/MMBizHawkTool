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
	public partial class ItemsPanel : BasePanel
	{
		#region Fields

		private Dictionary<long, Item> ammo = new Dictionary<long, Item>();

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
			switch (controlName)
			{
				case "arrows":
					ammo.Add(address, heroBow);
					break;
				case "bombCount":
					ammo.Add(address, bomb);
					break;
				case "bombchuCount":
					ammo.Add(address, bombchu);
					break;
				case "dekuStickuCount":
					ammo.Add(address, dekuStick);
					break;
				case "dekuNutCount":
					ammo.Add(address, dekuNut);
					break;
				case "magicBeanCount":
					ammo.Add(address, magicBean);
					break;
				case "powderKegCount":
					ammo.Add(address, powderKeg);
					break;

				default:
					base.AddToDictionnary(address, controlName);
					break;
			}
		}

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

			foreach (Watch z in itemsAdresses.Where<Watch>(w => ammo.ContainsKey((long)w.Address)))
			{
				((Item)ammo[(long)z.Address]).Ammo = z.ValueString;
			}

			if (itemsAdresses.Any<Watch>(z => z.Address == CommonAdresses["magicAmount"]))
			{
				int magic = (int)itemsAdresses.Where<Watch>(z => z.Address == CommonAdresses["magicAmount"]).First<Watch>().Value;

				fireArrow.Ammo = Math.Floor(magic / 4f).ToString();
				iceArrow.Ammo = Math.Floor(magic / 4f).ToString();
				lightArrow.Ammo = Math.Floor(magic / 8f).ToString();
			}
		}

		#endregion

		#region Properties
		#endregion
	}
}
