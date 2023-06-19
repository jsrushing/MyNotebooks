/* Search journal entries.
 * 7/9/22
 *	
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using myNotebooks.objects;

namespace myNotebooks.subforms
{
	public partial class frmSearch : Form
	{
		private Dictionary<string, int> journalBoundaries = new Dictionary<string, int>();
		private List<int> threeSelections = new List<int>();
		private bool IgnoreCheckChange = false;
		private List<Entry> FoundEntries = new List<Entry>();

		public frmSearch(Form parent)
		{
			InitializeComponent();

			if (Program.DictCheckedNotebooks.Count == 0)
			{ using (frmSelectNotebooksToSearch frm = new frmSelectNotebooksToSearch(parent)) { frm.ShowDialog(); } }

			SetNotebookSelectLabelAndButton();
			LabelsManager.PopulateLabelsList(lstLabelsForSearch);
			Utilities.SetStartPosition(this, parent);
			dtFindDate.Value = DateTime.Now;
			dtFindDate_From.Value = DateTime.Now.AddDays(-30);
			dtFindDate_To.Value = DateTime.Now;
		}

		private async void btnSearch_Click(object sender, EventArgs e) { await DoSearch(); }

		private void btnSelectNotebooks_Click(object sender, EventArgs e)
		{
			using (frmSelectNotebooksToSearch frm = new frmSelectNotebooksToSearch(this)) { frm.ShowDialog(); }
			SetNotebookSelectLabelAndButton();
		}

		private void chkUseDate_CheckedChanged(object sender, EventArgs e) { ToggleDateControls(true); }

		private void chkUseDateRange_CheckedChanged(object sender, EventArgs e) { ToggleDateControls(false); }

		private async Task DoSearch()
		{
			this.Cursor = Cursors.WaitCursor;
			var labels = string.Empty;
			string[] labelsArray;
			List<Entry> foundEntries = new List<Entry>();
			List<Entry> jeFound = null;

			journalBoundaries.Clear();
			lstFoundEntries.Items.Clear();
			FoundEntries.Clear();
			for (var i = 0; i < lstLabelsForSearch.CheckedItems.Count; i++) { labels += lstLabelsForSearch.CheckedItems[i].ToString() + ","; }
			labels = labels.Length > 0 ? labels.Substring(0, labels.Length - 1) : string.Empty;
			labelsArray = labels.Length > 0 ? labels.Split(',') : null;

			SearchObject so = new SearchObject(chkUseDate, chkUseDateRange, chkMatchCase, dtFindDate,
					dtFindDate_From, dtFindDate_To, radBtnAnd, radLabels_And, txtSearchTitle.Text, txtSearchText.Text, labelsArray);

			foreach (KeyValuePair<string, string> kvp in Program.DictCheckedNotebooks)
			{
				Utilities.SetProgramPIN(kvp.Key);
				jeFound = new Notebook(kvp.Key).Open().Search(so);
				await Utilities.PopulateEntries(lstFoundEntries, jeFound, "", "", "", false, 0, true);
				journalBoundaries.Add(kvp.Key, lstFoundEntries.Items.Count);
				FoundEntries.AddRange(jeFound);
				foundEntries.Clear();
			}

			if (lstFoundEntries.Items.Count == 0) { lstFoundEntries.Items.Add("no matches found"); }
			lblSeparator.Visible = true;
			this.Cursor = Cursors.Default;
		}

		private void GetCurrentSelections()
		{
			threeSelections.Clear();
			foreach (int i in lstFoundEntries.SelectedIndices) { threeSelections.Add(i); }
		}

		private Notebook GetEntryJournal()
		{
			List<int> selectedIndices = new List<int>();
			KeyValuePair<string, int> kvp = new KeyValuePair<string, int>();
			foreach (int i in lstFoundEntries.SelectedIndices) { selectedIndices.Add(i); }
			if (selectedIndices.Count() > 1) { selectedIndices = selectedIndices.Except(threeSelections).ToList(); }
			kvp = journalBoundaries.FirstOrDefault(p => p.Value > selectedIndices[0]);
			return kvp.Key == "" ? null : new Notebook(kvp.Key).Open();
		}

		private void lblSeparator_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				lblSeparator.Top += e.Y;
				Utilities.ResizeListsAndRTBs(lstFoundEntries, rtbSelectedEntry_Found, lblSeparator, lblSelectionType, this);
				//if (lstFoundEntries.SelectedIndices.Count > 0) { lstFoundEntries.TopIndex = lstFoundEntries.SelectedIndices[0]; }
			}
		}

		private void lstFoundEntries_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{ mnuEntryEditTop.Visible = lstFoundEntries.SelectedIndices.Contains((e.Y / 15) + lstFoundEntries.TopIndex); }
		}

		private void lstFoundEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox lb = (ListBox)sender;
			RichTextBox rtb = rtbSelectedEntry_Found;
			lb.SelectedIndexChanged -= new System.EventHandler(this.lstFoundEntries_SelectedIndexChanged);

			//while ((lstFoundEntries.SelectedIndex + lstFoundEntries.TopIndex) % 4 != 0) { lstFoundEntries.TopIndex++; }

			try
			{
				if (lb.SelectedIndex > -1)
				{
					Notebook j = GetEntryJournal();
					Utilities.SetProgramPIN(j.Name);
					Entry currentEntry = Entry.Select(rtb, lb, j, false, null, false);
					GetCurrentSelections();

					if (currentEntry != null)
					{
						lblSelectionType.Visible = rtb.Text.Length > 0;
						lblSeparator.Visible = rtb.Text.Length > 0;
						Utilities.ResizeListsAndRTBs(lb, rtb, lblSeparator, lblSelectionType, this);
					}
					else { lstFoundEntries.SelectedIndices.Clear(); }
				}

			}
			catch (Exception) { lb.SelectedIndex = -1; }

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

		private async void mnuEditEntry_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			Entry fe = lstFoundEntries.SelectedIndex == 0 ? FoundEntries[0] : FoundEntries[lstFoundEntries.SelectedIndex / 4];
			using (frmNewEntry frm = new frmNewEntry(this, new Notebook(fe.ClearNotebookName()).Open(), fe)) 
			{ 
				frm.ShowDialog(); 

				if (frm.Saved)
				{
					var indx = lstFoundEntries.SelectedIndex;
					await DoSearch();
					lstFoundEntries.SelectedIndex = indx;
				}
			}

			this.Cursor = Cursors.Default;
		}

		private async void mnuDeleteEntry_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			Entry fe = lstFoundEntries.SelectedIndex == 0 ? FoundEntries[0] : FoundEntries[lstFoundEntries.SelectedIndex / 4];

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Delete '" + fe.ClearTitle() + "' from '" + fe.ClearNotebookName() + "'?", "Delete Entry", this))
			{
				frm.ShowDialog();

				if (frm.Result == frmMessage.ReturnResult.Yes)
				{
					Notebook nb = new Notebook(fe.ClearNotebookName()).Open();

					if (nb != null)
					{
						var cnt = nb.Entries.Count;
						nb.Entries.Remove(nb.Entries.Single(e2 => e2.Id == fe.Id));
						if (nb.Entries.Count == cnt - 1)
						{
							await nb.Save();
							await this.DoSearch();
						}
						else
						{
							using (frmMessage frm2 = new frmMessage(frmMessage.OperationType.Message, "An error occurred. The entry was not deleted.", "Error", this)) { }
						}
					}
				}
				this.Cursor = Cursors.Default;
			}
		}

		private void mnuExit_Click(object sender, EventArgs e) { this.Hide(); }

		private void SetNotebookSelectLabelAndButton()
		{
			lblSearchingIn.Text = "Searching in " +
				(Program.DictCheckedNotebooks.Count == Program.AllNotebooks.Count ? "all " : Program.DictCheckedNotebooks.Count.ToString() + " selected ") + "notebook" + (Program.DictCheckedNotebooks.Count == 1 ? "" : "s");

			btnSelectNotebooks.Left = lblSearchingIn.Left + lblSearchingIn.Width + 5;
		}

		private void ToggleDateControls(bool toggleUseDate)
		{
			if (!IgnoreCheckChange)
			{
				dtFindDate.Enabled = false;
				dtFindDate_From.Enabled = false;
				dtFindDate_To.Enabled = false;

				if (chkUseDate.Checked | chkUseDateRange.Checked)
				{
					if (toggleUseDate)
					{
						dtFindDate.Enabled = true;
						IgnoreCheckChange = true;
						chkUseDateRange.Checked = false;
						IgnoreCheckChange = false;
					}
					else
					{
						dtFindDate_From.Enabled = true;
						dtFindDate_To.Enabled = true;
						IgnoreCheckChange = true;
						chkUseDate.Checked = false;
						IgnoreCheckChange = false;
					}
				}
			}

		}
	}

	public struct FoundEntry
	{
		public string NotebookName;
		public Entry NotebookEntry;
	}
}