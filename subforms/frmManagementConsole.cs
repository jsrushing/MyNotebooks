using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myNotebooks;
using myNotebooks.objects;
using MyNotebooks.DataAccess;
using MyNotebooks.objects;

namespace MyNotebooks.subforms
{
	public partial class frmManagementConsole : Form
	{
		public frmManagementConsole(Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
			grpUsers.Location = new Point(8, 0);
			//ShowHidePanels(pnlLogin);
			ddlAccessLevels.SelectedIndex = 0;

			// populate the permissions list
			foreach (PropertyInfo sPropertyName in typeof(Permissions).GetProperties())
			{
				if (!sPropertyName.Name.ToLower().Equals("companyid") & !sPropertyName.Name.ToLower().Equals("createdon") & !sPropertyName.Name.ToLower().Equals("editedon"))
				{ clbPermissions.Items.Add(sPropertyName.Name); }
			}
		}

		private void frmManagementConsole_Load(object sender, EventArgs e)
		{

		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			// look up the user
			DataSet ds = DbAccess.GetUser(txtUserName.Text, txtPwd.Text);

			if (ds.Tables.Count > 0)    // the user was found
			{
				Program.User = new(ds.Tables[0]) { Permissions = new(ds.Tables[1]) };

				if (Convert.ToInt32(Program.User.AccessLevel) > 2)  // 1 and 2 don't have companies, accounts, or groups.
				{
					Program.Company = DbAccess.GetCompany(Program.User.CompanyId);

					// populate the tree
					//treeOrg.Nodes.Add(Program.Company.Name);
				}


				// check items in the permissions list based on Program.User.Permissions


				//ShowHidePanels(pnlSelectGroup);
				//this.Hide();
			}
			else
			{
				pnlCreateUser.Visible = true;
			}
		}

		private void btnCreateUser_Click(object sender, EventArgs e)
		{
			User user = new();

			// create the user
			user = new(ddlAccessLevels.SelectedValue.ToString(), txtUserName.Text, txtPwd.Text, "0", "0", "0", "0", "0", DateTime.Now, null);
			user.Permissions = GetPermissions();
			Program.User = user;
		}

		private void btnCancelNewUser_Click(object sender, EventArgs e) { }

		private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }

		private Permissions GetPermissions()
		{
			DataTable dt = new();

			foreach (var v in clbPermissions.CheckedItems)
			{
				dt.Rows.Add(v.ToString());
			}

			return new Permissions(dt);
		}

	}
}
