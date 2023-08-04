using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using myNotebooks.subforms;

namespace myNotebooks.objects
{
	public class UserAssignments
	{
		public int UserId { get; set; }
		public int CompanyId { get; set; }
		public int AccountId { get; set; }
		public int DepartmentId { get; set; }
		public int GroupId { get; set; }
		public OrgType orgType { get; set; }

		public enum OrgType { Company, Account, Department, Group }

		public UserAssignments() { }

		public UserAssignments(DataTable dt) 
		{
			foreach (PropertyInfo sPropertyName in typeof(UserAssignments).GetProperties())
			{
				if(dt.Rows.Count > 0)
				{
					try
					{
						foreach(DataRow row in dt.Rows)
						{
							var value = row.Field<int>(sPropertyName.Name);
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, value);
						}
					}
					catch (Exception ex)
					{
						using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "The error '" + ex.Message + 
							"' occurred while processing the property '" + sPropertyName + "'.", "Error Occurred")) { frm.ShowDialog(); }
					}
				}
			}
		}

		public UserAssignments(DataRow dr)
		{
			foreach (PropertyInfo sPropertyName in typeof(UserAssignments).GetProperties())
			{
				if(sPropertyName.Name.ToLower() != "orgtype")
				{
					try
					{
						var value = dr.Field<int>(sPropertyName.Name);
						this.GetType().GetProperty(sPropertyName.Name).SetValue(this, value);
					}
					catch (Exception ex)
					{
						using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "The error '" + ex.Message +
							"' occurred while processing the property '" + sPropertyName + "'.", "Error Occurred")) { frm.ShowDialog(); }
					}
				}
			}
		}
	}
}
