
namespace myJournal.subforms
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
			this.grpCreateEntry = new System.Windows.Forms.GroupBox();
			this.pnlEntryDates = new System.Windows.Forms.Panel();
			this.lblEditedOn = new System.Windows.Forms.Label();
			this.lblCreatedOn = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblSortType = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblSelectedFont = new System.Windows.Forms.Label();
			this.btnColor = new System.Windows.Forms.Button();
			this.btnStrikeout = new System.Windows.Forms.Button();
			this.btnUnderline = new System.Windows.Forms.Button();
			this.btnItalic = new System.Windows.Forms.Button();
			this.btnBold = new System.Windows.Forms.Button();
			this.ddlFonts = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.toolsRTB = new System.Windows.Forms.ToolStrip();
			this.toolsBold = new System.Windows.Forms.ToolStripButton();
			this.toolsUnderline = new System.Windows.Forms.ToolStripButton();
			this.toolsItalic = new System.Windows.Forms.ToolStripButton();
			this.toolsFonts = new System.Windows.Forms.ToolStripComboBox();
			this.toolsFontSizes = new System.Windows.Forms.ToolStripComboBox();
			this.lblManageLabels = new System.Windows.Forms.Label();
			this.txtNewEntryTitle = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblEntryText_Hidden = new System.Windows.Forms.Label();
			this.lblEntryTitle_Hidden = new System.Windows.Forms.Label();
			this.clbLabels = new System.Windows.Forms.CheckedListBox();
			this.label14 = new System.Windows.Forms.Label();
			this.lblFont_NewEntry = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.rtbNewEntry = new System.Windows.Forms.RichTextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mnuSaveEntry = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSaveAndExit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFind = new System.Windows.Forms.ToolStripMenuItem();
			this.txtFind = new System.Windows.Forms.ToolStripTextBox();
			this.mnuCancelExit = new System.Windows.Forms.ToolStripMenuItem();
			this.grpCreateEntry.SuspendLayout();
			this.pnlEntryDates.SuspendLayout();
			this.panel1.SuspendLayout();
			this.toolsRTB.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpCreateEntry
			// 
			this.grpCreateEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpCreateEntry.Controls.Add(this.pnlEntryDates);
			this.grpCreateEntry.Controls.Add(this.lblSortType);
			this.grpCreateEntry.Controls.Add(this.panel1);
			this.grpCreateEntry.Controls.Add(this.toolsRTB);
			this.grpCreateEntry.Controls.Add(this.lblManageLabels);
			this.grpCreateEntry.Controls.Add(this.txtNewEntryTitle);
			this.grpCreateEntry.Controls.Add(this.label2);
			this.grpCreateEntry.Controls.Add(this.label4);
			this.grpCreateEntry.Controls.Add(this.lblEntryText_Hidden);
			this.grpCreateEntry.Controls.Add(this.lblEntryTitle_Hidden);
			this.grpCreateEntry.Controls.Add(this.clbLabels);
			this.grpCreateEntry.Controls.Add(this.label14);
			this.grpCreateEntry.Controls.Add(this.lblFont_NewEntry);
			this.grpCreateEntry.Controls.Add(this.label3);
			this.grpCreateEntry.Controls.Add(this.rtbNewEntry);
			this.grpCreateEntry.Location = new System.Drawing.Point(10, 25);
			this.grpCreateEntry.Name = "grpCreateEntry";
			this.grpCreateEntry.Size = new System.Drawing.Size(569, 484);
			this.grpCreateEntry.TabIndex = 5;
			this.grpCreateEntry.TabStop = false;
			// 
			// pnlEntryDates
			// 
			this.pnlEntryDates.Controls.Add(this.lblEditedOn);
			this.pnlEntryDates.Controls.Add(this.lblCreatedOn);
			this.pnlEntryDates.Controls.Add(this.label6);
			this.pnlEntryDates.Controls.Add(this.label8);
			this.pnlEntryDates.Controls.Add(this.label5);
			this.pnlEntryDates.Location = new System.Drawing.Point(46, 46);
			this.pnlEntryDates.Name = "pnlEntryDates";
			this.pnlEntryDates.Size = new System.Drawing.Size(317, 23);
			this.pnlEntryDates.TabIndex = 48;
			// 
			// lblEditedOn
			// 
			this.lblEditedOn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblEditedOn.Location = new System.Drawing.Point(197, 4);
			this.lblEditedOn.Name = "lblEditedOn";
			this.lblEditedOn.Size = new System.Drawing.Size(105, 18);
			this.lblEditedOn.TabIndex = 47;
			this.lblEditedOn.Text = "88/88/88 00:00:00";
			// 
			// lblCreatedOn
			// 
			this.lblCreatedOn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblCreatedOn.Location = new System.Drawing.Point(50, 4);
			this.lblCreatedOn.Name = "lblCreatedOn";
			this.lblCreatedOn.Size = new System.Drawing.Size(100, 18);
			this.lblCreatedOn.TabIndex = 45;
			this.lblCreatedOn.Text = "88/88/88 00:00:00";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(312, 5);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(0, 15);
			this.label6.TabIndex = 45;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label8.Location = new System.Drawing.Point(159, 5);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(46, 15);
			this.label8.TabIndex = 46;
			this.label8.Text = "edited: ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label5.Location = new System.Drawing.Point(6, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 15);
			this.label5.TabIndex = 44;
			this.label5.Text = "created: ";
			// 
			// lblSortType
			// 
			this.lblSortType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblSortType.AutoSize = true;
			this.lblSortType.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblSortType.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblSortType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblSortType.Location = new System.Drawing.Point(153, 324);
			this.lblSortType.Name = "lblSortType";
			this.lblSortType.Size = new System.Drawing.Size(59, 17);
			this.lblSortType.TabIndex = 43;
			this.lblSortType.Text = "Sort A-Z";
			this.lblSortType.Click += new System.EventHandler(this.lblSortType_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblSelectedFont);
			this.panel1.Controls.Add(this.btnColor);
			this.panel1.Controls.Add(this.btnStrikeout);
			this.panel1.Controls.Add(this.btnUnderline);
			this.panel1.Controls.Add(this.btnItalic);
			this.panel1.Controls.Add(this.btnBold);
			this.panel1.Controls.Add(this.ddlFonts);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(498, 45);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(317, 23);
			this.panel1.TabIndex = 42;
			this.panel1.Visible = false;
			// 
			// lblSelectedFont
			// 
			this.lblSelectedFont.AutoSize = true;
			this.lblSelectedFont.Location = new System.Drawing.Point(312, 5);
			this.lblSelectedFont.Name = "lblSelectedFont";
			this.lblSelectedFont.Size = new System.Drawing.Size(0, 15);
			this.lblSelectedFont.TabIndex = 45;
			// 
			// btnColor
			// 
			this.btnColor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnColor.Location = new System.Drawing.Point(247, 0);
			this.btnColor.Name = "btnColor";
			this.btnColor.Size = new System.Drawing.Size(59, 23);
			this.btnColor.TabIndex = 44;
			this.btnColor.Text = "Color";
			this.btnColor.UseVisualStyleBackColor = true;
			// 
			// btnStrikeout
			// 
			this.btnStrikeout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point);
			this.btnStrikeout.Location = new System.Drawing.Point(227, 0);
			this.btnStrikeout.Name = "btnStrikeout";
			this.btnStrikeout.Size = new System.Drawing.Size(22, 23);
			this.btnStrikeout.TabIndex = 43;
			this.btnStrikeout.Text = "U";
			this.btnStrikeout.UseVisualStyleBackColor = true;
			// 
			// btnUnderline
			// 
			this.btnUnderline.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.btnUnderline.Location = new System.Drawing.Point(207, 0);
			this.btnUnderline.Name = "btnUnderline";
			this.btnUnderline.Size = new System.Drawing.Size(22, 23);
			this.btnUnderline.TabIndex = 4;
			this.btnUnderline.Text = "U";
			this.btnUnderline.UseVisualStyleBackColor = true;
			// 
			// btnItalic
			// 
			this.btnItalic.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
			this.btnItalic.Location = new System.Drawing.Point(187, 0);
			this.btnItalic.Name = "btnItalic";
			this.btnItalic.Size = new System.Drawing.Size(22, 23);
			this.btnItalic.TabIndex = 3;
			this.btnItalic.Text = "I";
			this.btnItalic.UseVisualStyleBackColor = true;
			// 
			// btnBold
			// 
			this.btnBold.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnBold.Location = new System.Drawing.Point(169, 0);
			this.btnBold.Name = "btnBold";
			this.btnBold.Size = new System.Drawing.Size(22, 23);
			this.btnBold.TabIndex = 2;
			this.btnBold.Text = "B";
			this.btnBold.UseVisualStyleBackColor = true;
			// 
			// ddlFonts
			// 
			this.ddlFonts.FormattingEnabled = true;
			this.ddlFonts.Location = new System.Drawing.Point(41, 0);
			this.ddlFonts.Name = "ddlFonts";
			this.ddlFonts.Size = new System.Drawing.Size(121, 23);
			this.ddlFonts.TabIndex = 1;
			this.ddlFonts.SelectedIndexChanged += new System.EventHandler(this.ddlFonts_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "font:";
			// 
			// toolsRTB
			// 
			this.toolsRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.toolsRTB.Dock = System.Windows.Forms.DockStyle.None;
			this.toolsRTB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsBold,
            this.toolsUnderline,
            this.toolsItalic,
            this.toolsFonts,
            this.toolsFontSizes});
			this.toolsRTB.Location = new System.Drawing.Point(310, 44);
			this.toolsRTB.Name = "toolsRTB";
			this.toolsRTB.Size = new System.Drawing.Size(241, 25);
			this.toolsRTB.TabIndex = 41;
			this.toolsRTB.Text = "toolStrip1";
			this.toolsRTB.Visible = false;
			// 
			// toolsBold
			// 
			this.toolsBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolsBold.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.toolsBold.Image = ((System.Drawing.Image)(resources.GetObject("toolsBold.Image")));
			this.toolsBold.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolsBold.Name = "toolsBold";
			this.toolsBold.Size = new System.Drawing.Size(23, 22);
			this.toolsBold.Text = "B";
			this.toolsBold.Click += new System.EventHandler(this.ToolsMenuClick);
			// 
			// toolsUnderline
			// 
			this.toolsUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolsUnderline.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			this.toolsUnderline.Image = ((System.Drawing.Image)(resources.GetObject("toolsUnderline.Image")));
			this.toolsUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolsUnderline.Name = "toolsUnderline";
			this.toolsUnderline.Size = new System.Drawing.Size(23, 22);
			this.toolsUnderline.Text = "U";
			this.toolsUnderline.Click += new System.EventHandler(this.ToolsMenuClick);
			// 
			// toolsItalic
			// 
			this.toolsItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolsItalic.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
			this.toolsItalic.Image = ((System.Drawing.Image)(resources.GetObject("toolsItalic.Image")));
			this.toolsItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolsItalic.Name = "toolsItalic";
			this.toolsItalic.Size = new System.Drawing.Size(23, 22);
			this.toolsItalic.Text = "I";
			this.toolsItalic.Click += new System.EventHandler(this.ToolsMenuClick);
			// 
			// toolsFonts
			// 
			this.toolsFonts.AutoSize = false;
			this.toolsFonts.Name = "toolsFonts";
			this.toolsFonts.Size = new System.Drawing.Size(121, 23);
			this.toolsFonts.Text = "Times New Roman";
			// 
			// toolsFontSizes
			// 
			this.toolsFontSizes.AutoSize = false;
			this.toolsFontSizes.Name = "toolsFontSizes";
			this.toolsFontSizes.Size = new System.Drawing.Size(35, 23);
			this.toolsFontSizes.Text = "10";
			// 
			// lblManageLabels
			// 
			this.lblManageLabels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblManageLabels.AutoSize = true;
			this.lblManageLabels.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblManageLabels.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblManageLabels.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblManageLabels.Location = new System.Drawing.Point(218, 324);
			this.lblManageLabels.Name = "lblManageLabels";
			this.lblManageLabels.Size = new System.Drawing.Size(97, 17);
			this.lblManageLabels.TabIndex = 40;
			this.lblManageLabels.Text = "manage labels";
			this.lblManageLabels.Click += new System.EventHandler(this.lblManageLabels_Click);
			// 
			// txtNewEntryTitle
			// 
			this.txtNewEntryTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNewEntryTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNewEntryTitle.Location = new System.Drawing.Point(46, 19);
			this.txtNewEntryTitle.Multiline = true;
			this.txtNewEntryTitle.Name = "txtNewEntryTitle";
			this.txtNewEntryTitle.Size = new System.Drawing.Size(510, 23);
			this.txtNewEntryTitle.TabIndex = 1;
			this.txtNewEntryTitle.TextChanged += new System.EventHandler(this.txtNewEntryTitle_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label2.Location = new System.Drawing.Point(6, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Title:";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label4.Location = new System.Drawing.Point(13, 324);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 38;
			this.label4.Text = "labels";
			// 
			// lblEntryText_Hidden
			// 
			this.lblEntryText_Hidden.AutoSize = true;
			this.lblEntryText_Hidden.Location = new System.Drawing.Point(77, 503);
			this.lblEntryText_Hidden.Name = "lblEntryText_Hidden";
			this.lblEntryText_Hidden.Size = new System.Drawing.Size(67, 15);
			this.lblEntryText_Hidden.TabIndex = 35;
			this.lblEntryText_Hidden.Text = "hidden text";
			this.lblEntryText_Hidden.Visible = false;
			// 
			// lblEntryTitle_Hidden
			// 
			this.lblEntryTitle_Hidden.AutoSize = true;
			this.lblEntryTitle_Hidden.Location = new System.Drawing.Point(4, 503);
			this.lblEntryTitle_Hidden.Name = "lblEntryTitle_Hidden";
			this.lblEntryTitle_Hidden.Size = new System.Drawing.Size(67, 15);
			this.lblEntryTitle_Hidden.TabIndex = 34;
			this.lblEntryTitle_Hidden.Text = "hidden title";
			this.lblEntryTitle_Hidden.Visible = false;
			// 
			// clbLabels
			// 
			this.clbLabels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.clbLabels.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.clbLabels.CheckOnClick = true;
			this.clbLabels.FormattingEnabled = true;
			this.clbLabels.Location = new System.Drawing.Point(6, 346);
			this.clbLabels.Name = "clbLabels";
			this.clbLabels.Size = new System.Drawing.Size(550, 126);
			this.clbLabels.TabIndex = 27;
			this.clbLabels.SelectedIndexChanged += new System.EventHandler(this.lstLabels_SelectedIndexChanged);
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label14.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label14.Location = new System.Drawing.Point(6, 781);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(34, 17);
			this.label14.TabIndex = 25;
			this.label14.Text = "tags";
			// 
			// lblFont_NewEntry
			// 
			this.lblFont_NewEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFont_NewEntry.AutoSize = true;
			this.lblFont_NewEntry.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblFont_NewEntry.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblFont_NewEntry.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblFont_NewEntry.Location = new System.Drawing.Point(618, 70);
			this.lblFont_NewEntry.Name = "lblFont_NewEntry";
			this.lblFont_NewEntry.Size = new System.Drawing.Size(31, 15);
			this.lblFont_NewEntry.TabIndex = 5;
			this.lblFont_NewEntry.Text = "font";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label3.Location = new System.Drawing.Point(6, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 17);
			this.label3.TabIndex = 3;
			this.label3.Text = "Entry";
			// 
			// rtbNewEntry
			// 
			this.rtbNewEntry.AcceptsTab = true;
			this.rtbNewEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbNewEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbNewEntry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.rtbNewEntry.Location = new System.Drawing.Point(6, 69);
			this.rtbNewEntry.Name = "rtbNewEntry";
			this.rtbNewEntry.Size = new System.Drawing.Size(550, 247);
			this.rtbNewEntry.TabIndex = 2;
			this.rtbNewEntry.Text = "";
			this.rtbNewEntry.TextChanged += new System.EventHandler(this.rtbNewEntry_TextChanged);
			this.rtbNewEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbNewEntry_KeyDown);
			this.rtbNewEntry.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rtbNewEntry_MouseUp);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSaveEntry,
            this.mnuSaveAndExit,
            this.mnuFind,
            this.mnuCancelExit});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(590, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "Save Entry";
			// 
			// mnuSaveEntry
			// 
			this.mnuSaveEntry.Enabled = false;
			this.mnuSaveEntry.Name = "mnuSaveEntry";
			this.mnuSaveEntry.Size = new System.Drawing.Size(43, 20);
			this.mnuSaveEntry.Text = "&Save";
			this.mnuSaveEntry.Click += new System.EventHandler(this.mnuSaveEntry_Click);
			// 
			// mnuSaveAndExit
			// 
			this.mnuSaveAndExit.Enabled = false;
			this.mnuSaveAndExit.Name = "mnuSaveAndExit";
			this.mnuSaveAndExit.Size = new System.Drawing.Size(88, 20);
			this.mnuSaveAndExit.Text = "Save and &Exit";
			this.mnuSaveAndExit.Click += new System.EventHandler(this.mnuSaveAndExit_Click);
			// 
			// mnuFind
			// 
			this.mnuFind.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtFind});
			this.mnuFind.Name = "mnuFind";
			this.mnuFind.Size = new System.Drawing.Size(42, 20);
			this.mnuFind.Text = "&Find";
			this.mnuFind.Click += new System.EventHandler(this.mnuFind_Click);
			// 
			// txtFind
			// 
			this.txtFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFind.Name = "txtFind";
			this.txtFind.Size = new System.Drawing.Size(100, 23);
			this.txtFind.TextChanged += new System.EventHandler(this.mnuFindTextBox_TextChanged);
			// 
			// mnuCancelExit
			// 
			this.mnuCancelExit.Name = "mnuCancelExit";
			this.mnuCancelExit.Size = new System.Drawing.Size(38, 20);
			this.mnuCancelExit.Text = "E&xit";
			this.mnuCancelExit.Click += new System.EventHandler(this.mnuCancelExit_Click);
			// 
			// frmNewEntry
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(590, 517);
			this.Controls.Add(this.grpCreateEntry);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(372, 439);
			this.Name = "frmNewEntry";
			this.Text = "New Entry";
			this.Load += new System.EventHandler(this.frmNewEntry_Load);
			this.grpCreateEntry.ResumeLayout(false);
			this.grpCreateEntry.PerformLayout();
			this.pnlEntryDates.ResumeLayout(false);
			this.pnlEntryDates.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.toolsRTB.ResumeLayout(false);
			this.toolsRTB.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
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
	}
}