using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace myJournal.subforms
{
	public partial class frmAbout : Form
	{
		public frmAbout(Form parent)
		{
			InitializeComponent();
			this.Location = new System.Drawing.Point(parent.Left + 25, parent.Top + 25);
		}

		private void frmAbout_Load(object sender, EventArgs e)
		{
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
			lblVersion.Text = fvi.FileVersion;
			txtLocation.Text = Program.AppRoot;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
