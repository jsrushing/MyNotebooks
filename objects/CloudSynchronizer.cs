/* Sync with cloud.
 * 1/25/23
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		private async Task CheckForLocalOrCloudOnly(string tempFolder, string journalsFolder)
		{
			foreach (var sJrnlName in Program.AzureJournalNames.Except(Utilities.AllJournalNames()))        // any journal on Azure not found locally
			{
				await AzureFileClient.DownloadOrDeleteFile(tempFolder + sJrnlName, Program.AzurePassword + "_" + sJrnlName);
				Journal j3 = new Journal(tempFolder + sJrnlName, tempFolder + sJrnlName).Open(true);

				if (j3.Settings.IfCloudOnly_Download)
				{
					File.Move(tempFolder + sJrnlName, journalsFolder + sJrnlName);
					ItemsDownloaded.Add(sJrnlName + " dl'd from cloud");
				}

				if (j3.Settings.IfCloudOnly_Delete)
				{
					await AzureFileClient.DownloadOrDeleteFile(tempFolder + j3.Name, Program.AzurePassword + "_" + j3.Name, FileMode.Open, true);
				}

				File.Delete(tempFolder + sJrnlName);
			}

			foreach (var sLocalFile in Utilities.AllJournalNames().Except(Program.AzureJournalNames))   // any journal found locally but not on Azure
			{
				Journal j2 = new Journal(sLocalFile).Open();
				if (j2.Settings.AllowCloud)
				{
					if (j2.Settings.IfLocalOnly_Delete) { j2.Delete(); }
					else if (j2.Settings.IfLocalOnly_Upload) { AzureFileClient.UploadFile(j2.FileName); }
					else if (j2.Settings.IfLocalOnly_DisallowCloud) { j2.Settings.AllowCloud = false; j2.Save(); }
				}
			}
		}

		private void CompareJournals(Journal localJournal, Journal cloudJournal)
		{
			if(!Program.SkipFileSizeComparison)
			{ this.journalComparisonResult = localJournal.LastSaved > cloudJournal.LastSaved ? (ComparisonResult.LocalNewer) : cloudJournal.LastSaved > localJournal.LastSaved ? (ComparisonResult.CloudNewer) : (ComparisonResult.Same); }
			else { this.journalComparisonResult = ComparisonResult.Same; }
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

		private async Task ProcessJournals(List<Journal> allJournals, string tempFolder, string journalsFolder)
		{
			Journal cloudJournal = null;
			Journal j;

			for (var i = 0; i < allJournals.Count; i++)
			{
				j = allJournals[i];

				if (j != null)
				{
					if (j.Settings.AllowCloud)
					{
						try
						{
							await AzureFileClient.DownloadOrDeleteFile(tempFolder + j.Name, Program.AzurePassword + "_" + j.Name);
							cloudJournal = File.Exists(tempFolder + j.Name) ? new Journal(j.Name, tempFolder + j.Name).Open(true) : null;
						}
						catch (Exception) { }

						if (cloudJournal != null)
						{                                                                           
							if (cloudJournal.Entries.Count > 0)
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
							else // The cloud journal is a 0-entry placeholder which sets the local journal's AllowCloud = false.
							{
								j.Settings.AllowCloud = false;
								j.Save();
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
					if (j.Settings.AllowCloud) { AzureFileClient.UploadFile(journalsFolder + j.Name); }
				}

				File.Delete(tempFolder + j.Name);
			}
		}

		public async Task SynchWithCloud(bool alsoSynchSettings = false, Journal journal = null)
		{
			var journalsFolder			= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"];
			var tempFolder				= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"];
			List<Journal> allJournals	= new List<Journal>();
			Program.AllJournals			= Utilities.AllJournals();

			if (journal == null)	// If no journal is passed then 'allJournals' will contain all local journals. If one is passed (from Journal.Save()) it will only contain one.
			{ 
				allJournals = Program.AllJournals; } 
			else 
			{
				// Handle newly created, nevewr uploaded journal (title ends with '(local)').
				if (journal.FileName.EndsWith(" (local)"))
				{
					var sOldName		= journal.FileName;
					var sNewName		= journal.FileName.Substring(0, journal.FileName.LastIndexOf("\\") + 1) + journal.Name;
					journal.FileName	= sNewName;
					File.Copy(sOldName, sNewName, true);
					File.Delete(sOldName);
					if (journal.Settings.AllowCloud) { AzureFileClient.UploadFile(journalsFolder + journal.Name); }
					return;
				}

				allJournals.Add(journal); 
			}

			await ProcessJournals(allJournals, tempFolder, journalsFolder);
			await AzureFileClient.GetAzureJournalNames(Program.AzurePassword, true);
			Program.AllJournals = Utilities.AllJournals();
			await CheckForLocalOrCloudOnly(tempFolder, journalsFolder);		

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
			var tempFolder						= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"];

			try
			{
				if (localLabels.Length > 0)
					{
						try
						{
							await AzureFileClient.DownloadOrDeleteFile(tempFolder, Program.AzurePassword + "_labels", FileMode.Create, true, "labelsandsettings");
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