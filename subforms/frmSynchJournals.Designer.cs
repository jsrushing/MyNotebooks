namespace myJournal.subforms
{
	partial class frmSynchJournals
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
			this.pnlMain = new System.Windows.Forms.Panel();
			this.lstJournalsToSynch = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.chkSelectAll = new System.Windows.Forms.CheckBox();
			this.pnlMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.chkSelectAll);
			this.pnlMain.Controls.Add(this.lstJournalsToSynch);
			this.pnlMain.Controls.Add(this.label1);
			this.pnlMain.Controls.Add(this.btnCancel);
			this.pnlMain.Controls.Add(this.btnOk);
			this.pnlMain.Location = new System.Drawing.Point(12, 12);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(322, 255);
			this.pnlMain.TabIndex = 9;
			// 
			// lstJournalsToSynch
			// 
			this.lstJournalsToSynch.FormattingEnabled = true;
			this.lstJournalsToSynch.ItemHeight = 15;
			this.lstJournalsToSynch.Location = new System.Drawing.Point(7, 25);
			this.lstJournalsToSynch.Name = "lstJournalsToSynch";
			this.lstJournalsToSynch.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstJournalsToSynch.Size = new System.Drawing.Size(304, 169);
			this.lstJournalsToSynch.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select Journals to synch:";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(213, 220);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(24, 220);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "&Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// chkSelectAll
			// 
			this.chkSelectAll.AutoSize = true;
			this.chkSelectAll.Location = new System.Drawing.Point(205, 6);
			this.chkSelectAll.Name = "chkSelectAll";
			this.chkSelectAll.Size = new System.Drawing.Size(71, 19);
			this.chkSelectAll.TabIndex = 6;
			this.chkSelectAll.Text = "select all";
			this.chkSelectAll.UseVisualStyleBackColor = true;
			this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
			// 
			// frmSynchJournals
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(348, 274);
			this.Controls.Add(this.pnlMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSynchJournals";
			this.Text = "frmSynchJournals";
			this.Load += new System.EventHandler(this.frmSynchJournals_Load);
			this.pnlMain.ResumeLayout(false);
			this.pnlMain.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.ListBox lstJournalsToSynch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.CheckBox chkSelectAll;
	}
}