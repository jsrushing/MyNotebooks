
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
			this.grpCreateEntry = new System.Windows.Forms.GroupBox();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.lblTagManager2 = new System.Windows.Forms.Label();
			this.lblEntryText_Hidden = new System.Windows.Forms.Label();
			this.lblEntryTitle_Hidden = new System.Windows.Forms.Label();
			this.lstTags = new System.Windows.Forms.CheckedListBox();
			this.label14 = new System.Windows.Forms.Label();
			this.lblFont_NewEntry = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.rtbNewEntry = new System.Windows.Forms.RichTextBox();
			this.txtNewEntryTitle = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.grpCreateEntry.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpCreateEntry
			// 
			this.grpCreateEntry.Controls.Add(this.label1);
			this.grpCreateEntry.Controls.Add(this.label4);
			this.grpCreateEntry.Controls.Add(this.pnlButtons);
			this.grpCreateEntry.Controls.Add(this.lblTagManager2);
			this.grpCreateEntry.Controls.Add(this.lblEntryText_Hidden);
			this.grpCreateEntry.Controls.Add(this.lblEntryTitle_Hidden);
			this.grpCreateEntry.Controls.Add(this.lstTags);
			this.grpCreateEntry.Controls.Add(this.label14);
			this.grpCreateEntry.Controls.Add(this.lblFont_NewEntry);
			this.grpCreateEntry.Controls.Add(this.label3);
			this.grpCreateEntry.Controls.Add(this.rtbNewEntry);
			this.grpCreateEntry.Controls.Add(this.txtNewEntryTitle);
			this.grpCreateEntry.Controls.Add(this.label2);
			this.grpCreateEntry.Location = new System.Drawing.Point(12, 0);
			this.grpCreateEntry.Name = "grpCreateEntry";
			this.grpCreateEntry.Size = new System.Drawing.Size(414, 576);
			this.grpCreateEntry.TabIndex = 5;
			this.grpCreateEntry.TabStop = false;
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnCancel);
			this.pnlButtons.Controls.Add(this.btnOK);
			this.pnlButtons.Location = new System.Drawing.Point(26, 533);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(269, 34);
			this.pnlButtons.TabIndex = 37;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(191, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 26);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(8, 3);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 26);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lblTagManager2
			// 
			this.lblTagManager2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTagManager2.AutoSize = true;
			this.lblTagManager2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblTagManager2.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblTagManager2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblTagManager2.Location = new System.Drawing.Point(443, 400);
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
			// lstTags
			// 
			this.lstTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstTags.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstTags.CheckOnClick = true;
			this.lstTags.FormattingEnabled = true;
			this.lstTags.Location = new System.Drawing.Point(6, 432);
			this.lstTags.Name = "lstTags";
			this.lstTags.Size = new System.Drawing.Size(395, 90);
			this.lstTags.TabIndex = 27;
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label14.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label14.Location = new System.Drawing.Point(6, 873);
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
			this.lblFont_NewEntry.Location = new System.Drawing.Point(463, 70);
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
			this.label3.Location = new System.Drawing.Point(6, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 17);
			this.label3.TabIndex = 3;
			this.label3.Text = "Entry";
			// 
			// rtbNewEntry
			// 
			this.rtbNewEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbNewEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbNewEntry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.rtbNewEntry.Location = new System.Drawing.Point(6, 64);
			this.rtbNewEntry.Name = "rtbNewEntry";
			this.rtbNewEntry.Size = new System.Drawing.Size(395, 345);
			this.rtbNewEntry.TabIndex = 2;
			this.rtbNewEntry.Text = "";
			// 
			// txtNewEntryTitle
			// 
			this.txtNewEntryTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNewEntryTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNewEntryTitle.Location = new System.Drawing.Point(46, 19);
			this.txtNewEntryTitle.Multiline = true;
			this.txtNewEntryTitle.Name = "txtNewEntryTitle";
			this.txtNewEntryTitle.Size = new System.Drawing.Size(355, 23);
			this.txtNewEntryTitle.TabIndex = 1;
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
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label1.Location = new System.Drawing.Point(218, 413);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 17);
			this.label1.TabIndex = 40;
			this.label1.Text = "manage tags";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label4.Location = new System.Drawing.Point(13, 412);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 17);
			this.label4.TabIndex = 38;
			this.label4.Text = "tags";
			// 
			// frmNewEntry
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(469, 710);
			this.Controls.Add(this.grpCreateEntry);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmNewEntry";
			this.Text = "New Entry";
			this.Load += new System.EventHandler(this.frmNewEntry_Load);
			this.grpCreateEntry.ResumeLayout(false);
			this.grpCreateEntry.PerformLayout();
			this.pnlButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpCreateEntry;
		private System.Windows.Forms.Label lblTagManager2;
		private System.Windows.Forms.Label lblEntryText_Hidden;
		private System.Windows.Forms.Label lblEntryTitle_Hidden;
		private System.Windows.Forms.CheckedListBox lstTags;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label lblFont_NewEntry;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RichTextBox rtbNewEntry;
		private System.Windows.Forms.TextBox txtNewEntryTitle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlButtons;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
	}
}