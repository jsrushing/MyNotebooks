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
using static myJournal.objects.Utilities;
using System.Runtime.CompilerServices;

namespace myJournal.objects
{
	public class LabelsManager
	{
		public enum LabelsSortType
		{
			Ascending,
			Descending,
			None
		}		

		public bool ActionTaken { get; private set; }
		public Journal Journal { private get; set; }

		public LabelsManager(Journal journal = null, JournalEntry journalEntry = null, string journalPIN = null)
		{
			//_currentJournal = journal == null ? null : journal;
		}

		public void Add(string[] lables)
		{
				string[] newLabels = ((lables).Except(GetAllLabels_ExcludeDate())).ToArray();
				File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"], newLabels);
		}

		public void Delete(string labelName)
		{
			Save(File.ReadAllLines(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]).Where(c => c != labelName).ToList());
		}

		public List<string> FindOrphansInAJournal(Journal journal, bool addFoundOrphansToLabels = false)
		{
			List<string> lstReturn = new List<string>();
			string[] allLabels = GetAllLabels_ExcludeDate();

			foreach (JournalEntry je in journal.Entries)
			{
				foreach (string jeLabel in je.ClearLabels().Split(","))
				{
					if (jeLabel.Length > 0 && !allLabels.Contains(jeLabel) && !lstReturn.Contains(jeLabel))
					{ lstReturn.Add(jeLabel); }
				}
			}

			if (addFoundOrphansToLabels) { Add(lstReturn.ToArray()); }
			return lstReturn;
		}

		public string[] GetAllLabels_ExcludeDate(LabelsSortType sort = LabelsSortType.None)
		{
			string[] labels = File.ReadAllLines(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]);
			labels = labels.Take(labels.Count() - 1).ToArray();
			Array.Sort(labels);
			if(sort == LabelsSortType.Ascending) { Array.Reverse(labels); }
			return labels;	
		}

		public DateTime GetLabelsFileDate(string[] labels)
		{ return DateTime.Parse(labels.Last()); }

		public List<Journal> JournalsContainingLabel(string labelName)
		{
			LabelsManager lm = new LabelsManager();	
			List<Journal> lstRtrn = new List<Journal>();

			foreach (Journal journal in Utilities.AllJournals())
			{
				//SetProgramPINForSelectedJournal(jrnl);

				if(journal.Entries.Where(t => ("," + t.ClearLabels() + ",").Contains("," + labelName + ",")).ToList().Count > 0)
				{ lstRtrn.Add(journal); }
			}
			return lstRtrn;
		}

		public bool Save(List<string> labels)
		{
			bool bRtrn = false;
			try
			{
				StringBuilder sb = new StringBuilder();
				foreach (string tag in labels) { sb.AppendLine(tag); }
				sb.AppendLine(DateTime.Now.ToString("dd/MM/yy_HH/mm/ss"));
				File.WriteAllText(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"], sb.ToString());
				bRtrn = true;
			}
			catch (Exception) { }

			return bRtrn;
		}



	}
}
