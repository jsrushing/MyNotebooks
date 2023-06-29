/* Display messages and prompts.
 * 7/9/22
 */
using System;
using System.Windows.Forms;
using myJournal.subforms;
using myNotebooks.objects;

namespace myNotebooks.subforms
{
	public partial class frmMessage : Form
	{
		OperationType opType;
		string msg;
		string defaultText;
		public ReturnResult Result = ReturnResult.Cancel;
		public string ResultText { get; private set; }

		public enum OperationType
		{
			Message,
			DeleteNotebook,
			DeleteEntry,
			YesNoQuestion,
			InputBox,
			LabelNameInputBox
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
			msg = msg.Replace("\\n", "  ");
			var lineLength = 30;
			lblMessage.Height = (int)Math.Ceiling((double)msg.Length / lineLength) <= 1 ? 25 : 25 * ((int)Math.Ceiling((double)msg.Length / lineLength));
			lblSelectFromLabelsList.Visible = false;

			//if (msg.Length > 45) { lblMessage.Height += 20; }

			switch (opType)
			{
				case OperationType.DeleteEntry:
				case OperationType.DeleteNotebook:
					lblMessage.Text = opType == OperationType.DeleteNotebook ? "Delete notebook '" + msg + "'?" : "Delete entry '" + msg + "' ? ";
					pnlYesNo.Top = lblMessage.Top + lblMessage.Height;
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
					this.Height = pnlOk.Top + pnlOk.Height + 55;
					this.Text = this.defaultText;
					break;
				case OperationType.YesNoQuestion:
					pnlYesNoCancel.Top = lblMessage.Top + lblMessage.Height;
					pnlYesNoCancel.Visible = true;
					this.AcceptButton = btnCancel1;
					shownPanel = pnlYesNoCancel;
					this.Text = this.defaultText;
					this.Height = pnlYesNoCancel.Top + pnlYesNoCancel.Height + 55;
					break;
				case OperationType.InputBox:
					txtInput.Text = defaultText;
					txtInput.Visible = true;
					txtInput.Top = lblMessage.Top + lblMessage.Height;
					pnlOkCancel.Top = txtInput.Top + txtInput.Height + 5;
					pnlOkCancel.Visible = true;
					txtInput.SelectAll();
					this.AcceptButton = btnOk1;
					shownPanel = pnlOkCancel;
					this.Text = "Enter New Value";
					this.Height = pnlOkCancel.Top + pnlOkCancel.Height + 55;
					break;
				case OperationType.LabelNameInputBox:
					txtInput.Text = defaultText;
					txtInput.Visible = true;
					txtInput.Top = lblMessage.Top + lblMessage.Height;
					pnlOkCancel.Top = txtInput.Top + txtInput.Height + 5;
					pnlOkCancel.Visible = true;
					txtInput.SelectAll();
					this.AcceptButton = btnOk1;
					shownPanel = pnlOkCancel;
					this.Text = "Enter New Value";
					this.Height = pnlOkCancel.Top + pnlOkCancel.Height + 55;

					lblSelectFromLabelsList.Visible = true;
					lblSelectFromLabelsList.Top = txtInput.Top - lblSelectFromLabelsList.Height - 5;

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
			ResultText = txtInput.Text;
			this.Hide();
		}

		private void lblSelectFromLabelsList_Click(object sender, EventArgs e)
		{
			using(frmSelectLabel frm = new frmSelectLabel(this))
			{
				frm.ShowDialog(this);
				txtInput.Text = frm.SelectedLabel;
			}
		}
	}
}
