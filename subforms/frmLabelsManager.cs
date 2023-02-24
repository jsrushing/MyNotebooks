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
	public partial class frmLabelsManager : Form
	{
		private bool Renaming	= false;
		private bool Adding		= false;
		private bool Deleting	= false;

		private LabelsManager.LabelsSortType sort	= LabelsManager.LabelsSortType.None;
		private string OriginalPIN					= Program.PIN;
		private Dictionary<string, string> DictJournals = new Dictionary<string, string>();
		private bool EditingAllJournals;
		//private LabelsManager lm = new LabelsManager();

		public bool ActionTaken { get; private set; }

		//private enum LabelsSortType
		//{
		//	Ascending,
		//	Descending,
		//	None
		//}

		private Journal CurrentJournal;

		public frmLabelsManager(Form parent, Journal _jrnl = null)
		{
			InitializeComponent();

			if(_jrnl != null)
			{
				CurrentJournal = _jrnl;
				mnuRename_InCurrentJournal.Text = "In '" + _jrnl.Name + "'";
				mnuDelete_InCurrentJournal.Text = "In '" + _jrnl.Name + "'";
			}
			else 
			{ 
				mnuRename_InCurrentJournal.Visible = false; 
				mnuDelete_InCurrentJournal.Visible = false; 
			}

			Utilities.SetStartPosition(this, parent);
		}

		private void frmLabelsManager_FormClosing(object sender, FormClosingEventArgs e) { Program.PIN = OriginalPIN; }

		private void frmLabelsManager_Load(object sender, EventArgs e)
		{
			this.Size = this.MinimumSize;

			foreach(Control c in this.Controls) if (c.GetType() == typeof(Panel)) c.Location = new Point(0,0);

			ShowPanel(pnlJournalPINs);
			ShowHideOccurrences();

			foreach (Journal j in Utilities.AllJournals()) 
			{
				DictJournals.Add(j.Name, "");
				lstJournalPINs.Items.Add(j.Name); 
			}

			sort = LabelsManager.LabelsSortType.None;
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
			string s = lstJournalPINs.Text.Replace(" (****)", "");
			DictJournals[s] = txtPIN.Text;
			s += " (****)";
			lstJournalPINs.Items.Insert(lstJournalPINs.SelectedIndex, s);
			lstJournalPINs.Items.RemoveAt(lstJournalPINs.SelectedIndex);
			txtPIN.PasswordChar = '\0';
			txtPIN.Text = "(select a Journal)";
			txtPIN.Enabled = false;
			btnAddPIN.Enabled = false;
			lstJournalPINs.SelectedIndex = -1;
			lblShowPIN.Visible = false;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			pnlNewLabelName.Visible = false;
		}

		private void btnExitOrphans_Click(object sender, EventArgs e) { lstOccurrences.Items.Clear(); ShowHideOccurrences(); ShowPanel(pnlMain); }

		private void btnOK_Click(object sender, EventArgs e)
		{
			string sOldLabelName = lstLabels.SelectedItem != null ? lstLabels.SelectedItem.ToString() : string.Empty;
			bool bEdited = true;
			this.Cursor = Cursors.WaitCursor;

			if (Adding) 
			{ 
				AddLabelToUIListbox();
				LabelsManager.Save(lstLabels.Items.Cast<String>().ToList());
				pnlNewLabelName.Visible = false;
				LabelsManager.PopulateLabelsList(null, lstLabels);
				lstOccurrences.Items.Clear();
				ShowHideOccurrences();
				this.Cursor = Cursors.Default; 
			}

			if (Renaming | Deleting)
			{
				List<Journal> journalsToEdit = EditingAllJournals ? Utilities.AllJournals() : new List<Journal>();

				if (journalsToEdit.Count == 0) { journalsToEdit.Add(CurrentJournal); } // would be at least 1 if 'All Journals' was clicked

				foreach (Journal jrnl in journalsToEdit)
				{
					SetProgramPINForSelectedJournal(jrnl);

					List<JournalEntry> lstEntryHasOldLabel = jrnl.Entries.Where(t => ("," + t.ClearLabels() + ",").Contains("," + sOldLabelName + ",")).ToList();

					if (lstEntryHasOldLabel.Count > 0)
					{
						foreach (JournalEntry je in lstEntryHasOldLabel)
						{
							bEdited = je.RemoveOrReplaceLabel(txtLabelName.Text, sOldLabelName, Renaming);
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
						if (LabelsManager.JournalsContainingLabel(txtLabelName.Text).Count == 0) 
						{ 
							lstLabels.Items.RemoveAt(lstLabels.SelectedIndex);
							lstOccurrences.Items.Clear();
							ShowHideOccurrences();
						}
					}

					SaveLabels();
					this.Cursor = Cursors.Default;
				}

				this.Cursor = Cursors.Default;
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

		private void btnPINsOK_Click(object sender, EventArgs e) { ShowPanel(pnlMain); ShowHideOccurrences(); }

		private void btnRemoveSelectedOrphans_Click(object sender, EventArgs e)
		{
			using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Are you sure you want to delete the lables? This action cannot be reversed!", "", this))
			{
				frm.ShowDialog(this);

				if (frm.Result == frmMessage.ReturnResult.Yes)
				{ foreach (string lbl in lstOrphanedLabels.SelectedItems) { LabelsManager.Delete(lbl); } }

				if (lstOrphanedLabels.SelectedItems.Count > 0)
				{
					LabelsManager.PopulateLabelsList(null, lstLabels);
					ShowHideOccurrences();
				}
				lstLabels.SelectedItems.Clear();
				lstOccurrences.Items.Clear();
				ShowPanel(pnlMain);
			}
		}

		private void chkSelectAllOrphans_CheckedChanged(object sender, EventArgs e)
		{
			if (chkSelectAllOrphans.Checked)
			{
				for (int i = 0; i < lstOrphanedLabels.Items.Count; i++) { lstOrphanedLabels.SelectedItems.Add(lstOrphanedLabels.Items[i]); }
			}
			else { lstOrphanedLabels.SelectedItems.Clear(); }
		}

		private void lblSortType_Click(object sender, EventArgs e)
		{
			//LabelsManager lm = new LabelsManager();	
			
			switch (sort)
			{
				case LabelsManager.LabelsSortType.None:
					LabelsManager.PopulateLabelsList(null, lstLabels);
					//Utilities.Labels_PopulateLabelsList(null, lstLabels,
					lblSortType.Text = "sort A-Z";
					sort = LabelsManager.LabelsSortType.Ascending;
					break;
				case LabelsManager.LabelsSortType.Ascending:
					LabelsManager.PopulateLabelsList(null, lstLabels, LabelsManager.LabelsSortType.Descending);
					lblSortType.Text = "sort Z-A";
					sort = LabelsManager.LabelsSortType.Descending;
					break;
				case LabelsManager.LabelsSortType.Descending:
					LabelsManager.PopulateLabelsList(null, lstLabels, LabelsManager.LabelsSortType.Ascending);
					lblSortType.Text = "unsorted";
					sort = LabelsManager.LabelsSortType.None;
					break;
			}
		}

		private void lstJournalPINs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(lstJournalPINs.SelectedIndex > -1)
			{
				txtPIN.PasswordChar = '*';
				txtPIN.Text = DictJournals[lstJournalPINs.Text.Replace(" (****)", "")];
				txtPIN.Enabled = true;
				btnAddPIN.Enabled = true;
				txtPIN.Focus();
				lblShowPIN.Visible = true;
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
				PopulateOccurrences();
				this.FormBorderStyle = FormBorderStyle.Sizable;
			}
		}

		private void lblShowPIN_Click(object sender, EventArgs e)
		{
			txtPIN.PasswordChar = txtPIN.PasswordChar == '*' ? '\0' : '*';
			lblShowPIN.Text = lblShowPIN.Text == "show" ? "hide" : "show";
		}

		private void lstOccurrences_DoubleClick(object sender, EventArgs e)
		{
			int i = lstOccurrences.SelectedIndex;
			KeyValuePair<Journal, JournalEntry> kvp = (KeyValuePair<Journal, JournalEntry>)lstEntryObjects.Items[i];
			Journal j = kvp.Key;
			JournalEntry je = kvp.Value;
			SetProgramPINForSelectedJournal(j);

			using (frmNewEntry frm = new frmNewEntry(this, j, je))
			{ frm.ShowDialog(); if (frm.saved) { PopulateOccurrences(); } }
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
			lblOperation.Text = "Delete this label in " + (EditingAllJournals ? "all journals?" : "'" + this.CurrentJournal.Name) + "'?";
			pnlNewLabelName.Visible = true;
			txtLabelName.Text = lstLabels.SelectedItem.ToString();
			txtLabelName.Enabled = false;
			btnCancel.Focus();
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void mnuFindOrphans_Click(object sender, EventArgs e)
		{
			ShowPanel(pnlOrphanedLabels);
			List<string> lstOrphans = new List<string>();
			lstOrphanedLabels.Items.Clear();

			foreach(string label in LabelsManager.GetLabels_NoFileDate())
			{
				PopulateOccurrences(label);
				if(lstOccurrences.Items.Count == 1) { lstOrphans.Add(label); }
			}

			if(lstOrphans.Count > 0)
			{
				foreach (string lbl in lstOrphans) { lstOrphanedLabels.Items.Add(lbl); }
			}
			else { lstOrphanedLabels.Items.Add("no orphans were found."); }

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

		private void PopulateOccurrences(string labelName = null)
		{
			if (labelName == null)
			{
				if (lstLabels.SelectedItem != null && lstLabels.SelectedItem.ToString().Length > 0)
				{ labelName = lstLabels.SelectedItem.ToString(); }
				else { labelName = string.Empty; }
			}

			if(labelName.Length > 0)
			{
				this.Cursor = Cursors.WaitCursor;
				lstOccurrences.Items.Clear();
				var currentPIN = Program.PIN;
				List<Journal> journalsWithLabel = LabelsManager.JournalsContainingLabel(labelName);	// lm.JournalsContainingLabel(labelName);

				if (journalsWithLabel.Count > 0)
				{
					foreach (Journal jrnl in journalsWithLabel)
					{
						SetProgramPINForSelectedJournal(jrnl);
						List<JournalEntry> foundLables = jrnl.Entries.Where(t => ("," + t.ClearLabels() + ",").Contains("," + labelName + ",")).ToList();

						if (foundLables.Count > 0)
						{
							lstOccurrences.Items.Add("in '" + jrnl.Name + "'");
							lstEntryObjects.Items.Add("");

							foreach (JournalEntry je in foundLables) 
							{
								lstOccurrences.Items.Add("   > " + je.ClearTitle());
								lstEntryObjects.Items.Add(new KeyValuePair<Journal, JournalEntry>(jrnl, je));
							}
							
							lstOccurrences.Items.Add("-----------------------");
							lstEntryObjects.Items.Add("");
						}
					}
				}

				if (lstOccurrences.Items.Count == 0) { lstOccurrences.Items.Add("No occurrences found (are you missing a PIN?)"); }

				Program.PIN = currentPIN;
			}
			else { lstOccurrences.Items.Clear(); }

			ShowHideOccurrences();
			ShowHideInCurrentJournalMenus();
			this.Cursor = Cursors.Default;
		}

		private void SaveLabels() { LabelsManager.Save(lstLabels.Items.OfType<string>().ToList()); }

		private void SetProgramPINForSelectedJournal(Journal journal) { Program.PIN = DictJournals[journal.Name]; }

		private void ShowPanel(Panel panelToShow)
		{
			foreach (Control c in this.Controls) { if (c.GetType() == typeof(Panel)) { c.Visible = false; } }

			if(panelToShow == pnlMain)
			{
				panelToShow.Top = 25;
				mnuMain.Visible = true;
			}
			else { mnuMain.Visible = false; }

			panelToShow.Visible = true;
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
			{ lstLabels.Height = pnlMain.Height - 340; lstOccurrences.Height = pnlMain.Height - 300; lstOccurrences.Visible = true; }
			else { lstLabels.Height = pnlMain.Height - 100; lstOccurrences.Visible = false; }
		}

		private void txtLabelName_TextChanged(object sender, EventArgs e)
		{
			btnOK.Visible = Deleting ? true : !lstLabels.Items.Contains(txtLabelName.Text.Trim()); 
			lblLabelExists.Visible = !btnOK.Visible; 
		}

		private void txtPIN_KeyUp(object sender, KeyEventArgs e) { if(e.KeyCode == Keys.Enter) { btnAddPIN_Click(null, null); } }
	}
}