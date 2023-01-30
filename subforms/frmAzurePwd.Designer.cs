namespace myJournal.subforms
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
			this.btnEnterKey = new System.Windows.Forms.Button();
			this.txtEnterKey = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblError_EnterKey = new System.Windows.Forms.Label();
			this.pnlEnterKey = new System.Windows.Forms.Panel();
			this.pnlHaveKey = new System.Windows.Forms.Panel();
			this.btnHaveKeyNo = new System.Windows.Forms.Button();
			this.btnHaveKeyYes = new System.Windows.Forms.Button();
			this.pnlCreateKey = new System.Windows.Forms.Panel();
			this.txtCreateKey = new System.Windows.Forms.TextBox();
			this.btnCancel2 = new System.Windows.Forms.Button();
			this.btnCreateKey = new System.Windows.Forms.Button();
			this.lblError_CreateKey = new System.Windows.Forms.Label();
			this.pnlEnterKey.SuspendLayout();
			this.pnlHaveKey.SuspendLayout();
			this.pnlCreateKey.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnEnterKey
			// 
			this.btnEnterKey.Enabled = false;
			this.btnEnterKey.Location = new System.Drawing.Point(3, 34);
			this.btnEnterKey.Name = "btnEnterKey";
			this.btnEnterKey.Size = new System.Drawing.Size(75, 23);
			this.btnEnterKey.TabIndex = 1;
			this.btnEnterKey.Text = "&Continue";
			this.btnEnterKey.UseVisualStyleBackColor = true;
			this.btnEnterKey.Click += new System.EventHandler(this.btnEnterKey_Click);
			// 
			// txtEnterKey
			// 
			this.txtEnterKey.Location = new System.Drawing.Point(3, 5);
			this.txtEnterKey.Name = "txtEnterKey";
			this.txtEnterKey.Size = new System.Drawing.Size(155, 23);
			this.txtEnterKey.TabIndex = 0;
			this.txtEnterKey.TextChanged += new System.EventHandler(this.txtPwd_TextChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(83, 34);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblError_EnterKey
			// 
			this.lblError_EnterKey.AutoSize = true;
			this.lblError_EnterKey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblError_EnterKey.ForeColor = System.Drawing.Color.Red;
			this.lblError_EnterKey.Location = new System.Drawing.Point(39, 60);
			this.lblError_EnterKey.Name = "lblError_EnterKey";
			this.lblError_EnterKey.Size = new System.Drawing.Size(80, 13);
			this.lblError_EnterKey.TabIndex = 4;
			this.lblError_EnterKey.Text = "Key not found";
			this.lblError_EnterKey.Visible = false;
			// 
			// pnlEnterKey
			// 
			this.pnlEnterKey.Controls.Add(this.txtEnterKey);
			this.pnlEnterKey.Controls.Add(this.btnCancel);
			this.pnlEnterKey.Controls.Add(this.btnEnterKey);
			this.pnlEnterKey.Controls.Add(this.lblError_EnterKey);
			this.pnlEnterKey.Location = new System.Drawing.Point(22, 100);
			this.pnlEnterKey.Name = "pnlEnterKey";
			this.pnlEnterKey.Size = new System.Drawing.Size(164, 76);
			this.pnlEnterKey.TabIndex = 9;
			this.pnlEnterKey.Visible = false;
			// 
			// pnlHaveKey
			// 
			this.pnlHaveKey.Controls.Add(this.btnHaveKeyNo);
			this.pnlHaveKey.Controls.Add(this.btnHaveKeyYes);
			this.pnlHaveKey.Location = new System.Drawing.Point(22, 3);
			this.pnlHaveKey.Name = "pnlHaveKey";
			this.pnlHaveKey.Size = new System.Drawing.Size(164, 76);
			this.pnlHaveKey.TabIndex = 10;
			// 
			// btnHaveKeyNo
			// 
			this.btnHaveKeyNo.Location = new System.Drawing.Point(83, 26);
			this.btnHaveKeyNo.Name = "btnHaveKeyNo";
			this.btnHaveKeyNo.Size = new System.Drawing.Size(75, 23);
			this.btnHaveKeyNo.TabIndex = 1;
			this.btnHaveKeyNo.Text = "&No";
			this.btnHaveKeyNo.UseVisualStyleBackColor = true;
			this.btnHaveKeyNo.Click += new System.EventHandler(this.btnHaveKeyNo_Click);
			// 
			// btnHaveKeyYes
			// 
			this.btnHaveKeyYes.Location = new System.Drawing.Point(7, 26);
			this.btnHaveKeyYes.Name = "btnHaveKeyYes";
			this.btnHaveKeyYes.Size = new System.Drawing.Size(75, 23);
			this.btnHaveKeyYes.TabIndex = 0;
			this.btnHaveKeyYes.Text = "&Yes";
			this.btnHaveKeyYes.UseVisualStyleBackColor = true;
			this.btnHaveKeyYes.Click += new System.EventHandler(this.btnHaveKeyYes_Click);
			// 
			// pnlCreateKey
			// 
			this.pnlCreateKey.Controls.Add(this.txtCreateKey);
			this.pnlCreateKey.Controls.Add(this.btnCancel2);
			this.pnlCreateKey.Controls.Add(this.btnCreateKey);
			this.pnlCreateKey.Controls.Add(this.lblError_CreateKey);
			this.pnlCreateKey.Location = new System.Drawing.Point(22, 195);
			this.pnlCreateKey.Name = "pnlCreateKey";
			this.pnlCreateKey.Size = new System.Drawing.Size(164, 76);
			this.pnlCreateKey.TabIndex = 10;
			this.pnlCreateKey.Visible = false;
			// 
			// txtCreateKey
			// 
			this.txtCreateKey.Location = new System.Drawing.Point(5, 5);
			this.txtCreateKey.Name = "txtCreateKey";
			this.txtCreateKey.Size = new System.Drawing.Size(155, 23);
			this.txtCreateKey.TabIndex = 5;
			this.txtCreateKey.TextChanged += new System.EventHandler(this.txtPwd_TextChanged);
			// 
			// btnCancel2
			// 
			this.btnCancel2.Location = new System.Drawing.Point(85, 34);
			this.btnCancel2.Name = "btnCancel2";
			this.btnCancel2.Size = new System.Drawing.Size(75, 23);
			this.btnCancel2.TabIndex = 7;
			this.btnCancel2.Text = "&Cancel";
			this.btnCancel2.UseVisualStyleBackColor = true;
			this.btnCancel2.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnCreateKey
			// 
			this.btnCreateKey.Enabled = false;
			this.btnCreateKey.Location = new System.Drawing.Point(5, 34);
			this.btnCreateKey.Name = "btnCreateKey";
			this.btnCreateKey.Size = new System.Drawing.Size(75, 23);
			this.btnCreateKey.TabIndex = 6;
			this.btnCreateKey.Text = "&Create Key";
			this.btnCreateKey.UseVisualStyleBackColor = true;
			this.btnCreateKey.Click += new System.EventHandler(this.btnCreateKey_Click);
			// 
			// lblError_CreateKey
			// 
			this.lblError_CreateKey.AutoSize = true;
			this.lblError_CreateKey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblError_CreateKey.ForeColor = System.Drawing.Color.Red;
			this.lblError_CreateKey.Location = new System.Drawing.Point(43, 60);
			this.lblError_CreateKey.Name = "lblError_CreateKey";
			this.lblError_CreateKey.Size = new System.Drawing.Size(69, 13);
			this.lblError_CreateKey.TabIndex = 8;
			this.lblError_CreateKey.Text = "Key is in use";
			this.lblError_CreateKey.Visible = false;
			// 
			// frmAzurePwd
			// 
			this.AcceptButton = this.btnEnterKey;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(210, 283);
			this.Controls.Add(this.pnlHaveKey);
			this.Controls.Add(this.pnlCreateKey);
			this.Controls.Add(this.pnlEnterKey);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAzurePwd";
			this.Text = "Do you have an Azure Key?";
			this.pnlEnterKey.ResumeLayout(false);
			this.pnlEnterKey.PerformLayout();
			this.pnlHaveKey.ResumeLayout(false);
			this.pnlCreateKey.ResumeLayout(false);
			this.pnlCreateKey.PerformLayout();
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
	}
}