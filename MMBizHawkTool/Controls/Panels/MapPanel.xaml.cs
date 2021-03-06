﻿using System;
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
using MMBizHawkTool.Tools.Enums;
using MMBizHawkTool.Controls.Components;
using MMBizHawkTool.Tools.Effects;

namespace MMBizHawkTool.Controls.Panels
{
	/// <summary>
	/// Interaction logic for QuestStatusPanel.xaml
	/// </summary>
	public partial class MapPanel : BasePanel
	{
		#region Fields

		private static readonly Owl[] IndexWarp = { Owl.GreatBay, Owl.ZoraCape, Owl.Snowhead, Owl.MountainVillage, Owl.ClockTown, Owl.MilkRoad, Owl.Woodfall, Owl.SouthernSwamp, Owl.IkanaCanyon, Owl.StoneTower };

		private static long owlAddress = 0;

		private Owl owlsStatus = 0;
		private Owl lastDestination = Owl.ZoraCape;
		private Dictionary<Owl, MapOwl> handledStatus = new Dictionary<Owl, MapOwl>();

		#endregion

		#region cTor(s)

		public MapPanel()
		{
			InitializeComponent();
			handledStatus.Add(Owl.ClockTown, clockTown);
			handledStatus.Add(Owl.GreatBay, greatBay);
			handledStatus.Add(Owl.HiddenOwl, hiddenOwl);
			handledStatus.Add(Owl.IkanaCanyon, ikanaCanyon);
			handledStatus.Add(Owl.MilkRoad, milkRoad);
			handledStatus.Add(Owl.MountainVillage, mountainVillage);
			handledStatus.Add(Owl.Snowhead, snowhead);
			handledStatus.Add(Owl.SouthernSwamp, southerSwamp);
			handledStatus.Add(Owl.StoneTower, stoneTower);
			handledStatus.Add(Owl.Woodfall, woodfall);
			handledStatus.Add(Owl.ZoraCape, zoraCape);
		}

		#endregion

		#region Methods		

		/// <inheritdoc />
		public override void AddToDictionnary(long address, string controlName)
		{
			base.AddToDictionnary(address, controlName);
			owlAddress = address;
		}

		/// <inheritdoc />
		public override void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			IEnumerable<Watch> statusWatch = itemsAdresses.Where<Watch>(w => ((long)w.Address) == MapPanel.owlAddress);
			if (statusWatch.Any<Watch>())
			{
				owlsStatus = (Owl)Convert.ToUInt32(statusWatch.First<Watch>().Value);
			}
			foreach (Owl status in handledStatus.Keys)
			{
				if ((status & owlsStatus) == status)
				{
					handledStatus[status].IsEnabled = true;
				}
				else
				{
					handledStatus[status].IsEnabled = false;
				}
			}

			if (owlsStatus == Owl.HiddenOwl && itemsAdresses.Any<Watch>(z => z.Address == CommonAdresses["soarCursor"]))
			{
				int cursor = (int)itemsAdresses.Where<Watch>(z => z.Address == CommonAdresses["soarCursor"]).First<Watch>().Value;
				if (cursor < 10)
				{
					handledStatus[IndexWarp[cursor]].IsDestination = true;
					handledStatus[lastDestination].IsDestination = false;
					lastDestination = IndexWarp[cursor];
                }
				else
				{
					//Sofltlock
				}
			}
		}
	}

	#endregion
}

