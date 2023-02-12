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

namespace myJournal.objects
{
	internal class CloudSynchronizer
	{
		public enum ComparisonResult
		{
			Same,
			FirstNewer,
			SecondNewer
		}

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

		private ComparisonResult CompareJournals(FileInfo fileinfo1, FileInfo fileinfo2)
		{
			Journal j1 = new Journal("j1");
			j1.FileName = fileinfo1.FullName;
			j1 = j1.Open(true);

			Journal j2 = new Journal("j2");
			j2.FileName = fileinfo2.FullName;
			j2 = j2.Open(true);

			return j1.LastSaved < j2.LastSaved ? ComparisonResult.FirstNewer : j1.LastSaved > j2.LastSaved ? ComparisonResult.SecondNewer : ComparisonResult.Same;
		}

		public async Task SynchWithCloud(bool SynchSettings = false, Journal journal = null)
		{
			var journalsFolder = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"];
			var tempFolder = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"];
			Journal j;
			List<Journal> allJournals = new List<Journal>();
			if (journal == null) { allJournals = Utilities.AllJournals(); } else { allJournals.Add(journal); }

			for (var i = 0; i < allJournals.Count; i++)
			{
				j = new Journal(allJournals[i].Name).Open();

				if (j.AllowCloud)
				{
					FileInfo downloadedAzureJournal = null;
					FileInfo localJournal = new FileInfo(journalsFolder + j.Name);

					// synch local to azure
					try
					{
						await AzureFileClient.DownloadOrDeleteFile(tempFolder + "_" + j.Name, Program.AzurePassword + "_" + j.Name);
						downloadedAzureJournal = Program.AzureFileExists ? new FileInfo(tempFolder + "_" + j.Name) : null;
					}
					catch (Exception ex) { Err = ex.Message; }

					if (downloadedAzureJournal != null)
					{
						//ComparisonResult result = CompareJournals(localJournal, downloadedAzureJournal);

						switch(CompareJournals(localJournal, downloadedAzureJournal))
						{
							case ComparisonResult.Same:
								ItemsSkipped.Add(j.Name + " (files match)");
								break;
							case ComparisonResult.FirstNewer:
								AzureFileClient.UploadFile(journalsFolder + j.Name);
								ItemsSynchd.Add(j.Name + (" (syncd to cloud)"));
								break;
							case ComparisonResult.SecondNewer:
								File.Move(tempFolder + "_" + j.Name, journalsFolder + j.Name, true);
								ItemsDownloaded.Add(j.Name + (" (syncd from cloud)"));
								break;
						}
					}
					else
					{
						AzureFileClient.UploadFile(journalsFolder + j.Name);
						ItemsSynchd.Add(j.Name + " (created in cloud)");
					}

					File.Delete(tempFolder + "_" + j.Name);
				}
				else
				{
					j.Backup();
					ItemsBackedUp.Add(j.Name + " (backed up locally)");
				}

				//File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + "_" + j.Name);
			}

			// Synch from Azure ...
			await AzureFileClient.GetAzureFiles(Program.AzurePassword);
			List<string> localFiles = Utilities.AllJournalNames();

			foreach (string s in Program.AzureFiles)
			{
				var localFName = s.Remove(0, Program.AzurePassword.Length + 1);

				if (!localFiles.Contains(localFName))
				{
					await AzureFileClient.DownloadOrDeleteFile(journalsFolder + localFName, s);
					ItemsSynchd.Add(localFName + " (added from cloud)");
				}
			}

			// sync labels and settings
			if(SynchSettings) await SyncLabelsAndSettings();
		}

		public async Task SyncLabelsAndSettings()
		{
			FileInfo downloadedAzureLabels		= null;
			FileInfo downloadedAzureSettings	= null;
			FileInfo localLabels				= new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]);
			FileInfo localSettings				= new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_SettingsFile"]);
			var sLocalLabelsFile				= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"];
			var sLocalSettingsFile				= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_SettingsFile"];

			var labelsTempFile = "C:\\Users\\js_ru\\source\\repos\\myJournal2022\\bin\\Debug\\netcoreapp3.1\\journals\\backups\\temp\\_labels";
			var tempFolder = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"];

			//downloadedAzureLabels = Program.AzureFileExists ? new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + "_labels") : null);

			try
			{
				if (localLabels.Length > 0)
				{
					try
					{
						await AzureFileClient.DownloadOrDeleteFile(labelsTempFile, Program.AzurePassword + "_labels", FileMode.Create, false, "labelsandsettings");
						downloadedAzureLabels = Program.AzureFileExists ? new FileInfo(tempFolder + "_labels") : null; 
					}
					catch(Exception ex) { Err = ex.Message; }
				}

				if (downloadedAzureLabels != null)
				{
					if (localLabels.CreationTime < downloadedAzureLabels.CreationTime)
					{
						AzureFileClient.UploadFile(sLocalLabelsFile, "labelsandsettings");
					}
					else if (localLabels.CreationTime > downloadedAzureLabels.CreationTime)
					{
						File.Move(tempFolder + "_labels", sLocalLabelsFile, true);
					}
				}
				else
				{
					if (new FileInfo(sLocalLabelsFile).Length > 0) AzureFileClient.UploadFile(sLocalLabelsFile, "labelsandsettings");
				}

				File.Delete(tempFolder + "_labels");

			}
			catch (Exception ex) { Err = ex.Message; }

			try
			{
				if (localSettings.Length > 0)
				{
					try
					{
						await AzureFileClient.DownloadOrDeleteFile(sLocalSettingsFile, Program.AzurePassword + "_settings", FileMode.Open, false, "labelsandsettings");
						downloadedAzureSettings = Program.AzureFileExists ? new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + "_settings") : null;
					}
					catch(Exception ex ) { Err = ex.Message;}

					if (downloadedAzureSettings != null)
					{
						if (localSettings.CreationTime > downloadedAzureSettings.CreationTime) 
						{ 
							AzureFileClient.UploadFile(sLocalSettingsFile, "labelsandsettings");
						}
						if (downloadedAzureSettings.CreationTime > localLabels.CreationTime) 
						{
							File.Move(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + "_labels", sLocalSettingsFile, true);
						}
					}
				}
				else
				{
					if(new FileInfo(sLocalSettingsFile).Length > 0) AzureFileClient.UploadFile(sLocalSettingsFile);
				}
			}
			catch (Exception ex) { Err = ex.Message; }

			File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + "_settings");
		}
	}
}