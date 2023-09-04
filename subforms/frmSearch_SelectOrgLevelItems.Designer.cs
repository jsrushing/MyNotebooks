namespace MyNotebooks.subforms
{
	partial class frmSearch_SelectOrgLevelItems
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
			btnOk = new System.Windows.Forms.Button();
			clbOrgLevels = new System.Windows.Forms.CheckedListBox();
			lblSelectAllOrNone = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnOk.Location = new System.Drawing.Point(80, 477);
			btnOk.Name = "btnOk";
			btnOk.Size = new System.Drawing.Size(75, 23);
			btnOk.TabIndex = 2;
			btnOk.Text = "&Ok";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += this.btnOk_Click;
			// 
			// clbOrgLevels
			// 
			clbOrgLevels.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			clbOrgLevels.CheckOnClick = true;
			clbOrgLevels.FormattingEnabled = true;
			clbOrgLevels.Location = new System.Drawing.Point(12, 23);
			clbOrgLevels.Name = "clbOrgLevels";
			clbOrgLevels.Size = new System.Drawing.Size(210, 436);
			clbOrgLevels.TabIndex = 3;
			clbOrgLevels.SelectedIndexChanged += this.clbOrgLevels_SelectedIndexChanged;
			// 
			// lblSelectAllOrNone
			// 
			lblSelectAllOrNone.ForeColor = System.Drawing.SystemColors.Highlight;
			lblSelectAllOrNone.Location = new System.Drawing.Point(145, 4);
			lblSelectAllOrNone.Name = "lblSelectAllOrNone";
			lblSelectAllOrNone.Size = new System.Drawing.Size(77, 16);
			lblSelectAllOrNone.TabIndex = 4;
			lblSelectAllOrNone.Text = "select all";
			lblSelectAllOrNone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lblSelectAllOrNone.Click += this.lblSelectAllOrNone_Click;
			// 
			// frmSearch_SelectOrgLevelItems
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(238, 513);
			Controls.Add(lblSelectAllOrNone);
			Controls.Add(clbOrgLevels);
			Controls.Add(btnOk);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmSearch_SelectOrgLevelItems";
			Text = "Select {0} to search";
			Load += this.frmSearch_SelectOrgLevelItems_Load;
			Resize += this.frmSearch_SelectOrgLevelItems_Resize;
			this.ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.CheckedListBox clbOrgLevels;
		private System.Windows.Forms.Label lblSelectAllOrNone;
	}
}