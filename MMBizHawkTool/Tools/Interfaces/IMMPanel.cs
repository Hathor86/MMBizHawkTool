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
using BizHawk.Client.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMBizHawkTool.Tools.Interfaces
{
	/// <summary>
	/// Specific interface for panels
	/// </summary>
	public interface IMMPanel
	{
		/// <summary>
		/// Add address to the panel's dictionnary.
		/// It helps to control the corresponding image behavior
		/// </summary>
		/// <param name="address">Ram adress (it's in fact the unique key)</param>
		/// <param name="imageName">Name of the Image Control</param>
		void AddToDictionnary(long address, string imageName);

		/// <summary>
		/// Update items passed in parameters
		/// </summary>
		/// <param name="itemsAdresses"></param>
		void UpdateItems(IEnumerable<Watch> itemsAdresses);
	}
}
