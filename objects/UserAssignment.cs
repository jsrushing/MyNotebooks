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
	public class UserAssignment
	{
		public int CompanyId { get; set; }
		public int AccountId { get; set; }
		public int DepartmentId { get; set; }
		public int GroupId { get; set; }

		public UserAssignment() { }

		public UserAssignment(DataTable dt) 
		{
			foreach (PropertyInfo sPropertyName in typeof(UserAssignment).GetProperties())
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
						using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "The error '" + ex.Message + 
							"' occurred while processing the property '" + sPropertyName + "'.", "Error Occurred")) { frm.ShowDialog(); }
					}
				}
			}
		}

		public UserAssignment(DataRow dr)
		{
			foreach (PropertyInfo sPropertyName in typeof(UserAssignment).GetProperties())
			{
				try
				{
					//if(!dr.Field<int>(sPropertyName.Name) == null)
					//{

					//}
					var value = dr.Field<int>(sPropertyName.Name);
					this.GetType().GetProperty(sPropertyName.Name).SetValue(this, value);
				}
				catch (Exception ex)
				{
					//using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "The error '" + ex.Message +
					//	"' occurred while processing the property '" + sPropertyName + "'.", "Error Occurred")) { frm.ShowDialog(); }
				}
			}
		}
	}
}
