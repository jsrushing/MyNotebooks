/* Utility functions.
 * 7/9/22
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;

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

		public static void PopulateEntries(ListBox lbxToPopulate, List<JournalEntry> entries, string startDate = "", bool clearPrevious = true, string journalName = "")
		{
			if(clearPrevious) lbxToPopulate.Items.Clear();
			List<JournalEntry> tmpEntries = null;
			tmpEntries = entries;
			tmpEntries.Sort((x, y) => -x.Date.CompareTo(y.Date));

			foreach (JournalEntry je in tmpEntries)
			{
				for(int i = 0; i < je.Synopsis.Length; i++) 
				{ 
					lbxToPopulate.Items.Add(je.Synopsis[i]);
				} 
			}
		}

		public static void PopulateLabelsList(CheckedListBox clb, ListBox lb = null)
		{
			if (clb != null) { clb.Items.Clear(); }
			if (lb != null) { lb.Items.Clear(); }

			foreach (string label in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/settings/labels"))
			{
				if (lb != null)
				{ lb.Items.Add(label); }
				else
				{ clb.Items.Add(label); }
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

		public static JournalEntry SelectEntry(RichTextBox rtb, ListBox lb, Journal currentJournal, bool FirstSelection, JournalEntry je = null)
		{
			rtb.Clear();
			List<int> targets = new List<int>();
			JournalEntry entryRtrn = null;
			
			if(je != null)
			{
				entryRtrn = je;

				for (int i = 0; i < lb.Items.Count; i++)
				{
					if (lb.Items[i].ToString().StartsWith(je.Synopsis[0].ToString()))	//  je.ClearTitle() + " (" + je.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]) + ")"))
					{
						lb.SelectedIndices.Add(i);
						lb.SelectedIndices.Add(i + 1); 
						lb.SelectedIndices.Add(i + 2);
						rtb.Text = je.DisplayText;
						break;
					}
				}
			}
			else 
			{
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

				string sTitleAndDate = lb.Items[ctr].ToString().Replace(" - EDITED", "");        // Use the title and date of the entry to create a JournalEntry object whose .ClearText will populate the display ...
				string sTitle = sTitleAndDate.Substring(0, sTitleAndDate.LastIndexOf('(') - 1);
				string sDate = sTitleAndDate.Substring(sTitleAndDate.LastIndexOf('(') + 1, sTitleAndDate.LastIndexOf(')') - sTitleAndDate.LastIndexOf('(') - 1);
				
				entryRtrn = currentJournal.GetEntry(sTitle, sDate);

				if (entryRtrn != null)
				{
					if(entryRtrn.DisplayText != null)    // entries prior to 1.0.0.1 will not have .DisplayText
					{
						rtb.Text = entryRtrn.DisplayText;
					}
					else
					{
						rtb.Text = String.Format(ConfigurationManager.AppSettings["EntryOutputFormat_Printing"]
						, entryRtrn.ClearTitle(), entryRtrn.Date.ToString(ConfigurationManager.AppSettings["DisplayedDateFormat"]), entryRtrn.ClearTags(), entryRtrn.ClearText());
					}
					
					if (rtb.Text.Length == 0) { lb.TopIndex = lb.Top + lb.Height < rtb.Top ? ctr : lb.TopIndex; }
					lb.Height = rtb.Text.Length > 0 ? rtb.Top - 132 : 100;

					if (FirstSelection)
					{
						lb.TopIndex = lb.Top + lb.Height < rtb.Top ? ctr : lb.TopIndex;
					}
				}

				rtb.Visible = rtb.Text.Length > 0;
			}

			return entryRtrn;
		}
	}
}