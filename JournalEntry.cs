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

        public JournalEntry() { }

        public JournalEntry(string _title, string _text)
        {
            this.Date = DateTime.Now;
            this.Text = _text;
            this.Title = _title;
        }

        private string CompileEntry()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("*|*" + this.Date.ToLongDateString() + "_" + this.Date.ToLongTimeString() + System.Environment.NewLine);
            sb.Append("|*|" + this.Title + System.Environment.NewLine);
            sb.Append("|||" + this.Text);
            return sb.ToString();
        }

        public string GetEntry() { return CompileEntry(); }
    }
}
