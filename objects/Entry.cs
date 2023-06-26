/* Journal Entry object
 * 8/1//21
 * Refactored to Notebook Entry object
 * 06/10/23
 */
using System;
using System.Configuration;
using System.Linq;
using Encryption;
using System.Collections.Generic;
using System.Text;
using myNotebooks.subforms;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using myNotebooks.objects;
using myJournal;

namespace myNotebooks
{
	[Serializable]
    public class Entry
    {
        public DateTime		Date;
		public DateTime		LastEditedOn;
        public string		Text;
		public string		DisplayText { get { return GetTextDisplayText(); } set { DisplayText = value; } }
		public string		NotebookName { get; set; }
		public string		RTF;
        public string		Labels;
		public string		Title;
		public bool			isEdited = false;
        public string		Id;

		public Entry() { }

		// one-time code for converting Journal to Notebook.
		//public Entry(JournalEntry entry)
		//{
		//	this.Date = entry.Date;
		//	this.Text = entry.Text;
		//	this.Title = entry.Title;
		//	this.RTF = "";
		//	this.Labels = EncryptDecrypt.Encrypt(entry.ClearLabels());
		//	this.NotebookName = EncryptDecrypt.Encrypt("The New Real Thing");
		//	Id = Guid.NewGuid().ToString();
		//	isEdited = entry.isEdited;
		//}

		public Entry(string _title, string _text, string _RTF, string _labels, string _notebookName = "", bool _edited = false)
        {
			if(Date == DateTime.MinValue) { Date = DateTime.Now; }

			Text			= _text.Trim();		// EncryptDecrypt.Encrypt(_text.Trim());
			Title			= _title.Trim();	// EncryptDecrypt.Encrypt(_title.Trim());
			RTF				= _RTF;				//EncryptDecrypt.Encrypt(_RTF);
			Labels			= _labels;			// EncryptDecrypt.Encrypt(_labels);
			NotebookName	= _notebookName;	// EncryptDecrypt.Encrypt(_notebookName);
            Id				= Guid.NewGuid().ToString();
			isEdited		= _edited;	
		}

		string				GetTextDisplayText()
		{
			return String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
				, ClearTitle(), Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]), ClearLabels().Replace(",", ", "), ClearText());
		}

		public string[]		GetSynopsis(bool includeJournalName = false, int maxWidth = -1)
		{
			string[] sRtrn = new string[4];
			int iTextChunkLength = maxWidth > 0 ? maxWidth / 5 : 150;
			string sTitle = ClearTitle() + " (" + Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")"
				+ (LastEditedOn < new DateTime(2000, 1, 1) ? "" : " [edited on " + LastEditedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + "]");
			if (includeJournalName) { sTitle += this.NotebookName == null ? "" : " > in '" + this.ClearNotebookName() + "'"; }
			sRtrn[0] = sTitle;
			string sEntryText = ClearText().Replace("\n", " ");
			sEntryText = (sEntryText.Length < iTextChunkLength ? sEntryText : sEntryText.Substring(0, iTextChunkLength) + " ...");
			sRtrn[1] = sEntryText;
			sRtrn[2] = "labels: " + ClearLabels().Replace(",", ", ");
			sRtrn[3] = "---------------------";
			return sRtrn;
		}

		public bool			RemoveOrReplaceLabel(string newLabelName, string oldLabelName, bool renaming = true)
		{
			var labels = this.ClearLabels();
			var bLabelEdited = false;

			if (labels.Length > 0)
			{
				List<string> arrLabels = labels.Split(',').ToList();
				var iLabelIndex = arrLabels.IndexOf(oldLabelName);

				if (iLabelIndex > -1)
				{
					if (renaming)
					{
						arrLabels.RemoveAt(iLabelIndex);
						arrLabels.Insert(iLabelIndex, newLabelName);
					}
					else
					{
						arrLabels.RemoveAt(iLabelIndex);
					}

					var finalLabelsString = String.Join(",", arrLabels).Trim(',').Replace(",,", "");
					this.Labels = finalLabelsString.Length > 0 ? finalLabelsString : string.Empty;
					bLabelEdited = true;
				}
			}
			return bLabelEdited;
		}

		public static Entry Select(RichTextBox rtb, ListBox lb, Notebook currentNotebook, bool firstSelection = false, Entry je = null, bool resetTopIndex = true)
		{
			rtb.Clear();
			List<int> targets = new List<int>();
			Entry entryRtrn = null;

			if (je != null)
			{
				entryRtrn = je;

				for (var i = 0; i < lb.Items.Count; i++)
				{
					if (lb.Items[i].ToString().StartsWith(je.GetSynopsis(false)[0].ToString()))
					{
						lb.SelectedIndices.Add(i);
						lb.SelectedIndices.Add(i + 1);
						lb.SelectedIndices.Add(i + 2);
						rtb.Text = je.DisplayText;
						break;
					}
				}
			}
			else
			{
				try
				{
					if (lb.SelectedIndices.Count > 1)
					{
						for (var i = 0; i < lb.SelectedIndices.Count - 1; i++)
						{
							if (lb.SelectedIndices[i] == lb.SelectedIndices[i + 1] - 1)
							{
								targets.Add(lb.SelectedIndices[i]);
								targets.Add(lb.SelectedIndices[i + 1]);
								targets.Add(lb.SelectedIndices[i + 2]);
								break;
							}
						}
					}
				}
				catch (Exception) { }

				if (targets.Count == 3)
				{
					foreach (var i in targets)
					{
						lb.SelectedIndices.Remove(i);
					}
				}

				var ctr = lb.SelectedIndex;

				if (lb.Items[ctr].ToString().StartsWith("--")) { ctr--; }

				while (!lb.Items[ctr].ToString().StartsWith("--") & ctr > 0)
				{
					ctr--;
					if (ctr < 0) break;
				}

				if (ctr > 0) { ctr += 1; }
				lb.SelectedIndices.Clear();                             // Select the whole short entry ...
				lb.SelectedIndices.Add(ctr);
				lb.SelectedIndices.Add(ctr + 1);
				lb.SelectedIndices.Add(ctr + 2);                        //

				var sTitleAndDate = lb.Items[ctr].ToString().Replace(" - EDITED", "");        // Use the title and date of the entry to create a JournalEntry object whose .ClearText will populate the display

				string[] titleAndDate = Utilities.GetTitleAndDate(sTitleAndDate);

				if (titleAndDate[0] != null && titleAndDate[1] != null)
				{
					DateTime.TryParse(titleAndDate[1], out DateTime dt);
					entryRtrn = currentNotebook.GetEntry(titleAndDate[0], titleAndDate[1]);

					if (titleAndDate[0] == "created")
					{
						lb.SelectedIndices.Clear();
					}
					else
					{
						if (entryRtrn != null && entryRtrn.DisplayText != null) { rtb.Text = entryRtrn.DisplayText; }
						else
						{
							if(entryRtrn != null)
							{
								rtb.Text = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
								, entryRtrn.ClearTitle(), entryRtrn.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]), entryRtrn.ClearLabels(), entryRtrn.ClearText());
							}
						}

						if (resetTopIndex) { if (rtb.Text.Length == 0) { lb.TopIndex = lb.Top + lb.Height < rtb.Top ? ctr : lb.TopIndex; } }
						lb.Height = rtb.Text.Length > 0 ? rtb.Top - 132 : 100;
						if (firstSelection) { lb.TopIndex = lb.Top + lb.Height < rtb.Top ? ctr : lb.TopIndex; }
					}

					rtb.Visible = rtb.Text.Length > 0;
				}
			}
			return entryRtrn;
		}

		public string ClearTitle() { return Title; }
		public string ClearText() { return Text; }  //// EncryptDecrypt.Decrypt(Title); }
		public string ClearRTF() { return RTF; }// EncryptDecrypt.Decrypt(RTF); }
		public string ClearLabels() { return Labels == null ? "" : Labels; }
		public string ClearNotebookName() { return NotebookName; }	// return EncryptDecrypt.Decrypt(NotebookName); }

	}
}
