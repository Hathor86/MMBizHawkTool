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
	public enum QuestStatus:uint
	{
		OdolwaRemains = 1,
		GohtRemains = 2,
		GyorgRemains = 4,
		TwinmoldRemains = 8,
		Unknow1 = 16,
		Unknow2 = 32,
		SonataOfAwakening = 64,
		GoronLullaby = 128,
		NewWaveBossaNova = 256,
		ElegyOfEmptiness = 512,
		OathToOrder = 1024,
		SongOfSun = 2048, //Unused
		SongOfTime = 4096,
		SongOfHealing = 8192,
		EponaSong = 16384,
		SongOfSoaring = 32768,
		SongOfStorm = 65536,
		SariaSong = 131072, //Maybe? Unused anyway
		BombersNotebook = 262144,
		Unknow3 = 524288,
		Unknow4 = 1048576,
		Unknow5 = 2097152,
		Unknow6 = 4194304,
		Unknow7 = 8388608,
		LullabyIntro = 16777216,
		Unknow8 = 33554432,
		Unknow9 = 67108864,
		Unknow10 = 134217728,
		HP1 = 268435456,
		HP2 = 536870912,
		Unknow11 = 1073741824,
		Unknow12 = 2147483648
	}
}
