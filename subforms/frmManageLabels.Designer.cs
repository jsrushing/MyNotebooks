
namespace myJournal.subforms
{
	partial class frmManageLabels
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.pnlNewLabelName = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.lblOperation = new System.Windows.Forms.Label();
			this.txtLabelName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lstLabels = new System.Windows.Forms.ListBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRename = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRename_InAllJournals = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRename_InCurrentJournal = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMoveTop = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.pnlNewLabelName.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.pnlNewLabelName);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.lstLabels);
			this.panel1.Location = new System.Drawing.Point(12, 28);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(341, 283);
			this.panel1.TabIndex = 0;
			// 
			// pnlNewLabelName
			// 
			this.pnlNewLabelName.Controls.Add(this.btnCancel);
			this.pnlNewLabelName.Controls.Add(this.btnOK);
			this.pnlNewLabelName.Controls.Add(this.lblOperation);
			this.pnlNewLabelName.Controls.Add(this.txtLabelName);
			this.pnlNewLabelName.Location = new System.Drawing.Point(18, 72);
			this.pnlNewLabelName.Name = "pnlNewLabelName";
			this.pnlNewLabelName.Size = new System.Drawing.Size(287, 94);
			this.pnlNewLabelName.TabIndex = 2;
			this.pnlNewLabelName.Visible = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(139, 56);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(32, 56);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "&Ok";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lblOperation
			// 
			this.lblOperation.Location = new System.Drawing.Point(16, 20);
			this.lblOperation.Name = "lblOperation";
			this.lblOperation.Size = new System.Drawing.Size(87, 15);
			this.lblOperation.TabIndex = 1;
			this.lblOperation.Text = "Label Name:";
			this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtLabelName
			// 
			this.txtLabelName.Location = new System.Drawing.Point(104, 16);
			this.txtLabelName.Name = "txtLabelName";
			this.txtLabelName.Size = new System.Drawing.Size(167, 23);
			this.txtLabelName.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Labels:";
			// 
			// lstLabels
			// 
			this.lstLabels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstLabels.FormattingEnabled = true;
			this.lstLabels.ItemHeight = 15;
			this.lstLabels.Location = new System.Drawing.Point(9, 27);
			this.lstLabels.Name = "lstLabels";
			this.lstLabels.Size = new System.Drawing.Size(322, 244);
			this.lstLabels.TabIndex = 0;
			this.lstLabels.SelectedIndexChanged += new System.EventHandler(this.lstLabels_SelectedIndexChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuRename,
            this.mnuMoveTop,
            this.mnuDelete,
            this.mnuExit});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(366, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// mnuAdd
			// 
			this.mnuAdd.Name = "mnuAdd";
			this.mnuAdd.Size = new System.Drawing.Size(41, 20);
			this.mnuAdd.Text = "&Add";
			this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
			// 
			// mnuRename
			// 
			this.mnuRename.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRename_InAllJournals,
            this.mnuRename_InCurrentJournal});
			this.mnuRename.Enabled = false;
			this.mnuRename.Name = "mnuRename";
			this.mnuRename.Size = new System.Drawing.Size(62, 20);
			this.mnuRename.Text = "&Rename";
			// 
			// mnuRename_InAllJournals
			// 
			this.mnuRename_InAllJournals.Name = "mnuRename_InAllJournals";
			this.mnuRename_InAllJournals.Size = new System.Drawing.Size(180, 22);
			this.mnuRename_InAllJournals.Text = "In All Journals";
			this.mnuRename_InAllJournals.Click += new System.EventHandler(this.mnuRename_Click);
			// 
			// mnuRename_InCurrentJournal
			// 
			this.mnuRename_InCurrentJournal.Name = "mnuRename_InCurrentJournal";
			this.mnuRename_InCurrentJournal.Size = new System.Drawing.Size(180, 22);
			this.mnuRename_InCurrentJournal.Text = "In ";
			this.mnuRename_InCurrentJournal.Click += new System.EventHandler(this.mnuRename_Click);
			// 
			// mnuMoveTop
			// 
			this.mnuMoveTop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMoveUp,
            this.mnuMoveDown});
			this.mnuMoveTop.Enabled = false;
			this.mnuMoveTop.Name = "mnuMoveTop";
			this.mnuMoveTop.Size = new System.Drawing.Size(49, 20);
			this.mnuMoveTop.Text = "&Move";
			// 
			// mnuMoveUp
			// 
			this.mnuMoveUp.Name = "mnuMoveUp";
			this.mnuMoveUp.Size = new System.Drawing.Size(105, 22);
			this.mnuMoveUp.Text = "Up";
			this.mnuMoveUp.Click += new System.EventHandler(this.mnuMoveUp_Click);
			// 
			// mnuMoveDown
			// 
			this.mnuMoveDown.Name = "mnuMoveDown";
			this.mnuMoveDown.Size = new System.Drawing.Size(105, 22);
			this.mnuMoveDown.Text = "Down";
			this.mnuMoveDown.Click += new System.EventHandler(this.mnuMoveDown_Click);
			// 
			// mnuDelete
			// 
			this.mnuDelete.Enabled = false;
			this.mnuDelete.Name = "mnuDelete";
			this.mnuDelete.Size = new System.Drawing.Size(52, 20);
			this.mnuDelete.Text = "&Delete";
			this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
			// 
			// mnuExit
			// 
			this.mnuExit.Name = "mnuExit";
			this.mnuExit.Size = new System.Drawing.Size(38, 20);
			this.mnuExit.Text = "Exit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// frmManageLabels
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(366, 323);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(382, 362);
			this.Name = "frmManageLabels";
			this.Text = "Manage Labels";
			this.Load += new System.EventHandler(this.frmManageLabels_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnlNewLabelName.ResumeLayout(false);
			this.pnlNewLabelName.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mnuAdd;
		private System.Windows.Forms.ToolStripMenuItem mnuRename;
		private System.Windows.Forms.ToolStripMenuItem mnuMoveTop;
		private System.Windows.Forms.ToolStripMenuItem mnuDelete;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lstLabels;
		private System.Windows.Forms.ToolStripMenuItem mnuMoveUp;
		private System.Windows.Forms.ToolStripMenuItem mnuMoveDown;
		private System.Windows.Forms.ToolStripMenuItem mnuExit;
		private System.Windows.Forms.Panel pnlNewLabelName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label lblOperation;
		private System.Windows.Forms.TextBox txtLabelName;
		private System.Windows.Forms.ToolStripMenuItem mnuRename_InAllJournals;
		private System.Windows.Forms.ToolStripMenuItem mnuRename_InCurrentJournal;
	}
}