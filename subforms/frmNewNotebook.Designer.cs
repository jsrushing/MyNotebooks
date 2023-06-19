
namespace myNotebooks.subforms
{
	partial class frmNewNotebook
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
			btnSettings = new System.Windows.Forms.Button();
			lblNameExists = new System.Windows.Forms.Label();
			lblShowPIN = new System.Windows.Forms.Label();
			grp1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtName
			// 
			txtName.Location = new System.Drawing.Point(103, 25);
			txtName.Name = "txtName";
			txtName.Size = new System.Drawing.Size(138, 23);
			txtName.TabIndex = 0;
			txtName.TextChanged += this.txtName_TextChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(2, 28);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(98, 15);
			label1.TabIndex = 1;
			label1.Text = "Notebook Name:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(15, 60);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(85, 15);
			label2.TabIndex = 2;
			label2.Text = "Notebook PIN:";
			// 
			// txtPIN
			// 
			txtPIN.Location = new System.Drawing.Point(103, 57);
			txtPIN.Name = "txtPIN";
			txtPIN.PasswordChar = '*';
			txtPIN.Size = new System.Drawing.Size(138, 23);
			txtPIN.TabIndex = 1;
			txtPIN.TextChanged += this.txtPIN_TextChanged;
			// 
			// btnCancel
			// 
			btnCancel.Location = new System.Drawing.Point(164, 142);
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
			btnOk.Location = new System.Drawing.Point(21, 142);
			btnOk.Name = "btnOk";
			btnOk.Size = new System.Drawing.Size(75, 23);
			btnOk.TabIndex = 4;
			btnOk.Text = "&OK";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += this.btnOk_Click;
			// 
			// grp1
			// 
			grp1.Controls.Add(btnSettings);
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
			grp1.Size = new System.Drawing.Size(257, 175);
			grp1.TabIndex = 6;
			// 
			// btnSettings
			// 
			btnSettings.Enabled = false;
			btnSettings.Location = new System.Drawing.Point(124, 100);
			btnSettings.Name = "btnSettings";
			btnSettings.Size = new System.Drawing.Size(120, 23);
			btnSettings.TabIndex = 56;
			btnSettings.Text = "&Set Sync Behaviors";
			btnSettings.UseVisualStyleBackColor = true;
			btnSettings.Click += this.btnSettings_Click;
			// 
			// lblNameExists
			// 
			lblNameExists.AutoSize = true;
			lblNameExists.ForeColor = System.Drawing.Color.Red;
			lblNameExists.Location = new System.Drawing.Point(8, 6);
			lblNameExists.Name = "lblNameExists";
			lblNameExists.Size = new System.Drawing.Size(226, 15);
			lblNameExists.TabIndex = 42;
			lblNameExists.Text = "A notebook with this name already exists.";
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
			// frmNewNotebook
			// 
			AcceptButton = btnOk;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new System.Drawing.Size(284, 186);
			Controls.Add(grp1);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(300, 225);
			Name = "frmNewNotebook";
			Text = "New Notebook";
			Activated += this.frmNewJournal_Activated;
			Load += this.frmNewJournal_Load;
			grp1.ResumeLayout(false);
			grp1.PerformLayout();
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
		private System.Windows.Forms.Button btnSettings;
	}
}