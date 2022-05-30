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
using System.Reflection;

namespace myJournal.subforms
{
	public partial class frmLogin : Form
	{

		public frmLogin()
		{ InitializeComponent(); }

		private void frmLogin_Activated(object sender, EventArgs e) { txtPIN.Focus(); }

		private void frmLogin_Load(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
			grp1.Location = new Point((this.Width / 2) - (grp1.Width / 2), 50);
			ConfigurationManager.AppSettings["PINOk"] = "0";
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			//ConfigurationManager.AppSettings["CloseApp"] = "True";
			//this.Hide();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{}

		private void frmLogin_Resize(object sender, EventArgs e)
		{
			grp1.Location = new Point((this.Width / 2) - (grp1.Width / 2), 50);
		}

		private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (isPINOk())
			{
				ConfigurationManager.AppSettings["PINOk"] = "1";
				ConfigurationManager.AppSettings["masterPIN"] = txtPIN.Text;

				((frmParent)this.MdiParent).nextForm = new frmMain();



				//object o = t.GetProperty("nextForm").GetValue(f, null);

				//this.MdiParent.GetType().GetProperty("nextForm").SetValue(new frmMain(), new frmMain());

			}
			else
			{
				e.Cancel = true;
			}
		}

		private bool isPINOk()
		{
			string PIN = EncryptDecrypt.FullPin(txtPIN.Text);
			bool PIN_Ok = false;

			if (File.Exists("key.txt"))
			{
				PIN_Ok = PIN == EncryptDecrypt.Decrypt(File.ReadAllText("key.txt"), PIN, ConfigurationManager.AppSettings["PrivateKey"]);
			}
			else
			{
				File.WriteAllTextAsync("key.txt", EncryptDecrypt.Encrypt(PIN, PIN, ConfigurationManager.AppSettings["PrivateKey"]));
			}

			((frmParent)this.MdiParent).nextForm = new frmMain();

			if (PIN_Ok)
			{
				//this.Close();
			}
			else
			{
				lblError.Text = "Wrong PIN";
				lblError.Visible = true;
			}

			return true;
			//return PIN_Ok;
		}

		private void mnuLogin_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
