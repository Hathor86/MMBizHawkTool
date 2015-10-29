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
		#region cTor(s)

		public TempleStatus()
		{
			InitializeComponent();
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
				return locationText.Text;
			}
			set
			{
				locationText.Text = value;
			}
		}

		/// <summary>
		/// Get or set the number of fairy collected
		/// </summary>
		public int FairyCount
		{
			get
			{
				return (int)fairyCount.Content;
			}
			set
			{
				fairyCount.Content = value;
			}
		}

		/// <summary>
		/// Get or set the number of fairy collected
		/// </summary>
		public int SamllKeyCount
		{
			get
			{
				return (int)keyCount.Content;
			}
			set
			{
				keyCount.Content = value;
			}
		}

		#endregion
	}
}
