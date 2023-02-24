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
using System.Windows.Forms;

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

		public static void Add(string[] lables)
		{
				string[] newLabels = ((lables).Except(GetLabels_NoFileDate())).ToArray();
				File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"], newLabels);
		}

		public static void Delete(string labelName)
		{
			Save(File.ReadAllLines(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]).Where(c => c != labelName).ToList());
		}

		public List<string> FindOrphansInAJournal(Journal journal, bool addFoundOrphansToLabels = false)
		{
			List<string> lstReturn = new List<string>();
			string[] allLabels = GetLabels_NoFileDate();

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

		public static DateTime GetLabelsFileDate(string[] labels) 
		{ 
			DateTime dt = DateTime.MinValue;
			string lastLabel = labels.Last();
			try { dt = DateTime.ParseExact(lastLabel.Replace("_", " "), "dd/MM/yyyy HH:mm:ss", null); }
			catch { }	// lastLabel isn't a DateTime.
			return dt;
		}

		public static string[] GetLabels_NoFileDate(LabelsSortType sort = LabelsSortType.None)
		{
			string[] labels = File.ReadAllLines(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]);
			labels = labels.Take(labels.Count() - 1).ToArray();
			Array.Sort(labels);
			if(sort == LabelsSortType.Ascending) { Array.Reverse(labels); }
			return labels;	
		}

		public static string CheckedLabels_Get(CheckedListBox cbx)
		{
			string labels = string.Empty;
			for (int i = 0; i < cbx.CheckedItems.Count; i++)
			{
				labels += cbx.CheckedItems[i].ToString() + ",";
			}
			labels = labels.Length > 0 ? labels.Substring(0, labels.Length - 1) : string.Empty;
			return labels;
		}

		public static void CheckedLabels_Set(CheckedListBox clb, JournalEntry entry)
		{
			var labels = entry.ClearLabels().Split(",");
			for (var i = 0; i < clb.Items.Count; i++) { clb.SetItemChecked(i, labels.Contains(clb.Items[i].ToString())); }
		}

		public static List<string> FindOrphansInOneJournal(Journal journal, bool addFoundOrphansToLabels = false)
		{
			List<string> lstReturn = new List<string>();
			string[] allLabels = GetLabels_NoFileDate();

			foreach (JournalEntry je in journal.Entries)
			{
				foreach (string jeLabel in je.ClearLabels().Split(","))
				{
					if (jeLabel.Length > 0 && !allLabels.Contains(jeLabel) && !lstReturn.Contains(jeLabel))
					{ lstReturn.Add(jeLabel); }
				}
			}
			return lstReturn;
		}

		public static List<Journal> JournalsContainingLabel(string labelName)
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

		public static void PopulateLabelsList(CheckedListBox clb = null, ListBox lb = null, LabelsSortType sort = LabelsSortType.None)
		{
			if (clb != null) { clb.Items.Clear(); }
			if (lb != null) { lb.Items.Clear(); }
			//LabelsManager lm = new LabelsManager();

			foreach (string label in LabelsManager.GetLabels_NoFileDate(sort))
			{
				if (lb != null)
				{ lb.Items.Add(label); }
				else
				{ clb.Items.Add(label); }
			}
		}

		public static bool Save(List<string> labels = null)
		{
			var bRtrn = false;

			try
			{
				StringBuilder sb = new StringBuilder();
				CloudSynchronizer cs = new CloudSynchronizer();
				foreach (string tag in labels) { sb.AppendLine(tag); }
				sb.AppendLine (DateTime.Now.ToString(ConfigurationManager.AppSettings["FileDate"]));
				File.WriteAllText(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"], sb.ToString());
				cs.SyncLabelsAndSettings();
				bRtrn = true;
			}
			catch (Exception) { }

			return bRtrn;
		}
	}
}
