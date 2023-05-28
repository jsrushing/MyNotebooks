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
		private bool firstSelection = true;
		private List<Journal> journalsToSearch = new List<Journal>();
		private Dictionary<string, string> JournalsWithPINs = new Dictionary<string, string>();
		private Dictionary<string, int> journalBoundaries = new Dictionary<string, int>();
		private List<int> threeSelections = new List<int>();

		struct EntryProperties
		{
			public string title;
			public string text;
			public string displayText;
			public string parentJournalName;
			public string[] synopsis;
		}

		List<EntryProperties> entryProperties = new List<EntryProperties>();

		public frmSearch(Journal jrnl, Form parent)
		{
			InitializeComponent();
			if (jrnl != null)
			{
				journalsToSearch.Add(jrnl);
				JournalsWithPINs.Add(jrnl.Name, Program.PIN);
				lblJournalsToSearch.Text = jrnl.Name;
			}

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
			var journalName = string.Empty;
			var journalPIN = string.Empty;
			var originalPIN = Program.PIN;
			List<JournalEntry> foundEntries = new List<JournalEntry>();
			//var iIndexCtr = 0;
			List<JournalEntry> jeFound = null;

			lstFoundEntries.Items.Clear();

			for (int i = 0; i < lstLabelsForSearch.CheckedItems.Count; i++) { labels += lstLabelsForSearch.CheckedItems[i].ToString() + ","; }

			labels = labels.Length > 0 ? labels.Substring(0, labels.Length - 1) : string.Empty;
			labelsArray = labels.Length > 0 ? labels.Split(',') : null;

			SearchObject so = new SearchObject(chkUseDate, chkUseDateRange, chkMatchCase, dtFindDate,
					dtFindDate_From, dtFindDate_To, radBtnAnd, txtSearchTitle.Text, txtSearchText.Text, labelsArray);

			foreach (KeyValuePair<string, string> kvp in this.JournalsWithPINs)
			{
				Program.PIN = kvp.Value;
				//var v = kvp.Value;

				jeFound = new Journal(kvp.Key).Open().Search(so);
				foundEntries.AddRange(jeFound);

				//foreach (JournalEntry jeEntry in foundEntries)
				//{
				//	var title = jeEntry.Synopsis[0] + " in " + kvp.Key;
				//	jeEntry.Synopsis[0] = title;
				//}

				Utilities.PopulateEntries(lstFoundEntries, foundEntries, "", "", "", false);
				journalBoundaries.Add(kvp.Key, lstFoundEntries.Items.Count);

				//this.SetProps(foundEntries, kvp.Key);

				foundEntries.Clear();
			}

			if (lstFoundEntries.Items.Count == 0)
			{ lstFoundEntries.Items.Add("no matches found"); }
			//else { GetCurrentSelections(); }

			this.Cursor = Cursors.Default;
		}

		private void btnSelectJournals_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();

			using (frmSelectJournalsToSearch frm = new frmSelectJournalsToSearch(this, this.JournalsWithPINs))
			{
				frm.ShowDialog();
				this.JournalsWithPINs = frm.DictJournals;
			}

			if (JournalsWithPINs.Count > 0)
			{
				var displayWidth = this.Width - lblFoundEntries.Left - 25;
				var sectionWidth = displayWidth / JournalsWithPINs.Count;
				var itemToAppend = string.Empty;

				foreach (KeyValuePair<string, string> kvp in JournalsWithPINs)
				{
					itemToAppend = kvp.Key.Length > sectionWidth ? kvp.Key.Substring(0, sectionWidth - 3) + "..., " : kvp.Key + ", ";
					sb.Append(itemToAppend);
				}

			}

			if (sb.ToString().Length > 2) { lblJournalsToSearch.Text = sb.ToString().Substring(0, sb.ToString().Length - 2); }
			else { lblJournalsToSearch.Text = "(no journals selected"; }

		}

		private void chkUseDateRange_CheckedChanged(object sender, EventArgs e)
		{
			dtFindDate_From.Enabled = chkUseDateRange.Checked;
			dtFindDate_To.Enabled = chkUseDateRange.Checked;
		}

		private void chkUseDate_CheckedChanged(object sender, EventArgs e)
		{ dtFindDate.Enabled = chkUseDate.Enabled; }

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
				//selections = (List<int>)lb.SelectedIndices;
				Journal j = GetEntryJournal();
				Program.PIN = JournalsWithPINs.FirstOrDefault(p => p.Key == j.Name).Value;
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

		private void GetCurrentSelections()
		{
			threeSelections.Clear();

			foreach (int i in lstFoundEntries.SelectedIndices)
			{
				threeSelections.Add(i);
			}
		}

		private Journal GetEntryJournal()
		{
			List<int> selected = new List<int>();
			foreach (int i in lstFoundEntries.SelectedIndices) { selected.Add(i); }
			KeyValuePair<string, int> kvp = new KeyValuePair<string, int>();

			if (selected.Count() > 1)
			{	// strip out threeSelections
				selected = selected.Except(threeSelections).ToList();
			}

			kvp = journalBoundaries.FirstOrDefault(p => p.Value > selected[0]);
			//KeyValuePair<string, int> v2 = journalBoundaries.FirstOrDefault(p => p.Value > 0); ;

			//KeyValuePair<string, int> v2 = journalBoundaries.FirstOrDefault(p => p.Value > currentSelections[0]);

			//if (lstFoundEntries.SelectedIndices.Count == 4)
			//{ v2 = journalBoundaries.FirstOrDefault(p => p.Value > lstFoundEntries.SelectedIndices[3]); }
			//else if(lstFoundEntries.SelectedIndices.Count > 0) { v2 = journalBoundaries.FirstOrDefault(p => p.Value > lstFoundEntries.SelectedIndex); }

			return kvp.Key == "" ? null : new Journal(kvp.Key).Open();
		}
	}
}