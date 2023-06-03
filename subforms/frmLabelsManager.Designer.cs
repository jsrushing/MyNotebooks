
using System.Windows.Forms;

namespace myJournal.subforms
{
	partial class frmLabelsManager
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
			components = new System.ComponentModel.Container();
			pnlMain = new Panel();
			pnlNewLabelName = new Panel();
			btnOK = new Button();
			lblLabelExists = new Label();
			btnCancel = new Button();
			lblOperation = new Label();
			txtLabelName = new TextBox();
			label5 = new Label();
			lblSortType = new Label();
			lstLabels = new ListBox();
			label3 = new Label();
			lstOccurrences = new ListBox();
			mnuFoundEntries = new ContextMenuStrip(components);
			mnuContextDelete = new ToolStripMenuItem();
			mnuDelete_OneJournal = new ToolStripMenuItem();
			mnuDelete_AllJournals = new ToolStripMenuItem();
			mnuContextRename = new ToolStripMenuItem();
			mnuRename_OneJournal = new ToolStripMenuItem();
			mnuRename_AllJournals = new ToolStripMenuItem();
			label1 = new Label();
			mnuMain = new MenuStrip();
			mnuLabelsOperations = new ToolStripMenuItem();
			mnuAdd = new ToolStripMenuItem();
			mnuRename = new ToolStripMenuItem();
			mnuDelete = new ToolStripMenuItem();
			mnuFindOrphans = new ToolStripMenuItem();
			mnuMoveTop = new ToolStripMenuItem();
			mnuMoveUp = new ToolStripMenuItem();
			mnuMoveDown = new ToolStripMenuItem();
			mnuAssignPINs = new ToolStripMenuItem();
			mnuExit = new ToolStripMenuItem();
			lstEntryObjects = new ListBox();
			pnlOrphanedLabels = new Panel();
			btnExitOrphans = new Button();
			chkSelectAllOrphans = new CheckBox();
			btnRemoveSelectedOrphans = new Button();
			lstOrphanedLabels = new ListBox();
			label4 = new Label();
			pnlMain.SuspendLayout();
			pnlNewLabelName.SuspendLayout();
			mnuFoundEntries.SuspendLayout();
			mnuMain.SuspendLayout();
			pnlOrphanedLabels.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			pnlMain.Controls.Add(pnlNewLabelName);
			pnlMain.Controls.Add(lblSortType);
			pnlMain.Controls.Add(lstLabels);
			pnlMain.Controls.Add(label3);
			pnlMain.Controls.Add(lstOccurrences);
			pnlMain.Controls.Add(label1);
			pnlMain.Location = new System.Drawing.Point(16, 25);
			pnlMain.Name = "pnlMain";
			pnlMain.Size = new System.Drawing.Size(382, 518);
			pnlMain.TabIndex = 0;
			// 
			// pnlNewLabelName
			// 
			pnlNewLabelName.BackColor = System.Drawing.SystemColors.ActiveCaption;
			pnlNewLabelName.Controls.Add(btnOK);
			pnlNewLabelName.Controls.Add(lblLabelExists);
			pnlNewLabelName.Controls.Add(btnCancel);
			pnlNewLabelName.Controls.Add(lblOperation);
			pnlNewLabelName.Controls.Add(txtLabelName);
			pnlNewLabelName.Controls.Add(label5);
			pnlNewLabelName.Location = new System.Drawing.Point(18, 56);
			pnlNewLabelName.Name = "pnlNewLabelName";
			pnlNewLabelName.Size = new System.Drawing.Size(293, 110);
			pnlNewLabelName.TabIndex = 2;
			pnlNewLabelName.Visible = false;
			// 
			// btnOK
			// 
			btnOK.Location = new System.Drawing.Point(56, 71);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 2;
			btnOK.Text = "&Ok";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += this.btnOK_Click;
			// 
			// lblLabelExists
			// 
			lblLabelExists.AutoSize = true;
			lblLabelExists.BackColor = System.Drawing.SystemColors.ButtonFace;
			lblLabelExists.ForeColor = System.Drawing.Color.Red;
			lblLabelExists.Location = new System.Drawing.Point(40, 75);
			lblLabelExists.Name = "lblLabelExists";
			lblLabelExists.Size = new System.Drawing.Size(111, 15);
			lblLabelExists.TabIndex = 4;
			lblLabelExists.Text = "Label already exists.";
			lblLabelExists.Visible = false;
			// 
			// btnCancel
			// 
			btnCancel.Location = new System.Drawing.Point(163, 71);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 3;
			btnCancel.Text = "&Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += this.btnCancel_Click;
			// 
			// lblOperation
			// 
			lblOperation.AutoSize = true;
			lblOperation.BackColor = System.Drawing.SystemColors.ButtonFace;
			lblOperation.Location = new System.Drawing.Point(26, 15);
			lblOperation.Name = "lblOperation";
			lblOperation.Size = new System.Drawing.Size(100, 15);
			lblOperation.TabIndex = 1;
			lblOperation.Text = "New Label Name:";
			lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtLabelName
			// 
			txtLabelName.Location = new System.Drawing.Point(26, 34);
			txtLabelName.Name = "txtLabelName";
			txtLabelName.Size = new System.Drawing.Size(249, 23);
			txtLabelName.TabIndex = 0;
			txtLabelName.TextChanged += this.txtLabelName_TextChanged;
			// 
			// label5
			// 
			label5.BackColor = System.Drawing.SystemColors.ButtonFace;
			label5.Location = new System.Drawing.Point(11, 7);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(272, 93);
			label5.TabIndex = 5;
			// 
			// lblSortType
			// 
			lblSortType.AutoSize = true;
			lblSortType.Cursor = Cursors.Hand;
			lblSortType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			lblSortType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblSortType.Location = new System.Drawing.Point(234, 4);
			lblSortType.Name = "lblSortType";
			lblSortType.Size = new System.Drawing.Size(59, 17);
			lblSortType.TabIndex = 5;
			lblSortType.Text = "Sort A-Z";
			lblSortType.Click += this.lblSortType_Click;
			// 
			// lstLabels
			// 
			lstLabels.ContextMenuStrip = mnuFoundEntries;
			lstLabels.FormattingEnabled = true;
			lstLabels.IntegralHeight = false;
			lstLabels.ItemHeight = 15;
			lstLabels.Location = new System.Drawing.Point(9, 23);
			lstLabels.Name = "lstLabels";
			lstLabels.Size = new System.Drawing.Size(348, 184);
			lstLabels.TabIndex = 0;
			lstLabels.SelectedIndexChanged += this.lstLabels_SelectedIndexChanged;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(9, 210);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(173, 15);
			label3.TabIndex = 4;
			label3.Text = "Found Entries (dbl-click to edit)";
			// 
			// lstOccurrences
			// 
			lstOccurrences.FormattingEnabled = true;
			lstOccurrences.IntegralHeight = false;
			lstOccurrences.ItemHeight = 15;
			lstOccurrences.Location = new System.Drawing.Point(9, 227);
			lstOccurrences.Name = "lstOccurrences";
			lstOccurrences.Size = new System.Drawing.Size(348, 266);
			lstOccurrences.TabIndex = 3;
			lstOccurrences.MouseClick += this.lstOccurrences_MouseClick;
			lstOccurrences.DoubleClick += this.lstOccurrences_DoubleClick;
			// 
			// mnuFoundEntries
			// 
			mnuFoundEntries.Items.AddRange(new ToolStripItem[] { mnuContextDelete, mnuContextRename });
			mnuFoundEntries.Name = "mnuFoundEntries";
			mnuFoundEntries.Size = new System.Drawing.Size(118, 48);
			// 
			// mnuContextDelete
			// 
			mnuContextDelete.DropDownItems.AddRange(new ToolStripItem[] { mnuDelete_OneJournal, mnuDelete_AllJournals });
			mnuContextDelete.Name = "mnuContextDelete";
			mnuContextDelete.Size = new System.Drawing.Size(117, 22);
			mnuContextDelete.Text = "Delete";
			mnuContextDelete.Click += this.mnuDelete_Click;
			// 
			// mnuDelete_OneJournal
			// 
			mnuDelete_OneJournal.Name = "mnuDelete_OneJournal";
			mnuDelete_OneJournal.Size = new System.Drawing.Size(150, 22);
			mnuDelete_OneJournal.Text = "in One Journal";
			// 
			// mnuDelete_AllJournals
			// 
			mnuDelete_AllJournals.Name = "mnuDelete_AllJournals";
			mnuDelete_AllJournals.Size = new System.Drawing.Size(150, 22);
			mnuDelete_AllJournals.Text = "in All Journals";
			// 
			// mnuContextRename
			// 
			mnuContextRename.DropDownItems.AddRange(new ToolStripItem[] { mnuRename_OneJournal, mnuRename_AllJournals });
			mnuContextRename.Name = "mnuContextRename";
			mnuContextRename.Size = new System.Drawing.Size(117, 22);
			mnuContextRename.Text = "Rename";
			mnuContextRename.Click += this.mnuRename_Click;
			// 
			// mnuRename_OneJournal
			// 
			mnuRename_OneJournal.Name = "mnuRename_OneJournal";
			mnuRename_OneJournal.Size = new System.Drawing.Size(150, 22);
			mnuRename_OneJournal.Text = "in One Journal";
			// 
			// mnuRename_AllJournals
			// 
			mnuRename_AllJournals.Name = "mnuRename_AllJournals";
			mnuRename_AllJournals.Size = new System.Drawing.Size(150, 22);
			mnuRename_AllJournals.Text = "in All Journals";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(4, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(176, 15);
			label1.TabIndex = 1;
			label1.Text = "Labels (click to see occurrences)";
			// 
			// mnuMain
			// 
			mnuMain.Items.AddRange(new ToolStripItem[] { mnuLabelsOperations, mnuMoveTop, mnuAssignPINs, mnuExit });
			mnuMain.Location = new System.Drawing.Point(0, 0);
			mnuMain.Name = "mnuMain";
			mnuMain.Size = new System.Drawing.Size(1314, 24);
			mnuMain.TabIndex = 1;
			mnuMain.Text = "menuStrip1";
			// 
			// mnuLabelsOperations
			// 
			mnuLabelsOperations.DropDownItems.AddRange(new ToolStripItem[] { mnuAdd, mnuRename, mnuDelete, mnuFindOrphans });
			mnuLabelsOperations.Name = "mnuLabelsOperations";
			mnuLabelsOperations.Size = new System.Drawing.Size(52, 20);
			mnuLabelsOperations.Text = "Labels";
			mnuLabelsOperations.Click += this.mnuLabelsOperations_Click;
			// 
			// mnuAdd
			// 
			mnuAdd.Name = "mnuAdd";
			mnuAdd.Size = new System.Drawing.Size(145, 22);
			mnuAdd.Text = "&Add";
			mnuAdd.Click += this.mnuAdd_Click;
			// 
			// mnuRename
			// 
			mnuRename.Enabled = false;
			mnuRename.Name = "mnuRename";
			mnuRename.Size = new System.Drawing.Size(145, 22);
			mnuRename.Text = "&Rename";
			mnuRename.Visible = false;
			mnuRename.Click += this.mnuRename_Click;
			// 
			// mnuDelete
			// 
			mnuDelete.Enabled = false;
			mnuDelete.Name = "mnuDelete";
			mnuDelete.Size = new System.Drawing.Size(145, 22);
			mnuDelete.Text = "&Delete";
			mnuDelete.Visible = false;
			mnuDelete.Click += this.mnuDelete_Click;
			// 
			// mnuFindOrphans
			// 
			mnuFindOrphans.Name = "mnuFindOrphans";
			mnuFindOrphans.Size = new System.Drawing.Size(145, 22);
			mnuFindOrphans.Text = "Find &Orphans";
			mnuFindOrphans.Click += this.mnuFindOrphans_Click;
			// 
			// mnuMoveTop
			// 
			mnuMoveTop.DropDownItems.AddRange(new ToolStripItem[] { mnuMoveUp, mnuMoveDown });
			mnuMoveTop.Enabled = false;
			mnuMoveTop.Name = "mnuMoveTop";
			mnuMoveTop.Size = new System.Drawing.Size(49, 20);
			mnuMoveTop.Text = "&Move";
			// 
			// mnuMoveUp
			// 
			mnuMoveUp.Name = "mnuMoveUp";
			mnuMoveUp.Size = new System.Drawing.Size(105, 22);
			mnuMoveUp.Text = "&Up";
			mnuMoveUp.Click += this.mnuMoveUp_Click;
			// 
			// mnuMoveDown
			// 
			mnuMoveDown.Name = "mnuMoveDown";
			mnuMoveDown.Size = new System.Drawing.Size(105, 22);
			mnuMoveDown.Text = "D&own";
			mnuMoveDown.Click += this.mnuMoveDown_Click;
			// 
			// mnuAssignPINs
			// 
			mnuAssignPINs.Name = "mnuAssignPINs";
			mnuAssignPINs.Size = new System.Drawing.Size(96, 20);
			mnuAssignPINs.Text = "&Select Journals";
			mnuAssignPINs.Click += this.mnuAssignPINs_Click;
			// 
			// mnuExit
			// 
			mnuExit.Name = "mnuExit";
			mnuExit.Size = new System.Drawing.Size(38, 20);
			mnuExit.Text = "E&xit";
			mnuExit.Click += this.mnuExit_Click;
			// 
			// lstEntryObjects
			// 
			lstEntryObjects.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			lstEntryObjects.FormattingEnabled = true;
			lstEntryObjects.IntegralHeight = false;
			lstEntryObjects.ItemHeight = 15;
			lstEntryObjects.Location = new System.Drawing.Point(827, 29);
			lstEntryObjects.Name = "lstEntryObjects";
			lstEntryObjects.Size = new System.Drawing.Size(203, 200);
			lstEntryObjects.TabIndex = 4;
			lstEntryObjects.Visible = false;
			// 
			// pnlOrphanedLabels
			// 
			pnlOrphanedLabels.Controls.Add(btnExitOrphans);
			pnlOrphanedLabels.Controls.Add(chkSelectAllOrphans);
			pnlOrphanedLabels.Controls.Add(btnRemoveSelectedOrphans);
			pnlOrphanedLabels.Controls.Add(lstOrphanedLabels);
			pnlOrphanedLabels.Controls.Add(label4);
			pnlOrphanedLabels.Location = new System.Drawing.Point(425, 29);
			pnlOrphanedLabels.Name = "pnlOrphanedLabels";
			pnlOrphanedLabels.Size = new System.Drawing.Size(382, 518);
			pnlOrphanedLabels.TabIndex = 5;
			pnlOrphanedLabels.Visible = false;
			// 
			// btnExitOrphans
			// 
			btnExitOrphans.Location = new System.Drawing.Point(217, 176);
			btnExitOrphans.Name = "btnExitOrphans";
			btnExitOrphans.Size = new System.Drawing.Size(75, 23);
			btnExitOrphans.TabIndex = 5;
			btnExitOrphans.Text = "&Exit";
			btnExitOrphans.UseVisualStyleBackColor = true;
			btnExitOrphans.Click += this.btnExitOrphans_Click;
			// 
			// chkSelectAllOrphans
			// 
			chkSelectAllOrphans.AutoSize = true;
			chkSelectAllOrphans.Location = new System.Drawing.Point(232, 11);
			chkSelectAllOrphans.Name = "chkSelectAllOrphans";
			chkSelectAllOrphans.Size = new System.Drawing.Size(71, 19);
			chkSelectAllOrphans.TabIndex = 4;
			chkSelectAllOrphans.Text = "select all";
			chkSelectAllOrphans.UseVisualStyleBackColor = true;
			chkSelectAllOrphans.CheckedChanged += this.chkSelectAllOrphans_CheckedChanged;
			// 
			// btnRemoveSelectedOrphans
			// 
			btnRemoveSelectedOrphans.Location = new System.Drawing.Point(70, 176);
			btnRemoveSelectedOrphans.Name = "btnRemoveSelectedOrphans";
			btnRemoveSelectedOrphans.Size = new System.Drawing.Size(111, 23);
			btnRemoveSelectedOrphans.TabIndex = 3;
			btnRemoveSelectedOrphans.Text = "&Remove Selected";
			btnRemoveSelectedOrphans.UseVisualStyleBackColor = true;
			btnRemoveSelectedOrphans.Click += this.btnRemoveSelectedOrphans_Click;
			// 
			// lstOrphanedLabels
			// 
			lstOrphanedLabels.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			lstOrphanedLabels.FormattingEnabled = true;
			lstOrphanedLabels.ItemHeight = 15;
			lstOrphanedLabels.Location = new System.Drawing.Point(7, 31);
			lstOrphanedLabels.Name = "lstOrphanedLabels";
			lstOrphanedLabels.SelectionMode = SelectionMode.MultiExtended;
			lstOrphanedLabels.Size = new System.Drawing.Size(353, 139);
			lstOrphanedLabels.TabIndex = 2;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(9, 10);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(210, 15);
			label4.TabIndex = 0;
			label4.Text = "The listed orphaned labels were found:";
			// 
			// frmLabelsManager
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1314, 642);
			Controls.Add(pnlOrphanedLabels);
			Controls.Add(lstEntryObjects);
			Controls.Add(pnlMain);
			Controls.Add(mnuMain);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MainMenuStrip = mnuMain;
			MaximizeBox = false;
			MinimumSize = new System.Drawing.Size(382, 518);
			Name = "frmLabelsManager";
			Text = "Manage Labels";
			Load += this.frmLabelsManager_Load;
			Resize += this.frmLabelsManager_Resize;
			pnlMain.ResumeLayout(false);
			pnlMain.PerformLayout();
			pnlNewLabelName.ResumeLayout(false);
			pnlNewLabelName.PerformLayout();
			mnuFoundEntries.ResumeLayout(false);
			mnuMain.ResumeLayout(false);
			mnuMain.PerformLayout();
			pnlOrphanedLabels.ResumeLayout(false);
			pnlOrphanedLabels.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.MenuStrip mnuMain;
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
		private System.Windows.Forms.ListBox lstOccurrences;
		private System.Windows.Forms.ToolStripMenuItem mnuAssignPINs;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblLabelExists;
		private System.Windows.Forms.Label lblSortType;
		private System.Windows.Forms.ListBox lstEntryObjects;
		private System.Windows.Forms.ToolStripMenuItem mnuLabelsOperations;
		private System.Windows.Forms.ToolStripMenuItem mnuMoveTop;
		private System.Windows.Forms.ToolStripMenuItem mnuFindOrphans;
		private System.Windows.Forms.Panel pnlOrphanedLabels;
		private System.Windows.Forms.Button btnExitOrphans;
		private System.Windows.Forms.CheckBox chkSelectAllOrphans;
		private System.Windows.Forms.Button btnRemoveSelectedOrphans;
		private System.Windows.Forms.ListBox lstOrphanedLabels;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ToolStripMenuItem mnuAdd;
		private System.Windows.Forms.ToolStripMenuItem mnuRename;
		private System.Windows.Forms.ToolStripMenuItem mnuDelete;
		private System.Windows.Forms.Label label5;
		private ContextMenuStrip mnuFoundEntries;
		private ToolStripMenuItem mnuContextRename;
		private ToolStripMenuItem mnuContextDelete;
		private ToolStripMenuItem mnuDelete_OneJournal;
		private ToolStripMenuItem mnuDelete_AllJournals;
		private ToolStripMenuItem mnuRename_OneJournal;
		private ToolStripMenuItem mnuRename_AllJournals;
	}
}