using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebooks.objects
{
	public class MNLabel
	{
		public int		CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? EditedOn { get; set; }
		public int		EntryId { get; set; }
		public string	LabelText { get; set; }
		public bool		IsActive { get; set; }
	}
}
