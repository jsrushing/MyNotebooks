/* Journal object
 * Created on: 8/1//21
 * Created by: S. Rushing
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryption;
//using myJournal.objects;
//using myJournal.subforms;
using myJournal;
using myNotebooks;
using myNotebooks.objects;

namespace myJournal
{
	[Serializable]
	public class Journal
	{
		public string Name { get; set; }
		public DateTime LastSaved { get; set; }
		public string FileName { get; set; }
		public List<JournalEntry> Entries = new List<JournalEntry>();
		string root = "journals\\";
		public JournalSettings Settings;

		public bool BackupCompleted { get; private set; }

        public Journal(string _name = null, string _fileName = null) 
        {
            if(_name != null)
            {
				this.Name = _name;
				if (_fileName != null) { this.FileName = _fileName; } 
				else { this.FileName = Program.AppRoot + this.root + this.Name; }
			}
		}

  //      public void AddEntry(JournalEntry entryToAdd) { Entries.Add(entryToAdd); }

		//public void Backup()
		//{
		//	string dir = ConfigurationManager.AppSettings["FolderStructure_NotebookIncrementalBackupsFolder"];
		//	if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + dir))
		//	{ System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + dir); }
		//	this.Name = FileName.Substring(FileName.LastIndexOf("\\") + 1);
		//	File.Copy(this.FileName, AppDomain.CurrentDomain.BaseDirectory + dir + this.Name, true);
		//}

		//public void Backup_Forced()
		//{
		//	try
		//	{
		//		string dir = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_NotebookForcedBackupsFolder"];
		//		if (!System.IO.Directory.Exists(dir))
		//		{ System.IO.Directory.CreateDirectory(dir); }
		//		File.Copy(this.FileName, dir + this.Name);
		//		FileInfo fi = new FileInfo(dir + this.Name);
		//		File.Move(dir + this.Name, dir + this.Name + " (" + fi.CreationTime.ToString(ConfigurationManager.AppSettings["DateFormat_ForcedBackupFileName"] + ")"), true);
		//		BackupCompleted = true;
		//	}
		//	catch (Exception) { }
		//}

		//public async Task Create()
  //      {
		//	this.FileName += " (local)";
		//	Entries.Add(new JournalEntry("created", "-", "-", this.Name));
		//	Program.SkipFileSizeComparison = true;
		//	await this.Save();
		//	Program.SkipFileSizeComparison = false;
		//}

		//public async void Delete()
		//{
		//	if (this.Settings.AllowCloud) 
		//	{ await AzureFileClient.DownloadOrDeleteFile(this.FileName, Program.AzurePassword + this.Name, FileMode.Create, true);  }

		//	DeleteBackups();
		//	File.Delete(this.FileName);
		//}

		//private void DeleteBackups()
		//{
		//	File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebookIncrementalBackupsFolder"] + this.Name);
		//	File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebookForcedBackupsFolder"] + this.Name);
		//}

		//public async Task DeleteLabel(string label)
		//{
		//	var saveJournal = false;
		//	foreach (JournalEntry entry in this.Entries.Where(e => e.ClearLabels().Contains(label)).ToList())
		//	{ saveJournal = entry.RemoveOrReplaceLabel("", label, false); } 
			
		//	if(saveJournal) { await this.Save(); } 
		//}

  //      public JournalEntry GetEntry(string Title, string Date)
  //      {
		//	JournalEntry jeRtrn = null;
		//	try { jeRtrn = Entries.First(a => a.ClearTitle() == Title && a.Date.ToString("MM/dd/yy HH:mm:ss") == Date); }
		//	catch (Exception) { }
		//	return jeRtrn;
  //      }

		//public bool HasLabel(string Label) { return Entries.Where(e => e.ClearLabels().Contains(Label)).Any(); }

		public Journal Open(bool useFileName = false)
        {
            Journal jRtrn = null;
			var journalToOpen = useFileName ? this.FileName : Program.AppRoot + this.root + this.Name;

			try
            {
				if(journalToOpen.Length > 0)
				{
					using(Stream stream = File.Open(journalToOpen, FileMode.Open))
					{
						BinaryFormatter formatter = new BinaryFormatter();
						jRtrn = (Journal)formatter.Deserialize(stream);
						jRtrn.FileName = journalToOpen;
						jRtrn.Name = journalToOpen.Substring(journalToOpen.LastIndexOf("\\") + 1);
					}
				}	
            }
            catch(Exception) { }

            return jRtrn;
        }

		//private List<JournalEntry> ProcessLabels(List<JournalEntry> entriesToSearch, string[] labelsArray, bool UseAnd)
		//{
		//	List<JournalEntry> entriesToReturn = new List<JournalEntry>();

		//	string[] a = labelsArray;
		//	string[] b;


		//	foreach (JournalEntry entry in entriesToSearch)
		//	{
		//		if (UseAnd)
		//		{
		//			if(entry.ClearLabels().Length > 0)
		//			{
		//				b = entry.ClearLabels().Split(',');
		//				var hasLabels = true;

		//				foreach(var label in labelsArray)
		//				{
		//					if(!b.Contains(label)) { hasLabels = false; break; }
		//				}

		//				if(hasLabels) { if(!entriesToReturn.Contains(entry)) entriesToReturn.Add(entry); }
		//			}
		//		}
		//		else
		//		{
		//			foreach (var label in labelsArray)
		//			{
		//				if (entry.ClearLabels().Contains(label)) { if (!entriesToReturn.Contains(entry)) entriesToReturn.Add(entry); }
		//			}
		//		}
		//	}

		//	return entriesToReturn;
		//}

		//public async Task RenameJournal(string newName)
		//{
		//	DeleteBackups();
		//	this.Name = newName;
		//	this.FileName = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebookIncrementalBackupsFolder"] + this.Name;
		//	await this.Save();
		//	File.Move(this.FileName, this.FileName.Substring(0, this.FileName.LastIndexOf("\\")) + "\\" + newName);
		//	Backup();
		//}

		//public async Task RenameLabel(string oldName,  string newName)
		//{
		//	var saveJournal = false;
		//	foreach(JournalEntry entry in this.Entries.Where(e => e.ClearLabels().Contains(oldName)).ToList()) 
		//	{ saveJournal = entry.RemoveOrReplaceLabel(newName, oldName); }

		//	if(saveJournal ) { await this.Save(); }
		//}

  //      public void ReplaceEntry(JournalEntry jeToReplace, JournalEntry jeToInsert)
		//{
		//	jeToInsert.Date = jeToReplace.Date;
		//	jeToInsert.LastEditedOn = DateTime.Now;
		//	var index = Array.FindIndex(Entries.ToArray(), row => row.Id == jeToReplace.Id);
		//	Entries[index] = jeToInsert;
		//}

		//public async Task ResetPIN(Form caller)
		//{
		//	var currentPIN	= Program.PIN;
		//	var newPIN		= string.Empty;
		//	var save		= false;

		//	// input current PIN
		//	using(frmMessage frmGetCurrentPIN = new frmMessage(frmMessage.OperationType.InputBox, "Enter the current PIN.", "(current PIN)", caller))
		//	{
		//		frmGetCurrentPIN.ShowDialog();

		//		if (frmGetCurrentPIN.ResultText != currentPIN)
		//		{
		//			using (frmMessage frmBadPIN = new frmMessage(frmMessage.OperationType.Message, "The PIN you entered is not correct.", "Bad PIN", caller))
		//			{ frmBadPIN.ShowDialog(); }
		//		}
		//		else
		//		{
		//			using (frmMessage frmNewPIN = new frmMessage(frmMessage.OperationType.InputBox, "Enter the new PIN", "(enter PIN)", caller))
		//			{
		//				frmNewPIN.ShowDialog();
		//				newPIN = frmNewPIN.ResultText;

		//				if (frmNewPIN.Result != frmMessage.ReturnResult.Cancel)
		//				{
		//					foreach (JournalEntry e in this.Entries)
		//					{
		//						// get the entry's key values
		//						EntryValues ev = new EntryValues
		//						{
		//							NotebookName = e.NotebookName,
		//							text = e.ClearText(),
		//							RTF = e.ClearRTF(),
		//							title = e.ClearTitle()
		//						};

		//						// set programPIN to newPin
		//						Program.PIN = newPIN;

		//						// encrypt key values w/ new pin
		//						e.Title = EncryptDecrypt.Encrypt(ev.title);
		//						e.Text = EncryptDecrypt.Encrypt(ev.text);
		//						//e.JournalName = EncryptDecrypt.Encrypt(ev.Name);	// << need to encrypt name
		//						Program.PIN = currentPIN;
		//						save = true;
		//					}
		//				}
		//			}
		//		}

		//		if(save) { await this.Save(); Program.PIN = newPIN; }
		//	}
		//}

		//public async Task Save()
		//{
		//	this.LastSaved = DateTime.Now;

		//	using (Stream stream = File.Open(this.FileName, FileMode.Create))
		//	{
		//		BinaryFormatter formatter = new BinaryFormatter();
		//		formatter.Serialize(stream, this);
		//		stream.Close();
		//	}

		//	if (Program.AzurePassword.Length > 0 && this.Settings.AllowCloud)
		//	{
		//		CloudSynchronizer cs = new CloudSynchronizer();
		//		//await cs.SynchWithCloud(false, this);
		//	}

		//	//Backup();
		//	Program.AllNotebooks = Utilities.AllNotebooks();
		//}

		//public List<JournalEntry> Search(SearchObject So)
		//{
		//	List<JournalEntry> allEntries = this.Entries;

		//	if(So.chkUseDate.Checked | So.chkUseDateRange.Checked)
		//	{
		//		if (So.chkUseDate.Checked) 
		//		{ allEntries = Entries.Where(p => p.Date.ToShortDateString() == So.dtFindDate.Value.ToShortDateString()).ToList(); }
		//		else
		//		{ allEntries = Entries.Where(p => p.Date >= So.dtFindDate_From.Value && p.Date <= So.dtFindDate_To.Value).ToList(); }
		//	}

		//	if(So.labelsArray != null) { allEntries = ProcessLabels(allEntries, So.labelsArray, So.radBtnLabelsAnd.Checked); }

		//	if(!So.chkMatchCase.Checked) { So.searchTitle = So.searchTitle.ToLower(); So.searchText = So.searchText.ToLower(); }

		//	if(So.searchText.Length > 0 | So.searchTitle.Length > 0)
		//	{
		//		if (!So.chkMatchCase.Checked)
		//		{
		//			So.searchTitle = So.searchTitle.ToLower(); 
		//			So.searchText = So.searchText.ToLower();

		//			if (So.searchText.Length > 0 & So.searchTitle.Length > 0)
		//			{
		//				if (So.radBtnAnd.Checked)
		//				{ allEntries = allEntries.Where(e => e.ClearTitle().ToLower().Contains(So.searchTitle) & e.ClearText().ToLower().Contains(So.searchText)).ToList(); }
		//				else { allEntries = allEntries.Where(e => e.ClearTitle().ToLower().Contains(So.searchTitle) | e.ClearText().ToLower().Contains(So.searchText)).ToList(); }
		//			}
		//			else if (So.searchText.Length > 0)
		//			{ allEntries = allEntries.Where(e => e.ClearText().ToLower().Contains(So.searchText)).ToList(); }
		//			else if (So.searchTitle.Length > 0)
		//			{ allEntries = allEntries.Where(e => e.ClearTitle().ToLower().Contains(So.searchTitle)).ToList(); }
		//		}
		//		else
		//		{
		//			if(So.searchText.Length > 0 & So.searchTitle.Length > 0)
		//			{
		//				if (So.radBtnAnd.Checked)
		//				{ allEntries = allEntries.Where(e => e.Title.Contains(So.searchTitle) & e.ClearText().Contains(So.searchText)).ToList(); }
		//				else { allEntries = allEntries.Where(e => e.Title.Contains(So.searchTitle) | e.ClearText().Contains(So.searchText)).ToList(); }
		//			}
		//			else if(So.searchText.Length > 0)
		//			{ allEntries = allEntries.Where(e => e.ClearText().Contains(So.searchText)).ToList() ; }
		//			else if(So.searchTitle.Length > 0)
		//			{ allEntries = allEntries.Where(e => e.ClearTitle().Contains(So.searchTitle)).ToList(); }
		//		}
		//	}
		//	return allEntries;
		//}

		protected struct EntryValues
		{
			public string title;
			public string text;
			public string RTF;
			public string NotebookName;
		}
    }
}
