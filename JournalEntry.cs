using System;
using System.Collections.Generic;
using System.Text;

namespace myJournal
{
    class JournalEntry
    {
        public DateTime Date;
        public string Text;
        public string Title;
        public int Index;

        public JournalEntry() { }

        public JournalEntry(DateTime _date, string _text, string _title, int _index)
        {
            this.Date = _date;
            this.Text = _text;
            this.Title = _title;
            this.Index = _index;
        }
    }
}
