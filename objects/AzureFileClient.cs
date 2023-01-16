using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Files.Shares;
using Azure;
using System.IO;

namespace myJournal.objects
{
	internal class AzureFileClient
	{
		public AzureFileClient() { }

		public void UploadFile(string fileName1)
		{
			var connString = "DefaultEndpointsProtocol=https;AccountName=container1a;AccountKey=KfY2L4E7YVqhMPszJXxz0u3PDNdYkr+ha+vD1IUw8vWzr9HuFAGvtQUXQhAxtjlHKL+km1Ep+RzV+AStSFcPJQ==;EndpointSuffix=core.windows.net";
			var fileShareName = "journals";
			var folderName = "container1";
			var fileName = "testfile.txt";
			var localFilePath = fileName;

			ShareClient share = new ShareClient(connString, fileShareName);

			var directory = share.GetDirectoryClient(folderName);

			var myFile = directory.GetFileClient(fileName);

			using FileStream stream = File.OpenRead(localFilePath);

			myFile.Create(stream.Length);

			myFile.UploadRange(new HttpRange(0, stream.Length), stream);
		}
	}
}
