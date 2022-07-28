/* Add a new journal entry
 * 6/15/22
 */
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmNewEntry : Form
	{
		public JournalEntry entry = null;
		private bool isEdit = false;
		public bool deleteConfirmed = false;
		private int originalEntryLength = -1;
		private string originalText_Full;
		private string originalText_TextOnly;
		private bool isDirty = false;
		public frmNewEntry(JournalEntry entryToEdit = null)
		{
			InitializeComponent();
			entry = entryToEdit;
			isEdit = entry != null;
		}

		private void Alert(string msg)
		{
			frmMessage frm = new frmMessage(frmMessage.OperationType.Message, msg);
			Utilities.Showform(frm, this);
			frm.ShowDialog();
			this.Show();
		}

		private void frmNewEntry_Load(object sender, EventArgs e)
		{
			Utilities.PopulateLabelsList(lstLabels);

			if (isEdit)
			{
				txtNewEntryTitle.Text = entry.ClearTitle();
				originalText_TextOnly = entry.ClearText();

				rtbNewEntry.Text = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Editing"], entry.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"])
					, entry.ClearTitle(), originalText_TextOnly);

				Utilities.CheckExistingLabels(lstLabels, entry);
				originalEntryLength = rtbNewEntry.Text.Length - 1;
				originalText_Full = rtbNewEntry.Text.Substring(rtbNewEntry.Text.Length - originalEntryLength + 1);
				GrayOriginalText();
				rtbNewEntry.Focus();
				rtbNewEntry.SelectionStart = 0;
				mnuEditOriginalText.Visible = true;
			}

			isDirty = false;
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
			if (isDirty)
			{
				frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Do you want to save your changes?");
				Utilities.Showform(frm, this);

				if(frm.result == frmMessage.ReturnResult.No) { entry = null; }
				else if(frm.result == frmMessage.ReturnResult.Yes)  { mnuSaveEntry_Click(null, null); }

				frm.Close();
				this.Hide();
			}
			else
			{
				this.entry = null;
				this.Hide();
			}
		}

		private void mnuEditOriginalText_Click(object sender, EventArgs e)
		{
			rtbNewEntry.Text = originalText_TextOnly + rtbNewEntry.Text;
			GrayOriginalText();
			mnuEditOriginalText.Enabled = false;
		}

		private void mnuSaveEntry_Click(object sender, EventArgs e)
		{
			if (rtbNewEntry.Text.Length > 0 && txtNewEntryTitle.Text.Length > 0)
			{
				entry = new JournalEntry(txtNewEntryTitle.Text, rtbNewEntry.Text, rtbNewEntry.Rtf, Utilities.GetCheckedLabels(lstLabels), false);
				this.Hide();
			}
			else
			{
				Alert("You must enter both a title and text to save an entry.");
			}
		}

		private void GrayOriginalText()
		{
			rtbNewEntry.SelectionStart = rtbNewEntry.Text.Length - originalText_Full.Length - 1;
			rtbNewEntry.SelectionLength = originalText_Full.Length + 1;
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
			if(inNoType & rtbNewEntry.SelectionLength > 0) { rtbNewEntry.SelectionLength = 0; InNoTypeArea(); } 
		}

		private void rtbNewEntry_KeyUp(object sender, KeyEventArgs e)
		{
			//if(e.KeyCode == Keys.Right || e.KeyCode == Keys.Down) { InNoTypeArea(); }
		}

		private void rtbNewEntry_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down) { InNoTypeArea(); }
		}

		private void rtbNewEntry_MouseUp(object sender, MouseEventArgs e) { InNoTypeArea(); }

		private void lstLabels_SelectedIndexChanged(object sender, EventArgs e) { isDirty = true; }

		private void ModifyFontStyle(FontStyle style)
		{ rtbNewEntry.SelectionFont = new Font(rtbNewEntry.SelectionFont, rtbNewEntry.SelectionFont.Style ^ style); }

		private void ToolsMenuClick(object sender, EventArgs e)
		{
			string btnName = ((ToolStripButton)sender).Name.ToLower();
			FontStyle style = btnName.Contains("bold") ? FontStyle.Bold : btnName.Contains("underline") ? FontStyle.Underline : FontStyle.Italic;
			ModifyFontStyle(style);
		}

		private void txtNewEntryTitle_TextChanged(object sender, EventArgs e) { isDirty = true; }

		private void rtbNewEntry_TextChanged(object sender, EventArgs e) { isDirty = true; }
	}
}
