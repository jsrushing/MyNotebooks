/* Journal Entry object
 * 8/1//21
 */
using System;
using System.Configuration;
using System.Linq;
using encrypt_decrypt_string;
using System.Collections.Generic;
using System.Text;
using myJournal.subforms;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using myJournal.objects;

namespace myJournal
{
	[Serializable]
    public class Entry
    {
        public DateTime		Date;
		public DateTime		LastEditedOn;
        public string		Text;
		public string		DisplayText { get { return GetTextDisplayText(); } set { DisplayText = value; } }
		public string		NotebookName { get; set; }

		private string[]	synopsis;
		private string		RTF;
        private string		Labels;
		public string		Title;
		public bool			isEdited = false;
        public string		Id;

		public Entry() { }

		public Entry(string _title, string _text, string _RTF, string _labels, string _NotebookName = "", bool _edited = false)
        {
			Date		= DateTime.Now;
			Text		= EncryptDecrypt.Encrypt(_text.Trim());
            Title		= EncryptDecrypt.Encrypt(_title.Trim());
			RTF			= EncryptDecrypt.Encrypt(_RTF);
            Labels		= EncryptDecrypt.Encrypt(_labels);
			NotebookName = EncryptDecrypt.Encrypt(_NotebookName);
            Id			= Guid.NewGuid().ToString();
			isEdited	= _edited;	
		}

		public string GetFirstOrLastEditDate(bool getFirst)
		{
			var sText = this.ClearText();
			var sTargetText = "> Original Date: ";
			var iStartDateString = -1;
			iStartDateString = getFirst ? sText.IndexOf(sTargetText) + sTargetText.Length : sText.LastIndexOf(sTargetText) + sTargetText.Length;
			return sText.Substring(iStartDateString, 8);
		}

		string GetTextDisplayText()
		{
			return String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
				, ClearTitle(), Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]), ClearLabels().Replace(",", ", "), ClearText());
		}

		public string[] GetSynopsis(bool includeJournalName = false, int maxWidth = -1)
		{
			string[] sRtrn = new string[4];
			int iTextChunkLength = maxWidth > 0 ? maxWidth / 5 : 150;
			string sTitle = ClearTitle() + " (" + Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")"
				+ (LastEditedOn < new DateTime(2000, 1, 1) ? "" : " [edited on " + LastEditedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + "]");
			if (includeJournalName) { sTitle += this.NotebookName == null ? "" : " > in '" + NotebookName + "'"; }
			sRtrn[0] = sTitle;
			string sEntryText = ClearText();
			sEntryText = (sEntryText.Length < iTextChunkLength ? sEntryText : sEntryText.Substring(0, iTextChunkLength) + " ...");
			sRtrn[1] = sEntryText;
			sRtrn[2] = "labels: " + ClearLabels().Replace(",", ", ");
			sRtrn[3] = "---------------------";
			return sRtrn;
		}

		public void Replace(Entry newEntry)
		{
			Labels = newEntry.Labels;
			Text = newEntry.Text;
			Title = newEntry.Title;
			NotebookName = newEntry.NotebookName;
		}

		public bool RemoveOrReplaceLabel(string newLabelName, string oldLabelName, bool renaming = true)
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
					this.Labels = finalLabelsString.Length > 0 ? EncryptDecrypt.Encrypt(finalLabelsString) : string.Empty;
					bLabelEdited = true;
				}
			}
			return bLabelEdited;
		}

		public static Entry Select(RichTextBox rtb, ListBox lb, Notebook currentJournal, bool firstSelection = false, Entry je = null)
		{
			rtb.Clear();
			List<int> targets = new List<int>();
			Entry entryRtrn = null;

			if (je != null)
			{
				entryRtrn = je;

				for (var i = 0; i < lb.Items.Count; i++)
				{
					if (lb.Items[i].ToString().StartsWith(je.GetSynopsis()[0].ToString()))
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
						for (int i = 0; i < lb.SelectedIndices.Count - 1; i++)
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
					foreach (int i in targets)
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

				if (titleAndDate[0].Length > 0 && titleAndDate[1].Length > 0)
				{
					var sTitle = titleAndDate[0];
					var sDate = titleAndDate[1];

					entryRtrn = currentJournal.GetEntry(sTitle, sDate);

					if (sTitle == "created")
					{
						lb.SelectedIndices.Clear();
						entryRtrn = null;
					}

					if (entryRtrn != null)
					{
						if (entryRtrn.DisplayText != null) { rtb.Text = entryRtrn.DisplayText; }
						else
						{
							rtb.Text = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
							, entryRtrn.ClearTitle(), entryRtrn.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]), entryRtrn.ClearLabels(), entryRtrn.ClearText());
						}

						if (rtb.Text.Length == 0) { lb.TopIndex = lb.Top + lb.Height < rtb.Top ? ctr : lb.TopIndex; }
						lb.Height = rtb.Text.Length > 0 ? rtb.Top - 132 : 100;
						if (firstSelection) { lb.TopIndex = lb.Top + lb.Height < rtb.Top ? ctr : lb.TopIndex; }
					}

					rtb.Visible = rtb.Text.Length > 0;
				}
			}
			return entryRtrn;
		}

		public string ClearText()	{ return EncryptDecrypt.Decrypt(Text); }
		public string ClearTitle()	{ return EncryptDecrypt.Decrypt(Title); }
		public string ClearRTF()	{ return EncryptDecrypt.Decrypt(RTF); }
		public string ClearLabels()	{ return Labels == null ? String.Empty : EncryptDecrypt.Decrypt(Labels); }

		public string ClearName() { return EncryptDecrypt.Decrypt(NotebookName); }
	}
}
