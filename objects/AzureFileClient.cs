/* Sync with cloud.
 * 1/21/23
 */
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Files.Shares;
using encrypt_decrypt_string;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace myJournal.objects
{
	internal static class AzureFileClient
	{
		public enum CompareResult { }

		public static void UploadFile(string localFileName, string shareName = "journals")
		{
			var fileName = localFileName.Substring(localFileName.LastIndexOf("\\") + 1);
			ShareClient share = new ShareClient(Program.AzureConnString, shareName);
			ShareDirectoryClient directory = share.GetDirectoryClient("");
			ShareFileClient myFile = directory.GetFileClient(Program.AzurePassword + "_" + fileName);

			if (File.Exists(localFileName))
			{
				//using FileStream stream = new FileStream(localFileName,
				//	FileMode.Open, FileAccess.Read, FileShare.Read, 64 * 1024,
				//		(FileOptions)0x20000000 | FileOptions.WriteThrough & FileOptions.SequentialScan);

				using FileStream stream = new FileStream(localFileName, FileMode.Open, FileAccess.Read);
				myFile.Create(stream.Length);
				myFile.UploadRange(new HttpRange(0, stream.Length), stream);
			}
		}

		public static async Task DownloadOrDeleteFile(string localFileName, string AzFileName,
			FileMode mode = FileMode.Create, bool deleteFile = false, string shareName = "journals")
		{
			Program.AzureFileExists				= false;
			CloudStorageAccount storageAccount	= CloudStorageAccount.Parse(Program.AzureConnString);
			CloudFileClient		fileClient		= storageAccount.CreateCloudFileClient();
			CloudFileShare		share			= fileClient.GetShareReference(shareName);
			CloudFileDirectory	root			= share.GetRootDirectoryReference();
			CloudFile			myFile			= root.GetFileReference(AzFileName);

			if(await myFile.ExistsAsync())
			{
				if (deleteFile)
				{
					await myFile.DeleteAsync();
				}
				else
				{
					using (FileStream stream = new FileStream(localFileName, mode))
					{
						await myFile.DownloadToStreamAsync(stream); 
						Program.AzureFileExists = true;
					}
				}
			}
		}

		public static async Task CheckForCloudJournalAndRemoveEntries(Journal j)
		{
			var tmpFolder = ConfigurationManager.AppSettings["FolderStructure_Temp"];
			var tmpFileName = Program.AppRoot + tmpFolder + j.Name;
			try 
			{ 
				await DownloadOrDeleteFile(tmpFileName, Program.AzurePassword + "_" + j.Name);
				Journal j2 = new Journal(j.Name, tmpFileName).Open(true);
				j2.Settings.AllowCloud = false;
				j2.Entries.Clear();
				j2.Save();
				AzureFileClient.UploadFile(tmpFileName);
				File.Delete(tmpFileName);
			}
			catch (Exception) { }
		}

		public static async Task CheckNewAzurePassword(string key, bool creatingKey)
		{
			key									= EncryptDecrypt.Encrypt(key);
			CloudStorageAccount storageAccount	= CloudStorageAccount.Parse(Program.AzureConnString);
			CloudFileClient fileClient			= storageAccount.CreateCloudFileClient();
			CloudFileShare share				= fileClient.GetShareReference("keys");
			CloudFileDirectory root				= share.GetRootDirectoryReference();
			CloudFileDirectory myDirectory		= root.GetDirectoryReference("keys");
			FileResultSegment resultSegment		= await root.ListFilesAndDirectoriesSegmentedAsync(key, 1, null, new FileRequestOptions(), null);
			Program.AzurePassword				= resultSegment.Results.Count() == 1 ? creatingKey ? string.Empty : key : string.Empty;
		}

		public static async Task GetAzureJournalNames(string pwd, bool scrubAzPwd = false)
		{
			CloudStorageAccount storageAccount	= CloudStorageAccount.Parse(Program.AzureConnString);
			CloudFileClient		fileClient		= storageAccount.CreateCloudFileClient();
			CloudFileShare		share			= fileClient.GetShareReference("journals");
			CloudFileDirectory	root			= share.GetRootDirectoryReference();
			CloudFileDirectory	myDirectory		= root.GetDirectoryReference("journals");
			FileRequestOptions	options			= new FileRequestOptions();
			FileContinuationToken token			= null;
			FileResultSegment	rsltSgmnt		= await root.ListFilesAndDirectoriesSegmentedAsync(pwd, null, token, options, null);

			foreach(CloudFile file in rsltSgmnt.Results) { Program.AzureJournalNames.Add(scrubAzPwd ? file.Name.Replace(Program.AzurePassword + "_", "") : file.Name); }
		}
	}
}