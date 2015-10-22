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
using MMBizHawkTool.Tools.Enums;
using MMBizHawkTool.Tools;

namespace MMBizHawkTool.Controls
{
	/// <summary>
	/// Interaction logic for QuestStatusPanel.xaml
	/// </summary>
	public partial class QuestStatusPanel : UserControl, IMMPanel
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
			//handledStatus.Add(QuestStatus.LullabyIntro, null2);
			handledStatus.Add(QuestStatus.NewWaveBossaNova, newWaveBossaNova);
			handledStatus.Add(QuestStatus.OathToOrder, oathToOrder);
			handledStatus.Add(QuestStatus.OdolwaRemains, odolwaRemains);
			//handledStatus.Add(QuestStatus.SariaSong, odolwaRemains);
			handledStatus.Add(QuestStatus.SonataOfAwakening, sonataOfAwakening);
			handledStatus.Add(QuestStatus.SongOfHealing, songOfHealing);
			handledStatus.Add(QuestStatus.SongOfSoaring, songOfSoaring);
			handledStatus.Add(QuestStatus.SongOfStorm, songOfStorm);
			//handledStatus.Add(QuestStatus.SongOfSun, songOfStorm);
			handledStatus.Add(QuestStatus.TwinmoldRemains, twinmoldRemains);
			//handledStatus.Add(QuestStatus., twinmoldRemains);


		}

		#endregion

		#region Methods

		public void AddToDictionnary(long address, string imageName)
		{
			QuestStatusPanel.address = address;
		}

		public void UpdateItems(IEnumerable<Watch> itemsAdresses)
		{
			IEnumerable<Watch> statusWatch = itemsAdresses.Where<Watch>(w => (w.Address ?? 0) == QuestStatusPanel.address);
			if (statusWatch.Any<Watch>())
            {
				currentStatus = (QuestStatus)Convert.ToUInt32(statusWatch.First<Watch>().Value ?? 0);
			}
			foreach (QuestStatus status in handledStatus.Keys)
			{
				if ((status & currentStatus) == status)
				{
					handledStatus[status].Effect = null;
				}
				else
				{
					handledStatus[status].Effect = QuestStatusPanel.grayscaleEffect;
				}
			}
		}

		#endregion
	}
}
