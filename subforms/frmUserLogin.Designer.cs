namespace MyNotebooks.subforms
{
	partial class frmUserLogin
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
			label1 = new System.Windows.Forms.Label();
			txtUserName = new System.Windows.Forms.TextBox();
			txtPwd = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			btnOk_Login = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			pnlLogin = new System.Windows.Forms.Panel();
			pnlSelectGroup = new System.Windows.Forms.Panel();
			label7 = new System.Windows.Forms.Label();
			lblAddCurrentTreeSelection = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			treeOrg = new System.Windows.Forms.TreeView();
			pnlCreateUser = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			btnCancelNewUser = new System.Windows.Forms.Button();
			ddlAccessLevels = new System.Windows.Forms.ComboBox();
			label19 = new System.Windows.Forms.Label();
			btnCreateUser = new System.Windows.Forms.Button();
			clbPermissions = new System.Windows.Forms.CheckedListBox();
			label6 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			pnlLogin.SuspendLayout();
			pnlSelectGroup.SuspendLayout();
			pnlCreateUser.SuspendLayout();
			this.SuspendLayout();
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
			// txtUserName
			// 
			txtUserName.Location = new System.Drawing.Point(76, 10);
			txtUserName.Name = "txtUserName";
			txtUserName.Size = new System.Drawing.Size(184, 23);
			txtUserName.TabIndex = 1;
			// 
			// txtPwd
			// 
			txtPwd.Location = new System.Drawing.Point(77, 39);
			txtPwd.Name = "txtPwd";
			txtPwd.Size = new System.Drawing.Size(184, 23);
			txtPwd.TabIndex = 3;
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
			// btnOk_Login
			// 
			btnOk_Login.Location = new System.Drawing.Point(26, 73);
			btnOk_Login.Name = "btnOk_Login";
			btnOk_Login.Size = new System.Drawing.Size(75, 23);
			btnOk_Login.TabIndex = 4;
			btnOk_Login.Text = "&Ok";
			btnOk_Login.UseVisualStyleBackColor = true;
			btnOk_Login.Click += this.btnOk_Click;
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
			// pnlLogin
			// 
			pnlLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlLogin.Controls.Add(txtUserName);
			pnlLogin.Controls.Add(btnCancel);
			pnlLogin.Controls.Add(label1);
			pnlLogin.Controls.Add(btnOk_Login);
			pnlLogin.Controls.Add(label2);
			pnlLogin.Controls.Add(txtPwd);
			pnlLogin.Location = new System.Drawing.Point(0, 0);
			pnlLogin.Name = "pnlLogin";
			pnlLogin.Size = new System.Drawing.Size(272, 110);
			pnlLogin.TabIndex = 6;
			// 
			// pnlSelectGroup
			// 
			pnlSelectGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlSelectGroup.Controls.Add(label7);
			pnlSelectGroup.Controls.Add(lblAddCurrentTreeSelection);
			pnlSelectGroup.Controls.Add(comboBox1);
			pnlSelectGroup.Controls.Add(label5);
			pnlSelectGroup.Controls.Add(label4);
			pnlSelectGroup.Controls.Add(treeOrg);
			pnlSelectGroup.Location = new System.Drawing.Point(289, 0);
			pnlSelectGroup.Name = "pnlSelectGroup";
			pnlSelectGroup.Size = new System.Drawing.Size(272, 492);
			pnlSelectGroup.TabIndex = 8;
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
			treeOrg.Click += this.treeOrg_Click;
			treeOrg.DoubleClick += this.treeOrg_DoubleClick;
			// 
			// pnlCreateUser
			// 
			pnlCreateUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlCreateUser.Controls.Add(label3);
			pnlCreateUser.Controls.Add(btnCancelNewUser);
			pnlCreateUser.Controls.Add(ddlAccessLevels);
			pnlCreateUser.Controls.Add(label19);
			pnlCreateUser.Controls.Add(btnCreateUser);
			pnlCreateUser.Controls.Add(clbPermissions);
			pnlCreateUser.Controls.Add(label6);
			pnlCreateUser.Location = new System.Drawing.Point(0, 118);
			pnlCreateUser.Name = "pnlCreateUser";
			pnlCreateUser.Size = new System.Drawing.Size(272, 374);
			pnlCreateUser.TabIndex = 10;
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
			btnCancelNewUser.Location = new System.Drawing.Point(144, 338);
			btnCancelNewUser.Name = "btnCancelNewUser";
			btnCancelNewUser.Size = new System.Drawing.Size(91, 23);
			btnCancelNewUser.TabIndex = 19;
			btnCancelNewUser.Text = "&Cancel";
			btnCancelNewUser.UseVisualStyleBackColor = true;
			btnCancelNewUser.Click += this.btnCancelNewUser_Click;
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
			btnCreateUser.Location = new System.Drawing.Point(31, 338);
			btnCreateUser.Name = "btnCreateUser";
			btnCreateUser.Size = new System.Drawing.Size(91, 23);
			btnCreateUser.TabIndex = 15;
			btnCreateUser.Text = "Create &User";
			btnCreateUser.UseVisualStyleBackColor = true;
			btnCreateUser.Click += this.btnCreateUser_Click;
			// 
			// clbPermissions
			// 
			clbPermissions.CheckOnClick = true;
			clbPermissions.FormattingEnabled = true;
			clbPermissions.Location = new System.Drawing.Point(6, 69);
			clbPermissions.Name = "clbPermissions";
			clbPermissions.Size = new System.Drawing.Size(254, 256);
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
			// panel1
			// 
			panel1.Location = new System.Drawing.Point(693, 14);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(38, 32);
			panel1.TabIndex = 11;
			// 
			// frmUserLogin
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(573, 551);
			Controls.Add(panel1);
			Controls.Add(pnlCreateUser);
			Controls.Add(pnlSelectGroup);
			Controls.Add(pnlLogin);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmUserLogin";
			Text = "User Login";
			Load += this.UserLogin_Load;
			pnlLogin.ResumeLayout(false);
			pnlLogin.PerformLayout();
			pnlSelectGroup.ResumeLayout(false);
			pnlSelectGroup.PerformLayout();
			pnlCreateUser.ResumeLayout(false);
			pnlCreateUser.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOk_Login;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlLogin;
		private System.Windows.Forms.Button btnOkAccounts;
		private System.Windows.Forms.Button btnOkGroups;
		private System.Windows.Forms.CheckedListBox checkedListBox3;
		private System.Windows.Forms.Panel pnlSelectGroup;
		private System.Windows.Forms.Panel pnlCreateUser;
		private System.Windows.Forms.ComboBox ddlAccessLevels;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button btnCreateUser;
		private System.Windows.Forms.CheckedListBox clbPermissions;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnCancelNewUser;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TreeView treeOrg;
		private System.Windows.Forms.Label lblAddCurrentTreeSelection;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
	}
}