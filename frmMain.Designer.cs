
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
			this.btnLoadJournal = new System.Windows.Forms.Button();
			this.lbl1stSelection = new System.Windows.Forms.Label();
			this.txtJournalPIN = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lblSelectionType = new System.Windows.Forms.Label();
			this.ddlJournals = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lstEntries = new System.Windows.Forms.ListBox();
			this.rtbSelectedEntry = new System.Windows.Forms.RichTextBox();
			this.lblSeparator = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mnuJournal = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuJournal_Create = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuJournal_Delete = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSearch = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEntryTop = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEntryCreate = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEntryEditDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.lblWrongPin = new System.Windows.Forms.Label();
			this.lblEntries = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnLoadJournal
			// 
			this.btnLoadJournal.Enabled = false;
			this.btnLoadJournal.Location = new System.Drawing.Point(168, 59);
			this.btnLoadJournal.Name = "btnLoadJournal";
			this.btnLoadJournal.Size = new System.Drawing.Size(75, 23);
			this.btnLoadJournal.TabIndex = 36;
			this.btnLoadJournal.Text = "&Load";
			this.btnLoadJournal.UseVisualStyleBackColor = true;
			this.btnLoadJournal.Click += new System.EventHandler(this.btnLoadJournal_Click);
			// 
			// lbl1stSelection
			// 
			this.lbl1stSelection.AutoSize = true;
			this.lbl1stSelection.Location = new System.Drawing.Point(376, 67);
			this.lbl1stSelection.Name = "lbl1stSelection";
			this.lbl1stSelection.Size = new System.Drawing.Size(13, 15);
			this.lbl1stSelection.TabIndex = 35;
			this.lbl1stSelection.Text = "1";
			this.lbl1stSelection.Visible = false;
			// 
			// txtJournalPIN
			// 
			this.txtJournalPIN.Location = new System.Drawing.Point(61, 59);
			this.txtJournalPIN.Name = "txtJournalPIN";
			this.txtJournalPIN.Size = new System.Drawing.Size(100, 23);
			this.txtJournalPIN.TabIndex = 34;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(34, 62);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(26, 15);
			this.label4.TabIndex = 33;
			this.label4.Text = "PIN";
			// 
			// lblSelectionType
			// 
			this.lblSelectionType.AutoSize = true;
			this.lblSelectionType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblSelectionType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblSelectionType.Location = new System.Drawing.Point(12, 252);
			this.lblSelectionType.Name = "lblSelectionType";
			this.lblSelectionType.Size = new System.Drawing.Size(96, 17);
			this.lblSelectionType.TabIndex = 9;
			this.lblSelectionType.Text = "Selected Entry";
			// 
			// ddlJournals
			// 
			this.ddlJournals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ddlJournals.FormattingEnabled = true;
			this.ddlJournals.Location = new System.Drawing.Point(61, 30);
			this.ddlJournals.Name = "ddlJournals";
			this.ddlJournals.Size = new System.Drawing.Size(352, 23);
			this.ddlJournals.TabIndex = 1;
			this.ddlJournals.SelectedIndexChanged += new System.EventHandler(this.ddlJournals_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 33);
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
			this.lstEntries.Location = new System.Drawing.Point(12, 106);
			this.lstEntries.Name = "lstEntries";
			this.lstEntries.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstEntries.Size = new System.Drawing.Size(401, 123);
			this.lstEntries.TabIndex = 8;
			this.lstEntries.Visible = false;
			this.lstEntries.SelectedIndexChanged += new System.EventHandler(this.lstEntries_SelectEntry);
			// 
			// rtbSelectedEntry
			// 
			this.rtbSelectedEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbSelectedEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbSelectedEntry.Location = new System.Drawing.Point(15, 271);
			this.rtbSelectedEntry.Name = "rtbSelectedEntry";
			this.rtbSelectedEntry.Size = new System.Drawing.Size(398, 191);
			this.rtbSelectedEntry.TabIndex = 5;
			this.rtbSelectedEntry.TabStop = false;
			this.rtbSelectedEntry.Text = "";
			this.rtbSelectedEntry.Visible = false;
			// 
			// lblSeparator
			// 
			this.lblSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSeparator.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.lblSeparator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblSeparator.ForeColor = System.Drawing.Color.Red;
			this.lblSeparator.Location = new System.Drawing.Point(13, 232);
			this.lblSeparator.Name = "lblSeparator";
			this.lblSeparator.Size = new System.Drawing.Size(403, 19);
			this.lblSeparator.TabIndex = 30;
			this.lblSeparator.Text = resources.GetString("lblSeparator.Text");
			this.lblSeparator.Visible = false;
			this.lblSeparator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSeparator_MouseMove);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuJournal,
            this.mnuEntryTop});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(425, 24);
			this.menuStrip1.TabIndex = 37;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// mnuJournal
			// 
			this.mnuJournal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuJournal_Create,
            this.mnuJournal_Delete,
            this.mnuSearch});
			this.mnuJournal.Name = "mnuJournal";
			this.mnuJournal.Size = new System.Drawing.Size(57, 20);
			this.mnuJournal.Text = "Journal";
			// 
			// mnuJournal_Create
			// 
			this.mnuJournal_Create.Name = "mnuJournal_Create";
			this.mnuJournal_Create.Size = new System.Drawing.Size(109, 22);
			this.mnuJournal_Create.Text = "Create";
			this.mnuJournal_Create.Click += new System.EventHandler(this.mnuJournal_Create_Click);
			// 
			// mnuJournal_Delete
			// 
			this.mnuJournal_Delete.Enabled = false;
			this.mnuJournal_Delete.Name = "mnuJournal_Delete";
			this.mnuJournal_Delete.Size = new System.Drawing.Size(109, 22);
			this.mnuJournal_Delete.Text = "Delete";
			this.mnuJournal_Delete.Click += new System.EventHandler(this.mnuJournal_Delete_Click);
			// 
			// mnuSearch
			// 
			this.mnuSearch.Enabled = false;
			this.mnuSearch.Name = "mnuSearch";
			this.mnuSearch.Size = new System.Drawing.Size(109, 22);
			this.mnuSearch.Text = "Search";
			this.mnuSearch.Click += new System.EventHandler(this.mnuSearch_Click);
			// 
			// mnuEntryTop
			// 
			this.mnuEntryTop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEntryCreate,
            this.mnuEntryEditDelete});
			this.mnuEntryTop.Enabled = false;
			this.mnuEntryTop.Name = "mnuEntryTop";
			this.mnuEntryTop.Size = new System.Drawing.Size(46, 20);
			this.mnuEntryTop.Text = "Entry";
			// 
			// mnuEntryCreate
			// 
			this.mnuEntryCreate.Name = "mnuEntryCreate";
			this.mnuEntryCreate.Size = new System.Drawing.Size(132, 22);
			this.mnuEntryCreate.Text = "Create";
			this.mnuEntryCreate.Click += new System.EventHandler(this.mnuEntryCreate_Click);
			// 
			// mnuEntryEditDelete
			// 
			this.mnuEntryEditDelete.Enabled = false;
			this.mnuEntryEditDelete.Name = "mnuEntryEditDelete";
			this.mnuEntryEditDelete.Size = new System.Drawing.Size(132, 22);
			this.mnuEntryEditDelete.Text = "Edit/Delete";
			this.mnuEntryEditDelete.Click += new System.EventHandler(this.mnuEntryEditDelete_Click);
			// 
			// lblWrongPin
			// 
			this.lblWrongPin.AutoSize = true;
			this.lblWrongPin.ForeColor = System.Drawing.Color.Red;
			this.lblWrongPin.Location = new System.Drawing.Point(289, 63);
			this.lblWrongPin.Name = "lblWrongPin";
			this.lblWrongPin.Size = new System.Drawing.Size(63, 15);
			this.lblWrongPin.TabIndex = 38;
			this.lblWrongPin.Text = "wrong PIN";
			this.lblWrongPin.Visible = false;
			// 
			// lblEntries
			// 
			this.lblEntries.AutoSize = true;
			this.lblEntries.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblEntries.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblEntries.Location = new System.Drawing.Point(10, 87);
			this.lblEntries.Name = "lblEntries";
			this.lblEntries.Size = new System.Drawing.Size(50, 17);
			this.lblEntries.TabIndex = 39;
			this.lblEntries.Text = "Entries";
			this.lblEntries.Visible = false;
			// 
			// frmMain
			// 
			this.AcceptButton = this.btnLoadJournal;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(425, 474);
			this.Controls.Add(this.lblEntries);
			this.Controls.Add(this.lblWrongPin);
			this.Controls.Add(this.lblSelectionType);
			this.Controls.Add(this.btnLoadJournal);
			this.Controls.Add(this.lbl1stSelection);
			this.Controls.Add(this.txtJournalPIN);
			this.Controls.Add(this.lblSeparator);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.rtbSelectedEntry);
			this.Controls.Add(this.lstEntries);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ddlJournals);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmMain";
			this.Text = "MyJournal";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Resize += new System.EventHandler(this.frmMain_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnLoadJournal;
		private System.Windows.Forms.Label lbl1stSelection;
		private System.Windows.Forms.TextBox txtJournalPIN;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblSelectionType;
		private System.Windows.Forms.ComboBox ddlJournals;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lstEntries;
		private System.Windows.Forms.RichTextBox rtbSelectedEntry;
		private System.Windows.Forms.Label lblSeparator;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mnuJournal;
		private System.Windows.Forms.ToolStripMenuItem mnuJournal_Create;
		private System.Windows.Forms.ToolStripMenuItem mnuJournal_Delete;
		private System.Windows.Forms.ToolStripMenuItem mnuEntryTop;
		private System.Windows.Forms.ToolStripMenuItem mnuEntryCreate;
		private System.Windows.Forms.ToolStripMenuItem mnuEntryEditDelete;
		private System.Windows.Forms.Label lblWrongPin;
		private System.Windows.Forms.ToolStripMenuItem mnuSearch;
		private System.Windows.Forms.Label lblEntries;
	}
}