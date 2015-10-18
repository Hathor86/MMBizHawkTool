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
			ResourceIndex.Add(0, "/MMBizHawkTool;component/Resources/Icons/Items/Ocarina of Time.png");
			ResourceIndex.Add(1, "/MMBizHawkTool;component/Resources/Icons/Items/Hero's Bow.png");
			ResourceIndex.Add(2, "/MMBizHawkTool;component/Resources/Icons/Items/Fire Arrow.png");
		}
		#endregion

		#region Properties		

		#endregion
	}
}
