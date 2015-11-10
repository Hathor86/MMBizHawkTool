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
using BizHawk.Client.Common;

namespace MMBizHawkTool.Controls.Components
{
	/// <summary>
	/// Interaction logic for SpeedViewer.xaml
	/// </summary>
	public partial class SpeedViewer : UserControl
	{
		#region Fields

		private const double MaxSpeed = 18;
		private const double MaxAngle = 90f;

		public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(SpeedViewer), new FrameworkPropertyMetadata(string.Empty, OnLabelChange));
		public static readonly DependencyProperty SpeedProperty = DependencyProperty.Register("Speed", typeof(double), typeof(SpeedViewer), new FrameworkPropertyMetadata(0d, OnSpeedChange));

		#endregion

		#region cTor(s)

		public SpeedViewer()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Raised when we change the label
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnLabelChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			((SpeedViewer)source).label.Content = (string)e.NewValue;
		}

		/// <summary>
		/// Raised when we change the label
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnSpeedChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{

			RotateTransform r = ((TransformGroup)((SpeedViewer)source).arrow.RenderTransform).Children[2] as RotateTransform;

			((SpeedViewer)source).speedText.Content = string.Format("{0:0.00}", (double)e.NewValue);

			r.Angle = MaxAngle * (double)e.NewValue / MaxSpeed;
		}		

		#endregion

		#region Properties

		/// <summary>
		/// Get or set the speedviewer's label
		/// </summary>
		public string Label
		{
			get
			{
				return (string)GetValue(LabelProperty);
			}
			set
			{
				SetValue(LabelProperty, value);
			}
		}

		/// <summary>
		/// Get or set speed
		/// </summary>
		public double Speed
		{
			get
			{
				return (double)GetValue(SpeedProperty);
			}
            set
			{
				SetValue(SpeedProperty, value);
			}
		}

		#endregion
	}
}
