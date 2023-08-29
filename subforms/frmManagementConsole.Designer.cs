using System.Security.Cryptography.Xml;
using System.Windows.Forms;

namespace myNotebooks.subforms
{
	partial class frmManagementConsole
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			grpUsers = new GroupBox();
			btnCancelNewUser = new Button();
			btnCreateUser = new Button();
			pnlCreateUser = new Panel();
			ddlAccessLevels = new ComboBox();
			label19 = new Label();
			clbPermissions = new CheckedListBox();
			label6 = new Label();
			pnlLogin = new Panel();
			txtUserName = new TextBox();
			btnCancel = new Button();
			label1 = new Label();
			btnLogin = new Button();
			label2 = new Label();
			txtPwd = new TextBox();
			grpMasterUser = new GroupBox();
			grpCompany_MU = new GroupBox();
			lstCompanies_MU = new ListBox();
			mnuContextTree = new ContextMenuStrip(components);
			mnuAssignUser = new ToolStripMenuItem();
			mnuCreateNew = new ToolStripMenuItem();
			mnuEdit = new ToolStripMenuItem();
			mnuDelete = new ToolStripMenuItem();
			mnuManageNotebooks = new ToolStripMenuItem();
			grpGroup_MU = new GroupBox();
			lstGroups_MU = new ListBox();
			grpDepartment_MU = new GroupBox();
			lstDepartments_MU = new ListBox();
			grpAccount_MU = new GroupBox();
			lstAccounts_MU = new ListBox();
			toolStripContainer1 = new ToolStripContainer();
			grpTree = new GroupBox();
			treeUser = new TreeView();
			label3 = new Label();
			lblTreePath = new Label();
			panel2 = new Panel();
			groupBox1 = new GroupBox();
			grpCurrentUser = new GroupBox();
			grpCompany_CU = new GroupBox();
			lstCompanies_CU = new ListBox();
			grpGroup_CU = new GroupBox();
			lstGroups_CU = new ListBox();
			grpDepartment_CU = new GroupBox();
			lstDepartments_CU = new ListBox();
			grpAccount_CU = new GroupBox();
			lstAccounts_CU = new ListBox();
			grpUsers.SuspendLayout();
			pnlCreateUser.SuspendLayout();
			pnlLogin.SuspendLayout();
			grpMasterUser.SuspendLayout();
			grpCompany_MU.SuspendLayout();
			mnuContextTree.SuspendLayout();
			grpGroup_MU.SuspendLayout();
			grpDepartment_MU.SuspendLayout();
			grpAccount_MU.SuspendLayout();
			toolStripContainer1.SuspendLayout();
			grpTree.SuspendLayout();
			grpCurrentUser.SuspendLayout();
			grpCompany_CU.SuspendLayout();
			grpGroup_CU.SuspendLayout();
			grpDepartment_CU.SuspendLayout();
			grpAccount_CU.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpUsers
			// 
			grpUsers.Controls.Add(btnCancelNewUser);
			grpUsers.Controls.Add(btnCreateUser);
			grpUsers.Controls.Add(pnlCreateUser);
			grpUsers.Controls.Add(pnlLogin);
			grpUsers.Location = new System.Drawing.Point(8, 3);
			grpUsers.Name = "grpUsers";
			grpUsers.Size = new System.Drawing.Size(280, 516);
			grpUsers.TabIndex = 20;
			grpUsers.TabStop = false;
			grpUsers.Text = "Users";
			// 
			// btnCancelNewUser
			// 
			btnCancelNewUser.Location = new System.Drawing.Point(183, 486);
			btnCancelNewUser.Name = "btnCancelNewUser";
			btnCancelNewUser.Size = new System.Drawing.Size(91, 23);
			btnCancelNewUser.TabIndex = 21;
			btnCancelNewUser.Text = "&Cancel";
			btnCancelNewUser.UseVisualStyleBackColor = true;
			btnCancelNewUser.Click += this.btnCancelNewUser_Click;
			// 
			// btnCreateUser
			// 
			btnCreateUser.Location = new System.Drawing.Point(4, 486);
			btnCreateUser.Name = "btnCreateUser";
			btnCreateUser.Size = new System.Drawing.Size(157, 23);
			btnCreateUser.TabIndex = 20;
			btnCreateUser.Text = "Assign Organizations";
			btnCreateUser.UseVisualStyleBackColor = true;
			btnCreateUser.Click += this.btnCreateUser_Click;
			// 
			// pnlCreateUser
			// 
			pnlCreateUser.Controls.Add(ddlAccessLevels);
			pnlCreateUser.Controls.Add(label19);
			pnlCreateUser.Controls.Add(clbPermissions);
			pnlCreateUser.Controls.Add(label6);
			pnlCreateUser.Location = new System.Drawing.Point(4, 125);
			pnlCreateUser.Name = "pnlCreateUser";
			pnlCreateUser.Size = new System.Drawing.Size(270, 355);
			pnlCreateUser.TabIndex = 12;
			pnlCreateUser.Visible = false;
			// 
			// ddlAccessLevels
			// 
			ddlAccessLevels.FormattingEnabled = true;
			ddlAccessLevels.Location = new System.Drawing.Point(95, 9);
			ddlAccessLevels.Name = "ddlAccessLevels";
			ddlAccessLevels.Size = new System.Drawing.Size(165, 23);
			ddlAccessLevels.TabIndex = 18;
			// 
			// label19
			// 
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(20, 12);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(73, 15);
			label19.TabIndex = 17;
			label19.Text = "Access Level";
			// 
			// clbPermissions
			// 
			clbPermissions.CheckOnClick = true;
			clbPermissions.FormattingEnabled = true;
			clbPermissions.Location = new System.Drawing.Point(6, 56);
			clbPermissions.Name = "clbPermissions";
			clbPermissions.Size = new System.Drawing.Size(260, 292);
			clbPermissions.TabIndex = 16;
			clbPermissions.SelectedIndexChanged += this.clbPermissions_SelectedIndexChanged;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(6, 39);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(70, 15);
			label6.TabIndex = 15;
			label6.Text = "Permissions";
			// 
			// pnlLogin
			// 
			pnlLogin.Controls.Add(txtUserName);
			pnlLogin.Controls.Add(btnCancel);
			pnlLogin.Controls.Add(label1);
			pnlLogin.Controls.Add(btnLogin);
			pnlLogin.Controls.Add(label2);
			pnlLogin.Controls.Add(txtPwd);
			pnlLogin.Location = new System.Drawing.Point(4, 15);
			pnlLogin.Name = "pnlLogin";
			pnlLogin.Size = new System.Drawing.Size(266, 110);
			pnlLogin.TabIndex = 11;
			// 
			// txtUserName
			// 
			txtUserName.Location = new System.Drawing.Point(76, 5);
			txtUserName.MaxLength = 50;
			txtUserName.Name = "txtUserName";
			txtUserName.Size = new System.Drawing.Size(184, 23);
			txtUserName.TabIndex = 1;
			txtUserName.TextChanged += this.txtCredentials_TextChanged;
			// 
			// btnCancel
			// 
			btnCancel.Location = new System.Drawing.Point(163, 73);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 5;
			btnCancel.Text = "&Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += this.btnCancel_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(31, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(42, 15);
			label1.TabIndex = 0;
			label1.Text = "Name:";
			// 
			// btnLogin
			// 
			btnLogin.Location = new System.Drawing.Point(20, 73);
			btnLogin.Name = "btnLogin";
			btnLogin.Size = new System.Drawing.Size(137, 23);
			btnLogin.TabIndex = 4;
			btnLogin.Text = "&Lookup User";
			btnLogin.UseVisualStyleBackColor = true;
			btnLogin.Click += this.btnLogin_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(13, 42);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(60, 15);
			label2.TabIndex = 2;
			label2.Text = "Password:";
			// 
			// txtPwd
			// 
			txtPwd.Location = new System.Drawing.Point(76, 39);
			txtPwd.MaxLength = 50;
			txtPwd.Name = "txtPwd";
			txtPwd.Size = new System.Drawing.Size(184, 23);
			txtPwd.TabIndex = 1;
			txtPwd.TextChanged += this.txtCredentials_TextChanged;
			// 
			// grpMasterUser
			// 
			grpMasterUser.Controls.Add(grpCompany_MU);
			grpMasterUser.Controls.Add(grpGroup_MU);
			grpMasterUser.Controls.Add(grpDepartment_MU);
			grpMasterUser.Controls.Add(grpAccount_MU);
			grpMasterUser.Location = new System.Drawing.Point(294, 3);
			grpMasterUser.Name = "grpMasterUser";
			grpMasterUser.Size = new System.Drawing.Size(242, 516);
			grpMasterUser.TabIndex = 21;
			grpMasterUser.TabStop = false;
			grpMasterUser.Text = "Available Organization Levels";
			// 
			// grpCompany_MU
			// 
			grpCompany_MU.Controls.Add(lstCompanies_MU);
			grpCompany_MU.Location = new System.Drawing.Point(6, 19);
			grpCompany_MU.Name = "grpCompany_MU";
			grpCompany_MU.Size = new System.Drawing.Size(227, 123);
			grpCompany_MU.TabIndex = 33;
			grpCompany_MU.TabStop = false;
			grpCompany_MU.Tag = "6";
			grpCompany_MU.Text = "Companies";
			// 
			// lstCompanies_MU
			// 
			lstCompanies_MU.ContextMenuStrip = mnuContextTree;
			lstCompanies_MU.DisplayMember = "Name";
			lstCompanies_MU.FormattingEnabled = true;
			lstCompanies_MU.ItemHeight = 15;
			lstCompanies_MU.Location = new System.Drawing.Point(0, 21);
			lstCompanies_MU.Name = "lstCompanies_MU";
			lstCompanies_MU.Size = new System.Drawing.Size(227, 94);
			lstCompanies_MU.TabIndex = 25;
			lstCompanies_MU.Tag = "0";
			lstCompanies_MU.ValueMember = "Id";
			lstCompanies_MU.DragLeave += this.lstMU_DragLeave;
			lstCompanies_MU.MouseDown += this.lstMUCU_MouseDown;
			lstCompanies_MU.MouseMove += this.lstMUCU_MouseMove;
			// 
			// mnuContextTree
			// 
			mnuContextTree.Items.AddRange(new ToolStripItem[] { mnuAssignUser, mnuCreateNew, mnuEdit, mnuDelete, mnuManageNotebooks });
			mnuContextTree.Name = "mnuContextTree";
			mnuContextTree.Size = new System.Drawing.Size(179, 114);
			// 
			// mnuAssignUser
			// 
			mnuAssignUser.Name = "mnuAssignUser";
			mnuAssignUser.Size = new System.Drawing.Size(178, 22);
			mnuAssignUser.Text = "&Assign to User";
			mnuAssignUser.Click += this.mnuAssignUser_Click;
			// 
			// mnuCreateNew
			// 
			mnuCreateNew.Name = "mnuCreateNew";
			mnuCreateNew.Size = new System.Drawing.Size(178, 22);
			mnuCreateNew.Text = "Create &New";
			mnuCreateNew.Click += this.mnuCreateNew_Click;
			// 
			// mnuEdit
			// 
			mnuEdit.Name = "mnuEdit";
			mnuEdit.Size = new System.Drawing.Size(178, 22);
			mnuEdit.Text = "&Edit";
			mnuEdit.Click += this.mnuEdit_Click;
			// 
			// mnuDelete
			// 
			mnuDelete.Name = "mnuDelete";
			mnuDelete.Size = new System.Drawing.Size(178, 22);
			mnuDelete.Text = "&Delete_original";
			mnuDelete.Click += this.mnuDelete_Click;
			// 
			// mnuManageNotebooks
			// 
			mnuManageNotebooks.Name = "mnuManageNotebooks";
			mnuManageNotebooks.Size = new System.Drawing.Size(178, 22);
			mnuManageNotebooks.Text = "&Manage Notebooks";
			mnuManageNotebooks.Visible = false;
			mnuManageNotebooks.Click += this.mnuManageNotebooks_Click;
			// 
			// grpGroup_MU
			// 
			grpGroup_MU.Controls.Add(lstGroups_MU);
			grpGroup_MU.Location = new System.Drawing.Point(6, 388);
			grpGroup_MU.Name = "grpGroup_MU";
			grpGroup_MU.Size = new System.Drawing.Size(227, 123);
			grpGroup_MU.TabIndex = 34;
			grpGroup_MU.TabStop = false;
			grpGroup_MU.Tag = "3";
			grpGroup_MU.Text = "Groups";
			// 
			// lstGroups_MU
			// 
			lstGroups_MU.ContextMenuStrip = mnuContextTree;
			lstGroups_MU.DisplayMember = "Name";
			lstGroups_MU.FormattingEnabled = true;
			lstGroups_MU.ItemHeight = 15;
			lstGroups_MU.Location = new System.Drawing.Point(0, 21);
			lstGroups_MU.Name = "lstGroups_MU";
			lstGroups_MU.Size = new System.Drawing.Size(221, 94);
			lstGroups_MU.TabIndex = 25;
			lstGroups_MU.Tag = "3";
			lstGroups_MU.ValueMember = "Id";
			lstGroups_MU.DragLeave += this.lstMU_DragLeave;
			lstGroups_MU.DoubleClick += this.lstGroups_MU_DoubleClick;
			lstGroups_MU.MouseDown += this.lstMUCU_MouseDown;
			lstGroups_MU.MouseMove += this.lstMUCU_MouseMove;
			// 
			// grpDepartment_MU
			// 
			grpDepartment_MU.Controls.Add(lstDepartments_MU);
			grpDepartment_MU.Location = new System.Drawing.Point(6, 265);
			grpDepartment_MU.Name = "grpDepartment_MU";
			grpDepartment_MU.Size = new System.Drawing.Size(227, 123);
			grpDepartment_MU.TabIndex = 34;
			grpDepartment_MU.TabStop = false;
			grpDepartment_MU.Tag = "4";
			grpDepartment_MU.Text = "Departments";
			// 
			// lstDepartments_MU
			// 
			lstDepartments_MU.ContextMenuStrip = mnuContextTree;
			lstDepartments_MU.DisplayMember = "Name";
			lstDepartments_MU.FormattingEnabled = true;
			lstDepartments_MU.ItemHeight = 15;
			lstDepartments_MU.Location = new System.Drawing.Point(0, 21);
			lstDepartments_MU.Name = "lstDepartments_MU";
			lstDepartments_MU.Size = new System.Drawing.Size(227, 94);
			lstDepartments_MU.TabIndex = 25;
			lstDepartments_MU.Tag = "2";
			lstDepartments_MU.ValueMember = "Id";
			lstDepartments_MU.DragLeave += this.lstMU_DragLeave;
			lstDepartments_MU.MouseDown += this.lstMUCU_MouseDown;
			lstDepartments_MU.MouseMove += this.lstMUCU_MouseMove;
			// 
			// grpAccount_MU
			// 
			grpAccount_MU.Controls.Add(lstAccounts_MU);
			grpAccount_MU.Location = new System.Drawing.Point(6, 142);
			grpAccount_MU.Name = "grpAccount_MU";
			grpAccount_MU.Size = new System.Drawing.Size(227, 123);
			grpAccount_MU.TabIndex = 34;
			grpAccount_MU.TabStop = false;
			grpAccount_MU.Tag = "5";
			grpAccount_MU.Text = "Accounts";
			// 
			// lstAccounts_MU
			// 
			lstAccounts_MU.ContextMenuStrip = mnuContextTree;
			lstAccounts_MU.DisplayMember = "Name";
			lstAccounts_MU.FormattingEnabled = true;
			lstAccounts_MU.ItemHeight = 15;
			lstAccounts_MU.Location = new System.Drawing.Point(0, 21);
			lstAccounts_MU.Name = "lstAccounts_MU";
			lstAccounts_MU.Size = new System.Drawing.Size(227, 94);
			lstAccounts_MU.TabIndex = 25;
			lstAccounts_MU.Tag = "1";
			lstAccounts_MU.ValueMember = "Id";
			lstAccounts_MU.DragLeave += this.lstMU_DragLeave;
			lstAccounts_MU.MouseDown += this.lstMUCU_MouseDown;
			lstAccounts_MU.MouseMove += this.lstMUCU_MouseMove;
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(150, 150);
			toolStripContainer1.Location = new System.Drawing.Point(12, 263);
			toolStripContainer1.Name = "toolStripContainer1";
			toolStripContainer1.Size = new System.Drawing.Size(150, 175);
			toolStripContainer1.TabIndex = 25;
			toolStripContainer1.Text = "toolStripContainer1";
			// 
			// grpTree
			// 
			grpTree.Controls.Add(treeUser);
			grpTree.Location = new System.Drawing.Point(832, 145);
			grpTree.Name = "grpTree";
			grpTree.Size = new System.Drawing.Size(221, 461);
			grpTree.TabIndex = 28;
			grpTree.TabStop = false;
			grpTree.Text = "Current User";
			// 
			// treeUser
			// 
			treeUser.ContextMenuStrip = mnuContextTree;
			treeUser.Location = new System.Drawing.Point(12, 22);
			treeUser.Name = "treeUser";
			treeUser.Size = new System.Drawing.Size(209, 401);
			treeUser.TabIndex = 0;
			treeUser.Text = "tree";
			treeUser.BeforeSelect += this.treeUser_BeforeSelect;
			treeUser.NodeMouseClick += this.treeUser_NodeMouseClick;
			treeUser.Click += this.treeUser_Click;
			treeUser.DoubleClick += this.treeUser_DoubleClick;
			treeUser.MouseMove += this.treeUser_MouseMove;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.ForeColor = System.Drawing.Color.SteelBlue;
			label3.Location = new System.Drawing.Point(39, 565);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(34, 15);
			label3.TabIndex = 31;
			label3.Text = "Path:";
			// 
			// lblTreePath
			// 
			lblTreePath.AutoSize = true;
			lblTreePath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
			lblTreePath.ForeColor = System.Drawing.Color.SteelBlue;
			lblTreePath.Location = new System.Drawing.Point(39, 580);
			lblTreePath.Name = "lblTreePath";
			lblTreePath.Size = new System.Drawing.Size(261, 15);
			lblTreePath.TabIndex = 32;
			lblTreePath.Text = "Companies > Accounts > Departments > Groups";
			// 
			// panel2
			// 
			panel2.Location = new System.Drawing.Point(832, 18);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(125, 117);
			panel2.TabIndex = 22;
			// 
			// groupBox1
			// 
			groupBox1.Location = new System.Drawing.Point(1106, 521);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(114, 94);
			groupBox1.TabIndex = 35;
			groupBox1.TabStop = false;
			groupBox1.Text = "groupBox2";
			// 
			// grpCurrentUser
			// 
			grpCurrentUser.Controls.Add(grpCompany_CU);
			grpCurrentUser.Controls.Add(grpGroup_CU);
			grpCurrentUser.Controls.Add(grpDepartment_CU);
			grpCurrentUser.Controls.Add(grpAccount_CU);
			grpCurrentUser.Location = new System.Drawing.Point(544, 3);
			grpCurrentUser.Name = "grpCurrentUser";
			grpCurrentUser.Size = new System.Drawing.Size(242, 516);
			grpCurrentUser.TabIndex = 36;
			grpCurrentUser.TabStop = false;
			grpCurrentUser.Text = "Current User Organization Levels";
			// 
			// grpCompany_CU
			// 
			grpCompany_CU.Controls.Add(lstCompanies_CU);
			grpCompany_CU.Location = new System.Drawing.Point(6, 19);
			grpCompany_CU.Name = "grpCompany_CU";
			grpCompany_CU.Size = new System.Drawing.Size(227, 123);
			grpCompany_CU.TabIndex = 33;
			grpCompany_CU.TabStop = false;
			grpCompany_CU.Tag = "6";
			grpCompany_CU.Text = "Companies";
			// 
			// lstCompanies_CU
			// 
			lstCompanies_CU.AllowDrop = true;
			lstCompanies_CU.ContextMenuStrip = mnuContextTree;
			lstCompanies_CU.DisplayMember = "Name";
			lstCompanies_CU.FormattingEnabled = true;
			lstCompanies_CU.ItemHeight = 15;
			lstCompanies_CU.Location = new System.Drawing.Point(0, 21);
			lstCompanies_CU.Name = "lstCompanies_CU";
			lstCompanies_CU.Size = new System.Drawing.Size(227, 94);
			lstCompanies_CU.TabIndex = 25;
			lstCompanies_CU.Tag = "0";
			lstCompanies_CU.ValueMember = "Id";
			lstCompanies_CU.DragEnter += this.lstCU_DragEnter;
			lstCompanies_CU.MouseDown += this.lstMUCU_MouseDown;
			lstCompanies_CU.MouseMove += this.lstMUCU_MouseMove;
			// 
			// grpGroup_CU
			// 
			grpGroup_CU.Controls.Add(lstGroups_CU);
			grpGroup_CU.Location = new System.Drawing.Point(6, 388);
			grpGroup_CU.Name = "grpGroup_CU";
			grpGroup_CU.Size = new System.Drawing.Size(227, 123);
			grpGroup_CU.TabIndex = 34;
			grpGroup_CU.TabStop = false;
			grpGroup_CU.Tag = "3";
			grpGroup_CU.Text = "Groups";
			// 
			// lstGroups_CU
			// 
			lstGroups_CU.AllowDrop = true;
			lstGroups_CU.ContextMenuStrip = mnuContextTree;
			lstGroups_CU.DisplayMember = "Name";
			lstGroups_CU.FormattingEnabled = true;
			lstGroups_CU.ItemHeight = 15;
			lstGroups_CU.Location = new System.Drawing.Point(0, 21);
			lstGroups_CU.Name = "lstGroups_CU";
			lstGroups_CU.Size = new System.Drawing.Size(221, 94);
			lstGroups_CU.TabIndex = 25;
			lstGroups_CU.Tag = "3";
			lstGroups_CU.ValueMember = "Id";
			lstGroups_CU.DragEnter += this.lstCU_DragEnter;
			lstGroups_CU.DoubleClick += this.lstGroups_MU_DoubleClick;
			lstGroups_CU.MouseDown += this.lstMUCU_MouseDown;
			lstGroups_CU.MouseMove += this.lstMUCU_MouseMove;
			// 
			// grpDepartment_CU
			// 
			grpDepartment_CU.Controls.Add(lstDepartments_CU);
			grpDepartment_CU.Location = new System.Drawing.Point(6, 265);
			grpDepartment_CU.Name = "grpDepartment_CU";
			grpDepartment_CU.Size = new System.Drawing.Size(227, 123);
			grpDepartment_CU.TabIndex = 34;
			grpDepartment_CU.TabStop = false;
			grpDepartment_CU.Tag = "4";
			grpDepartment_CU.Text = "Departments";
			// 
			// lstDepartments_CU
			// 
			lstDepartments_CU.AllowDrop = true;
			lstDepartments_CU.ContextMenuStrip = mnuContextTree;
			lstDepartments_CU.DisplayMember = "Name";
			lstDepartments_CU.FormattingEnabled = true;
			lstDepartments_CU.ItemHeight = 15;
			lstDepartments_CU.Location = new System.Drawing.Point(0, 21);
			lstDepartments_CU.Name = "lstDepartments_CU";
			lstDepartments_CU.Size = new System.Drawing.Size(227, 94);
			lstDepartments_CU.TabIndex = 25;
			lstDepartments_CU.Tag = "2";
			lstDepartments_CU.ValueMember = "Id";
			lstDepartments_CU.DragEnter += this.lstCU_DragEnter;
			lstDepartments_CU.MouseDown += this.lstMUCU_MouseDown;
			lstDepartments_CU.MouseMove += this.lstMUCU_MouseMove;
			// 
			// grpAccount_CU
			// 
			grpAccount_CU.Controls.Add(lstAccounts_CU);
			grpAccount_CU.Location = new System.Drawing.Point(6, 142);
			grpAccount_CU.Name = "grpAccount_CU";
			grpAccount_CU.Size = new System.Drawing.Size(227, 123);
			grpAccount_CU.TabIndex = 34;
			grpAccount_CU.TabStop = false;
			grpAccount_CU.Tag = "5";
			grpAccount_CU.Text = "Accounts";
			// 
			// lstAccounts_CU
			// 
			lstAccounts_CU.AllowDrop = true;
			lstAccounts_CU.ContextMenuStrip = mnuContextTree;
			lstAccounts_CU.DisplayMember = "Name";
			lstAccounts_CU.FormattingEnabled = true;
			lstAccounts_CU.ItemHeight = 15;
			lstAccounts_CU.Location = new System.Drawing.Point(0, 21);
			lstAccounts_CU.Name = "lstAccounts_CU";
			lstAccounts_CU.Size = new System.Drawing.Size(227, 94);
			lstAccounts_CU.TabIndex = 25;
			lstAccounts_CU.Tag = "1";
			lstAccounts_CU.ValueMember = "Id";
			lstAccounts_CU.DragEnter += this.lstCU_DragEnter;
			lstAccounts_CU.MouseDown += this.lstMUCU_MouseDown;
			lstAccounts_CU.MouseMove += this.lstMUCU_MouseMove;
			// 
			// frmManagementConsole
			// 
			AcceptButton = btnLogin;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1113, 641);
			Controls.Add(grpCurrentUser);
			Controls.Add(groupBox1);
			Controls.Add(panel2);
			Controls.Add(lblTreePath);
			Controls.Add(label3);
			Controls.Add(grpTree);
			Controls.Add(grpMasterUser);
			Controls.Add(grpUsers);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmManagementConsole";
			Text = "ManagementConsole";
			Activated += this.frmManagementConsole_Activated;
			FormClosing += this.frmManagementConsole_FormClosing;
			Load += this.frmManagementConsole_Load;
			grpUsers.ResumeLayout(false);
			pnlCreateUser.ResumeLayout(false);
			pnlCreateUser.PerformLayout();
			pnlLogin.ResumeLayout(false);
			pnlLogin.PerformLayout();
			grpMasterUser.ResumeLayout(false);
			grpCompany_MU.ResumeLayout(false);
			mnuContextTree.ResumeLayout(false);
			grpGroup_MU.ResumeLayout(false);
			grpDepartment_MU.ResumeLayout(false);
			grpAccount_MU.ResumeLayout(false);
			toolStripContainer1.ResumeLayout(false);
			toolStripContainer1.PerformLayout();
			grpTree.ResumeLayout(false);
			grpCurrentUser.ResumeLayout(false);
			grpCompany_CU.ResumeLayout(false);
			grpGroup_CU.ResumeLayout(false);
			grpDepartment_CU.ResumeLayout(false);
			grpAccount_CU.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private GroupBox grpUsers;
		private GroupBox grpMasterUser;
		private ContextMenuStrip mnuContextTree;
		private ToolStripContainer toolStripContainer1;
		private Panel pnlCreateUser;
		private ComboBox ddlAccessLevels;
		private Label label19;
		private CheckedListBox clbPermissions;
		private Label label6;
		private Panel pnlLogin;
		private TextBox txtUserName;
		private Button btnCancel;
		private Label label1;
		private Button btnLogin;
		private Label label2;
		private TextBox txtPwd;
		private GroupBox grpTree;
		private TreeView treeUser;
		private Button btnCancelNewUser;
		private Button btnCreateUser;
		private ToolStripMenuItem mnuAssignUser;
		private ToolStripMenuItem mnuEdit;
		private ToolStripMenuItem mnuDelete;
		private ToolStripMenuItem mnuCreateNew;
		private Label label3;
		private Label lblTreePath;
		private GroupBox grpCompany_MU;
		private ListBox lstCompanies_MU;
		private GroupBox grpAccount_MU;
		private ListBox lstAccounts_MU;
		private GroupBox grpDepartment_MU;
		private ListBox lstDepartments_MU;
		private GroupBox grpGroup_MU;
		private ListBox lstGroups_MU;
		private Panel panel2;
		private GroupBox groupBox1;
		private GroupBox grpCurrentUser;
		private GroupBox grpCompany_CU;
		private ListBox lstCompanies_CU;
		private GroupBox grpGroup_CU;
		private ListBox lstGroups_CU;
		private GroupBox grpDepartment_CU;
		private ListBox lstDepartments_CU;
		private GroupBox grpAccount_CU;
		private ListBox lstAccounts_CU;
		private ToolStripMenuItem mnuManageNotebooks;
	}
}