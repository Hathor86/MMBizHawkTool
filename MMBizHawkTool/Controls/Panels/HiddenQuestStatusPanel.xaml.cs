using MMBizHawkTool.Tools.Interfaces;
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
	public partial class HiddenQuestStatusPanel : UserControl, IMMPanel
	{
		#region Fields

		private Dictionary<long, Control> handledItems = new Dictionary<long, Control>();

		#endregion

		#region cTor(s)

		public HiddenQuestStatusPanel()
		{
			InitializeComponent();
		}

		#endregion


		#region Methods

		public void AddToDictionnary(long address, string imageName)
		{
			Control c = FindName(imageName) as Control;

			if (c != null)
			{
				handledItems.Add(address, c);
			}
			else
			{
				switch (imageName)
				{
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
				}
			}
		}

		public void UpdateItems(IEnumerable<Watch> itemsAdresses)
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
