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
	/// Interaction logic for SkulltulaTokenCounter.xaml
	/// </summary>
	public partial class SkulltulaTokenCounter : UserControl
	{
		#region Fields

		public static readonly DependencyProperty LocationProperty = DependencyProperty.Register("Location", typeof(string), typeof(SkulltulaTokenCounter), new FrameworkPropertyMetadata(string.Empty, OnLocationChange));
		public static readonly DependencyProperty TokenCountProperty = DependencyProperty.Register("TokenCount", typeof(string), typeof(SkulltulaTokenCounter), new FrameworkPropertyMetadata(string.Empty, OnTokenCountChange));

		#endregion

		#region cTor(s)

		public SkulltulaTokenCounter()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Raised when we change the amount of ammo
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnLocationChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			((SkulltulaTokenCounter)source).locationLabel.Text = (string)e.NewValue;
		}

		/// <summary>
		/// Raised when we change the number of token
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnTokenCountChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			((SkulltulaTokenCounter)source).tokenCounter.Content = (string)e.NewValue;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get or set the location
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

		/// <summary>
		/// Get or set the amount of token
		/// </summary>
		public string TokenCount
		{
			get
			{
				return (string)GetValue(TokenCountProperty);
			}
			set
			{
				SetValue(TokenCountProperty, value);
			}
		}

		#endregion
	}
}
