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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMBizHawkTool.Tools.Enums
{
	[Flags]
	public enum Owl
	{
		GreatBay = 1,
		ZoraCape = 2,
		Snowhead = 4,
		MountainVillage = 8,
		ClockTown = 16,
		MilkRoad = 32,
		Woodfall = 64,
		SouthernSwamp = 128,
		IkanaCanyon = 256,
		StoneTower = 512,
		HiddenOwl = 32768
	}
}
