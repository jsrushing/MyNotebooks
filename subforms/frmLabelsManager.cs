/* Manage labels.
 * 7/9/22
 */
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using myJournal.objects;
using System.Threading.Tasks;

namespace myJournal.subforms
{
	public partial class frmLabelsManager : Form
	{
		private LabelsManager.LabelsSortType sort = LabelsManager.LabelsSortType.None;
		private string MnuDelete_OneJournalText = "{0} only";
		private string MnuDelete_SelectedJournalaText = "from the {0} selected notebooks";
		private List<int> OccurenceTitleIndicies = new List<int>();
		private bool DeletingOrphans;

		private List<Journal> SelectedJournals { get; set; }

		public bool ActionTaken { get; private set; }

		public frmLabelsManager(Form parent, bool deleteOrphans = false, Journal _jrnl = null)
		{
			InitializeComponent();
			SelectedJournals = new List<Journal>();
			Utilities.SetStartPosition(this, parent);
			DeletingOrphans = deleteOrphans;
		}

		private void frmLabelsManager_Load(object sender, EventArgs e)
		{
			foreach (Control c in this.Controls) if (c.GetType() == typeof(Panel)) c.Location = new Point(0, 25);
			ShowPanel(pnlMain);
			ShowHideOccurrences();
			this.GetSelectedJournals();
			sort = LabelsManager.LabelsSortType.None;
			lblSortType_Click(null, null);
			pnlMain.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
			lstLabels.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

			if (DeletingOrphans)
			{ mnuFindOrphans_Click(null, null); }
			else
			{
				if (Program.DictCheckedJournals.Count == 0)
				{ using (frmSelectJournalsToSearch frm = new frmSelectJournalsToSearch(this)) { frm.ShowDialog(); } }
			}
		}

		private void frmLabelsManager_Resize(object sender, EventArgs e) { ShowHideOccurrences(); }

		private void AddLabelToUIListbox()
		{ if (txtLabelName.Text.Length > 0) { lstLabels.Items.Add(txtLabelName.Text); } }

		private void btnCancel_Click(object sender, EventArgs e)
		{
			pnlNewLabelName.Visible = false;
		}

		private void btnExitOrphans_Click(object sender, EventArgs e)
		{ lstOccurrences.Items.Clear(); ShowHideOccurrences(); ShowPanel(pnlMain); }

		private void btnOK_Click(object sender, EventArgs e) { MenuBtnOk(); }

		private void btnRemoveSelectedOrphans_Click(object sender, EventArgs e)
		{
			if (lstOrphanedLabels.SelectedItems.Count > 0)
			{
				using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Are you sure you want to delete the lables? This action cannot be undone!", "", this))
				{
					frm.ShowDialog(this);

					if (frm.Result == frmMessage.ReturnResult.Yes)
					{ RemoveOrphans(); }


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
				for (int i = 0; i < lstOrphanedLabels.Items.Count; i++) { lstOrphanedLabels.SelectedItems.Add(lstOrphanedLabels.Items[i]); }
			}
			else { lstOrphanedLabels.SelectedItems.Clear(); }
		}

		private List<Journal> GetSelectedJournals()
		{
			SelectedJournals.Clear();
			foreach (KeyValuePair<string, string> kvp in Program.DictCheckedJournals) { SelectedJournals.Add(new Journal(kvp.Key).Open()); }
			return SelectedJournals;
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
				if (Program.DictCheckedJournals.Count == 0)
				{
					using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message,
						"No notebook is selected for the search.", "No Notebook Selected", this))
					{ frm.ShowDialog(); }
					lstLabels.SelectedIndex = -1;
				}
				else
				{
					mnuMoveTop.Visible = true;
					mnuMoveTop.Enabled = true;
					mnuMoveUp.Visible = lstLabels.SelectedIndex > 0;
					mnuMoveDown.Visible = lstLabels.SelectedIndex != lstLabels.Items.Count - 1;
					lstOccurrences.Items.Clear();
					lstEntryObjects.Items.Clear();
					PopulateOccurrences();
				}
			}
		}

		private void lstLabels_MouseUp(object sender, MouseEventArgs e)
		{ lstLabels.SelectedIndex = e.Button == MouseButtons.Right ? e.Y / 15 : lstLabels.SelectedIndex; }

		private void lstOccurrences_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				int i = lstOccurrences.SelectedIndex;
				KeyValuePair<Journal, JournalEntry> kvp = (KeyValuePair<Journal, JournalEntry>)lstEntryObjects.Items[i];
				Journal j = kvp.Key;
				JournalEntry je = kvp.Value;
				Utilities.SetProgramPIN(j.Name);

				using (frmNewEntry frm = new frmNewEntry(this, j, je))
				{ frm.ShowDialog(); if (frm.saved) { PopulateOccurrences(); } }
			}
			catch (Exception) { }
		}

		private void lstOccurrences_MouseUp(object sender, MouseEventArgs e)
		{
			mnuContextDelete.Visible = true;
			//lstOccurrences.ContextMenuStrip = mnuContextEntries;

			if (e.Button == MouseButtons.Right && lstOccurrences.Items.Count > 1)
			{
				lstOccurrences.SelectedIndex = e.Y / 15;

				if (!OccurenceTitleIndicies.Contains(lstOccurrences.SelectedIndex))
				{ mnuContextEntries.Visible = false; lstOccurrences.SelectedIndex = -1; }
				else
				{
					mnuContextEntries.Visible = true;
					mnuContextDelete.Text = "Delete '" + lstLabels.Text + "'";
					mnuContextRename.Text = "Rename '" + lstLabels.Text + "'";
					mnuDelete_OneJournal.Text = string.Format(MnuDelete_OneJournalText, lstOccurrences.SelectedItem.ToString().Replace("in", "from"));
					mnuDelete_AllJournals.Text = Program.DictCheckedJournals.Count == Program.AllJournals.Count ? "from all journals"
						: string.Format(MnuDelete_SelectedJournalaText, Program.DictCheckedJournals.Count.ToString());
				}
			}
			else { mnuContextDelete.Visible = false; }  // lstOccurrences.ContextMenuStrip = null; }
		}

		private async Task MenuBtnOk()
		{
			this.Cursor = Cursors.WaitCursor;
			AddLabelToUIListbox();
			await LabelsManager.SaveLabels(lstLabels.Items.OfType<string>().ToList());
			pnlNewLabelName.Visible = false;
			LabelsManager.PopulateLabelsList(null, lstLabels);
			lstOccurrences.Items.Clear();
			this.ShowHideOccurrences();
			this.ShowPanel(pnlMain);
			this.Cursor = Cursors.Default;
		}

		private async Task MenuDelete(object sender)
		{
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
			var deleteOK = false;
			List<Journal> oneJournal = null;
			var editingOneJournal = false;

			editingOneJournal = mnu.Text.ToLower().Contains("only");
			this.Cursor = Cursors.WaitCursor;

			if (editingOneJournal)
			{
				var journalName = lstOccurrences.Text.Replace("in ", "").Replace(" only", "").Replace("'", "");
				oneJournal = new List<Journal>();
				oneJournal.Add(new Journal(journalName).Open());
			}

			var sMsg = "Do you want to delete the label '" + lstLabels.SelectedItem.ToString() + "' ";
			sMsg += (editingOneJournal ? mnu.Text.Replace("in", "from").Replace(" only", "") :
				Program.DictCheckedJournals.Count == Program.AllJournals.Count ? " from all journals " : " the " + Program.DictCheckedJournals.Count.ToString() + " selected journal"
				+ (Program.DictCheckedJournals.Count == 1 && !editingOneJournal ? "" : "s")) + "?";

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, sMsg, "Delete Label?", this))
			{
				frm.ShowDialog();
				deleteOK = frm.Result == frmMessage.ReturnResult.Yes;
			}

			if (deleteOK)
			{
				var pIndex = lstLabels.SelectedIndex;

				await LabelsManager.DeleteLabel(lstLabels.SelectedItem.ToString(), (oneJournal == null ? this.GetSelectedJournals() : oneJournal), this);
				LabelsManager.PopulateLabelsList(null, lstLabels);
				KickLstLabels(pIndex);
			}

			ActionTaken = true;
			this.Cursor = Cursors.Default;
		}

		private async Task MenuMove(object sender)
		{
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
			var isUp = mnu.Name.ToLower().Contains("up");
			var sLbl = lstLabels.SelectedItem.ToString();
			var selIndx = lstLabels.SelectedIndex;
			lstLabels.Items.RemoveAt(selIndx);
			lstLabels.Items.Insert(selIndx + (isUp ? -1 : 1), sLbl);
			lstLabels.SelectedIndex = selIndx + (isUp ? -1 : 1);
			await LabelsManager.SaveLabels(lstLabels.Items.OfType<string>().ToList());
		}

		private async Task MenuRename()
		{
			var oldLabelName = lstLabels.Text;
			var newLabelName = string.Empty;

			var sMsg = "The label '" + lstLabels.SelectedItem + " will be renamed in " +
				(Program.DictCheckedJournals.Count == Program.AllJournals.Count ? "all" : "(" + Program.DictCheckedJournals.Count + ") selected" + " notebooks");

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.InputBox, sMsg, "What is the new label name?", this))
			{
				frm.ShowDialog();
				if (frm.Result == frmMessage.ReturnResult.Ok) { newLabelName = frm.EnteredValue; }
			}

			if (newLabelName.Length > 0)
			{
				List<Journal> jrnlsToSearch = GetSelectedJournals();
				await LabelsManager.RenameLabel(oldLabelName, newLabelName, jrnlsToSearch, Program.DictCheckedJournals, this);

				if (!lstLabels.Items.OfType<string>().Contains(newLabelName))
				{
					if (jrnlsToSearch.Count != Program.AllJournals.Count)
					{
						var sMsg2 = "The old label name has been left in the list. To completely remove the old label select all notebooks " +
							", add PINs, then try renaming again.";

						MessageBox.Show(sMsg, "Renamed but old name might still exist");
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

				await LabelsManager.SaveLabels(lstLabels.Items.OfType<string>().ToList());
				ActionTaken = true;
				lstOccurrences.Items.Clear();
			}
		}

		private void mnuAdd_Click(object sender, EventArgs e)
		{
			lblOperation.Text = "Label Name:";
			pnlNewLabelName.Visible = true;
			txtLabelName.Text = string.Empty;
			txtLabelName.Focus();
			this.AcceptButton = btnOK;
		}

		private void mnuAssignPINs_Click(object sender, EventArgs e)
		{
			using (frmSelectJournalsToSearch frm = new frmSelectJournalsToSearch(this))
			{
				frm.ShowDialog();
				Program.DictCheckedJournals = frm.CheckedJournals;
			}
			GetSelectedJournals();
			this.Size = this.MinimumSize;
			KickLstLabels();
			ShowPanel(pnlMain);
		}

		private void mnuDelete_Click(object sender, EventArgs e) { this.MenuDelete(sender); }

		private void mnuExit_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void mnuFindOrphans_Click(object sender, EventArgs e)
		{
			lstOrphanedLabels.Items.Clear();
			List<string> lstOrphans = LabelsManager.FindOrphansInSelectedJournals();

			if (lstOrphans.Count > 0)
			{
				lstOrphanedLabels.Items.AddRange(lstOrphans.ToArray());

				if (DeletingOrphans)
				{
					chkSelectAllOrphans.Checked = true;
					RemoveOrphans();
					this.Hide();
				}
				else { ShowPanel(pnlOrphanedLabels); }
			}
			else
			{
				using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "No orphaned labels were found.", Application.ProductName, this)) { frm.ShowDialog(); }
			}
		}

		private void mnuMoveUp_Click(object sender, EventArgs e) { this.MenuMove(sender); }

		private void mnuMoveDown_Click(object sender, EventArgs e) { this.MenuMove(sender); }

		private void mnuRename_Click(object sender, EventArgs e) { this.MenuRename(); }

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
				var currentPIN = Program.PIN;

				List<Journal> journalsWithLabel = LabelsManager.JournalsContainingLabel(labelName);

				if (journalsWithLabel.Count > 0)
				{
					foreach (Journal jrnl in journalsWithLabel)
					{
						Utilities.SetProgramPIN(jrnl.Name);
						List<JournalEntry> foundLables = jrnl.Entries.Where(t => ("," + t.ClearLabels() + ",").Contains("," + labelName + ",")).ToList();

						if (foundLables.Count > 0)
						{
							lstOccurrences.Items.Add("in '" + jrnl.Name + "'");
							OccurenceTitleIndicies.Add(lstOccurrences.Items.Count - 1);
							lstEntryObjects.Items.Add("");

							foreach (JournalEntry je in foundLables)
							{
								lstOccurrences.Items.Add("   > " + je.ClearTitle());
								lstEntryObjects.Items.Add(new KeyValuePair<Journal, JournalEntry>(jrnl, je));
							}

							lstOccurrences.Items.Add("-----------------------");
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
			foreach (string lbl in lstOrphanedLabels.SelectedItems) { await LabelsManager.DeleteLabel(lbl, Utilities.CheckedJournals(), this, true); }
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
				lstLabels.Height = 184;	// pnlMain.Height - 320;
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
		}
	}
}