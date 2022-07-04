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
		private string PIN;
		public bool isEdited = false;
        public string Id;

		public JournalEntry() { }

		public JournalEntry(string _title, string _text, string _tags, string _PIN, bool _edited = false)
        {
			frmMain frm = new frmMain();
			
            this.Date	= DateTime.Now;
			string key	= ConfigurationManager.AppSettings["PrivateKey"];
			this.PIN	= frm.GetPin();	//  _PIN;	// EncryptDecrypt.Encrypt(_PIN, _PIN, key);
			this.Text	= EncryptDecrypt.Encrypt(_text, _PIN, key);
            this.Title	= EncryptDecrypt.Encrypt(_title, _PIN, key);
            this.Tags	= EncryptDecrypt.Encrypt(_tags, _PIN, key);
            this.Id		= Guid.NewGuid().ToString();
			this.isEdited = _edited;
		}

		public List<string> EntryAsList(int ListboxWidth)
		{
			List<string> lstRtrn = new List<string>();
			int iTextChunkLength = Convert.ToInt16(ListboxWidth * .15);

			lstRtrn.Add(this.ClearTitle(this.PIN) + " (" + this.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")"); //+ (je.isEdited ? " - EDITED" : ""));
			string sEntryText = this.ClearText(this.PIN);

			lstRtrn.Add(sEntryText.Length < iTextChunkLength ?
				sEntryText :
				sEntryText.Substring(0, iTextChunkLength) + " ...");

			lstRtrn.Add("tags: " + this.ClearTags(this.PIN));
			lstRtrn.Add("---------------------");
			return lstRtrn;
		}

		public void ChangePIN(string newPIN)
		{

		}

		//public string ClearText(string _pin = null) { _pin = this.PIN == string.Empty ? null : this.PIN; return EncryptDecrypt.Decrypt(this.Text, _pin, ConfigurationManager.AppSettings["PrivateKey"]); }
		//public string ClearTitle(string _pin = null) { _pin = this.PIN == string.Empty ? null : this.PIN; return EncryptDecrypt.Decrypt(this.Title, _pin, ConfigurationManager.AppSettings["PrivateKey"]); }
		//public string ClearTags(string _pin = null) { _pin = this.PIN == string.Empty ? null : this.PIN; return this.Tags == null ? String.Empty : EncryptDecrypt.Decrypt(this.Tags, _pin, ConfigurationManager.AppSettings["PrivateKey"]); }
		//public string ClearPIN(string _pin = null) { _pin = this.PIN == string.Empty ? null : this.PIN; return this.Tags == null ? String.Empty : EncryptDecrypt.Decrypt(this.PIN, _pin, ConfigurationManager.AppSettings["PrivateKey"]); }
		public string ClearText( string i = "" ){ return EncryptDecrypt.Decrypt(this.Text, Program.PIN, ConfigurationManager.AppSettings["PrivateKey"]); }
		public string ClearTitle(string i = "") { return EncryptDecrypt.Decrypt(this.Title, Program.PIN, ConfigurationManager.AppSettings["PrivateKey"]); }
		public string ClearTags(string i = "") { return this.Tags == null ? String.Empty : EncryptDecrypt.Decrypt(this.Tags, Program.PIN, ConfigurationManager.AppSettings["PrivateKey"]); }

	}
}
