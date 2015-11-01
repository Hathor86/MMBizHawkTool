using BizHawk.Client.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MMBizHawkTool.Controls.Panels
{
	public abstract class BasePanel : UserControl
	{
		#region Fields

		public static Dictionary<string, long> CommonAdresses = new Dictionary<string, long>();

		protected Dictionary<long, FrameworkElement> handledItems = new Dictionary<long, FrameworkElement>();

		#endregion

		#region Methods

		/// <summary>
		/// Add address to the panel's dictionnary.
		/// It helps to control the corresponding image behavior
		/// </summary>
		/// <param name="address">Ram adress (it's in fact the unique key)</param>
		/// <param name="controlName">Name of the control that will interract with the value</param>
		public virtual void AddToDictionnary(long address, string controlName)
		{
			FrameworkElement c = FindName(controlName) as FrameworkElement;
			if(c != null)
			{
				handledItems.Add(address, c);
			}
		}

		/// <summary>
		/// Update items passed in parameters
		/// </summary>
		/// <param name="itemsAdresses"></param>
		public abstract void UpdateItems(IEnumerable<Watch> itemsAdresses);

		#endregion
	}
}
