/* Search journal entries.
 * 7/9/22
 *	
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmSearch : Form
	{
		private bool firstSelection = true;
		private List<Journal> journalsToSearch = new List<Journal>();

		public frmSearch(Journal jrnl, Form parent)
		{
			InitializeComponent();
			journalsToSearch.Add(jrnl);
			LabelsManager.PopulateLabelsList(lstLabelsForSearch);
			//Utilities.Labels_PopulateLabelsList(lstLabelsForSearch);
			Utilities.SetStartPosition(this, parent);
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
			Journal jrnlRtrn = new Journal(journalsToSearch[0].Name);
			if (journalsToSearch.Count == 1) { jrnlRtrn = jrnlRtrn.Open(); }
			else { jrnlRtrn = new Journal(GetJournalNameFromDisplay()); }
			return jrnlRtrn;
		}

		private string GetJournalNameFromDisplay()
		{
			string sRtrn = string.Empty;
			int i2 = lstFoundEntries.SelectedIndex;
			while (!lstFoundEntries.Items[i2].ToString().ToLower().StartsWith("journal") & i2 != -1) { i2--; }
			sRtrn = i2 > -1 ? lstFoundEntries.Items[i2].ToString() : "";
			return sRtrn;
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			string labels = string.Empty;
			string[] labelsArray = null;

			lstFoundEntries.Items.Clear();

			for (int i = 0; i < lstLabelsForSearch.CheckedItems.Count; i++) { labels += lstLabelsForSearch.CheckedItems[i].ToString() + ","; }

			labels = labels.Length > 0 ? labels.Substring(0, labels.Length - 1) : string.Empty;
			labelsArray = labels.Length > 0 ? labels.Split(',') : null;

			foreach (Journal j in journalsToSearch)
			{
				SearchObject so = new SearchObject(chkUseDate, chkUseDateRange, chkMatchCase, dtFindDate, 
					dtFindDate_From, dtFindDate_To, radBtnAnd, txtSearchTitle.Text, txtSearchText.Text, labelsArray);
				List<JournalEntry> foundEntries = j.Search(so);
				Utilities.PopulateEntries(lstFoundEntries, foundEntries, "", "", false);
			}

			if (lstFoundEntries.Items.Count == 0) { lstFoundEntries.Items.Add("no matches found"); }
		}
	}
}