using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace myJournal.subforms
{
	public partial class frmManageTags : Form
	{
		public frmManageTags()
		{
			InitializeComponent();
		}

		private void mnuAdd_Click(object sender, EventArgs e)
		{

		}

		private void mnuDelete_Click(object sender, EventArgs e)
		{

		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void mnuMoveUp_Click(object sender, EventArgs e)
		{

		}

		private void mnuMoveDown_Click(object sender, EventArgs e)
		{

		}

		private void mnuRename_Click(object sender, EventArgs e)
		{

		}

		private void PopulateLabels()
		{
			lstLabels.Items.Clear();

			foreach (string group in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/settings/groups"))
			{
				lstLabels.Items.Add(group);
			}
		}

		private void frmManageTags_Load(object sender, EventArgs e)
		{
			PopulateLabels();
		}

		private void lstLabels_SelectedIndexChanged(object sender, EventArgs e)
		{
			mnuRename.Enabled = true;
			mnuDelete.Enabled = true;
			mnuMoveTop.Enabled = true;
		}

		private void SaveLabels()
		{
			string[] tags = lstLabels.Items.OfType<string>().ToArray();
			StringBuilder sb = new StringBuilder();
			foreach (string s in tags) { sb.AppendLine(s); }
			File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/settings/groups", sb.ToString());
		}
	}
}
