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
		private string MnuDelete_SelectedJournalaText = "from the {0} selected journals";
		//private string MnuRename_OneJournalText = "{0} only";
		//private string MnuRename_SelectedJournalsText = "in the {0} selected journals";
		private List<int> occurenceTitleIndicies = new List<int>();

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

		private async Task Saver() { await LabelsManager.Save(lstLabels.Items.Cast<string>().ToList()); }

		private void btnOK_Click(object sender, EventArgs e) { MenuBtnOk(); }

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

		private List<Journal> GetSelectedJournals()
		{
			SelectedJournals.Clear();
			foreach (KeyValuePair<string, string> kvp in DictJournals) { SelectedJournals.Add(new Journal(kvp.Key).Open()); }
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
					mnuMoveTop.Enabled = true;
					mnuMoveUp.Visible = lstLabels.SelectedIndex > 0;
					mnuMoveDown.Visible = lstLabels.SelectedIndex != lstLabels.Items.Count - 1;
					lstOccurrences.Items.Clear();
					lstEntryObjects.Items.Clear();
					PopulateOccurrences();
					this.FormBorderStyle = FormBorderStyle.Sizable;
				}
			}
		}

		private void lstLabels_MouseUp(object sender, MouseEventArgs e) { lstLabels.SelectedIndex = e.Button == MouseButtons.Right ? e.Y / 15 : lstLabels.SelectedIndex; }

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

				if (!occurenceTitleIndicies.Contains(lstOccurrences.SelectedIndex))
				{ mnuContextEntries.Visible = false; lstOccurrences.SelectedIndex = -1; }
				else
				{
					mnuContextEntries.Visible = true;
					mnuContextDelete.Text = "Delete '" + lstLabels.Text + "'";
					mnuContextRename.Text = "Rename '" + lstLabels.Text + "'";
					mnuDelete_OneJournal.Text = string.Format(MnuDelete_OneJournalText, lstOccurrences.SelectedItem.ToString().Replace("in", "from"));
					//mnuRename_OneJournal.Text = string.Format(MnuRename_OneJournalText, lstOccurrences.SelectedItem.ToString());
					//mnuRename_AllJournals.Text = DictJournals.Count == Program.AllJournals.Count ? "in all journals" : string.Format(MnuRename_SelectedJournalsText, DictJournals.Count.ToString());
					mnuDelete_AllJournals.Text = DictJournals.Count == Program.AllJournals.Count ? "from all journals" : string.Format(MnuDelete_SelectedJournalaText, DictJournals.Count.ToString());

				}
			}
		}

		private async Task MenuBtnOk()
		{
			this.Cursor = Cursors.WaitCursor;

			if (Adding)
			{
				AddLabelToUIListbox();
				await LabelsManager.Save(lstLabels.Items.OfType<string>().ToList());
				pnlNewLabelName.Visible = false;
				LabelsManager.PopulateLabelsList(null, lstLabels);
				lstOccurrences.Items.Clear();
				this.ShowHideOccurrences();
				this.ShowPanel(pnlMain);
			}

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
				DictJournals.Count == Program.AllJournals.Count ? " from all journals " : " the " + DictJournals.Count.ToString() + " selected journal"
				+ (DictJournals.Count == 1 && !editingOneJournal ? "" : "s")) + "?";

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, sMsg, "Delete Label?", this))
			{
				frm.ShowDialog();
				deleteOK = frm.Result == frmMessage.ReturnResult.Yes;
			}

			if (deleteOK)
			{
				var pIndex = lstLabels.SelectedIndex;

				//await DoDelete(lstLabels.SelectedItem.ToString(), (oneJournal == null ? this.GetSelectedJournals() : oneJournal), DictJournals);
				await LabelsManager.DeleteLabel(lstLabels.SelectedItem.ToString(), (oneJournal == null ? this.GetSelectedJournals() : oneJournal), DictJournals, this);
				LabelsManager.PopulateLabelsList(null, lstLabels);
				KickLstLabels(pIndex);
			}
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
			await LabelsManager.Save(lstLabels.Items.OfType<string>().ToList());
		}

		private async Task MenuRename()
		{
			var oldLabelName = lstLabels.Text;
			var newLabelName = string.Empty;

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.InputBox, "What is the new label name?",oldLabelName, this))
			{
				frm.ShowDialog();
				if (frm.Result == frmMessage.ReturnResult.Ok) { newLabelName = frm.EnteredValue; }
			}

			if (newLabelName.Length > 0)
			{
				List<Journal> jrnlsToSearch = GetSelectedJournals();
				//DoRename(oldLabelName, newLabelName, jrnlsToSearch, DictJournals);
				await LabelsManager.RenameLabel(oldLabelName, newLabelName, jrnlsToSearch, DictJournals, this);

				if (jrnlsToSearch.Count != Program.AllJournals.Count)
				{
					string sMsg = "The old label name has been left in the list. To completely remove the old label select all notebooks " +
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

				//DoSave();
				await LabelsManager.Save(lstLabels.Items.OfType<string>().ToList());
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

		private void mnuDelete_Click(object sender, EventArgs e) { this.MenuDelete(sender); }

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

		private void mnuMoveUp_Click(object sender, EventArgs e) { MenuMove(sender); }

		private void mnuMoveDown_Click(object sender, EventArgs e) { MenuMove(sender); }

		private void mnuRename_Click(object sender, EventArgs e) { MenuRename(); }

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
							occurenceTitleIndicies.Add(lstOccurrences.Items.Count - 1);
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