
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
			this.lblTagManager2 = new System.Windows.Forms.Label();
			this.lblEntryText_Hidden = new System.Windows.Forms.Label();
			this.lblEntryTitle_Hidden = new System.Windows.Forms.Label();
			this.lstLabels = new System.Windows.Forms.CheckedListBox();
			this.label14 = new System.Windows.Forms.Label();
			this.lblFont_NewEntry = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.rtbNewEntry = new System.Windows.Forms.RichTextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mnuSaveEntry = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSaveAndExit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEditOriginalText = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCancelExit = new System.Windows.Forms.ToolStripMenuItem();
			this.grpCreateEntry.SuspendLayout();
			this.toolsRTB.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpCreateEntry
			// 
			this.grpCreateEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpCreateEntry.Controls.Add(this.toolsRTB);
			this.grpCreateEntry.Controls.Add(this.lblManageLabels);
			this.grpCreateEntry.Controls.Add(this.txtNewEntryTitle);
			this.grpCreateEntry.Controls.Add(this.label2);
			this.grpCreateEntry.Controls.Add(this.label4);
			this.grpCreateEntry.Controls.Add(this.lblTagManager2);
			this.grpCreateEntry.Controls.Add(this.lblEntryText_Hidden);
			this.grpCreateEntry.Controls.Add(this.lblEntryTitle_Hidden);
			this.grpCreateEntry.Controls.Add(this.lstLabels);
			this.grpCreateEntry.Controls.Add(this.label14);
			this.grpCreateEntry.Controls.Add(this.lblFont_NewEntry);
			this.grpCreateEntry.Controls.Add(this.label3);
			this.grpCreateEntry.Controls.Add(this.rtbNewEntry);
			this.grpCreateEntry.Location = new System.Drawing.Point(10, 25);
			this.grpCreateEntry.Name = "grpCreateEntry";
			this.grpCreateEntry.Size = new System.Drawing.Size(437, 459);
			this.grpCreateEntry.TabIndex = 5;
			this.grpCreateEntry.TabStop = false;
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
			this.toolsRTB.Location = new System.Drawing.Point(178, 44);
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
			this.lblManageLabels.Location = new System.Drawing.Point(218, 299);
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
			this.txtNewEntryTitle.Size = new System.Drawing.Size(378, 23);
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
			this.label4.Location = new System.Drawing.Point(13, 299);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 38;
			this.label4.Text = "labels";
			// 
			// lblTagManager2
			// 
			this.lblTagManager2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTagManager2.AutoSize = true;
			this.lblTagManager2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblTagManager2.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblTagManager2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblTagManager2.Location = new System.Drawing.Point(466, 400);
			this.lblTagManager2.Name = "lblTagManager2";
			this.lblTagManager2.Size = new System.Drawing.Size(51, 15);
			this.lblTagManager2.TabIndex = 36;
			this.lblTagManager2.Text = "Manage";
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
			// lstLabels
			// 
			this.lstLabels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstLabels.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstLabels.CheckOnClick = true;
			this.lstLabels.FormattingEnabled = true;
			this.lstLabels.Location = new System.Drawing.Point(6, 321);
			this.lstLabels.Name = "lstLabels";
			this.lstLabels.Size = new System.Drawing.Size(418, 126);
			this.lstLabels.TabIndex = 27;
			this.lstLabels.SelectedIndexChanged += new System.EventHandler(this.lstLabels_SelectedIndexChanged);
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label14.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label14.Location = new System.Drawing.Point(6, 756);
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
			this.lblFont_NewEntry.Location = new System.Drawing.Point(486, 70);
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
			this.rtbNewEntry.Size = new System.Drawing.Size(418, 222);
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
            this.mnuEditOriginalText,
            this.mnuCancelExit});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(458, 24);
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
			this.mnuSaveAndExit.Name = "mnuSaveAndExit";
			this.mnuSaveAndExit.Size = new System.Drawing.Size(88, 20);
			this.mnuSaveAndExit.Text = "Save and &Exit";
			this.mnuSaveAndExit.Click += new System.EventHandler(this.mnuSaveAndExit_Click);
			// 
			// mnuEditOriginalText
			// 
			this.mnuEditOriginalText.Name = "mnuEditOriginalText";
			this.mnuEditOriginalText.Size = new System.Drawing.Size(108, 20);
			this.mnuEditOriginalText.Text = "Edit &Original Text";
			this.mnuEditOriginalText.Visible = false;
			this.mnuEditOriginalText.Click += new System.EventHandler(this.mnuEditOriginalText_Click);
			// 
			// mnuCancelExit
			// 
			this.mnuCancelExit.Name = "mnuCancelExit";
			this.mnuCancelExit.Size = new System.Drawing.Size(79, 20);
			this.mnuCancelExit.Text = "Cancel/E&xit";
			this.mnuCancelExit.Click += new System.EventHandler(this.mnuCancelExit_Click);
			// 
			// frmNewEntry
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(458, 492);
			this.Controls.Add(this.grpCreateEntry);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(372, 439);
			this.Name = "frmNewEntry";
			this.Text = "New Entry";
			this.Load += new System.EventHandler(this.frmNewEntry_Load);
			this.grpCreateEntry.ResumeLayout(false);
			this.grpCreateEntry.PerformLayout();
			this.toolsRTB.ResumeLayout(false);
			this.toolsRTB.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox grpCreateEntry;
		private System.Windows.Forms.Label lblTagManager2;
		private System.Windows.Forms.Label lblEntryText_Hidden;
		private System.Windows.Forms.Label lblEntryTitle_Hidden;
		private System.Windows.Forms.CheckedListBox lstLabels;
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
		private System.Windows.Forms.ToolStripMenuItem mnuEditOriginalText;
		private System.Windows.Forms.ToolStrip toolsRTB;
		private System.Windows.Forms.ToolStripButton toolsBold;
		private System.Windows.Forms.ToolStripButton toolsUnderline;
		private System.Windows.Forms.ToolStripButton toolsItalic;
		private System.Windows.Forms.ToolStripComboBox toolsFonts;
		private System.Windows.Forms.ToolStripComboBox toolsFontSizes;
		private System.Windows.Forms.ToolStripMenuItem mnuSaveAndExit;
	}
}