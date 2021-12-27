using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace myJournal
{
    internal static class EntrySelector
    {
        public static void SelectEntry(ListBox lb, int index)
        {
            lb.SelectedIndices.Clear();
            lb.SelectedIndices.Add(index);
            lb.SelectedIndices.Add(index + 1);
            lb.SelectedIndices.Add(index + 2);
        }
    }
}
