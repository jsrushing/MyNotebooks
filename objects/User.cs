using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using myNotebooks.subforms;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace MyNotebooks.objects
{
	internal class User
	{
		public int		AccessLevel { get; set; }
		public string	Name { get; set; }
		public int		UserId { get; set; }
		public int		CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? EditedOn { get; set; }
		public UserAssignments Assignments { get; set; }
		public UserPermissions Permissions { get; set; }

		public User() { }

		public User(int accessLevel, string name, string password, int userId, DateTime createdOn, DateTime? editedOn = null, bool isEnterprise = false)
		{
			AccessLevel = accessLevel;
			UserId = userId;
			Name = name;
			//Password = password;
			//IsEnterprise = isEnterprise;
			CreatedOn = createdOn;
			EditedOn = editedOn;
		}

		public User(DataTable dt)
		{
			var value = "";
			var setProp = true;

			foreach (PropertyInfo sPropertyName in typeof(User).GetProperties())
			{
				try
				{
					if (sPropertyName.Name != "Assignments" &&  sPropertyName.Name != "Permissions")
					{
						if (dt.Columns[sPropertyName.Name].DataType == typeof(string))
						{
							value = dt.Rows[0].Field<string>(sPropertyName.Name).ToString();
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(Int32))
						{
							int iVal = dt.Rows[0].Field<Int32>(sPropertyName.Name);
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, iVal);
							setProp = false;
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(DateTime))
						{
							DateTime dtime = Convert.ToDateTime(dt.Rows[0].Field<DateTime>(sPropertyName.Name));
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dtime);
							setProp = false;
						}

						if (setProp) { this.GetType().GetProperty(sPropertyName.Name).SetValue(this, value); }
						setProp = true;
					}
					//Type type = dt.Columns[sPropertyName.Name].DataType;


				}
				catch (Exception ex) 
				{
					if (ex.GetType() != typeof(InvalidCastException))
					{
						using(frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "The error '" + ex.Message + "' occurred while processing the " +
							"property '" + sPropertyName + "'.", "Error Occurred")) { frm.ShowDialog(); }
					}
				}
			}
		}

		public void Save()
		{

		}
	}
}
