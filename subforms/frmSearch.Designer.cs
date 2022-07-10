
namespace myJournal.subforms
{
	partial class frmSearch
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
			this.grpFindEntry = new System.Windows.Forms.GroupBox();
			this.lblSeparator = new System.Windows.Forms.Label();
			this.radBtnAnd = new System.Windows.Forms.RadioButton();
			this.radBtnOr = new System.Windows.Forms.RadioButton();
			this.lstFoundEntries = new System.Windows.Forms.ListBox();
			this.chkUseDateRange = new System.Windows.Forms.CheckBox();
			this.chkUseDate = new System.Windows.Forms.CheckBox();
			this.lstLabelsForSearch = new System.Windows.Forms.CheckedListBox();
			this.label17 = new System.Windows.Forms.Label();
			this.dtFindDate = new System.Windows.Forms.DateTimePicker();
			this.txtSearchText = new System.Windows.Forms.TextBox();
			this.txtSearchTitle = new System.Windows.Forms.TextBox();
			this.dtFindDate_To = new System.Windows.Forms.DateTimePicker();
			this.label12 = new System.Windows.Forms.Label();
			this.dtFindDate_From = new System.Windows.Forms.DateTimePicker();
			this.rtbSelectedEntry_Found = new System.Windows.Forms.RichTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.lblSelectionType = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblFoundEntries = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearFieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.grpFindEntry.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpFindEntry
			// 
			this.grpFindEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpFindEntry.Controls.Add(this.lblSeparator);
			this.grpFindEntry.Controls.Add(this.radBtnAnd);
			this.grpFindEntry.Controls.Add(this.radBtnOr);
			this.grpFindEntry.Controls.Add(this.lstFoundEntries);
			this.grpFindEntry.Controls.Add(this.chkUseDateRange);
			this.grpFindEntry.Controls.Add(this.chkUseDate);
			this.grpFindEntry.Controls.Add(this.lstLabelsForSearch);
			this.grpFindEntry.Controls.Add(this.label17);
			this.grpFindEntry.Controls.Add(this.dtFindDate);
			this.grpFindEntry.Controls.Add(this.txtSearchText);
			this.grpFindEntry.Controls.Add(this.txtSearchTitle);
			this.grpFindEntry.Controls.Add(this.dtFindDate_To);
			this.grpFindEntry.Controls.Add(this.label12);
			this.grpFindEntry.Controls.Add(this.dtFindDate_From);
			this.grpFindEntry.Controls.Add(this.rtbSelectedEntry_Found);
			this.grpFindEntry.Controls.Add(this.label9);
			this.grpFindEntry.Controls.Add(this.lblSelectionType);
			this.grpFindEntry.Controls.Add(this.label8);
			this.grpFindEntry.Controls.Add(this.lblFoundEntries);
			this.grpFindEntry.Location = new System.Drawing.Point(16, 22);
			this.grpFindEntry.Name = "grpFindEntry";
			this.grpFindEntry.Size = new System.Drawing.Size(430, 439);
			this.grpFindEntry.TabIndex = 7;
			this.grpFindEntry.TabStop = false;
			// 
			// lblSeparator
			// 
			this.lblSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSeparator.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.lblSeparator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblSeparator.ForeColor = System.Drawing.Color.Red;
			this.lblSeparator.Location = new System.Drawing.Point(105, 270);
			this.lblSeparator.Name = "lblSeparator";
			this.lblSeparator.Size = new System.Drawing.Size(313, 19);
			this.lblSeparator.TabIndex = 37;
			this.lblSeparator.Text = resources.GetString("lblSeparator.Text");
			this.lblSeparator.Visible = false;
			this.lblSeparator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSeparator_MouseMove);
			// 
			// radBtnAnd
			// 
			this.radBtnAnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radBtnAnd.AutoSize = true;
			this.radBtnAnd.Location = new System.Drawing.Point(237, 36);
			this.radBtnAnd.Name = "radBtnAnd";
			this.radBtnAnd.Size = new System.Drawing.Size(45, 19);
			this.radBtnAnd.TabIndex = 36;
			this.radBtnAnd.TabStop = true;
			this.radBtnAnd.Text = "and";
			this.radBtnAnd.UseVisualStyleBackColor = true;
			// 
			// radBtnOr
			// 
			this.radBtnOr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radBtnOr.AutoSize = true;
			this.radBtnOr.Checked = true;
			this.radBtnOr.Location = new System.Drawing.Point(199, 36);
			this.radBtnOr.Name = "radBtnOr";
			this.radBtnOr.Size = new System.Drawing.Size(36, 19);
			this.radBtnOr.TabIndex = 35;
			this.radBtnOr.TabStop = true;
			this.radBtnOr.Text = "or";
			this.radBtnOr.UseVisualStyleBackColor = true;
			// 
			// lstFoundEntries
			// 
			this.lstFoundEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstFoundEntries.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstFoundEntries.FormattingEnabled = true;
			this.lstFoundEntries.ItemHeight = 15;
			this.lstFoundEntries.Location = new System.Drawing.Point(6, 165);
			this.lstFoundEntries.Name = "lstFoundEntries";
			this.lstFoundEntries.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstFoundEntries.Size = new System.Drawing.Size(418, 105);
			this.lstFoundEntries.TabIndex = 14;
			this.lstFoundEntries.SelectedIndexChanged += new System.EventHandler(this.lstFoundEntries_SelectedIndexChanged);
			// 
			// chkUseDateRange
			// 
			this.chkUseDateRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkUseDateRange.AutoSize = true;
			this.chkUseDateRange.Location = new System.Drawing.Point(149, 120);
			this.chkUseDateRange.Name = "chkUseDateRange";
			this.chkUseDateRange.Size = new System.Drawing.Size(82, 19);
			this.chkUseDateRange.TabIndex = 34;
			this.chkUseDateRange.Text = "date range";
			this.chkUseDateRange.UseVisualStyleBackColor = true;
			this.chkUseDateRange.CheckedChanged += new System.EventHandler(this.chkUseDateRange_CheckedChanged);
			// 
			// chkUseDate
			// 
			this.chkUseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkUseDate.AutoSize = true;
			this.chkUseDate.Location = new System.Drawing.Point(149, 90);
			this.chkUseDate.Name = "chkUseDate";
			this.chkUseDate.Size = new System.Drawing.Size(49, 19);
			this.chkUseDate.TabIndex = 33;
			this.chkUseDate.Text = "date";
			this.chkUseDate.UseVisualStyleBackColor = true;
			this.chkUseDate.CheckedChanged += new System.EventHandler(this.chkUseDate_CheckedChanged);
			// 
			// lstLabelsForSearch
			// 
			this.lstLabelsForSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstLabelsForSearch.CheckOnClick = true;
			this.lstLabelsForSearch.FormattingEnabled = true;
			this.lstLabelsForSearch.Location = new System.Drawing.Point(6, 30);
			this.lstLabelsForSearch.Name = "lstLabelsForSearch";
			this.lstLabelsForSearch.Size = new System.Drawing.Size(127, 112);
			this.lstLabelsForSearch.TabIndex = 29;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label17.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label17.Location = new System.Drawing.Point(3, 10);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(51, 17);
			this.label17.TabIndex = 26;
			this.label17.Text = "Labels:";
			// 
			// dtFindDate
			// 
			this.dtFindDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtFindDate.CustomFormat = "M/d/yyyy";
			this.dtFindDate.Enabled = false;
			this.dtFindDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtFindDate.Location = new System.Drawing.Point(199, 88);
			this.dtFindDate.Name = "dtFindDate";
			this.dtFindDate.ShowUpDown = true;
			this.dtFindDate.Size = new System.Drawing.Size(79, 23);
			this.dtFindDate.TabIndex = 17;
			this.dtFindDate.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// txtSearchText
			// 
			this.txtSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearchText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtSearchText.Location = new System.Drawing.Point(196, 57);
			this.txtSearchText.Name = "txtSearchText";
			this.txtSearchText.Size = new System.Drawing.Size(222, 16);
			this.txtSearchText.TabIndex = 22;
			// 
			// txtSearchTitle
			// 
			this.txtSearchTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearchTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtSearchTitle.Location = new System.Drawing.Point(192, 19);
			this.txtSearchTitle.Name = "txtSearchTitle";
			this.txtSearchTitle.Size = new System.Drawing.Size(226, 16);
			this.txtSearchTitle.TabIndex = 21;
			// 
			// dtFindDate_To
			// 
			this.dtFindDate_To.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtFindDate_To.CustomFormat = "M/d/yyyy";
			this.dtFindDate_To.Enabled = false;
			this.dtFindDate_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtFindDate_To.Location = new System.Drawing.Point(339, 118);
			this.dtFindDate_To.Name = "dtFindDate_To";
			this.dtFindDate_To.ShowUpDown = true;
			this.dtFindDate_To.Size = new System.Drawing.Size(79, 23);
			this.dtFindDate_To.TabIndex = 20;
			this.dtFindDate_To.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(316, 122);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(18, 15);
			this.label12.TabIndex = 19;
			this.label12.Text = "to";
			// 
			// dtFindDate_From
			// 
			this.dtFindDate_From.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtFindDate_From.CustomFormat = "M/d/yyyy";
			this.dtFindDate_From.Enabled = false;
			this.dtFindDate_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtFindDate_From.Location = new System.Drawing.Point(233, 118);
			this.dtFindDate_From.Name = "dtFindDate_From";
			this.dtFindDate_From.ShowUpDown = true;
			this.dtFindDate_From.Size = new System.Drawing.Size(79, 23);
			this.dtFindDate_From.TabIndex = 18;
			this.dtFindDate_From.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// rtbSelectedEntry_Found
			// 
			this.rtbSelectedEntry_Found.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbSelectedEntry_Found.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbSelectedEntry_Found.Location = new System.Drawing.Point(6, 294);
			this.rtbSelectedEntry_Found.Name = "rtbSelectedEntry_Found";
			this.rtbSelectedEntry_Found.Size = new System.Drawing.Size(418, 139);
			this.rtbSelectedEntry_Found.TabIndex = 12;
			this.rtbSelectedEntry_Found.Text = "";
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label9.Location = new System.Drawing.Point(148, 55);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(45, 17);
			this.label9.TabIndex = 3;
			this.label9.Text = "Entry:";
			// 
			// lblSelectionType
			// 
			this.lblSelectionType.AutoSize = true;
			this.lblSelectionType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblSelectionType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblSelectionType.Location = new System.Drawing.Point(3, 273);
			this.lblSelectionType.Name = "lblSelectionType";
			this.lblSelectionType.Size = new System.Drawing.Size(96, 17);
			this.lblSelectionType.TabIndex = 15;
			this.lblSelectionType.Text = "Selected Entry";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label8.Location = new System.Drawing.Point(149, 19);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 17);
			this.label8.TabIndex = 2;
			this.label8.Text = "Title:";
			// 
			// lblFoundEntries
			// 
			this.lblFoundEntries.AutoSize = true;
			this.lblFoundEntries.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblFoundEntries.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblFoundEntries.Location = new System.Drawing.Point(3, 144);
			this.lblFoundEntries.Name = "lblFoundEntries";
			this.lblFoundEntries.Size = new System.Drawing.Size(93, 17);
			this.lblFoundEntries.TabIndex = 13;
			this.lblFoundEntries.Text = "Found Entries";
			this.lblFoundEntries.Visible = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.clearFieldsToolStripMenuItem,
            this.mnuExit});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(458, 24);
			this.menuStrip1.TabIndex = 8;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.searchToolStripMenuItem.Text = "Search";
			this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
			// 
			// clearFieldsToolStripMenuItem
			// 
			this.clearFieldsToolStripMenuItem.Name = "clearFieldsToolStripMenuItem";
			this.clearFieldsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
			this.clearFieldsToolStripMenuItem.Text = "Clear Fields";
			// 
			// mnuExit
			// 
			this.mnuExit.Name = "mnuExit";
			this.mnuExit.Size = new System.Drawing.Size(38, 20);
			this.mnuExit.Text = "Exit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// frmSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(458, 473);
			this.Controls.Add(this.grpFindEntry);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(474, 512);
			this.Name = "frmSearch";
			this.Text = "Search";
			this.grpFindEntry.ResumeLayout(false);
			this.grpFindEntry.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox grpFindEntry;
		private System.Windows.Forms.ListBox lstFoundEntries;
		private System.Windows.Forms.CheckBox chkUseDateRange;
		private System.Windows.Forms.CheckBox chkUseDate;
		private System.Windows.Forms.CheckedListBox lstLabelsForSearch;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.DateTimePicker dtFindDate;
		private System.Windows.Forms.TextBox txtSearchText;
		private System.Windows.Forms.TextBox txtSearchTitle;
		private System.Windows.Forms.DateTimePicker dtFindDate_To;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.DateTimePicker dtFindDate_From;
		private System.Windows.Forms.RichTextBox rtbSelectedEntry_Found;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblSelectionType;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblFoundEntries;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearFieldsToolStripMenuItem;
		private System.Windows.Forms.RadioButton radBtnAnd;
		private System.Windows.Forms.RadioButton radBtnOr;
		private System.Windows.Forms.Label lblSeparator;
		private System.Windows.Forms.ToolStripMenuItem mnuExit;
	}
}