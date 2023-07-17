using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebooks.objects
{
	internal class Company
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? EditedOn { get; set;}

		public Company() { }

		public Company(DataTable table) { PopulateFromDataTable(table); }

		private void PopulateFromDataTable(DataTable dt)
		{
			foreach (PropertyInfo sPropertyName in typeof(Company).GetProperties())
			{
				this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dt.Columns[sPropertyName.Name]);
			}
		}
	}
}
