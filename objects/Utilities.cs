/* Utility functions.
 * 7/9/22
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace myJournal.objects
{
	public static class Utilities
	{
		public static List<string> AllJournalNames()
		{
			List<string> lstRtrn = new List<string>();
			foreach (Journal j in Program.AllJournals) lstRtrn.Add(j.Name);
			return lstRtrn;
		} 

		public static List<Journal> AllJournals()
		{
			List<Journal> jrnlReturn = new List<Journal>();
			var sJrnlFolder = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"];
			foreach (var s in Directory.GetFiles(sJrnlFolder)) { jrnlReturn.Add(new Journal(s.Replace(sJrnlFolder, "")).Open()); }
			return jrnlReturn;
		}

		public static string[] GetTitleAndDate(string searchString, int startPosition = 0)
		{
			var result = new string[2];

			try
			{
				var paren1 = -1;
				var paren2 = -1;

				if (searchString.Contains('('))
				{
					paren1 = searchString.IndexOf('(', startPosition) + 1;
					paren2 = searchString.IndexOf(")", startPosition + 1);

					//var test = searchString.Substring(paren1, paren2 - paren1);

					if (paren2 - paren1 == 17)
					{
						DateTime.TryParse(searchString.Substring(paren1, paren2 - paren1), out DateTime tryDate);

						if (tryDate > DateTime.MinValue)
						{
							result[0] = searchString.Substring(0, paren1 - 1).Trim();
							result[1] = tryDate.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]);
						}
						else
						{
							result = GetTitleAndDate(searchString, paren2);
						}
					}
					else { result = GetTitleAndDate(searchString, paren2); }
				}
			}
			catch (Exception) { }

			return result;
		}

		public static void PopulateEntries(ListBox lbxToPopulate, List<JournalEntry> entries, string journalName = "", string startDate = "", string endDate = "", bool clearPrevious = true, int SortBy = 0, bool includeJrnlName = false)
		{
			if(clearPrevious) lbxToPopulate.Items.Clear();
			List<JournalEntry> tmpEntries = null;
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

			foreach (JournalEntry je in tmpEntries)
			{
				var synopsis = je.GetSynopsis(includeJrnlName);

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
			Program.PIN = Program.DictCheckedJournals[j] == "" ? "" : Program.DictCheckedJournals[j];
		}

		public static void SetStartPosition(Form formToInitialize, Form parentForm)
		{ 
			formToInitialize.StartPosition = FormStartPosition.Manual;	
			formToInitialize.Location = new System.Drawing.Point(parentForm.Location.X + 25, parentForm.Location.Y + 25); 
		}
	}
}