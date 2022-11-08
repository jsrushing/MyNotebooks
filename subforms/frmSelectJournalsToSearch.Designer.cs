
namespace myJournal.subforms
{
	partial class frmSelectJournalsToSearch
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblShowPIN = new System.Windows.Forms.Label();
			this.lstJournals = new System.Windows.Forms.ListBox();
			this.txtCommonPIN = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblShowPIN);
			this.panel1.Controls.Add(this.lstJournals);
			this.panel1.Controls.Add(this.txtCommonPIN);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnOk);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(218, 246);
			this.panel1.TabIndex = 0;
			// 
			// lblShowPIN
			// 
			this.lblShowPIN.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			this.lblShowPIN.Location = new System.Drawing.Point(175, 169);
			this.lblShowPIN.Name = "lblShowPIN";
			this.lblShowPIN.Size = new System.Drawing.Size(35, 13);
			this.lblShowPIN.TabIndex = 46;
			this.lblShowPIN.Text = "show";
			this.lblShowPIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblShowPIN.Visible = false;
			// 
			// lstJournals
			// 
			this.lstJournals.FormattingEnabled = true;
			this.lstJournals.ItemHeight = 15;
			this.lstJournals.Location = new System.Drawing.Point(6, 25);
			this.lstJournals.Name = "lstJournals";
			this.lstJournals.Size = new System.Drawing.Size(204, 109);
			this.lstJournals.TabIndex = 1;
			// 
			// txtCommonPIN
			// 
			this.txtCommonPIN.Location = new System.Drawing.Point(89, 146);
			this.txtCommonPIN.Name = "txtCommonPIN";
			this.txtCommonPIN.PasswordChar = '*';
			this.txtCommonPIN.Size = new System.Drawing.Size(121, 23);
			this.txtCommonPIN.TabIndex = 43;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(71, 217);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 45;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Journals To Search:";
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(71, 188);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 44;
			this.btnOk.Text = "&OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 150);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 15);
			this.label2.TabIndex = 42;
			this.label2.Text = "common PIN:";
			// 
			// frmSelectJournalsToSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(303, 327);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "frmSelectJournalsToSearch";
			this.Text = "Choose Journals To Search";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListBox lstJournals;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblShowPIN;
		private System.Windows.Forms.TextBox txtCommonPIN;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label2;
	}
}