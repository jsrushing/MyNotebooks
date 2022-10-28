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
		public frmBackupManager()
		{
			InitializeComponent();
		}

		private void frmBackupManager_Load(object sender, EventArgs e)
		{
			string rootPath = AppDomain.CurrentDomain.BaseDirectory;
			foreach (string s in Directory.GetFiles(rootPath + ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"]))
			{ lstIncrementalBackups.Items.Add(s.Replace(rootPath + ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"], "")); }
			foreach (string s in Directory.GetFiles(rootPath + ConfigurationManager.AppSettings["FolderStructure_JournalForcedBackupsFolder"]))
			{ lstForcedBackups.Items.Add(s.Replace(rootPath + ConfigurationManager.AppSettings["FolderStructure_JournalForcedBackupsFolder"], "")); }
			this.Size = this.MinimumSize;
		}

		private void btnExit_Click(object sender, EventArgs e) { Close(); }

		private void btnRestore_Click(object sender, EventArgs e)
		{
			frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Do you want to restore the backup? The existing journal cannot be recovered!");
			Utilities.Showform(frm, this);
			if(frm.result == frmMessage.ReturnResult.Yes)
			{
				File.Copy("", "");
			}
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
			string fName = string.Empty;
			string root = AppDomain.CurrentDomain.BaseDirectory;

			if(lb != null && lb.SelectedItems.Count == 1)
			{
				if(lb == lstIncrementalBackups)
				{ 
					fName = root + ConfigurationManager.AppSettings["FolderStructure_JournalIncrementalBackupsFolder"] + lstIncrementalBackups.SelectedItem.ToString();
					lstForcedBackups.SelectedItems.Clear();
				}
				else if(lb == lstForcedBackups)
				{
					lblSize = lblFileSize_Forced;
					lblDate = lblFileDate_Forced;
					pnl = pnlFileInfo_Forced;
					fName = root + ConfigurationManager.AppSettings["FolderStructure_JournalForcedBackupsFolder"] + lstForcedBackups.SelectedItem.ToString();
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
