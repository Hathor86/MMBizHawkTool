/*
	MMBizHawkTool, a BizHawk plugin specific to The Legend of Zelda: Majora's Mask
    Copyright (C) 2015  François Guiot

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License along
    with this program; if not, write to the Free Software Foundation, Inc.,
    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/
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

namespace MMBizHawkTool.Controls.Misc
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
				return location.Content.ToString();				
			}
			set
			{
				location.Content = value;
			}
		}	

		#endregion
	}
}
