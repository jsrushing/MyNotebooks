/* Simple data object for Notebook Settings. Extensible.
 * 06/05/23
 * JSR
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace myNotebooks.objects
{
	[Serializable]
	public class NotebookSettings
	{
		public bool AllowCloud { get; set; }
		public bool IfCloudOnly_Download { get; set; }
		public bool IfCloudOnly_Delete { get; set; }
		public bool IfLocalOnly_Upload { get; set; }
		public bool IfLocalOnly_Delete { get; set; }
		public bool IfLocalOnly_DisallowCloud { get; set; }

		public NotebookSettings() { }


	}
}
