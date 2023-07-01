
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
			lblExport = new System.Windows.Forms.Label();
			lblImport = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnDone
			// 
			btnDone.Location = new System.Drawing.Point(145, 463);
			btnDone.Name = "btnDone";
			btnDone.Size = new System.Drawing.Size(103, 23);
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
			lblShowPIN.Location = new System.Drawing.Point(112, 76);
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
			chkSelectAll.Location = new System.Drawing.Point(155, 88);
			chkSelectAll.Name = "chkSelectAll";
			chkSelectAll.Size = new System.Drawing.Size(71, 19);
			chkSelectAll.TabIndex = 52;
			chkSelectAll.Text = "select all";
			chkSelectAll.UseVisualStyleBackColor = true;
			chkSelectAll.CheckedChanged += this.chkSelectAll_CheckedChanged;
			// 
			// lblExport
			// 
			lblExport.AutoSize = true;
			lblExport.Cursor = System.Windows.Forms.Cursors.Hand;
			lblExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			lblExport.ForeColor = System.Drawing.SystemColors.Highlight;
			lblExport.Location = new System.Drawing.Point(14, 473);
			lblExport.Name = "lblExport";
			lblExport.Size = new System.Drawing.Size(41, 15);
			lblExport.TabIndex = 53;
			lblExport.Text = "Export";
			lblExport.Click += this.ManagePinFile;
			lblExport.MouseEnter += this.AnimateExportImportLabels_MouseOver;
			lblExport.MouseLeave += this.AnimateExportImportLabels_MouseOff;
			// 
			// lblImport
			// 
			lblImport.AutoSize = true;
			lblImport.Cursor = System.Windows.Forms.Cursors.Hand;
			lblImport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			lblImport.ForeColor = System.Drawing.SystemColors.Highlight;
			lblImport.Location = new System.Drawing.Point(60, 473);
			lblImport.Name = "lblImport";
			lblImport.Size = new System.Drawing.Size(43, 15);
			lblImport.TabIndex = 54;
			lblImport.Text = "Import";
			lblImport.Click += this.ManagePinFile;
			lblImport.MouseEnter += this.AnimateExportImportLabels_MouseOver;
			lblImport.MouseLeave += this.AnimateExportImportLabels_MouseOff;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Cursor = System.Windows.Forms.Cursors.Hand;
			label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			label1.ForeColor = System.Drawing.SystemColors.Highlight;
			label1.Location = new System.Drawing.Point(52, 473);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(12, 15);
			label1.TabIndex = 55;
			label1.Text = "/";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Cursor = System.Windows.Forms.Cursors.Hand;
			label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			label3.ForeColor = System.Drawing.SystemColors.Highlight;
			label3.Location = new System.Drawing.Point(31, 458);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(59, 15);
			label3.TabIndex = 56;
			label3.Text = "selections";
			// 
			// frmSelectNotebooksToSearch
			// 
			AcceptButton = btnAddPIN;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(260, 497);
			Controls.Add(label3);
			Controls.Add(lblImport);
			Controls.Add(label1);
			Controls.Add(lblExport);
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
			Load += this.frmSelectNotebooksToSearch_Load;
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
		private System.Windows.Forms.Label lblExport;
		private System.Windows.Forms.Label lblImport;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
	}
}