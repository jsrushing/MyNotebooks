/* Sync with cloud.
 * 1/21/23
 */
using System;
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
			var						fileName	= localFileName.Substring(localFileName.LastIndexOf("\\") + 1);
			ShareClient				share		= new ShareClient(Program.AzureConnString, shareName);
			ShareDirectoryClient	directory	= share.GetDirectoryClient("");
			ShareFileClient			myFile		= directory.GetFileClient(Program.AzurePassword + "_" + fileName);

			if (File.Exists(localFileName))
			{
				using FileStream stream = new FileStream(localFileName, 
					FileMode.Open, FileAccess.Read, FileShare.Read, 64*1024, 
						(FileOptions)0x20000000 | FileOptions.WriteThrough & FileOptions.SequentialScan);
					myFile.Create(stream.Length);
					myFile.UploadRange(new HttpRange(0, stream.Length), stream);
			}
		}

		public static async Task DownloadOrDeleteFile(string localFileName, string AzFileName, FileMode mode = FileMode.Create, bool deleteFile = false, string shareName = "journals")
		{
			using (var stream = new FileStream(localFileName, mode))
			{
				try
				{
					Program.AzureFileExists				= false;
					CloudStorageAccount storageAccount	= CloudStorageAccount.Parse(Program.AzureConnString);
					CloudFileClient		fileClient		= storageAccount.CreateCloudFileClient();
					CloudFileShare		share			= fileClient.GetShareReference(shareName);
					CloudFileDirectory	root			= share.GetRootDirectoryReference();
					CloudFile			myFile			= root.GetFileReference(AzFileName);

					if (deleteFile)
					{ await myFile.DeleteAsync(); }
					else { await myFile.DownloadToStreamAsync(stream); Program.AzureFileExists = true;}	
				}
				catch(Exception) { }
			}
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

			if (creatingKey)	{ Program.AzurePassword = resultSegment.Results.Count() == 1 ? string.Empty : key; }
			else				{ Program.AzurePassword = resultSegment.Results.Count() == 1 ? key : string.Empty; }
		}

		public static async Task GetAzureFiles(string pwd)
		{
			CloudStorageAccount storageAccount	= CloudStorageAccount.Parse(Program.AzureConnString);
			CloudFileClient		fileClient		= storageAccount.CreateCloudFileClient();
			CloudFileShare		share			= fileClient.GetShareReference("journals");
			CloudFileDirectory	root			= share.GetRootDirectoryReference();
			CloudFileDirectory	myDirectory		= root.GetDirectoryReference("journals");
			FileRequestOptions	options			= new FileRequestOptions();
			FileContinuationToken token			= null;
			FileResultSegment	rsltSgmnt		= await root.ListFilesAndDirectoriesSegmentedAsync(pwd, null, token, options, null);

			foreach(CloudFile file in rsltSgmnt.Results) { Program.AzureFiles.Add(file.Name); }
		}
	}
}