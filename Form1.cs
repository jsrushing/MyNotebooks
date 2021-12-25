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

namespace myJournal
{
    public partial class Form1 : Form
    {
        Point ActiveBoxLocation = new Point(12, 0);
        Size ActiveBoxSize = (Size)new Point(290, 545);
        Size MainFormSize = (Size)new Point(331, 592);
        GroupBox DisplayedGroupBox;
        Journal currentJournal = null;
        int iChosenEntryForHighlighting;

        public Form1()
        {
            InitializeComponent();
            this.Size = MainFormSize;
            grpOpenScreen.Location = ActiveBoxLocation;
            grpOpenScreen.Size = ActiveBoxSize;
            LoadJournals();
            PopulateGroups();
        }
        private void ActivateGroupBox(GroupBox box)
        {
            TextBox txtBxToFocus = null;
            foreach (GroupBox gb in this.Controls)
            {
                gb.Visible = false;
            }

            switch (box.Name) 
            {
                case "grpOpenScreen":
                    this.Text = "My Journal";
                    break;
                case "grpCreateEntry":
                    this.Text = "Create Entry";
                    txtBxToFocus = this.txtNewEntryTitle;
                    break;
                case "grpFindEntry":
                    this.Text = "Search Journal";
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

        private void btnOK_NewJrnl_Click(object sender, EventArgs e)
        {
            Journal jrnl = new Journal(txtNewJournalName.Text);
            jrnl.CreateJournal();
            LoadJournals();
            ActivateGroupBox(grpOpenScreen);
        }

        private void btnCreateJournal_Click(object sender, EventArgs e)
        {
            ActivateGroupBox(grpNewJournal);
            txtNewJournalName.Focus();
        }

        private void lblAddEntry_Click(object sender, EventArgs e)
        {
            string sGroups = string.Empty;
            for(int i = 0; i < lstGroups.CheckedItems.Count; i++)
            {
                sGroups += lstGroups.CheckedItems[i].ToString() + ",";
            }

            currentJournal.Entries.Add(new JournalEntry(txtNewEntryTitle.Text, rtbNewEntry.Text, 
                sGroups.Length > 0 ? sGroups.Substring(0, sGroups.Length - 1) : string.Empty));

            currentJournal.SaveToDisk();
            PopulateEntries();
            ActivateGroupBox(grpOpenScreen);
        }

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
                    this.Text = "Create Entry";
                }
                else
                {
                    this.Text = "Select A Journal";
                }
            }

        }

        private void lblFindEntry_Click(object sender, EventArgs e)
        { ActivateGroupBox(grpFindEntry); }

        private void lblSettings_Click(object sender, EventArgs e)
        {
            // show the settings group box
        }

        private void lblHome_Click(object sender, EventArgs e)
        { ActivateGroupBox(grpOpenScreen); }

        private void lblClearAll_Click(object sender, EventArgs e)
        {
            // clear search criteria
        }

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
        /// Choose a listed entry (see ddlJournals_SelectedIndexChanged) and display its Text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            var iSelected = lstEntries.SelectedIndices;

            ListBox.SelectedIndexCollection c = lstEntries.SelectedIndices;
            List<int> targets = new List<int>();
            this.lstEntries.SelectedIndexChanged -= new System.EventHandler(this.lstEntries_SelectedIndexChanged);

            if(c.Count > 1)
            {
                for(int i = 0; i < c.Count - 1; i++)
                {
                    int i1 = c[i];
                    int i2 = c[i + 1];

                    if(c[i] == c[i + 1] - 1)
                    {
                        targets.Add(c[i]);
                        targets.Add(c[i + 1]);
                        targets.Add(c[i + 2]);
                        break;
                    }
                }
            }

            if(targets.Count == 3)
            {
                foreach(int i in targets)
                {
                    lstEntries.SelectedIndices.Remove(i);
                }
            }

            iChosenEntryForHighlighting = lstEntries.SelectedIndex;   

            int ctr = iChosenEntryForHighlighting;
            if (lstEntries.Items[ctr].ToString().StartsWith("--")) ctr--;

            while (!lstEntries.Items[ctr].ToString().StartsWith("--") & ctr > 0)
            {
                ctr--;
                if (ctr < 0) break;
            }

            if (ctr > 0) { ctr += 1; }
            string sTitleAndDate = lstEntries.Items[ctr].ToString();
            string sTitle = sTitleAndDate.Substring(0, sTitleAndDate.IndexOf('(') - 1);
            string sDate = sTitleAndDate.Substring(sTitleAndDate.IndexOf('(') + 1, sTitleAndDate.Length - 2 - sTitleAndDate.IndexOf('('));
            SelectChosenEntry(ctr);
            rtbSelectedEntry_Main.Text = currentJournal.GetEntry(sTitle, sDate).Text;
        }

        private void SelectChosenEntry(int index)
        {
            lstEntries.SelectedIndices.Clear();
            lstEntries.SelectedIndices.Add(index);
            lstEntries.SelectedIndices.Add(index + 1);
            lstEntries.SelectedIndices.Add(index + 2);
            this.lstEntries.SelectedIndexChanged += new System.EventHandler(this.lstEntries_SelectedIndexChanged);
        }

        private void lstFoundEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the selected found entry
        }

        /// <summary>
        /// Populate the entries listbox with entries in the selected journal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlJournals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlJournals.Enabled)
            {
                PopulateEntries();
            }
        }

        /// <summary>
        /// Populate the entries listbox with truncated JournalEntry's for user selection to see more.
        /// </summary>
        private void PopulateEntries()
        {
            lstEntries.Items.Clear();
            rtbSelectedEntry_Main.Text = string.Empty;
            Journal j = new Journal(ddlJournals.Text);
            currentJournal = j.OpenJournal();
            int iTextChunkLength = 45;

            foreach(JournalEntry je in currentJournal.Entries)
            {
                lstEntries.Items.Add(je.Title + " (" + je.Date + ")");
                lstEntries.Items.Add(je.Text.Length < iTextChunkLength ? je.Text : je.Text.Substring(0, iTextChunkLength - 1) + " ...");
                if(je.Groups.Length > 0) lstEntries.Items.Add(je.Groups);
                lstEntries.Items.Add("---------------------");
            }
        }

        private void PopulateGroups()
        {
            lstGroups.Items.Clear();

            foreach(string group in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/settings/groups")) 
            {
                lstGroups.Items.Add(group);
            }
        }

        /// <summary>
        /// Disallow focus on rtb used for displaying entry text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbSelectedEntry_Main_Click(object sender, EventArgs e)
        { btnCreateJournal.Focus(); }

        private void btnAddGroup_Click(object sender, EventArgs e)
        { ActivateGroupBox(grpNewGroup); }

        private void btnOK_NewGroup_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "/settings/groups"))
            {
                sw.WriteLine(txtNewGroup.Text);
            }
            PopulateGroups();
            txtNewGroup.Text = string.Empty;
            ActivateGroupBox(grpCreateEntry);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblEditEntry_Click(object sender, EventArgs e)
        {

        }
    }
}
