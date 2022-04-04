using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace myJournal
{
	public partial class frmPlay : Form
	{
		int iMouseX = -1;

		public frmPlay()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label1_MouseMove(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				label1.Top += e.Y;
			}
		}

		private void label1_MouseDown(object sender, MouseEventArgs e)
		{
			iMouseX = label1.Top;
		}

		private void label1_MouseLeave(object sender, EventArgs e)
		{
			iMouseX = -1;
		}
	}
}
