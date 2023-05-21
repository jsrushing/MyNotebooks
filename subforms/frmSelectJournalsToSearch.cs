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
		public List<Journal> SelectedJournals;
		public string CommonPIN;
		public Dictionary<string, string> DictJournals { get { return dictAllJournals; } }
		private Dictionary<string, string> dictAllJournals = new Dictionary<string, string>();

		public frmSelectJournalsToSearch(Form parent)
		{
			InitializeComponent();
			foreach (Journal j in Program.AllJournals)
			{
				dictAllJournals.Add(j.Name, "");
				lstJournalPINs.Items.Add(j.Name);
				Utilities.SetStartPosition(this, parent);
			}
		}

		private void btnAddPIN_Click(object sender, EventArgs e)
		{
			string s = lstJournalPINs.Text.Replace(" (****)", "");
			dictAllJournals[s] = txtPIN.Text;
			s += " (****)";
			lstJournalPINs.Items.Insert(lstJournalPINs.SelectedIndex, s);
			lstJournalPINs.Items.RemoveAt(lstJournalPINs.SelectedIndex);
			txtPIN.PasswordChar = '\0';
			txtPIN.Text = "(select a Journal)";
			txtPIN.Enabled = false;
			btnAddPIN.Enabled = false;
			lstJournalPINs.SelectedIndex = -1;
			lblShowPIN.Visible = false;
		}

		private void btnDone_Click(object sender, EventArgs e)
		{
			var jrnlName = string.Empty;
			//DictJournals = new Dictionary<string, string>();

			string[] checkedItems = lstJournalPINs.CheckedItems.OfType<string>().ToArray();
			string[] cleanedItems = new string[checkedItems.Length];

			for(int i = 0; i < checkedItems.Length; i++)
			{
				cleanedItems[i] = checkedItems[i].Replace("(****)", "").Trim();
			}


			Dictionary<string, string> tmpDict = dictAllJournals;

			foreach(KeyValuePair<string, string> item in tmpDict)
			{
				if (!cleanedItems.Contains(item.Key)) { dictAllJournals.Remove(item.Key); }
			}

			//DictJournals = dictAllJournals.Except(lstJournalPINs.CheckedIndices.OfType<string>().ToArray());


			//foreach (var v in lstJournalPINs.CheckedItems)
			//{
			//	jrnlName = v.ToString().Replace("(****)", "");
			//	DictJournals.Add(jrnlName, dictAllJournals[jrnlName]);
			//}

			this.Hide();
		}

		private void SetProgramPINForSelectedJournal(Journal journal) { Program.PIN = DictJournals[journal.Name]; }

		private void lstJournalPINs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstJournalPINs.SelectedIndex > -1)
			{
				txtPIN.PasswordChar = '*';
				txtPIN.Text = dictAllJournals[lstJournalPINs.Text.Replace(" (****)", "")];
				txtPIN.Enabled = true;
				btnAddPIN.Enabled = true;
				txtPIN.Focus();
				lblShowPIN.Visible = true;
			}
		}
	}
}
