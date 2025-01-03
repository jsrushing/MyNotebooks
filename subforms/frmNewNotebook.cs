﻿/* Add a new journal 
 * 6/15/22
 */
using System;
using System.Linq;
using System.Windows.Forms;
using MyNotebooks.DataAccess;
using MyNotebooks.objects;

namespace MyNotebooks.subforms
{
	public partial class frmNewNotebook : Form
	{
		public Notebook LocalNotebook { get; private set; }

		public frmNewNotebook(Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
			this.LocalNotebook = new Notebook("", "");
			//LocalNotebook.Settings = new NotebookSettings { IfCloudOnly_Download = true, IfLocalOnly_Upload = true, AllowCloud = true };
		}

		private void btnSettings_Click(object sender, EventArgs e)
		{
			if (txtName.Text.Length > 0)
			{
				LocalNotebook.Name = txtName.Text;
				using (frmNotebookSettings nbs = new frmNotebookSettings(LocalNotebook, this, false)) { nbs.ShowDialog(); }
			}
		}

		private void frmNewJournal_Load(object sender, EventArgs e) { }	//this.Size = this.MinimumSize; }

		private void frmNewJournal_Activated(object sender, EventArgs e) { txtName.Focus(); }

		private void btnCancel_Click(object sender, EventArgs e) { LocalNotebook = null; this.Hide(); }

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (!Program.AllNotebooks.Select(e => e.Name.ToLower()).ToList().Contains(txtName.Text.Trim().ToLower()))
			{
				this.LocalNotebook = new Notebook();
				//NotebookSettings nbs = LocalNotebook.Settings;
				//LocalNotebook.Settings = nbs;
				LocalNotebook.Name = txtName.Text;
				LocalNotebook.CreatedOn = DateTime.Now;
				LocalNotebook.ParentId = Program.ActiveNBParentId;
				LocalNotebook.Description = txtDescription.Text;
				this.Hide();

				//NotebookSettings nbs = LocalNotebook.Settings;
				//this.LocalNotebook = new Notebook(txtName.Text, null);
				//LocalNotebook.Settings = nbs;
				//LocalNotebook.PIN = txtPIN.Text;
				//LocalNotebook.Description = txtDescription.Text;
				////Program.PIN = txtPIN.Text;
				//this.Hide();
			}
			else
			{
				using (frmMessage frm = new(frmMessage.OperationType.Message, "The notebook '" + 
					txtName.Text.Trim() + "' already exists.", "Notebook Already Exists", this)) { frm.ShowDialog(); }
				txtName.SelectAll();
			}
		}

		private void txtName_TextChanged(object sender, EventArgs e)
		{
			lblNameExists.Visible = Program.AllNotebookNames.Contains(txtName.Text);
			btnOk.Enabled = txtName.Text.Length > 0 && !lblNameExists.Visible;
			btnSettings.Enabled = btnOk.Enabled;

			if (txtName.Text.Contains("|"))
			{
				using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "Sorry, for operational reasons Journal names may not contain the '|' symbol.", "", this))
					txtName.Text = txtName.Text.Replace("|", "");
				txtName.SelectionStart = txtName.Text.Length;
				txtName.Focus();
			}

		}
	}
}
