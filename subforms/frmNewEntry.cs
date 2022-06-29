using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myJournal.subforms
{
	public partial class frmNewEntry : Form
	{
		public frmNewEntry()
		{
			InitializeComponent();
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
		}
	}
}
