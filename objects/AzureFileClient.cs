using System;
using System.Collections.Generic;
using System.Text;
using Azure;
using Azure.Storage;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using System.IO;
using Microsoft.Identity.Client;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.File;
using System.Configuration;

namespace myJournal.objects
{
	internal class AzureFileClient
	{
		public AzureFileClient() { }

		public void UploadFile(string localFileName)
		{
			var connString					= "DefaultEndpointsProtocol=https;AccountName=container1a;AccountKey=4YNQFl9klH9bp8ieKKfhwiVgiKlZKWieBlyzvu8zlm2hyL0HaR/x3XpbpFYjJ5VF4YgtaAR9sN4F+ASttv59jA==;EndpointSuffix=core.windows.net";
			var fileShareName				= "journals";
			var fileName					= localFileName.Substring(localFileName.LastIndexOf("\\") + 1);
			//ShareClient share					= new ShareClient(connString, fileShareName);
			//ShareDirectoryClient directory	= share.GetDirectoryClient("");
			ShareFileClient myFile			= new ShareClient(connString, fileShareName).GetDirectoryClient("").GetFileClient(fileName);
			
			using FileStream stream	= File.OpenRead(localFileName);
			myFile.Create(stream.Length);
			myFile.UploadRange(new HttpRange(0, stream.Length), stream);
		}

		public async void DownloadFile(string localFileName, string AzFileName)
		{
			StorageCredentials creds = new StorageCredentials("container1a", "4YNQFl9klH9bp8ieKKfhwiVgiKlZKWieBlyzvu8zlm2hyL0HaR/x3XpbpFYjJ5VF4YgtaAR9sN4F+ASttv59jA==");
			CloudStorageAccount storageAccount = new CloudStorageAccount(creds, useHttps: true);
			CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
			CloudFileShare fileShare = fileClient.GetShareReference("journals");
			CloudFile f = fileShare.GetRootDirectoryReference().GetFileReference(AzFileName);
			await f.DownloadToFileAsync(Path.Combine(ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"], AzFileName), FileMode.Create);
		}
	}
}
