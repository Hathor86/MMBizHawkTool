using MMBizHawkTool.Tools.Interfaces;
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

		#endregion

		#region cTor(s)

		public SpeedViewer()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Update the current speed viewer depending of the specified speed
		/// </summary>
		/// <param name="speed">Speed value</param>
		public void UpdateSpeed(double speed)
		{
			RotateTransform r = ((TransformGroup)arrow.RenderTransform).Children[2] as RotateTransform;

			//double currentspeed = double.Parse(updated.First<Watch>().ValueString);
			speedText.Content = string.Format("{0:0.00}", speed);
			speed /= MaxSpeed;

			double angle = MaxAngle * speed;
			r.Angle = angle;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get or set the speedviwer's label
		/// </summary>
		public string Label
		{
			get
			{
				return label.Content.ToString();
			}
			set
			{
				label.Content = value;
			}
		}

		#endregion
	}
}
