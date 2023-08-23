
using System.Windows.Forms;

namespace myNotebooks.subforms
{
	partial class frmLabelsManager
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
			components = new System.ComponentModel.Container();
			pnlMain = new Panel();
			pnlNewLabelName = new Panel();
			txtLabelName = new TextBox();
			lblLabelExists = new Label();
			btnOK = new Button();
			btnCancel = new Button();
			lblOperation = new Label();
			label5 = new Label();
			lstLabels = new ListBox();
			mnuContextLabels = new ContextMenuStrip(components);
			mnuContextRename_lstLables = new ToolStripMenuItem();
			mnuContextDelete_lstLabels = new ToolStripMenuItem();
			lblEntries2 = new Label();
			lblSortType = new Label();
			lblEntries1 = new Label();
			lstOccurrences = new ListBox();
			mnuContextEntries = new ContextMenuStrip(components);
			mnuContextRename_lstEntries = new ToolStripMenuItem();
			mnuContextDelete_lstEntries = new ToolStripMenuItem();
			label1 = new Label();
			mnuMain = new MenuStrip();
			mnuLabelsOperations = new ToolStripMenuItem();
			mnuAdd = new ToolStripMenuItem();
			mnuFindOrphans = new ToolStripMenuItem();
			mnuMoveTop = new ToolStripMenuItem();
			mnuMoveUp = new ToolStripMenuItem();
			mnuMoveDown = new ToolStripMenuItem();
			mnuAssignPINs = new ToolStripMenuItem();
			lstEntryObjects = new ListBox();
			pnlOrphanedLabels = new Panel();
			btnExitOrphans = new Button();
			chkSelectAllOrphans = new CheckBox();
			btnRemoveSelectedOrphans = new Button();
			lstOrphanedLabels = new ListBox();
			label4 = new Label();
			listBox1 = new ListBox();
			listBox2 = new ListBox();
			label2 = new Label();
			label3 = new Label();
			pnlMain.SuspendLayout();
			pnlNewLabelName.SuspendLayout();
			mnuContextLabels.SuspendLayout();
			mnuContextEntries.SuspendLayout();
			mnuMain.SuspendLayout();
			pnlOrphanedLabels.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			pnlMain.Controls.Add(label3);
			pnlMain.Controls.Add(label2);
			pnlMain.Controls.Add(listBox2);
			pnlMain.Controls.Add(listBox1);
			pnlMain.Controls.Add(lstLabels);
			pnlMain.Controls.Add(lblEntries2);
			pnlMain.Controls.Add(lblSortType);
			pnlMain.Controls.Add(lblEntries1);
			pnlMain.Controls.Add(lstOccurrences);
			pnlMain.Controls.Add(label1);
			pnlMain.Location = new System.Drawing.Point(16, 25);
			pnlMain.Name = "pnlMain";
			pnlMain.Size = new System.Drawing.Size(269, 554);
			pnlMain.TabIndex = 0;
			// 
			// pnlNewLabelName
			// 
			pnlNewLabelName.BackColor = System.Drawing.SystemColors.ActiveCaption;
			pnlNewLabelName.Controls.Add(txtLabelName);
			pnlNewLabelName.Controls.Add(lblLabelExists);
			pnlNewLabelName.Controls.Add(btnOK);
			pnlNewLabelName.Controls.Add(btnCancel);
			pnlNewLabelName.Controls.Add(lblOperation);
			pnlNewLabelName.Controls.Add(label5);
			pnlNewLabelName.Location = new System.Drawing.Point(303, 297);
			pnlNewLabelName.Name = "pnlNewLabelName";
			pnlNewLabelName.Size = new System.Drawing.Size(204, 110);
			pnlNewLabelName.TabIndex = 2;
			pnlNewLabelName.Visible = false;
			// 
			// txtLabelName
			// 
			txtLabelName.Location = new System.Drawing.Point(26, 34);
			txtLabelName.Name = "txtLabelName";
			txtLabelName.Size = new System.Drawing.Size(154, 23);
			txtLabelName.TabIndex = 0;
			// 
			// lblLabelExists
			// 
			lblLabelExists.AutoSize = true;
			lblLabelExists.BackColor = System.Drawing.SystemColors.ButtonFace;
			lblLabelExists.ForeColor = System.Drawing.Color.Red;
			lblLabelExists.Location = new System.Drawing.Point(37, 56);
			lblLabelExists.Name = "lblLabelExists";
			lblLabelExists.Size = new System.Drawing.Size(111, 15);
			lblLabelExists.TabIndex = 4;
			lblLabelExists.Text = "Label already exists.";
			lblLabelExists.Visible = false;
			// 
			// btnOK
			// 
			btnOK.Location = new System.Drawing.Point(18, 71);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 2;
			btnOK.Text = "&Ok";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += this.btnOK_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new System.Drawing.Point(105, 71);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 3;
			btnCancel.Text = "&Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += this.btnCancel_Click;
			// 
			// lblOperation
			// 
			lblOperation.AutoSize = true;
			lblOperation.BackColor = System.Drawing.SystemColors.ButtonFace;
			lblOperation.Location = new System.Drawing.Point(26, 15);
			lblOperation.Name = "lblOperation";
			lblOperation.Size = new System.Drawing.Size(100, 15);
			lblOperation.TabIndex = 1;
			lblOperation.Text = "New Label Name:";
			lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			label5.BackColor = System.Drawing.SystemColors.ButtonFace;
			label5.Location = new System.Drawing.Point(11, 7);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(182, 93);
			label5.TabIndex = 5;
			// 
			// lstLabels
			// 
			lstLabels.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			lstLabels.ContextMenuStrip = mnuContextLabels;
			lstLabels.FormattingEnabled = true;
			lstLabels.IntegralHeight = false;
			lstLabels.ItemHeight = 15;
			lstLabels.Location = new System.Drawing.Point(9, 23);
			lstLabels.Name = "lstLabels";
			lstLabels.Size = new System.Drawing.Size(251, 79);
			lstLabels.TabIndex = 0;
			lstLabels.SelectedIndexChanged += this.lstLabels_SelectedIndexChanged;
			lstLabels.MouseUp += this.lstLabels_MouseUp;
			// 
			// mnuContextLabels
			// 
			mnuContextLabels.Items.AddRange(new ToolStripItem[] { mnuContextRename_lstLables, mnuContextDelete_lstLabels });
			mnuContextLabels.Name = "mnuContextLabels";
			mnuContextLabels.Size = new System.Drawing.Size(118, 48);
			// 
			// mnuContextRename_lstLables
			// 
			mnuContextRename_lstLables.Name = "mnuContextRename_lstLables";
			mnuContextRename_lstLables.Size = new System.Drawing.Size(117, 22);
			mnuContextRename_lstLables.Text = "&Rename";
			mnuContextRename_lstLables.Click += this.DeleteOrRename;
			// 
			// mnuContextDelete_lstLabels
			// 
			mnuContextDelete_lstLabels.Name = "mnuContextDelete_lstLabels";
			mnuContextDelete_lstLabels.Size = new System.Drawing.Size(117, 22);
			mnuContextDelete_lstLabels.Text = "&Delete";
			mnuContextDelete_lstLabels.Click += this.DeleteOrRename;
			// 
			// lblEntries2
			// 
			lblEntries2.AutoSize = true;
			lblEntries2.Location = new System.Drawing.Point(4, 376);
			lblEntries2.Name = "lblEntries2";
			lblEntries2.Size = new System.Drawing.Size(216, 15);
			lblEntries2.TabIndex = 6;
			lblEntries2.Text = "(dbl-click entry or right-click notebook)";
			// 
			// lblSortType
			// 
			lblSortType.AutoSize = true;
			lblSortType.Cursor = Cursors.Hand;
			lblSortType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			lblSortType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblSortType.Location = new System.Drawing.Point(187, 4);
			lblSortType.Name = "lblSortType";
			lblSortType.Size = new System.Drawing.Size(59, 17);
			lblSortType.TabIndex = 5;
			lblSortType.Text = "Sort A-Z";
			lblSortType.Click += this.lblSortType_Click;
			// 
			// lblEntries1
			// 
			lblEntries1.AutoSize = true;
			lblEntries1.Location = new System.Drawing.Point(4, 361);
			lblEntries1.Name = "lblEntries1";
			lblEntries1.Size = new System.Drawing.Size(79, 15);
			lblEntries1.TabIndex = 4;
			lblEntries1.Text = "Found Entries";
			// 
			// lstOccurrences
			// 
			lstOccurrences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstOccurrences.ContextMenuStrip = mnuContextEntries;
			lstOccurrences.FormattingEnabled = true;
			lstOccurrences.IntegralHeight = false;
			lstOccurrences.ItemHeight = 15;
			lstOccurrences.Location = new System.Drawing.Point(9, 428);
			lstOccurrences.Name = "lstOccurrences";
			lstOccurrences.Size = new System.Drawing.Size(251, 118);
			lstOccurrences.TabIndex = 3;
			lstOccurrences.DoubleClick += this.lstOccurrences_DoubleClick;
			lstOccurrences.MouseUp += this.lstOccurrences_MouseUp;
			// 
			// mnuContextEntries
			// 
			mnuContextEntries.Items.AddRange(new ToolStripItem[] { mnuContextRename_lstEntries, mnuContextDelete_lstEntries });
			mnuContextEntries.Name = "mnuFoundEntries";
			mnuContextEntries.Size = new System.Drawing.Size(185, 48);
			// 
			// mnuContextRename_lstEntries
			// 
			mnuContextRename_lstEntries.Name = "mnuContextRename_lstEntries";
			mnuContextRename_lstEntries.Size = new System.Drawing.Size(184, 22);
			mnuContextRename_lstEntries.Text = "&Rename in notebook";
			mnuContextRename_lstEntries.Click += this.DeleteOrRename;
			// 
			// mnuContextDelete_lstEntries
			// 
			mnuContextDelete_lstEntries.Name = "mnuContextDelete_lstEntries";
			mnuContextDelete_lstEntries.Size = new System.Drawing.Size(184, 22);
			mnuContextDelete_lstEntries.Text = "&Delete in notebook";
			mnuContextDelete_lstEntries.Click += this.DeleteOrRename;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(4, 7);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(109, 15);
			label1.TabIndex = 1;
			label1.Text = "Labels in Notebook";
			// 
			// mnuMain
			// 
			mnuMain.Items.AddRange(new ToolStripItem[] { mnuLabelsOperations, mnuMoveTop, mnuAssignPINs });
			mnuMain.Location = new System.Drawing.Point(0, 0);
			mnuMain.Name = "mnuMain";
			mnuMain.Size = new System.Drawing.Size(535, 24);
			mnuMain.TabIndex = 1;
			mnuMain.Text = "menuStrip1";
			// 
			// mnuLabelsOperations
			// 
			mnuLabelsOperations.DropDownItems.AddRange(new ToolStripItem[] { mnuAdd, mnuFindOrphans });
			mnuLabelsOperations.Name = "mnuLabelsOperations";
			mnuLabelsOperations.Size = new System.Drawing.Size(52, 20);
			mnuLabelsOperations.Text = "Labels";
			// 
			// mnuAdd
			// 
			mnuAdd.Name = "mnuAdd";
			mnuAdd.Size = new System.Drawing.Size(145, 22);
			mnuAdd.Text = "&Add";
			mnuAdd.Click += this.mnuAdd_Click;
			// 
			// mnuFindOrphans
			// 
			mnuFindOrphans.Name = "mnuFindOrphans";
			mnuFindOrphans.Size = new System.Drawing.Size(145, 22);
			mnuFindOrphans.Text = "Find &Orphans";
			mnuFindOrphans.Click += this.mnuFindOrphans_Click;
			// 
			// mnuMoveTop
			// 
			mnuMoveTop.DropDownItems.AddRange(new ToolStripItem[] { mnuMoveUp, mnuMoveDown });
			mnuMoveTop.Enabled = false;
			mnuMoveTop.Name = "mnuMoveTop";
			mnuMoveTop.Size = new System.Drawing.Size(49, 20);
			mnuMoveTop.Text = "&Move";
			// 
			// mnuMoveUp
			// 
			mnuMoveUp.Name = "mnuMoveUp";
			mnuMoveUp.Size = new System.Drawing.Size(105, 22);
			mnuMoveUp.Text = "&Up";
			mnuMoveUp.Click += this.MenuMove;
			// 
			// mnuMoveDown
			// 
			mnuMoveDown.Name = "mnuMoveDown";
			mnuMoveDown.Size = new System.Drawing.Size(105, 22);
			mnuMoveDown.Text = "D&own";
			mnuMoveDown.Click += this.MenuMove;
			// 
			// mnuAssignPINs
			// 
			mnuAssignPINs.Name = "mnuAssignPINs";
			mnuAssignPINs.Size = new System.Drawing.Size(111, 20);
			mnuAssignPINs.Text = "&Select Notebooks";
			mnuAssignPINs.Click += this.mnuSelectNotebooks_Click;
			// 
			// lstEntryObjects
			// 
			lstEntryObjects.Anchor = AnchorStyles.None;
			lstEntryObjects.FormattingEnabled = true;
			lstEntryObjects.IntegralHeight = false;
			lstEntryObjects.ItemHeight = 15;
			lstEntryObjects.Location = new System.Drawing.Point(317, 240);
			lstEntryObjects.Name = "lstEntryObjects";
			lstEntryObjects.Size = new System.Drawing.Size(127, 25);
			lstEntryObjects.TabIndex = 4;
			lstEntryObjects.Visible = false;
			// 
			// pnlOrphanedLabels
			// 
			pnlOrphanedLabels.Controls.Add(btnExitOrphans);
			pnlOrphanedLabels.Controls.Add(chkSelectAllOrphans);
			pnlOrphanedLabels.Controls.Add(btnRemoveSelectedOrphans);
			pnlOrphanedLabels.Controls.Add(lstOrphanedLabels);
			pnlOrphanedLabels.Controls.Add(label4);
			pnlOrphanedLabels.Location = new System.Drawing.Point(303, 25);
			pnlOrphanedLabels.Name = "pnlOrphanedLabels";
			pnlOrphanedLabels.Size = new System.Drawing.Size(212, 212);
			pnlOrphanedLabels.TabIndex = 5;
			pnlOrphanedLabels.Visible = false;
			// 
			// btnExitOrphans
			// 
			btnExitOrphans.Location = new System.Drawing.Point(124, 176);
			btnExitOrphans.Name = "btnExitOrphans";
			btnExitOrphans.Size = new System.Drawing.Size(75, 23);
			btnExitOrphans.TabIndex = 5;
			btnExitOrphans.Text = "&Exit";
			btnExitOrphans.UseVisualStyleBackColor = true;
			btnExitOrphans.Click += this.btnExitOrphans_Click;
			// 
			// chkSelectAllOrphans
			// 
			chkSelectAllOrphans.AutoSize = true;
			chkSelectAllOrphans.Location = new System.Drawing.Point(114, 6);
			chkSelectAllOrphans.Name = "chkSelectAllOrphans";
			chkSelectAllOrphans.Size = new System.Drawing.Size(71, 19);
			chkSelectAllOrphans.TabIndex = 4;
			chkSelectAllOrphans.Text = "select all";
			chkSelectAllOrphans.UseVisualStyleBackColor = true;
			chkSelectAllOrphans.CheckedChanged += this.chkSelectAllOrphans_CheckedChanged;
			// 
			// btnRemoveSelectedOrphans
			// 
			btnRemoveSelectedOrphans.Location = new System.Drawing.Point(7, 176);
			btnRemoveSelectedOrphans.Name = "btnRemoveSelectedOrphans";
			btnRemoveSelectedOrphans.Size = new System.Drawing.Size(111, 23);
			btnRemoveSelectedOrphans.TabIndex = 3;
			btnRemoveSelectedOrphans.Text = "&Remove Selected";
			btnRemoveSelectedOrphans.UseVisualStyleBackColor = true;
			btnRemoveSelectedOrphans.Click += this.btnRemoveSelectedOrphans_Click;
			// 
			// lstOrphanedLabels
			// 
			lstOrphanedLabels.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			lstOrphanedLabels.FormattingEnabled = true;
			lstOrphanedLabels.ItemHeight = 15;
			lstOrphanedLabels.Location = new System.Drawing.Point(7, 25);
			lstOrphanedLabels.Name = "lstOrphanedLabels";
			lstOrphanedLabels.SelectionMode = SelectionMode.MultiExtended;
			lstOrphanedLabels.Size = new System.Drawing.Size(208, 139);
			lstOrphanedLabels.TabIndex = 2;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(9, 7);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(96, 15);
			label4.TabIndex = 0;
			label4.Text = "Orphaned lables:";
			// 
			// listBox1
			// 
			listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			listBox1.ContextMenuStrip = mnuContextLabels;
			listBox1.FormattingEnabled = true;
			listBox1.IntegralHeight = false;
			listBox1.ItemHeight = 15;
			listBox1.Location = new System.Drawing.Point(9, 119);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(251, 79);
			listBox1.TabIndex = 7;
			// 
			// listBox2
			// 
			listBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			listBox2.ContextMenuStrip = mnuContextLabels;
			listBox2.FormattingEnabled = true;
			listBox2.IntegralHeight = false;
			listBox2.ItemHeight = 15;
			listBox2.Location = new System.Drawing.Point(9, 219);
			listBox2.Name = "listBox2";
			listBox2.Size = new System.Drawing.Size(251, 125);
			listBox2.TabIndex = 8;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(4, 104);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(196, 15);
			label2.TabIndex = 9;
			label2.Text = "Labels in All Notebooks in <Group>";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(4, 202);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(188, 15);
			label3.TabIndex = 10;
			label3.Text = "Labels in All Groups in <Account>";
			// 
			// frmLabelsManager
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(535, 581);
			Controls.Add(pnlNewLabelName);
			Controls.Add(pnlOrphanedLabels);
			Controls.Add(lstEntryObjects);
			Controls.Add(pnlMain);
			Controls.Add(mnuMain);
			FormBorderStyle = FormBorderStyle.SizableToolWindow;
			MainMenuStrip = mnuMain;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmLabelsManager";
			Text = "Labels Manager";
			Load += this.frmLabelsManager_Load;
			Resize += this.frmLabelsManager_Resize;
			pnlMain.ResumeLayout(false);
			pnlMain.PerformLayout();
			pnlNewLabelName.ResumeLayout(false);
			pnlNewLabelName.PerformLayout();
			mnuContextLabels.ResumeLayout(false);
			mnuContextEntries.ResumeLayout(false);
			mnuMain.ResumeLayout(false);
			mnuMain.PerformLayout();
			pnlOrphanedLabels.ResumeLayout(false);
			pnlOrphanedLabels.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private Panel pnlMain;
		private MenuStrip mnuMain;
		private Label label1;
		private ListBox lstLabels;
		private ToolStripMenuItem mnuMoveUp;
		private ToolStripMenuItem mnuMoveDown;
		private Panel pnlNewLabelName;
		private Button btnCancel;
		private Button btnOK;
		private Label lblOperation;
		private TextBox txtLabelName;
		private ListBox lstOccurrences;
		private ToolStripMenuItem mnuAssignPINs;
		private Label lblEntries1;
		private Label lblLabelExists;
		private Label lblSortType;
		private ListBox lstEntryObjects;
		private ToolStripMenuItem mnuLabelsOperations;
		private ToolStripMenuItem mnuMoveTop;
		private ToolStripMenuItem mnuFindOrphans;
		private Panel pnlOrphanedLabels;
		private Button btnExitOrphans;
		private CheckBox chkSelectAllOrphans;
		private Button btnRemoveSelectedOrphans;
		private ListBox lstOrphanedLabels;
		private Label label4;
		private ToolStripMenuItem mnuAdd;
		private Label label5;

		private ContextMenuStrip mnuContextEntries;
		private ContextMenuStrip mnuContextLabels;
		private ToolStripMenuItem mnuContextDelete_lstEntries;
		private ToolStripMenuItem mnuContextRename_lstLables;
		private Label lblEntries2;
		private ToolStripMenuItem mnuContextDelete_lstLabels;
		private ToolStripMenuItem mnuContextRename_lstEntries;
		private ListBox listBox2;
		private ListBox listBox1;
		private Label label3;
		private Label label2;
	}
}