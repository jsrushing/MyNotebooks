/* 
 * User Permissions object.
 * created 08/01/23
 * - jsr
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using myNotebooks.subforms;
using Newtonsoft.Json.Linq;

namespace myNotebooks.objects
{
	public class UserPermissions
	{
		public bool CreateCompany { get; set; }
		public bool CreateAccount { get; set; }
		public bool CreateDepartment { get; set; }
		public bool CreateGroup { get; set; }
		public bool CreateNotebook { get; set; }
		public bool CreateSimpleUser { get; set; }
		public bool CreateMasterUser { get; set; }
		public bool DeleteRenameCompany { get; set; }
		public bool DeleteRenameAccount { get; set; }
		public bool DeleteRenameDepartment { get; set; }
		public bool DeleteRenameGroup { get; set; }
		public bool DeleteRenameNotebooks { get; set; }
		public bool EditNotebookValues { get; set; }
		public bool EditNotebookSettings { get; set; }
		public bool ManageUsers { get; set; }
		public bool ManageUserPermissions { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime EditedOn { get; set; }

		public UserPermissions() { }

		public UserPermissions(DataTable dataTable) { PopulateFromDataTable(dataTable); }

		public UserPermissions(List<string> list) { PopulateFromListOfStrings(list); }

		public bool Equals(UserPermissions permsToCompare)
		{
			bool bRtrn = true;

			foreach(PropertyInfo sPropertyName in typeof(UserPermissions).GetProperties())
			{
				if(!sPropertyName.Name.ToLower().Equals("createdon") & !sPropertyName.Name.ToLower().Equals("editedon"))
				{
					if(this.GetType().GetProperty(sPropertyName.Name) != permsToCompare.GetType().GetProperty(sPropertyName.Name))
					{
						bRtrn = false;
						break;
					}
				}
			}

			return bRtrn;
		}

		public List<string> GetAllPermissions()
		{
			var list = new List<string>();

			foreach (PropertyInfo property in typeof(UserPermissions).GetProperties())
			{
				if (property.PropertyType == typeof(bool)) { list.Add(property.Name); }
			}
			return list;
		}

		public List<string> GetGrantedPermissions()
		{
			var list = new List<string>();

			foreach(PropertyInfo property in typeof(UserPermissions).GetProperties())
			{
				if(property.PropertyType == typeof(bool))
				{ if(Convert.ToBoolean(property.GetValue(this, null))) { list.Add(property.Name); } }
			}

			return list;
		}

		private void PopulateFromListOfStrings(List<string> list)
		{
			foreach (var item in list)
			{
				this.GetType().GetProperty(item).SetValue(this, true);
			}
		}

		private void PopulateFromDataTable(DataTable dt)
		{
			var value = "";

			foreach (PropertyInfo sPropertyName in typeof(UserPermissions).GetProperties())
			{
				try
				{
					if (dt.Columns[sPropertyName.Name].DataType == typeof(bool))
					{
						value = dt.Rows[0].Field<bool>(sPropertyName.Name).ToString();
						this.GetType().GetProperty(sPropertyName.Name).SetValue(this, Convert.ToBoolean(value));
					}
					else if (dt.Columns[sPropertyName.Name].DataType == typeof(DateTime))
					{
						DateTime dtime = Convert.ToDateTime(dt.Rows[0].Field<DateTime>(sPropertyName.Name));
						this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dtime);
					}

				}
				catch (Exception ex)
				{
					if (ex.GetType() != typeof(InvalidCastException))
					{
						using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "The error '" + ex.Message +
						"' occurred while processing the property '" + sPropertyName + "'.", "Error Occurred")) { frm.ShowDialog(); }
					}
				}
			}
		}
	}
}
