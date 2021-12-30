using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Linq;

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
		GroupBox backTarget = null;

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
			FontStyle fs = FontStyle.Bold | FontStyle.Italic;
            ActiveMenuFont = new Font(InactiveMenuFont.FontFamily, InactiveMenuFont.Size + 1);
			ActiveMenuFont = new Font(ActiveMenuFont, fs);
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
                    if(lstTags.Items.Count == 0) { Tags_PopulateTagsList(lstTags); }
					foreach(int i in lstTags.CheckedIndices) { lstTags.SetItemChecked(i, false); }
                    break;
                case "grpFindEntry":
                    this.Text = "Search Journal";
                    Tags_PopulateTagsList(lstGroupsForSearch);
                    //txtGroupsForSearch.Text = Properties.Settings.Default["TxtSelectGroupsForSearchDefault"].ToString();
                    break;
                case "grpNewJournal":
                    this.Text = "Create New Journal";
                    txtBxToFocus = this.txtNewJournalName;
					lblMessage_BadJournalName.Location = new Point(6, 30);
					lblMessage_BadJournalName.Width = grpNewJournal.Width - 3;
                    break;
                case "grpNewGroup":
                    this.Text = "Create New Group";
					Tags_PopulateTagsList(null, lstTagsForEdit);
					txtBxToFocus = this.txtTags_TagName_NewTag;
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
                PopulateEntries(lstEntries);
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
		private void btnConfirmEntryDelete_Click(object sender, EventArgs e)
		{
			currentJournal.Entries.Remove(currentEntry);
			currentJournal.SaveToDisk();
			PopulateEntries(lstEntries);
			ActivateGroupBox(grpOpenScreen);
		}
		
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
			if (lblMessage_BadJournalName.Visible)
			{
				lblMessage_BadJournalName.Visible = false;
			}
			else
			{
				try
				{
					Journal jrnl = new Journal(txtNewJournalName.Text);
					jrnl.CreateJournal();
					LoadJournals();
					ActivateGroupBox(grpOpenScreen);
				}
				catch (Exception) { lblMessage_BadJournalName.Visible = true; }
			}
        }

		private void btnOK_TagName_Edited_Click(object sender, EventArgs e)
		{
			int a = lstTagsForEdit.SelectedIndex;
			lstTagsForEdit.Items.RemoveAt(a);
			lstTagsForEdit.Items.Insert(a, txtTag_TagName_Edited.Text);
			grpEditTags_NewName.Visible = false;
			Tags_Save(null, lstTagsForEdit);
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
			try
			{
				currentJournal = new Journal(ddlJournals.Text).OpenJournal(); 

				if(currentJournal != null)
				{
					PopulateEntries(lstEntries);
					lblCreateEntry.Enabled = true; 
					lblFindEntry.Enabled = true;
				}
				else
				{
					lstEntries.Focus();
				}
			}
			catch(Exception) { }
        }

        #region Tags
        private void Tags_btnAddTag_Click(object sender, EventArgs e)
        { ActivateGroupBox(grpNewGroup); }

        private void Tags_btnOK_NewTag_Click(object sender, EventArgs e)
        {
            if (!bGroupBeingEdited)
            {
                using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "/settings/groups"))
                {
                    sw.WriteLine(txtTags_TagName_NewTag.Text);
                }
            }
            else
            {
                int i = lstTags.SelectedIndex;
                lstTags.Items.RemoveAt(i);
                lstTags.Items.Insert(i, txtTags_TagName_NewTag.Text);
                Tags_Save();
            }

            txtTags_TagName_NewTag.Text = string.Empty;
            Tags_PopulateTagsList(lstTags);
            ActivateGroupBox(grpCreateEntry);
            bGroupBeingEdited = false;
        }

        private void Tags_mnuEdit_Click(object sender, EventArgs e)
        {
            txtTags_TagName_NewTag.Text = lstTags.SelectedItem.ToString();
            bGroupBeingEdited = true;
            ActivateGroupBox(grpNewGroup);
        }

        private void Tags_mnuDelete_Click(object sender, EventArgs e)
        {
            lstTags.Items.RemoveAt((int)lstTags.SelectedIndex);
            Tags_Save();
            Tags_PopulateTagsList(lstTags);
            ActivateGroupBox(grpCreateEntry);
        }

        private void Tags_mnuTags_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = lstTags.SelectedIndices.Count == 0;
        }

        private void Tags_PopulateTagsList(CheckedListBox clb, ListBox lb = null)
        {
			if (clb != null) { clb.Items.Clear(); }
			if(lb != null) { lb.Items.Clear(); }

            foreach (string group in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/settings/groups"))
            {
				if(lb != null)
				{
					lb.Items.Add(group);
				}
				else
				{
					clb.Items.Add(group);
				}
            }
        }

        private void Tags_Save(CheckedListBox clb = null, ListBox lb = null)
        {
			string[] tags = clb == null ? lb.Items.OfType<string>().ToArray() : clb.Items.OfType<string>().ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (string s in tags) { sb.AppendLine(s); }
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/settings/groups", sb.ToString());
        }
        #endregion

        #region Clickable Labels

        private void lblCloseMenu_Click(object sender, EventArgs e) { pnlMenu.Visible = false; }

        private void lblClearSearchCriteria_Click(object sender, EventArgs e) 
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

        private void lblCreateEntry_Click(object sender, EventArgs e) { ActivateGroupBox(grpCreateEntry); }

        /// <summary>
        /// Delete an entry (on grpNewEnty, available during edit).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDeleteEntry_Click(object sender, EventArgs e)
        {
			lblMessage_ConfirmEntryDelete.Text = currentEntry.ClearTitle() + " " + lblMessage_ConfirmEntryDelete.Text;
			ActivateGroupBox(grpConfirmDeleteEntry);
        }

		private void lblEditTag_Click(object sender, EventArgs e)
		{
			grpEditTags_NewName.Location = grpEditTags_Add.Location;
			grpEditTags_NewName.Height = grpEditTags_EditRemove.Top + grpEditTags_EditRemove.Height;
			txtTag_TagName_Edited.Text = lstTagsForEdit.SelectedItem.ToString();
			grpEditTags_NewName.Visible = true;
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
                " > Original Date: " + currentEntry.Date.ToString("dd/M/yy H:m:s") + newLine +
                " > Title: " + currentEntry.ClearTitle() + newLine + 
                " > Entry:" + newLine + currentEntry.ClearText();
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
					//if (txtGroupsForSearch.Text != Properties.Settings.Default["TxtSelectGroupsForSearchDefault"].ToString())
					if (txtGroupsForSearch.Text.Length > 0)

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

        private void lblHome_Click(object sender, EventArgs e) 
		{
			GroupBox gb = backTarget == null ? grpOpenScreen : backTarget;
			ActivateGroupBox(gb);
			backTarget = null;
		}

		private void lblJournal_Create_Click(object sender, EventArgs e) { ActivateGroupBox(grpNewJournal); }

		private void lblMenu_Click(object sender, EventArgs e) { pnlMenu.Visible = !pnlMenu.Visible; }

		private void lblRemoveTag_Click(object sender, EventArgs e)
		{
			int a = lstTagsForEdit.SelectedIndex;
			lstTagsForEdit.Items.RemoveAt(a);
			grpEditTags_NewName.Visible = false;
			Tags_Save(null, lstTagsForEdit);
		}

		private void lblSettings_Show_Click(object sender, EventArgs e)
		{

		}

		private void lblTagManager_Click(object sender, EventArgs e) { ActivateGroupBox(grpNewGroup); }
		#endregion

		#region Menus - Toggle display on MouseEnter/Leave
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
			ddlJournals.Enabled = ddlJournals.Items.Count > 0;
			ddlJournals.SelectedIndex = ddlJournals.Items.Count == 1 ? 0 : -1;
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
        /// <param name="lstBoxToPopulate"></param>
        /// <param name="entries"></param>
        private void PopulateEntries(ListBox lstBoxToPopulate, List<JournalEntry> entries = null)
        {
			entries = entries != null ? currentJournal.Entries : null;
			int iTextChunkLength = Convert.ToInt16(lstEntries.Width * .15);
            lstBoxToPopulate.Items.Clear();

            foreach(JournalEntry je in currentJournal.Entries)
            {
                lstBoxToPopulate.Items.Add(je.ClearTitle() + " (" + je.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")");
                string sEntryText = je.ClearText();


                lstBoxToPopulate.Items.Add(sEntryText.Length < iTextChunkLength ?
                    sEntryText :
                    sEntryText.Substring(0, iTextChunkLength) + " ...");

                lstBoxToPopulate.Items.Add("tags: " + je.ClearTags());
                lstBoxToPopulate.Items.Add("---------------------");
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
            //if(txtGroupsForSearch.Text == Properties.Settings.Default["TxtSelectGroupsForSearchDefault"].ToString()) { txtGroupsForSearch.Text = ""; }
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

			txtGroupsForSearch.Text = s.Length > 0 ? s.Substring(0, s.Length - 1) : String.Empty;	// Properties.Settings.Default["TxtSelectGroupsForSearchDefault"].ToString() ;
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

	}
}
