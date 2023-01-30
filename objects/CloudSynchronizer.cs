using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;

namespace myJournal.objects
{
	internal class CloudSynchronizer
	{
		public int JournalsSynchd { get { return ItemsSynchd.Count; } }
		public int JournalsSkipped { get { return ItemsSkipped.Count; } }
		public int JournalsDownloaded { get { return ItemsDownloaded.Count; } }
		public int JournalsBackedUp { get { return ItemsBackedUp.Count; } }

		private List<string> ItemsSynchd = new List<string>();
		private List<string> ItemsSkipped = new List<string>();
		private List<string> ItemsDownloaded = new List<string>();
		private List<string> ItemsBackedUp = new List<string>();

		public CloudSynchronizer() { }

		public async Task SynchWithCloud()
		{
			var journalsFolder = ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"];
			Journal j;
			//AzureFileClient client = new AzureFileClient();
			List<Journal> allJournals = Utilities.AllJournals();

			for (int i = 0; i < allJournals.Count; i++)
			{
				j = new Journal(allJournals[i].Name).Open();

				if (j.AllowCloud)
				{
					FileInfo downloadedAzureJournal = null;
					var error = string.Empty;

					// synch local to azure
					try
					{
						await AzureFileClient.DownloadOrDeleteFile(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + "_" + j.Name, Program.AzurePassword + "_" + j.Name);
						if (Program.AzureFileExists)
						{ downloadedAzureJournal = Program.AzureFileExists ? new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + "_" + j.Name) : null; }
					}
					catch (Exception ex) { error = ex.Message; }

					if (Program.AzureFileExists)
					{
						FileInfo localJournal = new FileInfo(Program.AppRoot + journalsFolder + j.Name);

						if (localJournal.Length > downloadedAzureJournal.Length)  // local file has been updated
						{
							AzureFileClient.UploadFile(Program.AppRoot + journalsFolder + j.Name);
							ItemsSynchd.Add(j.Name + (" (syncd to cloud)"));
						}
						else if (downloadedAzureJournal.Length > localJournal.Length)   // Azure file has been updated
						{
							await AzureFileClient.DownloadOrDeleteFile(Program.AppRoot + journalsFolder, j.Name);
							ItemsDownloaded.Add(j.Name + (" (syncd from cloud)"));
						}
						else { ItemsSkipped.Add(j.Name + " (files match)"); }           // files match				

						File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + "_" + j.Name);
					}
					else
					{
						File.Copy(Program.AppRoot + journalsFolder + j.Name, Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + j.Name, true);
						AzureFileClient.UploadFile(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + j.Name);
						File.Delete(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + j.Name);
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
					//remoteJournalsToSynch.Add(s);
					await AzureFileClient.DownloadOrDeleteFile(Program.AppRoot + journalsFolder + localFName, s);
					ItemsSynchd.Add(localFName + " (added from cloud)");
				}
			}
		}
	}
}
