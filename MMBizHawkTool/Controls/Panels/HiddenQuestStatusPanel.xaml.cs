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
using MMBizHawkTool.Controls.Components;

namespace MMBizHawkTool.Controls.Panels
{
	/// <summary>
	/// Interaction logic for HiddenQuestStatusPanel.xaml
	/// </summary>
	public partial class HiddenQuestStatusPanel : BasePanel
	{
		#region Fields
		#endregion

		#region cTor(s)

		public HiddenQuestStatusPanel()
		{
			InitializeComponent();
		}

		#endregion


		#region Methods

		/// <inheritdoc />
		public override void AddToDictionnary(long address, string controlName)
		{
			switch (controlName)
			{
				case "bombersCode":
					handledItems.Add(address, bombersCode);
					break;

				case "skulltulaCode":
					handledItems.Add(address, skulltulaCode);
                    break;

				case "lotteryCode":
					handledItems.Add(address, lotteryCode);
                    break;

				case "woodfallSmallKeys":
					handledItems.Add(address, woodfall.keyCounter);
					break;

				case "woodfallFairies":
					handledItems.Add(address, woodfall.fairyCounter);
					break;

				case "snowheadSmallKeys":
					handledItems.Add(address, snowhead.keyCounter);
					break;

				case "snowheadFairies":
					handledItems.Add(address, snowhead.fairyCounter);
					break;

				case "greatBaySmallKeys":
					handledItems.Add(address, greatBay.keyCounter);
					break;

				case "greatBayFairies":
					handledItems.Add(address, greatBay.fairyCounter);
					break;

				case "stoneTowerSmallKeys":
					handledItems.Add(address, stoneTower.keyCounter);
					break;

				case "stoneTowerFairies":
					handledItems.Add(address, stoneTower.fairyCounter);
					break;

				case "swampSkulltulaToken":
					handledItems.Add(address, swampSkulltulaCounter.tokenCounter);
					break;

				case "oceansideSkulltulaToken":
					handledItems.Add(address, oceanSkulltulaCounter.tokenCounter);
					break;
			}
		}

		/// <inheritdoc />
		public override void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			foreach (Watch z in itemsAdresses.Where<Watch>(w => handledItems.ContainsKey((long)w.Address)))
			{
				if (handledItems[(long)z.Address].Name == "bombersCode")
				{
					Watch codeFetcher;
					string code = string.Empty;
					for (int i = 0; i < 5; i++)
					{
						codeFetcher = Watch.GenerateWatch(z.Domain, (long)z.Address + i, z.Size, z.Type, string.Empty, true);
						code = string.Format("{0}{1}", code, codeFetcher.ValueString);
					}
					((Label)handledItems[(long)z.Address]).Content = code;
				}
				else if (handledItems[(long)z.Address].Name == "skulltulaCode")
				{
					Watch codeFetcher;
					byte[] code = new byte[6];
					for (int i = 0; i < 6; i++)
					{
						codeFetcher = Watch.GenerateWatch(z.Domain, (long)z.Address + i, z.Size, z.Type, string.Empty, true);
						code[i] = (byte)codeFetcher.Value;
					}
					((SkulltulaCodeViewer)handledItems[(long)z.Address]).SetColorCode(code);
				}
				else if (CommonAdresses["currentDay"] == z.Address || handledItems[(long)z.Address].Name == "lotteryCode")
				{
					lotteryCode.Content = string.Empty;
					string code = string.Empty;

					//First we get the currentDay
					Watch codeFetcher = Watch.GenerateWatch(z.Domain, CommonAdresses["currentDay"], Watch.WatchSize.Byte, Watch.DisplayType.Unsigned, string.Empty, true);
					int currentDay = (int)codeFetcher.Value;

					if (currentDay == 1 || currentDay == 2 || currentDay == 3)
					{
						for (int i = 0; i < 3; i++)
						{
							codeFetcher = Watch.GenerateWatch(z.Domain, (long)z.Address + (currentDay - 1) * 3 + i, z.Size, z.Type, string.Empty, true);
							code = string.Format("{0}{1}", code, codeFetcher.ValueString);
						}
						((Label)handledItems[(long)z.Address]).Content = code;
					}
				}
				else
				{
					((Label)handledItems[(long)z.Address]).Content = z.ValueString;
				}
			}
		}

		#endregion

		#region Properties
		#endregion
	}
}
