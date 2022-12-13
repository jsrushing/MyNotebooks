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
		string defaultText;
		public ReturnResult Result = ReturnResult.Cancel;
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

		public frmMessage(OperationType type, string message = "", string defaultText = "", Form parent = null)
		{
			InitializeComponent();
			opType = type;
			msg = message;
			this.defaultText = defaultText;
			if(parent != null) { this.Location = new System.Drawing.Point(parent.Left + 25, parent.Top + 25); }
		}

		private void frmMessage_Activated(object sender, EventArgs e)
		{ if (txtInput.Visible) { txtInput.Focus(); } }

		private void frmMessage_Load(object sender, EventArgs e)
		{
			Panel shownPanel = null;

			foreach(Control c in this.Controls)
			{
				if(c.GetType() == typeof(Panel)) { c.Top = 28; }
			}

			lblMessage.Text = msg;

			switch (opType)
			{
				case OperationType.DeleteEntry:
				case OperationType.DeleteJournal:
					lblMessage.Text = opType == OperationType.DeleteJournal ? "Delete journal '" + msg + "'?" : "Delete entry '" + msg + "' ? ";
					pnlYesNo.Top = 28 * ((int)Math.Ceiling((double)lblMessage.Text.Length / 38));
					pnlYesNo.Visible = true;
					this.AcceptButton = btnNo2;
					shownPanel = pnlYesNo;
					this.Text = "Please Confirm";
					break;
				case OperationType.Message:
					pnlOk.Top = 28 * ((int)Math.Ceiling((double)msg.Length / 38));
					pnlOk.Visible = true;
					this.AcceptButton = btnOk2;
					this.Text = "";
					break;
				case OperationType.YesNoQuestion:
					pnlYesNoCancel.Top = 28 * ((int)Math.Ceiling((double)msg.Length / 38));
					pnlYesNoCancel.Visible = true;
					this.AcceptButton = btnCancel1;
					shownPanel = pnlYesNoCancel;
					this.Text = "Please Confirm";
					break;
				case OperationType.InputBox:
					lblMessage.Text = msg;
					txtInput.Text = defaultText;
					txtInput.Visible = true;
					pnlOkCancel.Top = txtInput.Top + txtInput.Height + 15;
					pnlOkCancel.Visible = true;
					txtInput.SelectAll();
					this.AcceptButton = btnOk1;
					shownPanel = pnlOkCancel;
					this.Text = "Enter New Value";
					break;
			}
			if(shownPanel != null) { this.Height = shownPanel.Height + shownPanel.Top + 50; }
		}

		private void btnYes_Click(object sender, EventArgs e)
		{
			Result = ReturnResult.Yes;
			this.Hide();
		}

		private void btnNo_Click(object sender, EventArgs e)
		{
			Result = ReturnResult.No;
			this.Hide();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Result = ReturnResult.Cancel;
			this.Hide();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Result = txtInput.Visible && txtInput.Text.Length == 0 ? ReturnResult.Cancel : ReturnResult.Ok;
			EnteredValue = txtInput.Text;
			this.Hide();
		}
	}
}
