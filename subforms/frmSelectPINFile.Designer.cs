namespace myJournal.subforms
{
	partial class frmSelectPINFile
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
			btnOK = new System.Windows.Forms.Button();
			lstLocalFileNames = new System.Windows.Forms.ListBox();
			btnCancel = new System.Windows.Forms.Button();
			lstAzureFileNames = new System.Windows.Forms.ListBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			txtPIN = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			lblShowPIN = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			btnOK.Location = new System.Drawing.Point(135, 278);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(51, 23);
			btnOK.TabIndex = 0;
			btnOK.Text = "&OK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += this.btnOK_Click;
			// 
			// lstLocalFileNames
			// 
			lstLocalFileNames.FormattingEnabled = true;
			lstLocalFileNames.ItemHeight = 15;
			lstLocalFileNames.Location = new System.Drawing.Point(12, 27);
			lstLocalFileNames.Name = "lstLocalFileNames";
			lstLocalFileNames.Size = new System.Drawing.Size(109, 229);
			lstLocalFileNames.TabIndex = 1;
			lstLocalFileNames.SelectedIndexChanged += this.LstClicks;
			// 
			// btnCancel
			// 
			btnCancel.Location = new System.Drawing.Point(194, 278);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(51, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "&Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += this.btnCancel_Click;
			// 
			// lstAzureFileNames
			// 
			lstAzureFileNames.FormattingEnabled = true;
			lstAzureFileNames.ItemHeight = 15;
			lstAzureFileNames.Location = new System.Drawing.Point(136, 27);
			lstAzureFileNames.Name = "lstAzureFileNames";
			lstAzureFileNames.Size = new System.Drawing.Size(109, 229);
			lstAzureFileNames.TabIndex = 3;
			lstAzureFileNames.SelectedIndexChanged += this.LstClicks;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(61, 15);
			label1.TabIndex = 4;
			label1.Text = "Local Files";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(136, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(65, 15);
			label2.TabIndex = 5;
			label2.Text = "Cloud Files";
			// 
			// txtPIN
			// 
			txtPIN.Location = new System.Drawing.Point(12, 279);
			txtPIN.Name = "txtPIN";
			txtPIN.PasswordChar = '*';
			txtPIN.Size = new System.Drawing.Size(104, 23);
			txtPIN.TabIndex = 6;
			txtPIN.TextChanged += this.textBox1_TextChanged;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(12, 262);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(47, 15);
			label3.TabIndex = 7;
			label3.Text = "File PIN";
			// 
			// lblShowPIN
			// 
			lblShowPIN.AutoSize = true;
			lblShowPIN.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			lblShowPIN.Location = new System.Drawing.Point(78, 264);
			lblShowPIN.Name = "lblShowPIN";
			lblShowPIN.Size = new System.Drawing.Size(35, 13);
			lblShowPIN.TabIndex = 8;
			lblShowPIN.Text = "show";
			lblShowPIN.Visible = false;
			lblShowPIN.Click += this.lblShowPIN_Click;
			// 
			// frmSelectPINFile
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new System.Drawing.Size(255, 313);
			Controls.Add(lblShowPIN);
			Controls.Add(label3);
			Controls.Add(txtPIN);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(lstAzureFileNames);
			Controls.Add(btnCancel);
			Controls.Add(lstLocalFileNames);
			Controls.Add(btnOK);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmSelectPINFile";
			Text = "Select a PIN File";
			Load += this.frmSelectPINFile_Load;
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ListBox lstLocalFileNames;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ListBox lstAzureFileNames;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPIN;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblShowPIN;
	}
}