using System;
using System.Collections.Generic;
using System.Text;

namespace myJournal.objects
{
	[Serializable]
	public class JournalSettings
	{
		public bool AllowCloud { get; set; }
		public bool CloudOnly_Download { get; set; }
		public bool LocalOnly_Upload { get; set; }
		public bool LocalOnly_Delete { get; set; }
		public bool LocalOnly_DisallowCloud { get; set; }

		public JournalSettings() { }


	}
}
