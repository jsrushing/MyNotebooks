
namespace myJournal.forms
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
			this.grpOpenScreen = new System.Windows.Forms.GroupBox();
			this.lblPrint = new System.Windows.Forms.Label();
			this.rtbSelectedEntry_Main = new System.Windows.Forms.RichTextBox();
			this.pnlMenu = new System.Windows.Forms.Panel();
			this.lblViewJournal = new System.Windows.Forms.Label();
			this.lblCloseMenu = new System.Windows.Forms.Label();
			this.lblSettings_Show = new System.Windows.Forms.Label();
			this.lblTagManager = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.lblJournal_Delete = new System.Windows.Forms.Label();
			this.lblJournal_Create = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.lblCreateEntry = new System.Windows.Forms.Label();
			this.lblEditEntry = new System.Windows.Forms.Label();
			this.lblFindEntry = new System.Windows.Forms.Label();
			this.lblMenu_1 = new System.Windows.Forms.Label();
			this.lblMenu_0 = new System.Windows.Forms.Label();
			this.lblMenu = new System.Windows.Forms.Label();
			this.lblEntriesStartFrom = new System.Windows.Forms.Label();
			this.ddlJournals = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblSelectionType = new System.Windows.Forms.Label();
			this.lstEntries = new System.Windows.Forms.ListBox();
			this.lblSelectAJournal = new System.Windows.Forms.Label();
			this.lblSeparator_grpOpenScreen = new System.Windows.Forms.Label();
			this.grpOpenScreen.SuspendLayout();
			this.pnlMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpOpenScreen
			// 
			this.grpOpenScreen.BackColor = System.Drawing.SystemColors.Window;
			this.grpOpenScreen.Controls.Add(this.lblPrint);
			this.grpOpenScreen.Controls.Add(this.rtbSelectedEntry_Main);
			this.grpOpenScreen.Controls.Add(this.pnlMenu);
			this.grpOpenScreen.Controls.Add(this.lblMenu);
			this.grpOpenScreen.Controls.Add(this.lblEntriesStartFrom);
			this.grpOpenScreen.Controls.Add(this.ddlJournals);
			this.grpOpenScreen.Controls.Add(this.label1);
			this.grpOpenScreen.Controls.Add(this.lblSelectionType);
			this.grpOpenScreen.Controls.Add(this.lstEntries);
			this.grpOpenScreen.Controls.Add(this.lblSelectAJournal);
			this.grpOpenScreen.Controls.Add(this.lblSeparator_grpOpenScreen);
			this.grpOpenScreen.Location = new System.Drawing.Point(12, 12);
			this.grpOpenScreen.Name = "grpOpenScreen";
			this.grpOpenScreen.Size = new System.Drawing.Size(290, 545);
			this.grpOpenScreen.TabIndex = 6;
			this.grpOpenScreen.TabStop = false;
			// 
			// lblPrint
			// 
			this.lblPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPrint.AutoSize = true;
			this.lblPrint.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblPrint.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblPrint.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblPrint.Location = new System.Drawing.Point(332, 257);
			this.lblPrint.Name = "lblPrint";
			this.lblPrint.Size = new System.Drawing.Size(34, 15);
			this.lblPrint.TabIndex = 29;
			this.lblPrint.Text = "print";
			this.lblPrint.Visible = false;
			// 
			// rtbSelectedEntry_Main
			// 
			this.rtbSelectedEntry_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbSelectedEntry_Main.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbSelectedEntry_Main.Location = new System.Drawing.Point(7, 280);
			this.rtbSelectedEntry_Main.Name = "rtbSelectedEntry_Main";
			this.rtbSelectedEntry_Main.Size = new System.Drawing.Size(277, 259);
			this.rtbSelectedEntry_Main.TabIndex = 5;
			this.rtbSelectedEntry_Main.TabStop = false;
			this.rtbSelectedEntry_Main.Text = "";
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
			this.pnlMenu.Location = new System.Drawing.Point(60, 52);
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
			this.lblViewJournal.Size = new System.Drawing.Size(60, 15);
			this.lblViewJournal.TabIndex = 26;
			this.lblViewJournal.Text = "All Entries";
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
			// 
			// lblMenu_1
			// 
			this.lblMenu_1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.lblMenu_1.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lblMenu_1.Location = new System.Drawing.Point(3, 3);
			this.lblMenu_1.Name = "lblMenu_1";
			this.lblMenu_1.Size = new System.Drawing.Size(110, 230);
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
			// 
			// lblEntriesStartFrom
			// 
			this.lblEntriesStartFrom.AutoSize = true;
			this.lblEntriesStartFrom.Location = new System.Drawing.Point(127, 77);
			this.lblEntriesStartFrom.Name = "lblEntriesStartFrom";
			this.lblEntriesStartFrom.Size = new System.Drawing.Size(108, 15);
			this.lblEntriesStartFrom.TabIndex = 10;
			this.lblEntriesStartFrom.Text = "(from 2 weeks ago)";
			this.lblEntriesStartFrom.Visible = false;
			// 
			// ddlJournals
			// 
			this.ddlJournals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ddlJournals.FormattingEnabled = true;
			this.ddlJournals.Location = new System.Drawing.Point(55, 36);
			this.ddlJournals.Name = "ddlJournals";
			this.ddlJournals.Size = new System.Drawing.Size(319, 23);
			this.ddlJournals.TabIndex = 1;
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
			// lblSelectionType
			// 
			this.lblSelectionType.AutoSize = true;
			this.lblSelectionType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblSelectionType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblSelectionType.Location = new System.Drawing.Point(4, 260);
			this.lblSelectionType.Name = "lblSelectionType";
			this.lblSelectionType.Size = new System.Drawing.Size(118, 17);
			this.lblSelectionType.TabIndex = 9;
			this.lblSelectionType.Text = "Select An Entry ...";
			this.lblSelectionType.Visible = false;
			// 
			// lstEntries
			// 
			this.lstEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstEntries.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstEntries.FormattingEnabled = true;
			this.lstEntries.HorizontalScrollbar = true;
			this.lstEntries.ItemHeight = 15;
			this.lstEntries.Location = new System.Drawing.Point(6, 95);
			this.lstEntries.Name = "lstEntries";
			this.lstEntries.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstEntries.Size = new System.Drawing.Size(368, 150);
			this.lstEntries.TabIndex = 8;
			// 
			// lblSelectAJournal
			// 
			this.lblSelectAJournal.AutoSize = true;
			this.lblSelectAJournal.Enabled = false;
			this.lblSelectAJournal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblSelectAJournal.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblSelectAJournal.Location = new System.Drawing.Point(6, 74);
			this.lblSelectAJournal.Name = "lblSelectAJournal";
			this.lblSelectAJournal.Size = new System.Drawing.Size(133, 17);
			this.lblSelectAJournal.TabIndex = 7;
			this.lblSelectAJournal.Text = "(Select A Journal ...)";
			// 
			// lblSeparator_grpOpenScreen
			// 
			this.lblSeparator_grpOpenScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSeparator_grpOpenScreen.AutoSize = true;
			this.lblSeparator_grpOpenScreen.ForeColor = System.Drawing.Color.Gray;
			this.lblSeparator_grpOpenScreen.Location = new System.Drawing.Point(3, 241);
			this.lblSeparator_grpOpenScreen.Name = "lblSeparator_grpOpenScreen";
			this.lblSeparator_grpOpenScreen.Size = new System.Drawing.Size(1192, 15);
			this.lblSeparator_grpOpenScreen.TabIndex = 30;
			this.lblSeparator_grpOpenScreen.Text = resources.GetString("lblSeparator_grpOpenScreen.Text");
			this.lblSeparator_grpOpenScreen.Visible = false;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(322, 573);
			this.Controls.Add(this.grpOpenScreen);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmMain";
			this.Text = "frmMain";
			this.grpOpenScreen.ResumeLayout(false);
			this.grpOpenScreen.PerformLayout();
			this.pnlMenu.ResumeLayout(false);
			this.pnlMenu.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpOpenScreen;
		private System.Windows.Forms.Label lblPrint;
		private System.Windows.Forms.RichTextBox rtbSelectedEntry_Main;
		private System.Windows.Forms.Panel pnlMenu;
		private System.Windows.Forms.Label lblViewJournal;
		private System.Windows.Forms.Label lblCloseMenu;
		private System.Windows.Forms.Label lblSettings_Show;
		private System.Windows.Forms.Label lblTagManager;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label lblJournal_Delete;
		private System.Windows.Forms.Label lblJournal_Create;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label lblCreateEntry;
		private System.Windows.Forms.Label lblEditEntry;
		private System.Windows.Forms.Label lblFindEntry;
		private System.Windows.Forms.Label lblMenu_1;
		private System.Windows.Forms.Label lblMenu_0;
		private System.Windows.Forms.Label lblMenu;
		private System.Windows.Forms.Label lblEntriesStartFrom;
		private System.Windows.Forms.ComboBox ddlJournals;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblSelectionType;
		private System.Windows.Forms.ListBox lstEntries;
		private System.Windows.Forms.Label lblSelectAJournal;
		private System.Windows.Forms.Label lblSeparator_grpOpenScreen;
	}
}