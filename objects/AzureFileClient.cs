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

		public void UploadFile(string localFileName)
		{
			var connString = "DefaultEndpointsProtocol=https;AccountName=container1a;AccountKey=4YNQFl9klH9bp8ieKKfhwiVgiKlZKWieBlyzvu8zlm2hyL0HaR/x3XpbpFYjJ5VF4YgtaAR9sN4F+ASttv59jA==;EndpointSuffix=core.windows.net";
			var fileShareName = "journals";
			var fileName = localFileName.Substring(localFileName.LastIndexOf("\\") + 1);

			ShareClient share = new ShareClient(connString, fileShareName);

			ShareDirectoryClient directory = share.GetDirectoryClient("");

			ShareFileClient myFile = directory.GetFileClient(fileName);

			using FileStream stream = File.OpenRead(localFileName);

			myFile.Create(stream.Length);

			myFile.UploadRange(new HttpRange(0, stream.Length), stream);
		}
	}
}
