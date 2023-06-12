
namespace myNotebooks.subforms
{
	partial class frmBackupManager
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
			this.lstIncrementalBackups = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lstForcedBackups = new System.Windows.Forms.ListBox();
			this.btnRestore = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.pnlFileInfo_Incremental = new System.Windows.Forms.Panel();
			this.lblFileDate_Incremental = new System.Windows.Forms.Label();
			this.lblFileSize_Incremental = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pnlFileInfo_Forced = new System.Windows.Forms.Panel();
			this.lblFileDate_Forced = new System.Windows.Forms.Label();
			this.lblFileSize_Forced = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.pnlFileInfo_Incremental.SuspendLayout();
			this.pnlFileInfo_Forced.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstIncrementalBackups
			// 
			this.lstIncrementalBackups.FormattingEnabled = true;
			this.lstIncrementalBackups.ItemHeight = 15;
			this.lstIncrementalBackups.Location = new System.Drawing.Point(12, 27);
			this.lstIncrementalBackups.Name = "lstIncrementalBackups";
			this.lstIncrementalBackups.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstIncrementalBackups.Size = new System.Drawing.Size(310, 109);
			this.lstIncrementalBackups.TabIndex = 0;
			this.lstIncrementalBackups.SelectedIndexChanged += new System.EventHandler(this.lstAvailableFiles_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Available Incremental Backups";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 149);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(141, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Available Forced Backups";
			// 
			// lstForcedBackups
			// 
			this.lstForcedBackups.FormattingEnabled = true;
			this.lstForcedBackups.ItemHeight = 15;
			this.lstForcedBackups.Location = new System.Drawing.Point(12, 167);
			this.lstForcedBackups.Name = "lstForcedBackups";
			this.lstForcedBackups.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstForcedBackups.Size = new System.Drawing.Size(310, 109);
			this.lstForcedBackups.TabIndex = 2;
			this.lstForcedBackups.SelectedIndexChanged += new System.EventHandler(this.lstAvailableFiles_SelectedIndexChanged);
			// 
			// btnRestore
			// 
			this.btnRestore.Location = new System.Drawing.Point(13, 283);
			this.btnRestore.Name = "btnRestore";
			this.btnRestore.Size = new System.Drawing.Size(167, 23);
			this.btnRestore.TabIndex = 4;
			this.btnRestore.Text = "&Restore Selected Backup(s)";
			this.btnRestore.UseVisualStyleBackColor = true;
			this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(246, 283);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 5;
			this.btnExit.Text = "E&xit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// pnlFileInfo_Incremental
			// 
			this.pnlFileInfo_Incremental.Controls.Add(this.lblFileDate_Incremental);
			this.pnlFileInfo_Incremental.Controls.Add(this.lblFileSize_Incremental);
			this.pnlFileInfo_Incremental.Controls.Add(this.label4);
			this.pnlFileInfo_Incremental.Controls.Add(this.label3);
			this.pnlFileInfo_Incremental.Location = new System.Drawing.Point(324, 27);
			this.pnlFileInfo_Incremental.Name = "pnlFileInfo_Incremental";
			this.pnlFileInfo_Incremental.Size = new System.Drawing.Size(148, 65);
			this.pnlFileInfo_Incremental.TabIndex = 6;
			this.pnlFileInfo_Incremental.Visible = false;
			// 
			// lblFileDate_Incremental
			// 
			this.lblFileDate_Incremental.Location = new System.Drawing.Point(33, 23);
			this.lblFileDate_Incremental.Name = "lblFileDate_Incremental";
			this.lblFileDate_Incremental.Size = new System.Drawing.Size(108, 19);
			this.lblFileDate_Incremental.TabIndex = 3;
			this.lblFileDate_Incremental.Text = "10/20/22 13:00:55";
			// 
			// lblFileSize_Incremental
			// 
			this.lblFileSize_Incremental.Location = new System.Drawing.Point(33, 4);
			this.lblFileSize_Incremental.Name = "lblFileSize_Incremental";
			this.lblFileSize_Incremental.Size = new System.Drawing.Size(87, 19);
			this.lblFileSize_Incremental.TabIndex = 2;
			this.lblFileSize_Incremental.Text = "20,563";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 15);
			this.label4.TabIndex = 1;
			this.label4.Text = "Date:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(33, 15);
			this.label3.TabIndex = 0;
			this.label3.Text = "Size: ";
			// 
			// pnlFileInfo_Forced
			// 
			this.pnlFileInfo_Forced.Controls.Add(this.lblFileDate_Forced);
			this.pnlFileInfo_Forced.Controls.Add(this.lblFileSize_Forced);
			this.pnlFileInfo_Forced.Controls.Add(this.label8);
			this.pnlFileInfo_Forced.Controls.Add(this.label9);
			this.pnlFileInfo_Forced.Location = new System.Drawing.Point(324, 167);
			this.pnlFileInfo_Forced.Name = "pnlFileInfo_Forced";
			this.pnlFileInfo_Forced.Size = new System.Drawing.Size(148, 65);
			this.pnlFileInfo_Forced.TabIndex = 7;
			this.pnlFileInfo_Forced.Visible = false;
			// 
			// lblFileDate_Forced
			// 
			this.lblFileDate_Forced.Location = new System.Drawing.Point(33, 22);
			this.lblFileDate_Forced.Name = "lblFileDate_Forced";
			this.lblFileDate_Forced.Size = new System.Drawing.Size(108, 19);
			this.lblFileDate_Forced.TabIndex = 3;
			this.lblFileDate_Forced.Text = "10/20/22 13:00:55";
			// 
			// lblFileSize_Forced
			// 
			this.lblFileSize_Forced.Location = new System.Drawing.Point(33, 3);
			this.lblFileSize_Forced.Name = "lblFileSize_Forced";
			this.lblFileSize_Forced.Size = new System.Drawing.Size(87, 19);
			this.lblFileSize_Forced.TabIndex = 2;
			this.lblFileSize_Forced.Text = "20,563";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(3, 22);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 15);
			this.label8.TabIndex = 1;
			this.label8.Text = "Date: ";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(3, 4);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(33, 15);
			this.label9.TabIndex = 0;
			this.label9.Text = "Size: ";
			// 
			// frmBackupManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(486, 319);
			this.Controls.Add(this.pnlFileInfo_Forced);
			this.Controls.Add(this.pnlFileInfo_Incremental);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnRestore);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lstForcedBackups);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lstIncrementalBackups);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MinimumSize = new System.Drawing.Size(502, 358);
			this.Name = "frmBackupManager";
			this.Text = "Backup Manager";
			this.Load += new System.EventHandler(this.frmBackupManager_Load);
			this.pnlFileInfo_Incremental.ResumeLayout(false);
			this.pnlFileInfo_Incremental.PerformLayout();
			this.pnlFileInfo_Forced.ResumeLayout(false);
			this.pnlFileInfo_Forced.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lstIncrementalBackups;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox lstForcedBackups;
		private System.Windows.Forms.Button btnRestore;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Panel pnlFileInfo_Incremental;
		private System.Windows.Forms.Label lblFileDate_Incremental;
		private System.Windows.Forms.Label lblFileSize_Incremental;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel pnlFileInfo_Forced;
		private System.Windows.Forms.Label lblFileDate_Forced;
		private System.Windows.Forms.Label lblFileSize_Forced;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
	}
}