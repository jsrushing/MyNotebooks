namespace MyNotebooks.subforms
{
	partial class frmNotebooksToSearch
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotebooksToSearch));
			clbNotebooks = new System.Windows.Forms.CheckedListBox();
			btnOk = new System.Windows.Forms.Button();
			lblSelectAllOrNone = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// clbNotebooks
			// 
			clbNotebooks.FormattingEnabled = true;
			clbNotebooks.Location = new System.Drawing.Point(12, 18);
			clbNotebooks.Name = "clbNotebooks";
			clbNotebooks.Size = new System.Drawing.Size(232, 220);
			clbNotebooks.TabIndex = 0;
			clbNotebooks.SelectedIndexChanged += this.clbNotebooks_SelectedIndexChanged;
			// 
			// btnOk
			// 
			btnOk.Location = new System.Drawing.Point(91, 246);
			btnOk.Name = "btnOk";
			btnOk.Size = new System.Drawing.Size(75, 23);
			btnOk.TabIndex = 1;
			btnOk.Text = "&Ok";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += this.btnOk_Click;
			// 
			// lblSelectAllOrNone
			// 
			lblSelectAllOrNone.AutoSize = true;
			lblSelectAllOrNone.ForeColor = System.Drawing.SystemColors.Highlight;
			lblSelectAllOrNone.Location = new System.Drawing.Point(177, 3);
			lblSelectAllOrNone.Name = "lblSelectAllOrNone";
			lblSelectAllOrNone.Size = new System.Drawing.Size(52, 15);
			lblSelectAllOrNone.TabIndex = 2;
			lblSelectAllOrNone.Text = "select all";
			lblSelectAllOrNone.Click += this.lblSelectAll_Click;
			// 
			// frmNotebooksToSearch
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(256, 276);
			Controls.Add(lblSelectAllOrNone);
			Controls.Add(btnOk);
			Controls.Add(clbNotebooks);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Name = "frmNotebooksToSearch";
			Text = "Select Notebooks To Search";
			Load += this.frmNotebooksToSearch_Load;
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.CheckedListBox clbNotebooks;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblSelectAllOrNone;
	}
}