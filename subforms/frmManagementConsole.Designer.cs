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
			grpCompanies_MU = new GroupBox();
			lstCompanies_MU = new ListBox();
			mnuContextTree = new ContextMenuStrip(components);
			mnuAssignUser = new ToolStripMenuItem();
			mnuCreateNew = new ToolStripMenuItem();
			mnuEdit = new ToolStripMenuItem();
			mnuDelete = new ToolStripMenuItem();
			grpGroups_MU = new GroupBox();
			lstGroups_MU = new ListBox();
			grpDepartments_MU = new GroupBox();
			lstDepartments_MU = new ListBox();
			grpAccounts_MU = new GroupBox();
			lstAccounts_MU = new ListBox();
			toolStripContainer1 = new ToolStripContainer();
			grpTree = new GroupBox();
			treeUser = new TreeView();
			label3 = new Label();
			lblTreePath = new Label();
			panel2 = new Panel();
			groupBox1 = new GroupBox();
			grpCurrentUser = new GroupBox();
			grpCompanies_CU = new GroupBox();
			lstCompanies_CU = new ListBox();
			grpGroups_CU = new GroupBox();
			lstGroups_CU = new ListBox();
			grpDepartments_CU = new GroupBox();
			lstDepartments_CU = new ListBox();
			grpAccounts_CU = new GroupBox();
			lstAccounts_CU = new ListBox();
			grpUsers.SuspendLayout();
			pnlCreateUser.SuspendLayout();
			pnlLogin.SuspendLayout();
			grpMasterUser.SuspendLayout();
			grpCompanies_MU.SuspendLayout();
			mnuContextTree.SuspendLayout();
			grpGroups_MU.SuspendLayout();
			grpDepartments_MU.SuspendLayout();
			grpAccounts_MU.SuspendLayout();
			toolStripContainer1.SuspendLayout();
			grpTree.SuspendLayout();
			grpCurrentUser.SuspendLayout();
			grpCompanies_CU.SuspendLayout();
			grpGroups_CU.SuspendLayout();
			grpDepartments_CU.SuspendLayout();
			grpAccounts_CU.SuspendLayout();
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
			btnCancelNewUser.Location = new System.Drawing.Point(183, 477);
			btnCancelNewUser.Name = "btnCancelNewUser";
			btnCancelNewUser.Size = new System.Drawing.Size(91, 23);
			btnCancelNewUser.TabIndex = 21;
			btnCancelNewUser.Text = "&Cancel";
			btnCancelNewUser.UseVisualStyleBackColor = true;
			btnCancelNewUser.Click += this.btnCancelNewUser_Click;
			// 
			// btnCreateUser
			// 
			btnCreateUser.Location = new System.Drawing.Point(4, 477);
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
			pnlCreateUser.Size = new System.Drawing.Size(270, 336);
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
			clbPermissions.Size = new System.Drawing.Size(260, 274);
			clbPermissions.TabIndex = 16;
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
			pnlLogin.Location = new System.Drawing.Point(4, 16);
			pnlLogin.Name = "pnlLogin";
			pnlLogin.Size = new System.Drawing.Size(266, 110);
			pnlLogin.TabIndex = 11;
			// 
			// txtUserName
			// 
			txtUserName.Location = new System.Drawing.Point(76, 10);
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
			label1.Location = new System.Drawing.Point(31, 13);
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
			grpMasterUser.Controls.Add(grpCompanies_MU);
			grpMasterUser.Controls.Add(grpGroups_MU);
			grpMasterUser.Controls.Add(grpDepartments_MU);
			grpMasterUser.Controls.Add(grpAccounts_MU);
			grpMasterUser.Location = new System.Drawing.Point(294, 3);
			grpMasterUser.Name = "grpMasterUser";
			grpMasterUser.Size = new System.Drawing.Size(242, 516);
			grpMasterUser.TabIndex = 21;
			grpMasterUser.TabStop = false;
			grpMasterUser.Text = "Available Organization Levels";
			// 
			// grpCompanies_MU
			// 
			grpCompanies_MU.Controls.Add(lstCompanies_MU);
			grpCompanies_MU.Location = new System.Drawing.Point(6, 19);
			grpCompanies_MU.Name = "grpCompanies_MU";
			grpCompanies_MU.Size = new System.Drawing.Size(227, 123);
			grpCompanies_MU.TabIndex = 33;
			grpCompanies_MU.TabStop = false;
			grpCompanies_MU.Tag = "6";
			grpCompanies_MU.Text = "Companies";
			// 
			// lstCompanies_MU
			// 
			lstCompanies_MU.ContextMenuStrip = mnuContextTree;
			lstCompanies_MU.FormattingEnabled = true;
			lstCompanies_MU.ItemHeight = 15;
			lstCompanies_MU.Location = new System.Drawing.Point(0, 21);
			lstCompanies_MU.Name = "lstCompanies_MU";
			lstCompanies_MU.Size = new System.Drawing.Size(227, 94);
			lstCompanies_MU.TabIndex = 25;
			lstCompanies_MU.Tag = "6";
			lstCompanies_MU.DragLeave += this.lstMU_DragLeave;
			lstCompanies_MU.MouseDoubleClick += this.lstMU_MouseDoubleClick;
			lstCompanies_MU.MouseDown += this.lstMU_MouseDown;
			lstCompanies_MU.MouseMove += this.lstMU_MouseMove;
			// 
			// mnuContextTree
			// 
			mnuContextTree.Items.AddRange(new ToolStripItem[] { mnuAssignUser, mnuCreateNew, mnuEdit, mnuDelete });
			mnuContextTree.Name = "mnuContextTree";
			mnuContextTree.Size = new System.Drawing.Size(150, 92);
			// 
			// mnuAssignUser
			// 
			mnuAssignUser.Name = "mnuAssignUser";
			mnuAssignUser.Size = new System.Drawing.Size(149, 22);
			mnuAssignUser.Text = "A&ssign to User";
			mnuAssignUser.Click += this.mnuAssignUser_Click;
			// 
			// mnuCreateNew
			// 
			mnuCreateNew.Name = "mnuCreateNew";
			mnuCreateNew.Size = new System.Drawing.Size(149, 22);
			mnuCreateNew.Text = "Create New";
			mnuCreateNew.Click += this.mnuCreateNew_Click;
			// 
			// mnuEdit
			// 
			mnuEdit.Name = "mnuEdit";
			mnuEdit.Size = new System.Drawing.Size(149, 22);
			mnuEdit.Text = "&Edit";
			mnuEdit.Click += this.mnuEdit_Click;
			// 
			// mnuDelete
			// 
			mnuDelete.Name = "mnuDelete";
			mnuDelete.Size = new System.Drawing.Size(149, 22);
			mnuDelete.Text = "&Delete";
			mnuDelete.Click += this.mnuDelete_Click;
			// 
			// grpGroups_MU
			// 
			grpGroups_MU.Controls.Add(lstGroups_MU);
			grpGroups_MU.Location = new System.Drawing.Point(6, 388);
			grpGroups_MU.Name = "grpGroups_MU";
			grpGroups_MU.Size = new System.Drawing.Size(227, 123);
			grpGroups_MU.TabIndex = 34;
			grpGroups_MU.TabStop = false;
			grpGroups_MU.Tag = "3";
			grpGroups_MU.Text = "Groups";
			// 
			// lstGroups_MU
			// 
			lstGroups_MU.ContextMenuStrip = mnuContextTree;
			lstGroups_MU.FormattingEnabled = true;
			lstGroups_MU.ItemHeight = 15;
			lstGroups_MU.Location = new System.Drawing.Point(0, 21);
			lstGroups_MU.Name = "lstGroups_MU";
			lstGroups_MU.Size = new System.Drawing.Size(221, 94);
			lstGroups_MU.TabIndex = 25;
			lstGroups_MU.Tag = "3";
			lstGroups_MU.DragLeave += this.lstMU_DragLeave;
			lstGroups_MU.MouseDoubleClick += this.lstMU_MouseDoubleClick;
			lstGroups_MU.MouseDown += this.lstMU_MouseDown;
			lstGroups_MU.MouseMove += this.lstMU_MouseMove;
			// 
			// grpDepartments_MU
			// 
			grpDepartments_MU.Controls.Add(lstDepartments_MU);
			grpDepartments_MU.Location = new System.Drawing.Point(6, 265);
			grpDepartments_MU.Name = "grpDepartments_MU";
			grpDepartments_MU.Size = new System.Drawing.Size(227, 123);
			grpDepartments_MU.TabIndex = 34;
			grpDepartments_MU.TabStop = false;
			grpDepartments_MU.Tag = "4";
			grpDepartments_MU.Text = "Departments";
			// 
			// lstDepartments_MU
			// 
			lstDepartments_MU.ContextMenuStrip = mnuContextTree;
			lstDepartments_MU.FormattingEnabled = true;
			lstDepartments_MU.ItemHeight = 15;
			lstDepartments_MU.Location = new System.Drawing.Point(0, 21);
			lstDepartments_MU.Name = "lstDepartments_MU";
			lstDepartments_MU.Size = new System.Drawing.Size(227, 94);
			lstDepartments_MU.TabIndex = 25;
			lstDepartments_MU.Tag = "4";
			lstDepartments_MU.DragLeave += this.lstMU_DragLeave;
			lstDepartments_MU.MouseDoubleClick += this.lstMU_MouseDoubleClick;
			lstDepartments_MU.MouseDown += this.lstMU_MouseDown;
			lstDepartments_MU.MouseMove += this.lstMU_MouseMove;
			// 
			// grpAccounts_MU
			// 
			grpAccounts_MU.Controls.Add(lstAccounts_MU);
			grpAccounts_MU.Location = new System.Drawing.Point(6, 142);
			grpAccounts_MU.Name = "grpAccounts_MU";
			grpAccounts_MU.Size = new System.Drawing.Size(227, 123);
			grpAccounts_MU.TabIndex = 34;
			grpAccounts_MU.TabStop = false;
			grpAccounts_MU.Tag = "5";
			grpAccounts_MU.Text = "Accounts";
			// 
			// lstAccounts_MU
			// 
			lstAccounts_MU.ContextMenuStrip = mnuContextTree;
			lstAccounts_MU.FormattingEnabled = true;
			lstAccounts_MU.ItemHeight = 15;
			lstAccounts_MU.Location = new System.Drawing.Point(0, 21);
			lstAccounts_MU.Name = "lstAccounts_MU";
			lstAccounts_MU.Size = new System.Drawing.Size(227, 94);
			lstAccounts_MU.TabIndex = 25;
			lstAccounts_MU.Tag = "5";
			lstAccounts_MU.DragLeave += this.lstMU_DragLeave;
			lstAccounts_MU.MouseDoubleClick += this.lstMU_MouseDoubleClick;
			lstAccounts_MU.MouseDown += this.lstMU_MouseDown;
			lstAccounts_MU.MouseMove += this.lstMU_MouseMove;
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
			grpTree.Location = new System.Drawing.Point(1089, 22);
			grpTree.Name = "grpTree";
			grpTree.Size = new System.Drawing.Size(221, 461);
			grpTree.TabIndex = 28;
			grpTree.TabStop = false;
			grpTree.Text = "Current User";
			// 
			// treeUser
			// 
			treeUser.ContextMenuStrip = mnuContextTree;
			treeUser.Location = new System.Drawing.Point(3, 18);
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
			panel2.Location = new System.Drawing.Point(972, 521);
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
			grpCurrentUser.Controls.Add(grpCompanies_CU);
			grpCurrentUser.Controls.Add(grpGroups_CU);
			grpCurrentUser.Controls.Add(grpDepartments_CU);
			grpCurrentUser.Controls.Add(grpAccounts_CU);
			grpCurrentUser.Location = new System.Drawing.Point(544, 3);
			grpCurrentUser.Name = "grpCurrentUser";
			grpCurrentUser.Size = new System.Drawing.Size(242, 516);
			grpCurrentUser.TabIndex = 36;
			grpCurrentUser.TabStop = false;
			grpCurrentUser.Text = "Current User Organization Levels";
			// 
			// grpCompanies_CU
			// 
			grpCompanies_CU.Controls.Add(lstCompanies_CU);
			grpCompanies_CU.Location = new System.Drawing.Point(6, 19);
			grpCompanies_CU.Name = "grpCompanies_CU";
			grpCompanies_CU.Size = new System.Drawing.Size(227, 123);
			grpCompanies_CU.TabIndex = 33;
			grpCompanies_CU.TabStop = false;
			grpCompanies_CU.Tag = "6";
			grpCompanies_CU.Text = "Companies";
			// 
			// lstCompanies_CU
			// 
			lstCompanies_CU.FormattingEnabled = true;
			lstCompanies_CU.ItemHeight = 15;
			lstCompanies_CU.Location = new System.Drawing.Point(0, 21);
			lstCompanies_CU.Name = "lstCompanies_CU";
			lstCompanies_CU.Size = new System.Drawing.Size(227, 94);
			lstCompanies_CU.TabIndex = 25;
			lstCompanies_CU.Tag = "6";
			lstCompanies_CU.DragEnter += this.lstCU_DragEnter;
			// 
			// grpGroups_CU
			// 
			grpGroups_CU.Controls.Add(lstGroups_CU);
			grpGroups_CU.Location = new System.Drawing.Point(6, 388);
			grpGroups_CU.Name = "grpGroups_CU";
			grpGroups_CU.Size = new System.Drawing.Size(227, 123);
			grpGroups_CU.TabIndex = 34;
			grpGroups_CU.TabStop = false;
			grpGroups_CU.Tag = "3";
			grpGroups_CU.Text = "Groups";
			// 
			// lstGroups_CU
			// 
			lstGroups_CU.FormattingEnabled = true;
			lstGroups_CU.ItemHeight = 15;
			lstGroups_CU.Location = new System.Drawing.Point(0, 21);
			lstGroups_CU.Name = "lstGroups_CU";
			lstGroups_CU.Size = new System.Drawing.Size(221, 94);
			lstGroups_CU.TabIndex = 25;
			lstGroups_CU.Tag = "3";
			lstGroups_CU.DragEnter += this.lstCU_DragEnter;
			// 
			// grpDepartments_CU
			// 
			grpDepartments_CU.Controls.Add(lstDepartments_CU);
			grpDepartments_CU.Location = new System.Drawing.Point(6, 265);
			grpDepartments_CU.Name = "grpDepartments_CU";
			grpDepartments_CU.Size = new System.Drawing.Size(227, 123);
			grpDepartments_CU.TabIndex = 34;
			grpDepartments_CU.TabStop = false;
			grpDepartments_CU.Tag = "4";
			grpDepartments_CU.Text = "Departments";
			// 
			// lstDepartments_CU
			// 
			lstDepartments_CU.FormattingEnabled = true;
			lstDepartments_CU.ItemHeight = 15;
			lstDepartments_CU.Location = new System.Drawing.Point(0, 21);
			lstDepartments_CU.Name = "lstDepartments_CU";
			lstDepartments_CU.Size = new System.Drawing.Size(227, 94);
			lstDepartments_CU.TabIndex = 25;
			lstDepartments_CU.Tag = "4";
			lstDepartments_CU.DragEnter += this.lstCU_DragEnter;
			// 
			// grpAccounts_CU
			// 
			grpAccounts_CU.Controls.Add(lstAccounts_CU);
			grpAccounts_CU.Location = new System.Drawing.Point(6, 142);
			grpAccounts_CU.Name = "grpAccounts_CU";
			grpAccounts_CU.Size = new System.Drawing.Size(227, 123);
			grpAccounts_CU.TabIndex = 34;
			grpAccounts_CU.TabStop = false;
			grpAccounts_CU.Tag = "5";
			grpAccounts_CU.Text = "Accounts";
			// 
			// lstAccounts_CU
			// 
			lstAccounts_CU.FormattingEnabled = true;
			lstAccounts_CU.ItemHeight = 15;
			lstAccounts_CU.Location = new System.Drawing.Point(0, 21);
			lstAccounts_CU.Name = "lstAccounts_CU";
			lstAccounts_CU.Size = new System.Drawing.Size(227, 94);
			lstAccounts_CU.TabIndex = 25;
			lstAccounts_CU.Tag = "5";
			lstAccounts_CU.DragEnter += this.lstCU_DragEnter;
			// 
			// frmManagementConsole
			// 
			AcceptButton = btnLogin;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(795, 525);
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
			grpUsers.ResumeLayout(false);
			pnlCreateUser.ResumeLayout(false);
			pnlCreateUser.PerformLayout();
			pnlLogin.ResumeLayout(false);
			pnlLogin.PerformLayout();
			grpMasterUser.ResumeLayout(false);
			grpCompanies_MU.ResumeLayout(false);
			mnuContextTree.ResumeLayout(false);
			grpGroups_MU.ResumeLayout(false);
			grpDepartments_MU.ResumeLayout(false);
			grpAccounts_MU.ResumeLayout(false);
			toolStripContainer1.ResumeLayout(false);
			toolStripContainer1.PerformLayout();
			grpTree.ResumeLayout(false);
			grpCurrentUser.ResumeLayout(false);
			grpCompanies_CU.ResumeLayout(false);
			grpGroups_CU.ResumeLayout(false);
			grpDepartments_CU.ResumeLayout(false);
			grpAccounts_CU.ResumeLayout(false);
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
		private TreeView treeUser
			;
		private Button btnCancelNewUser;
		private Button btnCreateUser;
		private ToolStripMenuItem mnuAssignUser;
		private ToolStripMenuItem mnuEdit;
		private ToolStripMenuItem mnuDelete;
		private ToolStripMenuItem mnuCreateNew;
		private Label label3;
		private Label lblTreePath;
		private GroupBox grpCompanies_MU;
		private ListBox lstCompanies_MU;
		private GroupBox grpAccounts_MU;
		private ListBox lstAccounts_MU;
		private GroupBox grpDepartments_MU;
		private ListBox lstDepartments_MU;
		private GroupBox grpGroups_MU;
		private ListBox lstGroups_MU;
		private Panel panel2;
		private GroupBox groupBox1;
		private GroupBox grpCurrentUser;
		private GroupBox grpCompanies_CU;
		private ListBox lstCompanies_CU;
		private GroupBox grpGroups_CU;
		private ListBox lstGroups_CU;
		private GroupBox grpDepartments_CU;
		private ListBox lstDepartments_CU;
		private GroupBox grpAccounts_CU;
		private ListBox lstAccounts_CU;
	}
}