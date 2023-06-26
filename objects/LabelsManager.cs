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
using static myNotebooks.objects.Utilities;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using myNotebooks.subforms;
using System.Xml;
using Org.BouncyCastle.Crypto.Agreement;
using System.Reflection.Emit;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace myNotebooks.objects
{
	public static class LabelsManager
	{
		public enum LabelsSortType
		{
			Ascending,
			Descending,
			None
		}		

		public static async Task AddLabel(string[] lables)
		{
			List<string> newLabels = (lables).Except(GetLabels_NoFileDate()).ToList();
			newLabels.AddRange(GetLabels_NoFileDate());
			await SaveLabels(newLabels.ToList());
		}

		public static string CheckedLabels_Get(CheckedListBox cbx)
		{
			string labels = string.Empty;
			
			for (var i = 0; i < cbx.CheckedItems.Count; i++) { labels += cbx.CheckedItems[i].ToString() + ","; }

			labels = labels.Length > 0 ? labels.Substring(0, labels.Length - 1) : string.Empty;
			return labels;
		}

		public static void CheckedLabels_Set(CheckedListBox clb, Entry entry)
		{
			var labels = entry.Labels.Split(",");
			for (var i = 0; i < clb.Items.Count; i++) { clb.SetItemChecked(i, labels.Contains(clb.Items[i].ToString())); }
		}

		public static async Task DeleteLabel(string labelName, List<Notebook> notebooksToEdit, Form parent = null, bool isOrphan = false)
		{
			if (isOrphan)
			{
				await SaveLabels(File.ReadAllLines(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]).Where(c => c != labelName).ToArray().SkipLast(1).ToList());
			}
			else
			{
				foreach(Notebook j in notebooksToEdit) 
				{ 
					Utilities.SetProgramPIN(j.Name);
					await j.DeleteLabelFromNotebook(labelName); 
				}

				if(notebooksToEdit.Count == Program.AllNotebooks.Count)
				{ await SaveLabels(File.ReadAllLines(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"]).Where(c => c != labelName).ToArray().SkipLast(1).ToList()); }
				else
				{
					var sMsg = "The label has been left in the labels list because you did not search all Notebooks. " +
						"You must select ALL notebooks (and provide PINs for all protected notebooks) to clear the label from the list.";
					using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, sMsg, "Label May Still Exist", parent)) { frm.ShowDialog(); }
				}
			}
		}

		public static List<string> FindOrphansInSelectedNotebooks()
		{
			List<string> lstReturn = new List<string>();
			List<string> allLabels = GetLabels_NoFileDate().ToList();
			lstReturn.AddRange(allLabels);
			Notebook nbook;

			foreach (KeyValuePair<string, string> kvp in Program.DictCheckedNotebooks)
			{
				nbook = new Notebook(kvp.Key).Open();

				if(nbook != null)
				{
					Utilities.SetProgramPIN(kvp.Key);
					foreach (Entry e in nbook.Entries)
					{ foreach(var v2 in allLabels.Intersect(e.Labels.Split(',')).ToList()) { lstReturn.Remove(v2); } }
				}
			}
			return lstReturn;
		}

		public static List<string> FindNewLabelsInOneSelectedJournal(Notebook journalToSearch = null, string journalName = "")
		{
			List<string> lstRtrn = new List<string>();

			if(journalToSearch == null && journalName != string.Empty) { journalToSearch = new Notebook(journalName).Open(); }

			foreach(Entry nbEntry in journalToSearch.Entries)
			{
				var sLabels = nbEntry.Labels;

				if(sLabels.Length > 0)
				{
					lstRtrn.AddRange(sLabels.Split(",").Except(GetLabels_NoFileDate()).ToList());
				}
			}

			return lstRtrn;
		}

		public static DateTime GetLabelsFileDate(string[] labels) 
		{ 
			DateTime dt = DateTime.MinValue;
			DateTime.TryParse(labels.Last(), out dt);
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

		public static List<Notebook> NotebooksContainingLabel(string labelName, bool returnIfTwoFound = false)
		{
			List<Notebook> lstRtrn = new List<Notebook>();
			List<Notebook> jrnls2Search = Program.AllNotebooks.Where(e => Program.DictCheckedNotebooks.ContainsKey(e.Name)).ToList();

			foreach (Notebook journal in jrnls2Search)
			{
				Utilities.SetProgramPIN(journal.Name);

				if (journal.Entries.Where(t => ("," + t.Labels + ",").Contains("," + labelName + ",")).ToList().Count > 0)
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

		public static async Task RenameLabel(string oldLabelName, string newLabelName, List<Notebook> notebooksToEdit, Dictionary<string, string> jrnlsAndPINs, Form parent)
		{
			foreach(Notebook j in notebooksToEdit)
			{
				Utilities.SetProgramPIN(j.Name);
				await j.RenameLabel(oldLabelName, newLabelName);
			}
		}

		public static async Task<bool> SaveLabels(List<string> labels = null)
		{
			var bRtrn = false;
			if(labels == null) { labels = GetLabels_NoFileDate().ToList(); }

			try
			{
				StringBuilder sb = new StringBuilder();
				CloudSynchronizer cs = new CloudSynchronizer();
				foreach (string label in labels) { sb.AppendLine(label); }
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
