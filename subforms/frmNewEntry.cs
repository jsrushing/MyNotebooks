/* Add a new journal entry
 * 6/15/22
 */
using System;
using System.Configuration;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using myNotebooks.objects;

namespace myNotebooks.subforms
{
	public partial class frmNewEntry : Form
	{
		private Entry		entry				= null;
		private Notebook	currentNotebook		= null;
		private bool		isEdit				= false;
		private int			originalEntryLength = -1;
		private bool		isDirty				= false;
		private string		originalTitle		= string.Empty;
		private string		originalText_Full	= string.Empty;
		private LabelsManager.LabelsSortType sort = LabelsManager.LabelsSortType.None;

		public bool saved { get; private set; }
		//public bool preserveOriginalText { get; set; }
		private bool preserveOriginalText;

		public frmNewEntry(Form parent, Notebook notebook, Entry entryToEdit = null, bool disallowOriginalTextEdit = false)
		{
			InitializeComponent();
			entry = entryToEdit;
			isEdit = entry != null;
			preserveOriginalText = disallowOriginalTextEdit;
			this.currentNotebook = notebook;
			Utilities.SetStartPosition(this, parent);
		}

		private void		ddlFonts_SelectedIndexChanged(object sender, EventArgs e)
		{
			lblSelectedFont.Font = new Font(ddlFonts.Text, 10);
			lblSelectedFont.Text = lblSelectedFont.Font.Name;
			Application.DoEvents();
		}

		private void		frmNewEntry_Load(object sender, EventArgs e)
		{
			originalTitle = this.Text;
			//ddlFonts.DataSource = Program.lstFonts;
			//ddlFonts.DisplayMember = "text";
			sort = LabelsManager.LabelsSortType.None;
			SortLabels();
			lblCreatedOn.Visible = false;
			lblEditedOn.Visible = false;

			if (isEdit)
			{
				txtNewEntryTitle.Text = entry.ClearTitle();
				lblCreatedOn.Visible = true;
				lblEditedOn.Visible = true;

				lblCreatedOn.Text = this.entry.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]);
				lblEditedOn.Text = this.entry.LastEditedOn < new DateTime(2000, 1, 1) ? "" : this.entry.LastEditedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]);

				if (preserveOriginalText)
				{
					originalText_Full = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Editing"],
						this.entry.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]), this.entry.ClearTitle(), this.entry.ClearText());

					originalEntryLength = originalText_Full.Length - 1;
					originalText_Full = originalText_Full.Substring(originalText_Full.Length - originalEntryLength + 1);
					rtbNewEntry.Text = originalText_Full;
					GrayOriginalText();
				}
				else
				{
					rtbNewEntry.Text = entry.ClearText();
				}

				LabelsManager.CheckedLabels_Set(clbLabels, entry);
				rtbNewEntry.Focus();
				rtbNewEntry.SelectionStart = 0;
			}

			SetIsDirty(false);
		}

		private void		frmNewEntry_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			mnuCancelExit_Click(null, null);
		}

		private void		GrayOriginalText()
		{
			rtbNewEntry.SelectionStart = 1;
			rtbNewEntry.SelectionLength = originalText_Full.Length + 1;
			rtbNewEntry.SelectionColor = Color.Gray;
			rtbNewEntry.SelectionLength = 0;
			rtbNewEntry.SelectionStart = 0;
		}

		private void		InNoTypeArea(bool clicked = false)
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

		private void		lblManageLabels_Click(object sender, EventArgs e)
		{
			using (frmLabelsManager frm = new frmLabelsManager(this, false, this.currentNotebook)) { frm.ShowDialog(); }
			LabelsManager.PopulateLabelsList(clbLabels);
		}

		private void		lblSortType_Click(object sender, EventArgs e) { SortLabels(); }

		private void		lstLabels_SelectedIndexChanged(object sender, EventArgs e) { SetIsDirty(true); }

		private void		ModifyFontStyle(FontStyle style)
		{ rtbNewEntry.SelectionFont = new Font(rtbNewEntry.SelectionFont, rtbNewEntry.SelectionFont.Style ^ style); }

		private async void	mnuCancelExit_Click(object sender, EventArgs e)
		{
			if (isDirty)
			{
				using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Do you want to save your changes?", "", this))
				{
					frm.ShowDialog(this);
					if (frm.Result == frmMessage.ReturnResult.No) { entry = null; }
					else if (frm.Result == frmMessage.ReturnResult.Yes) { await SaveEntry(); }
				}
			}
			else
			{
				this.entry = null;
			}

			this.Hide();
		}

		private void		mnuFindTextBox_TextChanged(object sender, EventArgs e)
		{
			// do find operation here
		}

		private void		mnuFind_Click(object sender, EventArgs e)
		{
			txtFind.Text = string.Empty;
			txtFind.Focus();
		}

		private async void	mnuSaveAndExit_Click(object sender, EventArgs e)
		{
			await SaveEntry();
			this.Hide();
		}

		private async void	mnuSaveEntry_Click(object sender, EventArgs e)
		{
			if (rtbNewEntry.Text.Length > 0 && txtNewEntryTitle.Text.Length > 0 && isDirty)
			{
				if (currentNotebook.Entries.Count == 1 & rtbNewEntry.Text.IndexOf(" ") > 49)
				{
					using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message,
						"Sorry, but because of the way we validate PIN's the 1st entry can't start with a single word longer than 50 characters.")) { frm.ShowDialog(); }
				}
				else { await SaveEntry(); }
			}
			else
			{
				using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message,
					"You must enter both a title and text to save an entry.", "", this)) { frm.ShowDialog(this); }
			}
		}

		private void		rtbNewEntry_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down) { InNoTypeArea(); } }

		private void		rtbNewEntry_MouseUp(object sender, MouseEventArgs e) { InNoTypeArea(); }

		private void		rtbNewEntry_TextChanged(object sender, EventArgs e) { SetIsDirty(true); }

		private async Task	SaveEntry()
		{
			// Test title for a date surrounded by parentheses, which interferes with parsing the entry's date when necessary.
			var openParen = txtNewEntryTitle.Text.IndexOf("(");
			var closeParen = txtNewEntryTitle.Text.IndexOf(")");
			var possibleDate = string.Empty;
			var processEntry = true;

			if (openParen > -1 && openParen - closeParen == 17)
			{
				possibleDate = txtNewEntryTitle.Text.Substring(openParen + 1, closeParen - openParen);
				DateTime.TryParse(possibleDate, out DateTime date);

				if (date > DateTime.MinValue)
				{
					var sMsg = "Sorry, entry titles may not contain a date and time, formatted as you have, surrounded by parentheses. Edit the title accordingly.";
					using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, sMsg, "Improperly Contstructed Title")) { ShowDialog(frm); }
					processEntry = false;
				}
			}

			//var possibleDate = string.Empty;
			//var processEntry = true;

			//while (openParen < closeParen & closeParen - openParen == 17 & openParen > -1 & closeParen > -1)
			//{
			//	possibleDate = title.Substring(openParen + 1, closeParen - openParen);
			//	DateTime.TryParse(possibleDate, out DateTime date);

			//	if (date > DateTime.MinValue)
			//	{ openParen = closeParen + 1; }
			//	else
			//	{
			//		var sMsg = "Sorry, entry titles may not contain a date and time, formatted as you have, surrounded by parentheses. Edit the title accordingly.";
			//		using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, sMsg, "Improperly Contstructed Title")) { ShowDialog(frm); }
			//		processEntry = false;
			//		break;
			//	}

			//	openParen = title.IndexOf('(', closeParen + 1);
			//	closeParen = title.IndexOf(")", openParen + 1);
			//}

			if (processEntry)
			{
				var title = Utilities.GetTitleAndDate(txtNewEntryTitle.Text)[0];
				Entry newEntry = new Entry(txtNewEntryTitle.Text.Trim(), rtbNewEntry.Text.Trim(), rtbNewEntry.Rtf, LabelsManager.CheckedLabels_Get(clbLabels), currentNotebook.Name);
				if (entry == null) { currentNotebook.AddEntry(newEntry); } else { currentNotebook.ReplaceEntry(entry, newEntry); }
				entry = newEntry;
				saved = true;
				SetIsDirty(false);
				await currentNotebook.Save();
			}
		}

		private void		SetIsDirty(bool dirty)
		{
			if (txtNewEntryTitle.Text.Length > 0 & rtbNewEntry.Text.Length > 0)
			{
				isDirty = dirty;
				mnuSaveEntry.Enabled = isDirty;
				mnuSaveAndExit.Enabled = isDirty;
			}

			if (this.entry != null & currentNotebook != null)
			{
				this.Text = "editing '" + entry.ClearTitle() + "' in '" + currentNotebook.Name + "'";
			}
			else
			{
				this.Text = dirty ? originalTitle + "*" : originalTitle;
			}
		}

		private void		SortLabels()
		{
			switch (sort)
			{
				case LabelsManager.LabelsSortType.None:
					LabelsManager.PopulateLabelsList(clbLabels, null, LabelsManager.LabelsSortType.None);
					lblSortType.Text = "sort A-Z";
					sort = LabelsManager.LabelsSortType.Ascending;
					break;
				case LabelsManager.LabelsSortType.Ascending:
					LabelsManager.PopulateLabelsList(clbLabels, null, LabelsManager.LabelsSortType.Descending);
					lblSortType.Text = "sort Z-A";
					sort = LabelsManager.LabelsSortType.Descending;
					break;
				case LabelsManager.LabelsSortType.Descending:
					LabelsManager.PopulateLabelsList(clbLabels, null, LabelsManager.LabelsSortType.Ascending);
					lblSortType.Text = "unsorted";
					sort = LabelsManager.LabelsSortType.None;
					break;
			}
		}

		private void		ToolsMenuClick(object sender, EventArgs e)
		{
			string btnName = ((ToolStripButton)sender).Name.ToLower();
			FontStyle style = btnName.Contains("bold") ? FontStyle.Bold : btnName.Contains("underline") ? FontStyle.Underline : FontStyle.Italic;
			ModifyFontStyle(style);
		}

		private void		txtNewEntryTitle_TextChanged(object sender, EventArgs e) { SetIsDirty(true); }
	}
}
