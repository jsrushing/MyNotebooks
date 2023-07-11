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

		public frmGroupLoginOrCreate()
		{
			InitializeComponent();
		}

		private void EnableDisableBtnOK(object sender, EventArgs e)
		{ btnOK.Enabled = txtName.Text.Length > 0 & txtPwd.Text.Length > 0; }

		private void frmGroupLoginOrCreate_Load(object sender, EventArgs e)
		{
			pnl1.Location = new Point(0, 0);
			pnl2.Location = new Point(0, 0);
			this.Size = pnl1.Size;
		}

		private void LoginOrCreate(object sender, EventArgs e)
		{
			Button b = (Button)sender;
			LoggingIn = b.Tag.Equals("login");
			pnl1.Visible = false;
			pnl2.Visible = true;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Program.PIN = txtPwd.Text;
			Program.GroupName_Encrypted = null;

			if (LoggingIn)
			{
				//var v = Directory.GetCurrentDirectory().Select(n => EncryptDecrypt.Decrypt(n) == txtName.Text).ToList();

				// use the group name and password to decrypt folder names in the group folder until a match is found.
				foreach (var dirName in Directory.GetDirectories(Program.GroupsFolder))
				{
					if(EncryptDecrypt.Decrypt(dirName) == txtName.Text)
					{
						Program.GroupName_Encrypted = dirName;

						// decrypt the notebook names in the group folder
						foreach(var s in Directory.GetFiles(dirName))
						{
							Program.AllNotebookNames.Add(EncryptDecrypt.Decrypt(s));
						}
					}
				}

				if(Program.GroupName_Encrypted != null)
				{
					Program.GroupPIN = txtPwd.Text;
				}
				else
				{
					using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "No group found.", "", this)) { frm.ShowDialog(); }
				}
			}
			else	// creating a new group
			{
				// create the folder
				Program.GroupName_Encrypted = EncryptDecrypt.Encrypt(txtName.Text);
				Program.GroupPIN = Program.PIN;
				Directory.CreateDirectory(Program.GroupsFolder + Program.GroupName_Encrypted);	
				// now save all nb's w/ their name encrypted with program.GroupPIN
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			GroupName = null;
			this.Hide();
		}
	}
}
