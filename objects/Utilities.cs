/* Utility functions.
 * 7/9/22
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using myNotebooks.subforms;

namespace myNotebooks.objects
{
	public static class Utilities
	{
		public static async Task PopulateAllNotebookNames()
		{
			List<string> lstRtrn = new List<string>();
			Program.AllNotebookNames.Clear();
			//await Utilities.PopulateAllNotebooks();
			foreach (Notebook nb in Program.AllNotebooks)if(nb != null) Program.AllNotebookNames.Add(nb.Name);
			//return lstRtrn;
		} 

		public static async Task PopulateAllNotebooks()
		{
			List<Notebook> nbReturn = new List<Notebook>();
			var sNotebooksFolder = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"];
			Program.AllNotebooks.Clear();
			foreach (var s in Directory.GetFiles(sNotebooksFolder)) { Program.AllNotebooks.Add(new Notebook(s.Replace(sNotebooksFolder, "")).Open()); }
			await PopulateAllNotebookNames();
		}

		// one-time code to convert Journal objects to Notebook objects
		//public static List<Journal> AllJournals()
		//{
		//	List<Journal> jrnlReturn = new List<Journal>();
		//	var sJournalsFolder = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"];
		//	foreach (var s in Directory.GetFiles(sJournalsFolder)) { jrnlReturn.Add(new Journal(s.Replace(sJournalsFolder, "")).Open()); }  // (new Journal(s.Replace(sJournalsFolder, "")).Open()); }
		//	return jrnlReturn;
		//}

		public static List<Notebook> CheckedNotebooks()
		{
			List<Notebook> rtrn = new List<Notebook>();

			foreach(KeyValuePair<string, string> kvp in Program.DictCheckedNotebooks)
			{ rtrn.Add(new Notebook(kvp.Key).Open()); }

			return rtrn;
		}

		public static string[] GetTitleAndDate(string searchString, int startPosition = 0)
		{
			var result = new string[2];

			try
			{
				var paren1 = searchString.LastIndexOf("(") + 1;
				var paren2 = searchString.LastIndexOf(')');

				if (paren2 - paren1 == 17)
				{
					DateTime.TryParse(searchString.Substring(paren1, paren2 - paren1), out DateTime tryDate);

					if (tryDate > DateTime.MinValue)
					{
						result[0] = searchString.Substring(0, paren1 - 1).Trim();
						result[1] = tryDate.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]);
					}
				}
				else 
				{ 
					using(frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "There is a problem with this entry. The Date can not be found.", "")) { frm.ShowDialog(); }
				}
			}
			catch (Exception) { }

			return result;
		}

		public async static Task ImportNotebooks(Form parent)
		{
			OpenFileDialog ofd = new OpenFileDialog { Multiselect = true };
			//var filesCopied = false;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				var target = String.Empty;
				var nbName = string.Empty;
				var ok2copy = true;

				foreach (var fileName in ofd.FileNames)
				{
					nbName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
					target = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"] + nbName;

					if (File.Exists(target))
					{
						using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion,
							"The notebook '" + nbName + "' already exists. Do you want to ovewrwrite the notebook?", "", parent))
						{
							frm.ShowDialog(parent);
							ok2copy = frm.Result == frmMessage.ReturnResult.Yes;
						}
					}

					using (frmMessage frm2 = new frmMessage(frmMessage.OperationType.InputBox, "Enter the PIN for '" + nbName + "'.", "", parent))
					{
						frm2.ShowDialog();
						ok2copy = frm2.Result == frmMessage.ReturnResult.Ok;
						if (ok2copy) { Program.PIN = frm2.ResultText; }
					}

					if (ok2copy)
					{
						File.Copy(fileName, target, true);
						Program.DictCheckedNotebooks.Add(nbName, Program.PIN);
						Program.AllNotebooks.Add(new Notebook(nbName).Open());
						//filesCopied = true;
						List<string> newLabels = LabelsManager.FindNewLabelsInOneSelectedJournal(null, nbName);

						if (newLabels.Count > 0)
						{
							var lbls = string.Join(',', newLabels);

							using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "The following labels were found in the " +
								"imported notebook but are not in your main labels list." + Environment.NewLine + lbls + Environment.NewLine + 
								"Do you want to add themt?", "New Labels Found", parent))
							{
								frm.ShowDialog();
								if (frm.Result == frmMessage.ReturnResult.Yes) { await LabelsManager.AddLabel(newLabels.ToArray()); }
							}
						}
					}

					ok2copy = true;
				}	
			}
			//return filesCopied;
		}

		public static async Task PopulateEntries(ListBox lbxToPopulate, List<Entry> entries, string journalName = "", string startDate = "", 
			string endDate = "", bool clearPrevious = true, int SortBy = 0, bool includeJrnlName = false, int maxWidth = 0)
		{
			if(clearPrevious) lbxToPopulate.Items.Clear();
			List<Entry> tmpEntries = null;
			tmpEntries = startDate.Length > 0 ? entries.Where(d => DateTime.Parse(d.Date.ToShortDateString()) >= DateTime.Parse(startDate)).ToList() : entries;
			tmpEntries = endDate.Length > 0 ? tmpEntries.Where(d => DateTime.Parse(d.Date.ToShortDateString()) <= DateTime.Parse(endDate)).ToList() : tmpEntries;

			switch (SortBy)
			{
				case 0: 
					tmpEntries.Sort((x, y) => -x.Date.CompareTo(y.Date));
					break;
				case 1:
					tmpEntries.Sort((x, y) => -x.LastEditedOn.CompareTo(y.LastEditedOn));
					break;
				case 2:
					tmpEntries.Sort((x, y) => x.ClearTitle().CompareTo(y.ClearTitle()));
					break;
			}

			foreach (Entry je in tmpEntries)
			{
				var synopsis = je.GetSynopsis(includeJrnlName, maxWidth);

				for(int i = 0; i < synopsis.Length; i++) 
				{ 
					lbxToPopulate.Items.Add(synopsis[i]);
				} 
			}
		}

		public static void ResizeListsAndRTBs(ListBox entriesList, RichTextBox entryRTB, Label seperatorLabel, Label typeLabel, Form callingForm)
		{
			int iBoxCenter = entriesList.Width / 2;
			seperatorLabel.Visible = true;
			entryRTB.Visible = true;
			seperatorLabel.Left = entriesList.Left + 10;
			seperatorLabel.Width = entriesList.Width - 20;
			entriesList.Height = seperatorLabel.Top - entriesList.Top;
			typeLabel.Top = seperatorLabel.Top + seperatorLabel.Height;
			entryRTB.Top = typeLabel.Top + typeLabel.Height;
			entryRTB.Height = callingForm.Height - entryRTB.Top - 50;
		}

		public static void SetProgramPIN(string j)
		{
			Program.PIN = Program.DictCheckedNotebooks[j] == "" ? "" : Program.DictCheckedNotebooks[j];
		}

		public static void SetStartPosition(Form formToInitialize, Form parentForm)
		{ 
			formToInitialize.StartPosition = FormStartPosition.Manual;	
			formToInitialize.Location = new System.Drawing.Point(parentForm.Location.X + 25, parentForm.Location.Y + 25); 
		}
	}
}