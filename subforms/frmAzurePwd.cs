using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using myJournal.objects;
using System.IO;
using encrypt_decrypt_string;

namespace myJournal.subforms
{
	public partial class frmAzurePwd : Form
	{
		private bool CreatingNewPwd = false;

		public frmAzurePwd(Form parent)
		{
			InitializeComponent();
			CreatingNewPwd = !File.Exists(Program.AppRoot + "ap");

			if (!CreatingNewPwd)
			{
				Program.AzurePassword = EncryptDecrypt.Decrypt(File.ReadAllText(Program.AppRoot + "ap"));
				Program.AzurePassword = EncryptDecrypt.Decrypt(File.ReadAllText(Program.AppRoot + "ap"));
				this.Hide();
			}
			else { Utilities.SetStartPosition(this, parent); btnContinue.Text = "Create"; }
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
				//AzureFileClient azureFileClient = new AzureFileClient();
				await AzureFileClient.CheckAzurePassword(txtPwd.Text);

				if(Program.AzurePassword.Length == 0)
				{
					File.WriteAllText(Program.AppRoot + "ap", EncryptDecrypt.Encrypt(txtPwd.Text + "_"));
					Program.AzurePassword = txtPwd.Text + "_";
				}

				if (Program.AzurePassword.Length > 0)
				{
					this.Close();
				}
				else
				{
					lblError.Text = "Password is already used";
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
