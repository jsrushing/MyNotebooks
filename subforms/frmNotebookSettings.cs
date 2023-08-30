using System;
using System.Windows.Forms;
using MyNotebooks.objects;

namespace MyNotebooks.subforms
{
	public partial class frmNotebookSettings : Form
	{
		Notebook	WorkingNotebook;
		public bool IsDirty				= false;
		bool		AllowValueChange	= false;
		bool		OriginalAllowCloud	= false;
		bool		SaveAndProcess		= true;

		#region Settings
		bool b_AllowCloud;
		bool b_IfCloudOnly_Download;
		bool b_IfCloudOnly_Delete;
		bool b_IfLocalOnly_Upload;
		bool b_IfLocalOnly_Delete;
		bool b_IfLocalOnly_DisallowCloud;
		#endregion
		// ..........

		public frmNotebookSettings(Notebook notebookToEdit, Form parent, bool saveAndProcessCloud = true)
		{
			InitializeComponent();

			SaveAndProcess = saveAndProcessCloud;

			if (notebookToEdit != null)
			{
				WorkingNotebook = notebookToEdit;
				Utilities.SetStartPosition(this, parent);
				this.Text = "Settings for '" + WorkingNotebook.Name + "'";
			}
			else { this.Close(); }
		}

		private void frmJournalSettings_Load(object sender, EventArgs e)
		{
			b_AllowCloud			= WorkingNotebook.Settings.AllowCloud;
			b_IfCloudOnly_Download	= WorkingNotebook.Settings.IfCloudOnly_Download;
			b_IfCloudOnly_Delete	= WorkingNotebook.Settings.IfCloudOnly_Delete;
			b_IfLocalOnly_Upload	= WorkingNotebook.Settings.IfLocalOnly_Upload;
			b_IfLocalOnly_Delete	= WorkingNotebook.Settings.IfLocalOnly_Delete;
			b_IfLocalOnly_DisallowCloud = WorkingNotebook.Settings.IfLocalOnly_DisallowCloud;

			AllowValueChange						= false;
			chkAllowCloud.Checked					= b_AllowCloud; 
			pnlCloudOptions.Enabled					= chkAllowCloud.Checked;
			radCloudNotLocal_DeleteCloud.Checked	= b_IfCloudOnly_Delete;
			radCloudNotLocal_DownloadCloud.Checked	= b_IfCloudOnly_Download;
			radLocalNotCloud_DeleteLocal.Checked	= b_IfLocalOnly_Delete;
			radLocalNotCloud_UploadToCloud.Checked	= b_IfLocalOnly_Upload;
			radLocalNotCloud_DisallowLocalCloud.Checked = b_IfLocalOnly_DisallowCloud;
			AllowValueChange	= true;
			OriginalAllowCloud	= b_AllowCloud;
		}

		private async void ApplySettings()
		{
			WorkingNotebook.Settings.AllowCloud = b_AllowCloud;
			WorkingNotebook.Settings.IfCloudOnly_Download = b_IfCloudOnly_Download;
			WorkingNotebook.Settings.IfCloudOnly_Delete = b_IfCloudOnly_Delete;
			WorkingNotebook.Settings.IfLocalOnly_Upload = b_IfLocalOnly_Upload;
			WorkingNotebook.Settings.IfLocalOnly_Delete = b_IfLocalOnly_Delete;
			WorkingNotebook.Settings.IfLocalOnly_DisallowCloud = b_IfLocalOnly_DisallowCloud;

			if (SaveAndProcess)
			{
				await WorkingNotebook.Save();

				//if (b_AllowCloud & !OriginalAllowCloud)
				//{
				//	CloudSynchronizer cs = new CloudSynchronizer();
				//	await cs.SynchWithCloud(false, WorkingNotebook);
				//}

				//if (!b_AllowCloud & OriginalAllowCloud)
				//{
				//	await AzureFileClient.CheckForCloudNotebooklAndRemoveEntries(WorkingNotebook);
				//}
			}
		}

		private void btnSaveChanges_Click(object sender, EventArgs e)
		{
			if (this.IsDirty) { ApplySettings(); }
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
			if (AllowValueChange)
			{
				b_AllowCloud = chkAllowCloud.Checked;
				b_IfCloudOnly_Download = radCloudNotLocal_DownloadCloud.Checked;
				b_IfCloudOnly_Delete = radCloudNotLocal_DeleteCloud.Checked;
				b_IfLocalOnly_Upload = radLocalNotCloud_UploadToCloud.Checked;
				b_IfLocalOnly_Delete = radLocalNotCloud_DeleteLocal.Checked;
				b_IfLocalOnly_DisallowCloud = radLocalNotCloud_DisallowLocalCloud.Checked;
				IsDirty = true;
			}
		}
	}
}
