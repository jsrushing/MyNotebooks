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
				, ClearTitle(), Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]), ClearTags().Replace(",", ", "), ClearText());
		}

		string[] GetSynopsis()
		{
			string[] sRtrn = new string[4];
			int iTextChunkLength = 150;
			sRtrn[0] = ClearTitle() + " (" + Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")";
			string sEntryText = ClearText();
			sEntryText = (sEntryText.Length < iTextChunkLength ? sEntryText : sEntryText.Substring(0, iTextChunkLength) + " ...");
			sRtrn[1] = sEntryText;
			sRtrn[2] = "labels: " + ClearTags().Replace(",", ", ");
			sRtrn[3] = "---------------------";
			return sRtrn;
		}

		public void Replace(JournalEntry newEntry)
		{
			Labels = newEntry.Labels;
			Text = newEntry.Text;
			Title = newEntry.Title;
		}

		public bool RemoveOrReplaceTag(string newTagName, string oldTagName, bool renaming = true)
		{
			string tags = this.ClearTags();
			bool bTagEdited = false;

			if (tags.Length > 0)
			{
				List<string> arrTags = tags.Split(',').ToList();
				int iTagIndex = arrTags.IndexOf(oldTagName);	// Array.IndexOf(arrTags, oldTagName);

				if (iTagIndex > -1)
				{
					if (renaming)
					{
						arrTags.RemoveAt(iTagIndex);
						arrTags.Insert(iTagIndex, newTagName);
					}
					else
					{
						arrTags.RemoveAt(iTagIndex);
					}

					string finalTagsString = String.Join(",", arrTags).Trim(',').Replace(",,", "");
					this.Labels = finalTagsString.Length > 0 ? EncryptDecrypt.Encrypt(finalTagsString) : string.Empty;
					bTagEdited = true;
				}
			}
			return bTagEdited;
		}

		public string ClearText()	{ return EncryptDecrypt.Decrypt(Text); }
		public string ClearTitle()	{ return EncryptDecrypt.Decrypt(Title); }
		public string ClearRTF()	{ return EncryptDecrypt.Decrypt(RTF); }
		public string ClearTags()	{ return Labels == null ? String.Empty : EncryptDecrypt.Decrypt(Labels); }
	}
}
