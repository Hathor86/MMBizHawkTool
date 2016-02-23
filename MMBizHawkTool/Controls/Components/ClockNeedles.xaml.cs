using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using MMBizHawkTool.Tools;

namespace MMBizHawkTool.Controls.Components
{
	/// <summary>
	/// Interaction logic for ClockNeedles.xaml
	/// </summary>
	public partial class ClockNeedles : UserControl
	{
		#region Fields

		private const double OneHourAngle = 15;
		private const double OneMinuteAngle = 6;

		public static readonly DependencyProperty TimeProperty = DependencyProperty.Register("Time", typeof(string), typeof(ClockNeedles), new FrameworkPropertyMetadata("00:00:00", OnTimeChange), ValidateTime);

		#endregion

		#region cTor(s)

		public ClockNeedles()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Validate the time value
		/// </summary>
		/// <param name="o">time to validate (string)</param>
		/// <returns>True if value is formated as following: hh24:mi:ss; otherwise, false</returns>
		private static bool ValidateTime(object o)
		{
			return GameTimeValueConverter.TimeRegex.IsMatch((string)o);
		}

		/// <summary>
		/// Raised when we change the time
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnTimeChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			string[] values = ((string)e.NewValue).Split(':');
			RotateTransform r;
			Needle n;

			n = ((ClockNeedles)source).hour;
			r = ((TransformGroup)(n.RenderTransform)).Children[2] as RotateTransform;
			r.Angle = double.Parse(values[0]) * OneHourAngle;			
			//n.Height = Math.Sqrt(1 / Math.Pow(Math.Sin(r.Angle * Math.PI / 180) / (((ClockNeedles)source).ActualHeight + 1), 2) + Math.Pow(Math.Cos(r.Angle * Math.PI / 180) / (((ClockNeedles)source).ActualWidth + 1), 2));

			n = ((ClockNeedles)source).minutes;
			r = ((TransformGroup)(n.RenderTransform)).Children[2] as RotateTransform;
			r.Angle = double.Parse(values[1]) * OneMinuteAngle;
			//n.Height = Math.Sqrt(1 / Math.Pow(Math.Sin(r.Angle * Math.PI / 180) / ((ClockNeedles)source).ActualHeight, 2) + Math.Pow(Math.Cos(r.Angle * Math.PI / 180) / ((ClockNeedles)source).ActualWidth, 2));

			n = ((ClockNeedles)source).second;
			r = ((TransformGroup)(n.RenderTransform)).Children[2] as RotateTransform;
			r.Angle = double.Parse(values[2]) * OneMinuteAngle;
			//n.Height = Math.Sqrt(1 / Math.Pow(Math.Sin(r.Angle * Math.PI / 180) / ((ClockNeedles)source).ActualHeight, 2) + Math.Pow(Math.Cos(r.Angle * Math.PI / 180) / ((ClockNeedles)source).ActualWidth, 2));
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or Sets current time
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
