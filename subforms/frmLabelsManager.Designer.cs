
using System.Windows.Forms;

namespace MyNotebooks.subforms
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
			TreeNode treeNode1 = new TreeNode("");
			TreeNode treeNode2 = new TreeNode("Notebook", new TreeNode[] { treeNode1 });
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLabelsManager));
			pnlMain = new Panel();
			pnlLabelDetails = new Panel();
			lstOccurrences = new ListBox();
			label7 = new Label();
			treeAvailableLabels = new TreeView();
			mnuContextLabels = new ContextMenuStrip(components);
			mnuContextRename_lstLables = new ToolStripMenuItem();
			mnuContextDelete_lstLabels = new ToolStripMenuItem();
			lblSortType = new Label();
			mnuContextEntries = new ContextMenuStrip(components);
			mnuContext_GridEntryDetails = new ToolStripMenuItem();
			gridViewEntryDetails = new DataGridView();
			colItem = new DataGridViewTextBoxColumn();
			colIdentifier = new DataGridViewTextBoxColumn();
			mnuMain = new MenuStrip();
			mnuLabelsOperations = new ToolStripMenuItem();
			mnuAddToCurrentEntry = new ToolStripMenuItem();
			mnuRename = new ToolStripMenuItem();
			mnuDelete = new ToolStripMenuItem();
			mnuMoveTop = new ToolStripMenuItem();
			toolStripMenuItem1 = new ToolStripMenuItem();
			toolStripMenuItem2 = new ToolStripMenuItem();
			toolStripMenuItem3 = new ToolStripMenuItem();
			bgWorker = new System.ComponentModel.BackgroundWorker();
			pnlRenameDeleteManager = new Panel();
			btnCancelRenameDelete = new Button();
			btnContinue = new Button();
			lblSelectAll = new Label();
			treeEntriesToEdit = new TreeView();
			pnlLabelChangeReview = new Panel();
			btnCancelLabelChanges = new Button();
			btnAuthorizeLabelChanges = new Button();
			label2 = new Label();
			lstLabelChangeReview = new ListBox();
			button2 = new Button();
			label1 = new Label();
			pnlMain.SuspendLayout();
			pnlLabelDetails.SuspendLayout();
			mnuContextLabels.SuspendLayout();
			mnuContextEntries.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)gridViewEntryDetails).BeginInit();
			mnuMain.SuspendLayout();
			pnlRenameDeleteManager.SuspendLayout();
			pnlLabelChangeReview.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			pnlMain.Controls.Add(pnlLabelDetails);
			pnlMain.Controls.Add(treeAvailableLabels);
			pnlMain.Location = new System.Drawing.Point(7, 25);
			pnlMain.Name = "pnlMain";
			pnlMain.Size = new System.Drawing.Size(288, 554);
			pnlMain.TabIndex = 0;
			// 
			// pnlLabelDetails
			// 
			pnlLabelDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			pnlLabelDetails.BackColor = System.Drawing.SystemColors.Control;
			pnlLabelDetails.Controls.Add(lstOccurrences);
			pnlLabelDetails.Controls.Add(label7);
			pnlLabelDetails.Location = new System.Drawing.Point(4, 295);
			pnlLabelDetails.Name = "pnlLabelDetails";
			pnlLabelDetails.Size = new System.Drawing.Size(278, 250);
			pnlLabelDetails.TabIndex = 13;
			pnlLabelDetails.Visible = false;
			// 
			// lstOccurrences
			// 
			lstOccurrences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstOccurrences.FormattingEnabled = true;
			lstOccurrences.IntegralHeight = false;
			lstOccurrences.ItemHeight = 15;
			lstOccurrences.Location = new System.Drawing.Point(6, 22);
			lstOccurrences.Name = "lstOccurrences";
			lstOccurrences.Size = new System.Drawing.Size(266, 225);
			lstOccurrences.TabIndex = 3;
			lstOccurrences.MouseUp += this.lstOccurrences_MouseUp;
			// 
			// label7
			// 
			label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(1, 3);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(182, 15);
			label7.TabIndex = 12;
			label7.Text = "Label Details, Entries, and Parents";
			// 
			// treeAvailableLabels
			// 
			treeAvailableLabels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			treeAvailableLabels.CheckBoxes = true;
			treeAvailableLabels.ContextMenuStrip = mnuContextLabels;
			treeAvailableLabels.HideSelection = false;
			treeAvailableLabels.HotTracking = true;
			treeAvailableLabels.Location = new System.Drawing.Point(7, 6);
			treeAvailableLabels.Name = "treeAvailableLabels";
			treeNode1.Name = "Node0";
			treeNode1.Text = "";
			treeNode2.Name = "nodeNotebook";
			treeNode2.Text = "Notebook";
			treeAvailableLabels.Nodes.AddRange(new TreeNode[] { treeNode2 });
			treeAvailableLabels.Size = new System.Drawing.Size(266, 283);
			treeAvailableLabels.TabIndex = 6;
			treeAvailableLabels.Text = "tree";
			treeAvailableLabels.AfterCheck += this.treeLabels_AfterCheck;
			treeAvailableLabels.AfterExpand += this.treeAvailableLabels_AfterExpand;
			treeAvailableLabels.AfterSelect += this.treeAvailableLabels_AfterSelect;
			treeAvailableLabels.MouseDown += this.treeAvailableLabels_MouseDown;
			treeAvailableLabels.MouseMove += this.treeAvailableLabels_MouseMove;
			// 
			// mnuContextLabels
			// 
			mnuContextLabels.Items.AddRange(new ToolStripItem[] { mnuContextRename_lstLables, mnuContextDelete_lstLabels });
			mnuContextLabels.Name = "mnuContextLabels";
			mnuContextLabels.Size = new System.Drawing.Size(153, 48);
			// 
			// mnuContextRename_lstLables
			// 
			mnuContextRename_lstLables.Name = "mnuContextRename_lstLables";
			mnuContextRename_lstLables.Size = new System.Drawing.Size(152, 22);
			mnuContextRename_lstLables.Text = "&Rename";
			mnuContextRename_lstLables.Click += this.DeleteOrRename;
			// 
			// mnuContextDelete_lstLabels
			// 
			mnuContextDelete_lstLabels.Name = "mnuContextDelete_lstLabels";
			mnuContextDelete_lstLabels.Size = new System.Drawing.Size(152, 22);
			mnuContextDelete_lstLabels.Text = "&Delete_original";
			mnuContextDelete_lstLabels.Click += this.DeleteOrRename;
			// 
			// lblSortType
			// 
			lblSortType.AutoSize = true;
			lblSortType.Cursor = Cursors.Hand;
			lblSortType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
			lblSortType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblSortType.Location = new System.Drawing.Point(992, 127);
			lblSortType.Name = "lblSortType";
			lblSortType.Size = new System.Drawing.Size(59, 17);
			lblSortType.TabIndex = 5;
			lblSortType.Text = "Sort A-Z";
			lblSortType.Visible = false;
			lblSortType.Click += this.lblSortType_Click;
			// 
			// mnuContextEntries
			// 
			mnuContextEntries.Items.AddRange(new ToolStripItem[] { mnuContext_GridEntryDetails });
			mnuContextEntries.Name = "mnuFoundEntries";
			mnuContextEntries.Size = new System.Drawing.Size(125, 26);
			// 
			// mnuContext_GridEntryDetails
			// 
			mnuContext_GridEntryDetails.Name = "mnuContext_GridEntryDetails";
			mnuContext_GridEntryDetails.Size = new System.Drawing.Size(124, 22);
			mnuContext_GridEntryDetails.Text = "Edit Entry";
			mnuContext_GridEntryDetails.Click += this.mnuContext_GridEntryDetails_Click;
			// 
			// gridViewEntryDetails
			// 
			gridViewEntryDetails.AllowUserToAddRows = false;
			gridViewEntryDetails.AllowUserToDeleteRows = false;
			gridViewEntryDetails.AllowUserToResizeColumns = false;
			gridViewEntryDetails.AllowUserToResizeRows = false;
			gridViewEntryDetails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			gridViewEntryDetails.ColumnHeadersVisible = false;
			gridViewEntryDetails.Columns.AddRange(new DataGridViewColumn[] { colItem, colIdentifier });
			gridViewEntryDetails.ContextMenuStrip = mnuContextEntries;
			gridViewEntryDetails.EditMode = DataGridViewEditMode.EditProgrammatically;
			gridViewEntryDetails.Location = new System.Drawing.Point(966, 450);
			gridViewEntryDetails.MultiSelect = false;
			gridViewEntryDetails.Name = "gridViewEntryDetails";
			gridViewEntryDetails.ReadOnly = true;
			gridViewEntryDetails.RowHeadersVisible = false;
			gridViewEntryDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			gridViewEntryDetails.Size = new System.Drawing.Size(269, 150);
			gridViewEntryDetails.TabIndex = 0;
			gridViewEntryDetails.Visible = false;
			gridViewEntryDetails.MouseDown += this.gridViewEntryDetails_MouseDown;
			// 
			// colItem
			// 
			colItem.HeaderText = "Item Type";
			colItem.Name = "colItem";
			colItem.ReadOnly = true;
			// 
			// colIdentifier
			// 
			colIdentifier.HeaderText = "Item Name";
			colIdentifier.Name = "colIdentifier";
			colIdentifier.ReadOnly = true;
			// 
			// mnuMain
			// 
			mnuMain.Items.AddRange(new ToolStripItem[] { mnuLabelsOperations, mnuMoveTop, toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3 });
			mnuMain.Location = new System.Drawing.Point(0, 0);
			mnuMain.Name = "mnuMain";
			mnuMain.Size = new System.Drawing.Size(993, 24);
			mnuMain.TabIndex = 1;
			mnuMain.Text = "menuStrip1";
			// 
			// mnuLabelsOperations
			// 
			mnuLabelsOperations.DropDownItems.AddRange(new ToolStripItem[] { mnuAddToCurrentEntry, mnuRename, mnuDelete });
			mnuLabelsOperations.Enabled = false;
			mnuLabelsOperations.Name = "mnuLabelsOperations";
			mnuLabelsOperations.Size = new System.Drawing.Size(109, 20);
			mnuLabelsOperations.Text = "&Checked Label(s)";
			// 
			// mnuAddToCurrentEntry
			// 
			mnuAddToCurrentEntry.Name = "mnuAddToCurrentEntry";
			mnuAddToCurrentEntry.Size = new System.Drawing.Size(183, 22);
			mnuAddToCurrentEntry.Text = "&Add to Current Entry";
			mnuAddToCurrentEntry.Click += this.mnuAddToCurrentEntry_Click;
			// 
			// mnuRename
			// 
			mnuRename.Name = "mnuRename";
			mnuRename.Size = new System.Drawing.Size(183, 22);
			mnuRename.Text = "&Rename";
			mnuRename.Click += this.DeleteOrRename;
			// 
			// mnuDelete
			// 
			mnuDelete.Name = "mnuDelete";
			mnuDelete.Size = new System.Drawing.Size(183, 22);
			mnuDelete.Text = "&Delete";
			mnuDelete.Click += this.DeleteOrRename;
			// 
			// mnuMoveTop
			// 
			mnuMoveTop.Name = "mnuMoveTop";
			mnuMoveTop.Size = new System.Drawing.Size(111, 20);
			mnuMoveTop.Text = "Create &New Label";
			mnuMoveTop.Click += this.mnuCreateNewLabel_Click;
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
			// 
			// toolStripMenuItem2
			// 
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new System.Drawing.Size(12, 20);
			// 
			// toolStripMenuItem3
			// 
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new System.Drawing.Size(12, 20);
			// 
			// bgWorker
			// 
			bgWorker.WorkerReportsProgress = true;
			// 
			// pnlRenameDeleteManager
			// 
			pnlRenameDeleteManager.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			pnlRenameDeleteManager.Controls.Add(btnCancelRenameDelete);
			pnlRenameDeleteManager.Controls.Add(btnContinue);
			pnlRenameDeleteManager.Controls.Add(lblSelectAll);
			pnlRenameDeleteManager.Controls.Add(treeEntriesToEdit);
			pnlRenameDeleteManager.Location = new System.Drawing.Point(321, 5);
			pnlRenameDeleteManager.Name = "pnlRenameDeleteManager";
			pnlRenameDeleteManager.Size = new System.Drawing.Size(292, 568);
			pnlRenameDeleteManager.TabIndex = 2;
			pnlRenameDeleteManager.Visible = false;
			// 
			// btnCancelRenameDelete
			// 
			btnCancelRenameDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnCancelRenameDelete.Location = new System.Drawing.Point(184, 533);
			btnCancelRenameDelete.Name = "btnCancelRenameDelete";
			btnCancelRenameDelete.Size = new System.Drawing.Size(75, 23);
			btnCancelRenameDelete.TabIndex = 9;
			btnCancelRenameDelete.Text = "&Cancel";
			btnCancelRenameDelete.UseVisualStyleBackColor = true;
			btnCancelRenameDelete.Click += this.btnCancelRenameDelete_Click;
			// 
			// btnContinue
			// 
			btnContinue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnContinue.Location = new System.Drawing.Point(14, 533);
			btnContinue.Name = "btnContinue";
			btnContinue.Size = new System.Drawing.Size(132, 23);
			btnContinue.TabIndex = 8;
			btnContinue.Text = "Continue";
			btnContinue.UseVisualStyleBackColor = true;
			btnContinue.Click += this.btnContinue_Click;
			// 
			// lblSelectAll
			// 
			lblSelectAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			lblSelectAll.AutoSize = true;
			lblSelectAll.Cursor = Cursors.Hand;
			lblSelectAll.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
			lblSelectAll.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblSelectAll.Location = new System.Drawing.Point(211, 6);
			lblSelectAll.Name = "lblSelectAll";
			lblSelectAll.Size = new System.Drawing.Size(51, 13);
			lblSelectAll.TabIndex = 6;
			lblSelectAll.Text = "select all";
			lblSelectAll.Click += this.lblSelectAll_Click;
			// 
			// treeEntriesToEdit
			// 
			treeEntriesToEdit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			treeEntriesToEdit.CheckBoxes = true;
			treeEntriesToEdit.HideSelection = false;
			treeEntriesToEdit.Location = new System.Drawing.Point(7, 24);
			treeEntriesToEdit.Name = "treeEntriesToEdit";
			treeEntriesToEdit.Size = new System.Drawing.Size(270, 503);
			treeEntriesToEdit.TabIndex = 1;
			treeEntriesToEdit.AfterCheck += this.treeLabels_AfterCheck;
			// 
			// pnlLabelChangeReview
			// 
			pnlLabelChangeReview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			pnlLabelChangeReview.Controls.Add(btnCancelLabelChanges);
			pnlLabelChangeReview.Controls.Add(btnAuthorizeLabelChanges);
			pnlLabelChangeReview.Controls.Add(label2);
			pnlLabelChangeReview.Controls.Add(lstLabelChangeReview);
			pnlLabelChangeReview.Controls.Add(button2);
			pnlLabelChangeReview.Controls.Add(label1);
			pnlLabelChangeReview.Location = new System.Drawing.Point(631, 5);
			pnlLabelChangeReview.Name = "pnlLabelChangeReview";
			pnlLabelChangeReview.Size = new System.Drawing.Size(292, 568);
			pnlLabelChangeReview.TabIndex = 10;
			pnlLabelChangeReview.Visible = false;
			// 
			// btnCancelLabelChanges
			// 
			btnCancelLabelChanges.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnCancelLabelChanges.Location = new System.Drawing.Point(184, 533);
			btnCancelLabelChanges.Name = "btnCancelLabelChanges";
			btnCancelLabelChanges.Size = new System.Drawing.Size(75, 23);
			btnCancelLabelChanges.TabIndex = 12;
			btnCancelLabelChanges.Text = "&Cancel";
			btnCancelLabelChanges.UseVisualStyleBackColor = true;
			btnCancelLabelChanges.Click += this.btnCancelLabelChanges_Click;
			// 
			// btnAuthorizeLabelChanges
			// 
			btnAuthorizeLabelChanges.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnAuthorizeLabelChanges.Location = new System.Drawing.Point(14, 533);
			btnAuthorizeLabelChanges.Name = "btnAuthorizeLabelChanges";
			btnAuthorizeLabelChanges.Size = new System.Drawing.Size(132, 23);
			btnAuthorizeLabelChanges.TabIndex = 11;
			btnAuthorizeLabelChanges.Text = "&Authorize Changes";
			btnAuthorizeLabelChanges.UseVisualStyleBackColor = true;
			btnAuthorizeLabelChanges.Click += this.btnAuthorizeLabelChanges_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(7, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(194, 15);
			label2.TabIndex = 10;
			label2.Text = "Please review the following actions.";
			// 
			// lstLabelChangeReview
			// 
			lstLabelChangeReview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstLabelChangeReview.FormattingEnabled = true;
			lstLabelChangeReview.IntegralHeight = false;
			lstLabelChangeReview.ItemHeight = 15;
			lstLabelChangeReview.Location = new System.Drawing.Point(7, 24);
			lstLabelChangeReview.Name = "lstLabelChangeReview";
			lstLabelChangeReview.Size = new System.Drawing.Size(270, 503);
			lstLabelChangeReview.TabIndex = 9;
			// 
			// button2
			// 
			button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button2.Location = new System.Drawing.Point(14, 1003);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(132, 23);
			button2.TabIndex = 8;
			button2.Text = "{0} in Selections";
			button2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Cursor = Cursors.Hand;
			label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
			label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			label1.Location = new System.Drawing.Point(303, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(51, 13);
			label1.TabIndex = 6;
			label1.Text = "select all";
			// 
			// frmLabelsManager
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(993, 585);
			Controls.Add(pnlLabelChangeReview);
			Controls.Add(lblSortType);
			Controls.Add(pnlRenameDeleteManager);
			Controls.Add(gridViewEntryDetails);
			Controls.Add(pnlMain);
			Controls.Add(mnuMain);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = mnuMain;
			MaximizeBox = false;
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(338, 624);
			Name = "frmLabelsManager";
			Text = "Labels Manager";
			Load += this.frmLabelsManager_Load;
			Resize += this.frmLabelsManager_Resize;
			pnlMain.ResumeLayout(false);
			pnlLabelDetails.ResumeLayout(false);
			pnlLabelDetails.PerformLayout();
			mnuContextLabels.ResumeLayout(false);
			mnuContextEntries.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)gridViewEntryDetails).EndInit();
			mnuMain.ResumeLayout(false);
			mnuMain.PerformLayout();
			pnlRenameDeleteManager.ResumeLayout(false);
			pnlRenameDeleteManager.PerformLayout();
			pnlLabelChangeReview.ResumeLayout(false);
			pnlLabelChangeReview.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private Panel pnlMain;
		private MenuStrip mnuMain;
		private ToolStripMenuItem mnuMoveUp;
		private ToolStripMenuItem mnuMoveDown;
		private ListBox lstOccurrences;
		private ToolStripMenuItem mnuAssignPINs;
		private Label lblSortType;
		private ToolStripMenuItem mnuLabelsOperations;
		private ToolStripMenuItem mnuMoveTop;
		private ToolStripMenuItem mnuAddCheckedLabelsToEntry;

		private ContextMenuStrip mnuContextEntries;
		private ContextMenuStrip mnuContextLabels;
		private ToolStripMenuItem mnuContextRename_lstLables;
		private ToolStripMenuItem mnuContextDelete_lstLabels;
		private ToolStripMenuItem mnuContext_GridEntryDetails;
		private TreeView treeAvailableLabels;
		private Label label7;
		private Panel pnlLabelDetails;
		private DataGridView gridViewEntryDetails;
		private DataGridViewTextBoxColumn colItem;
		private DataGridViewTextBoxColumn colIdentifier;
		private ToolStripMenuItem mnuCreateNewLabel;
		private ToolStripMenuItem toolStripMenuItem1;
		private ToolStripMenuItem toolStripMenuItem2;
		private ToolStripMenuItem toolStripMenuItem3;
		private System.ComponentModel.BackgroundWorker bgWorker;
		private ToolStripMenuItem addToCurrentEntryToolStripMenuItem;
		private ToolStripMenuItem renameToolStripMenuItem;
		private ToolStripMenuItem deleteToolStripMenuItem;
		private ToolStripMenuItem mnuAddToCurrentEntry;
		private ToolStripMenuItem mnuRename;
		private ToolStripMenuItem mnuDelete;
		private Panel pnlRenameDeleteManager;
		private Label lblSelectAll;
		private TreeView treeEntriesToEdit;
		private Button btnCancelRenameDelete;
		private Button btnContinue;
		private Panel pnlLabelChangeReview;
		private ListBox lstLabelChangeReview;
		private Button button2;
		private Label label1;
		private Label label2;
		private Button btnCancelLabelChanges;
		private Button btnAuthorizeLabelChanges;
	}
}