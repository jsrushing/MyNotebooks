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

		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
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
		}

		private void mnuJournal_Create_Click(object sender, EventArgs e)
		{
			((frmParent)this.MdiParent).nextForm = new frmNewJournal();
			this.Close();
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

	}
}
