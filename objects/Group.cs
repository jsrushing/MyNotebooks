using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyNotebooks.objects;

namespace myNotebooks.objects
{
	public class Group : IOrgLevel
	{
		//public string Id { get; set; }
		//public string DepartmentId { get; set; }
		//public string Name { get; set; }
		//public string Description { get; set; }
		//public DateTime CreatedOn { get; set; }
		//public DateTime? EditedOn { get; set; }

		public Group(DataRow dr) { PopulateFromDataRow(dr); }

		private void PopulateFromDataRow(DataRow dr)
		{
			this.OrgLevelType = subforms.frmMain.OrgLevelTypes.Group;

			foreach (PropertyInfo sPropertyName in typeof(Group).GetProperties())
			{
				this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dr[sPropertyName.Name]);
			}
		}
	}
}
