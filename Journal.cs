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
        string FileName = string.Empty;
        StringBuilder JournalText = new StringBuilder();
        JournalEntries Entries = new JournalEntries();
        string root = "journals\\";

        public Journal(string _name = null) 
        {
            if(_name != null)
            {
                this.Name = _name;
                this.FileName = AppDomain.CurrentDomain.BaseDirectory + this.root + this.Name + ".journal";
                Journal j = this;
                j = OpenJournal();
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

        public void CreateJournal()
        {
            File.Create(this.FileName); 
        }

        private void DeleteJournal()
        {
            File.Delete(this.FileName);
        }

        private Journal OpenJournal()
        {
            try
            {
                using(Stream stream = File.Open(this.FileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (Journal)formatter.Deserialize(stream);
                }
            }
            catch (FileNotFoundException) { return null; }
        }

        public void Save()
        {
            
        }

        public void SaveToDisk()
        {
            string tmpName = this.FileName + "_" + DateTime.Now.ToString("mmddyy_HHMMss");

            using (Stream stream = File.Open(tmpName, FileMode.Append))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
            }

            File.Move(tmpName, this.FileName, true);
        }

        private void GetJournalText()
        {
            // create the Entries object for named journal.
        }
    }
}
