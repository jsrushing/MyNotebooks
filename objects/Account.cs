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
	public class Account : IOrgLevel
	{
		//public string Id { get; set; }
		//public string ParentId { get; set; }
		//public string Name { get; set; }
		//public string Description { get; set; }
		//public DateTime CreatedOn { get; set; }
		//public DateTime? EditedOn { get; set; }

		public Account(DataRow dr) { PopulateFromDataRow(dr); }

		private void PopulateFromDataRow(DataRow dr)
		{
			this.OrgLevelType = subforms.frmMain.OrgLevelTypes.Account;

			foreach (PropertyInfo sPropertyName in typeof(Account).GetProperties())
			{
				this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dr[sPropertyName.Name]);
			}
		}
	}
}
