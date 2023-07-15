namespace MyNotebooks.subforms
{
	partial class UserLogin
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
			panel2 = new System.Windows.Forms.Panel();
			pnlCreateUser = new System.Windows.Forms.Panel();
			btnCancelNewUser = new System.Windows.Forms.Button();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label19 = new System.Windows.Forms.Label();
			btnCreateNewUser = new System.Windows.Forms.Button();
			clbPermissions = new System.Windows.Forms.CheckedListBox();
			label6 = new System.Windows.Forms.Label();
			pnlLogin.SuspendLayout();
			pnlCreateUser.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(9, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(42, 15);
			label1.TabIndex = 0;
			label1.Text = "Name:";
			// 
			// txtUserName
			// 
			txtUserName.Location = new System.Drawing.Point(57, 3);
			txtUserName.Name = "txtUserName";
			txtUserName.Size = new System.Drawing.Size(187, 23);
			txtUserName.TabIndex = 1;
			// 
			// txtPwd
			// 
			txtPwd.Location = new System.Drawing.Point(58, 32);
			txtPwd.Name = "txtPwd";
			txtPwd.Size = new System.Drawing.Size(187, 23);
			txtPwd.TabIndex = 3;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(15, 35);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(39, 15);
			label2.TabIndex = 2;
			label2.Text = "Email:";
			// 
			// btnOk_Login
			// 
			btnOk_Login.Location = new System.Drawing.Point(23, 66);
			btnOk_Login.Name = "btnOk_Login";
			btnOk_Login.Size = new System.Drawing.Size(75, 23);
			btnOk_Login.TabIndex = 4;
			btnOk_Login.Text = "&Ok";
			btnOk_Login.UseVisualStyleBackColor = true;
			btnOk_Login.Click += this.btnOk_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new System.Drawing.Point(160, 66);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 5;
			btnCancel.Text = "&Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// pnlLogin
			// 
			pnlLogin.Controls.Add(txtUserName);
			pnlLogin.Controls.Add(btnCancel);
			pnlLogin.Controls.Add(label1);
			pnlLogin.Controls.Add(btnOk_Login);
			pnlLogin.Controls.Add(label2);
			pnlLogin.Controls.Add(txtPwd);
			pnlLogin.Location = new System.Drawing.Point(4, 12);
			pnlLogin.Name = "pnlLogin";
			pnlLogin.Size = new System.Drawing.Size(268, 99);
			pnlLogin.TabIndex = 6;
			// 
			// panel2
			// 
			panel2.Location = new System.Drawing.Point(309, 15);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(38, 32);
			panel2.TabIndex = 8;
			// 
			// pnlCreateUser
			// 
			pnlCreateUser.Controls.Add(btnCancelNewUser);
			pnlCreateUser.Controls.Add(comboBox1);
			pnlCreateUser.Controls.Add(label19);
			pnlCreateUser.Controls.Add(btnCreateNewUser);
			pnlCreateUser.Controls.Add(clbPermissions);
			pnlCreateUser.Controls.Add(label6);
			pnlCreateUser.Enabled = false;
			pnlCreateUser.Location = new System.Drawing.Point(4, 117);
			pnlCreateUser.Name = "pnlCreateUser";
			pnlCreateUser.Size = new System.Drawing.Size(268, 316);
			pnlCreateUser.TabIndex = 10;
			pnlCreateUser.Visible = false;
			// 
			// btnCancelNewUser
			// 
			btnCancelNewUser.Location = new System.Drawing.Point(135, 282);
			btnCancelNewUser.Name = "btnCancelNewUser";
			btnCancelNewUser.Size = new System.Drawing.Size(91, 23);
			btnCancelNewUser.TabIndex = 19;
			btnCancelNewUser.Text = "&Cancel";
			btnCancelNewUser.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(95, 6);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(165, 23);
			comboBox1.TabIndex = 18;
			// 
			// label19
			// 
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(20, 9);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(73, 15);
			label19.TabIndex = 17;
			label19.Text = "Access Level";
			// 
			// btnCreateNewUser
			// 
			btnCreateNewUser.Location = new System.Drawing.Point(22, 282);
			btnCreateNewUser.Name = "btnCreateNewUser";
			btnCreateNewUser.Size = new System.Drawing.Size(91, 23);
			btnCreateNewUser.TabIndex = 15;
			btnCreateNewUser.Text = "Create &User";
			btnCreateNewUser.UseVisualStyleBackColor = true;
			// 
			// clbPermissions
			// 
			clbPermissions.FormattingEnabled = true;
			clbPermissions.Location = new System.Drawing.Point(6, 47);
			clbPermissions.Name = "clbPermissions";
			clbPermissions.Size = new System.Drawing.Size(254, 220);
			clbPermissions.TabIndex = 16;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(3, 28);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(70, 15);
			label6.TabIndex = 15;
			label6.Text = "Permissions";
			// 
			// UserLogin
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(276, 439);
			Controls.Add(pnlCreateUser);
			Controls.Add(panel2);
			Controls.Add(pnlLogin);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "UserLogin";
			Text = "User Login";
			Load += this.UserLogin_Load;
			pnlLogin.ResumeLayout(false);
			pnlLogin.PerformLayout();
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
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel pnlCreateUser;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button btnCreateNewUser;
		private System.Windows.Forms.CheckedListBox clbPermissions;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnCancelNewUser;
	}
}