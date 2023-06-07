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
using myJournal.subforms;
using System.Xml;
using Org.BouncyCastle.Crypto.Agreement;
using System.Reflection.Emit;
using Newtonsoft.Json.Linq;

namespace myJournal.objects
{
	public static class LabelsManager
	{
		public enum LabelsSortType
		{
			Ascending,
			Descending,
			None
		}		

		public static void Add(string[] lables)
		{
				string[] newLabels = ((lables).Except(GetLabels_NoFileDate())).ToArray();
				File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"], newLabels);
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

		public static async Task DeleteLabel(string labelName, List<Journal> journalsToEdit, Form parent, bool isOrphan = false)
		{
			if (isOrphan)
			{
				await Save(File.ReadAllLines(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]).Where(c => c != labelName).ToArray().SkipLast(1).ToList());
			}
			else
			{
				foreach(Journal j in journalsToEdit) 
				{ 
					Utilities.SetProgramPIN(j.Name);
					await j.DeleteLabel(labelName); 
				}

				if(journalsToEdit.Count == Program.AllJournals.Count)
				{ await Save(File.ReadAllLines(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]).Where(c => c != labelName).ToArray().SkipLast(1).ToList()); }
				else
				{
					var sMsg = "The label has been left in the labels list because you did not search all Journals. " +
						"You must select ALL journals (and provide PINs for all protected journals) to clear the label from the list.";
					using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, sMsg, "Label May Still Exist", parent)) { frm.ShowDialog(); }
				}
			}
		}

		public static List<string> FindOrphansInSelectedJournals()
		{
			List<string> lstReturn = new List<string>();
			List<string> allLabels = GetLabels_NoFileDate().ToList();
			lstReturn.AddRange(allLabels);
			Journal journal = null;

			foreach (KeyValuePair<string, string> kvp in Program.DictCheckedJournals)
			{
				Utilities.SetProgramPIN(kvp.Key);
				journal = new Journal(kvp.Key).Open();

				if(journal != null)
				{
					foreach (JournalEntry je in journal.Entries)
					{
						foreach(var v2 in allLabels.Intersect(je.ClearLabels().Split(',')).ToList()) { lstReturn.Remove(v2); }
					}
				}
			}

			//if (addFoundOrphansToLabels) { Add(lstReturn.ToArray()); }
			return lstReturn;
		}

		public static DateTime GetLabelsFileDate(string[] labels) 
		{ 
			DateTime dt = DateTime.MinValue;
			string lastLabel = labels.Last();
			try { dt = DateTime.ParseExact(lastLabel.Replace("_", " "), "dd/MM/yyyy HH:mm:ss", null); }		// USE CONFIGMANAGER !!!! <<<
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

		public static List<Journal> JournalsContainingLabel(string labelName, bool returnIfTwoFound = false)
		{
			List<Journal> lstRtrn = new List<Journal>();
			List<Journal> jrnls2Search = Program.AllJournals.Where(e => Program.DictCheckedJournals.ContainsKey(e.Name)).ToList();

			foreach (Journal journal in jrnls2Search)
			{
				Utilities.SetProgramPIN(journal.Name);

				if (journal.Entries.Where(t => ("," + t.ClearLabels() + ",").Contains("," + labelName + ",")).ToList().Count > 0)
				{
					lstRtrn.Add(journal);
					if (returnIfTwoFound && lstRtrn.Count == 2) { break; }
				}
			}
			return lstRtrn;
		}

		public static void PopulateLabelsList(CheckedListBox clb = null, ListBox lb = null, LabelsSortType sort = LabelsSortType.None)
		{
			if (clb != null) { clb.Items.Clear(); }
			if (lb != null) { lb.Items.Clear(); }

			foreach (string label in LabelsManager.GetLabels_NoFileDate(sort))
			{
				if (lb != null) { lb.Items.Add(label); }
				else { clb.Items.Add(label); }
			}
		}

		public static async Task RenameLabel(string oldLabelName, string newLabelName, List<Journal> journalsToEdit, Dictionary<string, string> jrnlsAndPINs, Form parent)
		{
			foreach(Journal j in journalsToEdit)
			{
				Utilities.SetProgramPIN(j.Name);
				await j.RenameLabel(oldLabelName, newLabelName);
			}
		}

		public static async Task<bool> Save(List<string> labels = null)
		{
			var bRtrn = false;

			try
			{
				StringBuilder sb = new StringBuilder();
				CloudSynchronizer cs = new CloudSynchronizer();
				foreach (string tag in labels) { sb.AppendLine(tag); }
				sb.AppendLine (DateTime.Now.ToString(ConfigurationManager.AppSettings["FileDate"]));
				File.WriteAllText(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"], sb.ToString());
				await cs.SyncLabelsAndSettings();
				bRtrn = true;
			}
			catch (Exception) { }

			return bRtrn;
		}
	}
}
