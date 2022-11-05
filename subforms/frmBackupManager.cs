/* Manage Backups
 * Created On: 10/25/22
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myJournal.subforms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmBackupManager : Form
	{
		string journalsFolder			= AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_JournalsFolder"];
		string backupFolder_Forced		= AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_JournalForcedBackupsFolder"];
		string backupFolder_Incremental = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"];
		public bool BackupRestored { get; private set; }

		public frmBackupManager()
		{
			InitializeComponent();
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
			string backupFilePath = lstIncrementalBackups.SelectedIndices.Count > 0 ? backupFolder_Incremental + lstIncrementalBackups.SelectedItem.ToString() : string.Empty;
			string journalsFolderPath = lstIncrementalBackups.SelectedIndices.Count > 0 ? journalsFolder + lstIncrementalBackups.SelectedItem.ToString() : string.Empty;

			if (lstForcedBackups.SelectedIndices.Count > 0)
			{ 
				backupFilePath = backupFolder_Forced + lstForcedBackups.SelectedItem.ToString();
				string truncatedForcedFileName = lstForcedBackups.SelectedItem.ToString();
				FileInfo fi = new FileInfo(backupFilePath);
				truncatedForcedFileName = truncatedForcedFileName.Substring(0, truncatedForcedFileName.IndexOf('_' + fi.CreationTime.ToString(ConfigurationManager.AppSettings["DateFormat_ForcedBackupFileName"])));
				journalsFolderPath = journalsFolder + truncatedForcedFileName; 
			}

			frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Do you want to restore the backup? The existing journal cannot be recovered!");
			Utilities.Showform(frm, this);

			if(frm.result == frmMessage.ReturnResult.Yes) 
			{
				File.Move(backupFilePath, journalsFolderPath, true);
				frm.Close();
				frm = new frmMessage(frmMessage.OperationType.Message, "The backup is restored.");
				BackupRestored = true;
			}
			this.Hide();
		}

		private void lstAvailableFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			pnlFileInfo_Forced.Visible = false;
			pnlFileInfo_Incremental.Visible = false;
			ShowFileInfo((ListBox)sender);
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
