using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MyNotebooks.objects;
using MyNotebooks;
using System.Linq;
using Org.BouncyCastle.Asn1.X509;

namespace myJournal.subforms
{
	public partial class frmSelectPINFile : Form
	{
		public string PINFileName { get; private set; }
		public string PIN { get; private set; }

		public bool IsLocalFile { get; private set; }
		private bool SuppressListClick;

		public frmSelectPINFile(Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
			lstAzureFileNames.Items.Clear();
			lstLocalFileNames.Items.Clear();
		}

		private async void frmSelectPINFile_Load(object sender, EventArgs e)
		{
			// populate the local PIN file names
			List<string> pinFiles = new List<string>();

			foreach (var pinFile in Directory.GetFiles(Program.AppRoot).Where(s => s.EndsWith(".pin")).ToList())
			{
				pinFiles.Add(pinFile.Substring(pinFile.LastIndexOf("\\") + 1, pinFile.Length - pinFile.LastIndexOf("\\") - 5));
			}

			lstLocalFileNames.Items.AddRange(pinFiles.ToArray());

			// populate the azure PIN file names
			//await AzureFileClient.GetAzureItemNames(true, "pinfiles");
			lstAzureFileNames.Items.AddRange(Program.AzurePinFileNames.ToArray());
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			PINFileName = "";
			this.Hide();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			PINFileName = lstAzureFileNames.SelectedItems.Count > 0 ?
				lstAzureFileNames.Text : lstLocalFileNames.SelectedItems.Count > 0 ? lstLocalFileNames.Text : "";
			PINFileName += ".pin";
			PIN = txtPIN.Text;
			IsLocalFile = PINFileName.Length > 0 ? lstLocalFileNames.SelectedItems.Count == 1 : lstAzureFileNames.SelectedItems.Count == 1;
			this.Hide();
		}

		private void lblShowPIN_Click(object sender, EventArgs e)
		{
			txtPIN.PasswordChar = txtPIN.PasswordChar == '*' ? '\0' : '*';
			lblShowPIN.Text = lblShowPIN.Text == "show" ? "hide" : "show";
		}

		private void LstClicks(object sender, EventArgs e)
		{
			if (!SuppressListClick)
			{
				ListBox lbx = (ListBox)sender;
				if (lbx.Name.ToLower().Contains("azure"))
				{
					SuppressListClick = true;
					lstLocalFileNames.SelectedItems.Clear();
				}
				else
				{
					SuppressListClick = true;
					lstAzureFileNames.SelectedItems.Clear();
				}

			}

			SuppressListClick = false;
			txtPIN.Text = string.Empty;
			txtPIN.Focus();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			lblShowPIN.Visible = txtPIN.Text.Length > 0;
		}

		private void lstLocalFileNames_DoubleClick(object sender, EventArgs e) { btnOK_Click(sender, e); }
	}
}
