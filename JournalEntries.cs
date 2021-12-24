using System;
using System.Collections.Generic;
using System.Text;

namespace myJournal
{
    class JournalEntries
    {
        public List<JournalEntry> Entries;

        public JournalEntries() { Entries = new List<JournalEntry>(); }

        public void AddEntry(JournalEntry entry)
        {
            Entries.Add(entry);
        }
    }
}
