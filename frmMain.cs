/* Main form.
	04/01/22
	07/06/22 - Dev. ended. In test.

	bug list:
		07/07/22 1100
			001x Can arrow down or right into no type area.
			> 002x Can select and drag into or out of no type area.
				1400 Fixed
		07/08/22 1000
			003x Save entry edit sometimes leaves out Text.
				1740 Found issue. Entries with '(' in the title cause failure to build currentEntry (it remains null after entry is selected).
				1745 Fixed: When selecting in the short entry (lstEntries) get LastIndexOf('(') instead of just .IndexOf.

			004x Entries with no text cannot be edited or deleted (menus are disabled because they toggle on rtbSelectedEntry.Text.Length > 0).
				1745 Fixed with 0003. This should never happen. Only came up because of 0003.


	toDo:
		07/07/22 001 Entry RTB formatting controls.
				 002 Save .RichText instead of just .Text;
				002ax Add password char for PIN and show/hide function.
					1730 Done.
		07/08/22 003x Column tab stops in rtbNewEntry.
					07/10/22 1810 Done (was simple properties setting - .AcceptTab)
				 004x Save new entry without exiting (to save incrementally)?
					07/11/22 1445 No. Have user save entry then edit if desired.
				 005x Allow selection length > 1 in editing entry notypearea for copying? Catch key code, only allow Ctrl.
					07/12/22 1330 No. Parts of old text can be copied via the Edit Existing Text menu.
				 006x Don't allow save of entry with no text or title.
					16:50 Done
				 007x Context menu for entries? (Delete, Edit)
					07/11/22 1445 No. This functionality isn't important since app is destined for mobile UI.
				 008x Disallow clicking/typing in Selected Entry text on frmMain.
					07/10/22 1145 Done.
				 009x PIN show/hide on frmNewJournal.
					7/10/22 1400 Done.
		07/10/22 010x Search criteria is case sensitive. Should be a user choice (default insensitive).
					07/11/22 1430 Fixed.
				 011x Add Yes/No/Cancel prompt for Cancel/Exit on frmNewEntry.
					1130 Done.

	07/13/22 Dev. closed. v1.0 released.

	bugs/hotfixes:
		bugs: 
		001x 07/23/22 1330
			Fatal error when selecting an entry from lstEntries AFTER selecting entry > clicking 'week' or 'month' filter > selecting one of the entries shown in the filtered results.
			08/02/22 Declared fixed. Bug hasn't been seen since this incident. It is probably related to old journals and entries. Deleted all old test journals.

		002X 08/02/22 07:20
			There's a problem with date display. Some (older?) entry dates are "H:m:s" and others are "HH:mm:ss".
			09/10/22 FIXED
			
		toDo:
		07/23/22 001 Related to bug 001.
					WHEN CLICKING 'week' OR 'month' FILTER ...
						1) IF an entry is clicked, remember it.
						2) Clear currentEntry + rtb
						3) Show the filtered entries
						4) If one is the entry remembered in 1), select it.
			08/02/22 Update. Have disabled filter actions. NEEDS ATTENTION. HIDE FILTER CONTROLS UNTIL FIXED !!!

	enhancements:
		07/14/22 001x Add date selection for shown entries (e.g. last <x> days)
			07/15/22 0230 Is working with user specified number of weeks.
							> Should have user input a date? From a list of dates for all entries?
					 2315 Done with date selection and last week/month filter.
		07/27/22 002a For edit entry, edit original text, only show previous entry's .ClearText().
						Done.

		08/09/22 003 See frmSearch & Journal

		09/10/22 *************************** DATES ARE STILL NOT WORKING! SEE TODO 001 AND BUG 001 ABOVE! *************************************

		09/12/22 004 Add formatting to RTB's
					> frmNewEntry
					> frmMain (displaying full entry w/ richtext).


	10/15/22
		Fix search error when clicking found entry.
		Change frmNewEntry.Text after saving from 'new entry in <jrnl>' to 'editing <entry name>'.
			done
		Journal rename?
			did it

 */
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmMain : Form
	{
		Journal currentJournal;
		JournalEntry currentEntry;
		private bool firstSelection = true;

		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
			string version = fvi.FileVersion;
			this.Text = "myJournal " + version;
			LoadJournals();
			LoadFonts();
		}

		private void LoadFonts()
		{
			ListViewItem lvi = null;

			foreach (FontFamily f in System.Drawing.FontFamily.Families)
			{
				lvi = new ListViewItem();
				lvi.Font = new Font(f.Name, 8);
				lvi.Text = f.Name;
				Program.lstFonts.Add(lvi);
			}
		}

		private void frmMain_Resize(object sender, EventArgs e)
		{
			if (!rtbSelectedEntry.Visible)
			{
				lstEntries.Height = this.Height - 160;
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
					Utilities.PopulateEntries(lstEntries, currentJournal.Entries, DateTime.Now.AddDays(-30).ToShortDateString());

					if(lstEntries.Items.Count > 0)
					{
						lstEntries.Height = this.Height - lstEntries.Top - 50;
						lstEntries.Visible = true;
						ShowHideJournalMenus(true);
						PopulateShowFromDates();
						//pnlDateFilters.Visible = true;
						btnWeekMonth_Click(btnMonth, null);
					}
					else
					{
						lblWrongPin.Visible = true;
						txtJournalPIN.Focus();
						txtJournalPIN.SelectAll();
						ShowHideEntriesArea(false);
					}	
					btnLoadJournal.Enabled = false;
					mnuEntryEdit.Enabled = false;
				}
				else
				{
					lstEntries.Focus();
				}
			}
			catch (Exception ex) { Console.Write(ex.Message); }
		}

		private void btnWeekMonth_Click(object sender, EventArgs e)
		{
			//storedEntry = currentEntry;

			if (cbxDates.Items.Count > 0)
			{
				DateTime targetDate = DateTime.Now.AddDays(((Button)sender).Text.ToLower().Equals("week") ? -7 : -30);

				for (int i = 0; i < cbxDates.Items.Count; i++)
				{ if (DateTime.Parse(cbxDates.Items[i].ToString()) >= targetDate) { cbxDates.SelectedIndex = i; break; } }
			}
		}

		private void cbxDates_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(currentJournal != null)
			{
				Utilities.PopulateEntries(lstEntries, currentJournal.Entries, cbxDates.Text);

				if (lstEntries.SelectedIndex == -1 && currentJournal.Entries.Contains(currentEntry))
				{
					Utilities.SelectEntry(rtbSelectedEntry, lstEntries, null, true, currentEntry);
				}
			}
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
			currentEntry = null;
			currentJournal = null;
			cbxDates.DataSource = null;
			lblWrongPin.Visible = false;
			//pnlDateFilters.Visible = false;
		}

		private void lstEntries_SelectEntry(object sender, EventArgs e)
		{
			ListBox lb = (ListBox)sender;
			RichTextBox rtb = rtbSelectedEntry;
			lb.SelectedIndexChanged -= new System.EventHandler(this.lstEntries_SelectEntry);
			currentEntry = Utilities.SelectEntry(rtb, lb, currentJournal, firstSelection);
			firstSelection = false;
			lblSelectionType.Visible = rtb.Text.Length > 0;
			lblSeparator.Visible = rtb.Text.Length > 0;
			Utilities.ResizeListsAndRTBs(lstEntries, rtbSelectedEntry, lblSeparator, lblSelectionType, this);
			lb.SelectedIndexChanged += new System.EventHandler(this.lstEntries_SelectEntry);
			mnuEntryEdit.Enabled = true;
			mnuEntryDelete.Enabled = mnuEntryEdit.Enabled;
		}

		private void lblSeparator_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				lblSeparator.Top += e.Y;
				Utilities.ResizeListsAndRTBs(lstEntries, rtbSelectedEntry, lblSeparator, lblSelectionType, this);
				lstEntries.TopIndex = lstEntries.SelectedIndices[0];
			}
		}

		private void lblShowPIN_Click(object sender, EventArgs e)
		{
			txtJournalPIN.PasswordChar = txtJournalPIN.PasswordChar == '*' ? '\0' : '*';
			lblShowPIN.Text = lblShowPIN.Text == "show" ? "hide" : "show";
		}

		private void mnuEntryCreate_Click(object sender, EventArgs e)
		{
			frmNewEntry frm = new frmNewEntry(currentJournal);
			frm.Text = "New entry in " + currentJournal.Name;
			Utilities.Showform(frm, this);

			if(frm.saved)
			{ Utilities.PopulateEntries(lstEntries, currentJournal.Entries, cbxDates.Text); }

			frm.Close();
			this.Show();
		}

		private void mnuEntryDelete_Click(object sender, EventArgs e)
		{
			frmMessage frm = new frmMessage(frmMessage.OperationType.DeleteEntry, currentEntry.ClearTitle());
			Utilities.Showform(frm, this);
			if(frm.result == frmMessage.ReturnResult.Yes) 
			{
				currentJournal.Entries.Remove(currentEntry);
				currentJournal.Save();
				Utilities.PopulateEntries(lstEntries, currentJournal.Entries, cbxDates.Text);
				ShowHideEntriesArea(false);
				lstEntries.Visible = true;
				lstEntries.Height = this.Height - 160;
			}
			frm.Close();
			this.Show();
		}

		private void mnuEntryEdit_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;

			frmNewEntry frm = new frmNewEntry(currentJournal, currentEntry);
			frm.Text = "Edit '" + currentEntry.ClearTitle() + "' in '" + currentJournal.Name + "'";
			frm.preserveOriginalText = mnu.Text.ToLower().StartsWith("preserve");
			Utilities.Showform(frm, this);

			if (frm.saved)
			{
				Utilities.PopulateEntries(lstEntries, currentJournal.Entries, cbxDates.Text);
				ShowHideEntriesArea(false);
				lstEntries.Visible = true;
			}

			frm.Close();
			this.Show();
			this.Height += 1;
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
			this.Show();
		}

		private void mnuJournal_Delete_Click(object sender, EventArgs e)
		{
			frmMessage frm = new frmMessage(frmMessage.OperationType.DeleteJournal, currentJournal.Name);
			Utilities.Showform(frm, this);
			if (frm.result == frmMessage.ReturnResult.Yes)
			{
				currentJournal.Delete();
				ddlJournals.Text = string.Empty;
				lstEntries.Items.Clear();
				LoadJournals();
			}
			this.Show();
		}

		private void mnuRenameJournal_Click(object sender, EventArgs e)
		{
			frmMessage frm = new frmMessage(frmMessage.OperationType.InputBox);
			Utilities.Showform(frm, this);
			if (frm.result == frmMessage.ReturnResult.Ok && frm.input.Length > 0)
			{
				currentJournal.Rename(frm.input);
				LoadJournals();
			}
			this.Show();
		}

		private void mnuSearch_Click(object sender, EventArgs e)
		{
			Program.PIN = txtJournalPIN.Text;
			frmSearch frm = new frmSearch(currentJournal);
			Utilities.Showform(frm, this);
			this.Show();
		}

		private void rtbSelectedEntry_MouseDown(object sender, MouseEventArgs e)
		{
			lstEntries.Focus();
		}

		private void txtJournalPIN_TextChanged(object sender, EventArgs e)
		{
			btnLoadJournal.Enabled = true;
			lblShowPIN.Visible = txtJournalPIN.Text.Length > 0;
			lblWrongPin.Visible = false;
		}

		private void LoadJournals()
		{
			string rootPath = AppDomain.CurrentDomain.BaseDirectory;
			ddlJournals.Items.Clear();
			ddlJournals.Text = string.Empty;

			if (!Directory.Exists(rootPath + "/journals/"))
			{
				Directory.CreateDirectory(rootPath + "/journals/");
				Directory.CreateDirectory(rootPath + "/settings/");
				File.Create(rootPath + "/settings/settings");
				File.Create(rootPath + "/settings/labels");
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

		private void PopulateShowFromDates()
		{
			cbxDates.DataSource = null;
			List<string> l = currentJournal.Entries.Select(e => e.Date.ToShortDateString()).Distinct().ToList();
			cbxDates.DataSource = l;
		}

		private void ShowHideEntriesArea(bool show)
		{
			rtbSelectedEntry.Text = show ? rtbSelectedEntry.Text : string.Empty;
			rtbSelectedEntry.Visible = show;
			lblSeparator.Visible = show;
			lblSelectionType.Visible = show;
			lblEntries.Visible = show;
			lstEntries.Visible = show;
		}

		private void ShowHideJournalMenus(bool show)
		{
			mnuEntryTop.Enabled = show;
			mnuJournal_Delete.Enabled = show;
			mnuSearch.Enabled = show;
			lblEntries.Visible = show;
			mnuEntryEdit.Enabled = show;
			mnuEntryDelete.Enabled = show;
			mnuRenameJournal.Enabled = show;
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