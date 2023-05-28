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

namespace myJournal
{
	[Serializable]
    public class JournalEntry
    {
        public DateTime Date;
		public DateTime LastEditedOn;
        public string Text;
		public string[] Synopsis{ get { return GetSynopsis(); } }
		public string DisplayText { get { return GetTextDisplayText(); } set { DisplayText = value; } }

		private string RTF;
        private string Labels;
		public string Title;
		public bool isEdited = false;
        public string Id;

		public JournalEntry() { }

		public JournalEntry(string _title, string _text, string _RTF, string _labels, bool _edited = false)
        {
			Date	= DateTime.Now;
			Text	= EncryptDecrypt.Encrypt(_text);
            Title	= EncryptDecrypt.Encrypt(_title);
			RTF		= EncryptDecrypt.Encrypt(_RTF);
            Labels	= EncryptDecrypt.Encrypt(_labels);
            Id		= Guid.NewGuid().ToString();
			isEdited = _edited;	
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

		string[] GetSynopsis()
		{
			string[] sRtrn = new string[4];
			int iTextChunkLength = 150;
			sRtrn[0] = ClearTitle() + " (" + Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")"
				+ (LastEditedOn < new DateTime(2000, 1, 1) ? "" : " [edited on " + LastEditedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + "]");
			string sEntryText = ClearText();
			sEntryText = (sEntryText.Length < iTextChunkLength ? sEntryText : sEntryText.Substring(0, iTextChunkLength) + " ...");
			sRtrn[1] = sEntryText;
			sRtrn[2] = "labels: " + ClearLabels().Replace(",", ", ");
			sRtrn[3] = "---------------------";
			return sRtrn;
		}

		public void Replace(JournalEntry newEntry)
		{
			Labels = newEntry.Labels;
			Text = newEntry.Text;
			Title = newEntry.Title;
		}

		public bool RemoveOrReplaceLabel(string newLabelName, string oldLabelName, bool renaming = true)
		{
			string labels = this.ClearLabels();
			bool bLabelEdited = false;

			if (labels.Length > 0)
			{
				List<string> arrLabels = labels.Split(',').ToList();
				int iLabelIndex = arrLabels.IndexOf(oldLabelName);

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

					string finalLabelsString = String.Join(",", arrLabels).Trim(',').Replace(",,", "");
					this.Labels = finalLabelsString.Length > 0 ? EncryptDecrypt.Encrypt(finalLabelsString) : string.Empty;
					bLabelEdited = true;
				}
			}
			return bLabelEdited;
		}

		public static JournalEntry Select(RichTextBox rtb, ListBox lb, Journal currentJournal, bool firstSelection = false, JournalEntry je = null)
		{
			rtb.Clear();
			List<int> targets = new List<int>();
			JournalEntry entryRtrn = null;

			if (je != null)
			{
				entryRtrn = je;

				for (var i = 0; i < lb.Items.Count; i++)
				{
					if (lb.Items[i].ToString().StartsWith(je.Synopsis[0].ToString()))
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

				if (lb.Items[ctr].ToString().StartsWith("--")) ctr--;

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

				var sTitleAndDate = lb.Items[ctr].ToString().Replace(" - EDITED", "");        // Use the title and date of the entry to create a JournalEntry object whose .ClearText will populate the display ...
				var sTitle = sTitleAndDate.Substring(0, sTitleAndDate.LastIndexOf('(') - 1);
				var sDate = sTitleAndDate.Substring(sTitleAndDate.LastIndexOf('(') + 1, sTitleAndDate.LastIndexOf(')') - sTitleAndDate.LastIndexOf('(') - 1);

				entryRtrn = currentJournal.GetEntry(sTitle, sDate);

				if (sTitle == "created")
				{
					lb.SelectedIndices.Clear();
					entryRtrn = null;
				}

				if (entryRtrn != null)
				{
					if (entryRtrn.DisplayText != null)    // entries prior to 1.0.0.1 will not have .DisplayText
					{
						rtb.Text = entryRtrn.DisplayText;
					}
					else
					{
						rtb.Text = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
						, entryRtrn.ClearTitle(), entryRtrn.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]), entryRtrn.ClearLabels(), entryRtrn.ClearText());
					}

					if (rtb.Text.Length == 0) { lb.TopIndex = lb.Top + lb.Height < rtb.Top ? ctr : lb.TopIndex; }

					lb.Height = rtb.Text.Length > 0 ? rtb.Top - 132 : 100;

					if (firstSelection)
					{
						lb.TopIndex = lb.Top + lb.Height < rtb.Top ? ctr : lb.TopIndex;
					}
				}

				rtb.Visible = rtb.Text.Length > 0;
			}

			return entryRtrn;
		}

		public string ClearText()	{ return EncryptDecrypt.Decrypt(Text); }
		public string ClearTitle()	{ return EncryptDecrypt.Decrypt(Title); }
		public string ClearRTF()	{ return EncryptDecrypt.Decrypt(RTF); }
		public string ClearLabels()	{ return Labels == null ? String.Empty : EncryptDecrypt.Decrypt(Labels); }
	}
}
