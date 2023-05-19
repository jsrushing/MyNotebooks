namespace myJournal.subforms
{
	partial class frmJournalSettings
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
			chkAllowCloud = new System.Windows.Forms.CheckBox();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			radLocalNotCloud_DisallowLocalCloud = new System.Windows.Forms.RadioButton();
			radLocalNotCloud_UploadToCloud = new System.Windows.Forms.RadioButton();
			radCloudNotLocal_DownloadCloud = new System.Windows.Forms.RadioButton();
			radCloudNotLocal_DeleteCloud = new System.Windows.Forms.RadioButton();
			label2 = new System.Windows.Forms.Label();
			pnlLocalNotCloud = new System.Windows.Forms.Panel();
			radLocalNotCloud_DeleteLocal = new System.Windows.Forms.RadioButton();
			pnlCloudNotLocal = new System.Windows.Forms.Panel();
			btnSaveChanges = new System.Windows.Forms.Button();
			pnlCloudOptions = new System.Windows.Forms.Panel();
			textBox2 = new System.Windows.Forms.TextBox();
			pnlLocalNotCloud.SuspendLayout();
			pnlCloudNotLocal.SuspendLayout();
			pnlCloudOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkAllowCloud
			// 
			chkAllowCloud.AutoSize = true;
			chkAllowCloud.Location = new System.Drawing.Point(12, 12);
			chkAllowCloud.Name = "chkAllowCloud";
			chkAllowCloud.Size = new System.Drawing.Size(91, 19);
			chkAllowCloud.TabIndex = 0;
			chkAllowCloud.Text = "Allow Cloud";
			chkAllowCloud.UseVisualStyleBackColor = true;
			chkAllowCloud.CheckedChanged += this.chkAllowCloud_CheckedChanged;
			// 
			// textBox1
			// 
			textBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
			textBox1.Location = new System.Drawing.Point(7, 37);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(240, 1);
			textBox1.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
			label1.Location = new System.Drawing.Point(3, -2);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(229, 15);
			label1.TabIndex = 2;
			label1.Text = "If journal exists locally but not in the cloud;";
			// 
			// radLocalNotCloud_DisallowLocalCloud
			// 
			radLocalNotCloud_DisallowLocalCloud.AutoSize = true;
			radLocalNotCloud_DisallowLocalCloud.Location = new System.Drawing.Point(3, 3);
			radLocalNotCloud_DisallowLocalCloud.Name = "radLocalNotCloud_DisallowLocalCloud";
			radLocalNotCloud_DisallowLocalCloud.Size = new System.Drawing.Size(182, 19);
			radLocalNotCloud_DisallowLocalCloud.TabIndex = 3;
			radLocalNotCloud_DisallowLocalCloud.TabStop = true;
			radLocalNotCloud_DisallowLocalCloud.Text = "disallow cloud in local journal";
			radLocalNotCloud_DisallowLocalCloud.UseVisualStyleBackColor = true;
			radLocalNotCloud_DisallowLocalCloud.CheckedChanged += this.ValueChanged;
			// 
			// radLocalNotCloud_UploadToCloud
			// 
			radLocalNotCloud_UploadToCloud.AutoSize = true;
			radLocalNotCloud_UploadToCloud.Location = new System.Drawing.Point(3, 46);
			radLocalNotCloud_UploadToCloud.Name = "radLocalNotCloud_UploadToCloud";
			radLocalNotCloud_UploadToCloud.Size = new System.Drawing.Size(197, 19);
			radLocalNotCloud_UploadToCloud.TabIndex = 4;
			radLocalNotCloud_UploadToCloud.TabStop = true;
			radLocalNotCloud_UploadToCloud.Text = "upload local journal to the cloud";
			radLocalNotCloud_UploadToCloud.UseVisualStyleBackColor = true;
			radLocalNotCloud_UploadToCloud.CheckedChanged += this.ValueChanged;
			// 
			// radCloudNotLocal_DownloadCloud
			// 
			radCloudNotLocal_DownloadCloud.AutoSize = true;
			radCloudNotLocal_DownloadCloud.Location = new System.Drawing.Point(3, 24);
			radCloudNotLocal_DownloadCloud.Name = "radCloudNotLocal_DownloadCloud";
			radCloudNotLocal_DownloadCloud.Size = new System.Drawing.Size(171, 19);
			radCloudNotLocal_DownloadCloud.TabIndex = 7;
			radCloudNotLocal_DownloadCloud.TabStop = true;
			radCloudNotLocal_DownloadCloud.Text = "download the cloud journal";
			radCloudNotLocal_DownloadCloud.UseVisualStyleBackColor = true;
			radCloudNotLocal_DownloadCloud.CheckedChanged += this.ValueChanged;
			// 
			// radCloudNotLocal_DeleteCloud
			// 
			radCloudNotLocal_DeleteCloud.AutoSize = true;
			radCloudNotLocal_DeleteCloud.Location = new System.Drawing.Point(3, 3);
			radCloudNotLocal_DeleteCloud.Name = "radCloudNotLocal_DeleteCloud";
			radCloudNotLocal_DeleteCloud.Size = new System.Drawing.Size(150, 19);
			radCloudNotLocal_DeleteCloud.TabIndex = 6;
			radCloudNotLocal_DeleteCloud.TabStop = true;
			radCloudNotLocal_DeleteCloud.Text = "delete the cloud journal";
			radCloudNotLocal_DeleteCloud.UseVisualStyleBackColor = true;
			radCloudNotLocal_DeleteCloud.CheckedChanged += this.ValueChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
			label2.Location = new System.Drawing.Point(3, 97);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(229, 15);
			label2.TabIndex = 5;
			label2.Text = "If journal exists in the cloud but not locally;";
			// 
			// pnlLocalNotCloud
			// 
			pnlLocalNotCloud.Controls.Add(radLocalNotCloud_DeleteLocal);
			pnlLocalNotCloud.Controls.Add(radLocalNotCloud_DisallowLocalCloud);
			pnlLocalNotCloud.Controls.Add(radLocalNotCloud_UploadToCloud);
			pnlLocalNotCloud.Location = new System.Drawing.Point(12, 15);
			pnlLocalNotCloud.Name = "pnlLocalNotCloud";
			pnlLocalNotCloud.Size = new System.Drawing.Size(231, 68);
			pnlLocalNotCloud.TabIndex = 51;
			// 
			// radLocalNotCloud_DeleteLocal
			// 
			radLocalNotCloud_DeleteLocal.AutoSize = true;
			radLocalNotCloud_DeleteLocal.Location = new System.Drawing.Point(3, 25);
			radLocalNotCloud_DeleteLocal.Name = "radLocalNotCloud_DeleteLocal";
			radLocalNotCloud_DeleteLocal.Size = new System.Drawing.Size(125, 19);
			radLocalNotCloud_DeleteLocal.TabIndex = 5;
			radLocalNotCloud_DeleteLocal.TabStop = true;
			radLocalNotCloud_DeleteLocal.Text = "delete local journal";
			radLocalNotCloud_DeleteLocal.UseVisualStyleBackColor = true;
			// 
			// pnlCloudNotLocal
			// 
			pnlCloudNotLocal.Controls.Add(radCloudNotLocal_DeleteCloud);
			pnlCloudNotLocal.Controls.Add(radCloudNotLocal_DownloadCloud);
			pnlCloudNotLocal.Location = new System.Drawing.Point(12, 115);
			pnlCloudNotLocal.Name = "pnlCloudNotLocal";
			pnlCloudNotLocal.Size = new System.Drawing.Size(218, 46);
			pnlCloudNotLocal.TabIndex = 52;
			// 
			// btnSaveChanges
			// 
			btnSaveChanges.Location = new System.Drawing.Point(88, 218);
			btnSaveChanges.Name = "btnSaveChanges";
			btnSaveChanges.Size = new System.Drawing.Size(75, 23);
			btnSaveChanges.TabIndex = 53;
			btnSaveChanges.Text = "&Save Changes";
			btnSaveChanges.UseVisualStyleBackColor = true;
			btnSaveChanges.Click += this.btnSaveChanges_Click;
			// 
			// pnlCloudOptions
			// 
			pnlCloudOptions.Controls.Add(textBox2);
			pnlCloudOptions.Controls.Add(label1);
			pnlCloudOptions.Controls.Add(label2);
			pnlCloudOptions.Controls.Add(pnlCloudNotLocal);
			pnlCloudOptions.Controls.Add(pnlLocalNotCloud);
			pnlCloudOptions.Enabled = false;
			pnlCloudOptions.Location = new System.Drawing.Point(1, 44);
			pnlCloudOptions.Name = "pnlCloudOptions";
			pnlCloudOptions.Size = new System.Drawing.Size(246, 170);
			pnlCloudOptions.TabIndex = 54;
			// 
			// textBox2
			// 
			textBox2.BackColor = System.Drawing.SystemColors.WindowFrame;
			textBox2.Location = new System.Drawing.Point(7, 91);
			textBox2.Multiline = true;
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(240, 1);
			textBox2.TabIndex = 55;
			// 
			// frmJournalSettings
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(249, 248);
			Controls.Add(pnlCloudOptions);
			Controls.Add(btnSaveChanges);
			Controls.Add(textBox1);
			Controls.Add(chkAllowCloud);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmJournalSettings";
			ShowInTaskbar = false;
			Text = "Journal Settings";
			Load += this.frmJournalSettings_Load;
			pnlLocalNotCloud.ResumeLayout(false);
			pnlLocalNotCloud.PerformLayout();
			pnlCloudNotLocal.ResumeLayout(false);
			pnlCloudNotLocal.PerformLayout();
			pnlCloudOptions.ResumeLayout(false);
			pnlCloudOptions.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.CheckBox chkAllowCloud;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radLocalNotCloud_DisallowLocalCloud;
		private System.Windows.Forms.RadioButton radLocalNotCloud_UploadToCloud;
		private System.Windows.Forms.RadioButton radCloudNotLocal_DownloadCloud;
		private System.Windows.Forms.RadioButton radCloudNotLocal_DeleteCloud;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel pnlLocalNotCloud;
		private System.Windows.Forms.Panel pnlCloudNotLocal;
		private System.Windows.Forms.Button btnSaveChanges;
		private System.Windows.Forms.Panel pnlCloudOptions;
		private System.Windows.Forms.RadioButton radLocalNotCloud_DeleteLocal;
		private System.Windows.Forms.TextBox textBox2;
	}
}