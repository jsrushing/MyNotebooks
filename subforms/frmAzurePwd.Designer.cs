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
			this.btnContinue = new System.Windows.Forms.Button();
			this.txtPwd = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblError = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnContinue
			// 
			this.btnContinue.Location = new System.Drawing.Point(12, 33);
			this.btnContinue.Name = "btnContinue";
			this.btnContinue.Size = new System.Drawing.Size(75, 23);
			this.btnContinue.TabIndex = 1;
			this.btnContinue.Text = "&Continue";
			this.btnContinue.UseVisualStyleBackColor = true;
			this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
			// 
			// txtPwd
			// 
			this.txtPwd.Location = new System.Drawing.Point(12, 4);
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.Size = new System.Drawing.Size(155, 23);
			this.txtPwd.TabIndex = 0;
			this.txtPwd.TextChanged += new System.EventHandler(this.txtPwd_TextChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(92, 33);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblError
			// 
			this.lblError.AutoSize = true;
			this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblError.ForeColor = System.Drawing.Color.Red;
			this.lblError.Location = new System.Drawing.Point(32, 58);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(115, 13);
			this.lblError.TabIndex = 4;
			this.lblError.Text = "Password not found!";
			this.lblError.Visible = false;
			// 
			// frmAzurePwd
			// 
			this.AcceptButton = this.btnContinue;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(184, 74);
			this.Controls.Add(this.lblError);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtPwd);
			this.Controls.Add(this.btnContinue);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAzurePwd";
			this.Text = "Create Azure Password";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnContinue;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblError;
	}
}