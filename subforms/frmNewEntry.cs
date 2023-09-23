/* Add a new journal entry
 * 6/15/22
 */
using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryption;
using MyNotebooks.DataAccess;
using MyNotebooks.objects;

namespace MyNotebooks.subforms
{
	public partial class frmNewEntry : Form
	{
		public Entry Entry { get; set; }
		public int ParentNotebookId { get; set; }
		public bool Saved { get; private set; }
		private readonly Notebook CurrentNotebook = null;
		private readonly bool IsEdit = false;
		private int OriginalEntryLength = -1;
		private bool IsDirty = false;
		private string OriginalTitle = string.Empty;
		private string OriginalText_Full = string.Empty;
		private LabelsManager.LabelsSortType Sort = LabelsManager.LabelsSortType.None;
		private readonly string LabelLabelsSelected = "({0} selected)";
		private readonly bool PreserveOriginalText;

		public frmNewEntry(Form parent, Notebook notebook, int parentNotebookId = 0, Entry entry = null, bool disallowOriginalTextEdit = false)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
			CurrentNotebook = notebook;
			ParentNotebookId = parentNotebookId;
			Entry = entry;
			PreserveOriginalText = disallowOriginalTextEdit;
			IsEdit = Entry != null;
		}

		private void frmNewEntry_Load(object sender, EventArgs e)
		{
			OriginalTitle = this.Text;
			Sort = LabelsManager.LabelsSortType.None;
			SortLabels();

			if (this.Entry != null & CurrentNotebook != null)
			{ this.Text = "editing '" + Entry.Title + "' in '" + CurrentNotebook.Name + "'"; }
			else
			{ this.Text = this.IsDirty ? OriginalTitle + "*" : OriginalTitle; }

			pnlEntryDates.Visible = IsEdit;

			if (IsEdit)
			{
				txtNewEntryTitle.Text = Entry.Title;
				lblCreatedOn.Text = this.Entry.CreatedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]);
				lblEditedOn.Text = this.Entry.EditedOn < new DateTime(2000, 1, 1) ? "" : this.Entry.EditedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]);

				if (PreserveOriginalText)
				{
					OriginalText_Full = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Editing"],
						this.Entry.CreatedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]), this.Entry.Title, this.Entry.Text);

					OriginalEntryLength = OriginalText_Full.Length - 1;
					OriginalText_Full = OriginalText_Full.Substring(OriginalText_Full.Length - OriginalEntryLength + 1);
					rtbNewEntry.Text = OriginalText_Full;
					GrayOriginalText();
				}
				else
				{
					rtbNewEntry.Text = Entry.Text;
				}

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

		private void ddlFonts_SelectedIndexChanged(object sender, EventArgs e)
		{
			lblSelectedFont.Font = new Font(ddlFonts.Text, 10);
			lblSelectedFont.Text = lblSelectedFont.Font.Name;
			Application.DoEvents();
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
			if (this.Entry == null)
			{
				using (frmMessage frm = new(frmMessage.OperationType.YesNoQuestion, "You must save the entry before adding labels. Save now?", "Entry Must Be Saved", this))
				{
					frm.ShowDialog();

					if (frm.Result == frmMessage.ReturnResult.Yes)
					{
						Entry newEntry =
							new()
							{
								CreatedBy = Program.User.Id,
								NotebookName = this.CurrentNotebook.Name,
								Title = txtNewEntryTitle.Text,
								Text = rtbNewEntry.Text,
								RTF = rtbNewEntry.Rtf,
								ParentId = this.CurrentNotebook.Id
							};

						newEntry.Id = DbAccess.CRUDNotebookEntry(newEntry).intValue;
						Entry = newEntry;
						SetIsDirty(false);
					}
				}
			}

			if (this.Entry != null)
			{
				using (frmLabelsManager frm = new(this, this.Entry))
				{
					frm.ShowDialog();

					if (frm.ActionTaken)
					{
						LabelsManager.PopulateLabelsList(clbLabels, null, LabelsManager.LabelsSortType.None, this.Entry);
						SetIsDirty();
					}
				}
			}
		}

		private void lblSortType_Click(object sender, EventArgs e) { SortLabels(); }

		private void clbLabels_SelectedIndexChanged(object sender, EventArgs e)
		{
			//lblNumLabelsSelected.Text = string.Format(LabelLabelsSelected, clbLabels.CheckedItems.Count);
			SetIsDirty();
		}

		private void GrayOriginalText()
		{
			rtbNewEntry.SelectionStart = 1;
			rtbNewEntry.SelectionLength = OriginalText_Full.Length + 1;
			rtbNewEntry.SelectionColor = Color.Gray;
			rtbNewEntry.SelectionLength = 0;
			rtbNewEntry.SelectionStart = 0;
		}

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

		private void ModifyFontStyle(FontStyle style)
		{ rtbNewEntry.SelectionFont = new Font(rtbNewEntry.SelectionFont, rtbNewEntry.SelectionFont.Style ^ style); }

		private void rtbNewEntry_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down) { InNoTypeArea(); } }

		private void rtbNewEntry_MouseUp(object sender, MouseEventArgs e) { InNoTypeArea(); }

		private void rtbNewEntry_TextChanged(object sender, EventArgs e) { SetIsDirty(); }

		private async Task SaveEntry()
		{
			if (!lblTitleExists.Visible)
			{
				OperationType opType = OperationType.Create;
				Entry newEntry = new();

				if (this.Entry != null)
				{
					this.Entry.Text = rtbNewEntry.Text.Trim();
					this.Entry.Title = txtNewEntryTitle.Text.Trim();
					this.Entry.Labels = LabelsManager.CheckedLabels_Get(clbLabels);

					// remove any un-checked labelsForSearch (with this entryId) from the Labels table
					var labelsToRemove = string.Empty;

					for (var i = 0; i < clbLabels.Items.Count; i++)
					{
						if (!clbLabels.CheckedItems.Contains(clbLabels.Items[i])) { labelsToRemove += clbLabels.Items[i].ToString() + ","; }
					}

					if (labelsToRemove.Length > 0) { this.Entry.LabelsToRemove = labelsToRemove; opType = OperationType.Update; }
					else
					{
						this.Entry.RTF = rtbNewEntry.Rtf;
						this.Entry.EditedOn = DateTime.Now;
						this.ParentNotebookId = CurrentNotebook != null ? CurrentNotebook.Id : 0;
						opType = OperationType.Update;
					}
				}
				else
				{
					newEntry = new(txtNewEntryTitle.Text.Trim(), rtbNewEntry.Text.Trim(), rtbNewEntry.Rtf,
						LabelsManager.CheckedLabels_Get(clbLabels), CurrentNotebook.Id, CurrentNotebook.Name);

					newEntry.CreatedBy = Program.User.Id;
					this.Entry = newEntry;
				}

				var sqlResult = DbAccess.CRUDNotebookEntry(this.Entry, opType);
				this.Entry.Id = sqlResult.intValue;
				var msg = string.Empty;

				if (sqlResult.intValue < -1)
				{ msg = "A SQL Error occurred (error number " + (sqlResult.intValue * -1).ToString() + ")               "; }
				else if (opType == OperationType.Update && (sqlResult.intValue != -1 & sqlResult.intValue != this.Entry.Id))
				{ msg = "An error occurred. The entry was not updated. " + sqlResult.strValue; }
				//else { this.Entry.Id = sqlResult; }

				if (msg.Length > 0)
				{ using (frmMessage frm = new(frmMessage.OperationType.Message, msg, "Error!", this)) { frm.ShowDialog(); } }
				else
				{
					Saved = true;
					SetIsDirty(false);
				}
			}
		}

		private void SetIsDirty(bool dirty = true)
		{
			var v = CurrentNotebook != null ? CurrentNotebook.Entries.ToArray().Where(e => e.Title == txtNewEntryTitle.Text) : null;
			lblTitleExists.Visible = !IsEdit && v.Any();

			if (!lblTitleExists.Visible)
			{
				if (txtNewEntryTitle.Text.Length > 0 & rtbNewEntry.Text.Length > 0)
				{
					IsDirty = dirty;
					mnuSaveEntry.Enabled = IsDirty;
					mnuSaveAndExit.Enabled = IsDirty;
				}
			}
		}

		private void SortLabels()
		{
			switch (Sort)
			{
				case LabelsManager.LabelsSortType.None:
					LabelsManager.PopulateLabelsList(clbLabels, null, LabelsManager.LabelsSortType.None, this.Entry);
					lblSortType.Text = "sort a-z";
					Sort = LabelsManager.LabelsSortType.Ascending;
					break;
				case LabelsManager.LabelsSortType.Ascending:
					LabelsManager.PopulateLabelsList(clbLabels, null, LabelsManager.LabelsSortType.Descending, this.Entry);
					lblSortType.Text = "sort z-a";
					Sort = LabelsManager.LabelsSortType.Descending;
					break;
				case LabelsManager.LabelsSortType.Descending:
					LabelsManager.PopulateLabelsList(clbLabels, null, LabelsManager.LabelsSortType.Ascending, this.Entry);
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

		private void txtNewEntryTitle_TextChanged(object sender, EventArgs e) { SetIsDirty(); }
	}
}
