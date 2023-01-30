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

		public frmAzurePwd(Form parent)
		{
			InitializeComponent();

			if (File.Exists(Program.AppRoot + "ap"))
			{
				Program.AzurePassword = File.ReadAllText(Program.AppRoot + "ap");
				this.Hide();
			}
			else
			{
				this.Size = new System.Drawing.Size(223, 120);
				Utilities.SetStartPosition(this, parent);
				pnlCreateKey.Top = pnlHaveKey.Top;
				pnlEnterKey.Top = pnlHaveKey.Top;
				this.ShowDialog();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) { Close(); }

		private async void btnCreateKey_Click(object sender, EventArgs e)
		{
			await AzureFileClient.CheckNewAzurePassword(txtCreateKey.Text, true);

			if (Program.AzurePassword.Length == 0)
			{
				lblError_CreateKey.Text = "Key is in use";
				lblError_CreateKey.Visible = true;
				txtCreateKey.Focus();
			}
			else
			{
				StoreAzureKey(Program.AzurePassword);
			}
		}

		private async void btnEnterKey_Click(object sender, EventArgs e)
		{
			await AzureFileClient.CheckNewAzurePassword(txtEnterKey.Text, false);

			if(Program.AzurePassword.Length == 0)
			{
				string key = EncryptDecrypt.Encrypt(txtEnterKey.Text);
				File.WriteAllText(Program.AppRoot + "ap", key);
				Program.AzurePassword = key;
			}

			if (Program.AzurePassword.Length > 0)
			{
				StoreAzureKey(Program.AzurePassword);
			}
			else
			{
				lblError_EnterKey.Text = "Password is already used";
				lblError_EnterKey.Visible = true;
			}
		}

		private void btnHaveKeyNo_Click(object sender, EventArgs e)
		{
			pnlHaveKey.Visible = false;
			this.Text = "Create Azure Key";
			pnlCreateKey.Visible = true;
			txtCreateKey.Focus();
		}

		private void btnHaveKeyYes_Click(object sender, EventArgs e)
		{
			pnlHaveKey.Visible = false;
			this.Text = "Enter Azure Key";
			pnlEnterKey.Visible = true;
			txtEnterKey.Focus();
		}

		private void StoreAzureKey(string key)
		{
			File.WriteAllText(Program.AppRoot + "ap", key);
			AzureFileClient.UploadFile(Program.AppRoot + "ap", "keys");
			this.Close();
		}

		private void txtPwd_TextChanged(object sender, EventArgs e)
		{
			TextBox tbx = (TextBox)sender;
			lblError_EnterKey.Visible = false;
			lblError_CreateKey.Visible = false;
			btnEnterKey.Enabled = tbx.TextLength > 7;
			btnCreateKey.Enabled = tbx.TextLength > 7;
		}
	}
}
