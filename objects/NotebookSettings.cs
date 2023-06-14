using System;
using System.Collections.Generic;
using System.Text;

namespace myNotebooks.objects
{
	[Serializable]
	public class NotebookSettings
	{
		public NotebookSettings(JournalSettings journalSettings)
		{
			this.AllowCloud = journalSettings.AllowCloud;
			this.IfCloudOnly_Download = journalSettings.IfCloudOnly_Download;
			this.IfCloudOnly_Delete = journalSettings.IfCloudOnly_Delete;
			this.IfLocalOnly_Upload = journalSettings.IfLocalOnly_Upload;
			this.IfLocalOnly_Delete = journalSettings.IfLocalOnly_Delete;
			this.IfLocalOnly_DisallowCloud = journalSettings.IfLocalOnly_DisallowCloud;
		}

		public bool AllowCloud { get; set; }
		public bool IfCloudOnly_Download { get; set; }
		public bool IfCloudOnly_Delete { get; set; }
		public bool IfLocalOnly_Upload { get; set; }
		public bool IfLocalOnly_Delete { get; set; }
		public bool IfLocalOnly_DisallowCloud { get; set; }

		public NotebookSettings() { }


	}
}
