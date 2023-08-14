using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using myNotebooks.subforms;
using MyNotebooks.objects;

namespace myNotebooks.objects
{
	public class Department : IOrgLevel
	{
		public Department(DataTable dt, int rowIndex) { PopulateFromDataTable(dt, rowIndex); }

		private void PopulateFromDataTable(DataTable dt, int rowIndex)
		{
			this.OrgLevelType = subforms.frmMain.OrgLevelTypes.Company;
			var value = "";

			foreach (PropertyInfo sPropertyName in typeof(Department).GetProperties())
			{
				if (!sPropertyName.Name.ToLower().Contains("orglevel"))
				{
					try
					{
						if (dt.Columns[sPropertyName.Name].DataType == typeof(string))
						{
							value = dt.Rows[rowIndex].Field<string>(sPropertyName.Name).ToString();
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, value);
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(DateTime))
						{
							DateTime dtime = Convert.ToDateTime(dt.Rows[rowIndex].Field<DateTime>(sPropertyName.Name));
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dtime);
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(int))
						{
							value = dt.Rows[rowIndex].Field<Int32>(sPropertyName.Name).ToString();
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, Convert.ToInt32(value));
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
}
