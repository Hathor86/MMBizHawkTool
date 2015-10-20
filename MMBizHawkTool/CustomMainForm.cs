using BizHawk.Client.Common;
using BizHawk.Emulation.Common;
using MMBizHawkTool.Controls;
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

			string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			path = Path.Combine(path, "param.xml");

			XmlDocument param = new XmlDocument();
			param.Load(path);

			long address;
			Watch.WatchSize wSize;
			Watch.DisplayType dType;
			CultureInfo ci = new CultureInfo("en-US");
			foreach (XmlElement panelNode in param.DocumentElement.ChildNodes)
			{
				switch (panelNode.Attributes["Type"].Value)
				{
					case "Item":
						foreach (XmlElement watchNode in panelNode.ChildNodes)
						{
							if (long.TryParse(watchNode.Attributes["Address"].Value, NumberStyles.HexNumber, ci, out address)
								&& Enum.TryParse<Watch.WatchSize>(watchNode.Attributes["WatchSize"].Value, out wSize)
								&& Enum.TryParse<Watch.DisplayType>(watchNode.Attributes["DisplayType"].Value, out dType))
							{
								watchList.Add(Watch.GenerateWatch(_memoryDomains.MainMemory, address, wSize, dType, string.Empty, true));
								foreach (IMMPanel panel in paneList)
								{
									if (panel is ItemsPanel)
									{
										panel.AddToDictionnary(address, watchNode.Attributes["Item"].Value);
									}
								}
							}
						}
						break;

					case "Common":
						foreach (XmlElement watchNode in panelNode.ChildNodes)
						{
							if (long.TryParse(watchNode.Attributes["Address"].Value, NumberStyles.HexNumber, ci, out address)
								&& Enum.TryParse<Watch.WatchSize>(watchNode.Attributes["WatchSize"].Value, out wSize)
								&& Enum.TryParse<Watch.DisplayType>(watchNode.Attributes["DisplayType"].Value, out dType))
							{
								watchList.Add(Watch.GenerateWatch(_memoryDomains.MainMemory, address, wSize, dType, string.Empty, true));
								if(watchNode.Attributes["Item"].Value == "MagicAmount")
								{
									ItemsPanel.MagicAmountAddress = address;
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
