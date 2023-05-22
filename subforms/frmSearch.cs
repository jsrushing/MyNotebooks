/* Search journal entries.
 * 7/9/22
 *	
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmSearch : Form
	{
		private bool firstSelection = true;
		private List<Journal> journalsToSearch = new List<Journal>();
		private Dictionary<string, string> JournalsWithPINs = new Dictionary<string, string>();

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
			var labels = string.Empty;
			string[] labelsArray;
			var journalName = string.Empty;
			var journalPIN = string.Empty;
			var originalPIN = Program.PIN;
			List<JournalEntry> foundEntries = new List<JournalEntry>();

			lstFoundEntries.Items.Clear();

			for (int i = 0; i < lstLabelsForSearch.CheckedItems.Count; i++) { labels += lstLabelsForSearch.CheckedItems[i].ToString() + ","; }

			labels = labels.Length > 0 ? labels.Substring(0, labels.Length - 1) : string.Empty;
			labelsArray = labels.Length > 0 ? labels.Split(',') : null;

			SearchObject so = new SearchObject(chkUseDate, chkUseDateRange, chkMatchCase, dtFindDate,
					dtFindDate_From, dtFindDate_To, radBtnAnd, txtSearchTitle.Text, txtSearchText.Text, labelsArray); ;

			foreach (KeyValuePair<string, string> kvp in this.JournalsWithPINs)
			{
				Program.PIN = kvp.Value;
				foundEntries.AddRange(new Journal(kvp.Key).Open().Search(so));
			}

			Utilities.PopulateEntries(lstFoundEntries, foundEntries);
			if (lstFoundEntries.Items.Count == 0) { lstFoundEntries.Items.Add("no matches found"); }
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
				lstFoundEntries.TopIndex = lstFoundEntries.SelectedIndices[0];
			}
		}

		private void lstFoundEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox lb = (ListBox)sender;
			RichTextBox rtb = rtbSelectedEntry_Found;
			lb.SelectedIndexChanged -= new System.EventHandler(this.lstFoundEntries_SelectedIndexChanged);
			JournalEntry currentEntry = JournalEntry.Select(rtb, lb, GetEntryJournal(), firstSelection);
			firstSelection = false;
			lblSelectionType.Visible = rtb.Text.Length > 0;
			lblSeparator.Visible = rtb.Text.Length > 0;
			Utilities.ResizeListsAndRTBs(lb, rtb, lblSeparator, lblSelectionType, this);
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

		private Journal GetEntryJournal()
		{
			return new Journal(GetJournalNameFromDisplay());
		}

		private string GetJournalNameFromDisplay()
		{
			string sRtrn = string.Empty;
			int i2 = lstFoundEntries.SelectedIndex;
			while(i2 % 4 != 0) { i2--; }
			sRtrn = i2 > -1 ? lstFoundEntries.Items[i2].ToString() : "";
			return sRtrn;
		}
	}
}