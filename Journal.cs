using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Configuration;

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

        public void Delete() { File.Delete(this.FileName); }

        public JournalEntry GetEntry(string _title, string _date)
        {
            JournalEntry je = null;
			try { je = this.Entries.First(a => a.ClearTitle() + a.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) == _title + _date); }
            catch(Exception) { }
            return je;
        }

        public Journal OpenJournal(string journalToOpen = "")
        {
            Journal jRtrn = null;
            try
            {
                using(Stream stream = File.Open(journalToOpen.Length > 0 ? AppDomain.CurrentDomain.BaseDirectory + this.root + journalToOpen : this.FileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    jRtrn = (Journal)formatter.Deserialize(stream);
					jRtrn.FileName = AppDomain.CurrentDomain.BaseDirectory + this.root + journalToOpen;

				}
            }
            catch(Exception) { }
            return jRtrn;
        }

        public void ReplaceEntry(JournalEntry jeToReplace, JournalEntry jeToInsert)
		{
			int idx = 0;
			for(idx = 0; idx < this.Entries.Count; idx++) { if(this.Entries[idx] == jeToReplace) { break; } }
			this.Entries.Remove(jeToReplace);
			this.Entries.Insert(idx, jeToInsert);
		}

        public void Save()
        {
            
        }

        public void SaveToDisk()
        {
            try { File.Delete(this.FileName); } catch (Exception) { }

            using (Stream stream = File.Open(this.FileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
            }
        }
    }
}
