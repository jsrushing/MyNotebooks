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
        }
        private void ActivateGroupBox(GroupBox box)
        {
            foreach (GroupBox gb in this.Controls)
            {
                gb.Visible = false;
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
            // code to add an entry to the journal
            currentJournal.Entries.Add(new JournalEntry(txtNewEntryTitle.Text, rtbNewEntry.Text));
            PopulateEntries();
            currentJournal.SaveToDisk();
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
                ActivateGroupBox(grpCreateEntry);
                this.Text = "Create Entry";
            }

        }

        private void lblFindEntry_Click(object sender, EventArgs e)
        {
            ActivateGroupBox(grpFindEntry);
            this.Text = "Find Entry";
        }

        private void lblSettings_Click(object sender, EventArgs e)
        {
            // show the settings group box
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            ActivateGroupBox(grpOpenScreen);
            this.Text = "My Journals";
        }

        private void lblClearAll_Click(object sender, EventArgs e)
        {
            // clear search criteria
        }

        private void LoadJournals()
        {
            ddlJournals.Items.Clear();

            string sDir = AppDomain.CurrentDomain.BaseDirectory + "/journals/";

            if (!Directory.Exists(sDir))
            {
                Directory.CreateDirectory(sDir);
            }
            else
            {
                foreach(string s in Directory.GetFiles(sDir))
                {
                    ddlJournals.Items.Add(s.Replace(sDir, ""));
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

        private void lstEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the selected entry
        }

        private void lstFoundEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the selected found entry
        }

        private void ddlJournals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlJournals.Enabled)
            {
                PopulateEntries();
            }
        }

        private void PopulateEntries()
        {
            lstEntries.Items.Clear();
            Journal j = new Journal(ddlJournals.Text);
            currentJournal = j.OpenJournal();

            foreach(JournalEntry je in currentJournal.Entries)
            {
                lstEntries.Items.Add(je.Title + " (" + je.Date + ")");
                lstEntries.Items.Add(je.Text.Length < 31 ? je.Text : je.Text.Substring(0, 30) + " ...");
                lstEntries.Items.Add("---------------------");
            }
        }
    }
}
