using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Encryption;
using myNotebooks;

namespace MyNotebooks.objects
{
	internal class Account
	{
		public string[] GroupNames { get; private set; }
		public string Name { get; private set; }

		public Account(string accountName) 
		{
			accountName = Program.AppRoot + "accounts\\" + accountName;

			if(Directory.Exists(accountName))
			{
				GroupNames = Directory.GetDirectories(accountName + "\\");
				Array.ForEach(GroupNames, e => e = EncryptDecrypt.Decrypt(e, e + Program.PIN_Master));
			}
			else { CreateNew(Program.AppRoot + accountName); }
		}

		public void CreateNew(string accountName)
		{
			Directory.CreateDirectory(accountName);
		}

	}
}
