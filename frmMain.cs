/* Main form.
	04/01/22

	bug list:
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


	toDo:
		07/07/22 001 Entry RTB formatting controls.
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
				 008x Disallow clicking/typing in Selected Entry text on frmMain.
					07/10/22 1145 Done.
				 009x PIN show/hide on frmNewJournal.
					7/10/22 1400 Done.
		07/10/22 010x Search criteria is case sensitive. Should be a user choice (default insensitive).
					07/11/22 1430 Fixed.
				 011x Add Yes/No/Cancel prompt for Cancel/Exit on frmNewEntry.
					1130 Done.

	07/13/22 Dev. closed. v1.0 released.

	bugs/hotfixes:
		bugs: 
		001x 07/23/22 1330
			Fatal error when selecting an entry from lstEntries AFTER selecting entry > clicking 'week' or 'month' filter > selecting one of the entries shown in the filtered results.
			08/02/22 Declared fixed. Bug hasn't been seen since this incident. It is probably related to old journals and entries. Deleted all old test journals.

		002X 08/02/22 07:20
			There's a problem with date display. Some (older?) entry dates are "H:m:s" and others are "HH:mm:ss".
			09/10/22 FIXED

		003x 11/27/22
			Replicate sequence: 
				> Open a PIN-protected journal 
				> Open Create Entry 
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
				Switch to JournalSelected mode when returning from Entry > Create.
				Tested OK 11/27/22. The mode switch was already programmed for Entry delete and Entry edit modes - just wasn't doing that for Create.

		toDo:
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
						Need to scan for orphaned labels after an import. Put a new method in Journal.cs - 'AllLabels()'?
					> 02/24/23 All is working, clickonce + cloud sync. Marked complete.

		12/07/22
			003 checkbox lists

	***************************************************************************************************************************************
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

 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using myNotebooks.objects;
using MyNotebooks.objects;
using myNotebooks.DataAccess;

namespace myNotebooks.subforms
{
	public partial class frmMain : Form
	{
		Notebook CurrentNotebook;
		Entry CurrentEntry;
		private bool FirstSelection = true;
		bool SuppressDateClick = false;
		string FoundCountString = "showing {0} of {1} entries";
		private int SelectedNotebookId;
		private KeyValuePair<int, string> SelectedNotebookIds;

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
			NotebookEntry	= 1,
			Notebook		= 2,
			Group			= 3,
			Department		= 4,
			Account			= 5,
			Company			= 6
		}

		public frmMain() { InitializeComponent(); }

		private string GetRandomLabels()
		{
			var rnd = new Random();
			string[] labels = LabelsManager.GetLabels_NoFileDate();
			string[] rtrn = { "", "" };
			rtrn[0] = labels[rnd.Next(labels.Length)];
			rtrn[1] = labels[rnd.Next(labels.Length)];
			return string.Join(',', rtrn);
		}

		private async void frmMain_Activated(object sender, EventArgs e)
		{
			//if(Program.AllNotebooks.Count == 0) await Utilities.PopulateAllNotebooks();
		}

		private async void frmMain_Load(object sender, EventArgs e)
		{
			if(Program.NotebooksNamesAndIds.Count == 0)
			{
				if(Program.User == null)
				{
					using (frmUserLogin frm = new()) { frm.ShowDialog(); }

					// if we don't have a user, disable all main menus except mnuSwitchAccounts
					if (Program.User == null)
					{
						foreach (ToolStripItem mnu in menuStrip1.Items) { mnu.Enabled = false; }
						mnuSwitchAccount.Enabled = true;
					}

					using (frmManagementConsole frm = new(this, true)) { frm.ShowDialog(); }

					if (Program.ActiveNBParentId == -1) { this.Close(); return; }
				}
			}

			this.Cursor = Cursors.WaitCursor;
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
			this.Text = fvi.ProductName + " " + Program.AppVersion + (fvi.FileName.ToLower().Contains("debug") ? " - DEBUG MODE" : "");

			#region one-time code

			// convert Journal objects to LocalNotebook objects

			//using (Stream stream = File.Open("C:\\Users\\js_ru\\source\\repos\\myJournal2022\\bin\\Debug\\netcoreapp3.1\\journals - Copy\\The New Real Thing", FileMode.Open))
			//{
			//	BinaryFormatter formatter = new BinaryFormatter();
			//	Journal jRtrn = (Journal)formatter.Deserialize(stream);
			//	LocalNotebook nb = new LocalNotebook(jRtrn);
			//	await nb.Create();

			//	//LocalNotebook nb = (LocalNotebook)formatter.Deserialize(stream);
			//	//jRtrn.FileName = journalToOpen;
			//	//jRtrn.Name = journalToOpen.Substring(journalToOpen.LastIndexOf("\\") + 1);
			//}

			//one - time code to create test notebooks
			//LocalNotebook newNotebook;
			//Entry newEntry;

			//for (var i = 0; i < 10; i++)
			//{
			//	Program.PIN = "";
			//	newNotebook = new("Project " + i.ToString());
			//	newNotebook.LastSaved = DateTime.Now;
			//	//newNotebook.FileName = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"] + newNotebook.Name;
			//	var rnd = new Random(Guid.NewGuid().GetHashCode());

			//	Entry newEntry1 = new Entry("created", "-", "-", "", newNotebook.Name); // Utilities.CreateEntry("created", "-", "-", "", newNotebook.Name, Program.PIN);
			//	newEntry1.CreatedOn = DateTime.Parse("01/01/23 1:00 AM");
			//	newNotebook.Entries.Add(newEntry1);

			//	for (var j = 0; j < 5; j++)
			//	{
			//		newEntry = new Entry("Entry " + j + 1.ToString() + " in " + newNotebook.Name,
			//			"This is the entry text for entry " + rnd.Next(1, 150), "{rtf", GetRandomLabels(), newNotebook.Name);

			//		//newEntry = Utilities.CreateEntry("Entry " + j + 1.ToString() + " in " + newNotebook.Name,
			//		//	"This is the entry text for entry " + rnd.Next(1, 150), "{rtf", GetRandomLabels(), newNotebook.Name, Program.PIN);

			//		newEntry.CreatedOn = DateTime.Now.AddDays(-Convert.ToDouble(rnd.Next(1, 150)));
			//		newNotebook.Entries.Add(newEntry);
			//	}

			//	newNotebook.Settings = new NotebookSettings { AllowCloud = true };
			//	await newNotebook.Create(false);
			//}

			// fix The New Real Thing entries
			//Program.PIN = "0711";
			//LocalNotebook nb = new LocalNotebook("The New Real Thing").Open();

			////fix some entries.RTF property is blank.
			////List<Entry> v = nb.Entries.Where(e => e.RTF.Length == 0).ToList();
			////v.ForEach(e => e.RTF = "{rtf");
			////// nb.Entries.ForEach(E => E.NotebookName = EncryptDecrypt.Encrypt("The New Real Thing"));
			////nb.Create();

			//// fix The New Real Thing problem of Entry[0] is not the 'created' entry.
			////LocalNotebook nb = new LocalNotebook("The New Real Thing").Open();
			////Program.PIN = "0711";
			//Entry entry = new Entry("created", "-", "{f", "The New Real Thing");
			//entry.CreatedOn = DateTime.Parse("12/01/2021 12:00 AM");
			//nb.Entries.Insert(0, entry);
			//nb.Create();
			//List<Entry> indx = nb.Entries.Where(e => e.Title == EncryptDecrypt.Encrypt("created")).ToList();
			//nb.FileName = EncryptDecrypt.Encrypt(nb.FileName);
			//nb.Name = EncryptDecrypt.Encrypt(nb.Name);
			//nb.Create();

			// fix all NotebookName values (encrypt them)
			//Utilities.PopulateAllNotebooks();
			//Program.PIN = "";

			//foreach(LocalNotebook nb in Program.AllNotebooks)
			//{
			//	foreach(Entry en in nb.Entries)
			//	{
			//		var name = en.NotebookName;

			//		en.NotebookName = EncryptDecrypt.Encrypt(nb.Name);

			//	}
			//	nb.Entries.ForEach(e => e.NotebookName = EncryptDecrypt.Encrypt(nb.Name));
			//}

			#endregion

			//CheckForSystemDirectories();    // Am I keeping system directories now that the cloud is working? Why or why not? 08/11/23 - No. Cloud only (db) from this date.

			//using (frmAzurePwd frm = new frmAzurePwd(this, frmAzurePwd.Mode.AskingForKey))
			//{ if (Program.AzurePassword.Length > 0) { frm.Close(); } }

			Program.AzurePassword = string.Empty;   // Kills the Azure synch process for debugging if desired.

			if (Program.User.AccessLevel < 2)
			{
				using (frmSelectNotebooksToSearch frm = new frmSelectNotebooksToSearch
					(this, "Select notebooks to work with. Notebooks which are PIN-protected can't be synchronized unless you provide the PIN."))
				{ frm.ShowDialog(); }
			}
			else
			{
				// navigate to the user's notebooks in their assigned group.
			}

			// Populate Program.DictCheckedNotebooks

			// program.dictcheckednotebooks should be populated at this point.

			pnlDateFilters.Left = pnlPin.Left - 11;
			ShowHideMenusAndControls(SelectionState.HideAll);
			//await Utilities.PopulateAllNotebookNames();

			if (Program.AzurePassword.Length > 0)
			{
				//CloudSynchronizer cs = new CloudSynchronizer();
				//await cs.SynchWithCloud(false, null, true);
			}

			LoadNotebooks();

			if (ddlNotebooks.Items.Count == 0)
			{
				//using(frmManagementConsole frm = new(this, true)) { frm.ShowDialog(); }

				//using (frmNewNotebook frm = new frmNewNotebook(this))
				//{
				//	frm.ShowDialog();

				//	if (frm.LocalNotebook != null)
				//	{
				//		await frm.LocalNotebook.Create();

				//		LoadNotebooks();
				//	}
				//	else
				//	{
				//		using (frmMessage frm2 = new frmMessage(frmMessage.OperationType.Message, "At least one notebook must exist. " +
				//			"Please re-open the program and create a notebook.", "One LocalNotebook Must Exist", this))
				//		{ frm2.ShowDialog(); this.Close(); }
				//	}
				//}
			}

			this.Cursor = Cursors.Default;
		}

		private void frmMain_Resize(object sender, EventArgs e)
		{
			if (!rtbSelectedEntry.Visible)
			{
				lstEntries.Height = this.Height - 160;
				lstEntries.Width = this.Width - 40;
			}
		}

		private async void btnLoadNotebook_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			lstEntries.Items.Clear();
			rtbSelectedEntry.Text = string.Empty;
			Program.PIN = txtJournalPIN.Text;
			lblWrongPin.Visible = false;
			if (CurrentNotebook != null && Program.DictCheckedNotebooks.Count == 1 && Program.DictCheckedNotebooks.Keys.Contains(CurrentNotebook.Name)) { Program.DictCheckedNotebooks.Clear(); }
			if (Program.DictCheckedNotebooks.Count == 0) { Program.DictCheckedNotebooks.Add(ddlNotebooks.Text, txtJournalPIN.Text); }

			CurrentNotebook = DbAccess.GetNotebookWithShortEntries(SelectedNotebookIds.Key, SelectedNotebookIds.Value);

			var wrongPIN = true;

			if (CurrentNotebook != null)
			{
				Program.SelectedNotebookName = CurrentNotebook.Name;

				if (CurrentNotebook.Entries.Count == 0)
				{
					ShowHideMenusAndControls(SelectionState.NotebookLoaded);
				}
				else
				{
					wrongPIN = CurrentNotebook.WrongPIN;

					if (!wrongPIN && !Program.AllNotebookNames.Contains(CurrentNotebook.Name))
					{
						Program.AllNotebooks.Add(CurrentNotebook);
					}

					if (wrongPIN)
					{
						lblWrongPin.Visible = true;
						txtJournalPIN.Focus();
						txtJournalPIN.SelectAll();
					}
					else
					{
						try
						{
							if (CurrentNotebook != null)
							{
								PopulateShowFromDates();
								SuppressDateClick = true;
								await ProcessDateFiltersAndPopulateEntries();
								SuppressDateClick = false;
								lstEntries.Height = this.Height - lstEntries.Top - 50;
								mnuLabels.Enabled = false;
								//lstEntries.Visible = true;
								//pnlDateFilters.Visible = true;

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
							}
							else
							{
								lstEntries.Focus();
							}
						}
						catch (Exception ex) { Console.Write(ex.Message); }
					}
				}
			}

			this.Cursor = Cursors.Default;
		}

		private async void btnResetLabelFilter_Click(object sender, EventArgs e)
		{
			await ProcessDateFiltersAndPopulateEntries();
			ShowHideMenusAndControls(SelectionState.NotebookLoaded);
		}

		private async void cbxDates_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!SuppressDateClick) { await ProcessDateFiltersAndPopulateEntries(); }
		}

		private async void cbxSortEntriesBy_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (CurrentNotebook != null)
			{
				await ProcessDateFiltersAndPopulateEntries();
				lstEntries.Focus();
			}
		}

		public static void CopyDirectory(DirectoryInfo source, DirectoryInfo target, bool copySubDirectories, bool clearTargetFolderBeforeCopy)
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

		private void CheckForSystemDirectories(bool recreateAll = false)
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

		private void ddlNotebooks_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowHideMenusAndControls(SelectionState.NotebookSelectedNotLoaded);
			btnLoadNotebook.Enabled = true;
			txtJournalPIN.Focus();
			CurrentEntry = null;
			CurrentNotebook = null;
			cbxDatesFrom.DataSource = null;
			lblWrongPin.Visible = false;
			lstEntries.Items.Clear();
			lstEntries.Visible = false;
			cbxSortEntriesBy.SelectedIndex = 0;
			pnlPin.Visible = ddlNotebooks.SelectedIndex > -1;
			txtJournalPIN.Text = Program.DictCheckedNotebooks.FirstOrDefault(e => e.Key == ddlNotebooks.Text).Value;
			pnlDateFilters.Visible = false;
			var v = ddlNotebooks.SelectedItem as ListItem;
			SelectedNotebookId = v.Id;
			SelectedNotebookIds = new(v.Id, v.Name);
		}

		private void ddlNotebooks_Click(object sender, EventArgs e)
		{ if (ddlNotebooks.Items.Count > 0) { ddlNotebooks.DroppedDown = true; } }

		private void lblSeparator_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				lblSeparator.Top += e.Y;
				Utilities.ResizeListsAndRTBs(lstEntries, rtbSelectedEntry, lblSeparator, lblSelectionType, this);
				lstEntries.TopIndex = lstEntries.SelectedIndices.Count > 0 ? lstEntries.SelectedIndices[0] : 0;
			}
		}

		private void lblShowPIN_Click(object sender, EventArgs e)
		{
			txtJournalPIN.PasswordChar = txtJournalPIN.PasswordChar == '*' ? '\0' : '*';
			lblShowPIN.Text = lblShowPIN.Text == "show" ? "hide" : "show";
		}

		private void LoadFonts()
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

		private async void LoadNotebooks()
		{
			ddlNotebooks.Items.Clear();
			ddlNotebooks.Text = string.Empty;
			if (Program.NotebooksNamesAndIds.Count == 0) await Utilities.PopulateAllNotebookNames();

			foreach (var v in Program.NotebooksNamesAndIds)
			{
				ListItem lvi = new ListItem() { Name = v.Key, Id = v.Value };
				ddlNotebooks.Items.Add(lvi);
			}

			ddlNotebooks.DisplayMember = "Name";
			ddlNotebooks.ValueMember = "Id";

			if (ddlNotebooks.Items.Count > 0)
			{
				ddlNotebooks.Enabled = true;
				pnlPin.Visible = false;

				if (ddlNotebooks.Items.Count == 1)
				{
					ddlNotebooks.SelectedIndex = 0;
					ShowHideMenusAndControls(SelectionState.NotebookSelectedNotLoaded);
					txtJournalPIN.Focus();
				}
				else
				{
					ShowHideMenusAndControls(SelectionState.NotebookNotSelected);
				}

				txtJournalPIN.Focus();
			}
		}

		private void lstEntries_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				bool entryClicked = lstEntries.SelectedIndices.Contains((e.Y / 15) + lstEntries.TopIndex);
				mnuEntryEdit.Visible = entryClicked;
				mnuEntryDelete.Visible = entryClicked;
				mnuEntryCreate.Visible = !entryClicked;
			}
		}

		private void lstEntries_SelectEntry(object sender, EventArgs e)
		{
			ListBox lb = (ListBox)sender;
			RichTextBox rtb = rtbSelectedEntry;

			if (lb.SelectedIndex > -1)
			{
				lb.SelectedIndexChanged -= new System.EventHandler(this.lstEntries_SelectEntry);
				CurrentEntry = Entry.Select(rtb, lb, CurrentNotebook, FirstSelection, null, true);

				if (CurrentEntry != null)       //&& !CurrentEntry.Id.Equals(currentId)) // Disallow modification of the 'created' entry.
				{
					CurrentEntry = DbAccess.GetFullEntry(CurrentEntry);
					FirstSelection = false;
					lblSelectionType.Visible = rtb.Text.Length > 0;
					lblSeparator.Visible = rtb.Text.Length > 0;
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

		private async void menuLabelsSummary_Click(object sender, System.EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			List<Entry> v = CurrentNotebook.Entries.Where(e => e.Labels.Contains(item.Tag.ToString())).ToList();
			await Utilities.PopulateEntries(lstEntries, v, "", "", "", true, 0, false, 0, item.Tag.ToString());
			btnResetLabelFilter.Visible = true;
			lblEntriesCount.Text = string.Format(FoundCountString, (lstEntries.Items.Count / 4).ToString(), CurrentNotebook.Entries.Count.ToString());
		}

		private void mnuAbout_Click(object sender, EventArgs e)
		{
			Form frm = new frmAbout(this);
			frm.ShowDialog(this);
		}

		private async void mnuAdministratorConsole_Click(object sender, EventArgs e)
		{
			using (frmManagementConsole frm = new(this))
			{
				frm.ShowDialog();

				if (Program.ActiveNBParentId > 0)
				{
					LoadNotebooks();
					ShowHideMenusAndControls(SelectionState.NotebookNotSelected);
				}
			}
		}

		private async void mnuEntryCreate_Click(object sender, EventArgs e)
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
				}
			}

			this.Cursor = Cursors.Default;
		}

		private async void mnuEntryDelete_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.DeleteEntry, CurrentEntry.Title, "", this))
			{
				frm.ShowDialog(this);

				if (frm.Result == frmMessage.ReturnResult.Yes)
				{
					CurrentNotebook.Entries.Remove(CurrentEntry);
					await CurrentNotebook.Save();
					await ProcessDateFiltersAndPopulateEntries();
					ShowHideMenusAndControls(SelectionState.NotebookLoaded);
				}
			}

			this.Cursor = Cursors.Default;
		}

		private async void mnuEntryEdit_Click(object sender, EventArgs e)
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
					if(CurrentEntry.LabelsToRemove == null) await CurrentNotebook.Save();
					await ProcessDateFiltersAndPopulateEntries();
					var v = lstEntries.Items.OfType<string>().FirstOrDefault(e => e.StartsWith(CurrentEntry.Title));
					lstEntries.SelectedIndex = lstEntries.Items.IndexOf(v);
				}
			}

			this.Cursor = Cursors.Default;
		}

		private async void mnuLabels_Click(object sender, EventArgs e)
		{
			using (frmLabelsManager frm = new frmLabelsManager(this, false, CurrentNotebook, CurrentEntry))
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

		private async void mnuNotebook_Create_Click(object sender, EventArgs e)
		{
			using (frmNewNotebook frm = new frmNewNotebook(this))
			{
				frm.ShowDialog(this);

				if (frm.LocalNotebook != null && frm.LocalNotebook.Name.Length > 0)
				{
					//frm.LocalNotebook.EditedOn = DateTime.Now;
					//frm.LocalNotebook.FileName = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"] + frm.LocalNotebook.Name;
					await frm.LocalNotebook.Create();
					//await Utilities.PopulateAllNotebookNames();
					LoadNotebooks();
				}
			}
		}

		private async void mnuNotebook_Delete_Click(object sender, EventArgs e)
		{
			using (frmMessage frm = new frmMessage(frmMessage.OperationType.DeleteNotebook, CurrentNotebook.Name.Replace("\\", ""), "", this))
			{
				frm.ShowDialog(this);

				if (frm.Result == frmMessage.ReturnResult.Yes)
				{
					CurrentNotebook.Delete_original();
					ddlNotebooks.Text = string.Empty;
					lstEntries.Items.Clear();
					ShowHideMenusAndControls(SelectionState.NotebookSelectedNotLoaded);
					await Utilities.PopulateAllNotebookNames();
					CurrentNotebook = null;
					LoadNotebooks();
				}
			}
		}

		private void mnuNotebook_Export_Click(object sender, EventArgs e)
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

		private void mnuNotebook_ForceBackup_Click(object sender, EventArgs e)
		{
			CurrentNotebook.Backup_Forced();
			string sMsg = CurrentNotebook.BackupCompleted ? "The backup was completed" : "An error occurred. The backup was not completed.";
			using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, sMsg, "", this)) { frm.ShowDialog(this); }
		}

		private async void mnuNotebook_Import_Click(object sender, EventArgs e)
		{ await Utilities.ImportNotebooks(this); LoadNotebooks(); ShowHideMenusAndControls(SelectionState.NotebookNotSelected); }

		private async void mnuNotebook_Rename_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			using (frmMessage frm = new frmMessage(frmMessage.OperationType.InputBox, "Enter the new notebook name.", CurrentNotebook.Name, this))
			{
				frm.ShowDialog(this);

				if (frm.Result == frmMessage.ReturnResult.Ok && frm.ResultText.Length > 0)
				{
					if (frm.ResultText != CurrentNotebook.Name)
					{
						await CurrentNotebook.Rename(frm.ResultText, true);
						await Utilities.PopulateAllNotebookNames();
						LoadNotebooks();
					}
					else
					{ using (frmMessage frm2 = new frmMessage(frmMessage.OperationType.Message, "The name has not been changed.", "Name Not Changed")) { frm2.ShowDialog(); } }
				}
				else if (frm.ResultText != null && frm.ResultText.Length == 0)
				{
					using (frmMessage frm3 = new frmMessage(frmMessage.OperationType.Message, "You must enter a new name.", "Name Required")) { frm3.ShowDialog(); }
				}
			}
			this.Cursor = Cursors.Default;
		}

		private async void mnuNotebook_ResetPIN_Click(object sender, EventArgs e)
		{
			await CurrentNotebook.ResetPIN(this);
			if (CurrentNotebook.Saved) { LoadNotebooks(); }
		}

		private async void mnuNotebook_RestoreBackups_Click(object sender, EventArgs e)
		{
			string sJournalName = ddlNotebooks.Text;
			using (frmBackupManager frm = new frmBackupManager(this))
			{
				frm.ShowDialog(this);
				if (frm.BackupRestored) { await Utilities.PopulateAllNotebookNames(); LoadNotebooks(); }
			}
		}

		private void mnuNotebook_Search_Click(object sender, EventArgs e)
		{
			using (frmSearch frm = new(this))
			{
				try
				{
					frm.ShowDialog();
					if (frm.NotebookName != null && frm.NotebookName.Length > 0) { LoadNotebooks(); }
				}
				catch (Exception ex)
				{
					using (frmMessage frmMsg = new frmMessage(frmMessage.OperationType.Message, ex.Message, "An error occurred", this))
					{ frmMsg.ShowDialog(); }
				}
			}
		}

		private void mnuNotebooks_Select_Click(object sender, EventArgs e)
		{
			using (frmSelectNotebooksToSearch frm = new frmSelectNotebooksToSearch(this,
				"Select notebooks to work with. Be sure to add a PIN for any protected notebooks."))
			{ frm.ShowDialog(this); }
		}

		private async void mnuNotebook_Settings_Click(object sender, EventArgs e)
		{
			using (frmNotebookSettings frm = new frmNotebookSettings(CurrentNotebook, this))
			{
				frm.ShowDialog();
				if (frm.IsDirty) { await CurrentNotebook.Save(); }
				//frm.Close();
			}
			SetDisplayText();
		}

		private async void mnuSwitchAccount_Click(object sender, EventArgs e)
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

		private async Task PopulateLabelsSummary()
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

		private void PopulateShowFromDates()
		{
			SuppressDateClick = true;
			cbxDatesFrom.DataSource = null;
			cbxDatesTo.Items.Clear();
			List<string> l = CurrentNotebook.Entries.Select(e => e.CreatedOn.ToShortDateString()).Distinct().ToList();
			l.Sort((x, y) => -DateTime.Parse(x).CompareTo(DateTime.Parse(y)));
			cbxDatesFrom.DataSource = l;
			//cbxDatesTo.Items.AddRange(cbxDates.Items.Cast<Object>().ToArray());
			foreach (string s in cbxDatesFrom.Items) { cbxDatesTo.Items.Add(s); }
			cbxDatesTo.SelectedIndex = 0;
			SuppressDateClick = false;
		}

		private async Task ProcessDateFiltersAndPopulateEntries()
		{
			if (cbxDatesFrom.Text.Length > 0 && cbxDatesTo.Text.Length > 0)
			{
				if (DateTime.Parse(cbxDatesFrom.Text) > DateTime.Parse(cbxDatesTo.Text))
				{
					using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "The 'from' date must be earlier than the 'to' date.", "Check Your Dates", this))
					{ frm.ShowDialog(); }
				}
				else
				{
					await Utilities.PopulateEntries(lstEntries, CurrentNotebook.Entries, CurrentNotebook.Name,
						cbxDatesFrom.Text, cbxDatesTo.Text, true, cbxSortEntriesBy.SelectedIndex, false, lstEntries.Width - 85);

					if (lstEntries.SelectedIndex == -1 && CurrentNotebook.Entries.Contains(CurrentEntry))
					{ Entry.Select(rtbSelectedEntry, lstEntries, null, true, CurrentEntry, true); }

					lblEntriesCount.Text = string.Format(FoundCountString, (lstEntries.Items.Count / 4).ToString(), CurrentNotebook.Entries.Count.ToString());
				}
			}
		}

		private void rtbSelectedEntry_MouseDown(object sender, MouseEventArgs e)
		{
			lstEntries.Focus();
		}

		private void SetDisplayText()
		{
			this.Text = this.Text.EndsWith(" (local)") ? this.Text.Replace(" (local)", "") : this.Text;
			//this.Text = CurrentNotebook != null ? CurrentNotebook.Settings.AllowCloud ? this.Text : this.Text + " (local)" : this.Text;
		}

		private async void ShowHideMenusAndControls(SelectionState st)
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
				mnuNotebook_ForceBackup.Enabled = false;
				mnuNotebook_Export.Enabled = true;
				mnuNotebook_Settings.Enabled = false;
				mnuLabelsSummary.DropDownItems.Clear();
				mnuLabelsSummary.Enabled = false;

				btnResetLabelFilter.Visible = false;
				pnlPin.Visible = true;
				SetDisplayText();
			}
			else if (st == SelectionState.NotebookLoaded)
			{
				ShowHideMenusAndControls(SelectionState.NotebookSelectedNotLoaded);

				lstEntries.Visible = true;
				lstEntries.Height = this.Height - 160;
				pnlPin.Visible = false;

				mnuEntryTop.Enabled = true;
				mnuEntryCreate.Enabled = true;

				mnuNotebook_Delete.Enabled = true;
				mnuNotebook_Rename.Enabled = true;
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
				lblEntries.Visible = true;
			}
			else if (st == SelectionState.NotebookNotSelected)
			{
				pnlPin.Visible = false;
				pnlDateFilters.Visible = false;
				lblSeparator.Visible = false;
				lstEntries.Visible = false;
				rtbSelectedEntry.Visible = false;
				lblSelectionType.Visible = false;
				lblEntries.Visible = false;
			}
		}

		private void txtNotebookPIN_TextChanged(object sender, EventArgs e)
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