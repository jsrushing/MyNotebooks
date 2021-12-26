using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace myJournal
{
    [Serializable]
    public class Journal
    {
        string Name = string.Empty;
        string FileName = string.Empty;
        StringBuilder JournalText = new StringBuilder();
        public List<JournalEntry> Entries = new List<JournalEntry>();
        string root = "journals\\";

        public Journal(string _name = null) 
        {
            if(_name != null)
            {
                this.Name = _name;
                this.FileName = AppDomain.CurrentDomain.BaseDirectory + this.root + this.Name;
            }
        }

        private void AddEntry(string _title, string _text)
        {
            Entries.Add(new JournalEntry(_title, _text, ""));
        }

        public void AddFirstEntry()
        {
            Entries.Add(new JournalEntry("created", "-", ""));
        }

        public void CreateJournal()
        {
            AddFirstEntry();
            SaveToDisk();
        }

        private void DeleteJournal()
        {
            File.Delete(this.FileName);
        }

        public JournalEntry GetEntry(string _title, string _date)
        {
            return this.Entries.First(a => a.Title + a.Date.ToString("M-dd-yy H-d-yy") == _title + _date);
        }

        public Journal OpenJournal()
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
            //string tmpName = this.FileName + "_" + DateTime.Now.ToString("mmddyy_HHMMss");

            try { File.Delete(this.FileName); } catch (Exception) { }

            using (Stream stream = File.Open(this.FileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
            }
        }
    }
}
