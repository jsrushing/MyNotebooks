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
		string _defaultText;
		public ReturnResult result;
		public string EnteredValue { get; private set; }

		public enum OperationType
		{
			Message,
			DeleteJournal,
			DeleteEntry,
			YesNoQuestion,
			InputBox
		}

		public enum ReturnResult
		{
			Yes,
			No,
			Cancel,
			Ok,
			None
		}

		public frmMessage(OperationType type, string message = "", string defaultText = "")
		{
			InitializeComponent();
			opType = type;
			msg = message;
			_defaultText = defaultText;
		}

		private void frmMessage_Activated(object sender, EventArgs e)
		{
			if (txtInput.Visible) { txtInput.Focus(); }

			foreach(Control c in this.Controls)
			{
				if(c.GetType() == typeof(Panel)) { c.Top = lblMessage.Top + lblMessage.Height + 4; }
			}
		}

		private void frmMessage_Load(object sender, EventArgs e)
		{
			this.Size = this.MinimumSize;

			foreach(Control c in this.Controls)
			{
				if(c.GetType() == typeof(Panel)) { c.Top = 30; }
			}

			lblMessage.Text = msg;

			switch (opType)
			{
				case OperationType.DeleteEntry:
					lblMessage.Text = "Delete entry '" + msg + "'?";
					pnlYesNo.Visible = true;
					this.AcceptButton = btnNo2;
					break;
				case OperationType.DeleteJournal:
					lblMessage.Text = "Delete journal '" + msg + "'?";
					pnlYesNo.Visible = true;
					this.AcceptButton = btnNo2;
					break;
				case OperationType.Message:
					pnlOk.Visible = true;
					this.AcceptButton = btnOk2;
					break;
				case OperationType.YesNoQuestion:
					pnlYesNoCancel.Visible = true;
					this.AcceptButton = btnCancel1;
					break;
				case OperationType.InputBox:
					lblMessage.Text = msg;
					txtInput.Text = _defaultText;
					txtInput.Visible = true;
					pnlOkCancel.Top = txtInput.Top + txtInput.Height + 4;
					pnlOkCancel.Visible = true;
					txtInput.SelectAll();
					this.AcceptButton = btnOk1;
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
			result = txtInput.Visible && txtInput.Text.Length == 0 ? ReturnResult.Cancel : ReturnResult.Ok;
			EnteredValue = txtInput.Text;
			this.Hide();
		}
	}
}
