/* Add a new journal entry
 * 6/15/22
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace myJournal.subforms
{
	public partial class frmNewEntry : Form
	{
		public JournalEntry entry = null;
		private string PIN = string.Empty;

		public frmNewEntry(string PIN)
		{
			InitializeComponent();
			this.PIN = PIN;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			txtNewEntryTitle.Text = string.Empty;
			rtbNewEntry.Text = string.Empty;
		}

		private void frmNewEntry_Load(object sender, EventArgs e)
		{
			grpCreateEntry.Location = new Point(10, 0);
			grpCreateEntry.Size = new Size(this.Width - 35, this.Height - 50);
			pnlButtons.Location = new Point(grpCreateEntry.Width / 2 - (pnlButtons.Width / 2), lstTags.Top + lstTags.Height + 10);
			LoadTags();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (rtbNewEntry.Text.Length > 0 && txtNewEntryTitle.Text.Length > 0)
			{
				string groups = string.Empty;

				for (int i = 0; i < lstTags.CheckedItems.Count; i++)
				{
					groups += lstTags.CheckedItems[i].ToString() + ",";
				}
				groups = groups.Length > 0 ? groups.Substring(0, groups.Length - 1) : string.Empty;
				entry = new JournalEntry(txtNewEntryTitle.Text, rtbNewEntry.Text, groups, false);
			}
			this.Hide();
		}

		private void LoadTags()
		{
			lstTags.Items.Clear();

			foreach (string group in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/settings/groups"))
			{
				lstTags.Items.Add(group);
			}
		}

	}
}
