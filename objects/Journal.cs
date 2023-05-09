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
using System.Text;
using myJournal.subforms;
using myJournal.objects;
using System.Windows.Forms;
using Org.BouncyCastle.Crypto.Agreement.JPake;

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
		public bool AllowCloud;

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

        public void AddEntry(JournalEntry entryToAdd) { Entries.Add(entryToAdd); }

		public void Backup()
		{
			string dir = ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"];
			if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + dir))
			{ System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + dir); }
			this.Name = FileName.Substring(FileName.LastIndexOf("\\") + 1);
			File.Copy(this.FileName, AppDomain.CurrentDomain.BaseDirectory + dir + this.Name, true);
		}

		public void Backup_Forced()
		{
			try
			{
				string dir = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_JournalForcedBackupsFolder"];
				if (!System.IO.Directory.Exists(dir))
				{ System.IO.Directory.CreateDirectory(dir); }
				File.Copy(this.FileName, dir + this.Name);
				FileInfo fi = new FileInfo(dir + this.Name);
				File.Move(dir + this.Name, dir + this.Name + " (" + fi.CreationTime.ToString(ConfigurationManager.AppSettings["DateFormat_ForcedBackupFileName"] + ")"), true);
				BackupCompleted = true;
			}
			catch (Exception) { }
		}

		public void Create()
        {
			this.FileName += " (local)";
			Entries.Add(new JournalEntry("created", "-", "-", ""));
			this.Save();
        }

		public async void Delete()
		{
			if (this.AllowCloud) 
			{ await AzureFileClient.DownloadOrDeleteFile(this.FileName, Program.AzurePassword + "_" + this.Name, FileMode.Create, true);  }

			DeleteBackups();
			File.Delete(this.FileName);
		}

		private void DeleteBackups()
		{
			File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"] + this.Name);
			File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalForcedBackupsFolder"] + this.Name);
		}

        public JournalEntry GetEntry(string Title, string Date)
        {
            JournalEntry je = null;
			try { je = this.Entries.First(a => a.ClearTitle() + a.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) == Title + Date); }
            catch(Exception ex) { Console.Write(ex.Message); }
            return je;
        }

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

		public void Rename(string newName)
		{
			DeleteBackups();
			this.Name = newName;
			this.FileName = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"] + this.Name;
			this.Save();
			File.Move(this.FileName, this.FileName.Substring(0, this.FileName.LastIndexOf("\\")) + "\\" + newName);
			Backup();
		}

        public void ReplaceEntry(JournalEntry jeToReplace, JournalEntry jeToInsert)
		{
			int idx;
			jeToInsert.Date = jeToReplace.Date;
			jeToInsert.LastEditedOn = DateTime.Now;
			for(idx = 0; idx < this.Entries.Count; idx++) { if(this.Entries[idx].Id == jeToReplace.Id) { break; } }
			this.Entries.Remove(jeToReplace);
			this.Entries.Insert(idx, jeToInsert);
		}

        public async void Save()
        {
			this.LastSaved = DateTime.Now;

            using (Stream stream = File.Open(this.FileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
				stream.Close();
            }

			//Program.SkipFileSizeComparison = true;

			if(Program.AzurePassword.Length > 0 && this.AllowCloud)
			{
				CloudSynchronizer cs = new CloudSynchronizer();
				await cs.SynchWithCloud(false, this);
			}

			Backup();
        }

		public List<JournalEntry> Search(SearchObject So)
		{
			List<JournalEntry> foundEntries = new List<JournalEntry>();
			string entryText = string.Empty;
			string entryTitle = string.Empty;

			foreach (JournalEntry je in this.Entries)
			{
				// date
				if (So.chkUseDate.Checked)
				{ if (je.Date.ToShortDateString() == So.dtFindDate.Value.ToShortDateString()) { foundEntries.Add(je); } }

				if (So.chkUseDateRange.Checked)
				{ if (je.Date >= So.dtFindDate_From.Value && je.Date <= So.dtFindDate_To.Value) { foundEntries.Add(je); } }

				// labels

				string s = je.ClearLabels();

				if (So.labelsArray != null)
				{ foreach (string group in So.labelsArray) { if (je.ClearLabels().Contains(group)) { foundEntries.Add(je); } } }

				// title and/or text
				So.searchTitle	= So.chkMatchCase.Checked ? So.searchTitle	: So.searchTitle.ToLower();
				So.searchText	= So.chkMatchCase.Checked ? So.searchText	: So.searchText.ToLower();
				entryText		= So.chkMatchCase.Checked ? je.ClearText()	: je.ClearText().ToLower();
				entryTitle		= So.chkMatchCase.Checked ? je.ClearTitle() : je.ClearTitle().ToLower();

				if (So.radBtnAnd.Checked)
				{ if (entryText.Contains(So.searchText) & entryTitle.Contains(So.searchTitle)) { foundEntries.Add(je); }}
				else
				{ if (So.searchText.Length > 0 && entryText.Contains(So.searchText) ) { foundEntries.Add(je); }}
			}
			return foundEntries;
		}
    }
}
