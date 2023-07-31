namespace MyNotebooks.subforms
{
	partial class AddOrgLevel
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
			txtOrgLevelName = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			txtOrgLevelDescription = new System.Windows.Forms.TextBox();
			btnOk = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtOrgLevelName
			// 
			txtOrgLevelName.Location = new System.Drawing.Point(56, 12);
			txtOrgLevelName.MaxLength = 50;
			txtOrgLevelName.Name = "txtOrgLevelName";
			txtOrgLevelName.Size = new System.Drawing.Size(132, 23);
			txtOrgLevelName.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 15);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(42, 15);
			label1.TabIndex = 1;
			label1.Text = "Name:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(12, 39);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(70, 15);
			label2.TabIndex = 2;
			label2.Text = "Description:";
			// 
			// txtOrgLevelDescription
			// 
			txtOrgLevelDescription.Location = new System.Drawing.Point(12, 57);
			txtOrgLevelDescription.MaxLength = 200;
			txtOrgLevelDescription.Multiline = true;
			txtOrgLevelDescription.Name = "txtOrgLevelDescription";
			txtOrgLevelDescription.Size = new System.Drawing.Size(176, 58);
			txtOrgLevelDescription.TabIndex = 3;
			// 
			// btnOk
			// 
			btnOk.Location = new System.Drawing.Point(12, 121);
			btnOk.Name = "btnOk";
			btnOk.Size = new System.Drawing.Size(75, 23);
			btnOk.TabIndex = 4;
			btnOk.Text = "&Ok";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += this.btnOk_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new System.Drawing.Point(113, 121);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 5;
			btnCancel.Text = "&Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += this.btnCancel_Click;
			// 
			// AddOrgLevel
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(203, 155);
			Controls.Add(btnCancel);
			Controls.Add(btnOk);
			Controls.Add(txtOrgLevelDescription);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(txtOrgLevelName);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "AddOrgLevel";
			Text = "Add ";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.TextBox txtOrgLevelName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtOrgLevelDescription;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
	}
}