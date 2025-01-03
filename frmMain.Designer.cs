﻿
namespace MyNotebooks.subforms
{
	partial class frmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			btnLoadNotebook = new System.Windows.Forms.Button();
			txtJournalPIN = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			lblSelectionType = new System.Windows.Forms.Label();
			ddlNotebooks = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			lstEntries = new System.Windows.Forms.ListBox();
			mnuEntryTop = new System.Windows.Forms.ContextMenuStrip(components);
			mnuEntryCreate = new System.Windows.Forms.ToolStripMenuItem();
			mnuEntryEdit = new System.Windows.Forms.ToolStripMenuItem();
			mnuPreserveOriginalText = new System.Windows.Forms.ToolStripMenuItem();
			mnuDiscardOriginalText = new System.Windows.Forms.ToolStripMenuItem();
			mnuEntryDelete = new System.Windows.Forms.ToolStripMenuItem();
			rtbSelectedEntry = new System.Windows.Forms.RichTextBox();
			lblSeparator = new System.Windows.Forms.Label();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			mnuNotebook = new System.Windows.Forms.ToolStripMenuItem();
			mnuNotebooks_Select = new System.Windows.Forms.ToolStripMenuItem();
			mnuNotebook_Create = new System.Windows.Forms.ToolStripMenuItem();
			mnuNotebook_Delete = new System.Windows.Forms.ToolStripMenuItem();
			mnuNotebook_Search = new System.Windows.Forms.ToolStripMenuItem();
			mnuNotebook_Rename = new System.Windows.Forms.ToolStripMenuItem();
			mnuNotebook_ForceBackup = new System.Windows.Forms.ToolStripMenuItem();
			mnuNotebook_Import = new System.Windows.Forms.ToolStripMenuItem();
			mnuNotebook_Export = new System.Windows.Forms.ToolStripMenuItem();
			mnuNotebook_Settings = new System.Windows.Forms.ToolStripMenuItem();
			mnuNotebook_ResetPIN = new System.Windows.Forms.ToolStripMenuItem();
			mnuLabelsSummary = new System.Windows.Forms.ToolStripMenuItem();
			mnuNotebook_Backups = new System.Windows.Forms.ToolStripMenuItem();
			mnuNotebook_Backups_Create = new System.Windows.Forms.ToolStripMenuItem();
			mnuNotebook_Backups_Restore = new System.Windows.Forms.ToolStripMenuItem();
			mnuLabels = new System.Windows.Forms.ToolStripMenuItem();
			helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
			mnuSwitchAccount = new System.Windows.Forms.ToolStripMenuItem();
			mnuAdministratorConsole = new System.Windows.Forms.ToolStripMenuItem();
			lblWrongPin = new System.Windows.Forms.Label();
			lblEntries = new System.Windows.Forms.Label();
			lblShowPIN = new System.Windows.Forms.Label();
			cbxDatesFrom = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			pnlDateFilters = new System.Windows.Forms.Panel();
			lblEntriesCount = new System.Windows.Forms.Label();
			cbxSortEntriesBy = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			cbxDatesTo = new System.Windows.Forms.ComboBox();
			pnlPin = new System.Windows.Forms.Panel();
			btnResetLabelFilter = new System.Windows.Forms.Button();
			bgWorker = new System.ComponentModel.BackgroundWorker();
			mnuNotebook_Backups_CreateJSON = new System.Windows.Forms.ToolStripMenuItem();
			mnuNotebook_Backups_CreatePlain = new System.Windows.Forms.ToolStripMenuItem();
			mnuEntryTop.SuspendLayout();
			menuStrip1.SuspendLayout();
			pnlDateFilters.SuspendLayout();
			pnlPin.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnLoadNotebook
			// 
			btnLoadNotebook.Location = new System.Drawing.Point(137, 2);
			btnLoadNotebook.Name = "btnLoadNotebook";
			btnLoadNotebook.Size = new System.Drawing.Size(75, 23);
			btnLoadNotebook.TabIndex = 36;
			btnLoadNotebook.Text = "&Load";
			btnLoadNotebook.UseVisualStyleBackColor = true;
			btnLoadNotebook.Click += this.loadSelectedNotebook;
			// 
			// txtJournalPIN
			// 
			txtJournalPIN.Location = new System.Drawing.Point(28, 2);
			txtJournalPIN.Name = "txtJournalPIN";
			txtJournalPIN.PasswordChar = '*';
			txtJournalPIN.Size = new System.Drawing.Size(100, 23);
			txtJournalPIN.TabIndex = 34;
			txtJournalPIN.TextChanged += this.txtNotebookPIN_TextChanged;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(1, 5);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(26, 15);
			label4.TabIndex = 33;
			label4.Text = "PIN";
			// 
			// lblSelectionType
			// 
			lblSelectionType.AutoSize = true;
			lblSelectionType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
			lblSelectionType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblSelectionType.Location = new System.Drawing.Point(12, 252);
			lblSelectionType.Name = "lblSelectionType";
			lblSelectionType.Size = new System.Drawing.Size(96, 17);
			lblSelectionType.TabIndex = 9;
			lblSelectionType.Text = "Selected Entry";
			lblSelectionType.Visible = false;
			// 
			// ddlNotebooks
			// 
			ddlNotebooks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			ddlNotebooks.Enabled = false;
			ddlNotebooks.FormattingEnabled = true;
			ddlNotebooks.Location = new System.Drawing.Point(85, 30);
			ddlNotebooks.Name = "ddlNotebooks";
			ddlNotebooks.Size = new System.Drawing.Size(691, 23);
			ddlNotebooks.TabIndex = 1;
			ddlNotebooks.SelectedIndexChanged += this.ddlNotebooks_SelectedIndexChanged;
			ddlNotebooks.Click += this.ddlNotebooks_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 33);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(71, 15);
			label1.TabIndex = 0;
			label1.Text = "Notebooks: ";
			// 
			// lstEntries
			// 
			lstEntries.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			lstEntries.ContextMenuStrip = mnuEntryTop;
			lstEntries.FormattingEnabled = true;
			lstEntries.HorizontalScrollbar = true;
			lstEntries.IntegralHeight = false;
			lstEntries.ItemHeight = 15;
			lstEntries.Location = new System.Drawing.Point(12, 109);
			lstEntries.Name = "lstEntries";
			lstEntries.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			lstEntries.Size = new System.Drawing.Size(764, 123);
			lstEntries.TabIndex = 8;
			lstEntries.UseTabStops = false;
			lstEntries.Visible = false;
			lstEntries.SelectedIndexChanged += this.lstEntries_SelectEntry;
			lstEntries.MouseUp += this.lstEntries_MouseUp;
			// 
			// mnuEntryTop
			// 
			mnuEntryTop.Enabled = false;
			mnuEntryTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuEntryCreate, mnuEntryEdit, mnuEntryDelete });
			mnuEntryTop.Name = "mnuEntryTop";
			mnuEntryTop.Size = new System.Drawing.Size(129, 70);
			mnuEntryTop.Text = "&Entry";
			// 
			// mnuEntryCreate
			// 
			mnuEntryCreate.Enabled = false;
			mnuEntryCreate.Name = "mnuEntryCreate";
			mnuEntryCreate.Size = new System.Drawing.Size(128, 22);
			mnuEntryCreate.Text = "&New Entry";
			mnuEntryCreate.Click += this.mnuEntryCreate_Click;
			// 
			// mnuEntryEdit
			// 
			mnuEntryEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuPreserveOriginalText, mnuDiscardOriginalText });
			mnuEntryEdit.Enabled = false;
			mnuEntryEdit.Name = "mnuEntryEdit";
			mnuEntryEdit.Size = new System.Drawing.Size(128, 22);
			mnuEntryEdit.Text = "E&dit";
			mnuEntryEdit.Click += this.mnuEntryEdit_Click;
			// 
			// mnuPreserveOriginalText
			// 
			mnuPreserveOriginalText.Name = "mnuPreserveOriginalText";
			mnuPreserveOriginalText.Size = new System.Drawing.Size(187, 22);
			mnuPreserveOriginalText.Text = "Preserve Original Text";
			mnuPreserveOriginalText.Click += this.mnuEntryEdit_Click;
			// 
			// mnuDiscardOriginalText
			// 
			mnuDiscardOriginalText.Name = "mnuDiscardOriginalText";
			mnuDiscardOriginalText.Size = new System.Drawing.Size(187, 22);
			mnuDiscardOriginalText.Text = "Edit Original Text";
			mnuDiscardOriginalText.Click += this.mnuEntryEdit_Click;
			// 
			// mnuEntryDelete
			// 
			mnuEntryDelete.Enabled = false;
			mnuEntryDelete.Name = "mnuEntryDelete";
			mnuEntryDelete.Size = new System.Drawing.Size(128, 22);
			mnuEntryDelete.Text = "Delete";
			mnuEntryDelete.Click += this.mnuEntryDelete_Click;
			// 
			// rtbSelectedEntry
			// 
			rtbSelectedEntry.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			rtbSelectedEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			rtbSelectedEntry.Location = new System.Drawing.Point(15, 271);
			rtbSelectedEntry.Name = "rtbSelectedEntry";
			rtbSelectedEntry.Size = new System.Drawing.Size(761, 283);
			rtbSelectedEntry.TabIndex = 5;
			rtbSelectedEntry.TabStop = false;
			rtbSelectedEntry.Text = "";
			rtbSelectedEntry.Visible = false;
			rtbSelectedEntry.MouseDown += this.rtbSelectedEntry_MouseDown;
			// 
			// lblSeparator
			// 
			lblSeparator.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			lblSeparator.Cursor = System.Windows.Forms.Cursors.HSplit;
			lblSeparator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			lblSeparator.ForeColor = System.Drawing.Color.Red;
			lblSeparator.Location = new System.Drawing.Point(13, 232);
			lblSeparator.Name = "lblSeparator";
			lblSeparator.Size = new System.Drawing.Size(766, 19);
			lblSeparator.TabIndex = 30;
			lblSeparator.Text = resources.GetString("lblSeparator.Text");
			lblSeparator.Visible = false;
			lblSeparator.MouseMove += this.lblSeparator_MouseMove;
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuNotebook, mnuLabels, helpToolStripMenuItem, mnuSwitchAccount, mnuAdministratorConsole });
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new System.Drawing.Size(788, 24);
			menuStrip1.TabIndex = 37;
			menuStrip1.Text = "menuStrip1";
			// 
			// mnuNotebook
			// 
			mnuNotebook.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuNotebooks_Select, mnuNotebook_Create, mnuNotebook_Delete, mnuNotebook_Search, mnuNotebook_Rename, mnuNotebook_ForceBackup, mnuNotebook_Import, mnuNotebook_Export, mnuNotebook_Settings, mnuNotebook_ResetPIN, mnuLabelsSummary, mnuNotebook_Backups });
			mnuNotebook.Name = "mnuNotebook";
			mnuNotebook.Size = new System.Drawing.Size(77, 20);
			mnuNotebook.Text = "&Notebooks";
			// 
			// mnuNotebooks_Select
			// 
			mnuNotebooks_Select.Enabled = false;
			mnuNotebooks_Select.Name = "mnuNotebooks_Select";
			mnuNotebooks_Select.Size = new System.Drawing.Size(161, 22);
			mnuNotebooks_Select.Text = "Se&lect";
			mnuNotebooks_Select.Visible = false;
			mnuNotebooks_Select.Click += this.mnuNotebooks_Select_Click;
			// 
			// mnuNotebook_Create
			// 
			mnuNotebook_Create.Name = "mnuNotebook_Create";
			mnuNotebook_Create.Size = new System.Drawing.Size(161, 22);
			mnuNotebook_Create.Text = "&Create";
			mnuNotebook_Create.Click += this.mnuNotebook_Create_Click;
			// 
			// mnuNotebook_Delete
			// 
			mnuNotebook_Delete.Enabled = false;
			mnuNotebook_Delete.Name = "mnuNotebook_Delete";
			mnuNotebook_Delete.Size = new System.Drawing.Size(161, 22);
			mnuNotebook_Delete.Text = "Delete";
			mnuNotebook_Delete.Click += this.mnuNotebook_Delete_Click;
			// 
			// mnuNotebook_Search
			// 
			mnuNotebook_Search.Name = "mnuNotebook_Search";
			mnuNotebook_Search.Size = new System.Drawing.Size(161, 22);
			mnuNotebook_Search.Text = "&Search";
			mnuNotebook_Search.Click += this.mnuNotebook_Search_Click;
			// 
			// mnuNotebook_Rename
			// 
			mnuNotebook_Rename.Enabled = false;
			mnuNotebook_Rename.Name = "mnuNotebook_Rename";
			mnuNotebook_Rename.Size = new System.Drawing.Size(161, 22);
			mnuNotebook_Rename.Text = "Rename";
			mnuNotebook_Rename.Click += this.mnuNotebook_Rename_Click;
			// 
			// mnuNotebook_ForceBackup
			// 
			mnuNotebook_ForceBackup.Enabled = false;
			mnuNotebook_ForceBackup.Name = "mnuNotebook_ForceBackup";
			mnuNotebook_ForceBackup.Size = new System.Drawing.Size(161, 22);
			mnuNotebook_ForceBackup.Text = "Force &Backup";
			mnuNotebook_ForceBackup.Visible = false;
			mnuNotebook_ForceBackup.Click += this.mnuNotebook_ForceBackup_Click;
			// 
			// mnuNotebook_Import
			// 
			mnuNotebook_Import.Enabled = false;
			mnuNotebook_Import.Name = "mnuNotebook_Import";
			mnuNotebook_Import.Size = new System.Drawing.Size(161, 22);
			mnuNotebook_Import.Text = "Import";
			mnuNotebook_Import.Click += this.mnuNotebook_Import_Click;
			// 
			// mnuNotebook_Export
			// 
			mnuNotebook_Export.Enabled = false;
			mnuNotebook_Export.Name = "mnuNotebook_Export";
			mnuNotebook_Export.Size = new System.Drawing.Size(161, 22);
			mnuNotebook_Export.Text = "Synch";
			mnuNotebook_Export.Visible = false;
			mnuNotebook_Export.Click += this.mnuNotebook_Export_Click;
			// 
			// mnuNotebook_Settings
			// 
			mnuNotebook_Settings.Enabled = false;
			mnuNotebook_Settings.Name = "mnuNotebook_Settings";
			mnuNotebook_Settings.Size = new System.Drawing.Size(161, 22);
			mnuNotebook_Settings.Text = "Settings";
			mnuNotebook_Settings.Visible = false;
			mnuNotebook_Settings.Click += this.mnuNotebook_Settings_Click;
			// 
			// mnuNotebook_ResetPIN
			// 
			mnuNotebook_ResetPIN.Enabled = false;
			mnuNotebook_ResetPIN.Name = "mnuNotebook_ResetPIN";
			mnuNotebook_ResetPIN.Size = new System.Drawing.Size(161, 22);
			mnuNotebook_ResetPIN.Text = "Reset &PIN";
			mnuNotebook_ResetPIN.Visible = false;
			mnuNotebook_ResetPIN.Click += this.mnuNotebook_ResetPIN_Click;
			// 
			// mnuLabelsSummary
			// 
			mnuLabelsSummary.Enabled = false;
			mnuLabelsSummary.Name = "mnuLabelsSummary";
			mnuLabelsSummary.Size = new System.Drawing.Size(161, 22);
			mnuLabelsSummary.Text = "Labels Summary";
			mnuLabelsSummary.Visible = false;
			// 
			// mnuNotebook_Backups
			// 
			mnuNotebook_Backups.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuNotebook_Backups_Create, mnuNotebook_Backups_Restore });
			mnuNotebook_Backups.Name = "mnuNotebook_Backups";
			mnuNotebook_Backups.Size = new System.Drawing.Size(161, 22);
			mnuNotebook_Backups.Text = "&Backups";
			// 
			// mnuNotebook_Backups_Create
			// 
			mnuNotebook_Backups_Create.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuNotebook_Backups_CreateJSON, mnuNotebook_Backups_CreatePlain });
			mnuNotebook_Backups_Create.Enabled = false;
			mnuNotebook_Backups_Create.Name = "mnuNotebook_Backups_Create";
			mnuNotebook_Backups_Create.Size = new System.Drawing.Size(113, 22);
			mnuNotebook_Backups_Create.Text = "&Create";
			// 
			// mnuNotebook_Backups_Restore
			// 
			mnuNotebook_Backups_Restore.Name = "mnuNotebook_Backups_Restore";
			mnuNotebook_Backups_Restore.Size = new System.Drawing.Size(113, 22);
			mnuNotebook_Backups_Restore.Text = "&Restore";
			mnuNotebook_Backups_Restore.Click += this.mnuNotebook_Backups_CreateOrRestore;
			// 
			// mnuLabels
			// 
			mnuLabels.Name = "mnuLabels";
			mnuLabels.Size = new System.Drawing.Size(52, 20);
			mnuLabels.Text = "&Labels";
			mnuLabels.Click += this.mnuLabels_Click;
			// 
			// helpToolStripMenuItem
			// 
			helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuAbout });
			helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			helpToolStripMenuItem.Text = "&Help";
			// 
			// mnuAbout
			// 
			mnuAbout.Name = "mnuAbout";
			mnuAbout.Size = new System.Drawing.Size(165, 22);
			mnuAbout.Text = "About MyJournal";
			mnuAbout.Click += this.mnuAbout_Click;
			// 
			// mnuSwitchAccount
			// 
			mnuSwitchAccount.Name = "mnuSwitchAccount";
			mnuSwitchAccount.Size = new System.Drawing.Size(107, 20);
			mnuSwitchAccount.Text = "&Switch Accounts";
			mnuSwitchAccount.Click += this.mnuSwitchAccount_Click;
			// 
			// mnuAdministratorConsole
			// 
			mnuAdministratorConsole.Name = "mnuAdministratorConsole";
			mnuAdministratorConsole.Size = new System.Drawing.Size(138, 20);
			mnuAdministratorConsole.Text = "&Administrator Console";
			mnuAdministratorConsole.Click += this.mnuAdministratorConsole_Click;
			// 
			// lblWrongPin
			// 
			lblWrongPin.AutoSize = true;
			lblWrongPin.ForeColor = System.Drawing.Color.Red;
			lblWrongPin.Location = new System.Drawing.Point(65, 29);
			lblWrongPin.Name = "lblWrongPin";
			lblWrongPin.Size = new System.Drawing.Size(63, 15);
			lblWrongPin.TabIndex = 38;
			lblWrongPin.Text = "wrong PIN";
			lblWrongPin.Visible = false;
			// 
			// lblEntries
			// 
			lblEntries.AutoSize = true;
			lblEntries.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
			lblEntries.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblEntries.Location = new System.Drawing.Point(10, 90);
			lblEntries.Name = "lblEntries";
			lblEntries.Size = new System.Drawing.Size(50, 17);
			lblEntries.TabIndex = 39;
			lblEntries.Text = "Entries";
			lblEntries.Visible = false;
			// 
			// lblShowPIN
			// 
			lblShowPIN.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline);
			lblShowPIN.Location = new System.Drawing.Point(29, 27);
			lblShowPIN.Name = "lblShowPIN";
			lblShowPIN.Size = new System.Drawing.Size(35, 13);
			lblShowPIN.TabIndex = 40;
			lblShowPIN.Text = "show";
			lblShowPIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			lblShowPIN.Visible = false;
			lblShowPIN.Click += this.lblShowPIN_Click;
			// 
			// cbxDatesFrom
			// 
			cbxDatesFrom.FormattingEnabled = true;
			cbxDatesFrom.Location = new System.Drawing.Point(39, 2);
			cbxDatesFrom.Name = "cbxDatesFrom";
			cbxDatesFrom.Size = new System.Drawing.Size(70, 23);
			cbxDatesFrom.TabIndex = 44;
			cbxDatesFrom.SelectedIndexChanged += this.cbxDates_SelectedIndexChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(4, 7);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(36, 15);
			label2.TabIndex = 41;
			label2.Text = "from ";
			// 
			// pnlDateFilters
			// 
			pnlDateFilters.Controls.Add(lblEntriesCount);
			pnlDateFilters.Controls.Add(cbxSortEntriesBy);
			pnlDateFilters.Controls.Add(label5);
			pnlDateFilters.Controls.Add(label3);
			pnlDateFilters.Controls.Add(cbxDatesTo);
			pnlDateFilters.Controls.Add(cbxDatesFrom);
			pnlDateFilters.Controls.Add(label2);
			pnlDateFilters.Location = new System.Drawing.Point(96, 59);
			pnlDateFilters.Name = "pnlDateFilters";
			pnlDateFilters.Size = new System.Drawing.Size(529, 27);
			pnlDateFilters.TabIndex = 49;
			pnlDateFilters.Visible = false;
			// 
			// lblEntriesCount
			// 
			lblEntriesCount.AutoSize = true;
			lblEntriesCount.Location = new System.Drawing.Point(366, 5);
			lblEntriesCount.Name = "lblEntriesCount";
			lblEntriesCount.Size = new System.Drawing.Size(140, 15);
			lblEntriesCount.TabIndex = 41;
			lblEntriesCount.Text = "showing 50 of 100 entries";
			lblEntriesCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxSortEntriesBy
			// 
			cbxSortEntriesBy.FormattingEnabled = true;
			cbxSortEntriesBy.Items.AddRange(new object[] { "Created On", "Edited On", "Title" });
			cbxSortEntriesBy.Location = new System.Drawing.Point(269, 1);
			cbxSortEntriesBy.Name = "cbxSortEntriesBy";
			cbxSortEntriesBy.Size = new System.Drawing.Size(91, 23);
			cbxSortEntriesBy.TabIndex = 52;
			cbxSortEntriesBy.Text = "Created On";
			cbxSortEntriesBy.SelectedIndexChanged += this.cbxSortEntriesBy_SelectedIndexChanged;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(223, 6);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(46, 15);
			label5.TabIndex = 51;
			label5.Text = "sort by:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(127, 7);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(18, 15);
			label3.TabIndex = 46;
			label3.Text = "to";
			// 
			// cbxDatesTo
			// 
			cbxDatesTo.FormattingEnabled = true;
			cbxDatesTo.Location = new System.Drawing.Point(146, 2);
			cbxDatesTo.Name = "cbxDatesTo";
			cbxDatesTo.Size = new System.Drawing.Size(70, 23);
			cbxDatesTo.TabIndex = 45;
			cbxDatesTo.SelectedIndexChanged += this.cbxDates_SelectedIndexChanged;
			// 
			// pnlPin
			// 
			pnlPin.Controls.Add(btnLoadNotebook);
			pnlPin.Controls.Add(label4);
			pnlPin.Controls.Add(lblShowPIN);
			pnlPin.Controls.Add(txtJournalPIN);
			pnlPin.Controls.Add(lblWrongPin);
			pnlPin.Location = new System.Drawing.Point(824, 232);
			pnlPin.Name = "pnlPin";
			pnlPin.Size = new System.Drawing.Size(218, 46);
			pnlPin.TabIndex = 50;
			pnlPin.Visible = false;
			// 
			// btnResetLabelFilter
			// 
			btnResetLabelFilter.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnResetLabelFilter.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F);
			btnResetLabelFilter.Location = new System.Drawing.Point(610, 86);
			btnResetLabelFilter.Name = "btnResetLabelFilter";
			btnResetLabelFilter.Size = new System.Drawing.Size(137, 21);
			btnResetLabelFilter.TabIndex = 51;
			btnResetLabelFilter.Text = "reset label filter";
			btnResetLabelFilter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			btnResetLabelFilter.UseVisualStyleBackColor = true;
			btnResetLabelFilter.Visible = false;
			btnResetLabelFilter.Click += this.btnResetLabelFilter_Click;
			// 
			// bgWorker
			// 
			bgWorker.WorkerReportsProgress = true;
			// 
			// mnuNotebook_Backups_CreateJSON
			// 
			mnuNotebook_Backups_CreateJSON.Name = "mnuNotebook_Backups_CreateJSON";
			mnuNotebook_Backups_CreateJSON.Size = new System.Drawing.Size(180, 22);
			mnuNotebook_Backups_CreateJSON.Text = "&JSON";
			mnuNotebook_Backups_CreateJSON.Click += this.mnuNotebook_Backups_CreateOrRestore;
			// 
			// mnuNotebook_Backups_CreatePlain
			// 
			mnuNotebook_Backups_CreatePlain.Name = "mnuNotebook_Backups_CreatePlain";
			mnuNotebook_Backups_CreatePlain.Size = new System.Drawing.Size(180, 22);
			mnuNotebook_Backups_CreatePlain.Text = "&Plain Text";
			mnuNotebook_Backups_CreatePlain.Click += this.mnuNotebook_Backups_CreateOrRestore;
			// 
			// frmMain
			// 
			AcceptButton = btnLoadNotebook;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Window;
			ClientSize = new System.Drawing.Size(788, 566);
			Controls.Add(btnResetLabelFilter);
			Controls.Add(lblEntries);
			Controls.Add(pnlPin);
			Controls.Add(pnlDateFilters);
			Controls.Add(lblSelectionType);
			Controls.Add(lblSeparator);
			Controls.Add(rtbSelectedEntry);
			Controls.Add(lstEntries);
			Controls.Add(label1);
			Controls.Add(ddlNotebooks);
			Controls.Add(menuStrip1);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			MinimumSize = new System.Drawing.Size(650, 441);
			Name = "frmMain";
			Text = "MyJournal";
			Activated += this.frmMain_Activated;
			FormClosed += this.frmMain_FormClosed;
			Load += this.frmMain_Load;
			Resize += this.frmMain_Resize;
			mnuEntryTop.ResumeLayout(false);
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			pnlDateFilters.ResumeLayout(false);
			pnlDateFilters.PerformLayout();
			pnlPin.ResumeLayout(false);
			pnlPin.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion
		private System.Windows.Forms.Button btnLoadNotebook;
		private System.Windows.Forms.TextBox txtJournalPIN;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblSelectionType;
		private System.Windows.Forms.ComboBox ddlNotebooks;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lstEntries;
		private System.Windows.Forms.RichTextBox rtbSelectedEntry;
		private System.Windows.Forms.Label lblSeparator;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook_Create;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook_Delete;
		private System.Windows.Forms.ContextMenuStrip mnuEntryTop;
		private System.Windows.Forms.ToolStripMenuItem mnuEntryCreate;
		private System.Windows.Forms.ToolStripMenuItem mnuEntryEdit;
		private System.Windows.Forms.Label lblWrongPin;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook_Search;
		private System.Windows.Forms.Label lblEntries;
		private System.Windows.Forms.ToolStripMenuItem mnuEntryDelete;
		private System.Windows.Forms.Label lblShowPIN;
		private System.Windows.Forms.ComboBox cbxDatesFrom;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel pnlDateFilters;
		private System.Windows.Forms.ToolStripMenuItem mnuPreserveOriginalText;
		private System.Windows.Forms.ToolStripMenuItem mnuDiscardOriginalText;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook_Rename;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook_ForceBackup;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbxDatesTo;
		private System.Windows.Forms.ToolStripMenuItem mnuLabels;
		private System.Windows.Forms.Panel pnlPin;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuAbout;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook_Import;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook_Export;
		private System.Windows.Forms.ComboBox cbxSortEntriesBy;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ToolStripMenuItem mnuSwitchAccount;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook_Settings;
		private System.Windows.Forms.Label lblEntriesCount;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook_ResetPIN;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebooks_Select;
		private System.Windows.Forms.ToolStripMenuItem mnuLabelsSummary;
		private System.Windows.Forms.Button btnResetLabelFilter;
		private System.Windows.Forms.ToolStripMenuItem mnuAdministratorConsole;
		private System.ComponentModel.BackgroundWorker bgWorker;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook_Backups;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook_Backups_Create;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook_Backups_Restore;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook_Backups_CreateJSON;
		private System.Windows.Forms.ToolStripMenuItem mnuNotebook_Backups_CreatePlain;
	}
}