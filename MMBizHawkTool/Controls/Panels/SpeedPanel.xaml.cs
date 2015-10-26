﻿using MMBizHawkTool.Tools.Interfaces;
using System;
using System.Collections.Generic;
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
using MMBizHawkTool.Controls.Misc;

namespace MMBizHawkTool.Controls.Panels
{
	/// <summary>
	/// Interaction logic for SpeedPanel.xaml
	/// </summary>
	public partial class SpeedPanel : UserControl, IMMPanel
	{
		#region Fields

		private Dictionary<long, SpeedViewer> _HandledItems = new Dictionary<long, SpeedViewer>();

		#endregion

		public SpeedPanel()
		{
			InitializeComponent();
		}

		public void AddToDictionnary(long address, string imageName)
		{
			_HandledItems.Add(address, (SpeedViewer)FindName(imageName));
		}

		public void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			IEnumerable<Watch> updatedValues = itemsAdresses.Where<Watch>(w => _HandledItems.ContainsKey((long)w.Address));
			foreach(Watch w in updatedValues)
			{
				_HandledItems[(long)w.Address].UpdateSpeed(double.Parse(w.ValueString));
			}
		}
	}
}
