using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace myJournal
{
    [Serializable]
    public class Journal
    {
        string Name = string.Empty;
        StringBuilder JournalText = new StringBuilder();
        JournalEntries Entries = new JournalEntries();
        string root = "/journals/";

        public Journal(string _name = null) 
        {
            if(_name != null)
            {
                this.Name = root + _name;
                Journal t = this;
                t = OpenJournal();
            }
        }

        private void AddEntry(string _title, string _text)
        {
            Entries.Add(new JournalEntry(_title, _text));
        }

        public void AddFirstEntry()
        {
            Entries.Add(new JournalEntry("created", "-"));
        }

        public void Create(string _name)
        {
            this.Name = root + _name;
        }

        private void DeleteJournal()
        {
            File.Delete(root + this.Name);
        }

        private Journal OpenJournal()
        {
            using(Stream stream = File.Open(this.Name, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (Journal)formatter.Deserialize(stream);
            }
        }

        public void Save()
        {
            
        }

        public void SaveToDisk()
        {
            string tmpName = this.Name + "_" + DateTime.Now.ToLongDateString() + "_" + DateTime.Now.ToLongTimeString();

            using (Stream stream = File.Open(tmpName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
            }
            DeleteJournal();
            File.Move(tmpName, this.Name);
        }

        private void GetJournalText()
        {
            // create the Entries object for named journal.
        }
    }
}
