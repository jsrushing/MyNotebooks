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
					if(frm.Result == frmMessage.ReturnResult.Yes) { await PopulateProgramDictCheckedNBooks(); }
					if(frm.Result != frmMessage.ReturnResult.No) { this.Hide(); }
				}
			}
			else { e.Cancel = false; }
		}

		private async Task AddHasPINIndicators()
		{
			if (Program.DictCheckedNotebooks.Count > 0)
			{
				// JSR : 60/17/23 - Make this more LINQ'd up ...
				//List<string> v = lstJournalPINs.Items.OfType<string>().ToList().Intersect(Program.DictCheckedNotebooks.Keys).ToList();

				try
				{
					//var v2 = Program.DictCheckedNotebooks.ToList();  //.ToDictionary(x => x.Value.Length > 0); 

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
			}
		}

		private async void btnAddPIN_Click(object sender, EventArgs e)
		{
			var s = lstNotebookPINs.Text.Replace(" (****)", "");
			var itemIndex = lstNotebookPINs.SelectedIndex;
			Program.DictCheckedNotebooks[s] = txtPIN.Text;
			//s += txtPIN.Text.Length == 0 ? "" : " (****)";
			await AddHasPINIndicators();
			//lstJournalPINs.Items.Insert(lstJournalPINs.SelectedIndex, s);
			//lstJournalPINs.Items.RemoveAt(lstJournalPINs.SelectedIndex);
			txtPIN.PasswordChar = '\0';
			txtPIN.Text = "(select a Journal)";
			txtPIN.Enabled = false;
			btnAddPIN.Enabled = false;
			lstNotebookPINs.SelectedIndex = -1;
			lblShowPIN.Visible = false;
			lstNotebookPINs.SetItemChecked(itemIndex, true);
			lstNotebookPINs.SelectedItems.Add(s);

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
				for (int i = 0; i < lstNotebookPINs.Items.Count; i++) { lstNotebookPINs.SetItemChecked(i, true); }
				chkSelectAll.Text = "un-select all";
			}
			else
			{
				//lstJournalPINs.SelectedIndices.Clear(); 
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
			if (lstNotebookPINs.SelectedIndex > -1)
			{
				IsDirty = Program.DictCheckedNotebooks.Count != lstNotebookPINs.CheckedItems.Count;
				if (lstNotebookPINs.SelectedItem.ToString() == ShowMoreString) { PopulateNotebooksList(false, true, false); }
				txtPIN.PasswordChar = '*';
				txtPIN.Text = Program.DictCheckedNotebooks.ContainsKey(Scrubbed(lstNotebookPINs.Text)) ? Program.DictCheckedNotebooks[Scrubbed(lstNotebookPINs.Text)] : string.Empty;
				txtPIN.Enabled = true;
				btnAddPIN.Enabled = true;
				txtPIN.Focus();
				lblShowPIN.Visible = true;
				lblShowPIN.Text = "show";
			}
		}

		private async Task PopulateProgramDictCheckedNBooks()
		{
			List<string> checkedItems = lstNotebookPINs.CheckedItems.OfType<string>().ToList();
			checkedItems.ForEach(e => Scrubbed(e));

			foreach (KeyValuePair<string, string> kvp in Program.DictCheckedNotebooks)
			{ if (!checkedItems.Contains(kvp.Key)) { Program.DictCheckedNotebooks.Remove(kvp.Key); } }

			foreach (var item in checkedItems)
			{
				if (!Program.DictCheckedNotebooks.ContainsKey(item))
				{ Program.DictCheckedNotebooks.Add(item, ""); }
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
