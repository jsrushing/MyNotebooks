/* LocalNotebook object
 * Created as Journal on: 8/1//21
 * Created by: S. Rushing
 * Modified to LocalNotebook 06/10/23
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryption;
using MailKit.Net.Imap;
using myNotebooks.objects;
using myNotebooks.subforms;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using Newtonsoft.Json.Linq;
using myNotebooks.DataAccess;
using MyNotebooks.objects;

namespace myNotebooks
{
	[Serializable]
	public class Notebook
	{
		public int		CreatedBy { get; set; }
		public DateTime	CreatedOn { get; set; }
		public DateTime? EditedOn { get; set; }
		public string	Description { get; set; }
		public int		Id { get; set; }
		public string	Name { get; set; }
		public string PIN { get; set; } = string.Empty;
		public int		ParentId { get; set; }

		public string		FileName;
		public string		root = "notebooks\\";
		public bool			WrongPIN = false;
		public bool			BackupCompleted;
		public bool			Saved;
		public List<Entry>	Entries = new();

		public NotebookSettings	Settings;

		private bool isNewNotebook = false;

		public Notebook(string _name = null, string _fileName = null) 
        {
            if(_name != null)
            {
				this.Name = _name;
				if (_fileName != null) { this.FileName = _fileName; } 
				else { this.FileName = Program.AppRoot + this.root + this.Name; }
			}
		}

		public Notebook(DataTable dt)
		{
			var value = "";

			foreach (PropertyInfo sPropertyName in typeof(Notebook).GetProperties())
			{
				try
				{
					if (dt.Columns[sPropertyName.Name].DataType == typeof(string))
					{
						value = dt.Rows[0].Field<string>(sPropertyName.Name).ToString();
						this.GetType().GetProperty(sPropertyName.Name).SetValue(this, value.ToString());
					}
					else if (dt.Columns[sPropertyName.Name].DataType == typeof(Int32))
					{
						value = dt.Rows[0].Field<Int32>(sPropertyName.Name).ToString();
						this.GetType().GetProperty(sPropertyName.Name).SetValue(this, Convert.ToInt32(value));
					}
					else if (dt.Columns[sPropertyName.Name].DataType == typeof(DateTime))
					{
						DateTime dtime = Convert.ToDateTime(dt.Rows[0].Field<DateTime>(sPropertyName.Name));
						this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dtime);
					}
				}
				catch(NullReferenceException) { }
			}
		}

		public void			AddEntry(Entry entryToAdd) { Entries.Add(entryToAdd); }

		public void			Backup()
		{
			string dir = ConfigurationManager.AppSettings["FolderStructure_NotebookIncrementalBackupsFolder"];
			if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + dir))
			{ System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + dir); }
			this.Name = FileName.Substring(FileName.LastIndexOf("\\") + 1);
			File.Copy(this.FileName, AppDomain.CurrentDomain.BaseDirectory + dir + this.Name, true);
		}

		public void			Backup_Forced()
		{
			try
			{
				string dir = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_NotebookForcedBackupsFolder"];
				if (!System.IO.Directory.Exists(dir))
				{ System.IO.Directory.CreateDirectory(dir); }
				File.Copy(this.FileName, dir + this.Name);
				FileInfo fi = new FileInfo(dir + this.Name);
				File.Move(dir + this.Name, dir + this.Name + " (" + fi.CreationTime.ToString(ConfigurationManager.AppSettings["DateFormat_ForcedBackupFileName"] + ")"), true);
				BackupCompleted = true;
			}
			catch (Exception) { }
		}

		public async Task	Create(bool addCreatedOn = true)
        {
			//this.FileName += this.Settings.AllowCloud ? "" : " (local)";
			//if(addCreatedOn) Entries.Add(new Entry("created", "-", "-", "", this.Name));
			//Program.SkipFileSizeComparison = true;
			this.CreatedBy = Program.User.UserId;
			isNewNotebook = true;
			await this.Save();
			//Program.SkipFileSizeComparison = false;
		}

		public async void	Delete()
		{
			if (Program.AzurePassword.Length > 0 && this.Settings.AllowCloud)
			{ await AzureFileClient.DownloadOrDeleteFile(this.FileName, Program.AzurePassword + this.Name, FileMode.Create, true);  }

			Program.DictCheckedNotebooks.Add(this.Name, Program.PIN);
			List<string> labelsInBook = this.GetAllLabelsInNotebook();
			List<Notebook> chkdBooks = Utilities.GetCheckedNotebooks();
			List<Notebook> booksWithLabel = new List<Notebook>();

			foreach(var lbl in labelsInBook) { booksWithLabel.AddRange(chkdBooks.Where(e => e.HasLabel(lbl) == true).ToList().Except(booksWithLabel)); }

			if (booksWithLabel.Count > 0) 
			{
				var lblsInBookCount = labelsInBook.Count;
				var usePlural = lblsInBookCount > 1;
				var msg = "This notebook contains " + lblsInBookCount + " labels. Do you want " +
					"to delete th" + (usePlural ? "is " : "ese ") + "label" + (usePlural ? "s " : " ") + " in the " + lblsInBookCount + " selected notebook " +
					(usePlural ? "s " : " ") + " in which the label " + (usePlural ? "s " : " ") + (usePlural ? "was " : "were ") + "found? " +
					"If you need to re-select the notebook " + (usePlural ? "s " : " ") + "in which the label will be deleted, click 'No', then the 'Labels' menu, then 'Select Notebooks'.";

				using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, msg)) 
				{ 
					frm.ShowDialog(); 

					if(frm.Result == frmMessage.ReturnResult.Yes)
					{
						foreach(var label in labelsInBook) { await LabelsManager.DeleteLabelInNotebooksList(label, booksWithLabel); } 
					}
				}
			}

			File.Delete(this.FileName);
			DeleteBackups();
		}
		
		private void		DeleteBackups()
		{
			File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebookIncrementalBackupsFolder"] + this.Name);
			File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebookForcedBackupsFolder"] + this.Name);
		}

		public async Task	DeleteLabelFromNotebook(string label)
		{
			var saveJournal = false;
			foreach (Entry entry in this.Entries.Where(e => e.Labels.Contains(label)).ToList())
			{ saveJournal = entry.RemoveOrReplaceLabel("", label, false); } 
			
			if(saveJournal) { await this.Save(); } 
		}

        public Entry		GetEntry(string Title, string Date)
        {
			Entry jeRtrn = null;

			foreach(Entry e in this.Entries)
			{
				if(e.CreatedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]).Equals(Date)) { jeRtrn = e; break; }
			}

			//try { jeRtrn = Entries.First(a => a.ClearTitle() == Title && a.CreatedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]).Equals(CreatedOn)); }
			//catch (Exception) { }
			return jeRtrn;
        }

		public List<string> GetAllLabelsInNotebook()
		{
			List<string> lstRtrn = new List<string>();

			foreach (Entry entry in this.Entries.Where(e => e.Labels.Length > 0))
			{ lstRtrn.AddRange(entry.Labels.Split(",").Except(lstRtrn)); }

			return lstRtrn;
		}

		public bool			HasLabel(string Label) { return Entries.Where(e => e.Labels.Contains(Label)).Any(); }

		public Notebook		Open(bool useFileName = false)
        {
            Notebook nbRtrn = null;
			var NotebookToOpen = "";
			NotebookToOpen = useFileName ? this.FileName : Program.AppRoot + this.root + this.Name;

			try
            {
				if(NotebookToOpen.Length > 0)
				{
					var nbName = NotebookToOpen.Contains("\\") ?
						NotebookToOpen.Substring(NotebookToOpen.LastIndexOf("\\") + 1, NotebookToOpen.Length - NotebookToOpen.LastIndexOf("\\") - 1) : NotebookToOpen;

					using(Stream stream = File.Open(NotebookToOpen, FileMode.Open))
					{
						DataContractSerializer serializer = new DataContractSerializer(typeof(Notebook));
						nbRtrn = (Notebook)serializer.ReadObject(stream);

						//nbRtrn.Name				= EncryptDecrypt.Decrypt(nbRtrn.Name, Program.PIN);

						if(nbRtrn.Name.Length > 0)
						{
							nbRtrn.FileName							= EncryptDecrypt.Decrypt(nbRtrn.FileName, Program.PIN);

							if(EncryptDecrypt.Decrypt(nbRtrn.Entries[0].Title, Program.PIN).Length > 0)
							{
								nbRtrn.Entries.ForEach(e => e.Title		= EncryptDecrypt.Decrypt(e.Title, Program.PIN));
								nbRtrn.Entries.ForEach(e => e.Text		= EncryptDecrypt.Decrypt(e.Text, Program.PIN));
								nbRtrn.Entries.ForEach(e => e.Labels	= EncryptDecrypt.Decrypt(e.Labels, Program.PIN));
								nbRtrn.Entries.ForEach(e => e.RTF		= EncryptDecrypt.Decrypt(e.RTF, Program.PIN));
								nbRtrn.Entries.ForEach(e => e.NotebookName = EncryptDecrypt.Decrypt(e.NotebookName, Program.PIN));
							}
							else { WrongPIN = true; }
						}
					}
				}	
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }

            return nbRtrn;
        }

		private List<Entry> ProcessLabels(List<Entry> entriesToSearch, string[] labelsArray, bool UseAnd)
		{
			List<Entry> entriesToReturn = new List<Entry>();

			string[] a = labelsArray;
			string[] b;


			foreach (Entry entry in entriesToSearch)
			{
				if (UseAnd)
				{
					if(entry.Labels.Length > 0)
					{
						b = entry.Labels.Split(',');
						var hasLabels = true;

						foreach(var label in labelsArray)
						{
							if(!b.Contains(label)) { hasLabels = false; break; }
						}

						if(hasLabels) { if(!entriesToReturn.Contains(entry)) entriesToReturn.Add(entry); }
					}
				}
				else
				{
					foreach (var label in labelsArray)
					{
						if (entry.Labels.Contains(label)) { if (!entriesToReturn.Contains(entry)) entriesToReturn.Add(entry); }
					}
				}
			}

			return entriesToReturn;
		}

		public async Task	Rename(string newName, bool uploadTriggerFile)
		{
			//DeleteBackups();
			var oldName		= this.Name;
			var oldFileName = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"] + this.Name;
			File.Move		(this.FileName, this.FileName.Substring(0, this.FileName.LastIndexOf("\\")) + "\\" + newName);
			Thread.Sleep	(500);
			this.FileName	= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"] + newName;
			this.Name		= newName;
			this.Entries	.ForEach(e => e.NotebookName = newName);
			await this.Save(false);

			if (this.Settings.AllowCloud)
			{
				await AzureFileClient.GetAzureItemNames();	// Populate Program.AzureNotebooks.

				if(Program.AzureNotebookNames.Contains(Program.AzurePassword + oldName)) 
				{ 
					Program.AzureNotebookNames.Remove(Program.AzurePassword + oldName);
					//await AzureFileClient.RenameFile($"notebooks/container1a.file.core.windows.net" + "//" + Program.AzurePassword + oldName, newName);
					await AzureFileClient.DownloadOrDeleteFile(this.FileName, Program.AzurePassword + oldName, FileMode.Create, true);
					CloudSynchronizer cs = new CloudSynchronizer(); await AzureFileClient.UploadFile(this.FileName);   // gets this newly renamed notebook to Azure

				}
				if (!Program.AzureNotebookNames.Contains(Program.AzurePassword + newName)) { Program.AzureNotebookNames.Add(Program.AzurePassword + newName); }
				if (uploadTriggerFile) { AzureFileClient.UploadRenamedFileTrigger(oldName, newName); }
			}
			//Backup();
		}

		public async Task	RenameLabel(string oldName,  string newName)
		{
			var saveJournal = false;
			foreach(Entry entry in this.Entries.Where(e => e.Labels.Contains(oldName)).ToList()) 
			{ saveJournal = entry.RemoveOrReplaceLabel(newName, oldName); }

			if(saveJournal ) { await this.Save(); }
		}

        public void			ReplaceEntry(Entry jeToReplace, Entry jeToInsert)
		{
			jeToInsert.CreatedOn = jeToReplace.CreatedOn;
			jeToInsert.EditedOn  = DateTime.Now;
			var index = Array.FindIndex(Entries.ToArray(), row => row.Id == jeToReplace.Id);
			Entries[index] = jeToInsert;
		}

		public async Task	ResetPIN(Form caller)
		{
			var newPIN		= string.Empty;
			var currentPIN	= Program.PIN;
			Saved = false;

			// input current PIN
			using (frmMessage frmGetCurrentPIN = new frmMessage(frmMessage.OperationType.InputBox, "Enter the current PIN.", "(current PIN)", caller))
			{
				frmGetCurrentPIN.ShowDialog();

				if (frmGetCurrentPIN.ResultText != currentPIN)
				{
					using (frmMessage frmBadPIN = new frmMessage(frmMessage.OperationType.Message, "The PIN you entered is not correct.", "Bad PIN", caller))
					{ frmBadPIN.ShowDialog(); }
				}
				else	// input new PIN
				{
					using (frmMessage frmNewPIN = new frmMessage(frmMessage.OperationType.InputBox, "Enter the new PIN", "(enter PIN)", caller))
					{
						frmNewPIN.ShowDialog();
						newPIN = frmNewPIN.ResultText;

						if (frmNewPIN.Result != frmMessage.ReturnResult.Cancel)
						{
							Program.PIN = newPIN;
							Saved = true;
						}
					}
				}

				if (Saved) { await this.Save(); }
			}
		}

		public async Task	Save(bool synchWithCloud = true)
		{
			//var fName = this.FileName.Length > 0 ? this.FileName : Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"] + this.Name;
			//fName = fName.Contains("\\") ? fName :  Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"] + this.Name;

			Notebook nTmp = (Notebook)this.MemberwiseClone();

			// Encrypt the notebook and entries to save to disk.
			//this.FileName						= EncryptDecrypt.Encrypt(this.FileName, this.PIN);
			this.Name		= EncryptDecrypt.Encrypt(this.Name,		this.PIN);
			this.PIN		= EncryptDecrypt.Encrypt(this.PIN, this.PIN);
			this.Description = EncryptDecrypt.Encrypt(this.Description, this.PIN);

			this.Entries.ForEach(e	=> e.Title	= EncryptDecrypt.Encrypt(e.Title,	this.PIN));
			this.Entries.ForEach(e	=> e.Text	= EncryptDecrypt.Encrypt(e.Text,	this.PIN));
			this.Entries.ForEach(e	=> e.Labels = EncryptDecrypt.Encrypt(e.Labels,	this.PIN));
			this.Entries.ForEach(e	=> e.RTF	= EncryptDecrypt.Encrypt(e.RTF,		this.PIN));
			this.Entries.ForEach(e	=> e.NotebookName = EncryptDecrypt.Encrypt(e.NotebookName, this.PIN));

			if (isNewNotebook && DbAccess.CRUDNotebook(this) == 0)
			{
				using (frmMessage frm = new(frmMessage.OperationType.Message,
					"An error occurred. The Notebook was not created.")) { frm.ShowDialog(); }
			}

			//File.Delete(fName);

			//using (Stream stream = File.Open(fName, FileMode.Create))
			//{
			//	DataContractSerializer dcs = new DataContractSerializer(typeof(Notebook));
			//	dcs.WriteObject(stream, this);
			//}

			//if (Program.AzurePassword.Length > 0 && this.Settings.AllowCloud)
			//{
			//	if(synchWithCloud)
			//	{
			//		CloudSynchronizer cs = new CloudSynchronizer();
			//		await cs.SynchWithCloud(false, this);
			//	}
			//}

			// switch back to the original notebook
			//this.FileName	= nTmp.FileName;  // EncryptDecrypt.Decrypt(this.FileName, Program.PIN);
			this.Name		= nTmp.Name;	// EncryptDecrypt.Decrypt(this.Name, Program.PIN);
			//this.Entries	= nTmp.Entries;

			if(Program.PIN.Length > 0)
			{
				this.Entries.ForEach(e => e.Title = EncryptDecrypt.Decrypt(e.Title, Program.PIN));
				this.Entries.ForEach(e => e.Text = EncryptDecrypt.Decrypt(e.Text, Program.PIN));
				this.Entries.ForEach(e => e.Labels = EncryptDecrypt.Decrypt(e.Labels, Program.PIN));
				this.Entries.ForEach(e => e.RTF = EncryptDecrypt.Decrypt(e.RTF, Program.PIN));
				this.Entries.ForEach(e => e.NotebookName = EncryptDecrypt.Decrypt(e.NotebookName, Program.PIN));
			}

			//Backup();
			if (isNewNotebook) { await Utilities.PopulateAllNotebookNames(); }
		}

		public List<Entry>	Search(SearchObject So)
		{
			List<Entry> allEntries = this.Entries;

			if(So.chkUseDate.Checked | So.chkUseDateRange.Checked)
			{
				if (So.chkUseDate.Checked) 
				{ allEntries = Entries.Where(p => p.CreatedOn.ToShortDateString() == So.dtFindDate.Value.ToShortDateString()).ToList(); }
				else
				{ allEntries = Entries.Where(p => p.CreatedOn >= So.dtFindDate_From.Value && p.CreatedOn <= So.dtFindDate_To.Value).ToList(); }
			}

			if(So.labelsArray != null) { allEntries = ProcessLabels(allEntries, So.labelsArray, So.radBtnLabelsAnd.Checked); }

			if(!So.chkMatchCase.Checked) { So.searchTitle = So.searchTitle.ToLower(); So.searchText = So.searchText.ToLower(); }

			if(So.searchText.Length > 0 | So.searchTitle.Length > 0)
			{
				if (!So.chkMatchCase.Checked)
				{
					So.searchTitle = So.searchTitle.ToLower(); 
					So.searchText = So.searchText.ToLower();

					if (So.searchText.Length > 0 & So.searchTitle.Length > 0)
					{
						if (So.radBtnAnd.Checked)
						{ allEntries = allEntries.Where(e => e.Title.ToLower().Contains(So.searchTitle) & e.Text.ToLower().Contains(So.searchText)).ToList(); }
						else { allEntries = allEntries.Where(e => e.Title.ToLower().Contains(So.searchTitle) | e.Text.ToLower().Contains(So.searchText)).ToList(); }
					}
					else if (So.searchText.Length > 0)
					{ allEntries = allEntries.Where(e => e.Text.ToLower().Contains(So.searchText)).ToList(); }
					else if (So.searchTitle.Length > 0)
					{ allEntries = allEntries.Where(e => e.Title.ToLower().Contains(So.searchTitle)).ToList(); }
				}
				else
				{
					if(So.searchText.Length > 0 & So.searchTitle.Length > 0)
					{
						if (So.radBtnAnd.Checked)
						{ allEntries = allEntries.Where(e => e.Title.Contains(So.searchTitle) & e.Text.Contains(So.searchText)).ToList(); }
						else { allEntries = allEntries.Where(e => e.Title.Contains(So.searchTitle) | e.Text.Contains(So.searchText)).ToList(); }
					}
					else if(So.searchText.Length > 0)
					{ allEntries = allEntries.Where(e => e.Text.Contains(So.searchText)).ToList() ; }
					else if(So.searchTitle.Length > 0)
					{ allEntries = allEntries.Where(e => e.Title.Contains(So.searchTitle)).ToList(); }
				}
			}
			return allEntries;
		}

		protected struct EntryValues
		{
			public string title;
			public string text;
			public string labels;
			public string RTF;
			public string notebookName;
		}
    }

}
