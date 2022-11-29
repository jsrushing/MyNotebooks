/* Manage labels.
 * 7/9/22
 * 11/5/22 : Completed major work on Rename and Delete (in 1 journal or Global)
 */
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmLabelsManager : Form
	{
		private bool Renaming = false;
		private bool Adding = false;
		private bool Deleting = false;
		private bool EditingAllJournals;
		private LabelsSortType sort = LabelsSortType.None;
		private string OriginalPIN = Program.PIN;

		public bool ActionTaken { get; private set; }

		private enum LabelsSortType
		{
			Ascending,
			Descending,
			None
		}

		private Journal CurrentJournal;

		public frmLabelsManager(Journal _jrnl = null)
		{
			InitializeComponent();

			if(_jrnl != null)
			{
				//LabelsManager.Journal = _jrnl;
				CurrentJournal = _jrnl;

				mnuRename_InCurrentJournal.Text = "In '" + _jrnl.Name + "'";
				mnuDelete_InCurrentJournal.Text = "In '" + _jrnl.Name + "'";
			}
			else { mnuRename_InCurrentJournal.Visible = false; mnuDelete_InCurrentJournal.Visible = false; }
		}

		private void frmLabelsManager_FormClosing(object sender, FormClosingEventArgs e) { Program.PIN = OriginalPIN; }

		private void frmLabelsManager_Load(object sender, EventArgs e)
		{
			this.Size = this.MinimumSize;
			pnlNewLabelName.Location = new Point(0, 0);
			pnlNewLabelName.Size = this.Size;
			pnlJournalPINs.Location = new Point(pnlMain.Location.X, 0);
			pnlJournalPINs.Visible = true;
			pnlMain.Visible = false;
			mnuMain.Visible = false;
			this.Width = pnlMain.Width + 47;
			ShowHideOccurrences();
			foreach (Journal j in Utilities.AllJournals()) { lstJournalPINs.Items.Add(j.Name); }
			lstJournalPINs.Sorted = true;
			sort = LabelsSortType.None;
			lblSortType_Click(null, null);
		}

		private void frmLabelsManager_Resize(object sender, EventArgs e)
		{ 
			if (this.Width > this.MinimumSize.Width) { this.Width = this.MinimumSize.Width; };
			ShowHideOccurrences();		
		}

		private void AddLabelToUIListbox()
		{
			if (txtLabelName.Text.Length > 0)
			{
				lstLabels.Items.Add(txtLabelName.Text);
			}
		}

		private void btnAddPIN_Click(object sender, EventArgs e)
		{
			string s = lstJournalPINs.SelectedItem.ToString();
			s = s.Contains("|") ? s.Substring(0, s.IndexOf("|")) : s;
			s = s + "|" + txtPIN.Text;
			lstJournalPINs.Items.Insert(lstJournalPINs.SelectedIndex, s);
			lstJournalPINs.Items.RemoveAt(lstJournalPINs.SelectedIndex);
			txtPIN.Text = "(select a Journal)";
			txtPIN.Enabled = false;
			btnAddPIN.Enabled = false;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			pnlNewLabelName.Visible = false;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			string sOldTagName = lstLabels.SelectedItem != null ? lstLabels.SelectedItem.ToString() : string.Empty;
			bool bEdited = true;

			if (Adding) 
			{ 
				AddLabelToUIListbox();
				SaveLabels(); 
				pnlNewLabelName.Visible = false;
				Utilities.PopulateLabelsList(null, lstLabels);
				lstOccurrences.Items.Clear();
				ShowHideOccurrences();
			}

			if (Renaming | Deleting)
			{
				List<Journal> journalsToEdit = EditingAllJournals ? Utilities.AllJournals() : new List<Journal>();

				if (journalsToEdit.Count == 0) { journalsToEdit.Add(CurrentJournal); } // would be at least 1 if 'All Journals' was clicked

				foreach (Journal jrnl in journalsToEdit)
				{
					SetProgramPINForSelectedJournal(jrnl);

					List<JournalEntry> lstEntryHasOldTag = jrnl.Entries.Where(t => ("," + t.ClearTags() + ",").Contains("," + sOldTagName + ",")).ToList();

					if (lstEntryHasOldTag.Count > 0)
					{
						foreach (JournalEntry je in lstEntryHasOldTag)
						{
							bEdited = je.RemoveOrReplaceTag(txtLabelName.Text, sOldTagName, Renaming);
							if (bEdited) { jrnl.Save(); }
						}
					}
				}

				if (bEdited)
				{
					if (Renaming)
					{
						if (EditingAllJournals) // it was a global change - the old label doesn't exist in any entry in any journal so remove it from the Labels file
						{
							if (!lstLabels.Items.Contains(txtLabelName.Text))
							{ 
								lstLabels.Items.Insert(lstLabels.SelectedIndex, txtLabelName.Text); 
								lstLabels.Items.RemoveAt(lstLabels.SelectedIndex);
							}
						}
						else { AddLabelToUIListbox(); }    // the old label might exist in other entries, so add the new label only to the Labels file
					}
					else    // It was a delete. If label exists in any journal, leave in list, otherwise remove from list.
					{
						if (!LabelExistsInAnyJournal(txtLabelName.Text)) 
						{ 
							lstLabels.Items.RemoveAt(lstLabels.SelectedIndex);
							lstOccurrences.Items.Clear();
							ShowHideOccurrences();
						}
					}

					SaveLabels();
					//LabelsManager.SaveLabels(lstLabels.Items.OfType<string>().ToList());
				}

				ActionTaken = bEdited;
				Adding = false;
				Deleting = false;
				Renaming = false;
				txtLabelName.Enabled = true;
				txtLabelName.Text = string.Empty;
				pnlNewLabelName.Visible = false;
				PopulateOccurrences();
			}
		}

		private void btnPINsOK_Click(object sender, EventArgs e)
		{
			pnlJournalPINs.Visible = false;
			pnlMain.Visible = true;
			mnuMain.Visible = true;
		}

		private void SetProgramPINForSelectedJournal(Journal journal)
		{
			string sPIN = string.Empty;
			string sJrnlPin = lstJournalPINs.Items.OfType<string>().ToArray().Single(x => x.StartsWith(journal.Name));
			sPIN = sJrnlPin.Contains("|") ? sJrnlPin.Substring(sJrnlPin.IndexOf("|") + 1) : string.Empty;
			Program.PIN = sPIN;
		}

		private bool LabelExistsInAnyJournal(string labelName)
		{
			foreach (Journal jrnl in Utilities.AllJournals())
			{
				SetProgramPINForSelectedJournal(jrnl);
				if(jrnl.Entries.Where(t => ("," + t.ClearTags() + ",").Contains("," + labelName + ",")).ToList().Count > 0)
				{
					return true;
				}	
			}
			return false;
		}

		private void lblSortType_Click(object sender, EventArgs e)
		{
			switch (sort)
			{
				case LabelsSortType.None:
					Utilities.PopulateLabelsList(null, lstLabels, Utilities.LabelsSortType.None);
					lblSortType.Text = "sort A-Z";
					sort = LabelsSortType.Ascending;
					break;
				case LabelsSortType.Ascending:
					Utilities.PopulateLabelsList(null, lstLabels, Utilities.LabelsSortType.Descending);
					lblSortType.Text = "sort Z-A";
					sort = LabelsSortType.Descending;
					break;
				case LabelsSortType.Descending:
					Utilities.PopulateLabelsList(null, lstLabels, Utilities.LabelsSortType.Ascending);
					lblSortType.Text = "unsorted";
					sort = LabelsSortType.None;
					break;
			}
		}

		private void lstJournalPINs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(lstJournalPINs.SelectedIndex > -1)
			{
				txtPIN.Text = string.Empty;
				txtPIN.Enabled = true;
				btnAddPIN.Enabled = true;
				txtPIN.Focus();
			}
		}

		private void lstLabels_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(lstLabels.SelectedIndex > -1)
			{
				mnuRename.Enabled = true;
				mnuDelete.Enabled = true;
				mnuMoveTop.Enabled = true;
				mnuMoveUp.Enabled = lstLabels.SelectedIndex > 0;
				mnuMoveDown.Enabled = lstLabels.SelectedIndex != lstLabels.Items.Count - 1;
				lstOccurrences.Items.Clear();
				lstEntryObjects.Items.Clear();
				//lstOccurrences.DataSource = null;
				PopulateOccurrences();
				this.FormBorderStyle = FormBorderStyle.Sizable;
			}
		}

		private void lstOccurrences_DoubleClick(object sender, EventArgs e)
		{
			int i = lstOccurrences.SelectedIndex;
			KeyValuePair<Journal, JournalEntry> kvp = (KeyValuePair<Journal, JournalEntry>)lstEntryObjects.Items[i];
			Journal j = kvp.Key;
			JournalEntry je = kvp.Value;
			SetProgramPINForSelectedJournal(j);
			frmNewEntry frm = new frmNewEntry(j, je);
			Utilities.Showform(frm, this);
			if (frm.saved) { ShowHideOccurrences(); }
			frm.Close();
			this.Show();
		}

		private void mnuAdd_Click(object sender, EventArgs e)
		{
			Adding = true;
			lblOperation.Text = "Label Name:";
			pnlNewLabelName.Visible = true;
			txtLabelName.Text = string.Empty;
			txtLabelName.Focus();
			this.AcceptButton = btnOK;
		}

		private void mnuAssignPINs_Click(object sender, EventArgs e)
		{
			pnlMain.Visible = false;
			pnlJournalPINs.Visible = true;

			if(lstJournalPINs.Items.Count == 0)
			{ foreach(Journal j in Utilities.AllJournals()) { lstJournalPINs.Items.Add(j.Name); } }

			this.Size = this.MinimumSize;
		}

		private void mnuDelete_Click(object sender, EventArgs e)
		{
			Deleting = true;
			EditingAllJournals = ((ToolStripMenuItem)sender).Text.ToLower().StartsWith("in all");
			lblOperation.Text = "Delete this label in " + (EditingAllJournals ? "all journals" : "'" + this.CurrentJournal.Name) + "'?";
			pnlNewLabelName.Visible = true;
			txtLabelName.Text = lstLabels.SelectedItem.ToString();
			txtLabelName.Enabled = false;
			btnCancel.Focus();
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void mnuMoveUp_Click(object sender, EventArgs e)
		{
			string sLbl = lstLabels.SelectedItem.ToString();
			int selIndx = lstLabels.SelectedIndex;
			lstLabels.Items.RemoveAt(selIndx);
			lstLabels.Items.Insert(selIndx - 1, sLbl);
			lstLabels.SelectedIndex = selIndx - 1;
			SaveLabels();
		}

		private void mnuMoveDown_Click(object sender, EventArgs e)
		{
			string sLbl = lstLabels.SelectedItem.ToString();
			int selIndx = lstLabels.SelectedIndex;
			lstLabels.Items.RemoveAt(selIndx);
			lstLabels.Items.Insert(selIndx + 1, sLbl);
			lstLabels.SelectedIndex = selIndx + 1;
			SaveLabels();
		}

		private void mnuRename_Click(object sender, EventArgs e)
		{
			Renaming = true;
			EditingAllJournals = ((ToolStripMenuItem)sender).Text.ToLower().StartsWith("in all");
			lblOperation.Text = "New Label Name:";
			txtLabelName.Text = lstLabels.SelectedItem.ToString();
			pnlNewLabelName.Visible = true;
			txtLabelName.Visible = true;
			txtLabelName.Focus();
			txtLabelName.SelectAll();
			this.AcceptButton = btnOK;
		}

		private void PopulateOccurrences()
		{
			if(lstLabels.SelectedItem != null)
			{
				string sLabelName = lstLabels.SelectedItem.ToString();
				lstOccurrences.Items.Clear();
				this.Cursor = Cursors.WaitCursor;
				List<JournalEntry> foundItems_Loop = new List<JournalEntry>();
				List<JournalEntry> foundItems;
				string sPIN = string.Empty;
				//Dictionary<string, JournalEntry> dict = new Dictionary<string, JournalEntry>();

				if (sLabelName.Length > 0)
				{
					foreach(Journal jrnl in Utilities.AllJournals())
					{
						SetProgramPINForSelectedJournal(jrnl);
						foundItems = jrnl.Entries.Where(t => ("," + t.ClearTags() + ",").Contains("," + sLabelName + ",")).ToList();

						if (foundItems.Count > 0)
						{
							//dict.Add("in '" + jrnl.Name + "'", null);
							lstOccurrences.Items.Add("in '" + jrnl.Name + "'");
							lstEntryObjects.Items.Add("");

							foreach (JournalEntry je in foundItems) 
							{
								//dict.Add("  > " + je.ClearTitle(), je);

								lstOccurrences.Items.Add("   > " + je.ClearTitle());
								lstEntryObjects.Items.Add(new KeyValuePair<Journal, JournalEntry>(jrnl, je));		//(jrnl.Name + "|" + je.ClearTitle());
							}
							
							lstOccurrences.Items.Add("-----------------------");
							lstEntryObjects.Items.Add("");

							//dict.Add("----------------", null);
						}

					}
					//if (dict.Count > 0)
					//{
					//	lstOccurrences.DataSource = new BindingSource(dict, null);
					//	lstOccurrences.DisplayMember = "Key";
					//	lstOccurrences.ValueMember = "Value";
					//}
					//else
					//{
					//	lstOccurrences.Items.Add("No occurrences found (are you missing a PIN?)");
					//}

					if (lstOccurrences.Items.Count == 0) { lstOccurrences.Items.Add("No occurrences found (are you missing a PIN?)"); }
				}
			}
			else { lstOccurrences.Items.Clear(); }

			ShowHideOccurrences();
			ShowHideInCurrentJournalMenus();
			this.Cursor = Cursors.Default;
		}

		private void SaveLabels()
		{
			StringBuilder sb = new StringBuilder();
			string[] arrTags = lstLabels.Items.OfType<string>().ToArray();
			//Array.Sort(arrTags, (x, y) => x.CompareTo(y));
			foreach (string tag in arrTags) { sb.AppendLine(tag); }

			File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_LabelsFolder"], sb.ToString());
		}

		private void ShowHideInCurrentJournalMenus()
		{
			bool b = lstOccurrences.Items.Contains("in '" + (CurrentJournal == null ? "" : CurrentJournal.Name) + "'");
			mnuDelete_InCurrentJournal.Visible = b;
			mnuRename_InCurrentJournal.Visible = b;
		}

		private void ShowHideOccurrences()
		{
			if (lstOccurrences.Items.Count > 0)
			{ lstLabels.Height = 184; }
			else { lstLabels.Height = pnlMain.Height - 30; }
		}

		private void txtLabelName_TextChanged(object sender, EventArgs e)
		{
			btnOK.Visible = Deleting ? true : !lstLabels.Items.Contains(txtLabelName.Text.Trim()); 
			lblTagExists.Visible = !btnOK.Visible; 
		}

		private void txtPIN_KeyUp(object sender, KeyEventArgs e) { if(e.KeyCode == Keys.Enter) { btnAddPIN_Click(null, null); } }

	}
}
