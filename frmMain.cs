/* Main form.
	04/01/22 Created - jsr
	07/13/22 Dev. closed. v1.0 released.
	08/25/24 Removed all multi-notebook features in 10/2023. 

	bugs/hotfixes:
		bugs: ('x' = done)
		07/07/22 1100
			001x Can arrow down or right into no type area.
			> 002x Can select and drag into or out of no type area.
				1400 Fixed
		07/08/22 1000
			003x Create entry edit sometimes leaves out Text.
				1740 Found issue. Entries with '(' in the title cause failure to build currentEntry (it remains null after entry is selected).
				1745 Fixed: When selecting in the short entry (lstEntries) get LastIndexOf('(') instead of just .IndexOf.

			004x Entries with no text cannot be edited or deleted (menus are disabled because they toggle on rtbSelectedEntry.Text.Length > 0).
				1745 Fixed with 0003. This should never happen. Only came up because of 0003.

		001x 07/23/22 1330
			Fatal error when selecting an entry from lstEntries AFTER selecting entry > clicking 'week' or 'month' filter > selecting one of the entries shown in the filtered results.
			08/02/22 Declared fixed. Bug hasn't been seen since this incident. It is probably related to old journals and entries. Deleted all old test journals.

		002X 08/02/22 07:20
			There's a problem with date display. Some (older?) entry dates are "H:m:s" and others are "HH:mm:ss".
			09/10/22 FIXED

		003x 11/27/22
			Replicate sequence: 
				> Open a PIN-protected journal 
				> Open Create EntryToEdit 
				> select Manage Labels 
				> provide PIN for journals 
				> Globally delete a label 
				-> New entry does not save and journal re-opens w/ no entry title + text
			Fix:
				Apparently when the MNLabel > Delete_original runs the Program.PIN is changed.
				Added a class variable to frmLabelsManager storing the Program.PIN when launched. Reset Program.PIN to that variable value on Form_Closing(...).
			Tested OK 11/27/22
			
		004x 11/27/22
			Replicate sequence:
				> Open a journal
				> Select an entry
				> Create a new entry (Create and Exit)
				->  frmMain is shown in EntrySelected mode but no entry is selected (because they reloaded). Therefore when lblSeperator is clicked on we throw an 'Index out of range' error 
						because no entry is selected.
			Fix: 
				Switch to JournalSelected mode when returning from EntryToEdit > Create.
				Tested OK 11/27/22. The mode switch was already programmed for EntryToEdit delete and EntryToEdit edit modes - just wasn't doing that for Create.

		005x 12/14/24
			Entries display not refreshing when
					1) Create new entry (also on edit existing?)
					2) Create new label. Add to entry. Save entry. Exit.
					3) Entries display does not refresh.
					4) Editied On is populated in new entry.
			FIX: 12/15/24
				Used frmNewEntry.SaveEntry() to save entry.
				Reason for showing EditedOn after creating a label is that the entry has to be saved before managing labels.
				Added 30 second delay in Entry.GetSynopsis() to avoid EditedOn being too close to CreatedOn.
				Changed delay to 60. 12/28/24

		006 12/14/24 
			Delete labels not working (frmLabelsManager.mnuDeleteLabels)

		007 12/30/24
			Prompt for 'Add new label to entry <entry>?' not tall enough, cuts off entry title on 2nd line.
				Stop prompting, just add the new label to the entry.

++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		toDo: ('x' = done)
		07/07/22 001 EntryToEdit RTB formatting controls.
				 002 Create .RichText instead of just .Text;
				002ax Add password char for PIN and show/hide function.
					1730 Done.
		07/08/22 003x Column tab stops in rtbNewEntry.
					07/10/22 1810 Done (was simple properties setting - .AcceptTab)
				 004x Create new entry without exiting (to save incrementally)?
					07/11/22 1445 No. Have user save entry then edit if desired.
				 005x Allow selection length > 1 in editing entry notypearea for copying? Catch key code, only allow Ctrl.
					07/12/22 1330 No. Parts of old text can be copied via the Edit Existing Text menu.
				 006x Don't allow save of entry with no text or title.
					16:50 Done
				 007x Context menu for entries? (Delete_original, Edit)
					07/11/22 1445 No. This functionality isn't important since app is destined for mobile UI.
				 008x Disallow clicking/typing in Selected EntryToEdit text on frmMain.
					07/10/22 1145 Done.
				 009x PIN show/hide on frmNewJournal.
					7/10/22 1400 Done.
		07/10/22 010x Search criteria is case sensitive. Should be a user choice (default insensitive).
					07/11/22 1430 Fixed.
				 011x Add Yes/No/Cancel prompt for Cancel/Exit on frmNewEntry.
					1130 Done.

		07/23/22 001x Related to bug 001.
					WHEN CLICKING 'week' OR 'month' FILTER ...
						1) IF an entry is clicked, remember it.
						2) Clear currentEntry + rtb
						3) Show the filtered entries
						4) If one is the entry remembered in 1), select it.
			08/02/22 Rename. Have disabled filter actions. NEEDS ATTENTION. HIDE FILTER CONTROLS UNTIL FIXED !!!
			12/13/22 Rename. As of v1.5 date filters are working. 'week' and 'month' buttons are deprecated/removed.

		12/1/22 
			002x ClickOnce install
				Got CO working w/ setup.exe on my desktop. Installed on laptop.
					> Don't have app updates working yet. Thinking I need it to install from the web before I do that.
					> Need to have it installing from web. GoDaddy is f'ng me w/ 'IP Address has changed' so I can't get to File Manager :(
				12/13/22 CO is working from GoDaddy.
					Still have to FTP newly published files to GoDaddy.
					Would like to publish directly to FTP but apparently that's not an option in VS2022

				003 Need to be able to distribute journals to multiple devices - so journals are portable.
					> Export Journal via email?
						Will need 'Import Journal' in app so user can browse to downloaded journal.
						This isn't really portable since updates on one device will have to be emailed.
							True portability will involve Journals being stored on web.
					> Import Journals is working. Is NOT a final fix!
						On update of ClickOnce deployment (which does work) there needs to be a mechanism to import Journals from 
							previous (published) version.
						Need to scan for orphaned labelsForSearch after an import. Put a new method in Journal.cs - 'AllLabels()'?
					> 02/24/23 All is working, clickonce + cloud sync. Marked complete.

		12/07/22
			003x checkbox lists
				12/28/24 - Don't remember this so marking it complete.

		12/28/24
			004 Db needs work.
				Change primary keys in Labels, Groups, Departments, and Accounts from (Id & ParentId) to (<text val> & ParentId).
				Chaange primary key in NotebookEntries from (Id) to (ParentId & Title).

		12/28/24
			005 SEARCH SEARCH SEARCH!

++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	enhancements:
		07/14/22 001x Add date selection for shown entries (e.g. last <x> days)
			07/15/22 0230 Is working with user specified number of weeks.
							> Should have user input a date? From a list of dates for all entries?
					 2315 Done with date selection and last week/month filter.
		07/27/22 002a For edit entry, edit original text, only show previous entry's .ClearText().
						Done.

		08/09/22 003x See frmSearch & Journal

		09/12/22 004 Add formatting to RTB's
			> frmNewEntry
			> frmMain (displaying full entry w/ richtext).

		10/15/22
			005x Fix search error when clicking found entry.
			006x Change frmNewEntry.Text after saving from 'new entry in <jrnl>' to 'editing <entry name>'.
				done
			007x Journal rename?
				did it
		02/02/23
			008 Write 'change Azure PWD'

		02/24/23	
			009 Write mnuJournal_Export_Click (as plain text?, as Journal file (encrypted)?)

		12/24/24
			010 Using local database.

		12/24/24
			011 Recreate a notebook from a backup
				Done 12/25/24
			011a Serialize notebook for 'Save to Disk'. Output JSON.
				Enhanced: Added both JSON and plain text outputs. 12/25/24
				Done 12/24/24
			011b Handle restored notebook.
				Done 12/28/24

 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyNotebooks.objects;
using MyNotebooks.DataAccess;
using System.ComponentModel;
using System.Threading;
using System.Text;
using System.Text.Json;

namespace MyNotebooks.subforms
{
	public partial class frmMain : Form
	{
		private Notebook		CurrentNotebook;
		private Entry			CurrentEntry;
		private bool			FirstSelection = true;
		private bool			SuppressDateClick = false;
		private readonly string FoundCountString = "showing {0} of {1} entries";
		private readonly int	SelectedNotebookId;
		private KeyValuePair<int, string> SelectedNotebookIds;
		//private BackgroundWorker Worker;

		private enum SelectionState
		{
			NotebookSelectedNotLoaded,
			NotebookLoaded,
			EntrySelected,
			HideAll,
			NotebookNotSelected
		}

		public enum OrgLevelTypes : uint
		{
			Entry = 1,
			Notebook = 2,
			Group = 3,
			Department = 4,
			Account = 5,
			Company = 6,
			None = 7
		}

		public frmMain()
		{
			InitializeComponent();
		}

		private async void	frmMain_Activated(object sender, EventArgs e)
		{
			if (Program.AllNotebooks.Count == 0)
			{
				try
				{
					await Utilities.PopulateAllNotebooks();
					LoadNotebooks();
					this.Cursor = Cursors.Default;
				}
				catch (Exception ex)    // This catches no SQL connection then exits.
				{
					GenerateMesssage("An error occurred loading Notebook names and Ids. ", ex, "Fatal Error");
					this.Close();
				}
			}
		}

		private void		frmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			foreach (Form f in Application.OpenForms)
			{
				f.Close();
			}
		}

		private async void	frmMain_Load(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
			this.Text = fvi.ProductName + " " + Program.AppVersion + (fvi.FileName.ToLower().Contains("debug") ? " - DEBUG MODE" : "");
			ShowHideMenusAndControls(SelectionState.HideAll);
			Program.User.Id = 1000;
		}

		private void		frmMain_Resize(object sender, EventArgs e)
		{
			if (!rtbSelectedEntry.Visible)
			{
				lstEntries.Height = this.Height - 160;
				lstEntries.Width = this.Width - 40;
			}
		}

		private async void	loadSelectedNotebook(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			lstEntries.Items.Clear();
			rtbSelectedEntry.Text = string.Empty;
			if (CurrentNotebook != null && Program.DictCheckedNotebooks.Count == 1 && Program.DictCheckedNotebooks.Keys.Contains(CurrentNotebook.Name)) { Program.DictCheckedNotebooks.Clear(); }
			if (Program.DictCheckedNotebooks.Count == 0) { Program.DictCheckedNotebooks.Add(ddlNotebooks.Text, txtJournalPIN.Text); }

			CurrentNotebook = DbAccess.GetNotebook_OptionalEntries(SelectedNotebookIds.Key);

			if (CurrentNotebook != null)
			{
				Program.SelectedNotebookName = CurrentNotebook.Name;

				if (CurrentNotebook.Entries.Count == 0)
				{
					using (frmNewEntry frm = new(this, CurrentNotebook))
					{
						frm.ShowDialog(this);
						if (frm.Entry != null)
						{
							CurrentNotebook.Entries.Add(frm.Entry);
							await Utilities.PopulateEntries(lstEntries, CurrentNotebook.Entries);
							PromptForBackup();
						}
					}
					ShowHideMenusAndControls(SelectionState.NotebookLoaded);
				}
				else
				{
					try
					{
						PopulateShowFromDates();
						SuppressDateClick = true;
						await ProcessDateFiltersAndPopulateEntries();
						SuppressDateClick = false;
						lstEntries.Height = this.Height - lstEntries.Top - 50;

						for (var i = 0; i < cbxDatesFrom.Items.Count; i++)
						{
							if (DateTime.Parse(cbxDatesFrom.Items[i].ToString()) <= DateTime.Parse(cbxDatesTo.Text).AddDays(-60) || i == cbxDatesFrom.Items.Count - 1)
							{
								cbxDatesFrom.SelectedIndex = i;
								break;
							}
						}

						cbxDatesTo.SelectedIndex = 0;
						ShowHideMenusAndControls(SelectionState.NotebookLoaded);
						lstEntries.Focus();
					}
					catch (Exception ex) { Console.Write(ex.Message); }
				}
			}

			this.Cursor = Cursors.Default;
		}

		private async void	btnResetLabelFilter_Click(object sender, EventArgs e)
		{
			await ProcessDateFiltersAndPopulateEntries();
			ShowHideMenusAndControls(SelectionState.NotebookLoaded);
		}

		private async void	cbxDates_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!SuppressDateClick) { await ProcessDateFiltersAndPopulateEntries(); }
		}

		private async void	cbxSortEntriesBy_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (CurrentNotebook != null)
			{
				await ProcessDateFiltersAndPopulateEntries();
				lstEntries.Focus();
			}
		}

		public static void	CopyDirectory(DirectoryInfo source, DirectoryInfo target, bool copySubDirectories, bool clearTargetFolderBeforeCopy)
		{
			Directory.CreateDirectory(target.FullName);

			if (clearTargetFolderBeforeCopy)
			{
				foreach (FileInfo fi in target.GetFiles())
				{ fi.Delete(); }
			}

			// Copy each file into the new directory.
			foreach (FileInfo fi in source.GetFiles())
			{
				Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
				fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
			}

			// Copy each subdirectory using recursion.
			if (copySubDirectories)
			{
				foreach (DirectoryInfo sourceSubDir in source.GetDirectories())
				{
					DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(source.Name);
					CopyDirectory(sourceSubDir, nextTargetSubDir, false, clearTargetFolderBeforeCopy);
				}
			}
		}

		private void		CheckForSystemDirectories(bool recreateAll = false)
		{
			if (recreateAll)
			{
				Directory.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"]);
				Directory.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebookIncrementalBackupsFolder"]);
				Directory.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebookForcedBackupsFolder"]);
				Directory.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_SettingsFolder"]);
				Directory.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"]);
				Directory.Delete(Program.GroupsFolder);
				File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]);
				File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]);

			}

			if (!Directory.Exists(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"]))    // create system directories and files
			{
				Directory.CreateDirectory(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"]);
				Directory.CreateDirectory(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebookIncrementalBackupsFolder"]);
				Directory.CreateDirectory(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebookForcedBackupsFolder"]);
				Directory.CreateDirectory(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_SettingsFolder"]);
				Directory.CreateDirectory(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"]);
				Directory.CreateDirectory(Program.GroupsFolder);
				File.Create(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_SettingsFile"]).Close();
				File.Create(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]).Close();

				using (StreamWriter sw = File.AppendText(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]))
				{ sw.WriteLine(DateTime.MinValue.ToString(ConfigurationManager.AppSettings["FileDate"])); }

				using (StreamWriter sw = File.AppendText(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_SettingsFile"]))
				{ sw.WriteLine(DateTime.MinValue.ToString(ConfigurationManager.AppSettings["FileDate"])); }
			}
		}

		private void		ddlNotebooks_Click(object sender, EventArgs e)
		{ if (ddlNotebooks.Items.Count > 0) { ddlNotebooks.DroppedDown = true; } }

		private void		ddlNotebooks_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowHideMenusAndControls(SelectionState.NotebookLoaded);
			CurrentEntry = null;
			CurrentNotebook = null;
			cbxDatesFrom.DataSource = null;
			lstEntries.Items.Clear();
			lstEntries.Visible = false;
			cbxSortEntriesBy.SelectedIndex = 0;
			var v = ddlNotebooks.SelectedItem as ListItem;
			SelectedNotebookIds = new(v.Id, v.Name);
			loadSelectedNotebook(sender, e);
		}

		private void		GenerateMesssage(string errorMessage, Exception exception = null, string title = "")
		{
			frmMessage frm = new(frmMessage.OperationType.Message, errorMessage + (exception != null ? Environment.NewLine + exception.Message : ""), title, this);
			frm.ShowDialog();
		}

		private string		GetUniqueNotebookName(string proposedNbName)
		{
			while(Program.AllNotebooks.Select(n => n.Name).Contains(proposedNbName))
			{
				using (frmMessage frm = new(frmMessage.OperationType.InputBox, "The notebook '" + 
					proposedNbName + "' already exists." + Environment.NewLine + "You must provide a unique name.", proposedNbName + "(2)", this))
				{
					frm.ShowDialog();
					proposedNbName = frm.ResultText;
				}
			}
			return proposedNbName;
		}

		private void		lblSeparator_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				lblSeparator.Top += e.Y;
				Utilities.ResizeListsAndRTBs(lstEntries, rtbSelectedEntry, lblSeparator, lblSelectionType, this);
				lstEntries.TopIndex = lstEntries.SelectedIndices.Count > 0 ? lstEntries.SelectedIndices[0] : 0;
			}
		}

		private void		lblShowPIN_Click(object sender, EventArgs e)
		{
			txtJournalPIN.PasswordChar = txtJournalPIN.PasswordChar == '*' ? '\0' : '*';
			lblShowPIN.Text = lblShowPIN.Text == "show" ? "hide" : "show";
		}

		private void		LoadFonts()
		{
			ListViewItem lvi = null;

			foreach (FontFamily f in System.Drawing.FontFamily.Families)
			{
				lvi = new ListViewItem();
				lvi.Font = new Font(f.Name, 8);
				lvi.Text = f.Name;
				Program.lstFonts.Add(lvi);
			}
		}

		private async void	LoadNotebooks()
		{
			ddlNotebooks.Items.Clear();
			ddlNotebooks.Text = string.Empty;

			foreach (Notebook n in Program.AllNotebooks)
			{
				ListItem lvi = new ListItem() { Name = n.Name, Id = n.Id };
				ddlNotebooks.Items.Add(lvi);
			}

			ddlNotebooks.DisplayMember = "Name";
			ddlNotebooks.ValueMember = "Id";
			ddlNotebooks.Enabled = ddlNotebooks.Items.Count > 0;

			if (ddlNotebooks.Items.Count > 0)
			{
				ShowHideMenusAndControls(SelectionState.NotebookNotSelected);
			}
		}

		private void		lstEntries_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				bool entryClicked = lstEntries.SelectedIndices.Contains((e.Y / 15) + lstEntries.TopIndex);
				mnuEntryEdit.Visible = entryClicked;
				mnuEntryDelete.Visible = entryClicked;
				mnuEntryCreate.Visible = !entryClicked;
			}
		}

		private void		lstEntries_SelectEntry(object sender, EventArgs e)
		{
			ListBox lb = (ListBox)sender;

			if (lb.SelectedIndex > -1)
			{
				lb.SelectedIndexChanged -= new System.EventHandler(this.lstEntries_SelectEntry);

				CurrentEntry = null;
				SelectShortEntry(sender);
				var idx = lb.SelectedIndex;
				while (idx % 4 != 0) { idx--; }
				CurrentEntry = Program.CurrentEntries[idx == 0 ? 0 : idx / 4];
				rtbSelectedEntry.Text = CurrentEntry.RTBText;

				DbAccess.GetLabelsForEntry(CurrentEntry.Id);

				if (CurrentEntry != null)
				{
					FirstSelection = false;
					lblSelectionType.Visible = rtbSelectedEntry.Text.Length > 0;
					lblSeparator.Visible = rtbSelectedEntry.Text.Length > 0;
					Utilities.ResizeListsAndRTBs(lstEntries, rtbSelectedEntry, lblSeparator, lblSelectionType, this);
					ShowHideMenusAndControls(SelectionState.EntrySelected);
					mnuLabels.Enabled = true;
				}
				else
				{
					ShowHideMenusAndControls(SelectionState.NotebookLoaded);
					lstEntries.SelectedIndices.Clear();
				}

				lb.SelectedIndexChanged += new System.EventHandler(this.lstEntries_SelectEntry);
			}
		}

		private void		mnuAbout_Click(object sender, EventArgs e)
		{
			Form frm = new frmAbout(this);
			frm.ShowDialog(this);
		}

		private async void  mnuAdministratorConsole_Click(object sender, EventArgs e) { this.Close(); }

		private async void	mnuEntryCreate_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			var vCurrentEntriesCount = lstEntries.Items.Count;
			using (frmNewEntry frm = new(this, CurrentNotebook, CurrentNotebook.Id))
			{
				frm.Text = "New entry in '" + CurrentNotebook.Name + "'";
				frm.ParentNotebookId = CurrentNotebook.Id;
				frm.ShowDialog(this);

				if (frm.Saved)
				{
					CurrentEntry = frm.Entry;
					//await CurrentNotebook.Create();
					CurrentNotebook.Entries.Add(CurrentEntry);
					await Utilities.PopulateEntries(lstEntries, CurrentNotebook.Entries);
					if (!cbxDatesTo.Items.Contains(CurrentEntry.CreatedOn)) { cbxDatesTo.Items.Insert(0, CurrentEntry.CreatedOn.ToShortDateString()); }
					if (cbxDatesTo.Items.Count > 0) cbxDatesTo.SelectedIndex = 0;
					if (lstEntries.Items.Count > 0) lstEntries.SelectedIndex = 0;
					PromptForBackup();
				}
			}
			this.Cursor = Cursors.Default;
		}

		private async void	mnuEntryDelete_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			var vMsg = "Do you want to delete " + "'" + CurrentEntry.Title + "'?";
			using (frmMessage frm = new(frmMessage.OperationType.YesNoQuestion, vMsg, "Confirm Delete", this))
			{
				frm.ShowDialog(this);

				if (frm.Result == frmMessage.ReturnResult.Yes)
				{
					CurrentEntry.Delete();
					CurrentNotebook.Entries.Remove(CurrentEntry);
					await ProcessDateFiltersAndPopulateEntries();
					ShowHideMenusAndControls(SelectionState.NotebookLoaded);
					PromptForBackup();
				}
			}

			this.Cursor = Cursors.Default;
		}

		private async void	mnuEntryEdit_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;

			using (frmNewEntry frm = new frmNewEntry(this, CurrentNotebook, CurrentNotebook.Id, CurrentEntry, mnu.Text.ToLower().StartsWith("preserve")))
			{
				frm.Text = "Edit '" + CurrentEntry.Title + "' in '" + CurrentNotebook.Name + "'";
				frm.ShowDialog(this);

				if (frm.Saved && frm.Entry != null)
				{
					CurrentEntry = frm.Entry;
					//if (CurrentEntry.LabelsToRemove == null) await CurrentNotebook.Save();
					await CurrentNotebook.Save();
					await ProcessDateFiltersAndPopulateEntries();
					var v = lstEntries.Items.OfType<string>().FirstOrDefault(e => e.StartsWith(CurrentEntry.Title));
					lstEntries.SelectedIndex = lstEntries.Items.IndexOf(v);
					PromptForBackup();
				}
			}

			this.Cursor = Cursors.Default;
		}

		private async void	mnuLabels_Click(object sender, EventArgs e)
		{
			DateTime start = DateTime.Now;
			while (Program.BgWorker.IsBusy && start.AddSeconds(4) > DateTime.Now) { Thread.Sleep(300); }

			using (frmLabelsManager frm = new(this, CurrentNotebook, CurrentEntry))
			{
				frm.ShowDialog();

				if (frm.ActionTaken)
				{
					await ProcessDateFiltersAndPopulateEntries();
					var v = lstEntries.Items.OfType<string>().FirstOrDefault(e => e.StartsWith(CurrentEntry.Title));
					lstEntries.SelectedIndex = lstEntries.Items.IndexOf(v);
				}
			}
		}

		private void		mnuNotebook_Backups_CreateOrRestore(object sender, EventArgs e)
		{
			ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
			if (tsmi.Name.ToLower().Contains("create")) { mnuNotebook_Print_Click(sender, e); }
			else { mnuNotebook_RestoreBackups_Click(sender, e); }
		}

		private async void	mnuNotebook_Create_Click(object sender, EventArgs e)
		{
			using (frmNewNotebook frm = new frmNewNotebook(this))
			{
				frm.ShowDialog(this);

				if (frm.LocalNotebook != null)
				{
					await frm.LocalNotebook.Create(this);
					LoadNotebooks();
				}
			}
		}

		private async void	mnuNotebook_Delete_Click(object sender, EventArgs e)
		{
			using (frmMessage frm = new frmMessage(frmMessage.OperationType.DeleteNotebook, CurrentNotebook.Name.Replace("\\", ""), "", this))
			{
				frm.ShowDialog(this);

				if (frm.Result == frmMessage.ReturnResult.Yes)
				{
					//CurrentNotebook.Delete_original();
					CurrentNotebook.Delete();
					ddlNotebooks.Text = string.Empty;
					lstEntries.Items.Clear();
					ShowHideMenusAndControls(SelectionState.NotebookSelectedNotLoaded);
					await Utilities.PopulateAllNotebooks();
					CurrentNotebook = null;
					LoadNotebooks();
				}
			}
		}

		private void		mnuNotebook_Export_Click(object sender, EventArgs e)
		{
			// How to export? Thinking needs a form of its own. to Excel, .txt, .pdf, encrypted for sharing?

			//using (frmSynchJournals frm = new frmSynchJournals(this))
			//{
			//	frm.ShowDialog();
			//	LoadJournals();
			//}

			//if (Program.AzurePassword.Length > 0)
			//{
			//	CloudSynchronizer cs = new CloudSynchronizer();
			//	await cs.SynchWithCloud();
			//}
		}

		private void		mnuNotebook_ForceBackup_Click(object sender, EventArgs e)
		{
			string sMsg = CurrentNotebook.BackupCompleted ? "The backup was completed" : "An error occurred. The backup was not completed.";
			GenerateMesssage(sMsg);
		}

		private async void	mnuNotebook_Import_Click(object sender, EventArgs e)
		{ await Utilities.ImportNotebooks(this); LoadNotebooks(); ShowHideMenusAndControls(SelectionState.NotebookNotSelected); }

		private void		mnuNotebook_Print_Click(object sender, EventArgs e) 
		{ CurrentNotebook.Print(this, ((ToolStripMenuItem)sender).Name.ToLower().Contains("json")); }

		private async void	mnuNotebook_Rename_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			using (frmMessage frm = new(frmMessage.OperationType.InputBox, "Enter the new notebook name.", CurrentNotebook.Name, this))
			{
				frm.ShowDialog(this);

				if (frm.Result == frmMessage.ReturnResult.Ok && frm.ResultText.Length > 0)
				{
					var newName = GetUniqueNotebookName(frm.ResultText);
					await CurrentNotebook.Rename(frm.ResultText, true);
					LoadNotebooks();

					for(int i = 0; i < ddlNotebooks.Items.Count; i++)
					{
						if (((ListItem)ddlNotebooks.Items[i]).Name == frm.ResultText) { ddlNotebooks.SelectedIndex = i; return; }
					}
						
					ddlNotebooks.SelectedIndex = ddlNotebooks.Items.IndexOf(frm.ResultText); 
				}
				else if (frm.ResultText != null && frm.ResultText.Length == 0)
				{ GenerateMesssage("You must enter a new name.", null, "Name Required"); }
			}
			this.Cursor = Cursors.Default;
		}

		private async void	mnuNotebook_ResetPIN_Click(object sender, EventArgs e)
		{
			await CurrentNotebook.ResetPIN(this);
			if (CurrentNotebook.Saved) { LoadNotebooks(); }
		}

		private async void	mnuNotebook_RestoreBackups_Click(object sender, EventArgs e)
		{
			try
			{
				string fname = Utilities.GetDialogResult(new OpenFileDialog(), "MyNotebooks backup files (*.mnbak)|*.mnbak", "", "Open Notebook Backup File");
				Notebook nb = fname.Length > 0 ? JsonSerializer.Deserialize<Notebook>(File.ReadAllText(fname)) : null;

				if (nb != null) 
				{
					nb.Name = GetUniqueNotebookName(Path.GetFileName(fname.Substring(0, fname.IndexOf("."))) + "-restored");
					if(nb.Name != null)
					{
						nb.Id = 0;
						await nb.Create(this);
						LoadNotebooks();
						ddlNotebooks.SelectedIndex = ddlNotebooks.Items.Count - 1;
					}
				}
			}
			catch (Exception ex)
			{ GenerateMesssage("An Error Occurred.", ex); }
		}

		private void		mnuNotebook_Search_Click(object sender, EventArgs e)
		{
			using (frmSearch frm = new(this))
			{
				try
				{
					frm.ShowDialog();
					if (frm.NotebookName != null && frm.NotebookName.Length > 0) { LoadNotebooks(); }
				}
				catch (Exception ex)
				{ GenerateMesssage("An Error Occurred", ex); }
			}
		}

		private void		mnuNotebooks_Select_Click(object sender, EventArgs e)
		{
			using (frmSelectNotebooksToSearch frm = new frmSelectNotebooksToSearch(this,
				"Select notebooks to work with. Be sure to add a PIN for any protected notebooks."))
			{ frm.ShowDialog(this); }
		}

		private async void	mnuNotebook_Settings_Click(object sender, EventArgs e)
		{
			using (frmNotebookSettings frm = new frmNotebookSettings(CurrentNotebook, this))
			{
				frm.ShowDialog();
				if (frm.IsDirty) { await CurrentNotebook.Save(); }
				//frm.Close();
			}
			SetDisplayText();
		}

		private async void	mnuSwitchAccount_Click(object sender, EventArgs e)
		{
			Program.User = null;
			using (frmUserLogin frm = new()) { frm.ShowDialog(); }

			//frmAzurePwd ap = new frmAzurePwd(this, frmAzurePwd.Mode.ChangingKey);

			//if (ap.KeyChanged)
			//{
			//	CheckForSystemDirectories(true);

			//	if (Program.AzurePassword.Length > 0)
			//	{
			//		CloudSynchronizer cs = new CloudSynchronizer();
			//		//await cs.SynchWithCloud();
			//	}
			//}
		}

		private async Task	PopulateLabelsSummary()
		{
			//foreach (var label in LabelsManager.GetLabels_NoFileDate())
			//{
			//	var v = CurrentNotebook.Entries.Where(e => e.Labels.Contains(label)).ToList();
			//	if (v.Count > 0)
			//	{
			//		ToolStripMenuItem item = new ToolStripMenuItem(label + " (" + v.Count + ")", null, menuLabelsSummary_Click);
			//		item.Tag = label;
			//		mnuLabelsSummary.DropDownItems.Add(item);
			//	}
			//}
		}

		private void		PopulateShowFromDates()
		{
			SuppressDateClick = true;
			cbxDatesFrom.DataSource = null;
			cbxDatesTo.Items.Clear();
			List<string> l = CurrentNotebook.Entries.Select(e => e.CreatedOn.ToString(ConfigurationManager.AppSettings["ShortDateFormat"])).Distinct().ToList();
			l.Sort((x, y) => -DateTime.Parse(x).CompareTo(DateTime.Parse(y)));
			cbxDatesFrom.DataSource = l;
			//cbxDatesTo.DataSource = l;
			//cbxDatesTo.Items.AddRange(cbxDates.Items.Cast<Object>().ToArray());
			foreach (string s in cbxDatesFrom.Items) { cbxDatesTo.Items.Add(s); }
			cbxDatesTo.SelectedIndex = 0;
			SuppressDateClick = false;
		}

		private async Task	ProcessDateFiltersAndPopulateEntries()
		{
			if (cbxDatesFrom.Text.Length > 0 && cbxDatesTo.Text.Length > 0)
			{
				if (DateTime.Parse(cbxDatesFrom.Text) > DateTime.Parse(cbxDatesTo.Text))
				{ GenerateMesssage("The 'from' date must be earlier than the 'to' date.", null, "Check Your Dates"); }
				else
				{
					await Utilities.PopulateEntries(lstEntries, CurrentNotebook.Entries, CurrentNotebook.Name,
						cbxDatesFrom.Text, cbxDatesTo.Text, true, cbxSortEntriesBy.SelectedIndex, false, lstEntries.Width - 85);

					lblEntriesCount.Text = string.Format(FoundCountString, (lstEntries.Items.Count / 4).ToString(), CurrentNotebook.Entries.Count.ToString());
				}
			}
		}

		private void		PromptForBackup()
		{
			frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Would you like to back up '" + 
				CurrentNotebook.Name +"'?", "Backup Notebook?", this);
			frm.ShowDialog();
			if (frm.Result == frmMessage.ReturnResult.Yes) { mnuNotebook_Print_Click(mnuNotebook_Backups_CreateJSON, null); }
		}

		private void		rtbSelectedEntry_MouseDown(object sender, MouseEventArgs e)
		{
			lstEntries.Focus();
		}

		private void		SelectShortEntry(object sender)
		{
			List<int> targets = new List<int>();
			ListBox lb = (ListBox)sender;

			try
			{
				if (lb.SelectedIndices.Count > 1)
				{
					for (var i = 0; i < lb.SelectedIndices.Count - 1; i++)
					{
						if (lb.SelectedIndices[i] == lb.SelectedIndices[i + 1] - 1)
						{
							targets.Add(lb.SelectedIndices[i]);
							targets.Add(lb.SelectedIndices[i + 1]);
							targets.Add(lb.SelectedIndices[i + 2]);
							break;
						}
					}
				}
			}
			catch (Exception) { }

			if (targets.Count == 3)
			{
				foreach (var i in targets)
				{
					lb.SelectedIndices.Remove(i);
				}
			}

			var ctr = lb.SelectedIndex;

			if (lb.Items[ctr].ToString().StartsWith("--")) { ctr--; }

			while (!lb.Items[ctr].ToString().StartsWith("--") & ctr > 0)
			{
				ctr--;
				if (ctr < 0) break;
			}

			if (ctr > 0) { ctr += 1; }
			lb.SelectedIndices.Clear();                             // Select the whole short entry ...
			lb.SelectedIndices.Add(ctr);
			lb.SelectedIndices.Add(ctr + 1);
			lb.SelectedIndices.Add(ctr + 2);                        //
		}

		private void		SetDisplayText()
		{
			this.Text = this.Text.EndsWith(" (local)") ? this.Text.Replace(" (local)", "") : this.Text;
			//this.Text = CurrentNotebook != null ? CurrentNotebook.Settings.AllowCloud ? this.Text : this.Text + " (local)" : this.Text;
		}

		private async void	ShowHideMenusAndControls(SelectionState st)
		{
			if (st == SelectionState.NotebookSelectedNotLoaded)
			{
				rtbSelectedEntry.Text = string.Empty;
				rtbSelectedEntry.Visible = false;
				pnlDateFilters.Visible = false;

				lblSeparator.Visible = false;
				lblSelectionType.Visible = false;
				lblEntries.Visible = false;

				mnuEntryTop.Enabled = false;
				mnuEntryCreate.Enabled = false;
				mnuEntryDelete.Enabled = false;
				mnuEntryEdit.Enabled = false;

				mnuNotebook_Delete.Enabled = false;
				mnuNotebook_Rename.Enabled = false;
				mnuNotebook_Backups_Create.Enabled = false;
				mnuNotebook_ForceBackup.Enabled = false;
				mnuNotebook_Export.Enabled = true;
				mnuNotebook_Settings.Enabled = false;
				mnuLabelsSummary.DropDownItems.Clear();
				mnuLabelsSummary.Enabled = false;

				btnResetLabelFilter.Visible = false;
				//pnlPin.Visible = true;
				SetDisplayText();
			}
			else if (st == SelectionState.NotebookLoaded)
			{
				ShowHideMenusAndControls(SelectionState.NotebookSelectedNotLoaded);

				lstEntries.Visible = true;
				lstEntries.Height = this.Height - 160;
				lstEntries.Top = pnlDateFilters.Top + pnlDateFilters.Height + 5;
				lblEntries.Top = lstEntries.Top - lblEntries.Height - 3;
				lblEntries.Visible = true;
				//pnlPin.Visible = false;

				mnuEntryTop.Enabled = true;
				mnuEntryCreate.Enabled = true;

				mnuNotebook_Delete.Enabled = true;
				mnuNotebook_Rename.Enabled = true;
				mnuNotebook_Backups_Create.Enabled = true;
				mnuNotebook_ForceBackup.Enabled = true;
				//mnuJournal_Export.Enabled = currentJournal.Settings.AllowCloud;
				mnuNotebook_Settings.Enabled = true;
				mnuLabelsSummary.Enabled = true;

				btnLoadNotebook.Enabled = false;
				txtJournalPIN.Text = string.Empty;
				pnlDateFilters.Visible = true;
				SetDisplayText();
				await PopulateLabelsSummary();
			}
			else if (st == SelectionState.EntrySelected)
			{
				rtbSelectedEntry.Visible = true;

				mnuEntryEdit.Enabled = true;
				mnuEntryDelete.Enabled = true;

				lblSeparator.Visible = true;
				lblSelectionType.Visible = true;
				//lblEntries.Visible = true;
			}
			else if (st == SelectionState.NotebookNotSelected)
			{
				//pnlPin.Visible = false;
				pnlDateFilters.Visible = false;
				lblSeparator.Visible = false;
				lstEntries.Visible = false;
				rtbSelectedEntry.Visible = false;
				lblSelectionType.Visible = false;
				lblEntries.Visible = false;
			}
		}

		private void		txtNotebookPIN_TextChanged(object sender, EventArgs e)
		{
			if (txtJournalPIN.Text.Length > 0)
			{
				btnLoadNotebook.Enabled = true;
				lblShowPIN.Visible = true;
				lblWrongPin.Visible = false;
			}
		}

		protected override CreateParams CreateParams {
			get {
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}
	}
}