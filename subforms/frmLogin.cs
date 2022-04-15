using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using encrypt_decrypt_string;

namespace myJournal.subforms
{
	public partial class frmLogin : Form
	{
		bool PIN_Ok = false;

		public frmLogin()
		{
			InitializeComponent();
		}

		private void frmLogin_Activated(object sender, EventArgs e)
		{ txtPIN.Focus(); }

		private void frmLogin_Load(object sender, EventArgs e)
		{ grp1.Location = new Point((this.Width / 2) - (grp1.Width / 2), (this.Height / 2) - (grp1.Height / 2)); }

		private void btnCancel_Click(object sender, EventArgs e)
		{
			ConfigurationManager.AppSettings["CloseApp"] = "True";
			this.Hide();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (txtPIN.Text.Length > 0)
			{
				string PIN = EncryptDecrypt.FullPin(txtPIN.Text);

				if (File.Exists("key.txt"))
				{
					PIN_Ok = PIN == EncryptDecrypt.Decrypt(File.ReadAllText("key.txt"), PIN, ConfigurationManager.AppSettings["PrivateKey"]);
				}
				else
				{
					File.WriteAllTextAsync("key.txt", EncryptDecrypt.Encrypt(PIN, PIN, ConfigurationManager.AppSettings["PrivateKey"]));
				}

				ConfigurationManager.AppSettings["PIN"] = txtPIN.Text;
				this.Hide();
			}
			else
			{
				this.Hide();
			}

			if (txtPIN.Text.Length > 0 && !PIN_Ok)
			{
				lblError.Text = "Wrong PIN";
				lblError.Visible = true;
			}

		}

	}
}
