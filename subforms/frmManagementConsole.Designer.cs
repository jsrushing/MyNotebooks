using System.Security.Cryptography.Xml;

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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Name: <name>");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Details", new System.Windows.Forms.TreeNode[] { treeNode1 });
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Permission 1 ...");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("UserPermissions", new System.Windows.Forms.TreeNode[] { treeNode3 });
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Company 1 ...");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Companies", new System.Windows.Forms.TreeNode[] { treeNode5 });
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Account 1 ...");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Accounts", new System.Windows.Forms.TreeNode[] { treeNode7 });
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Department 1 ...");
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Departments", new System.Windows.Forms.TreeNode[] { treeNode9 });
			System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Group 1 ...");
			System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Groups", new System.Windows.Forms.TreeNode[] { treeNode11 });
			grpUsers = new System.Windows.Forms.GroupBox();
			pnlCreateUser = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			ddlAccessLevels = new System.Windows.Forms.ComboBox();
			label19 = new System.Windows.Forms.Label();
			clbPermissions = new System.Windows.Forms.CheckedListBox();
			label6 = new System.Windows.Forms.Label();
			pnlLogin = new System.Windows.Forms.Panel();
			txtUserName = new System.Windows.Forms.TextBox();
			btnCancel = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			btnOk_Login = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			txtPwd = new System.Windows.Forms.TextBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			panel1 = new System.Windows.Forms.Panel();
			toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			groupBox3 = new System.Windows.Forms.GroupBox();
			checkBox1 = new System.Windows.Forms.CheckBox();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			btnAssignCompanies = new System.Windows.Forms.Button();
			clbCompanies = new System.Windows.Forms.CheckedListBox();
			grpGroups = new System.Windows.Forms.GroupBox();
			button9 = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			clbGroups = new System.Windows.Forms.CheckedListBox();
			button11 = new System.Windows.Forms.Button();
			label7 = new System.Windows.Forms.Label();
			lblAddCurrentTreeSelection = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			groupBox5 = new System.Windows.Forms.GroupBox();
			btnCancelNewUser = new System.Windows.Forms.Button();
			btnCreateUser = new System.Windows.Forms.Button();
			treeUser = new System.Windows.Forms.TreeView();
			label4 = new System.Windows.Forms.Label();
			comboBox2 = new System.Windows.Forms.ComboBox();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			comboBox3 = new System.Windows.Forms.ComboBox();
			comboBox4 = new System.Windows.Forms.ComboBox();
			comboBox5 = new System.Windows.Forms.ComboBox();
			comboBox6 = new System.Windows.Forms.ComboBox();
			groupBox6 = new System.Windows.Forms.GroupBox();
			button3 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			checkBox2 = new System.Windows.Forms.CheckBox();
			clbAccounts = new System.Windows.Forms.CheckedListBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			button6 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			checkBox3 = new System.Windows.Forms.CheckBox();
			clbDepartments = new System.Windows.Forms.CheckedListBox();
			grpUsers.SuspendLayout();
			pnlCreateUser.SuspendLayout();
			pnlLogin.SuspendLayout();
			toolStripContainer1.SuspendLayout();
			groupBox3.SuspendLayout();
			grpGroups.SuspendLayout();
			groupBox5.SuspendLayout();
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
			grpUsers.Size = new System.Drawing.Size(286, 549);
			grpUsers.TabIndex = 20;
			grpUsers.TabStop = false;
			grpUsers.Text = "Users";
			// 
			// pnlCreateUser
			// 
			pnlCreateUser.Controls.Add(label3);
			pnlCreateUser.Controls.Add(ddlAccessLevels);
			pnlCreateUser.Controls.Add(label19);
			pnlCreateUser.Controls.Add(clbPermissions);
			pnlCreateUser.Controls.Add(label6);
			pnlCreateUser.Location = new System.Drawing.Point(4, 125);
			pnlCreateUser.Name = "pnlCreateUser";
			pnlCreateUser.Size = new System.Drawing.Size(272, 415);
			pnlCreateUser.TabIndex = 12;
			pnlCreateUser.Visible = false;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			label3.Location = new System.Drawing.Point(3, 4);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(33, 15);
			label3.TabIndex = 20;
			label3.Text = "User";
			// 
			// ddlAccessLevels
			// 
			ddlAccessLevels.FormattingEnabled = true;
			ddlAccessLevels.Items.AddRange(new object[] { "Free 30-day trial" });
			ddlAccessLevels.Location = new System.Drawing.Point(95, 24);
			ddlAccessLevels.Name = "ddlAccessLevels";
			ddlAccessLevels.Size = new System.Drawing.Size(165, 23);
			ddlAccessLevels.TabIndex = 18;
			// 
			// label19
			// 
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(20, 27);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(73, 15);
			label19.TabIndex = 17;
			label19.Text = "Access Level";
			// 
			// clbPermissions
			// 
			clbPermissions.CheckOnClick = true;
			clbPermissions.FormattingEnabled = true;
			clbPermissions.Location = new System.Drawing.Point(6, 75);
			clbPermissions.Name = "clbPermissions";
			clbPermissions.Size = new System.Drawing.Size(254, 328);
			clbPermissions.TabIndex = 16;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(6, 57);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(93, 15);
			label6.TabIndex = 15;
			label6.Text = "UserPermissions";
			// 
			// pnlLogin
			// 
			pnlLogin.Controls.Add(txtUserName);
			pnlLogin.Controls.Add(btnCancel);
			pnlLogin.Controls.Add(label1);
			pnlLogin.Controls.Add(btnOk_Login);
			pnlLogin.Controls.Add(label2);
			pnlLogin.Controls.Add(txtPwd);
			pnlLogin.Location = new System.Drawing.Point(4, 16);
			pnlLogin.Name = "pnlLogin";
			pnlLogin.Size = new System.Drawing.Size(272, 110);
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
			// btnOk_Login
			// 
			btnOk_Login.Location = new System.Drawing.Point(20, 73);
			btnOk_Login.Name = "btnOk_Login";
			btnOk_Login.Size = new System.Drawing.Size(137, 23);
			btnOk_Login.TabIndex = 4;
			btnOk_Login.Text = "&Lookup Or Create User";
			btnOk_Login.UseVisualStyleBackColor = true;
			btnOk_Login.Click += this.btnOk_Click;
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
			groupBox3.Location = new System.Drawing.Point(300, 0);
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
			grpGroups.Location = new System.Drawing.Point(533, 0);
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
			label7.Cursor = System.Windows.Forms.Cursors.Hand;
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
			lblAddCurrentTreeSelection.Cursor = System.Windows.Forms.Cursors.Hand;
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
			// groupBox5
			// 
			groupBox5.Controls.Add(btnCancelNewUser);
			groupBox5.Controls.Add(btnCreateUser);
			groupBox5.Controls.Add(treeUser);
			groupBox5.Location = new System.Drawing.Point(533, 220);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(224, 329);
			groupBox5.TabIndex = 28;
			groupBox5.TabStop = false;
			groupBox5.Text = "Current User";
			// 
			// btnCancelNewUser
			// 
			btnCancelNewUser.Location = new System.Drawing.Point(123, 294);
			btnCancelNewUser.Name = "btnCancelNewUser";
			btnCancelNewUser.Size = new System.Drawing.Size(91, 23);
			btnCancelNewUser.TabIndex = 21;
			btnCancelNewUser.Text = "&Cancel";
			btnCancelNewUser.UseVisualStyleBackColor = true;
			// 
			// btnCreateUser
			// 
			btnCreateUser.Location = new System.Drawing.Point(10, 294);
			btnCreateUser.Name = "btnCreateUser";
			btnCreateUser.Size = new System.Drawing.Size(91, 23);
			btnCreateUser.TabIndex = 20;
			btnCreateUser.Text = "Create &User";
			btnCreateUser.UseVisualStyleBackColor = true;
			// 
			// treeUser
			// 
			treeUser.Location = new System.Drawing.Point(5, 22);
			treeUser.Name = "treeUser";
			treeNode1.Name = "Node1";
			treeNode1.Text = "Name: <name>";
			treeNode2.Name = "Node0";
			treeNode2.Text = "Details";
			treeNode3.Name = "Node3";
			treeNode3.Text = "Permission 1 ...";
			treeNode4.Name = "Node2";
			treeNode4.Text = "UserPermissions";
			treeNode5.Name = "Node5";
			treeNode5.Text = "Company 1 ...";
			treeNode6.Name = "Node4";
			treeNode6.Text = "Companies";
			treeNode7.Name = "Node7";
			treeNode7.Text = "Account 1 ...";
			treeNode8.Name = "Node6";
			treeNode8.Text = "Accounts";
			treeNode9.Name = "Node9";
			treeNode9.Text = "Department 1 ...";
			treeNode10.Name = "Node8";
			treeNode10.Text = "Departments";
			treeNode11.Name = "Node11";
			treeNode11.Text = "Group 1 ...";
			treeNode12.Name = "Node10";
			treeNode12.Text = "Groups";
			treeUser.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode2, treeNode4, treeNode6, treeNode8, treeNode10, treeNode12 });
			treeUser.Size = new System.Drawing.Size(209, 262);
			treeUser.TabIndex = 0;
			treeUser.Text = "tree";
			treeUser.BeforeSelect += this.treeUser_BeforeSelect;
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
			groupBox6.Location = new System.Drawing.Point(300, 185);
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
			groupBox1.Location = new System.Drawing.Point(300, 370);
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
			AcceptButton = btnOk_Login;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(768, 559);
			Controls.Add(comboBox6);
			Controls.Add(groupBox1);
			Controls.Add(comboBox5);
			Controls.Add(groupBox6);
			Controls.Add(comboBox4);
			Controls.Add(groupBox5);
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
			Load += this.frmManagementConsole_Load;
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
			groupBox5.ResumeLayout(false);
			groupBox6.ResumeLayout(false);
			groupBox6.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.GroupBox grpUsers;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox grpGroups;
		private System.Windows.Forms.Panel pnlCreateUser;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox ddlAccessLevels;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.CheckedListBox clbPermissions;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel pnlLogin;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOk_Login;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblAddCurrentTreeSelection;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnAssignCompanies;
		private System.Windows.Forms.CheckedListBox clbCompanies;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckedListBox clbGroups;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox6;
		private System.Windows.Forms.ComboBox comboBox5;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckedListBox clbAccounts;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckedListBox clbDepartments;
		private System.Windows.Forms.TreeView treeUser
			;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button btnCancelNewUser;
		private System.Windows.Forms.Button btnCreateUser;
	}
}