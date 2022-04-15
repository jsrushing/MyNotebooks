
namespace myJournal.subforms
{
	partial class frmLogin
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
			this.btnOk = new System.Windows.Forms.Button();
			this.txtPIN = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblError = new System.Windows.Forms.Label();
			this.grp1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.grp1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(33, 66);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "&OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// txtPIN
			// 
			this.txtPIN.Location = new System.Drawing.Point(20, 37);
			this.txtPIN.Name = "txtPIN";
			this.txtPIN.Size = new System.Drawing.Size(100, 23);
			this.txtPIN.TabIndex = 0;
			this.txtPIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(33, 95);
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
			this.lblError.ForeColor = System.Drawing.Color.Red;
			this.lblError.Location = new System.Drawing.Point(20, 126);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(0, 15);
			this.lblError.TabIndex = 4;
			// 
			// grp1
			// 
			this.grp1.Controls.Add(this.label2);
			this.grp1.Controls.Add(this.lblError);
			this.grp1.Controls.Add(this.txtPIN);
			this.grp1.Controls.Add(this.btnCancel);
			this.grp1.Controls.Add(this.btnOk);
			this.grp1.Location = new System.Drawing.Point(12, 12);
			this.grp1.Name = "grp1";
			this.grp1.Size = new System.Drawing.Size(143, 162);
			this.grp1.TabIndex = 6;
			this.grp1.TabStop = false;
			this.grp1.Text = "Login";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(57, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 15);
			this.label2.TabIndex = 7;
			this.label2.Text = "PIN";
			// 
			// frmLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(285, 271);
			this.Controls.Add(this.grp1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmLogin";
			this.Text = "frmLogin";
			this.Activated += new System.EventHandler(this.frmLogin_Activated);
			this.Load += new System.EventHandler(this.frmLogin_Load);
			this.grp1.ResumeLayout(false);
			this.grp1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.TextBox txtPIN;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblError;
		private System.Windows.Forms.GroupBox grp1;
		private System.Windows.Forms.Label label2;
	}
}