/*
This Source Code Form is subject to the
terms of the Mozilla Public License, v.
2.0. If a copy of the MPL was not
distributed with this file, You can
obtain one at
http://mozilla.org/MPL/2.0/.
*/
using BizHawk.Client.Common;
using BizHawk.Emulation.Common;
using MMBizHawkTool;
using MMBizHawkTool.Controls;
using MMBizHawkTool.Controls.Buttons;
using MMBizHawkTool.Controls.Panels;
using MMBizHawkTool.Forms;
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
	public partial class CustomMainForm : Form, IExternalToolForm
	{
		#region Fields

		[RequiredService]
		internal IMemoryDomains _memoryDomains { get; set; }
		[RequiredService]
		private IEmulator _emu { get; set; }

		internal WatchList watchList;
		private bool isInitialized = false;

		private EventHandler panelBoutonClickEventHandler;

		#endregion

		#region cTor(s)

		public CustomMainForm()
		{
			InitializeComponent();

			panelLoader_Items.PanelType = "Item";
			panelLoader_Masks.PanelType = "Mask";
			panelLoader_QuestStatus.PanelType = "Quest";
			panelLoader_HiddenQuestStatus.PanelType = "HiddenQuest";
			panelLoader_Map.PanelType = "Map";
			panelLoader_Speed.PanelType = "Speed";
			panelLoader_Rotation.PanelType = "Rotation";
			panelLoader_Clock.PanelType = "Clock";

			panelBoutonClickEventHandler = new EventHandler(
				delegate
				{
					foreach (BasePanel panel in PanelHolder.Panels)
					{
						panel.UpdateItems(watchList);
					}
				}
				);

			/*panelLoader_Items.Click += panelBoutonClickEventHandler;
			panelLoader_Masks.Click += panelBoutonClickEventHandler;
			panelLoader_QuestStatus.Click += panelBoutonClickEventHandler;
			panelLoader_HiddenQuestStatus.Click += panelBoutonClickEventHandler;
			panelLoader_Map.Click += panelBoutonClickEventHandler;
			panelLoader_Speed.Click += panelBoutonClickEventHandler;
			panelLoader_Rotation.Click += panelBoutonClickEventHandler;*/
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
			if (!isInitialized)
			{
				watchList = new WatchList(_memoryDomains, "N64");
				InitializePanels();
				isInitialized = true;
			}
			else
			{
				watchList.RefreshDomains(_memoryDomains);
			}

			watchList.UpdateValues();
			foreach (BasePanel panel in PanelHolder.Panels)
			{
				panel.UpdateItems(watchList);
			}
		}

		public void UpdateValues()
		{
			watchList.UpdateValues();

			IEnumerable<Watch> changes = from w in watchList
										 where w.Previous != w.Value
										 select w;
			foreach (BasePanel panel in PanelHolder.Panels)
			{
				panel.UpdateItems(changes);
			}
		}

		/// <summary>
		/// Initialize a type of panel with content passed in parameters
		/// </summary>
		/// <typeparam name="T">A <see cref="BasePanel"/></typeparam>
		/// <param name="panelNode">Panel XmlNodes from param.xml</param>
		private void PopulatePanel<T>(XmlNodeList panelNode) where T : BasePanel
		{
			long address;
			WatchSize wSize;
			Client.Common.DisplayType dType;
			CultureInfo ci = new CultureInfo("en-US");

			foreach (XmlElement watchNode in panelNode)
			{
				if (long.TryParse(watchNode.Attributes["Address"].Value, NumberStyles.HexNumber, ci, out address)
					&& Enum.TryParse<WatchSize>(watchNode.Attributes["WatchSize"].Value, out wSize)
					&& Enum.TryParse<Client.Common.DisplayType>(watchNode.Attributes["DisplayType"].Value, out dType))
				{
					watchList.Add(Watch.GenerateWatch(_memoryDomains.MainMemory, address, wSize, dType, true));
					foreach (BasePanel panel in PanelHolder.Panels)
					{
						if (panel is T)
						{
							panel.AddToDictionnary(address, watchNode.Attributes["Item"].Value);
						}
					}
				}
			}
		}

		/// <summary>
		/// Load config from xml file
		/// And initialize panels
		/// </summary>
		private void InitializePanels()
		{
			string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			path = Path.Combine(path, "MMBizHawkTool", "param.xml");

			XmlDocument param = new XmlDocument();
			param.Load(path);

			foreach (XmlElement panelNode in param.DocumentElement.ChildNodes)
			{
				if (panelNode.Attributes["Type"].Value == "Common")
				{
					long address;
					WatchSize wSize;
					Client.Common.DisplayType dType;
					CultureInfo ci = new CultureInfo("en-US");
					foreach (XmlElement watchNode in panelNode.ChildNodes)
					{
						if (long.TryParse(watchNode.Attributes["Address"].Value, NumberStyles.HexNumber, ci, out address)
							&& Enum.TryParse<WatchSize>(watchNode.Attributes["WatchSize"].Value, out wSize)
							&& Enum.TryParse<Client.Common.DisplayType>(watchNode.Attributes["DisplayType"].Value, out dType))
						{
							watchList.Add(Watch.GenerateWatch(_memoryDomains.MainMemory, address, wSize, dType, true));
							BasePanel.CommonAdresses.Add(watchNode.Attributes["Item"].Value, address);

							/*switch (watchNode.Attributes["Item"].Value)
							{
								case "xVelocity":
								case "yVelocity":
								case "zVelocity":
								case "overallVelocity":
									//((SpeedPanel)elementHost5.Child).AddToDictionnary(address, watchNode.Attributes["Item"].Value);
									break;
							}*/

						}
					}
					break;
				}
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm about = new AboutForm();
			about.aboutText.Text = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("MMBizHawkTool.Resources.Licenses.Licence.txt")).ReadToEnd();
			about.Show();
		}

		#endregion

		#region Properties

		public bool UpdateBefore
		{
			get
			{
				return false;
			}
		}

		#endregion
	}
}
