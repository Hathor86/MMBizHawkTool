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

		public static readonly DependencyProperty AmmoProperty = DependencyProperty.Register("Ammo", typeof(string), typeof(Item), new FrameworkPropertyMetadata("99", OnAmmoChange));
		public static readonly DependencyProperty AmmoVisibilityProperty = DependencyProperty.Register("AmmoVisibility", typeof(bool), typeof(Item), new FrameworkPropertyMetadata(false, OnAmmoVisibilityChange));
		public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(Item), new FrameworkPropertyMetadata(new BitmapImage(), OnImageSourceChange));

		#endregion

		#region cTor(s)

		public Item()
		{
			InitializeComponent();
			ammo.Visibility = Visibility.Hidden;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Raised when we change the amount of ammo
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnAmmoChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			((Item)source).ammo.Text = (string)e.NewValue;
		}

		/// <summary>
		/// Raised when we change the visibility of ammo counter
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnAmmoVisibilityChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			if ((bool)e.NewValue)
			{
				((Item)source).ammo.Visibility = Visibility.Visible;
			}
			else
			{
				((Item)source).ammo.Visibility = Visibility.Hidden;
			}
		}

		/// <summary>
		/// Raised when we change the image
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnImageSourceChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			((Item)source).itemImage.Source = (ImageSource)e.NewValue;
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
				return (string)GetValue(AmmoProperty);
			}
			set
			{
				SetValue(AmmoProperty, value);
			}
		}

		/// <summary>
		/// Get or set the visibility of ammo counter
		/// </summary>
		public bool AmmoVisibility
		{
			get
			{
				return (bool)GetValue(AmmoVisibilityProperty);
			}
			set
			{
				SetValue(AmmoVisibilityProperty, value);
			}
		}

		/// <summary>
		/// Get or sets the image of the item
		/// </summary>
		public ImageSource Source
		{
			get
			{
				return (ImageSource)GetValue(ImageSourceProperty);
			}
			set
			{
				SetValue(ImageSourceProperty, value);
			}
		}

		#endregion
	}
}
