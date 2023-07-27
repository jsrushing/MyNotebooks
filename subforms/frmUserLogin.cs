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
using myNotebooks;
using System.Reflection;
using myNotebooks.subforms;

namespace MyNotebooks.subforms
{
	public partial class frmUserLogin : Form
	{
		public frmUserLogin()
		{
			InitializeComponent();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			// look up the user
			DataSet ds = DbAccess.GetUser(txtUserName.Text, txtPwd.Text);

			if (ds.Tables.Count > 0)    // the user was found
			{
				Program.User = new(ds.Tables[0]) { Permissions = new(ds.Tables[1]) };
				if (Program.User != null) { this.Hide(); }
			}
			else
			{
				using (frmMessage frm = new(frmMessage.OperationType.Message, "No User Found.", "", this))
				{ frm.ShowDialog(); }
				txtUserName.Text = "";
				txtPwd.Text = "";
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }
	}
}
