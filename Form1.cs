using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace myJournal
{
	public partial class Form1 : Form
    {
        Point ActiveBoxLocation = new Point(12, 0);
        Size ActiveBoxSize = (Size)new Point(290, 545);
        Size MainFormSize = (Size)new Point(331, 592);
        GroupBox DisplayedGroupBox;
        Journal currentJournal = null;
        bool bGroupBeingEdited = false;
        string rootPath = AppDomain.CurrentDomain.BaseDirectory;
        JournalEntry currentEntry = null;
        Font InactiveMenuFont = null;
        Font ActiveMenuFont = null;

        public Form1()
        { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            grpOpenScreen.Location = ActiveBoxLocation;
            grpOpenScreen.Size = ActiveBoxSize;
            LoadJournals();
            DisplayedGroupBox = grpOpenScreen;
            this.Size = MainFormSize;

            pnlMenu.Size = new Size(lblMenu_1.Width + 2, lblMenu_1.Height + 2);
            lblMenu_0.Size = new Size(pnlMenu.Width, pnlMenu.Height);
            lblMenu_1.Size = new Size(lblMenu_0.Width - 4, lblMenu_1.Height - 2);
            lblMenu_1.Location = new Point(lblMenu_0.Left + 2, lblMenu_0.Top + 2);
            InactiveMenuFont = lblJournal_Create.Font;
            ActiveMenuFont = new Font(InactiveMenuFont, FontStyle.Bold | FontStyle.Underline);
            ActivateGroupBox(grpOpenScreen);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            DisplayedGroupBox.Location = ActiveBoxLocation;
            DisplayedGroupBox.Size = new Size(this.Width - 35, this.Height - 50);
        }


        /// <summary>
        /// Show a group box. Change form Text, set focus, etc. as required for that group box.
        /// </summary>
        /// <param name="box"></param>
        private void ActivateGroupBox(GroupBox box)
        {
            TextBox txtBxToFocus = null;

            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name.ToLower() == "groupbox")
                {
                    ((GroupBox)c).Visible = false;

                }
            }

            switch (box.Name)
            {
                case "grpOpenScreen":
                    this.Text = "My Journal";
                    rtbSelectedEntry_Main.Clear();
                    break;
                case "grpCreateEntry":
					btnAddEntry.Text = "Save Entry";
                    this.Text = "Create Entry";
                    txtNewEntryTitle.Text = String.Empty;
                    rtbNewEntry.Clear();
                    grpAppendDeleteOriginal.Visible = false;
                    txtBxToFocus = this.txtNewEntryTitle;
                    if(lstTags.Items.Count == 0) { Groups_PopulateGroupsList(lstTags); }
					foreach(int i in lstTags.CheckedIndices) { lstTags.SetItemChecked(i, false); }
                    break;
                case "grpFindEntry":
                    this.Text = "Search Journal";
                    Groups_PopulateGroupsList(lstGroupsForSearch);
                    txtGroupsForSearch.Text = Properties.Settings.Default["TxtSelectGroupsForSearchDefault"].ToString();
                    break;
                case "grpNewJournal":
                    this.Text = "Create New Journal";
                    txtBxToFocus = this.txtNewJournalName;
                    break;
                case "grpNewGroup":
                    this.Text = "Create New Group";
                    txtBxToFocus = this.txtNewGroup;
                    break;
                case "grpDeleteJournal":
                    lblDelete_Confirm.Visible = false;
                    lblDelete_Confirm.Text = " will be deleted. Press Delete to confirm.";
                    ddlJournalsToDelete.Visible = true;
                    lblJournalToDelete.Visible = true;
                    ddlJournalsToDelete.Text = ddlJournals.Text.Length > 0 ? ddlJournals.Text : String.Empty;
                    break;
            }

            pnlMenu.Visible = false;
            box.Location = ActiveBoxLocation;
            //box.Size = new Size(this.Width - 20, this.Height - 20);
            box.Visible = true;
            if (txtBxToFocus != null) txtBxToFocus.Focus();
            DisplayedGroupBox = box;
            this.Height += 1;
        }

		#region Buttons
		/// <summary>
		/// Add the new entry.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddEntry_Click(object sender, EventArgs e)
        {
            if (rtbNewEntry.Text.Length > 0 && txtNewEntryTitle.Text.Length > 0)
            {
                string sGroups = string.Empty;

                for (int i = 0; i < lstTags.CheckedItems.Count; i++)
                {
                    sGroups += lstTags.CheckedItems[i].ToString() + ",";
                }
                sGroups = sGroups.Length > 0 ? sGroups.Substring(0, sGroups.Length - 1) : string.Empty;
                
				if (grpAppendDeleteOriginal.Visible)
				{
                    string sTitle = txtNewEntryTitle.Text;
                    string sText = rtbNewEntry.Text + " ";

                    if (radOriginal_Append.Checked)
					{
						sTitle = txtNewEntryTitle.Text;	// txtNewEntryTitle.Text == lblEntryTitle_Hidden.Text ? 
							//txtNewEntryTitle.Text : 
							//txtNewEntryTitle.Text = txtNewEntryTitle.Text; 
					}
					else
					{
						sTitle = lblEntryTitle_Hidden.Text;
                        sText = lblEntryText_Hidden.Text;
					}

					currentJournal.ReplaceEntry(currentEntry, new JournalEntry(sTitle, sText, sGroups));
				}
				else
				{
					JournalEntry je = new JournalEntry(txtNewEntryTitle.Text, rtbNewEntry.Text, sGroups);
                    currentJournal.Entries.Add(je);
				}

                currentJournal.SaveToDisk();
                PopulateEntries(lstEntries, currentJournal.Entries);
            }

            txtNewEntryTitle.Text = String.Empty;
            rtbNewEntry.Clear();
            foreach(int i in lstTags.CheckedIndices) { lstTags.SetItemChecked(i, false); }
            ActivateGroupBox(grpOpenScreen);
        }

        /// <summary>
        /// Deleting Journal - either show confirmation or delete journal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_DeleteJournal_Click(object sender, EventArgs e)
        {
            if (lblDelete_Confirm.Visible)
            {
                if (currentJournal == null) { new Journal(ddlJournalsToDelete.Text).OpenJournal().Delete(); } else { currentJournal.Delete(); }
                currentJournal = null;
                LoadJournals();
                ddlJournals.Text = String.Empty;
                lstEntries.Items.Clear();
                rtbSelectedEntry_Main.Text = String.Empty;
                ActivateGroupBox(grpOpenScreen);
            }
            else
            {
                lblDelete_Confirm.Location = new Point(grpDeleteJournal.Width/2 - lblDelete_Confirm.Width / 2, lblDelete_Confirm.Top);
                lblDelete_Confirm.Text = ddlJournalsToDelete.Text + lblDelete_Confirm.Text;
                ddlJournalsToDelete.Visible = false;
                lblJournalToDelete.Visible = false;
                lblDelete_Confirm.Visible = true;
            }
        }

        /// <summary>
        /// Create the new journal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_NewJrnl_Click(object sender, EventArgs e)
        {
            Journal jrnl = new Journal(txtNewJournalName.Text);
            jrnl.CreateJournal();
            LoadJournals();
            ActivateGroupBox(grpOpenScreen);
        }
        #endregion

        /// <summary>
        /// Load the selected journal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void ddlJournals_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstEntries.Items.Clear();
            rtbSelectedEntry_Main.Text = string.Empty;
            currentJournal = new Journal(ddlJournals.Text).OpenJournal();
            PopulateEntries(lstEntries, currentJournal.Entries);
            lblCreateEntry.Enabled = true; 
            lblFindEntry.Enabled = true;
        }

        #region Groups

        private void Groups_btnAddGroup_Click(object sender, EventArgs e)
        { ActivateGroupBox(grpNewGroup); }

        private void Groups_btnOK_NewGroup_Click(object sender, EventArgs e)
        {
            if (!bGroupBeingEdited)
            {
                using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "/settings/groups"))
                {
                    sw.WriteLine(txtNewGroup.Text);
                }
            }
            else
            {
                int i = lstTags.SelectedIndex;
                lstTags.Items.RemoveAt(i);
                lstTags.Items.Insert(i, txtNewGroup.Text);
                Groups_Save();
            }

            txtNewGroup.Text = string.Empty;
            Groups_PopulateGroupsList(lstTags);
            ActivateGroupBox(grpCreateEntry);
            bGroupBeingEdited = false;
        }

        private void Groups_mnuEdit_Click(object sender, EventArgs e)
        {
            txtNewGroup.Text = lstTags.SelectedItem.ToString();
            bGroupBeingEdited = true;
            ActivateGroupBox(grpNewGroup);
        }

        private void Groups_mnuDelete_Click(object sender, EventArgs e)
        {
            lstTags.Items.RemoveAt((int)lstTags.SelectedIndex);
            Groups_Save();
            Groups_PopulateGroupsList(lstTags);
            ActivateGroupBox(grpCreateEntry);
        }

        private void Groups_mnuGroups_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = lstTags.SelectedIndices.Count == 0;
        }

        private void Groups_PopulateGroupsList(CheckedListBox clb)
        {
            clb.Items.Clear();

            foreach (string group in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/settings/groups"))
            {
                clb.Items.Add(group);
            }
        }

        private void Groups_Save()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string s in lstTags.Items)
            {
                sb.AppendLine(s);
            }

            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/settings/groups", sb.ToString());
        }
        #endregion

        #region Clickable Labels

        private void lblCloseMenu_Click(object sender, EventArgs e) { pnlMenu.Visible = false; }

        private void lblCreateEntry_Click(object sender, EventArgs e) { ActivateGroupBox(grpCreateEntry); }

        /// <summary>
        /// Delete an entry (on grpNewEnty, available during edit).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDeleteEntry_Click(object sender, EventArgs e)
        { 
        
        }

        /// <summary>
        /// Show the delete journal controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblJournal_Delete_Click(object sender, EventArgs e)
        {
            foreach (string s in ddlJournals.Items)
            {
                ddlJournalsToDelete.Items.Add(s);
            }
            ActivateGroupBox(grpDeleteJournal);
        }

        /// <summary>
        /// Edit an entry (available during edit).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblEditEntry_Click(object sender, EventArgs e)
        {
            ActivateGroupBox(grpCreateEntry);
			btnAddEntry.Text = "Save Edit";
			txtNewEntryTitle.Text = currentEntry.ClearTitle();
            lblEntryText_Hidden.Text = currentEntry.ClearText();
            lblEntryTitle_Hidden.Text = currentEntry.ClearTitle();
            string newLine = System.Environment.NewLine;
            rtbNewEntry.Text = newLine + newLine + 
                " Original Date: " + currentEntry.Date.ToString("dd/M/yy H:m:s") + newLine +
                "Title: " + currentEntry.ClearTitle() + newLine + 
                "Entry:" + newLine + currentEntry.ClearText();
            rtbNewEntry.Focus();
            rtbNewEntry.SelectionStart = 0; 
			grpAppendDeleteOriginal.Visible = true;
            foreach (int i in lstTags.CheckedIndices) { lstTags.SetItemChecked(i, false); }
            if(currentEntry.ClearTags().Length > 0)
			{
                foreach (string s in currentEntry.ClearTags().Split(','))
                {
                    int index = lstTags.FindString(s);
                    if (index > -1) { lstTags.SetItemChecked(index, true); }
                }
			}
        }

        private void lblFindEntry_Click(object sender, EventArgs e) { ActivateGroupBox(grpFindEntry); }

        /// <summary>
        /// Search for entries with various criteria.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblFindEntries_Click(object sender, EventArgs e)
        {
            List<JournalEntry> foundEntries = new List<JournalEntry>();
            List<string> journalNames = new List<string>();
            lstFoundEntries.Items.Clear();

            if (radCurrentJournal.Checked)
            {
                journalNames.Add(ddlJournals.Text);
            }
            else
            {
                for (int i = 0; i < ddlJournals.Items.Count; i++)
                {
                    journalNames.Add(ddlJournals.Items[i].ToString());
                }
            }

            Journal j = new Journal();
            Journal journalToSearch = new Journal();

            foreach (string journalName in journalNames)
            {
                journalToSearch = j.OpenJournal(journalName);

                foreach (JournalEntry je in journalToSearch.Entries)
                {
                    // date
                    if (chkUseDate.Checked)
                    {
                        if (je.Date == dtFindDate.Value)
                        {
                            foundEntries.Add(je);
                        }
                    }
                    if (chkUseDateRange.Checked)
                    {
                        if (je.Date >= dtFindDate_From.Value && je.Date <= dtFindDate_To.Value)
                        {
                            foundEntries.Add(je);
                        }
                    }
                    // tags
                    if (txtGroupsForSearch.Text != Properties.Settings.Default["TxtSelectGroupsForSearchDefault"].ToString())
                    {
                        string[] groups = txtGroupsForSearch.Text.Split(',');
                        foreach (string group in groups)
                        {
                            if (je.ClearTags().Contains(group)) { foundEntries.Add(je); }
                        }
                    }
                    // title contains
                    if (txtSearchTitle.TextLength > 0) { if (je.ClearTitle().Contains(txtSearchTitle.Text)) { foundEntries.Add(je); } }
                    // entry contains
                    if (txtSearchText.TextLength > 0) { if (je.ClearText().Contains(txtSearchText.Text)) { foundEntries.Add(je); } }
                }
            }

            if (foundEntries.Count > 0)
            {
                PopulateEntries(lstFoundEntries, foundEntries);
            }

        }

        private void lblSettings_Click(object sender, EventArgs e) { }

        private void lblHome_Click(object sender, EventArgs e) { ActivateGroupBox(grpOpenScreen); }

        /// <summary>
        /// Reset search criteria.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblClearAll_Click(object sender, EventArgs e) 
        {  
            dtFindDate.Value = DateTime.Now;
            dtFindDate_From.Value = DateTime.Now;
            dtFindDate_To.Value = DateTime.Now;
            radCurrentJournal.Checked = true;
            txtGroupsForSearch.Text = String.Empty;
            txtSearchTitle.Text = String.Empty; 
            txtSearchText.Text = String.Empty;  
            lstFoundEntries.Items.Clear();
            rtbSelectedEntry_Found.Clear();
        }
		#endregion

		/// <summary>
		/// If no journals exist, create system folders. Otherwise populate ddlJournals with journal names.
		/// </summary>
		private void LoadJournals()
        {
            ddlJournals.Items.Clear();

            string sDir = AppDomain.CurrentDomain.BaseDirectory;

            if (!Directory.Exists(sDir + "/journals/"))
            {
                Directory.CreateDirectory(sDir + "/journals/");
                Directory.CreateDirectory(sDir + "/settings/");
                File.Create(sDir + "/settings/settings");
                File.Create(sDir + "/settings/groups");
            }
            else
            {
                foreach(string s in Directory.GetFiles(sDir + "/journals/"))
                {
                    ddlJournals.Items.Add(s.Replace(sDir + "/journals/", ""));
                }
            }

            if(ddlJournals.Items.Count == 0)
            {
                ddlJournals.Items.Add("click '+' to create a journal >>");
                ddlJournals.Enabled = false;
                ddlJournals.SelectedIndex = 0;
            }
            else
            {
                ddlJournals.Enabled = true;
            }

            if(ddlJournals.Items.Count == 1) { ddlJournals.SelectedIndex = 0; }
        }

        /// <summary>
        /// When a short entry is selected, select all lines in the entry then display full entry text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListOfEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            RichTextBox rtb = lb.Name == "lstEntries" ? rtbSelectedEntry_Main : rtbSelectedEntry_Found;
            rtb.Clear();    
            List<int> targets = new List<int>();
            lb.SelectedIndexChanged -= new System.EventHandler(this.ListOfEntries_SelectedIndexChanged);
            ListBox.SelectedIndexCollection c = lb.SelectedIndices;

            if (c.Count > 1)
            {
                for (int i = 0; i < c.Count - 1; i++)
                {
                    if (c[i] == c[i + 1] - 1)
                    {
                        targets.Add(c[i]);
                        targets.Add(c[i + 1]);
                        targets.Add(c[i + 2]);
                        break;
                    }
                }
            }

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
            string sTitleAndDate = lb.Items[ctr].ToString();        // Use the title and date of the entry to create a JournalEntry object whose .ClearText will populate the display ...
            string sTitle = sTitleAndDate.Substring(0, sTitleAndDate.IndexOf('(') - 1);
            string sDate = sTitleAndDate.Substring(sTitleAndDate.IndexOf('(') + 1, sTitleAndDate.Length - 2 - sTitleAndDate.IndexOf('('));
            currentEntry = currentJournal.GetEntry(sTitle, sDate);  
            rtb.Text = currentEntry != null ? currentEntry.ClearText() : String.Empty;                    // (note: This depends too much on the title/date formatting. Must standardize that.
            lblEditEntry.Enabled = true;
            lb.SelectedIndexChanged += new System.EventHandler(this.ListOfEntries_SelectedIndexChanged);
        }

        /// <summary>
        /// Populate ListBox lstBox with all entries in entries.
        /// </summary>
        /// <param name="lstBox"></param>
        /// <param name="entries"></param>
        private void PopulateEntries(ListBox lstBox, List<JournalEntry> entries)
        {
            int iTextChunkLength = 45;  // this.Width - 265 - Convert.ToInt16(this.Width * .065);
            lstBox.Items.Clear();

            foreach(JournalEntry je in entries)
            {
                lstBox.Items.Add(je.ClearTitle() + " (" + je.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")");
                string sEntryText = je.ClearText();


                lstBox.Items.Add(sEntryText.Length < iTextChunkLength ?
                    sEntryText :
                    sEntryText.Substring(0, iTextChunkLength) + " ...");

                lstBox.Items.Add("tags: " + je.ClearTags());
                lstBox.Items.Add("---------------------");
            }
        }

        /// <summary>
        /// Disallow focus on rtb used for displaying entry text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbSelectedEntry_Main_Click(object sender, EventArgs e) { ddlJournals.Focus(); }

        /// <summary>
        /// Show the dropdown of Groups when clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGroupsForSearch_Click(object sender, EventArgs e)
        {
            if(txtGroupsForSearch.Text == Properties.Settings.Default["TxtSelectGroupsForSearchDefault"].ToString()) { txtGroupsForSearch.Text = ""; }
            lstGroupsForSearch.Visible = !lstGroupsForSearch.Visible;
        }
        
        /// <summary>
        /// Add checked groups to txtGroupsForSearch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstGroupsForSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = string.Empty;

            foreach(int i in lstGroupsForSearch.CheckedIndices)
            {
                s += lstGroupsForSearch.Items[i].ToString() + ",";
            }

            txtGroupsForSearch.Text = s.Length > 0 ? s.Substring(0, s.Length - 1) : Properties.Settings.Default["TxtSelectGroupsForSearchDefault"].ToString() ;
            lstGroupsForSearch.Visible = false;
        }

        /// <summary>
        /// Enable/Disable dateTimePickers on checkbox change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleDateUse(object sender, EventArgs e)
        {
            dtFindDate.Enabled = chkUseDate.Checked;
            dtFindDate_From.Enabled = chkUseDateRange.Checked;
            dtFindDate_To.Enabled = dtFindDate_From.Enabled;
        }

		private void lblMenu_Click(object sender, EventArgs e) { pnlMenu.Visible = !pnlMenu.Visible; }

		private void lblJournal_Create_Click(object sender, EventArgs e) { ActivateGroupBox(grpNewJournal); }

		private void lblSettings_Show_Click(object sender, EventArgs e)
		{

		}

        private void MenuItem_Enter(object sender, EventArgs e)
		{
            Label lbl = (Label)sender;
            lbl.Font = ActiveMenuFont;
		}

        private void MenuItem_Leave(object sender, EventArgs e)
		{
            Label lbl = (Label)(sender);
            lbl.Font = InactiveMenuFont;
        }

		private void lblTagManager_Click(object sender, EventArgs e) { ActivateGroupBox(grpNewGroup); }
	}
}
