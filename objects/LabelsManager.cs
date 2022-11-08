/* created 11/6/22
 * 
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace myJournal.objects
{
	public class LabelsManager
	{
		private bool Renaming = false;
		private bool Adding = false;
		private bool Deleting = false;
		private bool EditingAllJournals;
		public bool ActionTaken { get; private set; }
		public Journal Journal { private get; set; }


		private Journal _currentJournal = new Journal();

		public LabelsManager(Journal journal = null, JournalEntry journalEntry = null, string journalPIN = null)
		{
			_currentJournal = journal == null ? null : journal;

		}

		public List<JournalEntry> JournalHasLabel(Journal journal, string labelName)
		{
			return journal.Entries.Where(t => ("," + t.ClearTags() + ",").Contains("," + labelName + ",")).ToList();
		}

		public bool SaveLabels(List<string> labels)
		{
			bool bRtrn = false;
			try
			{
				StringBuilder sb = new StringBuilder();
				foreach (string tag in labels) { sb.AppendLine(tag); }
				File.WriteAllText(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFolder"], sb.ToString());
				bRtrn = true;
			}
			catch (Exception) { }

			return bRtrn;
		}



	}
}
