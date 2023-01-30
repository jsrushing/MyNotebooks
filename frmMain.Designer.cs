
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.btnLoadJournal = new System.Windows.Forms.Button();
			this.txtJournalPIN = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lblSelectionType = new System.Windows.Forms.Label();
			this.ddlJournals = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lstEntries = new System.Windows.Forms.ListBox();
			this.rtbSelectedEntry = new System.Windows.Forms.RichTextBox();
			this.lblSeparator = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mnuJournal = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuJournal_Create = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuJournal_Delete = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuJournal_Search = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuJournal_Rename = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuJournal_ForceBackup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuJournal_RestoreBackups = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuJournal_Import = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuJournal_Export = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEntryTop = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEntryCreate = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEntryEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuPreserveOriginalText = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDiscardOriginalText = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEntryDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuLabels = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuAboutMyJournal = new System.Windows.Forms.ToolStripMenuItem();
			this.lblWrongPin = new System.Windows.Forms.Label();
			this.lblEntries = new System.Windows.Forms.Label();
			this.lblShowPIN = new System.Windows.Forms.Label();
			this.cbxDatesFrom = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pnlDateFilters = new System.Windows.Forms.Panel();
			this.cbxSortEntriesBy = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbxDatesTo = new System.Windows.Forms.ComboBox();
			this.pnlPin = new System.Windows.Forms.Panel();
			this.menuStrip1.SuspendLayout();
			this.pnlDateFilters.SuspendLayout();
			this.pnlPin.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnLoadJournal
			// 
			this.btnLoadJournal.Location = new System.Drawing.Point(137, 2);
			this.btnLoadJournal.Name = "btnLoadJournal";
			this.btnLoadJournal.Size = new System.Drawing.Size(75, 23);
			this.btnLoadJournal.TabIndex = 36;
			this.btnLoadJournal.Text = "&Load";
			this.btnLoadJournal.UseVisualStyleBackColor = true;
			this.btnLoadJournal.Click += new System.EventHandler(this.btnLoadJournal_Click);
			// 
			// txtJournalPIN
			// 
			this.txtJournalPIN.Location = new System.Drawing.Point(28, 2);
			this.txtJournalPIN.Name = "txtJournalPIN";
			this.txtJournalPIN.PasswordChar = '*';
			this.txtJournalPIN.Size = new System.Drawing.Size(100, 23);
			this.txtJournalPIN.TabIndex = 34;
			this.txtJournalPIN.TextChanged += new System.EventHandler(this.txtJournalPIN_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(1, 5);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(26, 15);
			this.label4.TabIndex = 33;
			this.label4.Text = "PIN";
			// 
			// lblSelectionType
			// 
			this.lblSelectionType.AutoSize = true;
			this.lblSelectionType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblSelectionType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblSelectionType.Location = new System.Drawing.Point(12, 252);
			this.lblSelectionType.Name = "lblSelectionType";
			this.lblSelectionType.Size = new System.Drawing.Size(96, 17);
			this.lblSelectionType.TabIndex = 9;
			this.lblSelectionType.Text = "Selected Entry";
			this.lblSelectionType.Visible = false;
			// 
			// ddlJournals
			// 
			this.ddlJournals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ddlJournals.Enabled = false;
			this.ddlJournals.FormattingEnabled = true;
			this.ddlJournals.Location = new System.Drawing.Point(61, 30);
			this.ddlJournals.Name = "ddlJournals";
			this.ddlJournals.Size = new System.Drawing.Size(939, 23);
			this.ddlJournals.TabIndex = 1;
			this.ddlJournals.SelectedIndexChanged += new System.EventHandler(this.ddlJournals_SelectedIndexChanged);
			this.ddlJournals.Click += new System.EventHandler(this.ddlJournals_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Journal ";
			// 
			// lstEntries
			// 
			this.lstEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstEntries.FormattingEnabled = true;
			this.lstEntries.HorizontalScrollbar = true;
			this.lstEntries.IntegralHeight = false;
			this.lstEntries.ItemHeight = 15;
			this.lstEntries.Location = new System.Drawing.Point(12, 106);
			this.lstEntries.Name = "lstEntries";
			this.lstEntries.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstEntries.Size = new System.Drawing.Size(988, 123);
			this.lstEntries.TabIndex = 8;
			this.lstEntries.Visible = false;
			this.lstEntries.SelectedIndexChanged += new System.EventHandler(this.lstEntries_SelectEntry);
			// 
			// rtbSelectedEntry
			// 
			this.rtbSelectedEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbSelectedEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbSelectedEntry.Location = new System.Drawing.Point(15, 271);
			this.rtbSelectedEntry.Name = "rtbSelectedEntry";
			this.rtbSelectedEntry.Size = new System.Drawing.Size(985, 184);
			this.rtbSelectedEntry.TabIndex = 5;
			this.rtbSelectedEntry.TabStop = false;
			this.rtbSelectedEntry.Text = "";
			this.rtbSelectedEntry.Visible = false;
			this.rtbSelectedEntry.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbSelectedEntry_MouseDown);
			// 
			// lblSeparator
			// 
			this.lblSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSeparator.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.lblSeparator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblSeparator.ForeColor = System.Drawing.Color.Red;
			this.lblSeparator.Location = new System.Drawing.Point(13, 232);
			this.lblSeparator.Name = "lblSeparator";
			this.lblSeparator.Size = new System.Drawing.Size(990, 19);
			this.lblSeparator.TabIndex = 30;
			this.lblSeparator.Text = resources.GetString("lblSeparator.Text");
			this.lblSeparator.Visible = false;
			this.lblSeparator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSeparator_MouseMove);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuJournal,
            this.mnuEntryTop,
            this.mnuLabels,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1012, 24);
			this.menuStrip1.TabIndex = 37;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// mnuJournal
			// 
			this.mnuJournal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuJournal_Create,
            this.mnuJournal_Delete,
            this.mnuJournal_Search,
            this.mnuJournal_Rename,
            this.mnuJournal_ForceBackup,
            this.mnuJournal_RestoreBackups,
            this.mnuJournal_Import,
            this.mnuJournal_Export});
			this.mnuJournal.Name = "mnuJournal";
			this.mnuJournal.Size = new System.Drawing.Size(57, 20);
			this.mnuJournal.Text = "&Journal";
			// 
			// mnuJournal_Create
			// 
			this.mnuJournal_Create.Name = "mnuJournal_Create";
			this.mnuJournal_Create.Size = new System.Drawing.Size(160, 22);
			this.mnuJournal_Create.Text = "&New Journal";
			this.mnuJournal_Create.Click += new System.EventHandler(this.mnuJournal_Create_Click);
			// 
			// mnuJournal_Delete
			// 
			this.mnuJournal_Delete.Enabled = false;
			this.mnuJournal_Delete.Name = "mnuJournal_Delete";
			this.mnuJournal_Delete.Size = new System.Drawing.Size(160, 22);
			this.mnuJournal_Delete.Text = "Delete";
			this.mnuJournal_Delete.Click += new System.EventHandler(this.mnuJournal_Delete_Click);
			// 
			// mnuJournal_Search
			// 
			this.mnuJournal_Search.Enabled = false;
			this.mnuJournal_Search.Name = "mnuJournal_Search";
			this.mnuJournal_Search.Size = new System.Drawing.Size(160, 22);
			this.mnuJournal_Search.Text = "&Search";
			this.mnuJournal_Search.Click += new System.EventHandler(this.mnuJournal_Search_Click);
			// 
			// mnuJournal_Rename
			// 
			this.mnuJournal_Rename.Enabled = false;
			this.mnuJournal_Rename.Name = "mnuJournal_Rename";
			this.mnuJournal_Rename.Size = new System.Drawing.Size(160, 22);
			this.mnuJournal_Rename.Text = "Rename";
			this.mnuJournal_Rename.Click += new System.EventHandler(this.mnuJournal_Rename_Click);
			// 
			// mnuJournal_ForceBackup
			// 
			this.mnuJournal_ForceBackup.Enabled = false;
			this.mnuJournal_ForceBackup.Name = "mnuJournal_ForceBackup";
			this.mnuJournal_ForceBackup.Size = new System.Drawing.Size(160, 22);
			this.mnuJournal_ForceBackup.Text = "Force &Backup";
			this.mnuJournal_ForceBackup.Click += new System.EventHandler(this.mnuJournal_ForceBackup_Click);
			// 
			// mnuJournal_RestoreBackups
			// 
			this.mnuJournal_RestoreBackups.Name = "mnuJournal_RestoreBackups";
			this.mnuJournal_RestoreBackups.Size = new System.Drawing.Size(160, 22);
			this.mnuJournal_RestoreBackups.Text = "&Restore Backups";
			this.mnuJournal_RestoreBackups.Click += new System.EventHandler(this.mnuJournal_RestoreBackups_Click);
			// 
			// mnuJournal_Import
			// 
			this.mnuJournal_Import.Name = "mnuJournal_Import";
			this.mnuJournal_Import.Size = new System.Drawing.Size(160, 22);
			this.mnuJournal_Import.Text = "Import";
			this.mnuJournal_Import.Click += new System.EventHandler(this.mnuJournal_Import_Click);
			// 
			// mnuJournal_Export
			// 
			this.mnuJournal_Export.Name = "mnuJournal_Export";
			this.mnuJournal_Export.Size = new System.Drawing.Size(160, 22);
			this.mnuJournal_Export.Text = "Synch";
			this.mnuJournal_Export.Click += new System.EventHandler(this.mnuJournal_Export_Click);
			// 
			// mnuEntryTop
			// 
			this.mnuEntryTop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEntryCreate,
            this.mnuEntryEdit,
            this.mnuEntryDelete});
			this.mnuEntryTop.Enabled = false;
			this.mnuEntryTop.Name = "mnuEntryTop";
			this.mnuEntryTop.Size = new System.Drawing.Size(46, 20);
			this.mnuEntryTop.Text = "&Entry";
			// 
			// mnuEntryCreate
			// 
			this.mnuEntryCreate.Name = "mnuEntryCreate";
			this.mnuEntryCreate.Size = new System.Drawing.Size(128, 22);
			this.mnuEntryCreate.Text = "&New Entry";
			this.mnuEntryCreate.Click += new System.EventHandler(this.mnuEntryCreate_Click);
			// 
			// mnuEntryEdit
			// 
			this.mnuEntryEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPreserveOriginalText,
            this.mnuDiscardOriginalText});
			this.mnuEntryEdit.Enabled = false;
			this.mnuEntryEdit.Name = "mnuEntryEdit";
			this.mnuEntryEdit.Size = new System.Drawing.Size(128, 22);
			this.mnuEntryEdit.Text = "E&dit";
			this.mnuEntryEdit.Click += new System.EventHandler(this.mnuEntryEdit_Click);
			// 
			// mnuPreserveOriginalText
			// 
			this.mnuPreserveOriginalText.Name = "mnuPreserveOriginalText";
			this.mnuPreserveOriginalText.Size = new System.Drawing.Size(187, 22);
			this.mnuPreserveOriginalText.Text = "Preserve Original Text";
			this.mnuPreserveOriginalText.Click += new System.EventHandler(this.mnuEntryEdit_Click);
			// 
			// mnuDiscardOriginalText
			// 
			this.mnuDiscardOriginalText.Name = "mnuDiscardOriginalText";
			this.mnuDiscardOriginalText.Size = new System.Drawing.Size(187, 22);
			this.mnuDiscardOriginalText.Text = "Edit Original Text";
			this.mnuDiscardOriginalText.Click += new System.EventHandler(this.mnuEntryEdit_Click);
			// 
			// mnuEntryDelete
			// 
			this.mnuEntryDelete.Enabled = false;
			this.mnuEntryDelete.Name = "mnuEntryDelete";
			this.mnuEntryDelete.Size = new System.Drawing.Size(128, 22);
			this.mnuEntryDelete.Text = "Delete";
			this.mnuEntryDelete.Click += new System.EventHandler(this.mnuEntryDelete_Click);
			// 
			// mnuLabels
			// 
			this.mnuLabels.Name = "mnuLabels";
			this.mnuLabels.Size = new System.Drawing.Size(52, 20);
			this.mnuLabels.Text = "Labels";
			this.mnuLabels.Click += new System.EventHandler(this.mnuLabels_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAboutMyJournal});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// mnuAboutMyJournal
			// 
			this.mnuAboutMyJournal.Name = "mnuAboutMyJournal";
			this.mnuAboutMyJournal.Size = new System.Drawing.Size(165, 22);
			this.mnuAboutMyJournal.Text = "About MyJournal";
			this.mnuAboutMyJournal.Click += new System.EventHandler(this.mnuAboutMyJournal_Click);
			// 
			// lblWrongPin
			// 
			this.lblWrongPin.AutoSize = true;
			this.lblWrongPin.ForeColor = System.Drawing.Color.Red;
			this.lblWrongPin.Location = new System.Drawing.Point(99, 84);
			this.lblWrongPin.Name = "lblWrongPin";
			this.lblWrongPin.Size = new System.Drawing.Size(63, 15);
			this.lblWrongPin.TabIndex = 38;
			this.lblWrongPin.Text = "wrong PIN";
			this.lblWrongPin.Visible = false;
			// 
			// lblEntries
			// 
			this.lblEntries.AutoSize = true;
			this.lblEntries.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblEntries.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblEntries.Location = new System.Drawing.Point(10, 87);
			this.lblEntries.Name = "lblEntries";
			this.lblEntries.Size = new System.Drawing.Size(50, 17);
			this.lblEntries.TabIndex = 39;
			this.lblEntries.Text = "Entries";
			this.lblEntries.Visible = false;
			// 
			// lblShowPIN
			// 
			this.lblShowPIN.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			this.lblShowPIN.Location = new System.Drawing.Point(63, 82);
			this.lblShowPIN.Name = "lblShowPIN";
			this.lblShowPIN.Size = new System.Drawing.Size(35, 13);
			this.lblShowPIN.TabIndex = 40;
			this.lblShowPIN.Text = "show";
			this.lblShowPIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblShowPIN.Visible = false;
			this.lblShowPIN.Click += new System.EventHandler(this.lblShowPIN_Click);
			// 
			// cbxDatesFrom
			// 
			this.cbxDatesFrom.FormattingEnabled = true;
			this.cbxDatesFrom.Location = new System.Drawing.Point(39, 2);
			this.cbxDatesFrom.Name = "cbxDatesFrom";
			this.cbxDatesFrom.Size = new System.Drawing.Size(86, 23);
			this.cbxDatesFrom.TabIndex = 44;
			this.cbxDatesFrom.SelectedIndexChanged += new System.EventHandler(this.cbxDates_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 15);
			this.label2.TabIndex = 41;
			this.label2.Text = "from: ";
			// 
			// pnlDateFilters
			// 
			this.pnlDateFilters.Controls.Add(this.cbxSortEntriesBy);
			this.pnlDateFilters.Controls.Add(this.label5);
			this.pnlDateFilters.Controls.Add(this.label3);
			this.pnlDateFilters.Controls.Add(this.cbxDatesTo);
			this.pnlDateFilters.Controls.Add(this.cbxDatesFrom);
			this.pnlDateFilters.Controls.Add(this.label2);
			this.pnlDateFilters.Location = new System.Drawing.Point(257, 57);
			this.pnlDateFilters.Name = "pnlDateFilters";
			this.pnlDateFilters.Size = new System.Drawing.Size(448, 27);
			this.pnlDateFilters.TabIndex = 49;
			this.pnlDateFilters.Visible = false;
			// 
			// cbxSortEntriesBy
			// 
			this.cbxSortEntriesBy.FormattingEnabled = true;
			this.cbxSortEntriesBy.Items.AddRange(new object[] {
            "Created On",
            "Edited On",
            "Title"});
			this.cbxSortEntriesBy.Location = new System.Drawing.Point(288, 2);
			this.cbxSortEntriesBy.Name = "cbxSortEntriesBy";
			this.cbxSortEntriesBy.Size = new System.Drawing.Size(91, 23);
			this.cbxSortEntriesBy.TabIndex = 52;
			this.cbxSortEntriesBy.Text = "Created On";
			this.cbxSortEntriesBy.SelectedIndexChanged += new System.EventHandler(this.cbxSortEntriesBy_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(242, 7);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 15);
			this.label5.TabIndex = 51;
			this.label5.Text = "sort by:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(127, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(18, 15);
			this.label3.TabIndex = 46;
			this.label3.Text = "to";
			// 
			// cbxDatesTo
			// 
			this.cbxDatesTo.FormattingEnabled = true;
			this.cbxDatesTo.Location = new System.Drawing.Point(146, 2);
			this.cbxDatesTo.Name = "cbxDatesTo";
			this.cbxDatesTo.Size = new System.Drawing.Size(86, 23);
			this.cbxDatesTo.TabIndex = 45;
			this.cbxDatesTo.SelectedIndexChanged += new System.EventHandler(this.cbxDates_SelectedIndexChanged);
			// 
			// pnlPin
			// 
			this.pnlPin.Controls.Add(this.btnLoadJournal);
			this.pnlPin.Controls.Add(this.label4);
			this.pnlPin.Controls.Add(this.txtJournalPIN);
			this.pnlPin.Location = new System.Drawing.Point(33, 57);
			this.pnlPin.Name = "pnlPin";
			this.pnlPin.Size = new System.Drawing.Size(218, 27);
			this.pnlPin.TabIndex = 50;
			this.pnlPin.Visible = false;
			// 
			// frmMain
			// 
			this.AcceptButton = this.btnLoadJournal;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(1012, 628);
			this.Controls.Add(this.pnlPin);
			this.Controls.Add(this.pnlDateFilters);
			this.Controls.Add(this.lblShowPIN);
			this.Controls.Add(this.lblEntries);
			this.Controls.Add(this.lblWrongPin);
			this.Controls.Add(this.lblSelectionType);
			this.Controls.Add(this.lblSeparator);
			this.Controls.Add(this.rtbSelectedEntry);
			this.Controls.Add(this.lstEntries);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ddlJournals);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmMain";
			this.Text = "MyJournal";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Resize += new System.EventHandler(this.frmMain_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.pnlDateFilters.ResumeLayout(false);
			this.pnlDateFilters.PerformLayout();
			this.pnlPin.ResumeLayout(false);
			this.pnlPin.PerformLayout();
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
		private System.Windows.Forms.ToolStripMenuItem mnuEntryTop;
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
		private System.Windows.Forms.ToolStripMenuItem falseToolStripMenuItem;
	}
}