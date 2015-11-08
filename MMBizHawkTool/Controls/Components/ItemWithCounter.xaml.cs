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

namespace MMBizHawkTool.Controls.Components
{
	/// <summary>
	/// Interaction logic for ItemWithCounter.xaml
	/// </summary>
	public partial class Item : UserControl
	{
		#region Fields
		#endregion

		#region cTor(s)

		public Item()
		{
			InitializeComponent();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get or set the amount of ammo
		/// </summary>
		public string Ammo
		{
			get
			{
				return ammo.Text;
			}
			set
			{
				ammo.Text = value;
			}
		}

		/// <summary>
		/// Get or set the visibility of ammo counter
		/// </summary>
		public bool AmmoVisibility
		{
			get
			{
				return ammo.Visibility == Visibility.Visible;
			}
			set
			{
				if(!value)
				{
					ammo.Visibility = Visibility.Hidden;
                }
			}
		}

		/// <summary>
		/// Get or sets the image of the item
		/// </summary>
		public ImageSource Source
		{
			get
			{
				return itemImage.Source;
            }
			set
			{
				itemImage.Source = value;
            }
		}

		#endregion
	}
}
