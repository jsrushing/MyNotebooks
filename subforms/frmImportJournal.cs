using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace myJournal
{
	public partial class frmImportJournal : Form
	{
		private Point myLocation;
		Journal Journal_ImportTo;

		public frmImportJournal(Point pntLocation, ComboBox lst, Journal journalImportTo)
		{
			InitializeComponent();
			myLocation = new Point(pntLocation.X + 10, pntLocation.Y + 35);
			this.Journal_ImportTo = journalImportTo;
			foreach(object o in lst.Items) { cbxJournals_From.Items.Add(o.ToString()); }
		}

		private void frmImportJournal_Load(object sender, EventArgs e)
		{
			this.Location = myLocation;
			this.Size = new Size(this.Width - 20, this.Height - 45);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void btnImport_Click(object sender, EventArgs e)
		{

		}

		private void lblSelectAllEntries_Click(object sender, EventArgs e)
		{

		}

		private void cbxJournals_From_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
