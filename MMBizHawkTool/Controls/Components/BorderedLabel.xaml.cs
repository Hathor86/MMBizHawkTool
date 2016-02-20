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
		public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(Brush), typeof(BorderedLabel), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromArgb(0xBF,0,0,0)), OnBackgroundColorChange));
		public static readonly DependencyProperty BackgroundOrientationProperty = DependencyProperty.Register("BackgroundOrientation", typeof(double), typeof(BorderedLabel), new FrameworkPropertyMetadata(0d, OnBackgroundOrientationChange));

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

		/// <summary>
		/// Raised when we change the backgound color
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnBackgroundColorChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			((BorderedLabel)source).border.BorderBrush = (Brush)e.NewValue;
			((BorderedLabel)source).border.Background = (Brush)e.NewValue;
		}

		/// <summary>
		/// Raised when we change the orientation of the background
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnBackgroundOrientationChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			((BorderedLabel)source).borderRotation.Angle = (double)e.NewValue;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the text
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
		/// Gets or sets Text Color
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

		/// <summary>
		/// Gets or sets Background color
		/// </summary>
		public Brush BackgroundColor
		{
			get
			{
				return (Brush)GetValue(BackgroundColorProperty);
			}
			set
			{
				SetValue(BackgroundColorProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the orientation of the background
		/// </summary>
		public double BackgroundOriention
		{
			get
			{
				return (double)GetValue(BackgroundOrientationProperty);
			}
			set
			{
				SetValue(BackgroundOrientationProperty, value);
			}
		}

		#endregion
	}
}
