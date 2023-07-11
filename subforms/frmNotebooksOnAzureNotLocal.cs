using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace myJournal.subforms
{
	public partial class frmNotebooksInCloudNotLocal : Form
	{
		public frmNotebooksInCloudNotLocal(string[] items)
		{
			InitializeComponent();
			clbAzureItems.Items.AddRange(items);

			label1.Text = "These notebooks were found in your cloud but not in your local cache." +
				Environment.NewLine + "You may select book to download, and provide a PIN where necessary, and click 'Download'." +
				Environment.NewLine + "Or you may select books you want to ignore in the future and click 'Ignore'.";
		}
	}
}
