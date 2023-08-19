/* 
 * Console for users to select CADG's or for Top Level Users to manage users and CADG's.
 * created 07/23/23
 * - jsr
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Encryption;
using Microsoft.VisualBasic.ApplicationServices;
using myNotebooks.DataAccess;
using myNotebooks.objects;
using MyNotebooks.objects;
using Org.BouncyCastle.Asn1;

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
		private const string CreateUserButton_CreateUser = "Create User";
		private const string CreateUserButton_UpdateUser = "Update User";
		private const string CreateUserButton_UpdatePermissions = "Update Permissions";
		private ListBox CurrentMouseListBox;
		private GroupBox CurrentMouseGroupBox;
		private frmMain.OrgLevelTypes CurrentType;
		private bool IsQuickStart;
		private bool ForceClose;

		public frmManagementConsole(Form parent, bool isQuickStart = false)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
			SmallSize = new(pnlLogin.Width + 40, pnlLogin.Height + pnlLogin.Top + grpUsers.Top + 35);
			FullSize = new(grpCurrentUser.Left + grpCurrentUser.Width + 30, grpUsers.Top + grpUsers.Height + 50);
			MediumSize = new(SmallSize.Width, FullSize.Height);
			OneUserSize = new(grpMasterUser.Left + grpMasterUser.Width + 20, FullSize.Height);
			ddlAccessLevels.Items.AddRange(DbAccess.GetAccessLevels().ToArray());
			txtUserName.Text = Program.User != null ? Program.User.Name : "";
			this.Size = SmallSize;
			PopulatePermissions();
			OrgLevelGroups_MU.AddRange(new GroupBox[] { grpCompany_MU, grpAccount_MU, grpDepartment_MU, grpGroup_MU });
			OrgLevelGroups_CU.AddRange(new GroupBox[] { grpCompany_CU, grpAccount_CU, grpDepartment_CU, grpGroup_CU });
			OrgLevelLists_MU.AddRange(new ListBox[] { lstCompanies_MU, lstAccounts_MU, lstDepartments_MU, lstGroups_MU });
			OrgLevelLists_CU.AddRange(new ListBox[] { lstCompanies_CU, lstAccounts_CU, lstDepartments_CU, lstGroups_CU });
			IsQuickStart = isQuickStart;
			txtPwd.Focus();
		}

		private void frmManagementConsole_Load(object sender, EventArgs e)
		{
			if (IsQuickStart)
			{
				txtPwd.Text = Program.PIN;
				btnLogin_Click(null, null);
				IsQuickStart = false;
			}
		}

		private void frmManagementConsole_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (lstGroups_CU.SelectedItem == null & lstGroups_MU.SelectedItem == null)
			{
				if(!ForceClose && this.Size != SmallSize)
				{
					using (frmMessage frm = new(frmMessage.OperationType.Message, "You must select a group.", "Group Selection Required", this)) { frm.ShowDialog(); }
					e.Cancel = true;
				}
			}
			else
			{
				var v = lstGroups_MU.SelectedItem as ListItem;
				var v2 = lstGroups_CU.SelectedItem as ListItem;
				Program.ActiveNBParentId = v == null ? v2.Id : v.Id;
			}
		}

		private void frmManagementConsole_Activated(object sender, EventArgs e) { txtPwd.Focus(); }

		private void btnCancel_Click(object sender, EventArgs e) { ForceClose = true; this.Close(); }

		private void btnCancelContinue_Click(object sender, EventArgs e) { this.Size = SmallSize; }

		private void btnCreateUser_Click(object sender, EventArgs e)
		{
			var msg = string.Empty;

			try
			{
				if (btnCreateUser.Text == CreateUserButton_CreateUser)  // adding base user
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
							AccessLevel = ddlAccessLevels.SelectedIndex + 1,
							CreatedBy = Program.User.UserId,
							CreatedOn = DateTime.Now
						};

						using (frmMessage frm = new(frmMessage.OperationType.InputBox, "What is the user's email?", "Email Is Required", this))
						{
							frm.ShowDialog(this);
							if (frm.Result == frmMessage.ReturnResult.Ok)
							{
								CurrentUser.Email = frm.ResultText;
								CurrentUser.UserId = DbAccess.CRUDMNUser(CurrentUser);
								msg = "The User '" + CurrentUser.Name + "' was created. Now choose permissions and organizationl levels and click '" + CreateUserButton_UpdateUser + "'.";
								this.Size = FullSize;
								btnCreateUser.Text = CreateUserButton_UpdateUser;
								PopulateBaseOrgLevels();
								PopulateTopLevels(true, false);
								clbPermissions.Enabled = true;
							}
						}
					}
				}
				else if (btnCreateUser.Text == CreateUserButton_UpdateUser) // updating created user with permissions and assignments
				{
					msg = string.Empty;
					UserPermissions permissions = GetCheckedPermissions();
					permissions.CreatedOn = DateTime.Now;

					if (!CurrentUser.Permissions.GetGrantedPermissions().Equals(permissions.GetGrantedPermissions()))
					{
						var dtCreatedOn = CurrentUser.Permissions.CreatedOn;
						CurrentUser.Permissions = permissions;
						CurrentUser.Permissions.CreatedOn = dtCreatedOn;
						CurrentUser.Permissions.EditedOn = DateTime.Now;
						CurrentUser.SavePermissions();
						msg = "The permissions for '" + CurrentUser.Name + "' were updated.";
						using (frmMessage frm = new(frmMessage.OperationType.Message, msg, "Operation Complete", this)) { frm.ShowDialog(this); }
					}

					List<UserAssignments> assignments = GetAssignments();
					
					if (CurrentUser.Assignments != assignments)
					{
						CurrentUser.Assignments = assignments;
						CurrentUser.SaveAssignments();
						msg = "The organization levels for '" + CurrentUser.Name + "' were updated.";
						using (frmMessage frm = new(frmMessage.OperationType.Message, msg, "Operation Complete", this)) { frm.ShowDialog(this); }
					}

					//if (msg.Length > 0) { PopulateTopLevels(true, this.Size == FullSize); }
				}
				else if (btnCreateUser.Text == CreateUserButton_UpdatePermissions)
				{
					CurrentUser.Permissions = GetCheckedPermissions();
					CurrentUser.SavePermissions();
					msg = "The permissions for '" + CurrentUser.Name + "' were updated.";
					using (frmMessage frm = new(frmMessage.OperationType.Message, msg, "Operation Complete", this)) { frm.ShowDialog(this); }
				}
				//Program.User = new(DbAccess.GetUser(Program.User.Name, Program.User.Password).Tables[0]);
			}
			catch (Exception ex)
			{
				msg = "An error occurred: " + ex.Message + ". The User was not created.";
			}

			//if (msg.Length > 0)
			//{
			//	using (frmMessage frm = new(frmMessage.OperationType.Message, msg, "Operation Complete", this)) { frm.ShowDialog(this); }
			//}
		}

		private void btnCancelNewUser_Click(object sender, EventArgs e) { ResetForm(); }

		private void btnLogin_Click(object sender, EventArgs e)
		{
			DataSet ds = new();

			if (IsQuickStart) { CurrentUser = Program.User; }
			else
			{
				ds = DbAccess.GetUser(txtUserName.Text, txtPwd.Text);
				CurrentUser = null;

				if (ds.Tables.Count > 0 & ds.Tables[0].Rows.Count > 0)
				{
					CurrentUser = new(ds.Tables[0]);
					CurrentUser = CurrentUser == null ? Program.User.ContainsChild(CurrentUser) ? CurrentUser : null : CurrentUser;
				}
			}

			if (CurrentUser != null)
			{
				if (!IsQuickStart) CurrentUser.Permissions = new(ds.Tables[1]);

				//foreach (DataRow dr in ds.Tables[2].Rows) { CurrentUser.Assignments.Add(new UserAssignments(dr)); }

				//TreeNode topNode = new TreeNode();
				PopulateBaseOrgLevels();
				PopulatePermissions();
				ListBox lb2Populate = new ListBox();
				ddlAccessLevels.SelectedIndex = CurrentUser.AccessLevel - 1;
				btnCreateUser.Text = CreateUserButton_UpdateUser;
				ddlAccessLevels.Enabled = false;
				PopulateTopLevels();

				//treeUser.Nodes.Cast<TreeNode>().Where(e => e.Text == vOrgLevelName).First().Nodes.AddRange(Program.User.GetHighestNodeItems().ToArray());
				//treeUser.ExpandAll();

				btnCreateUser.Visible = !CurrentUser.Equals(Program.User);
				clbPermissions.Enabled = CurrentUser.HasPermission(UserPermissions.Permissions.ManageUserPermissions);
				this.Size = CurrentUser.Equals(Program.User) ? OneUserSize : FullSize;
				btnLogin.Enabled = false;
			}
			else
			{
				if(txtUserName.Text.Length > 0)
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
							ddlAccessLevels.SelectedIndex = -1;
							btnCreateUser.Visible = true;
							btnCreateUser.Text = CreateUserButton_CreateUser;
							PopulatePermissions();
						}
					}
				}
			}

			IsQuickStart = false;
			pnlCreateUser.Visible = true;
		}

		private void clbPermissions_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (btnCreateUser.Text != CreateUserButton_CreateUser)
			{
				btnCreateUser.Text = CreateUserButton_UpdatePermissions;
				btnCreateUser.Visible = true;
			}
		}

		private ListBox GetNextListBox(ListBox lb)
		{
			ListBox lbNext = new ListBox();
			var isMU = lb.Name.Substring(lb.Name.Length - 3) == "_MU";

			switch (lb.Parent.Text)
			{
				case "Groups":
					// lbNext = ??
					break;
				case "Departments":
					lbNext = isMU ? lstGroups_MU : lstGroups_CU;
					break;
				case "Accounts":
					lbNext = isMU ? lstDepartments_MU : lstDepartments_CU;
					break;
				case "Companies":
					lbNext = isMU ? lstAccounts_MU : lstAccounts_CU;
					break;
			}
			return lbNext;
		}

		private UserPermissions GetCheckedPermissions()
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
			{ ua = new() { UserId = CurrentUser.UserId, CompanyId = li.Id, orgType = UserAssignments.OrgType.Company };			lRtrn.Add(ua); }
			foreach (ListItem li in lstAccounts_CU.Items)
			{ ua = new() { UserId = CurrentUser.UserId, AccountId = li.Id, orgType = UserAssignments.OrgType.Account };			lRtrn.Add(ua); }
			foreach (ListItem li in lstDepartments_CU.Items)
			{ ua = new() { UserId = CurrentUser.UserId, DepartmentId = li.Id, orgType = UserAssignments.OrgType.Department };	lRtrn.Add(ua); }
			foreach (ListItem li in lstGroups_CU.Items)
			{ ua = new() { UserId = CurrentUser.UserId, GroupId = li.Id, orgType = UserAssignments.OrgType.Group };				lRtrn.Add(ua); }

			return lRtrn;
		}

		private bool ListContains(ListBox lb, ListItem item)
		{
			bool bRtrn = false;
			foreach (ListItem li in lb.Items) { if (li.Name == item.Name && li.Id == item.Id) { bRtrn = true; break; } }
			return bRtrn;
		}

		private void ListBoxes_ClearBelow(ListBox lb)
		{
			var clearBelow = false;

			if (lb.Name.EndsWith("_MU"))
			{
				foreach (ListBox lbx in OrgLevelLists_MU)
				{
					if (lbx.Name == lb.Name | clearBelow) { lbx.Items.Clear(); clearBelow = true; }
				}
			}
			else if (lb.Name.EndsWith("_CU"))
			{
				foreach (ListBox lbx in OrgLevelLists_CU)
				{
					if (lbx.Name == lb.Name | clearBelow) { lbx.Items.Clear(); clearBelow = true; }
				}
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

		private async void lstGroups_MU_DoubleClick(object sender, EventArgs e)
		{ mnuManageNotebooks_Click(null, null); await Utilities.PopulateAllNotebookNames(); }

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

		private void lstMUCU_MouseDown(object sender, MouseEventArgs e)
		{
			CurrentMouseListBox.SelectedIndex = CurrentMouseListBox.IndexFromPoint(e.X, e.Y);

			if (e.Button == MouseButtons.Right)
			{
				//if (CurrentMouseListBox.SelectedItem != null)
				//{
				var vMouseListSelectedItemName = CurrentMouseListBox.SelectedItem != null ? (CurrentMouseListBox.SelectedItem as ListItem).Name.Trim() : null;
				var vGrp = CurrentMouseGroupBox as GroupBox;
				GroupBox vMouseListBoxGroup = (GroupBox)CurrentMouseListBox.Parent;
				var vCurMouseBoxIndex = OrgLevelLists_MU.IndexOf(CurrentMouseListBox);
				var vParentListSelectedItem = string.Empty;

				if (vCurMouseBoxIndex > 0)
				{
					var vPreviousOrgLevelList = OrgLevelLists_MU[vCurMouseBoxIndex - 1] as ListBox;
					vParentListSelectedItem = vPreviousOrgLevelList.SelectedItem != null ? vPreviousOrgLevelList.SelectedItem.ToString().Trim() : "";
				}

				ListBox parentList = (ListBox)vMouseListBoxGroup.Controls[0];

				mnuCreateNew.Text = "&Create New " + vMouseListBoxGroup.Name.Replace("grp", "").Replace("_MU", "") +
											(vParentListSelectedItem.Length > 0 ? " in '" + vParentListSelectedItem.Trim() + "'" : "'");
				mnuCreateNew.Enabled = CurrentMouseListBox.Name.EndsWith("_MU");

				mnuAssignUser.Enabled = vMouseListSelectedItemName != null && vGrp.Enabled && vGrp.Enabled;

				if (vMouseListSelectedItemName != null) mnuAssignUser.Text = "&Assign '" + vMouseListSelectedItemName + "' to User";

				mnuAssignUser.Visible = this.Size == FullSize && CurrentMouseListBox.Name.EndsWith("_MU");

				mnuEdit.Enabled = vMouseListSelectedItemName != null & CurrentMouseListBox.Name.EndsWith("_MU");
				mnuEdit.Text = vMouseListSelectedItemName != null ? "Edit '" + vMouseListSelectedItemName + "'" : "Delete";

				mnuDelete.Enabled = vMouseListSelectedItemName != null;
				mnuDelete.Text = vMouseListSelectedItemName != null ? "Delete '" + vMouseListSelectedItemName + "'" : "Delete";

				mnuManageNotebooks.Visible = vGrp.Name.ToLower().Contains("group");
				//}
				//else
				//{
				//	mnuCreateNew.Enabled = CurrentMouseListBox.Items.Count == 0;
				//	mnuAssignUser.Enabled = false;
				//	mnuEdit.Enabled = false;
				//	mnuDelete.Enabled = false;
				//	mnuManageNotebooks.Visible = false;
				//}
			}
			else
			{
				SelectChildren(sender, e);
			}
		}

		private void lstMUCU_MouseMove(object sender, MouseEventArgs e)
		{
			CurrentMouseListBox = (ListBox)sender;
			CurrentMouseGroupBox = (GroupBox)CurrentMouseListBox.Parent;

			frmMain.OrgLevelTypes choice;

			var typeName = CurrentMouseGroupBox.Name.Replace("grp", "").Replace("_MU", "").Replace("_CU", "");
			if (Enum.TryParse(typeName, out choice)) { CurrentType = choice; }

		}

		private void mnuAssignUser_Click(object sender, EventArgs e)
		{
			var v = CurrentMouseListBox.SelectedItem as ListItem;
			var tmpId = v.Id;
			v = new ListItem();
			v.Name = CurrentMouseListBox.SelectedItem.ToString();
			v.Id = tmpId;
			ListBox lbTarget = OrgLevelLists_CU.Where(e => e.Name == CurrentMouseListBox.Name.Replace("_MU", "_CU")).FirstOrDefault();

			if (!ListContains(lbTarget, v)) { lbTarget.Items.Add(v); }
			else
			{
				using (frmMessage frm = new(frmMessage.OperationType.Message,
					"The User already has access to '" + v.Name + "'.", "Already Assigned", this)) { frm.ShowDialog(); }
			}
		}

		private void mnuCreateNew_Click(object sender, EventArgs e)
		{
			var vCurrentGroupBoxName = CurrentMouseGroupBox.Name.Replace("grp", "").Replace("_MU", "");
			frmMain.OrgLevelTypes newItemType = (frmMain.OrgLevelTypes)Enum.Parse(typeof(frmMain.OrgLevelTypes), vCurrentGroupBoxName);
			var msg = string.Empty;
			string sMsgTemplate = "A{0} must be selected before adding a{1}.";
			var parentListBox = lstCompanies_MU;
			var parentGroupBox = grpCompany_CU;

			switch (newItemType)
			{
				case frmMain.OrgLevelTypes.Account:
					parentListBox = lstCompanies_MU;
					parentGroupBox = (GroupBox)parentListBox.Parent;
					if (parentListBox.Items.Count == 1) parentListBox.SelectedIndex = 0;
					if (parentGroupBox.Enabled && parentListBox.SelectedIndex == -1) { msg = string.Format(sMsgTemplate, " Company", "n Account"); }
					break;
				case frmMain.OrgLevelTypes.Department:
					parentListBox = lstAccounts_MU;
					parentGroupBox = (GroupBox)parentListBox.Parent;
					if (parentListBox.Items.Count == 1) parentListBox.SelectedIndex = 0;
					if (parentGroupBox.Enabled && parentListBox.SelectedIndex == -1) { msg = string.Format(sMsgTemplate, "n Account", " Department"); }
					break;
				case frmMain.OrgLevelTypes.Group:
					parentListBox = lstDepartments_MU;
					parentGroupBox = (GroupBox)parentListBox.Parent;
					if (parentListBox.Items.Count == 1) parentListBox.SelectedIndex = 0;
					if (parentGroupBox.Enabled && parentListBox.SelectedIndex == -1) { msg = string.Format(sMsgTemplate, " Department", " Group"); }
					break;
			}

			if (msg.Length > 0)
			{
				using (frmMessage frm = new(frmMessage.OperationType.Message, msg, "", this)) { frm.ShowDialog(); }
			}
			else
			{
				var vSelectedParentItem = (ListItem)parentListBox.SelectedItem;
				var parentId = CurrentMouseListBox == lstCompanies_MU ? 0 : vSelectedParentItem != null ? Convert.ToInt32(vSelectedParentItem.Id) : 0;

				using (frmAddOrgLevel frm = new frmAddOrgLevel(CurrentUser.UserId, newItemType,
					vSelectedParentItem != null ? vSelectedParentItem.Name : vCurrentGroupBoxName, this, parentId))
				{
					frm.ShowDialog();
					if (frm.WasCreated)
					{
						if (parentId == 0) { PopulateTopLevels(); }
						else { SelectChildren(parentListBox, null); }
					}
				}
			}
		}

		private void mnuEdit_Click(object sender, EventArgs e)
		{

		}

		private void mnuDelete_Click(object sender, EventArgs e)
		{

		}

		private void mnuManageNotebooks_Click(object sender, EventArgs e)
		{
			// Get notebooks by ParentId (group id).
			var groupId = (CurrentMouseListBox.SelectedItem as ListItem).Id;
			Program.ActiveNBParentId = groupId;
			List<Notebook> notebooks = DbAccess.GetNotebookNamesAndIdsForGroup(groupId);
			var tmpProgramUser = Program.User;

			if (CurrentMouseListBox.Name.EndsWith("MU"))
			{ tmpProgramUser = Program.User; }
			else { tmpProgramUser = CurrentUser; }

			Program.AllNotebooks.AddRange(notebooks);
			
			this.Close();
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
				foreach (GroupBox gb in OrgLevelGroups_MU) { SetGroupEnabled_Disabled(gb.Name.Replace("grp", ""), false); }

				if (Program.User.AccessLevel >= 3)
				{
					SetGroupEnabled_Disabled("Group_MU");
				}
				if (Program.User.AccessLevel >= 4)
				{
					SetGroupEnabled_Disabled("Department_MU");
				}
				if (Program.User.AccessLevel >= 5)
				{
					SetGroupEnabled_Disabled("Account_MU");
				}
				if (Program.User.AccessLevel >= 6)
				{
					SetGroupEnabled_Disabled("Company_MU");
				}
			}

			if (CurrentUser != null)
			{
				foreach (GroupBox gb in OrgLevelGroups_CU) { SetGroupEnabled_Disabled(gb.Name.Replace("grp", ""), false); }

				if (CurrentUser.AccessLevel >= 3)
				{
					SetGroupEnabled_Disabled("Group_CU");
				}
				if (CurrentUser.AccessLevel >= 4)
				{
					SetGroupEnabled_Disabled("Department_CU");
				}
				if (CurrentUser.AccessLevel >= 5)
				{
					SetGroupEnabled_Disabled("Account_CU");
				}
				if (CurrentUser.AccessLevel >= 6)
				{
					SetGroupEnabled_Disabled("Company_CU");
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

		private void PopulateTopLevels(bool populateMU = true, bool populateCU = true)
		{
			//ListBox lbCurrentLevel = new ListBox();
			//List<ListBox> tmpList = populateMU ? OrgLevelLists_MU : OrgLevelLists_CU;

			//foreach (ListBox lb in tmpList) { lb.Items.Clear(); }

			//for (int i = 6; i > tmpList.Count; i--)
			//{
			//	var v2 = Program.User.OrgLevels.Where(e => e.OrgLevelType == (frmMain.OrgLevelTypes)i).ToList();

			//	if (v2.Count() > 0)
			//	{
			//		foreach (OrgLevel ol in v2)
			//		{
			//			tmpList[i - 6].Items.Add(ol);
			//		}
			//		break;
			//	}
			//}

			GroupBox box = new();
			List<ListBox> lstBoxes = new();

			if (populateMU)
			{
				foreach (ListBox lb in OrgLevelLists_MU) { lb.Items.Clear(); }
				box = OrgLevelGroups_MU.Where(e => e.Enabled).FirstOrDefault();
				lstBoxes = box.Controls.Cast<ListBox>().ToList();
				//var highestLevel = CurrentUser.Companies;
				//if(highestLevel == null) { highestLevel = CurrentUser.Accounts; }
				//if(highestLevel == null) { highestLevel = CurrentUser.Departments; }
				//if(!highestLevel) { highestLevel = CurrentUser.Groups}

				//Type type = null;
				//type = 

				//var listItems = CurrentUser.Companies;

				lstBoxes[0].Items.AddRange(DbAccess.GetTopLevelItemsForUser(Program.User.UserId).ToArray());
			}

			if (populateCU)
			{
				foreach (ListBox lb in OrgLevelLists_CU) { lb.Items.Clear(); }
				box = OrgLevelGroups_CU.Where(e => e.Enabled).FirstOrDefault();
				lstBoxes = box.Controls.Cast<ListBox>().ToList();
				lstBoxes[0].Items.AddRange(DbAccess.GetTopLevelItemsForUser(CurrentUser.UserId).ToArray());
			}

		}

		private void ResetForm(bool resize = true)
		{
			if (resize) this.Size = SmallSize;
			foreach (ListBox lb in OrgLevelLists_CU) { lb.Items.Clear(); }
			foreach (ListBox lb in OrgLevelLists_MU) { lb.Items.Clear(); }
			clbPermissions.Items.Clear();
			//txtUserName.Text = string.Empty;
			//txtPwd.Text = string.Empty;
			pnlCreateUser.Visible = false;
			txtUserName.Focus();
			btnLogin.Enabled = true;
		}

		private void SelectChildren(object sender, MouseEventArgs e)
		{
			//ListBox lb = (ListBox)sender;

			//if (lb.SelectedItem != null)
			//{
			//	var orgLvl = ((OrgLevel)lb.SelectedItem);
			//	var v4 = orgLvl.OrgLevelType;

			//	ListBox lbToPopulate = OrgLevelLists_MU[Convert.ToInt32(CurrentMouseListBox.Tag) + 1];
			//	lbToPopulate.Items.Clear();
			//	var v3 = Program.User.OrgLevels.Where(e => e.ParentId == orgLvl.Id ).ToList();

			//	foreach (OrgLevel ol in v3)
			//	{
			//		lbToPopulate.Items.Add(ol);
			//	}
			//}

			ListBox lb = (ListBox)sender;

			if (lb.SelectedItem != null)
			{
				var v2 = ((ListItem)lb.SelectedItem).Id;
				ListBox lbToPopulate = GetNextListBox((ListBox)sender);	// Will not get a listBox if sender is a Group listBox.

				if(lbToPopulate.Name.Length > 0)
				{
					ListBoxes_ClearBelow(lbToPopulate);
					//lbToPopulate.Items.Clear();

					foreach (ListItem li in DbAccess.GetOrgLevelChildren(Convert.ToInt16(lbToPopulate.Tag), v2))
					{ if (!ListContains(lbToPopulate, li)) { lbToPopulate.Items.Add(li); } }
				}
			}

		}

		private void SetContextMenus(TreeNode tn)
		{
			mnuAssignUser.Visible = false;
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
			GroupBox gb2;

			if (groupName.EndsWith("_MU"))
			{
				gb2 = OrgLevelGroups_MU.Where(box => box.Name == "grp" + groupName).FirstOrDefault();
				gb2.Enabled = setEnabled;
			}
			else
			{
				gb2 = OrgLevelGroups_CU.Where(box => box.Name == "grp" + groupName).FirstOrDefault();
				gb2.Enabled = setEnabled;
			}
		}

		#region treeUser methods

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
			//				info = new NodeInfo() { NodeId = Convert.ToInt16(tn.Tag), NodeName = tn.Text, NodeType = frmMain.OrgLevelType.Companies };
			//				break;
			//			case "accounts":
			//				nextRootNodeName = "Departments";
			//				level = CurrentUser.AccessLevel;
			//				info = new NodeInfo() { NodeId = Convert.ToInt16(tn.Tag), NodeName = tn.Text, NodeType = frmMain.OrgLevelType.Accounts };
			//				break;
			//			case "departments":
			//				nextRootNodeName = "Groups";
			//				level = CurrentUser.AccessLevel - 1;
			//				info = new NodeInfo() { NodeId = Convert.ToInt16(tn.Tag), NodeName = tn.Text, NodeType = frmMain.OrgLevelType.Departments };
			//				break;
			//			case "groups":
			//				nextRootNodeName = "Notebooks";
			//				level = CurrentUser.AccessLevel - 2;
			//				info = new NodeInfo() { NodeId = Convert.ToInt16(tn.Tag), NodeName = tn.Text, NodeType = frmMain.OrgLevelType.Groups };
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
				info = NodesInPath.Where(e => e.NodeType == frmMain.OrgLevelTypes.Company).First();
				lblTreePath.Text += info.NodeName + seperator;
			}
			catch { }
			try
			{
				info = NodesInPath.Where(e => e.NodeType == frmMain.OrgLevelTypes.Account).First();
				lblTreePath.Text += info.NodeName + seperator;
			}
			catch { }
			try
			{
				info = NodesInPath.Where(e => e.NodeType == frmMain.OrgLevelTypes.Department).First();
				lblTreePath.Text += info.NodeName + seperator;
			}
			catch { }
			try
			{
				info = NodesInPath.Where(e => e.NodeType == frmMain.OrgLevelTypes.Group).First();
				lblTreePath.Text += info.NodeName;
			}
			catch { }

			if (lblTreePath.Text.Length > 0) { this.Height = lblTreePath.Top + lblTreePath.Height + 50; }

		}
		#endregion

		private void txtCredentials_TextChanged(object sender, EventArgs e) { if (this.Size != SmallSize) { ResetForm(); } }
	}

	public struct NodeInfo
	{
		public int NodeId;
		public string NodeName;
		public frmMain.OrgLevelTypes NodeType;
	}
}
