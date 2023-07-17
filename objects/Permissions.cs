using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebooks.objects
{
	internal class Permissions
	{
		public int	CompanyId { get; set; }
		public bool CreateCompany { get; set; }
		public bool CreateAccount { get; set; }
		public bool CreateGroup { get; set; }
		public bool CreatedOn { get; set; }
		public bool CreateSimpleUser { get; set; }
		public bool DeleteRenameCompany { get; set; }
		public bool DeleteRenameAccount { get; set; }
		public bool DeleteRenameGroup { get; set; }
		public bool DeleteRenameNotebooks { get; set; }
		public bool EditNotebookValues { get; set; }
		public bool EditNotebookSettings { get; set; }
		public bool EditedOn { get; set; }
		public bool ManageUsers { get; set; }
		public bool ManageUserPermissions { get; set; }
		public bool Synch { get; set; }
		public bool ViewNotebooks { get; set; }

		public Permissions() { }

		public Permissions(DataTable dataTable) { PopulateFromDataTable(dataTable); }

		private void PopulateFromDataTable(DataTable dt)
		{
			foreach (PropertyInfo sPropertyName in typeof(Permissions).GetProperties())
			{
				this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dt.Columns[sPropertyName.Name]);
			}
		}

	}
}
