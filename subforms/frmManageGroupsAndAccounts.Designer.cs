using System.Windows.Forms;

namespace MyNotebooks.subforms
{
	partial class frmManageGroupsAndAccounts
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
			ToolStripMenuItem mnuDelete;
			pnlSelect = new Panel();
			btnManageAccounts = new Button();
			btnManageGroups = new Button();
			panel1 = new Panel();
			mnuMain = new MenuStrip();
			mnuCreateNew = new ToolStripMenuItem();
			mnuContext = new ContextMenuStrip(components);
			mnuRename = new ToolStripMenuItem();
			mnuContext_Item = new ToolStripMenuItem();
			lstItems = new ListBox();
			pnlManage = new Panel();
			label1 = new Label();
			lblGroupsOrAccounts = new Label();
			mnuDelete = new ToolStripMenuItem();
			pnlSelect.SuspendLayout();
			mnuMain.SuspendLayout();
			mnuContext.SuspendLayout();
			pnlManage.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuDelete
			// 
			mnuDelete.Name = "mnuDelete";
			mnuDelete.Size = new System.Drawing.Size(117, 22);
			mnuDelete.Text = "&Delete";
			// 
			// pnlSelect
			// 
			pnlSelect.Controls.Add(btnManageAccounts);
			pnlSelect.Controls.Add(btnManageGroups);
			pnlSelect.Location = new System.Drawing.Point(12, 23);
			pnlSelect.Name = "pnlSelect";
			pnlSelect.Size = new System.Drawing.Size(237, 67);
			pnlSelect.TabIndex = 5;
			// 
			// btnManageAccounts
			// 
			btnManageAccounts.Location = new System.Drawing.Point(57, 40);
			btnManageAccounts.Name = "btnManageAccounts";
			btnManageAccounts.Size = new System.Drawing.Size(123, 23);
			btnManageAccounts.TabIndex = 1;
			btnManageAccounts.Text = "Manage &Acccounts";
			btnManageAccounts.UseVisualStyleBackColor = true;
			btnManageAccounts.Click += this.BtnClick;
			// 
			// btnManageGroups
			// 
			btnManageGroups.Location = new System.Drawing.Point(64, 3);
			btnManageGroups.Name = "btnManageGroups";
			btnManageGroups.Size = new System.Drawing.Size(108, 23);
			btnManageGroups.TabIndex = 0;
			btnManageGroups.Text = "Manage &Groups";
			btnManageGroups.UseVisualStyleBackColor = true;
			btnManageGroups.Click += this.BtnClick;
			// 
			// panel1
			// 
			panel1.Location = new System.Drawing.Point(490, 363);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(253, 32);
			panel1.TabIndex = 6;
			panel1.Visible = false;
			// 
			// mnuMain
			// 
			mnuMain.Items.AddRange(new ToolStripItem[] { mnuCreateNew });
			mnuMain.Location = new System.Drawing.Point(0, 0);
			mnuMain.Name = "mnuMain";
			mnuMain.Size = new System.Drawing.Size(265, 24);
			mnuMain.TabIndex = 1;
			mnuMain.Text = "menuStrip1";
			// 
			// mnuCreateNew
			// 
			mnuCreateNew.Name = "mnuCreateNew";
			mnuCreateNew.Size = new System.Drawing.Size(80, 20);
			mnuCreateNew.Text = "Create &New";
			mnuCreateNew.Click += this.mnuCreateNew_Click;
			// 
			// mnuContext
			// 
			mnuContext.Items.AddRange(new ToolStripItem[] { mnuRename, mnuDelete });
			mnuContext.Name = "mnuContext";
			mnuContext.Size = new System.Drawing.Size(118, 48);
			// 
			// mnuRename
			// 
			mnuRename.Name = "mnuRename";
			mnuRename.Size = new System.Drawing.Size(117, 22);
			mnuRename.Text = "&Rename";
			// 
			// mnuContext_Item
			// 
			mnuContext_Item.Name = "mnuContext_Item";
			mnuContext_Item.Size = new System.Drawing.Size(184, 22);
			mnuContext_Item.Text = "Item 1";
			// 
			// lstItems
			// 
			lstItems.ContextMenuStrip = mnuContext;
			lstItems.FormattingEnabled = true;
			lstItems.ItemHeight = 15;
			lstItems.Location = new System.Drawing.Point(7, 24);
			lstItems.Name = "lstItems";
			lstItems.Size = new System.Drawing.Size(230, 409);
			lstItems.TabIndex = 7;
			lstItems.MouseUp += this.lstItems_MouseUp;
			// 
			// pnlManage
			// 
			pnlManage.Controls.Add(label1);
			pnlManage.Controls.Add(lblGroupsOrAccounts);
			pnlManage.Controls.Add(lstItems);
			pnlManage.Location = new System.Drawing.Point(12, 109);
			pnlManage.Name = "pnlManage";
			pnlManage.Size = new System.Drawing.Size(240, 450);
			pnlManage.TabIndex = 8;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			label1.Location = new System.Drawing.Point(66, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(171, 15);
			label1.TabIndex = 9;
			label1.Text = "dbl-click to login, or right-click";
			// 
			// lblGroupsOrAccounts
			// 
			lblGroupsOrAccounts.AutoSize = true;
			lblGroupsOrAccounts.Location = new System.Drawing.Point(7, 6);
			lblGroupsOrAccounts.Name = "lblGroupsOrAccounts";
			lblGroupsOrAccounts.Size = new System.Drawing.Size(57, 15);
			lblGroupsOrAccounts.TabIndex = 8;
			lblGroupsOrAccounts.Text = "Accounts";
			// 
			// frmManageGroupsAndAccounts
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(265, 667);
			Controls.Add(pnlManage);
			Controls.Add(panel1);
			Controls.Add(pnlSelect);
			Controls.Add(mnuMain);
			MainMenuStrip = mnuMain;
			MaximizeBox = false;
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(281, 400);
			Name = "frmManageGroupsAndAccounts";
			Text = "Manage Groups And Accounts";
			Load += this.frmManageGroupsAndAccounts_Load;
			pnlSelect.ResumeLayout(false);
			mnuMain.ResumeLayout(false);
			mnuMain.PerformLayout();
			mnuContext.ResumeLayout(false);
			pnlManage.ResumeLayout(false);
			pnlManage.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private Panel pnlSelect;
		private Panel panel1;
		private Button btnManageAccounts;
		private Button btnManageGroups;
		private MenuStrip mnuMain;
		private ToolStripMenuItem mnuCreateNew;
		private ContextMenuStrip mnuContext;
		private ToolStripMenuItem mnuContext_Item;
		private ListBox lstItems;
		private Panel pnlManage;
		private ToolStripMenuItem mnuRename;
		private Label lblGroupsOrAccounts;
		private Label label1;
	}
}