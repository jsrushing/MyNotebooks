namespace MyNotebooks.subforms
{
	partial class frmAzurePwd
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
			btnEnterKey = new System.Windows.Forms.Button();
			txtEnterKey = new System.Windows.Forms.TextBox();
			btnCancel = new System.Windows.Forms.Button();
			lblError_EnterKey = new System.Windows.Forms.Label();
			pnlEnterKey = new System.Windows.Forms.Panel();
			pnlHaveKey = new System.Windows.Forms.Panel();
			btnHaveKeyNo = new System.Windows.Forms.Button();
			btnHaveKeyYes = new System.Windows.Forms.Button();
			pnlCreateKey = new System.Windows.Forms.Panel();
			txtCreateKey = new System.Windows.Forms.TextBox();
			btnCancel2 = new System.Windows.Forms.Button();
			btnCreateKey = new System.Windows.Forms.Button();
			lblError_CreateKey = new System.Windows.Forms.Label();
			pnlChangeKey = new System.Windows.Forms.Panel();
			txtChangeKey = new System.Windows.Forms.TextBox();
			btnCancelChange = new System.Windows.Forms.Button();
			btnChangeKey = new System.Windows.Forms.Button();
			pnlEnterKey.SuspendLayout();
			pnlHaveKey.SuspendLayout();
			pnlCreateKey.SuspendLayout();
			pnlChangeKey.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnEnterKey
			// 
			btnEnterKey.Enabled = false;
			btnEnterKey.Location = new System.Drawing.Point(3, 34);
			btnEnterKey.Name = "btnEnterKey";
			btnEnterKey.Size = new System.Drawing.Size(75, 23);
			btnEnterKey.TabIndex = 1;
			btnEnterKey.Text = "&Continue";
			btnEnterKey.UseVisualStyleBackColor = true;
			btnEnterKey.Click += this.btnEnterKey_Click;
			// 
			// txtEnterKey
			// 
			txtEnterKey.Location = new System.Drawing.Point(3, 5);
			txtEnterKey.Name = "txtEnterKey";
			txtEnterKey.Size = new System.Drawing.Size(155, 23);
			txtEnterKey.TabIndex = 0;
			txtEnterKey.TextChanged += this.txtPwd_TextChanged;
			// 
			// btnCancel
			// 
			btnCancel.Location = new System.Drawing.Point(83, 34);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "&Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += this.btnCancel_Click;
			// 
			// lblError_EnterKey
			// 
			lblError_EnterKey.AutoSize = true;
			lblError_EnterKey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			lblError_EnterKey.ForeColor = System.Drawing.Color.Red;
			lblError_EnterKey.Location = new System.Drawing.Point(39, 60);
			lblError_EnterKey.Name = "lblError_EnterKey";
			lblError_EnterKey.Size = new System.Drawing.Size(80, 13);
			lblError_EnterKey.TabIndex = 4;
			lblError_EnterKey.Text = "Key not found";
			lblError_EnterKey.Visible = false;
			// 
			// pnlEnterKey
			// 
			pnlEnterKey.Controls.Add(txtEnterKey);
			pnlEnterKey.Controls.Add(btnCancel);
			pnlEnterKey.Controls.Add(btnEnterKey);
			pnlEnterKey.Controls.Add(lblError_EnterKey);
			pnlEnterKey.Location = new System.Drawing.Point(22, 100);
			pnlEnterKey.Name = "pnlEnterKey";
			pnlEnterKey.Size = new System.Drawing.Size(164, 76);
			pnlEnterKey.TabIndex = 9;
			pnlEnterKey.Visible = false;
			// 
			// pnlHaveKey
			// 
			pnlHaveKey.Controls.Add(btnHaveKeyNo);
			pnlHaveKey.Controls.Add(btnHaveKeyYes);
			pnlHaveKey.Location = new System.Drawing.Point(22, 3);
			pnlHaveKey.Name = "pnlHaveKey";
			pnlHaveKey.Size = new System.Drawing.Size(164, 76);
			pnlHaveKey.TabIndex = 10;
			pnlHaveKey.Visible = false;
			// 
			// btnHaveKeyNo
			// 
			btnHaveKeyNo.Location = new System.Drawing.Point(83, 26);
			btnHaveKeyNo.Name = "btnHaveKeyNo";
			btnHaveKeyNo.Size = new System.Drawing.Size(75, 23);
			btnHaveKeyNo.TabIndex = 1;
			btnHaveKeyNo.Text = "&No";
			btnHaveKeyNo.UseVisualStyleBackColor = true;
			btnHaveKeyNo.Click += this.btnHaveKeyNo_Click;
			// 
			// btnHaveKeyYes
			// 
			btnHaveKeyYes.Location = new System.Drawing.Point(7, 26);
			btnHaveKeyYes.Name = "btnHaveKeyYes";
			btnHaveKeyYes.Size = new System.Drawing.Size(75, 23);
			btnHaveKeyYes.TabIndex = 0;
			btnHaveKeyYes.Text = "&Yes";
			btnHaveKeyYes.UseVisualStyleBackColor = true;
			btnHaveKeyYes.Click += this.btnHaveKeyYes_Click;
			// 
			// pnlCreateKey
			// 
			pnlCreateKey.Controls.Add(txtCreateKey);
			pnlCreateKey.Controls.Add(btnCancel2);
			pnlCreateKey.Controls.Add(btnCreateKey);
			pnlCreateKey.Controls.Add(lblError_CreateKey);
			pnlCreateKey.Location = new System.Drawing.Point(22, 195);
			pnlCreateKey.Name = "pnlCreateKey";
			pnlCreateKey.Size = new System.Drawing.Size(164, 76);
			pnlCreateKey.TabIndex = 10;
			pnlCreateKey.Visible = false;
			// 
			// txtCreateKey
			// 
			txtCreateKey.Location = new System.Drawing.Point(5, 5);
			txtCreateKey.Name = "txtCreateKey";
			txtCreateKey.Size = new System.Drawing.Size(155, 23);
			txtCreateKey.TabIndex = 5;
			txtCreateKey.TextChanged += this.txtPwd_TextChanged;
			// 
			// btnCancel2
			// 
			btnCancel2.Location = new System.Drawing.Point(85, 34);
			btnCancel2.Name = "btnCancel2";
			btnCancel2.Size = new System.Drawing.Size(75, 23);
			btnCancel2.TabIndex = 7;
			btnCancel2.Text = "&Cancel";
			btnCancel2.UseVisualStyleBackColor = true;
			btnCancel2.Click += this.btnCancel_Click;
			// 
			// btnCreateKey
			// 
			btnCreateKey.Enabled = false;
			btnCreateKey.Location = new System.Drawing.Point(5, 34);
			btnCreateKey.Name = "btnCreateKey";
			btnCreateKey.Size = new System.Drawing.Size(75, 23);
			btnCreateKey.TabIndex = 6;
			btnCreateKey.Text = "&Create Key";
			btnCreateKey.UseVisualStyleBackColor = true;
			btnCreateKey.Click += this.btnCreateKey_Click;
			// 
			// lblError_CreateKey
			// 
			lblError_CreateKey.AutoSize = true;
			lblError_CreateKey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			lblError_CreateKey.ForeColor = System.Drawing.Color.Red;
			lblError_CreateKey.Location = new System.Drawing.Point(43, 60);
			lblError_CreateKey.Name = "lblError_CreateKey";
			lblError_CreateKey.Size = new System.Drawing.Size(69, 13);
			lblError_CreateKey.TabIndex = 8;
			lblError_CreateKey.Text = "Key is in use";
			lblError_CreateKey.Visible = false;
			// 
			// pnlChangeKey
			// 
			pnlChangeKey.Controls.Add(txtChangeKey);
			pnlChangeKey.Controls.Add(btnCancelChange);
			pnlChangeKey.Controls.Add(btnChangeKey);
			pnlChangeKey.Location = new System.Drawing.Point(22, 295);
			pnlChangeKey.Name = "pnlChangeKey";
			pnlChangeKey.Size = new System.Drawing.Size(164, 76);
			pnlChangeKey.TabIndex = 11;
			pnlChangeKey.Visible = false;
			// 
			// txtChangeKey
			// 
			txtChangeKey.Location = new System.Drawing.Point(5, 5);
			txtChangeKey.Name = "txtChangeKey";
			txtChangeKey.Size = new System.Drawing.Size(155, 23);
			txtChangeKey.TabIndex = 5;
			txtChangeKey.TextChanged += this.txtPwd_TextChanged;
			// 
			// btnCancelChange
			// 
			btnCancelChange.Location = new System.Drawing.Point(85, 34);
			btnCancelChange.Name = "btnCancelChange";
			btnCancelChange.Size = new System.Drawing.Size(75, 23);
			btnCancelChange.TabIndex = 7;
			btnCancelChange.Text = "&Cancel";
			btnCancelChange.UseVisualStyleBackColor = true;
			btnCancelChange.Click += this.btnCancelChange_Click;
			// 
			// btnChangeKey
			// 
			btnChangeKey.Enabled = false;
			btnChangeKey.Location = new System.Drawing.Point(5, 34);
			btnChangeKey.Name = "btnChangeKey";
			btnChangeKey.Size = new System.Drawing.Size(75, 23);
			btnChangeKey.TabIndex = 6;
			btnChangeKey.Text = "&Change Key";
			btnChangeKey.UseVisualStyleBackColor = true;
			btnChangeKey.Click += this.btnChangeKey_Click;
			// 
			// frmAzurePwd
			// 
			AcceptButton = btnEnterKey;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(653, 670);
			Controls.Add(pnlChangeKey);
			Controls.Add(pnlHaveKey);
			Controls.Add(pnlCreateKey);
			Controls.Add(pnlEnterKey);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmAzurePwd";
			Text = "Do you have an Azure Key?";
			Load += this.frmAzurePwd_Load;
			pnlEnterKey.ResumeLayout(false);
			pnlEnterKey.PerformLayout();
			pnlHaveKey.ResumeLayout(false);
			pnlCreateKey.ResumeLayout(false);
			pnlCreateKey.PerformLayout();
			pnlChangeKey.ResumeLayout(false);
			pnlChangeKey.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Button btnEnterKey;
		private System.Windows.Forms.TextBox txtEnterKey;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblError_EnterKey;
		private System.Windows.Forms.Panel pnlEnterKey;
		private System.Windows.Forms.Panel pnlHaveKey;
		private System.Windows.Forms.Panel pnlCreateKey;
		private System.Windows.Forms.TextBox txtCreateKey;
		private System.Windows.Forms.Button btnCancel2;
		private System.Windows.Forms.Button btnCreateKey;
		private System.Windows.Forms.Label lblError_CreateKey;
		private System.Windows.Forms.Button btnHaveKeyYes;
		private System.Windows.Forms.Button btnHaveKeyNo;
		private System.Windows.Forms.Panel pnlChangeKey;
		private System.Windows.Forms.TextBox txtChangeKey;
		private System.Windows.Forms.Button btnCancelChange;
		private System.Windows.Forms.Button btnChangeKey;
	}
}