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
			KeepLocal,
			KeepCloud
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

			if(fileinfo1.Length == fileinfo2.Length) { return ComparisonResult.Same; }
			else
			{
				return j1.LastSaved > j2.LastSaved ? ComparisonResult.KeepLocal : j1.LastSaved < j2.LastSaved ? ComparisonResult.KeepCloud : ComparisonResult.Same;
			}
		}

		private ComparisonResult CompareLabelsAndSettings(string[] localLables , string[] cloudLabels) 
		{ 
			//LabelsManager lm = new LabelsManager();
			DateTime localLabelsFileDate = LabelsManager.GetLabelsFileDate(localLables);
			DateTime cloudLabelsFileDate = LabelsManager.GetLabelsFileDate(cloudLabels);
			return localLabelsFileDate > cloudLabelsFileDate ? ComparisonResult.KeepLocal : localLabelsFileDate < cloudLabelsFileDate ? ComparisonResult.KeepCloud : ComparisonResult.Same;
		}

		private ComparisonResult CompareLabelsAndSettings(FileInfo fileinfo1, FileInfo fileinfo2)
		{
			string[] localLabels = Directory.GetFiles(fileinfo1.FullName);
			string[] cloudLabels = Directory.GetFiles(fileinfo2.FullName);
			//LabelsManager lm = new LabelsManager();
			DateTime localLabelsFileDate = LabelsManager.GetLabelsFileDate(localLabels);
			DateTime cloudLabelsFileDate = LabelsManager.GetLabelsFileDate(cloudLabels);
			return localLabelsFileDate > cloudLabelsFileDate ? ComparisonResult.KeepLocal : localLabelsFileDate < cloudLabelsFileDate ? ComparisonResult.KeepCloud : ComparisonResult.Same;


			//DateTime dt1 = fileinfo1.LastWriteTime;
			//DateTime dt2 = fileinfo2.LastWriteTime;

			//if (fileinfo1.Length == fileinfo2.Length) { return ComparisonResult.Same; }
			//else
			//{
			//return dt1 < dt2 ? ComparisonResult.KeepLocal : dt1 > dt2 ? ComparisonResult.KeepCloud : ComparisonResult.Same;
			//}
			//return d1.LastWriteTime > d1.LastWriteTime ? ComparisonResult.LocalNewer : d1.LastWriteTime < d2.LastWriteTime ? ComparisonResult.CloudNewer : ComparisonResult.Same;	
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
						switch(CompareJournals(localJournal, downloadedAzureJournal))
						{
							case ComparisonResult.Same:
								ItemsSkipped.Add(j.Name + " (files match)");
								break;
							case ComparisonResult.KeepLocal:
								AzureFileClient.UploadFile(journalsFolder + j.Name);
								ItemsSynchd.Add(j.Name + (" (syncd to cloud)"));
								break;
							case ComparisonResult.KeepCloud:
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
							case ComparisonResult.KeepLocal:
								AzureFileClient.UploadFile(sLocalLabelsFile, "labelsandsettings");
								break;
							case ComparisonResult.KeepCloud:
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
							case ComparisonResult.KeepLocal:
								AzureFileClient.UploadFile(sLocalSettingsFile, "labelsandsettings");
								break;
							case ComparisonResult.KeepCloud:
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