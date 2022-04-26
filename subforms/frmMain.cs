using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace myJournal.subforms
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			grp1.Location = new Point((this.Width / 2) - (grp1.Width / 2), 100);
		}
	}
}
