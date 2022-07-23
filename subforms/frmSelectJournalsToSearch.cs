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
	public partial class frmSelectJournalsToSearch : Form
	{
		public List<Journal> SelectedJournals;
		public string CommonPIN;

		public frmSelectJournalsToSearch()
		{
			InitializeComponent();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{

		}
	}
}
