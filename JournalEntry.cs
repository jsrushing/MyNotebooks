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
        public string Text;
        public string Title;
        public int Index;
        public string Groups;

        public JournalEntry() { }

        public JournalEntry(string _title, string _text, string _groups)
        {
            this.Date = DateTime.Now;            
            this.Text = EncryptDecrypt.Encrypt(_text, "", "");
            this.Title = EncryptDecrypt.Encrypt(_title, "", "");
            this.Groups = EncryptDecrypt.Encrypt(_groups, "", "");
        }
    }
}
