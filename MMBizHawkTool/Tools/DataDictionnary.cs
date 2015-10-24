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

namespace MMBizHawkTool.Tools
{
	public static class DataDictionnary
	{
		#region Fields

		public static readonly Dictionary<int, string> ResourceIndex = new Dictionary<int, string>();

		#endregion

		#region cTor(s)
		static DataDictionnary()
		{
			#region ResourceIndex

			#region Items
			ResourceIndex.Add(0, "/MMBizHawkTool;component/Resources/Icons/Items/Ocarina of Time.png");
			ResourceIndex.Add(1, "/MMBizHawkTool;component/Resources/Icons/Items/Hero's Bow.png");
			ResourceIndex.Add(2, "/MMBizHawkTool;component/Resources/Icons/Items/Fire Arrow.png");
			ResourceIndex.Add(3, "/MMBizHawkTool;component/Resources/Icons/Items/Ice Arrow.png");
			ResourceIndex.Add(4, "/MMBizHawkTool;component/Resources/Icons/Items/Light Arrow.png");
			ResourceIndex.Add(5, "/MMBizHawkTool;component/Resources/Icons/Items/Fairy Ocarina (Unused).png");
			ResourceIndex.Add(6, "/MMBizHawkTool;component/Resources/Icons/Items/Bomb.png");
			ResourceIndex.Add(7, "/MMBizHawkTool;component/Resources/Icons/Items/Bombchu.png");
			ResourceIndex.Add(8, "/MMBizHawkTool;component/Resources/Icons/Items/Deku Stick.png");
			ResourceIndex.Add(9, "/MMBizHawkTool;component/Resources/Icons/Items/Deku Nut.png");
			ResourceIndex.Add(10, "/MMBizHawkTool;component/Resources/Icons/Items/Magic Beans.png");
			ResourceIndex.Add(11, "/MMBizHawkTool;component/Resources/Icons/Items/Hookshot (Unused).png");
			ResourceIndex.Add(12, "/MMBizHawkTool;component/Resources/Icons/Items/Powder Keg.png");
			ResourceIndex.Add(13, "/MMBizHawkTool;component/Resources/Icons/Items/Pictograph Box.png");
			ResourceIndex.Add(14, "/MMBizHawkTool;component/Resources/Icons/Items/Lens of Truth.png");
			ResourceIndex.Add(15, "/MMBizHawkTool;component/Resources/Icons/Items/Hookshot.png");
			ResourceIndex.Add(16, "/MMBizHawkTool;component/Resources/Icons/Items/Great Fairy's Sword.png");
			ResourceIndex.Add(17, "/MMBizHawkTool;component/Resources/Icons/Items/Fairy Slingshot (Unused).png");
			ResourceIndex.Add(18, "/MMBizHawkTool;component/Resources/Icons/Items/Empty Bottle.png");
			ResourceIndex.Add(19, "/MMBizHawkTool;component/Resources/Icons/Items/Red Potion.png");
			ResourceIndex.Add(20, "/MMBizHawkTool;component/Resources/Icons/Items/Green Potion.png");
			ResourceIndex.Add(21, "/MMBizHawkTool;component/Resources/Icons/Items/Blue Potion.png");
			ResourceIndex.Add(22, "/MMBizHawkTool;component/Resources/Icons/Items/Fairy.png");
			ResourceIndex.Add(23, "/MMBizHawkTool;component/Resources/Icons/Items/Deku Princess.png");
			ResourceIndex.Add(24, "/MMBizHawkTool;component/Resources/Icons/Items/Milk.png");
			ResourceIndex.Add(25, "/MMBizHawkTool;component/Resources/Icons/Items/Half Milk.png");
			ResourceIndex.Add(26, "/MMBizHawkTool;component/Resources/Icons/Items/Fish.png");
			ResourceIndex.Add(27, "/MMBizHawkTool;component/Resources/Icons/Items/Bug.png");
			ResourceIndex.Add(28, "/MMBizHawkTool;component/Resources/Icons/Items/Blue Fire.png");
			ResourceIndex.Add(29, "/MMBizHawkTool;component/Resources/Icons/Items/Poe.png");
			ResourceIndex.Add(30, "/MMBizHawkTool;component/Resources/Icons/Items/Big Poe.png");
			ResourceIndex.Add(31, "/MMBizHawkTool;component/Resources/Icons/Items/Spring Water.png");
			ResourceIndex.Add(32, "/MMBizHawkTool;component/Resources/Icons/Items/Hot Spring Water.png");
			ResourceIndex.Add(33, "/MMBizHawkTool;component/Resources/Icons/Items/Zora Egg.png");
			ResourceIndex.Add(34, "/MMBizHawkTool;component/Resources/Icons/Items/Gold Dust.png");
			ResourceIndex.Add(35, "/MMBizHawkTool;component/Resources/Icons/Items/Magical Mushroom.png");
			ResourceIndex.Add(36, "/MMBizHawkTool;component/Resources/Icons/Items/Sea Horse.png");
			ResourceIndex.Add(37, "/MMBizHawkTool;component/Resources/Icons/Items/Chateau Romani.png");
			ResourceIndex.Add(38, "/MMBizHawkTool;component/Resources/Icons/Items/Hylian Loach.png");
			//ResourceIndex.Add(39, "/MMBizHawkTool;component/Resources/Icons/Items/Hylian Loach.png"); JP Text: Obaba's Drink
			ResourceIndex.Add(40, "/MMBizHawkTool;component/Resources/Icons/Items/Moon's Tear.png");
			ResourceIndex.Add(41, "/MMBizHawkTool;component/Resources/Icons/Items/Land Title Deed.png");
			ResourceIndex.Add(42, "/MMBizHawkTool;component/Resources/Icons/Items/Swamp Title Deed.png");
			ResourceIndex.Add(43, "/MMBizHawkTool;component/Resources/Icons/Items/Mountain Title Deed.png");
			ResourceIndex.Add(44, "/MMBizHawkTool;component/Resources/Icons/Items/Ocean Title Deed.png");
			ResourceIndex.Add(45, "/MMBizHawkTool;component/Resources/Icons/Items/Room Key.png");
			ResourceIndex.Add(46, "/MMBizHawkTool;component/Resources/Icons/Items/Special Delivery to Mama.png");
			ResourceIndex.Add(47, "/MMBizHawkTool;component/Resources/Icons/Items/Letter to Kafei.png");
			ResourceIndex.Add(48, "/MMBizHawkTool;component/Resources/Icons/Items/Pendant of Memories.png");
			ResourceIndex.Add(49, "/MMBizHawkTool;component/Resources/Icons/Items/Moonstone (Unused).png");
			#endregion Items

			#region Masks
			ResourceIndex.Add(50, "/MMBizHawkTool;component/Resources/Icons/Masks/Deku Mask.png");
			ResourceIndex.Add(51, "/MMBizHawkTool;component/Resources/Icons/Masks/Goron Mask.png");
			ResourceIndex.Add(52, "/MMBizHawkTool;component/Resources/Icons/Masks/Zora Mask.png");
			ResourceIndex.Add(53, "/MMBizHawkTool;component/Resources/Icons/Masks/Fierce Deity's Mask.png");
			ResourceIndex.Add(54, "/MMBizHawkTool;component/Resources/Icons/Masks/Mask of Truth.png");
			ResourceIndex.Add(55, "/MMBizHawkTool;component/Resources/Icons/Masks/Kafei's Mask.png");
			ResourceIndex.Add(56, "/MMBizHawkTool;component/Resources/Icons/Masks/All-Night Mask.png");
			ResourceIndex.Add(57, "/MMBizHawkTool;component/Resources/Icons/Masks/Bunny Hood.png");
			ResourceIndex.Add(58, "/MMBizHawkTool;component/Resources/Icons/Masks/Keaton Mask.png");
			ResourceIndex.Add(59, "/MMBizHawkTool;component/Resources/Icons/Masks/Garo's Mask.png");
			ResourceIndex.Add(60, "/MMBizHawkTool;component/Resources/Icons/Masks/Romani's Mask.png");
			ResourceIndex.Add(61, "/MMBizHawkTool;component/Resources/Icons/Masks/Circus Leader's Mask.png");
			ResourceIndex.Add(62, "/MMBizHawkTool;component/Resources/Icons/Masks/Postman's Hat.png");
			ResourceIndex.Add(63, "/MMBizHawkTool;component/Resources/Icons/Masks/Couple's Mask.png");
			ResourceIndex.Add(64, "/MMBizHawkTool;component/Resources/Icons/Masks/Great Fairy's Mask.png");
			ResourceIndex.Add(65, "/MMBizHawkTool;component/Resources/Icons/Masks/Gibdo Mask.png");
			ResourceIndex.Add(66, "/MMBizHawkTool;component/Resources/Icons/Masks/Don Gero's Mask.png");
			ResourceIndex.Add(67, "/MMBizHawkTool;component/Resources/Icons/Masks/Kamaro's Mask.png");
			ResourceIndex.Add(68, "/MMBizHawkTool;component/Resources/Icons/Masks/Captain's Hat.png");
			ResourceIndex.Add(69, "/MMBizHawkTool;component/Resources/Icons/Masks/Stone Mask.png");
			ResourceIndex.Add(70, "/MMBizHawkTool;component/Resources/Icons/Masks/Bremen Mask.png");
			ResourceIndex.Add(71, "/MMBizHawkTool;component/Resources/Icons/Masks/Blast Mask.png");
			ResourceIndex.Add(72, "/MMBizHawkTool;component/Resources/Icons/Masks/Mask of Scents.png");
			ResourceIndex.Add(73, "/MMBizHawkTool;component/Resources/Icons/Masks/Giant's Mask.png");
			#endregion Masks

			#endregion ResourceIndex
		}
		#endregion

		#region Properties		

		#endregion
	}
}
