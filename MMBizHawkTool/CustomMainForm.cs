using BizHawk.Client.Common;
using BizHawk.Emulation.Common;
using MMBizHawkTool.Controls;
using MMBizHawkTool.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
    public partial class CustomMainForm : Form, IToolForm, ICustomGameTool
    {
		#region Fields

		[RequiredService]
        private IMemoryDomains _memoryDomains { get; set; }
		[RequiredService]
		private IEmulator _emu { get; set; }

		private bool editMode = false;
		private List<Watch> _Watches = new List<Watch>();

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
			/*if (editMode)
			{
				this.elementHost1.Child.Effect = null;
			}
			else
			{
				this.elementHost1.Child.Effect = new GrayscaleEffect();
			}*/
	
			_Watches.Add(Watch.GenerateWatch(_memoryDomains.MainMemory, 0x1EF6E0, Watch.WatchSize.Byte, Watch.DisplayType.Signed, "", true));
			_Watches.Add(Watch.GenerateWatch(_memoryDomains.MainMemory, 0x1EF6E1, Watch.WatchSize.Byte, Watch.DisplayType.Signed, "", true));
		}

        public void UpdateValues()
        {
			/*w.Update();
			if(w.Value == 1)
			{
				((MMBizHawkTool.Controls.ItemsPanel)this.elementHost1.Child).heroBow.Effect = null;
			}
			else
			{
				((MMBizHawkTool.Controls.ItemsPanel)this.elementHost1.Child).heroBow.Effect = new MMBizHawkTool.Tools.GrayscaleEffect();
			}*/
			Parallel.ForEach<Watch>(_Watches, w => w.Update());

			IEnumerable<Watch> changes = from w in _Watches
					where w.Previous != w.Value
					select w;
			((ItemsPanel)elementHost1.Child).UpdateItems(changes);
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
