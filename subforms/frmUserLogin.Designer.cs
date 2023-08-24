namespace myNotebooks.subforms
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
			panel1 = new System.Windows.Forms.Panel();
			pnlLogin.SuspendLayout();
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
			txtUserName.MaxLength = 50;
			txtUserName.Name = "txtUserName";
			txtUserName.Size = new System.Drawing.Size(184, 23);
			txtUserName.TabIndex = 1;
			txtUserName.Text = "big";
			// 
			// txtPwd
			// 
			txtPwd.Location = new System.Drawing.Point(76, 39);
			txtPwd.MaxLength = 50;
			txtPwd.Name = "txtPwd";
			txtPwd.Size = new System.Drawing.Size(184, 23);
			txtPwd.TabIndex = 3;
			txtPwd.Text = "boy";
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
			// panel1
			// 
			panel1.Location = new System.Drawing.Point(326, 14);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(38, 32);
			panel1.TabIndex = 11;
			// 
			// frmUserLogin
			// 
			AcceptButton = btnOk_Login;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(270, 106);
			Controls.Add(panel1);
			Controls.Add(pnlLogin);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmUserLogin";
			Text = "User Login";
			pnlLogin.ResumeLayout(false);
			pnlLogin.PerformLayout();
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
		private System.Windows.Forms.Panel panel1;
	}
}