﻿/* Search journal entries.
 * 7/9/22
 *	
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		private Entry SelectedEntry = null;
		private int CurrentMouseOverIndex_lstEntries;
		private List<ListItem> FoundLabelsAsListItems = new();
		private const string LabelEntriesFoundText = "{0} entries found";
		public string NotebookName { get; private set; }
		private List<OrgLevel> OrgLevels = new();
		private readonly new Form Parent;
		private List<string> NbsToSearch = new();
		private Dictionary<string, int> NotebookBoundariesDict = new Dictionary<string, int>();
		private string LblSearchingInText = "Searching in {0} {1}s";
		private BackgroundWorker Worker;
		private bool FirstSearch = true;

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
			//Worker = new BackgroundWorker();
			//Worker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
			//Worker.WorkerReportsProgress = true;
			//Worker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
			//Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

			//using (frmSearch_SelectOrgLevel frm = new(this))
			//{
			//	frm.ShowDialog(Parent);

			//	using (frmSearch_SelectOrgLevelItems frm2 = new(frm.SelectedOrgLevelType, this))
			//	{
			//		frm2.ShowDialog(this);
			//		this.OrgLevels = frm2.TopOrgLevels;
			//	}
			//}

			//foreach (OrgLevel orgLevel in this.OrgLevels)
			//{
			//	orgLevel.Name = orgLevel.Name.Trim();
			//	ccb.Items.Add(new { orgLevel.Id, orgLevel.Name });
			//}

			//ccb.CheckUncheckAll(true);
			//this.Text = string.Format(LblSearchingInText, this.OrgLevels.Count.ToString(), this.OrgLevels[0].OrgLevelType.ToString());

			using (frmNotebooksToSearch frm = new())
			{
				frm.ShowDialog(this);
				NbsToSearch = frm.Notebooks;
				frm.Close();
			}

			if (NbsToSearch.Count == 0)
			{
				using (frmMessage frm2 = new frmMessage(frmMessage.OperationType.Message,
					"At least one Notebook must be selected.", "Invalid Input", this)) { frm2.ShowDialog(); this.Close(); }
			}

			foreach (string s in NbsToSearch) { ddlNbsToSearch.Items.Add(s); }
		}

		//private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
		//{
		//	Program.User.Notebooks.Clear();
		//	Program.User.Notebooks.AddRange(DbAccess.GetNotebooksUnderOrgLevel(OrgLevels[0].OrgLevelType, GetCheckedIds()));
		//	//List<Notebook> SortedNotebooks = Program.User.Notebooks.OrderBy(x => x.Name).ToList();
		//	Program.User.Notebooks.Sort((x, y) => x.Name.CompareTo(y.Name));

		//	foreach (Notebook nb in Program.User.Notebooks)
		//	{
		//		nb.Entries = DbAccess.GetEntriesInNotebook(nb.Id);

		//		foreach (Entry entry in nb.Entries)
		//		{
		//			List<MNLabel> v = entry.AllLabels.Where(e => !FoundLabelsAsListItems.Select(e => e.Name).Contains(e.LabelText)).ToList();

		//			foreach (MNLabel label in v) { FoundLabelsAsListItems.Add(new() { Name = label.LabelText, Id = label.Id }); }
		//			//lstLabelsForSearch.Items.Add(new ListItem() { Id = label.Id, Name = label.LabelText }); }
		//		}

		//	}
		//}

		//private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		//{
		//	this.Text += e.ProgressPercentage;
		//}

		//private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		//{
		//	lstLabelsForSearch.Items.AddRange(FoundLabelsAsListItems.ToArray());
		//	btnSearch.Enabled = true;
		//}

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
					await nb.Create();
					NotebookName = nb.Name;
					using (frmMessage frm2 = new frmMessage(frmMessage.OperationType.Message, "The notebook '" + NotebookName + "' was created.", "", this)) { frm2.ShowDialog(); }
				}
			}
		}

		private void chkUseDate_CheckedChanged(object sender, EventArgs e) { ToggleDateControls(true); }

		private void chkUseDateRange_CheckedChanged(object sender, EventArgs e) { ToggleDateControls(false); }

		private async Task DoSearch()
		{
			while (Worker.IsBusy) { Thread.Sleep(100); }
			this.Cursor = Cursors.WaitCursor;
			EntriesToSearch.Clear();
			this.FoundEntries.Clear();
			List<Entry> entries = new();
			List<Notebook> notebooks = new();

			foreach (Notebook nb in Program.User.Notebooks)
			{
				foreach (Entry entry in nb.Entries)
				{
					SearchObject so = new SearchObject(
						chkUseDate, chkUseDateRange, chkMatchCase, dtFindDate, dtFindDate_From, dtFindDate_To
						, radDate_And, radLabels_And, radTitleText_And, radTitle_And
						, txtSearchTitle.Text
						, txtSearchText.Text, GetCheckedLabels());

					var v = nb.Search(so);
					if (v.Count > 0) { FoundEntries.AddRange(v.Where(e => !FoundEntries.Contains(e))); }
				}
			}

			await Utilities.PopulateEntries(lstFoundEntries, FoundEntries, "", "", "", true, 3, true, lstFoundEntries.Width - 25);
			if (lstFoundEntries.Items.Count == 0) { lstFoundEntries.Items.Add("no matches found"); }
			btnExportEntries.Visible = lstFoundEntries.Items.Count > 1;
			lblNumEntriesFound.Visible = btnExportEntries.Visible;
			lblNumEntriesFound.Text = string.Format(LabelEntriesFoundText, FoundEntries.Count);
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

		private List<MNLabel> GetCheckedLabels()
		{
			List<MNLabel> lblsToReturn = new();

			foreach (ListItem li in lstLabelsForSearch.CheckedItems) { lblsToReturn.Add(new() { Id = li.Id, LabelText = li.Name }); }

			return lblsToReturn;

			//string vRtrn = string.Empty;
			//foreach (ListItem li in lstLabelsForSearch.CheckedItems) { vRtrn += li.Name + ","; }
			//return vRtrn.AsSpan(0, vRtrn.Length - 1).ToString();
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

		private void lstFoundEntries_MouseMove(object sender, MouseEventArgs e)
		{
			CurrentMouseOverIndex_lstEntries = (e.Y / lstFoundEntries.ItemHeight) + lstFoundEntries.TopIndex;
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

			if (lb.SelectedIndex > -1 && lb.SelectedIndex < lb.Items.Count)
			{
				lb.SelectedIndexChanged -= new System.EventHandler(this.lstFoundEntries_SelectedIndexChanged);

				SelectEntry();

				if (SelectedEntry != null)
				{
					rtbSelectedEntry_Found.Text = SelectedEntry.DisplayText;

					//	String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
					//, SelectedEntry.Title, SelectedEntry.CreatedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"])
					//, SelectedEntry.AllLabels.se , SelectedEntry.Text);
				}

				//SelectEntry();

				//List<int> selectedIndices = new List<int>();

				//var indx = CurrentMouseOverIndex_lstEntries;

				////var item = lstFoundEntries.Items[indx].ToString().StartsWith("---");

				//while (indx > 0 & !lstFoundEntries.Items[indx].ToString().StartsWith("---")) { indx--; }
				//indx += indx > 0 ? 1 : 0 ;
				//SelectedEntry = FoundEntries[indx / 4];

				//lb.SelectedIndices.Clear();
				//lb.SelectedIndices.Add(indx); lb.SelectedIndices.Add(indx + 1); lb.SelectedIndices.Add(indx + 2);


				//if (lb.SelectedIndices.Count == 4) 
				//{ 
				//	var v2 = lb.SelectedIndices.Cas;

				//	foreach(var v in ThreeSelections) { v2.Remove(lb.SelectedIndices.IndexOf(v)); }
				//	//selectedIndices = lb.SelectedIndices .Except(ThreeSelections).ToList();  
				//}

				//var vindex = v2[0];
				//while (vindex > 0 & !lb.Items[vindex].ToString().StartsWith("--")) { vindex--; }
				//lb.SelectedIndices.Add(vindex + 1); lb.SelectedIndices.Add(vindex + 2); lb.SelectedIndices.Add(vindex + 3);

				//GetCurrentSelections();

				////foreach (int i in lstFoundEntries.SelectedIndices) { selectedIndices.Add(i); }
				////if (selectedIndices.Count() > 1) { selectedIndices = selectedIndices.Except(ThreeSelections).ToList(); }


				//Entry e2 = FoundEntries[lb.SelectedIndex/4];

				////select the entire short entry
				////lb.SelectedIndices.Clear();





				//Notebook nb = GetEntryNotebook();
				//Entry currentEntry = Entry.Select(rtb, lb, nb, false, null, false);
				//GetCurrentSelections();

				//if (currentEntry != null)
				//{
				//	lblSelectionType.Visible = rtb.Text.Length > 0;
				//	lblSeparator.Visible = rtb.Text.Length > 0;
				//	Utilities.ResizeListsAndRTBs(lb, rtb, lblSeparator, lblSelectionType, this);
				//}
				//else { lstFoundEntries.SelectedIndices.Clear(); }

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
			radTitleOr.Checked = true;
			chkUseDate.Checked = false;
			chkUseDateRange.Checked = false;
			lstFoundEntries.Items.Clear();
			rtbSelectedEntry_Found.Text = string.Empty;
			lblSeparator.Visible = false;
		}

		private async void mnuEditEntry_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			Notebook nb = Program.User.Notebooks.FirstOrDefault(n => n.Name == SelectedEntry.NotebookName);
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;

			using (frmNewEntry frm = new(this, nb, 0, SelectedEntry, mnu.Text.ToLower().StartsWith("preserve")))
			{
				frm.ShowDialog();

				if (frm.Saved)
				{
					var indx = lstFoundEntries.SelectedIndex;   // nxt line will clear selections
					await DoSearch();
					lstFoundEntries.SelectedIndex = lstFoundEntries.Items.Count > 1 ? indx : -1;
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

		private void SelectEntry()
		{
			var indx = CurrentMouseOverIndex_lstEntries;

			if (indx < lstFoundEntries.Items.Count - 1)
			{
				while (indx > 0 & !lstFoundEntries.Items[indx].ToString().StartsWith("---")) { indx--; }
				indx += indx > 0 ? 1 : 0;
				SelectedEntry = FoundEntries[indx / 4];
				lstFoundEntries.SelectedIndices.Clear();
				lstFoundEntries.SelectedIndices.Add(indx); lstFoundEntries.SelectedIndices.Add(indx + 1); lstFoundEntries.SelectedIndices.Add(indx + 2);
			}
			else { lstFoundEntries.SelectedIndices.Clear(); }
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

		private void frmSearch_ResizeEnd(object sender, EventArgs e)
		{
			if (this.Height - 344 > 277)
			{
				lblSeparator.Top = this.Height - 344;
				Utilities.ResizeListsAndRTBs(lstFoundEntries, rtbSelectedEntry_Found, lblSeparator, lblSelectionType, this);
			}
		}

		private void ccbNotebooks_TextChanged(object sender, EventArgs e)
		{
			ccbNotebooks.Text = string.Empty;
		}

		private void ddlNbsToSearch_SelectedIndexChanged(object sender, EventArgs e)
		{
			ddlNbsToSearch.Text = string.Empty;
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
}