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
using MMBizHawkTool.Tools.Effects;

namespace MMBizHawkTool.Controls.Panels
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
					handledStatus[status].Effect = QuestStatusPanel.grayscaleEffect;
				}				
			}
#warning To improve
			if((currentStatus & QuestStatus.Unknow1) == QuestStatus.Unknow1)
			{
				otherStatus.Text = string.Format("{0},{1}", otherStatus.Text, QuestStatus.Unknow1.ToString());
			}
			if ((currentStatus & QuestStatus.Unknow2) == QuestStatus.Unknow2)
			{
				otherStatus.Text = string.Format("{0},{1}", otherStatus.Text, QuestStatus.Unknow2.ToString());
			}
			if ((currentStatus & QuestStatus.Unknow3) == QuestStatus.Unknow3)
			{
				otherStatus.Text = string.Format("{0},{1}", otherStatus.Text, QuestStatus.Unknow3.ToString());
			}
			if ((currentStatus & QuestStatus.Unknow4) == QuestStatus.Unknow4)
			{
				otherStatus.Text = string.Format("{0},{1}", otherStatus.Text, QuestStatus.Unknow4.ToString());
			}
			if ((currentStatus & QuestStatus.Unknow5) == QuestStatus.Unknow5)
			{
				otherStatus.Text = string.Format("{0},{1}", otherStatus.Text, QuestStatus.Unknow5.ToString());
			}
			if ((currentStatus & QuestStatus.Unknow6) == QuestStatus.Unknow6)
			{
				otherStatus.Text = string.Format("{0},{1}", otherStatus.Text, QuestStatus.Unknow6.ToString());
			}
			if ((currentStatus & QuestStatus.Unknow7) == QuestStatus.Unknow7)
			{
				otherStatus.Text = string.Format("{0},{1}", otherStatus.Text, QuestStatus.Unknow7.ToString());
			}
			if ((currentStatus & QuestStatus.Unknow8) == QuestStatus.Unknow8)
			{
				otherStatus.Text = string.Format("{0},{1}", otherStatus.Text, QuestStatus.Unknow8.ToString());
			}
			if ((currentStatus & QuestStatus.Unknow9) == QuestStatus.Unknow9)
			{
				otherStatus.Text = string.Format("{0},{1}", otherStatus.Text, QuestStatus.Unknow9.ToString());
			}
			if ((currentStatus & QuestStatus.Unknow10) == QuestStatus.Unknow10)
			{
				otherStatus.Text = string.Format("{0},{1}", otherStatus.Text, QuestStatus.Unknow10.ToString());
			}
			if ((currentStatus & QuestStatus.Unknow11) == QuestStatus.Unknow11)
			{
				otherStatus.Text = string.Format("{0},{1}", otherStatus.Text, QuestStatus.Unknow11.ToString());
			}
			if ((currentStatus & QuestStatus.Unknow12) == QuestStatus.Unknow12)
			{
				otherStatus.Text = string.Format("{0},{1}", otherStatus.Text, QuestStatus.Unknow12.ToString());
			}
		}

		#endregion
	}
}
