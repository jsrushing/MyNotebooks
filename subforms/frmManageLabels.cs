/* Manage labels.
 * 7/9/22
 */
using System;
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
		}

		private void AddLabel()
		{
			if (txtLabelName.Text.Length > 0)
			{
				lstLabels.Items.Add(txtLabelName.Text);
			}
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			pnlNewLabelName.Visible = false;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			string sOldTagName = lstLabels.SelectedItem != null ? lstLabels.SelectedItem.ToString() : string.Empty;
			bool bEdited = false;

			if (Adding)
			{
				AddLabel();
				SaveLabels();
				Adding = false;
			}

			if (Renaming | Deleting)
			{
				List<Journal> journalsToEdit = EditingAllJournals ? Utilities.AllJournals() :  new List<Journal>();

				if (journalsToEdit.Count == 0)	// would be at least 1 if 'All Journals' was clicked
				{ 
					journalsToEdit.Add(CurrentJournal); 
				}

				foreach (Journal jrnl in journalsToEdit)
				{
					List<JournalEntry> lstEntryHasOldTag = jrnl.Entries.Where(t => t.ClearTags().Contains(sOldTagName)).ToList();

					if (lstEntryHasOldTag.Count > 0)
					{
						foreach (JournalEntry je in lstEntryHasOldTag)
						{
							if (Renaming)
							{ bEdited = je.ReplaceTag(sOldTagName, txtLabelName.Text); }
							else { bEdited = je.RemoveTag(sOldTagName); }

							if (bEdited) { jrnl.Save(); }
						}
					}
				}

				if (bEdited) 
				{
					if (Renaming)
					{
						if (journalsToEdit.Count > 1)	// it was a global change - the old label doesn't exist in any entry
						{
							lstLabels.Items.Insert(lstLabels.SelectedIndex, txtLabelName.Text);
							lstLabels.Items.RemoveAt(lstLabels.SelectedIndex);
						}
						else { AddLabel(); }    // the old label might exist in other entries, so add the new one only

						Renaming = false;
					}
					else
					{
						lstLabels.Items.RemoveAt(lstLabels.SelectedIndex);
						Deleting = false;
						ActionTaken = true;
					}
				}

				Renaming = false;
			}

			if (bEdited) SaveLabels();
			ActionTaken = bEdited;
			txtLabelName.Enabled = true;
			txtLabelName.Text = string.Empty;
			pnlNewLabelName.Visible = false;
		}

		private void mnuAdd_Click(object sender, EventArgs e)
		{
			Adding = true;
			lblOperation.Text = "Label Name:";
			pnlNewLabelName.Visible = true;
			txtLabelName.Focus();
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
			EditingAllJournals = ((ToolStripMenuItem)sender).Text.ToLower().StartsWith("all");
			lblOperation.Text = "New Label Name:";
			txtLabelName.Text = lstLabels.SelectedItem.ToString();
			pnlNewLabelName.Visible = true;
			txtLabelName.Focus();
			txtLabelName.SelectAll();
		}

		private void lstLabels_SelectedIndexChanged(object sender, EventArgs e)
		{
			mnuRename.Enabled = true;
			mnuDelete.Enabled = true;
			mnuMoveTop.Enabled = true;
			mnuMoveUp.Enabled = lstLabels.SelectedIndex > 0;
			mnuMoveDown.Enabled = lstLabels.SelectedIndex != lstLabels.Items.Count - 1;
		}

		private void SaveLabels()
		{
			string[] tags = lstLabels.Items.OfType<string>().ToArray();
			StringBuilder sb = new StringBuilder();
			foreach (string s in tags) { sb.AppendLine(s); }
			File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/settings/labels", sb.ToString());
		}
	}
}
