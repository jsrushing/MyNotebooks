
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
			clbLabelsInNotebooks = new CheckedListBox();
			panel5 = new Panel();
			radTitleText_Or = new RadioButton();
			radTitle_And = new RadioButton();
			panel4 = new Panel();
			chkMatchCase_Text = new CheckBox();
			txtSearchText = new TextBox();
			label8 = new Label();
			label9 = new Label();
			txtSearchTitle = new TextBox();
			radTitleOr = new RadioButton();
			radText_And = new RadioButton();
			chkMatchCase_Title = new CheckBox();
			panel3 = new Panel();
			panel1 = new Panel();
			radioButton1 = new RadioButton();
			radioButton2 = new RadioButton();
			radDate_Or = new RadioButton();
			radDate_And = new RadioButton();
			panel2 = new Panel();
			dtFindDate_To = new DateTimePicker();
			dtFindDate_From = new DateTimePicker();
			label12 = new Label();
			dtFindDate = new DateTimePicker();
			chkUseDate = new CheckBox();
			chkUseDateRange = new CheckBox();
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
			label17 = new Label();
			rtbSelectedEntry_Found = new RichTextBox();
			lblSelectionType = new Label();
			label3 = new Label();
			ccbNotebooks = new CheckedComboBox();
			mnuEditEntry = new ToolStripMenuItem();
			bgWorker = new BackgroundWorker();
			label1 = new Label();
			ddlNbsToSearch = new ComboBox();
			panel6 = new Panel();
			grpFindEntry.SuspendLayout();
			panel5.SuspendLayout();
			panel4.SuspendLayout();
			panel3.SuspendLayout();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			pnlLabels_AndOr.SuspendLayout();
			mnuEntryEditTop.SuspendLayout();
			panel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpFindEntry
			// 
			grpFindEntry.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			grpFindEntry.Controls.Add(panel6);
			grpFindEntry.Controls.Add(clbLabelsInNotebooks);
			grpFindEntry.Controls.Add(panel5);
			grpFindEntry.Controls.Add(panel4);
			grpFindEntry.Controls.Add(panel3);
			grpFindEntry.Controls.Add(panel2);
			grpFindEntry.Controls.Add(lblNumEntriesFound);
			grpFindEntry.Controls.Add(btnExportEntries);
			grpFindEntry.Controls.Add(btnSearch);
			grpFindEntry.Controls.Add(lstEntryObjects);
			grpFindEntry.Controls.Add(pnlLabels_AndOr);
			grpFindEntry.Controls.Add(lblSeparator);
			grpFindEntry.Controls.Add(lstFoundEntries);
			grpFindEntry.Controls.Add(label17);
			grpFindEntry.Controls.Add(rtbSelectedEntry_Found);
			grpFindEntry.Controls.Add(lblSelectionType);
			grpFindEntry.Controls.Add(label3);
			grpFindEntry.Location = new System.Drawing.Point(16, 31);
			grpFindEntry.Name = "grpFindEntry";
			grpFindEntry.Size = new System.Drawing.Size(787, 638);
			grpFindEntry.TabIndex = 7;
			grpFindEntry.TabStop = false;
			// 
			// clbLabelsInNotebooks
			// 
			clbLabelsInNotebooks.CheckOnClick = true;
			clbLabelsInNotebooks.FormattingEnabled = true;
			clbLabelsInNotebooks.Location = new System.Drawing.Point(6, 34);
			clbLabelsInNotebooks.Name = "clbLabelsInNotebooks";
			clbLabelsInNotebooks.Size = new System.Drawing.Size(171, 148);
			clbLabelsInNotebooks.TabIndex = 60;
			clbLabelsInNotebooks.SelectedIndexChanged += this.SearchButtonEnableDisable;
			// 
			// panel5
			// 
			panel5.Controls.Add(radTitleText_Or);
			panel5.Controls.Add(radTitle_And);
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
			// radText_And
			// 
			radTitle_And.AutoSize = true;
			radTitle_And.Location = new System.Drawing.Point(39, 4);
			radTitle_And.Name = "radText_And";
			radTitle_And.Size = new System.Drawing.Size(45, 19);
			radTitle_And.TabIndex = 0;
			radTitle_And.Text = "and";
			radTitle_And.UseVisualStyleBackColor = true;
			// 
			// panel4
			// 
			panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel4.BorderStyle = BorderStyle.FixedSingle;
			panel4.Controls.Add(chkMatchCase_Text);
			panel4.Controls.Add(txtSearchText);
			panel4.Controls.Add(label8);
			panel4.Controls.Add(label9);
			panel4.Controls.Add(txtSearchTitle);
			panel4.Controls.Add(chkMatchCase_Title);
			panel4.Location = new System.Drawing.Point(191, 35);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(584, 94);
			panel4.TabIndex = 57;
			// 
			// chkMatchCase_Text
			// 
			chkMatchCase_Text.AutoSize = true;
			chkMatchCase_Text.Location = new System.Drawing.Point(315, 45);
			chkMatchCase_Text.Name = "chkMatchCase_Text";
			chkMatchCase_Text.Size = new System.Drawing.Size(112, 19);
			chkMatchCase_Text.TabIndex = 39;
			chkMatchCase_Text.Text = "match case, text";
			// 
			// txtSearchText
			// 
			txtSearchText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtSearchText.BorderStyle = BorderStyle.FixedSingle;
			txtSearchText.Location = new System.Drawing.Point(49, 66);
			txtSearchText.Name = "txtSearchText";
			txtSearchText.Size = new System.Drawing.Size(516, 23);
			txtSearchText.TabIndex = 22;
			txtSearchText.TextChanged += this.SearchButtonEnableDisable;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
			label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label8.Location = new System.Drawing.Point(6, 21);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(40, 17);
			label8.TabIndex = 2;
			label8.Text = "Title:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
			label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label9.Location = new System.Drawing.Point(8, 68);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(38, 17);
			label9.TabIndex = 3;
			label9.Text = "Text:";
			// 
			// txtSearchTitle
			// 
			txtSearchTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtSearchTitle.BorderStyle = BorderStyle.FixedSingle;
			txtSearchTitle.Location = new System.Drawing.Point(49, 18);
			txtSearchTitle.Name = "txtSearchTitle";
			txtSearchTitle.Size = new System.Drawing.Size(516, 23);
			txtSearchTitle.TabIndex = 21;
			txtSearchTitle.TextChanged += this.SearchButtonEnableDisable;
			// 
			// radTitleOr
			// 
			radTitleOr.AutoSize = true;
			radTitleOr.Checked = true;
			radTitleOr.Location = new System.Drawing.Point(3, 3);
			radTitleOr.Name = "radTitleOr";
			radTitleOr.Size = new System.Drawing.Size(36, 19);
			radTitleOr.TabIndex = 35;
			radTitleOr.TabStop = true;
			radTitleOr.Text = "or";
			radTitleOr.UseVisualStyleBackColor = true;
			// 
			// radText_And
			// 
			radText_And.AutoSize = true;
			radText_And.Location = new System.Drawing.Point(41, 3);
			radText_And.Name = "radText_And";
			radText_And.Size = new System.Drawing.Size(45, 19);
			radText_And.TabIndex = 36;
			radText_And.Text = "and";
			radText_And.UseVisualStyleBackColor = true;
			// 
			// chkMatchCase_Title
			// 
			chkMatchCase_Title.AutoSize = true;
			chkMatchCase_Title.Location = new System.Drawing.Point(180, 45);
			chkMatchCase_Title.Name = "chkMatchCase_Title";
			chkMatchCase_Title.Size = new System.Drawing.Size(112, 19);
			chkMatchCase_Title.TabIndex = 38;
			chkMatchCase_Title.Text = "match case, title";
			// 
			// panel3
			// 
			panel3.Controls.Add(panel1);
			panel3.Controls.Add(radDate_Or);
			panel3.Controls.Add(radDate_And);
			panel3.Location = new System.Drawing.Point(191, 128);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(90, 25);
			panel3.TabIndex = 58;
			// 
			// panel1
			// 
			panel1.Controls.Add(radioButton1);
			panel1.Controls.Add(radioButton2);
			panel1.Location = new System.Drawing.Point(107, 1);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(90, 25);
			panel1.TabIndex = 59;
			// 
			// radioButton1
			// 
			radioButton1.AutoSize = true;
			radioButton1.Checked = true;
			radioButton1.Location = new System.Drawing.Point(2, 4);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(36, 19);
			radioButton1.TabIndex = 1;
			radioButton1.TabStop = true;
			radioButton1.Text = "or";
			radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			radioButton2.AutoSize = true;
			radioButton2.Location = new System.Drawing.Point(39, 4);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(45, 19);
			radioButton2.TabIndex = 0;
			radioButton2.Text = "and";
			radioButton2.UseVisualStyleBackColor = true;
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
			pnlLabels_AndOr.Location = new System.Drawing.Point(60, 6);
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
			radLabels_And.Size = new System.Drawing.Size(49, 19);
			radLabels_And.TabIndex = 0;
			radLabels_And.Text = "and)";
			radLabels_And.UseVisualStyleBackColor = true;
			// 
			// lblSeparator
			// 
			lblSeparator.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			lblSeparator.Cursor = Cursors.HSplit;
			lblSeparator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			lblSeparator.ForeColor = System.Drawing.Color.Red;
			lblSeparator.Location = new System.Drawing.Point(111, 382);
			lblSeparator.Name = "lblSeparator";
			lblSeparator.Size = new System.Drawing.Size(670, 19);
			lblSeparator.TabIndex = 37;
			lblSeparator.Text = resources.GetString("lblSeparator.Text");
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
			// label17
			// 
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
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
			lblSelectionType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
			lblSelectionType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblSelectionType.Location = new System.Drawing.Point(3, 388);
			lblSelectionType.Name = "lblSelectionType";
			lblSelectionType.Size = new System.Drawing.Size(96, 17);
			lblSelectionType.TabIndex = 15;
			lblSelectionType.Text = "Selected Entry";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(53, 11);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(11, 15);
			label3.TabIndex = 61;
			label3.Text = "(";
			// 
			// ccbNotebooks
			// 
			ccbNotebooks.CheckOnClick = true;
			ccbNotebooks.DisplayMember = "Name";
			ccbNotebooks.DrawMode = DrawMode.OwnerDrawVariable;
			ccbNotebooks.DropDownHeight = 1;
			ccbNotebooks.IntegralHeight = false;
			ccbNotebooks.Location = new System.Drawing.Point(477, 6);
			ccbNotebooks.Name = "ccbNotebooks";
			ccbNotebooks.Size = new System.Drawing.Size(227, 24);
			ccbNotebooks.TabIndex = 55;
			ccbNotebooks.ValueMember = "Id";
			ccbNotebooks.ValueSeparator = ", ";
			ccbNotebooks.Visible = false;
			ccbNotebooks.ItemCheck += this.ccb_ItemCheck;
			ccbNotebooks.TextChanged += this.ccbNotebooks_TextChanged;
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
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = System.Drawing.SystemColors.ControlText;
			label1.Location = new System.Drawing.Point(22, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(139, 15);
			label1.TabIndex = 56;
			label1.Text = "Searching In Notebooks: ";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ddlNbsToSearch
			// 
			ddlNbsToSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ddlNbsToSearch.FormattingEnabled = true;
			ddlNbsToSearch.Location = new System.Drawing.Point(160, 5);
			ddlNbsToSearch.Name = "ddlNbsToSearch";
			ddlNbsToSearch.Size = new System.Drawing.Size(189, 23);
			ddlNbsToSearch.TabIndex = 60;
			ddlNbsToSearch.SelectedIndexChanged += this.ddlNbsToSearch_SelectedIndexChanged;
			// 
			// panel6
			// 
			panel6.Controls.Add(radText_And);
			panel6.Controls.Add(radTitleOr);
			panel6.Location = new System.Drawing.Point(188, 77);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(90, 25);
			panel6.TabIndex = 40;
			// 
			// frmSearch
			// 
			AcceptButton = btnSearch;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(815, 672);
			Controls.Add(ddlNbsToSearch);
			Controls.Add(label1);
			Controls.Add(grpFindEntry);
			Controls.Add(ccbNotebooks);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MinimumSize = new System.Drawing.Size(831, 550);
			Name = "frmSearch";
			Text = "Search";
			Load += this.frmSearch_Load;
			ResizeEnd += this.frmSearch_ResizeEnd;
			grpFindEntry.ResumeLayout(false);
			grpFindEntry.PerformLayout();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			pnlLabels_AndOr.ResumeLayout(false);
			pnlLabels_AndOr.PerformLayout();
			mnuEntryEditTop.ResumeLayout(false);
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private GroupBox grpFindEntry;
		private ListBox lstFoundEntries;
		private CheckBox chkUseDateRange;
		private CheckBox chkUseDate;
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
		private RadioButton radText_And;
		private RadioButton radTitleOr;
		private Label lblSeparator;
		private CheckBox chkMatchCase_Title;
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
		private CheckedComboBox ccbNotebooks;
		BackgroundWorker bgWorker;
		private Panel panel3;
		private RadioButton radDate_Or;
		private RadioButton radDate_And;
		private Panel panel2;
		private Panel panel5;
		private RadioButton radTitleText_Or;
		private RadioButton radTitle_And;
		private Panel panel4;
		private Panel panel1;
		private RadioButton radioButton1;
		private RadioButton radioButton2;
		private Label label1;
		private ComboBox ddlNbsToSearch;
		private CheckedListBox clbLabelsInNotebooks;
		private Label label3;
		private CheckBox chkMatchCase_Text;
		private Panel panel6;
	}
}