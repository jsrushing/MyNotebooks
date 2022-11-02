/* Journal Entry object
 * 8/1//21
 */
using System;
using System.Configuration;
using System.Linq;
using encrypt_decrypt_string;
using System.Collections.Generic;
using System.Text;
using myJournal.subforms;

namespace myJournal
{
	[Serializable]
    public class JournalEntry
    {
        public DateTime Date;
        public string Text;
		public string[] Synopsis{ get { return GetSynopsis(); } }
		public string DisplayText { get { return GetTextDisplayText(); } set { DisplayText = value; } }

		private string RTF;
        private string Labels;
		public string Title;
		public bool isEdited = false;
        public string Id;

		public JournalEntry() { }

		public JournalEntry(string _title, string _text, string _RTF, string _labels, bool _edited = false)
        {
			Date	= DateTime.Now;
			Text	= EncryptDecrypt.Encrypt(_text);
            Title	= EncryptDecrypt.Encrypt(_title);
			RTF		= EncryptDecrypt.Encrypt(_RTF);
            Labels	= EncryptDecrypt.Encrypt(_labels);
            Id		= Guid.NewGuid().ToString();
			isEdited = _edited;	
		}

		string GetTextDisplayText()
		{
			return String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
				, ClearTitle(), Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]), ClearTags(), ClearText());
		}

		string[] GetSynopsis()
		{
			string[] sRtrn = new string[4];
			int iTextChunkLength = 150;
			sRtrn[0] = ClearTitle() + " (" + Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")";
			string sEntryText = ClearText();
			sEntryText = (sEntryText.Length < iTextChunkLength ? sEntryText : sEntryText.Substring(0, iTextChunkLength) + " ...");
			sRtrn[1] = sEntryText;
			sRtrn[2] = "labels: " + ClearTags();
			sRtrn[3] = "---------------------";
			return sRtrn;
		}

		public void Replace(JournalEntry newEntry)
		{
			Labels = newEntry.Labels;
			Text = newEntry.Text;
			Title = newEntry.Title;
		}

		public bool RemoveTag(string TagToRemove)
		{
			string tags = this.ClearTags();
			bool bTagReplaced = false;

			if(tags.Length > 0)
			{
				string[] arrTags = tags.Split(',');

				if (Array.IndexOf(arrTags, TagToRemove) > -1)
				{
					arrTags = arrTags.Select(t => t.Remove(Array.IndexOf(arrTags, TagToRemove))).ToArray();
					this.Labels = EncryptDecrypt.Encrypt(String.Join(",", arrTags).Trim(','));
					bTagReplaced = true;
				}
			}
			return bTagReplaced;
		}

		public bool ReplaceTag(string oldTag, string newTag)
		{
			string tags = this.ClearTags();
			bool bTagReplaced = false;

			if(tags.Length > 0)
			{
				string[] arrTags = tags.Split(',');

				if(Array.IndexOf(arrTags, oldTag) > -1)
				{
					arrTags = arrTags.Select(t => t.Replace(oldTag, newTag)).ToArray();
					string finalTagsString = String.Join(",", arrTags).Trim(',').Replace(",,", ",");
					this.Labels = finalTagsString.Length > 2 ? EncryptDecrypt.Encrypt(finalTagsString) : string.Empty;
					bTagReplaced = true;
				}
			}
			return bTagReplaced;
			
			//// bracket oldTags with commas so we're sure to get the exact oldtag instead of possibly a tag with <oldTag> in the tag name
			//string sEntryTagsWithCommas = "," + this.ClearTags() + ",";

			//// if the old tag is found BRACKETED BY COMMAS, replace it. If not then leave sNewClearTags blank.
			//string sNewClearTags = sEntryTagsWithCommas.Contains("," + oldTag + ",") ? sEntryTagsWithCommas.Replace(oldTag, newTag) : string.Empty;

			//// remove any trailing and leading commas
			//while (sNewClearTags.StartsWith(',') | sNewClearTags.EndsWith(',')) { sNewClearTags = sNewClearTags.Trim(','); }

			//if (sNewClearTags.Length > 0) { Labels = EncryptDecrypt.Encrypt(sNewClearTags); }
			//return sNewClearTags.Length > 0;
		}

		public string ClearText()	{ return EncryptDecrypt.Decrypt(Text); }
		public string ClearTitle()	{ return EncryptDecrypt.Decrypt(Title); }
		public string ClearRTF()	{ return EncryptDecrypt.Decrypt(RTF); }
		public string ClearTags()	{ return Labels == null ? String.Empty : EncryptDecrypt.Decrypt(Labels); }
	}
}
