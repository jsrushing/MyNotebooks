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
		public string	AccessLevel { get; set; }
		public string	Name { get; set; }
		public string	UserId { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? EditedOn { get; set; }
		public UserAssignments Assignments { get; set; }
		public UserPermissions Permissions { get; set; }

		public User() { }

		public User(int accessLevel, string name, string password, int userId, DateTime createdOn, DateTime? editedOn = null, bool isEnterprise = false)
		{
			//AccessLevel		= accessLevel;
			//UserId			= userId;
			Name			= name;
			//Password		= password;
			//IsEnterprise	= isEnterprise;
			CreatedOn		= createdOn;
			EditedOn		= editedOn;
		}

		public User(DataTable dt)
		{
			foreach (PropertyInfo sPropertyName in typeof(User).GetProperties())
			{
				try
				{
					var v = dt.Rows[0].Field<string>(sPropertyName.Name);
					this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dt.Rows[0].Field<string>(sPropertyName.Name));
				}
				catch(Exception ex) { }
			}
		}

		public void Save()
		{

		}
	}
}
