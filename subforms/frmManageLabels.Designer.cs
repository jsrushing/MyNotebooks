
namespace myJournal.subforms
{
	partial class frmManageLabels
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
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlNewLabelName = new System.Windows.Forms.Panel();
			this.btnOK = new System.Windows.Forms.Button();
			this.lblTagExists = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblOperation = new System.Windows.Forms.Label();
			this.txtLabelName = new System.Windows.Forms.TextBox();
			this.lstLabels = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lstOccurrences = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.mnuMain = new System.Windows.Forms.MenuStrip();
			this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRename = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRename_InAllJournals = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRename_InCurrentJournal = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMoveTop = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDelete_InAllJournals = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDelete_InCurrentJournal = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFindAll = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuAssignPINs = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.pnlJournalPINs = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.btnPINsOK = new System.Windows.Forms.Button();
			this.btnAddPIN = new System.Windows.Forms.Button();
			this.txtPIN = new System.Windows.Forms.TextBox();
			this.lblEnterPIN = new System.Windows.Forms.Label();
			this.lstJournalPINs = new System.Windows.Forms.ListBox();
			this.pnlMain.SuspendLayout();
			this.pnlNewLabelName.SuspendLayout();
			this.mnuMain.SuspendLayout();
			this.pnlJournalPINs.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.pnlMain.Controls.Add(this.pnlNewLabelName);
			this.pnlMain.Controls.Add(this.lstLabels);
			this.pnlMain.Controls.Add(this.label3);
			this.pnlMain.Controls.Add(this.lstOccurrences);
			this.pnlMain.Controls.Add(this.label1);
			this.pnlMain.Location = new System.Drawing.Point(16, 25);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(335, 452);
			this.pnlMain.TabIndex = 0;
			// 
			// pnlNewLabelName
			// 
			this.pnlNewLabelName.Controls.Add(this.btnOK);
			this.pnlNewLabelName.Controls.Add(this.lblTagExists);
			this.pnlNewLabelName.Controls.Add(this.btnCancel);
			this.pnlNewLabelName.Controls.Add(this.lblOperation);
			this.pnlNewLabelName.Controls.Add(this.txtLabelName);
			this.pnlNewLabelName.Location = new System.Drawing.Point(18, 75);
			this.pnlNewLabelName.Name = "pnlNewLabelName";
			this.pnlNewLabelName.Size = new System.Drawing.Size(296, 94);
			this.pnlNewLabelName.TabIndex = 2;
			this.pnlNewLabelName.Visible = false;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(72, 59);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "&Ok";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lblTagExists
			// 
			this.lblTagExists.AutoSize = true;
			this.lblTagExists.ForeColor = System.Drawing.Color.DarkRed;
			this.lblTagExists.Location = new System.Drawing.Point(56, 63);
			this.lblTagExists.Name = "lblTagExists";
			this.lblTagExists.Size = new System.Drawing.Size(111, 15);
			this.lblTagExists.TabIndex = 4;
			this.lblTagExists.Text = "Label already exists.";
			this.lblTagExists.Visible = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(179, 59);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblOperation
			// 
			this.lblOperation.AutoSize = true;
			this.lblOperation.Location = new System.Drawing.Point(56, 6);
			this.lblOperation.Name = "lblOperation";
			this.lblOperation.Size = new System.Drawing.Size(100, 15);
			this.lblOperation.TabIndex = 1;
			this.lblOperation.Text = "New Label Name:";
			this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtLabelName
			// 
			this.txtLabelName.Location = new System.Drawing.Point(67, 24);
			this.txtLabelName.Name = "txtLabelName";
			this.txtLabelName.Size = new System.Drawing.Size(187, 23);
			this.txtLabelName.TabIndex = 0;
			this.txtLabelName.TextChanged += new System.EventHandler(this.txtLabelName_TextChanged);
			// 
			// lstLabels
			// 
			this.lstLabels.FormattingEnabled = true;
			this.lstLabels.IntegralHeight = false;
			this.lstLabels.ItemHeight = 15;
			this.lstLabels.Location = new System.Drawing.Point(9, 23);
			this.lstLabels.Name = "lstLabels";
			this.lstLabels.Size = new System.Drawing.Size(316, 184);
			this.lstLabels.TabIndex = 0;
			this.lstLabels.SelectedIndexChanged += new System.EventHandler(this.lstLabels_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 210);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(193, 15);
			this.label3.TabIndex = 4;
			this.label3.Text = "Found Entries (double-click to Edit)";
			// 
			// lstOccurrences
			// 
			this.lstOccurrences.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lstOccurrences.FormattingEnabled = true;
			this.lstOccurrences.IntegralHeight = false;
			this.lstOccurrences.ItemHeight = 15;
			this.lstOccurrences.Location = new System.Drawing.Point(9, 227);
			this.lstOccurrences.Name = "lstOccurrences";
			this.lstOccurrences.Size = new System.Drawing.Size(316, 208);
			this.lstOccurrences.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Labels (click to see occurrences)";
			// 
			// mnuMain
			// 
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuRename,
            this.mnuMoveTop,
            this.mnuDelete,
            this.mnuFindAll,
            this.mnuAssignPINs,
            this.mnuExit});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Size = new System.Drawing.Size(366, 24);
			this.mnuMain.TabIndex = 1;
			this.mnuMain.Text = "menuStrip1";
			// 
			// mnuAdd
			// 
			this.mnuAdd.Name = "mnuAdd";
			this.mnuAdd.Size = new System.Drawing.Size(41, 20);
			this.mnuAdd.Text = "&Add";
			this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
			// 
			// mnuRename
			// 
			this.mnuRename.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRename_InAllJournals,
            this.mnuRename_InCurrentJournal});
			this.mnuRename.Enabled = false;
			this.mnuRename.Name = "mnuRename";
			this.mnuRename.Size = new System.Drawing.Size(62, 20);
			this.mnuRename.Text = "&Rename";
			// 
			// mnuRename_InAllJournals
			// 
			this.mnuRename_InAllJournals.Name = "mnuRename_InAllJournals";
			this.mnuRename_InAllJournals.Size = new System.Drawing.Size(147, 22);
			this.mnuRename_InAllJournals.Text = "In All Journals";
			this.mnuRename_InAllJournals.Click += new System.EventHandler(this.mnuRename_Click);
			// 
			// mnuRename_InCurrentJournal
			// 
			this.mnuRename_InCurrentJournal.Name = "mnuRename_InCurrentJournal";
			this.mnuRename_InCurrentJournal.Size = new System.Drawing.Size(147, 22);
			this.mnuRename_InCurrentJournal.Text = "In ";
			this.mnuRename_InCurrentJournal.Click += new System.EventHandler(this.mnuRename_Click);
			// 
			// mnuMoveTop
			// 
			this.mnuMoveTop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMoveUp,
            this.mnuMoveDown});
			this.mnuMoveTop.Enabled = false;
			this.mnuMoveTop.Name = "mnuMoveTop";
			this.mnuMoveTop.Size = new System.Drawing.Size(49, 20);
			this.mnuMoveTop.Text = "&Move";
			this.mnuMoveTop.Visible = false;
			// 
			// mnuMoveUp
			// 
			this.mnuMoveUp.Name = "mnuMoveUp";
			this.mnuMoveUp.Size = new System.Drawing.Size(105, 22);
			this.mnuMoveUp.Text = "&Up";
			this.mnuMoveUp.Click += new System.EventHandler(this.mnuMoveUp_Click);
			// 
			// mnuMoveDown
			// 
			this.mnuMoveDown.Name = "mnuMoveDown";
			this.mnuMoveDown.Size = new System.Drawing.Size(105, 22);
			this.mnuMoveDown.Text = "D&own";
			this.mnuMoveDown.Click += new System.EventHandler(this.mnuMoveDown_Click);
			// 
			// mnuDelete
			// 
			this.mnuDelete.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDelete_InAllJournals,
            this.mnuDelete_InCurrentJournal});
			this.mnuDelete.Enabled = false;
			this.mnuDelete.Name = "mnuDelete";
			this.mnuDelete.Size = new System.Drawing.Size(52, 20);
			this.mnuDelete.Text = "&Delete";
			// 
			// mnuDelete_InAllJournals
			// 
			this.mnuDelete_InAllJournals.Name = "mnuDelete_InAllJournals";
			this.mnuDelete_InAllJournals.Size = new System.Drawing.Size(147, 22);
			this.mnuDelete_InAllJournals.Text = "In All Journals";
			this.mnuDelete_InAllJournals.Click += new System.EventHandler(this.mnuDelete_Click);
			// 
			// mnuDelete_InCurrentJournal
			// 
			this.mnuDelete_InCurrentJournal.Name = "mnuDelete_InCurrentJournal";
			this.mnuDelete_InCurrentJournal.Size = new System.Drawing.Size(147, 22);
			this.mnuDelete_InCurrentJournal.Text = "In \'<name>\'";
			this.mnuDelete_InCurrentJournal.Click += new System.EventHandler(this.mnuDelete_Click);
			// 
			// mnuFindAll
			// 
			this.mnuFindAll.Name = "mnuFindAll";
			this.mnuFindAll.Size = new System.Drawing.Size(59, 20);
			this.mnuFindAll.Text = "&Find All";
			this.mnuFindAll.Visible = false;
			this.mnuFindAll.Click += new System.EventHandler(this.mnuFindAll_Click);
			// 
			// mnuAssignPINs
			// 
			this.mnuAssignPINs.Name = "mnuAssignPINs";
			this.mnuAssignPINs.Size = new System.Drawing.Size(43, 20);
			this.mnuAssignPINs.Text = "PINs";
			this.mnuAssignPINs.Click += new System.EventHandler(this.mnuAssignPINs_Click);
			// 
			// mnuExit
			// 
			this.mnuExit.Name = "mnuExit";
			this.mnuExit.Size = new System.Drawing.Size(38, 20);
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// pnlJournalPINs
			// 
			this.pnlJournalPINs.Controls.Add(this.label2);
			this.pnlJournalPINs.Controls.Add(this.btnPINsOK);
			this.pnlJournalPINs.Controls.Add(this.btnAddPIN);
			this.pnlJournalPINs.Controls.Add(this.txtPIN);
			this.pnlJournalPINs.Controls.Add(this.lblEnterPIN);
			this.pnlJournalPINs.Controls.Add(this.lstJournalPINs);
			this.pnlJournalPINs.Location = new System.Drawing.Point(381, 0);
			this.pnlJournalPINs.Name = "pnlJournalPINs";
			this.pnlJournalPINs.Size = new System.Drawing.Size(336, 464);
			this.pnlJournalPINs.TabIndex = 2;
			this.pnlJournalPINs.Visible = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(72, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 15);
			this.label2.TabIndex = 6;
			this.label2.Text = "PIN";
			// 
			// btnPINsOK
			// 
			this.btnPINsOK.Location = new System.Drawing.Point(108, 437);
			this.btnPINsOK.Name = "btnPINsOK";
			this.btnPINsOK.Size = new System.Drawing.Size(120, 23);
			this.btnPINsOK.TabIndex = 5;
			this.btnPINsOK.Text = "Done";
			this.btnPINsOK.UseVisualStyleBackColor = true;
			this.btnPINsOK.Click += new System.EventHandler(this.btnPINsOK_Click);
			// 
			// btnAddPIN
			// 
			this.btnAddPIN.Enabled = false;
			this.btnAddPIN.Location = new System.Drawing.Point(210, 26);
			this.btnAddPIN.Name = "btnAddPIN";
			this.btnAddPIN.Size = new System.Drawing.Size(66, 23);
			this.btnAddPIN.TabIndex = 4;
			this.btnAddPIN.Text = "Add PIN";
			this.btnAddPIN.UseVisualStyleBackColor = true;
			this.btnAddPIN.Click += new System.EventHandler(this.btnAddPIN_Click);
			// 
			// txtPIN
			// 
			this.txtPIN.Enabled = false;
			this.txtPIN.Location = new System.Drawing.Point(103, 26);
			this.txtPIN.Name = "txtPIN";
			this.txtPIN.Size = new System.Drawing.Size(100, 23);
			this.txtPIN.TabIndex = 3;
			this.txtPIN.Text = "(select a Journal)";
			this.txtPIN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPIN_KeyUp);
			// 
			// lblEnterPIN
			// 
			this.lblEnterPIN.Location = new System.Drawing.Point(2, 2);
			this.lblEnterPIN.Name = "lblEnterPIN";
			this.lblEnterPIN.Size = new System.Drawing.Size(331, 16);
			this.lblEnterPIN.TabIndex = 2;
			this.lblEnterPIN.Text = "Specify a PIN for all protected Journals you wish to work with.";
			this.lblEnterPIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lstJournalPINs
			// 
			this.lstJournalPINs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstJournalPINs.FormattingEnabled = true;
			this.lstJournalPINs.ItemHeight = 15;
			this.lstJournalPINs.Location = new System.Drawing.Point(7, 56);
			this.lstJournalPINs.Name = "lstJournalPINs";
			this.lstJournalPINs.Size = new System.Drawing.Size(322, 364);
			this.lstJournalPINs.TabIndex = 1;
			this.lstJournalPINs.SelectedIndexChanged += new System.EventHandler(this.lstJournalPINs_SelectedIndexChanged);
			// 
			// frmManageLabels
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(366, 479);
			this.Controls.Add(this.pnlJournalPINs);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.mnuMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.mnuMain;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(382, 518);
			this.Name = "frmManageLabels";
			this.Text = "Manage Labels";
			this.Load += new System.EventHandler(this.frmManageLabels_Load);
			this.Resize += new System.EventHandler(this.frmManageLabels_Resize);
			this.pnlMain.ResumeLayout(false);
			this.pnlMain.PerformLayout();
			this.pnlNewLabelName.ResumeLayout(false);
			this.pnlNewLabelName.PerformLayout();
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.pnlJournalPINs.ResumeLayout(false);
			this.pnlJournalPINs.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.MenuStrip mnuMain;
		private System.Windows.Forms.ToolStripMenuItem mnuAdd;
		private System.Windows.Forms.ToolStripMenuItem mnuRename;
		private System.Windows.Forms.ToolStripMenuItem mnuMoveTop;
		private System.Windows.Forms.ToolStripMenuItem mnuDelete;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lstLabels;
		private System.Windows.Forms.ToolStripMenuItem mnuMoveUp;
		private System.Windows.Forms.ToolStripMenuItem mnuMoveDown;
		private System.Windows.Forms.ToolStripMenuItem mnuExit;
		private System.Windows.Forms.Panel pnlNewLabelName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label lblOperation;
		private System.Windows.Forms.TextBox txtLabelName;
		private System.Windows.Forms.ToolStripMenuItem mnuRename_InAllJournals;
		private System.Windows.Forms.ToolStripMenuItem mnuRename_InCurrentJournal;
		private System.Windows.Forms.ListBox lstOccurrences;
		private System.Windows.Forms.ToolStripMenuItem mnuFindAll;
		private System.Windows.Forms.Panel pnlJournalPINs;
		private System.Windows.Forms.Button btnAddPIN;
		private System.Windows.Forms.TextBox txtPIN;
		private System.Windows.Forms.Label lblEnterPIN;
		private System.Windows.Forms.ListBox lstJournalPINs;
		private System.Windows.Forms.Button btnPINsOK;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripMenuItem mnuAssignPINs;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblTagExists;
		private System.Windows.Forms.ToolStripMenuItem mnuDelete_InAllJournals;
		private System.Windows.Forms.ToolStripMenuItem mnuDelete_InCurrentJournal;
	}
}