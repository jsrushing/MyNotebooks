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
using myNotebooks.objects;
using myNotebooks.DataAccess;
using System.Windows.Forms;

namespace myNotebooks.objects
{
	public class MNUser

	{
		public int				AccessLevel { get; set; }
		public string			Name { get; set; }
		public string			Password { get; set; }
		public int				UserId { get; set; }
		public int				CreatedBy { get; set; }
		public DateTime			CreatedOn { get; set; }
		public DateTime?		EditedOn { get; set; }
		public List<Group>		Groups { get { return GetGroups(); } }
		public List<Department>	Departments { get { return GetDepartments(); } }
		public List<Account>	Accounts { get { return GetAccounts(); } }
		public List<Company>	Companies { get { return GetCompanies(); } }
		public List<UserAssignment> Assignments { get; set; } = new();
		public UserPermissions		Permissions { get; set; } = new();

		public MNUser() { }

		public MNUser(int accessLevel, string name, string password, int userId, DateTime createdOn, DateTime? editedOn = null, bool isEnterprise = false)
		{
			AccessLevel = accessLevel;
			UserId = userId;
			Name = name;
			//Password = password;
			//IsEnterprise = isEnterprise;
			CreatedOn = createdOn;
			EditedOn = editedOn;
		}

		public MNUser(DataTable dt)
		{
			var value = "";
			var setProp = true;

			foreach (PropertyInfo sPropertyName in typeof(MNUser).GetProperties())
			{
				try
				{
					if (sPropertyName.Name != "Assignments" &  sPropertyName.Name != "Permissions" & dt.Columns[sPropertyName.Name] != null)
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

		private List<Group> GetGroups() { return DbAccess.GetGroups(this.UserId); }

		private List<Department> GetDepartments() { return DbAccess.GetDepartments(this.UserId); }

		private List<Account> GetAccounts() { return DbAccess.GetAccounts(this.UserId); }

		private List<Company> GetCompanies() { return DbAccess.GetCompanies(this.UserId); }

		//public List<TreeNode> GetHighestNodeItems()
		//{
		//	return DbAccess.GetHighestNodeItemsForUser(this.UserId);
		//}

		public void Save()
		{

		}
	}
}
