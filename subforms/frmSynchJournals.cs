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
			this.Location = new System.Drawing.Point(parent.Location.X + 25, parent.Location.Y + 25);
			//this.Size = new System.Drawing.Size(364, 313);

			foreach(Journal j in Utilities.AllJournals())
			{
				//lstJournalsToSynch.Items.Add(j);
				lstJournalsToSynch.Items.Add(j.Name.Remove(0, Program.DeviceId.Length + 1));
			}
			//lstJournalsToSynch.DataSource = Utilities.AllJournalNames(); 
			lstJournalsToSynch.SelectedItems.Clear();
			//lstJournalsToSynch.DisplayMember= "Name".Remove(0, Program.DeviceId.Length + 1);
			btnCancel.Focus();
			pnlResults.Location = pnlMain.Location;
		}

		private void frmSynchJournals_Load(object sender, EventArgs e)
		{

		}

		private async void btnOk_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			AzureFileClient fileClient = new AzureFileClient();
			FileInfo downloadedAzureJournal = null;
			Journal j = null;
			List<string> itemsSynchd = new List<string>();
			List<string> itemsSkipped = new List<string>();
			string error = string.Empty;

			for (int i = 0; i < lstJournalsToSynch.SelectedItems.Count; i++)
			{
				string fullJournalName = Program.DeviceId + "_" + lstJournalsToSynch.SelectedItems[i].ToString();

				j = new Journal(fullJournalName).Open(fullJournalName);

				if (j.AllowCloud)
				{
					try
					{
						await fileClient.DownloadFile(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"], j.Name);
						downloadedAzureJournal = new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"] + j.Name);
					}
					catch (Exception ex) { error = ex.Message; }

					if(downloadedAzureJournal.Length == 0)	// the Azure file didn't exist so upload it
					{
						fileClient.UploadFile(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"] + j.Name);
						itemsSynchd.Add(j.Name + " (created in cloud)");
					}
					else
					{
						if(error.Length == 0) 
						{ 
							FileInfo localJournal = new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"] + j.Name);

							if(localJournal.Length > downloadedAzureJournal.Length)			// local file has been updated
							{
								fileClient.UploadFile(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"] + j.Name);
								itemsSynchd.Add(j.Name + (" (syncd to Azure)"));
							}
							else if(downloadedAzureJournal.Length > localJournal.Length)	// Azure file has been updated
							{
								await fileClient.DownloadFile(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"], j.Name);
								itemsSynchd.Add(j.Name + (" (syncd from Azure)"));
							}
							else { itemsSkipped.Add(j.Name + " (files match)"); }			// files match				
						}
						else 
						{ itemsSkipped.Add(j.Name + " error:" + error); }
					}

					this.Cursor = Cursors.Default;
				}
				else { itemsSkipped.Add(j.Name + " (cloud not allowed)"); }
				File.Delete(downloadedAzureJournal.FullName);
			}

			lstSyncdJournals.DataSource = itemsSynchd;
			lstUnSyncdJournals.DataSource = itemsSkipped;
			pnlResults.Visible = true;

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
