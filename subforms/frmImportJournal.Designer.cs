
namespace myJournal
{
	partial class frmImportJournal
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
			this.cbxJournals_From = new System.Windows.Forms.ComboBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnImport = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.lblSelectAllEntries = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cbxJournals_From
			// 
			this.cbxJournals_From.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxJournals_From.FormattingEnabled = true;
			this.cbxJournals_From.Location = new System.Drawing.Point(12, 27);
			this.cbxJournals_From.Name = "cbxJournals_From";
			this.cbxJournals_From.Size = new System.Drawing.Size(261, 23);
			this.cbxJournals_From.TabIndex = 0;
			this.cbxJournals_From.SelectedIndexChanged += new System.EventHandler(this.cbxJournals_From_SelectedIndexChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(139, 481);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnImport
			// 
			this.btnImport.Location = new System.Drawing.Point(58, 481);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(75, 23);
			this.btnImport.TabIndex = 3;
			this.btnImport.Text = "&Import";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(118, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Import From Journal:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 15);
			this.label2.TabIndex = 6;
			this.label2.Text = "Import Entries:";
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(11, 80);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(260, 202);
			this.checkedListBox1.TabIndex = 7;
			// 
			// lblSelectAllEntries
			// 
			this.lblSelectAllEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSelectAllEntries.AutoSize = true;
			this.lblSelectAllEntries.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblSelectAllEntries.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblSelectAllEntries.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblSelectAllEntries.Location = new System.Drawing.Point(206, 62);
			this.lblSelectAllEntries.Name = "lblSelectAllEntries";
			this.lblSelectAllEntries.Size = new System.Drawing.Size(55, 15);
			this.lblSelectAllEntries.TabIndex = 8;
			this.lblSelectAllEntries.Text = "select all";
			this.lblSelectAllEntries.Click += new System.EventHandler(this.lblSelectAllEntries_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 296);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 15);
			this.label3.TabIndex = 9;
			this.label3.Text = "Imported Items PIN";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(121, 288);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(150, 23);
			this.textBox1.TabIndex = 10;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(12, 339);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(259, 118);
			this.textBox2.TabIndex = 11;
			// 
			// frmImportJournal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(283, 521);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblSelectAllEntries);
			this.Controls.Add(this.checkedListBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.cbxJournals_From);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmImportJournal";
			this.Text = "frmImportJournal";
			this.Load += new System.EventHandler(this.frmImportJournal_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbxJournals_From;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.Label lblSelectAllEntries;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
	}
}