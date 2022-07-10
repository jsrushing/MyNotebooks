
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
			this.txtName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPIN = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.grp1 = new System.Windows.Forms.Panel();
			this.lblShowPIN = new System.Windows.Forms.Label();
			this.lblMessage_BadJournalName = new System.Windows.Forms.Label();
			this.grp1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(91, 25);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(128, 23);
			this.txtName.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Journal Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Journal PIN:";
			// 
			// txtPIN
			// 
			this.txtPIN.Location = new System.Drawing.Point(91, 57);
			this.txtPIN.Name = "txtPIN";
			this.txtPIN.PasswordChar = '*';
			this.txtPIN.Size = new System.Drawing.Size(128, 23);
			this.txtPIN.TabIndex = 3;
			this.txtPIN.TextChanged += new System.EventHandler(this.txtPIN_TextChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(77, 128);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(77, 99);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "&OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// grp1
			// 
			this.grp1.Controls.Add(this.lblShowPIN);
			this.grp1.Controls.Add(this.lblMessage_BadJournalName);
			this.grp1.Controls.Add(this.txtPIN);
			this.grp1.Controls.Add(this.btnCancel);
			this.grp1.Controls.Add(this.txtName);
			this.grp1.Controls.Add(this.btnOk);
			this.grp1.Controls.Add(this.label1);
			this.grp1.Controls.Add(this.label2);
			this.grp1.Location = new System.Drawing.Point(12, 12);
			this.grp1.Name = "grp1";
			this.grp1.Size = new System.Drawing.Size(230, 184);
			this.grp1.TabIndex = 6;
			// 
			// lblShowPIN
			// 
			this.lblShowPIN.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			this.lblShowPIN.Location = new System.Drawing.Point(184, 80);
			this.lblShowPIN.Name = "lblShowPIN";
			this.lblShowPIN.Size = new System.Drawing.Size(35, 13);
			this.lblShowPIN.TabIndex = 41;
			this.lblShowPIN.Text = "show";
			this.lblShowPIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblShowPIN.Visible = false;
			this.lblShowPIN.Click += new System.EventHandler(this.lblShowPIN_Click);
			// 
			// lblMessage_BadJournalName
			// 
			this.lblMessage_BadJournalName.AutoSize = true;
			this.lblMessage_BadJournalName.ForeColor = System.Drawing.Color.Red;
			this.lblMessage_BadJournalName.Location = new System.Drawing.Point(3, 166);
			this.lblMessage_BadJournalName.Name = "lblMessage_BadJournalName";
			this.lblMessage_BadJournalName.Size = new System.Drawing.Size(0, 15);
			this.lblMessage_BadJournalName.TabIndex = 6;
			// 
			// frmNewJournal
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(255, 208);
			this.Controls.Add(this.grp1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmNewJournal";
			this.Text = "New Journal";
			this.Activated += new System.EventHandler(this.frmNewJournal_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNewJournal_FormClosing);
			this.Load += new System.EventHandler(this.frmNewJournal_Load);
			this.grp1.ResumeLayout(false);
			this.grp1.PerformLayout();
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
		private System.Windows.Forms.Label lblMessage_BadJournalName;
		private System.Windows.Forms.Label lblShowPIN;
	}
}