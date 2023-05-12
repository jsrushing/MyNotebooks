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
		bool s_AllowCloud;
		bool s_CloudOnly_Download;
		bool s_LocalOnly_Upload;
		bool s_LocalOnly_Delete;
		bool s_LocalOnly_DisallowCloud;

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
			s_AllowCloud			= workingJournal.Settings.AllowCloud;
			s_CloudOnly_Download	= workingJournal.Settings.CloudOnly_Download;
			s_LocalOnly_Upload		= workingJournal.Settings.LocalOnly_Upload;
			s_LocalOnly_Delete		= workingJournal.Settings.LocalOnly_Delete;
			s_LocalOnly_DisallowCloud = workingJournal.Settings.LocalOnly_DisallowCloud;

			allowValueChange = false;
			chkAllowCloud.Checked						= s_AllowCloud;
			radCloudNotLocal_DownloadCloud.Checked		= s_CloudOnly_Download;
			radLocalNotCloud_DisallowLocalCloud.Checked = s_LocalOnly_DisallowCloud;
			radLocalNotCloud_DeleteLocal.Checked		= s_LocalOnly_Delete;
			radLocalNotCloud_UploadToCloud.Checked		= s_LocalOnly_Upload;

			radCloudNotLocal_DeleteCloud.Checked = !radCloudNotLocal_DownloadCloud.Checked;

			pnlCloudOptions.Enabled = chkAllowCloud.Checked;
			allowValueChange = true;
		}

		private void ApplySettings()
		{
			workingJournal.Settings.AllowCloud				= s_AllowCloud;
			workingJournal.Settings.LocalOnly_Upload		= s_LocalOnly_Upload;
			workingJournal.Settings.LocalOnly_Delete		= s_LocalOnly_Delete;
			workingJournal.Settings.LocalOnly_DisallowCloud	= s_LocalOnly_DisallowCloud;
			workingJournal.Settings.CloudOnly_Download		= s_CloudOnly_Download;
			workingJournal.Save();
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
				s_AllowCloud				= chkAllowCloud.Checked;
				s_LocalOnly_Upload			= radLocalNotCloud_UploadToCloud.Checked;
				s_LocalOnly_DisallowCloud	= radLocalNotCloud_DisallowLocalCloud.Checked;
				s_LocalOnly_Delete			= radLocalNotCloud_DeleteLocal.Checked;
				s_CloudOnly_Download		= radCloudNotLocal_DownloadCloud.Checked;
				isDirty						= true;
			}
		}
	}
}
