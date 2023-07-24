using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using Org.BouncyCastle.Asn1;

namespace MyNotebooks.objects
{
	internal class User
	{
		public int AccessLevel { get; set; }
		public int AccountId { get; set; }
		public int CompanyId { get; set; }
		public int DepartmentId { get; set; }
		public int GroupId { get; set; }
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public bool IsEnterprise { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? EditedOn { get; set; }
		public Permissions Permissions { get; set; }

		public User() { }

		public User(int accessLevel, string name, string password, int userId, int companyId,
			int accountId, int departmentId, int groupId, DateTime createdOn, DateTime? editedOn = null, bool isEnterprise = false)
		{
			AccessLevel = accessLevel;
			UserId = userId;
			Name = name;
			Password = password;
			CompanyId = companyId;
			AccountId = accountId;
			DepartmentId = departmentId;
			GroupId = groupId;
			IsEnterprise = isEnterprise;
			CreatedOn = createdOn;
			EditedOn = editedOn;
		}

		public User(DataTable dt)
		{
			foreach (PropertyInfo sPropertyName in typeof(User).GetProperties())
			{
				this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dt.Columns[sPropertyName.Name]);
			}
		}

		public void Save()
		{

		}
	}
}
