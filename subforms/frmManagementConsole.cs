using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Encryption;
using myNotebooks.DataAccess;
using myNotebooks.objects;
using MyNotebooks.objects;

namespace myNotebooks.subforms
{
	public partial class frmManagementConsole : Form
	{
		private Size SmallSize = new Size();
		//private Size MediumSize = new Size();
		private Size FullSize = new Size();
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

		public frmManagementConsole(Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
			SmallSize = new Size(pnlLogin.Width + 40, pnlLogin.Height + pnlLogin.Top + grpUsers.Top + 35);
			FullSize = new Size(grpCurrentUser.Left + grpCurrentUser.Width + 30, grpUsers.Top + grpUsers.Height + 50);
			//FullSize = new Size(grpTree.Left + grpTree.Width + 30, pnlCreateUser.Top + pnlCreateUser.Height + 50);
			//MediumSize = new Size(SmallSize.Width, FullSize.Height);
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
				foreach (DataRow dr in ds.Tables[2].Rows) { Program.User.Assignments.Add(new UserAssignment(dr)); }

				TreeNode topNode = new TreeNode();
				PopulateBaseTree();
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
			}
			else
			{
				using (frmMessage frm = new(frmMessage.OperationType.Message, "User not found.", "Invalid Credentials", this)) { frm.ShowDialog(this); }
			}




			if (CurrentUser != null)
			{
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

		private void PopulateBaseTree()
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
				SetNodeEnabled_Disabled("Companies", false);
				SetNodeEnabled_Disabled("Accounts", false);
				SetNodeEnabled_Disabled("Departments", false);
				SetNodeEnabled_Disabled("Groups", false);

				if (Program.User.AccessLevel >= 3)
				{
					SetNodeEnabled_Disabled("Groups");
				}
				if (Program.User.AccessLevel >= 4)
				{
					SetNodeEnabled_Disabled("Departments");
				}
				if (Program.User.AccessLevel >= 5)
				{
					SetNodeEnabled_Disabled("Accounts");
				}
				if (Program.User.AccessLevel >= 6)
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

		private void SetNodeEnabled_Disabled(string nodeName, bool setEnabled = true)
		{
			GroupBox gb2 = OrgLevelGroups_MU.Where(box => box.Name == "grp" + nodeName + "_MU").FirstOrDefault();
			gb2.Enabled = setEnabled;
			gb2 = OrgLevelGroups_CU.Where(box => box.Name == "grp" + nodeName + "_CU").FirstOrDefault();
			gb2.Enabled = setEnabled;

			//foreach (TreeNode tn in treeUser.Nodes)
			//{
			//	if (tn.Text == nodeName)
			//	{
			//		tn.ForeColor = setEnabled ? EnabledColor : DisabledColor;
			//		tn.BackColor = setEnabled ? Color.White : Color.White;
			//	}
			//}
		}

		private void treeUser_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{ e.Cancel = e.Node.ForeColor == DisabledColor; }

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

		private void treeUser_MouseMove(object sender, MouseEventArgs e)
		{
			HoverNode = treeUser.GetNodeAt(e.X, e.Y);
		}

		private void treeUser_Click(object sender, EventArgs e)
		{

		}

		private void OrgLevelList_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox lb = (ListBox)sender;
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

			//foreach (NodeInfo node in DbAccess.GetOrgLevelChildren(Convert.ToInt16(lbNext.Tag), )




		}

		private void OrgLevelList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ListBox lb = (ListBox)sender;

			var v2 = ((ListItem)lb.SelectedItem).Id;
			ListBox lbToPopulate = GetNextListBox((ListBox)sender);

			foreach (ListItem li in DbAccess.GetOrgLevelChildren(Convert.ToInt16(lbToPopulate.Tag), v2))
			{
				lbToPopulate.Items.Add(li);
			}
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
	}

	public struct NodeInfo
	{
		public int NodeId;
		public string NodeName;
		public frmMain.OrgLevelTypes NodeType;
	}
}
