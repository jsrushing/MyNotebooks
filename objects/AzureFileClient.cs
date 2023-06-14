/* Sync with cloud.
 * 1/21/23
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Files.Shares;
using Encryption;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;

namespace myNotebooks.objects
{
	internal static class AzureFileClient
	{
		public enum CompareResult { }

		public static async Task DownloadOrDeleteFile(string localFileName, string AzFileName,
			FileMode mode = FileMode.Create, bool deleteFile = false, string shareName = "notebooks")
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

		public static async Task CheckForCloudNotebooklAndRemoveEntries(Notebook book)
		{
			var tempFolder = ConfigurationManager.AppSettings["FolderStructure_Temp"];
			var tempFileName = Program.AppRoot + tempFolder + book.Name;

			try 
			{ 
				await DownloadOrDeleteFile(tempFileName, Program.AzurePassword + book.Name);
				Notebook book2 = new Notebook(book.Name, tempFileName).Open(true);
				book2.Entries.Clear();
				await book2.Save();
				await AzureFileClient.UploadFile(tempFileName);
				File.Delete(tempFileName);
			}
			catch (Exception) { }
		}

		public static async Task CheckNewAzurePassword(string key, bool creatingKey)
		{
			key									= EncryptDecrypt.Encrypt(key);
			CloudStorageAccount storageAccount	= CloudStorageAccount.Parse(Program.AzureConnString);
			CloudFileClient		fileClient		= storageAccount.CreateCloudFileClient();
			CloudFileShare		share			= fileClient.GetShareReference("keys");
			CloudFileDirectory	root			= share.GetRootDirectoryReference();
			CloudFileDirectory	myDirectory		= root.GetDirectoryReference("keys");
			FileResultSegment	resultSegment	= await root.ListFilesAndDirectoriesSegmentedAsync(key, 1, null, new FileRequestOptions(), null);
			Program.AzurePassword				= resultSegment.Results.Count() == 1 ? creatingKey ? string.Empty : key : string.Empty;
		}

		public static async Task GetAzureItemNames(bool scrubAzPwd = false, string shareName = "notebooks")
		{
			CloudStorageAccount storageAccount	= CloudStorageAccount.Parse(Program.AzureConnString);
			CloudFileClient		fileClient		= storageAccount.CreateCloudFileClient();
			CloudFileShare		share			= fileClient.GetShareReference(shareName);
			CloudFileDirectory	root			= share.GetRootDirectoryReference();
			CloudFileDirectory	myDirectory		= root.GetDirectoryReference("notebooks");
			FileRequestOptions	options			= new FileRequestOptions();
			FileContinuationToken token			= null;
			FileResultSegment	rsltSgmnt		= await root.ListFilesAndDirectoriesSegmentedAsync(Program.AzurePassword, null, token, options, null);

			Program.AzureNotebookNames.Clear();

			foreach(CloudFile file in rsltSgmnt.Results) 
			{ 
				if (shareName == "notebooks") { Program.AzureNotebookNames.Add(scrubAzPwd ? file.Name.Replace(Program.AzurePassword, "") : file.Name); } 
				else if(shareName == "notebooksrenamed") { Program.AzureRenameCommands.Add(scrubAzPwd ? file.Name.Replace(Program.AzurePassword, "") : file.Name); }
			}
		}

		public static async Task RenameFile(string filePath, string newFileName)
		{
			// Create a connection string to the Azure Storage account
			ShareServiceClient serviceClient = new ShareServiceClient(Program.AzureConnString);

			// Get a reference to the file share
			ShareClient share = serviceClient.GetShareClient("notebooks");

			// Get a reference to the file
			ShareDirectoryClient directory = share.GetDirectoryClient(Path.GetDirectoryName(filePath));
			ShareFileClient file = directory.GetFileClient(Path.GetFileName(filePath));

			// Specify the new file name
			string newFilePath = Path.Combine(directory.Path, newFileName);

			// Rename the file
			await file.RenameAsync(newFilePath);

			Console.WriteLine("File renamed successfully.");
		}

		public static async Task UploadFile(string localFileName, string shareName = "notebooks")
		{
			var fileName					= localFileName.Substring(localFileName.LastIndexOf("\\") + 1);
			ShareClient share				= new ShareClient(Program.AzureConnString, shareName);
			ShareDirectoryClient directory	= share.GetDirectoryClient("");
			ShareFileClient myFile			= directory.GetFileClient(fileName.Contains(Program.AzurePassword) ? fileName : Program.AzurePassword + fileName);

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

		public static async void UploadDeletedFileTrigger(string deletedFile) { }

		public async static void UploadRenamedFileTrigger(string oldName, string newName)
		{
			var tempFldr = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + Program.AzurePassword + oldName + "_" + newName;
			var contents = oldName + "_" + newName;
			using(StreamWriter sw = new StreamWriter(tempFldr)) {sw.WriteLine(contents); }
			await UploadFile(tempFldr, "notebooksrenamed");
			File.Delete(tempFldr);
		}
	}
}