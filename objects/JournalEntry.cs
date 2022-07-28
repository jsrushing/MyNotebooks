/* Journal Entry object
 * 8/1//21
 */
using System;
using System.Configuration;
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
		public string DisplayTitle { get { return GetTitleDisplayText(); } }
		public string DisplayText { get { return GetTextDisplayText(); } set { DisplayText = value; } }


		public string Title;
		string RTF;
        string Labels;
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
				, ClearTitle(), Date, ClearTags(), ClearText());
		}

		string GetTitleDisplayText()
		{
			StringBuilder sb = new StringBuilder();

			return sb.ToString();
		}

		string[] GetSynopsis()
		{
			string[] sRtrn = new string[4];
			int iTextChunkLength = 150;

			sRtrn[0] = ClearTitle() + " (" + Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")";
			string sEntryText = ClearText();
			sEntryText = (sEntryText.Length < iTextChunkLength ? sEntryText : sEntryText.Substring(0, iTextChunkLength) + " ...");
			sRtrn[1] = sEntryText;
			sRtrn[2] = "labels: " + ClearTags();
			sRtrn[3] = "---------------------";
			return sRtrn;
		}

		public void Replace(JournalEntry newEntry)
		{
			Labels = newEntry.Labels;
			Text = newEntry.Text;
			Title = newEntry.Title;
		}

		public void UpdateTo1001()
		{
			DisplayText = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
				, ClearTitle(), Date, ClearTags(), ClearText());
		}

		public string ClearText()	{ return EncryptDecrypt.Decrypt(Text); }
		public string ClearTitle()	{ return EncryptDecrypt.Decrypt(Title); }
		public string ClearRTF()	{ return EncryptDecrypt.Decrypt(RTF); }
		public string ClearTags()	{ return Labels == null ? String.Empty : EncryptDecrypt.Decrypt(Labels); }
	}
}
