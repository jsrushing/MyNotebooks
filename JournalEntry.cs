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

        public JournalEntry() { }

		public JournalEntry(string _title, string _text, string _tags, string _PIN, bool _edited = false)
        {
            this.Date = DateTime.Now;
			this.PIN = _PIN;
			string key = ConfigurationManager.AppSettings["PrivateKey"];
			this.Text = EncryptDecrypt.Encrypt(_text, _PIN, key);
            this.Title = EncryptDecrypt.Encrypt(_title, _PIN, key);
            this.Tags = EncryptDecrypt.Encrypt(_tags, _PIN, key);
            this.Id = Guid.NewGuid().ToString();
			this.isEdited = _edited;
        }

        public string ClearText(string _pin) { return EncryptDecrypt.Decrypt(this.Text, _pin, ConfigurationManager.AppSettings["PrivateKey"]); }
        public string ClearTitle(string _pin) { return EncryptDecrypt.Decrypt(this.Title, _pin, ConfigurationManager.AppSettings["PrivateKey"]); }
        public string ClearTags(string _pin = null) { return this.Tags == null ? String.Empty : EncryptDecrypt.Decrypt(this.Tags, _pin, ConfigurationManager.AppSettings["PrivateKey"]); }
    }
}
