
namespace myJournal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblCreateEntry = new System.Windows.Forms.Label();
            this.lblFindEntry = new System.Windows.Forms.Label();
            this.grpCreateEntry = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rtbNewEntry = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAddEntry = new System.Windows.Forms.Label();
            this.grpOpenScreen = new System.Windows.Forms.GroupBox();
            this.grpFindEntry = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstEntries = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblEntriesStartFrom = new System.Windows.Forms.Label();
            this.lblSettings = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFindEntries = new System.Windows.Forms.Label();
            this.dtFindDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.grpCreateEntry.SuspendLayout();
            this.grpOpenScreen.SuspendLayout();
            this.grpFindEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Open Journal ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(93, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(209, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // lblCreateEntry
            // 
            this.lblCreateEntry.AutoSize = true;
            this.lblCreateEntry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblCreateEntry.Location = new System.Drawing.Point(6, 19);
            this.lblCreateEntry.Name = "lblCreateEntry";
            this.lblCreateEntry.Size = new System.Drawing.Size(98, 15);
            this.lblCreateEntry.TabIndex = 2;
            this.lblCreateEntry.Text = "Create New Entry";
            this.lblCreateEntry.Click += new System.EventHandler(this.lblCreateEntry_Click);
            // 
            // lblFindEntry
            // 
            this.lblFindEntry.AutoSize = true;
            this.lblFindEntry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblFindEntry.Location = new System.Drawing.Point(110, 19);
            this.lblFindEntry.Name = "lblFindEntry";
            this.lblFindEntry.Size = new System.Drawing.Size(60, 15);
            this.lblFindEntry.TabIndex = 3;
            this.lblFindEntry.Text = "Find Entry";
            this.lblFindEntry.Click += new System.EventHandler(this.lblFindEntry_Click);
            // 
            // grpCreateEntry
            // 
            this.grpCreateEntry.Controls.Add(this.lblAddEntry);
            this.grpCreateEntry.Controls.Add(this.label3);
            this.grpCreateEntry.Controls.Add(this.rtbNewEntry);
            this.grpCreateEntry.Controls.Add(this.textBox1);
            this.grpCreateEntry.Controls.Add(this.label2);
            this.grpCreateEntry.Location = new System.Drawing.Point(361, 65);
            this.grpCreateEntry.Name = "grpCreateEntry";
            this.grpCreateEntry.Size = new System.Drawing.Size(290, 545);
            this.grpCreateEntry.TabIndex = 4;
            this.grpCreateEntry.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Title ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(240, 23);
            this.textBox1.TabIndex = 1;
            // 
            // rtbNewEntry
            // 
            this.rtbNewEntry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.rtbNewEntry.Location = new System.Drawing.Point(6, 68);
            this.rtbNewEntry.Name = "rtbNewEntry";
            this.rtbNewEntry.Size = new System.Drawing.Size(278, 448);
            this.rtbNewEntry.TabIndex = 2;
            this.rtbNewEntry.Text = "Find";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Text";
            // 
            // lblAddEntry
            // 
            this.lblAddEntry.AutoSize = true;
            this.lblAddEntry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblAddEntry.Location = new System.Drawing.Point(105, 522);
            this.lblAddEntry.Name = "lblAddEntry";
            this.lblAddEntry.Size = new System.Drawing.Size(83, 15);
            this.lblAddEntry.TabIndex = 4;
            this.lblAddEntry.Text = "Add This Entry";
            this.lblAddEntry.Click += new System.EventHandler(this.lblAddEntry_Click);
            // 
            // grpOpenScreen
            // 
            this.grpOpenScreen.Controls.Add(this.lblSettings);
            this.grpOpenScreen.Controls.Add(this.lblEntriesStartFrom);
            this.grpOpenScreen.Controls.Add(this.richTextBox1);
            this.grpOpenScreen.Controls.Add(this.label5);
            this.grpOpenScreen.Controls.Add(this.lstEntries);
            this.grpOpenScreen.Controls.Add(this.label4);
            this.grpOpenScreen.Controls.Add(this.lblFindEntry);
            this.grpOpenScreen.Controls.Add(this.lblCreateEntry);
            this.grpOpenScreen.Location = new System.Drawing.Point(12, 35);
            this.grpOpenScreen.Name = "grpOpenScreen";
            this.grpOpenScreen.Size = new System.Drawing.Size(290, 545);
            this.grpOpenScreen.TabIndex = 5;
            this.grpOpenScreen.TabStop = false;
            // 
            // grpFindEntry
            // 
            this.grpFindEntry.Controls.Add(this.textBox3);
            this.grpFindEntry.Controls.Add(this.textBox2);
            this.grpFindEntry.Controls.Add(this.dateTimePicker2);
            this.grpFindEntry.Controls.Add(this.label12);
            this.grpFindEntry.Controls.Add(this.dateTimePicker1);
            this.grpFindEntry.Controls.Add(this.dtFindDate);
            this.grpFindEntry.Controls.Add(this.lblFindEntries);
            this.grpFindEntry.Controls.Add(this.richTextBox2);
            this.grpFindEntry.Controls.Add(this.label9);
            this.grpFindEntry.Controls.Add(this.label10);
            this.grpFindEntry.Controls.Add(this.label8);
            this.grpFindEntry.Controls.Add(this.listBox1);
            this.grpFindEntry.Controls.Add(this.label11);
            this.grpFindEntry.Controls.Add(this.label7);
            this.grpFindEntry.Controls.Add(this.label6);
            this.grpFindEntry.Location = new System.Drawing.Point(683, 65);
            this.grpFindEntry.Name = "grpFindEntry";
            this.grpFindEntry.Size = new System.Drawing.Size(290, 545);
            this.grpFindEntry.TabIndex = 6;
            this.grpFindEntry.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Entries";
            // 
            // lstEntries
            // 
            this.lstEntries.FormattingEnabled = true;
            this.lstEntries.ItemHeight = 15;
            this.lstEntries.Location = new System.Drawing.Point(6, 74);
            this.lstEntries.Name = "lstEntries";
            this.lstEntries.Size = new System.Drawing.Size(278, 154);
            this.lstEntries.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Entry";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 254);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(278, 278);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // lblEntriesStartFrom
            // 
            this.lblEntriesStartFrom.AutoSize = true;
            this.lblEntriesStartFrom.Location = new System.Drawing.Point(50, 55);
            this.lblEntriesStartFrom.Name = "lblEntriesStartFrom";
            this.lblEntriesStartFrom.Size = new System.Drawing.Size(108, 15);
            this.lblEntriesStartFrom.TabIndex = 10;
            this.lblEntriesStartFrom.Text = "(from 2 weeks ago)";
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblSettings.Location = new System.Drawing.Point(230, 55);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(49, 15);
            this.lblSettings.TabIndex = 11;
            this.lblSettings.Text = "Settings";
            this.lblSettings.Click += new System.EventHandler(this.lblSettings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(18, 621);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 545);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Date Range";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Title contains";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Entry contains";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(6, 360);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(278, 177);
            this.richTextBox2.TabIndex = 12;
            this.richTextBox2.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 342);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "Entry";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(6, 180);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(278, 154);
            this.listBox1.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 15);
            this.label11.TabIndex = 13;
            this.label11.Text = "Entries";
            // 
            // lblFindEntries
            // 
            this.lblFindEntries.AutoSize = true;
            this.lblFindEntries.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblFindEntries.Location = new System.Drawing.Point(104, 154);
            this.lblFindEntries.Name = "lblFindEntries";
            this.lblFindEntries.Size = new System.Drawing.Size(58, 15);
            this.lblFindEntries.TabIndex = 16;
            this.lblFindEntries.Text = "Find Now";
            // 
            // dtFindDate
            // 
            this.dtFindDate.Location = new System.Drawing.Point(43, 13);
            this.dtFindDate.Name = "dtFindDate";
            this.dtFindDate.ShowUpDown = true;
            this.dtFindDate.Size = new System.Drawing.Size(241, 23);
            this.dtFindDate.TabIndex = 17;
            this.dtFindDate.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 65);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 23);
            this.dateTimePicker1.TabIndex = 18;
            this.dateTimePicker1.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(131, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 15);
            this.label12.TabIndex = 19;
            this.label12.Text = "to";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(155, 65);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(120, 23);
            this.dateTimePicker2.TabIndex = 20;
            this.dateTimePicker2.Value = new System.DateTime(2021, 12, 23, 18, 55, 40, 0);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(85, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(199, 23);
            this.textBox2.TabIndex = 21;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(85, 125);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(199, 23);
            this.textBox3.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 875);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpOpenScreen);
            this.Controls.Add(this.grpCreateEntry);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpFindEntry);
            this.Name = "Form1";
            this.Text = "My Journals";
            this.grpCreateEntry.ResumeLayout(false);
            this.grpCreateEntry.PerformLayout();
            this.grpOpenScreen.ResumeLayout(false);
            this.grpOpenScreen.PerformLayout();
            this.grpFindEntry.ResumeLayout(false);
            this.grpFindEntry.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblCreateEntry;
        private System.Windows.Forms.Label lblFindEntry;
        private System.Windows.Forms.GroupBox grpCreateEntry;
        private System.Windows.Forms.Label lblAddEntry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbNewEntry;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpOpenScreen;
        private System.Windows.Forms.ListBox lstEntries;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpFindEntry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.Label lblEntriesStartFrom;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dtFindDate;
        private System.Windows.Forms.Label lblFindEntries;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

