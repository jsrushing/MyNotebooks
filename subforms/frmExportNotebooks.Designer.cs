namespace myNotebooks.subforms
{
	partial class frmExportNotebooks
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
			this.lstJournalsToSynch = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlAddRecipient = new System.Windows.Forms.Panel();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.btnCancel_Recipient = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnOk_Recipient = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.lstRecipients = new System.Windows.Forms.ListBox();
			this.btnAddRecipient = new System.Windows.Forms.Button();
			this.pnlAddRecipient.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstJournalsToSynch
			// 
			this.lstJournalsToSynch.FormattingEnabled = true;
			this.lstJournalsToSynch.ItemHeight = 15;
			this.lstJournalsToSynch.Location = new System.Drawing.Point(7, 25);
			this.lstJournalsToSynch.Name = "lstJournalsToSynch";
			this.lstJournalsToSynch.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstJournalsToSynch.Size = new System.Drawing.Size(304, 169);
			this.lstJournalsToSynch.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select Journals to synch:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(485, 199);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Recipients";
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(24, 220);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "&Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(213, 220);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// pnlAddRecipient
			// 
			this.pnlAddRecipient.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.pnlAddRecipient.Controls.Add(this.txtEmail);
			this.pnlAddRecipient.Controls.Add(this.btnCancel_Recipient);
			this.pnlAddRecipient.Controls.Add(this.txtName);
			this.pnlAddRecipient.Controls.Add(this.btnOk_Recipient);
			this.pnlAddRecipient.Controls.Add(this.label3);
			this.pnlAddRecipient.Controls.Add(this.label4);
			this.pnlAddRecipient.Controls.Add(this.label5);
			this.pnlAddRecipient.Location = new System.Drawing.Point(354, 52);
			this.pnlAddRecipient.Name = "pnlAddRecipient";
			this.pnlAddRecipient.Size = new System.Drawing.Size(255, 132);
			this.pnlAddRecipient.TabIndex = 7;
			this.pnlAddRecipient.Visible = false;
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(72, 48);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(157, 23);
			this.txtEmail.TabIndex = 3;
			this.txtEmail.Text = "jsrushing@protonmail.com";
			// 
			// btnCancel_Recipient
			// 
			this.btnCancel_Recipient.Location = new System.Drawing.Point(154, 87);
			this.btnCancel_Recipient.Name = "btnCancel_Recipient";
			this.btnCancel_Recipient.Size = new System.Drawing.Size(75, 23);
			this.btnCancel_Recipient.TabIndex = 5;
			this.btnCancel_Recipient.Text = "&Cancel";
			this.btnCancel_Recipient.UseVisualStyleBackColor = true;
			this.btnCancel_Recipient.Click += new System.EventHandler(this.btn_Recipient_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(72, 16);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(157, 23);
			this.txtName.TabIndex = 0;
			this.txtName.Text = "Scott";
			// 
			// btnOk_Recipient
			// 
			this.btnOk_Recipient.Location = new System.Drawing.Point(37, 87);
			this.btnOk_Recipient.Name = "btnOk_Recipient";
			this.btnOk_Recipient.Size = new System.Drawing.Size(75, 23);
			this.btnOk_Recipient.TabIndex = 4;
			this.btnOk_Recipient.Text = "&OK";
			this.btnOk_Recipient.UseVisualStyleBackColor = true;
			this.btnOk_Recipient.Click += new System.EventHandler(this.btn_Recipient_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.label3.Location = new System.Drawing.Point(27, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 15);
			this.label3.TabIndex = 1;
			this.label3.Text = "Name:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.label4.Location = new System.Drawing.Point(30, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 15);
			this.label4.TabIndex = 2;
			this.label4.Text = "Email:";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.label5.Location = new System.Drawing.Point(6, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(240, 117);
			this.label5.TabIndex = 6;
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.lstJournalsToSynch);
			this.pnlMain.Controls.Add(this.label1);
			this.pnlMain.Controls.Add(this.btnCancel);
			this.pnlMain.Controls.Add(this.btnOk);
			this.pnlMain.Location = new System.Drawing.Point(9, 6);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(322, 255);
			this.pnlMain.TabIndex = 8;
			// 
			// lstRecipients
			// 
			this.lstRecipients.FormattingEnabled = true;
			this.lstRecipients.ItemHeight = 15;
			this.lstRecipients.Location = new System.Drawing.Point(488, 217);
			this.lstRecipients.Name = "lstRecipients";
			this.lstRecipients.Size = new System.Drawing.Size(297, 64);
			this.lstRecipients.TabIndex = 7;
			// 
			// btnAddRecipient
			// 
			this.btnAddRecipient.Location = new System.Drawing.Point(550, 193);
			this.btnAddRecipient.Name = "btnAddRecipient";
			this.btnAddRecipient.Size = new System.Drawing.Size(39, 23);
			this.btnAddRecipient.TabIndex = 6;
			this.btnAddRecipient.Text = "Add";
			this.btnAddRecipient.UseVisualStyleBackColor = true;
			this.btnAddRecipient.Click += new System.EventHandler(this.btnAddRecipient_Click);
			// 
			// frmExportJournals
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(658, 268);
			this.Controls.Add(this.lstRecipients);
			this.Controls.Add(this.pnlAddRecipient);
			this.Controls.Add(this.btnAddRecipient);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmExportJournals";
			this.Text = "Synch Journals";
			this.Load += new System.EventHandler(this.frmExportJournals_Load);
			this.pnlAddRecipient.ResumeLayout(false);
			this.pnlAddRecipient.PerformLayout();
			this.pnlMain.ResumeLayout(false);
			this.pnlMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lstJournalsToSynch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlAddRecipient;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.Button btnCancel_Recipient;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnOk_Recipient;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.ListBox lstRecipients;
		private System.Windows.Forms.Button btnAddRecipient;
	}
}