/* Utility functions.
 * 7/9/22
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Configuration;

namespace myJournal.objects
{
	public static class Utilities
	{
		public static void Showform(Form frm, Form frmParent)
		{
			frm.StartPosition = FormStartPosition.Manual;
			frm.Location = new Point(frmParent.Left, frmParent.Top);
			frm.Size = new Size(frmParent.Width, frmParent.Height);
			frmParent.Hide();
			frm.ShowDialog();
		}

		public static void CheckExistingLabels(CheckedListBox clb, JournalEntry entry)
		{
			string labels = entry.ClearTags() + ",";

			for (int i = 0; i < clb.Items.Count; i++)
			{
				clb.SetItemChecked(i, labels.Contains(clb.Items[i].ToString() + ","));
			}
		}

		public static string GetCheckedLabels(CheckedListBox cbx)
		{
			string labels = string.Empty;
			for (int i = 0; i < cbx.CheckedItems.Count; i++)
			{
				labels += cbx.CheckedItems[i].ToString() + ",";
			}
			labels = labels.Length > 0 ? labels.Substring(0, labels.Length - 1) : string.Empty;
			return labels;
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

		public static void ResizeListsAndRTBs(ListBox entriesList, RichTextBox entryRTB, Label seperatorLabel, Label typeLabel, Form callingForm)
		{
			int iBoxCenter = entriesList.Width / 2;
			seperatorLabel.Visible = true;
			entryRTB.Visible = true;
			seperatorLabel.Left = entriesList.Left + 10;
			seperatorLabel.Width = entriesList.Width - 20;
			entriesList.Height = seperatorLabel.Top - entriesList.Top;
			typeLabel.Top = seperatorLabel.Top + seperatorLabel.Height;
			entryRTB.Top = typeLabel.Top + typeLabel.Height;
			entryRTB.Height = callingForm.Height - entryRTB.Top - 50;
		}

		public static JournalEntry SelectEntry(RichTextBox rtb, ListBox lb, Journal currentJournal, bool FirstSelection)
		{
			rtb.Clear();
			List<int> targets = new List<int>();
			JournalEntry currentEntry;

			try
			{
				if (lb.SelectedIndices.Count > 1)
				{
					for (int i = 0; i < lb.SelectedIndices.Count - 1; i++)
					{
						if (lb.SelectedIndices[i] == lb.SelectedIndices[i + 1] - 1)
						{
							targets.Add(lb.SelectedIndices[i]);
							targets.Add(lb.SelectedIndices[i + 1]);
							targets.Add(lb.SelectedIndices[i + 2]);
							break;
						}
					}
				}
			}
			catch (Exception) { }

			if (targets.Count == 3)
			{
				foreach (int i in targets)
				{
					lb.SelectedIndices.Remove(i);
				}
			}

			int ctr = lb.SelectedIndex;

			if (lb.Items[ctr].ToString().StartsWith("--")) ctr--;

			while (!lb.Items[ctr].ToString().StartsWith("--") & ctr > 0)
			{
				ctr--;
				if (ctr < 0) break;
			}

			if (ctr > 0) { ctr += 1; }
			lb.SelectedIndices.Clear();                             // Select the whole short entry ...
			lb.SelectedIndices.Add(ctr);
			lb.SelectedIndices.Add(ctr + 1);
			lb.SelectedIndices.Add(ctr + 2);                        //

			// this is where you have to account for isEdited
			string sTitleAndDate = lb.Items[ctr].ToString().Replace(" - EDITED", "");        // Use the title and date of the entry to create a JournalEntry object whose .ClearText will populate the display ...
			string sTitle = sTitleAndDate.Substring(0, sTitleAndDate.LastIndexOf('(') - 1);
			string sDate = sTitleAndDate.Substring(sTitleAndDate.LastIndexOf('(') + 1, sTitleAndDate.Length - 2 - sTitleAndDate.LastIndexOf('('));
			currentEntry = currentJournal.GetEntry(sTitle, sDate);

			if (currentEntry != null)
			{
				StringBuilder sb = new StringBuilder();
				rtb.Text = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
					, currentEntry.ClearTitle(), currentEntry.Date
					, currentEntry.ClearTags()
					, currentEntry.ClearText());
				if (rtb.Text.Length == 0) { lb.TopIndex = lb.Top + lb.Height < rtb.Top ? ctr : lb.TopIndex; }
				lb.Height = rtb.Text.Length > 0 ? rtb.Top - 132 : 100;

				if (FirstSelection)
				{
					lb.TopIndex = lb.Top + lb.Height < rtb.Top ? ctr : lb.TopIndex;
				}
			}

			rtb.Visible = rtb.Text.Length > 0;
			return currentEntry;
		}
	}
}
