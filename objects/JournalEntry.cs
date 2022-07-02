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
		public JournalEntry() { }

		public JournalEntry(string _title, string _text, string _tags, string _PIN, bool _edited = false)
        {
            this.Date	= DateTime.Now;
			string key	= ConfigurationManager.AppSettings["PrivateKey"];
			this.PIN	= _PIN;	// EncryptDecrypt.Encrypt(_PIN, _PIN, key);
			this.Text	= EncryptDecrypt.Encrypt(_text, _PIN, key);
            this.Title	= EncryptDecrypt.Encrypt(_title, _PIN, key);
            this.Tags	= EncryptDecrypt.Encrypt(_tags, _PIN, key);
            this.Id		= Guid.NewGuid().ToString();
			this.isEdited = _edited;
		}

		public void ChangePIN(string newPIN)
		{

		}

		public string ClearText(string _pin = null) { _pin = this.PIN == string.Empty ? null : this.PIN; return EncryptDecrypt.Decrypt(this.Text, _pin, ConfigurationManager.AppSettings["PrivateKey"]); }
		public string ClearTitle(string _pin = null) { _pin = this.PIN == string.Empty ? null : this.PIN; return EncryptDecrypt.Decrypt(this.Title, _pin, ConfigurationManager.AppSettings["PrivateKey"]); }
		public string ClearTags(string _pin = null) { _pin = this.PIN == string.Empty ? null : this.PIN; return this.Tags == null ? String.Empty : EncryptDecrypt.Decrypt(this.Tags, _pin, ConfigurationManager.AppSettings["PrivateKey"]); }
		public string ClearPIN(string _pin = null) { _pin = this.PIN == string.Empty ? null : this.PIN; return this.Tags == null ? String.Empty : EncryptDecrypt.Decrypt(this.PIN, _pin, ConfigurationManager.AppSettings["PrivateKey"]); }
	}
}
