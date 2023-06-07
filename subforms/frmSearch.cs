/* Search journal entries.
 * 7/9/22
 *	
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using encrypt_decrypt_string;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmSearch : Form
	{
		//private List<Journal> journalsToSearch = new List<Journal>();
		//private Dictionary<string, string> CheckedJournals = new Dictionary<string, string>();
		private Dictionary<string, int> journalBoundaries = new Dictionary<string, int>();
		private List<int> threeSelections = new List<int>();
		private bool IgnoreCheckChange = false;

		public frmSearch(Form parent)
		{
			InitializeComponent();
			//if (jrnl != null)
			//{
			//	journalsToSearch.Add(jrnl);
			//	CheckedJournals.Add(jrnl.Name, Program.PIN);
			//	cbxJournalsToSearch.Text = jrnl.Name;
			//}

			if (Program.DictCheckedJournals.Count == 0)
			{ using (frmSelectJournalsToSearch frm = new frmSelectJournalsToSearch(this)) { frm.ShowDialog(); } }

			foreach (KeyValuePair<string, string> kvp in Program.DictCheckedJournals)
			{ cbxJournalsToSearch.Items.Add(kvp.Key); }

			if (cbxJournalsToSearch.Items.Count == 0) { cbxJournalsToSearch.Text = "(no Journals selected)"; }
			LabelsManager.PopulateLabelsList(lstLabelsForSearch);
			Utilities.SetStartPosition(this, parent);
			dtFindDate.Value = DateTime.Now;
			dtFindDate_From.Value = DateTime.Now.AddDays(-30);
			dtFindDate_To.Value = DateTime.Now;
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			journalBoundaries.Clear();
			var labels = string.Empty;
			string[] labelsArray;
			List<JournalEntry> foundEntries = new List<JournalEntry>();
			List<JournalEntry> jeFound = null;

			lstFoundEntries.Items.Clear();
			for (var i = 0; i < lstLabelsForSearch.CheckedItems.Count; i++) { labels += lstLabelsForSearch.CheckedItems[i].ToString() + ","; }
			labels = labels.Length > 0 ? labels.Substring(0, labels.Length - 1) : string.Empty;
			labelsArray = labels.Length > 0 ? labels.Split(',') : null;

			SearchObject so = new SearchObject(chkUseDate, chkUseDateRange, chkMatchCase, dtFindDate,
					dtFindDate_From, dtFindDate_To, radBtnAnd, txtSearchTitle.Text, txtSearchText.Text, labelsArray);

			foreach (KeyValuePair<string, string> kvp in Program.DictCheckedJournals)	//this.CheckedJournals)
			{
				Program.PIN = kvp.Value;
				jeFound = new Journal(kvp.Key).Open().Search(so);
				foreach (JournalEntry je in jeFound) { je.JournalName = kvp.Key; }
				foundEntries.AddRange(jeFound);
				Utilities.PopulateEntries(lstFoundEntries, foundEntries, "", "", "", false);
				journalBoundaries.Add(kvp.Key, lstFoundEntries.Items.Count);
				foundEntries.Clear();
			}

			if (lstFoundEntries.Items.Count == 0) { lstFoundEntries.Items.Add("no matches found"); }
			this.Cursor = Cursors.Default;
		}

		private void btnSelectJournals_Click(object sender, EventArgs e)
		{
			cbxJournalsToSearch.Items.Clear();

			using (frmSelectJournalsToSearch frm = new frmSelectJournalsToSearch(this))
			{
				frm.ShowDialog();
			}

			if (Program.DictCheckedJournals.Count > 0)
			{
				var sectionWidth = cbxJournalsToSearch.Width;

				foreach (KeyValuePair<string, string> kvp in Program.DictCheckedJournals)
				{
					cbxJournalsToSearch.Items.Add(kvp.Key.Length > sectionWidth ? kvp.Key.Substring(0, sectionWidth - 3) + "..." : kvp.Key);
				}

				cbxJournalsToSearch.SelectedIndex = 0;
			}
			else { cbxJournalsToSearch.Text = "(no Journals selected)"; }

		}

		private void cbxJournalsToSearch_DropDownClosed(object sender, EventArgs e)
		{
			cbxJournalsToSearch.SelectedIndex = 0;
			btnSelectJournals.Focus();
		}

		private void chkUseDate_CheckedChanged(object sender, EventArgs e) { ToggleDateControls(true); }

		private void chkUseDateRange_CheckedChanged(object sender, EventArgs e) { ToggleDateControls(false); }

		private void GetCurrentSelections()
		{
			threeSelections.Clear();
			foreach (int i in lstFoundEntries.SelectedIndices) { threeSelections.Add(i); }
		}

		private Journal GetEntryJournal()
		{
			List<int> selectedIndices = new List<int>();
			KeyValuePair<string, int> kvp = new KeyValuePair<string, int>();
			foreach (int i in lstFoundEntries.SelectedIndices) { selectedIndices.Add(i); }
			if (selectedIndices.Count() > 1) { selectedIndices = selectedIndices.Except(threeSelections).ToList(); }
			kvp = journalBoundaries.FirstOrDefault(p => p.Value > selectedIndices[0]);
			return kvp.Key == "" ? null : new Journal(kvp.Key).Open();
		}

		private void lblSeparator_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				lblSeparator.Top += e.Y;
				Utilities.ResizeListsAndRTBs(lstFoundEntries, rtbSelectedEntry_Found, lblSeparator, lblSelectionType, this);
				if (lstFoundEntries.SelectedIndices.Count > 0)
				{
					lstFoundEntries.TopIndex = lstFoundEntries.SelectedIndices[0];
				}
			}
		}

		private void lstFoundEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox lb = (ListBox)sender;
			RichTextBox rtb = rtbSelectedEntry_Found;

			if (lb.SelectedIndex > -1)
			{
				lb.SelectedIndexChanged -= new System.EventHandler(this.lstFoundEntries_SelectedIndexChanged);
				Journal j = GetEntryJournal();
				Program.PIN = Program.DictCheckedJournals.FirstOrDefault(p => p.Key == j.Name).Value;
				JournalEntry currentEntry = JournalEntry.Select(rtb, lb, j);
				GetCurrentSelections();

				if (currentEntry != null)
				{
					lblSelectionType.Visible = rtb.Text.Length > 0;
					lblSeparator.Visible = rtb.Text.Length > 0;
					Utilities.ResizeListsAndRTBs(lb, rtb, lblSeparator, lblSelectionType, this);
				}
				else { lstFoundEntries.SelectedIndices.Clear(); }
			}

			lb.SelectedIndexChanged += new System.EventHandler(this.lstFoundEntries_SelectedIndexChanged);
		}

		private void mnuClearFields_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < lstLabelsForSearch.Items.Count; i++)
			{
				lstLabelsForSearch.SetItemChecked(i, false);
			}
			txtSearchText.Text = string.Empty;
			txtSearchTitle.Text = string.Empty;
			chkMatchCase.Checked = false;
			radBtnOr.Checked = true;
			chkUseDate.Checked = false;
			chkUseDateRange.Checked = false;
			lstFoundEntries.Items.Clear();
			rtbSelectedEntry_Found.Text = string.Empty;
			lblSeparator.Visible = false;
		}

		private void mnuExit_Click(object sender, EventArgs e) { this.Hide(); }

		private void mnuSelectJournals_Click(object sender, EventArgs e)
		{
			// code to select journals to search - enhancement
		}

		private void ToggleDateControls(bool toggleUseDate)
		{
			if (!IgnoreCheckChange)
			{
				dtFindDate.Enabled = false;
				dtFindDate_From.Enabled = false;
				dtFindDate_To.Enabled = false;

				if (chkUseDate.Checked | chkUseDateRange.Checked)
				{
					if (toggleUseDate)
					{
						dtFindDate.Enabled = true;
						IgnoreCheckChange = true;
						chkUseDateRange.Checked = false;
						IgnoreCheckChange = false;
					}
					else
					{
						dtFindDate_From.Enabled = true;
						dtFindDate_To.Enabled = true;
						IgnoreCheckChange = true;
						chkUseDate.Checked = false;
						IgnoreCheckChange = false;
					}
				}
			}

		}
	}
}