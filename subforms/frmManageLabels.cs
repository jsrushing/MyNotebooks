/* Manage labels.
 * 7/9/22
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
	public partial class frmManageLabels : Form
	{
		private bool Renaming = false;
		private bool Adding = false;
		private bool Deleting = false;
		private bool EditingAllJournals;
		public bool ActionTaken { get; private set; }
		private Journal CurrentJournal;

		public frmManageLabels(Journal _jrnl = null)
		{
			InitializeComponent();

			if(_jrnl != null)
			{
				CurrentJournal = _jrnl;
				mnuRename_InCurrentJournal.Text = "In " + CurrentJournal.Name + " only";
			}
			else { mnuRename_InCurrentJournal.Visible = false; }
		}

		private void frmManageLabels_Load(object sender, EventArgs e)
		{
			Utilities.PopulateLabelsList(null, lstLabels);
			this.Size = this.MinimumSize;
			pnlNewLabelName.Location = new Point(0, 0);
			pnlNewLabelName.Size = this.Size;
			pnlJournalPINs.Location = pnlMain.Location;
			pnlJournalPINs.Visible = true;
			pnlMain.Visible = false;
			mnuMain.Visible = false;
			foreach (Journal j in Utilities.AllJournals()) { lstJournalPINs.Items.Add(j.Name); }
		}

		private void AddLabel()
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

			if (Adding) { AddLabel(); SaveLabels(); Utilities.PopulateLabelsList(null, lstLabels); }

			if (Renaming | Deleting)
			{
				List<Journal> journalsToEdit = EditingAllJournals ? Utilities.AllJournals() :  new List<Journal>();

				if (journalsToEdit.Count == 0) { journalsToEdit.Add(CurrentJournal); } // would be at least 1 if 'All Journals' was clicked

				foreach (Journal jrnl in journalsToEdit)
				{
					SetPINForJournal(jrnl);
					
					List<JournalEntry> lstEntryHasOldTag = jrnl.Entries.Where(t => ("," + t.ClearTags() + ",").Contains("," + sOldTagName + ",")).ToList();

					if (lstEntryHasOldTag.Count > 0)
					{
						foreach (JournalEntry je in lstEntryHasOldTag)
						{
							bEdited = Renaming ? je.ReplaceTag(sOldTagName, txtLabelName.Text) : je.RemoveTag(sOldTagName);
							if (bEdited) { jrnl.Save(); }
						}
					}
				}

				if (bEdited) 
				{
					if (Renaming)
					{
						if (EditingAllJournals)	// it was a global change - the old label doesn't exist in any entry in any journal so remove it from the Labels file
						{
							lstLabels.Items.Insert(lstLabels.SelectedIndex, txtLabelName.Text);
							lstLabels.Items.RemoveAt(lstLabels.SelectedIndex);
						}
						else { AddLabel(); }    // the old label might exist in other entries, so add the new label only to the Labels file
					}
					else	// It was a delete. Global by default. No instances exist so just remove from list.
					{
						lstLabels.Items.RemoveAt(lstLabels.SelectedIndex);
					}
				}
			}

			if (bEdited) SaveLabels();
			ActionTaken = bEdited;
			Adding = false;
			Deleting = false;
			Renaming = false;
			txtLabelName.Enabled = true;
			txtLabelName.Text = string.Empty;
			pnlNewLabelName.Visible = false;
		}

		private void btnPINsOK_Click(object sender, EventArgs e)
		{
			pnlJournalPINs.Visible = false;
			pnlMain.Visible = true;
			mnuMain.Visible = true;
		}

		private void SetPINForJournal(Journal journal)
		{
			string sPIN = string.Empty;
			string sJrnlPin = lstJournalPINs.Items.OfType<string>().ToArray().Single(x => x.StartsWith(journal.Name));
			sPIN = sJrnlPin.Contains("|") ? sJrnlPin.Substring(sJrnlPin.IndexOf("|") + 1) : string.Empty;
			Program.PIN = sPIN;
		}

		private void lstJournalPINs_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtPIN.Text = string.Empty;
			txtPIN.Enabled = true;
			btnAddPIN.Enabled = true;
			txtPIN.Focus();
		}

		private void lstLabels_SelectedIndexChanged(object sender, EventArgs e)
		{
			mnuRename.Enabled = true;
			mnuDelete.Enabled = true;
			mnuMoveTop.Enabled = true;
			mnuMoveUp.Enabled = lstLabels.SelectedIndex > 0;
			mnuMoveDown.Enabled = lstLabels.SelectedIndex != lstLabels.Items.Count - 1;
			lstOccurrences.Items.Clear();
		}

		private void mnuAdd_Click(object sender, EventArgs e)
		{
			Adding = true;
			lblOperation.Text = "Label Name:";
			pnlNewLabelName.Visible = true;
			txtLabelName.Focus();
		}

		private void mnuAssignPINs_Click(object sender, EventArgs e)
		{
			pnlMain.Visible = false;
			pnlJournalPINs.Visible = true;

			if(lstJournalPINs.Items.Count == 0)
			{ foreach(Journal j in Utilities.AllJournals()) { lstJournalPINs.Items.Add(j.Name); } }
		}

		private void mnuDelete_Click(object sender, EventArgs e)
		{
			Deleting = true;
			EditingAllJournals = true;
			lblOperation.Text = "Delete Label? ";
			pnlNewLabelName.Visible = true;
			txtLabelName.Text = lstLabels.SelectedItem.ToString();
			txtLabelName.Enabled = false;
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void mnuFindAll_Click(object sender, EventArgs e)
		{
			PopulateOccurrences();
		}

		private void mnuMoveUp_Click(object sender, EventArgs e)
		{
			string sLbl = lstLabels.SelectedItem.ToString();
			int selIndx = lstLabels.SelectedIndex;
			lstLabels.Items.RemoveAt(selIndx);
			lstLabels.Items.Insert(selIndx - 1, sLbl);
			lstLabels.SelectedIndex = selIndx - 1;
		}

		private void mnuMoveDown_Click(object sender, EventArgs e)
		{
			string sLbl = lstLabels.SelectedItem.ToString();
			int selIndx = lstLabels.SelectedIndex;
			lstLabels.Items.RemoveAt(selIndx);
			lstLabels.Items.Insert(selIndx + 1, sLbl);
			lstLabels.SelectedIndex = selIndx + 1;
		}

		private void mnuRename_Click(object sender, EventArgs e)
		{
			Renaming = true;
			EditingAllJournals = ((ToolStripMenuItem)sender).Text.ToLower().StartsWith("in all");
			lblOperation.Text = "New Label Name:";
			txtLabelName.Text = lstLabels.SelectedItem.ToString();
			pnlNewLabelName.Visible = true;
			txtLabelName.Focus();
			txtLabelName.SelectAll();
		}

		private void PopulateOccurrences()
		{
			string sTagName = lstLabels.SelectedItem.ToString();
			lstOccurrences.Items.Clear();
			this.Cursor = Cursors.WaitCursor;
			List<JournalEntry> foundItems_Loop = new List<JournalEntry>();
			List<JournalEntry> foundItems;
			string sPIN = string.Empty;

			if (sTagName.Length > 0)
			{
				foreach(Journal jrnl in Utilities.AllJournals())
				{
					SetPINForJournal(jrnl);
					foundItems = jrnl.Entries.Where(t => ("," + t.ClearTags() + ",").Contains("," + sTagName + ",")).ToList();

					if (foundItems.Count > 0)
					{
						lstOccurrences.Items.Add("in '" + jrnl.Name + "'");
						foreach (JournalEntry je in foundItems) { lstOccurrences.Items.Add("   > " + je.ClearTitle()); }
						lstOccurrences.Items.Add("-----------------------");
					}
				}
			}
			if(lstOccurrences.Items.Count == 0) { lstOccurrences.Items.Add("No occurrences found"); }
			this.Cursor = Cursors.Default;
		}

		private void SaveLabels()
		{
			StringBuilder sb = new StringBuilder();
			string[] arrTags = lstLabels.Items.OfType<string>().ToArray();
			Array.Sort(arrTags, (x, y) => x.CompareTo(y));
			foreach (string tag in arrTags) { sb.AppendLine(tag); }
			File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_LabelsFile"], sb.ToString());
		}

	}
}
