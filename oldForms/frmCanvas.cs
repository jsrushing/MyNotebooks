using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using myJournal.subforms;

namespace myJournal
{
	public partial class frmCanvas : Form
	{
		Form DisplayedForm;

		public frmCanvas()
		{
			InitializeComponent();
		}

		private void frmCanvas_Load(object sender, EventArgs e)
		{
			ActivateForm(new frmMain());
		}

		private void ActivateForm(Form frmToActivate)
		{
			DisplayedForm = frmToActivate;
			//pnlMenu.Visible = false;
			frmToActivate.Size = this.Size;
			frmToActivate.ShowDialog();
			frmToActivate.Close();

			switch (DisplayedForm.Name)
			{
				case ("frmLogin"):
					if (ConfigurationManager.AppSettings["CloseApp"] == "True")
					{
						this.Close();
					}
					else
					{
						ActivateForm(new frmMain());
					}
					break;
			}
		}
	}
}
