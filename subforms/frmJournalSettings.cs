using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using myJournal.objects;
using Org.BouncyCastle.Bcpg.Sig;

namespace myJournal.subforms
{
	public partial class frmJournalSettings : Form
	{
		Journal workingJournal = new Journal();
		public bool isDirty = false;
		bool allowValueChange = false;
		//public Journal GetModifiedJournal { get { return isDirty ? workingJournal : null; } }

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
			var allowCloud	= workingJournal.AllowCloud;
			var dl			= workingJournal.DownloadIfNotFoundLocally;
			var ul			= workingJournal.UploadIfNotFoundInCloud;

			allowValueChange = false;
			chkAllowCloud.Checked					= allowCloud;
			radCloudNotLocal_DownloadCloud.Checked	= dl;
			radLocalNotCloud_UploadToCloud.Checked	= ul;
			radCloudNotLocal_DeleteCloud.Checked	= !radCloudNotLocal_DownloadCloud.Checked;
			radLocalNotCloud_DeleteLocal.Checked	= !radLocalNotCloud_UploadToCloud.Checked;
			pnlCloudOptions.Enabled					= chkAllowCloud.Checked;
			allowValueChange = true;
		}

		private void btnSaveChanges_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void chkAllowCloud_CheckedChanged(object sender, EventArgs e)
		{
			pnlCloudOptions.Enabled = chkAllowCloud.Checked;
			ValueChanged(sender, e);
		}

		private void ValueChanged(object sender, EventArgs e)
		{
			if(allowValueChange)
			{
				workingJournal.AllowCloud = chkAllowCloud.Checked;
				workingJournal.UploadIfNotFoundInCloud = radLocalNotCloud_UploadToCloud.Checked;
				workingJournal.DownloadIfNotFoundLocally = radCloudNotLocal_DownloadCloud.Checked;
				isDirty = true;
			}
		}
	}
}
