/* Search journal entries.
 * 7/9/22
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmSearch : Form
	{
		private List<JournalEntry> SearchList = null;

		public frmSearch()
		{
		}

		public frmSearch(List<JournalEntry> entriesToSearch)
		{
			InitializeComponent();
			SearchList = entriesToSearch;
			Utilities.PopulateLabelsList(lstLabelsForSearch);
		}

		private void chkUseDateRange_CheckedChanged(object sender, EventArgs e)
		{
			dtFindDate_From.Enabled = chkUseDateRange.Checked;
			dtFindDate_To.Enabled = chkUseDateRange.Checked;
		}

		private void chkUseDate_CheckedChanged(object sender, EventArgs e)
		{
			dtFindDate.Enabled = chkUseDate.Enabled;
		}

		private void searchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// labels
			string labels = string.Empty;
			string[] groups = null;
			List<JournalEntry> foundEntries = new List<JournalEntry>();

			for (int i = 0; i < lstLabelsForSearch.CheckedItems.Count; i++)
			{
				labels += lstLabelsForSearch.CheckedItems[i].ToString() + ",";
			}

			labels = labels.Length > 0 ? labels.Substring(0, labels.Length - 1) : string.Empty;
			groups = labels.Length > 0 ? labels.Split(',') : null;

			foreach (JournalEntry je in SearchList)
			{
				// date
				if (chkUseDate.Checked)
				{
					if (je.Date.ToShortDateString() == dtFindDate.Value.ToShortDateString())
					{
						foundEntries.Add(je);
					}
				}

				if (chkUseDateRange.Checked)
				{
					if (je.Date >= dtFindDate_From.Value && je.Date <= dtFindDate_To.Value)
					{
						foundEntries.Add(je);
					}
				}

				if(groups != null)
				{
					foreach (string group in groups)
					{
						if (je.ClearTags().Contains(group)) { foundEntries.Add(je); }
					}
				}

				if (radBtnAnd.Checked)
				{
					if(txtSearchTitle.Text.Length > 0 & txtSearchText.Text.Length > 0)
					{
						if (je.ClearText().Contains(txtSearchText.Text) & je.ClearTitle().Contains(txtSearchTitle.Text)) { foundEntries.Add(je); }
					}
					else if(txtSearchText.Text.Length > 0) 
					{
						if (je.ClearText().Contains(txtSearchText.Text)) { foundEntries.Add(je); }
					}
					else if (txtSearchTitle.Text.Length > 0)
					{
						if (je.ClearTitle().Contains(txtSearchTitle.Text)) { foundEntries.Add(je); }
					}
				}
				else
				{
					if (txtSearchText.Text.Length > 0) { if (je.ClearText().Contains(txtSearchText.Text)) { foundEntries.Add(je); } }
					if (txtSearchTitle.Text.Length > 0) { if (je.ClearTitle().Contains(txtSearchTitle.Text)) { foundEntries.Add(je); } }
				}

				if (foundEntries.Count > 0)
				{
					Utilities.PopulateEntries(lstFoundEntries, foundEntries);
					lblFoundEntries.Visible = true;
				}
			}
		}
	}
}
