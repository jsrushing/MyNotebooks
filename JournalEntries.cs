using System;
using System.Collections.Generic;
using System.Text;

namespace myJournal
{
    [Serializable]
    class JournalEntries
    {
        public List<JournalEntry> Entries;

        public JournalEntries() { Entries = new List<JournalEntry>(); }

        public void Add(JournalEntry entry)
        {
            Entries.Add(entry);
        }
    }
}
