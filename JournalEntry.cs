using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using encrypt_decrypt_string;
using System.Configuration;

namespace myJournal
{
    [Serializable]
    public class JournalEntry
    {
        public DateTime Date;
        string Text;
        string Title;
        string Tags;
		public string PIN;
		public bool isEdited = false;
        public string Id;
		private string _clearText;
		private string _clearTitle;
		private string _clearTags;
		public JournalEntry() { }

		public JournalEntry(string _title, string _text, string _tags, string _PIN, bool _edited = false)
        {
            this.Date	= DateTime.Now;
			this.PIN	= _PIN;
			string key	= ConfigurationManager.AppSettings["PrivateKey"];
			this.Text	= EncryptDecrypt.Encrypt(_text, this.PIN, key);
            this.Title	= EncryptDecrypt.Encrypt(_title, this.PIN, key);
            this.Tags	= EncryptDecrypt.Encrypt(_tags, this.PIN, key);
            this.Id		= Guid.NewGuid().ToString();
			this.isEdited = _edited;

			this._clearText		= ClearText();
			this._clearTitle	= ClearTitle();
			this._clearTags		= ClearTags();
		}

		public string ClearText() { return EncryptDecrypt.Decrypt(this.Text, this.PIN, ConfigurationManager.AppSettings["PrivateKey"]); }
		public string ClearTitle() { return EncryptDecrypt.Decrypt(this.Title, this.PIN, ConfigurationManager.AppSettings["PrivateKey"]); }
		public string ClearTags() { return this.Tags == null ? String.Empty : EncryptDecrypt.Decrypt(this.Tags, this.PIN, ConfigurationManager.AppSettings["PrivateKey"]); }
	}
}
