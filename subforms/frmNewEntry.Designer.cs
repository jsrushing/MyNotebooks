
namespace MyNotebooks.subforms
{
	partial class frmNewEntry
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewEntry));
			grpCreateEntry = new System.Windows.Forms.GroupBox();
			lblTitleExists = new System.Windows.Forms.Label();
			pnlEntryDates = new System.Windows.Forms.Panel();
			lblEditedOn = new System.Windows.Forms.Label();
			lblCreatedOn = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			lblSortType = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			lblSelectedFont = new System.Windows.Forms.Label();
			btnColor = new System.Windows.Forms.Button();
			btnStrikeout = new System.Windows.Forms.Button();
			btnUnderline = new System.Windows.Forms.Button();
			btnItalic = new System.Windows.Forms.Button();
			btnBold = new System.Windows.Forms.Button();
			ddlFonts = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			toolsRTB = new System.Windows.Forms.ToolStrip();
			toolsBold = new System.Windows.Forms.ToolStripButton();
			toolsUnderline = new System.Windows.Forms.ToolStripButton();
			toolsItalic = new System.Windows.Forms.ToolStripButton();
			toolsFonts = new System.Windows.Forms.ToolStripComboBox();
			toolsFontSizes = new System.Windows.Forms.ToolStripComboBox();
			lblManageLabels = new System.Windows.Forms.Label();
			txtNewEntryTitle = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			lblEntryText_Hidden = new System.Windows.Forms.Label();
			lblEntryTitle_Hidden = new System.Windows.Forms.Label();
			clbLabels = new System.Windows.Forms.CheckedListBox();
			label14 = new System.Windows.Forms.Label();
			lblFont_NewEntry = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			rtbNewEntry = new System.Windows.Forms.RichTextBox();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			mnuSaveEntry = new System.Windows.Forms.ToolStripMenuItem();
			mnuSaveAndExit = new System.Windows.Forms.ToolStripMenuItem();
			mnuFind = new System.Windows.Forms.ToolStripMenuItem();
			txtFind = new System.Windows.Forms.ToolStripTextBox();
			mnuCancelExit = new System.Windows.Forms.ToolStripMenuItem();
			bgWorker = new System.ComponentModel.BackgroundWorker();
			lblAddNewLabel = new System.Windows.Forms.Label();
			grpCreateEntry.SuspendLayout();
			pnlEntryDates.SuspendLayout();
			panel1.SuspendLayout();
			toolsRTB.SuspendLayout();
			menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpCreateEntry
			// 
			grpCreateEntry.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			grpCreateEntry.Controls.Add(lblAddNewLabel);
			grpCreateEntry.Controls.Add(lblTitleExists);
			grpCreateEntry.Controls.Add(pnlEntryDates);
			grpCreateEntry.Controls.Add(lblSortType);
			grpCreateEntry.Controls.Add(panel1);
			grpCreateEntry.Controls.Add(toolsRTB);
			grpCreateEntry.Controls.Add(lblManageLabels);
			grpCreateEntry.Controls.Add(txtNewEntryTitle);
			grpCreateEntry.Controls.Add(label2);
			grpCreateEntry.Controls.Add(label4);
			grpCreateEntry.Controls.Add(lblEntryText_Hidden);
			grpCreateEntry.Controls.Add(lblEntryTitle_Hidden);
			grpCreateEntry.Controls.Add(clbLabels);
			grpCreateEntry.Controls.Add(label14);
			grpCreateEntry.Controls.Add(lblFont_NewEntry);
			grpCreateEntry.Controls.Add(label3);
			grpCreateEntry.Controls.Add(rtbNewEntry);
			grpCreateEntry.Location = new System.Drawing.Point(10, 25);
			grpCreateEntry.Name = "grpCreateEntry";
			grpCreateEntry.Size = new System.Drawing.Size(569, 484);
			grpCreateEntry.TabIndex = 5;
			grpCreateEntry.TabStop = false;
			// 
			// lblTitleExists
			// 
			lblTitleExists.AutoSize = true;
			lblTitleExists.ForeColor = System.Drawing.Color.Red;
			lblTitleExists.Location = new System.Drawing.Point(45, 3);
			lblTitleExists.Name = "lblTitleExists";
			lblTitleExists.Size = new System.Drawing.Size(188, 15);
			lblTitleExists.TabIndex = 50;
			lblTitleExists.Text = "Sorry, this entry title already exists.";
			lblTitleExists.Visible = false;
			// 
			// pnlEntryDates
			// 
			pnlEntryDates.Controls.Add(lblEditedOn);
			pnlEntryDates.Controls.Add(lblCreatedOn);
			pnlEntryDates.Controls.Add(label6);
			pnlEntryDates.Controls.Add(label8);
			pnlEntryDates.Controls.Add(label5);
			pnlEntryDates.Location = new System.Drawing.Point(55, 46);
			pnlEntryDates.Name = "pnlEntryDates";
			pnlEntryDates.Size = new System.Drawing.Size(398, 23);
			pnlEntryDates.TabIndex = 48;
			// 
			// lblEditedOn
			// 
			lblEditedOn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			lblEditedOn.Location = new System.Drawing.Point(232, 5);
			lblEditedOn.Name = "lblEditedOn";
			lblEditedOn.Size = new System.Drawing.Size(105, 18);
			lblEditedOn.TabIndex = 47;
			lblEditedOn.Text = "88/88/88 00:00:00";
			// 
			// lblCreatedOn
			// 
			lblCreatedOn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			lblCreatedOn.Location = new System.Drawing.Point(67, 5);
			lblCreatedOn.Name = "lblCreatedOn";
			lblCreatedOn.Size = new System.Drawing.Size(100, 18);
			lblCreatedOn.TabIndex = 45;
			lblCreatedOn.Text = "88/88/88 00:00:00";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(312, 5);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(0, 15);
			label6.TabIndex = 45;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			label8.Location = new System.Drawing.Point(177, 4);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(60, 15);
			label8.TabIndex = 46;
			label8.Text = "edited on:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			label5.Location = new System.Drawing.Point(6, 4);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(69, 15);
			label5.TabIndex = 44;
			label5.Text = "created on: ";
			// 
			// lblSortType
			// 
			lblSortType.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			lblSortType.AutoSize = true;
			lblSortType.Cursor = System.Windows.Forms.Cursors.Hand;
			lblSortType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
			lblSortType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblSortType.Location = new System.Drawing.Point(75, 324);
			lblSortType.Name = "lblSortType";
			lblSortType.Size = new System.Drawing.Size(54, 17);
			lblSortType.TabIndex = 43;
			lblSortType.Text = "sort a-z";
			lblSortType.Click += this.lblSortType_Click;
			// 
			// panel1
			// 
			panel1.Controls.Add(lblSelectedFont);
			panel1.Controls.Add(btnColor);
			panel1.Controls.Add(btnStrikeout);
			panel1.Controls.Add(btnUnderline);
			panel1.Controls.Add(btnItalic);
			panel1.Controls.Add(btnBold);
			panel1.Controls.Add(ddlFonts);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(498, 45);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(317, 23);
			panel1.TabIndex = 42;
			panel1.Visible = false;
			// 
			// lblSelectedFont
			// 
			lblSelectedFont.AutoSize = true;
			lblSelectedFont.Location = new System.Drawing.Point(312, 5);
			lblSelectedFont.Name = "lblSelectedFont";
			lblSelectedFont.Size = new System.Drawing.Size(0, 15);
			lblSelectedFont.TabIndex = 45;
			// 
			// btnColor
			// 
			btnColor.Font = new System.Drawing.Font("Segoe UI", 9F);
			btnColor.Location = new System.Drawing.Point(247, 0);
			btnColor.Name = "btnColor";
			btnColor.Size = new System.Drawing.Size(59, 23);
			btnColor.TabIndex = 44;
			btnColor.Text = "Color";
			btnColor.UseVisualStyleBackColor = true;
			// 
			// btnStrikeout
			// 
			btnStrikeout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Strikeout);
			btnStrikeout.Location = new System.Drawing.Point(227, 0);
			btnStrikeout.Name = "btnStrikeout";
			btnStrikeout.Size = new System.Drawing.Size(22, 23);
			btnStrikeout.TabIndex = 43;
			btnStrikeout.Text = "U";
			btnStrikeout.UseVisualStyleBackColor = true;
			// 
			// btnUnderline
			// 
			btnUnderline.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
			btnUnderline.Location = new System.Drawing.Point(207, 0);
			btnUnderline.Name = "btnUnderline";
			btnUnderline.Size = new System.Drawing.Size(22, 23);
			btnUnderline.TabIndex = 4;
			btnUnderline.Text = "U";
			btnUnderline.UseVisualStyleBackColor = true;
			// 
			// btnItalic
			// 
			btnItalic.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
			btnItalic.Location = new System.Drawing.Point(187, 0);
			btnItalic.Name = "btnItalic";
			btnItalic.Size = new System.Drawing.Size(22, 23);
			btnItalic.TabIndex = 3;
			btnItalic.Text = "I";
			btnItalic.UseVisualStyleBackColor = true;
			// 
			// btnBold
			// 
			btnBold.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			btnBold.Location = new System.Drawing.Point(169, 0);
			btnBold.Name = "btnBold";
			btnBold.Size = new System.Drawing.Size(22, 23);
			btnBold.TabIndex = 2;
			btnBold.Text = "B";
			btnBold.UseVisualStyleBackColor = true;
			// 
			// ddlFonts
			// 
			ddlFonts.FormattingEnabled = true;
			ddlFonts.Location = new System.Drawing.Point(41, 0);
			ddlFonts.Name = "ddlFonts";
			ddlFonts.Size = new System.Drawing.Size(121, 23);
			ddlFonts.TabIndex = 1;
			ddlFonts.SelectedIndexChanged += this.ddlFonts_SelectedIndexChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(7, 4);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(32, 15);
			label1.TabIndex = 0;
			label1.Text = "font:";
			// 
			// toolsRTB
			// 
			toolsRTB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			toolsRTB.Dock = System.Windows.Forms.DockStyle.None;
			toolsRTB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolsBold, toolsUnderline, toolsItalic, toolsFonts, toolsFontSizes });
			toolsRTB.Location = new System.Drawing.Point(310, 44);
			toolsRTB.Name = "toolsRTB";
			toolsRTB.Size = new System.Drawing.Size(241, 25);
			toolsRTB.TabIndex = 41;
			toolsRTB.Text = "toolStrip1";
			toolsRTB.Visible = false;
			// 
			// toolsBold
			// 
			toolsBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolsBold.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
			toolsBold.Image = (System.Drawing.Image)resources.GetObject("toolsBold.Image");
			toolsBold.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolsBold.Name = "toolsBold";
			toolsBold.Size = new System.Drawing.Size(23, 22);
			toolsBold.Text = "B";
			toolsBold.Click += this.ToolsMenuClick;
			// 
			// toolsUnderline
			// 
			toolsUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolsUnderline.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Underline);
			toolsUnderline.Image = (System.Drawing.Image)resources.GetObject("toolsUnderline.Image");
			toolsUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolsUnderline.Name = "toolsUnderline";
			toolsUnderline.Size = new System.Drawing.Size(23, 22);
			toolsUnderline.Text = "U";
			toolsUnderline.Click += this.ToolsMenuClick;
			// 
			// toolsItalic
			// 
			toolsItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolsItalic.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic);
			toolsItalic.Image = (System.Drawing.Image)resources.GetObject("toolsItalic.Image");
			toolsItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolsItalic.Name = "toolsItalic";
			toolsItalic.Size = new System.Drawing.Size(23, 22);
			toolsItalic.Text = "I";
			toolsItalic.Click += this.ToolsMenuClick;
			// 
			// toolsFonts
			// 
			toolsFonts.AutoSize = false;
			toolsFonts.Name = "toolsFonts";
			toolsFonts.Size = new System.Drawing.Size(121, 23);
			toolsFonts.Text = "Times New Roman";
			// 
			// toolsFontSizes
			// 
			toolsFontSizes.AutoSize = false;
			toolsFontSizes.Name = "toolsFontSizes";
			toolsFontSizes.Size = new System.Drawing.Size(35, 23);
			toolsFontSizes.Text = "10";
			// 
			// lblManageLabels
			// 
			lblManageLabels.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			lblManageLabels.AutoSize = true;
			lblManageLabels.Cursor = System.Windows.Forms.Cursors.Hand;
			lblManageLabels.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
			lblManageLabels.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblManageLabels.Location = new System.Drawing.Point(154, 324);
			lblManageLabels.Name = "lblManageLabels";
			lblManageLabels.Size = new System.Drawing.Size(86, 17);
			lblManageLabels.TabIndex = 40;
			lblManageLabels.Text = "Add Existing";
			lblManageLabels.Click += this.lblManageLabels_Click;
			// 
			// txtNewEntryTitle
			// 
			txtNewEntryTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtNewEntryTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtNewEntryTitle.Location = new System.Drawing.Point(46, 19);
			txtNewEntryTitle.MaxLength = 255;
			txtNewEntryTitle.Multiline = true;
			txtNewEntryTitle.Name = "txtNewEntryTitle";
			txtNewEntryTitle.Size = new System.Drawing.Size(510, 23);
			txtNewEntryTitle.TabIndex = 1;
			txtNewEntryTitle.TextChanged += this.txtNewEntryTitle_TextChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
			label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label2.Location = new System.Drawing.Point(6, 19);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(40, 17);
			label2.TabIndex = 0;
			label2.Text = "Title:";
			// 
			// label4
			// 
			label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
			label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label4.Location = new System.Drawing.Point(6, 324);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 38;
			label4.Text = "labels";
			// 
			// lblEntryText_Hidden
			// 
			lblEntryText_Hidden.AutoSize = true;
			lblEntryText_Hidden.Location = new System.Drawing.Point(77, 503);
			lblEntryText_Hidden.Name = "lblEntryText_Hidden";
			lblEntryText_Hidden.Size = new System.Drawing.Size(67, 15);
			lblEntryText_Hidden.TabIndex = 35;
			lblEntryText_Hidden.Text = "hidden text";
			lblEntryText_Hidden.Visible = false;
			// 
			// lblEntryTitle_Hidden
			// 
			lblEntryTitle_Hidden.AutoSize = true;
			lblEntryTitle_Hidden.Location = new System.Drawing.Point(4, 503);
			lblEntryTitle_Hidden.Name = "lblEntryTitle_Hidden";
			lblEntryTitle_Hidden.Size = new System.Drawing.Size(67, 15);
			lblEntryTitle_Hidden.TabIndex = 34;
			lblEntryTitle_Hidden.Text = "hidden title";
			lblEntryTitle_Hidden.Visible = false;
			// 
			// clbLabels
			// 
			clbLabels.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			clbLabels.BorderStyle = System.Windows.Forms.BorderStyle.None;
			clbLabels.CheckOnClick = true;
			clbLabels.FormattingEnabled = true;
			clbLabels.Location = new System.Drawing.Point(6, 346);
			clbLabels.Name = "clbLabels";
			clbLabels.Size = new System.Drawing.Size(550, 126);
			clbLabels.TabIndex = 27;
			clbLabels.SelectedIndexChanged += this.clbLabels_SelectedIndexChanged;
			// 
			// label14
			// 
			label14.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
			label14.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label14.Location = new System.Drawing.Point(6, 781);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(34, 17);
			label14.TabIndex = 25;
			label14.Text = "tags";
			// 
			// lblFont_NewEntry
			// 
			lblFont_NewEntry.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			lblFont_NewEntry.AutoSize = true;
			lblFont_NewEntry.Cursor = System.Windows.Forms.Cursors.Hand;
			lblFont_NewEntry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
			lblFont_NewEntry.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblFont_NewEntry.Location = new System.Drawing.Point(618, 70);
			lblFont_NewEntry.Name = "lblFont_NewEntry";
			lblFont_NewEntry.Size = new System.Drawing.Size(31, 15);
			lblFont_NewEntry.TabIndex = 5;
			lblFont_NewEntry.Text = "font";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
			label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label3.Location = new System.Drawing.Point(6, 50);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(41, 17);
			label3.TabIndex = 3;
			label3.Text = "Entry";
			// 
			// rtbNewEntry
			// 
			rtbNewEntry.AcceptsTab = true;
			rtbNewEntry.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			rtbNewEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			rtbNewEntry.Font = new System.Drawing.Font("Segoe UI", 9F);
			rtbNewEntry.Location = new System.Drawing.Point(6, 69);
			rtbNewEntry.Name = "rtbNewEntry";
			rtbNewEntry.Size = new System.Drawing.Size(550, 247);
			rtbNewEntry.TabIndex = 2;
			rtbNewEntry.Text = "";
			rtbNewEntry.TextChanged += this.rtbNewEntry_TextChanged;
			rtbNewEntry.KeyDown += this.rtbNewEntry_KeyDown;
			rtbNewEntry.MouseUp += this.rtbNewEntry_MouseUp;
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuSaveEntry, mnuSaveAndExit, mnuFind, mnuCancelExit });
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new System.Drawing.Size(590, 24);
			menuStrip1.TabIndex = 6;
			menuStrip1.Text = "Create Entry";
			// 
			// mnuSaveEntry
			// 
			mnuSaveEntry.Enabled = false;
			mnuSaveEntry.Name = "mnuSaveEntry";
			mnuSaveEntry.Size = new System.Drawing.Size(43, 20);
			mnuSaveEntry.Text = "&Save";
			mnuSaveEntry.Click += this.mnuSaveEntry_Click;
			// 
			// mnuSaveAndExit
			// 
			mnuSaveAndExit.Enabled = false;
			mnuSaveAndExit.Name = "mnuSaveAndExit";
			mnuSaveAndExit.Size = new System.Drawing.Size(88, 20);
			mnuSaveAndExit.Text = "Save and &Exit";
			mnuSaveAndExit.Click += this.mnuSaveAndExit_Click;
			// 
			// mnuFind
			// 
			mnuFind.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { txtFind });
			mnuFind.Name = "mnuFind";
			mnuFind.Size = new System.Drawing.Size(42, 20);
			mnuFind.Text = "&Find";
			mnuFind.Click += this.mnuFind_Click;
			// 
			// txtFind
			// 
			txtFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtFind.Name = "txtFind";
			txtFind.Size = new System.Drawing.Size(100, 23);
			txtFind.TextChanged += this.mnuFindTextBox_TextChanged;
			// 
			// mnuCancelExit
			// 
			mnuCancelExit.Name = "mnuCancelExit";
			mnuCancelExit.Size = new System.Drawing.Size(38, 20);
			mnuCancelExit.Text = "E&xit";
			mnuCancelExit.Click += this.mnuCancelExit_Click;
			// 
			// bgWorker
			// 
			bgWorker.WorkerReportsProgress = true;
			// 
			// lblAddNewLabel
			// 
			lblAddNewLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			lblAddNewLabel.AutoSize = true;
			lblAddNewLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			lblAddNewLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
			lblAddNewLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblAddNewLabel.Location = new System.Drawing.Point(253, 324);
			lblAddNewLabel.Name = "lblAddNewLabel";
			lblAddNewLabel.Size = new System.Drawing.Size(64, 17);
			lblAddNewLabel.TabIndex = 51;
			lblAddNewLabel.Text = "Add New";
			lblAddNewLabel.Click += this.lblAddNewLabel_Click;
			// 
			// frmNewEntry
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(590, 517);
			Controls.Add(grpCreateEntry);
			Controls.Add(menuStrip1);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			MinimumSize = new System.Drawing.Size(372, 439);
			Name = "frmNewEntry";
			Text = "New Entry";
			FormClosing += this.frmNewEntry_FormClosing;
			Load += this.frmNewEntry_Load;
			grpCreateEntry.ResumeLayout(false);
			grpCreateEntry.PerformLayout();
			pnlEntryDates.ResumeLayout(false);
			pnlEntryDates.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			toolsRTB.ResumeLayout(false);
			toolsRTB.PerformLayout();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.GroupBox grpCreateEntry;
		private System.Windows.Forms.Label lblEntryText_Hidden;
		private System.Windows.Forms.Label lblEntryTitle_Hidden;
		private System.Windows.Forms.CheckedListBox clbLabels;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label lblFont_NewEntry;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RichTextBox rtbNewEntry;
		private System.Windows.Forms.TextBox txtNewEntryTitle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblManageLabels;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mnuSaveEntry;
		private System.Windows.Forms.ToolStripMenuItem mnuCancelExit;
		private System.Windows.Forms.ToolStrip toolsRTB;
		private System.Windows.Forms.ToolStripButton toolsBold;
		private System.Windows.Forms.ToolStripButton toolsUnderline;
		private System.Windows.Forms.ToolStripButton toolsItalic;
		private System.Windows.Forms.ToolStripComboBox toolsFonts;
		private System.Windows.Forms.ToolStripComboBox toolsFontSizes;
		private System.Windows.Forms.ToolStripMenuItem mnuSaveAndExit;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnColor;
		private System.Windows.Forms.Button btnStrikeout;
		private System.Windows.Forms.Button btnUnderline;
		private System.Windows.Forms.Button btnItalic;
		private System.Windows.Forms.Button btnBold;
		private System.Windows.Forms.ComboBox ddlFonts;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem mnuFind;
		private System.Windows.Forms.ToolStripTextBox txtFind;
		private System.Windows.Forms.Label lblSelectedFont;
		private System.Windows.Forms.Label lblSortType;
		private System.Windows.Forms.Label lblEditedOn;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblCreatedOn;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel pnlEntryDates;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblTitleExists;
		private System.ComponentModel.BackgroundWorker bgWorker;
		private System.Windows.Forms.Label lblAddNewLabel;
	}
}