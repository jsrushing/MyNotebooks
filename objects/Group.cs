using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Text;
using myNotebooks;
using Encryption;

namespace MyNotebooks.objects
{
	internal class Group
	{
		public string[] NotebookNames { get; private set; }

		public Group(string groupName)
		{
			groupName = Program.GroupFolder + "\\" + groupName;

			if (Directory.Exists(groupName))
			{
				NotebookNames = Directory.GetFiles(groupName);
				Array.ForEach(NotebookNames, x => x = EncryptDecrypt.Decrypt(x, Program.PIN_Group));
			}
			else { CreateNew(groupName); }
		}

		public void CreateNew(string groupName)
		{
			var groupFolder = Program.AccountName + "\\" + groupName;
			Directory.CreateDirectory(groupFolder);
			Directory.CreateDirectory(groupFolder + "\\temp");
			Directory.CreateDirectory(groupFolder + "\\settings");
			Program.GroupFolder = groupFolder;
		}
	}
}
