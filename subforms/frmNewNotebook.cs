/* Add a new journal 
 * 6/15/22
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using myNotebooks.objects;

namespace myNotebooks.subforms
{
	public partial class frmNewNotebook : Form
	{
		public Notebook Notebook { get; private set; }
		public NotebookSettings Settings { get; private set; }

		public frmNewNotebook(Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
			this.Notebook = new Notebook();
			this.Settings = new NotebookSettings { IfCloudOnly_Download = true, IfLocalOnly_Upload = true, AllowCloud = true };
			this.Notebook.Settings = this.Settings;
		}

		private void frmNewJournal_Load(object sender, EventArgs e) { this.Size = this.MinimumSize; }

		private void frmNewJournal_Activated(object sender, EventArgs e) { txtName.Focus(); }

		private void frmNewNotebook_FormClosing(object sender, FormClosingEventArgs e)
		{ this.Notebook = null; }

		private void btnCancel_Click(object sender, EventArgs e) { this.Hide(); }

		private void btnOk_Click(object sender, EventArgs e)
		{
			char[] c = System.IO.Path.GetInvalidFileNameChars();
			if (txtName.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) != -1)
			{
				using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "Sorry, notebook names may not contain characters " +
					"which are not allowed in file names, for example *, <, >, {, }, |, :, ?, /, \\ (and others).", "", this))
				{ frm.ShowDialog(); }
			}
			else
			{
				this.Notebook.Name = txtName.Text;
				Program.PIN = txtPIN.Text;
				this.Hide();
			}
		}

		private void lblShowPIN_Click(object sender, EventArgs e)
		{
			txtPIN.PasswordChar = txtPIN.PasswordChar == '*' ? '\0' : '*';
			lblShowPIN.Text = lblShowPIN.Text == "show" ? "hide" : "show";
		}

		private void txtPIN_TextChanged(object sender, EventArgs e) { lblShowPIN.Visible = txtPIN.Text.Length > 0; }

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

		private void btnSettings_Click(object sender, EventArgs e)
		{
			if (txtName.Text.Length > 0)
			{
				//Notebook = new Notebook(txtName.Text);
				//{ Notebook.Settings = this.Settings; }
				using (frmNotebookSettings nbs = new frmNotebookSettings(Notebook, this, false)) { nbs.ShowDialog(); }
				this.Settings = Notebook.Settings;
			}
		}
	}
}
