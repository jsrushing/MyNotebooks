using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using myJournal.subforms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmMain : Form
	{
		Journal currentJournal;
		JournalEntry currentEntry;

		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			LoadJournals();
		}

		private void frmMain_Resize(object sender, EventArgs e)
		{
			if (!rtbSelectedEntry.Visible)
			{
				lstEntries.Height = this.Height - 170;
				lstEntries.Width = this.Width - 40;
			}
		}

		private void btnLoadJournal_Click(object sender, EventArgs e)
		{
			lstEntries.Items.Clear();
			rtbSelectedEntry.Text = string.Empty;
			Program.PIN = txtJournalPIN.Text;
			lblWrongPin.Visible = false;

			try
			{
				currentJournal = new Journal(ddlJournals.Text).Open(ddlJournals.Text);

				if (currentJournal != null)
				{
					PopulateEntries();

					if(lstEntries.Items.Count > 0)
					{
						lblSelectAJournal.Enabled = true;
						lblSelectAJournal.Text = "Entries";
						lstEntries.Height = this.Height - lstEntries.Top - 50;
						lbl1stSelection.Text = "1";
						lstEntries.Visible = true;
						ShowHideJournalMenus(true);
					}
					else
					{
						lblWrongPin.Visible = true;
						lstEntries.Visible = false;
					}	
				}
				else
				{
					lstEntries.Focus();
				}
			}
			catch (Exception) { }
		}

		private void ddlJournals_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnLoadJournal.Enabled = true;
			txtJournalPIN.Text = string.Empty;
			lstEntries.Items.Clear();
			lstEntries.Visible = false;
			txtJournalPIN.Focus();
			rtbSelectedEntry.Text = string.Empty;
			ShowHideEntriesArea(false);
			ShowHideJournalMenus(false);
		}

		private void lstEntries_SelectEntry(object sender, EventArgs e)
		{
			ListBox lb = (ListBox)sender;
			RichTextBox rtb = rtbSelectedEntry;
			rtb.Clear();
			List<int> targets = new List<int>();
			lb.SelectedIndexChanged -= new System.EventHandler(this.lstEntries_SelectEntry);

			try
			{
				if (lb.SelectedIndices.Count > 1)
				{
					for (int i = 0; i < lb.SelectedIndices.Count - 1; i++)
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
				foreach (int i in targets)
				{
					lb.SelectedIndices.Remove(i);
				}
			}

			int ctr = lb.SelectedIndex;

			if (lb.Items[ctr].ToString().StartsWith("--")) ctr--;

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

			// this is where you have to account for isEdited

			string sTitleAndDate = lb.Items[ctr].ToString().Replace(" - EDITED", "");        // Use the title and date of the entry to create a JournalEntry object whose .ClearText will populate the display ...
			string sTitle = sTitleAndDate.Substring(0, sTitleAndDate.IndexOf('(') - 1);
			string sDate = sTitleAndDate.Substring(sTitleAndDate.IndexOf('(') + 1, sTitleAndDate.Length - 2 - sTitleAndDate.IndexOf('('));

			currentEntry = currentJournal.GetEntry(sTitle, sDate);

			if (currentEntry != null)
			{
				StringBuilder sb = new StringBuilder();
				rtb.Text = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
					, currentEntry.ClearTitle(), currentEntry.Date
					, currentEntry.ClearTags()
					, currentEntry.ClearText());
				if (rtb.Text.Length == 0) { lstEntries.TopIndex = lstEntries.Top + lstEntries.Height < rtbSelectedEntry.Top ? ctr : lstEntries.TopIndex; }
				lblPrint.Visible = rtb.Text.Length > 0;
				grpSelectedEntryLabels.Visible = rtb.Text.Length > 0;
				lblSeparator.Visible = rtb.Text.Length > 0;
				lblSelectionType.Text = "Selected Entry";
				lstEntries.Height = rtb.Text.Length > 0 ? rtbSelectedEntry.Top - 132 : 100;

				if (lbl1stSelection.Text.Equals("1"))
				{
					lstEntries.TopIndex = lstEntries.Top + lstEntries.Height < rtbSelectedEntry.Top ? ctr : lstEntries.TopIndex;
					lbl1stSelection.Text = "0";
				}

				ResizeListsAndRTBs();
			}

			lb.SelectedIndexChanged += new System.EventHandler(this.lstEntries_SelectEntry);
			rtbSelectedEntry.Visible = rtbSelectedEntry.Text.Length > 0;			
		}

		private void lblSeparator_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				lblSeparator.Top += e.Y;
				ResizeListsAndRTBs();
				lstEntries.TopIndex = lstEntries.SelectedIndices[0];
			}
		}

		private void mnuEntryCreate_Click(object sender, EventArgs e)
		{
			frmNewEntry frm = new frmNewEntry();
			Utilities.Showform(frm, this);
			if(frm.entry != null)
			{
				currentJournal.AddEntry(frm.entry);
				currentJournal.Save();
				PopulateEntries();
			}
			frm.Close();
		}

		private void mnuJournal_Create_Click(object sender, EventArgs e)
		{
			frmNewJournal frm = new frmNewJournal();
			Utilities.Showform(frm, this);
			Program.PIN = frm.sPIN == null ? string.Empty : frm.sPIN;
			string name = frm.sJournalName == null ? string.Empty : frm.sJournalName;
			frm.Close();

			if (name.Length > 0){
				Journal j = new Journal(name);
				j.Create();
				LoadJournals();
			}
		}

		private void mnuJournal_Delete_Click(object sender, EventArgs e)
		{
			frmConfirmDeleteJournal frm = new frmConfirmDeleteJournal(currentJournal);
			Utilities.Showform(frm, this);
			if (frm.deleted)
			{
				currentJournal = null;
				ddlJournals.Text = string.Empty;
				lstEntries.Items.Clear();
				LoadJournals();
			}
		}

		private void mnuSearch_Click(object sender, EventArgs e)
		{
			frmSearch frm = new frmSearch(currentJournal.Entries);
			Utilities.Showform(frm, this);
		}

		private void LoadJournals()
		{
			string rootPath = AppDomain.CurrentDomain.BaseDirectory;
			ddlJournals.Items.Clear();

			if (!Directory.Exists(rootPath + "/journals/"))
			{
				Directory.CreateDirectory(rootPath + "/journals/");
				Directory.CreateDirectory(rootPath + "/settings/");
				File.Create(rootPath + "/settings/settings");
				File.Create(rootPath + "/settings/groups");
			}
			else
			{
				foreach (string s in Directory.GetFiles(rootPath + "/journals/"))
				{
					ddlJournals.Items.Add(s.Replace(rootPath + "/journals/", ""));
				}
			}
			ddlJournals.Enabled = ddlJournals.Items.Count > 0;
			ddlJournals.SelectedIndex = ddlJournals.Items.Count == 1 ? 0 : -1;
			btnLoadJournal.Enabled = false;
			txtJournalPIN.Text = string.Empty;
			lstEntries.Visible = false;
			ShowHideEntriesArea(false);
			ShowHideJournalMenus(false);
		}

		private void PopulateEntries(List<JournalEntry> entries = null)
		{
			entries = entries != null ? currentJournal.Entries : null;
			lstEntries.Items.Clear();			

			foreach (JournalEntry je in currentJournal.Entries)
			{
				foreach(string s in je.EntryAsList(lstEntries.Width))
				{
					lstEntries.Items.Add(s);
				}
			}

			lstEntries.Height = this.Height - lstEntries.Top - 50;
			ShowHideEntriesArea(false);
		}

		private void ResizeListsAndRTBs()
		{
			int iBoxCenter = lstEntries.Width / 2;
			lblSeparator.Visible = true;
			rtbSelectedEntry.Visible = true;
			lblSeparator.Left = lstEntries.Left + 10;
			lblSeparator.Width = lstEntries.Width - 20;
			lstEntries.Height = lblSeparator.Top - lstEntries.Top - 5;
			grpSelectedEntryLabels.Top = lblSeparator.Top + lblSeparator.Height + 10;
			rtbSelectedEntry.Top = grpSelectedEntryLabels.Top + grpSelectedEntryLabels.Height - 20;
			rtbSelectedEntry.Height = this.Height - rtbSelectedEntry.Top - 50;
		}

		private void ShowHideEntriesArea(bool show)
		{
			rtbSelectedEntry.Visible = show;
			lblSeparator.Visible = show;
			lblSelectionType.Visible = false;
		}

		private void ShowHideJournalMenus(bool show)
		{
			mnuEntryTop.Enabled = show;
			mnuJournal_Delete.Enabled = show;
			mnuSearch.Enabled = show;
		}

		protected override CreateParams CreateParams {
			get {
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}
	}
}
