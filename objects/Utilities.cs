/* Utility functions.
 * 7/9/22
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Encryption;
using MyNotebooks.DataAccess;
using MyNotebooks.subforms;
using Newtonsoft.Json.Linq;
using static Azure.Core.HttpHeader;

namespace MyNotebooks.objects
{
	public static class Utilities
	{
		//public static Entry CreateEntry(string title, string text, string RTF, string labelsForSearch, string notebookName, string PIN)
		//{
		//	return new Entry(EncryptDecrypt.Encrypt(title, PIN), EncryptDecrypt.Encrypt(text, PIN), 
		//		EncryptDecrypt.Encrypt(RTF, PIN), EncryptDecrypt.Encrypt(labelsForSearch, PIN), EncryptDecrypt.Encrypt(notebookName, PIN));
		//}

		public static bool FileNameIsValid(string proposedFileName) { return proposedFileName.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) == -1; }

		public static List<Notebook> GetCheckedNotebooks()
		{
			List<Notebook> rtrn = new List<Notebook>();

			foreach(var key in Program.DictCheckedNotebooks.Keys)
			{
				Program.PIN = Program.DictCheckedNotebooks[key];
				rtrn.Add(new Notebook(key).Open());
			}

			return rtrn;
		}

		//public static SQLResult GetOperationResult(SQLResult result, int objectId, bool isCreate = false)
		//{
		//	if (isCreate)
		//	{
		//		if (result.strValue.Length == 0) { objectId = result.intValue; }
		//	}
		//	else
		//	{
		//		if (result.strValue.Length > 0)
		//		{
		//			using (frmMessage frm = new(frmMessage.OperationType.Message, "An error occurred. '" + result.strValue + "'", "Error"))
		//			{ frm.ShowDialog(); }
		//		}
		//	}
		//}
	//}

		public static string[] GetTitleAndDate(string searchString, int startPosition = 0)
		{
			var result = new string[2];
			var paren1 = searchString.LastIndexOf("(") + 1;
			var paren2 = searchString.LastIndexOf(')');

			try
			{
				if (paren2 - paren1 == 17)
				{
					DateTime.TryParse(searchString.Substring(paren1, paren2 - paren1), out DateTime tryDate);

					if (tryDate > DateTime.MinValue)
					{
						result[0] = searchString.Substring(0, paren1 + 1 - 1).Trim();
						result[1] = tryDate.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]);
					}
				}
				else
				{
					//using(frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "There is a problem with this entry. The CreatedOn can not be found.", "")) { frm.ShowDialog(); }
				}
			}
			catch (Exception) { }

			return result;
		}

		public async static Task ImportNotebooks(Form parent)
		{
			OpenFileDialog ofd = new OpenFileDialog { Multiselect = true };
			//var filesCopied = false;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				var target = String.Empty;
				var nbName = string.Empty;
				var ok2copy = true;

				foreach (var fileName in ofd.FileNames)
				{
					nbName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
					target = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"] + nbName;

					if (File.Exists(target))
					{
						using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion,
							"The notebook '" + nbName + "' already exists. Do you want to ovewrwrite the notebook?", "", parent))
						{
							frm.ShowDialog(parent);
							ok2copy = frm.Result == frmMessage.ReturnResult.Yes;
						}
					}

					using (frmMessage frm2 = new frmMessage(frmMessage.OperationType.InputBox, "Enter the PIN for '" + nbName + "'.", "", parent))
					{
						frm2.ShowDialog();
						ok2copy = frm2.Result == frmMessage.ReturnResult.Ok;
						if (ok2copy) { Program.PIN = frm2.ResultText; }
					}

					if (ok2copy)
					{
						File.Copy(fileName, target, true);
						Program.DictCheckedNotebooks.Add(nbName, Program.PIN);
						Program.AllNotebooks.Add(new Notebook(nbName).Open());
						//filesCopied = true;
						List<string> newLabels = LabelsManager.FindNewLabelsInOneSelectedJournal(null, nbName);

						if (newLabels.Count > 0)
						{
							var lbls = string.Join(',', newLabels);

							using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "The following labelsForSearch were found in the " +
								"imported notebook but are not in your main labelsForSearch list." + Environment.NewLine + lbls + Environment.NewLine + 
								"Do you want to add them?", "New Labels Found", parent))
							{
								frm.ShowDialog();
								if (frm.Result == frmMessage.ReturnResult.Yes) { await LabelsManager.AddLabel(newLabels.ToArray()); }
							}
						}
					}

					ok2copy = true;
				}	
			}
			//return filesCopied;
		}

		public static async Task PopulateAllNotebookNames(List<string> notebookNames = null)
		{

			if (notebookNames != null)
			{
				//Program.AllNotebookNames.AddRange(notebookNames); << DOESN'T WORK ??	
				foreach (string notebookName in notebookNames) { Program.AllNotebookNames.Add(notebookName); }
			}
			else
			{
				Program.AllNotebookNames.Clear();
				Program.NotebooksNamesAndIds.Clear();

				foreach(var v2 in DbAccess.GetNotebookNamesAndIdsForGroup(Program.ActiveNBParentId))
				{ Program.NotebooksNamesAndIds.Add(v2.Name, v2.Id); }

				//var v = DbAccess.get

				//Program.User.Notebooks.Select(item => item.Name).ToList();

				//List<string> s = Directory.GetFiles(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"]).ToList();
				//Program.AllNotebookNames.AddRange(s.Select(s => s[(s.LastIndexOf("\\") + 1)..]));
			}
		} 

		public static async Task PopulateAllNotebooks(List<string> notebookNames = null)
		{
			Program.AllNotebooks.Clear();
			await PopulateAllNotebookNames(notebookNames);
			//if(notebookNames == null) { await PopulateAllNotebookNames(); } else { await PopulateAllNotebookNames(notebookNames); }
			foreach (var notebookName in Program.AllNotebookNames) { Program.AllNotebooks.Add(new Notebook(notebookName).Open()); }
		}

		// one-time code to convert Journal objects to LocalNotebook objects
		//public static List<Journal> AllJournals()
		//{
		//	List<Journal> jrnlReturn = new List<Journal>();
		//	var sJournalsFolder = Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"];
		//	foreach (var s in Directory.GetFiles(sJournalsFolder)) { jrnlReturn.Add(new Journal(s.Replace(sJournalsFolder, "")).Open()); }  // (new Journal(s.Replace(sJournalsFolder, "")).Open()); }
		//	return jrnlReturn;
		//}

		public static void PopulateDictCheckedNotebooks(string name)
		{
			var items = name.Split(",");

			if (Program.AllNotebookNames.Contains(EncryptDecrypt.Decrypt(items[0])))
			{
				Program.DictCheckedNotebooks.Add(EncryptDecrypt.Decrypt(items[0]), EncryptDecrypt.Decrypt(items[1]));
			}
		}

		public static void PopulatePropertiesFromDataRow(Type targetType, DataTable dt, int rowIndex = 0, string skippedProperties = "")
		{
			var value = "";
			var setProp = true;

			foreach (PropertyInfo sPropertyName in targetType.GetProperties())
			{
				try
				{
					if (!skippedProperties.Contains(sPropertyName.Name) & dt.Columns[sPropertyName.Name] != null)
					{
						if (dt.Columns[sPropertyName.Name].DataType == typeof(string))
						{
							value = dt.Rows[rowIndex].Field<string>(sPropertyName.Name).ToString();
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(Int32))
						{
							int iVal = dt.Rows[rowIndex].Field<Int32>(sPropertyName.Name);
							targetType.GetType().GetProperty(sPropertyName.Name).SetValue(targetType, iVal);
							setProp = false;
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(DateTime))
						{
							DateTime dtime = Convert.ToDateTime(dt.Rows[rowIndex].Field<DateTime>(sPropertyName.Name));
							targetType.GetType().GetProperty(sPropertyName.Name).SetValue(targetType, dtime);
							setProp = false;
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(bool))
						{
							bool b = dt.Rows[rowIndex].Field<bool>(sPropertyName.Name);
							targetType.GetType().GetProperty(sPropertyName.Name).SetValue(targetType, b.ToString() == "1");
							setProp = false;
						}

						if (setProp) { targetType.GetType().GetProperty(sPropertyName.Name).SetValue(targetType, value); }
						setProp = true;
					}
				}
				catch (Exception ex)
				{
					if (ex.GetType() != typeof(InvalidCastException))
					{
						if (!skippedProperties.Contains(sPropertyName.Name))
						{
							using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "The error '" + ex.Message + "' occurred while processing the " +
								"property '" + sPropertyName + "'.", "Error Occurred")) { frm.ShowDialog(); }
						}
					}
				}
			}
		}

		public static async Task PopulateEntries(ListBox lbxToPopulate, List<Entry> entries, string notebookName = "", string startDate = "", 
			string endDate = "", bool clearPrevious = true, int SortBy = 0, bool includeNotebookName = false, int maxWidth = 0, string labelFilter = "")
		{
			if(clearPrevious) lbxToPopulate.Items.Clear();
			List<Entry> tmpEntries = null;
			tmpEntries = startDate.Length > 0 ? entries.Where(d => DateTime.Parse(d.CreatedOn.ToShortDateString()) >= DateTime.Parse(startDate)).ToList() : entries;
			tmpEntries = endDate.Length > 0 ? tmpEntries.Where(d => DateTime.Parse(d.CreatedOn.ToShortDateString()) <= DateTime.Parse(endDate)).ToList() : tmpEntries;

			if(labelFilter.Length > 0)
			{
				tmpEntries = tmpEntries.Where(e => e.Labels.Contains(labelFilter)).ToList();
			}
			
			switch (SortBy)
			{
				case 0: 
					tmpEntries.Sort((x, y) => -x.CreatedOn.CompareTo(y.CreatedOn));
					break;
				case 1:
					tmpEntries.Sort((x, y) => -x.EditedOn.CompareTo(y.EditedOn));
					break;
				case 2:
					tmpEntries.Sort((x, y) => x.Title.CompareTo(y.Title));
					break;
				case 3:
					tmpEntries.Sort((x,y) => x.NotebookName.CompareTo(y.NotebookName));
					break;
			}

			foreach (Entry nbEntry in tmpEntries)
			{
				nbEntry.PopulateLabels();
				nbEntry.NotebookName += "' " + nbEntry.ParentPath;
				var synopsis = nbEntry.GetSynopsis(includeNotebookName, maxWidth);
				for(int i = 0; i < synopsis.Length; i++) { lbxToPopulate.Items.Add(synopsis[i]); } 
			}
		}

		public static void ResizeListsAndRTBs(ListBox entriesList, RichTextBox entryRTB, Label seperatorLabel, Label typeLabel, Form callingForm)
		{
			int iBoxCenter = entriesList.Width / 2;
			seperatorLabel.Visible = true;
			entryRTB.Visible = true;
			seperatorLabel.Left = entriesList.Left + 10;
			seperatorLabel.Width = entriesList.Width - 20;
			entriesList.Height = seperatorLabel.Top - entriesList.Top;
			typeLabel.Top = seperatorLabel.Top + seperatorLabel.Height;
			entryRTB.Top = typeLabel.Top + typeLabel.Height;
			entryRTB.Height = callingForm.Height - entryRTB.Top - 50;
		}

		public static void SetProgramPIN(string nb)
		{ Program.PIN = Program.DictCheckedNotebooks[nb] == "" ? "" : Program.DictCheckedNotebooks[nb]; }

		public static void SetStartPosition(Form formToInitialize, Form parentForm)
		{ 
			formToInitialize.StartPosition = FormStartPosition.Manual;	
			formToInitialize.Location = new System.Drawing.Point(parentForm.Location.X + 25, parentForm.Location.Y + 25); 
		}
	}
}