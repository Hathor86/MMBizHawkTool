using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MMBizHawkTool.Tools
{
	/// <summary>
	/// This class hold a converter for wpf property
	/// You can use this to apply math operation as multiply, percentage, add, etc...
	/// </summary>
	public class MathValueConverter : IValueConverter
	{
		#region Fields

		private static readonly Regex percentRegex = new Regex(@"(?<Amount>\d+)%", RegexOptions.Compiled);
		private static readonly Regex divideRegex = new Regex(@"x\/(?<Amount>-?\d+)", RegexOptions.Compiled);
		private Match match;

		#endregion

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			match = percentRegex.Match((string)parameter);

			if (match.Success)
			{
				return ((double)value) * double.Parse(match.Groups["Amount"].Value) / 100;
			}
			else
			{
				match = divideRegex.Match((string)parameter);
				if (match.Success)
				{
					return ((double)value) / double.Parse(match.Groups["Amount"].Value);
				}
				else
				{
					return null;
				}
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException("Connot convert back");
		}
	}
}
