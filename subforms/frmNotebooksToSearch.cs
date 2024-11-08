using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Azure;

namespace MyNotebooks.subforms
{
	public partial class frmNotebooksToSearch : Form
	{
		public List<string> Notebooks = new();

		public frmNotebooksToSearch()
		{
			InitializeComponent();
		}

		private void lblSelectAll_Click(object sender, EventArgs e)
		{
			bool b = lblSelectAllOrNone.Text == "select all";
			CheckUncheckAll(b);
			lblSelectAllOrNone.Text = b ? "unselect all" : "select all";
		}

		private void CheckUncheckAll(bool setChecked)
		{
			for (int i = 0; i < clbNotebooks.Items.Count; i++) { clbNotebooks.SetItemChecked(i, setChecked); }
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			foreach (var v in clbNotebooks.CheckedItems)
			{
				Notebooks.Add(v.ToString());
			}
			this.Hide();
		}

		private void frmNotebooksToSearch_Load(object sender, EventArgs e)
		{
			foreach (var v in Program.NotebooksNamesAndIds) { clbNotebooks.Items.Add(v.Key); }
		}

		private void clbNotebooks_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(clbNotebooks.SelectedIndex != -1)
			{
				clbNotebooks.SetItemChecked(clbNotebooks.SelectedIndex, !clbNotebooks.GetItemChecked(clbNotebooks.SelectedIndex));
			}
		}
	}
}
