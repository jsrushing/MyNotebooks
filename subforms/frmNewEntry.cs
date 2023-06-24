/* Add a new journal entry
 * 6/15/22
 */
using System;
using System.Configuration;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryption;
using myNotebooks.objects;

namespace myNotebooks.subforms
{
	public partial class frmNewEntry : Form
	{
		public Entry Entry { get; set; }
		private Notebook CurrentNotebook = null;
		private bool IsEdit = false;
		private int OriginalEntryLength = -1;
		private bool IsDirty = false;
		private string OriginalTitle = string.Empty;
		private string OriginalText_Full = string.Empty;
		private LabelsManager.LabelsSortType Sort = LabelsManager.LabelsSortType.None;
		private string LabelLabelsSelected = "({0} selected)";

		public bool Saved { get; private set; }
		private bool PreserveOriginalText;

		public frmNewEntry(Form parent, Notebook notebook, Entry entryToEdit = null, bool disallowOriginalTextEdit = false)
		{
			InitializeComponent();
			Entry					= entryToEdit;
			IsEdit					= Entry != null;
			PreserveOriginalText	= disallowOriginalTextEdit;
			CurrentNotebook			= notebook;
			Utilities.SetStartPosition(this, parent);
		}

		private void ddlFonts_SelectedIndexChanged(object sender, EventArgs e)
		{
			lblSelectedFont.Font = new Font(ddlFonts.Text, 10);
			lblSelectedFont.Text = lblSelectedFont.Font.Name;
			Application.DoEvents();
		}

		private void frmNewEntry_Load(object sender, EventArgs e)
		{
			OriginalTitle = this.Text;
			//ddlFonts.DataSource = Program.lstFonts;
			//ddlFonts.DisplayMember = "text";
			Sort = LabelsManager.LabelsSortType.None;
			SortLabels();
			lblCreatedOn.Visible = false;
			lblEditedOn.Visible = false;

			if (IsEdit)
			{
				txtNewEntryTitle.Text = Entry.ClearTitle();
				lblCreatedOn.Visible = true;
				lblEditedOn.Visible = true;

				lblCreatedOn.Text = this.Entry.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]);
				lblEditedOn.Text = this.Entry.LastEditedOn < new DateTime(2000, 1, 1) ? "" : this.Entry.LastEditedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]);

				if (PreserveOriginalText)
				{
					OriginalText_Full = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Editing"],
						this.Entry.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]), this.Entry.ClearTitle(), this.Entry.ClearText());

					OriginalEntryLength = OriginalText_Full.Length - 1;
					OriginalText_Full = OriginalText_Full.Substring(OriginalText_Full.Length - OriginalEntryLength + 1);
					rtbNewEntry.Text = OriginalText_Full;
					GrayOriginalText();
				}
				else
				{
					rtbNewEntry.Text = Entry.ClearText();
				}

				LabelsManager.CheckedLabels_Set(clbLabels, Entry);
				lblNumLabelsSelected.Text = string.Format(LabelLabelsSelected, clbLabels.CheckedItems.Count);
				rtbNewEntry.Focus();
				rtbNewEntry.SelectionStart = 0;
			}

			SetIsDirty(false);
		}

		private void frmNewEntry_FormClosing(object sender, FormClosingEventArgs e)
		{
			//	e.Cancel = true;
			//	mnuCancelExit_Click(null, null);
		}

		private void GrayOriginalText()
		{
			rtbNewEntry.SelectionStart = 1;
			rtbNewEntry.SelectionLength = OriginalText_Full.Length + 1;
			rtbNewEntry.SelectionColor = Color.Gray;
			rtbNewEntry.SelectionLength = 0;
			rtbNewEntry.SelectionStart = 0;
		}

		private void InNoTypeArea(bool clicked = false)
		{
			if (PreserveOriginalText)
			{
				int positionToCheck = rtbNewEntry.SelectionStart;
				positionToCheck += rtbNewEntry.SelectionLength;
				bool inNoType = positionToCheck >= rtbNewEntry.Text.Length - OriginalEntryLength;
				rtbNewEntry.SelectionStart = inNoType ? rtbNewEntry.Text.Length - OriginalEntryLength + 4 : rtbNewEntry.SelectionStart;
				if (inNoType & rtbNewEntry.SelectionLength > 0) { rtbNewEntry.SelectionLength = 0; InNoTypeArea(); }
			}
		}

		private void lblManageLabels_Click(object sender, EventArgs e)
		{
			using (frmLabelsManager frm = new frmLabelsManager(this, false, this.CurrentNotebook)) { frm.ShowDialog(); }
			LabelsManager.PopulateLabelsList(clbLabels);
		}

		private void lblSortType_Click(object sender, EventArgs e) { SortLabels(); }

		private void lstLabels_SelectedIndexChanged(object sender, EventArgs e) 
		{
			lblNumLabelsSelected.Text = string.Format(LabelLabelsSelected, clbLabels.CheckedItems.Count);
			SetIsDirty(true); 
		}

		private void ModifyFontStyle(FontStyle style)
		{ rtbNewEntry.SelectionFont = new Font(rtbNewEntry.SelectionFont, rtbNewEntry.SelectionFont.Style ^ style); }

		private async void mnuCancelExit_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				using frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Do you want to save your changes?", "", this);
				frm.ShowDialog(this);
				if (frm.Result == frmMessage.ReturnResult.No) { Entry = null; }
				else if (frm.Result == frmMessage.ReturnResult.Yes) { await SaveEntry(); }
			}
			else
			{
				this.Entry = null;
			}

			this.Hide();
		}

		private void mnuFindTextBox_TextChanged(object sender, EventArgs e)
		{
			// do find operation here
		}

		private void mnuFind_Click(object sender, EventArgs e)
		{
			txtFind.Text = string.Empty;
			txtFind.Focus();
		}

		private async void mnuSaveAndExit_Click(object sender, EventArgs e)
		{
			await SaveEntry();
			this.Hide();
		}

		private async void mnuSaveEntry_Click(object sender, EventArgs e)
		{
			if (rtbNewEntry.Text.Length > 0 && txtNewEntryTitle.Text.Length > 0 && IsDirty)
			{
				if (CurrentNotebook.Entries.Count == 1 & rtbNewEntry.Text.IndexOf(" ") > 49)
				{   // Bad PINs are detected by checking that the decrypted text in the 0th notebook doesn't start w/ a word 50 chars long. See frmMain.btnLoadNotebook_Click().
					using frmMessage frm = new frmMessage(frmMessage.OperationType.Message,
						"Sorry, but for security reasons the very 1st entry in a notebook can't start with a single word longer than 50 characters.");
					frm.ShowDialog();
				}
				else { await SaveEntry(); }
			}
			else
			{
				using frmMessage frm = new frmMessage(frmMessage.OperationType.Message,
					"You must enter both a title and text to save an entry.", "", this);
				frm.ShowDialog(this);
			}
		}

		private void rtbNewEntry_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down) { InNoTypeArea(); } }

		private void rtbNewEntry_MouseUp(object sender, MouseEventArgs e) { InNoTypeArea(); }

		private void rtbNewEntry_TextChanged(object sender, EventArgs e) { SetIsDirty(true); }

		private async Task SaveEntry()
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

			if (processEntry)
			{
				if(this.Entry != null)
				{
					this.Entry.Text = rtbNewEntry.Text.Trim();  //  EncryptDecrypt.Encrypt(rtbNewEntry.Text.Trim());
					this.Entry.Title = txtNewEntryTitle.Text.Trim();    // EncryptDecrypt.Encrypt(txtNewEntryTitle.Text.Trim());
					this.Entry.Labels = LabelsManager.CheckedLabels_Get(clbLabels);
					// can't set RTF ... fix it
					Entry.LastEditedOn = DateTime.Now;
				}
				else
				{
					Entry newEntry = new Entry(txtNewEntryTitle.Text.Trim(), rtbNewEntry.Text.Trim(), rtbNewEntry.Rtf, LabelsManager.CheckedLabels_Get(clbLabels), CurrentNotebook.Name);
					if (Entry == null) { CurrentNotebook.AddEntry(newEntry); } else { CurrentNotebook.ReplaceEntry(Entry, newEntry); }
					Entry = newEntry;
				}

				Saved = true;
				SetIsDirty(false);
			}
		}

		private void SetIsDirty(bool dirty)
		{
			if (txtNewEntryTitle.Text.Length > 0 & rtbNewEntry.Text.Length > 0)
			{
				IsDirty = dirty;
				mnuSaveEntry.Enabled = IsDirty;
				mnuSaveAndExit.Enabled = IsDirty;
			}

			if (this.Entry != null & CurrentNotebook != null)
			{
				this.Text = "editing '" + Entry.ClearTitle() + "' in '" + CurrentNotebook.Name + "'";
			}
			else
			{
				this.Text = dirty ? OriginalTitle + "*" : OriginalTitle;
			}
		}

		private void SortLabels()
		{
			switch (Sort)
			{
				case LabelsManager.LabelsSortType.None:
					LabelsManager.PopulateLabelsList(clbLabels, null, LabelsManager.LabelsSortType.None);
					lblSortType.Text = "sort A-Z";
					Sort = LabelsManager.LabelsSortType.Ascending;
					break;
				case LabelsManager.LabelsSortType.Ascending:
					LabelsManager.PopulateLabelsList(clbLabels, null, LabelsManager.LabelsSortType.Descending);
					lblSortType.Text = "sort Z-A";
					Sort = LabelsManager.LabelsSortType.Descending;
					break;
				case LabelsManager.LabelsSortType.Descending:
					LabelsManager.PopulateLabelsList(clbLabels, null, LabelsManager.LabelsSortType.Ascending);
					lblSortType.Text = "unsorted";
					Sort = LabelsManager.LabelsSortType.None;
					break;
			}
		}

		private void ToolsMenuClick(object sender, EventArgs e)
		{
			string btnName = ((ToolStripButton)sender).Name.ToLower();
			FontStyle style = btnName.Contains("bold") ? FontStyle.Bold : btnName.Contains("underline") ? FontStyle.Underline : FontStyle.Italic;
			ModifyFontStyle(style);
		}

		private void txtNewEntryTitle_TextChanged(object sender, EventArgs e) { SetIsDirty(true); }
	}
}
