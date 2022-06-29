using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

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
			//this.WindowState = FormWindowState.Maximized;
			LoadJournals();
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
		}

		private void ddlJournals_SelectedIndexChanged(object sender, EventArgs e)
		{
			mnuJournal_Delete.Enabled = true;
			mnuEntryTop.Enabled = true;
		}

		private void mnuJournal_Create_Click(object sender, EventArgs e)
		{
			frmNewJournal frm = new frmNewJournal();
			ShowForm(frm);
			string pin = frm.sPIN == null ? string.Empty : frm.sPIN;
			string name = frm.sJournalName == null ? string.Empty : frm.sJournalName;
			frm.Close();

			if ( pin.Length > 0 |  name.Length > 0){
				Journal j = new Journal(pin, name);
				j.Create();
				LoadJournals();
			}
		}

		private void btnLoadJournal_Click(object sender, EventArgs e)
		{
			//pnlMenu.Visible = false;
			lstEntries.Items.Clear();
			rtbSelectedEntry_Main.Text = string.Empty;

			try
			{
				currentJournal = new Journal(ConfigurationManager.AppSettings["PIN"], ddlJournals.Text).Open(ddlJournals.Text);

				if (currentJournal != null)
				{
					PopulateEntries(lstEntries);
					//lblCreateEntry.Enabled = true;
					//lblFindEntry.Enabled = true;
					//lblViewJournal.Enabled = true;
					lblSelectAJournal.Enabled = true;
					lblSelectAJournal.Text = "Entries";
					lstEntries.Height = this.Height - 100;
					lbl1stSelection.Text = "1";
				}
				else
				{
					lstEntries.Focus();
				}
			}
			catch (Exception) { }
		}

		private void PopulateEntries(ListBox lstBoxToPopulate, List<JournalEntry> entries = null)
		{
			entries = entries != null ? currentJournal.Entries : null;
			int iTextChunkLength = Convert.ToInt16(lstBoxToPopulate.Width * .15);
			lstBoxToPopulate.Items.Clear();

			foreach (JournalEntry je in currentJournal.Entries)
			{
				// add display of isEdited here
				lstBoxToPopulate.Items.Add(je.ClearTitle(txtJournalPIN.Text) + " (" + je.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")"); //+ (je.isEdited ? " - EDITED" : ""));
				string sEntryText = je.ClearText();

				lstBoxToPopulate.Items.Add(sEntryText.Length < iTextChunkLength ?
					sEntryText :
					sEntryText.Substring(0, iTextChunkLength) + " ...");

				lstBoxToPopulate.Items.Add("tags: " + je.ClearTags());
				lstBoxToPopulate.Items.Add("---------------------");
			}

			if (lstBoxToPopulate.Items.Count > 0)
			{
				lstBoxToPopulate.Height = lstBoxToPopulate.Height + rtbSelectedEntry_Main.Height;
			}

			//lblJournal_Save.Enabled = true;
		}

		private void lstEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox lb = (ListBox)sender;
			RichTextBox rtb = rtbSelectedEntry_Main; //RichTextBox rtb = lb.Name == "lstEntries" ? rtbSelectedEntry_Main : rtbSelectedEntry;
			rtb.Clear();
			List<int> targets = new List<int>();
			lb.SelectedIndexChanged -= new System.EventHandler(this.lstEntries_SelectedIndexChanged);
			//ListBox.SelectedIndexCollection cltnLbSelectedEntries = lb.SelectedIndices;
			//pnlMenu.Visible = false;

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
					//, currentJournal.Name
					, currentEntry.ClearTitle(), currentEntry.Date
					, currentEntry.ClearTags()
					, currentEntry.ClearText());
				if (rtb.Text.Length == 0) { lstEntries.TopIndex = lstEntries.Top + lstEntries.Height < rtbSelectedEntry_Main.Top ? ctr : lstEntries.TopIndex; }
				//lblEditEntry.Enabled = true;
				lblPrint.Visible = rtb.Text.Length > 0;
				grpSelectedEntryLabels.Visible = rtb.Text.Length > 0;
				lblSeparator_grpOpenScreen.Visible = rtb.Text.Length > 0;
				//lblSelectedFoundEntry.Visible = rtbSelectedEntry_Found.Text.Length > 0;
				lblSelectionType.Text = "Selected Entry";

				//lstEntries.Height = rtb.Text.Length > 0 ? rtbSelectedEntry_Main.Top - 132 : grpOpenScreen.Height - 100;

				lstEntries.Height = rtb.Text.Length > 0 ? rtbSelectedEntry_Main.Top - 132 : 100;

				if (lbl1stSelection.Text.Equals("1"))
				{
					lstEntries.TopIndex = lstEntries.Top + lstEntries.Height < rtbSelectedEntry_Main.Top ? ctr : lstEntries.TopIndex;
					lbl1stSelection.Text = "0";
				}

				ResizeListsAndRTBs(lstEntries, rtbSelectedEntry_Main, lblSeparator_grpOpenScreen);
			}

			lb.SelectedIndexChanged += new System.EventHandler(this.lstEntries_SelectedIndexChanged);
		}

		private void ResizeListsAndRTBs(ListBox lbx, RichTextBox rtb, Label lblSeperator)
		{
			int iBoxCenter = lbx.Width / 2;
			lblSeperator.Left = lbx.Left + 10;
			lblSeperator.Width = lbx.Width - 20;
			lbx.Height = lblSeperator.Top - lbx.Top - 5;
			grpSelectedEntryLabels.Top = lblSeperator.Top + lblSeperator.Height + 10;
			rtb.Top = grpSelectedEntryLabels.Top + grpSelectedEntryLabels.Height;
			rtb.Height = this.Height - rtb.Top - 50;
		}

		private void lblSeparator_grpOpenScreen_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				lblSeparator_grpOpenScreen.Top += e.Y;
				ResizeListsAndRTBs(lstEntries, rtbSelectedEntry_Main, lblSeparator_grpOpenScreen);
				lstEntries.TopIndex = lstEntries.SelectedIndices[0];
			}
		}

		private void ShowForm(Form frm, int left = -1, int top = -1)
		{
			frm.StartPosition = FormStartPosition.Manual;

			frm.Location = new Point(this.Left, this.Top);
			frm.Size = new Size(this.Width, this.Height);

			//frm.Location = left > -1 | top > -1 ?
			//	new Point(this.Left + left, this.Top + top) :
			//	new Point(this.Left + (this.Width / 2) - (frm.Width / 2), (this.Top + (this.Height / 2) - (frm.Width / 2)));

			//if (left > -1 & top > -1)
			//{
			//	frm.Location =  new Point(this.Left + left, this.Top + top);
			//}
			//else
			//{
			//	frm.Location = new Point(this.Left + (this.Width / 2) - (frm.Width / 2), (this.Top + (this.Height / 2) - (frm.Width / 2)));
			//}
			frm.ShowDialog();
		}

		protected override CreateParams CreateParams {
			get {
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}

		private void mnuEntryCreate_Click(object sender, EventArgs e)
		{
			frmNewEntry frm = new frmNewEntry();
			ShowForm(frm, 10, 10);
			if(frm.entry != null)
			{
				currentJournal.AddEntry(frm.entry);
				currentJournal.Save();
				PopulateEntries(lstEntries);
			}
			frm.Close();
		}
	}
}
