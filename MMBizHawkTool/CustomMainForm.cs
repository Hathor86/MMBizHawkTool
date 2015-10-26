/*
	MMBizHawkTool, a BizHawk plugin specific to The Legend of Zelda: Majora's Mask
    Copyright (C) 2015  François Guiot

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License along
    with this program; if not, write to the Free Software Foundation, Inc.,
    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/
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
			path = Path.Combine(path, "MMBizHawkTool", "param.xml");

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
									case "magicAmount":
										ItemsPanel.MagicAmountAddress = address;
										break;

									case "xVelocity":
									case "yVelocity":
									case "zVelocity":
									case "overallVelocity":
										((SpeedPanel)elementHost5.Child).AddToDictionnary(address, watchNode.Attributes["Item"].Value);
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

		public string GetDisclaimer()
		{
			return string.Format(@"MMBizhawkTool version {0}, Copyright (C) 2015 François Guiot
    MMBizhawkTool comes with ABSOLUTELY NO WARRANTY; for details double clic on title bar.
    This is free software, and you are welcome to redistribute it
    under certain conditions; double clic on title bar for details.", Assembly.GetExecutingAssembly().GetName().Version);
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

		private void CustomMainForm_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			System.Windows.MessageBox.Show(new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("MMBizhawkTool.Resources.Liences.Lence.txt")).ReadToEnd());
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
