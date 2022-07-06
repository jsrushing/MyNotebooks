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
		private bool firstSelection = true;
		private Journal currentJournal;
		public frmSearch(Journal jrnl)
		{
			InitializeComponent();
			currentJournal = jrnl;
			SearchList = jrnl.Entries;
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

		private void frmSearch_Load(object sender, EventArgs e)
		{ }

		private void lstFoundEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox lb = (ListBox)sender;
			RichTextBox rtb = rtbSelectedEntry_Found;
			lb.SelectedIndexChanged -= new System.EventHandler(this.lstFoundEntries_SelectedIndexChanged);

			JournalEntry currentEntry = Utilities.SelectEntry(rtb, lb, currentJournal, firstSelection);
			firstSelection = false;

			lblSelectionType.Visible = rtb.Text.Length > 0;
			lblSeparator.Visible = rtb.Text.Length > 0;
			Utilities.ResizeListsAndRTBs(lb, rtb, lblSeparator, lblSelectionType, this);
			lb.SelectedIndexChanged += new System.EventHandler(this.lstFoundEntries_SelectedIndexChanged);
		}

		private void lblSeparator_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				lblSeparator.Top += e.Y;
				Utilities.ResizeListsAndRTBs(lstFoundEntries, rtbSelectedEntry_Found, lblSeparator, lblSelectionType, this);
				lstFoundEntries.TopIndex = lstFoundEntries.SelectedIndices[0];
			}
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}
