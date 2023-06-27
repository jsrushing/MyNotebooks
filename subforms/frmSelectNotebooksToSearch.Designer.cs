
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
			lblUserPrompt = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			txtPIN = new System.Windows.Forms.TextBox();
			lstNotebookPINs = new System.Windows.Forms.CheckedListBox();
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
			// lblUserPrompt
			// 
			lblUserPrompt.Location = new System.Drawing.Point(6, 4);
			lblUserPrompt.Name = "lblUserPrompt";
			lblUserPrompt.Size = new System.Drawing.Size(248, 45);
			lblUserPrompt.TabIndex = 0;
			lblUserPrompt.Text = "Specify a PIN for any protected notebooks. To remove a PIN, add a blank value.";
			lblUserPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			// lstNotebookPINs
			// 
			lstNotebookPINs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			lstNotebookPINs.CheckOnClick = true;
			lstNotebookPINs.FormattingEnabled = true;
			lstNotebookPINs.Location = new System.Drawing.Point(12, 106);
			lstNotebookPINs.Name = "lstNotebookPINs";
			lstNotebookPINs.Size = new System.Drawing.Size(236, 346);
			lstNotebookPINs.TabIndex = 51;
			lstNotebookPINs.SelectedIndexChanged += this.lstJournalPINs_SelectedIndexChanged;
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
			Controls.Add(lstNotebookPINs);
			Controls.Add(btnDone);
			Controls.Add(txtPIN);
			Controls.Add(label2);
			Controls.Add(btnAddPIN);
			Controls.Add(lblUserPrompt);
			Controls.Add(lblShowPIN);
			Controls.Add(chkSelectAll);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmSelectNotebooksToSearch";
			Text = "Choose Notebooks";
			FormClosing += this.frmSelectNotebooksToSearch_FormClosing;
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion
		private System.Windows.Forms.Label lblUserPrompt;
		private System.Windows.Forms.Label lblShowPIN;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnAddPIN;
		private System.Windows.Forms.Button btnDone;
		private System.Windows.Forms.TextBox txtPIN;
		private System.Windows.Forms.CheckedListBox lstNotebookPINs;
		private System.Windows.Forms.CheckBox chkSelectAll;
	}
}