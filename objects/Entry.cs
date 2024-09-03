/* Journal Entry object
 * 8/1//21
 * Refactored to LocalNotebook Entry object
 * 06/10/23
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using MyNotebooks.DataAccess;
using MyNotebooks.objects;
using MyNotebooks.subforms;

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

		public string		ParentPath = null;
		public string		RTF { get; set; }
		public string		Text { get; set; }
		public string		Text_Shortened { get; set; }
		public string		Title { get; set; }
		public string		RTBText {  get { return GetRTBText(); } }

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
			var err = false;

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
								"Entry property '" + sPropertyName + "'.", "Error Occurred")) { frm.ShowDialog(); }
						}
						err = true;
					}
				}
			}

			if(!err) this.AllLabels = DbAccess.GetLabelsForEntry(this.Id);
		}

		public SQLResult Create() { return GetOperationResult(DbAccess.CRUDNotebookEntry(this), true); }
		public SQLResult Update() { return GetOperationResult(DbAccess.CRUDNotebookEntry(this, OperationType.Update)); }
		public SQLResult Delete() { return GetOperationResult(DbAccess.CRUDNotebookEntry(this, OperationType.Delete)); }

		private SQLResult	GetOperationResult(SQLResult result, bool isCreate = false)
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
			return result;
		}

		public string[]		GetSynopsis(bool includeNotebookName = false, int maxWidth = -1)
		{
			string[] sRtrn = new string[4];
			int iTextChunkLength = maxWidth > 0 ? Convert.ToInt32(maxWidth / 5.3): 150;
			string sTitle = Title + " (" + CreatedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")"
				+ (EditedOn  < new DateTime(2000, 1, 1) ? "" : " [edited on " + EditedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + "]");

			if (includeNotebookName) 
			{
				//var hasParentPath = NotebookName.Contains("(c) ");
				sTitle += " in '" + NotebookName + "' " + this.ParentPath;
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

		private string		GetRTBText()
		{
			return string.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
				, this.Title, this.CreatedOn.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"])
				, string.Join(",", this.AllLabels.Select(e => e.LabelText).ToArray()), this.Text);
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
	}
}
