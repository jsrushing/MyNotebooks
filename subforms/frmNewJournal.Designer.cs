
namespace myJournal.subforms
{
	partial class frmNewJournal
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
			txtName = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			txtPIN = new System.Windows.Forms.TextBox();
			btnCancel = new System.Windows.Forms.Button();
			btnOk = new System.Windows.Forms.Button();
			grp1 = new System.Windows.Forms.Panel();
			pnlCloudOptions = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			pnlCloudNotLocal = new System.Windows.Forms.Panel();
			radCloudNotLocal_DeleteCloud = new System.Windows.Forms.RadioButton();
			radCloudNotLocal_DownloadCloud = new System.Windows.Forms.RadioButton();
			pnlLocalNotCloud = new System.Windows.Forms.Panel();
			radLocalNotCloud_DeleteLocal = new System.Windows.Forms.RadioButton();
			radLocalNotCloud_UploadToCloud = new System.Windows.Forms.RadioButton();
			chkAllowWebBackup = new System.Windows.Forms.CheckBox();
			lblNameExists = new System.Windows.Forms.Label();
			lblShowPIN = new System.Windows.Forms.Label();
			radLocalNotCloud_DisallowLocalCloud = new System.Windows.Forms.RadioButton();
			grp1.SuspendLayout();
			pnlCloudOptions.SuspendLayout();
			pnlCloudNotLocal.SuspendLayout();
			pnlLocalNotCloud.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtName
			// 
			txtName.Location = new System.Drawing.Point(91, 25);
			txtName.Name = "txtName";
			txtName.Size = new System.Drawing.Size(153, 23);
			txtName.TabIndex = 0;
			txtName.TextChanged += this.txtName_TextChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(2, 28);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(83, 15);
			label1.TabIndex = 1;
			label1.Text = "Journal Name:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(15, 60);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(70, 15);
			label2.TabIndex = 2;
			label2.Text = "Journal PIN:";
			// 
			// txtPIN
			// 
			txtPIN.Location = new System.Drawing.Point(91, 57);
			txtPIN.Name = "txtPIN";
			txtPIN.PasswordChar = '*';
			txtPIN.Size = new System.Drawing.Size(153, 23);
			txtPIN.TabIndex = 1;
			txtPIN.TextChanged += this.txtPIN_TextChanged;
			// 
			// btnCancel
			// 
			btnCancel.Location = new System.Drawing.Point(160, 293);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 5;
			btnCancel.Text = "&Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += this.btnCancel_Click;
			// 
			// btnOk
			// 
			btnOk.Enabled = false;
			btnOk.Location = new System.Drawing.Point(17, 293);
			btnOk.Name = "btnOk";
			btnOk.Size = new System.Drawing.Size(75, 23);
			btnOk.TabIndex = 4;
			btnOk.Text = "&OK";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += this.btnOk_Click;
			// 
			// grp1
			// 
			grp1.Controls.Add(pnlCloudOptions);
			grp1.Controls.Add(chkAllowWebBackup);
			grp1.Controls.Add(lblNameExists);
			grp1.Controls.Add(lblShowPIN);
			grp1.Controls.Add(txtPIN);
			grp1.Controls.Add(btnCancel);
			grp1.Controls.Add(txtName);
			grp1.Controls.Add(btnOk);
			grp1.Controls.Add(label1);
			grp1.Controls.Add(label2);
			grp1.Location = new System.Drawing.Point(12, -1);
			grp1.Name = "grp1";
			grp1.Size = new System.Drawing.Size(257, 321);
			grp1.TabIndex = 6;
			// 
			// pnlCloudOptions
			// 
			pnlCloudOptions.Controls.Add(label3);
			pnlCloudOptions.Controls.Add(label4);
			pnlCloudOptions.Controls.Add(pnlCloudNotLocal);
			pnlCloudOptions.Controls.Add(pnlLocalNotCloud);
			pnlCloudOptions.Enabled = false;
			pnlCloudOptions.Location = new System.Drawing.Point(5, 124);
			pnlCloudOptions.Name = "pnlCloudOptions";
			pnlCloudOptions.Size = new System.Drawing.Size(246, 160);
			pnlCloudOptions.TabIndex = 55;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
			label3.Location = new System.Drawing.Point(3, -2);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(238, 15);
			label3.TabIndex = 2;
			label3.Text = "If journal exists locally but not in the cloud ...";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
			label4.Location = new System.Drawing.Point(3, 90);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(238, 15);
			label4.TabIndex = 5;
			label4.Text = "If journal exists in the cloud but not locally ...";
			// 
			// pnlCloudNotLocal
			// 
			pnlCloudNotLocal.Controls.Add(radCloudNotLocal_DeleteCloud);
			pnlCloudNotLocal.Controls.Add(radCloudNotLocal_DownloadCloud);
			pnlCloudNotLocal.Location = new System.Drawing.Point(12, 107);
			pnlCloudNotLocal.Name = "pnlCloudNotLocal";
			pnlCloudNotLocal.Size = new System.Drawing.Size(218, 46);
			pnlCloudNotLocal.TabIndex = 52;
			// 
			// radCloudNotLocal_DeleteCloud
			// 
			radCloudNotLocal_DeleteCloud.AutoSize = true;
			radCloudNotLocal_DeleteCloud.Location = new System.Drawing.Point(3, -1);
			radCloudNotLocal_DeleteCloud.Name = "radCloudNotLocal_DeleteCloud";
			radCloudNotLocal_DeleteCloud.Size = new System.Drawing.Size(150, 19);
			radCloudNotLocal_DeleteCloud.TabIndex = 6;
			radCloudNotLocal_DeleteCloud.TabStop = true;
			radCloudNotLocal_DeleteCloud.Text = "delete the cloud journal";
			radCloudNotLocal_DeleteCloud.UseVisualStyleBackColor = true;
			// 
			// radCloudNotLocal_DownloadCloud
			// 
			radCloudNotLocal_DownloadCloud.AutoSize = true;
			radCloudNotLocal_DownloadCloud.Location = new System.Drawing.Point(3, 25);
			radCloudNotLocal_DownloadCloud.Name = "radCloudNotLocal_DownloadCloud";
			radCloudNotLocal_DownloadCloud.Size = new System.Drawing.Size(171, 19);
			radCloudNotLocal_DownloadCloud.TabIndex = 7;
			radCloudNotLocal_DownloadCloud.TabStop = true;
			radCloudNotLocal_DownloadCloud.Text = "download the cloud journal";
			radCloudNotLocal_DownloadCloud.UseVisualStyleBackColor = true;
			// 
			// pnlLocalNotCloud
			// 
			pnlLocalNotCloud.Controls.Add(radLocalNotCloud_DisallowLocalCloud);
			pnlLocalNotCloud.Controls.Add(radLocalNotCloud_DeleteLocal);
			pnlLocalNotCloud.Controls.Add(radLocalNotCloud_UploadToCloud);
			pnlLocalNotCloud.Location = new System.Drawing.Point(12, 15);
			pnlLocalNotCloud.Name = "pnlLocalNotCloud";
			pnlLocalNotCloud.Size = new System.Drawing.Size(223, 68);
			pnlLocalNotCloud.TabIndex = 51;
			// 
			// radLocalNotCloud_DeleteLocal
			// 
			radLocalNotCloud_DeleteLocal.AutoSize = true;
			radLocalNotCloud_DeleteLocal.Location = new System.Drawing.Point(3, 23);
			radLocalNotCloud_DeleteLocal.Name = "radLocalNotCloud_DeleteLocal";
			radLocalNotCloud_DeleteLocal.Size = new System.Drawing.Size(145, 19);
			radLocalNotCloud_DeleteLocal.TabIndex = 3;
			radLocalNotCloud_DeleteLocal.TabStop = true;
			radLocalNotCloud_DeleteLocal.Text = "delete the local journal";
			radLocalNotCloud_DeleteLocal.UseVisualStyleBackColor = true;
			// 
			// radLocalNotCloud_UploadToCloud
			// 
			radLocalNotCloud_UploadToCloud.AutoSize = true;
			radLocalNotCloud_UploadToCloud.Location = new System.Drawing.Point(3, 46);
			radLocalNotCloud_UploadToCloud.Name = "radLocalNotCloud_UploadToCloud";
			radLocalNotCloud_UploadToCloud.Size = new System.Drawing.Size(217, 19);
			radLocalNotCloud_UploadToCloud.TabIndex = 4;
			radLocalNotCloud_UploadToCloud.TabStop = true;
			radLocalNotCloud_UploadToCloud.Text = "upload the local journal to the cloud";
			radLocalNotCloud_UploadToCloud.UseVisualStyleBackColor = true;
			// 
			// chkAllowWebBackup
			// 
			chkAllowWebBackup.AutoSize = true;
			chkAllowWebBackup.Location = new System.Drawing.Point(8, 99);
			chkAllowWebBackup.Name = "chkAllowWebBackup";
			chkAllowWebBackup.Size = new System.Drawing.Size(129, 19);
			chkAllowWebBackup.TabIndex = 3;
			chkAllowWebBackup.Text = "allow cloud backup";
			chkAllowWebBackup.UseVisualStyleBackColor = true;
			chkAllowWebBackup.CheckedChanged += this.chkAllowWebBackup_CheckedChanged;
			// 
			// lblNameExists
			// 
			lblNameExists.AutoSize = true;
			lblNameExists.ForeColor = System.Drawing.Color.Red;
			lblNameExists.Location = new System.Drawing.Point(8, 6);
			lblNameExists.Name = "lblNameExists";
			lblNameExists.Size = new System.Drawing.Size(212, 15);
			lblNameExists.TabIndex = 42;
			lblNameExists.Text = "A journal with this name already exists.";
			lblNameExists.Visible = false;
			// 
			// lblShowPIN
			// 
			lblShowPIN.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			lblShowPIN.Location = new System.Drawing.Point(184, 80);
			lblShowPIN.Name = "lblShowPIN";
			lblShowPIN.Size = new System.Drawing.Size(35, 13);
			lblShowPIN.TabIndex = 2;
			lblShowPIN.Text = "show";
			lblShowPIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			lblShowPIN.Visible = false;
			lblShowPIN.Click += this.lblShowPIN_Click;
			// 
			// radLocalNotCloud_DisallowLocalCloud
			// 
			radLocalNotCloud_DisallowLocalCloud.AutoSize = true;
			radLocalNotCloud_DisallowLocalCloud.Location = new System.Drawing.Point(3, 0);
			radLocalNotCloud_DisallowLocalCloud.Name = "radLocalNotCloud_DisallowLocalCloud";
			radLocalNotCloud_DisallowLocalCloud.Size = new System.Drawing.Size(182, 19);
			radLocalNotCloud_DisallowLocalCloud.TabIndex = 5;
			radLocalNotCloud_DisallowLocalCloud.TabStop = true;
			radLocalNotCloud_DisallowLocalCloud.Text = "disallow cloud in local journal";
			radLocalNotCloud_DisallowLocalCloud.UseVisualStyleBackColor = true;
			// 
			// frmNewJournal
			// 
			AcceptButton = btnOk;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new System.Drawing.Size(281, 325);
			Controls.Add(grp1);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(297, 364);
			Name = "frmNewJournal";
			Text = "New Journal";
			Activated += this.frmNewJournal_Activated;
			Load += this.frmNewJournal_Load;
			grp1.ResumeLayout(false);
			grp1.PerformLayout();
			pnlCloudOptions.ResumeLayout(false);
			pnlCloudOptions.PerformLayout();
			pnlCloudNotLocal.ResumeLayout(false);
			pnlCloudNotLocal.PerformLayout();
			pnlLocalNotCloud.ResumeLayout(false);
			pnlLocalNotCloud.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPIN;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Panel grp1;
		private System.Windows.Forms.Label lblShowPIN;
		private System.Windows.Forms.Label lblNameExists;
		private System.Windows.Forms.CheckBox chkAllowWebBackup;
		private System.Windows.Forms.Panel pnlCloudOptions;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel pnlCloudNotLocal;
		private System.Windows.Forms.RadioButton radCloudNotLocal_DeleteCloud;
		private System.Windows.Forms.RadioButton radCloudNotLocal_DownloadCloud;
		private System.Windows.Forms.Panel pnlLocalNotCloud;
		private System.Windows.Forms.RadioButton radLocalNotCloud_DeleteLocal;
		private System.Windows.Forms.RadioButton radLocalNotCloud_UploadToCloud;
		private System.Windows.Forms.RadioButton radLocalNotCloud_DisallowLocalCloud;
	}
}