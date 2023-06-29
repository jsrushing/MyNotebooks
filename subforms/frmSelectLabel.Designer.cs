namespace myJournal.subforms
{
	partial class frmSelectLabel
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
			ddlLabels = new System.Windows.Forms.ComboBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ddlLabels
			// 
			ddlLabels.FormattingEnabled = true;
			ddlLabels.Location = new System.Drawing.Point(12, 12);
			ddlLabels.Name = "ddlLabels";
			ddlLabels.Size = new System.Drawing.Size(158, 23);
			ddlLabels.TabIndex = 0;
			// 
			// btnOK
			// 
			btnOK.Location = new System.Drawing.Point(20, 47);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(62, 23);
			btnOK.TabIndex = 1;
			btnOK.Text = "&OK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += this.btnOK_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new System.Drawing.Point(100, 47);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(62, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "&Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += this.btnCancel_Click;
			// 
			// frmSelectLabel
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(191, 82);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			Controls.Add(ddlLabels);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmSelectLabel";
			Text = "Select a Label";
			this.ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.ComboBox ddlLabels;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
	}
}