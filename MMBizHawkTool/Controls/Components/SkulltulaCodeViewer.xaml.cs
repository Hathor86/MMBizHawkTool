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
	/// Interaction logic for SkulltulaCodeViwer.xaml
	/// </summary>
	public partial class SkulltulaCodeViewer : UserControl
	{
		#region Fields

		private static readonly Dictionary<int, SolidColorBrush> colorCode = new Dictionary<int, SolidColorBrush>();

		#endregion

		#region cTor(s)

		static SkulltulaCodeViewer()
		{
			colorCode.Add(0, new SolidColorBrush(Color.FromArgb(255, 255, 0, 0)));
			colorCode.Add(1, new SolidColorBrush(Color.FromArgb(255, 0, 0, 255)));
			colorCode.Add(2, new SolidColorBrush(Color.FromArgb(255, 255, 255, 0)));
			colorCode.Add(3, new SolidColorBrush(Color.FromArgb(255, 0, 255, 0)));
		}

		public SkulltulaCodeViewer()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Set the color to the view
		/// </summary>
		/// <param name="code"></param>
		public void SetColorCode(byte[] code)
		{
			for (int i = 0; i < 6; i++)
			{
				if (colorCode.ContainsKey(code[i]))
				{
					((Ellipse)FindName(string.Format("_{0}", i))).Fill = colorCode[code[i]];
				}
			}
		}

		#endregion

		#region Properties
		#endregion
	}
}
