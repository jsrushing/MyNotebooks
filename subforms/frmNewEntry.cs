/* Add a new journal entry
 * 6/15/22
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using myJournal.objects;
using System.Configuration;

namespace myJournal.subforms
{
	public partial class frmNewEntry : Form
	{
		public JournalEntry entry = null;
		private bool isEdit = false;
		public bool deleteConfirmed = false;
		private int originalEntryLength = -1;
		private string originalText;

		public frmNewEntry(JournalEntry entryToEdit = null)
		{
			InitializeComponent();
			entry = entryToEdit;
			isEdit = entry != null;
		}

		private void frmNewEntry_Load(object sender, EventArgs e)
		{
			Utilities.PopulateLabelsList(lstLabels);

			if (isEdit)
			{
				txtNewEntryTitle.Text = entry.ClearTitle();
				txtNewEntryTitle.TabStop = false;

				rtbNewEntry.Text = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Editing"], entry.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"])
					, entry.ClearTitle(), entry.ClearText());

				Utilities.CheckExistingLabels(lstLabels, entry);
				originalEntryLength = rtbNewEntry.Text.Length - 1;
				originalText = rtbNewEntry.Text.Substring(rtbNewEntry.Text.Length - originalEntryLength + 2);
				GrayOriginalText();
				rtbNewEntry.Focus();
			}
		}

		private void lblManageLabels_Click(object sender, EventArgs e)
		{
			frmManageLabels frm = new frmManageLabels();
			Utilities.Showform(frm, this);
			this.Show();
			Utilities.PopulateLabelsList(lstLabels);
		}

		private void mnuSaveEntry_Click(object sender, EventArgs e)
		{
			if (rtbNewEntry.Text.Length > 0 && txtNewEntryTitle.Text.Length > 0)
			{
				string labels = string.Empty;

				for (int i = 0; i < lstLabels.CheckedItems.Count; i++)
				{
					labels += lstLabels.CheckedItems[i].ToString() + ",";
				}

				labels = labels.Length > 0 ? labels.Substring(0, labels.Length - 1) : string.Empty;
				entry = new JournalEntry(txtNewEntryTitle.Text, rtbNewEntry.Text, labels, false);
			}
			this.Hide();
		}

		private void mnuCancelExit_Click(object sender, EventArgs e)
		{
			txtNewEntryTitle.Text = string.Empty;
			rtbNewEntry.Text = string.Empty;
			entry = null;
			this.Hide();
		}

		private void rtbNewEntry_Click(object sender, EventArgs e)
		{
			if(rtbNewEntry.SelectionStart >= rtbNewEntry.Text.Length - originalEntryLength) { rtbNewEntry.SelectionStart = 0; }
		}

		private void mnuEditOriginalText_Click(object sender, EventArgs e)
		{
			rtbNewEntry.Text = originalText + System.Environment.NewLine + rtbNewEntry.Text;
			GrayOriginalText();
			mnuEditOriginalText.Enabled = false;
		}

		private void GrayOriginalText()
		{
			rtbNewEntry.SelectionStart = rtbNewEntry.Text.Length - originalText.Length - 1;
			rtbNewEntry.SelectionLength = originalText.Length + 1;
			rtbNewEntry.SelectionColor = Color.Gray;
			rtbNewEntry.SelectionLength = 0;
			rtbNewEntry.SelectionStart = 0;
		}
	}
}
