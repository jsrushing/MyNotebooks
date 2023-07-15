using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Encryption;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyNotebooks.DataAccess;
using MyNotebooks.objects;

namespace MyNotebooks.subforms
{
	public partial class UserLogin : Form
	{
		public UserLogin()
		{
			InitializeComponent();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			// look up the user
			DataSet ds = DbAccess.GetUser(txtUserName.Text, txtPwd.Text);
			if (ds.Tables.Count > 0)
			{
				DataTable dtUser = ds.Tables[0];            // company id, name, access level, created on, edited on
				DataTable dtPermissions = ds.Tables[1];     // permissions
				User u = new(ds.Tables[0]) { Permissions = new(ds.Tables[1])};
			}
			else
			{
				pnlCreateUser.Location = pnlLogin.Location;
				pnlCreateUser.Visible = true;
				pnlLogin.Visible = false;
				this.Size = pnlCreateUser.Size;
			}
		}

		private void UserLogin_Load(object sender, EventArgs e)
		{
			pnlLogin.Location = new Point(4, 12);
			this.Size = pnlLogin.Size;
		}
	}
}
