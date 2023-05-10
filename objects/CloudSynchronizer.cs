/* Sync with cloud.
 * 1/25/23
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.FileProviders;
using static myJournal.objects.Utilities;
using System.CodeDom;
using myJournal.subforms;
using Microsoft.Identity.Client;

namespace myJournal.objects
{
	internal class CloudSynchronizer
	{
		public enum ComparisonResult
		{
			Same,
			LocalNewer,
			CloudNewer
		}

		public int JournalsSynchd		{ get { return ItemsSynchd.Count; } }
		public int JournalsSkipped		{ get { return ItemsSkipped.Count; } }
		public int JournalsDownloaded	{ get { return ItemsDownloaded.Count; } }
		public int JournalsBackedUp		{ get { return ItemsBackedUp.Count; } }
		public int JournalsDeleted		{ get { return ItemsDeleted.Count; } }

		public string Err = string.Empty; 

		private List<string> ItemsSynchd		= new List<string>();
		private List<string> ItemsSkipped		= new List<string>();
		private List<string> ItemsDownloaded	= new List<string>();
		private List<string> ItemsBackedUp		= new List<string>();
		private List<string> ItemsDeleted		= new List<string>();
		private ComparisonResult journalComparisonResult { get; set; }

		public CloudSynchronizer() { journalComparisonResult = ComparisonResult.Same; }

		private void CompareJournals(Journal localJournal, Journal cloudJournal)
		{
			//ComparisonResult _result = ComparisonResult.Same;

			if(!Program.SkipFileSizeComparison)
			{
				this.journalComparisonResult = localJournal.LastSaved > cloudJournal.LastSaved ? (ComparisonResult.LocalNewer) : cloudJournal.LastSaved > localJournal.LastSaved ? (ComparisonResult.CloudNewer) : (ComparisonResult.Same);
			}
			
			//if (_result != ComparisonResult.Same)
			//{
			//	//if (!Program.SkipFileSizeComparison)
			//	//{
			//	//	//if (_result == ComparisonResult.LocalNewer)
			//	//	//{
			//	//	//	AzureFileClient.UploadFile(localJournal.FileName);
			//	//	//	ItemsSynchd.Add(localJournal.FileName + "up'd (newer)");
			//	//	//}
			//	//	//else
			//	//	//{
			//	//	//	//File.Move(cloudJournal.FileName, localJournal.FileName);
			//	//	//	//await AzureFileClient.DownloadOrDeleteFile(localJournal.FileName, localJournal.Name);
			//	//	//	//ItemsDownloaded.Add(localJournal.Name + " dl'd (newer)");
			//	//	//}
			//	//}
			//	//else { _result = ComparisonResult.LocalNewer; }
			//}

			//this.MainResult = _result;	
		}

		private ComparisonResult CompareLabelsAndSettings(FileInfo fileinfo1, FileInfo fileinfo2)
		{
			DateTime localLabelsFileDate = LabelsManager.GetLabelsFileDate(GetLabelsAsArray(fileinfo1));
			DateTime cloudLabelsFileDate = LabelsManager.GetLabelsFileDate(GetLabelsAsArray(fileinfo2));
			return localLabelsFileDate > cloudLabelsFileDate ? ComparisonResult.LocalNewer : localLabelsFileDate < cloudLabelsFileDate ? ComparisonResult.CloudNewer : ComparisonResult.Same;
		}

		private string[] GetLabelsAsArray(FileInfo file)
		{
			string sRtrn = string.Empty;

			using (FileStream fs = File.OpenRead(file.FullName))
			{
				byte[] b = new byte[1024];
				UTF8Encoding temp = new UTF8Encoding(true);

				while (fs.Read(b, 0, b.Length) > 0)
				{ sRtrn = temp.GetString(b); }
			}

			return sRtrn.Substring(0, sRtrn.LastIndexOf("\r\n")).Split("\r\n");
		}

		public async Task SynchWithCloud(bool alsoSynchSettings = false, Journal journal = null)
		{
			var journalsFolder			= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"];
			var tempFolder				= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + "_";
			List<Journal> allJournals	= new List<Journal>();
			Journal j					= new Journal();

			if (journal == null)	// If no journal is passed then 'allJournals' will contain all local journals. If one is passed (from Journal.Save()) it will only contain one.
			{ 
				allJournals = Program.AllJournals; } 
			else 
			{ 	
				// handle journal being named with '(local)' which means it's newly created and has never been uploaded.
				if (journal.AllowCloud && journal.FileName.EndsWith(" (local)"))
				{
					var sOldName		= journal.FileName;
					var sNewName		= journal.FileName.Substring(0, journal.FileName.LastIndexOf("\\") + 1) + journal.Name;
					journal.FileName	= sNewName;
					File.Copy(sOldName, sNewName, true);
					File.Delete(sOldName);
					AzureFileClient.UploadFile(journalsFolder + journal.Name);
					return;
				}

				allJournals.Add(journal); 
			}

			for (var i = 0; i < allJournals.Count; i++)
			{
				j = new Journal(allJournals[i].Name).Open();

				if(j != null)
				{
					if (j.AllowCloud)
					{
						Journal cloudJournal;

						try
						{
							await AzureFileClient.DownloadOrDeleteFile(tempFolder + j.Name, Program.AzurePassword + "_" + j.Name);
							cloudJournal = File.Exists(tempFolder + j.Name) ? new Journal(j.Name, tempFolder + j.Name).Open(true) : null;
						}
						catch (Exception ex) { Err = ex.Message; break; }

						if (cloudJournal != null)
						{
							this.CompareJournals(j, cloudJournal);

							switch (journalComparisonResult)
							{
								case ComparisonResult.Same:
									ItemsSkipped.Add(j.Name + " (files match)");
									break;
								case ComparisonResult.LocalNewer:
									AzureFileClient.UploadFile(j.FileName);
									ItemsSynchd.Add(j.FileName + "up'd (newer)");
									break;
								case ComparisonResult.CloudNewer:
									File.Move(cloudJournal.FileName, j.FileName, true);
									ItemsDownloaded.Add(j.Name + " (syncd from cloud)");
									break;
							}
						}
					}
					else
					{
						j.Backup();
						ItemsBackedUp.Add(j.Name + " (backed up locally)");
					}
				}
				else
				{
					if (j.AllowCloud)
					{
						AzureFileClient.UploadFile(journalsFolder + j.Name);
					}
				}

				File.Delete(tempFolder + j.Name);
			}


			await AzureFileClient.GetAzureFiles(Program.AzurePassword, true);

			foreach(string sJrnlName in Program.AzureFiles.Except(Utilities.AllJournalNames()))		// any journal on Azure not found locally
			{

					await AzureFileClient.DownloadOrDeleteFile(journalsFolder + sJrnlName, Program.AzurePassword + "_" + sJrnlName);
					ItemsDownloaded.Add(sJrnlName + " dl'd from cloud");
			}
				
			foreach(string sLocalFile in Utilities.AllJournalNames().Except(Program.AzureFiles))	// any journal found locally but not on Azure
			{
				// Either download the journal found on Azure or delete the file - business rule <<				
				j = new Journal(sLocalFile).Open(true);

				if (j.AllowCloud)
				{
					// Add an item to Settings - DeleteLocalIfNotOnAzure
					// If(!Settings.DeleteLocalIfNotFoundOnAzure)
					// {
					//		File.Delete(journalsFolder + sLocalFile);
					//		ItemsDeleted.Add(sLocalFile);
					// }
					// else
					// {
					//		await AzureFileClient.DownloadOrDeleteFile(journalsFolder + sLocalFile, Program.AzurePassword + "_" + sLocalFile);
					//		ItemsDownloaded.Add(sLocalFile + " dl'd from cloud");
					// }

					File.Delete(journalsFolder + sLocalFile);
					ItemsDeleted.Add(sLocalFile);
				}
			}				

			if(alsoSynchSettings) await SyncLabelsAndSettings();
		}

		public async Task SyncLabelsAndSettings()
		{
			//return;
			FileInfo downloadedAzureLabels		= null;
			FileInfo downloadedAzureSettings	= null;
			FileInfo localLabels				= new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]);
			FileInfo localSettings				= new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_SettingsFile"]);
			var sLocalLabelsFile				= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"];
			var sLocalSettingsFile				= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_SettingsFile"];
			var tempFolder						= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + "_labels";

			try
			{
				if (localLabels.Length > 0)
					{
						try
						{
							await AzureFileClient.DownloadOrDeleteFile(tempFolder, Program.AzurePassword + "_labels", FileMode.Create, false, "labelsandsettings");
							downloadedAzureLabels = Program.AzureFileExists ? new FileInfo(tempFolder) : null; 
						}
						catch(Exception ex) { Err = ex.Message; }
					}

					if (downloadedAzureLabels != null)
					{
						
						switch(CompareLabelsAndSettings(localLabels, downloadedAzureLabels))
						{
							case ComparisonResult.Same:
								break;
							case ComparisonResult.LocalNewer:
								AzureFileClient.UploadFile(sLocalLabelsFile, "labelsandsettings");
								break;
							case ComparisonResult.CloudNewer:
								File.Move(tempFolder, sLocalLabelsFile, true);
								break;	
						}
					}
				else
				{
					if (new FileInfo(sLocalLabelsFile).Length > 0) AzureFileClient.UploadFile(sLocalLabelsFile, "labelsandsettings");
				}

				File.Delete(tempFolder);			
			}
			catch (Exception ex) { Err = ex.Message; }

			try
			{
				if (localSettings.Length > 0)
				{
					tempFolder = tempFolder.Substring(0, tempFolder.LastIndexOf("\\")) + "_settings";

					try
					{
						await AzureFileClient.DownloadOrDeleteFile(sLocalSettingsFile, Program.AzurePassword + "_settings", FileMode.Open, false, "labelsandsettings");
						downloadedAzureSettings = Program.AzureFileExists ? new FileInfo(tempFolder) : null;
					}
					catch (Exception ex) { Err = ex.Message; }

					if (downloadedAzureSettings != null)
					{
						switch (CompareLabelsAndSettings(localLabels, downloadedAzureLabels))
						{
							case ComparisonResult.Same:
								break;
							case ComparisonResult.LocalNewer:
								AzureFileClient.UploadFile(sLocalSettingsFile, "labelsandsettings");
								break;
							case ComparisonResult.CloudNewer:
								File.Move(tempFolder, sLocalSettingsFile, true);
								break;
						}
					}
				}
				else
				{
					if (new FileInfo(sLocalSettingsFile).Length > 0) AzureFileClient.UploadFile(sLocalSettingsFile);
				}
			}
			catch (Exception ex) { Err = ex.Message; }

			File.Delete(tempFolder + "_settings");
		}
	}
}


//result = fileinfo1.LastWriteTimeUtc < fileinfo2.LastWriteTimeUtc ?
//	ComparisonResult.LocalNewer
//	: fileinfo1.LastWriteTimeUtc > fileinfo2.LastWriteTimeUtc ? ComparisonResult.CloudNewer
//	: ComparisonResult.Same;

//var sMsg = "The journal '" + fileinfo1.Name + (localNewer ? "' on your device " : "' in your cloud ") +
//	"is newer than the journal found " + (localNewer ? "in your cloud." : "on your device.");
//sMsg += Environment.NewLine + Environment.NewLine + "Press 'Yes' to " + (localNewer ? "upload " : "download ") + "the newer journal" +
//	(localNewer ? " from your device to your cloud." : " to your device from your cloud.") +
//	Environment.NewLine + "'No' to " + (localNewer ? "download " : "upload ") + "the older journal " + (!localNewer ? " from your device to your cloud." : " to your device from your cloud.") +
//	Environment.NewLine + "or 'Cancel' to make no changes.";

//var sMsg = "The journal '" + fileinfo1.Name + (LocalNewer ? "' on your device " : "' in your cloud ") +
//	"is larger than the journal found " + (LocalNewer ? "in your cloud." : "on your device.");
//sMsg += Environment.NewLine + Environment.NewLine + "Press 'Yes' to " + (LocalNewer ? "upload " : "download ") + "the larger journal, " +
//	Environment.NewLine + "'No' to " + (LocalNewer ? "download " : "upload ") + "the smaller journal, " +
//	Environment.NewLine + "or 'Cancel' to make no changes.";

//var sMsg = "The journal '" + fileinfo1.Name + (localNewer ? "' on your device " : "' in your cloud ") +
//	"is newer than the journal found " + (localNewer ? "in your cloud." : "on your device.");
//sMsg += Environment.NewLine + Environment.NewLine + "Press 'Yes' to " + (localNewer ? "upload " : "download ") + "the newer journal, " +
//	Environment.NewLine + "'No' to " + (localNewer ? "download " : "upload ") + "the older journal, " +
//	Environment.NewLine + "or 'Cancel' to make no changes.";

//frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, sMsg, "Journal (" + fileinfo1.Name + ") Size Mismatch Found");
//frm.ShowDialog();

//if(frm.Result == frmMessage.ReturnResult.Yes)
//{
//	result = fileinfo1.LastWriteTimeUtc < fileinfo2.LastWriteTimeUtc ? ComparisonResult.LocalNewer : ComparisonResult.CloudNewer;
//}
//else if(frm.Result == frmMessage.ReturnResult.No)
//{
//	result = fileinfo1.LastWriteTimeUtc < fileinfo2.LastWriteTimeUtc ? ComparisonResult.CloudNewer : ComparisonResult.LocalNewer;
//}