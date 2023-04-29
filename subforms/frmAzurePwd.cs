/* Sync with cloud.
 * 1/21/23
 */
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
		public bool KeyChanged { get; set; }

		public enum Mode
		{
			AskingForKey,
			EnteringKey,
			CreatingKey,
			ChangingKey
		}

		List<Panel> panels = new List<Panel>();
		List<TextBox> entries = new List<TextBox>();	
		Form parentForm = null;

		public frmAzurePwd(Form parent, Mode mode)
		{
			parentForm = parent;
			InitializeComponent();

			if (mode != Mode.ChangingKey && File.Exists(Program.AppRoot + "ap"))
			{
				Program.AzurePassword = File.ReadAllText(Program.AppRoot + "ap");
				this.Hide();
			}
			else
			{
				Panel panel = new Panel();

				this.Size = new System.Drawing.Size(223, 120);
				Utilities.SetStartPosition(this, parent);

				foreach (Control c in this.Controls)
				{ 
					if (c.GetType() == typeof(Panel))
					{ 
						panel = (Panel)c;
						panel.Location = pnlHaveKey.Location;
						panels.Add(panel);
					}
					else if (c.GetType() == typeof(TextBox)) { entries.Add((TextBox)c); }
				}

				SetUpUI(mode);
				this.ShowDialog();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) 
		{ 
			ClearAllText(); 
			SetUpUI(Mode.AskingForKey); 
		}

		private void btnCancelChange_Click(object sender, EventArgs e) { Close(); }

		private void btnChangeKey_Click(object sender, EventArgs e)
		{
			// recreate ap file
			//string key = EncryptDecrypt.Encrypt(txtChangeKey.Text);
			//File.WriteAllText(Program.AppRoot + "ap", key);
			//Program.AzurePassword = key;
			//// synch the new key to file share "keys"
			//AzureFileClient.UploadFile(Program.AppRoot + "ap");
			StoreAzureKey(EncryptDecrypt.Encrypt(txtChangeKey.Text));
			KeyChanged = true;
			this.Hide();
		}

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
				this.StoreAzureKey(Program.AzurePassword);
			}
		}

		private async void btnEnterKey_Click(object sender, EventArgs e)
		{
			await AzureFileClient.CheckNewAzurePassword(txtEnterKey.Text, false);

			if (Program.AzurePassword.Length == 0)
			{
				string key = EncryptDecrypt.Encrypt(txtEnterKey.Text);
				StoreAzureKey(key);
				Program.AzurePassword = key;
			}
			else
			{
				if (Program.AzurePassword.Length > 0)
				{
					StoreAzureKey(Program.AzurePassword);
				}
				else
				{
					lblError_EnterKey.Text = "Password is in use";
					lblError_EnterKey.Visible = true;
				}
			}
		}

		private void btnHaveKeyNo_Click(object sender, EventArgs e) { SetUpUI(Mode.CreatingKey); }

		private void btnHaveKeyYes_Click(object sender, EventArgs e) { SetUpUI(Mode.EnteringKey); }

		private void ClearAllText() { foreach (TextBox tb in entries) { tb.Text = string.Empty; } }
		
		private void HideAllPanels() { foreach (Panel p in panels) { p.Visible = false; } }

		private void SetUpUI(Mode mode)
		{
			HideAllPanels();

			switch(mode)
			{
				case Mode.AskingForKey:
					this.Text = "Do you have an Azure key?";
					pnlHaveKey.Visible = true;
					break;
				case Mode.EnteringKey: 
					this.Text = "Enter Azure Key";
					pnlEnterKey.Visible = true;
					txtEnterKey.Focus();
					break;
				case Mode.CreatingKey: 
					this.Text = "Create Azure Key";
					pnlCreateKey.Visible = true;
					txtCreateKey.Focus();
					break;
				case Mode.ChangingKey:
					this.Text = "Change Azure Key";
					pnlChangeKey.Visible = true;
					txtChangeKey.Focus();
					break;
			}
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
			btnChangeKey.Enabled = tbx.TextLength > 7;
		}
	}
}