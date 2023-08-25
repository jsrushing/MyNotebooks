
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
			lblEntries2 = new Label();
			lblEntries1 = new Label();
			label3 = new Label();
			label2 = new Label();
			listBox2 = new ListBox();
			listBox1 = new ListBox();
			lstLabels = new ListBox();
			label1 = new Label();
			pnlNewLabelName = new Panel();
			txtLabelName = new TextBox();
			lblLabelExists = new Label();
			btnOK = new Button();
			btnCancel = new Button();
			lblOperation = new Label();
			label5 = new Label();
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
			panel1 = new Panel();
			pnlMain.SuspendLayout();
			pnlLabelDetails.SuspendLayout();
			mnuContextLabels.SuspendLayout();
			mnuContextEntries.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)gridViewEntryDetails).BeginInit();
			pnlNewLabelName.SuspendLayout();
			mnuMain.SuspendLayout();
			pnlOrphanedLabels.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			pnlMain.Controls.Add(pnlLabelDetails);
			pnlMain.Controls.Add(label6);
			pnlMain.Controls.Add(treeAvailableLabels);
			pnlMain.Controls.Add(lblSortType);
			pnlMain.Location = new System.Drawing.Point(16, 25);
			pnlMain.Name = "pnlMain";
			pnlMain.Size = new System.Drawing.Size(340, 554);
			pnlMain.TabIndex = 0;
			// 
			// pnlLabelDetails
			// 
			pnlLabelDetails.BackColor = System.Drawing.SystemColors.Control;
			pnlLabelDetails.Controls.Add(lstOccurrences);
			pnlLabelDetails.Controls.Add(label7);
			pnlLabelDetails.Location = new System.Drawing.Point(4, 295);
			pnlLabelDetails.Name = "pnlLabelDetails";
			pnlLabelDetails.Size = new System.Drawing.Size(333, 256);
			pnlLabelDetails.TabIndex = 13;
			pnlLabelDetails.Visible = false;
			// 
			// lstOccurrences
			// 
			lstOccurrences.FormattingEnabled = true;
			lstOccurrences.IntegralHeight = false;
			lstOccurrences.ItemHeight = 15;
			lstOccurrences.Location = new System.Drawing.Point(6, 22);
			lstOccurrences.Name = "lstOccurrences";
			lstOccurrences.Size = new System.Drawing.Size(318, 231);
			lstOccurrences.TabIndex = 3;
			lstOccurrences.MouseUp += this.lstOccurrences_MouseUp;
			// 
			// label7
			// 
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
			label6.Size = new System.Drawing.Size(164, 15);
			label6.TabIndex = 11;
			label6.Text = "Labels in Currently Selected ...";
			// 
			// treeAvailableLabels
			// 
			treeAvailableLabels.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			treeAvailableLabels.ContextMenuStrip = mnuContextLabels;
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
			treeAvailableLabels.Size = new System.Drawing.Size(318, 264);
			treeAvailableLabels.TabIndex = 6;
			treeAvailableLabels.Text = "tree";
			treeAvailableLabels.BeforeExpand += this.treeAvailableLabels_BeforeExpand;
			treeAvailableLabels.AfterExpand += this.treeAvailableLabels_AfterExpand;
			treeAvailableLabels.AfterSelect += this.treeAvailableLabels_AfterSelect;
			treeAvailableLabels.Click += this.treeAvailableLabels_Click;
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
			mnuContextEntries.Size = new System.Drawing.Size(181, 48);
			// 
			// mnuContext_GridEntryDetails
			// 
			mnuContext_GridEntryDetails.Name = "mnuContext_GridEntryDetails";
			mnuContext_GridEntryDetails.Size = new System.Drawing.Size(180, 22);
			mnuContext_GridEntryDetails.Text = "Edit Entry";
			mnuContext_GridEntryDetails.Click += this.mnuContext_GridEntryDetails_Click;
			// 
			// gridViewEntryDetails
			// 
			gridViewEntryDetails.AllowUserToAddRows = false;
			gridViewEntryDetails.AllowUserToDeleteRows = false;
			gridViewEntryDetails.AllowUserToResizeColumns = false;
			gridViewEntryDetails.AllowUserToResizeRows = false;
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
			gridViewEntryDetails.DoubleClick += this.gridViewEntryDetails_DoubleClick;
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
			// lblEntries2
			// 
			lblEntries2.AutoSize = true;
			lblEntries2.Location = new System.Drawing.Point(628, 437);
			lblEntries2.Name = "lblEntries2";
			lblEntries2.Size = new System.Drawing.Size(216, 15);
			lblEntries2.TabIndex = 6;
			lblEntries2.Text = "(dbl-click entry or right-click notebook)";
			// 
			// lblEntries1
			// 
			lblEntries1.AutoSize = true;
			lblEntries1.Location = new System.Drawing.Point(628, 422);
			lblEntries1.Name = "lblEntries1";
			lblEntries1.Size = new System.Drawing.Size(79, 15);
			lblEntries1.TabIndex = 4;
			lblEntries1.Text = "Found Entries";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(628, 266);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(188, 15);
			label3.TabIndex = 10;
			label3.Text = "Labels in All Groups in <Account>";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(628, 168);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(196, 15);
			label2.TabIndex = 9;
			label2.Text = "Labels in All Notebooks in <Group>";
			// 
			// listBox2
			// 
			listBox2.ContextMenuStrip = mnuContextLabels;
			listBox2.FormattingEnabled = true;
			listBox2.IntegralHeight = false;
			listBox2.ItemHeight = 15;
			listBox2.Location = new System.Drawing.Point(633, 283);
			listBox2.Name = "listBox2";
			listBox2.Size = new System.Drawing.Size(190, 125);
			listBox2.TabIndex = 8;
			// 
			// listBox1
			// 
			listBox1.ContextMenuStrip = mnuContextLabels;
			listBox1.FormattingEnabled = true;
			listBox1.IntegralHeight = false;
			listBox1.ItemHeight = 15;
			listBox1.Location = new System.Drawing.Point(633, 183);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(190, 79);
			listBox1.TabIndex = 7;
			// 
			// lstLabels
			// 
			lstLabels.ContextMenuStrip = mnuContextLabels;
			lstLabels.FormattingEnabled = true;
			lstLabels.IntegralHeight = false;
			lstLabels.ItemHeight = 15;
			lstLabels.Location = new System.Drawing.Point(633, 87);
			lstLabels.Name = "lstLabels";
			lstLabels.Size = new System.Drawing.Size(190, 79);
			lstLabels.TabIndex = 0;
			lstLabels.SelectedIndexChanged += this.lstLabels_SelectedIndexChanged;
			lstLabels.MouseUp += this.lstLabels_MouseUp;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(628, 71);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(109, 15);
			label1.TabIndex = 1;
			label1.Text = "Labels in Notebook";
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
			pnlNewLabelName.Location = new System.Drawing.Point(376, 297);
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
			mnuMain.Items.AddRange(new ToolStripItem[] { mnuLabelsOperations, mnuMoveTop, mnuAssignPINs });
			mnuMain.Location = new System.Drawing.Point(0, 0);
			mnuMain.Name = "mnuMain";
			mnuMain.Size = new System.Drawing.Size(1067, 24);
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
			lstEntryObjects.FormattingEnabled = true;
			lstEntryObjects.IntegralHeight = false;
			lstEntryObjects.ItemHeight = 15;
			lstEntryObjects.Location = new System.Drawing.Point(376, 254);
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
			pnlOrphanedLabels.Location = new System.Drawing.Point(376, 25);
			pnlOrphanedLabels.Name = "pnlOrphanedLabels";
			pnlOrphanedLabels.Size = new System.Drawing.Size(233, 212);
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
			lstOrphanedLabels.Size = new System.Drawing.Size(229, 139);
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
			// panel1
			// 
			panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			panel1.Location = new System.Drawing.Point(394, 422);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(186, 110);
			panel1.TabIndex = 11;
			panel1.Visible = false;
			// 
			// frmLabelsManager
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1067, 636);
			Controls.Add(gridViewEntryDetails);
			Controls.Add(lblEntries2);
			Controls.Add(panel1);
			Controls.Add(label3);
			Controls.Add(lblEntries1);
			Controls.Add(label2);
			Controls.Add(listBox1);
			Controls.Add(listBox2);
			Controls.Add(pnlNewLabelName);
			Controls.Add(lstLabels);
			Controls.Add(pnlOrphanedLabels);
			Controls.Add(lstEntryObjects);
			Controls.Add(pnlMain);
			Controls.Add(mnuMain);
			Controls.Add(label1);
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
			pnlLabelDetails.ResumeLayout(false);
			pnlLabelDetails.PerformLayout();
			mnuContextLabels.ResumeLayout(false);
			mnuContextEntries.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)gridViewEntryDetails).EndInit();
			pnlNewLabelName.ResumeLayout(false);
			pnlNewLabelName.PerformLayout();
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
		private ToolStripMenuItem mnuContextRename_lstLables;
		private Label lblEntries2;
		private ToolStripMenuItem mnuContextDelete_lstLabels;
		private ToolStripMenuItem mnuContext_GridEntryDetails;
		private ListBox listBox2;
		private ListBox listBox1;
		private Label label3;
		private Label label2;
		private TreeView treeAvailableLabels;
		private Label label6;
		private Panel panel1;
		private Label label7;
		private Panel pnlLabelDetails;
		private DataGridView gridViewEntryDetails;
		private DataGridViewTextBoxColumn colItem;
		private DataGridViewTextBoxColumn colIdentifier;
	}
}