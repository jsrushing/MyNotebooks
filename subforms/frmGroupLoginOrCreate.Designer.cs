namespace myJournal.subforms
{
	partial class frmGroupLoginOrCreate
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
			pnl1 = new System.Windows.Forms.Panel();
			btnCreate = new System.Windows.Forms.Button();
			btnLogin = new System.Windows.Forms.Button();
			pnl2 = new System.Windows.Forms.Panel();
			lblShowPIN = new System.Windows.Forms.Label();
			txtPwd = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			pnl1.SuspendLayout();
			pnl2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnl1
			// 
			pnl1.Controls.Add(btnCreate);
			pnl1.Controls.Add(btnLogin);
			pnl1.Location = new System.Drawing.Point(0, 0);
			pnl1.Name = "pnl1";
			pnl1.Size = new System.Drawing.Size(277, 133);
			pnl1.TabIndex = 11;
			// 
			// btnCreate
			// 
			btnCreate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			btnCreate.Location = new System.Drawing.Point(60, 68);
			btnCreate.Name = "btnCreate";
			btnCreate.Size = new System.Drawing.Size(165, 46);
			btnCreate.TabIndex = 1;
			btnCreate.Tag = "create";
			btnCreate.Text = "&Create a new Group";
			btnCreate.UseVisualStyleBackColor = true;
			btnCreate.Click += this.LoginOrCreate;
			// 
			// btnLogin
			// 
			btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			btnLogin.Location = new System.Drawing.Point(60, 16);
			btnLogin.Name = "btnLogin";
			btnLogin.Size = new System.Drawing.Size(165, 46);
			btnLogin.TabIndex = 0;
			btnLogin.Tag = "login";
			btnLogin.Text = "&Login to a Group";
			btnLogin.UseVisualStyleBackColor = true;
			btnLogin.Click += this.LoginOrCreate;
			// 
			// pnl2
			// 
			pnl2.Controls.Add(lblShowPIN);
			pnl2.Controls.Add(txtPwd);
			pnl2.Controls.Add(label2);
			pnl2.Controls.Add(txtName);
			pnl2.Controls.Add(label1);
			pnl2.Controls.Add(btnCancel);
			pnl2.Controls.Add(btnOK);
			pnl2.Location = new System.Drawing.Point(0, 151);
			pnl2.Name = "pnl2";
			pnl2.Size = new System.Drawing.Size(277, 133);
			pnl2.TabIndex = 12;
			pnl2.Visible = false;
			// 
			// lblShowPIN
			// 
			lblShowPIN.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			lblShowPIN.Location = new System.Drawing.Point(231, 55);
			lblShowPIN.Name = "lblShowPIN";
			lblShowPIN.Size = new System.Drawing.Size(35, 13);
			lblShowPIN.TabIndex = 41;
			lblShowPIN.Text = "show";
			lblShowPIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			lblShowPIN.Click += this.lblShowPIN_Click;
			// 
			// txtPwd
			// 
			txtPwd.Location = new System.Drawing.Point(73, 45);
			txtPwd.Name = "txtPwd";
			txtPwd.PasswordChar = '*';
			txtPwd.Size = new System.Drawing.Size(157, 23);
			txtPwd.TabIndex = 5;
			txtPwd.TextChanged += this.EnableDisableBtnOK;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(10, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(60, 15);
			label2.TabIndex = 4;
			label2.Text = "Password:";
			// 
			// txtName
			// 
			txtName.Location = new System.Drawing.Point(73, 16);
			txtName.Name = "txtName";
			txtName.Size = new System.Drawing.Size(193, 23);
			txtName.TabIndex = 3;
			txtName.Text = "Operations";
			txtName.TextChanged += this.EnableDisableBtnOK;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(28, 19);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(42, 15);
			label1.TabIndex = 2;
			label1.Text = "Name:";
			// 
			// btnCancel
			// 
			btnCancel.Location = new System.Drawing.Point(150, 80);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 1;
			btnCancel.Text = "&Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += this.btnCancel_Click;
			// 
			// btnOK
			// 
			btnOK.Enabled = false;
			btnOK.Location = new System.Drawing.Point(54, 80);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 0;
			btnOK.Text = "&OK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += this.btnOK_Click;
			// 
			// frmGroupLoginOrCreate
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new System.Drawing.Size(280, 304);
			Controls.Add(pnl2);
			Controls.Add(pnl1);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmGroupLoginOrCreate";
			Text = "Groups";
			Load += this.frmGroupLoginOrCreate_Load;
			pnl1.ResumeLayout(false);
			pnl2.ResumeLayout(false);
			pnl2.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Panel pnl1;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Panel pnl2;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label lblShowPIN;
	}
}