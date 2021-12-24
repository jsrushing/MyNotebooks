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

        public Form1()
        {
            InitializeComponent();
            this.Size = MainFormSize;
            grpOpenScreen.Location = ActiveBoxLocation;
            grpOpenScreen.Size = ActiveBoxSize;
            LoadJournals();
            // populate groups
        }
        private void ActivateGroupBox(GroupBox box)
        {
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
                    break;
                case "grpFindEntry":
                    this.Text = "Search Journal";
                    break;
                case "grpNewJournal":
                    this.Text = "Create New Journal";
                    break;
            }

            box.Size = ActiveBoxSize;
            box.Location = ActiveBoxLocation;
            box.Visible = true;
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
            currentJournal.Entries.Add(new JournalEntry(txtNewEntryTitle.Text, rtbNewEntry.Text));
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
            int ctr = lstEntries.SelectedIndex;
            if (lstEntries.Items[ctr].ToString().StartsWith("--")) ctr--;

            while (!lstEntries.Items[ctr].ToString().StartsWith("--") & ctr > 0)
            {
                ctr--;
                if (ctr < 0) break;
            }
            string sTitleAndDate = lstEntries.Items[ctr == 0 ? ctr : ctr + 1].ToString();
            string sTitle = sTitleAndDate.Substring(0, sTitleAndDate.IndexOf('(') - 1);
            string sDate = sTitleAndDate.Substring(sTitleAndDate.IndexOf('(') + 1, sTitleAndDate.Length - 2 - sTitleAndDate.IndexOf('('));

            JournalEntry je = currentJournal.GetEntry(sTitle, sDate);

            rtbSelectedEntry_Main.Text = je.Text;

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
        {
            
        }
    }
}
