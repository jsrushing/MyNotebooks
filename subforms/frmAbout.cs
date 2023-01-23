using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmAbout : Form
	{
		public frmAbout(Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
		}

		private void frmAbout_Load(object sender, EventArgs e)
		{
			lblVersion.Text = Program.AppVersion;
			txtLocation.Text = Program.AppRoot;
		}

		private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
	}
}
