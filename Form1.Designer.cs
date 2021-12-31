
namespace myJournal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.ddlJournals = new System.Windows.Forms.ComboBox();
			this.lblCreateEntry = new System.Windows.Forms.Label();
			this.lblFindEntry = new System.Windows.Forms.Label();
			this.grpCreateEntry = new System.Windows.Forms.GroupBox();
			this.lblTagManager2 = new System.Windows.Forms.Label();
			this.lblEntryText_Hidden = new System.Windows.Forms.Label();
			this.lblEntryTitle_Hidden = new System.Windows.Forms.Label();
			this.grpAppendDeleteOriginal = new System.Windows.Forms.GroupBox();
			this.lblDeleteEntry = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.radOriginal_Replace = new System.Windows.Forms.RadioButton();
			this.radOriginal_Append = new System.Windows.Forms.RadioButton();
			this.btnAddEntry = new System.Windows.Forms.Button();
			this.lstTags = new System.Windows.Forms.CheckedListBox();
			this.mnuGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.label14 = new System.Windows.Forms.Label();
			this.lblHome_NewEntry = new System.Windows.Forms.Label();
			this.lblFont_NewEntry = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.rtbNewEntry = new System.Windows.Forms.RichTextBox();
			this.txtNewEntryTitle = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lblAddEntry = new System.Windows.Forms.Label();
			this.grpOpenScreen = new System.Windows.Forms.GroupBox();
			this.lblPrint = new System.Windows.Forms.Label();
			this.pnlMenu = new System.Windows.Forms.Panel();
			this.lblViewJournal = new System.Windows.Forms.Label();
			this.lblCloseMenu = new System.Windows.Forms.Label();
			this.lblSettings_Show = new System.Windows.Forms.Label();
			this.lblTagManager = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.lblJournal_Delete = new System.Windows.Forms.Label();
			this.lblJournal_Create = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.lblEditEntry = new System.Windows.Forms.Label();
			this.lblMenu_1 = new System.Windows.Forms.Label();
			this.lblMenu_0 = new System.Windows.Forms.Label();
			this.lblMenu = new System.Windows.Forms.Label();
			this.lblEntriesStartFrom = new System.Windows.Forms.Label();
			this.rtbSelectedEntry_Main = new System.Windows.Forms.RichTextBox();
			this.lblSelectionType = new System.Windows.Forms.Label();
			this.lstEntries = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.grpFindEntry = new System.Windows.Forms.GroupBox();
			this.lstFoundEntries = new System.Windows.Forms.ListBox();
			this.chkUseDateRange = new System.Windows.Forms.CheckBox();
			this.chkUseDate = new System.Windows.Forms.CheckBox();
			this.label18 = new System.Windows.Forms.Label();
			this.radAllJournals = new System.Windows.Forms.RadioButton();
			this.radCurrentJournal = new System.Windows.Forms.RadioButton();
			this.lstGroupsForSearch = new System.Windows.Forms.CheckedListBox();
			this.txtGroupsForSearch = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.lblClearAll = new System.Windows.Forms.Label();
			this.dtFindDate = new System.Windows.Forms.DateTimePicker();
			this.lblHome = new System.Windows.Forms.Label();
			this.txtSearchText = new System.Windows.Forms.TextBox();
			this.txtSearchTitle = new System.Windows.Forms.TextBox();
			this.dtFindDate_To = new System.Windows.Forms.DateTimePicker();
			this.label12 = new System.Windows.Forms.Label();
			this.dtFindDate_From = new System.Windows.Forms.DateTimePicker();
			this.lblFindEntries = new System.Windows.Forms.Label();
			this.rtbSelectedEntry_Found = new System.Windows.Forms.RichTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.grpNewJournal = new System.Windows.Forms.GroupBox();
			this.lblMessage_BadJournalName = new System.Windows.Forms.Label();
			this.lblHome_NewJrnl = new System.Windows.Forms.Label();
			this.btnOK_NewJrnl = new System.Windows.Forms.Button();
			this.txtNewJournalName = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.grpNewGroup = new System.Windows.Forms.GroupBox();
			this.grpEditTags_NewName = new System.Windows.Forms.GroupBox();
			this.lblBack_EditTag = new System.Windows.Forms.Label();
			this.txtTag_TagName_Edited = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnOK_TagName_Edited = new System.Windows.Forms.Button();
			this.grpEditTags_EditRemove = new System.Windows.Forms.GroupBox();
			this.lblRemoveTag = new System.Windows.Forms.Label();
			this.lblEditTag = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.lstTagsForEdit = new System.Windows.Forms.ListBox();
			this.grpEditTags_Add = new System.Windows.Forms.GroupBox();
			this.txtTags_TagName_NewTag = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.btnOK_TagName_New = new System.Windows.Forms.Button();
			this.lblHome_NewGroup = new System.Windows.Forms.Label();
			this.grpDeleteJournal = new System.Windows.Forms.GroupBox();
			this.lblDelete_Confirm = new System.Windows.Forms.Label();
			this.ddlJournalsToDelete = new System.Windows.Forms.ComboBox();
			this.lblHome_DeleteJournal = new System.Windows.Forms.Label();
			this.btnOK_DeleteJournal = new System.Windows.Forms.Button();
			this.lblJournalToDelete = new System.Windows.Forms.Label();
			this.grpConfirmDeleteEntry = new System.Windows.Forms.GroupBox();
			this.lblMessage_ConfirmEntryDelete = new System.Windows.Forms.Label();
			this.lblBack_ConfirmEntryDelete = new System.Windows.Forms.Label();
			this.btnOK_ConfirmEntryDelete = new System.Windows.Forms.Button();
			this.grpCreateEntry.SuspendLayout();
			this.grpAppendDeleteOriginal.SuspendLayout();
			this.mnuGroups.SuspendLayout();
			this.grpOpenScreen.SuspendLayout();
			this.pnlMenu.SuspendLayout();
			this.grpFindEntry.SuspendLayout();
			this.grpNewJournal.SuspendLayout();
			this.grpNewGroup.SuspendLayout();
			this.grpEditTags_NewName.SuspendLayout();
			this.grpEditTags_EditRemove.SuspendLayout();
			this.grpEditTags_Add.SuspendLayout();
			this.grpDeleteJournal.SuspendLayout();
			this.grpConfirmDeleteEntry.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Journal ";
			// 
			// ddlJournals
			// 
			this.ddlJournals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ddlJournals.FormattingEnabled = true;
			this.ddlJournals.Location = new System.Drawing.Point(55, 36);
			this.ddlJournals.Name = "ddlJournals";
			this.ddlJournals.Size = new System.Drawing.Size(229, 23);
			this.ddlJournals.TabIndex = 1;
			this.ddlJournals.SelectedIndexChanged += new System.EventHandler(this.ddlJournals_SelectedIndexChanged);
			this.ddlJournals.Click += new System.EventHandler(this.ddlJournals_Click);
			// 
			// lblCreateEntry
			// 
			this.lblCreateEntry.AutoSize = true;
			this.lblCreateEntry.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblCreateEntry.Enabled = false;
			this.lblCreateEntry.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblCreateEntry.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblCreateEntry.Location = new System.Drawing.Point(17, 103);
			this.lblCreateEntry.Name = "lblCreateEntry";
			this.lblCreateEntry.Size = new System.Drawing.Size(42, 15);
			this.lblCreateEntry.TabIndex = 2;
			this.lblCreateEntry.Text = "Create";
			this.lblCreateEntry.Click += new System.EventHandler(this.lblCreateEntry_Click);
			this.lblCreateEntry.MouseEnter += new System.EventHandler(this.MenuItem_Enter);
			this.lblCreateEntry.MouseLeave += new System.EventHandler(this.MenuItem_Leave);
			// 
			// lblFindEntry
			// 
			this.lblFindEntry.AutoSize = true;
			this.lblFindEntry.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblFindEntry.Enabled = false;
			this.lblFindEntry.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblFindEntry.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblFindEntry.Location = new System.Drawing.Point(17, 143);
			this.lblFindEntry.Name = "lblFindEntry";
			this.lblFindEntry.Size = new System.Drawing.Size(30, 15);
			this.lblFindEntry.TabIndex = 3;
			this.lblFindEntry.Text = "Find";
			this.lblFindEntry.Click += new System.EventHandler(this.lblFindEntry_Click);
			this.lblFindEntry.MouseEnter += new System.EventHandler(this.MenuItem_Enter);
			this.lblFindEntry.MouseLeave += new System.EventHandler(this.MenuItem_Leave);
			// 
			// grpCreateEntry
			// 
			this.grpCreateEntry.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.grpCreateEntry.Controls.Add(this.lblTagManager2);
			this.grpCreateEntry.Controls.Add(this.lblEntryText_Hidden);
			this.grpCreateEntry.Controls.Add(this.lblEntryTitle_Hidden);
			this.grpCreateEntry.Controls.Add(this.grpAppendDeleteOriginal);
			this.grpCreateEntry.Controls.Add(this.btnAddEntry);
			this.grpCreateEntry.Controls.Add(this.lstTags);
			this.grpCreateEntry.Controls.Add(this.label14);
			this.grpCreateEntry.Controls.Add(this.lblHome_NewEntry);
			this.grpCreateEntry.Controls.Add(this.lblFont_NewEntry);
			this.grpCreateEntry.Controls.Add(this.label3);
			this.grpCreateEntry.Controls.Add(this.rtbNewEntry);
			this.grpCreateEntry.Controls.Add(this.txtNewEntryTitle);
			this.grpCreateEntry.Controls.Add(this.label2);
			this.grpCreateEntry.Location = new System.Drawing.Point(386, 0);
			this.grpCreateEntry.Name = "grpCreateEntry";
			this.grpCreateEntry.Size = new System.Drawing.Size(290, 545);
			this.grpCreateEntry.TabIndex = 4;
			this.grpCreateEntry.TabStop = false;
			// 
			// lblTagManager2
			// 
			this.lblTagManager2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblTagManager2.AutoSize = true;
			this.lblTagManager2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblTagManager2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblTagManager2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblTagManager2.Location = new System.Drawing.Point(37, 400);
			this.lblTagManager2.Name = "lblTagManager2";
			this.lblTagManager2.Size = new System.Drawing.Size(48, 15);
			this.lblTagManager2.TabIndex = 36;
			this.lblTagManager2.Text = "Manage";
			this.lblTagManager2.Click += new System.EventHandler(this.lblTagManager_Click);
			// 
			// lblEntryText_Hidden
			// 
			this.lblEntryText_Hidden.AutoSize = true;
			this.lblEntryText_Hidden.Location = new System.Drawing.Point(77, 527);
			this.lblEntryText_Hidden.Name = "lblEntryText_Hidden";
			this.lblEntryText_Hidden.Size = new System.Drawing.Size(67, 15);
			this.lblEntryText_Hidden.TabIndex = 35;
			this.lblEntryText_Hidden.Text = "hidden text";
			this.lblEntryText_Hidden.Visible = false;
			// 
			// lblEntryTitle_Hidden
			// 
			this.lblEntryTitle_Hidden.AutoSize = true;
			this.lblEntryTitle_Hidden.Location = new System.Drawing.Point(4, 527);
			this.lblEntryTitle_Hidden.Name = "lblEntryTitle_Hidden";
			this.lblEntryTitle_Hidden.Size = new System.Drawing.Size(67, 15);
			this.lblEntryTitle_Hidden.TabIndex = 34;
			this.lblEntryTitle_Hidden.Text = "hidden title";
			this.lblEntryTitle_Hidden.Visible = false;
			// 
			// grpAppendDeleteOriginal
			// 
			this.grpAppendDeleteOriginal.Controls.Add(this.lblDeleteEntry);
			this.grpAppendDeleteOriginal.Controls.Add(this.label6);
			this.grpAppendDeleteOriginal.Controls.Add(this.radOriginal_Replace);
			this.grpAppendDeleteOriginal.Controls.Add(this.radOriginal_Append);
			this.grpAppendDeleteOriginal.Location = new System.Drawing.Point(46, 0);
			this.grpAppendDeleteOriginal.Name = "grpAppendDeleteOriginal";
			this.grpAppendDeleteOriginal.Size = new System.Drawing.Size(244, 34);
			this.grpAppendDeleteOriginal.TabIndex = 33;
			this.grpAppendDeleteOriginal.TabStop = false;
			this.grpAppendDeleteOriginal.Visible = false;
			// 
			// lblDeleteEntry
			// 
			this.lblDeleteEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDeleteEntry.AutoSize = true;
			this.lblDeleteEntry.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblDeleteEntry.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblDeleteEntry.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblDeleteEntry.Location = new System.Drawing.Point(195, 11);
			this.lblDeleteEntry.Name = "lblDeleteEntry";
			this.lblDeleteEntry.Size = new System.Drawing.Size(43, 15);
			this.lblDeleteEntry.TabIndex = 29;
			this.lblDeleteEntry.Text = "delete";
			this.lblDeleteEntry.Click += new System.EventHandler(this.lblDeleteEntry_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(4, 13);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 15);
			this.label6.TabIndex = 32;
			this.label6.Text = "original:";
			// 
			// radOriginal_Replace
			// 
			this.radOriginal_Replace.AutoSize = true;
			this.radOriginal_Replace.Location = new System.Drawing.Point(121, 11);
			this.radOriginal_Replace.Name = "radOriginal_Replace";
			this.radOriginal_Replace.Size = new System.Drawing.Size(63, 19);
			this.radOriginal_Replace.TabIndex = 31;
			this.radOriginal_Replace.Text = "replace";
			this.radOriginal_Replace.UseVisualStyleBackColor = true;
			// 
			// radOriginal_Append
			// 
			this.radOriginal_Append.AutoSize = true;
			this.radOriginal_Append.Checked = true;
			this.radOriginal_Append.Location = new System.Drawing.Point(58, 11);
			this.radOriginal_Append.Name = "radOriginal_Append";
			this.radOriginal_Append.Size = new System.Drawing.Size(65, 19);
			this.radOriginal_Append.TabIndex = 30;
			this.radOriginal_Append.TabStop = true;
			this.radOriginal_Append.Text = "append";
			this.radOriginal_Append.UseVisualStyleBackColor = true;
			// 
			// btnAddEntry
			// 
			this.btnAddEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddEntry.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnAddEntry.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnAddEntry.Location = new System.Drawing.Point(190, 520);
			this.btnAddEntry.Name = "btnAddEntry";
			this.btnAddEntry.Size = new System.Drawing.Size(94, 20);
			this.btnAddEntry.TabIndex = 28;
			this.btnAddEntry.Text = "Add This Entry";
			this.btnAddEntry.UseVisualStyleBackColor = false;
			this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
			// 
			// lstTags
			// 
			this.lstTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstTags.CheckOnClick = true;
			this.lstTags.ContextMenuStrip = this.mnuGroups;
			this.lstTags.FormattingEnabled = true;
			this.lstTags.Location = new System.Drawing.Point(6, 420);
			this.lstTags.Name = "lstTags";
			this.lstTags.Size = new System.Drawing.Size(278, 94);
			this.lstTags.TabIndex = 27;
			// 
			// mnuGroups
			// 
			this.mnuGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.mnuDelete});
			this.mnuGroups.Name = "mnuGroups";
			this.mnuGroups.Size = new System.Drawing.Size(108, 48);
			this.mnuGroups.Opening += new System.ComponentModel.CancelEventHandler(this.Tags_mnuTags_Opening);
			// 
			// mnuEdit
			// 
			this.mnuEdit.Name = "mnuEdit";
			this.mnuEdit.Size = new System.Drawing.Size(107, 22);
			this.mnuEdit.Text = "Edit";
			this.mnuEdit.Click += new System.EventHandler(this.Tags_mnuEdit_Click);
			// 
			// mnuDelete
			// 
			this.mnuDelete.Name = "mnuDelete";
			this.mnuDelete.Size = new System.Drawing.Size(107, 22);
			this.mnuDelete.Text = "Delete";
			this.mnuDelete.Click += new System.EventHandler(this.Tags_mnuDelete_Click);
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(6, 400);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(29, 15);
			this.label14.TabIndex = 25;
			this.label14.Text = "tags";
			// 
			// lblHome_NewEntry
			// 
			this.lblHome_NewEntry.AutoSize = true;
			this.lblHome_NewEntry.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblHome_NewEntry.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblHome_NewEntry.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblHome_NewEntry.Location = new System.Drawing.Point(6, 11);
			this.lblHome_NewEntry.Name = "lblHome_NewEntry";
			this.lblHome_NewEntry.Size = new System.Drawing.Size(33, 15);
			this.lblHome_NewEntry.TabIndex = 24;
			this.lblHome_NewEntry.Text = "back";
			this.lblHome_NewEntry.Click += new System.EventHandler(this.lblHome_Click);
			// 
			// lblFont_NewEntry
			// 
			this.lblFont_NewEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFont_NewEntry.AutoSize = true;
			this.lblFont_NewEntry.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblFont_NewEntry.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblFont_NewEntry.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblFont_NewEntry.Location = new System.Drawing.Point(249, 70);
			this.lblFont_NewEntry.Name = "lblFont_NewEntry";
			this.lblFont_NewEntry.Size = new System.Drawing.Size(31, 15);
			this.lblFont_NewEntry.TabIndex = 5;
			this.lblFont_NewEntry.Text = "font";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "Entry";
			// 
			// rtbNewEntry
			// 
			this.rtbNewEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbNewEntry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.rtbNewEntry.Location = new System.Drawing.Point(6, 87);
			this.rtbNewEntry.Name = "rtbNewEntry";
			this.rtbNewEntry.Size = new System.Drawing.Size(278, 308);
			this.rtbNewEntry.TabIndex = 2;
			this.rtbNewEntry.Text = "";
			// 
			// txtNewEntryTitle
			// 
			this.txtNewEntryTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNewEntryTitle.Location = new System.Drawing.Point(38, 34);
			this.txtNewEntryTitle.Name = "txtNewEntryTitle";
			this.txtNewEntryTitle.Size = new System.Drawing.Size(240, 23);
			this.txtNewEntryTitle.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 15);
			this.label2.TabIndex = 0;
			this.label2.Text = "Title ";
			// 
			// lblAddEntry
			// 
			this.lblAddEntry.Location = new System.Drawing.Point(0, 0);
			this.lblAddEntry.Name = "lblAddEntry";
			this.lblAddEntry.Size = new System.Drawing.Size(100, 23);
			this.lblAddEntry.TabIndex = 27;
			// 
			// grpOpenScreen
			// 
			this.grpOpenScreen.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.grpOpenScreen.Controls.Add(this.lblPrint);
			this.grpOpenScreen.Controls.Add(this.pnlMenu);
			this.grpOpenScreen.Controls.Add(this.lblMenu);
			this.grpOpenScreen.Controls.Add(this.lblEntriesStartFrom);
			this.grpOpenScreen.Controls.Add(this.rtbSelectedEntry_Main);
			this.grpOpenScreen.Controls.Add(this.ddlJournals);
			this.grpOpenScreen.Controls.Add(this.label1);
			this.grpOpenScreen.Controls.Add(this.lblSelectionType);
			this.grpOpenScreen.Controls.Add(this.lstEntries);
			this.grpOpenScreen.Controls.Add(this.label4);
			this.grpOpenScreen.Location = new System.Drawing.Point(61, 0);
			this.grpOpenScreen.Name = "grpOpenScreen";
			this.grpOpenScreen.Size = new System.Drawing.Size(290, 545);
			this.grpOpenScreen.TabIndex = 5;
			this.grpOpenScreen.TabStop = false;
			// 
			// lblPrint
			// 
			this.lblPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPrint.AutoSize = true;
			this.lblPrint.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblPrint.Enabled = false;
			this.lblPrint.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblPrint.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblPrint.Location = new System.Drawing.Point(242, 257);
			this.lblPrint.Name = "lblPrint";
			this.lblPrint.Size = new System.Drawing.Size(34, 15);
			this.lblPrint.TabIndex = 29;
			this.lblPrint.Text = "print";
			this.lblPrint.Click += new System.EventHandler(this.lblPrint_Click);
			// 
			// pnlMenu
			// 
			this.pnlMenu.BackColor = System.Drawing.SystemColors.HighlightText;
			this.pnlMenu.Controls.Add(this.lblViewJournal);
			this.pnlMenu.Controls.Add(this.lblCloseMenu);
			this.pnlMenu.Controls.Add(this.lblSettings_Show);
			this.pnlMenu.Controls.Add(this.lblTagManager);
			this.pnlMenu.Controls.Add(this.label21);
			this.pnlMenu.Controls.Add(this.lblJournal_Delete);
			this.pnlMenu.Controls.Add(this.lblJournal_Create);
			this.pnlMenu.Controls.Add(this.label15);
			this.pnlMenu.Controls.Add(this.lblCreateEntry);
			this.pnlMenu.Controls.Add(this.lblEditEntry);
			this.pnlMenu.Controls.Add(this.lblFindEntry);
			this.pnlMenu.Controls.Add(this.lblMenu_1);
			this.pnlMenu.Controls.Add(this.lblMenu_0);
			this.pnlMenu.Location = new System.Drawing.Point(34, 29);
			this.pnlMenu.Name = "pnlMenu";
			this.pnlMenu.Size = new System.Drawing.Size(175, 293);
			this.pnlMenu.TabIndex = 28;
			this.pnlMenu.Visible = false;
			// 
			// lblViewJournal
			// 
			this.lblViewJournal.AutoSize = true;
			this.lblViewJournal.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblViewJournal.Enabled = false;
			this.lblViewJournal.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblViewJournal.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblViewJournal.Location = new System.Drawing.Point(17, 63);
			this.lblViewJournal.Name = "lblViewJournal";
			this.lblViewJournal.Size = new System.Drawing.Size(73, 15);
			this.lblViewJournal.TabIndex = 26;
			this.lblViewJournal.Text = "View Entries";
			this.lblViewJournal.Click += new System.EventHandler(this.lblViewJournal_Click);
			this.lblViewJournal.MouseEnter += new System.EventHandler(this.MenuItem_Enter);
			this.lblViewJournal.MouseLeave += new System.EventHandler(this.MenuItem_Leave);
			// 
			// lblCloseMenu
			// 
			this.lblCloseMenu.AutoSize = true;
			this.lblCloseMenu.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblCloseMenu.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblCloseMenu.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblCloseMenu.Location = new System.Drawing.Point(9, 203);
			this.lblCloseMenu.Name = "lblCloseMenu";
			this.lblCloseMenu.Size = new System.Drawing.Size(70, 15);
			this.lblCloseMenu.TabIndex = 24;
			this.lblCloseMenu.Text = "Close Menu";
			this.lblCloseMenu.Click += new System.EventHandler(this.lblCloseMenu_Click);
			this.lblCloseMenu.MouseEnter += new System.EventHandler(this.MenuItem_Enter);
			this.lblCloseMenu.MouseLeave += new System.EventHandler(this.MenuItem_Leave);
			// 
			// lblSettings_Show
			// 
			this.lblSettings_Show.AutoSize = true;
			this.lblSettings_Show.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblSettings_Show.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblSettings_Show.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblSettings_Show.Location = new System.Drawing.Point(9, 183);
			this.lblSettings_Show.Name = "lblSettings_Show";
			this.lblSettings_Show.Size = new System.Drawing.Size(50, 15);
			this.lblSettings_Show.TabIndex = 21;
			this.lblSettings_Show.Text = "Settings";
			this.lblSettings_Show.Click += new System.EventHandler(this.lblSettings_Show_Click);
			this.lblSettings_Show.MouseEnter += new System.EventHandler(this.MenuItem_Enter);
			this.lblSettings_Show.MouseLeave += new System.EventHandler(this.MenuItem_Leave);
			// 
			// lblTagManager
			// 
			this.lblTagManager.AutoSize = true;
			this.lblTagManager.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblTagManager.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblTagManager.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblTagManager.Location = new System.Drawing.Point(9, 163);
			this.lblTagManager.Name = "lblTagManager";
			this.lblTagManager.Size = new System.Drawing.Size(77, 15);
			this.lblTagManager.TabIndex = 19;
			this.lblTagManager.Text = "Manage Tags";
			this.lblTagManager.Click += new System.EventHandler(this.lblTagManager_Click);
			this.lblTagManager.MouseEnter += new System.EventHandler(this.MenuItem_Enter);
			this.lblTagManager.MouseLeave += new System.EventHandler(this.MenuItem_Leave);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label21.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.label21.Location = new System.Drawing.Point(9, 83);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(45, 15);
			this.label21.TabIndex = 17;
			this.label21.Text = "Entries";
			// 
			// lblJournal_Delete
			// 
			this.lblJournal_Delete.AutoSize = true;
			this.lblJournal_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblJournal_Delete.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblJournal_Delete.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblJournal_Delete.Location = new System.Drawing.Point(17, 43);
			this.lblJournal_Delete.Name = "lblJournal_Delete";
			this.lblJournal_Delete.Size = new System.Drawing.Size(43, 15);
			this.lblJournal_Delete.TabIndex = 16;
			this.lblJournal_Delete.Text = "Delete";
			this.lblJournal_Delete.Click += new System.EventHandler(this.lblJournal_Delete_Click);
			this.lblJournal_Delete.MouseEnter += new System.EventHandler(this.MenuItem_Enter);
			this.lblJournal_Delete.MouseLeave += new System.EventHandler(this.MenuItem_Leave);
			// 
			// lblJournal_Create
			// 
			this.lblJournal_Create.AutoSize = true;
			this.lblJournal_Create.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblJournal_Create.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblJournal_Create.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblJournal_Create.Location = new System.Drawing.Point(17, 23);
			this.lblJournal_Create.Name = "lblJournal_Create";
			this.lblJournal_Create.Size = new System.Drawing.Size(42, 15);
			this.lblJournal_Create.TabIndex = 15;
			this.lblJournal_Create.Text = "Create";
			this.lblJournal_Create.Click += new System.EventHandler(this.lblJournal_Create_Click);
			this.lblJournal_Create.MouseEnter += new System.EventHandler(this.MenuItem_Enter);
			this.lblJournal_Create.MouseLeave += new System.EventHandler(this.MenuItem_Leave);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.label15.Location = new System.Drawing.Point(9, 8);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(52, 15);
			this.label15.TabIndex = 14;
			this.label15.Text = "Journals";
			// 
			// lblEditEntry
			// 
			this.lblEditEntry.AutoSize = true;
			this.lblEditEntry.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblEditEntry.Enabled = false;
			this.lblEditEntry.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblEditEntry.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblEditEntry.Location = new System.Drawing.Point(17, 123);
			this.lblEditEntry.Name = "lblEditEntry";
			this.lblEditEntry.Size = new System.Drawing.Size(67, 15);
			this.lblEditEntry.TabIndex = 13;
			this.lblEditEntry.Text = "Edit/Delete";
			this.lblEditEntry.Click += new System.EventHandler(this.lblEditEntry_Click);
			this.lblEditEntry.MouseEnter += new System.EventHandler(this.MenuItem_Enter);
			this.lblEditEntry.MouseLeave += new System.EventHandler(this.MenuItem_Leave);
			// 
			// lblMenu_1
			// 
			this.lblMenu_1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.lblMenu_1.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lblMenu_1.Location = new System.Drawing.Point(3, 3);
			this.lblMenu_1.Name = "lblMenu_1";
			this.lblMenu_1.Size = new System.Drawing.Size(110, 244);
			this.lblMenu_1.TabIndex = 23;
			// 
			// lblMenu_0
			// 
			this.lblMenu_0.BackColor = System.Drawing.SystemColors.ControlText;
			this.lblMenu_0.Location = new System.Drawing.Point(0, 0);
			this.lblMenu_0.Name = "lblMenu_0";
			this.lblMenu_0.Size = new System.Drawing.Size(132, 260);
			this.lblMenu_0.TabIndex = 22;
			// 
			// lblMenu
			// 
			this.lblMenu.AutoSize = true;
			this.lblMenu.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblMenu.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblMenu.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblMenu.Location = new System.Drawing.Point(4, 11);
			this.lblMenu.Name = "lblMenu";
			this.lblMenu.Size = new System.Drawing.Size(39, 15);
			this.lblMenu.TabIndex = 28;
			this.lblMenu.Text = "menu";
			this.lblMenu.Click += new System.EventHandler(this.lblMenu_Click);
			// 
			// lblEntriesStartFrom
			// 
			this.lblEntriesStartFrom.AutoSize = true;
			this.lblEntriesStartFrom.Location = new System.Drawing.Point(54, 77);
			this.lblEntriesStartFrom.Name = "lblEntriesStartFrom";
			this.lblEntriesStartFrom.Size = new System.Drawing.Size(108, 15);
			this.lblEntriesStartFrom.TabIndex = 10;
			this.lblEntriesStartFrom.Text = "(from 2 weeks ago)";
			// 
			// rtbSelectedEntry_Main
			// 
			this.rtbSelectedEntry_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbSelectedEntry_Main.Location = new System.Drawing.Point(6, 275);
			this.rtbSelectedEntry_Main.Name = "rtbSelectedEntry_Main";
			this.rtbSelectedEntry_Main.Size = new System.Drawing.Size(278, 264);
			this.rtbSelectedEntry_Main.TabIndex = 5;
			this.rtbSelectedEntry_Main.TabStop = false;
			this.rtbSelectedEntry_Main.Text = "";
			this.rtbSelectedEntry_Main.Click += new System.EventHandler(this.rtbSelectedEntry_Main_Click);
			// 
			// lblSelectionType
			// 
			this.lblSelectionType.AutoSize = true;
			this.lblSelectionType.Location = new System.Drawing.Point(6, 258);
			this.lblSelectionType.Name = "lblSelectionType";
			this.lblSelectionType.Size = new System.Drawing.Size(54, 15);
			this.lblSelectionType.TabIndex = 9;
			this.lblSelectionType.Text = "Selected ";
			// 
			// lstEntries
			// 
			this.lstEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstEntries.FormattingEnabled = true;
			this.lstEntries.HorizontalScrollbar = true;
			this.lstEntries.ItemHeight = 15;
			this.lstEntries.Location = new System.Drawing.Point(6, 95);
			this.lstEntries.Name = "lstEntries";
			this.lstEntries.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstEntries.Size = new System.Drawing.Size(278, 154);
			this.lstEntries.TabIndex = 8;
			this.lstEntries.SelectedIndexChanged += new System.EventHandler(this.ListOfEntries_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 78);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 15);
			this.label4.TabIndex = 7;
			this.label4.Text = "Entries";
			// 
			// grpFindEntry
			// 
			this.grpFindEntry.Controls.Add(this.lstFoundEntries);
			this.grpFindEntry.Controls.Add(this.chkUseDateRange);
			this.grpFindEntry.Controls.Add(this.chkUseDate);
			this.grpFindEntry.Controls.Add(this.label18);
			this.grpFindEntry.Controls.Add(this.radAllJournals);
			this.grpFindEntry.Controls.Add(this.radCurrentJournal);
			this.grpFindEntry.Controls.Add(this.lstGroupsForSearch);
			this.grpFindEntry.Controls.Add(this.txtGroupsForSearch);
			this.grpFindEntry.Controls.Add(this.label17);
			this.grpFindEntry.Controls.Add(this.lblClearAll);
			this.grpFindEntry.Controls.Add(this.dtFindDate);
			this.grpFindEntry.Controls.Add(this.lblHome);
			this.grpFindEntry.Controls.Add(this.txtSearchText);
			this.grpFindEntry.Controls.Add(this.txtSearchTitle);
			this.grpFindEntry.Controls.Add(this.dtFindDate_To);
			this.grpFindEntry.Controls.Add(this.label12);
			this.grpFindEntry.Controls.Add(this.dtFindDate_From);
			this.grpFindEntry.Controls.Add(this.lblFindEntries);
			this.grpFindEntry.Controls.Add(this.rtbSelectedEntry_Found);
			this.grpFindEntry.Controls.Add(this.label9);
			this.grpFindEntry.Controls.Add(this.label10);
			this.grpFindEntry.Controls.Add(this.label8);
			this.grpFindEntry.Controls.Add(this.label11);
			this.grpFindEntry.Location = new System.Drawing.Point(705, 13);
			this.grpFindEntry.Name = "grpFindEntry";
			this.grpFindEntry.Size = new System.Drawing.Size(290, 545);
			this.grpFindEntry.TabIndex = 6;
			this.grpFindEntry.TabStop = false;
			// 
			// lstFoundEntries
			// 
			this.lstFoundEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstFoundEntries.FormattingEnabled = true;
			this.lstFoundEntries.ItemHeight = 15;
			this.lstFoundEntries.Location = new System.Drawing.Point(6, 205);
			this.lstFoundEntries.Name = "lstFoundEntries";
			this.lstFoundEntries.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstFoundEntries.Size = new System.Drawing.Size(278, 109);
			this.lstFoundEntries.TabIndex = 14;
			this.lstFoundEntries.SelectedIndexChanged += new System.EventHandler(this.ListOfEntries_SelectedIndexChanged);
			// 
			// chkUseDateRange
			// 
			this.chkUseDateRange.AutoSize = true;
			this.chkUseDateRange.Location = new System.Drawing.Point(50, 12);
			this.chkUseDateRange.Name = "chkUseDateRange";
			this.chkUseDateRange.Size = new System.Drawing.Size(103, 19);
			this.chkUseDateRange.TabIndex = 34;
			this.chkUseDateRange.Text = "use date range";
			this.chkUseDateRange.UseVisualStyleBackColor = true;
			this.chkUseDateRange.CheckedChanged += new System.EventHandler(this.ToggleDateUse);
			// 
			// chkUseDate
			// 
			this.chkUseDate.AutoSize = true;
			this.chkUseDate.Location = new System.Drawing.Point(206, 13);
			this.chkUseDate.Name = "chkUseDate";
			this.chkUseDate.Size = new System.Drawing.Size(70, 19);
			this.chkUseDate.TabIndex = 33;
			this.chkUseDate.Text = "use date";
			this.chkUseDate.UseVisualStyleBackColor = true;
			this.chkUseDate.CheckedChanged += new System.EventHandler(this.ToggleDateUse);
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(3, 63);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(55, 15);
			this.label18.TabIndex = 32;
			this.label18.Text = "Search in";
			// 
			// radAllJournals
			// 
			this.radAllJournals.AutoSize = true;
			this.radAllJournals.Location = new System.Drawing.Point(197, 61);
			this.radAllJournals.Name = "radAllJournals";
			this.radAllJournals.Size = new System.Drawing.Size(82, 19);
			this.radAllJournals.TabIndex = 31;
			this.radAllJournals.Text = "all journals";
			this.radAllJournals.UseVisualStyleBackColor = true;
			// 
			// radCurrentJournal
			// 
			this.radCurrentJournal.AutoSize = true;
			this.radCurrentJournal.Checked = true;
			this.radCurrentJournal.Location = new System.Drawing.Point(64, 61);
			this.radCurrentJournal.Name = "radCurrentJournal";
			this.radCurrentJournal.Size = new System.Drawing.Size(129, 19);
			this.radCurrentJournal.TabIndex = 30;
			this.radCurrentJournal.TabStop = true;
			this.radCurrentJournal.Text = "current journal only";
			this.radCurrentJournal.UseVisualStyleBackColor = true;
			// 
			// lstGroupsForSearch
			// 
			this.lstGroupsForSearch.CheckOnClick = true;
			this.lstGroupsForSearch.ContextMenuStrip = this.mnuGroups;
			this.lstGroupsForSearch.FormattingEnabled = true;
			this.lstGroupsForSearch.Location = new System.Drawing.Point(41, 108);
			this.lstGroupsForSearch.Name = "lstGroupsForSearch";
			this.lstGroupsForSearch.Size = new System.Drawing.Size(213, 76);
			this.lstGroupsForSearch.TabIndex = 29;
			this.lstGroupsForSearch.Visible = false;
			this.lstGroupsForSearch.SelectedIndexChanged += new System.EventHandler(this.lstGroupsForSearch_SelectedIndexChanged);
			// 
			// txtGroupsForSearch
			// 
			this.txtGroupsForSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtGroupsForSearch.Location = new System.Drawing.Point(41, 86);
			this.txtGroupsForSearch.Name = "txtGroupsForSearch";
			this.txtGroupsForSearch.Size = new System.Drawing.Size(243, 23);
			this.txtGroupsForSearch.TabIndex = 27;
			this.txtGroupsForSearch.Click += new System.EventHandler(this.txtGroupsForSearch_Click);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(4, 89);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(37, 15);
			this.label17.TabIndex = 26;
			this.label17.Text = "tag(s)";
			// 
			// lblClearAll
			// 
			this.lblClearAll.AutoSize = true;
			this.lblClearAll.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblClearAll.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblClearAll.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblClearAll.Location = new System.Drawing.Point(224, 175);
			this.lblClearAll.Name = "lblClearAll";
			this.lblClearAll.Size = new System.Drawing.Size(52, 15);
			this.lblClearAll.TabIndex = 24;
			this.lblClearAll.Text = "Clear All";
			this.lblClearAll.Click += new System.EventHandler(this.lblClearSearchCriteria_Click);
			// 
			// dtFindDate
			// 
			this.dtFindDate.CustomFormat = "M/d/yyyy";
			this.dtFindDate.Enabled = false;
			this.dtFindDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtFindDate.Location = new System.Drawing.Point(201, 33);
			this.dtFindDate.Name = "dtFindDate";
			this.dtFindDate.ShowUpDown = true;
			this.dtFindDate.Size = new System.Drawing.Size(79, 23);
			this.dtFindDate.TabIndex = 17;
			this.dtFindDate.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// lblHome
			// 
			this.lblHome.AutoSize = true;
			this.lblHome.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblHome.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblHome.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblHome.Location = new System.Drawing.Point(3, 12);
			this.lblHome.Name = "lblHome";
			this.lblHome.Size = new System.Drawing.Size(33, 15);
			this.lblHome.TabIndex = 23;
			this.lblHome.Text = "back";
			this.lblHome.Click += new System.EventHandler(this.lblHome_Click);
			// 
			// txtSearchText
			// 
			this.txtSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearchText.Location = new System.Drawing.Point(85, 143);
			this.txtSearchText.Name = "txtSearchText";
			this.txtSearchText.Size = new System.Drawing.Size(199, 23);
			this.txtSearchText.TabIndex = 22;
			// 
			// txtSearchTitle
			// 
			this.txtSearchTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearchTitle.Location = new System.Drawing.Point(85, 114);
			this.txtSearchTitle.Name = "txtSearchTitle";
			this.txtSearchTitle.Size = new System.Drawing.Size(199, 23);
			this.txtSearchTitle.TabIndex = 21;
			// 
			// dtFindDate_To
			// 
			this.dtFindDate_To.CustomFormat = "M/d/yyyy";
			this.dtFindDate_To.Enabled = false;
			this.dtFindDate_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtFindDate_To.Location = new System.Drawing.Point(107, 32);
			this.dtFindDate_To.Name = "dtFindDate_To";
			this.dtFindDate_To.ShowUpDown = true;
			this.dtFindDate_To.Size = new System.Drawing.Size(79, 23);
			this.dtFindDate_To.TabIndex = 20;
			this.dtFindDate_To.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(174, 36);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(18, 15);
			this.label12.TabIndex = 19;
			this.label12.Text = "to";
			// 
			// dtFindDate_From
			// 
			this.dtFindDate_From.CustomFormat = "M/d/yyyy";
			this.dtFindDate_From.Enabled = false;
			this.dtFindDate_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtFindDate_From.Location = new System.Drawing.Point(18, 32);
			this.dtFindDate_From.Name = "dtFindDate_From";
			this.dtFindDate_From.ShowUpDown = true;
			this.dtFindDate_From.Size = new System.Drawing.Size(79, 23);
			this.dtFindDate_From.TabIndex = 18;
			this.dtFindDate_From.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// lblFindEntries
			// 
			this.lblFindEntries.AutoSize = true;
			this.lblFindEntries.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblFindEntries.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblFindEntries.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblFindEntries.Location = new System.Drawing.Point(118, 175);
			this.lblFindEntries.Name = "lblFindEntries";
			this.lblFindEntries.Size = new System.Drawing.Size(59, 15);
			this.lblFindEntries.TabIndex = 16;
			this.lblFindEntries.Text = "Find Now";
			this.lblFindEntries.Click += new System.EventHandler(this.lblFindEntries_Click);
			// 
			// rtbSelectedEntry_Found
			// 
			this.rtbSelectedEntry_Found.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbSelectedEntry_Found.Location = new System.Drawing.Point(6, 335);
			this.rtbSelectedEntry_Found.Name = "rtbSelectedEntry_Found";
			this.rtbSelectedEntry_Found.Size = new System.Drawing.Size(278, 198);
			this.rtbSelectedEntry_Found.TabIndex = 12;
			this.rtbSelectedEntry_Found.Text = "";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(2, 146);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(82, 15);
			this.label9.TabIndex = 3;
			this.label9.Text = "Entry contains";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(3, 317);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(81, 15);
			this.label10.TabIndex = 15;
			this.label10.Text = "Selected Entry";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(7, 117);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(77, 15);
			this.label8.TabIndex = 2;
			this.label8.Text = "Title contains";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(3, 187);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(79, 15);
			this.label11.TabIndex = 13;
			this.label11.Text = "Found Entries";
			// 
			// grpNewJournal
			// 
			this.grpNewJournal.Controls.Add(this.lblMessage_BadJournalName);
			this.grpNewJournal.Controls.Add(this.lblHome_NewJrnl);
			this.grpNewJournal.Controls.Add(this.btnOK_NewJrnl);
			this.grpNewJournal.Controls.Add(this.txtNewJournalName);
			this.grpNewJournal.Controls.Add(this.label13);
			this.grpNewJournal.Location = new System.Drawing.Point(19, 587);
			this.grpNewJournal.Name = "grpNewJournal";
			this.grpNewJournal.Size = new System.Drawing.Size(290, 323);
			this.grpNewJournal.TabIndex = 7;
			this.grpNewJournal.TabStop = false;
			// 
			// lblMessage_BadJournalName
			// 
			this.lblMessage_BadJournalName.Location = new System.Drawing.Point(6, 117);
			this.lblMessage_BadJournalName.Name = "lblMessage_BadJournalName";
			this.lblMessage_BadJournalName.Size = new System.Drawing.Size(280, 39);
			this.lblMessage_BadJournalName.TabIndex = 27;
			this.lblMessage_BadJournalName.Text = " The Journal Name you entered has illegal characters. Please try again.";
			this.lblMessage_BadJournalName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblMessage_BadJournalName.Visible = false;
			// 
			// lblHome_NewJrnl
			// 
			this.lblHome_NewJrnl.AutoSize = true;
			this.lblHome_NewJrnl.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblHome_NewJrnl.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblHome_NewJrnl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblHome_NewJrnl.Location = new System.Drawing.Point(6, 12);
			this.lblHome_NewJrnl.Name = "lblHome_NewJrnl";
			this.lblHome_NewJrnl.Size = new System.Drawing.Size(33, 15);
			this.lblHome_NewJrnl.TabIndex = 25;
			this.lblHome_NewJrnl.Text = "back";
			this.lblHome_NewJrnl.Click += new System.EventHandler(this.lblHome_Click);
			// 
			// btnOK_NewJrnl
			// 
			this.btnOK_NewJrnl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnOK_NewJrnl.Location = new System.Drawing.Point(99, 72);
			this.btnOK_NewJrnl.Name = "btnOK_NewJrnl";
			this.btnOK_NewJrnl.Size = new System.Drawing.Size(75, 23);
			this.btnOK_NewJrnl.TabIndex = 2;
			this.btnOK_NewJrnl.Text = "OK";
			this.btnOK_NewJrnl.UseVisualStyleBackColor = false;
			this.btnOK_NewJrnl.Click += new System.EventHandler(this.btnOK_NewJrnl_Click);
			// 
			// txtNewJournalName
			// 
			this.txtNewJournalName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNewJournalName.Location = new System.Drawing.Point(88, 40);
			this.txtNewJournalName.Name = "txtNewJournalName";
			this.txtNewJournalName.Size = new System.Drawing.Size(185, 23);
			this.txtNewJournalName.TabIndex = 1;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(6, 43);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(83, 15);
			this.label13.TabIndex = 0;
			this.label13.Text = "Journal Name:";
			// 
			// grpNewGroup
			// 
			this.grpNewGroup.Controls.Add(this.grpEditTags_NewName);
			this.grpNewGroup.Controls.Add(this.grpEditTags_EditRemove);
			this.grpNewGroup.Controls.Add(this.grpEditTags_Add);
			this.grpNewGroup.Controls.Add(this.lblHome_NewGroup);
			this.grpNewGroup.Location = new System.Drawing.Point(358, 587);
			this.grpNewGroup.Name = "grpNewGroup";
			this.grpNewGroup.Size = new System.Drawing.Size(290, 395);
			this.grpNewGroup.TabIndex = 26;
			this.grpNewGroup.TabStop = false;
			// 
			// grpEditTags_NewName
			// 
			this.grpEditTags_NewName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpEditTags_NewName.Controls.Add(this.lblBack_EditTag);
			this.grpEditTags_NewName.Controls.Add(this.txtTag_TagName_Edited);
			this.grpEditTags_NewName.Controls.Add(this.label7);
			this.grpEditTags_NewName.Controls.Add(this.btnOK_TagName_Edited);
			this.grpEditTags_NewName.Location = new System.Drawing.Point(6, 258);
			this.grpEditTags_NewName.Name = "grpEditTags_NewName";
			this.grpEditTags_NewName.Size = new System.Drawing.Size(275, 131);
			this.grpEditTags_NewName.TabIndex = 28;
			this.grpEditTags_NewName.TabStop = false;
			this.grpEditTags_NewName.Text = "Edit Tag";
			this.grpEditTags_NewName.Visible = false;
			// 
			// lblBack_EditTag
			// 
			this.lblBack_EditTag.AutoSize = true;
			this.lblBack_EditTag.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblBack_EditTag.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblBack_EditTag.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblBack_EditTag.Location = new System.Drawing.Point(6, 19);
			this.lblBack_EditTag.Name = "lblBack_EditTag";
			this.lblBack_EditTag.Size = new System.Drawing.Size(33, 15);
			this.lblBack_EditTag.TabIndex = 29;
			this.lblBack_EditTag.Text = "back";
			this.lblBack_EditTag.Click += new System.EventHandler(this.lblHome_Click);
			// 
			// txtTag_TagName_Edited
			// 
			this.txtTag_TagName_Edited.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTag_TagName_Edited.Location = new System.Drawing.Point(67, 38);
			this.txtTag_TagName_Edited.Name = "txtTag_TagName_Edited";
			this.txtTag_TagName_Edited.Size = new System.Drawing.Size(121, 23);
			this.txtTag_TagName_Edited.TabIndex = 4;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 41);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 15);
			this.label7.TabIndex = 3;
			this.label7.Text = "Tag Name:";
			// 
			// btnOK_TagName_Edited
			// 
			this.btnOK_TagName_Edited.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK_TagName_Edited.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnOK_TagName_Edited.Location = new System.Drawing.Point(194, 38);
			this.btnOK_TagName_Edited.Name = "btnOK_TagName_Edited";
			this.btnOK_TagName_Edited.Size = new System.Drawing.Size(75, 23);
			this.btnOK_TagName_Edited.TabIndex = 5;
			this.btnOK_TagName_Edited.Text = "OK";
			this.btnOK_TagName_Edited.UseVisualStyleBackColor = false;
			this.btnOK_TagName_Edited.Click += new System.EventHandler(this.btnOK_TagName_Edited_Click);
			// 
			// grpEditTags_EditRemove
			// 
			this.grpEditTags_EditRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpEditTags_EditRemove.Controls.Add(this.lblRemoveTag);
			this.grpEditTags_EditRemove.Controls.Add(this.lblEditTag);
			this.grpEditTags_EditRemove.Controls.Add(this.label19);
			this.grpEditTags_EditRemove.Controls.Add(this.lstTagsForEdit);
			this.grpEditTags_EditRemove.Location = new System.Drawing.Point(6, 113);
			this.grpEditTags_EditRemove.Name = "grpEditTags_EditRemove";
			this.grpEditTags_EditRemove.Size = new System.Drawing.Size(275, 139);
			this.grpEditTags_EditRemove.TabIndex = 27;
			this.grpEditTags_EditRemove.TabStop = false;
			this.grpEditTags_EditRemove.Text = "Edit/Remove Tags";
			// 
			// lblRemoveTag
			// 
			this.lblRemoveTag.AutoSize = true;
			this.lblRemoveTag.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblRemoveTag.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblRemoveTag.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblRemoveTag.Location = new System.Drawing.Point(140, 19);
			this.lblRemoveTag.Name = "lblRemoveTag";
			this.lblRemoveTag.Size = new System.Drawing.Size(52, 15);
			this.lblRemoveTag.TabIndex = 3;
			this.lblRemoveTag.Text = "Remove";
			this.lblRemoveTag.Click += new System.EventHandler(this.lblRemoveTag_Click);
			// 
			// lblEditTag
			// 
			this.lblEditTag.AutoSize = true;
			this.lblEditTag.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblEditTag.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblEditTag.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblEditTag.Location = new System.Drawing.Point(107, 19);
			this.lblEditTag.Name = "lblEditTag";
			this.lblEditTag.Size = new System.Drawing.Size(27, 15);
			this.lblEditTag.TabIndex = 2;
			this.lblEditTag.Text = "Edit";
			this.lblEditTag.Click += new System.EventHandler(this.lblEditTag_Click);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(17, 19);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(84, 15);
			this.label19.TabIndex = 1;
			this.label19.Text = "Selected Item: ";
			// 
			// lstTagsForEdit
			// 
			this.lstTagsForEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstTagsForEdit.FormattingEnabled = true;
			this.lstTagsForEdit.ItemHeight = 15;
			this.lstTagsForEdit.Location = new System.Drawing.Point(6, 36);
			this.lstTagsForEdit.Name = "lstTagsForEdit";
			this.lstTagsForEdit.Size = new System.Drawing.Size(263, 94);
			this.lstTagsForEdit.TabIndex = 0;
			// 
			// grpEditTags_Add
			// 
			this.grpEditTags_Add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpEditTags_Add.Controls.Add(this.txtTags_TagName_NewTag);
			this.grpEditTags_Add.Controls.Add(this.label16);
			this.grpEditTags_Add.Controls.Add(this.btnOK_TagName_New);
			this.grpEditTags_Add.Location = new System.Drawing.Point(6, 38);
			this.grpEditTags_Add.Name = "grpEditTags_Add";
			this.grpEditTags_Add.Size = new System.Drawing.Size(278, 69);
			this.grpEditTags_Add.TabIndex = 26;
			this.grpEditTags_Add.TabStop = false;
			this.grpEditTags_Add.Text = "Add New Tag";
			// 
			// txtTags_TagName_NewTag
			// 
			this.txtTags_TagName_NewTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTags_TagName_NewTag.Location = new System.Drawing.Point(70, 28);
			this.txtTags_TagName_NewTag.Name = "txtTags_TagName_NewTag";
			this.txtTags_TagName_NewTag.Size = new System.Drawing.Size(121, 23);
			this.txtTags_TagName_NewTag.TabIndex = 1;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(6, 31);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(63, 15);
			this.label16.TabIndex = 0;
			this.label16.Text = "Tag Name:";
			// 
			// btnOK_TagName_New
			// 
			this.btnOK_TagName_New.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK_TagName_New.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnOK_TagName_New.Location = new System.Drawing.Point(197, 28);
			this.btnOK_TagName_New.Name = "btnOK_TagName_New";
			this.btnOK_TagName_New.Size = new System.Drawing.Size(75, 23);
			this.btnOK_TagName_New.TabIndex = 2;
			this.btnOK_TagName_New.Text = "OK";
			this.btnOK_TagName_New.UseVisualStyleBackColor = false;
			this.btnOK_TagName_New.Click += new System.EventHandler(this.Tags_btnOK_NewTag_Click);
			// 
			// lblHome_NewGroup
			// 
			this.lblHome_NewGroup.AutoSize = true;
			this.lblHome_NewGroup.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblHome_NewGroup.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblHome_NewGroup.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblHome_NewGroup.Location = new System.Drawing.Point(6, 12);
			this.lblHome_NewGroup.Name = "lblHome_NewGroup";
			this.lblHome_NewGroup.Size = new System.Drawing.Size(33, 15);
			this.lblHome_NewGroup.TabIndex = 25;
			this.lblHome_NewGroup.Text = "back";
			this.lblHome_NewGroup.Click += new System.EventHandler(this.lblHome_Click);
			// 
			// grpDeleteJournal
			// 
			this.grpDeleteJournal.Controls.Add(this.lblDelete_Confirm);
			this.grpDeleteJournal.Controls.Add(this.ddlJournalsToDelete);
			this.grpDeleteJournal.Controls.Add(this.lblHome_DeleteJournal);
			this.grpDeleteJournal.Controls.Add(this.btnOK_DeleteJournal);
			this.grpDeleteJournal.Controls.Add(this.lblJournalToDelete);
			this.grpDeleteJournal.Location = new System.Drawing.Point(669, 587);
			this.grpDeleteJournal.Name = "grpDeleteJournal";
			this.grpDeleteJournal.Size = new System.Drawing.Size(290, 107);
			this.grpDeleteJournal.TabIndex = 26;
			this.grpDeleteJournal.TabStop = false;
			// 
			// lblDelete_Confirm
			// 
			this.lblDelete_Confirm.Location = new System.Drawing.Point(41, 27);
			this.lblDelete_Confirm.Name = "lblDelete_Confirm";
			this.lblDelete_Confirm.Size = new System.Drawing.Size(211, 39);
			this.lblDelete_Confirm.TabIndex = 26;
			this.lblDelete_Confirm.Text = " will be deleted. Press Delete to continue.";
			this.lblDelete_Confirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblDelete_Confirm.Visible = false;
			// 
			// ddlJournalsToDelete
			// 
			this.ddlJournalsToDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ddlJournalsToDelete.FormattingEnabled = true;
			this.ddlJournalsToDelete.Location = new System.Drawing.Point(56, 40);
			this.ddlJournalsToDelete.Name = "ddlJournalsToDelete";
			this.ddlJournalsToDelete.Size = new System.Drawing.Size(228, 23);
			this.ddlJournalsToDelete.TabIndex = 16;
			// 
			// lblHome_DeleteJournal
			// 
			this.lblHome_DeleteJournal.AutoSize = true;
			this.lblHome_DeleteJournal.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblHome_DeleteJournal.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblHome_DeleteJournal.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblHome_DeleteJournal.Location = new System.Drawing.Point(6, 12);
			this.lblHome_DeleteJournal.Name = "lblHome_DeleteJournal";
			this.lblHome_DeleteJournal.Size = new System.Drawing.Size(33, 15);
			this.lblHome_DeleteJournal.TabIndex = 25;
			this.lblHome_DeleteJournal.Text = "back";
			this.lblHome_DeleteJournal.Click += new System.EventHandler(this.lblHome_Click);
			// 
			// btnOK_DeleteJournal
			// 
			this.btnOK_DeleteJournal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnOK_DeleteJournal.Location = new System.Drawing.Point(107, 72);
			this.btnOK_DeleteJournal.Name = "btnOK_DeleteJournal";
			this.btnOK_DeleteJournal.Size = new System.Drawing.Size(75, 23);
			this.btnOK_DeleteJournal.TabIndex = 2;
			this.btnOK_DeleteJournal.Text = "Delete";
			this.btnOK_DeleteJournal.UseVisualStyleBackColor = false;
			this.btnOK_DeleteJournal.Click += new System.EventHandler(this.btnOK_DeleteJournal_Click);
			// 
			// lblJournalToDelete
			// 
			this.lblJournalToDelete.AutoSize = true;
			this.lblJournalToDelete.Location = new System.Drawing.Point(6, 43);
			this.lblJournalToDelete.Name = "lblJournalToDelete";
			this.lblJournalToDelete.Size = new System.Drawing.Size(45, 15);
			this.lblJournalToDelete.TabIndex = 0;
			this.lblJournalToDelete.Text = "Journal";
			// 
			// grpConfirmDeleteEntry
			// 
			this.grpConfirmDeleteEntry.Controls.Add(this.lblMessage_ConfirmEntryDelete);
			this.grpConfirmDeleteEntry.Controls.Add(this.lblBack_ConfirmEntryDelete);
			this.grpConfirmDeleteEntry.Controls.Add(this.btnOK_ConfirmEntryDelete);
			this.grpConfirmDeleteEntry.Location = new System.Drawing.Point(669, 719);
			this.grpConfirmDeleteEntry.Name = "grpConfirmDeleteEntry";
			this.grpConfirmDeleteEntry.Size = new System.Drawing.Size(290, 107);
			this.grpConfirmDeleteEntry.TabIndex = 27;
			this.grpConfirmDeleteEntry.TabStop = false;
			// 
			// lblMessage_ConfirmEntryDelete
			// 
			this.lblMessage_ConfirmEntryDelete.Location = new System.Drawing.Point(41, 27);
			this.lblMessage_ConfirmEntryDelete.Name = "lblMessage_ConfirmEntryDelete";
			this.lblMessage_ConfirmEntryDelete.Size = new System.Drawing.Size(211, 39);
			this.lblMessage_ConfirmEntryDelete.TabIndex = 26;
			this.lblMessage_ConfirmEntryDelete.Text = " will be deleted. Press Delete to continue.";
			this.lblMessage_ConfirmEntryDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblBack_ConfirmEntryDelete
			// 
			this.lblBack_ConfirmEntryDelete.AutoSize = true;
			this.lblBack_ConfirmEntryDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblBack_ConfirmEntryDelete.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblBack_ConfirmEntryDelete.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblBack_ConfirmEntryDelete.Location = new System.Drawing.Point(6, 12);
			this.lblBack_ConfirmEntryDelete.Name = "lblBack_ConfirmEntryDelete";
			this.lblBack_ConfirmEntryDelete.Size = new System.Drawing.Size(33, 15);
			this.lblBack_ConfirmEntryDelete.TabIndex = 25;
			this.lblBack_ConfirmEntryDelete.Text = "back";
			this.lblBack_ConfirmEntryDelete.Click += new System.EventHandler(this.lblHome_Click);
			// 
			// btnOK_ConfirmEntryDelete
			// 
			this.btnOK_ConfirmEntryDelete.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnOK_ConfirmEntryDelete.Location = new System.Drawing.Point(107, 72);
			this.btnOK_ConfirmEntryDelete.Name = "btnOK_ConfirmEntryDelete";
			this.btnOK_ConfirmEntryDelete.Size = new System.Drawing.Size(75, 23);
			this.btnOK_ConfirmEntryDelete.TabIndex = 2;
			this.btnOK_ConfirmEntryDelete.Text = "Delete";
			this.btnOK_ConfirmEntryDelete.UseVisualStyleBackColor = false;
			this.btnOK_ConfirmEntryDelete.Click += new System.EventHandler(this.btnConfirmEntryDelete_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1109, 1061);
			this.Controls.Add(this.grpConfirmDeleteEntry);
			this.Controls.Add(this.grpDeleteJournal);
			this.Controls.Add(this.grpNewGroup);
			this.Controls.Add(this.grpNewJournal);
			this.Controls.Add(this.grpOpenScreen);
			this.Controls.Add(this.grpCreateEntry);
			this.Controls.Add(this.grpFindEntry);
			this.Controls.Add(this.lblAddEntry);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(331, 592);
			this.Name = "Form1";
			this.Text = "My Journals";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.grpCreateEntry.ResumeLayout(false);
			this.grpCreateEntry.PerformLayout();
			this.grpAppendDeleteOriginal.ResumeLayout(false);
			this.grpAppendDeleteOriginal.PerformLayout();
			this.mnuGroups.ResumeLayout(false);
			this.grpOpenScreen.ResumeLayout(false);
			this.grpOpenScreen.PerformLayout();
			this.pnlMenu.ResumeLayout(false);
			this.pnlMenu.PerformLayout();
			this.grpFindEntry.ResumeLayout(false);
			this.grpFindEntry.PerformLayout();
			this.grpNewJournal.ResumeLayout(false);
			this.grpNewJournal.PerformLayout();
			this.grpNewGroup.ResumeLayout(false);
			this.grpNewGroup.PerformLayout();
			this.grpEditTags_NewName.ResumeLayout(false);
			this.grpEditTags_NewName.PerformLayout();
			this.grpEditTags_EditRemove.ResumeLayout(false);
			this.grpEditTags_EditRemove.PerformLayout();
			this.grpEditTags_Add.ResumeLayout(false);
			this.grpEditTags_Add.PerformLayout();
			this.grpDeleteJournal.ResumeLayout(false);
			this.grpDeleteJournal.PerformLayout();
			this.grpConfirmDeleteEntry.ResumeLayout(false);
			this.grpConfirmDeleteEntry.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlJournals;
        private System.Windows.Forms.Label lblCreateEntry;
        private System.Windows.Forms.Label lblFindEntry;
        private System.Windows.Forms.GroupBox grpCreateEntry;
        private System.Windows.Forms.Label lblAddEntry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbNewEntry;
        private System.Windows.Forms.TextBox txtNewEntryTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpOpenScreen;
        private System.Windows.Forms.ListBox lstEntries;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpFindEntry;
        private System.Windows.Forms.Label lblSelectionType;
        private System.Windows.Forms.RichTextBox rtbSelectedEntry_Main;
        private System.Windows.Forms.Label lblEntriesStartFrom;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.TextBox txtSearchTitle;
        private System.Windows.Forms.DateTimePicker dtFindDate_To;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtFindDate_From;
        private System.Windows.Forms.DateTimePicker dtFindDate;
        private System.Windows.Forms.Label lblFindEntries;
        private System.Windows.Forms.RichTextBox rtbSelectedEntry_Found;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grpNewJournal;
        private System.Windows.Forms.Label lblFont_NewEntry;
        private System.Windows.Forms.Label lblHome_NewEntry;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Label lblClearAll;
        private System.Windows.Forms.Label lblHome_NewJrnl;
        private System.Windows.Forms.Button btnOK_NewJrnl;
        private System.Windows.Forms.TextBox txtNewJournalName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckedListBox lstTags;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox grpNewGroup;
        private System.Windows.Forms.Label lblHome_NewGroup;
        private System.Windows.Forms.Button btnOK_TagName_New;
        private System.Windows.Forms.TextBox txtTags_TagName_NewTag;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblEditEntry;
        private System.Windows.Forms.ContextMenuStrip mnuGroups;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.CheckedListBox lstGroupsForSearch;
        private System.Windows.Forms.TextBox txtGroupsForSearch;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RadioButton radAllJournals;
        private System.Windows.Forms.RadioButton radCurrentJournal;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chkUseDateRange;
        private System.Windows.Forms.CheckBox chkUseDate;
        private System.Windows.Forms.ListBox lstFoundEntries;
		private System.Windows.Forms.Label lblDeleteEntry;
		private System.Windows.Forms.RadioButton radOriginal_Replace;
		private System.Windows.Forms.RadioButton radOriginal_Append;
		private System.Windows.Forms.GroupBox grpAppendDeleteOriginal;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox grpDeleteJournal;
		private System.Windows.Forms.ComboBox ddlJournalsToDelete;
		private System.Windows.Forms.Label lblHome_DeleteJournal;
		private System.Windows.Forms.Button btnOK_DeleteJournal;
		private System.Windows.Forms.Label lblJournalToDelete;
		private System.Windows.Forms.Label lblDelete_Confirm;
		private System.Windows.Forms.Panel pnlMenu;
		private System.Windows.Forms.Label lblSettings_Show;
		private System.Windows.Forms.Label lblTagManager;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label lblJournal_Delete;
		private System.Windows.Forms.Label lblJournal_Create;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label lblMenu;
		private System.Windows.Forms.Label lblMenu_1;
		private System.Windows.Forms.Label lblMenu_0;
		private System.Windows.Forms.Label lblCloseMenu;
		private System.Windows.Forms.Label lblEntryText_Hidden;
		private System.Windows.Forms.Label lblEntryTitle_Hidden;
		private System.Windows.Forms.Label lblTagManager2;
		private System.Windows.Forms.Label lblMessage_BadJournalName;
		private System.Windows.Forms.GroupBox grpEditTags_EditRemove;
		private System.Windows.Forms.ListBox lstTagsForEdit;
		private System.Windows.Forms.GroupBox grpEditTags_Add;
		private System.Windows.Forms.GroupBox grpEditTags_NewName;
		private System.Windows.Forms.TextBox txtTag_TagName_Edited;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnOK_TagName_Edited;
		private System.Windows.Forms.Label lblRemoveTag;
		private System.Windows.Forms.Label lblEditTag;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.GroupBox grpConfirmDeleteEntry;
		private System.Windows.Forms.Label lblMessage_ConfirmEntryDelete;
		private System.Windows.Forms.Label lblBack_ConfirmEntryDelete;
		private System.Windows.Forms.Button btnOK_ConfirmEntryDelete;
		private System.Windows.Forms.Label lblBack_EditTag;
		private System.Windows.Forms.Label lblViewJournal;
		private System.Windows.Forms.Label lblPrint;
	}
}

