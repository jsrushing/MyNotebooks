
namespace myNotebooks.subforms
{
	partial class frmSelectNotebooksToSearch
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
			btnDone = new System.Windows.Forms.Button();
			btnAddPIN = new System.Windows.Forms.Button();
			lblShowPIN = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			txtPIN = new System.Windows.Forms.TextBox();
			lstJournalPINs = new System.Windows.Forms.CheckedListBox();
			chkSelectAll = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnDone
			// 
			btnDone.Location = new System.Drawing.Point(65, 463);
			btnDone.Name = "btnDone";
			btnDone.Size = new System.Drawing.Size(133, 23);
			btnDone.TabIndex = 49;
			btnDone.Text = "&Done";
			btnDone.UseVisualStyleBackColor = true;
			btnDone.Click += this.btnDone_Click;
			// 
			// btnAddPIN
			// 
			btnAddPIN.Location = new System.Drawing.Point(175, 54);
			btnAddPIN.Name = "btnAddPIN";
			btnAddPIN.Size = new System.Drawing.Size(59, 23);
			btnAddPIN.TabIndex = 48;
			btnAddPIN.Text = "Add PIN";
			btnAddPIN.UseVisualStyleBackColor = true;
			btnAddPIN.Click += this.btnAddPIN_Click;
			// 
			// lblShowPIN
			// 
			lblShowPIN.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			lblShowPIN.Location = new System.Drawing.Point(59, 76);
			lblShowPIN.Name = "lblShowPIN";
			lblShowPIN.Size = new System.Drawing.Size(35, 13);
			lblShowPIN.TabIndex = 46;
			lblShowPIN.Text = "show";
			lblShowPIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			lblShowPIN.Visible = false;
			lblShowPIN.Click += this.lblShowPIN_Click;
			// 
			// label1
			// 
			label1.Location = new System.Drawing.Point(6, 4);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(248, 45);
			label1.TabIndex = 0;
			label1.Text = "Specify a PIN for any protected notebooks. To remove a PIN, add a blank value.";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(22, 58);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(29, 15);
			label2.TabIndex = 42;
			label2.Text = "PIN:";
			// 
			// txtPIN
			// 
			txtPIN.Enabled = false;
			txtPIN.Location = new System.Drawing.Point(53, 54);
			txtPIN.Name = "txtPIN";
			txtPIN.Size = new System.Drawing.Size(116, 23);
			txtPIN.TabIndex = 50;
			txtPIN.Text = "(select a Notebook)";
			// 
			// lstJournalPINs
			// 
			lstJournalPINs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			lstJournalPINs.CheckOnClick = true;
			lstJournalPINs.FormattingEnabled = true;
			lstJournalPINs.Location = new System.Drawing.Point(12, 106);
			lstJournalPINs.Name = "lstJournalPINs";
			lstJournalPINs.Size = new System.Drawing.Size(236, 346);
			lstJournalPINs.TabIndex = 51;
			lstJournalPINs.SelectedIndexChanged += this.lstJournalPINs_SelectedIndexChanged;
			// 
			// chkSelectAll
			// 
			chkSelectAll.AutoSize = true;
			chkSelectAll.Location = new System.Drawing.Point(165, 88);
			chkSelectAll.Name = "chkSelectAll";
			chkSelectAll.Size = new System.Drawing.Size(71, 19);
			chkSelectAll.TabIndex = 52;
			chkSelectAll.Text = "select all";
			chkSelectAll.UseVisualStyleBackColor = true;
			chkSelectAll.CheckedChanged += this.chkSelectAll_CheckedChanged;
			// 
			// frmSelectNotebooksToSearch
			// 
			AcceptButton = btnAddPIN;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(260, 497);
			Controls.Add(lstJournalPINs);
			Controls.Add(btnDone);
			Controls.Add(txtPIN);
			Controls.Add(label2);
			Controls.Add(btnAddPIN);
			Controls.Add(label1);
			Controls.Add(lblShowPIN);
			Controls.Add(chkSelectAll);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmSelectNotebooksToSearch";
			Text = "Choose Notebooks";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblShowPIN;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnAddPIN;
		private System.Windows.Forms.Button btnDone;
		private System.Windows.Forms.TextBox txtPIN;
		private System.Windows.Forms.CheckedListBox lstJournalPINs;
		private System.Windows.Forms.CheckBox chkSelectAll;
	}
}