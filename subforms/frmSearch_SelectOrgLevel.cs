using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
		//public int SelectedOrgLevelId { get; set; }
		public frmMain.OrgLevelTypes SelectedOrgLevelType { get; set; }

		public frmSearch_SelectOrgLevel(Form parent) 
		{ 
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
		}

		private void frmSearch_SelectOrgLevel_Load(object sender, EventArgs e)
		{
			if(Program.User.AccessLevel >= 1) { ddlOrgLevels.Items.Add("Group"); }
			if (Program.User.AccessLevel >= 2) { ddlOrgLevels.Items.Add("Department"); }
			if (Program.User.AccessLevel >= 3) { ddlOrgLevels.Items.Add("Account"); }
			if (Program.User.AccessLevel >= 4) { ddlOrgLevels.Items.Add("Company"); }
		}

		private void ddlOrgLevels_SelectedIndexChanged(object sender, EventArgs e)
		{
			var v = ddlOrgLevels.SelectedItem as ListItem;
			//SelectedOrgLevelId = Convert.ToInt32(v.Id.ToString());
			SelectedOrgLevelType = (frmMain.OrgLevelTypes)Enum.Parse(typeof(frmMain.OrgLevelTypes), ddlOrgLevels.Text);
			btnOk.Enabled = true;
		}

		private void btnOk_Click(object sender, EventArgs e) { this.Hide(); }
	}
}
