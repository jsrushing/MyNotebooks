using System;
using System.Windows.Forms;
using myNotebooks.subforms;
using myNotebooks.DataAccess;

namespace myNotebooks.subforms
{
	public partial class frmAddOrgLevel : Form
	{
		private int CreatedBy;
		private int ParentId;
		private frmMain.OrgLevelTypes OrgLevel;

		public frmAddOrgLevel(int creatorId, frmMain.OrgLevelTypes orgLevel, int parentId = 0)
		{
			InitializeComponent();
			this.Text += orgLevel.ToString();
			CreatedBy = creatorId;
			OrgLevel = orgLevel;
			ParentId = parentId;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			var msg = string.Empty;
			var msg2 = "Operation ";

			if (txtOrgLevelName.Text.Length > 0)
			{
				if(DbAccess.CreateOrgLevel(CreatedBy, txtOrgLevelDescription.Text, OrgLevel, txtOrgLevelName.Text, ParentId))
				{ msg = "The " + OrgLevel.ToString() + " was created."; msg2 += "Complete"; }
				else { msg = "An error occurred. The " + OrgLevel.ToString() + " was not created."; msg2 += "Failed"; }

				using(frmMessage frm = new(frmMessage.OperationType.Message, msg, msg2, this)) { frm.ShowDialog(this); }

				// if level created, add currentuser to new level

			}
			else
			{ using (frmMessage frm = new(frmMessage.OperationType.Message, "Name is required.", "Input Missing", this)) { frm.ShowDialog(); } }
		}

		private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }
	}
}
