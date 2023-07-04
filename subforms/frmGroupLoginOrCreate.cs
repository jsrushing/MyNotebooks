using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Encryption;
using myNotebooks;
using myNotebooks.subforms;

namespace myJournal.subforms
{
	public partial class frmGroupLoginOrCreate : Form
	{
		public string GroupName { get; private set; }
		private bool LoggingIn;
		private string[] GroupDirectories = Directory.GetDirectories(Program.GroupsFolder);

		public frmGroupLoginOrCreate()
		{
			InitializeComponent();
			btnLogin.Enabled = GroupDirectories.Count() > 0;
		}

		private void EnableDisableBtnOK(object sender, EventArgs e)
		{ btnOK.Enabled = txtName.Text.Length > 0; }

		private void frmGroupLoginOrCreate_Load(object sender, EventArgs e)
		{
			pnl1.Location = new Point(0, 0);
			pnl2.Location = new Point(0, 0);
			this.Size = new Size(296, 174);
		}

		private void LoginOrCreate(object sender, EventArgs e)
		{
			Button b = (Button)sender;
			LoggingIn = b.Tag.Equals("login");
			pnl1.Visible = false;
			pnl2.Visible = true;
			txtName.Focus();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Program.PIN = txtPwd.Text;
			Program.GroupName_Encrypted = null;
			Program.AzurePassword = Program.GroupName_Encrypted;
			var msg = "";

			if (LoggingIn)
			{
				//var v = Directory.GetCurrentDirectory().Select(n => EncryptDecrypt.Decrypt(n) == txtName.Text).ToList();

				// use the group name and password to decrypt folder names in the group folder until a match is found.
				foreach (var dirName in Directory.GetDirectories(Program.GroupsFolder))
				{
					var vNameNotBase64 = Path.GetFileName(dirName);

					if (EncryptDecrypt.Decrypt(Path.GetFileName(dirName)) == txtName.Text)
					{
						Program.GroupName_Encrypted = vNameNotBase64;

						// decrypt the notebook names in the group folder
						foreach (var s in Directory.GetFiles(Program.GroupsFolder + vNameNotBase64))
						{
							Program.AllNotebookNames.Add(EncryptDecrypt.Decrypt(Path.GetFileName(s)));
						}
					}
				}

				if (Program.GroupName_Encrypted != null)
				{
					Program.GroupPIN = txtPwd.Text;
					msg = "You are logged in to '" + txtName.Text + "'.";
				}
				else
				{
					using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "No group found.", "", this)) { frm.ShowDialog(); }
				}
			}
			else    // creating a new group
			{
				// create the folder
				Program.GroupName_Encrypted = EncryptDecrypt.Encrypt(txtName.Text).Replace("/", "_").Replace("+", "-");
				Program.GroupPIN = Program.PIN;
				Directory.CreateDirectory(Program.GroupsFolder + Program.GroupName_Encrypted);
				msg = "The group '" + txtName.Text + "' has been created.";
				// now save all nb's w/ their name encrypted with program.GroupPIN
			}

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, msg, "Opersation Complete", this)) { frm.ShowDialog(); }
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			GroupName = null;
			this.Hide();
		}

		private void lblShowPIN_Click(object sender, EventArgs e)
		{
			txtPwd.PasswordChar = txtPwd.PasswordChar == '*' ? '\0' : '*';
			lblShowPIN.Text = lblShowPIN.Text == "show" ? "hide" : "show";
		}
	}
}
