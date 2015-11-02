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
using MMBizHawkTool.Tools.Enums;
using MMBizHawkTool.Tools;
using MMBizHawkTool.Tools.Effects;

namespace MMBizHawkTool.Controls.Panels
{
	/// <summary>
	/// Interaction logic for QuestStatusPanel.xaml
	/// </summary>
	public partial class QuestStatusPanel : BasePanel
	{
		#region Fields

		private static long address;
		private static GrayscaleEffect grayscaleEffect = new GrayscaleEffect();

		private QuestStatus currentStatus = 0;
		private Dictionary<QuestStatus, Image> handledStatus = new Dictionary<QuestStatus, Image>();

		#endregion

		#region cTor(s)

		public QuestStatusPanel()
		{
			InitializeComponent();
			handledStatus.Add(QuestStatus.BombersNotebook, bombersNotebbok);
			handledStatus.Add(QuestStatus.ElegyOfEmptiness, elegyOfEmptiness);
			handledStatus.Add(QuestStatus.EponaSong, eponaSong);
			handledStatus.Add(QuestStatus.GohtRemains, gohtRemains);
			handledStatus.Add(QuestStatus.GoronLullaby, goronLullaby);
			handledStatus.Add(QuestStatus.GyorgRemains, gyorgRemains);
			handledStatus.Add(QuestStatus.HP1, hp1);
			handledStatus.Add(QuestStatus.HP2, hp2);
			handledStatus.Add(QuestStatus.HP1 | QuestStatus.HP2, hp3);
			handledStatus.Add(QuestStatus.LullabyIntro, lullabyIntro);
			handledStatus.Add(QuestStatus.NewWaveBossaNova, newWaveBossaNova);
			handledStatus.Add(QuestStatus.OathToOrder, oathToOrder);
			handledStatus.Add(QuestStatus.OdolwaRemains, odolwaRemains);
			handledStatus.Add(QuestStatus.SariaSong, sariaSong);
			handledStatus.Add(QuestStatus.SonataOfAwakening, sonataOfAwakening);
			handledStatus.Add(QuestStatus.SongOfHealing, songOfHealing);
			handledStatus.Add(QuestStatus.SongOfSoaring, songOfSoaring);
			handledStatus.Add(QuestStatus.SongOfStorm, songOfStorm);
			handledStatus.Add(QuestStatus.SongOfSun, songOfSun);
			handledStatus.Add(QuestStatus.TwinmoldRemains, twinmoldRemains);
		}

		#endregion

		#region Methods

		/// <inheritdoc />
		public override void AddToDictionnary(long address, string controlName)
		{
			QuestStatusPanel.address = address;
		}

		/// <inheritdoc />
		public override void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			IEnumerable<Watch> statusWatch = itemsAdresses.Where<Watch>(w => ((long)w.Address) == QuestStatusPanel.address);
			if (statusWatch.Any<Watch>())
			{
				currentStatus = (QuestStatus)Convert.ToUInt32(statusWatch.First<Watch>().Value);
				otherStatus.Text = string.Empty;
			}
			foreach (QuestStatus status in handledStatus.Keys)
			{
				if ((status & currentStatus) == status)
				{
					handledStatus[status].Effect = null;
				}
				else
				{
					handledStatus[status].Effect = grayscaleEffect;
				}
			}

			//Just help to indentify unknow status
			foreach (QuestStatus status in Enum.GetValues(typeof(QuestStatus)).Cast<QuestStatus>())
			{
				if (status == QuestStatus.Unknow1
					|| status == QuestStatus.Unknow2
					|| status == QuestStatus.Unknow3
					|| status == QuestStatus.Unknow4
					|| status == QuestStatus.Unknow5
					|| status == QuestStatus.Unknow6
					|| status == QuestStatus.Unknow7
					|| status == QuestStatus.Unknow8
					|| status == QuestStatus.Unknow9
					|| status == QuestStatus.Unknow10
					|| status == QuestStatus.Unknow11
					|| status == QuestStatus.Unknow12)
				{
					otherStatus.Text = string.Format("{0},{1}", otherStatus.Text, status.ToString());
				}
			}
		}

		#endregion
	}
}
