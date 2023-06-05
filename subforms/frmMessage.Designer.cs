
namespace myJournal.subforms
{
	partial class frmMessage
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			lblMessage = new System.Windows.Forms.Label();
			pnlYesNoCancel = new System.Windows.Forms.Panel();
			btnNo1 = new System.Windows.Forms.Button();
			btnCancel1 = new System.Windows.Forms.Button();
			btnYes1 = new System.Windows.Forms.Button();
			pnlYesNo = new System.Windows.Forms.Panel();
			btnNo2 = new System.Windows.Forms.Button();
			btnYes2 = new System.Windows.Forms.Button();
			pnlOkCancel = new System.Windows.Forms.Panel();
			btnCancel2 = new System.Windows.Forms.Button();
			btnOk1 = new System.Windows.Forms.Button();
			pnlOk = new System.Windows.Forms.Panel();
			btnOk2 = new System.Windows.Forms.Button();
			txtInput = new System.Windows.Forms.TextBox();
			pnlYesNoCancel.SuspendLayout();
			pnlYesNo.SuspendLayout();
			pnlOkCancel.SuspendLayout();
			pnlOk.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblMessage
			// 
			lblMessage.Location = new System.Drawing.Point(5, 5);
			lblMessage.Name = "lblMessage";
			lblMessage.Size = new System.Drawing.Size(251, 56);
			lblMessage.TabIndex = 0;
			lblMessage.Text = "Delete entry 'this is the entry'?";
			// 
			// pnlYesNoCancel
			// 
			pnlYesNoCancel.Controls.Add(btnNo1);
			pnlYesNoCancel.Controls.Add(btnCancel1);
			pnlYesNoCancel.Controls.Add(btnYes1);
			pnlYesNoCancel.Location = new System.Drawing.Point(3, 64);
			pnlYesNoCancel.Name = "pnlYesNoCancel";
			pnlYesNoCancel.Size = new System.Drawing.Size(253, 32);
			pnlYesNoCancel.TabIndex = 1;
			pnlYesNoCancel.Visible = false;
			// 
			// btnNo1
			// 
			btnNo1.Location = new System.Drawing.Point(91, 4);
			btnNo1.Name = "btnNo1";
			btnNo1.Size = new System.Drawing.Size(75, 23);
			btnNo1.TabIndex = 2;
			btnNo1.Text = "&No";
			btnNo1.UseVisualStyleBackColor = true;
			btnNo1.Click += this.btnNo_Click;
			// 
			// btnCancel1
			// 
			btnCancel1.Location = new System.Drawing.Point(172, 4);
			btnCancel1.Name = "btnCancel1";
			btnCancel1.Size = new System.Drawing.Size(75, 23);
			btnCancel1.TabIndex = 1;
			btnCancel1.Text = "&Cancel";
			btnCancel1.UseVisualStyleBackColor = true;
			btnCancel1.Click += this.btnCancel_Click;
			// 
			// btnYes1
			// 
			btnYes1.Location = new System.Drawing.Point(10, 4);
			btnYes1.Name = "btnYes1";
			btnYes1.Size = new System.Drawing.Size(75, 23);
			btnYes1.TabIndex = 0;
			btnYes1.Text = "&Yes";
			btnYes1.UseVisualStyleBackColor = true;
			btnYes1.Click += this.btnYes_Click;
			// 
			// pnlYesNo
			// 
			pnlYesNo.Controls.Add(btnNo2);
			pnlYesNo.Controls.Add(btnYes2);
			pnlYesNo.Location = new System.Drawing.Point(3, 102);
			pnlYesNo.Name = "pnlYesNo";
			pnlYesNo.Size = new System.Drawing.Size(253, 32);
			pnlYesNo.TabIndex = 2;
			pnlYesNo.Visible = false;
			// 
			// btnNo2
			// 
			btnNo2.Location = new System.Drawing.Point(172, 4);
			btnNo2.Name = "btnNo2";
			btnNo2.Size = new System.Drawing.Size(75, 23);
			btnNo2.TabIndex = 2;
			btnNo2.Text = "&No";
			btnNo2.UseVisualStyleBackColor = true;
			btnNo2.Click += this.btnNo_Click;
			// 
			// btnYes2
			// 
			btnYes2.Location = new System.Drawing.Point(10, 4);
			btnYes2.Name = "btnYes2";
			btnYes2.Size = new System.Drawing.Size(75, 23);
			btnYes2.TabIndex = 0;
			btnYes2.Text = "&Yes";
			btnYes2.UseVisualStyleBackColor = true;
			btnYes2.Click += this.btnYes_Click;
			// 
			// pnlOkCancel
			// 
			pnlOkCancel.Controls.Add(btnCancel2);
			pnlOkCancel.Controls.Add(btnOk1);
			pnlOkCancel.Location = new System.Drawing.Point(3, 140);
			pnlOkCancel.Name = "pnlOkCancel";
			pnlOkCancel.Size = new System.Drawing.Size(253, 32);
			pnlOkCancel.TabIndex = 3;
			pnlOkCancel.Visible = false;
			// 
			// btnCancel2
			// 
			btnCancel2.Location = new System.Drawing.Point(172, 4);
			btnCancel2.Name = "btnCancel2";
			btnCancel2.Size = new System.Drawing.Size(75, 23);
			btnCancel2.TabIndex = 2;
			btnCancel2.Text = "&Cancel";
			btnCancel2.UseVisualStyleBackColor = true;
			btnCancel2.Click += this.btnCancel_Click;
			// 
			// btnOk1
			// 
			btnOk1.Location = new System.Drawing.Point(10, 4);
			btnOk1.Name = "btnOk1";
			btnOk1.Size = new System.Drawing.Size(75, 23);
			btnOk1.TabIndex = 0;
			btnOk1.Text = "&Ok";
			btnOk1.UseVisualStyleBackColor = true;
			btnOk1.Click += this.btnOk_Click;
			// 
			// pnlOk
			// 
			pnlOk.Controls.Add(btnOk2);
			pnlOk.Location = new System.Drawing.Point(3, 178);
			pnlOk.Name = "pnlOk";
			pnlOk.Size = new System.Drawing.Size(253, 32);
			pnlOk.TabIndex = 4;
			pnlOk.Visible = false;
			// 
			// btnOk2
			// 
			btnOk2.Location = new System.Drawing.Point(91, 4);
			btnOk2.Name = "btnOk2";
			btnOk2.Size = new System.Drawing.Size(75, 23);
			btnOk2.TabIndex = 0;
			btnOk2.Text = "&Ok";
			btnOk2.UseVisualStyleBackColor = true;
			btnOk2.Click += this.btnOk_Click;
			// 
			// txtInput
			// 
			txtInput.Location = new System.Drawing.Point(13, 28);
			txtInput.Name = "txtInput";
			txtInput.Size = new System.Drawing.Size(237, 23);
			txtInput.TabIndex = 0;
			txtInput.Visible = false;
			// 
			// frmMessage
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(269, 225);
			Controls.Add(txtInput);
			Controls.Add(pnlOk);
			Controls.Add(pnlOkCancel);
			Controls.Add(pnlYesNo);
			Controls.Add(pnlYesNoCancel);
			Controls.Add(lblMessage);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			Name = "frmMessage";
			Text = "Please Confirm";
			Activated += this.frmMessage_Activated;
			Load += this.frmMessage_Load;
			pnlYesNoCancel.ResumeLayout(false);
			pnlYesNo.ResumeLayout(false);
			pnlOkCancel.ResumeLayout(false);
			pnlOk.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.Panel pnlYesNoCancel;
		private System.Windows.Forms.Button btnNo1;
		private System.Windows.Forms.Button btnCancel1;
		private System.Windows.Forms.Button btnYes1;
		private System.Windows.Forms.Panel pnlYesNo;
		private System.Windows.Forms.Button btnNo2;
		private System.Windows.Forms.Button btnYes2;
		private System.Windows.Forms.Panel pnlOkCancel;
		private System.Windows.Forms.Button btnCancel2;
		private System.Windows.Forms.Button btnOk1;
		private System.Windows.Forms.Panel pnlOk;
		private System.Windows.Forms.Button btnOk2;
		private System.Windows.Forms.TextBox txtInput;
	}
}