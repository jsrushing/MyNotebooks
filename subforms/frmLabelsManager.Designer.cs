
using System.Windows.Forms;

namespace myNotebooks.subforms
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
			txtLabelName = new TextBox();
			lblLabelExists = new Label();
			btnOK = new Button();
			btnCancel = new Button();
			lblOperation = new Label();
			label5 = new Label();
			lstLabels = new ListBox();
			mnuContextLabels = new ContextMenuStrip(components);
			mnuContextRename_lstLables = new ToolStripMenuItem();
			mnuContextDelete_lstLabels = new ToolStripMenuItem();
			lblEntries2 = new Label();
			lblSortType = new Label();
			lblEntries1 = new Label();
			lstOccurrences = new ListBox();
			mnuContextEntries = new ContextMenuStrip(components);
			mnuContextRename_lstEntries = new ToolStripMenuItem();
			mnuContextDelete_lstEntries = new ToolStripMenuItem();
			label1 = new Label();
			mnuMain = new MenuStrip();
			mnuLabelsOperations = new ToolStripMenuItem();
			mnuAdd = new ToolStripMenuItem();
			mnuFindOrphans = new ToolStripMenuItem();
			mnuMoveTop = new ToolStripMenuItem();
			mnuMoveUp = new ToolStripMenuItem();
			mnuMoveDown = new ToolStripMenuItem();
			mnuAssignPINs = new ToolStripMenuItem();
			lstEntryObjects = new ListBox();
			pnlOrphanedLabels = new Panel();
			btnExitOrphans = new Button();
			chkSelectAllOrphans = new CheckBox();
			btnRemoveSelectedOrphans = new Button();
			lstOrphanedLabels = new ListBox();
			label4 = new Label();
			pnlMain.SuspendLayout();
			pnlNewLabelName.SuspendLayout();
			mnuContextLabels.SuspendLayout();
			mnuContextEntries.SuspendLayout();
			mnuMain.SuspendLayout();
			pnlOrphanedLabels.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			pnlMain.Controls.Add(pnlNewLabelName);
			pnlMain.Controls.Add(lstLabels);
			pnlMain.Controls.Add(lblEntries2);
			pnlMain.Controls.Add(lblSortType);
			pnlMain.Controls.Add(lblEntries1);
			pnlMain.Controls.Add(lstOccurrences);
			pnlMain.Controls.Add(label1);
			pnlMain.Location = new System.Drawing.Point(16, 25);
			pnlMain.Name = "pnlMain";
			pnlMain.Size = new System.Drawing.Size(269, 554);
			pnlMain.TabIndex = 0;
			// 
			// pnlNewLabelName
			// 
			pnlNewLabelName.BackColor = System.Drawing.SystemColors.ActiveCaption;
			pnlNewLabelName.Controls.Add(txtLabelName);
			pnlNewLabelName.Controls.Add(lblLabelExists);
			pnlNewLabelName.Controls.Add(btnOK);
			pnlNewLabelName.Controls.Add(btnCancel);
			pnlNewLabelName.Controls.Add(lblOperation);
			pnlNewLabelName.Controls.Add(label5);
			pnlNewLabelName.Location = new System.Drawing.Point(19, 75);
			pnlNewLabelName.Name = "pnlNewLabelName";
			pnlNewLabelName.Size = new System.Drawing.Size(204, 110);
			pnlNewLabelName.TabIndex = 2;
			pnlNewLabelName.Visible = false;
			// 
			// txtLabelName
			// 
			txtLabelName.Location = new System.Drawing.Point(26, 34);
			txtLabelName.Name = "txtLabelName";
			txtLabelName.Size = new System.Drawing.Size(154, 23);
			txtLabelName.TabIndex = 0;
			// 
			// lblLabelExists
			// 
			lblLabelExists.AutoSize = true;
			lblLabelExists.BackColor = System.Drawing.SystemColors.ButtonFace;
			lblLabelExists.ForeColor = System.Drawing.Color.Red;
			lblLabelExists.Location = new System.Drawing.Point(37, 56);
			lblLabelExists.Name = "lblLabelExists";
			lblLabelExists.Size = new System.Drawing.Size(111, 15);
			lblLabelExists.TabIndex = 4;
			lblLabelExists.Text = "Label already exists.";
			lblLabelExists.Visible = false;
			// 
			// btnOK
			// 
			btnOK.Location = new System.Drawing.Point(18, 71);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 2;
			btnOK.Text = "&Ok";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += this.btnOK_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new System.Drawing.Point(105, 71);
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
			// label5
			// 
			label5.BackColor = System.Drawing.SystemColors.ButtonFace;
			label5.Location = new System.Drawing.Point(11, 7);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(182, 93);
			label5.TabIndex = 5;
			// 
			// lstLabels
			// 
			lstLabels.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			lstLabels.ContextMenuStrip = mnuContextLabels;
			lstLabels.FormattingEnabled = true;
			lstLabels.IntegralHeight = false;
			lstLabels.ItemHeight = 15;
			lstLabels.Location = new System.Drawing.Point(9, 23);
			lstLabels.Name = "lstLabels";
			lstLabels.Size = new System.Drawing.Size(251, 184);
			lstLabels.TabIndex = 0;
			lstLabels.SelectedIndexChanged += this.lstLabels_SelectedIndexChanged;
			lstLabels.MouseUp += this.lstLabels_MouseUp;
			// 
			// mnuContextLabels
			// 
			mnuContextLabels.Items.AddRange(new ToolStripItem[] { mnuContextRename_lstLables, mnuContextDelete_lstLabels });
			mnuContextLabels.Name = "mnuContextLabels";
			mnuContextLabels.Size = new System.Drawing.Size(118, 48);
			// 
			// mnuContextRename_lstLables
			// 
			mnuContextRename_lstLables.Name = "mnuContextRename_lstLables";
			mnuContextRename_lstLables.Size = new System.Drawing.Size(117, 22);
			mnuContextRename_lstLables.Text = "&Rename";
			mnuContextRename_lstLables.Click += this.DeleteOrRename;
			// 
			// mnuContextDelete_lstLabels
			// 
			mnuContextDelete_lstLabels.Name = "mnuContextDelete_lstLabels";
			mnuContextDelete_lstLabels.Size = new System.Drawing.Size(117, 22);
			mnuContextDelete_lstLabels.Text = "&Delete";
			mnuContextDelete_lstLabels.Click += this.DeleteOrRename;
			// 
			// lblEntries2
			// 
			lblEntries2.AutoSize = true;
			lblEntries2.Location = new System.Drawing.Point(9, 225);
			lblEntries2.Name = "lblEntries2";
			lblEntries2.Size = new System.Drawing.Size(216, 15);
			lblEntries2.TabIndex = 6;
			lblEntries2.Text = "(dbl-click entry or right-click notebook)";
			// 
			// lblSortType
			// 
			lblSortType.AutoSize = true;
			lblSortType.Cursor = Cursors.Hand;
			lblSortType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			lblSortType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblSortType.Location = new System.Drawing.Point(145, 4);
			lblSortType.Name = "lblSortType";
			lblSortType.Size = new System.Drawing.Size(59, 17);
			lblSortType.TabIndex = 5;
			lblSortType.Text = "Sort A-Z";
			lblSortType.Click += this.lblSortType_Click;
			// 
			// lblEntries1
			// 
			lblEntries1.AutoSize = true;
			lblEntries1.Location = new System.Drawing.Point(9, 210);
			lblEntries1.Name = "lblEntries1";
			lblEntries1.Size = new System.Drawing.Size(79, 15);
			lblEntries1.TabIndex = 4;
			lblEntries1.Text = "Found Entries";
			// 
			// lstOccurrences
			// 
			lstOccurrences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstOccurrences.ContextMenuStrip = mnuContextEntries;
			lstOccurrences.FormattingEnabled = true;
			lstOccurrences.IntegralHeight = false;
			lstOccurrences.ItemHeight = 15;
			lstOccurrences.Location = new System.Drawing.Point(9, 243);
			lstOccurrences.Name = "lstOccurrences";
			lstOccurrences.Size = new System.Drawing.Size(251, 303);
			lstOccurrences.TabIndex = 3;
			lstOccurrences.DoubleClick += this.lstOccurrences_DoubleClick;
			lstOccurrences.MouseUp += this.lstOccurrences_MouseUp;
			// 
			// mnuContextEntries
			// 
			mnuContextEntries.Items.AddRange(new ToolStripItem[] { mnuContextRename_lstEntries, mnuContextDelete_lstEntries });
			mnuContextEntries.Name = "mnuFoundEntries";
			mnuContextEntries.Size = new System.Drawing.Size(185, 70);
			// 
			// mnuContextRename_lstEntries
			// 
			mnuContextRename_lstEntries.Name = "mnuContextRename_lstEntries";
			mnuContextRename_lstEntries.Size = new System.Drawing.Size(184, 22);
			mnuContextRename_lstEntries.Text = "&Rename in notebook";
			mnuContextRename_lstEntries.Click += this.DeleteOrRename;
			// 
			// mnuContextDelete_lstEntries
			// 
			mnuContextDelete_lstEntries.Name = "mnuContextDelete_lstEntries";
			mnuContextDelete_lstEntries.Size = new System.Drawing.Size(184, 22);
			mnuContextDelete_lstEntries.Text = "&Delete in notebook";
			mnuContextDelete_lstEntries.Click += this.DeleteOrRename;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(4, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(113, 15);
			label1.TabIndex = 1;
			label1.Text = "Labels (click to find)";
			// 
			// mnuMain
			// 
			mnuMain.Items.AddRange(new ToolStripItem[] { mnuLabelsOperations, mnuMoveTop, mnuAssignPINs });
			mnuMain.Location = new System.Drawing.Point(0, 0);
			mnuMain.Name = "mnuMain";
			mnuMain.Size = new System.Drawing.Size(524, 24);
			mnuMain.TabIndex = 1;
			mnuMain.Text = "menuStrip1";
			// 
			// mnuLabelsOperations
			// 
			mnuLabelsOperations.DropDownItems.AddRange(new ToolStripItem[] { mnuAdd, mnuFindOrphans });
			mnuLabelsOperations.Name = "mnuLabelsOperations";
			mnuLabelsOperations.Size = new System.Drawing.Size(52, 20);
			mnuLabelsOperations.Text = "Labels";
			// 
			// mnuAdd
			// 
			mnuAdd.Name = "mnuAdd";
			mnuAdd.Size = new System.Drawing.Size(145, 22);
			mnuAdd.Text = "&Add";
			mnuAdd.Click += this.mnuAdd_Click;
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
			mnuMoveUp.Click += this.MenuMove;
			// 
			// mnuMoveDown
			// 
			mnuMoveDown.Name = "mnuMoveDown";
			mnuMoveDown.Size = new System.Drawing.Size(105, 22);
			mnuMoveDown.Text = "D&own";
			mnuMoveDown.Click += this.MenuMove;
			// 
			// mnuAssignPINs
			// 
			mnuAssignPINs.Name = "mnuAssignPINs";
			mnuAssignPINs.Size = new System.Drawing.Size(111, 20);
			mnuAssignPINs.Text = "&Select Notebooks";
			mnuAssignPINs.Click += this.mnuSelectNotebooks_Click;
			// 
			// lstEntryObjects
			// 
			lstEntryObjects.Anchor = AnchorStyles.None;
			lstEntryObjects.FormattingEnabled = true;
			lstEntryObjects.IntegralHeight = false;
			lstEntryObjects.ItemHeight = 15;
			lstEntryObjects.Location = new System.Drawing.Point(312, 240);
			lstEntryObjects.Name = "lstEntryObjects";
			lstEntryObjects.Size = new System.Drawing.Size(127, 25);
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
			pnlOrphanedLabels.Location = new System.Drawing.Point(303, 25);
			pnlOrphanedLabels.Name = "pnlOrphanedLabels";
			pnlOrphanedLabels.Size = new System.Drawing.Size(212, 212);
			pnlOrphanedLabels.TabIndex = 5;
			pnlOrphanedLabels.Visible = false;
			// 
			// btnExitOrphans
			// 
			btnExitOrphans.Location = new System.Drawing.Point(124, 176);
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
			chkSelectAllOrphans.Location = new System.Drawing.Point(114, 6);
			chkSelectAllOrphans.Name = "chkSelectAllOrphans";
			chkSelectAllOrphans.Size = new System.Drawing.Size(71, 19);
			chkSelectAllOrphans.TabIndex = 4;
			chkSelectAllOrphans.Text = "select all";
			chkSelectAllOrphans.UseVisualStyleBackColor = true;
			chkSelectAllOrphans.CheckedChanged += this.chkSelectAllOrphans_CheckedChanged;
			// 
			// btnRemoveSelectedOrphans
			// 
			btnRemoveSelectedOrphans.Location = new System.Drawing.Point(7, 176);
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
			lstOrphanedLabels.Location = new System.Drawing.Point(7, 25);
			lstOrphanedLabels.Name = "lstOrphanedLabels";
			lstOrphanedLabels.SelectionMode = SelectionMode.MultiExtended;
			lstOrphanedLabels.Size = new System.Drawing.Size(208, 139);
			lstOrphanedLabels.TabIndex = 2;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(9, 7);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(96, 15);
			label4.TabIndex = 0;
			label4.Text = "Orphaned lables:";
			// 
			// frmLabelsManager
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(524, 581);
			Controls.Add(pnlOrphanedLabels);
			Controls.Add(lstEntryObjects);
			Controls.Add(pnlMain);
			Controls.Add(mnuMain);
			FormBorderStyle = FormBorderStyle.SizableToolWindow;
			MainMenuStrip = mnuMain;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmLabelsManager";
			Text = "Labels Manager";
			Load += this.frmLabelsManager_Load;
			Resize += this.frmLabelsManager_Resize;
			pnlMain.ResumeLayout(false);
			pnlMain.PerformLayout();
			pnlNewLabelName.ResumeLayout(false);
			pnlNewLabelName.PerformLayout();
			mnuContextLabels.ResumeLayout(false);
			mnuContextEntries.ResumeLayout(false);
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
		private System.Windows.Forms.Panel pnlNewLabelName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label lblOperation;
		private System.Windows.Forms.TextBox txtLabelName;
		private System.Windows.Forms.ListBox lstOccurrences;
		private System.Windows.Forms.ToolStripMenuItem mnuAssignPINs;
		private System.Windows.Forms.Label lblEntries1;
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
		private System.Windows.Forms.Label label5;

		private ContextMenuStrip mnuContextEntries;
		private ContextMenuStrip mnuContextLabels;
		private ToolStripMenuItem mnuContextDelete_lstEntries;
		private ToolStripMenuItem mnuContextRename_lstLables;
		private Label lblEntries2;
		private ToolStripMenuItem mnuContextDelete_lstLabels;
		private ToolStripMenuItem mnuContextRename_lstEntries;
	}
}