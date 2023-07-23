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
			grpUsers = new System.Windows.Forms.GroupBox();
			pnlCreateUser = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			btnCancelNewUser = new System.Windows.Forms.Button();
			ddlAccessLevels = new System.Windows.Forms.ComboBox();
			label19 = new System.Windows.Forms.Label();
			btnCreateUser = new System.Windows.Forms.Button();
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
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			groupBox3 = new System.Windows.Forms.GroupBox();
			groupBox4 = new System.Windows.Forms.GroupBox();
			groupBox5 = new System.Windows.Forms.GroupBox();
			grpGroups = new System.Windows.Forms.GroupBox();
			pnlSelectGroup = new System.Windows.Forms.Panel();
			label7 = new System.Windows.Forms.Label();
			lblAddCurrentTreeSelection = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			treeOrg = new System.Windows.Forms.TreeView();
			grpUsers.SuspendLayout();
			pnlCreateUser.SuspendLayout();
			pnlLogin.SuspendLayout();
			toolStripContainer1.SuspendLayout();
			grpGroups.SuspendLayout();
			pnlSelectGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpUsers
			// 
			grpUsers.Controls.Add(pnlCreateUser);
			grpUsers.Controls.Add(pnlLogin);
			grpUsers.Location = new System.Drawing.Point(12, 27);
			grpUsers.Name = "grpUsers";
			grpUsers.Size = new System.Drawing.Size(286, 543);
			grpUsers.TabIndex = 20;
			grpUsers.TabStop = false;
			grpUsers.Text = "Users";
			// 
			// pnlCreateUser
			// 
			pnlCreateUser.Controls.Add(label3);
			pnlCreateUser.Controls.Add(btnCancelNewUser);
			pnlCreateUser.Controls.Add(ddlAccessLevels);
			pnlCreateUser.Controls.Add(label19);
			pnlCreateUser.Controls.Add(btnCreateUser);
			pnlCreateUser.Controls.Add(clbPermissions);
			pnlCreateUser.Controls.Add(label6);
			pnlCreateUser.Location = new System.Drawing.Point(4, 127);
			pnlCreateUser.Name = "pnlCreateUser";
			pnlCreateUser.Size = new System.Drawing.Size(272, 410);
			pnlCreateUser.TabIndex = 12;
			pnlCreateUser.Visible = false;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			label3.Location = new System.Drawing.Point(3, 4);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(73, 15);
			label3.TabIndex = 20;
			label3.Text = "Create User";
			// 
			// btnCancelNewUser
			// 
			btnCancelNewUser.Location = new System.Drawing.Point(144, 373);
			btnCancelNewUser.Name = "btnCancelNewUser";
			btnCancelNewUser.Size = new System.Drawing.Size(91, 23);
			btnCancelNewUser.TabIndex = 19;
			btnCancelNewUser.Text = "&Cancel";
			btnCancelNewUser.UseVisualStyleBackColor = true;
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
			// btnCreateUser
			// 
			btnCreateUser.Location = new System.Drawing.Point(31, 373);
			btnCreateUser.Name = "btnCreateUser";
			btnCreateUser.Size = new System.Drawing.Size(91, 23);
			btnCreateUser.TabIndex = 15;
			btnCreateUser.Text = "Create &User";
			btnCreateUser.UseVisualStyleBackColor = true;
			// 
			// clbPermissions
			// 
			clbPermissions.CheckOnClick = true;
			clbPermissions.FormattingEnabled = true;
			clbPermissions.Location = new System.Drawing.Point(6, 69);
			clbPermissions.Name = "clbPermissions";
			clbPermissions.Size = new System.Drawing.Size(254, 292);
			clbPermissions.TabIndex = 16;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(3, 50);
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
			btnOk_Login.Location = new System.Drawing.Point(26, 73);
			btnOk_Login.Name = "btnOk_Login";
			btnOk_Login.Size = new System.Drawing.Size(75, 23);
			btnOk_Login.TabIndex = 4;
			btnOk_Login.Text = "&Ok";
			btnOk_Login.UseVisualStyleBackColor = true;
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
			txtPwd.Name = "txtPwd";
			txtPwd.Size = new System.Drawing.Size(184, 23);
			txtPwd.TabIndex = 3;
			// 
			// groupBox2
			// 
			groupBox2.Location = new System.Drawing.Point(771, 470);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(200, 100);
			groupBox2.TabIndex = 21;
			groupBox2.TabStop = false;
			groupBox2.Text = "groupBox2";
			// 
			// panel1
			// 
			panel1.Location = new System.Drawing.Point(869, 431);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(200, 100);
			panel1.TabIndex = 20;
			// 
			// statusStrip1
			// 
			statusStrip1.Location = new System.Drawing.Point(0, 573);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(1107, 22);
			statusStrip1.TabIndex = 23;
			statusStrip1.Text = "statusStrip1";
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
			groupBox3.Location = new System.Drawing.Point(673, 125);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(200, 100);
			groupBox3.TabIndex = 25;
			groupBox3.TabStop = false;
			groupBox3.Text = "Companies";
			// 
			// groupBox4
			// 
			groupBox4.Location = new System.Drawing.Point(879, 56);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(200, 100);
			groupBox4.TabIndex = 22;
			groupBox4.TabStop = false;
			groupBox4.Text = "Accounts";
			// 
			// groupBox5
			// 
			groupBox5.Location = new System.Drawing.Point(660, 276);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(200, 100);
			groupBox5.TabIndex = 22;
			groupBox5.TabStop = false;
			groupBox5.Text = "Departments";
			// 
			// grpGroups
			// 
			grpGroups.Controls.Add(pnlSelectGroup);
			grpGroups.Location = new System.Drawing.Point(321, 27);
			grpGroups.Name = "grpGroups";
			grpGroups.Size = new System.Drawing.Size(282, 519);
			grpGroups.TabIndex = 22;
			grpGroups.TabStop = false;
			grpGroups.Text = "Groups";
			// 
			// pnlSelectGroup
			// 
			pnlSelectGroup.Controls.Add(label7);
			pnlSelectGroup.Controls.Add(lblAddCurrentTreeSelection);
			pnlSelectGroup.Controls.Add(comboBox1);
			pnlSelectGroup.Controls.Add(label5);
			pnlSelectGroup.Controls.Add(label4);
			pnlSelectGroup.Controls.Add(treeOrg);
			pnlSelectGroup.Location = new System.Drawing.Point(3, 22);
			pnlSelectGroup.Name = "pnlSelectGroup";
			pnlSelectGroup.Size = new System.Drawing.Size(272, 492);
			pnlSelectGroup.TabIndex = 9;
			pnlSelectGroup.Visible = false;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Cursor = System.Windows.Forms.Cursors.Hand;
			label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label7.Location = new System.Drawing.Point(169, 470);
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
			lblAddCurrentTreeSelection.Location = new System.Drawing.Point(148, 15);
			lblAddCurrentTreeSelection.Name = "lblAddCurrentTreeSelection";
			lblAddCurrentTreeSelection.Size = new System.Drawing.Size(116, 15);
			lblAddCurrentTreeSelection.TabIndex = 4;
			lblAddCurrentTreeSelection.Text = "add current selection";
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(78, 33);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(185, 23);
			comboBox1.TabIndex = 3;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(7, 36);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(69, 15);
			label5.TabIndex = 2;
			label5.Text = "Bookmarks:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			label4.Location = new System.Drawing.Point(6, 6);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(89, 15);
			label4.TabIndex = 1;
			label4.Text = "Select a Group";
			// 
			// treeOrg
			// 
			treeOrg.Location = new System.Drawing.Point(7, 62);
			treeOrg.Name = "treeOrg";
			treeOrg.Size = new System.Drawing.Size(256, 403);
			treeOrg.TabIndex = 0;
			// 
			// frmManagementConsole
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1107, 595);
			Controls.Add(groupBox5);
			Controls.Add(groupBox4);
			Controls.Add(grpGroups);
			Controls.Add(groupBox3);
			Controls.Add(groupBox2);
			Controls.Add(grpUsers);
			Controls.Add(panel1);
			Controls.Add(statusStrip1);
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
			grpGroups.ResumeLayout(false);
			pnlSelectGroup.ResumeLayout(false);
			pnlSelectGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.GroupBox grpUsers;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox grpGroups;
		private System.Windows.Forms.Panel pnlCreateUser;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnCancelNewUser;
		private System.Windows.Forms.ComboBox ddlAccessLevels;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button btnCreateUser;
		private System.Windows.Forms.CheckedListBox clbPermissions;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel pnlLogin;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOk_Login;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.Panel pnlSelectGroup;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblAddCurrentTreeSelection;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TreeView treeOrg;
	}
}