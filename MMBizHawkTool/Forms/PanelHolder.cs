using MMBizHawkTool.Controls.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Linq.Expressions;
using System.Globalization;
using BizHawk.Client.Common;
using System.Xml;
using System.IO;
using System.Reflection;
using BizHawk.Client.EmuHawk;
using BizHawk.Emulation.Common;
using System.Windows.Media.Imaging;
using MMBizHawkTool.Tools;

namespace MMBizHawkTool.Forms
{
	/// <summary>
	/// A form that hold a <see cref="BasePanel"/>
	/// </summary>
	public partial class PanelHolder : Form
	{
		#region Fields

		private static HashSet<BasePanel> panelList = new HashSet<BasePanel>();

		#endregion

		#region cTors()

		public PanelHolder(string panelType, CustomMainForm form)
		{
			InitializeComponent();

			switch (panelType)
			{
				case "Item":
					panelHost.Child = new ItemsPanel();
					this.Text = "Items";
                    break;

				case "Mask":
					panelHost.Child = new MasksPanel();
					this.Text = "Masks";
					break;

				case "Quest":
					panelHost.Child = new QuestStatusPanel();
					this.Text = "Quest Status";
					break;

				case "HiddenQuest":
					panelHost.Child = new HiddenQuestStatusPanel();
					this.Text = "Hidden Quest Status";
					break;

				case "Map":
					panelHost.Child = new MapPanel();
					this.Text = "Map";
					break;

				case "Speed":
					SpeedPanel s = new SpeedPanel();
					s.AddToDictionnary(BasePanel.CommonAdresses["xVelocity"], "xVelocity");
					s.AddToDictionnary(BasePanel.CommonAdresses["yVelocity"], "yVelocity");
					s.AddToDictionnary(BasePanel.CommonAdresses["zVelocity"], "zVelocity");
					s.AddToDictionnary(BasePanel.CommonAdresses["overallVelocity"], "overallVelocity");
					panelHost.Child = s;
					this.Text = "Speed";
					break;

				case "Rotation":
					RotationPanel r = new RotationPanel();
					r.AddToDictionnary(BasePanel.CommonAdresses["xRotation"], "xRotation");
					r.AddToDictionnary(BasePanel.CommonAdresses["yRotation"], "yRotation");
					r.AddToDictionnary(BasePanel.CommonAdresses["zRotation"], "zRotation");
					panelHost.Child = r;
					this.Text = "Rotation";
					break;

				case "Clock":
					ClockPanel c = new ClockPanel();
					panelHost.Child = c;
					this.Text = "Clock";
					break;
			}

			panelList.Add((BasePanel)panelHost.Child);

			string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			path = Path.Combine(path, "MMBizHawkTool", "param.xml");

			XmlDocument param = new XmlDocument();
			param.Load(path);

			foreach (XmlElement panelNode in param.DocumentElement.ChildNodes)
			{
				if (panelNode.Attributes["Type"].Value == panelType)
				{
					long address;
					WatchSize wSize;
					BizHawk.Client.Common.DisplayType dType;
					CultureInfo ci = new CultureInfo("en-US");

					foreach (XmlElement watchNode in panelNode.ChildNodes)
					{
						if (long.TryParse(watchNode.Attributes["Address"].Value, NumberStyles.HexNumber, ci, out address)
							&& Enum.TryParse<WatchSize>(watchNode.Attributes["WatchSize"].Value, out wSize)
							&& Enum.TryParse<BizHawk.Client.Common.DisplayType>(watchNode.Attributes["DisplayType"].Value, out dType))
						{
							form.watchList.Add(Watch.GenerateWatch(form._memoryDomains.MainMemory, address, wSize, dType, true));							
							((BasePanel)panelHost.Child).AddToDictionnary(address, watchNode.Attributes["Item"].Value);
						}
					}
					((BasePanel)panelHost.Child).UpdateItems(form.watchList);
                    break;
				}
			}
		}

		#endregion

		#region Methods			

		protected override void OnClosed(EventArgs e)
		{
			panelList.Remove((BasePanel)panelHost.Child);
			base.OnClosed(e);
		}

		#endregion

		#region Properties		

		public static IEnumerable<BasePanel> Panels
		{
			get
			{
				return panelList;
			}
		}

		#endregion
	}
}
