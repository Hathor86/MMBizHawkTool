using BizHawk.Client.Common;
using BizHawk.Emulation.Common;
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
        [RequiredService]
        private IMemoryDomains _memoryDomains { get; set; }
		[RequiredService]
		private IEmulator _emu { get; set; }

		Watch w;

		public CustomMainForm()
        {
			InitializeComponent();

		}

        public bool UpdateBefore
        {
            get
            {
                return true;
            }
        }

        public bool AskSaveChanges()
        {
            return true;
        }

        public void FastUpdate()
        {

        }

        public void Restart()
        {
			w = Watch.GenerateWatch(_memoryDomains.MainMemory, 0x1EF6E1, Watch.WatchSize.Byte, Watch.DisplayType.Signed, "", true);
		}

        public void UpdateValues()
        {
			w.Update();
			if(w.Value == 1)
			{
				((MMBizHawkTool.Controls.ItemsPanel)this.elementHost1.Child).heroBow.Effect = null;
			}
			else
			{
				((MMBizHawkTool.Controls.ItemsPanel)this.elementHost1.Child).heroBow.Effect = new MMBizHawkTool.Tools.GrayscaleEffect();
			}
        }
    }
}
