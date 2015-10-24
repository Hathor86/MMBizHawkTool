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

namespace MMBizHawkTool.Controls.Panels
{
	/// <summary>
	/// Interaction logic for SpeedPanel.xaml
	/// </summary>
	public partial class SpeedPanel : UserControl, IMMPanel
	{
		#region Fields

		private const double MaxSpeed = 18;
		private const double MaxAngle = 90f;

		private long address;

		#endregion

		#region cTor(s)

		public SpeedPanel()
		{
			InitializeComponent();
		}

		#endregion

		public void AddToDictionnary(long address, string imageName)
		{
			this.address = address;
		}

		public void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			IEnumerable<Watch> updated = itemsAdresses.Where<Watch>(w => w.Address == address);
			RotateTransform r = ((TransformGroup)arrow.RenderTransform).Children[2] as RotateTransform;
			if(r != null)
			{
				if(updated.Any<Watch>())
				{
					double currentspeed = double.Parse(updated.First<Watch>().ValueString);
					sppedText.Content = string.Format("{0:0.00}", currentspeed);
					currentspeed /= MaxSpeed;

					double angle = MaxAngle * currentspeed;
					r.Angle = angle;
				}
			}			
		}
	}
}
