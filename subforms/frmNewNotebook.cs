/* Add a new journal 
 * 6/15/22
 */
using System;
using System.Windows.Forms;
using Encryption;
using myNotebooks.objects;
using MyNotebooks.Properties;

namespace myNotebooks.subforms
{
	public partial class frmNewNotebook : Form
	{
		public Notebook WorkingNotebook { get; private set; }
		public NotebookSettings WorkingSettings = new NotebookSettings { IfCloudOnly_Download = true, IfLocalOnly_Upload = true, AllowCloud = true };
	public frmNewNotebook(Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
			this.WorkingNotebook = null;
		}

		private void btnSettings_Click(object sender, EventArgs e)
		{
			if (txtName.Text.Length > 0)
			{
				WorkingNotebook = new Notebook(EncryptDecrypt.Encrypt(txtName.Text, Program.PIN_Notebooks));
				WorkingNotebook.Settings = WorkingSettings;
				using (frmNotebookSettings nbs = new frmNotebookSettings(WorkingNotebook, this, false)) { nbs.ShowDialog(); }
			}
		}

		private void frmNewNotebook_Load(object sender, EventArgs e) { this.Size = this.MinimumSize; }

		private void frmNewNotebook_Activated(object sender, EventArgs e) { txtName.Focus(); }

		private void btnCancel_Click(object sender, EventArgs e) 
		{ 
			WorkingNotebook = null; 
			this.Hide(); 
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			//Program.AllNotebookNames.Clear();
			this.WorkingNotebook = WorkingNotebook == null ?  new Notebook(EncryptDecrypt.Encrypt(txtName.Text, Program.PIN_Group), null, this) : WorkingNotebook;
			WorkingNotebook.Settings = WorkingNotebook.Settings == null ? WorkingSettings : WorkingNotebook.Settings;
			Program.PIN_Notebooks = txtPIN.Text;
			Program.AllNotebookNames.Add(EncryptDecrypt.Decrypt(WorkingNotebook.Name, Program.PIN_Group));
			this.Hide();
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

		private void frmNewNotebook_FormClosing(object sender, FormClosingEventArgs e) { } // Notebook = null; }
	}
}
