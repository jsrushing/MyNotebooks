
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmSelectJournalsToSearch : Form
	{
		public Dictionary<string, string> CheckedJournals { get { return dictJournalsAndPINs; } }
		private Dictionary<string, string> dictJournalsAndPINs = new Dictionary<string, string>();
		//private Dictionary<string, string> dictCheckedItems = new Dictionary<string, string>();

		public frmSelectJournalsToSearch(Form parent)
		{
			InitializeComponent();
			//dictCheckedItems = checkedItems;

			foreach (Notebook j in Program.AllNotebooks)
			{
				if (Program.DictCheckedJournals.ContainsKey(j.Name))
				{
					if (Program.DictCheckedJournals[j.Name].Length > 0)
					{
						lstJournalPINs.Items.Add(j.Name + " (****)");
						dictJournalsAndPINs.Add(j.Name, Program.DictCheckedJournals[j.Name]);
					}
					else
					{
						lstJournalPINs.Items.Add(j.Name);
						dictJournalsAndPINs.Add(j.Name, "");
					}

					lstJournalPINs.SetItemChecked(lstJournalPINs.Items.Count - 1, true);
				}
				else { lstJournalPINs.Items.Add(j.Name); }
			}

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
			dictJournalsAndPINs[s] = txtPIN.Text;
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
			Dictionary<string, string> tmpDict = dictJournalsAndPINs;

			foreach (KeyValuePair<string, string> kvp in tmpDict)
			{ if (!checkedItems.Contains(kvp.Key)) { tmpDict.Remove(kvp.Key); } }

			foreach (var item in checkedItems)
			{
				if (!tmpDict.ContainsKey(Scrubbed(item)))
				{ dictJournalsAndPINs.Add(Scrubbed(item), ""); }
			}

			Program.DictCheckedJournals = dictJournalsAndPINs;
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
				txtPIN.PasswordChar = '*';
				txtPIN.Text = Program.DictCheckedJournals.ContainsKey(Scrubbed(lstJournalPINs.Text)) ? Program.DictCheckedJournals[Scrubbed(lstJournalPINs.Text)] : string.Empty;
				txtPIN.Enabled = true;
				btnAddPIN.Enabled = true;
				txtPIN.Focus();
				lblShowPIN.Visible = true;
				lblShowPIN.Text = "show";
			}
		}

		private void frmSelectJournalsToSearch_FormClosing(object sender, FormClosingEventArgs e)
		{
			dictJournalsAndPINs.Clear();
			e.Cancel = true;
		}

		private string Scrubbed(string stringToScrub) { return stringToScrub.Replace(" (****)", ""); }
	}
}
