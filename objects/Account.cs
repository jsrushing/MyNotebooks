using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using myNotebooks;

namespace MyNotebooks.objects
{
	internal class Account
	{
		public string[] GroupNames { get; private set; }

		public Account(string accountName) 
		{
			GroupNames = Directory.GetDirectories(Program.AppRoot + "accounts\\" + accountName + "\\");



		}

		public void CreateNew(string accountName)
		{

		}

	}
}
