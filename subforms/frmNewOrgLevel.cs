using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myNotebooks.objects;
using MyNotebooks.objects;

namespace MyNotebooks.subforms
{
	public partial class frmNewOrgLevel : Form
	{
		private ItemType type = ItemType.Group;
		private int CreatorId;

		public enum ItemType
		{
			Company,
			Account,
			Department,
			Group
		}
		public frmNewOrgLevel(Form parent, ItemType itemType, MNUser user)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
			this.type = itemType;
			this.Text = "Create New " + itemType.ToString();
			this.CreatorId = user.UserId;
		}

		private void frmNewOrgLevel_Load(object sender, EventArgs e)
		{

		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			switch (type)
			{
				case ItemType.Company:

					break;
				case ItemType.Account:
					break;
				case ItemType.Department:
					break;
				case ItemType.Group:
					break;
			}
		}
	}
}
