using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myNotebooks.objects
{
	internal interface IOrgLevel
	{
		public string Id { get; set; }
		public string ParentId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? EditedOn { get; set; }
	}
}
