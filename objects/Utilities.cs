/* Utility functions.
 * 7/9/22
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using myJournal.subforms;

namespace myJournal.objects
{
	public static class Utilities
	{
		public static List<string> AllJournalNames()
		{
			List<string> lstRtrn = new List<string>();
			foreach(Journal j in Program.AllJournals) { lstRtrn.Add(j.Name); }
			return lstRtrn;
		} 

		public static List<Journal> AllJournals()
		{
			List<Journal> jrnlReturn = new List<Journal>();
			//string sJrnlDiskName;
			//Journal j;
			string sJrnlFolder = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"];

			foreach (string s in Directory.GetFiles(sJrnlFolder))
			{
				//sJrnlDiskName = s.Replace(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"], "");
				//j = new Journal(sJrnlDiskName).Open();
				//j.AllowCloud = true;
				//j.DownloadIfNotFoundLocally = true;
				//j.UploadIfNotFoundInCloud = false;
				//j.Save();
				//jrnlReturn.Add(j);
				jrnlReturn.Add(new Journal(s.Replace(sJrnlFolder, "")).Open());
			}

			return jrnlReturn;
		}

		public static void PopulateEntries(ListBox lbxToPopulate, List<JournalEntry> entries, string startDate = "", string endDate = "", bool clearPrevious = true, int SortBy = 0)
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
				for(int i = 0; i < je.Synopsis.Length; i++) 
				{ 
					lbxToPopulate.Items.Add(je.Synopsis[i]);
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

		public static void SetStartPosition(Form formToInitialize, Form parentForm)
		{ 
			formToInitialize.StartPosition = FormStartPosition.Manual;	
			formToInitialize.Location = new System.Drawing.Point(parentForm.Location.X + 25, parentForm.Location.Y + 25); 
		}
	}
}