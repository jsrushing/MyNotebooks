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

namespace myNotebooks.subforms
{
	public partial class frmSelectNotebooksToSearch : Form
	{
		public Dictionary<string, string> CheckedNotebooks { get { return dictNotebooksAndPINs; } }
		private Dictionary<string, string> dictNotebooksAndPINs = new Dictionary<string, string>();
		//private Dictionary<string, string> dictCheckedItems = new Dictionary<string, string>();
		private const string ShowMoreString = "(show more)";

		public frmSelectNotebooksToSearch(Form parent)
		{
			InitializeComponent();

			if (Program.DictCheckedNotebooks.Count > 0) 
			{ PopulateNotebooksList(true, false, false); } else { PopulateNotebooksList(false, false, true); }

			//foreach (Notebook j in Program.AllNotebooks)
			//{
			//	if (Program.DictCheckedNotebooks.ContainsKey(j.Name))
			//	{
			//		if (Program.DictCheckedNotebooks[j.Name].Length > 0)
			//		{
			//			lstJournalPINs.Items.Add(j.Name + " (****)");
			//			dictNotebooksAndPINs.Add(j.Name, Program.DictCheckedNotebooks[j.Name]);
			//		}
			//		else
			//		{
			//			lstJournalPINs.Items.Add(j.Name);
			//			dictNotebooksAndPINs.Add(j.Name, "");
			//		}

			//		lstJournalPINs.SetItemChecked(lstJournalPINs.Items.Count - 1, true);
			//	}
			//	else { lstJournalPINs.Items.Add(j.Name); }
			//}

			Utilities.SetStartPosition(this, parent);
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
						var newentry = lstJournalPINs.Items.IndexOf(name) > -1 ? lstJournalPINs.Items.IndexOf(name) : lstJournalPINs.Items.IndexOf(name + " (****)");

						if (pin.Length > 0)
						{ lstJournalPINs.Items[newentry] = name + " (****)"; }
						else { lstJournalPINs.Items[newentry] = name; }
					}
				}
				catch(Exception ex) { using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, ex.Message, "Error", this)); }
			}
		}

		private async void btnAddPIN_Click(object sender, EventArgs e)
		{
			var s = lstJournalPINs.Text.Replace(" (****)", "");
			var itemIndex = lstJournalPINs.SelectedIndex;
			Program.DictCheckedNotebooks[s] = txtPIN.Text;
			//s += txtPIN.Text.Length == 0 ? "" : " (****)";
			await AddHasPINIndicators();
			//lstJournalPINs.Items.Insert(lstJournalPINs.SelectedIndex, s);
			//lstJournalPINs.Items.RemoveAt(lstJournalPINs.SelectedIndex);
			txtPIN.PasswordChar = '\0';
			txtPIN.Text = "(select a Journal)";
			txtPIN.Enabled = false;
			btnAddPIN.Enabled = false;
			lstJournalPINs.SelectedIndex = -1;
			lblShowPIN.Visible = false;
			lstJournalPINs.SetItemChecked(itemIndex, true);
			lstJournalPINs.SelectedItems.Add(s);

		}

		private void btnDone_Click(object sender, EventArgs e)
		{
			string[] checkedItems = lstJournalPINs.CheckedItems.OfType<string>().ToArray();



			for (var i = 0; i < checkedItems.Length; i++) { checkedItems[i] = Scrubbed(checkedItems[i]); }
			//Dictionary<string, string> tmpDict = dictNotebooksAndPINs;

			foreach (KeyValuePair<string, string> kvp in Program.DictCheckedNotebooks)
			{ if (!checkedItems.Contains(kvp.Key)) { Program.DictCheckedNotebooks.Remove(kvp.Key); } }

			foreach (var item in checkedItems)
			{
				if (!Program.DictCheckedNotebooks.ContainsKey(Scrubbed(item)))
				{ Program.DictCheckedNotebooks.Add(Scrubbed(item), ""); }
			}

			//Program.DictCheckedNotebooks = dictNotebooksAndPINs;
			this.Hide();
		}

		private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
		{
			if (chkSelectAll.Checked)
			{
				for (int i = 0; i < lstJournalPINs.Items.Count; i++) { lstJournalPINs.SetItemChecked(i, true); }
				chkSelectAll.Text = "un-select all";
			}
			else
			{
				//lstJournalPINs.SelectedIndices.Clear(); 
				for (int i = 0; i < lstJournalPINs.Items.Count; i++) { lstJournalPINs.SetItemChecked(i, false); }
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
			if (lstJournalPINs.SelectedIndex > -1)
			{
				if(lstJournalPINs.SelectedItem.ToString() == ShowMoreString) { PopulateNotebooksList(false, true, false); }
				txtPIN.PasswordChar = '*';
				txtPIN.Text = Program.DictCheckedNotebooks.ContainsKey(Scrubbed(lstJournalPINs.Text)) ? Program.DictCheckedNotebooks[Scrubbed(lstJournalPINs.Text)] : string.Empty;
				txtPIN.Enabled = true;
				btnAddPIN.Enabled = true;
				txtPIN.Focus();
				lblShowPIN.Visible = true;
				lblShowPIN.Text = "show";
			}
		}

		private void frmSelectNotebooksToSearch_FormClosing(object sender, FormClosingEventArgs e)
		{
			dictNotebooksAndPINs.Clear();
			e.Cancel = true;
		}

		private async void PopulateNotebooksList(bool populateWithCheckedJournals, bool showMore, bool showAll)
		{
			if(!showMore) lstJournalPINs.Items.Clear();

			lstJournalPINs.Items.Clear();

			if (showAll)
			{
				await Utilities.PopulateAllNotebookNames();

				//lstJournalPINs.Items.AddRange(Program.AllNotebookNames)

				foreach (var notebookName in Program.AllNotebookNames) { lstJournalPINs.Items.Add(notebookName); }
			}

			if (populateWithCheckedJournals) { PopulateCheckedItems(); }

			if (showMore)
			{
				PopulateCheckedItems();
				lstJournalPINs.Items.Remove(ShowMoreString);
				foreach(var name in Program.AllNotebookNames.Except(Program.DictCheckedNotebooks.Keys)) { lstJournalPINs.Items.Add($"{name}"); }
			}

			AddHasPINIndicators();
		}

		private void PopulateCheckedItems()
		{
			foreach (var name in Program.DictCheckedNotebooks.Keys) { lstJournalPINs.Items.Add(name); }
			for (var i = 0; i < lstJournalPINs.Items.Count; i++) { lstJournalPINs.SetItemChecked(i, true); }
			lstJournalPINs.Items.Add(ShowMoreString);
		}

		private string Scrubbed(string stringToScrub) { return stringToScrub.Replace(" (****)", ""); }
	}
}
