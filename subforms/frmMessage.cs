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
		OperationType OpType;
		string Msg;
		string DefaultText;
		public ReturnResult Result = ReturnResult.Cancel;
		public string ResultText { get; private set; }
		public bool IsLocalFile { get; private set; }

		public enum OperationType
		{
			Message,
			DeleteNotebook,
			DeleteEntry,
			YesNoQuestion,
			InputBox,
			LabelNameInputBox,
			PasswordInputBox
		}

		public enum ReturnResult
		{
			Yes,
			No,
			Cancel,
			Ok,
			None
		}

		public frmMessage(OperationType type, string message = "", string defaultText = "", Form parent = null, string[] dropDownItems = null)
		{
			InitializeComponent();
			OpType = type;
			Msg = message;
			this.DefaultText = defaultText;
			if (parent != null) { Utilities.SetStartPosition(this, parent); }

			if (dropDownItems != null)
			{
				ddlItemsToSelect.Items.AddRange(dropDownItems);
				ddlItemsToSelect.Location	= txtInput.Location;
				ddlItemsToSelect.Size		= txtInput.Size;
				ddlItemsToSelect.Visible	= true;
			}
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

			lblMessage.Text = Msg;
			Msg = Msg.Replace("\\n", "  ");
			var lineLength = 45;
			lblMessage.Height = (int)Math.Ceiling((double)Msg.Length / lineLength) <= 1 ? 25 : 25 * ((int)Math.Ceiling((double)Msg.Length / lineLength));
			lblSelectFromLabelsList.Visible = false;

			//if (Msg.Length > 45) { lblMessage.Height += 20; }

			switch (OpType)
			{
				case OperationType.DeleteEntry:
				case OperationType.DeleteNotebook:
					lblMessage.Text = OpType == OperationType.DeleteNotebook ? "Delete notebook '" + Msg + "'?" : "Delete entry '" + Msg + "' ? ";
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
					this.Text = this.DefaultText;
					break;
				case OperationType.YesNoQuestion:
					pnlYesNoCancel.Top = lblMessage.Top + lblMessage.Height;
					pnlYesNoCancel.Visible = true;
					this.AcceptButton = btnCancel1;
					shownPanel = pnlYesNoCancel;
					this.Text = this.DefaultText;
					this.Height = pnlYesNoCancel.Top + pnlYesNoCancel.Height + 55;
					break;
				case OperationType.InputBox:
				case OperationType.LabelNameInputBox:
				case OperationType.PasswordInputBox:
					txtInput.Text = DefaultText;
					txtInput.Visible = true;
					txtInput.Top = lblMessage.Top + lblMessage.Height;
					pnlOkCancel.Top = txtInput.Top + txtInput.Height + 5;
					pnlOkCancel.Visible = true;
					txtInput.SelectAll();
					this.AcceptButton = btnOk1;
					shownPanel = pnlOkCancel;
					this.Text = "Enter New Value";
					this.Height = pnlOkCancel.Top + pnlOkCancel.Height + 55;
					//lblSelectFromLabelsList.Visible = OpType != OperationType.InputBox;
					if(OpType == OperationType.PasswordInputBox)
					{
						lblShowPIN.Visible = true;
						txtInput.PasswordChar = '*';
					}
					break;
			}

			if (lblSelectFromLabelsList.Visible)
			{
				lblSelectFromLabelsList.Top = lblSelectFromLabelsList.Visible ? txtInput.Top - lblSelectFromLabelsList.Height - 5 : 0;
				lblSelectFromLabelsList.Text = "Select from " + (OpType == OperationType.LabelNameInputBox ? " Labels " : "PIN Files") + " list";
			}

			if (ddlItemsToSelect.Visible)
			{
				pnlDropDown.Top = pnlOkCancel.Top;
				pnlOkCancel.Top += pnlDropDown.Top + pnlDropDown.Height + 5;
			}

			if (shownPanel != null) { this.Height = shownPanel.Height + shownPanel.Top + 50 + (pnlDropDown.Visible ? pnlDropDown.Height + 5 : 0); }
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

		private void lblShowPin_Click(object sender, EventArgs e)
		{
			txtInput.PasswordChar = txtInput.PasswordChar == '*' ? '\0' : '*';
			lblShowPIN.Text = lblShowPIN.Text == "show" ? "hide" : "show";
		}
	}
}
