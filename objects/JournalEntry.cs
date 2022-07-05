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
        string Title;
        string Tags;
		public bool isEdited = false;
        public string Id;

		public JournalEntry(string _title, string _text, string _tags, bool _edited = false)
        {
			this.Date	= DateTime.Now;
			string key	= ConfigurationManager.AppSettings["PrivateKey"];
			this.Text	= EncryptDecrypt.Encrypt(_text, Program.PIN, key);
            this.Title	= EncryptDecrypt.Encrypt(_title, Program.PIN, key);
            this.Tags	= EncryptDecrypt.Encrypt(_tags, Program.PIN, key);
            this.Id		= Guid.NewGuid().ToString();
			this.isEdited = _edited;
		}

		public List<string> EntryAsList(int ListboxWidth)
		{
			List<string> lstRtrn = new List<string>();
			
			if(this.ClearTitle().Length > 0)
			{
				int iTextChunkLength = Convert.ToInt16(ListboxWidth * .15);

				lstRtrn.Add(this.ClearTitle() + " (" + this.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")"); //+ (je.isEdited ? " - EDITED" : ""));
				string sEntryText = this.ClearText();

				lstRtrn.Add(sEntryText.Length < iTextChunkLength ?
					sEntryText :
					sEntryText.Substring(0, iTextChunkLength) + " ...");

				lstRtrn.Add("tags: " + this.ClearTags());
				lstRtrn.Add("---------------------");
			}
			return lstRtrn;
		}

		public void Replace(JournalEntry newEntry)
		{
			this.Tags = newEntry.Tags;
			this.Text = newEntry.Text;
			this.Title = newEntry.Title;
		}

		public string ClearText(){ return EncryptDecrypt.Decrypt(this.Text, Program.PIN, ConfigurationManager.AppSettings["PrivateKey"]); }
		public string ClearTitle() { return EncryptDecrypt.Decrypt(this.Title, Program.PIN, ConfigurationManager.AppSettings["PrivateKey"]); }
		public string ClearTags() { return this.Tags == null ? String.Empty : EncryptDecrypt.Decrypt(this.Tags, Program.PIN, ConfigurationManager.AppSettings["PrivateKey"]); }
	}
}
