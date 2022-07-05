/* Add a new journal entry
 * 6/15/22
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmNewEntry : Form
	{
		public JournalEntry entry = null;

		public frmNewEntry()
		{
			InitializeComponent();
		}

		private void frmNewEntry_Load(object sender, EventArgs e)
		{
			grpCreateEntry.Location = new Point(10, 0);
			grpCreateEntry.Size = new Size(this.Width - 35, this.Height - 50);
			pnlButtons.Location = new Point(grpCreateEntry.Width / 2 - (pnlButtons.Width / 2), lstLabels.Top + lstLabels.Height + 10);
			Utilities.PopulateLabelsList(lstLabels);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			txtNewEntryTitle.Text = string.Empty;
			rtbNewEntry.Text = string.Empty;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (rtbNewEntry.Text.Length > 0 && txtNewEntryTitle.Text.Length > 0)
			{
				string groups = string.Empty;

				for (int i = 0; i < lstLabels.CheckedItems.Count; i++)
				{
					groups += lstLabels.CheckedItems[i].ToString() + ",";
				}
				groups = groups.Length > 0 ? groups.Substring(0, groups.Length - 1) : string.Empty;
				entry = new JournalEntry(txtNewEntryTitle.Text, rtbNewEntry.Text, groups, false);
			}
			this.Hide();
		}

		private void lblManageLabels_Click(object sender, EventArgs e)
		{
			frmManageLabels frm = new frmManageLabels();
			Utilities.Showform(frm, this);
			Utilities.PopulateLabelsList(lstLabels);
		}
	}
}
