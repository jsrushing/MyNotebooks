using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebooks.objects
{
	internal class ListItem
	{
		public string Name {  get; set; }
		public int Id { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
