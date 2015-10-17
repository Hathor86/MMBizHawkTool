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

        }

        public void UpdateValues()
        {

        }
    }
}
