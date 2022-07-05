using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
		}

		private void lblFindEntries_Click(object sender, EventArgs e)
		{
			// search by date(s)
			
			// search by tags

			// search by title

			// search by text

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
	}
}
