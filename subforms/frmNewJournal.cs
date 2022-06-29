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
		public string sJournalName;
		public string sPIN;

		public frmNewJournal()
		{ 
			InitializeComponent();
		}

		private void frmNewJournal_Load(object sender, EventArgs e)
		{ grp1.Location = new Point((this.Width / 2) - (grp1.Width / 2), 25); }

		private void frmNewJournal_Activated(object sender, EventArgs e) { txtName.Focus(); }

		private void btnOk_Click(object sender, EventArgs e)
		{
			//((frmParent)this.MdiParent).nextForm = new frmMain();
			this.Close();
		}

		private void frmNewJournal_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (txtPIN.Text.Length > 0 | txtName.Text.Length > 0)
			{
				e.Cancel = true;
				sJournalName = txtName.Text;
				sPIN = txtPIN.Text;
				this.Hide();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			txtName.Text = string.Empty;
			txtPIN.Text = string.Empty;
			this.Close();
		}
	}
}
