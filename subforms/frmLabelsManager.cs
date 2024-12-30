/* Manage labelsForSearch.
 * 7/9/22
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyNotebooks.DataAccess;
using MyNotebooks.objects;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyNotebooks.subforms
{
	public partial class frmLabelsManager : Form
	{
		private LabelsManager.LabelsSortType sort = LabelsManager.LabelsSortType.None;
		private List<int> OccurenceTitleIndicies = new List<int>();
		private bool DeletingOrphans;
		private string strSeperator = "-----------------------";
		public Entry CurrentEntry { get; set; }
		public Notebook CurrentNotebook { get; set; }
		private List<Entry> EntriesToEdit;
		private bool FirstDetailsLoad = true;
		private bool ProgramaticallyChecking = false;
		private int LastClickedEntryIndex = -1;
		private const string ViewEntryMenuText = "View Entry";
		private const string LoadNotebookMenuText = "Load Notebook";
		private int CheckedNodeCount;
		private List<Notebook> SelectedNotebooks { get; set; }
		public bool ActionTaken { get; private set; }

		private void btnAuthorizeLabelChanges_Click(object sender, EventArgs e)
		{

		}

		private void btnCancelLabelChanges_Click(object sender, EventArgs e) { ShowPanel(pnlRenameDeleteManager); }

		private void btnCancelRenameDelete_Click(object sender, EventArgs e)
		{
			lblSelectAll.Text = "select all";
			ShowPanel(pnlMain);
		}

		private void btnContinue_Click(object sender, EventArgs e)
		{
			if (btnContinue.Text.ToLower().Contains("delete"))
			{ DeleteLabels(); }
			else { RenameLabels(); }
		}

		public frmLabelsManager(Form parent, Notebook nb, Entry currentEntry = null)
		{
			InitializeComponent();
			SelectedNotebooks = new List<Notebook>();
			Utilities.SetStartPosition(this, parent);
			CurrentEntry = currentEntry;
			CurrentNotebook = nb;
		}

		private async void frmLabelsManager_Load(object sender, EventArgs e)
		{
			pnlRenameDeleteManager.Left = pnlMain.Left;
			pnlLabelChangeReview.Left = pnlMain.Left;
			//ShowHideOccurrences();
			this.Size = new Size(pnlMain.Width + 25, pnlMain.Height + 40);
			ShowPanel(pnlMain);
			pnlMain.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top;
			pnlRenameDeleteManager.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top;
			//sort = LabelsManager.LabelsSortType.None;
			ResetTree();
			mnuAddToCurrentEntry.Enabled = CurrentEntry != null;
		}

		private void frmLabelsManager_Resize(object sender, EventArgs e) { ShowHideOccurrences(); }

		private void btnExitOrphans_Click(object sender, EventArgs e)
		{ lstOccurrences.Items.Clear(); ShowHideOccurrences(); ShowPanel(pnlMain); }

		private void DeleteLabels()
		{
			var checkedLabels = GetCheckedNodesAsNodes(treeAvailableLabels);
			var vE = checkedLabels.Where(n => n.Parent.Index == 0).ToList().Select(n => n.Text).ToList();
			var vNb = checkedLabels.Where(n => n.Parent.Index == 1).ToList().Select(n => n.Text).ToList();
			var vAllNbs = checkedLabels.Where(n => n.Parent.Index == 2).ToList().Select(n => n.Text).ToList();

			foreach(var node in vE)
			{
				// get the entry id from its title and its notebook.

			}

		}

		private void RenameLabels()
		{
			var checkedLabels = GetCheckedNodesAsNodes(treeEntriesToEdit);
			string newName = "";

			if (checkedLabels.Count > 0)
			{
				// Get the new name ...
				using (frmMessage frm = new(frmMessage.OperationType.InputBox, "What is the new label name?"))
				{
					frm.ShowDialog();
					newName = frm.ResultText;
				}

				if(newName.Length > 0)
				{
					var tab1 = "  ";
					var tab2 = "    ";
					List<Entry> entriesToEdit = new();
					lstLabelChangeReview.Items.Clear();

					var vE		= checkedLabels.Where(n => n.Parent.Index == 0).ToList().Select(n => n.Text).ToList();
					var vNb		= checkedLabels.Where(n => n.Parent.Index == 1).ToList().Select(n => n.Text).ToList();
					var vAllNbs = checkedLabels.Where(n => n.Parent.Index == 2).ToList().Select(n => n.Text).ToList();

					if (vE.Count > 0) entriesToEdit.Add(CurrentEntry);

					if(vNb.Count > 0)
					{
						foreach(var vNode in vNb)
						{
							entriesToEdit.AddRange(CurrentNotebook.Entries.Where(e => e.AllLabels.Select(l => l.LabelText).Contains(vNode)));
						}
					}
					
					if(vAllNbs.Count > 0)
					{
						foreach(Notebook n in Program.AllNotebooks)
						{
							foreach(var vNode in vAllNbs)
							{
								entriesToEdit.AddRange(n.Entries.Where(e => e.AllLabels.Select(l => l.LabelText).Contains(vNode)));
							}
						}						
					}

					if(vE.Count > 0) 
					{ 
						lstLabelChangeReview.Items.Add("In the Entry '" + CurrentEntry.Title + "'"); 

						foreach(var vNode in checkedLabels.Where(n => n.Parent.Index == 0))
						{
							lstLabelChangeReview.Items.Add(tab1 + vNode + " renamed to '" + newName + "'");
						}
					}

					if(vNb.Count > 0)
					{
						lstLabelChangeReview.Items.Add("In the Notebook '" + CurrentNotebook.Name + "'");

						foreach(var lbl in vNb)
						{
							var v = entriesToEdit.Where(e => e.AllLabels.Select(l => l.LabelText).Contains(lbl)).ToList();

							lstLabelChangeReview.Items.Add(tab1 + "the Label '" + lbl + "' will be renamed in the Entr" + (v.Count > 1 ? "ies" : "y") + ":");

							foreach(Entry e in v)
							{
								lstLabelChangeReview.Items.Add(tab1 + tab2 + "'" + e.Title + "'");
							}
						}
					}

					if (vAllNbs.Count > 0)
					{
						/* In the notebook <nb>
						 *   
						 *  
						 * 
						 */
						foreach (var label in vAllNbs)
						{
							var nbsWithEntriesWithLabel = Program.AllNotebooks.Select(n => n.Entries.Where(e => e.AllLabels.Select(l => l.LabelText).Contains(label)));

							foreach (var nb in nbsWithEntriesWithLabel)
							{
								lstLabelChangeReview.Items.Add("In the Notebook '" + nb + "'");

								foreach (var lbl in vAllNbs)
								{
									lstLabelChangeReview.Items.Add("the Label '" + lbl + "' exists in the Entries:");

									foreach (Entry e in entriesToEdit.Where(e => e.AllLabels.Select(l => l.LabelText).Contains(lbl)))
									{
										lstLabelChangeReview.Items.Add(tab1 + tab2 + e.Title);
									}
								}

							}
						}
					}

					ShowPanel(pnlLabelChangeReview);
				}
			}
		}

		private async void DeleteOrRename(object sender, EventArgs e)
		{
			this.Cursor			= Cursors.WaitCursor;
			var checkedLabels	= GetCheckedNodesAsNodes(treeAvailableLabels);
			var vE				= checkedLabels.Where(n => n.Parent.Index == 0).ToList().Select(n => n.Text).ToList();
			var vNb				= checkedLabels.Where(n => n.Parent.Index == 1).ToList().Select(n => n.Text).ToList();
			var vAllNbs			= checkedLabels.Where(n => n.Parent.Index == 2).ToList().Select(n => n.Text).ToList();

			treeEntriesToEdit.Nodes.Clear();
			treeEntriesToEdit.Nodes.Add("In Entry '" + (CurrentEntry == null ? "n/a" : CurrentEntry.Title + "'"));
			treeEntriesToEdit.Nodes.Add("In Notebook '" + CurrentNotebook.Name + "'");
			treeEntriesToEdit.Nodes.Add("In All Notebooks");

			foreach (var node in vAllNbs) { treeEntriesToEdit.Nodes[2].Nodes.Add((node)); }

			foreach (var node in vNb)
			{ if (!vAllNbs.Contains(node)) treeEntriesToEdit.Nodes[1].Nodes.Add((node)); }

			foreach (var node in vE)
			{ if (!vAllNbs.Contains(node) & !vNb.Contains(node)) { treeEntriesToEdit.Nodes[0].Nodes.Add(node); } }

			lblSelectAll_Click(null, null);
			btnContinue.Text = ((ToolStripMenuItem)sender).Text + " Labels";
			treeEntriesToEdit.ExpandAll();
			ShowPanel(pnlRenameDeleteManager);
			this.Cursor = Cursors.Default;
		}

		public int GetCheckedNodeCount(TreeNodeCollection nodes)
		{
			foreach (System.Windows.Forms.TreeNode aNode in nodes)
			{
				if (aNode.Checked)
				{ CheckedNodeCount++; }

				if (aNode.Nodes.Count != 0)
					GetCheckedNodeCount(aNode.Nodes);
			}

			return CheckedNodeCount;
		}

		public List<TreeNode> GetCheckedNodesAsNodes(System.Windows.Forms.TreeView tree)
		{
			List<TreeNode> selectedNodes = new List<TreeNode>();

			foreach (TreeNode parent in tree.Nodes)
			{
				foreach (TreeNode child in parent.Nodes)
				{
					if (child.Checked) { selectedNodes.Add(child); }
				}
			}
			return selectedNodes;
		}

		public List<MNLabel> GetCheckedNodesAsLabels(System.Windows.Forms.TreeView tv = null)
		{
			List<MNLabel> lstRtrn = new();
			List<string> lstRtrnString = new();
			MNLabel tmpLbl = null;
			var lblId = 0;
			if (tv == null) tv = treeAvailableLabels;

			foreach (TreeNode tn in tv.Nodes)
			{
				foreach (TreeNode child in tn.Nodes)
				{
					if (child.Checked)
					{
						lblId = CurrentEntry == null ? -1000 : CurrentEntry.Id;

						if (!lstRtrn.Any(l => l.LabelText == child.Text.Replace(" (+)", "") & l.ParentId == lblId))
						{
							tmpLbl = new() { CreatedBy = 1000, LabelText = child.Text.Replace(" (+)", ""), ParentId = lblId };
							//tmpLbl = new() { CreatedBy = Program.User.Id, LabelText = child.Text.Replace(" (+)", ""), ParentId = CurrentEntry.Id };
							//if (!CurrentEntry.AllLabels.Where(l => l.LabelText.Equals(child.Text)).Any() && !lstRtrn.Contains(tmpLbl)) { lstRtrn.Add(tmpLbl); }

							if (!lstRtrn.Contains(tmpLbl)) lstRtrn.Add(tmpLbl);
						}
					}
				}
			}

			return lstRtrn;
		}

		private void gridViewEntryDetails_MouseDown(object sender, MouseEventArgs e)
		{
			var vRowIndex = e.Y / gridViewEntryDetails.RowTemplate.Height;
			gridViewEntryDetails.Rows[vRowIndex].Selected = true;
			var v2 = ViewEntryMenuText;

			switch (vRowIndex)
			{
				case 0:
					break;
				case 1:
					v2 = LoadNotebookMenuText;
					break;
				case > 1:
					var v3 = gridViewEntryDetails.Rows[vRowIndex].Cells[1].Value;
					v2 = "Explore '" + (v3 != null ? v3.ToString() : "") + "'";
					break;
			}

			mnuContext_GridEntryDetails.Text = v2;
		}

		private void lblSelectAll_Click(object sender, EventArgs e)
		{
			lblSelectAll.Text = "select " + (lblSelectAll.Text.Contains("all") ? "none" : "all");

			foreach (TreeNode parent in treeEntriesToEdit.Nodes)
			{ foreach (TreeNode ch in parent.Nodes) { ch.Checked = lblSelectAll.Text.Contains("none"); } }
		}

		private void lblSortType_Click(object sender, EventArgs e)
		{
			//switch (sort)
			//{
			//	case LabelsManager.LabelsSortType.None:
			//		LabelsManager.PopulateLabelsList(null, , LabelsManager.LabelsSortType.None, this.CurrentEntry);
			//		lblSortType.Text = "sort A-Z";
			//		sort = LabelsManager.LabelsSortType.Ascending;
			//		break;
			//	case LabelsManager.LabelsSortType.Ascending:
			//		LabelsManager.PopulateLabelsList(null, lstLabels, LabelsManager.LabelsSortType.Ascending, this.CurrentEntry);
			//		lblSortType.Text = "unsorted";
			//		sort = LabelsManager.LabelsSortType.None;
			//		break;
			//	case LabelsManager.LabelsSortType.Descending:
			//		LabelsManager.PopulateLabelsList(null, lstLabels, LabelsManager.LabelsSortType.None, this.CurrentEntry);
			//		lblSortType.Text = "sort A-Z";
			//		sort = LabelsManager.LabelsSortType.Descending;
			//		break;
			//}
		}

		private void lstOccurrences_MouseUp(object sender, MouseEventArgs e)
		{ PopulateGridViewEntryDetails(e.Y); }

		private void mnuAddToCurrentEntry_Click(object sender, EventArgs e)
		{
			var a = GetCheckedNodesAsLabels().Select(l => l.LabelText);
			var b = CurrentEntry.AllLabels.Select(l => l.LabelText);
			//var x = b.Except(a);

			foreach (var v in a.Except(b))
			{ CurrentEntry.AddLabel(new MNLabel() { LabelText = v, ParentId = CurrentEntry.Id }, Program.LblsInAllNotebooks.Contains(v)); }

			//foreach(var label in x)
			//{ CurrentEntry.RemoveOrReplaceLabel(label,"",false); }

			this.ActionTaken = true;
			this.Hide();
		}

		private void mnuContext_GridEntryDetails_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
			int v = Convert.ToInt32(gridViewEntryDetails.SelectedRows[0].Cells[1].Tag);
			var gridIndex = gridViewEntryDetails.SelectedRows[0];

			switch (gridIndex.Index)
			{
				case 0:     // View Entry
					using (frmNewEntry frm = new(this, null, 0, DbAccess.GetEntry(v)))
					{
						frm.ShowDialog();

						if (frm.Saved)
						{
							PopulateLabelInformation();
							lstOccurrences.SelectedIndex = LastClickedEntryIndex;
							PopulateGridViewEntryDetails();
						}
					}
					break;
				case 1:     // Load Notebook
					Program.NotebooksNamesAndIds.Clear();
					Program.NotebooksNamesAndIds.Add(gridViewEntryDetails.Rows[1].Cells[1].Value.ToString(),
						Convert.ToInt32(gridViewEntryDetails.Rows[1].Cells[1].Tag));
					using (frmMain frm = new()) { frm.ShowDialog(this); }
					break;
					//case 2:     // Explore Group
					//	Program.ActiveNBParentId = Convert.ToInt32(gridViewEntryDetails.Rows[2].Cells[1].Tag);
					//	Program.NotebooksNamesAndIds.Clear();
					//	using (frmMain frm = new()) { frm.ShowDialog(); }
					//	break;
					//case 3:     // Explore Department
					//	break;
					//case 4:     // Explore Account
					//	break;
					//case 5:     // Explore Company
					//	break;
			}

		}

		private void mnuCreateNewLabel_Click(object sender, EventArgs e)
		{
			var msg = "What is the Label text?";

			using (frmMessage frm = new(frmMessage.OperationType.InputBox, msg, "", this, null, 100))
			{
				frm.ShowDialog(this);

				if (frm.ResultText != null)
				{
					var txt = frm.ResultText.Trim();

					if (Program.LblsInAllNotebooks.ConvertAll(s => s.ToLower()).Contains(txt.ToLower()))
					{
						msg = "The label '" + txt + "' already exists. Select it under All Notebooks and click 'Checked Label(s) > Add to Entry'";
						frmMessage frm3 = new(frmMessage.OperationType.Message, msg);
						frm3.ShowDialog(this);
					}
					else
					{
						Program.LblsInAllNotebooks.Add(frm.ResultText);
						treeAvailableLabels.Nodes[2].Nodes.Add(txt);

						if (CurrentEntry != null)
						{
							//msg = "Would you like to add the label '" + frm.ResultText + "' to the entry " + Environment.NewLine + "'" + CurrentEntry.Title + "'?";

							//using (frmMessage frm2 = new(frmMessage.OperationType.YesNoQuestion, msg, "All Label to Entry?", this))
							//{
								//frm2.ShowDialog(this);

								//if (frm2.Result == frmMessage.ReturnResult.Yes)
								//{
									treeAvailableLabels.Nodes[2].Nodes[treeAvailableLabels.Nodes[2].Nodes.Count - 1].Checked = true;
									mnuAddToCurrentEntry_Click(null, null);
									treeAvailableLabels.Nodes[2].Nodes[treeAvailableLabels.Nodes[2].Nodes.Count - 1].Checked = false;
								//}
							//}
						}
					}
				}
			}
		}

		private void PopulateLabelInformation()
		{
			// Populate and display details about the selected label
			TreeNode tn = treeAvailableLabels.SelectedNode;
			lstOccurrences.Items.Clear();
			gridViewEntryDetails.Visible = false;

			if (tn.Level > 0)
			{
				var id = Convert.ToInt32(tn.Tag);
				var v = DbAccess.GetLabel(id);
				lstOccurrences.Items.Clear();
				treeAvailableLabels.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
				lstOccurrences.Items.Add("Label: " + v.Key.LabelText);
				lstOccurrences.Items.Add("Created By: " + v.Value.Name.ToString() + " (" + v.Value.Email + ")");
				lstOccurrences.Items.Add("Created On: " + v.Value.CreatedOn.ToString());
				lstOccurrences.Items.Add("Found in Entries ...");

				foreach (Entry entry in DbAccess.GetEntriesWithLabel(v.Key))
				{
					ListItem item = new() { Id = entry.Id, Name = "  " + entry.Title + " (in '" + entry.NotebookName + "')" };
					lstOccurrences.Items.Add(item);
				}

				lstOccurrences.Visible = true;
				//ShowPanel(pnlMain);
				ShowHideOccurrences();
				pnlLabelDetails.Visible = lstOccurrences.Items.Count > 0;
			}
		}

		private void PopulateGridViewEntryDetails(int mouseY = -1)
		{
			// Populate and display the label Parent data grid.
			gridViewEntryDetails.Rows.Clear();
			gridViewEntryDetails.Rows.Add(6);
			gridViewEntryDetails.GridColor = Color.White;
			ListItem selectedItem = lstOccurrences.SelectedItem as ListItem;
			LastClickedEntryIndex = lstOccurrences.SelectedIndex;
			gridViewEntryDetails.Visible = false;

			if (selectedItem != null && selectedItem.Name.StartsWith("  "))
			{
				gridViewEntryDetails.Rows[0].Cells[0].Value = "Entry: ";
				gridViewEntryDetails.Rows[0].Cells[1].Value = selectedItem.Name.Substring(2, selectedItem.Name.IndexOf(" (") - 2);
				gridViewEntryDetails.Rows[0].Cells[1].Tag = selectedItem.Id;
				List<KeyValuePair<int, string>> parents = DbAccess.GetEntryParentTree(selectedItem.Id);

				for (int i = 0; i < parents.Count; i++)
				{
					var manualText = string.Empty;

					switch (i)
					{
						case 0:
							manualText = "Notebook: ";
							break;
						case 1:
							manualText = "Group: ";
							break;
						case 2:
							manualText = "Department: ";
							break;
						case 3:
							manualText = "Account: ";
							break;
						case 4:
							manualText = "Company: ";
							break;
					}

					gridViewEntryDetails.Rows[i + 1].Cells[0].Value = manualText;
					gridViewEntryDetails.Rows[i + 1].Cells[1].Value = parents[i].Value.ToString().Trim();
					gridViewEntryDetails.Rows[i + 1].Cells[1].Tag = parents[i].Key;

					//lstEntryParents.Items.Add(manualText + parents[i].Value);
				}

				gridViewEntryDetails.RowTemplate.Height = 23;
				gridViewEntryDetails.Columns[0].Width = 80;
				gridViewEntryDetails.Columns[1].Width = 170;
				gridViewEntryDetails.Height = (gridViewEntryDetails.RowTemplate.Height * 7) - 20;
				gridViewEntryDetails.Width = gridViewEntryDetails.Columns[0].Width + gridViewEntryDetails.Columns[1].Width + 3;
				gridViewEntryDetails.Visible = true;
				gridViewEntryDetails.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				if (mouseY > -1) gridViewEntryDetails.Top = mouseY + gridViewEntryDetails.Height + 40;
				if (FirstDetailsLoad) { FirstDetailsLoad = false; PopulateGridViewEntryDetails(mouseY); }
			}
		}

		private void ResetTree()
		{
			Utilities.ResetTree(treeAvailableLabels, CurrentEntry);
			treeAvailableLabels.Nodes[0].Expand();
		}

		private void ShowPanel(Panel panelToShow)
		{
			foreach (Control c in this.Controls) { if (c.GetType() == typeof(Panel)) { c.Visible = false; } }
			pnlMain.Height = this.Height - pnlMain.Top - 25;
			pnlRenameDeleteManager.Height = pnlMain.Height + 10;
			pnlRenameDeleteManager.Height = this.Height - pnlRenameDeleteManager.Top - 18;
			treeAvailableLabels.Height = pnlMain.Height - treeAvailableLabels.Top - 40;
			//treeEntriesToEdit.Height = treeAvailableLabels.Height;
			mnuMain.Visible = panelToShow == pnlMain;
			panelToShow.Size = new Size(this.Width - 20, this.Height - 40);
			panelToShow.Visible = true;
		}

		private void ShowHideOccurrences()
		{
			//if (lstOccurrences.Items.Count > 0)
			//{
			//	treeAvailableLabels.Height = pnlMain.Top + pnlLabelDetails.Top - 55;
			//	lstOccurrences.Height = pnlMain.Height - 250;
			//	pnlLabelDetails.Visible = true;
			//}
			//else
			//{
			//	treeAvailableLabels.Height = pnlMain.Height - 40;
			//	lstOccurrences.Visible = false;
			//}

			//var msg = string.Empty;

			//if (lstOccurrences.Items.Count == 1)
			//{ msg = ""; }
			//else { msg = "Found " + (lstOccurrences.Items.Count - (OccurenceTitleIndicies.Count * 2)).ToString("###,###,###") + " entries in " + (OccurenceTitleIndicies.Count).ToString() + " notebooks"; }
		}

		private void treeAvailableLabels_AfterSelect(object sender, TreeViewEventArgs e)
		{ //if (e.Node.Level > 0) { PopulateLabelInformation(); }
		}

		private void treeAvailableLabels_AfterExpand(object sender, TreeViewEventArgs e)
		{ if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "") { e.Node.Nodes.Clear(); } }

		private void treeLabels_AfterCheck(object sender, TreeViewEventArgs e)
		{// Implment checking/un-checking all subnodes when a parent is clicked and suppressing level 0 node clicks for Rename/Delete mgr.
			if (!ProgramaticallyChecking)
			{
				TreeNode tn = e.Node;
				mnuLabelsOperations.Enabled = false;

				if (tn != null)
				{
					if (tn.Level == 0)
					{
						ProgramaticallyChecking = true;
						var v = (System.Windows.Forms.TreeView)sender;

						if (v.Equals(treeEntriesToEdit))
						{ tn.Checked = false; }
						else
						{
							if (tn.Nodes.Count == 0)
							{ tn.Checked = false; }
							else
							{ foreach (TreeNode tn2 in tn.Nodes) { tn2.Checked = tn.Checked; } }
						}

						ProgramaticallyChecking = false;
					}

					//if(tn.Parent.Level == 0 & !tn.Checked)
					//{
					//	//using(frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "To remove labels, uncheck them in the Entry Edit screen then save the Entry.       ", ""))
					//	//{ frm.ShowDialog(this); tn.Checked = true; }

					//	tn.Checked = true;
					//}

					mnuLabelsOperations.Enabled = true;
				}
			}
		}

		private void treeAvailableLabels_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				var vNode = treeAvailableLabels.GetNodeAt(e.X, e.Y);
				treeAvailableLabels.SelectedNode = vNode;
				mnuContextLabels.Enabled = true;
				if (vNode.Level == 0) { mnuContextLabels.Enabled = false; }
			}
		}

		private void treeAvailableLabels_MouseMove(object sender, MouseEventArgs e)
		{
			gridViewEntryDetails.Visible = false;
		}
	}
}