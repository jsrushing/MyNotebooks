using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace myJournal.subforms
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
			LoadJournals();
		}

		private void LoadJournals()
		{
			string rootPath = AppDomain.CurrentDomain.BaseDirectory;
			ddlJournals.Items.Clear();

			if (!Directory.Exists(rootPath + "/journals/"))
			{
				Directory.CreateDirectory(rootPath + "/journals/");
				Directory.CreateDirectory(rootPath + "/settings/");
				File.Create(rootPath + "/settings/settings");
				File.Create(rootPath + "/settings/groups");
			}
			else
			{
				foreach (string s in Directory.GetFiles(rootPath + "/journals/"))
				{
					ddlJournals.Items.Add(s.Replace(rootPath + "/journals/", ""));
				}
			}
			ddlJournals.Enabled = ddlJournals.Items.Count > 0;
			ddlJournals.SelectedIndex = ddlJournals.Items.Count == 1 ? 0 : -1;
		}

		private void ddlJournals_SelectedIndexChanged(object sender, EventArgs e)
		{
			mnuJournal_Delete.Enabled = true;
		}

		private void mnuJournal_Create_Click(object sender, EventArgs e)
		{
			((frmParent)this.MdiParent).nextForm = new frmNewJournal();
			this.Close();
		}
	}
}
