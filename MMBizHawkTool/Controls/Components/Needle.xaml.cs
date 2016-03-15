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
	/// Interaction logic for Needle.xaml
	/// </summary>
	public partial class Needle : UserControl
	{
		#region Fields

		public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(Needle), new FrameworkPropertyMetadata(Color.FromArgb(255,0,0,0), OnColorChange));

		#endregion

		#region cTor(s)

		public Needle()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Raised when we change needle color
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnColorChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			((Needle)source).strokeBrush.Color = (Color)e.NewValue;			
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets needle color
		/// </summary>
		public Color Color
		{
			get
			{
				return (Color)GetValue(ColorProperty);
			}
			set
			{
				SetValue(ColorProperty, value);
			}
		}

		#endregion
	}
}
