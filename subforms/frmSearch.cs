/* Search journal entries.
 * 7/9/22
 *	
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryption;
using MyNotebooks.DataAccess;
using MyNotebooks.objects;
using MyNotebooks.subforms;
using static MyNotebooks.objects.CheckedComboBox.Dropdown;

namespace MyNotebooks.subforms
{
	public partial class frmSearch : Form
	{
		private List<int> ThreeSelections = new();
		private bool IgnoreCheckChange = false;
		private List<Entry> FoundEntries = new();
		private List<Entry> EntriesToSearch = new();
		private const string LabelEntriesFoundText = "{0} entries found";
		private int OrgLevelToSearch;
		public string NotebookName { get; private set; }
		private List<OrgLevel> OrgLevels = new();
		private readonly new Form Parent;
		private Dictionary<string, int> NotebookBoundariesDict = new Dictionary<string, int>();
		private string LblSearchingInText = "Searching in {0} {1}s";

		public frmSearch(Form parent)
		{
			this.Parent = parent;
			InitializeComponent();
			LabelsManager.PopulateLabelsList(lstLabelsForSearch);
			Utilities.SetStartPosition(this, parent);
			dtFindDate.Value = DateTime.Now;
			dtFindDate_From.Value = DateTime.Now.AddDays(-30);
			dtFindDate_To.Value = DateTime.Now;
		}

		private void frmSearch_Load(object sender, EventArgs e)
		{
			using (frmSearch_SelectOrgLevel frm = new(this))
			{
				frm.ShowDialog(Parent);

				using (frmSearch_SelectOrgLevelItems frm2 = new(frm.SelectedOrgLevelType, this))
				{
					frm2.ShowDialog(this);
					this.OrgLevels = frm2.TopOrgLevels;
				}
			}

			foreach (OrgLevel orgLevel in this.OrgLevels)
			{
				ccb.Items.Add(new { orgLevel.Id, orgLevel.Name });

			}
			ccb.CheckUncheckAll(true);
			lblSearchingIn.Text = string.Format(LblSearchingInText, this.OrgLevels.Count.ToString(), this.OrgLevels[0].OrgLevelType.ToString());
		}

		private async void btnSearch_Click(object sender, EventArgs e) { await DoSearch(); }

		private async void btnExportEntries_Click(object sender, EventArgs e)
		{
			using (frmNewNotebook frm = new frmNewNotebook(this))
			{
				frm.ShowDialog();

				if (frm.LocalNotebook.Name.Length > 0)
				{
					Notebook nb = frm.LocalNotebook;
					FoundEntries.ForEach(e => e.NotebookName = frm.LocalNotebook.Name);
					nb.Entries.Add(new Entry("created", "-", "{rtf", nb.Name));
					nb.Entries.AddRange(FoundEntries);
					await nb.Create(false);
					//await nb.Create();
					NotebookName = nb.Name;
					using (frmMessage frm2 = new frmMessage(frmMessage.OperationType.Message, "The notebook '" + NotebookName + "' was created.", "", this)) { frm2.ShowDialog(); }
				}
			}
		}

		private void chkUseDate_CheckedChanged(object sender, EventArgs e) { ToggleDateControls(true); }

		private void chkUseDateRange_CheckedChanged(object sender, EventArgs e) { ToggleDateControls(false); }

		//private object? PopulateNotebookEntries()
		//{
		//	foreach(Notebook nb in Program.User.Notebooks)
		//	{

		//	}
		//	return null;
		//}

		private async Task DoSearch()
		{
			this.Cursor = Cursors.WaitCursor;
			var labels = string.Empty;
			List<Entry> foundEntries = new List<Entry>();
			EntriesToSearch.Clear();
			List<Entry> entries = new();
			List<Notebook> notebooks = new();
			//DbAccess.PopulateNotebooksByUserAndDescendants(true);


			// get all entries under the org level

			if(Program.User.Notebooks.Count == 0)
			{
				Program.User.Notebooks.AddRange(DbAccess.GetNotebooksUnderOrgLevel(OrgLevels[0].OrgLevelType, GetCheckedIds()));
				
					//foreach (OrgLevel ol in this.OrgLevels)
				//{
					//entries = DbAccess.GetEntriesCreatedByUser();
					//DbAccess.PopulateNotebooksByUserAndDescendants(ol.OrgLevelType, GetCheckedIds());
					//this.EntriesToSearch = DbAccess.GetEntriesCreatedByUser((int)ol.OrgLevelType, GetCheckedIds());

					//this.EntriesToSearch.AddRange(entries.Where(e => !EntriesToSearch.Contains(e)).ToList());

					//notebooks = DbAccess.GetNotebooksUnderOrgLevel(ol.OrgLevelType, GetCheckedIds());

					//notebooks = notebooks.Where(p => !Program.User.Notebooks.Any(p2 => p2.Id == p.Id)).ToList();

					//if (notebooks.Any() ) { Program.User.Notebooks.AddRange(notebooks); }
				//}

				// land here with Program.User populated with Notebook objects

				this.Cursor = Cursors.WaitCursor;

				foreach (Notebook nb in Program.User.Notebooks)
				{
					nb.Entries = DbAccess.GetEntriesInNotebook(nb.Id);
				}

				this.Cursor = Cursors.Default;
			}

			// land here with Program.User.Notebooks populated with Entry objects

			// get labels being searched for ...
			//labels = labels.Length > 0 ? labels.Substring(0, labels.Length - 1) : string.Empty;
			//labelsArray = labels.Length > 0 ? labels.Split(',') : null;

			foreach(Notebook nb in Program.User.Notebooks)
			{
				foreach(Entry entry in nb.Entries)
				{ 				
					SearchObject sob = new SearchObject(chkUseDate, chkUseDateRange, chkMatchCase, dtFindDate,
								dtFindDate_From, dtFindDate_To, radBtnAnd, radLabels_And, txtSearchTitle.Text
								, txtSearchText.Text, entry.AllLabels.Select(e => e.LabelText).ToArray());

					foundEntries.AddRange(nb.Search(sob));
				}
			}

			await Utilities.PopulateEntries(lstFoundEntries, foundEntries, "", "", "", true , 0, true, lstFoundEntries.Width);

			//NotebookBoundariesDict.Clear();
			//lstFoundEntries.Items.Clear();
			//FoundEntries.Clear();

			//lstLabelsForSearch.Items.Clear();
			//var v = EntriesToSearch.Select(e => e.AllLabels).ToList();

			//for (var i = 0; i < lstLabelsForSearch.CheckedItems.Count; i++) { labels += lstLabelsForSearch.CheckedItems[i].ToString() + ","; }

			//labels = labels.Length > 0 ? labels.Substring(0, labels.Length - 1) : string.Empty;
			//labelsArray = labels.Length > 0 ? labels.Split(',') : null;

			//SearchObject so = new SearchObject(chkUseDate, chkUseDateRange, chkMatchCase, dtFindDate,
			//		dtFindDate_From, dtFindDate_To, radBtnAnd, radLabels_And, txtSearchTitle.Text, txtSearchText.Text, labelsArray);

			//var lastIndex = 0;

			//foreach (KeyValuePair<string, string> kvp in Program.DictCheckedNotebooks)
			//{
			//	Utilities.SetProgramPIN(kvp.Key);
			//	entriesFound = new Notebook(kvp.Key.Replace(" (****)", ""), "").Open().Search(so);
			//	await Utilities.PopulateEntries(lstFoundEntries, entriesFound, "", "", "", false, 0, true);

			//	if (entriesFound.Count > 0)
			//	{
			//		lastIndex += entriesFound.Count * 4;
			//		if (!NotebookBoundariesDict.Keys.Contains(kvp.Key)) NotebookBoundariesDict.Add(kvp.Key, lastIndex);
			//		FoundEntries.AddRange(entriesFound);
			//	}

			//	foundEntries.Clear();
			//}

			if (lstFoundEntries.Items.Count == 0) { lstFoundEntries.Items.Add("no matches found"); }
			btnExportEntries.Visible = lstFoundEntries.Items.Count > 1;
			lblNumEntriesFound.Visible = btnExportEntries.Visible;
			//lblNumEntriesFound.Text = string.Format(this.LabelEntriesFoundText, lstFoundEntries.Items.Count / 4);
			lblSeparator.Visible = true;
			this.Cursor = Cursors.Default;
		}

		private string GetCheckedIds()
		{
			var vRtrn = string.Empty;

			foreach (OrgLevel ol in this.OrgLevels)
			{
				vRtrn += ol.Id + ",";
			}

			//for(int i = 0; i < ccb.CheckedIndices.Count; i++)
			//{
			//	var v = (ListItem)ccb.Items[i];

			//	vRtrn += v.Id.ToString() + ",";
			//}

			//for (int i = 0; i < ccb.Items.Count; i++)
			//{
			//	if (ccb.GetItemChecked(i)) { vRtrn += ccb.Items[i]; }
			//}



			//foreach (int v in ccb.CheckedIndices)
			//{
			//	var v2 = ccb.CheckedIndices[v];
			//	vRtrn = v.ToString() + ",";
			//	//var item = new ListItem() { Name = v.}
			//	vRtrn += new ListItem() { Name = v.ToString() } + ",";
			//}
			return vRtrn.AsSpan(0, vRtrn.Length - 1).ToString();
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

			if (lb.SelectedIndex > -1)
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

			using (frmNewEntry frm = new frmNewEntry(this, nb, 0, fe, mnu.Text.ToLower().StartsWith("preserve")))
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

		private void lblSelectAllOrNone_Click(object sender, EventArgs e)
		{
			bool b = lblSelectAllOrNone.Text == "select all";
			ccb.CheckUncheckAll(b);
			lblSelectAllOrNone.Text = b ? "unselect all" : "select all";
			ccb.DroppedDown = true;
		}

		private void ccb_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			//this.Text = sender.ToString();  // this.Text == "whoo" ? "what?" : "whoo";

			////MyNotebooks.objects.CheckedComboBox+Dropdown+CustomCheckedListBox 
			////CheckedComboBox clb = (CheckedComboBox)sender;
			//CheckedListBox clb = (CheckedListBox)sender;

			//var v = clb.SelectedItem as ListViewItem;

			//var v3 = clb.Items;

			//var v4 = ccb.GetSelectedItem();


			//if(v != null)
			//{
			//	foreach(ListViewItem item in clb.Items)
			//	{
			//		if (item.Checked) { }
			//	}
			//}
		}

		//private void ccb_SelectedIndexChanged(object sender, EventArgs e)
		//{

		//}

		//private void ccb_SelectedValueChanged(object sender, EventArgs e)
		//{

		//}

		//private void ccb_MouseClick(object sender, MouseEventArgs e)
		//{
		//	//if (ccb.SelectedIndex > 0)
		//	//{ int i = 1; }
		//	lblSearchingIn.Text = string.Format(LblSearchingInText, ccb.CheckedItems.Count, OrgLevels[0].OrgLevelType.ToString());
		//}

		//private void ccb_Click(object sender, EventArgs e)
		//{
		//	lblSearchingIn.Text = string.Format(LblSearchingInText, OrgLevels[0].OrgLevelType.ToString(), ccb.CheckedItems.Count);
		//}
	}

	public struct FoundEntry
	{
		public string NotebookName;
		public Entry NotebookEntry;
	}
}