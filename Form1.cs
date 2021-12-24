using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myJournal
{
    public partial class Form1 : Form
    {
        Point ActiveBoxLocation = new Point(12, 0);
        Size ActiveBoxSize = (Size)new Point(290, 545);
        Size MainFormSize = (Size)new Point(331, 592);
        public Form1()
        {
            InitializeComponent();
            this.Size = MainFormSize;
            grpOpenScreen.Location = ActiveBoxLocation;
            grpOpenScreen.Size = ActiveBoxSize;
        }

        private void lblCreateEntry_Click(object sender, EventArgs e)
        {
            if(ddlJournals.Text == "")
            {
                // create a new journal
            }
            else if (ddlJournals.Text == "Create New Journal")
            {
                // create a new journal
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

        private void lblAddEntry_Click(object sender, EventArgs e)
        {
            // code to add an entry to the journal
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

        private void ActivateGroupBox(GroupBox box)
        {
            foreach (GroupBox gb in this.Controls)
            {
                gb.Visible = false;
            }

            box.Size = ActiveBoxSize;
            box.Location = ActiveBoxLocation;
            box.Visible = true;
        }
    }
}
