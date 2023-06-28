/* Manage labels.
 * 7/9/22
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using myNotebooks.objects;

namespace myNotebooks.subforms
{
	public partial class frmLabelsManager : Form
	{
		private LabelsManager.LabelsSortType sort = LabelsManager.LabelsSortType.None;
		private List<int> OccurenceTitleIndicies = new List<int>();
		private bool DeletingOrphans;
		private string strSeperator = "-----------------------";

		private List<Notebook> SelectedNotebooks { get; set; }

		public bool ActionTaken { get; private set; }

		public frmLabelsManager(Form parent, bool deleteOrphans = false, Notebook _jrnl = null)
		{
			InitializeComponent();
			SelectedNotebooks = new List<Notebook>();
			Utilities.SetStartPosition(this, parent);
			DeletingOrphans = deleteOrphans;
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
				this.GetSelectedNotebooks();
				sort = LabelsManager.LabelsSortType.None;
				lblSortType_Click(null, null);
				pnlMain.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
				lstLabels.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
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
				lstLabels.Items.Add(txtLabelName.Text);
				await LabelsManager.SaveLabelsToFile(lstLabels.Items.OfType<string>().ToList());
				pnlNewLabelName.Visible = false;
				//LabelsManager.PopulateLabelsList(null, lstLabels);
				lstOccurrences.Items.Clear();
				this.ShowHideOccurrences();
				this.ShowPanel(pnlMain);
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
			foreach (KeyValuePair<string, string> kvp in Program.DictCheckedNotebooks) { SelectedNotebooks.Add(new Notebook(kvp.Key, "", this).Open()); }
			return SelectedNotebooks;
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
					LabelsManager.PopulateLabelsList(null, lstLabels);
					lblSortType.Text = "sort A-Z";
					sort = LabelsManager.LabelsSortType.Ascending;
					break;
				case LabelsManager.LabelsSortType.Ascending:
					LabelsManager.PopulateLabelsList(null, lstLabels, LabelsManager.LabelsSortType.Descending);
					lblSortType.Text = "sort Z-A";
					sort = LabelsManager.LabelsSortType.Descending;
					break;
				case LabelsManager.LabelsSortType.Descending:
					LabelsManager.PopulateLabelsList(null, lstLabels, LabelsManager.LabelsSortType.Ascending);
					lblSortType.Text = "unsorted";
					sort = LabelsManager.LabelsSortType.None;
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
			try
			{
				var i = lstOccurrences.SelectedIndex;
				KeyValuePair<Notebook, Entry> kvp = (KeyValuePair<Notebook, Entry>)lstEntryObjects.Items[i];
				Utilities.SetProgramPIN(kvp.Key.Name);
				var currentEntry = kvp.Value;

				using (frmNewEntry frm = new frmNewEntry(this, kvp.Key, kvp.Value))
				{
					frm.ShowDialog();

					if (frm.Saved)
					{
						Entry nbEntry = frm.Entry;
						kvp.Key.ReplaceEntry(currentEntry, nbEntry);
						await kvp.Key.Save();
						var lblIndx = lstLabels.SelectedIndex;
						PopulateOccurrences();
						lstLabels.SelectedIndex = -1;
						lstLabels.SelectedIndex = lblIndx;
						lstOccurrences.SelectedIndex = i;
					}
				}
			}
			catch (Exception) { }
		}

		private void lstOccurrences_MouseUp(object sender, MouseEventArgs e)
		{
			mnuContextDelete_lstEntries.Visible = true;

			if (e.Button == MouseButtons.Right && lstOccurrences.Items.Count > 1)
			{
				lstOccurrences.SelectedIndex = e.Y / 15;

				if (!OccurenceTitleIndicies.Contains(lstOccurrences.SelectedIndex))
				{ mnuContextEntries.Visible = false; lstOccurrences.SelectedIndex = -1; }
				else
				{
					mnuContextEntries.Visible = true;
				}
			}
			else { mnuContextDelete_lstEntries.Visible = false; }
		}

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
				var notebookName = lstOccurrences.Text.Replace("in ", "").Replace(" only", "").Replace("'", "");
				notebooksToEdit.Add(new Notebook(notebookName, "", this).Open());
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

				using (frmMessage frm = new frmMessage(frmMessage.OperationType.InputBox, msg))
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

				//await LabelsManager.SaveLabels();
				//LabelsManager.PopulateLabelsList(null, lstLabels);
				//KickLstLabels(pIndex);
				lstOccurrences.Items.Clear();
			}

			this.Cursor = Cursors.Default;
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

							foreach (Entry nbEntry in foundLables.OrderByDescending(e => e.Date))
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

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, sMsg, "Label Delete Successful", this))
			{ frm.ShowDialog(); }
		}

		private void ShowPanel(Panel panelToShow)
		{   //411, 576
			foreach (Control c in this.Controls) { if (c.GetType() == typeof(Panel)) { c.Visible = false; } }
			if (panelToShow == pnlMain) { panelToShow.Top = 25; this.Size = new Size(panelToShow.Left + panelToShow.Width + 17, this.Height = panelToShow.Height + panelToShow.Top + 35); }
			if (panelToShow == pnlOrphanedLabels) { lstLabels.SelectedIndices.Clear(); this.Size = new Size(panelToShow.Left + panelToShow.Width + 15, panelToShow.Height + panelToShow.Top + 40); }
			panelToShow.Visible = true;
		}

		private void ShowHideOccurrences()
		{
			if (lstOccurrences.Items.Count > 0)
			{
				lstLabels.Height = 184; // pnlMain.Height - 320;
				lstOccurrences.Height = pnlMain.Height - 250; lstOccurrences.Visible = true;
				lblEntries1.Visible = true;
				lblEntries2.Visible = true;
			}
			else
			{
				lstLabels.Height = pnlMain.Height - 50;
				lstOccurrences.Visible = false;
				lblEntries1.Visible = false;
				lblEntries2.Visible = false;
			}

			var msg = string.Empty;

			if (lstOccurrences.Items.Count == 1)
			{ msg = ""; }
			else { msg = "Found " + (lstOccurrences.Items.Count - (OccurenceTitleIndicies.Count * 2)).ToString("###,###,###") + " entries in " + (OccurenceTitleIndicies.Count).ToString() + " Notebooks"; }

			lblEntries1.Text = lstOccurrences.Items.Count == 0 ? "Found 0 Entries" : msg;
		}
	}
}