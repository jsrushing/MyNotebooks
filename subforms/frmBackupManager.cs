/* Manage Backups
 * Created On: 10/25/22
 */
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using myNotebooks.objects;

namespace myNotebooks.subforms
{
	public partial class frmBackupManager : Form
	{
		string journalsFolder			= AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"];
		string backupFolder_Forced		= AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_NotebookForcedBackupsFolder"];
		string backupFolder_Incremental = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_NotebookIncrementalBackupsFolder"];
		public bool BackupRestored { get; private set; }

		public frmBackupManager(Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
		}

		private void frmBackupManager_Load(object sender, EventArgs e)
		{
			foreach (string s in Directory.GetFiles(backupFolder_Incremental))
			{ lstIncrementalBackups.Items.Add(s.Replace(backupFolder_Incremental, "")); }
			foreach (string s in Directory.GetFiles(backupFolder_Forced))
			{ lstForcedBackups.Items.Add(s.Replace(backupFolder_Forced, "")); }
			this.Size = this.MinimumSize;
		}

		private void btnExit_Click(object sender, EventArgs e) { Close(); }

		private void btnRestore_Click(object sender, EventArgs e)
		{
			var backupFilePath			= lstIncrementalBackups.SelectedIndices.Count > 0 ? backupFolder_Incremental + lstIncrementalBackups.SelectedItem.ToString() : string.Empty;
			var journalsFolderPath		= lstIncrementalBackups.SelectedIndices.Count > 0 ? journalsFolder + lstIncrementalBackups.SelectedItem.ToString() : string.Empty;
			var isForcedBackupRestore	= lstForcedBackups.SelectedIndices.Count > 0;
			var truncatedForcedFileName = string.Empty;

			if (isForcedBackupRestore)
			{ 
				backupFilePath = backupFolder_Forced + lstForcedBackups.SelectedItem.ToString();
				FileInfo fi = new FileInfo(backupFilePath);
				truncatedForcedFileName = lstForcedBackups.SelectedItem.ToString();
				truncatedForcedFileName = truncatedForcedFileName.Substring(0, truncatedForcedFileName.LastIndexOf(" ("));
				journalsFolderPath = journalsFolder + truncatedForcedFileName;

				using (frmMessage frm2 = new frmMessage(frmMessage.OperationType.InputBox, "Enter the PIN for '" + truncatedForcedFileName + "' so orphaned labels can be restored."))
				{
					frm2.ShowDialog();
					Program.PIN = frm2.ResultText;
				}
			}

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Do you want to restore the backup? The existing journal cannot be recovered!", "", this)) 
			{ 
				frm.ShowDialog(this); 

				if(frm.Result == frmMessage.ReturnResult.Yes) 
				{
					File.Move(backupFilePath, journalsFolderPath, true);
					using (frmMessage frm2 = new frmMessage(frmMessage.OperationType.Message, "The backup is restored.")) { frm2.ShowDialog();}	
					BackupRestored = true;
					//if (isForcedBackupRestore) { LabelsManager.Add(LabelsManager.FindOrphansInOneJournal(new Journal(truncatedForcedFileName).Open()); }
				}
			}


			this.Hide();
		}

		private void lstAvailableFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			pnlFileInfo_Forced.Visible = false;
			pnlFileInfo_Incremental.Visible = false;
			ShowFileInfo((ListBox)sender);
		}

		private string GetJournalNameWithoutDate(string nameWithDate)
		{
			return nameWithDate.Contains(" (") ? nameWithDate.Substring(nameWithDate.LastIndexOf(" (") + 1).Trim(')') : string.Empty;
		}

		private void ShowFileInfo(ListBox lb = null)
		{
			Label lblSize = lblFileSize_Incremental;
			Label lblDate = lblFileDate_Incremental;
			Panel pnl = pnlFileInfo_Incremental;
			string fName = lstIncrementalBackups.SelectedIndices.Count > 0 ? backupFolder_Incremental + lstIncrementalBackups.SelectedItem.ToString() : string.Empty;

			if (lb != null && lb.SelectedItems.Count == 1)
			{
				if(lb == lstIncrementalBackups)
				{ 
					lstForcedBackups.SelectedItems.Clear();
				}
				else if(lb == lstForcedBackups)
				{
					lblSize = lblFileSize_Forced;
					lblDate = lblFileDate_Forced;
					pnl = pnlFileInfo_Forced;
					fName = backupFolder_Forced + lstForcedBackups.SelectedItem.ToString();
					lstIncrementalBackups.SelectedItems.Clear();
				}

				FileInfo fi = new FileInfo(fName);
				lblSize.Text = fi.Length.ToString("###,###,###");
				lblDate.Text = fi.CreationTime.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]);

				pnl.Visible = true;
			}

		}
	}
}
