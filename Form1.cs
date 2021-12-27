using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using encrypt_decrypt_string;

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

        public Form1()
        { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = MainFormSize;
            grpOpenScreen.Location = ActiveBoxLocation;
            grpOpenScreen.Size = ActiveBoxSize;
            LoadJournals();
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
                    break;
                case "grpCreateEntry":
                    this.Text = "Create Entry";
                    txtNewEntryTitle.Text = String.Empty;
                    rtbNewEntry.Clear();
                    txtBxToFocus = this.txtNewEntryTitle;
                    if(lstGroups.Items.Count == 0) { Groups_PopulateGroupsList(lstGroups); }
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
            }

            box.Size = ActiveBoxSize;
            box.Location = ActiveBoxLocation;
            box.Visible = true;
            if (txtBxToFocus != null) txtBxToFocus.Focus();
            DisplayedGroupBox = box;
        }

        /// <summary>
        /// Add the new entry. THIS SHOULD BE CUT OVER TO A BUTTON.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            if (rtbNewEntry.Text.Length > 0 && txtNewEntryTitle.Text.Length > 0)
            {
                string sGroups = string.Empty;

                for (int i = 0; i < lstGroups.CheckedItems.Count; i++)
                {
                    sGroups += lstGroups.CheckedItems[i].ToString() + ",";
                }

                currentJournal.Entries.Add(new JournalEntry(txtNewEntryTitle.Text, rtbNewEntry.Text,
                    sGroups.Length > 0 ? sGroups.Substring(0, sGroups.Length - 1) : string.Empty));

                currentJournal.SaveToDisk();
                PopulateEntries(lstEntries, currentJournal.Entries);
            }
            txtNewEntryTitle.Text = String.Empty;
            rtbNewEntry.Clear();
            ActivateGroupBox(grpOpenScreen);
        }

        private void btnCreateJournal_Click(object sender, EventArgs e) { ActivateGroupBox(grpNewJournal); }

        private void btnOK_NewJrnl_Click(object sender, EventArgs e)
        {
            Journal jrnl = new Journal(txtNewJournalName.Text);
            jrnl.CreateJournal();
            LoadJournals();
            ActivateGroupBox(grpOpenScreen);
        }

        private void ddlJournals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlJournals.Enabled)
            {
                lstEntries.Items.Clear();
                rtbSelectedEntry_Main.Text = string.Empty;
                Journal j = new Journal(ddlJournals.Text);
                currentJournal = j.OpenJournal();
                PopulateEntries(lstEntries, currentJournal.Entries);
            }
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
                int i = lstGroups.SelectedIndex;
                lstGroups.Items.RemoveAt(i);
                lstGroups.Items.Insert(i, txtNewGroup.Text);
                Groups_Save();
            }

            txtNewGroup.Text = string.Empty;
            Groups_PopulateGroupsList(lstGroups);
            ActivateGroupBox(grpCreateEntry);
            bGroupBeingEdited = false;
        }

        private void Groups_mnuEdit_Click(object sender, EventArgs e)
        {
            txtNewGroup.Text = lstGroups.SelectedItem.ToString();
            bGroupBeingEdited = true;
            ActivateGroupBox(grpNewGroup);
        }

        private void Groups_mnuDelete_Click(object sender, EventArgs e)
        {
            lstGroups.Items.RemoveAt((int)lstGroups.SelectedIndex);
            Groups_Save();
            Groups_PopulateGroupsList(lstGroups);
            ActivateGroupBox(grpCreateEntry);
        }

        private void Groups_mnuGroups_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = lstGroups.SelectedIndices.Count == 0;
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

            foreach (string s in lstGroups.Items)
            {
                sb.AppendLine(s);
            }

            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/settings/groups", sb.ToString());
        }
        #endregion

        private void lblCreateEntry_Click(object sender, EventArgs e)
        {
            if (!ddlJournals.Enabled)
            {
                this.Text = "Please create a journal";
            }
            else
            {
                if(currentJournal != null)
                {
                    ActivateGroupBox(grpCreateEntry);
                }
                else
                {
                    this.Text = "Select A Journal";
                }
            }
        }

        private void lblEditEntry_Click(object sender, EventArgs e)
        {

        }

        private void lblFindEntry_Click(object sender, EventArgs e) { ActivateGroupBox(grpFindEntry); }

        private void lblSettings_Click(object sender, EventArgs e)
        {
            // show the settings group box
        }

        private void lblHome_Click(object sender, EventArgs e) { ActivateGroupBox(grpOpenScreen); }

        private void lblClearAll_Click(object sender, EventArgs e)
        {
            // clear search criteria
        }

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
            EntrySelector.SelectEntry(lb, ctr);
            string sTitleAndDate = lb.Items[ctr].ToString();
            string sTitle = sTitleAndDate.Substring(0, sTitleAndDate.IndexOf('(') - 1);
            string sDate = sTitleAndDate.Substring(sTitleAndDate.IndexOf('(') + 1, sTitleAndDate.Length - 2 - sTitleAndDate.IndexOf('('));
            rtb.Text = EncryptDecrypt.Decrypt(currentJournal.GetEntry(sTitle, sDate).Text, "", "");
            lb.SelectedIndexChanged += new System.EventHandler(this.ListOfEntries_SelectedIndexChanged);
        }

        /// <summary>
        /// Select all lines of a selected (short) entry.
        /// </summary>
        /// <param name="index"></param>
        private void lstFoundEntries_SelectedIndexChanged(object sender, EventArgs e) { EntrySelector.SelectEntry(lstFoundEntries, lstFoundEntries.SelectedIndex); }
        
        /// <summary>
        /// Populate ListBox lstBox with all entries in entries.
        /// </summary>
        /// <param name="lstBox"></param>
        /// <param name="entries"></param>
        private void PopulateEntries(ListBox lstBox, List<JournalEntry> entries)
        {
            int iTextChunkLength = Convert.ToInt16( Properties.Settings.Default["ShortEntryDisplayTextLength"]);
            lstBox.Items.Clear();

            foreach(JournalEntry je in entries)
            {
                lstBox.Items.Add(EncryptDecrypt.Decrypt(je.Title, "", "") + " (" + je.Date.ToString("M-dd-yy H_m_ss") + ")");
                lstBox.Items.Add(je.Text.Length < iTextChunkLength ? EncryptDecrypt.Decrypt(je.Text, "", "") : EncryptDecrypt.Decrypt(je.Text, "", "").Substring(0, iTextChunkLength - 1) + " ...");
                lstBox.Items.Add("tags: " + EncryptDecrypt.Decrypt(je.Groups, "", ""));
                lstBox.Items.Add("---------------------");
            }
        }

        /// <summary>
        /// Disallow focus on rtb used for displaying entry text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbSelectedEntry_Main_Click(object sender, EventArgs e) { btnCreateJournal.Focus(); }

        private void txtGroupsForSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGroupsForSearch_Click(object sender, EventArgs e)
        {
            if(txtGroupsForSearch.Text == Properties.Settings.Default["TxtSelectGroupsForSearchDefault"].ToString()) { txtGroupsForSearch.Text = ""; }
            lstGroupsForSearch.Visible = !lstGroupsForSearch.Visible;
        }

        private void lstGroupsForSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            var iChecked = lstGroupsForSearch.CheckedIndices;
            string s = string.Empty;

            foreach(int i in iChecked)
            {
                s += lstGroupsForSearch.Items[i].ToString() + ",";
            }
            txtGroupsForSearch.Text = s.Length > 0 ? s.Substring(0, s.Length - 1) : Properties.Settings.Default["TxtSelectGroupsForSearchDefault"].ToString() ;
            lstGroupsForSearch.Visible = false;
        }

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
                for(int i = 0; i < ddlJournals.Items.Count; i++)
                {
                    journalNames.Add(ddlJournals.Items[i].ToString());
                }
            }

            Journal j = new Journal();
            Journal journalToSearch = new Journal();

            foreach(string journalName in journalNames)
            {
                journalToSearch = j.OpenJournal(journalName);

                foreach(JournalEntry je in journalToSearch.Entries)
                {
                    // date
                    if (chkUseDate.Checked)
                    {
                        if(je.Date == dtFindDate.Value)
                        {
                            foundEntries.Add(je);
                        }
                        if (chkUseDateRange.Checked)
                        {
                            if(je.Date >= dtSearchFrom.Value && je.Date <= dtSearchTo.Value)
                            {
                                foundEntries.Add(je);
                            }
                        }
                    }
                    // tags
                    if(txtGroupsForSearch.Text != Properties.Settings.Default["TxtSelectGroupsForSearchDefault"].ToString())
                    {
                        string[] groups = txtGroupsForSearch.Text.Split(',');
                        foreach(string group in groups)
                        {
                            if (EncryptDecrypt.Decrypt(je.Groups, "", "").Contains(group)) { foundEntries.Add(je); }
                        }
                    }
                    // title contains
                    if (txtSearchTitle.TextLength > 0) { if (EncryptDecrypt.Decrypt(je.Title, "", "").Contains(txtSearchTitle.Text)) { foundEntries.Add(je); } }
                    // entry contains
                    if (txtSearchText.TextLength > 0) { if (EncryptDecrypt.Decrypt(je.Text, "", "").Contains(txtSearchText.Text)) { foundEntries.Add(je); } }
                }
            }

            if(foundEntries.Count > 0)
            {
                PopulateEntries(lstFoundEntries, foundEntries);
            }

        }

        private void ToggleDateUse(object sender, EventArgs e)
        {
            dtFindDate.Enabled = chkUseDate.Checked;
            dtSearchFrom.Enabled = chkUseDateRange.Checked;
            dtSearchTo.Enabled = dtSearchFrom.Enabled;
        }
    }
}
