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
using MyNotebooks.DataAccess;
using MyNotebooks.objects;

namespace MyNotebooks.subforms
{

	public partial class frmSearch_SelectOrgLevel : Form
	{
		public int SelectedOrgLevelId { get; set; }

		public frmSearch_SelectOrgLevel() { InitializeComponent(); }

		private void frmSearch_SelectOrgLevel_Load(object sender, EventArgs e)
		{ foreach (ListItem item in DbAccess.GetOrgLevels()) { ddlOrgLevels.Items.Add(item); } }

		private void ddlOrgLevels_SelectedIndexChanged(object sender, EventArgs e)
		{
			var v = ddlOrgLevels.SelectedItem as ListItem;
			SelectedOrgLevelId = Convert.ToInt32(v.Id.ToString());
			btnOk.Enabled = true;
		}

		private void btnOk_Click(object sender, EventArgs e) { this.Hide(); }
	}
}
