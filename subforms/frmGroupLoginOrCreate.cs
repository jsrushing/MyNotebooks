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
using myNotebooks.objects;
using myNotebooks.subforms;

namespace myJournal.subforms
{
	public partial class frmGroupLoginOrCreate : Form
	{
		public string GroupName { get; private set; }
		private bool LoggingIn;
		private string[] GroupDirectories = Directory.GetDirectories(Program.GroupsFolder);

		public frmGroupLoginOrCreate(bool doAutoLogin, Form parent)
		{
			InitializeComponent();
			btnLogin.Enabled = GroupDirectories.Count() > 0;
			Utilities.SetStartPosition(this, parent);
			// for debugging
			//txtName.Text = "Operations";
			//txtPwd.Text = "ops";
			PopulateExistingGroups();
			if (doAutoLogin) { LoginOrCreate(btnLogin, null); }
		}

		private void frmGroupLoginOrCreate_Load(object sender, EventArgs e)
		{
			pnl1.Location = new Point(0, 0);
			pnl2.Location = new Point(0, 0);
			this.Size = new Size(296, 174);
			ddlExistingGroups.Location = txtName.Location;
			ddlExistingGroups.Size = txtName.Size;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			GroupName = null;
			this.Hide();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Program.PIN_Group = txtPwd.Text;
			Program.GroupName_Encrypted = null;
			Program.AzurePassword = Program.PIN_Group;
			var msg = "";
			Program.GroupName_Encrypted = EncryptDecrypt.Encrypt(txtName.Text, Program.PIN_Master);
			Program.GroupFolder = Program.GroupsFolder + Program.GroupName_Encrypted;

			if (LoggingIn)
			{
				//var v = Directory.GetCurrentDirectory().Select(n => EncryptDecrypt.Decrypt(n) == txtName.Text).ToList();



				// use the group name and password to decrypt folder names in the group folder until a match is found.
				//foreach (var dirName in Directory.GetDirectories(Program.GroupsFolder))
				//{
				//	var vNameNotBase64 = Path.GetFileName(dirName);
				//	var decryptTry = EncryptDecrypt.Decrypt(vNameNotBase64, Program.PIN_Master);

				//	if (decryptTry.Length > 0 && decryptTry.ToLower() == txtName.Text.ToLower())
				//	{
				//		Program.GroupName_Encrypted = vNameNotBase64;
				//		var vPath = string.Empty;

				//		// decrypt the notebook names in the group folder
				//		foreach (var s in Directory.GetFiles(Program.GroupsFolder + vNameNotBase64))
				//		{
				//			vPath = EncryptDecrypt.Decrypt(Path.GetFileName(s), Program.PIN_Group);
				//			Program.AllNotebookNames.Add(vPath);
				//		}

				//		if (!Program.PreviousGroups.Contains(decryptTry)) { Program.PreviousGroups.Add(decryptTry); }
				//	}
				//}

				if (Program.GroupName_Encrypted != null)
				{
					foreach (var nbName in Directory.GetFiles(Program.GroupFolder))
					{ Program.AllNotebookNames.Add(EncryptDecrypt.Decrypt(Path.GetFileName(nbName), Program.PIN_Group)); }

					GroupName = txtName.Text;
					Program.PIN_Group = txtPwd.Text;
					msg = "You are logged in to '" + txtName.Text + "'.";
				}
				else
				{
					msg = "No group found";
				}
			}
			else    // creating a new group
			{
				// create the folders
				Directory.CreateDirectory(Program.GroupsFolder + Program.GroupName_Encrypted);
				Directory.CreateDirectory(Program.GroupsFolder + Program.GroupName_Encrypted + "\\temp");
				Directory.CreateDirectory(Program.GroupsFolder + Program.GroupName_Encrypted + "\\settings");
				msg = "The group '" + txtName.Text + "' has been created.";
				this.GroupName = txtName.Text;
				//Program.PreviousGroups.Add(Program.GroupName_Encrypted);
			}

			using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, msg, "Operation Complete", this)) { frm.ShowDialog(); }
			this.Close();
		}

		private void ddlPreviousGroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtName.Text = ddlExistingGroups.Text;
			txtPwd.Text = string.Empty; 
			txtPwd.Focus();
		}

		private void ddlPreviousGroups_TextChanged(object sender, EventArgs e)
		{
			btnOK.Enabled = ddlExistingGroups.Text.Length > 0;
			txtName.Text = ddlExistingGroups.Text;
		}

		private void EnableDisableBtnOK(object sender, EventArgs e)
		{ btnOK.Enabled = txtName.Text.Length > 0; }

		private void lblShowPIN_Click(object sender, EventArgs e)
		{
			txtPwd.PasswordChar = txtPwd.PasswordChar == '*' ? '\0' : '*';
			lblShowPIN.Text = lblShowPIN.Text == "show" ? "hide" : "show";
		}

		private void lblCreate_Click(object sender, EventArgs e)
		{ LoginOrCreate(btnCreate, null); }

		private void LoginOrCreate(object sender, EventArgs e)
		{
			Button b = (Button)sender;
			LoggingIn = b.Tag.Equals("login");
			pnl1.Visible = false;
			pnl2.Visible = true;
			txtName.Focus();
			ddlExistingGroups.Visible = LoggingIn;
			ddlExistingGroups.SelectedIndex = 0;
			txtPwd.Focus();
			if (!LoggingIn) { txtName.Text = ""; txtName.Focus(); }
		}

		private void PopulateExistingGroups()
		{
			ddlExistingGroups.Items.Clear();
			foreach (var dirName in Directory.GetDirectories(Program.GroupsFolder))
			{ ddlExistingGroups.Items.Add(EncryptDecrypt.Decrypt(Path.GetFileName(dirName), Program.PIN_Master)); }
		}
	}
}
