
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
			TreeNode treeNode3 = new TreeNode("");
			TreeNode treeNode4 = new TreeNode("Group", new TreeNode[] { treeNode3 });
			TreeNode treeNode5 = new TreeNode("");
			TreeNode treeNode6 = new TreeNode("Department", new TreeNode[] { treeNode5 });
			TreeNode treeNode7 = new TreeNode("");
			TreeNode treeNode8 = new TreeNode("Account", new TreeNode[] { treeNode7 });
			TreeNode treeNode9 = new TreeNode("");
			TreeNode treeNode10 = new TreeNode("Company", new TreeNode[] { treeNode9 });
			pnlMain = new Panel();
			pnlLabelDetails = new Panel();
			lstOccurrences = new ListBox();
			label7 = new Label();
			label6 = new Label();
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
			pnlNewLabelName = new Panel();
			txtLabelName = new TextBox();
			lblLabelExists = new Label();
			btnOK = new Button();
			btnCancel = new Button();
			lblOperation = new Label();
			label5 = new Label();
			mnuMain = new MenuStrip();
			mnuLabelsOperations = new ToolStripMenuItem();
			mnuMoveTop = new ToolStripMenuItem();
			toolStripMenuItem1 = new ToolStripMenuItem();
			toolStripMenuItem2 = new ToolStripMenuItem();
			toolStripMenuItem3 = new ToolStripMenuItem();
			lstEntryObjects = new ListBox();
			panel1 = new Panel();
			bgWorker = new System.ComponentModel.BackgroundWorker();
			pnlMain.SuspendLayout();
			pnlLabelDetails.SuspendLayout();
			mnuContextLabels.SuspendLayout();
			mnuContextEntries.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)gridViewEntryDetails).BeginInit();
			pnlNewLabelName.SuspendLayout();
			mnuMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			pnlMain.Controls.Add(pnlLabelDetails);
			pnlMain.Controls.Add(label6);
			pnlMain.Controls.Add(treeAvailableLabels);
			pnlMain.Controls.Add(lblSortType);
			pnlMain.Location = new System.Drawing.Point(7, 25);
			pnlMain.Name = "pnlMain";
			pnlMain.Size = new System.Drawing.Size(349, 554);
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
			pnlLabelDetails.Size = new System.Drawing.Size(339, 250);
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
			lstOccurrences.Size = new System.Drawing.Size(327, 225);
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
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(4, 4);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(127, 15);
			label6.TabIndex = 11;
			label6.Text = "Labels under current ...";
			// 
			// treeAvailableLabels
			// 
			treeAvailableLabels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			treeAvailableLabels.CheckBoxes = true;
			treeAvailableLabels.ContextMenuStrip = mnuContextLabels;
			treeAvailableLabels.HideSelection = false;
			treeAvailableLabels.HotTracking = true;
			treeAvailableLabels.Location = new System.Drawing.Point(11, 25);
			treeAvailableLabels.Name = "treeAvailableLabels";
			treeNode1.Name = "Node0";
			treeNode1.Text = "";
			treeNode2.Name = "nodeNotebook";
			treeNode2.Text = "Notebook";
			treeNode3.Name = "Node1";
			treeNode3.Text = "";
			treeNode4.Name = "nodeGroup";
			treeNode4.Text = "Group";
			treeNode5.Name = "Node2";
			treeNode5.Text = "";
			treeNode6.Name = "nodeDepartment";
			treeNode6.Text = "Department";
			treeNode7.Name = "Node3";
			treeNode7.Text = "";
			treeNode8.Name = "nodeAccount";
			treeNode8.Text = "Account";
			treeNode9.Name = "Node4";
			treeNode9.Text = "";
			treeNode10.Name = "nodeCompany";
			treeNode10.Text = "Company";
			treeAvailableLabels.Nodes.AddRange(new TreeNode[] { treeNode2, treeNode4, treeNode6, treeNode8, treeNode10 });
			treeAvailableLabels.Size = new System.Drawing.Size(327, 264);
			treeAvailableLabels.TabIndex = 6;
			treeAvailableLabels.Text = "tree";
			treeAvailableLabels.AfterCheck += this.treeAvailableLabels_AfterCheck;
			treeAvailableLabels.AfterExpand += this.treeAvailableLabels_AfterExpand;
			treeAvailableLabels.AfterSelect += this.treeAvailableLabels_AfterSelect;
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
			lblSortType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			lblSortType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			lblSortType.Location = new System.Drawing.Point(187, 4);
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
			gridViewEntryDetails.Location = new System.Drawing.Point(84, 257);
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
			// pnlNewLabelName
			// 
			pnlNewLabelName.BackColor = System.Drawing.SystemColors.ActiveCaption;
			pnlNewLabelName.Controls.Add(txtLabelName);
			pnlNewLabelName.Controls.Add(lblLabelExists);
			pnlNewLabelName.Controls.Add(btnOK);
			pnlNewLabelName.Controls.Add(btnCancel);
			pnlNewLabelName.Controls.Add(lblOperation);
			pnlNewLabelName.Controls.Add(label5);
			pnlNewLabelName.Location = new System.Drawing.Point(361, 33);
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
			// mnuMain
			// 
			mnuMain.Items.AddRange(new ToolStripItem[] { mnuLabelsOperations, mnuMoveTop, toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3 });
			mnuMain.Location = new System.Drawing.Point(0, 0);
			mnuMain.Name = "mnuMain";
			mnuMain.Size = new System.Drawing.Size(359, 24);
			mnuMain.TabIndex = 1;
			mnuMain.Text = "menuStrip1";
			// 
			// mnuLabelsOperations
			// 
			mnuLabelsOperations.Enabled = false;
			mnuLabelsOperations.Name = "mnuLabelsOperations";
			mnuLabelsOperations.Size = new System.Drawing.Size(170, 20);
			mnuLabelsOperations.Text = "&Add Checked Labels to Entry";
			mnuLabelsOperations.Click += this.mnuAddCheckedLabelsToEntry_Click;
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
			// lstEntryObjects
			// 
			lstEntryObjects.FormattingEnabled = true;
			lstEntryObjects.IntegralHeight = false;
			lstEntryObjects.ItemHeight = 15;
			lstEntryObjects.Location = new System.Drawing.Point(414, 289);
			lstEntryObjects.Name = "lstEntryObjects";
			lstEntryObjects.Size = new System.Drawing.Size(127, 25);
			lstEntryObjects.TabIndex = 4;
			lstEntryObjects.Visible = false;
			// 
			// panel1
			// 
			panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			panel1.Location = new System.Drawing.Point(379, 158);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(186, 110);
			panel1.TabIndex = 11;
			panel1.Visible = false;
			// 
			// bgWorker
			// 
			bgWorker.WorkerReportsProgress = true;
			// 
			// frmLabelsManager
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(359, 585);
			Controls.Add(gridViewEntryDetails);
			Controls.Add(panel1);
			Controls.Add(pnlNewLabelName);
			Controls.Add(lstEntryObjects);
			Controls.Add(pnlMain);
			Controls.Add(mnuMain);
			FormBorderStyle = FormBorderStyle.SizableToolWindow;
			MainMenuStrip = mnuMain;
			MaximizeBox = false;
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(338, 624);
			Name = "frmLabelsManager";
			Text = "Labels Manager";
			Load += this.frmLabelsManager_Load;
			Resize += this.frmLabelsManager_Resize;
			pnlMain.ResumeLayout(false);
			pnlMain.PerformLayout();
			pnlLabelDetails.ResumeLayout(false);
			pnlLabelDetails.PerformLayout();
			mnuContextLabels.ResumeLayout(false);
			mnuContextEntries.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)gridViewEntryDetails).EndInit();
			pnlNewLabelName.ResumeLayout(false);
			pnlNewLabelName.PerformLayout();
			mnuMain.ResumeLayout(false);
			mnuMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private Panel pnlMain;
		private MenuStrip mnuMain;
		private ToolStripMenuItem mnuMoveUp;
		private ToolStripMenuItem mnuMoveDown;
		private Panel pnlNewLabelName;
		private Button btnCancel;
		private Button btnOK;
		private Label lblOperation;
		private TextBox txtLabelName;
		private ListBox lstOccurrences;
		private ToolStripMenuItem mnuAssignPINs;
		private Label lblLabelExists;
		private Label lblSortType;
		private ListBox lstEntryObjects;
		private ToolStripMenuItem mnuLabelsOperations;
		private ToolStripMenuItem mnuMoveTop;
		private ToolStripMenuItem mnuAddCheckedLabelsToEntry;
		private Label label5;

		private ContextMenuStrip mnuContextEntries;
		private ContextMenuStrip mnuContextLabels;
		private ToolStripMenuItem mnuContextRename_lstLables;
		private ToolStripMenuItem mnuContextDelete_lstLabels;
		private ToolStripMenuItem mnuContext_GridEntryDetails;
		private TreeView treeAvailableLabels;
		private Label label6;
		private Panel panel1;
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
	}
}