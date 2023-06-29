using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using myNotebooks.objects;

namespace myJournal.subforms
{
	public partial class frmSelectLabel : Form
	{
		public string SelectedLabel { get; private set; }
		public frmSelectLabel(Form parent)
		{
			InitializeComponent();
			ddlLabels.Items.AddRange(LabelsManager.GetLabels_NoFileDate());
			SelectedLabel = string.Empty;
			Utilities.SetStartPosition(this, parent);
		}

		private void btnOK_Click(object sender, EventArgs e) { SelectedLabel = ddlLabels.Text; this.Hide(); }

		private void btnCancel_Click(object sender, EventArgs e) { this.Hide(); }
	}
}
