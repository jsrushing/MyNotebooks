/* Main form.
	04/01/22
	07/06/22 - Dev. ended. In test.
	bug list:
		07/07/22 1100
			0001x Can arrow down or right into no type area.
			> 0002x Can select and drag into or out of no type area.
				1400 Fixed
		07/08/22 1000
			0003x Save entry edit sometimes leaves out Text.
				1740 Found issue. Entries with '(' in the title cause failure to build currentEntry (it remains null after entry is selected).
				1745 Fixed: When selecting in the short entry (lstEntries) get LastIndexOf('(') instead of just .IndexOf.

			0004x Entries with no text cannot be edited or deleted (menus are disabled because they toggle on rtbSelectedEntry.Text.Length > 0).
				1745 Fixed with 0003. This should never happen. Only came up because of 0003.

	toDo:
		07/07/22 001 Entry RTB formatting controls.
				 > 002 Save .RichText instead of just .Text;
				002ax Add password char for PIN and show/hide function.
					1730 Done.
		07/08/22 003x Column tab stops in rtbNewEntry.
					07/10/22 1810 Done (was simple properties setting - .AcceptTab)
				 004x Save new entry without exiting (to save incrementally)?
					07/11/22 1445 No. Have user save entry then edit if desired.
				 005 Allow selection length > 1 in editing entry notypearea for copying? Catch key code, only allow Ctrl.
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

 */
using System;
using System.IO;
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
					Utilities.PopulateEntries(lstEntries, currentJournal.Entries);

					if(lstEntries.Items.Count > 0)
					{
						lstEntries.Height = this.Height - lstEntries.Top - 50;
						lstEntries.Visible = true;
						ShowHideJournalMenus(true);
					}
					else
					{
						lblWrongPin.Visible = true;
						txtJournalPIN.Focus();
						txtJournalPIN.SelectAll();
						ShowHideEntriesArea(false);
					}	
					btnLoadJournal.Enabled = false;
				}
				else
				{
					lstEntries.Focus();
				}
			}
			catch (Exception) { }
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
			mnuEntryEdit.Enabled = false;
			mnuEntryDelete.Enabled = false;
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
			mnuEntryEdit.Enabled = true;	// rtbSelectedEntry.Text.Length > 0;
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
			frmNewEntry frm = new frmNewEntry();
			Utilities.Showform(frm, this);
			if(frm.entry != null)
			{
				currentJournal.AddEntry(frm.entry);
				currentJournal.Save();
				Utilities.PopulateEntries(lstEntries, currentJournal.Entries);
			}
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
				Utilities.PopulateEntries(lstEntries, currentJournal.Entries);
				ShowHideEntriesArea(false);
				lstEntries.Visible = true;
				lstEntries.Height = this.Height - 160;
			}
			frm.Close();
			this.Show();
		}

		private void mnuEntryEdit_Click(object sender, EventArgs e)
		{
			frmNewEntry frm = new frmNewEntry(currentEntry);
			Utilities.Showform(frm, this);

			if (frm.entry != null)
			{
				currentEntry.Replace(frm.entry);
				currentJournal.Save();
				Utilities.PopulateEntries(lstEntries, currentJournal.Entries);
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
			btnLoadJournal.Enabled = false;
			txtJournalPIN.Text = string.Empty;
			lstEntries.Visible = false;
			ShowHideEntriesArea(false);
			ShowHideJournalMenus(false);
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
