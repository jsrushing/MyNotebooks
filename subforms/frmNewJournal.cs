/* Add a new journal 
 * 6/15/22
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmNewJournal : Form
	{
		public string sJournalName;

		public frmNewJournal()
		{ 
			InitializeComponent();
		}

		private void frmNewJournal_Load(object sender, EventArgs e) { this.Size = this.MinimumSize; }

		private void frmNewJournal_Activated(object sender, EventArgs e) { txtName.Focus(); }

		private void frmNewJournal_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (txtPIN.Text.Length > 0 | txtName.Text.Length > 0)
			{
				e.Cancel = true;
				sJournalName = txtName.Text;
				this.Hide();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			txtName.Text = string.Empty;
			txtPIN.Text = string.Empty;
			this.Hide();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			sJournalName = txtName.Text.Length > 0 ? txtName.Text : string.Empty;
			Program.PIN = txtPIN.Text;
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
			if (txtName.Text.Contains("|"))
			{
				Utilities.ShowMessage("Sorry, for operational reasons Journal names may not contain the '|' symbol.", this);
				txtName.Text = txtName.Text.Replace("|", "");
				txtName.SelectionStart = txtName.Text.Length;
				txtName.Focus();
			}

		}
	}
}
