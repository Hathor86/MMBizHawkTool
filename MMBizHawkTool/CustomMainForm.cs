using BizHawk.Client.Common;
using BizHawk.Emulation.Common;
using MMBizHawkTool.Controls;
using MMBizHawkTool.Controls.Panels;
using MMBizHawkTool.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm : Form, ICustomGameTool
	{
		#region Fields

		[RequiredService]
		private IMemoryDomains _memoryDomains { get; set; }
		[RequiredService]
		private IEmulator _emu { get; set; }

		private bool editMode = false;

		private List<Watch> watchList = new List<Watch>();
		private List<IMMPanel> paneList = new List<IMMPanel>();

		#endregion

		#region cTor(s)

		public CustomMainForm()
		{
			InitializeComponent();


		}
		#endregion

		#region Methods		

		public bool AskSaveChanges()
		{
			return true;
		}

		public void FastUpdate()
		{

		}

		public void Restart()
		{
			paneList.Add(elementHost1.Child as IMMPanel);
			paneList.Add(elementHost2.Child as IMMPanel);
			paneList.Add(elementHost3.Child as IMMPanel);
			paneList.Add(elementHost4.Child as IMMPanel);
			paneList.Add(elementHost5.Child as IMMPanel);

			string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			path = Path.Combine(path, "param.xml");

			XmlDocument param = new XmlDocument();
			param.Load(path);

			foreach (XmlElement panelNode in param.DocumentElement.ChildNodes)
			{
				switch (panelNode.Attributes["Type"].Value)
				{
					case "Item":
						PopulatePanel<ItemsPanel>(panelNode.ChildNodes);
						break;

					case "Mask":
						PopulatePanel<MasksPanel>(panelNode.ChildNodes);
						break;

					case "Quest":
						PopulatePanel<QuestStatusPanel>(panelNode.ChildNodes);
						break;

					case "Map":
						PopulatePanel<MapPanel>(panelNode.ChildNodes);
						break;

					case "Common":
						long address;
						Watch.WatchSize wSize;
						Watch.DisplayType dType;
						CultureInfo ci = new CultureInfo("en-US");
						foreach (XmlElement watchNode in panelNode.ChildNodes)
						{
							if (long.TryParse(watchNode.Attributes["Address"].Value, NumberStyles.HexNumber, ci, out address)
								&& Enum.TryParse<Watch.WatchSize>(watchNode.Attributes["WatchSize"].Value, out wSize)
								&& Enum.TryParse<Watch.DisplayType>(watchNode.Attributes["DisplayType"].Value, out dType))
							{
								watchList.Add(Watch.GenerateWatch(_memoryDomains.MainMemory, address, wSize, dType, string.Empty, true));
								switch (watchNode.Attributes["Item"].Value)
								{
									case "MagicAmount":
										ItemsPanel.MagicAmountAddress = address;
										break;

									case "OverallVelocity":
										((SpeedPanel)elementHost5.Child).AddToDictionnary(address, string.Empty);
                                        break;
								}

							}
						}
						break;

					default:
						break;
				}
			}

			Parallel.ForEach<Watch>(watchList, w => w.Update());
			foreach (IMMPanel panel in paneList)
			{
				panel.UpdateItems(watchList);
			}
		}

		public void UpdateValues()
		{
			Parallel.ForEach<Watch>(watchList, w => w.Update());

			IEnumerable<Watch> changes = from w in watchList
										 where w.Previous != w.Value
										 select w;
			foreach (IMMPanel panel in paneList)
			{
				panel.UpdateItems(changes);
			}
		}

		/// <summary>
		/// Initialize a type of panel with content passed in parameters
		/// </summary>
		/// <typeparam name="T">An IMMPanel</typeparam>
		/// <param name="panelNode">Panel XmlNodes from param.xml</param>
		private void PopulatePanel<T>(XmlNodeList panelNode) where T : IMMPanel
		{
			long address;
			Watch.WatchSize wSize;
			Watch.DisplayType dType;
			CultureInfo ci = new CultureInfo("en-US");

			foreach (XmlElement watchNode in panelNode)
			{
				if (long.TryParse(watchNode.Attributes["Address"].Value, NumberStyles.HexNumber, ci, out address)
					&& Enum.TryParse<Watch.WatchSize>(watchNode.Attributes["WatchSize"].Value, out wSize)
					&& Enum.TryParse<Watch.DisplayType>(watchNode.Attributes["DisplayType"].Value, out dType))
				{
					watchList.Add(Watch.GenerateWatch(_memoryDomains.MainMemory, address, wSize, dType, string.Empty, true));
					foreach (IMMPanel panel in paneList)
					{
						if (panel is T)
						{
							panel.AddToDictionnary(address, watchNode.Attributes["Item"].Value);
						}
					}
				}
			}
		}

		#endregion

		#region Properties

		public bool UpdateBefore
		{
			get
			{
				return true;
			}
		}

		#endregion
	}
}
