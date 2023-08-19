using System;
using System.Windows.Forms;
using myNotebooks.subforms;
using myNotebooks.DataAccess;
using myNotebooks.objects;
using System.Diagnostics.Eventing.Reader;

namespace myNotebooks.subforms
{
	public partial class frmAddOrgLevel : Form
	{
		private int CreatedBy;
		private int ParentId;
		private frmMain.OrgLevelTypes OrgLevel;
		public bool WasCreated { get; private set; }

		public frmAddOrgLevel(int creatorId, frmMain.OrgLevelTypes orgLevel, string parentName, Form parentForm, int parentId = 0)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parentForm);
			this.Text = "New " + orgLevel.ToString() + (orgLevel != frmMain.OrgLevelTypes.Company ? " in '" + parentName.Trim() + "'" : "");
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
				WasCreated = DbAccess.CRUDOrgLevel(CreatedBy, txtOrgLevelDescription.Text, OrgLevel, txtOrgLevelName.Text, ParentId);
				if (WasCreated) { }	// msg = "The " + OrgLevel.ToString() + " was created."; msg2 += "Complete"; }
				else { msg = "An error occurred. The " + OrgLevel.ToString() + " was not created."; msg2 += "Failed"; }

				if (msg.Length > 0)
				{ using (frmMessage frm = new(frmMessage.OperationType.Message, msg, msg2, this)) { frm.ShowDialog(); } }
				
				this.Hide();
			}
			else
			{ using (frmMessage frm = new(frmMessage.OperationType.Message, "Name is required.", "Input Missing", this)) { frm.ShowDialog(); } }
		}

		private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }
	}
}
