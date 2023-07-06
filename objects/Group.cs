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
		public List<Notebook> Notebooks { get; private set; } = new List<Notebook>();
		public string Name { get; private set; }
		public string PIN { get; private set; }

		public Group(string Name, string PIN)
		{
			this.PIN = PIN;
			this.Name = Name;
			foreach (string nbName in Directory.GetDirectories(Program.GroupsFolder + this.Name))
			{
				Program.AllNotebookNames.Add(EncryptDecrypt.Decrypt(nbName, Program.PIN_Group));
			}
		}
	}
}
