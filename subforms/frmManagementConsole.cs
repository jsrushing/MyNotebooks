using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Azure.Core.Extensions;
using Encryption;
using Microsoft.VisualBasic.ApplicationServices;
using myNotebooks.DataAccess;
using myNotebooks.objects;
using MyNotebooks.objects;

namespace myNotebooks.subforms
{
	public partial class frmManagementConsole : Form
	{
		private Size SmallSize = new Size();
		private Size MediumSize = new Size();
		private Size FullSize = new Size();
		private Size OneUserSize = new Size();
		private MNUser CurrentUser = null;
		private Color EnabledColor = Color.Black;
		private Color DisabledColor = Color.LightGray;
		private List<NodeInfo> NodesInPath = new List<NodeInfo>();
		private TreeNode HoverNode = null;
		private TreeNode LastClickedNode = null;
		private List<GroupBox> OrgLevelGroups_MU = new List<GroupBox>();
		private List<ListBox> OrgLevelLists_MU = new List<ListBox>();
		private List<GroupBox> OrgLevelGroups_CU = new List<GroupBox>();
		private List<ListBox> OrgLevelLists_CU = new List<ListBox>();
		private ListItem DraggedItem = null;
		private const string CreateUserButton_CreateUser = "Create &User";
		private const string CreateUserButton_UpdateUser = "&Assign Organizations";

		public frmManagementConsole(Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
			SmallSize = new(pnlLogin.Width + 40, pnlLogin.Height + pnlLogin.Top + grpUsers.Top + 35);
			FullSize = new(grpCurrentUser.Left + grpCurrentUser.Width + 30, grpUsers.Top + grpUsers.Height + 50);
			MediumSize = new(SmallSize.Width, FullSize.Height);
			OneUserSize = new(grpMasterUser.Left + grpMasterUser.Width + 20, FullSize.Height);
			ddlAccessLevels.Items.AddRange(DbAccess.GetAccessLevels().ToArray());
			txtUserName.Text = Program.User.Name;
			this.Size = SmallSize;
			PopulatePermissions();
			OrgLevelGroups_MU.AddRange(new GroupBox[] { grpCompanies_MU, grpAccounts_MU, grpDepartments_MU, grpGroups_MU });
			OrgLevelLists_MU.AddRange(new ListBox[] { lstCompanies_MU, lstAccounts_MU, lstDepartments_MU, lstGroups_MU });
			OrgLevelGroups_CU.AddRange(new GroupBox[] { grpCompanies_CU, grpAccounts_CU, grpDepartments_CU, grpGroups_CU });
			OrgLevelLists_CU.AddRange(new ListBox[] { lstCompanies_CU, lstAccounts_CU, lstDepartments_CU, lstGroups_CU });

			txtPwd.Focus();
		}

		private void frmManagementConsole_Load(object sender, EventArgs e) { }

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
				if (btnCreateUser.Text == CreateUserButton_CreateUser)
				{
					if (ddlAccessLevels.SelectedIndex == -1)
					{
						using (frmMessage frm = new(frmMessage.OperationType.Message, "You must select an Access Level.", "Access Level is Required", this)) { frm.ShowDialog(this); }
					}
					else
					{
						CurrentUser = new()
						{
							Name = txtUserName.Text,
							Password = EncryptDecrypt.Encrypt(txtPwd.Text, txtPwd.Text),
							AccessLevel = ddlAccessLevels.SelectedIndex,
							CreatedBy = Program.User.UserId,
							Permissions = GetPermissions()
						};

						CurrentUser.UserId = DbAccess.CreateMNUser(CurrentUser);
						CurrentUser.SavePermissions();
						msg = "The User '" + CurrentUser.Name + "' was created. Now add organizationl levels and click 'Assign Organizations'.";
						this.Size = FullSize;
						btnCreateUser.Text = CreateUserButton_UpdateUser;
						PopulateBaseOrgLevels();
					}
				}
				else if (btnCreateUser.Text == CreateUserButton_UpdateUser)
				{
					CurrentUser.Assignments = GetAssignments();
					CurrentUser.SaveAssignments();
					msg = "The organization levels for '" + CurrentUser.Name + "' were updated.";
				}

			}
			catch (Exception ex)
			{
				msg = "An error occurred: " + ex.Message + ". The User was not created.";
			}

			if (msg.Length > 0)
			{
				using (frmMessage frm = new(frmMessage.OperationType.Message, msg)) { frm.ShowDialog(this); }
			}
		}

		private void btnCancelNewUser_Click(object sender, EventArgs e)
		{
			clbPermissions.ClearSelected();
			pnlCreateUser.Visible = false;

			if (CurrentUser != null && !CurrentUser.Equals(Program.User))
			{
				var msg = "The user '" + CurrentUser.Name + "' will be deleted. Do you want to continue?";
				using (frmMessage frm = new(frmMessage.OperationType.YesNoQuestion, msg, "User Will Be Deleted!", this)) 
				{ 
					frm.ShowDialog(); 
					if(frm.Result == frmMessage.ReturnResult.Yes) { CurrentUser.Delete(); CurrentUser = null; }
				}
			}

			ResetForm();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			DataSet ds = DbAccess.GetUser(txtUserName.Text, txtPwd.Text);

			CurrentUser = ds.Tables.Count > 0 & ds.Tables[0].Rows.Count > 0 ? new(ds.Tables[0]) { Permissions = new(ds.Tables[1]) } : null;

			if (CurrentUser != null)
			{
				foreach (DataRow dr in ds.Tables[2].Rows) { Program.User.Assignments.Add(new UserAssignments(dr)); }

				TreeNode topNode = new TreeNode();
				PopulateBaseOrgLevels();
				PopulatePermissions();
				var vOrgLevelName = string.Empty;
				ListBox lb2Populate = new ListBox();

				ddlAccessLevels.SelectedIndex = CurrentUser.AccessLevel - 1;
				ddlAccessLevels.Enabled = false;

				switch (Program.User.AccessLevel)
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

				ListBox lbMU = OrgLevelLists_MU.Where(box => box.Name == "lst" + vOrgLevelName + "_MU").FirstOrDefault();
				ListBox lbCU = OrgLevelLists_CU.Where(box => box.Name == "lst" + vOrgLevelName + "_CU").FirstOrDefault();

				foreach (ListItem li in (DbAccess.GetHighestNodeItemsForUser(Program.User.UserId))) { lbMU.Items.Add(li); }
				foreach (ListItem li in (DbAccess.GetHighestNodeItemsForUser(CurrentUser.UserId))) { lbCU.Items.Add(li); }

				//treeUser.Nodes.Cast<TreeNode>().Where(e => e.Text == vOrgLevelName).First().Nodes.AddRange(Program.User.GetHighestNodeItems().ToArray());
				//treeUser.ExpandAll();

				btnCreateUser.Visible = !CurrentUser.Equals(Program.User);
				this.Size = CurrentUser.Equals(Program.User) ? OneUserSize : FullSize;
				btnLogin.Enabled = false;
			}
			else
			{
				using (frmMessage frm = new(frmMessage.OperationType.YesNoQuestion,
					"User not found. Would you like to create the user '" + txtUserName.Text + "'?", "Invalid Credentials", this))
				{
					frm.ShowDialog(this);
					if (frm.Result == frmMessage.ReturnResult.Yes)
					{
						CurrentUser = null;
						this.Size = MediumSize;
						ddlAccessLevels.Enabled = true;
						btnCreateUser.Text = CreateUserButton_CreateUser;
						PopulatePermissions();
					}
				}
			}

			pnlCreateUser.Visible = true;
		}

		private ListBox GetNextListBox(ListBox lb)
		{
			ListBox lbNext = new ListBox();

			switch (lb.Parent.Text)
			{
				case "Groups":
					// lbNext = ??
					break;
				case "Departments":
					lbNext = lstGroups_MU;
					break;
				case "Accounts":
					lbNext = lstDepartments_MU;
					break;
				case "Companies":
					lbNext = lstAccounts_MU;
					break;
			}
			return lbNext;
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

		private List<UserAssignments> GetAssignments()
		{
			List<UserAssignments> lRtrn = new();
			UserAssignments ua = new();

			foreach (ListItem li in lstCompanies_CU.Items)
			{ ua = new() { UserId = CurrentUser.UserId, CompanyId = li.Id, orgType = UserAssignments.OrgType.Company }; lRtrn.Add(ua); }
			foreach (ListItem li in lstAccounts_CU.Items)
			{ ua = new() { UserId = CurrentUser.UserId, AccountId = li.Id, orgType = UserAssignments.OrgType.Account }; lRtrn.Add(ua); }
			foreach (ListItem li in lstDepartments_CU.Items)
			{ ua = new() { UserId = CurrentUser.UserId, DepartmentId = li.Id, orgType = UserAssignments.OrgType.Department }; lRtrn.Add(ua); }
			foreach (ListItem li in lstGroups_CU.Items)
			{ ua = new() { UserId = CurrentUser.UserId, GroupId = li.Id, orgType = UserAssignments.OrgType.Group }; lRtrn.Add(ua); }

			return lRtrn;
		}


		private void lstMU_DragLeave(object sender, EventArgs e)
		{
			ListBox lb = (ListBox)sender;

			DraggedItem = null;

			int index = lb.SelectedIndex;

			if (index > -1)
			{
				ListItem li = (ListItem)lb.Items[index];
				DragDropEffects dde1 = DoDragDrop(li, DragDropEffects.Move);
			}

		}

		private void lstCU_DragEnter(object sender, DragEventArgs e)
		{
			ListBox lb = (ListBox)sender;

			if (DraggedItem != null)
			{
				lb.Items.Add(DraggedItem);
			}
		}

		private void lstMU_MouseDown(object sender, MouseEventArgs e)
		{
			//ListBox lb = (ListBox)sender;

			//DraggedItem = null;

			//int index = lb.IndexFromPoint(e.X, e.Y);

			//if (index > -1)
			//{
			//	ListItem li = (ListItem)lb.Items[index];
			//	DragDropEffects dde1 = DoDragDrop(li, DragDropEffects.Move);
			//}
		}

		private void mnuCreateNew_Click(object sender, EventArgs e)
		{
			// get the clicked level
			var v = treeUser.SelectedNode;

			var v2 = v.PrevNode;

			var v3 = NodesInPath[0];

			frmMain.OrgLevelTypes type = (frmMain.OrgLevelTypes)Enum.Parse(typeof(frmMain.OrgLevelTypes), v.Name);

			using (frmAddOrgLevel frm = new frmAddOrgLevel(CurrentUser.UserId, type, Convert.ToInt32(v.Tag))) { frm.ShowDialog(); }


			// get its parent level and id

		}

		private void PopulateBaseOrgLevels()
		{
			//treeUser.Nodes.Clear();
			//TreeNode tnUser = new("User Details");
			////TreeNode tnPerms = new("Permissions");
			//tnUser.Name = "UserDetails";
			////tnPerms.Tag = "Permissions";

			//if (CurrentUser != null)
			//{
			//	tnUser.Nodes.Add("Name: " + CurrentUser.Name);
			//	//tnUser.Nodes.Add("Access Level: " + CurrentUser.AccessLevel.ToString() + " (" + DbAccess.GetAccessLevelName(CurrentUser.AccessLevel - 1) + ")");
			//	tnUser.Nodes.Add("Access Level: " + DbAccess.GetAccessLevelName(CurrentUser.AccessLevel - 1));
			//	tnUser.Nodes.Add("Created By: " + Program.User.Name);
			//}
			//treeUser.Nodes.Add(tnUser);
			//treeUser.Nodes.Add(new TreeNode() { Text = "Companies", Name = "Companies" });
			//treeUser.Nodes.Add(new TreeNode() { Text = "Accounts", Name = "Accounts" });
			//treeUser.Nodes.Add(new TreeNode() { Text = "Departments", Name = "Departments" });
			//treeUser.Nodes.Add(new TreeNode() { Text = "Groups", Name = "Groups" });

			if (Program.User != null)
			{
				SetGroupEnabled_Disabled("Companies_MU", false);
				SetGroupEnabled_Disabled("Accounts_MU", false);
				SetGroupEnabled_Disabled("Departments_MU", false);
				SetGroupEnabled_Disabled("Groups_MU", false);

				if (Program.User.AccessLevel >= 3)
				{
					SetGroupEnabled_Disabled("Groups_MU");
				}
				if (Program.User.AccessLevel >= 4)
				{
					SetGroupEnabled_Disabled("Departments_MU");
				}
				if (Program.User.AccessLevel >= 5)
				{
					SetGroupEnabled_Disabled("Accounts_MU");
				}
				if (Program.User.AccessLevel >= 6)
				{
					SetGroupEnabled_Disabled("Companies_MU");
				}
			}

			if (CurrentUser != null)
			{
				SetGroupEnabled_Disabled("Companies_CU", false);
				SetGroupEnabled_Disabled("Accounts_CU", false);
				SetGroupEnabled_Disabled("Departments_CU", false);
				SetGroupEnabled_Disabled("Groups_CU", false);

				if (CurrentUser.AccessLevel >= 3)
				{
					SetGroupEnabled_Disabled("Groups_CU");
				}
				if (CurrentUser.AccessLevel >= 4)
				{
					SetGroupEnabled_Disabled("Departments_CU");
				}
				if (CurrentUser.AccessLevel >= 5)
				{
					SetGroupEnabled_Disabled("Accounts_CU");
				}
				if (CurrentUser.AccessLevel >= 6)
				{
					SetGroupEnabled_Disabled("Companies_CU");
				}
			}


			//treeUser.ExpandAll();
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

		private void ResetForm()
		{
			this.Size = SmallSize;
			foreach (ListBox lb in OrgLevelLists_CU) { lb.Items.Clear(); }
			foreach (ListBox lb in OrgLevelLists_MU) { lb.Items.Clear(); }
			clbPermissions.Items.Clear();
			//txtUserName.Text = string.Empty;
			//txtPwd.Text = string.Empty;
			txtUserName.Focus();
			btnLogin.Enabled = true;
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
				if (tn.Parent.Tag != null)
				{
					if (!tn.Parent.Tag.ToString().ToLower().Equals("permissions") & !tn.Parent.Tag.ToString().ToLower().Equals("userdetails"))
					{
						mnuAssignUser.Visible = true;
						mnuEdit.Visible = true;
						mnuDelete.Visible = true;
					}
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

		private void SetGroupEnabled_Disabled(string groupName, bool setEnabled = true)
		{
			GroupBox gb2 = OrgLevelGroups_MU.Where(box => box.Name == "grp" + groupName).FirstOrDefault();
			gb2.Enabled = setEnabled;
			gb2 = OrgLevelGroups_CU.Where(box => box.Name == "grp" + groupName).FirstOrDefault();
			gb2.Enabled = setEnabled;
		}

		private void SetNodeEnabled_Disabled(string nodeName, bool setEnabled = true)
		{
			//foreach (TreeNode tn in treeUser.Nodes)
			//{
			//	if (tn.Text == nodeName)
			//	{
			//		tn.ForeColor = setEnabled ? EnabledColor : DisabledColor;
			//		tn.BackColor = setEnabled ? Color.White : Color.White;
			//	}
			//}
		}

		#region treeUser methods

		private void treeUser_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{ e.Cancel = e.Node.ForeColor == DisabledColor; }

		private void treeUser_Click(object sender, EventArgs e)
		{

		}

		private void treeUser_DoubleClick(object sender, EventArgs e)
		{
			//LastClickedNode = treeUser.SelectedNode;

			//try
			//{
			//	string nextRootNodeName = string.Empty;
			//	int level = -1;
			//	TreeNode tn = treeUser.SelectedNode;
			//	TreeNode vParent = tn.Parent;
			//	NodeInfo info = new();

			//	if (treeUser.SelectedNode.Parent != null)
			//	{
			//		switch (treeUser.SelectedNode.Parent.Name.ToString().ToLower())
			//		{
			//			case "user details":
			//				// reserved for later
			//				break;
			//			case "companies":
			//				nextRootNodeName = "Accounts";
			//				level = CurrentUser.AccessLevel + 1;
			//				info = new NodeInfo() { NodeId = Convert.ToInt16(tn.Tag), NodeName = tn.Text, NodeType = frmMain.OrgLevelTypes.Companies };
			//				break;
			//			case "accounts":
			//				nextRootNodeName = "Departments";
			//				level = CurrentUser.AccessLevel;
			//				info = new NodeInfo() { NodeId = Convert.ToInt16(tn.Tag), NodeName = tn.Text, NodeType = frmMain.OrgLevelTypes.Accounts };
			//				break;
			//			case "departments":
			//				nextRootNodeName = "Groups";
			//				level = CurrentUser.AccessLevel - 1;
			//				info = new NodeInfo() { NodeId = Convert.ToInt16(tn.Tag), NodeName = tn.Text, NodeType = frmMain.OrgLevelTypes.Departments };
			//				break;
			//			case "groups":
			//				nextRootNodeName = "Notebooks";
			//				level = CurrentUser.AccessLevel - 2;
			//				info = new NodeInfo() { NodeId = Convert.ToInt16(tn.Tag), NodeName = tn.Text, NodeType = frmMain.OrgLevelTypes.Groups };
			//				break;
			//		}

			//		//NodesInPath.Add(info);
			//		//UpdatePath();

			//		TreeNode nextNode = treeUser.Nodes.Cast<TreeNode>().Where(e => e.Text == nextRootNodeName).First();

			//		foreach (TreeNode node in DbAccess.GetOrgLevelChildren(Convert.ToInt32(tn.Tag), level))
			//		{
			//			if (!nextNode.Nodes.ContainsKey(node.Text))
			//			{
			//				nextNode.Nodes.Add(node);
			//			}
			//		}

			//		treeUser.ExpandAll();

			//	}
			//}
			//catch { }
		}

		private void treeUser_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{

			if (e.Button == MouseButtons.Right)
			{
				//treeUser.SelectedNode = e.Node;
				var v = HoverNode;
				mnuCreateNew.Text = "Add " + v.Name;
				SetContextMenus(e.Node);
			}

			if (e.Node.Level == 0) {; } else { LastClickedNode = e.Node; }

			//if(treeUser.GetNodeAt(e.X, e.Y).Level == 0)
			//{
			//	treeUser.SelectedNode = null;

			//}		
		}

		private void treeUser_MouseMove(object sender, MouseEventArgs e)
		{
			HoverNode = treeUser.GetNodeAt(e.X, e.Y);
		}

		private void UpdatePath()
		{
			lblTreePath.Text = string.Empty;
			NodeInfo info = new NodeInfo();
			string seperator = " > ";
			try
			{
				info = NodesInPath.Where(e => e.NodeType == frmMain.OrgLevelTypes.Companies).First();
				lblTreePath.Text += info.NodeName + seperator;
			}
			catch { }
			try
			{
				info = NodesInPath.Where(e => e.NodeType == frmMain.OrgLevelTypes.Accounts).First();
				lblTreePath.Text += info.NodeName + seperator;
			}
			catch { }
			try
			{
				info = NodesInPath.Where(e => e.NodeType == frmMain.OrgLevelTypes.Departments).First();
				lblTreePath.Text += info.NodeName + seperator;
			}
			catch { }
			try
			{
				info = NodesInPath.Where(e => e.NodeType == frmMain.OrgLevelTypes.Groups).First();
				lblTreePath.Text += info.NodeName;
			}
			catch { }

			if (lblTreePath.Text.Length > 0) { this.Height = lblTreePath.Top + lblTreePath.Height + 50; }

		} 
		#endregion

		private void txtCredentials_TextChanged(object sender, EventArgs e) { if (this.Size != SmallSize) { ResetForm(); } }

		private void lstCompanies_MU_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ListBox lb = (ListBox)sender;
			var bExists = false;

			var v2 = ((ListItem)lb.SelectedItem).Id;
			ListBox lbToPopulate = GetNextListBox((ListBox)sender);

			foreach (ListItem li in DbAccess.GetOrgLevelChildren(Convert.ToInt16(lbToPopulate.Tag), v2))
			{
				foreach(ListItem li2 in lbToPopulate.Items)
				{
					if(li.Name.Trim() == li2.Name.Trim()) { bExists = true; break; }
				}

				if (!bExists) { lbToPopulate.Items.Add(li); }
			}
		}
	}

	public struct NodeInfo
	{
		public int NodeId;
		public string NodeName;
		public frmMain.OrgLevelTypes NodeType;
	}
}
