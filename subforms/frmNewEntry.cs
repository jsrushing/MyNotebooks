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
				originalText = rtbNewEntry.Text.Substring(rtbNewEntry.Text.Length - originalEntryLength + 1);
				GrayOriginalText();
				rtbNewEntry.Focus();
				mnuEditOriginalText.Visible = true;
			}
		}

		private void lblManageLabels_Click(object sender, EventArgs e)
		{
			frmManageLabels frm = new frmManageLabels();
			Utilities.Showform(frm, this);
			this.Show();
			Utilities.PopulateLabelsList(lstLabels);
		}

		private void mnuCancelExit_Click(object sender, EventArgs e)
		{
			if(txtNewEntryTitle.Text.Length > 0 | rtbNewEntry.Text.Length > 0)
			{
				frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Do you want to save your changes?");
				Utilities.Showform(frm, this);
				if(frm.result == frmMessage.ReturnResult.No)
				{
					entry = null;
					frm.Close();
					this.Hide();
				}
				else if(frm.result == frmMessage.ReturnResult.Yes)
				{
					mnuSaveEntry_Click(null, null);
				}
				else
				{
					frm.Close();
					this.Show();
				}
			}
		}

		private void mnuEditOriginalText_Click(object sender, EventArgs e)
		{
			rtbNewEntry.Text = originalText + System.Environment.NewLine + rtbNewEntry.Text;
			GrayOriginalText();
			mnuEditOriginalText.Enabled = false;
		}

		private void mnuSaveEntry_Click(object sender, EventArgs e)
		{
			if (rtbNewEntry.Text.Length > 0 && txtNewEntryTitle.Text.Length > 0)
			{
				entry = new JournalEntry(txtNewEntryTitle.Text, rtbNewEntry.Text, Utilities.GetCheckedLabels(lstLabels), false);
				this.Hide();
			}
			else
			{
				frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "You must enter both a title and text to save an entry.");
				Utilities.Showform(frm, this);
				frm.Close();
				this.Show();
			}
		}

		private void GrayOriginalText()
		{
			rtbNewEntry.SelectionStart = rtbNewEntry.Text.Length - originalText.Length - 1;
			rtbNewEntry.SelectionLength = originalText.Length + 1;
			rtbNewEntry.SelectionColor = Color.Gray;
			rtbNewEntry.SelectionLength = 0;
			rtbNewEntry.SelectionStart = 0;
		}

		private void InNoTypeArea(bool clicked = false)
		{
			int positionToCheck = rtbNewEntry.SelectionStart;
			positionToCheck += rtbNewEntry.SelectionLength;
			bool inNoType = positionToCheck >= rtbNewEntry.Text.Length - originalEntryLength;
			rtbNewEntry.SelectionStart = inNoType ? rtbNewEntry.Text.Length - originalEntryLength - 1 : rtbNewEntry.SelectionStart;
			if(inNoType & rtbNewEntry.SelectionLength > 0) { rtbNewEntry.SelectionLength = 0; } 
		}

		private void rtbNewEntry_KeyUp(object sender, KeyEventArgs e) { if(e.KeyCode == Keys.Down || e.KeyCode == Keys.Right) { InNoTypeArea(); }}

		private void rtbNewEntry_MouseUp(object sender, MouseEventArgs e) { InNoTypeArea(); }

		private void lstLabels_SelectedIndexChanged(object sender, EventArgs e) { lstLabels.SelectedIndices.Clear(); }
	}
}
