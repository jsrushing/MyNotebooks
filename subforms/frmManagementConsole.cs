using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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
		//private Size MediumSize = new Size();
		private Size FullSize = new Size();
		private MNUser CurrentUser = null;
		private Color EnabledColor = Color.Black;
		private Color DisabledColor = Color.LightGray;

		public frmManagementConsole(Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
			SmallSize = new Size(pnlLogin.Width + 40, pnlLogin.Height + pnlLogin.Top + grpUsers.Top + 35);
			FullSize = new Size(grpTree.Left + grpTree.Width + 30, pnlCreateUser.Top + pnlCreateUser.Height + 50);
			//MediumSize = new Size(SmallSize.Width, FullSize.Height);
			ddlAccessLevels.Items.AddRange(DbAccess.GetAccessLevels().ToArray());
			txtUserName.Text = Program.User.Name;
			this.Size = SmallSize;
			PopulatePermissions();
			txtPwd.Focus();
		}

		private void frmManagementConsole_Load(object sender, EventArgs e)
		{
		}

		private void frmManagementConsole_Activated(object sender, EventArgs e)
		{
			txtPwd.Focus();
		}

		private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }

		private void btnCancelContinue_Click(object sender, EventArgs e) { this.Size = SmallSize; }

		private void btnCreateUser_Click(object sender, EventArgs e)
		{
			var msg = string.Empty;

			try
			{
				CurrentUser.Name = txtUserName.Text;
				CurrentUser.Password = EncryptDecrypt.Encrypt(txtPwd.Text, txtPwd.Text);
				CurrentUser.CreatedBy = Program.User.UserId;
				CurrentUser.UserId = DbAccess.CreateMNUser(CurrentUser);
				DbAccess.CreateMNUserPermissions(CurrentUser);
				msg = "The User '" + CurrentUser.Name + "' was created.";
			}
			catch (Exception ex)
			{
				msg = "An error occurred: " + ex.Message + ". The User was not created.";
			}
			using (frmMessage frm = new(frmMessage.OperationType.Message, msg)) { frm.ShowDialog(this); }
		}

		private void btnCancelNewUser_Click(object sender, EventArgs e)
		{
			clbPermissions.ClearSelected();
			pnlCreateUser.Visible = false;
			this.Size = SmallSize;
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			DataSet ds = DbAccess.GetUser(txtUserName.Text, txtPwd.Text);

			CurrentUser = ds.Tables.Count > 0 & ds.Tables[0].Rows.Count > 0 ? new(ds.Tables[0]) { Permissions = new(ds.Tables[1]) } : null;

			if (CurrentUser != null)
			{
				foreach (DataRow dr in ds.Tables[2].Rows) { CurrentUser.Assignments.Add(new UserAssignment(dr)); }

				TreeNode topNode = new TreeNode();
				PopulateBaseTree();
				PopulatePermissions();
				var vOrgLevelName = string.Empty;

				ddlAccessLevels.SelectedIndex = CurrentUser.AccessLevel;
				ddlAccessLevels.Enabled = false;

				switch (CurrentUser.AccessLevel)
				{

					case 3:
						vOrgLevelName = "Groups";
						break;
					case 4:
						vOrgLevelName = "Departments";
						break;
					case 5:
						vOrgLevelName = "Accounts";
						break;
					case 6:
					case 7:
						vOrgLevelName = "Companies";
						break;
				}

				treeUser.Nodes.Cast<TreeNode>().Where(e => e.Text == vOrgLevelName).First().Nodes.AddRange(CurrentUser.GetHighestNodeItems().ToArray());
				treeUser.ExpandAll();
			}
			else
			{
				using (frmMessage frm = new(frmMessage.OperationType.Message, "User not found.", "Invalid Credentials", this)) { frm.ShowDialog(this); }
			}


			if (CurrentUser != null)
			{



				// populate org. level names in tree - ONLY THE HIGHEST LEVEL

			}
			else
			{
				ddlAccessLevels.SelectedIndex = 0;
				ddlAccessLevels.Enabled = true;
			}

			this.Size = CurrentUser != null ? FullSize : SmallSize;
			pnlCreateUser.Visible = true;
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

		private void PopulateBaseTree()
		{
			treeUser.Nodes.Clear();
			TreeNode tnUser = new("User Details");
			//TreeNode tnPerms = new("Permissions");
			tnUser.Tag = "UserDetails";
			//tnPerms.Tag = "Permissions";

			if (CurrentUser != null)
			{
				tnUser.Nodes.Add("Name: " + CurrentUser.Name);
				//tnUser.Nodes.Add("Access Level: " + CurrentUser.AccessLevel.ToString() + " (" + DbAccess.GetAccessLevelName(CurrentUser.AccessLevel - 1) + ")");
				tnUser.Nodes.Add("Access Level: " + DbAccess.GetAccessLevelName(CurrentUser.AccessLevel - 1));
				tnUser.Nodes.Add("Created By: " + Program.User.Name);
			}
			treeUser.Nodes.Add(tnUser);
			treeUser.Nodes.Add(new TreeNode() { Text = "Companies", Tag = "Companies" });
			treeUser.Nodes.Add(new TreeNode() { Text = "Accounts", Tag = "Accounts" });
			treeUser.Nodes.Add(new TreeNode() { Text = "Departments", Tag = "Departments" });
			treeUser.Nodes.Add(new TreeNode() { Text = "Groups", Tag = "Groups" });

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

		private void PopulatePermissions()
		{
			clbPermissions.Items.Clear();

			if (CurrentUser != null)
			{
				List<string> allPerms = CurrentUser.Permissions.GetAllPermissions();
				List<string> grantedPerms = CurrentUser.Permissions.GetGrantedPermissions();
				foreach (string perm in allPerms) { clbPermissions.Items.Add(perm, grantedPerms.Contains(perm)); }
			}
			else
			{
				foreach (PropertyInfo sPropertyName in typeof(UserPermissions).GetProperties())
				{
					if (!sPropertyName.Name.ToLower().Equals("companyid") & !sPropertyName.Name.ToLower().Equals("createdon") & !sPropertyName.Name.ToLower().Equals("editedon"))
					{ clbPermissions.Items.Add(sPropertyName.Name); }
				}
			}
		}

		private void SetNodeEnabled_Disabled(string nodeName, bool setEnabled = true)
		{
			foreach (TreeNode tn in treeUser.Nodes)
			{
				if (tn.Text == nodeName)
				{
					tn.ForeColor = setEnabled ? EnabledColor : DisabledColor;
					tn.BackColor = setEnabled ? Color.White : Color.White;
				}
			}
		}

		private void treeUser_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{ e.Cancel = e.Node.ForeColor == DisabledColor; }

		private void treeUser_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				treeUser.SelectedNode = e.Node;
				SetContextMenus(e.Node);
			}
		}

		private void SetContextMenus(TreeNode tn)
		{
			mnuAssignUser.Visible = false;
			mnuAdd.Visible = false;
			mnuEdit.Visible = false;
			mnuDelete.Visible = false;
			mnuCreateNew.Visible = false;

			if (tn.Parent != null)
			{
				if (!tn.Parent.Tag.ToString().ToLower().Equals("permissions") & !tn.Parent.Tag.ToString().ToLower().Equals("userdetails"))
				{
					mnuAssignUser.Visible = true;
					mnuEdit.Visible = true;
					mnuDelete.Visible = true;
				}
			}
			else
			{
				switch (tn.Text.ToLower())
				{
					case "user details":
						mnuEdit.Visible = true;
						mnuDelete.Visible = true;
						break;
					case "accounts":
					case "departments":
					case "groups":
					case "companies":
						mnuCreateNew.Visible = true;
						break;
				}
			}
		}

		private void mnuCreateNew_Click(object sender, EventArgs e)
		{
			var v = treeUser.SelectedNode;

		}

		private void treeUser_DoubleClick(object sender, EventArgs e)
		{
			//TreeNode topNode = null;
			string nextRootNodeName = string.Empty;

			int level = -1;

			TreeNode tn = treeUser.SelectedNode;

			var vId = tn.Tag;   // the id of a dbl-clicked tree item
			TreeNode vParent = tn.Parent;
			

			switch(treeUser.SelectedNode.Parent.Tag.ToString().ToLower())
			{
				case "user details":
					// reserved for later
					break;
				case "companies":
					// populate accounts for company
					nextRootNodeName = "Accounts";
					level = CurrentUser.AccessLevel + 1;
					// 
					break;
				case "accounts":
					nextRootNodeName = "Departments";
					level = CurrentUser.AccessLevel;
					//var v = treeUser.SelectedNode;
					//var tag = v.Tag;

					break;
				case "departments":
					nextRootNodeName = "Groups";
					level = CurrentUser.AccessLevel - 1;
					break;
				case "groups":
					nextRootNodeName = "Notebooks";
					level = CurrentUser.AccessLevel - 2;
					break;
			}

			treeUser.Nodes.Cast<TreeNode>().Where(e => e.Text == nextRootNodeName).First().Nodes.AddRange(DbAccess.GetOrgLevelChildren(Convert.ToInt32(vId), level ).ToArray());

		}
	}
}
