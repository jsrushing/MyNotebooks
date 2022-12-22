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

namespace myJournal
{
	[Serializable]
    public class JournalEntry
    {
        public DateTime Date;
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

		string GetTextDisplayText()
		{
			return String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
				, ClearTitle(), Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]), ClearLabels().Replace(",", ", "), ClearText());
		}

		string[] GetSynopsis()
		{
			string[] sRtrn = new string[4];
			int iTextChunkLength = 150;
			sRtrn[0] = ClearTitle() + " (" + Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")";
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

		public string ClearText()	{ return EncryptDecrypt.Decrypt(Text); }
		public string ClearTitle()	{ return EncryptDecrypt.Decrypt(Title); }
		public string ClearRTF()	{ return EncryptDecrypt.Decrypt(RTF); }
		public string ClearLabels()	{ return Labels == null ? String.Empty : EncryptDecrypt.Decrypt(Labels); }
	}
}
