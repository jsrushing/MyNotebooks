using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebooks.objects
{
	public class Account
	{
		public string Id { get; set; }
		public string CompanyId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? EditedOn { get; set; }

		public Account() { }

		public Account(DataRow dr) { PopulateFromDataRow(dr); }

		private void PopulateFromDataRow(DataRow dr)
		{
			foreach (PropertyInfo sPropertyName in typeof(Group).GetProperties())
			{
				this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dr[sPropertyName.Name]);
			}
		}
	}
}
