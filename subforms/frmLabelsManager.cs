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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyNotebooks.DataAccess;
using MyNotebooks.objects;

namespace MyNotebooks.subforms
{
	public partial class frmLabelsManager : Form
	{
		private LabelsManager.LabelsSortType sort = LabelsManager.LabelsSortType.None;
		private List<int> OccurenceTitleIndicies = new List<int>();
		private bool DeletingOrphans;
		private string strSeperator = "-----------------------";
		public Entry CurrentEntry { get; set; }
		private bool FirstDetailsLoad = true;
		private bool ProgramaticallyChecking = false;
		private int LastClickedEntryIndex = -1;
		private const string ViewEntryMenuText = "View Entry";
		private const string LoadNotebookMenuText = "Load Notebook";
		private BackgroundWorker Worker;
		private List<MNLabel> LblsUnderEntry = new();
		private List<MNLabel> LblsUnderNotebook = new();
		private List<MNLabel> LblsUnderGroup = new();
		private List<MNLabel> LblsUnderDepartment = new();
		private List<MNLabel> LblsUnderAccount = new();
		private List<MNLabel> LblsUnderCompany = new();

		private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			LblsUnderEntry		= DbAccess.GetLabelsUnderOrgLevel(CurrentEntry.Id, 1);
			LblsUnderNotebook	= DbAccess.GetLabelsUnderOrgLevel(CurrentEntry.Id, 2);
			LblsUnderGroup		= DbAccess.GetLabelsUnderOrgLevel(CurrentEntry.Id, 3);
			LblsUnderDepartment = DbAccess.GetLabelsUnderOrgLevel(CurrentEntry.Id, 4);
			LblsUnderAccount	= DbAccess.GetLabelsUnderOrgLevel(CurrentEntry.Id, 5);
			LblsUnderCompany	= DbAccess.GetLabelsUnderOrgLevel(CurrentEntry.Id, 6);
		}

		private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.Text = e.ProgressPercentage.ToString() + "%";
		}

		private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			TreeNode tn = new TreeNode();

			foreach (MNLabel label in LblsUnderNotebook)	PopulateTreeWithLabels(0, label);
			foreach (MNLabel label in LblsUnderGroup)		PopulateTreeWithLabels(1, label);	//{ treeAvailableLabels.Nodes[1].Nodes.Add(label.Id.ToString(), label.LabelText); }
			foreach (MNLabel label in LblsUnderDepartment)	PopulateTreeWithLabels(2, label);	//{ treeAvailableLabels.Nodes[2].Nodes.Add(label.Id.ToString(), label.LabelText); }
			foreach (MNLabel label in LblsUnderAccount)		PopulateTreeWithLabels(3, label);	//{ treeAvailableLabels.Nodes[3].Nodes.Add(label.Id.ToString(), label.LabelText); }
			foreach (MNLabel label in LblsUnderCompany)		PopulateTreeWithLabels(4, label);	//{ treeAvailableLabels.Nodes[4].Nodes.Add(label.Id.ToString(), label.LabelText); }

			foreach(TreeNode tn2 in treeAvailableLabels.Nodes)
			{ if(tn2.Nodes.Count == 0) { tn2.Nodes.Add(""); } }
		}

		private void PopulateTreeWithLabels(int nodeIndex, MNLabel lbl)
		{
			TreeNode tn = new();
			bool exists = false;
			tn.Text = lbl.LabelText;
			tn.Tag = lbl.Id.ToString();

			foreach(TreeNode childInTgt in treeAvailableLabels.Nodes[nodeIndex].Nodes)
			{
				if(childInTgt.Text ==  lbl.LabelText) { exists = true; break; }	
			}

			if (!exists) { treeAvailableLabels.Nodes[nodeIndex].Nodes.Add(tn); }
		}

		private List<Notebook> SelectedNotebooks { get; set; }

		public bool ActionTaken { get; private set; }

		public frmLabelsManager(Form parent, bool deleteOrphans = false, Entry currentEntry = null)
		{
			InitializeComponent();
			SelectedNotebooks = new List<Notebook>();
			Utilities.SetStartPosition(this, parent);
			DeletingOrphans = deleteOrphans;
			CurrentEntry = currentEntry;
		}

		private async void frmLabelsManager_Load(object sender, EventArgs e)
		{

			if (Program.DictCheckedNotebooks.Count == 0)
			{
				//var msg = "The labelsForSearch in the deleted notebook will be deleted from all selected notebooks." + Environment.NewLine + "Specify a PIN for any protected notebooks you select.";
				using (frmSelectNotebooksToSearch frm = new frmSelectNotebooksToSearch(this)) { frm.ShowDialog(); }
			}

			foreach (Control c in this.Controls) if (c.GetType() == typeof(Panel)) c.Location = new Point(0, 25);
			ShowPanel(pnlMain);
			ShowHideOccurrences();
			this.Size = new Size(pnlMain.Width + 25, pnlMain.Height + 25);
			sort = LabelsManager.LabelsSortType.None;
			lblSortType_Click(null, null);
			ResetTree();
			Worker = new BackgroundWorker();
			Worker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
			Worker.WorkerReportsProgress = true;
			Worker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
			Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
			Worker.RunWorkerAsync();
		}

		private void frmLabelsManager_Resize(object sender, EventArgs e) { ShowHideOccurrences(); }

		private void btnCancel_Click(object sender, EventArgs e)
		{
			pnlNewLabelName.Visible = false;
		}

		private void btnExitOrphans_Click(object sender, EventArgs e)
		{ lstOccurrences.Items.Clear(); ShowHideOccurrences(); ShowPanel(pnlMain); }

		private async void btnOK_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			if (txtLabelName.Text.Length > 0)
			{
				MNLabel lbl = new()
				{
					CreatedBy = Program.User.Id,
					ParentId = CurrentEntry.Id,
					LabelText = txtLabelName.Text,
				};

				lbl.Create();
				//lstLabels.Items.Add(txtLabelName.Text);
				//await LabelsManager.SaveLabelsToFile(lstLabels.Items.OfType<string>().ToList());
				pnlNewLabelName.Visible = false;
				CurrentEntry.AllLabels.Add(lbl);
				//LabelsManager.PopulateLabelsList(null, lstLabels, LabelsManager.LabelsSortType.None, CurrentEntry);
				//lstOccurrences.Items.Clear();
				//this.ShowHideOccurrences();
				//this.ShowPanel(pnlMain);
			}

			this.Cursor = Cursors.Default;
		}

		public List<MNLabel> GetCheckedNodes()
		{
			List<MNLabel> lstRtrn = new();

			foreach (TreeNode tn in treeAvailableLabels.Nodes)
			{
				foreach (TreeNode child in tn.Nodes)
				{
					if (child.Checked)
					{
						if (!lstRtrn.Any(l => l.LabelText == child.Text & l.ParentId == CurrentEntry.Id))
						{
							MNLabel tmpLbl = new() { CreatedBy = Program.User.Id, LabelText = child.Text, ParentId = CurrentEntry.Id };
							var v = CurrentEntry.AllLabels.Where(l => l.LabelText.Equals(child.Text)).Any();
							if (!v && !lstRtrn.Contains(tmpLbl)) { lstRtrn.Add(tmpLbl); }
						}
					}
					else
					{
						// remove from AllLabels if exists.
						var label = CurrentEntry.AllLabels.Where(l => l.LabelText == child.Text).FirstOrDefault();
						CurrentEntry.AllLabels.Remove(label);
					}
				}
			}

			return lstRtrn;
		}

		private List<Notebook> GetSelectedNotebooks()
		{
			SelectedNotebooks.Clear();
			foreach (KeyValuePair<string, string> kvp in Program.DictCheckedNotebooks) { SelectedNotebooks.Add(new Notebook(kvp.Key, "").Open()); }
			return SelectedNotebooks;
		}

		private void gridViewEntryDetails_DoubleClick(object sender, EventArgs e)
		{
			gridViewEntryDetails.Visible = false;
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

		private void lblSortType_Click(object sender, EventArgs e)
		{
			//switch (sort)
			//{
			//	case LabelsManager.LabelsSortType.None:
			//		LabelsManager.PopulateLabelsList(null, lstLabels, LabelsManager.LabelsSortType.None, this.CurrentEntry);
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

		private void mnuAddCheckedLabelsToEntry_Click(object sender, EventArgs e)
		{
			List<MNLabel> existingLabels = new();
			foreach (var label in CurrentEntry.AllLabels) { existingLabels.Add(label); }


			//var vEntryLabels = CurrentEntry.AllLabels;

			foreach (MNLabel lbl in GetCheckedNodes())
			{
				if (!CurrentEntry.AllLabels.Any(l => l.LabelText == lbl.LabelText & l.ParentId == lbl.ParentId))
				{ lbl.Create(); }

				CurrentEntry.AllLabels.Add(lbl);
			}

			foreach (MNLabel mNLabel in existingLabels.Where(e => !CurrentEntry.AllLabels.Contains(e)))
			{
				DbAccess.CRUDLabel(mNLabel, OperationType.Delete);
				CurrentEntry.AllLabels.Remove(mNLabel);
			}

			ActionTaken = true;
			this.Close();
		}

		private async void DeleteOrRename(object sender, EventArgs e)
		{
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
			var commandText = mnu.Text.ToLower().Contains("rename") ? "rename" : "delete";
			var newLabelName = string.Empty;
			List<Notebook> notebooksToEdit = Utilities.GetCheckedNotebooks();
			var editingOneNotebook = mnu.Name.Contains("Entries");
			var sMsg = string.Empty;    // "Do you want to " + commandText + " the label '" + lstLabels.SelectedItem.ToString() + "' ";
			this.Cursor = Cursors.WaitCursor;

			if (editingOneNotebook)
			{
				notebooksToEdit.Clear();

				var notebookName = lstOccurrences.Text;
				notebookName = notebookName.Substring(4, notebookName.Length - 5);
				Utilities.SetProgramPIN(notebookName);

				notebooksToEdit.Add(new Notebook(notebookName, null).Open());
				sMsg += "in the notebook '" + notebookName + "'?";
			}
			else
			{
				sMsg += "in all " + (notebooksToEdit.Count == Program.AllNotebookNames.Count ? "" : notebooksToEdit.Count.ToString() + " selected ") + "notebooks?";
			}

			if (commandText == "rename")
			{
				var msg = "";   // "You are renaming '" +
								//lstLabels.SelectedItem.ToString() + "' in " + (notebooksToEdit.Count() == Program.AllNotebookNames.Count ? " all " : notebooksToEdit.Count.ToString())
								//+ " notebooks." + Environment.NewLine + "What's the new label name?";

				using (frmMessage frm = new frmMessage(frmMessage.OperationType.LabelNameInputBox, msg))
				{
					frm.ShowDialog();
					newLabelName = frm.ResultText;
					ActionTaken = newLabelName != null;
				}
			}
			else
			{
				using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, sMsg, "Confirm Action", this))
				{
					frm.ShowDialog();
					ActionTaken = frm.Result == frmMessage.ReturnResult.Yes;
				}
			}

			if (ActionTaken)
			{
				var pIndex = 0; // lstLabels.SelectedIndex;

				if (commandText.Equals("rename"))
				{
					//await LabelsManager.RenameLabelInNotebooksList(lstLabels.SelectedItem.ToString(), newLabelName, notebooksToEdit, Program.DictCheckedNotebooks, this);

					if (notebooksToEdit.Count < Program.AllNotebookNames.Count)
					{
						sMsg = "";
					}

				}
				else
				{ /*await LabelsManager.DeleteLabelInNotebooksList(lstLabels.SelectedItem.ToString(), notebooksToEdit, this);*/ }

				lblSortType_Click(null, null);
				lstOccurrences.Items.Clear();
			}

			this.Cursor = Cursors.Default;
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
						{    // refresh lstOccurrences
							 //treeAvailableLabels.SelectedNode = LastClickedLabelNode;
							PopulateLabelDetails();
							lstOccurrences.SelectedIndex = LastClickedEntryIndex;
							PopulateGridViewEntryDetails();
						}
					}
					break;
				case 1:     // Load Notebook
							// Launch frmMain with Program.NotebooksNamesAndIds pre-loaded with the target Notebook.
					Program.NotebooksNamesAndIds.Clear();
					Program.NotebooksNamesAndIds.Add(gridViewEntryDetails.Rows[1].Cells[1].Value.ToString(),
						Convert.ToInt32(gridViewEntryDetails.Rows[1].Cells[1].Tag));
					using (frmMain frm = new()) { frm.ShowDialog(this); }
					break;
				case 2:     // Explore Group
					Program.ActiveNBParentId = Convert.ToInt32(gridViewEntryDetails.Rows[2].Cells[1].Tag);
					Program.NotebooksNamesAndIds.Clear();
					using (frmMain frm = new()) { frm.ShowDialog(); }
					break;
				case 3:     // Explore Department
					break;
				case 4:     // Explore Account
					break;
				case 5:     // Explore Company
					break;
			}

		}

		private void mnuCreateNewLabel_Click(object sender, EventArgs e)
		{
			var msg = "You are creating a new Label for the entry '" + CurrentEntry.Title +
				"'. What is the Label text?";

			using (frmMessage frm = new(frmMessage.OperationType.InputBox, msg, "", this))
			{
				frm.ShowDialog(this);

				if (frm.ResultText != null)
				{
					// insure label name doesn't exist for the Company above the current Entry


					MNLabel lbl = new()
					{
						CreatedBy = Program.User.Id,
						LabelText = frm.ResultText,
						ParentId = CurrentEntry.Id
					};

					if (!CurrentEntry.AllLabels.Any(l => l.LabelText == lbl.LabelText & l.ParentId == lbl.ParentId))
					{
						lbl.Create();
						ResetTree();
						var l = CurrentEntry.AllLabels.FirstOrDefault(l => l.LabelText == l.LabelText);
						if (l == null) CurrentEntry.AllLabels.Add(lbl);
					}
				}
			}
		}

		private void PopulateLabelDetails()
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
					ListItem item = new() { Id = entry.Id, Name = "  " + entry.Title };
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
				gridViewEntryDetails.Rows[0].Cells[1].Value = selectedItem.Name.Substring(2, selectedItem.Name.Length - 2);
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


				//lstEntryParents.Visible = true;
			}
		}

		private void PopulateOccurrences(string labelName = null)
		{
			//if (labelName == null)
			//{
			//	if (lstLabels.SelectedItem != null && lstLabels.SelectedItem.ToString().Length > 0)
			//	{ labelName = lstLabels.SelectedItem.ToString(); }
			//	else { labelName = string.Empty; }
			//}

			if (labelName != null && labelName.Length > 0)
			{
				this.Cursor = Cursors.WaitCursor;
				lstOccurrences.Items.Clear();
				OccurenceTitleIndicies.Clear();
				var currentPIN = Program.PIN;

				List<Notebook> notebooksWithLabel = LabelsManager.NotebooksContainingLabel(labelName);

				if (notebooksWithLabel.Count > 0)
				{
					foreach (Notebook nb in notebooksWithLabel)
					{
						Utilities.SetProgramPIN(nb.Name);
						List<Entry> foundLables = nb.Entries.Where(t => ("," + t.Labels + ",").Contains("," + labelName + ",")).ToList();

						if (foundLables.Count > 0)
						{
							lstOccurrences.Items.Add("in '" + nb.Name + "'");
							OccurenceTitleIndicies.Add(lstOccurrences.Items.Count - 1);
							//lstEntryObjects.Items.Add("");

							foreach (Entry nbEntry in foundLables.OrderByDescending(e => e.CreatedOn))
							{
								lstOccurrences.Items.Add("   > " + nbEntry.Title);
								//lstEntryObjects.Items.Add(new KeyValuePair<Notebook, Entry>(nb, nbEntry));
							}

							lstOccurrences.Items.Add(strSeperator);
							//lstEntryObjects.Items.Add("");
						}
					}
				}

				if (lstOccurrences.Items.Count == 0) { lstOccurrences.Items.Add("Nothing found (is a PIN missing?)"); }
				Program.PIN = currentPIN;
			}
			else { lstOccurrences.Items.Clear(); }

			ShowHideOccurrences();
			this.Cursor = Cursors.Default;
		}

		//private async Task RemoveOrphans()
		//{
		//	foreach (string lbl in lstOrphanedLabels.SelectedItems) { await LabelsManager.DeleteLabelInNotebooksList(lbl, Utilities.GetCheckedNotebooks(), this, true); }
		//}

		private void ResetTree()
		{
			treeAvailableLabels.Nodes.Clear();
			treeAvailableLabels.Nodes.Add("Notebook '" + Program.SelectedNotebookName + "'");
			//treeAvailableLabels.Nodes[0].Nodes.Add("");
			treeAvailableLabels.Nodes.Add("Group '" + Program.SelectedGroupName + "'");
			//treeAvailableLabels.Nodes[1].Nodes.Add("");
			treeAvailableLabels.Nodes.Add("Department '" + Program.SelectedDepartmentName + "'");
			//treeAvailableLabels.Nodes[2].Nodes.Add("");
			treeAvailableLabels.Nodes.Add("Account '" + Program.SelectedAccountName + "'");
			//treeAvailableLabels.Nodes[3].Nodes.Add("");
			treeAvailableLabels.Nodes.Add("Company '" + Program.SelectedCompanyName + "'");
			//treeAvailableLabels.Nodes[4].Nodes.Add("");
		}

		private void ShowMessage(string sMsg)
		{
			sMsg += Utilities.GetCheckedNotebooks().Count == Program.AllNotebookNames.Count ?
				" from "
				: "Since all notebooks in your collection were not selected for the search the label has been retained in ";

			sMsg += "your Labels collection.";

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, sMsg, "MNLabel Delete_original Successful", this))
			{ frm.ShowDialog(); }
		}

		private void ShowPanel(Panel panelToShow)
		{   // starting height 631
			foreach (Control c in this.Controls) { if (c.GetType() == typeof(Panel)) { c.Visible = false; } }

			//if (panelToShow == pnlMain)
			//{
			//	treeAvailableLabels.Height = lstOccurrences.Items.Count > 0 ?
			//		pnlMain.Height + pnlMain.Top + treeAvailableLabels.Top - pnlLabelDetails.Top - 25:
			//		pnlMain.Height + pnlMain.Top + pnlMain.Height;
			//}

			//if (panelToShow == pnlOrphanedLabels)
			//{
			//	lstLabels.SelectedIndices.Clear();
			//	this.Size = new Size(panelToShow.Left + panelToShow.Width + 15, panelToShow.Height + panelToShow.Top + 40);
			//}
			panelToShow.Visible = true;
		}

		private void ShowHideOccurrences()
		{
			if (lstOccurrences.Items.Count > 0)
			{
				treeAvailableLabels.Height = pnlMain.Top + pnlLabelDetails.Top - 25;
				lstOccurrences.Height = pnlMain.Height - 250;
				pnlLabelDetails.Visible = true;
			}
			else
			{
				treeAvailableLabels.Height = pnlMain.Height;
				lstOccurrences.Visible = false;
			}

			var msg = string.Empty;

			if (lstOccurrences.Items.Count == 1)
			{ msg = ""; }
			else { msg = "Found " + (lstOccurrences.Items.Count - (OccurenceTitleIndicies.Count * 2)).ToString("###,###,###") + " entries in " + (OccurenceTitleIndicies.Count).ToString() + " notebooks"; }

			//lblEntries1.Text = lstOccurrences.Items.Count == 0 ? "Found 0 Entries" : msg;
		}

		private void treeAvailableLabels_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Level > 0)
			{
				PopulateLabelDetails();
				e.Node.Checked = !e.Node.Checked;
			}
		}

		private void treeAvailableLabels_AfterExpand(object sender, TreeViewEventArgs e)
		{
			while(Worker.IsBusy) { Thread.Sleep(300); }
			if(e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "") { e.Node.Nodes.Clear(); }
		}

		private void treeAvailableLabels_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (!ProgramaticallyChecking)
			{
				TreeNode tn = e.Node;   // treeAvailableLabels.SelectedNode;
				mnuLabelsOperations.Enabled = false;

				if (tn != null)
				{
					if (tn.Level == 0)
					{
						ProgramaticallyChecking = true;

						if (tn.Nodes.Count == 0)
						{
							tn.Checked = false;
						}
						else
						{
							foreach (TreeNode tn2 in tn.Nodes)
							{
								tn2.Checked = tn.Checked;
							}
						}

						ProgramaticallyChecking = false;
					}
					else
					{
						foreach (TreeNode treeNode in treeAvailableLabels.Nodes)
						{
							foreach (TreeNode childNode in treeNode.Nodes)
							{
								if (childNode.Text == tn.Text)
								{
									ProgramaticallyChecking = true;
									childNode.Checked = tn.Checked;
								}
							}

							ProgramaticallyChecking = false;

						}
					}

					if (tn.Checked)
					{
						//return;
					}
					mnuLabelsOperations.Enabled = true;
				}
			}
		}

		private void treeAvailableLabels_MouseMove(object sender, MouseEventArgs e)
		{
			//if (!lstOccurrences.Visible)
			//{
			//currentHoverNode = treeAvailableLabels.GetNodeAt(e.X, e.Y + treeAvailableLabels.TopNode.Index);
			//if (tn != null && tn.Level == 0) { treeAvailableLabels.SelectedNode = tn; }
			//}

			gridViewEntryDetails.Visible = false;
		}

	}
}