
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
            this.label1 = new System.Windows.Forms.Label();
            this.ddlJournals = new System.Windows.Forms.ComboBox();
            this.lblCreateEntry = new System.Windows.Forms.Label();
            this.lblFindEntry = new System.Windows.Forms.Label();
            this.grpCreateEntry = new System.Windows.Forms.GroupBox();
            this.lblHome_NewEntry = new System.Windows.Forms.Label();
            this.lblFont_NewEntry = new System.Windows.Forms.Label();
            this.lblAddEntry = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbNewEntry = new System.Windows.Forms.RichTextBox();
            this.txtNewEntryTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpOpenScreen = new System.Windows.Forms.GroupBox();
            this.btnCreateJournal = new System.Windows.Forms.Button();
            this.lblSettings = new System.Windows.Forms.Label();
            this.lblEntriesStartFrom = new System.Windows.Forms.Label();
            this.rtbSelectedEntry_Main = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstEntries = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpFindEntry = new System.Windows.Forms.GroupBox();
            this.chkSearchAllJournals = new System.Windows.Forms.CheckBox();
            this.lblClearAll = new System.Windows.Forms.Label();
            this.lblHome = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dtFindDate = new System.Windows.Forms.DateTimePicker();
            this.lblFindEntries = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lstFoundEntries = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpNewJournal = new System.Windows.Forms.GroupBox();
            this.lblHome_NewJrnl = new System.Windows.Forms.Label();
            this.btnOK_NewJrnl = new System.Windows.Forms.Button();
            this.txtNewJournalName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lstGroups = new System.Windows.Forms.CheckedListBox();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.grpCreateEntry.SuspendLayout();
            this.grpOpenScreen.SuspendLayout();
            this.grpFindEntry.SuspendLayout();
            this.grpNewJournal.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Journal ";
            // 
            // ddlJournals
            // 
            this.ddlJournals.FormattingEnabled = true;
            this.ddlJournals.Location = new System.Drawing.Point(56, 22);
            this.ddlJournals.Name = "ddlJournals";
            this.ddlJournals.Size = new System.Drawing.Size(192, 23);
            this.ddlJournals.TabIndex = 1;
            this.ddlJournals.SelectedIndexChanged += new System.EventHandler(this.ddlJournals_SelectedIndexChanged);
            // 
            // lblCreateEntry
            // 
            this.lblCreateEntry.AutoSize = true;
            this.lblCreateEntry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCreateEntry.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblCreateEntry.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblCreateEntry.Location = new System.Drawing.Point(6, 52);
            this.lblCreateEntry.Name = "lblCreateEntry";
            this.lblCreateEntry.Size = new System.Drawing.Size(105, 15);
            this.lblCreateEntry.TabIndex = 2;
            this.lblCreateEntry.Text = "Create New Entry";
            this.lblCreateEntry.Click += new System.EventHandler(this.lblCreateEntry_Click);
            // 
            // lblFindEntry
            // 
            this.lblFindEntry.AutoSize = true;
            this.lblFindEntry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFindEntry.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblFindEntry.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblFindEntry.Location = new System.Drawing.Point(119, 52);
            this.lblFindEntry.Name = "lblFindEntry";
            this.lblFindEntry.Size = new System.Drawing.Size(62, 15);
            this.lblFindEntry.TabIndex = 3;
            this.lblFindEntry.Text = "Find Entry";
            this.lblFindEntry.Click += new System.EventHandler(this.lblFindEntry_Click);
            // 
            // grpCreateEntry
            // 
            this.grpCreateEntry.Controls.Add(this.btnAddGroup);
            this.grpCreateEntry.Controls.Add(this.lstGroups);
            this.grpCreateEntry.Controls.Add(this.label14);
            this.grpCreateEntry.Controls.Add(this.lblHome_NewEntry);
            this.grpCreateEntry.Controls.Add(this.lblFont_NewEntry);
            this.grpCreateEntry.Controls.Add(this.lblAddEntry);
            this.grpCreateEntry.Controls.Add(this.label3);
            this.grpCreateEntry.Controls.Add(this.rtbNewEntry);
            this.grpCreateEntry.Controls.Add(this.txtNewEntryTitle);
            this.grpCreateEntry.Controls.Add(this.label2);
            this.grpCreateEntry.Location = new System.Drawing.Point(334, 12);
            this.grpCreateEntry.Name = "grpCreateEntry";
            this.grpCreateEntry.Size = new System.Drawing.Size(290, 545);
            this.grpCreateEntry.TabIndex = 4;
            this.grpCreateEntry.TabStop = false;
            // 
            // lblHome_NewEntry
            // 
            this.lblHome_NewEntry.AutoSize = true;
            this.lblHome_NewEntry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHome_NewEntry.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblHome_NewEntry.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblHome_NewEntry.Location = new System.Drawing.Point(6, 11);
            this.lblHome_NewEntry.Name = "lblHome_NewEntry";
            this.lblHome_NewEntry.Size = new System.Drawing.Size(39, 15);
            this.lblHome_NewEntry.TabIndex = 24;
            this.lblHome_NewEntry.Text = "home";
            this.lblHome_NewEntry.Click += new System.EventHandler(this.lblHome_Click);
            // 
            // lblFont_NewEntry
            // 
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
            // lblAddEntry
            // 
            this.lblAddEntry.AutoSize = true;
            this.lblAddEntry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAddEntry.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblAddEntry.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblAddEntry.Location = new System.Drawing.Point(200, 522);
            this.lblAddEntry.Name = "lblAddEntry";
            this.lblAddEntry.Size = new System.Drawing.Size(86, 15);
            this.lblAddEntry.TabIndex = 4;
            this.lblAddEntry.Text = "Add This Entry";
            this.lblAddEntry.Click += new System.EventHandler(this.lblAddEntry_Click);
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
            this.rtbNewEntry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbNewEntry.Location = new System.Drawing.Point(6, 87);
            this.rtbNewEntry.Name = "rtbNewEntry";
            this.rtbNewEntry.Size = new System.Drawing.Size(278, 347);
            this.rtbNewEntry.TabIndex = 2;
            this.rtbNewEntry.Text = "";
            // 
            // txtNewEntryTitle
            // 
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
            // grpOpenScreen
            // 
            this.grpOpenScreen.Controls.Add(this.btnCreateJournal);
            this.grpOpenScreen.Controls.Add(this.lblSettings);
            this.grpOpenScreen.Controls.Add(this.lblEntriesStartFrom);
            this.grpOpenScreen.Controls.Add(this.rtbSelectedEntry_Main);
            this.grpOpenScreen.Controls.Add(this.ddlJournals);
            this.grpOpenScreen.Controls.Add(this.label1);
            this.grpOpenScreen.Controls.Add(this.label5);
            this.grpOpenScreen.Controls.Add(this.lstEntries);
            this.grpOpenScreen.Controls.Add(this.label4);
            this.grpOpenScreen.Controls.Add(this.lblFindEntry);
            this.grpOpenScreen.Controls.Add(this.lblCreateEntry);
            this.grpOpenScreen.Location = new System.Drawing.Point(12, 0);
            this.grpOpenScreen.Name = "grpOpenScreen";
            this.grpOpenScreen.Size = new System.Drawing.Size(290, 545);
            this.grpOpenScreen.TabIndex = 5;
            this.grpOpenScreen.TabStop = false;
            // 
            // btnCreateJournal
            // 
            this.btnCreateJournal.Location = new System.Drawing.Point(258, 21);
            this.btnCreateJournal.Name = "btnCreateJournal";
            this.btnCreateJournal.Size = new System.Drawing.Size(25, 23);
            this.btnCreateJournal.TabIndex = 12;
            this.btnCreateJournal.Text = "+";
            this.btnCreateJournal.UseVisualStyleBackColor = true;
            this.btnCreateJournal.Click += new System.EventHandler(this.btnCreateJournal_Click);
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblSettings.Location = new System.Drawing.Point(230, 77);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(49, 15);
            this.lblSettings.TabIndex = 11;
            this.lblSettings.Text = "Settings";
            this.lblSettings.Click += new System.EventHandler(this.lblSettings_Click);
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
            this.rtbSelectedEntry_Main.Location = new System.Drawing.Point(6, 275);
            this.rtbSelectedEntry_Main.Name = "rtbSelectedEntry_Main";
            this.rtbSelectedEntry_Main.Size = new System.Drawing.Size(278, 264);
            this.rtbSelectedEntry_Main.TabIndex = 5;
            this.rtbSelectedEntry_Main.TabStop = false;
            this.rtbSelectedEntry_Main.Text = "";
            this.rtbSelectedEntry_Main.Click += new System.EventHandler(this.rtbSelectedEntry_Main_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Selected Entry";
            // 
            // lstEntries
            // 
            this.lstEntries.FormattingEnabled = true;
            this.lstEntries.ItemHeight = 15;
            this.lstEntries.Location = new System.Drawing.Point(6, 95);
            this.lstEntries.Name = "lstEntries";
            this.lstEntries.Size = new System.Drawing.Size(278, 154);
            this.lstEntries.TabIndex = 8;
            this.lstEntries.SelectedIndexChanged += new System.EventHandler(this.lstEntries_SelectedIndexChanged);
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
            this.grpFindEntry.Controls.Add(this.chkSearchAllJournals);
            this.grpFindEntry.Controls.Add(this.lblClearAll);
            this.grpFindEntry.Controls.Add(this.lblHome);
            this.grpFindEntry.Controls.Add(this.textBox3);
            this.grpFindEntry.Controls.Add(this.textBox2);
            this.grpFindEntry.Controls.Add(this.dateTimePicker2);
            this.grpFindEntry.Controls.Add(this.label12);
            this.grpFindEntry.Controls.Add(this.dateTimePicker1);
            this.grpFindEntry.Controls.Add(this.dtFindDate);
            this.grpFindEntry.Controls.Add(this.lblFindEntries);
            this.grpFindEntry.Controls.Add(this.richTextBox2);
            this.grpFindEntry.Controls.Add(this.label9);
            this.grpFindEntry.Controls.Add(this.label10);
            this.grpFindEntry.Controls.Add(this.label8);
            this.grpFindEntry.Controls.Add(this.lstFoundEntries);
            this.grpFindEntry.Controls.Add(this.label11);
            this.grpFindEntry.Controls.Add(this.label7);
            this.grpFindEntry.Controls.Add(this.label6);
            this.grpFindEntry.Location = new System.Drawing.Point(645, 12);
            this.grpFindEntry.Name = "grpFindEntry";
            this.grpFindEntry.Size = new System.Drawing.Size(290, 545);
            this.grpFindEntry.TabIndex = 6;
            this.grpFindEntry.TabStop = false;
            // 
            // chkSearchAllJournals
            // 
            this.chkSearchAllJournals.AutoSize = true;
            this.chkSearchAllJournals.Location = new System.Drawing.Point(157, 13);
            this.chkSearchAllJournals.Name = "chkSearchAllJournals";
            this.chkSearchAllJournals.Size = new System.Drawing.Size(124, 19);
            this.chkSearchAllJournals.TabIndex = 25;
            this.chkSearchAllJournals.Text = "Search All Journals";
            this.chkSearchAllJournals.UseVisualStyleBackColor = true;
            // 
            // lblClearAll
            // 
            this.lblClearAll.AutoSize = true;
            this.lblClearAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClearAll.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblClearAll.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblClearAll.Location = new System.Drawing.Point(228, 181);
            this.lblClearAll.Name = "lblClearAll";
            this.lblClearAll.Size = new System.Drawing.Size(52, 15);
            this.lblClearAll.TabIndex = 24;
            this.lblClearAll.Text = "Clear All";
            this.lblClearAll.Click += new System.EventHandler(this.lblClearAll_Click);
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHome.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblHome.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblHome.Location = new System.Drawing.Point(6, 11);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(39, 15);
            this.lblHome.TabIndex = 23;
            this.lblHome.Text = "home";
            this.lblHome.Click += new System.EventHandler(this.lblHome_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(85, 147);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(199, 23);
            this.textBox3.TabIndex = 22;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(85, 118);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(199, 23);
            this.textBox2.TabIndex = 21;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(155, 87);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(120, 23);
            this.dateTimePicker2.TabIndex = 20;
            this.dateTimePicker2.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(132, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 15);
            this.label12.TabIndex = 19;
            this.label12.Text = "to";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 87);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 23);
            this.dateTimePicker1.TabIndex = 18;
            this.dateTimePicker1.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
            // 
            // dtFindDate
            // 
            this.dtFindDate.Location = new System.Drawing.Point(40, 35);
            this.dtFindDate.Name = "dtFindDate";
            this.dtFindDate.ShowUpDown = true;
            this.dtFindDate.Size = new System.Drawing.Size(241, 23);
            this.dtFindDate.TabIndex = 17;
            this.dtFindDate.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
            // 
            // lblFindEntries
            // 
            this.lblFindEntries.AutoSize = true;
            this.lblFindEntries.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFindEntries.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblFindEntries.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblFindEntries.Location = new System.Drawing.Point(118, 181);
            this.lblFindEntries.Name = "lblFindEntries";
            this.lblFindEntries.Size = new System.Drawing.Size(59, 15);
            this.lblFindEntries.TabIndex = 16;
            this.lblFindEntries.Text = "Find Now";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(6, 344);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(278, 193);
            this.richTextBox2.TabIndex = 12;
            this.richTextBox2.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Entry contains";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 326);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "Selected Entry";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Title contains";
            // 
            // lstFoundEntries
            // 
            this.lstFoundEntries.FormattingEnabled = true;
            this.lstFoundEntries.ItemHeight = 15;
            this.lstFoundEntries.Location = new System.Drawing.Point(6, 214);
            this.lstFoundEntries.Name = "lstFoundEntries";
            this.lstFoundEntries.Size = new System.Drawing.Size(278, 109);
            this.lstFoundEntries.TabIndex = 14;
            this.lstFoundEntries.SelectedIndexChanged += new System.EventHandler(this.lstFoundEntries_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 15);
            this.label11.TabIndex = 13;
            this.label11.Text = "Found Entries";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Date Range";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Date";
            // 
            // grpNewJournal
            // 
            this.grpNewJournal.Controls.Add(this.lblHome_NewJrnl);
            this.grpNewJournal.Controls.Add(this.btnOK_NewJrnl);
            this.grpNewJournal.Controls.Add(this.txtNewJournalName);
            this.grpNewJournal.Controls.Add(this.label13);
            this.grpNewJournal.Location = new System.Drawing.Point(19, 587);
            this.grpNewJournal.Name = "grpNewJournal";
            this.grpNewJournal.Size = new System.Drawing.Size(290, 107);
            this.grpNewJournal.TabIndex = 7;
            this.grpNewJournal.TabStop = false;
            // 
            // lblHome_NewJrnl
            // 
            this.lblHome_NewJrnl.AutoSize = true;
            this.lblHome_NewJrnl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHome_NewJrnl.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblHome_NewJrnl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblHome_NewJrnl.Location = new System.Drawing.Point(6, 12);
            this.lblHome_NewJrnl.Name = "lblHome_NewJrnl";
            this.lblHome_NewJrnl.Size = new System.Drawing.Size(39, 15);
            this.lblHome_NewJrnl.TabIndex = 25;
            this.lblHome_NewJrnl.Text = "home";
            this.lblHome_NewJrnl.Click += new System.EventHandler(this.lblHome_Click);
            // 
            // btnOK_NewJrnl
            // 
            this.btnOK_NewJrnl.Location = new System.Drawing.Point(99, 72);
            this.btnOK_NewJrnl.Name = "btnOK_NewJrnl";
            this.btnOK_NewJrnl.Size = new System.Drawing.Size(75, 23);
            this.btnOK_NewJrnl.TabIndex = 2;
            this.btnOK_NewJrnl.Text = "OK";
            this.btnOK_NewJrnl.UseVisualStyleBackColor = true;
            this.btnOK_NewJrnl.Click += new System.EventHandler(this.btnOK_NewJrnl_Click);
            // 
            // txtNewJournalName
            // 
            this.txtNewJournalName.Location = new System.Drawing.Point(88, 40);
            this.txtNewJournalName.Name = "txtNewJournalName";
            this.txtNewJournalName.Size = new System.Drawing.Size(193, 23);
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 440);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 15);
            this.label14.TabIndex = 25;
            this.label14.Text = "group";
            // 
            // lstGroups
            // 
            this.lstGroups.FormattingEnabled = true;
            this.lstGroups.Location = new System.Drawing.Point(51, 440);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.Size = new System.Drawing.Size(233, 76);
            this.lstGroups.TabIndex = 27;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(15, 462);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(25, 23);
            this.btnAddGroup.TabIndex = 13;
            this.btnAddGroup.Text = "+";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 1061);
            this.Controls.Add(this.grpNewJournal);
            this.Controls.Add(this.grpOpenScreen);
            this.Controls.Add(this.grpCreateEntry);
            this.Controls.Add(this.grpFindEntry);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "My Journals";
            this.grpCreateEntry.ResumeLayout(false);
            this.grpCreateEntry.PerformLayout();
            this.grpOpenScreen.ResumeLayout(false);
            this.grpOpenScreen.PerformLayout();
            this.grpFindEntry.ResumeLayout(false);
            this.grpFindEntry.PerformLayout();
            this.grpNewJournal.ResumeLayout(false);
            this.grpNewJournal.PerformLayout();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbSelectedEntry_Main;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.Label lblEntriesStartFrom;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dtFindDate;
        private System.Windows.Forms.Label lblFindEntries;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstFoundEntries;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpNewJournal;
        private System.Windows.Forms.Label lblFont_NewEntry;
        private System.Windows.Forms.Label lblHome_NewEntry;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Label lblClearAll;
        private System.Windows.Forms.Button btnCreateJournal;
        private System.Windows.Forms.Label lblHome_NewJrnl;
        private System.Windows.Forms.Button btnOK_NewJrnl;
        private System.Windows.Forms.TextBox txtNewJournalName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkSearchAllJournals;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.CheckedListBox lstGroups;
        private System.Windows.Forms.Label label14;
    }
}

