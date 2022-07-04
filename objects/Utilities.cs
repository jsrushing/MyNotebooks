using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace myJournal.objects
{
	public static class Utilities
	{
		public static void Showform(Form frm, Form frmParent)
		{
			frm.StartPosition = FormStartPosition.Manual;
			frm.Location = new Point(frmParent.Left, frmParent.Top);
			frm.Size = new Size(frmParent.Width, frmParent.Height);
			frm.ShowDialog();
		}
	}
}
