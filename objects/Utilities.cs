using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

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

		public static void PopulateLabelsList(CheckedListBox clb, ListBox lb = null)
		{
			if (clb != null) { clb.Items.Clear(); }
			if (lb != null) { lb.Items.Clear(); }

			foreach (string group in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/settings/groups"))
			{
				if (lb != null)
				{
					lb.Items.Add(group);
				}
				else
				{
					clb.Items.Add(group);
				}
			}
		}

		public static void PopulateEntries(ListBox lbxToPopulate, List<JournalEntry> entries)
		{
			lbxToPopulate.Items.Clear();

			foreach (JournalEntry je in entries)
			{
				foreach (string s in je.EntryAsList(lbxToPopulate.Width))
				{
					lbxToPopulate.Items.Add(s);
				}
			}

		}
	}
}
