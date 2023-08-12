/* Search journal entries.
 * 7/9/22
 *	
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryption;
using myNotebooks.objects;

namespace myNotebooks.subforms
{
	public partial class frmSearch : Form
	{
		private List<int>	ThreeSelections = new List<int>();
		private bool		IgnoreCheckChange = false;
		private List<Entry> FoundEntries = new List<Entry>();
		private string		LabelEntriesFoundText = "{0} entries found";
		private Dictionary<string, int> NotebookBoundariesDict = new Dictionary<string, int>();
		public string		NotebookName { get; private set; }

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

		private async void btnExportEntries_Click(object sender, EventArgs e)
		{
			using (frmNewNotebook frm = new frmNewNotebook(this))
			{
				frm.ShowDialog();
				  
				if(frm.Notebook.Name.Length > 0)
				{
					Notebook nb = frm.Notebook;
					FoundEntries.ForEach(e => e.NotebookName = frm.Notebook.Name);
					nb.Entries.Add(new Entry("created", "-", "{rtf", nb.Name));
					nb.Entries.AddRange(FoundEntries);
					await nb.Create(false);
					//await nb.Save();
					NotebookName = nb.Name;
					using (frmMessage frm2 = new frmMessage(frmMessage.OperationType.Message, "The notebook '" + NotebookName + "' was created.", "", this)) { frm2.ShowDialog(); }
				}
			}
		}

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
			List<Entry> nbFound = null;

			NotebookBoundariesDict.Clear();
			lstFoundEntries.Items.Clear();
			FoundEntries.Clear();
			for (var i = 0; i < lstLabelsForSearch.CheckedItems.Count; i++) { labels += lstLabelsForSearch.CheckedItems[i].ToString() + ","; }
			labels = labels.Length > 0 ? labels.Substring(0, labels.Length - 1) : string.Empty;
			labelsArray = labels.Length > 0 ? labels.Split(',') : null;

			SearchObject so = new SearchObject(chkUseDate, chkUseDateRange, chkMatchCase, dtFindDate,
					dtFindDate_From, dtFindDate_To, radBtnAnd, radLabels_And, txtSearchTitle.Text, txtSearchText.Text, labelsArray);

			var lastIndex = 0;

			foreach (KeyValuePair<string, string> kvp in Program.DictCheckedNotebooks)
			{
				Utilities.SetProgramPIN(kvp.Key);
				nbFound = new Notebook(kvp.Key.Replace(" (****)", ""), "").Open().Search(so);
				await Utilities.PopulateEntries(lstFoundEntries, nbFound, "", "", "", false, 0, true);

				if(nbFound.Count > 0 )
				{
					lastIndex += nbFound.Count * 4;
					if(!NotebookBoundariesDict.Keys.Contains(kvp.Key)) NotebookBoundariesDict.Add(kvp.Key, lastIndex);
					FoundEntries.AddRange(nbFound);
				}

				foundEntries.Clear();
			}

			if (lstFoundEntries.Items.Count == 0) { lstFoundEntries.Items.Add("no matches found"); }
			btnExportEntries.Visible = lstFoundEntries.Items.Count > 1;
			lblNumEntriesFound.Visible = btnExportEntries.Visible;
			lblNumEntriesFound.Text = string.Format(this.LabelEntriesFoundText, lstFoundEntries.Items.Count / 4);
			lblSeparator.Visible = true;
			this.Cursor = Cursors.Default;
		}

		private void GetCurrentSelections()
		{
			ThreeSelections.Clear();
			foreach (int i in lstFoundEntries.SelectedIndices) { ThreeSelections.Add(i); }
		}

		private Notebook GetEntryNotebook()
		{
			List<int> selectedIndices = new List<int>();
			KeyValuePair<string, int> kvp = new KeyValuePair<string, int>();
			foreach (int i in lstFoundEntries.SelectedIndices) { selectedIndices.Add(i); }
			if (selectedIndices.Count() > 1) { selectedIndices = selectedIndices.Except(ThreeSelections).ToList(); }
			kvp = NotebookBoundariesDict.FirstOrDefault(p => p.Value >= selectedIndices[0]);
			Utilities.SetProgramPIN(kvp.Key);
			return kvp.Key == "" ? null : new Notebook(kvp.Key, "").Open();
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

			if(lb.SelectedIndex > -1)
			{
				lb.SelectedIndexChanged -= new System.EventHandler(this.lstFoundEntries_SelectedIndexChanged);
				Notebook nb = GetEntryNotebook();
				Entry currentEntry = Entry.Select(rtb, lb, nb, false, null, false);
				GetCurrentSelections();

				if (currentEntry != null)
				{
					lblSelectionType.Visible = rtb.Text.Length > 0;
					lblSeparator.Visible = rtb.Text.Length > 0;
					Utilities.ResizeListsAndRTBs(lb, rtb, lblSeparator, lblSelectionType, this);
				}
				else { lstFoundEntries.SelectedIndices.Clear(); }

			}

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
			Notebook nb = new Notebook(fe.NotebookName, "").Open();
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;

			using (frmNewEntry frm = new frmNewEntry(this, nb, fe, mnu.Text.ToLower().StartsWith("preserve")))
			{
				frm.ShowDialog();

				if (frm.Saved)
				{
					nb.ReplaceEntry(fe, frm.Entry);
					await nb.Save();
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

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Delete '" + fe.Title + "' from '" + fe.NotebookName + "'?", "Delete Entry", this))
			{
				frm.ShowDialog();

				if (frm.Result == frmMessage.ReturnResult.Yes)
				{
					Notebook nb = new Notebook(fe.NotebookName, "").Open();

					if (nb != null)
					{
						var cnt = nb.Entries.Count;
						nb.Entries.Remove(nb.Entries.Single(e2 => e2.Id == fe.Id));

						while (nb.Entries.Count == cnt) { }

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
			lblSearchingIn.Text = "Searching in " + Program.DictCheckedNotebooks.Count + " of " + Program.AllNotebookNames.Count + " notebooks";
				//(Program.DictCheckedNotebooks.Count == Program.AllNotebookNames.Count ? "all " : Program.DictCheckedNotebooks.Count.ToString() + " selected ") + "notebook" + (Program.DictCheckedNotebooks.Count == 1 ? "" : "s");

			btnSelectNotebooks.Left = lblSearchingIn.Left + lblSearchingIn.Width + 5;
			btnExportEntries.Left = btnSelectNotebooks.Left + btnSelectNotebooks.Width + 5;
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