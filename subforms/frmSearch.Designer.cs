
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
			grpFindEntry = new System.Windows.Forms.GroupBox();
			btnSearch = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			chkMatchWholeWord = new System.Windows.Forms.CheckBox();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			chkMatchCase = new System.Windows.Forms.CheckBox();
			lblSeparator = new System.Windows.Forms.Label();
			radBtnAnd = new System.Windows.Forms.RadioButton();
			radBtnOr = new System.Windows.Forms.RadioButton();
			lstFoundEntries = new System.Windows.Forms.ListBox();
			chkUseDateRange = new System.Windows.Forms.CheckBox();
			chkUseDate = new System.Windows.Forms.CheckBox();
			lstLabelsForSearch = new System.Windows.Forms.CheckedListBox();
			label17 = new System.Windows.Forms.Label();
			dtFindDate = new System.Windows.Forms.DateTimePicker();
			txtSearchText = new System.Windows.Forms.TextBox();
			txtSearchTitle = new System.Windows.Forms.TextBox();
			dtFindDate_To = new System.Windows.Forms.DateTimePicker();
			label12 = new System.Windows.Forms.Label();
			dtFindDate_From = new System.Windows.Forms.DateTimePicker();
			rtbSelectedEntry_Found = new System.Windows.Forms.RichTextBox();
			label9 = new System.Windows.Forms.Label();
			lblSelectionType = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			lblFoundEntries = new System.Windows.Forms.Label();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			mnuSelectJournals = new System.Windows.Forms.ToolStripMenuItem();
			mnuClearFields = new System.Windows.Forms.ToolStripMenuItem();
			mnuExit = new System.Windows.Forms.ToolStripMenuItem();
			grpFindEntry.SuspendLayout();
			menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpFindEntry
			// 
			grpFindEntry.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			grpFindEntry.Controls.Add(btnSearch);
			grpFindEntry.Controls.Add(label2);
			grpFindEntry.Controls.Add(chkMatchWholeWord);
			grpFindEntry.Controls.Add(comboBox1);
			grpFindEntry.Controls.Add(label1);
			grpFindEntry.Controls.Add(chkMatchCase);
			grpFindEntry.Controls.Add(lblSeparator);
			grpFindEntry.Controls.Add(radBtnAnd);
			grpFindEntry.Controls.Add(radBtnOr);
			grpFindEntry.Controls.Add(lstFoundEntries);
			grpFindEntry.Controls.Add(chkUseDateRange);
			grpFindEntry.Controls.Add(chkUseDate);
			grpFindEntry.Controls.Add(lstLabelsForSearch);
			grpFindEntry.Controls.Add(label17);
			grpFindEntry.Controls.Add(dtFindDate);
			grpFindEntry.Controls.Add(txtSearchText);
			grpFindEntry.Controls.Add(txtSearchTitle);
			grpFindEntry.Controls.Add(dtFindDate_To);
			grpFindEntry.Controls.Add(label12);
			grpFindEntry.Controls.Add(dtFindDate_From);
			grpFindEntry.Controls.Add(rtbSelectedEntry_Found);
			grpFindEntry.Controls.Add(label9);
			grpFindEntry.Controls.Add(lblSelectionType);
			grpFindEntry.Controls.Add(label8);
			grpFindEntry.Controls.Add(lblFoundEntries);
			grpFindEntry.Location = new System.Drawing.Point(16, 22);
			grpFindEntry.Name = "grpFindEntry";
			grpFindEntry.Size = new System.Drawing.Size(465, 439);
			grpFindEntry.TabIndex = 7;
			grpFindEntry.TabStop = false;
			// 
			// btnSearch
			// 
			btnSearch.Location = new System.Drawing.Point(338, 106);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new System.Drawing.Size(75, 23);
			btnSearch.TabIndex = 43;
			btnSearch.Text = "&Search";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += this.btnSearch_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(278, 62);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(47, 15);
			label2.TabIndex = 42;
			label2.Text = "match: ";
			// 
			// chkMatchWholeWord
			// 
			chkMatchWholeWord.AutoSize = true;
			chkMatchWholeWord.Location = new System.Drawing.Point(372, 61);
			chkMatchWholeWord.Name = "chkMatchWholeWord";
			chkMatchWholeWord.Size = new System.Drawing.Size(88, 19);
			chkMatchWholeWord.TabIndex = 41;
			chkMatchWholeWord.Text = "whole word";
			chkMatchWholeWord.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(256, 12);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(197, 23);
			comboBox1.TabIndex = 40;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(149, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(105, 15);
			label1.TabIndex = 39;
			label1.Text = "Journals to Search:";
			// 
			// chkMatchCase
			// 
			chkMatchCase.AutoSize = true;
			chkMatchCase.Location = new System.Drawing.Point(325, 61);
			chkMatchCase.Name = "chkMatchCase";
			chkMatchCase.Size = new System.Drawing.Size(49, 19);
			chkMatchCase.TabIndex = 38;
			chkMatchCase.Text = "case";
			chkMatchCase.UseVisualStyleBackColor = true;
			// 
			// lblSeparator
			// 
			lblSeparator.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			lblSeparator.Cursor = System.Windows.Forms.Cursors.HSplit;
			lblSeparator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			lblSeparator.ForeColor = System.Drawing.Color.Red;
			lblSeparator.Location = new System.Drawing.Point(105, 270);
			lblSeparator.Name = "lblSeparator";
			lblSeparator.Size = new System.Drawing.Size(348, 19);
			lblSeparator.TabIndex = 37;
			lblSeparator.Text = resources.GetString("lblSeparator.Text");
			lblSeparator.Visible = false;
			lblSeparator.MouseMove += this.lblSeparator_MouseMove;
			// 
			// radBtnAnd
			// 
			radBtnAnd.AutoSize = true;
			radBtnAnd.Location = new System.Drawing.Point(216, 60);
			radBtnAnd.Name = "radBtnAnd";
			radBtnAnd.Size = new System.Drawing.Size(45, 19);
			radBtnAnd.TabIndex = 36;
			radBtnAnd.TabStop = true;
			radBtnAnd.Text = "and";
			radBtnAnd.UseVisualStyleBackColor = true;
			// 
			// radBtnOr
			// 
			radBtnOr.AutoSize = true;
			radBtnOr.Checked = true;
			radBtnOr.Location = new System.Drawing.Point(181, 60);
			radBtnOr.Name = "radBtnOr";
			radBtnOr.Size = new System.Drawing.Size(36, 19);
			radBtnOr.TabIndex = 35;
			radBtnOr.TabStop = true;
			radBtnOr.Text = "or";
			radBtnOr.UseVisualStyleBackColor = true;
			// 
			// lstFoundEntries
			// 
			lstFoundEntries.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			lstFoundEntries.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lstFoundEntries.FormattingEnabled = true;
			lstFoundEntries.ItemHeight = 15;
			lstFoundEntries.Location = new System.Drawing.Point(6, 165);
			lstFoundEntries.Name = "lstFoundEntries";
			lstFoundEntries.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			lstFoundEntries.Size = new System.Drawing.Size(453, 105);
			lstFoundEntries.TabIndex = 14;
			lstFoundEntries.SelectedIndexChanged += this.lstFoundEntries_SelectedIndexChanged;
			// 
			// chkUseDateRange
			// 
			chkUseDateRange.AutoSize = true;
			chkUseDateRange.Location = new System.Drawing.Point(169, 138);
			chkUseDateRange.Name = "chkUseDateRange";
			chkUseDateRange.Size = new System.Drawing.Size(82, 19);
			chkUseDateRange.TabIndex = 34;
			chkUseDateRange.Text = "date range";
			chkUseDateRange.UseVisualStyleBackColor = true;
			chkUseDateRange.CheckedChanged += this.chkUseDateRange_CheckedChanged;
			// 
			// chkUseDate
			// 
			chkUseDate.AutoSize = true;
			chkUseDate.Location = new System.Drawing.Point(169, 108);
			chkUseDate.Name = "chkUseDate";
			chkUseDate.Size = new System.Drawing.Size(49, 19);
			chkUseDate.TabIndex = 33;
			chkUseDate.Text = "date";
			chkUseDate.UseVisualStyleBackColor = true;
			chkUseDate.CheckedChanged += this.chkUseDate_CheckedChanged;
			// 
			// lstLabelsForSearch
			// 
			lstLabelsForSearch.CheckOnClick = true;
			lstLabelsForSearch.FormattingEnabled = true;
			lstLabelsForSearch.Location = new System.Drawing.Point(6, 30);
			lstLabelsForSearch.Name = "lstLabelsForSearch";
			lstLabelsForSearch.Size = new System.Drawing.Size(137, 112);
			lstLabelsForSearch.TabIndex = 29;
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			label17.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label17.Location = new System.Drawing.Point(3, 10);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(51, 17);
			label17.TabIndex = 26;
			label17.Text = "Labels:";
			// 
			// dtFindDate
			// 
			dtFindDate.CustomFormat = "M/d/yyyy";
			dtFindDate.Enabled = false;
			dtFindDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			dtFindDate.Location = new System.Drawing.Point(220, 106);
			dtFindDate.Name = "dtFindDate";
			dtFindDate.ShowUpDown = true;
			dtFindDate.Size = new System.Drawing.Size(79, 23);
			dtFindDate.TabIndex = 17;
			dtFindDate.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// txtSearchText
			// 
			txtSearchText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtSearchText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			txtSearchText.Location = new System.Drawing.Point(196, 81);
			txtSearchText.Name = "txtSearchText";
			txtSearchText.Size = new System.Drawing.Size(257, 16);
			txtSearchText.TabIndex = 22;
			// 
			// txtSearchTitle
			// 
			txtSearchTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtSearchTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
			txtSearchTitle.Location = new System.Drawing.Point(192, 43);
			txtSearchTitle.Name = "txtSearchTitle";
			txtSearchTitle.Size = new System.Drawing.Size(261, 16);
			txtSearchTitle.TabIndex = 21;
			// 
			// dtFindDate_To
			// 
			dtFindDate_To.CustomFormat = "M/d/yyyy";
			dtFindDate_To.Enabled = false;
			dtFindDate_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			dtFindDate_To.Location = new System.Drawing.Point(360, 136);
			dtFindDate_To.Name = "dtFindDate_To";
			dtFindDate_To.ShowUpDown = true;
			dtFindDate_To.Size = new System.Drawing.Size(79, 23);
			dtFindDate_To.TabIndex = 20;
			dtFindDate_To.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(337, 140);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(18, 15);
			label12.TabIndex = 19;
			label12.Text = "to";
			// 
			// dtFindDate_From
			// 
			dtFindDate_From.CustomFormat = "M/d/yyyy";
			dtFindDate_From.Enabled = false;
			dtFindDate_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			dtFindDate_From.Location = new System.Drawing.Point(254, 136);
			dtFindDate_From.Name = "dtFindDate_From";
			dtFindDate_From.ShowUpDown = true;
			dtFindDate_From.Size = new System.Drawing.Size(79, 23);
			dtFindDate_From.TabIndex = 18;
			dtFindDate_From.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// rtbSelectedEntry_Found
			// 
			rtbSelectedEntry_Found.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			rtbSelectedEntry_Found.BorderStyle = System.Windows.Forms.BorderStyle.None;
			rtbSelectedEntry_Found.Location = new System.Drawing.Point(6, 294);
			rtbSelectedEntry_Found.Name = "rtbSelectedEntry_Found";
			rtbSelectedEntry_Found.Size = new System.Drawing.Size(453, 139);
			rtbSelectedEntry_Found.TabIndex = 12;
			rtbSelectedEntry_Found.Text = "";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label9.Location = new System.Drawing.Point(148, 79);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(45, 17);
			label9.TabIndex = 3;
			label9.Text = "Entry:";
			// 
			// lblSelectionType
			// 
			lblSelectionType.AutoSize = true;
			lblSelectionType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			lblSelectionType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblSelectionType.Location = new System.Drawing.Point(3, 273);
			lblSelectionType.Name = "lblSelectionType";
			lblSelectionType.Size = new System.Drawing.Size(96, 17);
			lblSelectionType.TabIndex = 15;
			lblSelectionType.Text = "Selected Entry";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label8.Location = new System.Drawing.Point(149, 43);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(40, 17);
			label8.TabIndex = 2;
			label8.Text = "Title:";
			// 
			// lblFoundEntries
			// 
			lblFoundEntries.AutoSize = true;
			lblFoundEntries.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			lblFoundEntries.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblFoundEntries.Location = new System.Drawing.Point(3, 144);
			lblFoundEntries.Name = "lblFoundEntries";
			lblFoundEntries.Size = new System.Drawing.Size(93, 17);
			lblFoundEntries.TabIndex = 13;
			lblFoundEntries.Text = "Found Entries";
			lblFoundEntries.Visible = false;
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuSelectJournals, mnuClearFields, mnuExit });
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new System.Drawing.Size(493, 24);
			menuStrip1.TabIndex = 8;
			menuStrip1.Text = "menuStrip1";
			// 
			// mnuSelectJournals
			// 
			mnuSelectJournals.Name = "mnuSelectJournals";
			mnuSelectJournals.Size = new System.Drawing.Size(96, 20);
			mnuSelectJournals.Text = "Select &Journals";
			mnuSelectJournals.Visible = false;
			mnuSelectJournals.Click += this.mnuSelectJournals_Click;
			// 
			// mnuClearFields
			// 
			mnuClearFields.Name = "mnuClearFields";
			mnuClearFields.Size = new System.Drawing.Size(79, 20);
			mnuClearFields.Text = "&Clear Fields";
			mnuClearFields.Click += this.mnuClearFields_Click;
			// 
			// mnuExit
			// 
			mnuExit.Name = "mnuExit";
			mnuExit.Size = new System.Drawing.Size(38, 20);
			mnuExit.Text = "E&xit";
			mnuExit.Click += this.mnuExit_Click;
			// 
			// frmSearch
			// 
			AcceptButton = btnSearch;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(493, 473);
			Controls.Add(grpFindEntry);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			MinimumSize = new System.Drawing.Size(509, 512);
			Name = "frmSearch";
			Text = "Search";
			grpFindEntry.ResumeLayout(false);
			grpFindEntry.PerformLayout();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
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
		private System.Windows.Forms.ToolStripMenuItem mnuClearFields;
		private System.Windows.Forms.RadioButton radBtnAnd;
		private System.Windows.Forms.RadioButton radBtnOr;
		private System.Windows.Forms.Label lblSeparator;
		private System.Windows.Forms.ToolStripMenuItem mnuExit;
		private System.Windows.Forms.CheckBox chkMatchCase;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem mnuSelectJournals;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkMatchWholeWord;
		private System.Windows.Forms.Button btnSearch;
	}
}