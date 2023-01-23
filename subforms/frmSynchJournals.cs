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
		}

		private void frmSynchJournals_Load(object sender, EventArgs e)
		{
			lstJournalsToSynch.Items.Clear();
			foreach(Journal j in Utilities.AllJournals()) { lstJournalsToSynch.Items.Add(j.Name); }
			lstJournalsToSynch.SelectedItems.Clear();
			btnOk.Focus();
			pnlResults.Location = pnlMain.Location;
		}

		private async void btnOk_Click(object sender, EventArgs e)
		{
			this.Cursor					= Cursors.WaitCursor;
			List<string> itemsSkipped	= new List<string>();
			List<string> itemsSynchd	= new List<string>();
			var journalsFolder			= ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"];
			Journal j;

			for (int i = 0; i < lstJournalsToSynch.SelectedItems.Count; i++)
			{
				j = new Journal(lstJournalsToSynch.SelectedItems[i].ToString()).Open();

				if (j.AllowCloud)
				{
					AzureFileClient fileClient = new AzureFileClient();
					FileInfo downloadedAzureJournal = null;
					var error = string.Empty;

					try
					{
						await fileClient.DownloadFile(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"], j.Name);
						downloadedAzureJournal = new FileInfo(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_Temp"] + j.Name);
					}
					catch (Exception ex) { error = ex.Message; }

					if(downloadedAzureJournal.Length == 0)	// the Azure file didn't exist so upload it
					{
						fileClient.UploadFile(Program.AppRoot + journalsFolder + j.Name);
						itemsSynchd.Add(j.Name + " (created in cloud)");
					}
					else
					{
						if(error.Length == 0) 
						{ 
							FileInfo localJournal = new FileInfo(Program.AppRoot + journalsFolder + j.Name);

							if(localJournal.Length > downloadedAzureJournal.Length)			// local file has been updated
							{
								fileClient.UploadFile(Program.AppRoot + journalsFolder + j.Name);
								itemsSynchd.Add(j.Name + (" (syncd to Azure)"));
							}
							else if(downloadedAzureJournal.Length > localJournal.Length)	// Azure file has been updated
							{
								await fileClient.DownloadFile(Program.AppRoot + journalsFolder, j.Name);
								itemsSynchd.Add(j.Name + (" (syncd from Azure)"));
							}
							else { itemsSkipped.Add(j.Name + " (files match)"); }			// files match				
						}
						else 
						{ itemsSkipped.Add(j.Name + " error:" + error); }
						
						File.Delete(downloadedAzureJournal.FullName);
					}
				}
				else { itemsSkipped.Add(j.Name + " (cloud not allowed)"); }
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
