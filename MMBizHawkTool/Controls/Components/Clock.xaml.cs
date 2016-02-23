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
	/// Interaction logic for Clock.xaml
	/// </summary>
	public partial class Clock : UserControl
	{
		#region Fields

		private static readonly Color GreenColor = Color.FromArgb(0xFF, 0x69, 0xB2, 0x2C);
		private static readonly Color BlueColor = Color.FromArgb(0xFF, 0x2C, 0x6F, 0xB2);

		public static readonly DependencyProperty EnableAlternateTimeProperty = DependencyProperty.Register("EnableAlternateTime", typeof(bool), typeof(Clock), new FrameworkPropertyMetadata(false, OnEnableAternateTimeChange));
		public static readonly DependencyProperty InvertedSongOfTimeProperty = DependencyProperty.Register("InvertedSongOfTime", typeof(bool), typeof(Clock), new FrameworkPropertyMetadata(false, OnInvertedSongOfTimeChange));
		public static readonly DependencyProperty TimeProperty = DependencyProperty.Register("Time", typeof(string), typeof(Clock), new FrameworkPropertyMetadata("00:00:00", OnTimeChange));
		public static readonly DependencyProperty AlternateTimeProperty = DependencyProperty.Register("AlternateTime", typeof(string), typeof(Clock), new FrameworkPropertyMetadata("00:00:00", OnAlternateTimeChange));
		public static readonly DependencyProperty DayProperty = DependencyProperty.Register("Day", typeof(string), typeof(Clock), new FrameworkPropertyMetadata("0", OnDayChange));

		#endregion

		#region cTor(s)

		public Clock()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods		

		/// <summary>
		/// Raised when time changes (other clock)
		/// (set the color to blue in fact)
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnAlternateTimeChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			((Clock)source).alternateTime.Time = (string)e.NewValue;
		}

		/// <summary>
		/// Raised when we reach dawn of another day :)
		/// (set the color to blue in fact)
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnDayChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			((Clock)source).dayLabel.Text = string.Format("Day {0}", e.NewValue); 
		}

		/// <summary>
		/// Raised when we enable/disable the inverted song of time
		/// (set the color to blue in fact)
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnEnableAternateTimeChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			if ((bool)e.NewValue)
			{
				((Clock)source).alternateTime.Visibility = Visibility.Visible;
			}
			else
			{
				((Clock)source).alternateTime.Visibility = Visibility.Hidden;
			}
		}

		/// <summary>
		/// Raised when we enable/disable the alternate time
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnInvertedSongOfTimeChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			if ((bool)e.NewValue)
			{
				((Clock)source).background_color2.Color = BlueColor;
			}
			else
			{
				((Clock)source).background_color2.Color = GreenColor;
			}
		}

		/// <summary>
		/// Raised when time changes 
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnTimeChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			((Clock)source).gameTime.Time = (string)e.NewValue;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the alternate time
		/// </summary>
		public string AlternateTime
		{
			get
			{
				return (string)GetValue(AlternateTimeProperty);
			}
			set
			{
				SetValue(AlternateTimeProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets current day
		/// </summary>
		public string Day
		{
			get
			{
				return string.Format("Day {0}", GetValue(DayProperty));
			}
			set
			{
				SetValue(DayProperty, value);
			}
		}

		/// <summary>
		/// Enable or disable the secondary needles
		/// </summary>
		public bool EnableAlternateTime
		{
			get
			{
				return (bool)GetValue(EnableAlternateTimeProperty);
			}
			set
			{
				SetValue(EnableAlternateTimeProperty, value);
			}
		}

		/// <summary>
		/// Enable or disable inverted song of time (color the clock)
		/// </summary>
		public bool InvertedSongOfTime
		{
			get
			{
				return (bool)GetValue(InvertedSongOfTimeProperty);
			}
			set
			{
				SetValue(InvertedSongOfTimeProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets game time
		/// </summary>
		public string Time
		{
			get
			{
				return (string)GetValue(TimeProperty);
			}
			set
			{
				SetValue(TimeProperty, value);
			}
		}

		#endregion
	}
}
