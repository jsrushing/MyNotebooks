﻿/* Journal object
 * 8/1//21
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using myJournal.subforms;

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
		//private string PIN;

        public Journal(string _name = null) 
        {
			//if (_PIN == null || _PIN.Length == 0) { _PIN = null; }
			frmMain frm = new frmMain();

            if(_name != null)
            {
                this.Name = _name;
                this.FileName = AppDomain.CurrentDomain.BaseDirectory + this.root + this.Name;
				//this.PIN = frm.GetPin();	// _PIN;
			}
        }

        public void AddEntry(JournalEntry entryToAdd) { Entries.Add(entryToAdd); }

        private void AddFirstEntry() { Entries.Add(new JournalEntry("created", "-", "")); }

        public void Create()
        {
            AddFirstEntry();
            Save();
        }

        public void Delete() { File.Delete(this.FileName); }

		public string GetAllEntries()
		{
			StringBuilder sb = new StringBuilder();
			//sb.AppendLine("Journal: " + this.Name);
			foreach(JournalEntry je in this.Entries)
			{
				sb.Append(String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Editing"].Replace("Original ", ""), je.Date, je.ClearTitle(), je.ClearText()));
			}
			return sb.ToString();
		}

        public JournalEntry GetEntry(string _title, string _date)
        {
            JournalEntry je = null;
			try { je = this.Entries.First(a => a.ClearTitle() + a.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) == _title + _date); }
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
					//jRtrn.PIN = this.PIN;
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