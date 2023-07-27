using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using myNotebooks.subforms;

namespace MyNotebooks.objects
{
	internal class UserAssignments
	{
		public int Companyid { get; set; }
		public int AccountId { get; set; }
		public int DepartmentId { get; set; }
		public int GroupId { get; set; }

		public UserAssignments() { }

		public UserAssignments(DataTable dt) 
		{
			foreach (PropertyInfo sPropertyName in typeof(UserAssignments).GetProperties())
			{
				if(dt.Rows.Count > 0)
				{
					try
					{
						var value = dt.Rows[0].Field<int>(sPropertyName.Name);
						this.GetType().GetProperty(sPropertyName.Name).SetValue(this, value);
					}
					catch (Exception ex)
					{
						using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "The error '" + ex.Message + "' occurred while processing the " +
							"property '" + sPropertyName + "'.", "Error Occurred")) { frm.ShowDialog(); }
					}
				}
			}
		}
	}
}
