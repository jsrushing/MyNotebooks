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

namespace myNotebooks.objects
{
	internal class CloudSynchronizer
	{
		public enum ComparisonResult
		{
			Same,
			LocalNewer,
			CloudNewer
		}

		public int NotebooksSynchd		{ get { return ItemsSynchd.Count; } }
		public int NotebooksSkipped		{ get { return ItemsSkipped.Count; } }
		public int NotebooksDownloaded	{ get { return ItemsDownloaded.Count; } }
		public int NotebooksBackedUp		{ get { return ItemsBackedUp.Count; } }
		public int NotebooksDeleted		{ get { return ItemsDeleted.Count; } }

		public string Err = string.Empty; 

		private List<string> ItemsSynchd		= new List<string>();
		private List<string> ItemsSkipped		= new List<string>();
		private List<string> ItemsDownloaded	= new List<string>();
		private List<string> ItemsBackedUp		= new List<string>();
		private List<string> ItemsDeleted		= new List<string>();
		private ComparisonResult notebookComparisonResult { get; set; }

		public CloudSynchronizer() { notebookComparisonResult = ComparisonResult.Same; }

		private async Task CheckForLocalOrCloudOnly(string tempFolder, string notebooksFolder)
		{
			foreach (var sBookName in Program.AzureNotebookNames.Except(Program.AllNotebookNames))        // any journal on Azure not found locally
			{
				await AzureFileClient.DownloadOrDeleteFile(tempFolder + sBookName, Program.AzurePassword + sBookName);
				Notebook j3 = new Notebook(tempFolder + sBookName, tempFolder + sBookName).Open();	

				if(j3 == null) { j3 = new Notebook(sBookName, tempFolder + sBookName).Open(true);}

				if (j3 != null && j3.Settings.IfCloudOnly_Download)
				{
					if(!File.Exists(notebooksFolder + sBookName))
					{ 
						File.Move(tempFolder + sBookName, notebooksFolder + sBookName); 
						ItemsDownloaded.Add(sBookName + " dl'd from cloud");
					}		
				}

				if (j3 !=null &&j3.Settings.IfCloudOnly_Delete)
				{
					await AzureFileClient.DownloadOrDeleteFile(tempFolder + j3.Name, Program.AzurePassword + j3.Name, FileMode.Open, true);
				}

				File.Delete(tempFolder + sBookName);
			}

			foreach (var sLocalFile in Program.AllNotebookNames.Except(Program.AzureNotebookNames))   // any journal found locally but not on Azure
			{
				Notebook j2 = new Notebook(sLocalFile).Open();
				if (j2.Settings.AllowCloud)
				{
					if (j2.Settings.IfLocalOnly_Delete) { j2.Delete(); }
					else if (j2.Settings.IfLocalOnly_Upload) { await AzureFileClient.UploadFile(j2.FileName); }
					else if (j2.Settings.IfLocalOnly_DisallowCloud) { j2.Settings.AllowCloud = false; await	j2.Save(); }
				}
			}
		}

		private void CompareNotebooks(Notebook localJournal, Notebook cloudJournal)
		{
			if(!Program.SkipFileSizeComparison)
			{ this.notebookComparisonResult = localJournal.LastSaved > cloudJournal.LastSaved ? (ComparisonResult.LocalNewer) : cloudJournal.LastSaved > localJournal.LastSaved ? (ComparisonResult.CloudNewer) : (ComparisonResult.Same); }
			else { this.notebookComparisonResult = ComparisonResult.Same; }
		}

		private ComparisonResult CompareLabelsAndSettings(FileInfo fileinfo1, FileInfo fileinfo2)
		{
			DateTime localLabelsFileDate = LabelsManager.GetLabelsFileDate(GetLabelsAsArray(fileinfo1));
			DateTime cloudLabelsFileDate = LabelsManager.GetLabelsFileDate(GetLabelsAsArray(fileinfo2));

			return localLabelsFileDate > cloudLabelsFileDate ? 
				ComparisonResult.LocalNewer : localLabelsFileDate < cloudLabelsFileDate ? ComparisonResult.CloudNewer : ComparisonResult.Same;
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

			//var v = sRtrn.Substring(0, sRtrn.LastIndexOf("\r\n")).Split("\r\n").TakeLast(1);
			return sRtrn.Substring(0, sRtrn.LastIndexOf("\r\n")).Split("\r\n");
		}

		private async Task ProcessNotebooks(List<Notebook> allNotebooks, string tempFolder, string notebooksFolder)
		{
			Notebook cloudNotebook = null;
			Notebook book;

			for (var i = 0; i < allNotebooks.Count; i++)
			{
				book = allNotebooks[i];

				if (book != null)
				{
					if (book.Settings.AllowCloud)
					{
						try
						{
							await AzureFileClient.DownloadOrDeleteFile(tempFolder + book.Name, Program.AzurePassword + book.Name);
							cloudNotebook = File.Exists(tempFolder + book.Name) ? new Notebook(book.Name, tempFolder + book.Name).Open(true) : null;
						}
						catch (Exception) { }

						if (cloudNotebook != null)
						{

							if (cloudNotebook.Entries.Count > 0)    // Turning CloudAccess OFF in one notebook propogates to next device.
							{
								this.CompareNotebooks(book, cloudNotebook);

								switch (notebookComparisonResult)
								{
									case ComparisonResult.Same:
										ItemsSkipped.Add(book.Name + " (files match)");
										break;
									case ComparisonResult.LocalNewer:
										await AzureFileClient.UploadFile(book.FileName);
										ItemsSynchd.Add(book.FileName + "up'd (newer)");
										break;
									case ComparisonResult.CloudNewer:
										File.Move(cloudNotebook.FileName, book.FileName, true);
										ItemsDownloaded.Add(book.Name + " (syncd from cloud)");
										break;
								}

								File.Delete(tempFolder + cloudNotebook.Name);
							}
							else // The cloud journal is a 0-entry placeholder which sets the local journal's AllowCloud = false.
							{
								book.Settings.AllowCloud = false;
								await book.Save();
							}
						}
						else	// a local notebook doesn't have a match in the cloud
						{
							// check for renamed notebook, rename if found
							await AzureFileClient.GetAzureItemNames(true, "notebooksrenamed");
							List<string> azCommands = Program.AzureRenameCommands.Where(e => e.StartsWith(book.Name)).ToList();

							if(azCommands.Count > 0)
							{
								var newName = azCommands[0].Replace(book.Name + "_", "");
								await book.Rename(newName, false);	// will Save() the book

								// Get the cloud book. The local copy will have been saved so it's newer, but the cloud one is what we want since it has the latest updates.
								await AzureFileClient.DownloadOrDeleteFile(tempFolder + book.Name, Program.AzurePassword + book.Name);
								cloudNotebook = File.Exists(tempFolder + book.Name) ? new Notebook(book.Name, tempFolder + book.Name).Open(true) : null;
								File.Move(cloudNotebook.FileName, book.FileName, true);

								//await book.Save();
							}
							else
							{
								if (book.Settings.IfLocalOnly_Upload)			{ await AzureFileClient.UploadFile(book.FileName); }
								if (book.Settings.IfLocalOnly_Delete)			{ File.Delete(book.FileName); }
								if (book.Settings.IfLocalOnly_DisallowCloud)	{ book.Settings.AllowCloud = false; }
							}
						}
					}
					else
					{
						book.Backup();
						ItemsBackedUp.Add(book.Name + " (backed up locally)");
					}
				}
				else
				{
					if (book.Settings.AllowCloud) { await AzureFileClient.UploadFile(notebooksFolder + book.Name); }
				}

				File.Delete(tempFolder + book.Name);
			}
		}

		public async Task SynchWithCloud(bool alsoSynchSettings = false, Notebook notebook = null)
		{
			var NotebooksFolder			= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"];
			var tempFolder				= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"];
			List<Notebook> allNotebooks	= new List<Notebook>();
			await Utilities.PopulateAllNotebooks();

			if(Program.AllNotebooks.Count == 0) { await Utilities.PopulateAllNotebooks(); }
			if (notebook == null) { allNotebooks = Program.AllNotebooks; } else { allNotebooks.Add(notebook); }

			if(notebook != null)
			{
				if (notebook.FileName.EndsWith(" (local)"))
				{
					var sOldName = notebook.FileName;
					var sNewName = notebook.FileName.Substring(0, notebook.FileName.LastIndexOf("\\") + 1) + notebook.Name;
					notebook.FileName = sNewName;
					File.Copy(sOldName, sNewName, true);
					File.Delete(sOldName);
					if (notebook.Settings.AllowCloud) { await AzureFileClient.UploadFile(NotebooksFolder + notebook.Name); }
					return;
				}

				Notebook nb = allNotebooks.Where(e => e.Name == notebook.Name & e.LastSaved == notebook.LastSaved).First();
				if (nb == null) { Program.AllNotebooks.Add(notebook); }
			}

			await ProcessNotebooks(allNotebooks, tempFolder, NotebooksFolder);
			await AzureFileClient.GetAzureItemNames(true);
			await CheckForLocalOrCloudOnly(tempFolder, NotebooksFolder);			

			if(alsoSynchSettings) await SyncLabelsAndSettings();
		}

		public async Task SyncLabelsAndSettings()
		{
			//return;
			FileInfo downloadedAzureLabels		= null;
			//FileInfo downloadedAzureSettings	= null;
			FileInfo localLabels				= new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]);
			//FileInfo localSettings				= new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_SettingsFile"]);
			var sLocalLabelsFile				= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"];
			//var sLocalSettingsFile				= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_SettingsFile"];
			var tempFolder						= Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"];
			var tempLabelsFile					= tempFolder + "_labels";
			//var tempSettingsFile				= tempFolder + "_settings";

			try
			{
				if (localLabels.Length > 0)
				{
					try
					{
						// this is failing ... 060923 0930
						await AzureFileClient.DownloadOrDeleteFile(tempLabelsFile, Program.AzurePassword + "labels", FileMode.Create, false, "labelsandsettings");
						downloadedAzureLabels = Program.AzureFileExists ? new FileInfo(tempLabelsFile) : null;
					}
					catch (Exception ex) { Err = ex.Message; }
				}

				if (downloadedAzureLabels != null)
				{
					switch (CompareLabelsAndSettings(localLabels, downloadedAzureLabels))
					{
						case ComparisonResult.Same:
							break;
						case ComparisonResult.LocalNewer:
							await AzureFileClient.UploadFile(sLocalLabelsFile, "labelsandsettings");
							break;
						case ComparisonResult.CloudNewer:
							File.Move(tempLabelsFile, sLocalLabelsFile, true);
							break;
					}
				}
				else { await AzureFileClient.UploadFile(sLocalLabelsFile, "labelsandsettings"); }
			}
			catch (Exception ex) { Err = ex.Message; }
			
			File.Delete(tempLabelsFile);			

			//try
			//{
			//	if (localSettings.Length > 0)
			//	{
			//		try
			//		{
			//			await AzureFileClient.DownloadOrDeleteFile(tempSettingsFile, Program.AzurePassword + "_settings", FileMode.Open, false, "labelsandsettings");
			//			downloadedAzureSettings = Program.AzureFileExists ? new FileInfo(tempSettingsFile) : null;
			//		}
			//		catch (Exception ex) { Err = ex.Message; }

			//		if (downloadedAzureSettings != null)
			//		{
			//			switch (CompareLabelsAndSettings(localLabels, downloadedAzureLabels))
			//			{
			//				case ComparisonResult.Same:
			//					break;
			//				case ComparisonResult.LocalNewer:
			//					AzureFileClient.UploadFile(sLocalSettingsFile, "labelsandsettings");
			//					break;
			//				case ComparisonResult.CloudNewer:
			//					File.Move(tempSettingsFile, sLocalSettingsFile, true);
			//					break;
			//			}
			//		}
			//		else
			//		{
			//			if (new FileInfo(sLocalSettingsFile).Length > 0) AzureFileClient.UploadFile(sLocalSettingsFile);
			//		}
			//	}
			//	else
			//	{
			//		if (new FileInfo(sLocalSettingsFile).Length > 0) AzureFileClient.UploadFile(sLocalSettingsFile);
			//	}
			//}
			//catch (Exception ex) { Err = ex.Message; }

			//File.Delete(tempSettingsFile);
		}
	}
}