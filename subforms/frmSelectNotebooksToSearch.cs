/* One-stop selection of notebooks to work with.
 * 06/05/23
 * JSR
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using myNotebooks.objects;

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

		private void AddHasPINTIndicators()
		{
			for(int i = 0; i < lstJournalPINs.Items.Count; i++)
			{

			}
		}

		private void btnAddPIN_Click(object sender, EventArgs e)
		{
			var s = lstJournalPINs.Text.Replace(" (****)", "");
			var itemIndex = lstJournalPINs.SelectedIndex;
			dictNotebooksAndPINs[s] = txtPIN.Text;
			s += txtPIN.Text.Length == 0 ? "" : " (****)";
			lstJournalPINs.Items.Insert(lstJournalPINs.SelectedIndex, s);
			lstJournalPINs.Items.RemoveAt(lstJournalPINs.SelectedIndex);
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
			Dictionary<string, string> tmpDict = dictNotebooksAndPINs;

			foreach (KeyValuePair<string, string> kvp in tmpDict)
			{ if (!checkedItems.Contains(kvp.Key)) { tmpDict.Remove(kvp.Key); } }

			foreach (var item in checkedItems)
			{
				if (!tmpDict.ContainsKey(Scrubbed(item)))
				{ dictNotebooksAndPINs.Add(Scrubbed(item), ""); }
			}

			Program.DictCheckedNotebooks = dictNotebooksAndPINs;
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

			if(showAll)
			{
				await Utilities.PopulateAllNotebookNames();

				foreach (var notebookName in Program.AllNotebookNames)
				{
					if (Program.DictCheckedNotebooks.ContainsKey(notebookName))
					{
						if (Program.DictCheckedNotebooks[notebookName].Length > 0)
						{
							lstJournalPINs.Items.Add(notebookName + " (****)");
							dictNotebooksAndPINs.Add(notebookName, Program.DictCheckedNotebooks[notebookName]);
						}
						else
						{
							lstJournalPINs.Items.Add(notebookName);
							dictNotebooksAndPINs.Add(notebookName, "");
						}

						lstJournalPINs.SetItemChecked(lstJournalPINs.Items.Count - 1, true);
					}
					else { lstJournalPINs.Items.Add(notebookName); }
				}
			}

			if (populateWithCheckedJournals)
			{
				//object[] objects = (object[])Program);
				//lstJournalPINs.Items.AddRange(objects);

				foreach (var name in Program.DictCheckedNotebooks.Keys) { lstJournalPINs.Items.Add(Program.DictCheckedNotebooks[name].Length > 0 ? name + " (****)" : name); }
				for (var i  = 0; i < lstJournalPINs.Items.Count; i++) { lstJournalPINs.SetItemChecked(i, true); }
				lstJournalPINs.Items.Add(ShowMoreString);
			}

			if (showMore)
			{
				lstJournalPINs.Items.Remove(ShowMoreString);
				foreach(var name in Program.AllNotebookNames.Except(Program.DictCheckedNotebooks.Keys)) { lstJournalPINs.Items.Add($"{name}"); }

				//string[] names = Program.AllNotebookNames.ToArray();
				//List<string> lst = Program.AllNotebookNames.ToList();
				//IEnumerable<string> strings = Program.AllNotebookNames.Except(Program.DictCheckedNotebooks.Keys);
				//List <KeyValuePair<string, string>> items = Program.AllNotebookNames.Except(Program.DictCheckedNotebooks.Keys).ToDictionary(x => x, x => x).ToList();

				//object[] objects = (object[])Program.AllNotebookNames.Except(Program.DictCheckedNotebooks.Keys);
				//List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>(Program.AllNotebookNames.Except(Program.DictCheckedNotebooks.Keys), "");
				//lstJournalPINs.Items.AddRange(objects);
			}
		}

		private string Scrubbed(string stringToScrub) { return stringToScrub.Replace(" (****)", ""); }
	}
}
