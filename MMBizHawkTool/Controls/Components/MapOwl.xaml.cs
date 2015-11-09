using MMBizHawkTool.Tools.Effects;
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
	/// Interaction logic for MapOwl.xaml
	/// </summary>
	public partial class MapOwl : UserControl
	{
		#region Fields

		public static readonly DependencyProperty IsDestinationProperty = DependencyProperty.Register("IsDestination", typeof(bool), typeof(MapOwl), new FrameworkPropertyMetadata(false, OnIsDestinationChange));
		public static readonly DependencyProperty LocationProperty = DependencyProperty.Register("Location", typeof(string), typeof(MapOwl), new FrameworkPropertyMetadata(string.Empty, OnLocationChange));		

		private static readonly SolidColorBrush WhiteColor = new SolidColorBrush(Colors.White);
		private static readonly SolidColorBrush GreenColor = new SolidColorBrush(Colors.Lime);

		#endregion

		#region cTor(s)

		public MapOwl()
		{
			InitializeComponent();
			IsEnabledChanged += MapOwl_IsEnabledChanged;
		}

		#endregion

		#region Methods

		private void MapOwl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if ((bool)e.NewValue)
			{
				owl.Effect = null;
			}
			else
			{
				owl.Effect = new GrayscaleEffect();
			}
		}

		/// <summary>
		/// Raised when we change the location
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnIsDestinationChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			if ((bool)e.NewValue)
			{
				((MapOwl)source).locationLabel.TextColor = GreenColor;
			}
			else
			{
				((MapOwl)source).locationLabel.TextColor = WhiteColor;
			}
		}

		/// <summary>
		/// Raised when we change the location
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnLocationChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{

			((MapOwl)source).locationLabel.Text = (string)e.NewValue;
		}		

		#endregion

		#region Properties

		/// <summary>
		/// Get or set this owl as soaring destination
		/// </summary>
		public bool IsDestination
		{
			get
			{
				return (bool)GetValue(IsDestinationProperty);
			}
			set
			{
				SetValue(IsDestinationProperty, value);
			}
		}

		/// <summary>
		/// Get or set owl's location
		/// </summary>
		public string Location
		{
			get
			{
				return (string)GetValue(LocationProperty);
			}
			set
			{
				SetValue(LocationProperty, value);
			}
		}

		#endregion
	}
}
