/* Display messages and prompts.
 * 7/9/22
 */
using System;
using System.Windows.Forms;

namespace myJournal.subforms
{
	public partial class frmMessage : Form
	{
		OperationType opType;
		string msg;
		public ReturnResult result;

		public enum OperationType
		{
			Message,
			DeleteJournal,
			DeleteEntry,
			YesNoQuestion
		}

		public enum ReturnResult
		{
			Yes,
			No,
			Cancel,
			Ok,
			None
		}

		public frmMessage(OperationType type, string message)
		{
			InitializeComponent();
			opType = type;
			msg = message;
		}

		private void frmMessage_Load(object sender, EventArgs e)
		{
			foreach(Control c in this.Controls)
			{
				if(c.GetType() == typeof(Panel)) { c.Top = 30; }
			}

			switch (opType)
			{
				case OperationType.DeleteEntry:
					lblMessage.Text = "Delete entry '" + msg + "'?";
					pnlYesNo.Visible = true;
					break;
				case OperationType.DeleteJournal:
					lblMessage.Text = "Delete journal '" + msg + "'?";
					pnlYesNo.Visible = true;
					break;
				case OperationType.Message:
					lblMessage.Text = msg;
					pnlOk.Visible = true;
					break;
				case OperationType.YesNoQuestion:
					lblMessage.Text = msg;
					pnlYesNoCancel.Visible = true;
					break;
			}
		}

		private void btnYes_Click(object sender, EventArgs e)
		{
			result = ReturnResult.Yes;
			this.Hide();
		}

		private void btnNo_Click(object sender, EventArgs e)
		{
			result = ReturnResult.No;
			this.Hide();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			result = ReturnResult.Cancel;
			this.Hide();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			result = ReturnResult.Ok;
			this.Hide();
		}
	}
}
