/* Confirm journal delete.
 * 7/9/22
 */
using System;
using System.Windows.Forms;

namespace myJournal.subforms
{
	public partial class frmConfirmDeleteJournal : Form
	{
		private Journal je;
		public bool deleted = false;

		public frmConfirmDeleteJournal(Journal jeToDelete)
		{
			InitializeComponent();
			je = jeToDelete;
			lblPrompt.Text = "Delete journal " + je.Name + "?";
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			je.Delete();
			deleted = true;
			this.Hide();
		}
	}
}
