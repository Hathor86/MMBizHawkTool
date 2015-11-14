using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMBizHawkTool.Forms
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
			Assembly assembly = Assembly.GetExecutingAssembly();
			FileVersionInfo info = FileVersionInfo.GetVersionInfo(assembly.Location);

			label_Name.Text = info.ProductName;
			label_Description.Text = info.Comments;
			label_Copyright.Text = info.LegalCopyright;
			label_Version.Text = string.Format("Version {0}", info.ProductVersion);
		}
	}
}
