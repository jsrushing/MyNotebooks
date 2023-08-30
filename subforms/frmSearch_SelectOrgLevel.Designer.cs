namespace MyNotebooks.subforms
{
	partial class frmSearch_SelectOrgLevel
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
			label1 = new System.Windows.Forms.Label();
			ddlOrgLevels = new System.Windows.Forms.ComboBox();
			btnOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(162, 15);
			label1.TabIndex = 0;
			label1.Text = "Select an Org Level to Search:";
			// 
			// ddlOrgLevels
			// 
			ddlOrgLevels.DisplayMember = "Name";
			ddlOrgLevels.FormattingEnabled = true;
			ddlOrgLevels.Location = new System.Drawing.Point(37, 27);
			ddlOrgLevels.Name = "ddlOrgLevels";
			ddlOrgLevels.Size = new System.Drawing.Size(121, 23);
			ddlOrgLevels.TabIndex = 1;
			ddlOrgLevels.ValueMember = "Id";
			ddlOrgLevels.SelectedIndexChanged += this.ddlOrgLevels_SelectedIndexChanged;
			// 
			// btnOk
			// 
			btnOk.Enabled = false;
			btnOk.Location = new System.Drawing.Point(60, 56);
			btnOk.Name = "btnOk";
			btnOk.Size = new System.Drawing.Size(75, 23);
			btnOk.TabIndex = 2;
			btnOk.Text = "&Ok";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += this.btnOk_Click;
			// 
			// frmSearch_SelectOrgLevel
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(195, 87);
			Controls.Add(btnOk);
			Controls.Add(ddlOrgLevels);
			Controls.Add(label1);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmSearch_SelectOrgLevel";
			Text = "Search";
			Load += this.frmSearch_SelectOrgLevel_Load;
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox ddlOrgLevels;
		private System.Windows.Forms.Button btnOk;
	}
}