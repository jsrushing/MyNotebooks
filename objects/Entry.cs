/* Journal Entry object
 * 8/1//21
 * Refactored to LocalNotebook Entry object
 * 06/10/23
 */
using System;
using System.Configuration;
using System.Linq;
using Encryption;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MyNotebooks.subforms;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using MyNotebooks.objects;
using System.Reflection;
using MyNotebooks.DataAccess;
using Org.BouncyCastle.Bcpg.Sig;
using System.Threading.Tasks;

namespace MyNotebooks
{
	[Serializable]
    public class Entry
    {
		public int			CreatedBy { get; set; }
        public DateTime		CreatedOn { get; set; }
		public string		DisplayText { get { return GetTextDisplayText(); } set { DisplayText = value; } }
		public DateTime		EditedOn { get; set; }
        public int			Id { get; set; }
		public string		Labels { get; set; } = string.Empty;
		public string		LabelsToRemove { get; set; }
		public string		NotebookName { get; set; }
		public int			ParentId { get; set; }
		public string		ParentPath { get; set; }
		public string		RTF { get; set; }
		public string		Text { get; set; }
		public string		Text_Shortened { get; set; }
		public string		Title { get; set; }

		public List<MNLabel> AllLabels = new();

		public Entry() { }

		public Entry(string _title, string _text, string _RTF, string _labels, int notebookId = 0, string _notebookName = "", bool _edited = false)
        {
			if(CreatedOn == DateTime.MinValue) { CreatedOn = DateTime.Now; }

			Text		= _text.Trim();
			Title		= _title.Trim();
			RTF			= _RTF;
			NotebookName = _notebookName;
			ParentId	= notebookId;
		}

		public Entry(DataTable dt, int rowIndex = 0)
		{
			var value = "";
			var setProp = true;

			foreach (PropertyInfo sPropertyName in typeof(Entry).GetProperties())
			{
				try
				{
					if (sPropertyName.Name != "DisplayText" & dt.Columns[sPropertyName.Name] != null)
					{
						if (dt.Columns[sPropertyName.Name].DataType == typeof(string))
						{
							value = dt.Rows[rowIndex].Field<string>(sPropertyName.Name).ToString();
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(int))
						{
							int iVal = dt.Rows[rowIndex].Field<int>(sPropertyName.Name);
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, iVal);
							setProp = false;
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(DateTime))
						{
							DateTime dtime = Convert.ToDateTime(dt.Rows[rowIndex].Field<DateTime>(sPropertyName.Name));
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dtime);
							setProp = false;
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(bool))
						{
							bool b = dt.Rows[rowIndex].Field<bool>(sPropertyName.Name);
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, b.ToString() == "1");
							setProp = false;
						}

						if (setProp) { this.GetType().GetProperty(sPropertyName.Name).SetValue(this, value); }
						setProp = true;
					}
				}
				catch (Exception ex)
				{
					if (ex.GetType() != typeof(InvalidCastException))
					{
						if(sPropertyName.Name != "EditedOn" && sPropertyName.Name != "Id")
						{
							using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "The error '" + ex.Message + "' occurred while processing the " +
								"property '" + sPropertyName + "'.", "Error Occurred")) { frm.ShowDialog(); }
						}
					}
				}
			}
		}

		public async Task	Create() { GetOperationResult(DbAccess.CRUDNotebookEntry(this), true); }
		public async Task	Update() { GetOperationResult(DbAccess.CRUDNotebookEntry(this, OperationType.Update)); }
		public async Task	Delete() { GetOperationResult(DbAccess.CRUDNotebookEntry(this, OperationType.Delete)); }

		private void		GetOperationResult(SQLResult result, bool isCreate = false)
		{
			if (isCreate)
			{
				if (result.strValue.Length == 0) { this.Id = result.intValue; }
			}
			else
			{
				if (result.strValue.Length > 0)
				{
					using (frmMessage frm = new(frmMessage.OperationType.Message, "An error occurred. '" + result.strValue + "'", "Error"))
					{ frm.ShowDialog(); }
				}
			}
		}

		public string[]		GetSynopsis(bool includeNotebookName = false, int maxWidth = -1)
		{
			string[] sRtrn = new string[4];
			int iTextChunkLength = maxWidth > 0 ? Convert.ToInt32(maxWidth / 5.3): 150;
			string sTitle = Title + " (" + CreatedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")"
				+ (EditedOn  < new DateTime(2000, 1, 1) ? "" : " [edited on " + EditedOn .ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + "]");
			if (includeNotebookName) 
			{
				var hasParentPath = NotebookName.Contains("(c) ");
				sTitle += NotebookName + (hasParentPath ? "" : this.ParentPath) == null ? "" : " > in '" + NotebookName + "'"; 
			}

			sRtrn[0] = sTitle;
			string sEntryText = Text.Replace("\n", " ");
			sEntryText = (sEntryText.Length < iTextChunkLength ? sEntryText : sEntryText.Substring(0, iTextChunkLength) + " ...");
			sRtrn[1] = sEntryText;
			sRtrn[2] = "labels: " + string.Join(", ", this.AllLabels.Select(e => e.LabelText).ToArray());
			sRtrn[3] = "---------------------";
			return sRtrn;
		}

		private string		GetTextDisplayText()
		{
			string sRtrn = string.Empty;
			//string lbls = string.Join(", ", this.AllLabels.Select(e => e.LabelText).ToArray());

			sRtrn = string.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
				, Title
				, CreatedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"])
				, string.Join(", ", this.AllLabels.Select(e => e.LabelText).ToArray())
				, this.Text);

			////}
			return sRtrn;
		}

		public void			PopulateLabels()
		{
			this.AllLabels.Clear();
			this.AllLabels = DbAccess.GetLabelsForEntry(Convert.ToInt32(this.Id));
		}

		public bool			RemoveOrReplaceLabel(string newLabelName, string oldLabelName, bool renaming = true)
		{
			var labels = this.Labels;
			var bLabelEdited = false;

			if (labels.Length > 0)
			{
				List<string> arrLabels = labels.Split(',').ToList();
				var iLabelIndex = arrLabels.IndexOf(oldLabelName);

				if (iLabelIndex > -1)
				{
					if (renaming)
					{
						arrLabels.RemoveAt(iLabelIndex);
						arrLabels.Insert(iLabelIndex, newLabelName);
					}
					else
					{
						arrLabels.RemoveAt(iLabelIndex);
					}

					var finalLabelsString = string.Join(",", arrLabels).Trim(',').Replace(",,", "");
					this.Labels = finalLabelsString.Length > 0 ? finalLabelsString : string.Empty;
					bLabelEdited = true;
				}
			}
			return bLabelEdited;
		}

		public static Entry Select(RichTextBox rtb, ListBox lb, Notebook currentNotebook, bool firstSelection = false, Entry je = null, bool resetTopIndex = true)
		{
			rtb.Clear();
			List<int> targets = new List<int>();
			Entry entryRtrn = null;

			if (je != null)
			{
				entryRtrn = je;

				for (var i = 0; i < lb.Items.Count; i++)
				{
					if (lb.Items[i].ToString().StartsWith(je.GetSynopsis(false)[0].ToString()))
					{
						lb.SelectedIndices.Add(i);
						lb.SelectedIndices.Add(i + 1);
						lb.SelectedIndices.Add(i + 2);
						rtb.Text = je.DisplayText;
						break;
					}
				}
			}
			else
			{
				try
				{
					if (lb.SelectedIndices.Count > 1)
					{
						for (var i = 0; i < lb.SelectedIndices.Count - 1; i++)
						{
							if (lb.SelectedIndices[i] == lb.SelectedIndices[i + 1] - 1)
							{
								targets.Add(lb.SelectedIndices[i]);
								targets.Add(lb.SelectedIndices[i + 1]);
								targets.Add(lb.SelectedIndices[i + 2]);
								break;
							}
						}
					}
				}
				catch (Exception) { }

				if (targets.Count == 3)
				{
					foreach (var i in targets)
					{
						lb.SelectedIndices.Remove(i);
					}
				}

				var ctr = lb.SelectedIndex;

				if (lb.Items[ctr].ToString().StartsWith("--")) { ctr--; }

				while (!lb.Items[ctr].ToString().StartsWith("--") & ctr > 0)
				{
					ctr--;
					if (ctr < 0) break;
				}

				if (ctr > 0) { ctr += 1; }
				lb.SelectedIndices.Clear();                             // Select the whole short entry ...
				lb.SelectedIndices.Add(ctr);
				lb.SelectedIndices.Add(ctr + 1);
				lb.SelectedIndices.Add(ctr + 2);                        //

				var sTitleAndDate = lb.Items[ctr].ToString().Replace(" - EDITED", "");        // Use the title and date of the entry to create a JournalEntry object whose .ClearText will populate the display

				string[] titleAndDate = Utilities.GetTitleAndDate(sTitleAndDate);

				if (titleAndDate[0] != null && titleAndDate[1] != null)
				{
					DateTime.TryParse(titleAndDate[1], out DateTime dt);
					entryRtrn = currentNotebook.GetEntry(titleAndDate[0], titleAndDate[1]);	// DbAccess.GetFullEntry(currentNotebook.GetEntry(titleAndDate[0], titleAndDate[1]));

					if(entryRtrn != null)
					{
						rtb.Text = string.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
						, entryRtrn.Title, entryRtrn.CreatedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"])
						, entryRtrn.Labels, entryRtrn.Text);
					}

					if (resetTopIndex) { if (rtb.Text.Length == 0) { lb.TopIndex = lb.Top + lb.Height < rtb.Top ? ctr : lb.TopIndex; } }
					lb.Height = rtb.Text.Length > 0 ? rtb.Top - 132 : 100;
					if (firstSelection) { lb.TopIndex = lb.Top + lb.Height < rtb.Top ? ctr : lb.TopIndex; }

					rtb.Visible = rtb.Text.Length > 0;
				}
			}
			return entryRtrn;
		}
	}
}
