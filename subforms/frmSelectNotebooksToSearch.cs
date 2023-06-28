/* One-stop selection of notebooks to work with.
 * 06/05/23
 * JSR
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using myNotebooks.objects;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Prng.Drbg;

namespace myNotebooks.subforms
{
	public partial class frmSelectNotebooksToSearch : Form
	{
		private const string ShowMoreString = "(show more)";
		private bool IsDirty = false;
		private bool allowSelection = true;
		private Dictionary<string, string> initialDictCheckedItems = Program.DictCheckedNotebooks;

		public frmSelectNotebooksToSearch(Form parent, string userMessage = "")
		{
			InitializeComponent();
			lblUserPrompt.Text = userMessage.Length > 0 ? userMessage : "Specify a PIN for any protected notebooks." + Environment.NewLine + "To remove a PIN, add a blank value.";

			if (Program.DictCheckedNotebooks.Count > 0) { PopulateNotebooksList(true, false, false); }
			else { PopulateNotebooksList(false, false, true); }

			Utilities.SetStartPosition(this, parent);
		}

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

		private async void btnAddPIN_Click(object sender, EventArgs e)
		{
			var s = lstNotebookPINs.Text.Replace(" (****)", "");
			var itemIndex = lstNotebookPINs.SelectedIndex;
			Program.DictCheckedNotebooks[s] = txtPIN.Text;
			await AddHasPINIndicators();
			txtPIN.PasswordChar = '\0';
			txtPIN.Text = "(select a Journal)";
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

		private async Task PopulateProgramDictCheckedNBooks()
		{
			//List<string> checkedItems = lstNotebookPINs.CheckedItems.OfType<string>().ToList();
			//List<KeyValuePair<string, string>> chkdBooks = Program.DictCheckedNotebooks.ToList();

			//Program.DictCheckedNotebooks.Clear();

			foreach(string checkedItem in lstNotebookPINs.CheckedItems.OfType<string>().ToList())
			{
				if (!Program.DictCheckedNotebooks.Keys.Contains(Scrubbed(checkedItem))) 
				{
					Program.DictCheckedNotebooks.Add(checkedItem, "");
				}
			}


			//foreach (KeyValuePair<string, string> kvp in Program.DictCheckedNotebooks)
			//{ if (!checkedItems.Contains(kvp.Key)) { Program.DictCheckedNotebooks.Remove(Scrubbed(kvp.Key)); } }

			//foreach (KeyValuePair<string, string> item in Program.DictCheckedNotebooks)
			//{
			//	if (!Program.DictCheckedNotebooks.ContainsKey(item.Key))
			//	{ Program.DictCheckedNotebooks.Add(item.Key, ""); }
			//}
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
				PopulateCheckedItems();
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
