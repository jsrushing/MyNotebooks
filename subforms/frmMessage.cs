/* Display messages and prompts.
 * 7/9/22
 */
using System;
using System.Windows.Forms;
using myJournal.objects;

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
			if (parent != null) { Utilities.SetStartPosition(this, parent); }
		}

		private void frmMessage_Activated(object sender, EventArgs e)
		{ if (txtInput.Visible) { txtInput.Focus(); } }

		private void frmMessage_Load(object sender, EventArgs e)
		{
			Panel shownPanel = null;

			foreach (Control c in this.Controls)
			{
				if (c.GetType() == typeof(Panel)) { c.Top = 28; }
			}

			lblMessage.Text = msg;
			lblMessage.Height = 28 * ((int)Math.Ceiling((double)msg.Length / 38));

			switch (opType)
			{
				case OperationType.DeleteEntry:
				case OperationType.DeleteJournal:
					lblMessage.Text = opType == OperationType.DeleteJournal ? "Delete journal '" + msg + "'?" : "Delete entry '" + msg + "' ? ";
					pnlYesNo.Top =lblMessage.Top + lblMessage.Height;
					pnlYesNo.Visible = true;
					this.AcceptButton = btnNo2;
					shownPanel = pnlYesNo;
					this.Text = "Please Confirm";
					this.Height = pnlYesNo.Top + pnlYesNo.Height + 55;
					break;
				case OperationType.Message:
					pnlOk.Top = lblMessage.Top + lblMessage.Height;	
					pnlOk.Visible = true;
					this.AcceptButton = btnOk2;
					shownPanel = pnlOk;
					this.Text = "";
					this.Height = pnlOk.Top + pnlOk.Height + 55;
					break;
				case OperationType.YesNoQuestion:
					pnlYesNoCancel.Top = lblMessage.Top + lblMessage.Height;
					pnlYesNoCancel.Visible = true;
					this.AcceptButton = btnCancel1;
					shownPanel = pnlYesNoCancel;
					this.Text = "Please Confirm";
					this.Height = pnlYesNoCancel.Top + pnlYesNoCancel.Height + 55;
					break;
				case OperationType.InputBox:
					txtInput.Text = defaultText;
					txtInput.Visible = true;
					//txtInput.Top = 23 * ((int)Math.Ceiling((double)msg.Length / 42));
					pnlOkCancel.Top = txtInput.Top + txtInput.Height + 15;
					pnlOkCancel.Visible = true;
					txtInput.SelectAll();
					this.AcceptButton = btnOk1;
					shownPanel = pnlOkCancel;
					this.Text = "Enter New Value";
					this.Height = pnlOkCancel.Top + pnlOkCancel.Height + 55;
					break;
			}

			lblMessage.Height = lblMessage.Text.Length > 0 ? (Convert.ToInt16(lblMessage.Text.Length / 25) > 0 ? Convert.ToInt16(lblMessage.Text.Length / 25) : 1) * 28 : 28;
			if (shownPanel != null) { this.Height = shownPanel.Height + shownPanel.Top + 50; }
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
			Result = ReturnResult.Ok;
			EnteredValue = txtInput.Text;
			this.Hide();
		}
	}
}
