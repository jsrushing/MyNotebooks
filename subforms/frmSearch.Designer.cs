
using System.Windows.Forms;

namespace myNotebooks.subforms
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
			grpFindEntry = new GroupBox();
			btnSearch = new Button();
			lstEntryObjects = new ListBox();
			pnlLabels_AndOr = new Panel();
			radLabels_Or = new RadioButton();
			radLabels_And = new RadioButton();
			lblSearchingIn = new Label();
			btnSelectNotebooks = new Button();
			label2 = new Label();
			chkMatchWholeWord = new CheckBox();
			chkMatchCase = new CheckBox();
			lblSeparator = new Label();
			radBtnAnd = new RadioButton();
			radBtnOr = new RadioButton();
			lstFoundEntries = new ListBox();
			mnuEntryEditTop = new ContextMenuStrip(components);
			mnuEntryEdit = new ToolStripMenuItem();
			chkUseDateRange = new CheckBox();
			chkUseDate = new CheckBox();
			lstLabelsForSearch = new CheckedListBox();
			label17 = new Label();
			dtFindDate = new DateTimePicker();
			txtSearchText = new TextBox();
			txtSearchTitle = new TextBox();
			dtFindDate_To = new DateTimePicker();
			label12 = new Label();
			dtFindDate_From = new DateTimePicker();
			rtbSelectedEntry_Found = new RichTextBox();
			label9 = new Label();
			lblSelectionType = new Label();
			label8 = new Label();
			mnuEditEntry = new ToolStripMenuItem();
			grpFindEntry.SuspendLayout();
			pnlLabels_AndOr.SuspendLayout();
			mnuEntryEditTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpFindEntry
			// 
			grpFindEntry.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			grpFindEntry.Controls.Add(btnSearch);
			grpFindEntry.Controls.Add(lstEntryObjects);
			grpFindEntry.Controls.Add(pnlLabels_AndOr);
			grpFindEntry.Controls.Add(lblSearchingIn);
			grpFindEntry.Controls.Add(btnSelectNotebooks);
			grpFindEntry.Controls.Add(label2);
			grpFindEntry.Controls.Add(chkMatchWholeWord);
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
			grpFindEntry.Location = new System.Drawing.Point(16, 22);
			grpFindEntry.Name = "grpFindEntry";
			grpFindEntry.Size = new System.Drawing.Size(683, 717);
			grpFindEntry.TabIndex = 7;
			grpFindEntry.TabStop = false;
			// 
			// btnSearch
			// 
			btnSearch.Location = new System.Drawing.Point(488, 133);
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
			lstEntryObjects.Location = new System.Drawing.Point(557, 121);
			lstEntryObjects.Name = "lstEntryObjects";
			lstEntryObjects.Size = new System.Drawing.Size(120, 34);
			lstEntryObjects.TabIndex = 50;
			lstEntryObjects.Visible = false;
			// 
			// pnlLabels_AndOr
			// 
			pnlLabels_AndOr.Controls.Add(radLabels_Or);
			pnlLabels_AndOr.Controls.Add(radLabels_And);
			pnlLabels_AndOr.Location = new System.Drawing.Point(54, 5);
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
			// lblSearchingIn
			// 
			lblSearchingIn.AutoSize = true;
			lblSearchingIn.Location = new System.Drawing.Point(149, 18);
			lblSearchingIn.Name = "lblSearchingIn";
			lblSearchingIn.Size = new System.Drawing.Size(186, 15);
			lblSearchingIn.TabIndex = 47;
			lblSearchingIn.Text = "Searching in 3 selected notebooks";
			// 
			// btnSelectNotebooks
			// 
			btnSelectNotebooks.Location = new System.Drawing.Point(343, 14);
			btnSelectNotebooks.Name = "btnSelectNotebooks";
			btnSelectNotebooks.Size = new System.Drawing.Size(116, 23);
			btnSelectNotebooks.TabIndex = 45;
			btnSelectNotebooks.Text = "select notebooks";
			btnSelectNotebooks.UseVisualStyleBackColor = true;
			btnSelectNotebooks.Click += this.btnSelectNotebooks_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(278, 73);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(47, 15);
			label2.TabIndex = 42;
			label2.Text = "match: ";
			// 
			// chkMatchWholeWord
			// 
			chkMatchWholeWord.AutoSize = true;
			chkMatchWholeWord.Location = new System.Drawing.Point(372, 72);
			chkMatchWholeWord.Name = "chkMatchWholeWord";
			chkMatchWholeWord.Size = new System.Drawing.Size(88, 19);
			chkMatchWholeWord.TabIndex = 41;
			chkMatchWholeWord.Text = "whole word";
			chkMatchWholeWord.UseVisualStyleBackColor = true;
			// 
			// chkMatchCase
			// 
			chkMatchCase.AutoSize = true;
			chkMatchCase.Location = new System.Drawing.Point(325, 72);
			chkMatchCase.Name = "chkMatchCase";
			chkMatchCase.Size = new System.Drawing.Size(15, 14);
			chkMatchCase.TabIndex = 38;
			// 
			// lblSeparator
			// 
			lblSeparator.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			lblSeparator.Cursor = Cursors.HSplit;
			lblSeparator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			lblSeparator.ForeColor = System.Drawing.Color.Red;
			lblSeparator.Location = new System.Drawing.Point(105, 433);
			lblSeparator.Name = "lblSeparator";
			lblSeparator.Size = new System.Drawing.Size(566, 19);
			lblSeparator.TabIndex = 37;
			lblSeparator.Text = resources.GetString("lblSeparator.Text");
			lblSeparator.Visible = false;
			lblSeparator.MouseMove += this.lblSeparator_MouseMove;
			// 
			// radBtnAnd
			// 
			radBtnAnd.AutoSize = true;
			radBtnAnd.Location = new System.Drawing.Point(216, 71);
			radBtnAnd.Name = "radBtnAnd";
			radBtnAnd.Size = new System.Drawing.Size(45, 19);
			radBtnAnd.TabIndex = 36;
			radBtnAnd.Text = "and";
			radBtnAnd.UseVisualStyleBackColor = true;
			// 
			// radBtnOr
			// 
			radBtnOr.AutoSize = true;
			radBtnOr.Checked = true;
			radBtnOr.Location = new System.Drawing.Point(181, 71);
			radBtnOr.Name = "radBtnOr";
			radBtnOr.Size = new System.Drawing.Size(36, 19);
			radBtnOr.TabIndex = 35;
			radBtnOr.TabStop = true;
			radBtnOr.Text = "or";
			radBtnOr.UseVisualStyleBackColor = true;
			// 
			// lstFoundEntries
			// 
			lstFoundEntries.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			lstFoundEntries.BorderStyle = BorderStyle.FixedSingle;
			lstFoundEntries.ContextMenuStrip = mnuEntryEditTop;
			lstFoundEntries.FormattingEnabled = true;
			lstFoundEntries.ItemHeight = 15;
			lstFoundEntries.Location = new System.Drawing.Point(6, 175);
			lstFoundEntries.Name = "lstFoundEntries";
			lstFoundEntries.SelectionMode = SelectionMode.MultiSimple;
			lstFoundEntries.Size = new System.Drawing.Size(671, 257);
			lstFoundEntries.TabIndex = 14;
			lstFoundEntries.UseTabStops = false;
			lstFoundEntries.SelectedIndexChanged += this.lstFoundEntries_SelectedIndexChanged;
			lstFoundEntries.MouseUp += this.lstFoundEntries_MouseUp;
			// 
			// mnuEntryEditTop
			// 
			mnuEntryEditTop.Items.AddRange(new ToolStripItem[] { mnuEntryEdit });
			mnuEntryEditTop.Name = "mnuEntryEditTop";
			mnuEntryEditTop.Size = new System.Drawing.Size(125, 26);
			// 
			// mnuEntryEdit
			// 
			mnuEntryEdit.Name = "mnuEntryEdit";
			mnuEntryEdit.Size = new System.Drawing.Size(124, 22);
			mnuEntryEdit.Text = "Edit Entry";
			mnuEntryEdit.Click += this.mnuEditEntry_Click;
			// 
			// chkUseDateRange
			// 
			chkUseDateRange.AutoSize = true;
			chkUseDateRange.Location = new System.Drawing.Point(169, 149);
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
			chkUseDate.Location = new System.Drawing.Point(169, 123);
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
			lstLabelsForSearch.IntegralHeight = false;
			lstLabelsForSearch.Location = new System.Drawing.Point(6, 30);
			lstLabelsForSearch.Name = "lstLabelsForSearch";
			lstLabelsForSearch.Size = new System.Drawing.Size(137, 140);
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
			dtFindDate.Format = DateTimePickerFormat.Custom;
			dtFindDate.Location = new System.Drawing.Point(220, 121);
			dtFindDate.Name = "dtFindDate";
			dtFindDate.ShowUpDown = true;
			dtFindDate.Size = new System.Drawing.Size(79, 23);
			dtFindDate.TabIndex = 17;
			dtFindDate.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// txtSearchText
			// 
			txtSearchText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtSearchText.BorderStyle = BorderStyle.FixedSingle;
			txtSearchText.Location = new System.Drawing.Point(196, 92);
			txtSearchText.Name = "txtSearchText";
			txtSearchText.Size = new System.Drawing.Size(475, 23);
			txtSearchText.TabIndex = 22;
			// 
			// txtSearchTitle
			// 
			txtSearchTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtSearchTitle.BorderStyle = BorderStyle.FixedSingle;
			txtSearchTitle.Location = new System.Drawing.Point(192, 48);
			txtSearchTitle.Name = "txtSearchTitle";
			txtSearchTitle.Size = new System.Drawing.Size(479, 23);
			txtSearchTitle.TabIndex = 21;
			// 
			// dtFindDate_To
			// 
			dtFindDate_To.CustomFormat = "M/d/yyyy";
			dtFindDate_To.Enabled = false;
			dtFindDate_To.Format = DateTimePickerFormat.Custom;
			dtFindDate_To.Location = new System.Drawing.Point(360, 147);
			dtFindDate_To.Name = "dtFindDate_To";
			dtFindDate_To.ShowUpDown = true;
			dtFindDate_To.Size = new System.Drawing.Size(79, 23);
			dtFindDate_To.TabIndex = 20;
			dtFindDate_To.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(337, 151);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(18, 15);
			label12.TabIndex = 19;
			label12.Text = "to";
			// 
			// dtFindDate_From
			// 
			dtFindDate_From.CustomFormat = "M/d/yyyy";
			dtFindDate_From.Enabled = false;
			dtFindDate_From.Format = DateTimePickerFormat.Custom;
			dtFindDate_From.Location = new System.Drawing.Point(254, 147);
			dtFindDate_From.Name = "dtFindDate_From";
			dtFindDate_From.ShowUpDown = true;
			dtFindDate_From.Size = new System.Drawing.Size(79, 23);
			dtFindDate_From.TabIndex = 18;
			dtFindDate_From.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
			// 
			// rtbSelectedEntry_Found
			// 
			rtbSelectedEntry_Found.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			rtbSelectedEntry_Found.BorderStyle = BorderStyle.FixedSingle;
			rtbSelectedEntry_Found.Location = new System.Drawing.Point(6, 464);
			rtbSelectedEntry_Found.Name = "rtbSelectedEntry_Found";
			rtbSelectedEntry_Found.Size = new System.Drawing.Size(671, 247);
			rtbSelectedEntry_Found.TabIndex = 12;
			rtbSelectedEntry_Found.Text = "";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label9.Location = new System.Drawing.Point(148, 94);
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
			lblSelectionType.Location = new System.Drawing.Point(3, 445);
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
			label8.Location = new System.Drawing.Point(149, 51);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(40, 17);
			label8.TabIndex = 2;
			label8.Text = "Title:";
			// 
			// mnuEditEntry
			// 
			mnuEditEntry.Name = "mnuEditEntry";
			mnuEditEntry.Size = new System.Drawing.Size(32, 19);
			mnuEditEntry.Text = "Edit Entry";
			// 
			// frmSearch
			// 
			AcceptButton = btnSearch;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(711, 751);
			Controls.Add(grpFindEntry);
			MinimumSize = new System.Drawing.Size(509, 512);
			Name = "frmSearch";
			Text = "Search";
			grpFindEntry.ResumeLayout(false);
			grpFindEntry.PerformLayout();
			pnlLabels_AndOr.ResumeLayout(false);
			pnlLabels_AndOr.PerformLayout();
			mnuEntryEditTop.ResumeLayout(false);
			this.ResumeLayout(false);
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
		private System.Windows.Forms.RadioButton radBtnAnd;
		private System.Windows.Forms.RadioButton radBtnOr;
		private System.Windows.Forms.Label lblSeparator;
		private System.Windows.Forms.CheckBox chkMatchCase;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkMatchWholeWord;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Button btnSelectNotebooks;
		private System.Windows.Forms.Label lblSearchingIn;
		private System.Windows.Forms.Panel pnlOkCancel;
		private System.Windows.Forms.RadioButton radLabels_Or;
		private System.Windows.Forms.RadioButton radLabels_And;
		private System.Windows.Forms.Panel pnlLabels_AndOr;
		private System.Windows.Forms.Button btnEditEntry;
		private System.Windows.Forms.ListBox lstEntryObjects;
		private ContextMenuStrip mnuEntryEditTop;
		private ToolStripMenuItem mnuEntryEdit;
		private ToolStripMenuItem mnuEditEntry;
	}
}