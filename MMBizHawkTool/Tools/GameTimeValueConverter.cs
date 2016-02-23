using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace MMBizHawkTool.Tools
{
	/// <summary>
	/// This class hlods a converter for game time to "human" time and vice versa
	/// </summary>
	public class GameTimeValueConverter : IValueConverter
	{
		#region Fields

		private const double OneGameSecond = 86400d / 65535d; //Number of real seconds / IG seconds.FF FF (65535) is midnight

		private static readonly Regex _timeRegex = new Regex(@"(?<Hours>((0|1)[0-9])|2[0-3]):(?<Minutes>[0-5][0-9]):(?<Seconds>[0-5][0-9])", RegexOptions.Compiled);

		private int currentTime;
		private double hour;
		private double minute;
		private double second;
		private string[] currentTimeValues;

		#endregion

		#region Methods

		/// <summary>
		/// Convert game time to regular time
		/// </summary>
		/// <param name="value">Value to convert</param>
		/// <param name="targetType">Target type</param>
		/// <param name="parameter">Parameters</param>
		/// <param name="culture">A <see cref="CultureInfo"/></param>
		/// <returns>Formatted <see cref="string"/> (hh24:mi:ss) represented the game time as seen by human</returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			currentTime = (int)value;
			hour = Math.Floor(currentTime * OneGameSecond / 3600d);
			minute = Math.Floor((currentTime * OneGameSecond / 3600d - hour) * 60);
			second = Math.Floor(((((currentTime * OneGameSecond / 3600d) - hour) * 60) - minute) * 60);
			return string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);
		}

		/// <summary>
		/// Convert game time to regular time
		/// </summary>
		/// <param name="value">Value to convert</param>
		/// <returns>Formatted <see cref="string"/> (hh24:mm:ss) represented the game time as seen by human</returns>
		public object Convert(object value)
		{
			return Convert(value, null, null, CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Convert normal time to game time
		/// </summary>
		/// <param name="value">Value to convert (a formatted <see cref="string"/> in format hh24:mi:ss</param>
		/// <param name="targetType">Target type</param>
		/// <param name="parameter">Parameters ignored in this case</param>
		/// <param name="culture">A <see cref="CultureInfo"/></param>
		/// <returns>A <see cref="ushort"/> representing game time as seen by the game</returns>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(_timeRegex.IsMatch((string)value))
			{
				currentTimeValues = ((string)value).Split(':');
				hour = System.Convert.ToDouble(currentTimeValues[0]) * 60 * 60; // hours in seconds...
				hour += System.Convert.ToDouble(currentTimeValues[1]) * 60; // add minutes in seconds
				hour += System.Convert.ToDouble(currentTimeValues[2]); // add to seconds

				hour /= 86400; //which portion of the day

				return Math.Floor(hour * 65535);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Convert normal time to game time
		/// </summary>
		/// <param name="value">Value to convert (a formatted <see cref="string"/> in format hh24:mi:ss</param>
		/// <returns>A <see cref="ushort"/> representing game time as seen by the game</returns>
		public object ConvertBack(object value)
		{
			return ConvertBack(value, null, null, CultureInfo.CurrentCulture);
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the <see cref="Regex"/> used for time validation
		/// </summary>
		public static Regex TimeRegex
		{
			get
			{
				return _timeRegex;
			}
		}

		#endregion
	}
}
