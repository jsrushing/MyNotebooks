using System.Security.Cryptography.Xml;
using System.Windows.Forms;

namespace MyNotebooks.subforms
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
			groupBox2 = new GroupBox();
			panel1 = new Panel();
			toolStripContainer1 = new ToolStripContainer();
			groupBox3 = new GroupBox();
			checkBox1 = new CheckBox();
			button2 = new Button();
			button1 = new Button();
			btnAssignCompanies = new Button();
			clbCompanies = new CheckedListBox();
			grpGroups = new GroupBox();
			button9 = new Button();
			button10 = new Button();
			clbGroups = new CheckedListBox();
			button11 = new Button();
			label7 = new Label();
			lblAddCurrentTreeSelection = new Label();
			comboBox1 = new ComboBox();
			label5 = new Label();
			grpTree = new GroupBox();
			btnCancelNewUser = new Button();
			btnCreateUser = new Button();
			treeUser = new TreeView();
			mnuContextTree = new ContextMenuStrip(components);
			mnuAssignUser = new ToolStripMenuItem();
			mnuAdd = new ToolStripMenuItem();
			mnuEdit = new ToolStripMenuItem();
			mnuDelete = new ToolStripMenuItem();
			mnuCreateNew = new ToolStripMenuItem();
			label4 = new Label();
			comboBox2 = new ComboBox();
			label8 = new Label();
			label9 = new Label();
			label10 = new Label();
			label11 = new Label();
			comboBox3 = new ComboBox();
			comboBox4 = new ComboBox();
			comboBox5 = new ComboBox();
			comboBox6 = new ComboBox();
			groupBox6 = new GroupBox();
			button3 = new Button();
			button4 = new Button();
			button5 = new Button();
			checkBox2 = new CheckBox();
			clbAccounts = new CheckedListBox();
			groupBox1 = new GroupBox();
			button6 = new Button();
			button7 = new Button();
			button8 = new Button();
			checkBox3 = new CheckBox();
			clbDepartments = new CheckedListBox();
			grpUsers.SuspendLayout();
			pnlCreateUser.SuspendLayout();
			pnlLogin.SuspendLayout();
			toolStripContainer1.SuspendLayout();
			groupBox3.SuspendLayout();
			grpGroups.SuspendLayout();
			grpTree.SuspendLayout();
			mnuContextTree.SuspendLayout();
			groupBox6.SuspendLayout();
			groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpUsers
			// 
			grpUsers.Controls.Add(pnlCreateUser);
			grpUsers.Controls.Add(pnlLogin);
			grpUsers.Location = new System.Drawing.Point(8, 0);
			grpUsers.Name = "grpUsers";
			grpUsers.Size = new System.Drawing.Size(286, 461);
			grpUsers.TabIndex = 20;
			grpUsers.TabStop = false;
			grpUsers.Text = "Users";
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
			btnLogin.Text = "&Lookup Or Create MNUser";
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
			// 
			// groupBox2
			// 
			groupBox2.Location = new System.Drawing.Point(1029, 328);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(200, 100);
			groupBox2.TabIndex = 21;
			groupBox2.TabStop = false;
			groupBox2.Text = "groupBox2";
			// 
			// panel1
			// 
			panel1.Location = new System.Drawing.Point(1029, 177);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(200, 100);
			panel1.TabIndex = 20;
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
			// groupBox3
			// 
			groupBox3.Controls.Add(checkBox1);
			groupBox3.Controls.Add(button2);
			groupBox3.Controls.Add(button1);
			groupBox3.Controls.Add(btnAssignCompanies);
			groupBox3.Controls.Add(clbCompanies);
			groupBox3.Location = new System.Drawing.Point(763, 12);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(227, 179);
			groupBox3.TabIndex = 25;
			groupBox3.TabStop = false;
			groupBox3.Text = "Companies";
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(135, 10);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(71, 19);
			checkBox1.TabIndex = 21;
			checkBox1.Text = "select all";
			checkBox1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.Location = new System.Drawing.Point(150, 149);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(66, 23);
			button2.TabIndex = 20;
			button2.Text = "Manage";
			button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			button1.Location = new System.Drawing.Point(78, 149);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(66, 23);
			button1.TabIndex = 19;
			button1.Text = "Remove";
			button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			button1.UseVisualStyleBackColor = true;
			// 
			// btnAssignCompanies
			// 
			btnAssignCompanies.Location = new System.Drawing.Point(6, 149);
			btnAssignCompanies.Name = "btnAssignCompanies";
			btnAssignCompanies.Size = new System.Drawing.Size(66, 23);
			btnAssignCompanies.TabIndex = 18;
			btnAssignCompanies.Text = "Assign";
			btnAssignCompanies.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			btnAssignCompanies.UseVisualStyleBackColor = true;
			// 
			// clbCompanies
			// 
			clbCompanies.CheckOnClick = true;
			clbCompanies.FormattingEnabled = true;
			clbCompanies.Location = new System.Drawing.Point(6, 31);
			clbCompanies.Name = "clbCompanies";
			clbCompanies.Size = new System.Drawing.Size(210, 112);
			clbCompanies.TabIndex = 17;
			// 
			// grpGroups
			// 
			grpGroups.Controls.Add(button9);
			grpGroups.Controls.Add(button10);
			grpGroups.Controls.Add(clbGroups);
			grpGroups.Controls.Add(button11);
			grpGroups.Location = new System.Drawing.Point(755, 581);
			grpGroups.Name = "grpGroups";
			grpGroups.Size = new System.Drawing.Size(224, 214);
			grpGroups.TabIndex = 22;
			grpGroups.TabStop = false;
			grpGroups.Text = "Groups";
			// 
			// button9
			// 
			button9.Location = new System.Drawing.Point(150, 178);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(66, 23);
			button9.TabIndex = 33;
			button9.Text = "Manage";
			button9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			button9.UseVisualStyleBackColor = true;
			// 
			// button10
			// 
			button10.Location = new System.Drawing.Point(78, 178);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(66, 23);
			button10.TabIndex = 32;
			button10.Text = "Remove";
			button10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			button10.UseVisualStyleBackColor = true;
			// 
			// clbGroups
			// 
			clbGroups.CheckOnClick = true;
			clbGroups.FormattingEnabled = true;
			clbGroups.Location = new System.Drawing.Point(6, 21);
			clbGroups.Name = "clbGroups";
			clbGroups.Size = new System.Drawing.Size(210, 148);
			clbGroups.TabIndex = 21;
			// 
			// button11
			// 
			button11.Location = new System.Drawing.Point(6, 178);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(66, 23);
			button11.TabIndex = 31;
			button11.Text = "Assign";
			button11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			button11.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Cursor = Cursors.Hand;
			label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label7.Location = new System.Drawing.Point(1082, 493);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(94, 15);
			label7.TabIndex = 5;
			label7.Text = "delete bookmark";
			// 
			// lblAddCurrentTreeSelection
			// 
			lblAddCurrentTreeSelection.AutoSize = true;
			lblAddCurrentTreeSelection.Cursor = Cursors.Hand;
			lblAddCurrentTreeSelection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			lblAddCurrentTreeSelection.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblAddCurrentTreeSelection.Location = new System.Drawing.Point(1061, 38);
			lblAddCurrentTreeSelection.Name = "lblAddCurrentTreeSelection";
			lblAddCurrentTreeSelection.Size = new System.Drawing.Size(116, 15);
			lblAddCurrentTreeSelection.TabIndex = 4;
			lblAddCurrentTreeSelection.Text = "add current selection";
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(1141, 58);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(185, 23);
			comboBox1.TabIndex = 3;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(1070, 61);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(69, 15);
			label5.TabIndex = 2;
			label5.Text = "Bookmarks:";
			// 
			// grpTree
			// 
			grpTree.Controls.Add(btnCancelNewUser);
			grpTree.Controls.Add(btnCreateUser);
			grpTree.Controls.Add(treeUser);
			grpTree.Location = new System.Drawing.Point(288, 0);
			grpTree.Name = "grpTree";
			grpTree.Size = new System.Drawing.Size(221, 461);
			grpTree.TabIndex = 28;
			grpTree.TabStop = false;
			grpTree.Text = "Current User";
			// 
			// btnCancelNewUser
			// 
			btnCancelNewUser.Location = new System.Drawing.Point(123, 425);
			btnCancelNewUser.Name = "btnCancelNewUser";
			btnCancelNewUser.Size = new System.Drawing.Size(91, 23);
			btnCancelNewUser.TabIndex = 21;
			btnCancelNewUser.Text = "&Cancel";
			btnCancelNewUser.UseVisualStyleBackColor = true;
			btnCancelNewUser.Click += this.btnCancelNewUser_Click;
			// 
			// btnCreateUser
			// 
			btnCreateUser.Location = new System.Drawing.Point(6, 425);
			btnCreateUser.Name = "btnCreateUser";
			btnCreateUser.Size = new System.Drawing.Size(91, 23);
			btnCreateUser.TabIndex = 20;
			btnCreateUser.Text = "Create &User";
			btnCreateUser.UseVisualStyleBackColor = true;
			btnCreateUser.Click += this.btnCreateUser_Click;
			// 
			// treeUser
			// 
			treeUser.ContextMenuStrip = mnuContextTree;
			treeUser.Location = new System.Drawing.Point(3, 22);
			treeUser.Name = "treeUser";
			treeUser.Size = new System.Drawing.Size(209, 389);
			treeUser.TabIndex = 0;
			treeUser.Text = "tree";
			treeUser.BeforeSelect += this.treeUser_BeforeSelect;
			treeUser.NodeMouseClick += this.treeUser_NodeMouseClick;
			treeUser.DoubleClick += this.treeUser_DoubleClick;
			// 
			// mnuContextTree
			// 
			mnuContextTree.Items.AddRange(new ToolStripItem[] { mnuAssignUser, mnuAdd, mnuEdit, mnuDelete, mnuCreateNew });
			mnuContextTree.Name = "mnuContextTree";
			mnuContextTree.Size = new System.Drawing.Size(156, 114);
			// 
			// mnuAssignUser
			// 
			mnuAssignUser.Name = "mnuAssignUser";
			mnuAssignUser.Size = new System.Drawing.Size(155, 22);
			mnuAssignUser.Text = "A&ssign MNUser";
			// 
			// mnuAdd
			// 
			mnuAdd.Name = "mnuAdd";
			mnuAdd.Size = new System.Drawing.Size(155, 22);
			mnuAdd.Text = "&Add";
			// 
			// mnuEdit
			// 
			mnuEdit.Name = "mnuEdit";
			mnuEdit.Size = new System.Drawing.Size(155, 22);
			mnuEdit.Text = "&Edit";
			// 
			// mnuDelete
			// 
			mnuDelete.Name = "mnuDelete";
			mnuDelete.Size = new System.Drawing.Size(155, 22);
			mnuDelete.Text = "&Delete";
			// 
			// mnuCreateNew
			// 
			mnuCreateNew.Name = "mnuCreateNew";
			mnuCreateNew.Size = new System.Drawing.Size(155, 22);
			mnuCreateNew.Text = "Create New";
			mnuCreateNew.Click += this.mnuCreateNew_Click;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(1010, 540);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(93, 15);
			label4.TabIndex = 1;
			label4.Text = "UserPermissions";
			// 
			// comboBox2
			// 
			comboBox2.FormattingEnabled = true;
			comboBox2.Items.AddRange(new object[] { "Free 30-day trial" });
			comboBox2.Location = new System.Drawing.Point(1082, 536);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new System.Drawing.Size(188, 23);
			comboBox2.TabIndex = 20;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(1013, 569);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(67, 15);
			label8.TabIndex = 21;
			label8.Text = "Companies";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(1023, 598);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(57, 15);
			label9.TabIndex = 22;
			label9.Text = "Accounts";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(1005, 627);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(75, 15);
			label10.TabIndex = 23;
			label10.Text = "Departments";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(1035, 656);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(45, 15);
			label11.TabIndex = 24;
			label11.Text = "Groups";
			// 
			// comboBox3
			// 
			comboBox3.FormattingEnabled = true;
			comboBox3.Items.AddRange(new object[] { "Free 30-day trial" });
			comboBox3.Location = new System.Drawing.Point(1082, 565);
			comboBox3.Name = "comboBox3";
			comboBox3.Size = new System.Drawing.Size(188, 23);
			comboBox3.TabIndex = 25;
			// 
			// comboBox4
			// 
			comboBox4.FormattingEnabled = true;
			comboBox4.Items.AddRange(new object[] { "Free 30-day trial" });
			comboBox4.Location = new System.Drawing.Point(1082, 594);
			comboBox4.Name = "comboBox4";
			comboBox4.Size = new System.Drawing.Size(188, 23);
			comboBox4.TabIndex = 26;
			// 
			// comboBox5
			// 
			comboBox5.FormattingEnabled = true;
			comboBox5.Items.AddRange(new object[] { "Free 30-day trial" });
			comboBox5.Location = new System.Drawing.Point(1082, 652);
			comboBox5.Name = "comboBox5";
			comboBox5.Size = new System.Drawing.Size(188, 23);
			comboBox5.TabIndex = 27;
			// 
			// comboBox6
			// 
			comboBox6.FormattingEnabled = true;
			comboBox6.Items.AddRange(new object[] { "Free 30-day trial" });
			comboBox6.Location = new System.Drawing.Point(1082, 623);
			comboBox6.Name = "comboBox6";
			comboBox6.Size = new System.Drawing.Size(188, 23);
			comboBox6.TabIndex = 28;
			// 
			// groupBox6
			// 
			groupBox6.Controls.Add(button3);
			groupBox6.Controls.Add(button4);
			groupBox6.Controls.Add(button5);
			groupBox6.Controls.Add(checkBox2);
			groupBox6.Controls.Add(clbAccounts);
			groupBox6.Location = new System.Drawing.Point(763, 197);
			groupBox6.Name = "groupBox6";
			groupBox6.Size = new System.Drawing.Size(227, 179);
			groupBox6.TabIndex = 29;
			groupBox6.TabStop = false;
			groupBox6.Text = "Accounts";
			// 
			// button3
			// 
			button3.Location = new System.Drawing.Point(150, 149);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(66, 23);
			button3.TabIndex = 24;
			button3.Text = "Manage";
			button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			button4.Location = new System.Drawing.Point(78, 149);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(66, 23);
			button4.TabIndex = 23;
			button4.Text = "Remove";
			button4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			button4.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			button5.Location = new System.Drawing.Point(6, 149);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(66, 23);
			button5.TabIndex = 22;
			button5.Text = "Assign";
			button5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			button5.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			checkBox2.AutoSize = true;
			checkBox2.Location = new System.Drawing.Point(135, 10);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new System.Drawing.Size(71, 19);
			checkBox2.TabIndex = 21;
			checkBox2.Text = "select all";
			checkBox2.UseVisualStyleBackColor = true;
			// 
			// clbAccounts
			// 
			clbAccounts.CheckOnClick = true;
			clbAccounts.FormattingEnabled = true;
			clbAccounts.Location = new System.Drawing.Point(6, 31);
			clbAccounts.Name = "clbAccounts";
			clbAccounts.Size = new System.Drawing.Size(210, 112);
			clbAccounts.TabIndex = 17;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(button6);
			groupBox1.Controls.Add(button7);
			groupBox1.Controls.Add(button8);
			groupBox1.Controls.Add(checkBox3);
			groupBox1.Controls.Add(clbDepartments);
			groupBox1.Location = new System.Drawing.Point(763, 382);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(227, 179);
			groupBox1.TabIndex = 30;
			groupBox1.TabStop = false;
			groupBox1.Text = "Departments";
			// 
			// button6
			// 
			button6.Location = new System.Drawing.Point(150, 149);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(66, 23);
			button6.TabIndex = 24;
			button6.Text = "Manage";
			button6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			button6.UseVisualStyleBackColor = true;
			// 
			// button7
			// 
			button7.Location = new System.Drawing.Point(78, 149);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(66, 23);
			button7.TabIndex = 23;
			button7.Text = "Remove";
			button7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			button7.UseVisualStyleBackColor = true;
			// 
			// button8
			// 
			button8.Location = new System.Drawing.Point(6, 149);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(66, 23);
			button8.TabIndex = 22;
			button8.Text = "Assign";
			button8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			button8.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			checkBox3.AutoSize = true;
			checkBox3.Location = new System.Drawing.Point(135, 10);
			checkBox3.Name = "checkBox3";
			checkBox3.Size = new System.Drawing.Size(71, 19);
			checkBox3.TabIndex = 21;
			checkBox3.Text = "select all";
			checkBox3.UseVisualStyleBackColor = true;
			// 
			// clbDepartments
			// 
			clbDepartments.CheckOnClick = true;
			clbDepartments.FormattingEnabled = true;
			clbDepartments.Location = new System.Drawing.Point(6, 31);
			clbDepartments.Name = "clbDepartments";
			clbDepartments.Size = new System.Drawing.Size(210, 112);
			clbDepartments.TabIndex = 17;
			// 
			// frmManagementConsole
			// 
			AcceptButton = btnLogin;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(518, 469);
			Controls.Add(comboBox6);
			Controls.Add(groupBox1);
			Controls.Add(comboBox5);
			Controls.Add(groupBox6);
			Controls.Add(comboBox4);
			Controls.Add(grpTree);
			Controls.Add(comboBox3);
			Controls.Add(label7);
			Controls.Add(label11);
			Controls.Add(lblAddCurrentTreeSelection);
			Controls.Add(label10);
			Controls.Add(comboBox1);
			Controls.Add(label9);
			Controls.Add(label5);
			Controls.Add(label8);
			Controls.Add(grpGroups);
			Controls.Add(comboBox2);
			Controls.Add(label4);
			Controls.Add(groupBox3);
			Controls.Add(groupBox2);
			Controls.Add(grpUsers);
			Controls.Add(panel1);
			Name = "frmManagementConsole";
			Text = "ManagementConsole";
			Activated += this.frmManagementConsole_Activated;
			grpUsers.ResumeLayout(false);
			pnlCreateUser.ResumeLayout(false);
			pnlCreateUser.PerformLayout();
			pnlLogin.ResumeLayout(false);
			pnlLogin.PerformLayout();
			toolStripContainer1.ResumeLayout(false);
			toolStripContainer1.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			grpGroups.ResumeLayout(false);
			grpTree.ResumeLayout(false);
			mnuContextTree.ResumeLayout(false);
			groupBox6.ResumeLayout(false);
			groupBox6.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private GroupBox grpUsers;
		private GroupBox groupBox2;
		private Panel panel1;
		private ContextMenuStrip mnuContextTree;
		private ToolStripContainer toolStripContainer1;
		private GroupBox groupBox3;
		private GroupBox grpGroups;
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
		private Label label7;
		private Label lblAddCurrentTreeSelection;
		private ComboBox comboBox1;
		private Label label5;
		private Button btnAssignCompanies;
		private CheckedListBox clbCompanies;
		private Button button2;
		private Button button1;
		private CheckedListBox clbGroups;
		private GroupBox grpTree;
		private Label label4;
		private ComboBox comboBox6;
		private ComboBox comboBox5;
		private ComboBox comboBox4;
		private ComboBox comboBox3;
		private Label label11;
		private Label label10;
		private Label label9;
		private Label label8;
		private ComboBox comboBox2;
		private CheckBox checkBox1;
		private GroupBox groupBox6;
		private CheckBox checkBox2;
		private CheckedListBox clbAccounts;
		private GroupBox groupBox1;
		private CheckBox checkBox3;
		private CheckedListBox clbDepartments;
		private TreeView treeUser
			;
		private Button button9;
		private Button button10;
		private Button button11;
		private Button button3;
		private Button button4;
		private Button button5;
		private Button button6;
		private Button button7;
		private Button button8;
		private Button btnCancelNewUser;
		private Button btnCreateUser;
		private ToolStripMenuItem mnuAssignUser;
		private ToolStripMenuItem mnuAdd;
		private ToolStripMenuItem mnuEdit;
		private ToolStripMenuItem mnuDelete;
		private ToolStripMenuItem mnuCreateNew;
	}
}