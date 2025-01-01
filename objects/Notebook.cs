/* LocalNotebook object
 * Created as Journal on: 8/1//21
 * Created by: S. Rushing
 * Modified to LocalNotebook 06/10/23
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryption;
using MyNotebooks.DataAccess;
using MyNotebooks.objects;
using MyNotebooks.subforms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;

namespace MyNotebooks
{
	[Serializable]
	public class Notebook
	{
		public int			CreatedBy { get; set; }
		public DateTime		CreatedOn { get; set; }
		public DateTime?	EditedOn { get; set; }
		public string		Description { get; set; }
		public int			Id { get; set; }
		public string		Name { get; set; }
		public string		PIN { get; set; } = string.Empty;
		public int			ParentId { get; set; }
		public string		FileName;
		public string		root = "notebooks\\";
		public bool			WrongPIN = false;
		public bool			BackupCompleted;
		public bool			Saved;
		public List<Entry>		Entries { get; set; }
		public NotebookSettings	Settings;

		public Notebook() { }

		public Notebook(string _name = null, string _fileName = null) 
        {
            if(_name != null)
            {
				this.Name = _name;
				if (_fileName != null) { this.FileName = _fileName; } 
				else { this.FileName = Program.AppRoot + this.root + this.Name; }
			}
		}

		public Notebook(DataTable dt, int rowIndex = 0)
		{
			var value = "";
			this.Entries = new List<Entry>();

			foreach (PropertyInfo sPropertyName in typeof(Notebook).GetProperties())
			{
				try
				{
					if (sPropertyName.Name.ToLower() != "entries" && dt.Rows[rowIndex].Field<object>(sPropertyName.Name) != null)
					{
						if (dt.Columns[sPropertyName.Name].DataType == typeof(string))
						{
							value = dt.Rows[rowIndex].Field<string>(sPropertyName.Name).ToString();
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, value.ToString());
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(Int32))
						{
							value = dt.Rows[rowIndex].Field<Int32>(sPropertyName.Name).ToString();
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, Convert.ToInt32(value));
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(DateTime))
						{
							DateTime dtime = Convert.ToDateTime(dt.Rows[rowIndex].Field<DateTime>(sPropertyName.Name));
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dtime);
						}
					}
				}
				catch(NullReferenceException) { }
			}
		}

		//public void			AddEntry(Entry entryToAdd) { Entries.Add(entryToAdd); }

		//public void			Backup()
		//{
		//	string dir = ConfigurationManager.AppSettings["FolderStructure_NotebookIncrementalBackupsFolder"];
		//	if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + dir))
		//	{ System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + dir); }
		//	this.Name = FileName.Substring(FileName.LastIndexOf("\\") + 1);
		//	File.Copy(this.FileName, AppDomain.CurrentDomain.BaseDirectory + dir + this.Name, true);
		//}

		//public void			Backup_Forced()
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

		//public SQLResult Create() { return GetOperationResult(DbAccess.CRUDNotebook(this), true); }
		//public SQLResult Update() { return GetOperationResult(DbAccess.CRUDNotebook(this, OperationType.Update)); }
		public SQLResult Delete() { return GetOperationResult(DbAccess.CRUDNotebook(this, OperationType.Delete)); }

		private SQLResult	GetOperationResult(SQLResult result, bool isCreate = false)
		{
			if (isCreate) { if (result.strValue.Length == 0) { this.Id = result.intValue; } }
			else
			{ if (result.strValue.Length > 0) { GenerateMesssage("An error occurred" + result.strValue, null, "Error"); } }
			
			return result;
		}

		public async Task	Create(Form callingForm = null)
        {
			this.CreatedBy = Program.User.Id;
			this.Entries = this.Entries == null ? new() : this.Entries;
			await this.Save(callingForm);
		}

		public async void	Delete_original()
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
				var msg = "This notebook contains " + lblsInBookCount + " labelsForSearch. Do you want " +
					"to delete th" + (usePlural ? "is " : "ese ") + "labelText" + (usePlural ? "s " : " ") + " in the " + lblsInBookCount + " selected notebook " +
					(usePlural ? "s " : " ") + " in which the labelText " + (usePlural ? "s " : " ") + (usePlural ? "was " : "were ") + "found? " +
					"If you need to re-select the notebook " + (usePlural ? "s " : " ") + "in which the labelText will be deleted, click 'No', then the 'Labels' menu, then 'Select Notebooks'.";

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
			//DeleteBackups();
		}
		
		//private void		DeleteBackups()
		//{
		//	File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebookIncrementalBackupsFolder"] + this.Name);
		//	File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebookForcedBackupsFolder"] + this.Name);
		//}

		public async Task	DeleteLabelFromNotebook(string label)
		{
			var saveJournal = false;
			foreach (Entry entry in this.Entries.Where(e => e.Labels.Contains(label)).ToList())
			{ saveJournal = entry.RemoveOrReplaceLabel(label, "", false); } 
			
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

		private void		GenerateMesssage(string message, Exception exception = null, string title = "", Form caller = null)
		{
			frmMessage frm = new(frmMessage.OperationType.Message, message + (exception != null ? Environment.NewLine + exception.Message : ""), title, caller);
			frm.ShowDialog();
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

		public void			Print(Form callingForm, bool printJSON = true)
		{
			try
			{
				if (printJSON)
				{
					string fName = Utilities.GetDialogResult(new SaveFileDialog(), "MyNotebooks backup files (*.mnbak)|*.mnbak", this.Name + "_json", "Save File");
					if (fName.Length > 0) 
					{ 
						File.WriteAllText(fName, JsonSerializer.Serialize(this)); 
						GenerateMesssage("The notebook was saved as '" + Path.GetFileName(fName) + "'.", null, "Notebook Saved", callingForm);
					}
				}
				else
				{
					StringBuilder sb = new StringBuilder();
					sb.AppendLine("Notebook: " + this.Name);
					foreach (Entry entry in this.Entries)
					{
						sb.Append("Title: " + entry.Title);
						sb.Append(" Created: " + entry.CreatedOn.ToString());
						sb.AppendLine(entry.EditedOn > entry.CreatedOn ? " Edited: " + entry.EditedOn : "");
						sb.AppendLine(entry.Text);

						if (entry.AllLabels.Count > 0)
						{
							sb.Append("labels: ");
							sb.AppendLine(string.Join(", ", entry.AllLabels.Select(e => e.LabelText).ToArray()));
						}
						sb.AppendLine();
					}

					string fName = Utilities.GetDialogResult(new SaveFileDialog(), "MyNotebooks backup files (*.mnbak)|.mnbak", this.Name + "_plaintext", "Save File");
					if(fName.Length > 0) { File.WriteAllText(fName, sb.ToString()); }
					GenerateMesssage("The notebook was printed as '" + Path.GetFileName(fName) + "'.", null, "Notebook Saved", callingForm);
				}
			}
			catch (Exception ex)
			{ GenerateMesssage("An Error Occurred", ex); }
		}

		private static List<Entry> ProcessLabels(List<Entry> entriesToSearch, List<string> labelsForSearch, bool UseAnd)
		{
			List<Entry> entriesToReturn = new();

			foreach (Entry entry in entriesToSearch)
			{
				if (UseAnd)
				{
					foreach (MNLabel label in entry.AllLabels)
					{
						if (labelsForSearch.Count > 0)
						{
							if (labelsForSearch.Intersect(entry.AllLabels.Select(l => l.LabelText)).Count() == labelsForSearch.Count && !entriesToReturn.Contains(entry)) 
							{ entriesToReturn.Add(entry); }
						}
					}
				}
				else
				{
					if (labelsForSearch.Intersect(entry.AllLabels.Select(l => l.LabelText)).Any()) { entriesToReturn.Add(entry); }
				}
			}
			return entriesToReturn;
		}

		public async Task	Rename(string newName, bool uploadTriggerFile)
		{
			this.Name = newName;
			await this.Save();
		}

		public async Task	RenameLabel(string oldName,  string newName)
		{
			var saveJournal = false;
			foreach(Entry entry in this.Entries.Where(e => e.Labels.Contains(oldName)).ToList()) 
			{ saveJournal = entry.RemoveOrReplaceLabel(oldName, newName); }

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
					GenerateMesssage("The PIN you entered is not correct.", null, "Bad PIN", caller);
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

		public async Task	Save(Form callingForm = null)
		{
			if (this.Id == 0)
			{
				var vId = DbAccess.CRUDNotebook(this);

				if(vId.intValue == 0) 
				{ GenerateMesssage("An error occurred. The Notebook was not saved. " + vId.strValue, null, "Error!", callingForm);	}
				else 
				{ 
					this.Id = vId.intValue;
					Program.AllNotebooks.Add(this);
					await Utilities.PopulateAllNotebookNames();
					GenerateMesssage("The Notebook was saved/restored.", null, "Operation Complete", callingForm);
				}
			}
			else
			{
				DbAccess.CRUDNotebook(this, OperationType.Update);
				await Utilities.PopulateAllNotebooks();
				GenerateMesssage("The Notebook was updated.", null, "Operation Complete", callingForm);
			}
		}

		public AllFoundEntries	Search(SearchObject So)
		{
			AllFoundEntries fe = new();

			if (So.labelsForSearch.Count > 0 & Entries.Count > 0)
			{
				fe.foundWithLabels.AddRange(ProcessLabels(Entries, So.labelsForSearch, So.radLabels_And.Checked));
			}

			var title = !So.chkMatchCase_Title.Checked ? So.searchTitle.ToLower() : So.searchTitle;
			var text = !So.chkMatchCase_Text.Checked ? So.searchText.ToLower() : So.searchText;

			if (So.searchTitle.Length > 0)
			{
				if (!So.chkMatchCase_Title.Checked)
				{
					fe.foundWithTitle = Entries.Where(e => e.Title.ToLower().Contains(title)).ToList();
				}
				else
				{
					fe.foundWithTitle = Entries.Where(e => e.Title.Contains(title)).ToList();
				}
			}

			if (So.searchText.Length > 0)
			{
				if (!So.chkMatchCase_Text.Checked)
				{
					fe.foundWithText = Entries.Where(e => e.Text.ToLower().Contains(text)).ToList();
				}
				else
				{
					fe.foundWithText = Entries.Where(e => e.Text.Contains(text)).ToList();
				}
			}

			if (So.chkUseDate.Checked | So.chkUseDateRange.Checked)
			{
				if (So.radCreatedOn.Checked)
				{
					fe.foundWithDate = Entries.Where(p => p.CreatedOn >= So.dtFindDate_From.Value && p.CreatedOn <= So.dtFindDate_To.Value).ToList();
				}
				else
				{
					fe.foundWithDate = Entries.Where(p => p.EditedOn >= So.dtFindDate_From.Value && p.EditedOn <= So.dtFindDate_To.Value).ToList();
				}
			}

			return fe;
		}
	}

}
