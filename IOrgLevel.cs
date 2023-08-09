using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myNotebooks.subforms;

namespace MyNotebooks
{
	internal interface IOrgLevel
	{
		frmMain.OrgLevelTypes OrgLevelType { get; set; }
		public string Id { get; set; }
		public string CompanyId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? EditedOn { get; set; }
	}
}
