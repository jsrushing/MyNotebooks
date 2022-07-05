/* Manage labels.
 * 7/9/22
 */
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using myJournal.objects;

namespace myJournal.subforms
{
	public partial class frmManageLabels : Form
	{
		private bool Renaming = false;
		private bool Adding = false;
		private bool Deleting = false;

		public frmManageLabels()
		{
			InitializeComponent();
		}

		private void frmManageLabels_Load(object sender, EventArgs e)
		{
			Utilities.PopulateLabelsList(null, lstLabels);
			pnlNewLabelName.Location = new Point(0, 0);
			pnlNewLabelName.Size = this.Size;
		}

		private void mnuAdd_Click(object sender, EventArgs e)
		{
			Adding = true;
			lblOperation.Text = "Label Name:";
			pnlNewLabelName.Visible = true;
			txtLabelName.Focus();
		}

		private void mnuDelete_Click(object sender, EventArgs e)
		{
			Deleting = true;
			lblOperation.Text = "Delete Label? ";
			pnlNewLabelName.Visible = true;
			txtLabelName.Text = lstLabels.SelectedItem.ToString();
			txtLabelName.Enabled = false;
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void mnuMoveUp_Click(object sender, EventArgs e)
		{
			string sLbl = lstLabels.SelectedItem.ToString();
			int selIndx = lstLabels.SelectedIndex;
			lstLabels.Items.RemoveAt(selIndx);
			lstLabels.Items.Insert(selIndx - 1, sLbl);
			lstLabels.SelectedIndex = selIndx - 1;
		}

		private void mnuMoveDown_Click(object sender, EventArgs e)
		{
			string sLbl = lstLabels.SelectedItem.ToString();
			int selIndx = lstLabels.SelectedIndex;
			lstLabels.Items.RemoveAt(selIndx);
			lstLabels.Items.Insert(selIndx + 1, sLbl);
			lstLabels.SelectedIndex = selIndx + 1;
		}

		private void mnuRename_Click(object sender, EventArgs e)
		{
			Renaming = true;
			lblOperation.Text = "Label Name:";
			txtLabelName.Text = lstLabels.SelectedItem.ToString();
			pnlNewLabelName.Visible = true;
			txtLabelName.Focus();
			txtLabelName.SelectAll();
		}

		private void lstLabels_SelectedIndexChanged(object sender, EventArgs e)
		{
			mnuRename.Enabled = true;
			mnuDelete.Enabled = true;
			mnuMoveTop.Enabled = true;
			mnuMoveUp.Enabled = lstLabels.SelectedIndex > 0;
			mnuMoveDown.Enabled = lstLabels.SelectedIndex != lstLabels.Items.Count - 1;
		}

		private void SaveLabels()
		{
			string[] tags = lstLabels.Items.OfType<string>().ToArray();
			StringBuilder sb = new StringBuilder();
			foreach (string s in tags) { sb.AppendLine(s); }
			File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/settings/groups", sb.ToString());
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			pnlNewLabelName.Visible = false;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (Adding)
			{
				if(txtLabelName.Text.Length > 0)
				{
					lstLabels.Items.Add(txtLabelName.Text);
				}
				Adding = false;
			}

			if (Renaming)
			{
				lstLabels.Items.Insert(lstLabels.SelectedIndex, txtLabelName.Text);
				lstLabels.Items.RemoveAt(lstLabels.SelectedIndex);
				Renaming = false;
			}

			if (Deleting)
			{
				lstLabels.Items.RemoveAt(lstLabels.SelectedIndex);
				Deleting = false;
			}

			SaveLabels();
			txtLabelName.Enabled = true;
			txtLabelName.Text = string.Empty;
			pnlNewLabelName.Visible = false;
		}
	}
}
