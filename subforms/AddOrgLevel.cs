using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myNotebooks;
using myNotebooks.subforms;

namespace MyNotebooks.subforms
{
	public partial class AddOrgLevel : Form
	{
		private int CreatedBy;

		public AddOrgLevel(frmMain.OrgLevelTypes orgLevel, int creatorId)
		{
			InitializeComponent();
			this.Text += orgLevel.ToString();
			CreatedBy = creatorId;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (txtOrgLevelName.Text.Length > 0)
			{

			}
		}
	}
}
