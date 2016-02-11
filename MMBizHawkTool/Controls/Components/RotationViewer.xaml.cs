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
	/// Interaction logic for RotationViewer.xaml
	/// </summary>
	public partial class RotationViewer : UserControl
	{
		#region Fields

		public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(RotationViewer), new FrameworkPropertyMetadata(string.Empty, OnLabelChange));
		public static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", typeof(double), typeof(RotationViewer), new FrameworkPropertyMetadata(0d, OnAngleChange), ValidateAngle);

		#endregion


		#region cTor(s)

		public RotationViewer()
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
			((RotationViewer)source).label.Content = (string)e.NewValue;
		}

		/// <summary>
		/// Validate the angle value
		/// </summary>
		/// <param name="o">Angle to validate (double)</param>
		/// <returns>True if value is valid (between 0 and 360)</returns>
		private static bool ValidateAngle(object o)
		{
			return (double)o <= 360 && (double)o >= 0;
		}

		/// <summary>
		/// Raised when we change the angle
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnAngleChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{			
			RotateTransform r = ((TransformGroup)((RotationViewer)source).disk.RenderTransform).Children[2] as RotateTransform;

			((RotationViewer)source).angleText.Content = string.Format("{0:0.00}°", (double)e.NewValue);

			r.Angle = (double)e.NewValue;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get or set the RotationViewer's label
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
		/// Gets or sets RotationViewer's Angle
		/// </summary>
		public double Angle
		{
			get
			{
				return (double)GetValue(AngleProperty);
			}
			set
			{
				SetValue(AngleProperty, value);
			}
		}

		#endregion
	}
}
