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
		Journal workingJournal;
		public bool isDirty = false;
		bool allowValueChange = false;
		bool b_AllowCloud;
		bool b_IfCloudOnly_Download;
		bool b_IfCloudOnly_Delete;
		bool b_IfLocalOnly_Upload;
		bool b_IfLocalOnly_Delete;
		bool b_IfLocalOnly_DisallowCloud;

		public frmJournalSettings(Journal journalToEdit, Form parent)
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
			b_AllowCloud				= workingJournal.Settings.AllowCloud;
			b_IfCloudOnly_Download		= workingJournal.Settings.IfCloudOnly_Download;
			b_IfCloudOnly_Delete		= workingJournal.Settings.IfCloudOnly_Delete;
			b_IfLocalOnly_Upload		= workingJournal.Settings.IfLocalOnly_Upload;
			b_IfLocalOnly_Delete		= workingJournal.Settings.IfLocalOnly_Delete;
			b_IfLocalOnly_DisallowCloud = workingJournal.Settings.IfLocalOnly_DisallowCloud;

			allowValueChange = false;
			chkAllowCloud.Checked						= b_AllowCloud;
			radCloudNotLocal_DownloadCloud.Checked		= b_IfCloudOnly_Download;
			radLocalNotCloud_DisallowLocalCloud.Checked = b_IfLocalOnly_DisallowCloud;
			radLocalNotCloud_DeleteLocal.Checked		= b_IfLocalOnly_Delete;
			radLocalNotCloud_UploadToCloud.Checked		= b_IfLocalOnly_Upload;
			radCloudNotLocal_DeleteCloud.Checked		= b_IfCloudOnly_Delete;

			radCloudNotLocal_DeleteCloud.Checked = !radCloudNotLocal_DownloadCloud.Checked;

			pnlCloudOptions.Enabled = chkAllowCloud.Checked;
			allowValueChange = true;
		}

		private async void ApplySettings()
		{
			workingJournal.Settings.AllowCloud				= b_AllowCloud;
			workingJournal.Settings.IfLocalOnly_Upload		= b_IfLocalOnly_Upload;
			workingJournal.Settings.IfLocalOnly_Delete		= b_IfLocalOnly_Delete;
			workingJournal.Settings.IfLocalOnly_DisallowCloud = b_IfLocalOnly_DisallowCloud;
			workingJournal.Settings.IfCloudOnly_Download	= b_IfCloudOnly_Download;
			workingJournal.Settings.IfCloudOnly_Delete		= b_IfCloudOnly_Delete;
			workingJournal.Save();

			if(!workingJournal.Settings.AllowCloud)
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
			ValueChanged(sender, e);
		}

		private void ValueChanged(object sender, EventArgs e)
		{
			if (allowValueChange)
			{
				b_AllowCloud				= chkAllowCloud.Checked;
				b_IfLocalOnly_Upload			= radLocalNotCloud_UploadToCloud.Checked;
				b_IfLocalOnly_DisallowCloud	= radLocalNotCloud_DisallowLocalCloud.Checked;
				b_IfLocalOnly_Delete			= radLocalNotCloud_DeleteLocal.Checked;
				b_IfCloudOnly_Download		= radCloudNotLocal_DownloadCloud.Checked;
				b_IfCloudOnly_Delete			= radCloudNotLocal_DeleteCloud.Checked;
				isDirty						= true;
			}
		}
	}
}
