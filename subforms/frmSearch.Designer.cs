
using System.ComponentModel;
using System.Windows.Forms;
using MyNotebooks.objects;

namespace MyNotebooks.subforms
{
	partial class frmSearch
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

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
			components = new Container();
			ComponentResourceManager resources = new ComponentResourceManager(typeof(frmSearch));
			grpFindEntry = new GroupBox();
			panel5 = new Panel();
			radTitleText_Or = new RadioButton();
			radTitleText_And = new RadioButton();
			panel4 = new Panel();
			txtSearchText = new TextBox();
			label8 = new Label();
			label9 = new Label();
			txtSearchTitle = new TextBox();
			radTitleOr = new RadioButton();
			radTitle_And = new RadioButton();
			chkMatchCase = new CheckBox();
			chkMatchWholeWord = new CheckBox();
			label2 = new Label();
			panel3 = new Panel();
			radDate_Or = new RadioButton();
			radDate_And = new RadioButton();
			panel2 = new Panel();
			dtFindDate_To = new DateTimePicker();
			dtFindDate_From = new DateTimePicker();
			label12 = new Label();
			dtFindDate = new DateTimePicker();
			chkUseDate = new CheckBox();
			chkUseDateRange = new CheckBox();
			lblSelectAllOrNone = new Label();
			ccb = new CheckedComboBox();
			lblNumEntriesFound = new Label();
			btnExportEntries = new Button();
			btnSearch = new Button();
			lstEntryObjects = new ListBox();
			pnlLabels_AndOr = new Panel();
			radLabels_Or = new RadioButton();
			radLabels_And = new RadioButton();
			lblSeparator = new Label();
			lstFoundEntries = new ListBox();
			mnuEntryEditTop = new ContextMenuStrip(components);
			mnuEntryEdit = new ToolStripMenuItem();
			preserveOriginalTextToolStripMenuItem = new ToolStripMenuItem();
			editOriginalTextToolStripMenuItem = new ToolStripMenuItem();
			mnuDeleteEntry = new ToolStripMenuItem();
			lstLabelsForSearch = new CheckedListBox();
			label17 = new Label();
			rtbSelectedEntry_Found = new RichTextBox();
			lblSelectionType = new Label();
			mnuEditEntry = new ToolStripMenuItem();
			bgWorker = new BackgroundWorker();
			grpFindEntry.SuspendLayout();
			panel5.SuspendLayout();
			panel4.SuspendLayout();
			panel3.SuspendLayout();
			panel2.SuspendLayout();
			pnlLabels_AndOr.SuspendLayout();
			mnuEntryEditTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpFindEntry
			// 
			grpFindEntry.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			grpFindEntry.Controls.Add(panel5);
			grpFindEntry.Controls.Add(panel4);
			grpFindEntry.Controls.Add(panel3);
			grpFindEntry.Controls.Add(panel2);
			grpFindEntry.Controls.Add(lblSelectAllOrNone);
			grpFindEntry.Controls.Add(ccb);
			grpFindEntry.Controls.Add(lblNumEntriesFound);
			grpFindEntry.Controls.Add(btnExportEntries);
			grpFindEntry.Controls.Add(btnSearch);
			grpFindEntry.Controls.Add(lstEntryObjects);
			grpFindEntry.Controls.Add(pnlLabels_AndOr);
			grpFindEntry.Controls.Add(lblSeparator);
			grpFindEntry.Controls.Add(lstFoundEntries);
			grpFindEntry.Controls.Add(lstLabelsForSearch);
			grpFindEntry.Controls.Add(label17);
			grpFindEntry.Controls.Add(rtbSelectedEntry_Found);
			grpFindEntry.Controls.Add(lblSelectionType);
			grpFindEntry.Location = new System.Drawing.Point(16, 22);
			grpFindEntry.Name = "grpFindEntry";
			grpFindEntry.Size = new System.Drawing.Size(787, 638);
			grpFindEntry.TabIndex = 7;
			grpFindEntry.TabStop = false;
			// 
			// panel5
			// 
			panel5.Controls.Add(radTitleText_Or);
			panel5.Controls.Add(radTitleText_And);
			panel5.Location = new System.Drawing.Point(188, 24);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(90, 25);
			panel5.TabIndex = 59;
			// 
			// radTitleText_Or
			// 
			radTitleText_Or.AutoSize = true;
			radTitleText_Or.Checked = true;
			radTitleText_Or.Location = new System.Drawing.Point(2, 4);
			radTitleText_Or.Name = "radTitleText_Or";
			radTitleText_Or.Size = new System.Drawing.Size(36, 19);
			radTitleText_Or.TabIndex = 1;
			radTitleText_Or.TabStop = true;
			radTitleText_Or.Text = "or";
			radTitleText_Or.UseVisualStyleBackColor = true;
			// 
			// radTitleText_And
			// 
			radTitleText_And.AutoSize = true;
			radTitleText_And.Location = new System.Drawing.Point(39, 4);
			radTitleText_And.Name = "radTitleText_And";
			radTitleText_And.Size = new System.Drawing.Size(45, 19);
			radTitleText_And.TabIndex = 0;
			radTitleText_And.Text = "and";
			radTitleText_And.UseVisualStyleBackColor = true;
			// 
			// panel4
			// 
			panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel4.BorderStyle = BorderStyle.FixedSingle;
			panel4.Controls.Add(txtSearchText);
			panel4.Controls.Add(label8);
			panel4.Controls.Add(label9);
			panel4.Controls.Add(txtSearchTitle);
			panel4.Controls.Add(radTitleOr);
			panel4.Controls.Add(radTitle_And);
			panel4.Controls.Add(chkMatchCase);
			panel4.Controls.Add(chkMatchWholeWord);
			panel4.Controls.Add(label2);
			panel4.Location = new System.Drawing.Point(191, 35);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(584, 94);
			panel4.TabIndex = 57;
			// 
			// txtSearchText
			// 
			txtSearchText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtSearchText.BorderStyle = BorderStyle.FixedSingle;
			txtSearchText.Location = new System.Drawing.Point(53, 64);
			txtSearchText.Name = "txtSearchText";
			txtSearchText.Size = new System.Drawing.Size(512, 23);
			txtSearchText.TabIndex = 22;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label8.Location = new System.Drawing.Point(6, 23);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(40, 17);
			label8.TabIndex = 2;
			label8.Text = "Title:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label9.Location = new System.Drawing.Point(5, 66);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(45, 17);
			label9.TabIndex = 3;
			label9.Text = "Entry:";
			// 
			// txtSearchTitle
			// 
			txtSearchTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtSearchTitle.BorderStyle = BorderStyle.FixedSingle;
			txtSearchTitle.Location = new System.Drawing.Point(49, 20);
			txtSearchTitle.Name = "txtSearchTitle";
			txtSearchTitle.Size = new System.Drawing.Size(516, 23);
			txtSearchTitle.TabIndex = 21;
			// 
			// radTitleOr
			// 
			radTitleOr.AutoSize = true;
			radTitleOr.Checked = true;
			radTitleOr.Location = new System.Drawing.Point(81, 44);
			radTitleOr.Name = "radTitleOr";
			radTitleOr.Size = new System.Drawing.Size(36, 19);
			radTitleOr.TabIndex = 35;
			radTitleOr.TabStop = true;
			radTitleOr.Text = "or";
			radTitleOr.UseVisualStyleBackColor = true;
			// 
			// radTitle_And
			// 
			radTitle_And.AutoSize = true;
			radTitle_And.Location = new System.Drawing.Point(119, 44);
			radTitle_And.Name = "radTitle_And";
			radTitle_And.Size = new System.Drawing.Size(45, 19);
			radTitle_And.TabIndex = 36;
			radTitle_And.Text = "and";
			radTitle_And.UseVisualStyleBackColor = true;
			// 
			// chkMatchCase
			// 
			chkMatchCase.AutoSize = true;
			chkMatchCase.Location = new System.Drawing.Point(227, 44);
			chkMatchCase.Name = "chkMatchCase";
			chkMatchCase.Size = new System.Drawing.Size(49, 19);
			chkMatchCase.TabIndex = 38;
			chkMatchCase.Text = "case";
			// 
			// chkMatchWholeWord
			// 
			chkMatchWholeWord.AutoSize = true;
			chkMatchWholeWord.Location = new System.Drawing.Point(279, 44);
			chkMatchWholeWord.Name = "chkMatchWholeWord";
			chkMatchWholeWord.Size = new System.Drawing.Size(88, 19);
			chkMatchWholeWord.TabIndex = 41;
			chkMatchWholeWord.Text = "whole word";
			chkMatchWholeWord.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(178, 46);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(47, 15);
			label2.TabIndex = 42;
			label2.Text = "match: ";
			// 
			// panel3
			// 
			panel3.Controls.Add(radDate_Or);
			panel3.Controls.Add(radDate_And);
			panel3.Location = new System.Drawing.Point(191, 128);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(90, 25);
			panel3.TabIndex = 58;
			// 
			// radDate_Or
			// 
			radDate_Or.AutoSize = true;
			radDate_Or.Checked = true;
			radDate_Or.Location = new System.Drawing.Point(2, 4);
			radDate_Or.Name = "radDate_Or";
			radDate_Or.Size = new System.Drawing.Size(36, 19);
			radDate_Or.TabIndex = 1;
			radDate_Or.TabStop = true;
			radDate_Or.Text = "or";
			radDate_Or.UseVisualStyleBackColor = true;
			// 
			// radDate_And
			// 
			radDate_And.AutoSize = true;
			radDate_And.Location = new System.Drawing.Point(39, 4);
			radDate_And.Name = "radDate_And";
			radDate_And.Size = new System.Drawing.Size(45, 19);
			radDate_And.TabIndex = 0;
			radDate_And.Text = "and";
			radDate_And.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			panel2.BorderStyle = BorderStyle.FixedSingle;
			panel2.Controls.Add(dtFindDate_To);
			panel2.Controls.Add(dtFindDate_From);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(dtFindDate);
			panel2.Controls.Add(chkUseDate);
			panel2.Controls.Add(chkUseDateRange);
			panel2.Location = new System.Drawing.Point(194, 137);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(430, 51);
			panel2.TabIndex = 57;
			// 
			// dtFindDate_To
			// 
			dtFindDate_To.CustomFormat = "M/d/yyyy";
			dtFindDate_To.Enabled = false;
			dtFindDate_To.Format = DateTimePickerFormat.Custom;
			dtFindDate_To.Location = new System.Drawing.Point(344, 21);
			dtFindDate_To.Name = "dtFindDate_To";
			dtFindDate_To.ShowUpDown = true;
			dtFindDate_To.Size = new System.Drawing.Size(79, 23);
			dtFindDate_To.TabIndex = 20;
			dtFindDate_To.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// dtFindDate_From
			// 
			dtFindDate_From.CustomFormat = "M/d/yyyy";
			dtFindDate_From.Enabled = false;
			dtFindDate_From.Format = DateTimePickerFormat.Custom;
			dtFindDate_From.Location = new System.Drawing.Point(238, 21);
			dtFindDate_From.Name = "dtFindDate_From";
			dtFindDate_From.ShowUpDown = true;
			dtFindDate_From.Size = new System.Drawing.Size(79, 23);
			dtFindDate_From.TabIndex = 18;
			dtFindDate_From.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(321, 25);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(18, 15);
			label12.TabIndex = 19;
			label12.Text = "to";
			// 
			// dtFindDate
			// 
			dtFindDate.CustomFormat = "M/d/yyyy";
			dtFindDate.Enabled = false;
			dtFindDate.Format = DateTimePickerFormat.Custom;
			dtFindDate.Location = new System.Drawing.Point(59, 21);
			dtFindDate.Name = "dtFindDate";
			dtFindDate.ShowUpDown = true;
			dtFindDate.Size = new System.Drawing.Size(79, 23);
			dtFindDate.TabIndex = 17;
			dtFindDate.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// chkUseDate
			// 
			chkUseDate.AutoSize = true;
			chkUseDate.Location = new System.Drawing.Point(8, 25);
			chkUseDate.Name = "chkUseDate";
			chkUseDate.Size = new System.Drawing.Size(49, 19);
			chkUseDate.TabIndex = 33;
			chkUseDate.Text = "date";
			chkUseDate.UseVisualStyleBackColor = true;
			chkUseDate.CheckedChanged += this.chkUseDate_CheckedChanged;
			// 
			// chkUseDateRange
			// 
			chkUseDateRange.AutoSize = true;
			chkUseDateRange.Location = new System.Drawing.Point(153, 25);
			chkUseDateRange.Name = "chkUseDateRange";
			chkUseDateRange.Size = new System.Drawing.Size(82, 19);
			chkUseDateRange.TabIndex = 34;
			chkUseDateRange.Text = "date range";
			chkUseDateRange.UseVisualStyleBackColor = true;
			chkUseDateRange.CheckedChanged += this.chkUseDateRange_CheckedChanged;
			// 
			// lblSelectAllOrNone
			// 
			lblSelectAllOrNone.ForeColor = System.Drawing.SystemColors.Highlight;
			lblSelectAllOrNone.Location = new System.Drawing.Point(464, 7);
			lblSelectAllOrNone.Name = "lblSelectAllOrNone";
			lblSelectAllOrNone.Size = new System.Drawing.Size(77, 16);
			lblSelectAllOrNone.TabIndex = 54;
			lblSelectAllOrNone.Text = "unselect all";
			lblSelectAllOrNone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			lblSelectAllOrNone.Click += this.lblSelectAllOrNone_Click;
			// 
			// ccb
			// 
			ccb.CheckOnClick = true;
			ccb.DisplayMember = "Name";
			ccb.DrawMode = DrawMode.OwnerDrawVariable;
			ccb.DropDownHeight = 1;
			ccb.IntegralHeight = false;
			ccb.Location = new System.Drawing.Point(235, 0);
			ccb.Name = "ccb";
			ccb.Size = new System.Drawing.Size(227, 24);
			ccb.TabIndex = 55;
			ccb.ValueMember = "Id";
			ccb.ValueSeparator = ", ";
			ccb.ItemCheck += this.ccb_ItemCheck;
			// 
			// lblNumEntriesFound
			// 
			lblNumEntriesFound.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			lblNumEntriesFound.AutoSize = true;
			lblNumEntriesFound.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			lblNumEntriesFound.Location = new System.Drawing.Point(679, 175);
			lblNumEntriesFound.Name = "lblNumEntriesFound";
			lblNumEntriesFound.Size = new System.Drawing.Size(94, 15);
			lblNumEntriesFound.TabIndex = 52;
			lblNumEntriesFound.Text = "{0} entries found";
			lblNumEntriesFound.Visible = false;
			// 
			// btnExportEntries
			// 
			btnExportEntries.Enabled = false;
			btnExportEntries.Location = new System.Drawing.Point(889, 13);
			btnExportEntries.Name = "btnExportEntries";
			btnExportEntries.Size = new System.Drawing.Size(135, 23);
			btnExportEntries.TabIndex = 51;
			btnExportEntries.Text = "export entries";
			btnExportEntries.UseVisualStyleBackColor = true;
			btnExportEntries.Visible = false;
			btnExportEntries.Click += this.btnExportEntries_Click;
			// 
			// btnSearch
			// 
			btnSearch.Enabled = false;
			btnSearch.Location = new System.Drawing.Point(643, 140);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new System.Drawing.Size(127, 23);
			btnSearch.TabIndex = 43;
			btnSearch.Text = "&Search";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += this.btnSearch_Click;
			// 
			// lstEntryObjects
			// 
			lstEntryObjects.FormattingEnabled = true;
			lstEntryObjects.ItemHeight = 15;
			lstEntryObjects.Location = new System.Drawing.Point(837, 154);
			lstEntryObjects.Name = "lstEntryObjects";
			lstEntryObjects.Size = new System.Drawing.Size(120, 34);
			lstEntryObjects.TabIndex = 50;
			lstEntryObjects.Visible = false;
			// 
			// pnlLabels_AndOr
			// 
			pnlLabels_AndOr.Controls.Add(radLabels_Or);
			pnlLabels_AndOr.Controls.Add(radLabels_And);
			pnlLabels_AndOr.Location = new System.Drawing.Point(87, 5);
			pnlLabels_AndOr.Name = "pnlLabels_AndOr";
			pnlLabels_AndOr.Size = new System.Drawing.Size(90, 25);
			pnlLabels_AndOr.TabIndex = 48;
			// 
			// radLabels_Or
			// 
			radLabels_Or.AutoSize = true;
			radLabels_Or.Checked = true;
			radLabels_Or.Location = new System.Drawing.Point(2, 4);
			radLabels_Or.Name = "radLabels_Or";
			radLabels_Or.Size = new System.Drawing.Size(36, 19);
			radLabels_Or.TabIndex = 1;
			radLabels_Or.TabStop = true;
			radLabels_Or.Text = "or";
			radLabels_Or.UseVisualStyleBackColor = true;
			// 
			// radLabels_And
			// 
			radLabels_And.AutoSize = true;
			radLabels_And.Location = new System.Drawing.Point(39, 4);
			radLabels_And.Name = "radLabels_And";
			radLabels_And.Size = new System.Drawing.Size(45, 19);
			radLabels_And.TabIndex = 0;
			radLabels_And.Text = "and";
			radLabels_And.UseVisualStyleBackColor = true;
			// 
			// lblSeparator
			// 
			lblSeparator.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			lblSeparator.Cursor = Cursors.HSplit;
			lblSeparator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			lblSeparator.ForeColor = System.Drawing.Color.Red;
			lblSeparator.Location = new System.Drawing.Point(105, 376);
			lblSeparator.Name = "lblSeparator";
			lblSeparator.Size = new System.Drawing.Size(670, 19);
			lblSeparator.TabIndex = 37;
			lblSeparator.Text = resources.GetString("lblSeparator.Text");
			lblSeparator.Visible = false;
			lblSeparator.MouseMove += this.lblSeparator_MouseMove;
			// 
			// lstFoundEntries
			// 
			lstFoundEntries.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			lstFoundEntries.BorderStyle = BorderStyle.FixedSingle;
			lstFoundEntries.ContextMenuStrip = mnuEntryEditTop;
			lstFoundEntries.FormattingEnabled = true;
			lstFoundEntries.ItemHeight = 15;
			lstFoundEntries.Location = new System.Drawing.Point(6, 192);
			lstFoundEntries.Name = "lstFoundEntries";
			lstFoundEntries.SelectionMode = SelectionMode.MultiSimple;
			lstFoundEntries.Size = new System.Drawing.Size(775, 182);
			lstFoundEntries.TabIndex = 14;
			lstFoundEntries.UseTabStops = false;
			lstFoundEntries.SelectedIndexChanged += this.lstFoundEntries_SelectedIndexChanged;
			lstFoundEntries.MouseMove += this.lstFoundEntries_MouseMove;
			lstFoundEntries.MouseUp += this.lstFoundEntries_MouseUp;
			// 
			// mnuEntryEditTop
			// 
			mnuEntryEditTop.Items.AddRange(new ToolStripItem[] { mnuEntryEdit, mnuDeleteEntry });
			mnuEntryEditTop.Name = "mnuEntryEditTop";
			mnuEntryEditTop.Size = new System.Drawing.Size(108, 48);
			// 
			// mnuEntryEdit
			// 
			mnuEntryEdit.DropDownItems.AddRange(new ToolStripItem[] { preserveOriginalTextToolStripMenuItem, editOriginalTextToolStripMenuItem });
			mnuEntryEdit.Name = "mnuEntryEdit";
			mnuEntryEdit.Size = new System.Drawing.Size(107, 22);
			mnuEntryEdit.Text = "Edit";
			// 
			// preserveOriginalTextToolStripMenuItem
			// 
			preserveOriginalTextToolStripMenuItem.Name = "preserveOriginalTextToolStripMenuItem";
			preserveOriginalTextToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			preserveOriginalTextToolStripMenuItem.Text = "Preserve Original Text";
			preserveOriginalTextToolStripMenuItem.Click += this.mnuEditEntry_Click;
			// 
			// editOriginalTextToolStripMenuItem
			// 
			editOriginalTextToolStripMenuItem.Name = "editOriginalTextToolStripMenuItem";
			editOriginalTextToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			editOriginalTextToolStripMenuItem.Text = "Edit Original Text";
			editOriginalTextToolStripMenuItem.Click += this.mnuEditEntry_Click;
			// 
			// mnuDeleteEntry
			// 
			mnuDeleteEntry.Name = "mnuDeleteEntry";
			mnuDeleteEntry.Size = new System.Drawing.Size(107, 22);
			mnuDeleteEntry.Text = "Delete";
			mnuDeleteEntry.Click += this.mnuDeleteEntry_Click;
			// 
			// lstLabelsForSearch
			// 
			lstLabelsForSearch.CheckOnClick = true;
			lstLabelsForSearch.FormattingEnabled = true;
			lstLabelsForSearch.IntegralHeight = false;
			lstLabelsForSearch.Location = new System.Drawing.Point(6, 30);
			lstLabelsForSearch.Name = "lstLabelsForSearch";
			lstLabelsForSearch.Size = new System.Drawing.Size(179, 158);
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
			// rtbSelectedEntry_Found
			// 
			rtbSelectedEntry_Found.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			rtbSelectedEntry_Found.BorderStyle = BorderStyle.FixedSingle;
			rtbSelectedEntry_Found.Location = new System.Drawing.Point(6, 408);
			rtbSelectedEntry_Found.Name = "rtbSelectedEntry_Found";
			rtbSelectedEntry_Found.Size = new System.Drawing.Size(775, 224);
			rtbSelectedEntry_Found.TabIndex = 12;
			rtbSelectedEntry_Found.Text = "";
			// 
			// lblSelectionType
			// 
			lblSelectionType.AutoSize = true;
			lblSelectionType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			lblSelectionType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblSelectionType.Location = new System.Drawing.Point(3, 388);
			lblSelectionType.Name = "lblSelectionType";
			lblSelectionType.Size = new System.Drawing.Size(96, 17);
			lblSelectionType.TabIndex = 15;
			lblSelectionType.Text = "Selected Entry";
			// 
			// mnuEditEntry
			// 
			mnuEditEntry.Name = "mnuEditEntry";
			mnuEditEntry.Size = new System.Drawing.Size(32, 19);
			mnuEditEntry.Text = "Edit Entry";
			// 
			// bgWorker
			// 
			bgWorker.WorkerReportsProgress = true;
			// 
			// frmSearch
			// 
			AcceptButton = btnSearch;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(815, 672);
			Controls.Add(grpFindEntry);
			Name = "frmSearch";
			Text = "Search";
			Load += this.frmSearch_Load;
			grpFindEntry.ResumeLayout(false);
			grpFindEntry.PerformLayout();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			pnlLabels_AndOr.ResumeLayout(false);
			pnlLabels_AndOr.PerformLayout();
			mnuEntryEditTop.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		#endregion

		private GroupBox grpFindEntry;
		private ListBox lstFoundEntries;
		private CheckBox chkUseDateRange;
		private CheckBox chkUseDate;
		private CheckedListBox lstLabelsForSearch;
		private Label label17;
		private DateTimePicker dtFindDate;
		private TextBox txtSearchText;
		private TextBox txtSearchTitle;
		private DateTimePicker dtFindDate_To;
		private Label label12;
		private DateTimePicker dtFindDate_From;
		private RichTextBox rtbSelectedEntry_Found;
		private Label label9;
		private Label lblSelectionType;
		private Label label8;
		private RadioButton radTitle_And;
		private RadioButton radTitleOr;
		private Label lblSeparator;
		private CheckBox chkMatchCase;
		private Label label2;
		private CheckBox chkMatchWholeWord;
		private Button btnSearch;
		private RadioButton radLabels_Or;
		private RadioButton radLabels_And;
		private Panel pnlLabels_AndOr;
		private ListBox lstEntryObjects;
		private ContextMenuStrip mnuEntryEditTop;
		private ToolStripMenuItem mnuEntryEdit;
		private ToolStripMenuItem mnuEditEntry;
		private ToolStripMenuItem mnuDeleteEntry;
		private Button btnExportEntries;
		private Label lblNumEntriesFound;
		private ToolStripMenuItem preserveOriginalTextToolStripMenuItem;
		private ToolStripMenuItem editOriginalTextToolStripMenuItem;
		private Label lblSelectAllOrNone;
		private CheckedComboBox ccb;
		BackgroundWorker bgWorker;
		private Panel panel3;
		private RadioButton radDate_Or;
		private RadioButton radDate_And;
		private Panel panel2;
		private Panel panel5;
		private RadioButton radTitleText_Or;
		private RadioButton radTitleText_And;
		private Panel panel4;
	}
}