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
using Encryption;
using Microsoft.Extensions.Azure;
using myNotebooks;
using myNotebooks.objects;
using myNotebooks.subforms;
using MyNotebooks.DataAccess;
using MyNotebooks.objects;

namespace MyNotebooks.subforms
{
	public partial class frmManagementConsole : Form
	{
		private Size SmallSize = new Size();
		private Size MediumSize = new Size();
		private Size FullSize = new Size();
		private MNUser CurrentUser = null;
		private Color enabledColor = Color.Black;
		private Color disabledColor = Color.LightGray;

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

			// populate the permissions list
			foreach (PropertyInfo sPropertyName in typeof(UserPermissions).GetProperties())
			{
				if (!sPropertyName.Name.ToLower().Equals("companyid") & !sPropertyName.Name.ToLower().Equals("createdon") & !sPropertyName.Name.ToLower().Equals("editedon"))
				{ clbPermissions.Items.Add(sPropertyName.Name); }
			}

			txtPwd.Focus();
		}

		private void frmManagementConsole_Load(object sender, EventArgs e)
		{
		}

		private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }

		private void btnCancelContinue_Click(object sender, EventArgs e)
		{
			this.Size = SmallSize;
		}

		private void btnCancelNewUser_Click(object sender, EventArgs e)
		{
			clbPermissions.ClearSelected();
			pnlCreateUser.Visible = false;
			this.Size = SmallSize;
		}

		private void btnContinue_Click(object sender, EventArgs e)
		{
			if (ddlAccessLevels.SelectedIndex == -1)
			{
				using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "You must select an Access Level.", "Input Necessary", this)) { frm.ShowDialog(); }
				return;
			}

			CurrentUser = new MNUser(Convert.ToInt16(ddlAccessLevels.SelectedIndex), txtUserName.Text, "", 0, DateTime.Now);
			CurrentUser.Permissions = GetPermissions();
			PopulateBaseTree();

			this.Size = FullSize;
		}

		private void btnCreateUser_Click(object sender, EventArgs e)
		{
			this.Size = FullSize;
			//MNUser user = new();

			//// create the user
			//user = new(Convert.ToInt32(ddlAccessLevels.SelectedValue.ToString()), txtUserName.Text, txtPwd.Text, 0, 0, 0, 0, 0, DateTime.Now, null);
			//user.UserPermissions = GetPermissions();
			//user.Save();
			//Program.MNUser = user;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			// look up the user
			DataSet ds = DbAccess.GetUser(txtUserName.Text, txtPwd.Text);

			if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)    // the user was found
			{
				TreeNode tn = null;
				treeUser.Nodes.Clear();
				CurrentUser = new(ds.Tables[0]) { Permissions = new(ds.Tables[1]), Assignments = new(ds.Tables[2]) };
				PopulateBaseTree();
				this.Size = FullSize;
			}
			else
			{
				pnlCreateUser.Visible = true;
				ddlAccessLevels.Items.AddRange(DbAccess.GetAccessLevels().ToArray());
				CurrentUser = null;
				PopulateBaseTree();
				this.Size = MediumSize;
			}
		}

		private void PopulateBaseTree()
		{
			treeUser.Nodes.Clear();
			TreeNode tnUser = new("MNUser Details");
			TreeNode tnPerms = new("Permissions");

			if (CurrentUser != null)
			{
				tnUser.Nodes.Add("Name: " + CurrentUser.Name);
				tnUser.Nodes.Add("Access Level: " + CurrentUser.AccessLevel.ToString() + " (" + DbAccess.GetAccessLevelName(CurrentUser.AccessLevel) + ")");

				List<string> allPerms = CurrentUser.Permissions.GetAllPermissions();
				List<string> grantedPerms = CurrentUser.Permissions.GetGrantedPermissions();

				foreach (string s in allPerms)
				{
					TreeNode tnPerm = new(s) { ForeColor = grantedPerms.Contains(s) ? Color.Black : SystemColors.GrayText, BackColor = grantedPerms.Contains(s) ? Color.White : Color.White };
					tnPerms.Nodes.Add(tnPerm);
				}
			}
			treeUser.Nodes.Add(tnUser);
			treeUser.Nodes.Add(tnPerms);
			treeUser.Nodes.Add("Companies");
			treeUser.Nodes.Add("Accounts");
			treeUser.Nodes.Add("Departments");
			treeUser.Nodes.Add("Groups");

			if (CurrentUser != null)
			{
				SetNodeEnabled_Disabled("Companies", false);
				SetNodeEnabled_Disabled("Accounts", false);
				SetNodeEnabled_Disabled("Departments", false);
				SetNodeEnabled_Disabled("Groups", false);

				if (CurrentUser.AccessLevel >= 2)  // 1 and 2 don't have companies, accounts, or groups.
				{
					SetNodeEnabled_Disabled("Groups");
				}
				if (CurrentUser.AccessLevel >= 3)  // 1 and 2 don't have companies, accounts, or groups.
				{
					SetNodeEnabled_Disabled("Departments");
				}
				if (CurrentUser.AccessLevel >= 4)  // 1 and 2 don't have companies, accounts, or groups.
				{
					SetNodeEnabled_Disabled("Accounts");
				}
				if (CurrentUser.AccessLevel >= 5)  // 1 and 2 don't have companies, accounts, or groups.
				{
					SetNodeEnabled_Disabled("Companies");
				}
			}
			treeUser.ExpandAll();
		}

		private void SetNodeEnabled_Disabled(string nodeName, bool setEnabled = true)
		{
			foreach (TreeNode tn in treeUser.Nodes)
			{
				if (tn.Text == nodeName)
				{
					tn.ForeColor = setEnabled ? enabledColor : disabledColor;
					tn.BackColor = setEnabled ? Color.White : Color.White;
				}
			}
		}

		private UserPermissions GetPermissions()
		{
			List<string> permissions = new List<string>();

			foreach (var v in clbPermissions.CheckedItems)
			{
				permissions.Add(v.ToString());
			}

			return new UserPermissions(permissions);
		}

		private void treeUser_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{ e.Cancel = e.Node.ForeColor == SystemColors.GrayText; }

		private void frmManagementConsole_Activated(object sender, EventArgs e)
		{
			txtPwd.Focus();
		}

		private void treeUser_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				var v = treeUser.SelectedNode;
			}
		}

		private void btnCreateUser_Click_1(object sender, EventArgs e)
		{
			CurrentUser.Name = txtUserName.Text;
			CurrentUser.Password = EncryptDecrypt.Encrypt(txtPwd.Text, txtPwd.Text);
			CurrentUser.UserId = DbAccess.CreateMNUser(txtUserName.Text, txtPwd.Text, ddlAccessLevels.SelectedIndex);
			DbAccess.CreateMNUserPermissions(CurrentUser);
		}
	}
}
