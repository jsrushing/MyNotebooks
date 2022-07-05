
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
			this.grpFindEntry = new System.Windows.Forms.GroupBox();
			this.lstFoundEntries = new System.Windows.Forms.ListBox();
			this.chkUseDateRange = new System.Windows.Forms.CheckBox();
			this.chkUseDate = new System.Windows.Forms.CheckBox();
			this.lstGroupsForSearch = new System.Windows.Forms.CheckedListBox();
			this.txtGroupsForSearch = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.lblClearAll = new System.Windows.Forms.Label();
			this.dtFindDate = new System.Windows.Forms.DateTimePicker();
			this.txtSearchText = new System.Windows.Forms.TextBox();
			this.txtSearchTitle = new System.Windows.Forms.TextBox();
			this.dtFindDate_To = new System.Windows.Forms.DateTimePicker();
			this.label12 = new System.Windows.Forms.Label();
			this.dtFindDate_From = new System.Windows.Forms.DateTimePicker();
			this.lblFindEntries = new System.Windows.Forms.Label();
			this.rtbSelectedEntry_Found = new System.Windows.Forms.RichTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.lblSelectedFoundEntry = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblFoundEntries = new System.Windows.Forms.Label();
			this.grpFindEntry.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpFindEntry
			// 
			this.grpFindEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpFindEntry.Controls.Add(this.lstFoundEntries);
			this.grpFindEntry.Controls.Add(this.chkUseDateRange);
			this.grpFindEntry.Controls.Add(this.chkUseDate);
			this.grpFindEntry.Controls.Add(this.lstGroupsForSearch);
			this.grpFindEntry.Controls.Add(this.txtGroupsForSearch);
			this.grpFindEntry.Controls.Add(this.label17);
			this.grpFindEntry.Controls.Add(this.lblClearAll);
			this.grpFindEntry.Controls.Add(this.dtFindDate);
			this.grpFindEntry.Controls.Add(this.txtSearchText);
			this.grpFindEntry.Controls.Add(this.txtSearchTitle);
			this.grpFindEntry.Controls.Add(this.dtFindDate_To);
			this.grpFindEntry.Controls.Add(this.label12);
			this.grpFindEntry.Controls.Add(this.dtFindDate_From);
			this.grpFindEntry.Controls.Add(this.lblFindEntries);
			this.grpFindEntry.Controls.Add(this.rtbSelectedEntry_Found);
			this.grpFindEntry.Controls.Add(this.label9);
			this.grpFindEntry.Controls.Add(this.lblSelectedFoundEntry);
			this.grpFindEntry.Controls.Add(this.label8);
			this.grpFindEntry.Controls.Add(this.lblFoundEntries);
			this.grpFindEntry.Location = new System.Drawing.Point(16, -8);
			this.grpFindEntry.Name = "grpFindEntry";
			this.grpFindEntry.Size = new System.Drawing.Size(409, 469);
			this.grpFindEntry.TabIndex = 7;
			this.grpFindEntry.TabStop = false;
			// 
			// lstFoundEntries
			// 
			this.lstFoundEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstFoundEntries.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstFoundEntries.FormattingEnabled = true;
			this.lstFoundEntries.ItemHeight = 15;
			this.lstFoundEntries.Location = new System.Drawing.Point(6, 198);
			this.lstFoundEntries.Name = "lstFoundEntries";
			this.lstFoundEntries.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstFoundEntries.Size = new System.Drawing.Size(397, 105);
			this.lstFoundEntries.TabIndex = 14;
			// 
			// chkUseDateRange
			// 
			this.chkUseDateRange.AutoSize = true;
			this.chkUseDateRange.Location = new System.Drawing.Point(11, 16);
			this.chkUseDateRange.Name = "chkUseDateRange";
			this.chkUseDateRange.Size = new System.Drawing.Size(103, 19);
			this.chkUseDateRange.TabIndex = 34;
			this.chkUseDateRange.Text = "use date range";
			this.chkUseDateRange.UseVisualStyleBackColor = true;
			// 
			// chkUseDate
			// 
			this.chkUseDate.AutoSize = true;
			this.chkUseDate.Location = new System.Drawing.Point(11, 47);
			this.chkUseDate.Name = "chkUseDate";
			this.chkUseDate.Size = new System.Drawing.Size(70, 19);
			this.chkUseDate.TabIndex = 33;
			this.chkUseDate.Text = "use date";
			this.chkUseDate.UseVisualStyleBackColor = true;
			// 
			// lstGroupsForSearch
			// 
			this.lstGroupsForSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstGroupsForSearch.CheckOnClick = true;
			this.lstGroupsForSearch.FormattingEnabled = true;
			this.lstGroupsForSearch.Location = new System.Drawing.Point(56, 181);
			this.lstGroupsForSearch.Name = "lstGroupsForSearch";
			this.lstGroupsForSearch.Size = new System.Drawing.Size(383, 76);
			this.lstGroupsForSearch.TabIndex = 29;
			this.lstGroupsForSearch.Visible = false;
			// 
			// txtGroupsForSearch
			// 
			this.txtGroupsForSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtGroupsForSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtGroupsForSearch.Location = new System.Drawing.Point(107, 81);
			this.txtGroupsForSearch.Name = "txtGroupsForSearch";
			this.txtGroupsForSearch.Size = new System.Drawing.Size(292, 16);
			this.txtGroupsForSearch.TabIndex = 27;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label17.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label17.Location = new System.Drawing.Point(56, 80);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(48, 17);
			this.label17.TabIndex = 26;
			this.label17.Text = "tag(s):";
			// 
			// lblClearAll
			// 
			this.lblClearAll.AutoSize = true;
			this.lblClearAll.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblClearAll.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblClearAll.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblClearAll.Location = new System.Drawing.Point(224, 168);
			this.lblClearAll.Name = "lblClearAll";
			this.lblClearAll.Size = new System.Drawing.Size(52, 15);
			this.lblClearAll.TabIndex = 24;
			this.lblClearAll.Text = "Clear All";
			// 
			// dtFindDate
			// 
			this.dtFindDate.CustomFormat = "M/d/yyyy";
			this.dtFindDate.Enabled = false;
			this.dtFindDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtFindDate.Location = new System.Drawing.Point(83, 44);
			this.dtFindDate.Name = "dtFindDate";
			this.dtFindDate.ShowUpDown = true;
			this.dtFindDate.Size = new System.Drawing.Size(79, 23);
			this.dtFindDate.TabIndex = 17;
			this.dtFindDate.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// txtSearchText
			// 
			this.txtSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearchText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtSearchText.Location = new System.Drawing.Point(107, 138);
			this.txtSearchText.Name = "txtSearchText";
			this.txtSearchText.Size = new System.Drawing.Size(292, 16);
			this.txtSearchText.TabIndex = 22;
			// 
			// txtSearchTitle
			// 
			this.txtSearchTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearchTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtSearchTitle.Location = new System.Drawing.Point(107, 109);
			this.txtSearchTitle.Name = "txtSearchTitle";
			this.txtSearchTitle.Size = new System.Drawing.Size(292, 16);
			this.txtSearchTitle.TabIndex = 21;
			// 
			// dtFindDate_To
			// 
			this.dtFindDate_To.CustomFormat = "M/d/yyyy";
			this.dtFindDate_To.Enabled = false;
			this.dtFindDate_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtFindDate_To.Location = new System.Drawing.Point(223, 14);
			this.dtFindDate_To.Name = "dtFindDate_To";
			this.dtFindDate_To.ShowUpDown = true;
			this.dtFindDate_To.Size = new System.Drawing.Size(79, 23);
			this.dtFindDate_To.TabIndex = 20;
			this.dtFindDate_To.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(200, 18);
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
			this.dtFindDate_From.Location = new System.Drawing.Point(117, 14);
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
			this.lblFindEntries.Location = new System.Drawing.Point(118, 168);
			this.lblFindEntries.Name = "lblFindEntries";
			this.lblFindEntries.Size = new System.Drawing.Size(59, 15);
			this.lblFindEntries.TabIndex = 16;
			this.lblFindEntries.Text = "Find Now";
			// 
			// rtbSelectedEntry_Found
			// 
			this.rtbSelectedEntry_Found.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbSelectedEntry_Found.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbSelectedEntry_Found.Location = new System.Drawing.Point(6, 334);
			this.rtbSelectedEntry_Found.Name = "rtbSelectedEntry_Found";
			this.rtbSelectedEntry_Found.Size = new System.Drawing.Size(397, 88);
			this.rtbSelectedEntry_Found.TabIndex = 12;
			this.rtbSelectedEntry_Found.Text = "";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label9.Location = new System.Drawing.Point(3, 137);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(101, 17);
			this.label9.TabIndex = 3;
			this.label9.Text = "Entry contains:";
			// 
			// lblSelectedFoundEntry
			// 
			this.lblSelectedFoundEntry.AutoSize = true;
			this.lblSelectedFoundEntry.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblSelectedFoundEntry.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblSelectedFoundEntry.Location = new System.Drawing.Point(3, 313);
			this.lblSelectedFoundEntry.Name = "lblSelectedFoundEntry";
			this.lblSelectedFoundEntry.Size = new System.Drawing.Size(96, 17);
			this.lblSelectedFoundEntry.TabIndex = 15;
			this.lblSelectedFoundEntry.Text = "Selected Entry";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label8.Location = new System.Drawing.Point(8, 108);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(96, 17);
			this.label8.TabIndex = 2;
			this.label8.Text = "Title contains:";
			// 
			// lblFoundEntries
			// 
			this.lblFoundEntries.AutoSize = true;
			this.lblFoundEntries.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblFoundEntries.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblFoundEntries.Location = new System.Drawing.Point(3, 177);
			this.lblFoundEntries.Name = "lblFoundEntries";
			this.lblFoundEntries.Size = new System.Drawing.Size(93, 17);
			this.lblFoundEntries.TabIndex = 13;
			this.lblFoundEntries.Text = "Found Entries";
			this.lblFoundEntries.Visible = false;
			// 
			// frmSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(440, 473);
			this.Controls.Add(this.grpFindEntry);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmSearch";
			this.Text = "Search";
			this.grpFindEntry.ResumeLayout(false);
			this.grpFindEntry.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpFindEntry;
		private System.Windows.Forms.ListBox lstFoundEntries;
		private System.Windows.Forms.CheckBox chkUseDateRange;
		private System.Windows.Forms.CheckBox chkUseDate;
		private System.Windows.Forms.CheckedListBox lstGroupsForSearch;
		private System.Windows.Forms.TextBox txtGroupsForSearch;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label lblClearAll;
		private System.Windows.Forms.DateTimePicker dtFindDate;
		private System.Windows.Forms.TextBox txtSearchText;
		private System.Windows.Forms.TextBox txtSearchTitle;
		private System.Windows.Forms.DateTimePicker dtFindDate_To;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.DateTimePicker dtFindDate_From;
		private System.Windows.Forms.Label lblFindEntries;
		private System.Windows.Forms.RichTextBox rtbSelectedEntry_Found;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblSelectedFoundEntry;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblFoundEntries;
	}
}