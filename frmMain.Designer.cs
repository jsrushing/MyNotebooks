
namespace myJournal.subforms
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
			btnLoadJournal = new System.Windows.Forms.Button();
			txtJournalPIN = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			lblSelectionType = new System.Windows.Forms.Label();
			ddlJournals = new System.Windows.Forms.ComboBox();
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
			mnuJournal = new System.Windows.Forms.ToolStripMenuItem();
			mnuJournal_Create = new System.Windows.Forms.ToolStripMenuItem();
			mnuJournal_Delete = new System.Windows.Forms.ToolStripMenuItem();
			mnuJournal_Search = new System.Windows.Forms.ToolStripMenuItem();
			mnuJournal_Rename = new System.Windows.Forms.ToolStripMenuItem();
			mnuJournal_ForceBackup = new System.Windows.Forms.ToolStripMenuItem();
			mnuJournal_RestoreBackups = new System.Windows.Forms.ToolStripMenuItem();
			mnuJournal_Import = new System.Windows.Forms.ToolStripMenuItem();
			mnuJournal_Export = new System.Windows.Forms.ToolStripMenuItem();
			mnuJournal_Settings = new System.Windows.Forms.ToolStripMenuItem();
			mnuLabels = new System.Windows.Forms.ToolStripMenuItem();
			helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mnuAboutMyJournal = new System.Windows.Forms.ToolStripMenuItem();
			mnuSwitchAccount = new System.Windows.Forms.ToolStripMenuItem();
			lblWrongPin = new System.Windows.Forms.Label();
			lblEntries = new System.Windows.Forms.Label();
			lblShowPIN = new System.Windows.Forms.Label();
			cbxDatesFrom = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			pnlDateFilters = new System.Windows.Forms.Panel();
			label6 = new System.Windows.Forms.Label();
			lblEntriesCount = new System.Windows.Forms.Label();
			cbxSortEntriesBy = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			cbxDatesTo = new System.Windows.Forms.ComboBox();
			pnlPin = new System.Windows.Forms.Panel();
			mnuResetPIN = new System.Windows.Forms.ToolStripMenuItem();
			mnuEntryTop.SuspendLayout();
			menuStrip1.SuspendLayout();
			pnlDateFilters.SuspendLayout();
			pnlPin.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnLoadJournal
			// 
			btnLoadJournal.Location = new System.Drawing.Point(137, 2);
			btnLoadJournal.Name = "btnLoadJournal";
			btnLoadJournal.Size = new System.Drawing.Size(75, 23);
			btnLoadJournal.TabIndex = 36;
			btnLoadJournal.Text = "&Load";
			btnLoadJournal.UseVisualStyleBackColor = true;
			btnLoadJournal.Click += this.btnLoadNotebook_Click;
			// 
			// txtJournalPIN
			// 
			txtJournalPIN.Location = new System.Drawing.Point(28, 2);
			txtJournalPIN.Name = "txtJournalPIN";
			txtJournalPIN.PasswordChar = '*';
			txtJournalPIN.Size = new System.Drawing.Size(100, 23);
			txtJournalPIN.TabIndex = 34;
			txtJournalPIN.TextChanged += this.txtJournalPIN_TextChanged;
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
			lblSelectionType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			lblSelectionType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblSelectionType.Location = new System.Drawing.Point(12, 252);
			lblSelectionType.Name = "lblSelectionType";
			lblSelectionType.Size = new System.Drawing.Size(96, 17);
			lblSelectionType.TabIndex = 9;
			lblSelectionType.Text = "Selected Entry";
			lblSelectionType.Visible = false;
			// 
			// ddlJournals
			// 
			ddlJournals.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			ddlJournals.Enabled = false;
			ddlJournals.FormattingEnabled = true;
			ddlJournals.Location = new System.Drawing.Point(85, 30);
			ddlJournals.Name = "ddlJournals";
			ddlJournals.Size = new System.Drawing.Size(689, 23);
			ddlJournals.TabIndex = 1;
			ddlJournals.SelectedIndexChanged += this.ddlJournals_SelectedIndexChanged;
			ddlJournals.Click += this.ddlJournals_Click;
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
			lstEntries.Location = new System.Drawing.Point(12, 106);
			lstEntries.Name = "lstEntries";
			lstEntries.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			lstEntries.Size = new System.Drawing.Size(762, 123);
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
			rtbSelectedEntry.Size = new System.Drawing.Size(759, 184);
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
			lblSeparator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			lblSeparator.ForeColor = System.Drawing.Color.Red;
			lblSeparator.Location = new System.Drawing.Point(13, 232);
			lblSeparator.Name = "lblSeparator";
			lblSeparator.Size = new System.Drawing.Size(764, 19);
			lblSeparator.TabIndex = 30;
			lblSeparator.Text = resources.GetString("lblSeparator.Text");
			lblSeparator.Visible = false;
			lblSeparator.MouseMove += this.lblSeparator_MouseMove;
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuJournal, mnuLabels, helpToolStripMenuItem, mnuSwitchAccount });
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new System.Drawing.Size(786, 24);
			menuStrip1.TabIndex = 37;
			menuStrip1.Text = "menuStrip1";
			// 
			// mnuJournal
			// 
			mnuJournal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuJournal_Create, mnuJournal_Delete, mnuJournal_Search, mnuJournal_Rename, mnuJournal_ForceBackup, mnuJournal_RestoreBackups, mnuJournal_Import, mnuJournal_Export, mnuJournal_Settings, mnuResetPIN });
			mnuJournal.Name = "mnuJournal";
			mnuJournal.Size = new System.Drawing.Size(77, 20);
			mnuJournal.Text = "&Notebooks";
			// 
			// mnuJournal_Create
			// 
			mnuJournal_Create.Name = "mnuJournal_Create";
			mnuJournal_Create.Size = new System.Drawing.Size(180, 22);
			mnuJournal_Create.Text = "&Create";
			mnuJournal_Create.Click += this.mnuJournal_Create_Click;
			// 
			// mnuJournal_Delete
			// 
			mnuJournal_Delete.Enabled = false;
			mnuJournal_Delete.Name = "mnuJournal_Delete";
			mnuJournal_Delete.Size = new System.Drawing.Size(180, 22);
			mnuJournal_Delete.Text = "Delete";
			mnuJournal_Delete.Click += this.mnuJournal_Delete_Click;
			// 
			// mnuJournal_Search
			// 
			mnuJournal_Search.Name = "mnuJournal_Search";
			mnuJournal_Search.Size = new System.Drawing.Size(180, 22);
			mnuJournal_Search.Text = "&Search";
			mnuJournal_Search.Click += this.mnuJournal_Search_Click;
			// 
			// mnuJournal_Rename
			// 
			mnuJournal_Rename.Enabled = false;
			mnuJournal_Rename.Name = "mnuJournal_Rename";
			mnuJournal_Rename.Size = new System.Drawing.Size(180, 22);
			mnuJournal_Rename.Text = "Rename";
			mnuJournal_Rename.Click += this.mnuJournal_Rename_Click;
			// 
			// mnuJournal_ForceBackup
			// 
			mnuJournal_ForceBackup.Enabled = false;
			mnuJournal_ForceBackup.Name = "mnuJournal_ForceBackup";
			mnuJournal_ForceBackup.Size = new System.Drawing.Size(180, 22);
			mnuJournal_ForceBackup.Text = "Force &Backup";
			mnuJournal_ForceBackup.Visible = false;
			mnuJournal_ForceBackup.Click += this.mnuJournal_ForceBackup_Click;
			// 
			// mnuJournal_RestoreBackups
			// 
			mnuJournal_RestoreBackups.Name = "mnuJournal_RestoreBackups";
			mnuJournal_RestoreBackups.Size = new System.Drawing.Size(180, 22);
			mnuJournal_RestoreBackups.Text = "&Restore Backups";
			mnuJournal_RestoreBackups.Visible = false;
			mnuJournal_RestoreBackups.Click += this.mnuJournal_RestoreBackups_Click;
			// 
			// mnuJournal_Import
			// 
			mnuJournal_Import.Name = "mnuJournal_Import";
			mnuJournal_Import.Size = new System.Drawing.Size(180, 22);
			mnuJournal_Import.Text = "Import";
			mnuJournal_Import.Click += this.mnuJournal_Import_Click;
			// 
			// mnuJournal_Export
			// 
			mnuJournal_Export.Name = "mnuJournal_Export";
			mnuJournal_Export.Size = new System.Drawing.Size(180, 22);
			mnuJournal_Export.Text = "Synch";
			mnuJournal_Export.Visible = false;
			mnuJournal_Export.Click += this.mnuJournal_Export_Click;
			// 
			// mnuJournal_Settings
			// 
			mnuJournal_Settings.Enabled = false;
			mnuJournal_Settings.Name = "mnuJournal_Settings";
			mnuJournal_Settings.Size = new System.Drawing.Size(180, 22);
			mnuJournal_Settings.Text = "Settings";
			mnuJournal_Settings.Click += this.mnuJournal_Settings_Click;
			// 
			// mnuLabels
			// 
			mnuLabels.Name = "mnuLabels";
			mnuLabels.Size = new System.Drawing.Size(52, 20);
			mnuLabels.Text = "Labels";
			mnuLabels.Click += this.mnuLabels_Click;
			// 
			// helpToolStripMenuItem
			// 
			helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuAboutMyJournal });
			helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			helpToolStripMenuItem.Text = "Help";
			// 
			// mnuAboutMyJournal
			// 
			mnuAboutMyJournal.Name = "mnuAboutMyJournal";
			mnuAboutMyJournal.Size = new System.Drawing.Size(165, 22);
			mnuAboutMyJournal.Text = "About MyJournal";
			mnuAboutMyJournal.Click += this.mnuAboutMyJournal_Click;
			// 
			// mnuSwitchAccount
			// 
			mnuSwitchAccount.Name = "mnuSwitchAccount";
			mnuSwitchAccount.Size = new System.Drawing.Size(102, 20);
			mnuSwitchAccount.Text = "Switch Account";
			mnuSwitchAccount.Click += this.mnuSwitchAccount_Click;
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
			lblEntries.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			lblEntries.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblEntries.Location = new System.Drawing.Point(10, 87);
			lblEntries.Name = "lblEntries";
			lblEntries.Size = new System.Drawing.Size(50, 17);
			lblEntries.TabIndex = 39;
			lblEntries.Text = "Entries";
			lblEntries.Visible = false;
			// 
			// lblShowPIN
			// 
			lblShowPIN.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
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
			cbxDatesFrom.Size = new System.Drawing.Size(86, 23);
			cbxDatesFrom.TabIndex = 44;
			cbxDatesFrom.SelectedIndexChanged += this.cbxDates_SelectedIndexChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(1, 7);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(39, 15);
			label2.TabIndex = 41;
			label2.Text = "from: ";
			// 
			// pnlDateFilters
			// 
			pnlDateFilters.Controls.Add(label6);
			pnlDateFilters.Controls.Add(lblEntriesCount);
			pnlDateFilters.Controls.Add(cbxSortEntriesBy);
			pnlDateFilters.Controls.Add(label5);
			pnlDateFilters.Controls.Add(label3);
			pnlDateFilters.Controls.Add(cbxDatesTo);
			pnlDateFilters.Controls.Add(cbxDatesFrom);
			pnlDateFilters.Controls.Add(label2);
			pnlDateFilters.Location = new System.Drawing.Point(260, 58);
			pnlDateFilters.Name = "pnlDateFilters";
			pnlDateFilters.Size = new System.Drawing.Size(489, 27);
			pnlDateFilters.TabIndex = 49;
			pnlDateFilters.Visible = false;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(407, 5);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(77, 15);
			label6.TabIndex = 53;
			label6.Text = "entries found";
			// 
			// lblEntriesCount
			// 
			lblEntriesCount.Location = new System.Drawing.Point(385, 6);
			lblEntriesCount.Name = "lblEntriesCount";
			lblEntriesCount.Size = new System.Drawing.Size(25, 15);
			lblEntriesCount.TabIndex = 41;
			lblEntriesCount.Text = "0";
			lblEntriesCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxSortEntriesBy
			// 
			cbxSortEntriesBy.FormattingEnabled = true;
			cbxSortEntriesBy.Items.AddRange(new object[] { "Created On", "Edited On", "Title" });
			cbxSortEntriesBy.Location = new System.Drawing.Point(288, 2);
			cbxSortEntriesBy.Name = "cbxSortEntriesBy";
			cbxSortEntriesBy.Size = new System.Drawing.Size(91, 23);
			cbxSortEntriesBy.TabIndex = 52;
			cbxSortEntriesBy.Text = "Created On";
			cbxSortEntriesBy.SelectedIndexChanged += this.cbxSortEntriesBy_SelectedIndexChanged;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(242, 7);
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
			cbxDatesTo.Size = new System.Drawing.Size(86, 23);
			cbxDatesTo.TabIndex = 45;
			cbxDatesTo.SelectedIndexChanged += this.cbxDates_SelectedIndexChanged;
			// 
			// pnlPin
			// 
			pnlPin.Controls.Add(btnLoadJournal);
			pnlPin.Controls.Add(label4);
			pnlPin.Controls.Add(lblShowPIN);
			pnlPin.Controls.Add(txtJournalPIN);
			pnlPin.Controls.Add(lblWrongPin);
			pnlPin.Location = new System.Drawing.Point(33, 56);
			pnlPin.Name = "pnlPin";
			pnlPin.Size = new System.Drawing.Size(218, 46);
			pnlPin.TabIndex = 50;
			pnlPin.Visible = false;
			// 
			// mnuResetPIN
			// 
			mnuResetPIN.Name = "mnuResetPIN";
			mnuResetPIN.Size = new System.Drawing.Size(180, 22);
			mnuResetPIN.Text = "Reset &PIN";
			mnuResetPIN.Click += this.mnuResetPIN_Click;
			// 
			// frmMain
			// 
			AcceptButton = btnLoadJournal;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Window;
			ClientSize = new System.Drawing.Size(786, 628);
			Controls.Add(lblEntries);
			Controls.Add(pnlPin);
			Controls.Add(pnlDateFilters);
			Controls.Add(lblSelectionType);
			Controls.Add(lblSeparator);
			Controls.Add(rtbSelectedEntry);
			Controls.Add(lstEntries);
			Controls.Add(label1);
			Controls.Add(ddlJournals);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Name = "frmMain";
			Text = "MyJournal";
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
		private System.Windows.Forms.Button btnLoadJournal;
		private System.Windows.Forms.TextBox txtJournalPIN;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblSelectionType;
		private System.Windows.Forms.ComboBox ddlJournals;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lstEntries;
		private System.Windows.Forms.RichTextBox rtbSelectedEntry;
		private System.Windows.Forms.Label lblSeparator;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mnuJournal;
		private System.Windows.Forms.ToolStripMenuItem mnuJournal_Create;
		private System.Windows.Forms.ToolStripMenuItem mnuJournal_Delete;
		private System.Windows.Forms.ContextMenuStrip mnuEntryTop;
		private System.Windows.Forms.ToolStripMenuItem mnuEntryCreate;
		private System.Windows.Forms.ToolStripMenuItem mnuEntryEdit;
		private System.Windows.Forms.Label lblWrongPin;
		private System.Windows.Forms.ToolStripMenuItem mnuJournal_Search;
		private System.Windows.Forms.Label lblEntries;
		private System.Windows.Forms.ToolStripMenuItem mnuEntryDelete;
		private System.Windows.Forms.Label lblShowPIN;
		private System.Windows.Forms.ComboBox cbxDatesFrom;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel pnlDateFilters;
		private System.Windows.Forms.ToolStripMenuItem mnuPreserveOriginalText;
		private System.Windows.Forms.ToolStripMenuItem mnuDiscardOriginalText;
		private System.Windows.Forms.ToolStripMenuItem mnuJournal_Rename;
		private System.Windows.Forms.ToolStripMenuItem mnuJournal_ForceBackup;
		private System.Windows.Forms.ToolStripMenuItem mnuJournal_RestoreBackups;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbxDatesTo;
		private System.Windows.Forms.ToolStripMenuItem mnuLabels;
		private System.Windows.Forms.Panel pnlPin;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuAboutMyJournal;
		private System.Windows.Forms.ToolStripMenuItem mnuJournal_Import;
		private System.Windows.Forms.ToolStripMenuItem mnuJournal_Export;
		private System.Windows.Forms.ComboBox cbxSortEntriesBy;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ToolStripMenuItem mnuSwitchAccount;
		private System.Windows.Forms.ToolStripMenuItem mnuJournal_Settings;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblEntriesCount;
		private System.Windows.Forms.ToolStripMenuItem mnuResetPIN;
	}
}