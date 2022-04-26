
namespace myJournal.subforms
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
			this.grp1 = new System.Windows.Forms.GroupBox();
			this.btnLoadJournal = new System.Windows.Forms.Button();
			this.lbl1stSelection = new System.Windows.Forms.Label();
			this.txtJournalPIN = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.grpSelectedEntryLabels = new System.Windows.Forms.Panel();
			this.lblPrint = new System.Windows.Forms.Label();
			this.lblSelectionType = new System.Windows.Forms.Label();
			this.lblMenu = new System.Windows.Forms.Label();
			this.lblEntriesStartFrom = new System.Windows.Forms.Label();
			this.ddlJournals = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lstEntries = new System.Windows.Forms.ListBox();
			this.lblSelectAJournal = new System.Windows.Forms.Label();
			this.rtbSelectedEntry_Main = new System.Windows.Forms.RichTextBox();
			this.lblSeparator_grpOpenScreen = new System.Windows.Forms.Label();
			this.grp1.SuspendLayout();
			this.grpSelectedEntryLabels.SuspendLayout();
			this.SuspendLayout();
			// 
			// grp1
			// 
			this.grp1.BackColor = System.Drawing.SystemColors.Window;
			this.grp1.Controls.Add(this.btnLoadJournal);
			this.grp1.Controls.Add(this.lbl1stSelection);
			this.grp1.Controls.Add(this.txtJournalPIN);
			this.grp1.Controls.Add(this.label4);
			this.grp1.Controls.Add(this.grpSelectedEntryLabels);
			this.grp1.Controls.Add(this.lblMenu);
			this.grp1.Controls.Add(this.lblEntriesStartFrom);
			this.grp1.Controls.Add(this.ddlJournals);
			this.grp1.Controls.Add(this.label1);
			this.grp1.Controls.Add(this.lstEntries);
			this.grp1.Controls.Add(this.lblSelectAJournal);
			this.grp1.Controls.Add(this.rtbSelectedEntry_Main);
			this.grp1.Controls.Add(this.lblSeparator_grpOpenScreen);
			this.grp1.Location = new System.Drawing.Point(2, 12);
			this.grp1.Name = "grp1";
			this.grp1.Size = new System.Drawing.Size(369, 545);
			this.grp1.TabIndex = 6;
			this.grp1.TabStop = false;
			// 
			// btnLoadJournal
			// 
			this.btnLoadJournal.Location = new System.Drawing.Point(162, 80);
			this.btnLoadJournal.Name = "btnLoadJournal";
			this.btnLoadJournal.Size = new System.Drawing.Size(75, 23);
			this.btnLoadJournal.TabIndex = 36;
			this.btnLoadJournal.Text = "&Load";
			this.btnLoadJournal.UseVisualStyleBackColor = true;
			// 
			// lbl1stSelection
			// 
			this.lbl1stSelection.AutoSize = true;
			this.lbl1stSelection.Location = new System.Drawing.Point(268, 88);
			this.lbl1stSelection.Name = "lbl1stSelection";
			this.lbl1stSelection.Size = new System.Drawing.Size(13, 15);
			this.lbl1stSelection.TabIndex = 35;
			this.lbl1stSelection.Text = "1";
			this.lbl1stSelection.Visible = false;
			// 
			// txtJournalPIN
			// 
			this.txtJournalPIN.Location = new System.Drawing.Point(55, 80);
			this.txtJournalPIN.Name = "txtJournalPIN";
			this.txtJournalPIN.Size = new System.Drawing.Size(100, 23);
			this.txtJournalPIN.TabIndex = 34;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(28, 83);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(26, 15);
			this.label4.TabIndex = 33;
			this.label4.Text = "PIN";
			// 
			// grpSelectedEntryLabels
			// 
			this.grpSelectedEntryLabels.Controls.Add(this.lblPrint);
			this.grpSelectedEntryLabels.Controls.Add(this.lblSelectionType);
			this.grpSelectedEntryLabels.Location = new System.Drawing.Point(10, 254);
			this.grpSelectedEntryLabels.Name = "grpSelectedEntryLabels";
			this.grpSelectedEntryLabels.Size = new System.Drawing.Size(280, 19);
			this.grpSelectedEntryLabels.TabIndex = 32;
			this.grpSelectedEntryLabels.Visible = false;
			// 
			// lblPrint
			// 
			this.lblPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPrint.AutoSize = true;
			this.lblPrint.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblPrint.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblPrint.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblPrint.Location = new System.Drawing.Point(320, 0);
			this.lblPrint.Name = "lblPrint";
			this.lblPrint.Size = new System.Drawing.Size(34, 15);
			this.lblPrint.TabIndex = 29;
			this.lblPrint.Text = "print";
			this.lblPrint.Visible = false;
			// 
			// lblSelectionType
			// 
			this.lblSelectionType.AutoSize = true;
			this.lblSelectionType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblSelectionType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblSelectionType.Location = new System.Drawing.Point(3, 0);
			this.lblSelectionType.Name = "lblSelectionType";
			this.lblSelectionType.Size = new System.Drawing.Size(118, 17);
			this.lblSelectionType.TabIndex = 9;
			this.lblSelectionType.Text = "Select An Entry ...";
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
			this.lblEntriesStartFrom.Location = new System.Drawing.Point(127, 32);
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
			this.ddlJournals.Location = new System.Drawing.Point(55, 51);
			this.ddlJournals.Name = "ddlJournals";
			this.ddlJournals.Size = new System.Drawing.Size(299, 23);
			this.ddlJournals.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Journal ";
			// 
			// lstEntries
			// 
			this.lstEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstEntries.FormattingEnabled = true;
			this.lstEntries.HorizontalScrollbar = true;
			this.lstEntries.IntegralHeight = false;
			this.lstEntries.ItemHeight = 15;
			this.lstEntries.Location = new System.Drawing.Point(6, 109);
			this.lstEntries.Name = "lstEntries";
			this.lstEntries.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstEntries.Size = new System.Drawing.Size(357, 123);
			this.lstEntries.TabIndex = 8;
			// 
			// lblSelectAJournal
			// 
			this.lblSelectAJournal.AutoSize = true;
			this.lblSelectAJournal.Enabled = false;
			this.lblSelectAJournal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblSelectAJournal.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblSelectAJournal.Location = new System.Drawing.Point(6, 29);
			this.lblSelectAJournal.Name = "lblSelectAJournal";
			this.lblSelectAJournal.Size = new System.Drawing.Size(133, 17);
			this.lblSelectAJournal.TabIndex = 7;
			this.lblSelectAJournal.Text = "(Select A Journal ...)";
			// 
			// rtbSelectedEntry_Main
			// 
			this.rtbSelectedEntry_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbSelectedEntry_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbSelectedEntry_Main.Location = new System.Drawing.Point(9, 279);
			this.rtbSelectedEntry_Main.Name = "rtbSelectedEntry_Main";
			this.rtbSelectedEntry_Main.Size = new System.Drawing.Size(354, 244);
			this.rtbSelectedEntry_Main.TabIndex = 5;
			this.rtbSelectedEntry_Main.TabStop = false;
			this.rtbSelectedEntry_Main.Text = "";
			// 
			// lblSeparator_grpOpenScreen
			// 
			this.lblSeparator_grpOpenScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSeparator_grpOpenScreen.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.lblSeparator_grpOpenScreen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblSeparator_grpOpenScreen.ForeColor = System.Drawing.Color.Red;
			this.lblSeparator_grpOpenScreen.Location = new System.Drawing.Point(7, 235);
			this.lblSeparator_grpOpenScreen.Name = "lblSeparator_grpOpenScreen";
			this.lblSeparator_grpOpenScreen.Size = new System.Drawing.Size(329, 19);
			this.lblSeparator_grpOpenScreen.TabIndex = 30;
			this.lblSeparator_grpOpenScreen.Text = resources.GetString("lblSeparator_grpOpenScreen.Text");
			this.lblSeparator_grpOpenScreen.Visible = false;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(420, 580);
			this.Controls.Add(this.grp1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmMain";
			this.Text = "MyJournal";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.grp1.ResumeLayout(false);
			this.grp1.PerformLayout();
			this.grpSelectedEntryLabels.ResumeLayout(false);
			this.grpSelectedEntryLabels.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grp1;
		private System.Windows.Forms.Button btnLoadJournal;
		private System.Windows.Forms.Label lbl1stSelection;
		private System.Windows.Forms.TextBox txtJournalPIN;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel grpSelectedEntryLabels;
		private System.Windows.Forms.Label lblPrint;
		private System.Windows.Forms.Label lblSelectionType;
		private System.Windows.Forms.Label lblMenu;
		private System.Windows.Forms.Label lblEntriesStartFrom;
		private System.Windows.Forms.ComboBox ddlJournals;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lstEntries;
		private System.Windows.Forms.Label lblSelectAJournal;
		private System.Windows.Forms.RichTextBox rtbSelectedEntry_Main;
		private System.Windows.Forms.Label lblSeparator_grpOpenScreen;
	}
}