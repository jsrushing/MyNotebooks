using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1;

namespace MyNotebooks.objects
{
	internal class User
	{
		public int AccessLevel { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }	
		public int CompanyId { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime EditedOn { get; set; }


		public User() { }

		public User(DataTable dt) 
		{
			foreach (PropertyInfo sPropertyName in typeof(User).GetProperties())
			{
				this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dt.Columns[sPropertyName.Name]);
			}
		}
	}
}
