using System;
using System.Data;
using System.Reflection;
using myNotebooks.objects;
using myNotebooks.subforms;

namespace MyNotebooks.objects
{
	public class OrgLevel : IOrgLevel
	{
		public OrgLevel() { }	

		public OrgLevel(frmMain.OrgLevelTypes type, DataTable dt = null, int rowIndex = -1) 
		{ 
			this.OrgLevelType = type;
			var value = "";

			foreach (PropertyInfo sPropertyName in typeof(Account).GetProperties())
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
