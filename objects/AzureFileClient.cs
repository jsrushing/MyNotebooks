using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Files.Shares;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using myJournal.subforms;

namespace myJournal.objects
{
	internal class AzureFileClient
	{

		public AzureFileClient() { }
		

		public void UploadFile(string localFileName)
		{
			var fileName					= localFileName.Substring(localFileName.LastIndexOf("\\") + 1);
			if(!fileName.StartsWith(Program.AzurePassword)) { fileName = Program.AzurePassword + fileName; }
			ShareClient share				= new ShareClient(Program.AzureConnString, "journals");
			ShareDirectoryClient directory	= share.GetDirectoryClient("");
			ShareFileClient myFile			= directory.GetFileClient(fileName);


			if (File.Exists(localFileName))
			{
				using FileStream stream = File.OpenRead(localFileName);
				myFile.Create(stream.Length);
				myFile.UploadRange(new HttpRange(0, stream.Length), stream);
			}
		}

		public async Task DownloadOrDeleteFile(string localFileName, string AzFileName, bool deleteFile = false)
		{
			//AzFileName = Program.AzurePassword + AzFileName;

			using (var fileStream = new FileStream(localFileName, FileMode.Create))
			{
				try
				{
					Program.AzureFileExists = false;
					CloudStorageAccount storageAccount	= CloudStorageAccount.Parse(Program.AzureConnString);
					CloudFileClient fileClient			= storageAccount.CreateCloudFileClient();
					CloudFileShare share				= fileClient.GetShareReference("journals");
					CloudFileDirectory directory		= share.GetRootDirectoryReference();
					CloudFile myFile					= directory.GetFileReference(AzFileName);

					if (deleteFile)
					{ await myFile.DeleteAsync(); }
					else { await myFile.DownloadToStreamAsync(fileStream); }
					
					Program.AzureFileExists = true;
				}
				catch(Exception) { }
			}	
		}

		public async Task CheckAzurePassword(string pwd)
		{
			//pwd = Program.AzurePassword + "\\";

			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Program.AzureConnString);
			CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
			CloudFileShare share = fileClient.GetShareReference("journals");
			CloudFileDirectory root = share.GetRootDirectoryReference();
			CloudFileDirectory myDirectory = root.GetDirectoryReference("journals");

			FileRequestOptions options= new FileRequestOptions();
			FileContinuationToken token = null;
			FileResultSegment resultSegment = await root.ListFilesAndDirectoriesSegmentedAsync(pwd, 1, token, options, null);

			if(resultSegment.Results.Count() > 0)
			{ Program.AzurePassword = pwd + "_"; }
		}

		public async Task GetAzureFiles(string pwd)
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
