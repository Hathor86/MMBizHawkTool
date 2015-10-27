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
	/// Interaction logic for MapOwl.xaml
	/// </summary>
	public partial class MapOwl : UserControl
	{
		#region cTor(s)

		public MapOwl()
		{
			InitializeComponent();
			this.IsEnabledChanged += MapOwl_IsEnabledChanged;
		}

		private void MapOwl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if((bool)e.NewValue)
			{
				owl.Effect = null;
			}
			else
			{
				owl.Effect = new GrayscaleEffect();
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get or set owl's location
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

		#endregion
	}
}
