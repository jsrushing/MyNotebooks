using System;
using System.Collections.Generic;
using System.Text;

namespace myJournal
{
    [Serializable]
    public class JournalEntries
    {
        public List<JournalEntry> Entries = new List<JournalEntry>();

        public JournalEntries() { }

        public void Add(JournalEntry entry)
        {
            Entries.Add(entry);
        }
    }
}
