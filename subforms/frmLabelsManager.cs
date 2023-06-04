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
using Org.BouncyCastle.Crypto.Agreement.JPake;

namespace myJournal.subforms
{
	public partial class frmLabelsManager : Form
	{
		private bool Renaming = false;
		private bool Adding = false;
		private bool Deleting = false;

		private LabelsManager.LabelsSortType sort = LabelsManager.LabelsSortType.None;
		private string OriginalPIN = Program.PIN;
		private Dictionary<string, string> DictJournals = new Dictionary<string, string>();
		private string MnuDelete_OneJournalText = "{0} only";
		private string MnuRename_OneJournalText = "{0} only";
		private string MnuDelete_SelectedJournalaText = "from the {0} selected journals";
		private string MnuRename_SelectedJournalsText = "in the {0} selected journals";

		private List<Journal> SelectedJournals { get; set; }

		public bool ActionTaken { get; private set; }

		private Journal CurrentJournal;

		public frmLabelsManager(Form parent, Journal _jrnl = null)
		{
			InitializeComponent();
			SelectedJournals = new List<Journal>();
			Utilities.SetStartPosition(this, parent);
		}

		private void frmLabelsManager_Load(object sender, EventArgs e)
		{
			this.Size = this.MinimumSize;

			foreach (Control c in this.Controls) if (c.GetType() == typeof(Panel)) c.Location = new Point(0, 25);

			using (frmSelectJournalsToSearch frm = new frmSelectJournalsToSearch(this, DictJournals))
			{ frm.ShowDialog(); this.DictJournals = frm.CheckedJournals; }

			ShowHideOccurrences();
			this.GetSelectedJournals();
			sort = LabelsManager.LabelsSortType.None;
			lblSortType_Click(null, null);
		}

		private void frmLabelsManager_Resize(object sender, EventArgs e)
		{
			if (this.Width > this.MinimumSize.Width) { this.Width = this.MinimumSize.Width; };
			ShowHideOccurrences();
		}

		private void AddLabelToUIListbox() { if (txtLabelName.Text.Length > 0) { lstLabels.Items.Add(txtLabelName.Text); } }

		private void btnCancel_Click(object sender, EventArgs e)
		{
			pnlNewLabelName.Visible = false;
		}

		private void btnExitOrphans_Click(object sender, EventArgs e) { lstOccurrences.Items.Clear(); ShowHideOccurrences(); ShowPanel(pnlMain); }

		private void btnOK_Click(object sender, EventArgs e)
		{
			//string sOldLabelName = lstLabels.SelectedItem != null ? lstLabels.SelectedItem.ToString() : string.Empty;
			//bool bEdited = true;
			//this.Cursor = Cursors.WaitCursor;

			//if (Adding)
			//{
			//	AddLabelToUIListbox();
			//	LabelsManager.Save(lstLabels.Items.Cast<String>().ToList());
			//	pnlNewLabelName.Visible = false;
			//	LabelsManager.PopulateLabelsList(null, lstLabels);
			//	lstOccurrences.Items.Clear();
			//	ShowHideOccurrences();
			//	this.Cursor = Cursors.Default;
			//}

			//if (Renaming | Deleting)
			//{
			//	List<Journal> journalsToEdit = EditingSelectedJournals ? Program.AllJournals : new List<Journal>();

			//	if (journalsToEdit.Count == 0) { journalsToEdit.Add(CurrentJournal); } // would be at least 1 if 'All Journals' was clicked

			//	foreach (Journal jrnl in journalsToEdit)
			//	{
			//		SetProgramPINForSelectedJournal(jrnl);

			//		List<JournalEntry> lstEntryHasOldLabel = jrnl.Entries.Where(t => ("," + t.ClearLabels() + ",").Contains("," + sOldLabelName + ",")).ToList();

			//		if (lstEntryHasOldLabel.Count > 0)
			//		{
			//			foreach (JournalEntry je in lstEntryHasOldLabel)
			//			{
			//				bEdited = je.RemoveOrReplaceLabel(txtLabelName.Text, sOldLabelName, Renaming);
			//				if (bEdited) { jrnl.Save(); }
			//			}
			//		}
			//	}

			//	if (bEdited)
			//	{
			//		if (Renaming)
			//		{
			//			if (EditingSelectedJournals) // it was a global change - the old label doesn't exist in any entry in any journal so remove it from the Labels file
			//			{
			//				if (!lstLabels.Items.Contains(txtLabelName.Text))
			//				{
			//					lstLabels.Items.Insert(lstLabels.SelectedIndex, txtLabelName.Text);
			//					lstLabels.Items.RemoveAt(lstLabels.SelectedIndex);
			//				}
			//			}
			//			else { AddLabelToUIListbox(); }    // the old label might exist in other entries, so add the new label only to the Labels file
			//		}
			//		else    // It was a delete. If label exists in any journal, leave in list, otherwise remove from list.
			//		{
			//			//if (LabelsManager.JournalsContainingLabel(txtLabelName.Text).Count == 0)
			//			//{
			//			//	lstLabels.Items.RemoveAt(lstLabels.SelectedIndex);
			//			//	lstOccurrences.Items.Clear();
			//			//	ShowHideOccurrences();
			//			//}
			//		}

			//		SaveLabels();
			//		this.Cursor = Cursors.Default;
			//	}

			//	this.Cursor = Cursors.Default;
			//	ActionTaken = bEdited;
			//	Adding = false;
			//	Deleting = false;
			//	Renaming = false;
			//	txtLabelName.Enabled = true;
			//	txtLabelName.Text = string.Empty;
			//	pnlNewLabelName.Visible = false;
			//	PopulateOccurrences();
			//}
		}

		private void btnPINsOK_Click(object sender, EventArgs e) { ShowPanel(pnlMain); ShowHideOccurrences(); }

		private void btnRemoveSelectedOrphans_Click(object sender, EventArgs e)
		{
			using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Are you sure you want to delete the lables? This action cannot be reversed!", "", this))
			{
				frm.ShowDialog(this);

				//if (frm.Result == frmMessage.ReturnResult.Yes)
				//{ foreach (string lbl in lstOrphanedLabels.SelectedItems) { LabelsManager.DoDelete(lbl, ); } }

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

		private void chkSelectAllOrphans_CheckedChanged(object sender, EventArgs e)
		{
			if (chkSelectAllOrphans.Checked)
			{
				for (int i = 0; i < lstOrphanedLabels.Items.Count; i++) { lstOrphanedLabels.SelectedItems.Add(lstOrphanedLabels.Items[i]); }
			}
			else { lstOrphanedLabels.SelectedItems.Clear(); }
		}

		private async Task DoDelete(string lblName, List<Journal> journalsToEdit, Dictionary<string, string> journalsAndPINs)
		{
			await LabelsManager.DeleteLabel(lblName, journalsToEdit, journalsAndPINs);
			KickLstLabels();
		}

		private List<Journal> GetSelectedJournals()
		{
			SelectedJournals.Clear();
			foreach (KeyValuePair<string, string> kvp in DictJournals) { SelectedJournals.Add(new Journal(kvp.Key).Open()); }
			return SelectedJournals;
		}

		private void KickLstLabels()
		{
			if (lstLabels.SelectedItems.Count == 1)
			{
				var indx = lstLabels.SelectedIndex;
				lstLabels.SelectedIndex = -1;
				lstLabels.SelectedIndex = indx;
			}
		}

		private void lblSortType_Click(object sender, EventArgs e)
		{
			//LabelsManager lm = new LabelsManager();	

			switch (sort)
			{
				case LabelsManager.LabelsSortType.None:
					LabelsManager.PopulateLabelsList(null, lstLabels);
					//Utilities.Labels_PopulateLabelsList(null, lstLabels,
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
				if (DictJournals.Count == 0)
				{
					using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message,
						"No journal is selected for the search.", "No Journal Selected", this))
					{ frm.ShowDialog(); }
					lstLabels.SelectedIndex = -1;
				}
				else
				{
					mnuMoveTop.Visible = true;
					mnuMoveUp.Visible = lstLabels.SelectedIndex > 0;
					mnuMoveDown.Visible = lstLabels.SelectedIndex != lstLabels.Items.Count - 1;
					lstOccurrences.Items.Clear();
					lstEntryObjects.Items.Clear();
					PopulateOccurrences();
					this.FormBorderStyle = FormBorderStyle.Sizable;

				}
			}
		}

		private void lstOccurrences_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				int i = lstOccurrences.SelectedIndex;
				KeyValuePair<Journal, JournalEntry> kvp = (KeyValuePair<Journal, JournalEntry>)lstEntryObjects.Items[i];
				Journal j = kvp.Key;
				JournalEntry je = kvp.Value;
				SetProgramPINForSelectedJournal(j);

				using (frmNewEntry frm = new frmNewEntry(this, j, je))
				{ frm.ShowDialog(); if (frm.saved) { PopulateOccurrences(); } }
			}
			catch (Exception) { }
		}

		private void lstOccurrences_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				lstOccurrences.SelectedIndex = e.Y / 15;
				if (lstOccurrences.SelectedIndex % 3 != 0) { lstOccurrences.SelectedIndex = -1; }
				mnuContextEntries.Visible = lstOccurrences.SelectedIndex != -1;

				if (mnuContextEntries.Visible)
				{
					mnuDelete_OneJournal.Text = string.Format(MnuDelete_OneJournalText, lstOccurrences.SelectedItem.ToString().Replace("in", "from"));
					mnuRename_OneJournal.Text = string.Format(MnuRename_OneJournalText, lstOccurrences.SelectedItem.ToString());
					mnuDelete_AllJournals.Text = DictJournals.Count == Program.AllJournals.Count ? "from all journals" : string.Format(MnuDelete_SelectedJournalaText, DictJournals.Count.ToString());
					mnuRename_AllJournals.Text = DictJournals.Count == Program.AllJournals.Count ? "in all journals" : string.Format(MnuRename_SelectedJournalsText, DictJournals.Count.ToString());
				}
			}
		}

		private void mnuAdd_Click(object sender, EventArgs e)
		{
			Adding = true;
			lblOperation.Text = "Label Name:";
			pnlNewLabelName.Visible = true;
			txtLabelName.Text = string.Empty;
			txtLabelName.Focus();
			this.AcceptButton = btnOK;
		}

		private void mnuAssignPINs_Click(object sender, EventArgs e)
		{
			using (frmSelectJournalsToSearch frm = new frmSelectJournalsToSearch(this, DictJournals))
			{
				frm.ShowDialog();
				this.DictJournals = frm.CheckedJournals;
			}
			GetSelectedJournals();
			this.Size = this.MinimumSize;
			KickLstLabels();
		}

		private void mnuDelete_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
			var deleteOK = false;
			List<Journal> oneJournal = null;
			var editingOneJournal = false;

			editingOneJournal = mnu.Text.ToLower().Contains("only");

			if(editingOneJournal)
			{
				var journalName = lstOccurrences.Text;
				journalName = journalName.Replace("in ", "").Replace(" only", "").Replace("'", "");
				oneJournal = new List<Journal>();
				oneJournal.Add(new Journal(journalName).Open());
			}

			var sMsg = "Do you want to delete the label '" + lstLabels.SelectedItem.ToString() + "' ";
			sMsg += (editingOneJournal ? mnu.Text.Replace("in", "from").Replace(" only", "") : 
				DictJournals.Count == Program.AllJournals.Count ? " from all journals " : " the " + DictJournals.Count.ToString() + " selected journal" 
				+ (DictJournals.Count == 1 && !editingOneJournal ? "" : "s")) + "?";

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, sMsg, "Delete Label?", this))
			{
				frm.ShowDialog();
				deleteOK = frm.Result == frmMessage.ReturnResult.Yes;
			}

			if (deleteOK)
			{
				DoDelete(lstLabels.SelectedItem.ToString(), (oneJournal == null? this.GetSelectedJournals() : oneJournal), DictJournals);
				LabelsManager.PopulateLabelsList(null, lstLabels);
			}
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void mnuFindOrphans_Click(object sender, EventArgs e)
		{
			ShowPanel(pnlOrphanedLabels);
			List<string> lstOrphans = new List<string>();
			lstOrphanedLabels.Items.Clear();

			foreach (string label in LabelsManager.GetLabels_NoFileDate())
			{
				PopulateOccurrences(label);
				if (lstOccurrences.Items.Count == 1) { lstOrphans.Add(label); }
			}

			if (lstOrphans.Count > 0)
			{
				foreach (string lbl in lstOrphans) { lstOrphanedLabels.Items.Add(lbl); }
			}
			else { lstOrphanedLabels.Items.Add("no orphans were found."); }

		}

		private void mnuMoveUp_Click(object sender, EventArgs e)
		{
			string sLbl = lstLabels.SelectedItem.ToString();
			int selIndx = lstLabels.SelectedIndex;
			lstLabels.Items.RemoveAt(selIndx);
			lstLabels.Items.Insert(selIndx - 1, sLbl);
			lstLabels.SelectedIndex = selIndx - 1;
			SaveLabels();
		}

		private void mnuMoveDown_Click(object sender, EventArgs e)
		{
			string sLbl = lstLabels.SelectedItem.ToString();
			int selIndx = lstLabels.SelectedIndex;
			lstLabels.Items.RemoveAt(selIndx);
			lstLabels.Items.Insert(selIndx + 1, sLbl);
			lstLabels.SelectedIndex = selIndx + 1;
			SaveLabels();
		}

		private void mnuRename_Click(object sender, EventArgs e)
		{
			Renaming = true;
			//EditingSelectedJournals = ((ToolStripMenuItem)sender).Text.ToLower().StartsWith("in all");
			lblOperation.Text = "New Label Name:";
			txtLabelName.Text = lstLabels.SelectedItem.ToString();
			pnlNewLabelName.Visible = true;
			txtLabelName.Visible = true;
			txtLabelName.Focus();
			txtLabelName.SelectAll();
			this.AcceptButton = btnOK;
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
				var currentPIN = Program.PIN;

				List<Journal> journalsWithLabel = LabelsManager.JournalsContainingLabel(labelName, DictJournals);

				if (journalsWithLabel.Count > 0)
				{
					foreach (Journal jrnl in journalsWithLabel)
					{
						SetProgramPINForSelectedJournal(jrnl);
						List<JournalEntry> foundLables = jrnl.Entries.Where(t => ("," + t.ClearLabels() + ",").Contains("," + labelName + ",")).ToList();

						if (foundLables.Count > 0)
						{
							lstOccurrences.Items.Add("in '" + jrnl.Name + "'");
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

				if (lstOccurrences.Items.Count == 0) { lstOccurrences.Items.Add("No occurrences found (are you missing a PIN?)"); }

				Program.PIN = currentPIN;
			}
			else { lstOccurrences.Items.Clear(); }

			ShowHideOccurrences();
			this.Cursor = Cursors.Default;
		}

		private async Task SaveLabels() { await LabelsManager.Save(lstLabels.Items.OfType<string>().ToList()); }

		private void SetProgramPINForSelectedJournal(Journal journal) { Program.PIN = DictJournals[journal.Name] == "" ? "12345678" : DictJournals[journal.Name]; }

		private void ShowPanel(Panel panelToShow)
		{
			foreach (Control c in this.Controls) { if (c.GetType() == typeof(Panel)) { c.Visible = false; } }

			if (panelToShow == pnlMain)
			{
				panelToShow.Top = 25;
				//mnuMain.Visible = true;
			}
			//else { mnuMain.Visible = false; }

			panelToShow.Visible = true;
		}

		private void ShowHideOccurrences()
		{
			if (lstOccurrences.Items.Count > 0)
			{ lstLabels.Height = pnlMain.Height - 340; lstOccurrences.Height = pnlMain.Height - 300; lstOccurrences.Visible = true; }
			else { lstLabels.Height = pnlMain.Height - 100; lstOccurrences.Visible = false; }
		}

		private void txtLabelName_TextChanged(object sender, EventArgs e)
		{
			btnOK.Visible = Deleting ? true : !lstLabels.Items.Contains(txtLabelName.Text.Trim());
			lblLabelExists.Visible = !btnOK.Visible;
		}
	}
}