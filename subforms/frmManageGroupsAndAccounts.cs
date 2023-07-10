using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Encryption;
using myNotebooks;
using myNotebooks.subforms;
using MyNotebooks.objects;

namespace MyNotebooks.subforms
{
	public partial class frmManageGroupsAndAccounts : Form
	{
		private bool ManagingGroups = false;
		private bool ForceGroups = false;
		private bool ForceAccounts = false;
		private Dictionary<string, string> accounts = new Dictionary<string, string>();

		public frmManageGroupsAndAccounts(bool forceGroups, bool forceAccounts)
		{
			InitializeComponent();
			this.ForceGroups = forceGroups;
			this.ForceAccounts = forceAccounts;
		}

		private void frmManageGroupsAndAccounts_Load(object sender, EventArgs e)
		{
			this.Size = new Size(277, 157);
			List<string> accounts = new List<string>();

			// Ask for PIN_Master

			// Ask if user has device PIN (yes, no)

			// Ask for the PIN

			// If cancelled, move on

			// If PIN_Device != null, look for the accounts file in the device root

				// if accounts file exists

					// if first line can't be decrypted with PIN_Device
						// WRONG PIN
					// else
						// decrypt each line into a Dictionary (<account name>, <PIN>) accounts
				//
			


			// now get any accounts in the accounts folder you can decrypt with PIN_Master

			// Show the accounts list (the dictionary.keys)


				



			ManagingGroups = this.ForceGroups;

			if (!ManagingGroups)	// Get the accounts list.
			{
				if (Program.PIN_Device != null && File.Exists(Program.AppRoot + "storedaccounts"))  // There's a stored list of Accounts on the device.
				{
					// <accountname> | <account PIN>
					accounts = File.ReadAllLines(Program.AppRoot + "mn").ToList();

					foreach(string account in accounts)
					{
						accounts.Add(EncryptDecrypt.Decrypt(account, Program.PIN_Device);
					}
				}

				string[] dirAccounts = Directory.GetDirectories(Program.AppRoot + "account\\").Except(accounts).ToArray();

				if(accounts.Count != dirAccounts.Length)	// Directories exist which weren't in the stored accounts file.
				{
					using(frmMessage frm = new frmMessage(frmMessage.OperationType.PasswordInputBox, "What's the Master PIN?", "PIN Required", this))
					{
						frm.ShowDialog();
						Program.PIN_Master = frm.Result == frmMessage.ReturnResult.Ok ? frm.ResultText : null;

						if(Program.PIN_Master != null)
						{	
							foreach(string dirAccount in dirAccounts)
							{
								try
								{
									// trap for decrypt fail ... ???
									accounts.Add(EncryptDecrypt.Decrypt(dirAccount, Program.PIN_Master));
								}
								catch(Exception ex) { Console.WriteLine(ex.Message); }
							}
						}
					}
				}
				lstItems.Items.AddRange(accounts.ToArray());
			}
			else
			{

			}


			if (ForceGroups) { BtnClick(btnManageGroups, null); }
			if (ForceAccounts) { BtnClick(btnManageAccounts, null); }


		}

		private void BtnClick(object sender, EventArgs e)
		{
			Button b = (Button)sender;
			ManagingGroups = b.Text.ToLower().Contains("group");
			pnlManage.Top = pnlSelect.Top;
			pnlManage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.Size = this.MinimumSize;   // new Size(277, 516);
			lstItems.Height = pnlManage.Height - 145;
			lblGroupsOrAccounts.Text = ManagingGroups ? "Groups" : "Accounts";
			mnuMain.Visible = true;
			mnuCreateNew.Text = ManagingGroups ? "Create &New Group" : "Create &New Account";
			pnlSelect.Visible = false;
			pnlManage.Visible = true;
			PopulateItems();
		}

		private void lstItems_MouseUp(object sender, MouseEventArgs e) { mnuContext.Visible = lstItems.SelectedIndex > -1; }

		private void mnuCreateNew_Click(object sender, EventArgs e)
		{
			var newName = string.Empty;
			Group newGroup = null;
			var newPIN = string.Empty;

			if (mnuCreateNew.Text.ToLower().Contains("group"))
			{
				using (frmMessage frm = new frmMessage(frmMessage.OperationType.InputBox, "What's the new Group name?", "Group Name", this))
				{
					frm.ShowDialog();

					if(frm.Result == frmMessage.ReturnResult.Ok)
					{
						using(frmMessage frm2 = new frmMessage(frmMessage.OperationType.PasswordInputBox, "What's the PIN?", "", this))
						{
							frm2.ShowDialog(this);
							Program.PIN_Group = frm2.ResultText;
							newGroup = new Group(EncryptDecrypt.Encrypt(frm.ResultText, Program.PIN_Master));
						}
					}
					// cancelled
				}

			}
			else
			{
				using (frmMessage frm = new frmMessage(frmMessage.OperationType.InputBox, "What's the new Account name?", "Account Name", this))
				{
					frm.ShowDialog();
					newName = frm.ResultText;	
					Account account = new Account(EncryptDecrypt.Encrypt(newName, Program.PIN_Master));
				}
			}
		}

		private void PopulateItems()
		{
			if (ManagingGroups)
			{
				string[] groups = Directory.GetDirectories(Program.AppRoot + "accounts\\groups\\");
				Array.ForEach(groups, group => { group = EncryptDecrypt.Decrypt(group, Program.PIN_Master); });
				lstItems.Items.Add(groups);
			}
			else	// populate account names
			{
				// get accounts list
				string[] accounts = Directory.GetDirectories(Program.AppRoot + "accounts\\");
				Array.ForEach(accounts, s => s = EncryptDecrypt.Decrypt(s, Program.PIN_Master));
				lstItems.Items.AddRange(accounts);
			}

		}
	}
}
