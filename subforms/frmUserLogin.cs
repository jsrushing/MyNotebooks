using System;
using System.Data;
using System.Windows.Forms;
using MyNotebooks.DataAccess;

namespace MyNotebooks.subforms
{
	public partial class frmUserLogin : Form
	{
		public frmUserLogin()
		{
			InitializeComponent();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			// look up the user
			Program.PIN = txtPwd.Text;
			DataSet ds = DbAccess.GetUser(txtUserName.Text, txtPwd.Text);

			if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)    // the user was found
			{
				Program.User = new(ds.Tables[0]) { Permissions = new(ds.Tables[1]) };

				if (Program.User == null) { this.Close(); }
				else
				{
					this.Hide();
					using (frmManagementConsole frm = new(this, true)) { frm.ShowDialog(); }
					if (Program.ActiveNBParentId == -1) { this.Close(); }
				}
			}
			else
			{
				using (frmMessage frm = new(frmMessage.OperationType.Message, "No MyNotebooks User Found.", "No Such User", this))
				{ frm.ShowDialog(); }
				txtUserName.Text = "";
				txtPwd.Text = "";
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }
	}
}
