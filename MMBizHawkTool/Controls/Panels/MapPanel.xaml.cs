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
using MMBizHawkTool.Tools.Enums;
using MMBizHawkTool.Controls.Misc;

namespace MMBizHawkTool.Controls.Panels
{
	/// <summary>
	/// Interaction logic for QuestStatusPanel.xaml
	/// </summary>
	public partial class MapPanel : UserControl, IMMPanel
	{
		#region Field

		private static long owlAddress = 0;

		private Owl owlsStatus = 0;
		private Dictionary<Owl, MapOwl> handledStatus = new Dictionary<Owl, MapOwl>();

		#endregion

		#region cTor(s)

		public MapPanel()
		{
			InitializeComponent();
			handledStatus.Add(Owl.ClockTown, clockTown);
			handledStatus.Add(Owl.GreatBay, greatBay);
			handledStatus.Add(Owl.HiddenOwl, hiddenOwl);
			handledStatus.Add(Owl.IkanaCanyon, ikanaCanyon);
			handledStatus.Add(Owl.MilkRoad, milkRoad);
			handledStatus.Add(Owl.MountainVillage, mountainVillage);
			handledStatus.Add(Owl.Snowhead, snowhead);
			handledStatus.Add(Owl.SouthernSwamp, southerSwamp);
			handledStatus.Add(Owl.StoneTower, stoneTower);
			handledStatus.Add(Owl.Woodfall, woodfall);
			handledStatus.Add(Owl.ZoraCape, zoraCape);
		}

		#endregion

		#region Methods

		public void AddToDictionnary(long address, string imageName)
		{
			owlAddress = address;
		}

		public void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			IEnumerable<Watch> statusWatch = itemsAdresses.Where<Watch>(w => (w.Address ?? 0) == MapPanel.owlAddress);
			if (statusWatch.Any<Watch>())
			{
				owlsStatus = (Owl)Convert.ToUInt32(statusWatch.First<Watch>().Value ?? 0);
			}
			foreach (Owl status in handledStatus.Keys)
			{
				if ((status & owlsStatus) == status)
				{
					handledStatus[status].IsEnabled = true;
				}
				else
				{
					handledStatus[status].IsEnabled = false;
				}
			}
		}

		#endregion
	}
}
