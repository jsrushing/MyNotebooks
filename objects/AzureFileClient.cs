using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Files.Shares;
using encrypt_decrypt_string;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using myJournal.subforms;

namespace myJournal.objects
{
	internal static class AzureFileClient
	{
		//CloudStorageAccount storageAccount;
		//CloudFileClient fileClient;
		//CloudFileShare share;
		//CloudFileDirectory root;
		////CloudFileDirectory myDirectory;

		public static void UploadFile(string localFileName)
		{
			var fileName					= localFileName.Substring(localFileName.LastIndexOf("\\") + 1);
			ShareClient share				= new ShareClient(Program.AzureConnString, "journals");
			ShareDirectoryClient directory	= share.GetDirectoryClient("");
			ShareFileClient myFile			= directory.GetFileClient(fileName.StartsWith(Program.AzurePassword) ? fileName : Program.AzurePassword + fileName);

			if (File.Exists(localFileName))
			{
				using FileStream stream = File.OpenRead(localFileName);
				myFile.Create(stream.Length);
				myFile.UploadRange(new HttpRange(0, stream.Length), stream);
			}
		}

		public static async Task DownloadOrDeleteFile(string localFileName, string AzFileName, bool deleteFile = false)
		{
			//AzFileName = Program.AzurePassword + AzFileName;

			using (var fileStream = new FileStream(localFileName, FileMode.Create))
			{
				try
				{
					Program.AzureFileExists = false;
					CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Program.AzureConnString);
					CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
					CloudFileShare share = fileClient.GetShareReference("journals");
					CloudFileDirectory root = share.GetRootDirectoryReference();
					CloudFile myFile = root.GetFileReference(AzFileName);

					if (deleteFile)
					{ await myFile.DeleteAsync(); }
					else { await myFile.DownloadToStreamAsync(fileStream); }
					
					Program.AzureFileExists = true;
				}
				catch(Exception) { }
			}	
			
			File.Delete(localFileName);
		}

		public static async Task CheckAzurePassword(string pwd)
		{
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Program.AzureConnString);
			CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
			CloudFileShare share = fileClient.GetShareReference("journals");
			CloudFileDirectory root = share.GetRootDirectoryReference();
			CloudFileDirectory myDirectory = root.GetDirectoryReference("journals");

			FileRequestOptions options= new FileRequestOptions();
			FileContinuationToken token = null;
			FileResultSegment resultSegment = await root.ListFilesAndDirectoriesSegmentedAsync(pwd, 1, token, options, null);

			Program.AzurePassword = resultSegment.Results.Count() > 0 ? pwd + "_" : string.Empty;
		}

		public static async Task GetAzureFiles(string pwd)
		{
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Program.AzureConnString);
			CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
			CloudFileShare share = fileClient.GetShareReference("journals");
			CloudFileDirectory root = share.GetRootDirectoryReference();
			CloudFileDirectory myDirectory = root.GetDirectoryReference("journals");

			FileRequestOptions options = new FileRequestOptions();
			FileContinuationToken token = null;
			FileResultSegment resultSegment = await root.ListFilesAndDirectoriesSegmentedAsync(pwd, null, token, options, null);

			foreach(CloudFile file in resultSegment.Results) { Program.AzureFiles.Add(file.Name); }
		}
	}
}
