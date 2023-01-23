using System;
using System.Configuration;
using System.Windows.Forms;
using myJournal.objects;
using System.IO;
using System.Collections.Generic;

namespace myJournal.subforms
{
	public partial class frmSynchJournals : Form
	{
		public frmSynchJournals(Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);

			foreach(Journal j in Utilities.AllJournals())
			{
				lstJournalsToSynch.Items.Add(j.Name.Remove(0, Program.DeviceId.Length + 1));
			}
			//lstJournalsToSynch.DataSource = Utilities.AllJournalNames(); 
			lstJournalsToSynch.SelectedItems.Clear();
			//lstJournalsToSynch.DisplayMember= "Name".Remove(0, Program.DeviceId.Length + 1);
			btnOk.Focus();
			pnlResults.Location = pnlMain.Location;
		}

		private void frmSynchJournals_Load(object sender, EventArgs e)
		{

		}

		private async void btnOk_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			string fullJournalName = string.Empty;
			Journal j = null;
			List<string> itemsSkipped = new List<string>();
			List<string> itemsSynchd = new List<string>();

			for (int i = 0; i < lstJournalsToSynch.SelectedItems.Count; i++)
			{
				fullJournalName = Program.DeviceId + "_" + lstJournalsToSynch.SelectedItems[i].ToString();
				j = new Journal(fullJournalName).Open(fullJournalName);

				if (j.AllowCloud)
				{
					AzureFileClient fileClient = new AzureFileClient();
					FileInfo downloadedAzureJournal = null;
					var error = string.Empty;

					try
					{
						await fileClient.DownloadFile(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"], j.Name);
						downloadedAzureJournal = new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"] + j.Name);
					}
					catch (Exception ex) { error = ex.Message; }

					if(downloadedAzureJournal.Length == 0)	// the Azure file didn't exist so upload it
					{
						fileClient.UploadFile(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"] + j.Name);
						itemsSynchd.Add(j.Name.Remove(0, Program.DeviceId.Length + 1) + " (created in cloud)");
					}
					else
					{
						if(error.Length == 0) 
						{ 
							FileInfo localJournal = new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"] + j.Name);

							if(localJournal.Length > downloadedAzureJournal.Length)			// local file has been updated
							{
								fileClient.UploadFile(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"] + j.Name);
								itemsSynchd.Add(j.Name.Remove(0, Program.DeviceId.Length + 1) + (" (syncd to Azure)"));
							}
							else if(downloadedAzureJournal.Length > localJournal.Length)	// Azure file has been updated
							{
								await fileClient.DownloadFile(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"], j.Name);
								itemsSynchd.Add(j.Name.Remove(0, Program.DeviceId.Length + 1) + (" (syncd from Azure)"));
							}
							else { itemsSkipped.Add(j.Name.Remove(0, Program.DeviceId.Length + 1) + " (files match)"); }			// files match				
						}
						else 
						{ itemsSkipped.Add(j.Name.Remove(0, Program.DeviceId.Length + 1) + " error:" + error); }
						
						File.Delete(downloadedAzureJournal.FullName);
					}
				}
				else { itemsSkipped.Add(j.Name.Remove(0, Program.DeviceId.Length + 1) + " (cloud not allowed)"); }
			}

			lstSyncdJournals.DataSource = itemsSynchd;
			lstUnSyncdJournals.DataSource = itemsSkipped;
			pnlResults.Visible = true;
			this.Cursor = Cursors.Default;
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

		private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }
	}
}
