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

namespace myJournal.objects
{
	internal class CloudSynchronizer
	{
		public int JournalsSynchd { get { return ItemsSynchd.Count; } }
		public int JournalsSkipped { get { return ItemsSkipped.Count; } }
		public int JournalsDownloaded { get { return ItemsDownloaded.Count; } }
		public int JournalsBackedUp { get { return ItemsBackedUp.Count; } }
		public string Err = string.Empty; 

		private List<string> ItemsSynchd = new List<string>();
		private List<string> ItemsSkipped = new List<string>();
		private List<string> ItemsDownloaded = new List<string>();
		private List<string> ItemsBackedUp = new List<string>();

		public CloudSynchronizer() { }

		public async Task SynchWithCloud(Journal journal = null)
		{
			var journalsFolder = ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"];
			Journal j;
			List<Journal> allJournals = new List<Journal>();
			if (journal == null) { allJournals = Utilities.AllJournals(); } else { allJournals.Add(journal); }

			for (var i = 0; i < allJournals.Count; i++)
			{
				j = new Journal(allJournals[i].Name).Open();

				if (j.AllowCloud)
				{
					FileInfo downloadedAzureJournal = null;

					// synch local to azure
					try
					{
						await AzureFileClient.DownloadOrDeleteFile(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + "_" + j.Name, Program.AzurePassword + "_" + j.Name);

						if (Program.AzureFileExists)
						{ downloadedAzureJournal = Program.AzureFileExists ? new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + "_" + j.Name) : null; }
					}
					catch (Exception ex) { Err = ex.Message; }

					if (Program.AzureFileExists)
					{
						FileInfo localJournal = new FileInfo(Program.AppRoot + journalsFolder + j.Name);

						if (localJournal.LastWriteTime < downloadedAzureJournal.LastWriteTime)  // local file has been updated
						{
							AzureFileClient.UploadFile(Program.AppRoot + journalsFolder + j.Name);
							ItemsSynchd.Add(j.Name + (" (syncd to cloud)"));
						}
						else if (downloadedAzureJournal.LastWriteTime < localJournal.LastWriteTime)   // Azure file has been updated
						{
							await AzureFileClient.DownloadOrDeleteFile(Program.AppRoot + journalsFolder, j.Name);
							ItemsDownloaded.Add(j.Name + (" (syncd from cloud)"));
						}
						else { ItemsSkipped.Add(j.Name + " (files match)"); }           // files match				

						File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + "_" + j.Name);
					}
					else
					{
						AzureFileClient.UploadFile(Program.AppRoot + journalsFolder + j.Name);
						ItemsSynchd.Add(j.Name + " (created in cloud)");
					}
				}
				else
				{
					j.Backup();
					ItemsBackedUp.Add(j.Name + " (backed up locally)");
				}

				File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + "_" + j.Name);
			}

			// Synch from Azure ...
			await AzureFileClient.GetAzureFiles(Program.AzurePassword);
			List<string> localFiles = Utilities.AllJournalNames();

			foreach (string s in Program.AzureFiles)
			{
				var localFName = s.Remove(0, Program.AzurePassword.Length + 1);

				if (!localFiles.Contains(localFName))
				{
					await AzureFileClient.DownloadOrDeleteFile(Program.AppRoot + journalsFolder + localFName, s);
					ItemsSynchd.Add(localFName + " (added from cloud)");
				}
			}

			// sync labels and settings
			await SyncLabelsAndSettings();
		}

		public async Task SyncLabelsAndSettings()
		{
			FileInfo downloadedAzureLabels		= null;
			FileInfo downloadedAzureSettings	= null;
			FileInfo localLabels		= new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]);
			FileInfo localSettings		= new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_SettingsFile"]);
			string sLocalLabelsFile		= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"];
			string sLocalSettingsFile	= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_SettingsFile"];

			try
			{
				// see if cloud labels file exists
				await AzureFileClient.DownloadOrDeleteFile(sLocalLabelsFile, Program.AzurePassword + "_labels", FileMode.Open, false, "labelsandsettings");

				if(localLabels.Length > 0)
				{
					if (Program.AzureFileExists)
					{ downloadedAzureLabels = Program.AzureFileExists ? new FileInfo(sLocalLabelsFile) : null; }
					else
					{ AzureFileClient.UploadFile(sLocalLabelsFile, "labelsandsettings"); }
				}

				if (localSettings.Length > 0)
				{
					await AzureFileClient.DownloadOrDeleteFile(sLocalSettingsFile, Program.AzurePassword + "_settings", FileMode.Open, false, "labelsandsettings");

					if (Program.AzureFileExists)
					{ downloadedAzureSettings = Program.AzureFileExists ? new FileInfo(sLocalLabelsFile) : null; }
					if (Program.AzureFileExists)
					{ AzureFileClient.UploadFile(sLocalLabelsFile); }
				}

				if (downloadedAzureLabels != null)
				{	
					if(localLabels.Length > downloadedAzureLabels.Length) { AzureFileClient.UploadFile(sLocalLabelsFile, "labelsandsettings"); }
					if(downloadedAzureLabels.Length > localLabels.Length) { await AzureFileClient.DownloadOrDeleteFile(sLocalLabelsFile, "settings"); }
				}

				if (downloadedAzureSettings != null)
				{
					if (localSettings.Length > downloadedAzureSettings.Length) { AzureFileClient.UploadFile(sLocalSettingsFile, "labelsandsettings"); }
					if (downloadedAzureSettings.Length > localLabels.Length) { await AzureFileClient.DownloadOrDeleteFile(sLocalSettingsFile, "settings", FileMode.Open, false, "labelsandsettings"); }
				}

			}
			catch (Exception ex) { Err = ex.Message; }
		}
	}
}