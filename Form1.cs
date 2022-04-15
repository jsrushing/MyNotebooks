using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Linq;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using myJournal.forms;
using myJournal.subforms;
using encrypt_decrypt_string;

namespace myJournal
{
	public partial class Form1 : Form
	{
		Point ActiveBoxLocation		= new Point(0,0);
		Size ActiveBoxSize			= new Size(0, 0);
		Size MainFormSize			= new Size(0, 0);
        Journal currentJournal		= null;
        bool bTagBeingEdited		= false;
        string rootPath				= AppDomain.CurrentDomain.BaseDirectory;
		PrintDocument PrintDocument = new PrintDocument();
		PrintDialog	PrintDialog		= new PrintDialog();
        JournalEntry currentEntry	= null;
        Font InactiveMenuFont		= null;
        Font ActiveMenuFont			= null;
		GroupBox backTarget			= null;
		Form activeForm;
        GroupBox DisplayedGroupBox;
		Form DisplayedForm;

		[DllImport("User32.dll")]
		static extern Int64 SendMessage (IntPtr hwnd, Int64 wMsg, bool wParam, Object lParam);
		const Int64 EM_FMTLINES = 1;	// &HC8;


		protected Point CenterGroupBox(GroupBox boxToCenter, GroupBox boxBackground = null, int boxTop = -1, int boxHeight = 0)
		{
			int b1_Left	= (boxBackground == null ? this.Width / 2 : boxBackground.Width / 2) - boxToCenter.Width / 2;
			int b1_Top	= (boxTop > -1 ? boxTop : this.Height / 2) - boxToCenter.Height / 2;
			return new Point(b1_Left, b1_Top);
		}
		public Form1()
        { 
			InitializeComponent(); 
			PrintDocument.PrintPage += new PrintPageEventHandler(PrintPage); 
		}

        private void Form1_Load(object sender, EventArgs e)
        {
			//frmPlay frm = new frmPlay();
			//frm.ShowDialog();


			//Int64 val = Convert.ToInt64("FC8");
			//byte[] buffer = { &HA9, &HC8, &HE6, &HC4 };

			activeForm = new frmMain();

			int x = Convert.ToInt16(ConfigurationManager.AppSettings["Left_ActiveBox"]);
			int y = Convert.ToInt16(ConfigurationManager.AppSettings["Top_ActiveBox"]);
			ActiveBoxLocation = new Point(x,y);
			x = Convert.ToInt16(ConfigurationManager.AppSettings["Width_ActiveBox"]);
			y = Convert.ToInt16(ConfigurationManager.AppSettings["Height_ActiveBox"]);
			ActiveBoxSize = new Size(x,y);
			x = Convert.ToInt16(ConfigurationManager.AppSettings["Width_MainForm"]);
			y = Convert.ToInt16(ConfigurationManager.AppSettings["Height_MainForm"]);
			MainFormSize = new Size(x, y);

            LoadJournals();

			lblJournal_Delete.Enabled	= ddlJournals.Enabled;
            DisplayedGroupBox			= grpOpenScreen;
            this.Size					= MainFormSize;
            pnlMenu.Size				= new Size(lblMenu_1.Width + 2, lblMenu_1.Height + 2);
			pnlMenu.Location			= new Point(lblMenu.Left + lblMenu.Width, lblMenu.Top + lblMenu.Height);
            lblMenu_0.Size				= new Size(pnlMenu.Width, pnlMenu.Height);
            lblMenu_1.Size				= new Size(lblMenu_0.Width - 4, lblMenu_1.Height - 2);
            lblMenu_1.Location			= new Point(lblMenu_0.Left + 2, lblMenu_0.Top + 2);
            InactiveMenuFont			= lblJournal_Create.Font;
			FontStyle fs				= FontStyle.Bold | FontStyle.Italic;
            ActiveMenuFont				= new Font(InactiveMenuFont.FontFamily, InactiveMenuFont.Size + 1);
			ActiveMenuFont				= new Font(ActiveMenuFont, fs);

			ActivateGroupBox(grpOpenScreen);
			//ActivateGroupBox(grpLogin);
			ActivateForm(new frmLogin());
		}

		private void Form1_Resize(object sender, EventArgs e)
        {
            DisplayedGroupBox.Location = ActiveBoxLocation;
            DisplayedGroupBox.Size = new Size(this.Width - 35, this.Height - 50);
			ResizeListsAndRTBs(lstEntries, rtbSelectedEntry_Main, lblSeparator_grpOpenScreen);
		}

		private void ActivateForm(Form frmToActivate)
		{
			DisplayedForm = frmToActivate;
			pnlMenu.Visible = false;
			frmToActivate.Size = this.Size;
			frmToActivate.ShowDialog();
			frmToActivate.Close();

			switch (DisplayedForm.Name) {
				case ("frmLogin"):
					if(ConfigurationManager.AppSettings["CloseApp"] == "True")
					{ this.Close(); }
					else
					{ ActivateGroupBox(grpOpenScreen); }
					break;
			}			
		}

        /// <summary>
        /// Show a group box. Change form Text, set focus, etc. as required for that group box.
        /// </summary>
        /// <param name="box"></param>
        private void ActivateGroupBox(GroupBox box)
        {
            TextBox txtBxToFocus = null;
			Button btnToFocus = null;

            foreach (Control c in this.Controls)
            {
				if(c.GetType().Name.ToLower() == "groupbox")
				{
					((GroupBox)c).Visible = false;
				}
            }

            switch (box.Name)
            {
				//case "grpLogin":
				//	this.Text = "Login";
				//	pnlPIN.Location = new Point((grpLogin.Width / 2) - (pnlPIN.Width / 2), 10);
				//	ConfigurationManager.AppSettings["PIN"] = string.Empty;
				//	txtBxToFocus = txtPin1;
				//	btnToFocus = btnPIN;
				//	break;
                case "grpOpenScreen":
                    this.Text = "My Journal";
                    rtbSelectedEntry_Main.Clear();
					lstEntries.Height = grpOpenScreen.Height - 100;
					ResizeListsAndRTBs(lstEntries, rtbSelectedEntry_Main, lblSeparator_grpOpenScreen);
					break;
                case "grpCreateEntry":
					btnAddEntry.Text = "Save Entry";
                    this.Text = "Create Entry";
					if(backTarget == null)
					{
						txtNewEntryTitle.Text = String.Empty;
						rtbNewEntry.Clear();
					}
                    grpAppendDeleteOriginal.Visible = false;
                    txtBxToFocus = this.txtNewEntryTitle;
                    Tags_PopulateTagsList(lstTags);
					foreach(int i in lstTags.CheckedIndices) { lstTags.SetItemChecked(i, false); }
                    break;
                case "grpDeleteJournal":
                    lblDeleteJournal_ConfirmMsg.Visible = false;
                    lblDeleteJournal_ConfirmMsg.Text = " will be deleted. Press Delete to confirm.";
                    ddlJournalsToDelete.Visible = true;
                    lblJournalToDelete.Visible = true;
                    ddlJournalsToDelete.Text = ddlJournals.Text.Length > 0 ? ddlJournals.Text : String.Empty;
                    break;
                case "grpFindEntry":
                    this.Text = "Search Journal";
                    Tags_PopulateTagsList(lstGroupsForSearch);
					lstGroupsForSearch.Location = new Point(txtGroupsForSearch.Left, txtGroupsForSearch.Top + txtGroupsForSearch.Height);
					lstGroupsForSearch.Visible = false ;
					txtGroupsForSearch.Text = String.Empty;
					lstFoundEntries.Items.Clear();
					rtbSelectedEntry_Found.Text = String.Empty;
                    //txtGroupsForSearch.Text = Properties.Settings.Default["TxtSelectGroupsForSearchDefault"].ToString();
                    break;
                case "grpManageTags":
                    this.Text = "Create New Group";
					Tags_PopulateTagsList(null, lstTagsForEdit);
					grpEditTags_NewName.Visible = false;
					txtBxToFocus = this.txtTags_TagName_NewTag;
					lblEditTag.Enabled = lstTagsForEdit.SelectedIndex > -1;
					lblRemoveTag.Enabled = lblEditTag.Enabled;
					lblMoveDown.Enabled = lblEditTag.Enabled;
					lblMoveUp.Enabled = lblEditTag.Enabled;
                    break;
                case "grpNewJournal":
                    this.Text = "Create New Journal";
                    txtBxToFocus = this.txtNewJournalName;
					lblMessage_BadJournalName.Location = new Point(6, 30);
					lblMessage_BadJournalName.Width = grpNewJournal.Width - 3;
                    break;
            }

            pnlMenu.Visible		= false;
			box.Location		= ActiveBoxLocation;
            box.Visible			= true;
            DisplayedGroupBox	= box;
			backTarget			= null;
            this.Height			+= 1;
            if (txtBxToFocus != null) txtBxToFocus.Focus();
			if (btnToFocus != null) this.AcceptButton = btnToFocus;
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
						sTitle = txtNewEntryTitle.Text;
					}
					else
					{
						sTitle = lblEntryTitle_Hidden.Text;
                        sText = lblEntryText_Hidden.Text;
					}

					currentJournal.ReplaceEntry(currentEntry, new JournalEntry(sTitle, sText, sGroups, ConfigurationManager.AppSettings["PIN"], true));
				}
				else
				{
					currentJournal.AddEntry(new JournalEntry(txtNewEntryTitle.Text, rtbNewEntry.Text, sGroups, ConfigurationManager.AppSettings["PIN"], true));
				}
                currentJournal.Save();
                PopulateEntries(lstEntries);
            }

            txtNewEntryTitle.Text = String.Empty;
            rtbNewEntry.Clear();
            foreach(int i in lstTags.CheckedIndices) { lstTags.SetItemChecked(i, false); }
            ActivateGroupBox(grpOpenScreen);
        }

		/// <summary>
		/// Deleting Entry - do the delete
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOk_DeleteEntry_Click(object sender, EventArgs e)
		{
			currentJournal.Entries.Remove(currentEntry);
			currentJournal.Save();
			PopulateEntries(lstEntries);
			ActivateGroupBox(grpOpenScreen);
		}
		
		/// <summary>
		/// Deleting Journal - show confirmation message or do the delete
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOK_DeleteJournal_Click(object sender, EventArgs e)
        {
            if (lblDeleteJournal_ConfirmMsg.Visible)
            {
                if (currentJournal == null) { new Journal(ConfigurationManager.AppSettings["PIN"], ddlJournalsToDelete.Text).Open().Delete(); } else { currentJournal.Delete(); }
                currentJournal = null;
                LoadJournals();
                ddlJournals.Text = String.Empty;
                lstEntries.Items.Clear();
                rtbSelectedEntry_Main.Text = String.Empty;
                ActivateGroupBox(grpOpenScreen);
            }
            else
            {
                lblDeleteJournal_ConfirmMsg.Location = new Point(grpDeleteJournal.Width/2 - lblDeleteJournal_ConfirmMsg.Width / 2, lblDeleteJournal_ConfirmMsg.Top);
                lblDeleteJournal_ConfirmMsg.Text = "'" + ddlJournalsToDelete.Text + "' " + lblDeleteJournal_ConfirmMsg.Text;
                ddlJournalsToDelete.Visible = false;
                lblJournalToDelete.Visible = false;
                lblDeleteJournal_ConfirmMsg.Visible = true;
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
					Journal jrnl = new Journal(ConfigurationManager.AppSettings["PIN"], txtNewJournalName.Text);
					jrnl.Create();
					LoadJournals();
					ActivateGroupBox(grpOpenScreen);
				}
				catch (Exception) { lblMessage_BadJournalName.Visible = true; }
			}
        }

		/// <summary>
		/// Save a tag edit.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
			pnlMenu.Visible = false;
			lstEntries.Items.Clear();
            rtbSelectedEntry_Main.Text = string.Empty;

			try
			{
				currentJournal = new Journal(ConfigurationManager.AppSettings["PIN"], ddlJournals.Text).Open(ddlJournals.Text); 

				if(currentJournal != null)
				{
					PopulateEntries(lstEntries);
					lblCreateEntry.Enabled = true; 
					lblFindEntry.Enabled = true;
					lblViewJournal.Enabled = true;
					lblSelectAJournal.Enabled = true;
					lblSelectAJournal.Text = "Entries";
					lstEntries.Height = grpOpenScreen.Height - 100;
				}
				else
				{
					lstEntries.Focus();
				}
			}
			catch(Exception) { }
        }

        #region Tags
        private void Tags_btnAddTag_Click(object sender, EventArgs e) { ActivateGroupBox(backTarget != null ? backTarget : grpOpenScreen); }

		/// <summary>
		/// Add new or edit a tag.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Tags_btnOK_NewTag_Click(object sender, EventArgs e)
        {
            if (!bTagBeingEdited)
            {
                using (StreamWriter sw = File.AppendText(rootPath + "/settings/groups"))
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
			backTarget = new GroupBox();
            ActivateGroupBox(grpCreateEntry);
            bTagBeingEdited = false;
        }

		/// <summary>
		/// Show the edit tags controls.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Tags_mnuEdit_Click(object sender, EventArgs e)
        {
            txtTags_TagName_NewTag.Text = lstTags.SelectedItem.ToString();
            bTagBeingEdited = true;
            ActivateGroupBox(grpManageTags);
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

            foreach (string group in File.ReadAllLines(rootPath + "/settings/groups"))
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
            File.WriteAllText(rootPath + "/settings/groups", sb.ToString());
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
			lblDeleteEntry_ConfirmMsg.Text = "'" + currentEntry.ClearTitle() + "' " + lblDeleteEntry_ConfirmMsg.Text;
			ActivateGroupBox(grpConfirmDeleteEntry);
        }

		/// <summary>
		/// Show tag edit controls.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lblEditTag_Click(object sender, EventArgs e)
		{
			if(lstTagsForEdit.SelectedIndex > -1)
			{
				grpEditTags_NewName.Location = grpEditTags_Add.Location;
				grpEditTags_NewName.Height = grpEditTags_EditRemove.Top + grpEditTags_EditRemove.Height;
				grpEditTags_NewName.Width = grpEditTags_Add.Width;
				txtTag_TagName_Edited.Text = lstTagsForEdit.SelectedItem.ToString();
				grpEditTags_NewName.Visible = true;
				txtTag_TagName_Edited.SelectAll();
				txtTag_TagName_Edited.Focus();
				backTarget = grpManageTags;
			}
		}

		/// <summary>
		/// Configure and show the edit entry group box.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void lblEditEntry_Click(object sender, EventArgs e)
        {
            ActivateGroupBox(grpCreateEntry);
			btnAddEntry.Text = "Save Edit";
			txtNewEntryTitle.Text = currentEntry.ClearTitle(ConfigurationManager.AppSettings["PIN"]);
            lblEntryText_Hidden.Text = currentEntry.ClearText(ConfigurationManager.AppSettings["PIN"]);
            lblEntryTitle_Hidden.Text = currentEntry.ClearTitle(ConfigurationManager.AppSettings["PIN"]);
            string newLine = System.Environment.NewLine;

			rtbNewEntry.Text = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Editing"], currentEntry.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"])
				, currentEntry.ClearTitle(ConfigurationManager.AppSettings["PIN"]), currentEntry.ClearText(ConfigurationManager.AppSettings["PIN"]));

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
        /// Show the delete journal controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        private void lblJournal_Delete_Click(object sender, EventArgs e)
        {
            foreach (string s in ddlJournals.Items)
            {
                ddlJournalsToDelete.Items.Add(s);
            }
            ActivateGroupBox(grpDeleteJournal);
        }

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

            Journal j = new Journal(ConfigurationManager.AppSettings["PIN"]);
            Journal journalToSearch = new Journal(ConfigurationManager.AppSettings["PIN"]);

            foreach (string journalName in journalNames)
            {
                journalToSearch = j.Open(journalName);

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
					if (txtGroupsForSearch.Text.Length > 0)

					{
						string[] groups = txtGroupsForSearch.Text.Split(',');
                        foreach (string group in groups)
                        {
                            if (je.ClearTags().Contains(group)) { foundEntries.Add(je); }
                        }
                    }
                    // title contains
                    if (txtSearchTitle.TextLength > 0) { if (je.ClearTitle(ConfigurationManager.AppSettings["PIN"]).Contains(txtSearchTitle.Text)) { foundEntries.Add(je); } }
                    // entry contains
                    if (txtSearchText.TextLength > 0) { if (je.ClearText(ConfigurationManager.AppSettings["PIN"]).Contains(txtSearchText.Text)) { foundEntries.Add(je); } }
                }
            }

            if (foundEntries.Count > 0)
            {
                PopulateEntries(lstFoundEntries, foundEntries);
				lblFoundEntries.Visible = true;
            }

        }

        private void lblHome_Click(object sender, EventArgs e) 
		{
			GroupBox gb = backTarget == null ? grpOpenScreen : backTarget;
			ActivateGroupBox(gb);
		}

		private void lblJournal_Create_Click(object sender, EventArgs e) { ActivateGroupBox(grpNewJournal); }

		private void lblMenu_Click(object sender, EventArgs e) { pnlMenu.Visible = !pnlMenu.Visible; }

		/// <summary>
		/// Print the contents of rtbSelectedEntry.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lblPrint_Click(object sender, EventArgs e)
		{
			PrintDialog.Document = PrintDocument;
			if (PrintDialog.ShowDialog() == DialogResult.OK)
			{
				PrintDocument.Print();
			}
		}

		private void lblRemoveTag_Click(object sender, EventArgs e)
		{
			int a = lstTagsForEdit.SelectedIndex;

			if (a > -1)
			{
				lstTagsForEdit.Items.RemoveAt(a);
				grpEditTags_NewName.Visible = false;
				Tags_Save(null, lstTagsForEdit);
				Tags_PopulateTagsList(lstTags);
			}

		}

		private void lblSettings_Show_Click(object sender, EventArgs e)
		{

		}

		private void lblTagManager_Click(object sender, EventArgs e) 
		{
			Label label = (Label)sender;
			ActivateGroupBox(grpManageTags);
			backTarget = label.Name.EndsWith("2") ? grpCreateEntry : grpOpenScreen;
		}

		private void lblViewJournal_Click(object sender, EventArgs e)
		{
			pnlMenu.Visible = false;
			rtbSelectedEntry_Main.Text = currentJournal.GetAllEntries();
			lblSelectionType.Visible = true;
			lblPrint.Visible = lblSelectionType.Visible;
			lblSelectionType.Text = "All Entries";
		}

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

            if (!Directory.Exists(rootPath + "/journals/"))
            {
                Directory.CreateDirectory(rootPath + "/journals/");
                Directory.CreateDirectory(rootPath + "/settings/");
                File.Create(rootPath + "/settings/settings");
                File.Create(rootPath + "/settings/groups");
            }
            else
            {
                foreach(string s in Directory.GetFiles(rootPath + "/journals/"))
                {
                    ddlJournals.Items.Add(s.Replace(rootPath + "/journals/", ""));
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
            ListBox.SelectedIndexCollection cltnLbSelectedEntries = lb.SelectedIndices;
			pnlMenu.Visible = false;

			try
			{
				if (cltnLbSelectedEntries.Count > 1)
				{
					for (int i = 0; i < cltnLbSelectedEntries.Count - 1; i++)
					{
						if (cltnLbSelectedEntries[i] == cltnLbSelectedEntries[i + 1] - 1)
						{
							targets.Add(cltnLbSelectedEntries[i]);
							targets.Add(cltnLbSelectedEntries[i + 1]);
							targets.Add(cltnLbSelectedEntries[i + 2]);
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

			if(currentEntry != null)
			{
				StringBuilder sb = new StringBuilder();
				rtb.Text = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
					//, currentJournal.Name
					, currentEntry.ClearTitle(ConfigurationManager.AppSettings["PIN"]), currentEntry.Date
					, currentEntry.ClearTags(ConfigurationManager.AppSettings["PIN"])
					, currentEntry.ClearText(ConfigurationManager.AppSettings["PIN"]));
				lblEditEntry.Enabled = true;
				lblPrint.Visible = rtb.Text.Length > 0;
				grpSelectedEntryLabels.Visible = rtb.Text.Length > 0;
				lblSeparator_grpOpenScreen.Visible = rtb.Text.Length > 0;
				lblSelectedFoundEntry.Visible = rtbSelectedEntry_Found.Text.Length > 0;
				lblSelectionType.Text = "Selected Entry";
				lstEntries.Height = rtb.Text.Length > 0 ? rtbSelectedEntry_Main.Top - 132 : grpOpenScreen.Height - 100;
				lstEntries.TopIndex = lstEntries.Top + lstEntries.Height < rtbSelectedEntry_Main.Top ? ctr : lstEntries.TopIndex;
			}

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
				// add display of isEdited here
                lstBoxToPopulate.Items.Add(je.ClearTitle(ConfigurationManager.AppSettings["PIN"]) + " (" + je.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")"); //+ (je.isEdited ? " - EDITED" : ""));
                string sEntryText = je.ClearText(ConfigurationManager.AppSettings["PIN"]);

                lstBoxToPopulate.Items.Add(sEntryText.Length < iTextChunkLength ?
                    sEntryText :
                    sEntryText.Substring(0, iTextChunkLength) + " ...");

                lstBoxToPopulate.Items.Add("tags: " + je.ClearTags(ConfigurationManager.AppSettings["PIN"]));
                lstBoxToPopulate.Items.Add("---------------------");
            }

			if(lstBoxToPopulate.Items.Count > 0)
			{
				lstBoxToPopulate.Height = lstBoxToPopulate.Height + rtbSelectedEntry_Main.Height;
			}

			lblJournal_Import.Enabled = true;
        }

		private void PrintPage(object sender, PrintPageEventArgs e)
		{
			int linesPrinted = 0;
			Brush brush = new SolidBrush(rtbSelectedEntry_Main.ForeColor);
			string[] lines = rtbSelectedEntry_Main.Text.Split('\n');
			int x = e.MarginBounds.Left;
			int y = e.MarginBounds.Top;

			foreach(string line in lines)
			{
				while (linesPrinted < lines.Length)
				{
					e.Graphics.DrawString(lines[linesPrinted++], rtbSelectedEntry_Main.Font, brush, x, y);
					y += 15;
					if(y >= e.MarginBounds.Bottom)
					{
						e.HasMorePages = true;
						return;
					}
					linesPrinted = 0;
					e.HasMorePages = false;
				}
			}
			//e.Graphics.DrawString(rtbSelectedEntry_Main.Text.Split('\n'), rtbSelectedEntry_Main.Font, Brushes.Black, 20, 20);
		}

        /// <summary>
        /// Disallow focus on rtb used for displaying entry text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbSelectedEntry_Main_Click(object sender, EventArgs e) { pnlMenu.Visible = false; ddlJournals.Focus(); }

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

		private void ddlJournals_Click(object sender, EventArgs e) 
		{ 
			lblPrint.Visible = false; 
			pnlMenu.Visible = false; 
			lblSeparator_grpOpenScreen.Visible = false;
		}

		/// <summary>
		/// Populate rtbSelectedEntry with entire journal contents.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rtbSelectedEntry_Main_TextChanged(object sender, EventArgs e)
		{
			lblSelectionType.Visible = rtbSelectedEntry_Main.Text.Length > 0;
		}

		private void lblMoveUpDown_Click(object sender, EventArgs e)
		{
			if(lstTagsForEdit.SelectedIndex > -1)
			{
				Label l = (Label)sender;
				int iOriginal = lstTagsForEdit.SelectedIndex;
				int iOffset = lstTagsForEdit.SelectedIndex + (l.Name.ToLower().Contains("up") ? 1 : -1);
				string sItem = lstTagsForEdit.SelectedItem.ToString();
				lstTagsForEdit.Items.RemoveAt(iOriginal);
				lstTagsForEdit.Items.Insert(iOriginal + iOffset, sItem);
			}
		}

		private void lstTagsForEdit_SelectedIndexChanged(object sender, EventArgs e)
		{
			lblMoveDown.Enabled = lstTagsForEdit.SelectedIndex != lstTagsForEdit.Items.Count - 1;
			lblMoveUp.Enabled = lstTagsForEdit.SelectedIndex > 0;
			lblEditTag.Enabled = true;
			lblRemoveTag.Enabled = true;
		}

		private void lblLogOut_Click(object sender, EventArgs e)
		{
			ActivateForm(new frmLogin());
		}

		private void lblSeparator_grpOpenScreen_MouseMove(object sender, MouseEventArgs e)
		{
			//rtbSelectedEntry_Main.Visible = false;

			if (e.Button == MouseButtons.Left)
			{
				lblSeparator_grpOpenScreen.Top += e.Y;
				ResizeListsAndRTBs(lstEntries, rtbSelectedEntry_Main, lblSeparator_grpOpenScreen);	
			}
		}

		private void ResizeListsAndRTBs(ListBox lbx, RichTextBox rtb, Label lblSeperator)
		{
			int iBoxCenter = lbx.Width / 2;
			lblSeperator.Left = lbx.Left + 10;
			lblSeperator.Width = lbx.Width - 20;
			lbx.Height = lblSeperator.Top - lbx.Top - 5;
			grpSelectedEntryLabels.Top = lblSeperator.Top + lblSeperator.Height + 10;
			rtb.Top = grpSelectedEntryLabels.Top + grpSelectedEntryLabels.Height;
			rtb.Height = DisplayedGroupBox.Height - rtb.Top - 10;
		}

		private void lblJournal_Import_Click(object sender, EventArgs e)
		{	
			ActivateForm(new frmImportJournal(new Point(this.Left, this.Top), ddlJournals));
		}
	}
}
