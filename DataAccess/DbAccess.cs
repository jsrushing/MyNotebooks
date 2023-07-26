/* Handle access to Azure Db.
 * created 07/12/23
 * - jsr
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Encryption;
using System.Threading.Tasks;
using MyNotebooks.objects;
using System.Reflection;
using Microsoft.VisualBasic.ApplicationServices;

namespace MyNotebooks.DataAccess
{
	internal class DbAccess
	{
		private static string connString = "Server=mynotebooksserver.database.windows.net;Database=MyNotebooks;user id=mydb_admin;password=cloud_Bringer1!";

		public static DataSet GetUser(string userName, string password)
		{
			DataSet ds = new();

			using(SqlConnection conn = new(connString))
			{
				conn.Open();

				using(SqlCommand cmd = new("sp_GetUser", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@userName", userName);
					var v = EncryptDecrypt.Encrypt(password, password);
					cmd.Parameters.AddWithValue("@password", EncryptDecrypt.Encrypt(password, password));
					SqlDataAdapter adapter = new() { SelectCommand = cmd } ;
					adapter.Fill(ds);
				}
			}
			return ds;
		}

		//public static int CreateUser(MyNotebooks.objects.User usr)
		//{
		//	int iRtrn = -1;

		//	using (SqlConnection conn = new(connString))
		//	{
		//		conn.Open();

		//		using (SqlCommand cmd = new("sp_CreateUser", conn))
		//		{
		//			cmd.CommandType = CommandType.StoredProcedure;
		//			cmd.Parameters.AddWithValue("@AccessLevel", usr.AccessLevel);
		//			cmd.Parameters.AddWithValue("@Name", usr.Name);
		//			//cmd.Parameters.AddWithValue("@CompanyId", usr.CompanyId);
		//			//cmd.Parameters.AddWithValue("@AccountId", usr.AccountId);
		//			//cmd.Parameters.AddWithValue("@DepartmentId", usr.DepartmentId);
		//			//cmd.Parameters.AddWithValue("@GroupId", usr.GroupId);
		//			//cmd.Parameters.AddWithValue("@IsEnterprise", usr.IsEnterprise);
		//			cmd.Parameters.AddWithValue("@password", EncryptDecrypt.Encrypt(usr.Password, usr.Password));

		//			foreach(PropertyInfo sPropertyName in typeof(UserPermissions).GetProperties())
		//			{
		//				cmd.Parameters.AddWithValue
		//					(
		//						"@" + sPropertyName,
		//						// from https://stackoverflow.com/questions/1196991/get-property-value-from-string-using-reflection
		//						usr.Permissions.GetType().GetProperty(sPropertyName.Name).GetValue(usr.Permissions, null)
		//					);
		//			}

		//			cmd.Parameters.Add("@retVal");
		//			cmd.Parameters["@retVal"].Direction = ParameterDirection.ReturnValue;
		//			cmd.ExecuteNonQuery();
		//			iRtrn = Convert.ToInt32(cmd.Parameters["@retVal"].Value.ToString());
		//		}
		//	}

		//	return iRtrn;
		//}

		public static Company GetCompany(string companyId)
		{
			Company cRtrn = null;
			DataTable dt = new();

			using (SqlConnection conn = new(connString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetCompany", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@companyId", Convert.ToInt32(companyId));
					SqlDataAdapter adapter = new() { SelectCommand = cmd };
					adapter.Fill(dt);
					cRtrn = new Company(dt);
				}
			}
			
			return cRtrn;
		}
	}
}
