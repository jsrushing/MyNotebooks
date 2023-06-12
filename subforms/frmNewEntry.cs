/* Add a new journal entry
 * 6/15/22
 */
using System;
using System.Configuration;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using myNotebooks.objects;
using Org.BouncyCastle.Asn1.Sec;

namespace myNotebooks.subforms
{
	public partial class frmNewEntry : Form
	{
		private Entry			entry				= null;
		private Notebook		currentNotebook		= null;
		private bool			isEdit				= false;
		private int				originalEntryLength = -1;
		private bool			isDirty				= false;
		private string			originalTitle;
		private string			originalText_Full;
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

		private void ddlFonts_SelectedIndexChanged(object sender, EventArgs e)
		{
			lblSelectedFont.Font = new Font(ddlFonts.Text, 10);
			lblSelectedFont.Text = lblSelectedFont.Font.Name;
			Application.DoEvents();
		}

		private void frmNewEntry_Load(object sender, EventArgs e)
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

		private void frmNewEntry_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			mnuCancelExit_Click(null, null);
		}

		private void GrayOriginalText()
		{
			rtbNewEntry.SelectionStart = 1;
			rtbNewEntry.SelectionLength = originalText_Full.Length + 1;
			rtbNewEntry.SelectionColor = Color.Gray;
			rtbNewEntry.SelectionLength = 0;
			rtbNewEntry.SelectionStart = 0;
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
			using (frmLabelsManager frm = new frmLabelsManager(this, false, this.currentNotebook)) { frm.ShowDialog(); }
			LabelsManager.PopulateLabelsList(clbLabels);
		}

		private void lblSortType_Click(object sender, EventArgs e) { SortLabels(); }

		private void lstLabels_SelectedIndexChanged(object sender, EventArgs e) { SetIsDirty(true); }

		private void ModifyFontStyle(FontStyle style)
		{ rtbNewEntry.SelectionFont = new Font(rtbNewEntry.SelectionFont, rtbNewEntry.SelectionFont.Style ^ style); }

		private void mnuCancelExit_Click(object sender, EventArgs e)
		{
			if (isDirty)
			{
				using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Do you want to save your changes?", "", this))
				{
					frm.ShowDialog(this);
					if (frm.Result == frmMessage.ReturnResult.No) { entry = null; }
					else if (frm.Result == frmMessage.ReturnResult.Yes) { SaveEntry(); }
				}
			}
			else
			{
				this.entry = null;
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

		private void mnuSaveAndExit_Click(object sender, EventArgs e)
		{
			SaveEntry();
			this.Hide();
		}

		private void mnuSaveEntry_Click(object sender, EventArgs e)
		{
			if (rtbNewEntry.Text.Length > 0 && txtNewEntryTitle.Text.Length > 0 && isDirty)
			{
				SaveEntry();
			}
			else
			{
				using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "You must enter both a title and text to save an entry.", "", this)) { frm.ShowDialog(this); }
			}
		}

		private void rtbNewEntry_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down) { InNoTypeArea(); } }

		private void rtbNewEntry_MouseUp(object sender, MouseEventArgs e) { InNoTypeArea(); }

		private void rtbNewEntry_TextChanged(object sender, EventArgs e) { SetIsDirty(true); }

		private async Task SaveEntry()
		{
			//string[] DateAndTitle = Utilities.GetTitleAndDate(txtNewEntryTitle.Text);

			//if (DateAndTitle[0] != null && DateAndTitle[1] != null && DateAndTitle[0].Length > 0 && DateAndTitle[1].Length > 0)
			//{
				Entry newEntry = new Entry(txtNewEntryTitle.Text.Trim(), rtbNewEntry.Text.Trim(), rtbNewEntry.Rtf, LabelsManager.CheckedLabels_Get(clbLabels), currentNotebook.Name, false);
				if (entry == null) { currentNotebook.AddEntry(newEntry); } else { currentNotebook.ReplaceEntry(entry, newEntry); }
				entry = newEntry;
				saved = true;
				SetIsDirty(false);
				await currentNotebook.Save();
			//}
			//else
			//{
			//	var sMsg = "Entry titles may not contain a date and time surrounded by parentheses. Edit the title accordingly.";
			//	using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, sMsg, "Improperly Contstructed Title")) { ShowDialog(frm); }
			//}
		}

		private void SetIsDirty(bool dirty)
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

		private void SortLabels()
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

		private void ToolsMenuClick(object sender, EventArgs e)
		{
			string btnName = ((ToolStripButton)sender).Name.ToLower();
			FontStyle style = btnName.Contains("bold") ? FontStyle.Bold : btnName.Contains("underline") ? FontStyle.Underline : FontStyle.Italic;
			ModifyFontStyle(style);
		}

		private void txtNewEntryTitle_TextChanged(object sender, EventArgs e) { SetIsDirty(true); }
	}
}
