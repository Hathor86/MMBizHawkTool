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
