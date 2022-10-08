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
		public Journal journal = null;
		private bool isEdit = false;
		public bool deleteConfirmed = false;
		private int originalEntryLength = -1;
		private string originalText_Full;
		private string originalText_TextOnly;
		private bool isDirty = false;
		private string originalTitle;
		public bool saved = false;
		public bool preserveOriginalText;

		public frmNewEntry(Journal currentJournal, JournalEntry entryToEdit = null)
		{
			InitializeComponent();
			entry = entryToEdit;
			isEdit = entry != null;
			journal = currentJournal;
		}

		private void Alert(string msg)
		{
			frmMessage frm = new frmMessage(frmMessage.OperationType.Message, msg);
			Utilities.Showform(frm, this);
			frm.ShowDialog();
			this.Show();
		}

		private void GrayOriginalText()
		{
			rtbNewEntry.SelectionStart = 1;
			rtbNewEntry.SelectionLength = originalText_Full.Length + 1;
			rtbNewEntry.SelectionColor = Color.Gray;
			rtbNewEntry.SelectionLength = 0;
			rtbNewEntry.SelectionStart = 0;
		}

		private void frmNewEntry_Load(object sender, EventArgs e)
		{
			Utilities.PopulateLabelsList(lstLabels);
			originalTitle = this.Text;
			ddlFonts.DataSource = Program.lstFonts;
			ddlFonts.DisplayMember = "text";

			if (isEdit)
			{
				txtNewEntryTitle.Text = entry.ClearTitle();
				originalText_TextOnly = entry.ClearText();
				
				originalText_Full = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Editing"], entry.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"])
					, entry.ClearTitle(), originalText_TextOnly);

				originalEntryLength = originalText_Full.Length - 1;
				originalText_Full = originalText_Full.Substring(originalText_Full.Length - originalEntryLength + 1);
				rtbNewEntry.Text = originalText_Full;

				if (preserveOriginalText)
				{
					GrayOriginalText();
				}

				Utilities.CheckExistingLabels(lstLabels, entry);
				rtbNewEntry.Focus();
				rtbNewEntry.SelectionStart = 0;
			}

			SetIsDirty(false);
		}

		private void InNoTypeArea(bool clicked = false)
		{
			if (preserveOriginalText)
			{
				int positionToCheck = rtbNewEntry.SelectionStart;
				positionToCheck += rtbNewEntry.SelectionLength;
				bool inNoType = positionToCheck >= rtbNewEntry.Text.Length - originalEntryLength;
				rtbNewEntry.SelectionStart = inNoType ? rtbNewEntry.Text.Length - originalEntryLength + 4 : rtbNewEntry.SelectionStart;
				if (inNoType & rtbNewEntry.SelectionLength > 0) { rtbNewEntry.SelectionLength = 0; InNoTypeArea(); } 
			}
		}

		private void lblManageLabels_Click(object sender, EventArgs e)
		{
			frmManageLabels frm = new frmManageLabels();
			Utilities.Showform(frm, this); // ShowDialog() happens here.
			// labels file is modified as directed on frmManageLabels then flow returns here ...
			Utilities.PopulateLabelsList(lstLabels);
			this.Show();
		}

		private void lstLabels_SelectedIndexChanged(object sender, EventArgs e) { SetIsDirty(true); }

		private void ModifyFontStyle(FontStyle style)
		{ rtbNewEntry.SelectionFont = new Font(rtbNewEntry.SelectionFont, rtbNewEntry.SelectionFont.Style ^ style); }

		private void mnuCancelExit_Click(object sender, EventArgs e)
		{
			if (isDirty)
			{
				frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Do you want to save your changes?");
				Utilities.Showform(frm, this);

				if(frm.result == frmMessage.ReturnResult.No) { entry = null; }
				else if(frm.result == frmMessage.ReturnResult.Yes)  { Save(); }

				frm.Close();
				this.Hide();
			}
			else
			{
				this.entry = null;
				this.Hide();
			}
		}

		private void mnuSaveAndExit_Click(object sender, EventArgs e)
		{
			Save();
			this.Hide();
		}

		private void mnuSaveEntry_Click(object sender, EventArgs e)
		{
			if (rtbNewEntry.Text.Length > 0 && txtNewEntryTitle.Text.Length > 0)
			{
				Save();
			}
			else
			{
				Alert("You must enter both a title and text to save an entry.");
			}
		}

		private void rtbNewEntry_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down) { InNoTypeArea(); }}

		private void rtbNewEntry_MouseUp(object sender, MouseEventArgs e) { InNoTypeArea(); }

		private void rtbNewEntry_TextChanged(object sender, EventArgs e) { SetIsDirty(true); }

		private void Save()
		{
			JournalEntry newEntry = new JournalEntry(txtNewEntryTitle.Text, rtbNewEntry.Text, rtbNewEntry.Rtf, Utilities.GetCheckedLabels(lstLabels), false);

			if(entry == null)
			{
				journal.AddEntry(newEntry);
			}
			else
			{
				journal.ReplaceEntry(entry, newEntry);
			}

			journal.Save();
			entry = newEntry;
			saved = true;
			SetIsDirty(false);
		}

		private void SetIsDirty(bool dirty)
		{
			if(txtNewEntryTitle.Text.Length > 0 & rtbNewEntry.Text.Length > 0)
			{
				isDirty = dirty;
				mnuSaveEntry.Enabled = isDirty;
				mnuSaveAndExit.Enabled = isDirty;
			}

			this.Text = dirty ? originalTitle + "*" : originalTitle;
		}

		private void ToolsMenuClick(object sender, EventArgs e)
		{
			string btnName = ((ToolStripButton)sender).Name.ToLower();
			FontStyle style = btnName.Contains("bold") ? FontStyle.Bold : btnName.Contains("underline") ? FontStyle.Underline : FontStyle.Italic;
			ModifyFontStyle(style);
		}

		private void txtNewEntryTitle_TextChanged(object sender, EventArgs e) { SetIsDirty(true); }

		private void mnuFindTextBox_TextChanged(object sender, EventArgs e)
		{
			// do find operation here
		}

		private void mnuFind_Click(object sender, EventArgs e)
		{
			txtFind.Text = string.Empty;
			txtFind.Focus();
		}

		private void ddlFonts_SelectedIndexChanged(object sender, EventArgs e)
		{
			lblSelectedFont.Font = new Font(ddlFonts.SelectedItem.ToString(), 9);
			lblSelectedFont.Text = lblSelectedFont.Font.Name;
		}

		private void ddlFonts_MouseMove(object sender, MouseEventArgs e)
		{
			string gs = ddlFonts.SelectedText;
		}
	}
}
