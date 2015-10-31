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
		public BorderedLabel()
		{
			InitializeComponent();
		}

		#region Properties

		/// <summary>
		/// Get or set the text
		/// </summary>
		public string Text
		{
			get
			{
				return text.Text;
			}
			set
			{
				text.Text = value;
            }
		}

		#endregion
	}
}
