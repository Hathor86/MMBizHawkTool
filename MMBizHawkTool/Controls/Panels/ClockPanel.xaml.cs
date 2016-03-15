using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BizHawk.Client.Common;
using MMBizHawkTool.Controls.Components;
using MMBizHawkTool.Tools;

namespace MMBizHawkTool.Controls.Panels
{
	/// <summary>
	/// Interaction logic for ClockPanel.xaml
	/// </summary>
	public partial class ClockPanel : BasePanel
	{
		#region Fields

		private GameTimeValueConverter gameTimeConverter = new GameTimeValueConverter();

		#endregion

		#region cTor(s)

		public ClockPanel()
		{
			InitializeComponent();
			timeLimit.LostFocus += new RoutedEventHandler(TimeLimit_LostFocus);
			timeLimit.KeyUp += new KeyEventHandler(TimeLimit_KeyUp);
		}

		#endregion

		#region Methods		

		public override void AddToDictionnary(long address, string controlName)
		{
			if (controlName == "currentDay")
			{
				handledItems.Add(address, time);
			}
			else
			{
				base.AddToDictionnary(address, controlName);
			}
		}

		private void TimeLimit_KeyUp(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter)
			{
				TimeLimit_LostFocus(null, null);
			}
		}

		private void TimeLimit_LostFocus(object sender, RoutedEventArgs e)
		{
			if (GameTimeValueConverter.TimeRegex.IsMatch(timeLimit.Text))
			{
				time.AlternateTime = timeLimit.Text;
				time.EnableAlternateTime = true;
			}
			else
			{
				time.EnableAlternateTime = false;
				remainingFrames.Text = string.Empty;
			}
		}

		public override void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			IEnumerable<Watch> updatedValues = itemsAdresses.Where<Watch>(w => handledItems.ContainsKey(w.Address));
			foreach (Watch w in updatedValues)
			{
				if (handledItems[w.Address] == time && w.Size == WatchSize.Word)
				{
					time.Time = (string)gameTimeConverter.Convert(w.Value);
					if(time.EnableAlternateTime)
					{
						remainingFrames.Text = string.Format(CultureInfo.InvariantCulture, "{0:0} frames remaining", ((double)gameTimeConverter.ConvertBack(time.AlternateTime) - w.Value) / (3 + timeSpeed.Value));
					}
				}
				else if (handledItems[w.Address] == time && w.Size == WatchSize.Byte)
				{
					time.Day = w.ValueString;
				}
				else
				{
					((Slider)handledItems[w.Address]).Value = Convert.ToInt16(w.ValueString);
					time.InvertedSongOfTime = (((Slider)handledItems[w.Address]).Value == -2);
				}
			}
		}

		#endregion
	}
}
