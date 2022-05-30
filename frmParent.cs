using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using myJournal.subforms;
using System.Configuration;
using System.Runtime.InteropServices;

namespace myJournal
{
	public partial class frmParent : Form
	{
		private int childFormNumber = 0;
		public Form currentForm;
		public Form nextForm = null;

		public delegate void OnJournalCreate(string journalName, string PIN);

		public static event OnJournalCreate OnCreate;

				public frmParent()
		{
			InitializeComponent();
			ShowForm(new frmMain());
			string s = RuntimeInformation.FrameworkDescription;
		}

		private void ShowNewForm(object sender, EventArgs e)
		{
			Form childForm = new Form();
			childForm.MdiParent = this;
			childForm.Text = "Window " + childFormNumber++;
			childForm.Show();
		}

		private void OpenFile(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				string FileName = openFileDialog.FileName;
			}
		}

		private void frmParent_Activated(object sender, EventArgs e)
		{
			if(nextForm != null) {ShowForm(nextForm); nextForm = null; }
		
		}

		private void mnuCancel_Login_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void mnuLogin_Click(object sender, EventArgs e)
		{

			this.ActiveMdiChild.Close();

			if(ConfigurationManager.AppSettings["PINOk"] == "1")
			{
				ShowForm(new frmMain());
				//mnuStrip_Login.Visible = false;
				//mnuStrip_Main.Visible = true;		//Form childForm = new frmMain();
				//childForm.MdiParent = this;
				//currentForm = childForm;
				//currentForm.Show();
			}
		}

		private void ShowForm(Form frmToShow)
		{
			currentForm = frmToShow;
			currentForm.MdiParent = this;
			currentForm.MinimizeBox = false;
			currentForm.MaximizeBox = false;
			currentForm.Show();
		}

		private void frmParent_Load(object sender, EventArgs e)
		{
			
		}

	}
}
