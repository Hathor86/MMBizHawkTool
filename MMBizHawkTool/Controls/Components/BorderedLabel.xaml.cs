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
	/// Interaction logic for BorderedLabel.xaml
	/// </summary>
	public partial class BorderedLabel : UserControl
	{
		#region Fields

		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(BorderedLabel), new FrameworkPropertyMetadata(string.Empty, OnTextChange));
		public static readonly DependencyProperty TextColorProperty = DependencyProperty.Register("TextColor", typeof(Brush), typeof(BorderedLabel), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.White), OnTextColorChange));

		#endregion

		#region cTor(s)

		public BorderedLabel()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Raised when we change the text
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnTextChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{

			((BorderedLabel)source).text.Text = (string)e.NewValue;
		}

		/// <summary>
		/// Raised when we change the text color
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnTextColorChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{

			((BorderedLabel)source).text.Foreground = (Brush)e.NewValue;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get or set the text
		/// </summary>
		public string Text
		{
			get
			{
				return (string)GetValue(TextProperty);
			}
			set
			{
				SetValue(TextProperty, value);				
            }
		}

		/// <summary>
		/// Get or set Text Color
		/// </summary>
		public Brush TextColor
		{
			get
			{
				return (Brush)GetValue(TextColorProperty);
            }
			set
			{
				SetValue(TextColorProperty, value);
            }
		}

		#endregion
	}
}
