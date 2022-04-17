using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Configuration;
using System.Web;

namespace myJournal
{
    [Serializable]
    public class Journal
    {
		public string Name = string.Empty;
        string FileName = string.Empty;
        StringBuilder JournalText = new StringBuilder();
        public List<JournalEntry> Entries = new List<JournalEntry>();
        string root = "journals\\";
		public string PIN;

        public Journal(string _PIN, string _name = null) 
        {
			//Configuration config = System.Web.
            if(_name != null)
            {
                this.Name = _name;
                this.FileName = AppDomain.CurrentDomain.BaseDirectory + this.root + this.Name;
				this.PIN = _PIN;
			}
        }

        public void AddEntry(JournalEntry entryToAdd) { Entries.Add(entryToAdd); }

        private void AddFirstEntry() { Entries.Add(new JournalEntry("created", "-", "", PIN)); }

        public void Create()
        {
            AddFirstEntry();
            Save();
        }

		public void ChangePIN(string newPIN)
		{
			foreach (JournalEntry je in this.Entries)
			{
				JournalEntry newJE = new JournalEntry(je.ClearTitle(), je.ClearText(), je.ClearTags(), newPIN);
				newJE.Date = je.Date;
			}
		}

        public void Delete() { File.Delete(this.FileName); }

		public string GetAllEntries()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Journal: " + this.Name);
			foreach(JournalEntry je in this.Entries)
			{
				sb.Append(String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Editing"].Replace("Original ", ""), je.Date, je.ClearTitle(this.PIN), je.ClearText(this.PIN)));
			}
			return sb.ToString();
		}

        public JournalEntry GetEntry(string _title, string _date)
        {
            JournalEntry je = null;
			try { je = this.Entries.First(a => a.ClearTitle(this.PIN) + a.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) == _title + _date); }
            catch(Exception) { }
            return je;
        }

        public Journal Open(string journalToOpen = "")
        {
            Journal jRtrn = null;

            try
            {
                using(Stream stream = File.Open(journalToOpen.Length > 0 ? AppDomain.CurrentDomain.BaseDirectory + this.root + journalToOpen : this.FileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    jRtrn = (Journal)formatter.Deserialize(stream);
					jRtrn.FileName = AppDomain.CurrentDomain.BaseDirectory + this.root + journalToOpen;
					jRtrn.PIN = this.PIN;
				}
            }
            catch(Exception) { }
            return jRtrn;
        }

        public void ReplaceEntry(JournalEntry jeToReplace, JournalEntry jeToInsert)
		{
			int idx;
			for(idx = 0; idx < this.Entries.Count; idx++) { if(this.Entries[idx] == jeToReplace) { break; } }
			this.Entries.Remove(jeToReplace);
			this.Entries.Insert(idx, jeToInsert);
		}

        public void Save()
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
