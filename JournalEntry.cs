/* Journal Entry object
 * 8/1//21
 */
using System;
using System.Configuration;
using encrypt_decrypt_string;

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

		public void ChangePIN(string newPIN)
		{

		}

		public string ClearText(string _pin = null) { _pin = this.PIN == string.Empty ? null : this.PIN; return EncryptDecrypt.Decrypt(this.Text, _pin, ConfigurationManager.AppSettings["PrivateKey"]); }
		public string ClearTitle(string _pin = null) { _pin = this.PIN == string.Empty ? null : this.PIN; return EncryptDecrypt.Decrypt(this.Title, _pin, ConfigurationManager.AppSettings["PrivateKey"]); }
		public string ClearTags(string _pin = null) { _pin = this.PIN == string.Empty ? null : this.PIN; return this.Tags == null ? String.Empty : EncryptDecrypt.Decrypt(this.Tags, _pin, ConfigurationManager.AppSettings["PrivateKey"]); }
	}
}
