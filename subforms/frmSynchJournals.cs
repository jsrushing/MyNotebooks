using System;
using System.Configuration;
using System.Windows.Forms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmSynchJournals : Form
	{
		public frmSynchJournals(Form parent)
		{
			InitializeComponent();
			this.Location = new System.Drawing.Point(parent.Location.X + 25, parent.Location.Y + 25);
			this.Size = new System.Drawing.Size(364, 313);
			lstJournalsToSynch.DataSource = Utilities.AllJournalNames();
			lstJournalsToSynch.SelectedItems.Clear();
			btnCancel.Focus();
		}

		private void frmSynchJournals_Load(object sender, EventArgs e)
		{

		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			AzureFileClient fileClient = new AzureFileClient();

			fileClient.DownloadFile(ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"], "testfile.txt");


			//foreach(string journalName in lstJournalsToSynch.SelectedItems)
			//{
			//	fileClient.UploadFile(Program.AppRoot +  ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"] + journalName);
			//}

			//this.Close();
		}

		private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
		{
			if (chkSelectAll.Checked)
			{
				for(int i = 0; i < lstJournalsToSynch.Items.Count; i++) 
				{
					lstJournalsToSynch.SelectedItems.Add(lstJournalsToSynch.Items[i]);
				}
				chkSelectAll.Text = "un-select all";
			}
			else { lstJournalsToSynch.SelectedItems.Clear(); chkSelectAll.Text = "select all"; }

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
