using System;
using System.Collections.Generic;
using System.Text;

namespace myJournal.objects
{
	[Serializable]
	public class JournalSettings
	{
		public bool AllowCloud { get; set; }
		public bool IfCloudOnly_Download { get; set; }
		public bool IfCloudOnly_Delete { get; set; }
		public bool IfLocalOnly_Upload { get; set; }
		public bool IfLocalOnly_Delete { get; set; }
		public bool IfLocalOnly_DisallowCloud { get; set; }

		public JournalSettings() { }


	}
}
