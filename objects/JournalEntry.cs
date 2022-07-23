/* Journal Entry object
 * 8/1//21
 */
using System;
using System.Configuration;
using encrypt_decrypt_string;
using System.Collections.Generic;
using myJournal.subforms;

namespace myJournal
{
	[Serializable]
    public class JournalEntry
    {
        public DateTime Date;
        string Text;
		public string DisplayText;
        string Title;
		string RTF;
        string Labels;
		public bool isEdited = false;
        public string Id;

		public JournalEntry() { }

		public JournalEntry(string _title, string _text, string _RTF, string _labels, bool _edited = false)
        {
			this.Date	= DateTime.Now;
			this.Text	= EncryptDecrypt.Encrypt(_text);
            this.Title	= EncryptDecrypt.Encrypt(_title);
			this.RTF	= EncryptDecrypt.Encrypt(_RTF);
            this.Labels	= EncryptDecrypt.Encrypt(_labels);
            this.Id		= Guid.NewGuid().ToString();
			this.isEdited = _edited;

			this.DisplayText = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
						, this.ClearTitle(), this.Date
						, this.ClearTags()
						, this.ClearText());
		}

		public List<string> ShortDisplayText(int ListboxWidth)
		{
			List<string> lstRtrn = new List<string>();
			
			if(this.ClearTitle().Length > 0)
			{
				int iTextChunkLength = Convert.ToInt16(ListboxWidth * .165);
				lstRtrn.Add(this.ClearTitle() + " (" + this.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")");
				string sEntryText = this.ClearText();
				lstRtrn.Add(sEntryText.Length < iTextChunkLength ? sEntryText : sEntryText.Substring(0, iTextChunkLength) + " ...");
				lstRtrn.Add("labels: " + this.ClearTags());
				lstRtrn.Add("---------------------");
			}
			return lstRtrn;
		}

		public void Replace(JournalEntry newEntry)
		{
			this.Labels = newEntry.Labels;
			this.Text = newEntry.Text;
			this.Title = newEntry.Title;
		}

		public string ClearText()	{ return EncryptDecrypt.Decrypt(this.Text); }
		public string ClearTitle()	{ return EncryptDecrypt.Decrypt(this.Title); }
		public string ClearRTF()	{ return EncryptDecrypt.Decrypt(this.RTF); }
		public string ClearTags()	{ return this.Labels == null ? String.Empty : EncryptDecrypt.Decrypt(this.Labels); }
	}
}
