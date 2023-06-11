using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using myJournal.objects;
using Org.BouncyCastle.Bcpg.Sig;

namespace myJournal.subforms
{
	public partial class frmJournalSettings : Form
	{
		Notebook workingJournal;
		public bool isDirty = false;
		bool allowValueChange = false;
		bool originalAllowCloud = false;
		#region Settings
		bool b_AllowCloud;
		bool b_IfCloudOnly_Download;
		bool b_IfCloudOnly_Delete;
		bool b_IfLocalOnly_Upload;
		bool b_IfLocalOnly_Delete;
		bool b_IfLocalOnly_DisallowCloud;
		#endregion
		// ..........

		public frmJournalSettings(Notebook journalToEdit, Form parent)
		{
			InitializeComponent();

			if (journalToEdit != null)
			{
				workingJournal = journalToEdit;
				Utilities.SetStartPosition(this, parent);
				this.Text = "Settings for '" + workingJournal.Name + "'";
			}
			else { this.Close(); }
		}

		private void frmJournalSettings_Load(object sender, EventArgs e)
		{
			b_AllowCloud = workingJournal.Settings.AllowCloud;
			b_IfCloudOnly_Download = workingJournal.Settings.IfCloudOnly_Download;
			b_IfCloudOnly_Delete = workingJournal.Settings.IfCloudOnly_Delete;
			b_IfLocalOnly_Upload = workingJournal.Settings.IfLocalOnly_Upload;
			b_IfLocalOnly_Delete = workingJournal.Settings.IfLocalOnly_Delete;
			b_IfLocalOnly_DisallowCloud = workingJournal.Settings.IfLocalOnly_DisallowCloud;

			allowValueChange = false;
			chkAllowCloud.Checked = b_AllowCloud;
			pnlCloudOptions.Enabled = chkAllowCloud.Checked;
			radCloudNotLocal_DeleteCloud.Checked = b_IfCloudOnly_Delete;
			radCloudNotLocal_DownloadCloud.Checked = b_IfCloudOnly_Download;
			radLocalNotCloud_DeleteLocal.Checked = b_IfLocalOnly_Delete;
			radLocalNotCloud_UploadToCloud.Checked = b_IfLocalOnly_Upload;
			radLocalNotCloud_DisallowLocalCloud.Checked = b_IfLocalOnly_DisallowCloud;
			allowValueChange = true;
			originalAllowCloud = b_AllowCloud;
		}

		private async void ApplySettings()
		{
			workingJournal.Settings.AllowCloud = b_AllowCloud;
			workingJournal.Settings.IfCloudOnly_Download = b_IfCloudOnly_Download;
			workingJournal.Settings.IfCloudOnly_Delete = b_IfCloudOnly_Delete;
			workingJournal.Settings.IfLocalOnly_Upload = b_IfLocalOnly_Upload;
			workingJournal.Settings.IfLocalOnly_Delete = b_IfLocalOnly_Delete;
			workingJournal.Settings.IfLocalOnly_DisallowCloud = b_IfLocalOnly_DisallowCloud;
			workingJournal.Save();

			if (b_AllowCloud & !originalAllowCloud)
			{
				CloudSynchronizer cs = new CloudSynchronizer();
				await cs.SynchWithCloud(false, workingJournal);

			}

			if (!b_AllowCloud & originalAllowCloud)
			{
				await AzureFileClient.CheckForCloudJournalAndRemoveEntries(workingJournal);
			}
		}

		private void btnSaveChanges_Click(object sender, EventArgs e)
		{
			if (this.isDirty) { ApplySettings(); }
			this.Hide();
		}

		private void chkAllowCloud_CheckedChanged(object sender, EventArgs e)
		{
			pnlCloudOptions.Enabled = chkAllowCloud.Checked;
			if (!chkAllowCloud.Checked)
			{
				radCloudNotLocal_DeleteCloud.Checked = false;
				radCloudNotLocal_DownloadCloud.Checked = false;
				radLocalNotCloud_DeleteLocal.Checked = false;
				radLocalNotCloud_DisallowLocalCloud.Checked = false;
				radLocalNotCloud_UploadToCloud.Checked = false;
			}
			else
			{
				radLocalNotCloud_UploadToCloud.Checked = true;
				radCloudNotLocal_DownloadCloud.Checked = true;
			}
			ValueChanged(sender, e);
		}

		private void ValueChanged(object sender, EventArgs e)
		{
			if (allowValueChange)
			{
				b_AllowCloud = chkAllowCloud.Checked;
				b_IfCloudOnly_Download = radCloudNotLocal_DownloadCloud.Checked;
				b_IfCloudOnly_Delete = radCloudNotLocal_DeleteCloud.Checked;
				b_IfLocalOnly_Upload = radLocalNotCloud_UploadToCloud.Checked;
				b_IfLocalOnly_Delete = radLocalNotCloud_DeleteLocal.Checked;
				b_IfLocalOnly_DisallowCloud = radLocalNotCloud_DisallowLocalCloud.Checked;
				isDirty = true;
			}
		}
	}
}
