using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyNotebooks.objects;
using MyNotebooks.DataAccess;
using System.Diagnostics;

namespace MyNotebooks.subforms
{
	public partial class frmSearch_SelectOrgLevelItems : Form
	{
		private const int				MaxWidth = 254;
		private frmMain.OrgLevelTypes	OrgLevelType;
		public List<OrgLevel>			TopOrgLevels = new();
		private List<OrgLevel>			LocalTopOrgLevels = new();

		public frmSearch_SelectOrgLevelItems(frmMain.OrgLevelTypes orgLevelType, Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
			this.OrgLevelType = orgLevelType;
			//this.OrgLevelId = orgLevelId;
		}

		private void frmSearch_SelectOrgLevelItems_Load(object sender, EventArgs e)
		{
			this.Text = string.Format(this.Text, this.OrgLevelType.ToString() + "(s)");
			TopOrgLevels = DbAccess.GetOrgLevelItemsAvailableToUser(this.OrgLevelType);

			foreach (OrgLevel level in TopOrgLevels)
			{ clbOrgLevels.Items.Add(new ListItem() { Id = level.Id, Name = level.Name }, false); }
		}

		private void frmSearch_SelectOrgLevelItems_Resize(object sender, EventArgs e)
		{
			this.Width = MaxWidth;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			TopOrgLevels = LocalTopOrgLevels;
			this.Hide();
		}

		private void lblSelectAllOrNone_Click(object sender, EventArgs e)
		{
			bool b = lblSelectAllOrNone.Text == "select all";

			for (int i = 0; i < clbOrgLevels.Items.Count; i++) { clbOrgLevels.SetItemChecked(i, b); PopulateLocalCheckedItems(i); }
			lblSelectAllOrNone.Text = b ? "unselect all" : "select all";
		}

		private void clbOrgLevels_SelectedIndexChanged(object sender, EventArgs e)
		{
			PopulateLocalCheckedItems(clbOrgLevels.SelectedIndex);
		}

		private void PopulateLocalCheckedItems(int index)
		{
			if (clbOrgLevels.GetItemChecked(index)) 
			{ LocalTopOrgLevels.Add(TopOrgLevels[index]);  }
			else { LocalTopOrgLevels.Remove(TopOrgLevels[index]); }
		}
	}
}
