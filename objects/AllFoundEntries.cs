using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebooks.objects
{

	public class AllFoundEntries
	{
		public List<Entry> foundWithLabels = new();
		public List<Entry> foundWithTitle = new();
		public List<Entry> foundWithText = new();
		public List<Entry> foundWithDate = new();

		public AllFoundEntries() { }

		public void Add(AllFoundEntries entriesToAdd)
		{
			this.foundWithLabels.AddRange(entriesToAdd.foundWithLabels);
			this.foundWithTitle.AddRange(entriesToAdd.foundWithTitle);
			this.foundWithText.AddRange(entriesToAdd.foundWithText);
			this.foundWithDate.AddRange(entriesToAdd.foundWithDate);
		}
	}
}
