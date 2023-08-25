/* Manage labels.
 * 7/9/22
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using myNotebooks.DataAccess;
using myNotebooks.objects;
using MyNotebooks.objects;

namespace myNotebooks.subforms
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
		private TreeNode LastClickedLabelNode = null;
		private int LastClickedEntryIndex = -1;
		private const string ViewEntryMenuText = "View Entry";
		private const string LoadNotebookMenuText = "Load Notebook";

		private List<Notebook> SelectedNotebooks { get; set; }

		public bool ActionTaken { get; private set; }

		public frmLabelsManager(Form parent, bool deleteOrphans = false, Notebook _jrnl = null, Entry currentEntry = null)
		{
			InitializeComponent();
			SelectedNotebooks = new List<Notebook>();
			Utilities.SetStartPosition(this, parent);
			DeletingOrphans = deleteOrphans;
			CurrentEntry = currentEntry;
		}

		private async void frmLabelsManager_Load(object sender, EventArgs e)
		{
			if (DeletingOrphans)
			{ this.Visible = false; await ManageOrphans(); this.Close(); }
			else
			{
				if (Program.DictCheckedNotebooks.Count == 0)
				{
					//var msg = "The labels in the deleted notebook will be deleted from all selected notebooks." + Environment.NewLine + "Specify a PIN for any protected notebooks you select.";
					using (frmSelectNotebooksToSearch frm = new frmSelectNotebooksToSearch(this)) { frm.ShowDialog(); }
				}

				foreach (Control c in this.Controls) if (c.GetType() == typeof(Panel)) c.Location = new Point(0, 25);
				ShowPanel(pnlMain);
				ShowHideOccurrences();
				this.Size = new Size(pnlMain.Width + 25, pnlMain.Height + 25);
				//this.GetSelectedNotebooks();
				sort = LabelsManager.LabelsSortType.None;
				lblSortType_Click(null, null);
				//pnlMain.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
				//lstLabels.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

				treeAvailableLabels.Nodes.Clear();
				treeAvailableLabels.Nodes.Add("Notebook '" + Program.SelectedNotebookName + "'");
				treeAvailableLabels.Nodes.Add("Group '" + Program.SelectedGroupName + "'");
				treeAvailableLabels.Nodes.Add("Department '" + Program.SelectedDepartmentName + "'");
				treeAvailableLabels.Nodes.Add("Account '" + Program.SelectedAccountName + "'");
				treeAvailableLabels.Nodes.Add("Company '" + Program.SelectedCompanyName + "'");

				foreach (TreeNode tn in treeAvailableLabels.Nodes) { tn.Nodes.Add(""); }

			}
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
					CreatedBy = Program.User.UserId,
					ParentId = CurrentEntry.Id,
					LabelText = txtLabelName.Text,
				};

				lbl.Save();
				//lstLabels.Items.Add(txtLabelName.Text);
				//await LabelsManager.SaveLabelsToFile(lstLabels.Items.OfType<string>().ToList());
				pnlNewLabelName.Visible = false;
				CurrentEntry.AllLabels.Add(lbl);
				LabelsManager.PopulateLabelsList(null, lstLabels, LabelsManager.LabelsSortType.None, CurrentEntry);
				//lstOccurrences.Items.Clear();
				//this.ShowHideOccurrences();
				//this.ShowPanel(pnlMain);
			}

			this.Cursor = Cursors.Default;
		}

		private async void btnRemoveSelectedOrphans_Click(object sender, EventArgs e)
		{
			if (lstOrphanedLabels.SelectedItems.Count > 0)
			{
				using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Are you sure you want to delete the lables? This action cannot be undone!", "", this))
				{
					frm.ShowDialog(this);

					if (frm.Result == frmMessage.ReturnResult.Yes)
					{ await RemoveOrphans(); }

					if (lstOrphanedLabels.SelectedItems.Count > 0)
					{
						LabelsManager.PopulateLabelsList(null, lstLabels);
						ShowHideOccurrences();
					}

					lstLabels.SelectedItems.Clear();
					lstOccurrences.Items.Clear();
					this.ShowPanel(pnlMain);
				}
			}
		}

		private void chkSelectAllOrphans_CheckedChanged(object sender, EventArgs e)
		{
			if (chkSelectAllOrphans.Checked)
			{
				for (var i = 0; i < lstOrphanedLabels.Items.Count; i++) { lstOrphanedLabels.SelectedItems.Add(lstOrphanedLabels.Items[i]); }
			}
			else { lstOrphanedLabels.SelectedItems.Clear(); }
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

		private void KickLstLabels(int previousIndex = -1)
		{
			if (lstLabels.SelectedItems.Count == 1 | previousIndex > -1)
			{
				var indx = previousIndex > -1 ? previousIndex : lstLabels.SelectedIndex;
				lstLabels.SelectedIndex = -1;
				lstLabels.SelectedIndex = indx;
			}
		}

		private void lblSortType_Click(object sender, EventArgs e)
		{
			switch (sort)
			{
				case LabelsManager.LabelsSortType.None:
					LabelsManager.PopulateLabelsList(null, lstLabels, LabelsManager.LabelsSortType.None, this.CurrentEntry);
					lblSortType.Text = "sort A-Z";
					sort = LabelsManager.LabelsSortType.Ascending;
					break;
				case LabelsManager.LabelsSortType.Ascending:
					LabelsManager.PopulateLabelsList(null, lstLabels, LabelsManager.LabelsSortType.Ascending, this.CurrentEntry);
					lblSortType.Text = "unsorted";
					sort = LabelsManager.LabelsSortType.None;
					break;
				case LabelsManager.LabelsSortType.Descending:
					LabelsManager.PopulateLabelsList(null, lstLabels, LabelsManager.LabelsSortType.None, this.CurrentEntry);
					lblSortType.Text = "sort A-Z";
					sort = LabelsManager.LabelsSortType.Descending;
					break;
			}
		}

		private void lstLabels_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstLabels.SelectedIndex > -1)
			{
				lblEntries1.Text = "";
				mnuMoveTop.Visible = true;
				mnuMoveTop.Enabled = true;
				mnuMoveUp.Visible = lstLabels.SelectedIndex > 0;
				mnuMoveDown.Visible = lstLabels.SelectedIndex != lstLabels.Items.Count - 1;
				lstOccurrences.Items.Clear();
				lstEntryObjects.Items.Clear();
				PopulateOccurrences();

				if (Program.DictCheckedNotebooks.Count == 0)
				{ lstOccurrences.Items.Clear(); lstOccurrences.Items.Add("no notebooks are selected"); }
			}
		}

		private void lstLabels_MouseUp(object sender, MouseEventArgs e)
		{
			lstLabels.SelectedIndex = e.Button == MouseButtons.Right && lstLabels.SelectedIndex > -1 ? e.Y / 15 : lstLabels.SelectedIndex;
			mnuContextLabels.Visible = e.Button == MouseButtons.Right && lstLabels.SelectedIndex > -1;
		}

		private async void lstOccurrences_DoubleClick(object sender, EventArgs e)
		{

			//try
			//{
			//	var i = lstOccurrences.SelectedIndex;
			//	KeyValuePair<Notebook, Entry> kvp = (KeyValuePair<Notebook, Entry>)lstEntryObjects.Items[i];
			//	Utilities.SetProgramPIN(kvp.Key.Name);
			//	var currentEntry = kvp.Value;

			//	using (frmNewEntry frm = new frmNewEntry(this, kvp.Key, 0, kvp.Value))
			//	{
			//		frm.ShowDialog();

			//		if (frm.Saved)
			//		{
			//			Entry nbEntry = frm.Entry;
			//			kvp.Key.ReplaceEntry(currentEntry, nbEntry);
			//			await kvp.Key.Save();
			//			var lblIndx = lstLabels.SelectedIndex;
			//			PopulateOccurrences();
			//			lstLabels.SelectedIndex = -1;
			//			lstLabels.SelectedIndex = lblIndx;
			//			lstOccurrences.SelectedIndex = i;
			//		}
			//	}
			//}
			//catch (Exception) { }
		}

		private void lstOccurrences_MouseUp(object sender, MouseEventArgs e)
		{ PopulateGridViewEntryDetails(); }

		private async Task ManageOrphans()
		{
			//List<string> lstOrphans = LabelsManager.FindOrphansInSelectedNotebooks();

			var label = lstLabels.Text;
			List<Notebook> nbList = Utilities.GetCheckedNotebooks();

			List<Notebook> booksWithLabel = nbList.Where(c => c.HasLabel(label)).ToList();

			foreach (Notebook nb in booksWithLabel) { await nb.DeleteLabelFromNotebook(label); }

			//booksWithLabel.ForEach(b => b.DeleteLabelFromNotebook(label));	// How to await this call?

			var sMsg = nbList.Count + " notebooks were scanned and the label '" + label + "' was found and deleted ";


			if (DeletingOrphans)
			{
				chkSelectAllOrphans.Checked = true;
				await RemoveOrphans();
				sMsg += " in all which were scanned. ";
			}
			else
			{
				lstOrphanedLabels.Items.Clear();
				lstOrphanedLabels.Items.Add(lstOrphanedLabels);
				ShowPanel(pnlOrphanedLabels);
			}

			if (!pnlOrphanedLabels.Visible) { ShowMessage(sMsg); this.Close(); }


			//if (lstOrphans.Count > 0)
			//{
			//	lstOrphanedLabels.Items.AddRange(lstOrphans.ToArray());

			//	if (DeletingOrphans)
			//	{
			//	}
			//	else { ShowPanel(pnlOrphanedLabels); }
			//}
			//else
			//{
			//	if(!DeletingOrphans)
			//	{
			//		using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message,
			//			"No orphaned labels were found.", Application.ProductName, this)) { frm.ShowDialog(); }
			//	}
			//}

			//if (DeletingOrphans) { this.Close(); }
		}

		private async void MenuMove(object sender, EventArgs e)
		{
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
			var isUp = mnu.Name.ToLower().Contains("up");
			var sLbl = lstLabels.SelectedItem.ToString();
			var selIndx = lstLabels.SelectedIndex;
			lstLabels.Items.RemoveAt(selIndx);
			lstLabels.Items.Insert(selIndx + (isUp ? -1 : 1), sLbl);
			lstLabels.SelectedIndex = selIndx + (isUp ? -1 : 1);
			await LabelsManager.SaveLabelsToFile(lstLabels.Items.OfType<string>().ToList());
		}

		private void mnuAdd_Click(object sender, EventArgs e)
		{
			lblOperation.Text = "Label Name:";
			pnlNewLabelName.Visible = true;
			txtLabelName.Text = string.Empty;
			txtLabelName.Focus();
			this.AcceptButton = btnOK;
		}

		private async void DeleteOrRename(object sender, EventArgs e)
		{
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
			var commandText = mnu.Text.ToLower().Contains("rename") ? "rename" : "delete";
			var newLabelName = string.Empty;
			List<Notebook> notebooksToEdit = Utilities.GetCheckedNotebooks();
			var editingOneNotebook = mnu.Name.Contains("Entries");
			var sMsg = "Do you want to " + commandText + " the label '" + lstLabels.SelectedItem.ToString() + "' ";
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
				var msg = "You are renaming '" +
					lstLabels.SelectedItem.ToString() + "' in " + (notebooksToEdit.Count() == Program.AllNotebookNames.Count ? " all " : notebooksToEdit.Count.ToString())
					+ " notebooks." + Environment.NewLine + "What's the new label name?";

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
				var pIndex = lstLabels.SelectedIndex;

				if (commandText.Equals("rename"))
				{
					await LabelsManager.RenameLabelInNotebooksList(lstLabels.SelectedItem.ToString(), newLabelName, notebooksToEdit, Program.DictCheckedNotebooks, this);

					if (notebooksToEdit.Count < Program.AllNotebookNames.Count)
					{
						sMsg = "";
					}

				}
				else
				{ await LabelsManager.DeleteLabelInNotebooksList(lstLabels.SelectedItem.ToString(), notebooksToEdit, this); }

				lblSortType_Click(null, null);
				lstOccurrences.Items.Clear();
			}

			this.Cursor = Cursors.Default;
		}

		private void mnuContext_GridEntryDetails_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
			Int32 v = Convert.ToInt32(gridViewEntryDetails.SelectedRows[0].Cells[1].Tag);

			if (mnu.Text == ViewEntryMenuText)
			{
				using (frmNewEntry frm = new(this, null, 0, DbAccess.GetEntry(v)))
				{
					frm.ShowDialog();

					if (frm.Saved)
					{    // refresh lstOccurrences
						treeAvailableLabels.SelectedNode = LastClickedLabelNode;
						PopulateLabelDetails();
						lstOccurrences.SelectedIndex = LastClickedEntryIndex;
						PopulateGridViewEntryDetails();
					}
				}
			}
			else if (mnu.Text == LoadNotebookMenuText)
			{
				// launch frmMain with this notebook loaded
				var notebookId = Convert.ToInt32(gridViewEntryDetails.Rows[1].Cells[1].Tag);
				var notebookName = gridViewEntryDetails.Rows[1].Cells[1].Value.ToString();
				Program.NotebooksNamesAndIds.Clear();
				Program.NotebooksNamesAndIds.Add(notebookName, notebookId);
				using(frmMain frm = new()) { frm.ShowDialog(this); }
			}
			else
			{
				// invent way to explore org levels here ...
			}
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private async void mnuFindOrphans_Click(object sender, EventArgs e) { await ManageOrphans(); }

		private async void mnuRename_Click(object sender, EventArgs e)
		{
			var oldLabelName = lstLabels.Text;
			var newLabelName = string.Empty;

			var sMsg = "The label '" + lstLabels.SelectedItem + " will be renamed in " +
				(Program.DictCheckedNotebooks.Count == Program.AllNotebooks.Count ? "all" : "the (" + Program.DictCheckedNotebooks.Count + ") selected" + " notebooks.");

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.InputBox, sMsg, "new label name", this))
			{
				frm.ShowDialog();
				if (frm.Result == frmMessage.ReturnResult.Ok) { newLabelName = frm.ResultText; }
			}

			if (newLabelName.Length > 0)
			{
				List<Notebook> jrnlsToSearch = GetSelectedNotebooks();
				await LabelsManager.RenameLabelInNotebooksList(oldLabelName, newLabelName, jrnlsToSearch, Program.DictCheckedNotebooks, this);

				if (!lstLabels.Items.OfType<string>().Contains(newLabelName))
				{
					if (jrnlsToSearch.Count != Program.AllNotebooks.Count)
					{
						var sMsg2 = "The old label name has been left in the list. To completely remove the old label select all notebooks " +
							", add PINs, then try renaming again.";

						MessageBox.Show(sMsg2, "Renamed but old name might still exist");
						lstLabels.Items.Add(newLabelName);
						lstLabels.SelectedIndex = lstLabels.Items.Count - 1;
					}
					else
					{
						lstLabels.Items.Insert(lstLabels.SelectedIndex, newLabelName);
						lstLabels.Items.RemoveAt(lstLabels.SelectedIndex);
					}
				}
				else
				{ lstLabels.Items.RemoveAt(lstLabels.SelectedIndex); }

				await LabelsManager.SaveLabelsToFile(lstLabels.Items.OfType<string>().ToList());
				ActionTaken = true;
				lstOccurrences.Items.Clear();
			}
		}

		private void mnuSelectNotebooks_Click(object sender, EventArgs e)
		{
			using (frmSelectNotebooksToSearch frm = new frmSelectNotebooksToSearch(this)) { frm.ShowDialog(); }
			GetSelectedNotebooks();
			KickLstLabels();
			ShowPanel(pnlMain);
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
				ShowPanel(pnlMain);
				pnlLabelDetails.Visible = lstOccurrences.Items.Count > 0;
			}
		}

		private void PopulateGridViewEntryDetails()
		{
			// Populate and display the label parent data grid.
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

				if (FirstDetailsLoad) { FirstDetailsLoad = false; PopulateGridViewEntryDetails(); }


				//lstEntryParents.Visible = true;
			}
		}

		private void PopulateOccurrences(string labelName = null)
		{
			if (labelName == null)
			{
				if (lstLabels.SelectedItem != null && lstLabels.SelectedItem.ToString().Length > 0)
				{ labelName = lstLabels.SelectedItem.ToString(); }
				else { labelName = string.Empty; }
			}

			if (labelName.Length > 0)
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
							lstEntryObjects.Items.Add("");

							foreach (Entry nbEntry in foundLables.OrderByDescending(e => e.CreatedOn))
							{
								lstOccurrences.Items.Add("   > " + nbEntry.Title);
								lstEntryObjects.Items.Add(new KeyValuePair<Notebook, Entry>(nb, nbEntry));
							}

							lstOccurrences.Items.Add(strSeperator);
							lstEntryObjects.Items.Add("");
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

		private async Task RemoveOrphans()
		{
			foreach (string lbl in lstOrphanedLabels.SelectedItems) { await LabelsManager.DeleteLabelInNotebooksList(lbl, Utilities.GetCheckedNotebooks(), this, true); }
		}

		private void ShowMessage(string sMsg)
		{
			sMsg += Utilities.GetCheckedNotebooks().Count == Program.AllNotebookNames.Count ?
				" from "
				: "Since all notebooks in your collection were not selected for the search the label has been retained in ";

			sMsg += "your Labels collection.";

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, sMsg, "MNLabel Delete Successful", this))
			{ frm.ShowDialog(); }
		}

		private void ShowPanel(Panel panelToShow)
		{   //411, 576
			foreach (Control c in this.Controls) { if (c.GetType() == typeof(Panel)) { c.Visible = false; } }
			if (panelToShow == pnlMain) { treeAvailableLabels.Height = lstOccurrences.Items.Count > 0 ? 264 : 523; }  // { panelToShow.Top = 25; this.Size = new Size(panelToShow.Left + panelToShow.Width + 17, this.Height = panelToShow.Height + panelToShow.Top + 35); }
			if (panelToShow == pnlOrphanedLabels) { lstLabels.SelectedIndices.Clear(); this.Size = new Size(panelToShow.Left + panelToShow.Width + 15, panelToShow.Height + panelToShow.Top + 40); }
			panelToShow.Visible = true;
		}

		private void ShowHideOccurrences()
		{
			if (lstOccurrences.Items.Count > 0)
			{
				treeAvailableLabels.Height = 184;
				//lstLabels.Height = 184; // pnlMain.Height - 320;
				lstOccurrences.Height = pnlMain.Height - 250;
				pnlLabelDetails.Visible = true;
				//lblEntries1.Visible = true;
				//lblEntries2.Visible = true;
			}
			else
			{
				treeAvailableLabels.Height = pnlMain.Height - 50;
				//lstLabels.Height = pnlMain.Height - 50;
				lstOccurrences.Visible = false;
				//lblEntries1.Visible = false;
				//lblEntries2.Visible = false;
			}

			var msg = string.Empty;

			if (lstOccurrences.Items.Count == 1)
			{ msg = ""; }
			else { msg = "Found " + (lstOccurrences.Items.Count - (OccurenceTitleIndicies.Count * 2)).ToString("###,###,###") + " entries in " + (OccurenceTitleIndicies.Count).ToString() + " notebooks"; }

			lblEntries1.Text = lstOccurrences.Items.Count == 0 ? "Found 0 Entries" : msg;
		}

		private void treeAvailableLabels_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{

		}

		private void treeAvailableLabels_AfterSelect(object sender, TreeViewEventArgs e)
		{ 
			if(treeAvailableLabels.SelectedNode.Level > 0)
			{
				PopulateLabelDetails(); 
				LastClickedLabelNode = treeAvailableLabels.SelectedNode; 
			}
		}

		private void treeAvailableLabels_AfterExpand(object sender, TreeViewEventArgs e)
		{
			// Get labels under one of the root nodes.
			TreeNode tn = e.Node;

			if (tn.Level == 0 && tn.Nodes[0].Text.Length == 0)
			{
				tn.Nodes.Clear();
				var orgLevel = Convert.ToInt32(Enum.Parse(typeof(frmMain.OrgLevelTypes), tn.Text.AsSpan(0, tn.Text.IndexOf(" "))));

				foreach (MNLabel label in DbAccess.GetLabelsUnderOrgLevel(CurrentEntry.Id, orgLevel))
				{ tn.Nodes.Add(new TreeNode() { Text = label.LabelText, Tag = label.Id }); }
			}
		}

		private void treeAvailableLabels_AfterCheck(object sender, TreeViewEventArgs e)
		{
			 if(!ProgramaticallyChecking)
			{
				TreeNode tn = treeAvailableLabels.SelectedNode;

				if (tn != null)
				{
					if(tn.Level == 0)
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
					else { LastClickedLabelNode = tn; }
				}
			}
		}

		private void treeAvailableLabels_MouseMove(object sender, MouseEventArgs e)
		{
			if(!lstOccurrences.Visible)
			{
				TreeNode tn = treeAvailableLabels.GetNodeAt(e.X, e.Y);
				if (tn != null && tn.Level == 0) { treeAvailableLabels.SelectedNode = tn; }
			}

			gridViewEntryDetails.Visible = false;
		}
	}
}