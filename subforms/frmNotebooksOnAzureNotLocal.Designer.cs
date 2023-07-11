namespace myJournal.subforms
{
	partial class frmNotebooksInCloudNotLocal
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
			clbAzureItems = new System.Windows.Forms.CheckedListBox();
			btnDownloadSelected = new System.Windows.Forms.Button();
			btnIgnoreSelected = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			btnAddPIN = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// clbAzureItems
			// 
			clbAzureItems.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			clbAzureItems.FormattingEnabled = true;
			clbAzureItems.Location = new System.Drawing.Point(12, 117);
			clbAzureItems.Name = "clbAzureItems";
			clbAzureItems.Size = new System.Drawing.Size(223, 346);
			clbAzureItems.TabIndex = 0;
			// 
			// btnDownloadSelected
			// 
			btnDownloadSelected.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnDownloadSelected.Location = new System.Drawing.Point(27, 469);
			btnDownloadSelected.Name = "btnDownloadSelected";
			btnDownloadSelected.Size = new System.Drawing.Size(75, 23);
			btnDownloadSelected.TabIndex = 1;
			btnDownloadSelected.Text = "&Download";
			btnDownloadSelected.UseVisualStyleBackColor = true;
			// 
			// btnIgnoreSelected
			// 
			btnIgnoreSelected.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnIgnoreSelected.Location = new System.Drawing.Point(145, 469);
			btnIgnoreSelected.Name = "btnIgnoreSelected";
			btnIgnoreSelected.Size = new System.Drawing.Size(75, 23);
			btnIgnoreSelected.TabIndex = 2;
			btnIgnoreSelected.Text = "&Ignore";
			btnIgnoreSelected.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(223, 51);
			label1.TabIndex = 3;
			label1.Text = "These Notebooks were found in the cloud but do not exist locally.";
			// 
			// textBox1
			// 
			textBox1.Location = new System.Drawing.Point(12, 89);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(100, 23);
			textBox1.TabIndex = 4;
			// 
			// btnAddPIN
			// 
			btnAddPIN.Location = new System.Drawing.Point(118, 88);
			btnAddPIN.Name = "btnAddPIN";
			btnAddPIN.Size = new System.Drawing.Size(75, 23);
			btnAddPIN.TabIndex = 5;
			btnAddPIN.Text = "Add &PIN";
			btnAddPIN.UseVisualStyleBackColor = true;
			// 
			// frmNotebooksInCloudNotLocal
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(246, 482);
			Controls.Add(btnAddPIN);
			Controls.Add(textBox1);
			Controls.Add(label1);
			Controls.Add(btnIgnoreSelected);
			Controls.Add(btnDownloadSelected);
			Controls.Add(clbAzureItems);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(262, 521);
			Name = "frmNotebooksInCloudNotLocal";
			Text = "Cloud Notebooks";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.CheckedListBox clbAzureItems;
		private System.Windows.Forms.Button btnDownloadSelected;
		private System.Windows.Forms.Button btnIgnoreSelected;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnAddPIN;
	}
}