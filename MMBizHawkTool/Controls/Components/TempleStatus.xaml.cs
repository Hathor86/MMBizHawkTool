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
	/// Interaction logic for TempleStatus.xaml
	/// </summary>
	public partial class TempleStatus : UserControl
	{

		#region Fields

		private static readonly Dictionary<string, double[]> themes = new Dictionary<string, double[]>();

		#endregion

		#region cTor(s)

		static TempleStatus()
		{
			themes.Add("Snowhead", new double[4] { 120, 0, 50, 0 });
			themes.Add("Great Bay", new double[4] { 227, 0, 50, 0 });
			themes.Add("Stone Tower", new double[4] { 30, 0, 50, 0 });
		}

		public TempleStatus()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Apply a specific theme
		/// </summary>
		/// <param name="theme">The to apply</param>
		private void ApplyTheme(string theme)
		{
			if(themes.ContainsKey(theme))
			{
				fairy.Effect = new HSVEffect()
				{
					Hue = themes[theme][0]
					, Brightness = themes[theme][1]
					, Saturation = themes[theme][2]
					,Contrast = themes[theme][3]
				};
			}
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
				return locationLabel.Text;
			}
			set
			{
				locationLabel.Text = value;
				ApplyTheme(value);
            }
		}
		
		#endregion
	}
}
