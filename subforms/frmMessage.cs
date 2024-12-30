/* Display messages and prompts.
 * 7/9/22
 */
using System;
using System.Windows.Forms;
using myJournal.subforms;
using MyNotebooks.objects;

namespace MyNotebooks.subforms
{
	public partial class frmMessage : Form
	{
		OperationType opType;
		string msg;
		string defaultText;
		public ReturnResult Result = ReturnResult.Cancel;
		public string ResultText { get; private set; }
		public bool IsLocalFile { get; private set; }

		private const int SmallWidth = 400;
		private const int RegularWidth = 694;

		public enum OperationType
		{
			Message,
			DeleteNotebook,
			DeleteEntry,
			YesNoQuestion,
			YesNoCancelQuestion,
			InputBox,
			LabelNameInputBox,
			PINFileInputBox
		}

		public enum ReturnResult
		{
			Yes,
			No,
			Cancel,
			Ok,
			None
		}

		public frmMessage(OperationType type, string message = "", string defaultText = "", Form parent = null, string[] dropDownItems = null, int maxInput = 0)
		{
			InitializeComponent();
			opType = type;
			msg = message;
			this.defaultText = defaultText;
			if (parent != null) { Utilities.SetStartPosition(this, parent); }

			if (dropDownItems != null)
			{
				ddlItemsToSelect.Items.AddRange(dropDownItems);
				ddlItemsToSelect.Visible = true;
			}

			txtInput.MaxLength = maxInput > 0 ? maxInput : 2500;
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
			var lineLength = 80;
			lblMessage.Height = (int)Math.Ceiling((double)msg.Length / lineLength) <= 1 ? 25 : 25 * ((int)Math.Ceiling((double)msg.Length / lineLength));
			if(msg.IndexOf(Environment.NewLine) > -1) { lblMessage.Height += 25; }
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
					pnlYesNo.Top = lblMessage.Top + lblMessage.Height;
					pnlYesNo.Visible = true;
					this.AcceptButton = btnNo2;
					shownPanel = pnlYesNo;
					this.Text = this.defaultText;
					this.Height = pnlYesNo.Top + pnlYesNo.Height + 55;
					break;
				case OperationType.YesNoCancelQuestion:
					pnlYesNoCancel.Top = lblMessage.Top + lblMessage.Height;
					pnlYesNoCancel.Visible = true;
					this.AcceptButton = btnCancel1;
					shownPanel = pnlYesNoCancel;
					this.Text = this.defaultText;
					this.Height = pnlYesNoCancel.Top + pnlYesNoCancel.Height + 55;
					break;
				case OperationType.InputBox:
				case OperationType.PINFileInputBox:
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
					lblSelectFromLabelsList.Visible = opType != OperationType.InputBox;
					break;
			}

			if (lblSelectFromLabelsList.Visible)
			{
				lblSelectFromLabelsList.Top = lblSelectFromLabelsList.Visible ? txtInput.Top - lblSelectFromLabelsList.Height - 5 : 0;
				lblSelectFromLabelsList.Text = "Select from " + (opType == OperationType.LabelNameInputBox ? " Labels " : "PIN Files") + " list";
			}

			if (ddlItemsToSelect.Visible)
			{
				pnlDropDown.Top = pnlOkCancel.Top;
				pnlOkCancel.Top += pnlDropDown.Top + pnlDropDown.Height + 5;
			}

			if (shownPanel != null) 
			{ 
				this.Height = shownPanel.Height + shownPanel.Top + 50 + (pnlDropDown.Visible ? pnlDropDown.Height + 5 : 0); 
				if(msg.Length < 45) { SetSmallWidth(opType); };
			}
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

		private void ddlItemsToSelect_SelectedIndexChanged(object sender, EventArgs e) { txtInput.Text = ddlItemsToSelect.Text; }

		private void lblSelectFromLabelsList_Click(object sender, EventArgs e)
		{
			Label lbl = (Label)sender;

			if (lbl.Text.ToLower().Contains("label"))
			{
				using (frmSelectLabel frm = new frmSelectLabel(this))
				{
					frm.ShowDialog(this);
					txtInput.Text = frm.SelectedLabel;
				}
			}

			if (lbl.Text.ToLower().Contains("pin file"))
			{
				using (frmSelectPINFile frm = new frmSelectPINFile(this))
				{
					frm.ShowDialog();
					txtInput.Text = frm.PINFileName;
					IsLocalFile = frm.IsLocalFile;
				}
			}
		}

		private void SetSmallWidth(OperationType opType)
		{
			this.Width = SmallWidth;
			if(pnlOk.Visible) { btnOk2.Left = pnlOk.Width / 2 - btnOk2.Width / 2; }
			if(pnlOkCancel.Visible)
			{
				btnOk1.Left = pnlOkCancel.Width / 2 - btnOk1.Width - 30;
				btnCancel2.Left = pnlOkCancel.Width / 2 + 30;
			}
			if (pnlYesNo.Visible)
			{
				btnYes2.Left = pnlYesNo.Width / 2 - btnYes2.Width - 30;
				btnNo2.Left = pnlYesNo.Width / 2 + 30;
			}
			if (pnlYesNoCancel.Visible)
			{
				btnOk1.Left = pnlYesNoCancel.Width / 2 - btnOk1.Width / 2;
				btnCancel1.Left = btnOk1.Left + btnOk1.Width + 10;
				btnYes1.Left = btnOk1.Left - btnYes1.Width - 10;
			}
		}
	}
}
