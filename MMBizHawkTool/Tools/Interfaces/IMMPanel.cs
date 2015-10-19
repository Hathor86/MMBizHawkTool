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
