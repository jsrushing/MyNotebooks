using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Encryption;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyNotebooks.DataAccess;
using MyNotebooks.objects;
using myNotebooks;
using System.Reflection;

namespace MyNotebooks.subforms
{
	public partial class frmUserLogin : Form
	{
		public frmUserLogin()
		{
			InitializeComponent();
		}

		private void UserLogin_Load(object sender, EventArgs e)
		{
			pnlLogin.Location = new Point(8, 0);
			pnlCreateUser.Location = new Point(pnlLogin.Left, pnlLogin.Top + pnlLogin.Height + 5);
			pnlSelectGroup.Location = new Point(pnlLogin.Left, pnlLogin.Top);
			ShowHidePanels(pnlLogin);
			ddlAccessLevels.SelectedIndex = 0;
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
					treeOrg.Nodes.Add(Program.Company.Name);
				}

				// populate the permissions list
				foreach (PropertyInfo sPropertyName in typeof(Permissions).GetProperties())
				{
					if (!sPropertyName.Name.ToLower().Equals("companyid") & !sPropertyName.Name.ToLower().Equals("createdon") & !sPropertyName.Name.ToLower().Equals("editedon"))
					{ clbPermissions.Items.Add(sPropertyName.Name); }
				}

				// check items in the permissions list based on Program.User.Permissions


				ShowHidePanels(pnlSelectGroup);
				//this.Hide();
			}
			else
			{
				pnlCreateUser.Visible = true;
				ShowHidePanels(pnlCreateUser);
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

		private void btnCancelNewUser_Click(object sender, EventArgs e) { ShowHidePanels(pnlLogin); }

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

		private void ShowHidePanels(Panel panelToShow)
		{
			if (panelToShow == pnlLogin)
			{
				pnlCreateUser.Visible = false;
				this.Size = new Size(pnlLogin.Width + 40, pnlLogin.Height + 50);
			}
			if (panelToShow == pnlCreateUser)
			{
				pnlCreateUser.Visible = true;
				this.Size = new Size(pnlLogin.Width + 40, pnlCreateUser.Top + pnlCreateUser.Height + 55);
			}
			if (panelToShow == pnlSelectGroup)
			{
				pnlLogin.Visible = false;
				pnlCreateUser.Visible = false;
				pnlSelectGroup.Visible = true;
				this.Size = new Size(pnlSelectGroup.Width + 40, pnlSelectGroup.Top + pnlSelectGroup.Height + 55);
			}
		}

		private void treeOrg_Click(object sender, EventArgs e)
		{
			// look up the next list of items based on what was clicked

		}

		private void treeOrg_DoubleClick(object sender, EventArgs e)
		{

		}
	}
}
