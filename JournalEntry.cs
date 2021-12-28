using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
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

        public string Id;

        public JournalEntry() { }

        public JournalEntry(string _title, string _text, string _tags)
        {
            this.Date = DateTime.Now;            
            this.Text = EncryptDecrypt.Encrypt(_text, "", "");
            this.Title = EncryptDecrypt.Encrypt(_title, "", "");
            this.Tags = EncryptDecrypt.Encrypt(_tags, "", "");
        }

        public string ClearText() { return EncryptDecrypt.Decrypt(this.Text, "", ""); }
        public string ClearTitle() { return EncryptDecrypt.Decrypt(this.Title, "", ""); }
        public string ClearTags() { return this.Tags == null ? String.Empty : EncryptDecrypt.Decrypt(this.Tags, "", ""); }
    }
}
