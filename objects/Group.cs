using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebooks.objects
{
	internal class Group
	{
		public string Id { get; set; }
		public string DepartmentId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? EditedOn { get; set; }

		public Group() { }

		public Group(DataTable table) { PopulateFromDataTable(table); }

		private void PopulateFromDataTable(DataTable dt)
		{
			foreach (PropertyInfo sPropertyName in typeof(Group).GetProperties())
			{
				foreach(DataRow row in dt.Rows)
				{
					this.GetType().GetProperty(sPropertyName.Name).SetValue(this, row[sPropertyName.Name]);
				}
			}
		}
	}
}
