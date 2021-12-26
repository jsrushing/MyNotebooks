using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
            this.Text = _text;
            this.Title = _title;
            this.Groups = _groups;
        }
    }
}
