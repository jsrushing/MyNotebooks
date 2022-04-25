using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace myJournal.subforms
{
	public partial class frmNewJournal : Form
	{
		public frmNewJournal()
		{ InitializeComponent(); }

		private void frmNewJournal_Load(object sender, EventArgs e)
		{ grp1.Location = new Point((this.Width / 2) - (grp1.Width / 2), 25); }

		private void frmNewJournal_Activated(object sender, EventArgs e) { txtName.Focus(); }
	}
}
