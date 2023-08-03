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
using myNotebooks.objects;
using System.Reflection;
using Microsoft.VisualBasic.ApplicationServices;
using myNotebooks;
using System.Windows.Forms;
using myNotebooks.subforms;
using MyNotebooks.objects;

namespace myNotebooks.DataAccess
{
	internal class DbAccess
	{
//		private static string connString = "Server=mynotebooksserver.database.windows.net;Database=myNotebooks;user id=mydb_admin;password=cloud_Bringer1!";
		private static string connString = "Server=FORRESTSTNW;Database=MyNotebooks;Trusted_Connection = true";

		public static int CreateMNUser(MNUser user)
		{
			int iRtrn = 0;
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand("sp_CreateUser", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@userName", user.Name);
						cmd.Parameters.AddWithValue("@password", user.Password);
						cmd.Parameters.AddWithValue("@accessLevel", user.AccessLevel);
						cmd.Parameters.AddWithValue("@createdBy", user.CreatedBy);
						cmd.Parameters.Add("@retVal", SqlDbType.Int);
						cmd.Parameters["@retVal"].Direction = ParameterDirection.ReturnValue;
						cmd.ExecuteNonQuery();
						iRtrn = Convert.ToInt32(cmd.Parameters["@retVal"].Value.ToString());
					}
				}
			}
			catch (Exception ex) { var v = ex.Message; }

			return iRtrn;
		}

		public static int CreateMNUserAssignments(int userId, int companyId, int accountId, int departmentId, int groupId)
		{
			int iRtrn = 0;

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				using (SqlCommand cmd = new SqlCommand("sp_CreateUserAssignments", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@orgLevlelType", userId);
					cmd.Parameters.AddWithValue("@companyId", companyId);
					cmd.Parameters.AddWithValue("@accountId", accountId);
					cmd.Parameters.AddWithValue("@departmentId", departmentId);
					cmd.Parameters.AddWithValue("@groupId", groupId);
					cmd.Parameters.Add("@retVal");
					cmd.Parameters["@retVal"].Direction = ParameterDirection.ReturnValue;
					cmd.ExecuteNonQuery();
					iRtrn = Convert.ToInt32(cmd.Parameters["@retVal"].Value.ToString());
				}
			}
			return iRtrn;
		}

		public static int CreateMNUserPermissions(MNUser user)
		{
			int iRtrn = 0;

			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand("sp_CreateUserPermissions", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@orgLevlelType", user.UserId);

						foreach(string sPerm in user.Permissions.GetGrantedPermissions()) 
						{
							cmd.Parameters.AddWithValue("@" + sPerm, 1);
						}

						cmd.Parameters.Add("@retVal", SqlDbType.Int);
						cmd.Parameters["@retVal"].Direction = ParameterDirection.ReturnValue;
						cmd.ExecuteNonQuery();
						iRtrn = Convert.ToInt32(cmd.Parameters["@retVal"].Value.ToString());
					}
				}
			}
			catch (Exception ex) { var v = ex.Message; }

			return iRtrn;
		}

		public static string GetAccessLevelName(int accessLevel)
		{
			string sRtrn = string.Empty;
			using(SqlConnection conn = new SqlConnection(connString)) 
			{ 
				conn.Open();
				using(SqlCommand cmd = new("sp_GetAccessLevels", conn)) 
				{
					cmd.CommandType = CommandType.StoredProcedure;
					using(SqlDataReader reader = cmd.ExecuteReader())
					{
						while(reader.Read())
						{
							if (reader[0].Equals(accessLevel + 1)) 
							{ 
								sRtrn = reader[1].ToString();
								break;
							}
						}
					}
				}
				return sRtrn;
			}
		}

		public static List<string> GetAccessLevels()
		{
			List<string> list = new List<string>();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				using (SqlCommand cmd = new("sp_GetAccessLevels", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							list.Add(reader[1].ToString());
						}
					}
				}
				return list;
			}
		}

		public static bool CreateOrgLevel(int creatorId, string orgLevelDescription, frmMain.OrgLevelTypes orgLevelType, string orgLevelName, int parentId)
		{
			bool bRtrn = false;

			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand("sp_CreateOrgLevel", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@createdBy", creatorId);
						cmd.Parameters.AddWithValue("@orgLevelDescription", orgLevelDescription);
						var v = (int)orgLevelType;
						cmd.Parameters.AddWithValue("@orgLevelType", (int)orgLevelType);
						cmd.Parameters.AddWithValue("@orgLevelName", orgLevelName);
						cmd.Parameters.AddWithValue("@parentId", parentId);
						cmd.Parameters.Add("@retVal", SqlDbType.Int);
						cmd.Parameters["@retVal"].Direction = ParameterDirection.ReturnValue;
						cmd.ExecuteNonQuery();
						bRtrn = cmd.Parameters["@retVal"].Value.ToString() == "1";
					}
				}
			}
			catch (Exception ex) { var v = ex.Message; }

			return bRtrn;
		}

		public static List<Group> GetGroups(int userId)
		{
			List<Group> lstRtrn = new List<Group>();
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				using (SqlCommand cmd = new("sp_GetGroups"))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@orgLevlelType", userId);
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						foreach (DataRow row in reader)
						{
							lstRtrn.Add(new(row));
						}
					}
				}
			}
			return lstRtrn;
		}

		public static List<Department> GetDepartments(int userId)
		{
			List<Department> lstRtrn = new List<Department>();
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				using (SqlCommand cmd = new("sp_GetDepartments"))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@orgLevlelType", userId);
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						foreach (DataRow row in reader)
						{
							lstRtrn.Add(new(row));
						}
					}
				}
			}
			return lstRtrn;
		}

		public static List<Account> GetAccounts(int userId)
		{
			List<Account> lstRtrn = new List<Account>();
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				using (SqlCommand cmd = new("sp_GetAccounts"))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@orgLevlelType", userId);
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						foreach (DataRow row in reader)
						{
							lstRtrn.Add(new(row));
						}
					}
				}
			}
			return lstRtrn;
		}

		public static List<Company> GetCompanies(int userId)
		{
			List<Company> lstRtrn = new List<Company>();
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				using (SqlCommand cmd = new("sp_GetCompanies"))
				{
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@orgLevlelType", userId);
					using(SqlDataReader reader = cmd.ExecuteReader())
					{
						foreach (DataRow row in reader)
						{
							lstRtrn.Add(new(row));
						}
					}
				}
			}
			return lstRtrn;
		}

		public static List<ListItem> GetHighestNodeItemsForUser(int userId)
		{
			//List<TreeNode> lstRtrn = new List<TreeNode>();	
			//TreeNode node;
			DataTable dt = new DataTable();
			List<ListItem> lstRtrn = new List<ListItem>();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				using (SqlCommand cmd = new("sp_GetOrgLevelItems", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@userId", userId);

					SqlDataAdapter adapter = new SqlDataAdapter() { SelectCommand = cmd };
					adapter.Fill(dt);

					foreach(DataRow row in dt.Rows)
					{
						//lstBox.Items.Add(new ListItem() { Id = (int)row["Id"], Name = row["Name"].ToString() });
						lstRtrn.Add(new ListItem() { Id = (int)row["Id"], Name = row["Name"].ToString() });

						//node = new() { Tag = row["Id"].ToString(), Text = row["Name"].ToString().Trim(), ToolTipText = row["Description"].ToString() };
						//lstRtrn.Add(node);
					}
				}
			}

			return lstRtrn;
		}


		public static List<ListItem> GetOrgLevelChildren(int orgLevelId, int parentId) 
		{
			List<ListItem> lstRtrn = new List<ListItem>();
			TreeNode node;
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				using (SqlCommand cmd = new("sp_GetOrgLevelChildren", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@orgLevelId", orgLevelId);
					cmd.Parameters.AddWithValue("parentId", parentId);

					SqlDataAdapter adapter = new SqlDataAdapter() { SelectCommand = cmd };
					adapter.Fill(dt);

					foreach (DataRow row in dt.Rows)
					{
						lstRtrn.Add(new ListItem() { Id = (int)row["Id"], Name = row["Name"].ToString()});

						//node = new() { Tag = row["Id"].ToString(), Text = row["Name"].ToString().Trim(), Name = row["Name"].ToString().Trim(), ToolTipText = row["Description"].ToString() };
						//lstRtrn.Add(node);
					}
				}
			}

			return lstRtrn;
		}

		//public static List<NodeInfo> GetOrgLevelChildNodes(int orgLevelId, int parentId)
		//{
		//	List<NodeInfo> lstRtrn = new List<NodeInfo>();
		//	TreeNode node;
		//	DataTable dt = new DataTable();

		//	using (SqlConnection conn = new SqlConnection(connString))
		//	{
		//		conn.Open();
		//		using (SqlCommand cmd = new("sp_GetOrgLevelChildren", conn))
		//		{
		//			cmd.CommandType = CommandType.StoredProcedure;
		//			cmd.Parameters.AddWithValue("@orgLevelId", parentId);
		//			cmd.Parameters.AddWithValue("parentId", orgLevelId);

		//			SqlDataAdapter adapter = new SqlDataAdapter() { SelectCommand = cmd };
		//			adapter.Fill(dt);

		//			foreach (DataRow row in dt.Rows)
		//			{
		//				node = new() { Tag = row["Id"].ToString(), Text = row["Name"].ToString().Trim(), Name = row["Name"].ToString().Trim(), ToolTipText = row["Description"].ToString() };
		//				lstRtrn.Add(node);
		//			}
		//		}
		//	}

		//	return lstRtrn;
		//}


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

		//public static int CreateUser(myNotebooks.objects.MNUser usr)
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
		//			//cmd.Parameters.AddWithValue("@UserId", usr.UserId);
		//			//cmd.Parameters.AddWithValue("@DepartmentId", usr.DepartmentId);
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

		//public static Companies GetCompany(string companyId)
		//{
		//	Companies cRtrn = null;
		//	DataTable dt = new();

		//	using (SqlConnection conn = new(connString))
		//	{
		//		conn.Open();

		//		using (SqlCommand cmd = new("sp_GetCompany", conn))
		//		{
		//			cmd.CommandType = CommandType.StoredProcedure;
		//			cmd.Parameters.AddWithValue("@companyId", Convert.ToInt32(companyId));
		//			SqlDataAdapter adapter = new() { SelectCommand = cmd };
		//			adapter.Fill(dt);
		//			cRtrn = new Companies(dt);
		//		}
		//	}
			
		//	return cRtrn;
		//}

		
	}
}
