/* One-stop selection of notebooks to work with.
 * 06/05/23
 * JSR
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryption;
using Microsoft.Extensions.Primitives;
using myJournal.subforms;
using MyNotebooks.objects;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Prng.Drbg;

namespace MyNotebooks.subforms
{
	public partial class frmSelectNotebooksToSearch : Form
	{
		private const string ShowMoreString = "(show more)";
		private bool IsDirty = false;
		private bool allowSelection = true;
		private Dictionary<string, string> initialDictCheckedItems = Program.DictCheckedNotebooks;
		private Font mouseOffFont = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
		private Font mouseOverFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Underline | FontStyle.Italic, GraphicsUnit.Point);


		public frmSelectNotebooksToSearch(Form parent, string userMessage = "")
		{
			InitializeComponent();
			lblUserPrompt.Text = userMessage.Length > 0 ? userMessage : "Specify a PIN for any protected notebooks." + Environment.NewLine + "To remove a PIN, add a blank value.";

			if (Program.DictCheckedNotebooks.Count > 0) { PopulateNotebooksList(true, false, false); }
			else { PopulateNotebooksList(false, false, true); }

			Utilities.SetStartPosition(this, parent);
		}

		private void frmSelectNotebooksToSearch_Load(object sender, EventArgs e) { }

		private async void frmSelectNotebooksToSearch_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;

			if (IsDirty)
			{
				using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Do you want to save your changes?", "Confirm"))
				{
					frm.ShowDialog();
					if (frm.Result != frmMessage.ReturnResult.No) { Program.DictCheckedNotebooks = initialDictCheckedItems; }
					if (frm.Result == frmMessage.ReturnResult.No | frm.Result == frmMessage.ReturnResult.Yes) { this.Hide(); }
				}
			}
			else { e.Cancel = false; }
		}

		private async Task AddHasPINIndicators()
		{
			if (Program.DictCheckedNotebooks.Count > 0)
			{
				allowSelection = false;

				try
				{
					//var v2 = Program.DictCheckedNotebooks.ToList();  //.ToDictionary(x => x.Value.Length > 0); // ???

					foreach (KeyValuePair<string, string> kvp in Program.DictCheckedNotebooks)
					{
						var name = kvp.Key;
						var pin = kvp.Value;
						var newentry = lstNotebookPINs.Items.IndexOf(name) > -1 ? lstNotebookPINs.Items.IndexOf(name) : lstNotebookPINs.Items.IndexOf(name + " (****)");

						if (pin.Length > 0)
						{ lstNotebookPINs.Items[newentry] = name + " (****)"; }
						else { lstNotebookPINs.Items[newentry] = name; }
					}
				}
				catch (Exception ex) { using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, ex.Message, "Error", this)) { frm.ShowDialog(); } }

				allowSelection = true;
			}
		}

		private void AnimateExportImportLabels_MouseOff(object sender, EventArgs e)
		{
			lblExport.Font = mouseOffFont;
			lblImport.Font = mouseOffFont;
		}

		private void AnimateExportImportLabels_MouseOver(object sender, EventArgs e)
		{
			Label lbl = (Label)sender;
			lbl.Font = mouseOverFont;
		}

		private async void btnAddPIN_Click(object sender, EventArgs e)
		{
			var s = lstNotebookPINs.Text.Replace(" (****)", "");
			var itemIndex = lstNotebookPINs.SelectedIndex;
			Program.DictCheckedNotebooks[s] = txtPIN.Text;
			await AddHasPINIndicators();
			txtPIN.PasswordChar = '\0';
			txtPIN.Text = "(select a notebook)";
			txtPIN.Enabled = false;
			btnAddPIN.Enabled = false;
			lblShowPIN.Visible = false;
			lstNotebookPINs.SelectedIndex = -1;
			allowSelection = false;
			lstNotebookPINs.SetItemChecked(itemIndex, true);
			lstNotebookPINs.SelectedItems.Add(s);
			allowSelection = true;

		}

		private async void btnDone_Click(object sender, EventArgs e)
		{
			await PopulateProgramDictCheckedNBooks();
			IsDirty = false;
			this.Hide();
		}

		private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
		{
			if (chkSelectAll.Checked)
			{
				for (var i = 0; i < lstNotebookPINs.Items.Count; i++) { lstNotebookPINs.SetItemChecked(i, true); }

				chkSelectAll.Text = "un-select all";
			}
			else
			{
				for (int i = 0; i < lstNotebookPINs.Items.Count; i++) { lstNotebookPINs.SetItemChecked(i, false); }
				chkSelectAll.Text = "select all";
			}
		}

		private void lblShowPIN_Click(object sender, EventArgs e)
		{
			txtPIN.PasswordChar = txtPIN.PasswordChar == '*' ? '\0' : '*';
			lblShowPIN.Text = lblShowPIN.Text == "show" ? "hide" : "show";
		}

		private void lstJournalPINs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstNotebookPINs.SelectedIndex > -1 && allowSelection)
			{
				{
					if (lstNotebookPINs.SelectedItem.ToString() != ShowMoreString)
					{
						IsDirty = Program.DictCheckedNotebooks.Count != lstNotebookPINs.CheckedItems.Count;

						if (!Program.DictCheckedNotebooks.ContainsKey(lstNotebookPINs.SelectedItem.ToString()))
						{ Program.DictCheckedNotebooks.Add(lstNotebookPINs.SelectedItem.ToString(), ""); }
						else { Program.DictCheckedNotebooks.Remove(lstNotebookPINs.SelectedItem.ToString()); }
					}
					else { PopulateNotebooksList(false, true, false); }

					txtPIN.PasswordChar = '*';
					txtPIN.Text = Program.DictCheckedNotebooks.ContainsKey(Scrubbed(lstNotebookPINs.Text)) ? Program.DictCheckedNotebooks[Scrubbed(lstNotebookPINs.Text)] : string.Empty;
					txtPIN.Enabled = true;
					btnAddPIN.Enabled = true;
					txtPIN.Focus();
					lblShowPIN.Visible = true;
					lblShowPIN.Text = "show";
				}
			}
		}

		private async void ManagePinFile(object sender, EventArgs e)
		{
			//ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
			Label lbl = (Label)sender;

			if (lbl.Text.ToLower().Contains("import"))
			{
				using (frmSelectPINFile frm = new frmSelectPINFile(this))
				{
					frm.ShowDialog();
					var pinFileName = frm.PINFileName != null ? frm.PINFileName.Replace(".pin", "") : null;
					Program.PIN = frm.PIN != null ? frm.PIN : string.Empty;

					if (pinFileName != null && pinFileName.Length > 0)
					{
						Program.DictCheckedNotebooks.Clear();
						if (frm.IsLocalFile)
						{
							foreach (var pinFile in File.ReadAllLines(Program.AppRoot + pinFileName + ".pin"))
							{
								Utilities.PopulateDictCheckedNotebooks(pinFile);
							}
						}
						else    // its an Azure PIN file
						{
							await AzureFileClient.GetAzureItemNames(true, "pinfiles");

							foreach (var s in Program.AzurePinFileNames)
							{
								Utilities.PopulateDictCheckedNotebooks(s);
							}
						}

						if (Program.DictCheckedNotebooks.Count > 0) { PopulateNotebooksList(true, false, false); }
						else { using frmMessage frm2 = new frmMessage(frmMessage.OperationType.Message, "The PIN was incorrect.", "Wrong PIN", this); frm2.ShowDialog(); }
					}
				}
			}
			else
			{
				if (Program.DictCheckedNotebooks.Count == 0)
				{
					using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "No notebooks are selected.", "Nothing Selected", this))
					{ frm.ShowDialog(); }
				}
				else
				{
					var newFileName = string.Empty;

					// ask for the new file name
					using (frmMessage frm = new frmMessage(frmMessage.OperationType.PINFileInputBox, "File name?", null, this))
					{
						frm.ShowDialog();
						newFileName = frm.ResultText + ".pin";

						// see if the file exists, exit unless user chooses to overwrite
						if (File.Exists(Program.AppRoot + newFileName))
						{
							using (frmMessage frm2 = new frmMessage(frmMessage.OperationType.YesNoQuestion, "The file '" + newFileName + " already exists. Would you like to overwrite it?", "File Exists!", this))
							{
								frm2.ShowDialog();
								newFileName = frm2.Result != frmMessage.ReturnResult.Yes ? null : newFileName;
							}
						}
					}

					if (newFileName != null && newFileName.Length > 0)
					{
						//if (Utilities.FileNameIsValid(newFileName))
						//{
							using (frmMessage frm = new frmMessage(frmMessage.OperationType.InputBox, "What's the PIN?", "", this))
							{
								frm.ShowDialog(this);
								Program.PIN = frm.ResultText;
							}

							// encrypt Program.DictCheckedNotebooks
							StringBuilder sb = new StringBuilder();

							foreach (var v in Program.DictCheckedNotebooks)
							{ sb.AppendLine(EncryptDecrypt.Encrypt(v.Key, Program.PIN) + "," + EncryptDecrypt.Encrypt(v.Value, Program.PIN)); }

							// save to Program.AppRoot + <filename> + ".pin"	// trap for valid filename
							File.WriteAllText(Program.AppRoot + newFileName, sb.ToString());

							// ask to upload file to cloud
							using (frmMessage frm = new frmMessage(frmMessage.OperationType.YesNoQuestion, "Would you like to keep this PIN file in your cloud?", "Store In Cloud?", this))
							{
								frm.ShowDialog(this);

								if (frm.Result == frmMessage.ReturnResult.Yes)
								{
									// upload the file to share "pinfiles"
									await AzureFileClient.UploadFile(Program.AppRoot + newFileName + ".pin", "pinfiles");
								}
							}
						//}
						//else
						//{
						//	//using (frmMessage frm4 = new frmMessage(frmMessage.OperationType.Message, Program.InvalidFileName, "", this))
						//	//{ frm4.ShowDialog(); }
						//}
					}
				}
			}
		}

		private async Task PopulateProgramDictCheckedNBooks()
		{
			foreach (var checkedItem in lstNotebookPINs.CheckedItems.OfType<string>().ToList())
			{
				if (!Program.DictCheckedNotebooks.Keys.Contains(Scrubbed(checkedItem)) && !checkedItem.Equals(ShowMoreString))
				{
					Program.DictCheckedNotebooks.Add(checkedItem, "");
				}
			}
		}

		private async void PopulateNotebooksList(bool populateWithCheckedJournals, bool showMore, bool showAll)
		{
			if (!showMore) lstNotebookPINs.Items.Clear();
			
			lstNotebookPINs.Items.Clear();

			if (showAll)
			{
				await Utilities.PopulateAllNotebookNames();
				lstNotebookPINs.Items.AddRange(Program.AllNotebookNames.ToArray());
			}

			if (populateWithCheckedJournals) { PopulateCheckedItems(); }

			if (showMore)
			{
				if (!populateWithCheckedJournals) PopulateCheckedItems();
				lstNotebookPINs.Items.Remove(ShowMoreString);
				foreach (var name in Program.AllNotebookNames.Except(Program.DictCheckedNotebooks.Keys)) { lstNotebookPINs.Items.Add($"{name}"); }
			}

			await AddHasPINIndicators();
		}

		private void PopulateCheckedItems()
		{
			foreach (var name in Program.DictCheckedNotebooks.Keys) { lstNotebookPINs.Items.Add(name); }
			for (var i = 0; i < lstNotebookPINs.Items.Count; i++) { lstNotebookPINs.SetItemChecked(i, true); }
			if (lstNotebookPINs.Items.Count < Program.AllNotebookNames.Count) { lstNotebookPINs.Items.Add(ShowMoreString); }
		}

		private string Scrubbed(string stringToScrub) { return stringToScrub.Replace(" (****)", ""); }
	}
}
