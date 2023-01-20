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
using Microsoft.Extensions.Azure;
using MimeKit.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace myJournal.objects
{
	internal class AzureFileClient
	{
		public AzureFileClient() { }

		public void UploadFile(string localFileName)
		{
			var connString					= "DefaultEndpointsProtocol=https;AccountName=container1a;" +
												"AccountKey=4YNQFl9klH9bp8ieKKfhwiVgiKlZKWieBlyzvu8zlm2hyL0HaR/x3XpbpFYjJ5VF4YgtaAR9sN4F+ASttv59jA==;" +
											"	EndpointSuffix=core.windows.net";
			var fileShareName				= "journals";
			var fileName					= localFileName.Substring(localFileName.LastIndexOf("\\") + 1);
			ShareClient share				= new ShareClient(connString, fileShareName);
			ShareDirectoryClient directory	= share.GetDirectoryClient("");
			ShareFileClient myFile			= share.GetDirectoryClient("").GetFileClient(fileName);

			if (File.Exists(localFileName))
			{
				using FileStream stream	= File.OpenRead(localFileName);
				myFile.Create(stream.Length);
				myFile.UploadRange(new HttpRange(0, stream.Length), stream);
			}
		}

		public async Task DownloadFile(string localFileName, string AzFileName)
		{

			var connString =
				= "DefaultEndpointsProtocol=https;AccountName=container1a;" +
					"AccountKey=4YNQFl9klH9bp8ieKKfhwiVgiKlZKWieBlyzvu8zlm2hyL0HaR/x3XpbpFYjJ5VF4YgtaAR9sN4F+ASttv59jA==;" +
					"EndpointSuffix=core.windows.net";

			try
			{
				using (var fileStream = new FileStream(localFileName + "\\" + AzFileName, FileMode.Create))
				{
					CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connString);
					CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
					CloudFileShare share = fileClient.GetShareReference("journals");
					CloudFile myFile = share.GetRootDirectoryReference().GetFileReference(AzFileName);
					await myFile.DownloadToStreamAsync(fileStream);
				}
			}
			catch(Exception) { }	
		}

	}
}
