using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace myJournal
{
    class JournalEntry
    {
        public DateTime Date;
        public string Text;
        public string Title;
        public int Index;
        public string Entry;

        public JournalEntry() { }

        public JournalEntry(string _title, string _text)
        {
            this.Date = DateTime.Now;
            this.Text = _text;
            this.Title = _title;
            CompileEntry();
        }

        private void CompileEntry()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("*|*" + this.Date.ToLongDateString() + "_" + this.Date.ToLongTimeString() + System.Environment.NewLine);
            sb.Append("|*|" + this.Title + System.Environment.NewLine);
            sb.Append("|||" + this.Text);
            this.Entry = sb.ToString();
        }

        public string GetEntry() { return this.Entry; }
    }
}
