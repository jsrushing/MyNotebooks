using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmAzurePwd : Form
	{
		public frmAzurePwd(Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private async void btnContinue_Click(object sender, EventArgs e)
		{
			if(txtPwd.Text.Equals(string.Empty))
			{
				lblError.Text = "You must enter a password.";
				lblError.Visible = true;
				return;
			}
			else
			{
				AzureFileClient azureFileClient = new AzureFileClient();
				await azureFileClient.CheckAzurePassword(txtPwd.Text);

				if (Program.AzurePassword.Length > 0)
				{
					Close();
				}
				else
				{
					lblError.Text = "Password not found";
					lblError.Visible = true;
				}
				

			}
		}

		private void txtPwd_TextChanged(object sender, EventArgs e)
		{
			lblError.Visible=false;
		}
	}
}
