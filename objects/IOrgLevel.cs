/* 
 * OrgLevelType interface.
 * created 08/09/23
 * - jsr
 */
using System;
using myNotebooks.subforms;

namespace MyNotebooks.objects
{
	public abstract class IOrgLevel
	{
		public frmMain.OrgLevelTypes OrgLevelType { get; set; }
		public string		Id { get; set; }
		public string		ParentId { get; set; }
		public string		Name { get; set; }
		public string		Description { get; set; }
		public DateTime		CreatedOn { get; set; }
		public DateTime?	EditedOn { get; set; }
	}
}
