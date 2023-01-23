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
			var fileName					= localFileName.Substring(localFileName.LastIndexOf("\\") + 1);
			ShareClient share				= new ShareClient(Program.AzureConnString, "journals");
			ShareDirectoryClient directory	= share.GetDirectoryClient("");
			ShareFileClient myFile			= directory.GetFileClient(Program.DeviceId + fileName);

			if (File.Exists(localFileName))
			{
				using FileStream stream	= File.OpenRead(localFileName);
				myFile.Create(stream.Length);
				myFile.UploadRange(new HttpRange(0, stream.Length), stream);
			}
		}

		public async Task DownloadFile(string localFileName, string AzFileName)
		{
			using (var fileStream = new FileStream(localFileName + "\\" + AzFileName, FileMode.Create))
			{
				try
				{
					CloudStorageAccount storageAccount	= CloudStorageAccount.Parse(Program.AzureConnString);
					CloudFileClient fileClient			= storageAccount.CreateCloudFileClient();
					CloudFileShare share				= fileClient.GetShareReference("journals");
					CloudFileDirectory directory		= share.GetRootDirectoryReference();
					CloudFile myFile					= directory.GetFileReference(Program.DeviceId + AzFileName);
					await myFile.DownloadToStreamAsync(fileStream);
				}
				catch(Exception ex) { }
			}	
		}
	}
}
