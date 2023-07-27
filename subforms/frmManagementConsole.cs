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
using Microsoft.Extensions.Azure;
using myNotebooks;
using myNotebooks.objects;
using MyNotebooks.DataAccess;
using MyNotebooks.objects;

namespace MyNotebooks.subforms
{
	public partial class frmManagementConsole : Form
	{
		private Size SmallSize = new Size();
		private Size MediumSize = new Size();
		private Size FullSize = new Size();
		private User CurrentUser = null;

		public frmManagementConsole(Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
			SmallSize = new Size(pnlLogin.Width + 25, pnlLogin.Height + pnlLogin.Top + grpUsers.Top + 35);
			FullSize = new Size(785, 597);
			MediumSize = new Size(SmallSize.Width, FullSize.Height);

			txtUserName.Text = Program.User.Name;

			this.Size = SmallSize;

			//ShowHidePanels(pnlLogin);
			ddlAccessLevels.SelectedIndex = 0;

			// populate the permissions list
			foreach (PropertyInfo sPropertyName in typeof(UserPermissions).GetProperties())
			{
				if (!sPropertyName.Name.ToLower().Equals("companyid") & !sPropertyName.Name.ToLower().Equals("createdon") & !sPropertyName.Name.ToLower().Equals("editedon"))
				{ clbPermissions.Items.Add(sPropertyName.Name); }
			}
		}

		private void frmManagementConsole_Load(object sender, EventArgs e)
		{
			txtPwd.Focus();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			// look up the user
			DataSet ds = DbAccess.GetUser(txtUserName.Text, txtPwd.Text);

			if (ds.Tables.Count > 0)    // the user was found
			{
				TreeNode tn = null;

				treeUser.Nodes.Clear();


				tn = new TreeNode("User Details");
				tn.Nodes.Add("Name: " + Program.User.Name);
				tn.Nodes.Add("Access Level: " + Program.User.AccessLevel.ToString());
				treeUser.Nodes.Add(tn);


				tn = new TreeNode("User Permissions");
				List<string> allPerms = Program.User.Permissions.GetAllPermissions();
				List<string> grantedPerms = Program.User.Permissions.GetGrantedPermissions();

				foreach (string s in allPerms)
				{
					TreeNode tnPerm = new(s) { ForeColor = grantedPerms.Contains(s) ? Color.Black : SystemColors.GrayText };
					tn.Nodes.Add(tnPerm);
				}
				treeUser.Nodes.Add(tn);

				tn = new TreeNode("Companies");
				tn.ForeColor = SystemColors.GrayText;
				treeUser.Nodes.Add(tn);
				tn = new TreeNode("Accounts");
				tn.ForeColor = SystemColors.GrayText;
				treeUser.Nodes.Add(tn);
				tn = new TreeNode("Departments");
				tn.ForeColor = SystemColors.GrayText;
				treeUser.Nodes.Add(tn);
				tn = new TreeNode("Groups");
				tn.ForeColor = SystemColors.GrayText;
				treeUser.Nodes.Add(tn);

				CurrentUser = new(ds.Tables[0]) { Permissions = new(ds.Tables[1]), Assignments = new(ds.Tables[2]) };

				if (CurrentUser.AccessLevel >= 2)  // 1 and 2 don't have companies, accounts, or groups.
				{
					SetNodeEnabled_Disabled("Groups");
					// populate the groups the user has access to. for master users this will be all groups. For sub user may be many groups.
				}
				if (CurrentUser.AccessLevel >= 3)  // 1 and 2 don't have companies, accounts, or groups.
				{
					SetNodeEnabled_Disabled("Departments");
					// populate the groups the user has access to. for master users this will be all groups. For sub user may be many groups.
				}
				if (CurrentUser.AccessLevel >= 4)  // 1 and 2 don't have companies, accounts, or groups.
				{
					SetNodeEnabled_Disabled("Accounts");
					// populate the groups the user has access to. for master users this will be all groups. For sub user may be many groups.
				}
				if (CurrentUser.AccessLevel >= 5)  // 1 and 2 don't have companies, accounts, or groups.
				{
					SetNodeEnabled_Disabled("Companies");
					// populate the groups the user has access to. for master users this will be all groups. For sub user may be many groups.
				}


				// check items in the permissions list based on Program.User.UserPermissions

				this.Size = FullSize;
				//ShowHidePanels(pnlSelectGroup);
				//this.Hide();
			}
			else
			{
				pnlCreateUser.Visible = true;
				this.Size = MediumSize;
			}
		}

		private void SetNodeEnabled_Disabled(string nodeName, bool setEnabled = true)
		{
			foreach (TreeNode tn in treeUser.Nodes)
			{
				if (tn.Text == nodeName) { tn.ForeColor = setEnabled ? Color.Black : SystemColors.GrayText; }
			}
		}

		private void btnCreateUser_Click(object sender, EventArgs e)
		{
			this.Size = FullSize;
			//User user = new();

			//// create the user
			//user = new(Convert.ToInt32(ddlAccessLevels.SelectedValue.ToString()), txtUserName.Text, txtPwd.Text, 0, 0, 0, 0, 0, DateTime.Now, null);
			//user.UserPermissions = GetPermissions();
			//user.Save();
			//Program.User = user;
		}

		private void btnCancelNewUser_Click(object sender, EventArgs e)
		{
			clbPermissions.ClearSelected();
			pnlCreateUser.Visible = false;
			this.Size = SmallSize;
		}

		private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }

		private UserPermissions GetPermissions()
		{
			DataTable dt = new();

			foreach (var v in clbPermissions.CheckedItems)
			{
				dt.Rows.Add(v.ToString());
			}

			return new UserPermissions(dt);
		}

		private void treeUser_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			e.Cancel = e.Node.ForeColor == SystemColors.GrayText;
		}
	}
}
