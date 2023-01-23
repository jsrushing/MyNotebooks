/* Add a new journal 
 * 6/15/22
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmNewJournal : Form
	{
		private List<string> lstAllJournalNames = Utilities.AllJournalNames();
		public string NewJournalName { get; private set; }
		public bool AllowCloud { get { return chkAllowWebBackup.Checked; } set { AllowCloud = value; } }

		public frmNewJournal(Form parent)
		{ 
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
		}

		private void frmNewJournal_Load(object sender, EventArgs e) 
		{ 
			this.Size = this.MinimumSize; 
		}

		private void frmNewJournal_Activated(object sender, EventArgs e) { txtName.Focus(); }

		private void btnCancel_Click(object sender, EventArgs e) { this.Hide(); }

		private void btnOk_Click(object sender, EventArgs e)
		{
			NewJournalName = txtName.Text;
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
			lblNameExists.Visible = lstAllJournalNames.Contains(txtName.Text);
			btnOk.Enabled = txtName.Text.Length > 0 && !lblNameExists.Visible;

			if (txtName.Text.Contains("|"))
			{
				using(frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "Sorry, for operational reasons Journal names may not contain the '|' symbol.", "", this))
				txtName.Text = txtName.Text.Replace("|", "");
				txtName.SelectionStart = txtName.Text.Length;
				txtName.Focus();
			}

		}
	}
}
