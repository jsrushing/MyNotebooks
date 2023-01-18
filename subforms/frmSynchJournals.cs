using System;
using System.Configuration;
using System.Windows.Forms;
using myJournal.objects;
using System.IO;

namespace myJournal.subforms
{
	public partial class frmSynchJournals : Form
	{
		public frmSynchJournals(Form parent)
		{
			InitializeComponent();
			this.Location = new System.Drawing.Point(parent.Location.X + 25, parent.Location.Y + 25);
			this.Size = new System.Drawing.Size(364, 313);
			foreach(Journal j in Utilities.AllJournals())
			{
				lstJournalsToSynch.Items.Add(j);
				//lstJournalsToSynch.Items.Add(j.Name + "(" + j.AllowCloud.ToString() + ")");
			}
			//lstJournalsToSynch.DataSource = Utilities.AllJournalNames(); 
			lstJournalsToSynch.SelectedItems.Clear();
			lstJournalsToSynch.DisplayMember= "Name";
			btnCancel.Focus();
		}

		private void frmSynchJournals_Load(object sender, EventArgs e)
		{

		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			AzureFileClient fileClient = new AzureFileClient();
			FileInfo fiRemoteFile = null;
			Journal j = null;

			// see if the selected journal to synch is newer than the existing file (if it exists).
			//foreach(Journal j in lstJournalsToSynch.SelectedItems)
			for(int i = 0; i < lstJournalsToSynch.SelectedItems.Count; i++)
			{
				j = (Journal)lstJournalsToSynch.SelectedItems[i];

				if (j.AllowCloud)
				{
					// get the remote file, if it exists
					try
					{
						fileClient.DownloadFile(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"], j.Name);	
						fiRemoteFile = new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"] + j.Name);
					}
					catch(Exception) { }

					if(fiRemoteFile != null)
					{
						FileInfo fiLocalFile = new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"] + j.Name);

						if (fiLocalFile.Length != fiRemoteFile.Length) // the local file is younger - synch the file
						{
							fileClient.UploadFile(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"] + j.Name);
						}
					}
					else { fileClient.UploadFile(ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"] + j.Name); }
				}
				else
				{
					// perform local backup
				}
				this.Cursor=Cursors.Default;
			}




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
