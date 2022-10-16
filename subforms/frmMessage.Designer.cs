
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
			this.lblMessage = new System.Windows.Forms.Label();
			this.pnlYesNoCancel = new System.Windows.Forms.Panel();
			this.btnNo1 = new System.Windows.Forms.Button();
			this.btnCancel1 = new System.Windows.Forms.Button();
			this.btnYes1 = new System.Windows.Forms.Button();
			this.pnlYesNo = new System.Windows.Forms.Panel();
			this.btnNo2 = new System.Windows.Forms.Button();
			this.btnYes2 = new System.Windows.Forms.Button();
			this.pnlOkCancel = new System.Windows.Forms.Panel();
			this.btnCancel2 = new System.Windows.Forms.Button();
			this.btnOk1 = new System.Windows.Forms.Button();
			this.pnlOk = new System.Windows.Forms.Panel();
			this.btnOk2 = new System.Windows.Forms.Button();
			this.pnlTextBox = new System.Windows.Forms.Panel();
			this.txtInput = new System.Windows.Forms.TextBox();
			this.pnlYesNoCancel.SuspendLayout();
			this.pnlYesNo.SuspendLayout();
			this.pnlOkCancel.SuspendLayout();
			this.pnlOk.SuspendLayout();
			this.pnlTextBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblMessage
			// 
			this.lblMessage.AutoSize = true;
			this.lblMessage.Location = new System.Drawing.Point(5, 9);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(164, 15);
			this.lblMessage.TabIndex = 0;
			this.lblMessage.Text = "Delete entry \'this is the entry\'?";
			// 
			// pnlYesNoCancel
			// 
			this.pnlYesNoCancel.Controls.Add(this.btnNo1);
			this.pnlYesNoCancel.Controls.Add(this.btnCancel1);
			this.pnlYesNoCancel.Controls.Add(this.btnYes1);
			this.pnlYesNoCancel.Location = new System.Drawing.Point(3, 31);
			this.pnlYesNoCancel.Name = "pnlYesNoCancel";
			this.pnlYesNoCancel.Size = new System.Drawing.Size(253, 32);
			this.pnlYesNoCancel.TabIndex = 1;
			this.pnlYesNoCancel.Visible = false;
			// 
			// btnNo1
			// 
			this.btnNo1.Location = new System.Drawing.Point(91, 4);
			this.btnNo1.Name = "btnNo1";
			this.btnNo1.Size = new System.Drawing.Size(75, 23);
			this.btnNo1.TabIndex = 2;
			this.btnNo1.Text = "&No";
			this.btnNo1.UseVisualStyleBackColor = true;
			this.btnNo1.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// btnCancel1
			// 
			this.btnCancel1.Location = new System.Drawing.Point(172, 4);
			this.btnCancel1.Name = "btnCancel1";
			this.btnCancel1.Size = new System.Drawing.Size(75, 23);
			this.btnCancel1.TabIndex = 1;
			this.btnCancel1.Text = "&Cancel";
			this.btnCancel1.UseVisualStyleBackColor = true;
			this.btnCancel1.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnYes1
			// 
			this.btnYes1.Location = new System.Drawing.Point(10, 4);
			this.btnYes1.Name = "btnYes1";
			this.btnYes1.Size = new System.Drawing.Size(75, 23);
			this.btnYes1.TabIndex = 0;
			this.btnYes1.Text = "&Yes";
			this.btnYes1.UseVisualStyleBackColor = true;
			this.btnYes1.Click += new System.EventHandler(this.btnYes_Click);
			// 
			// pnlYesNo
			// 
			this.pnlYesNo.Controls.Add(this.btnNo2);
			this.pnlYesNo.Controls.Add(this.btnYes2);
			this.pnlYesNo.Location = new System.Drawing.Point(3, 69);
			this.pnlYesNo.Name = "pnlYesNo";
			this.pnlYesNo.Size = new System.Drawing.Size(253, 32);
			this.pnlYesNo.TabIndex = 2;
			this.pnlYesNo.Visible = false;
			// 
			// btnNo2
			// 
			this.btnNo2.Location = new System.Drawing.Point(172, 4);
			this.btnNo2.Name = "btnNo2";
			this.btnNo2.Size = new System.Drawing.Size(75, 23);
			this.btnNo2.TabIndex = 2;
			this.btnNo2.Text = "&No";
			this.btnNo2.UseVisualStyleBackColor = true;
			this.btnNo2.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// btnYes2
			// 
			this.btnYes2.Location = new System.Drawing.Point(10, 4);
			this.btnYes2.Name = "btnYes2";
			this.btnYes2.Size = new System.Drawing.Size(75, 23);
			this.btnYes2.TabIndex = 0;
			this.btnYes2.Text = "&Yes";
			this.btnYes2.UseVisualStyleBackColor = true;
			this.btnYes2.Click += new System.EventHandler(this.btnYes_Click);
			// 
			// pnlOkCancel
			// 
			this.pnlOkCancel.Controls.Add(this.btnCancel2);
			this.pnlOkCancel.Controls.Add(this.btnOk1);
			this.pnlOkCancel.Location = new System.Drawing.Point(3, 107);
			this.pnlOkCancel.Name = "pnlOkCancel";
			this.pnlOkCancel.Size = new System.Drawing.Size(253, 32);
			this.pnlOkCancel.TabIndex = 3;
			this.pnlOkCancel.Visible = false;
			// 
			// btnCancel2
			// 
			this.btnCancel2.Location = new System.Drawing.Point(172, 4);
			this.btnCancel2.Name = "btnCancel2";
			this.btnCancel2.Size = new System.Drawing.Size(75, 23);
			this.btnCancel2.TabIndex = 2;
			this.btnCancel2.Text = "&Cancel";
			this.btnCancel2.UseVisualStyleBackColor = true;
			this.btnCancel2.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk1
			// 
			this.btnOk1.Location = new System.Drawing.Point(10, 4);
			this.btnOk1.Name = "btnOk1";
			this.btnOk1.Size = new System.Drawing.Size(75, 23);
			this.btnOk1.TabIndex = 0;
			this.btnOk1.Text = "&Ok";
			this.btnOk1.UseVisualStyleBackColor = true;
			this.btnOk1.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// pnlOk
			// 
			this.pnlOk.Controls.Add(this.btnOk2);
			this.pnlOk.Location = new System.Drawing.Point(3, 145);
			this.pnlOk.Name = "pnlOk";
			this.pnlOk.Size = new System.Drawing.Size(253, 32);
			this.pnlOk.TabIndex = 4;
			this.pnlOk.Visible = false;
			// 
			// btnOk2
			// 
			this.btnOk2.Location = new System.Drawing.Point(91, 4);
			this.btnOk2.Name = "btnOk2";
			this.btnOk2.Size = new System.Drawing.Size(75, 23);
			this.btnOk2.TabIndex = 0;
			this.btnOk2.Text = "&Ok";
			this.btnOk2.UseVisualStyleBackColor = true;
			this.btnOk2.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// pnlTextBox
			// 
			this.pnlTextBox.Controls.Add(this.txtInput);
			this.pnlTextBox.Location = new System.Drawing.Point(5, 184);
			this.pnlTextBox.Name = "pnlTextBox";
			this.pnlTextBox.Size = new System.Drawing.Size(253, 32);
			this.pnlTextBox.TabIndex = 5;
			this.pnlTextBox.Visible = false;
			// 
			// txtInput
			// 
			this.txtInput.Location = new System.Drawing.Point(8, 5);
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(237, 23);
			this.txtInput.TabIndex = 0;
			// 
			// frmMessage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(289, 379);
			this.Controls.Add(this.pnlTextBox);
			this.Controls.Add(this.pnlOk);
			this.Controls.Add(this.pnlOkCancel);
			this.Controls.Add(this.pnlYesNo);
			this.Controls.Add(this.pnlYesNoCancel);
			this.Controls.Add(this.lblMessage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmMessage";
			this.Text = "Please Confirm";
			this.Activated += new System.EventHandler(this.frmMessage_Activated);
			this.Load += new System.EventHandler(this.frmMessage_Load);
			this.pnlYesNoCancel.ResumeLayout(false);
			this.pnlYesNo.ResumeLayout(false);
			this.pnlOkCancel.ResumeLayout(false);
			this.pnlOk.ResumeLayout(false);
			this.pnlTextBox.ResumeLayout(false);
			this.pnlTextBox.PerformLayout();
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
		private System.Windows.Forms.Panel pnlTextBox;
		private System.Windows.Forms.TextBox txtInput;
	}
}