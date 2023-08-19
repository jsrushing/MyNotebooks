/* Handle Db access.
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.CompilerServices;

namespace myNotebooks.DataAccess
{
	public enum OperationType
	{ Create = 1, Update = 2, Delete = 3 }

	internal class DbAccess
	{
//		private static string connString = "Server=mynotebooksserver.database.windows.net;Database=myNotebooks;user id=mydb_admin;password=cloud_Bringer1!";
		private static string connString = "Server=FORRESTSTNW;Database=MyNotebooks;Trusted_Connection = true";

		public static bool			CRUDLabel(MNLabel label, Entry entry, OperationType opType = OperationType.Create)
		{
			bool bRtrn = false;

			try
			{
				using (SqlConnection conn = new(connString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand("sp_CRUD_Label", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@labelText",label.LabelText);
						cmd.Parameters.AddWithValue("@entryId", entry.Id);
						cmd.Parameters.AddWithValue("@opType",	opType == OperationType.Delete ? 2 : (int)opType);
						if (opType == OperationType.Create)		cmd.Parameters.AddWithValue("@createdBy", Program.User.UserId);
						if (opType == OperationType.Delete)		cmd.Parameters.AddWithValue("isActive", 0); 
						cmd.ExecuteNonQuery();
					}
				}
				bRtrn = true;
			}
			catch { }

			return bRtrn;
		}

		public static int			CRUDMNUser(MNUser user, OperationType opType = OperationType.Create)
		{
			int iRtrn = 0;
			try
			{
				using (SqlConnection conn = new(connString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand("sp_CRUD_User", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@userName",	user.Name);
						cmd.Parameters.AddWithValue("@password",	user.Password);
						cmd.Parameters.AddWithValue("@accessLevel", user.AccessLevel);
						cmd.Parameters.AddWithValue("@email",		user.Email);
						cmd.Parameters.AddWithValue("@opType",		opType == OperationType.Delete ? 2 : (int)opType);
						if (opType == OperationType.Create) cmd.Parameters.AddWithValue("@createdBy", Program.User.UserId);
						if (opType != OperationType.Create) cmd.Parameters.AddWithValue("@userId", Program.User.UserId);
						if (opType == OperationType.Delete) cmd.Parameters.AddWithValue("isActive", 0);
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

		public static bool			CreateMNUserAssignments(MNUser user)
		{
			var bRtrn = false;

			using (SqlConnection conn = new(connString))
			{
				conn.Open();

				try
				{
					foreach(UserAssignments ua in user.Assignments)
					{
						using (SqlCommand cmd = new SqlCommand("sp_CRUD_UserAssignments", conn))
						{
							cmd.CommandType = CommandType.StoredProcedure;
							cmd.Parameters.AddWithValue("@userId", ua.UserId);
							if (ua.orgType == UserAssignments.OrgType.Company)		cmd.Parameters.AddWithValue("@companyId",		ua.CompanyId);
							if (ua.orgType == UserAssignments.OrgType.Account)		cmd.Parameters.AddWithValue("@accountId",		ua.AccountId);
							if (ua.orgType == UserAssignments.OrgType.Department)	cmd.Parameters.AddWithValue("@departmentId",	ua.DepartmentId);
							if (ua.orgType == UserAssignments.OrgType.Group)		cmd.Parameters.AddWithValue("@groupId",			ua.GroupId);
							//cmd.Parameters.Add("@retVal");
							//cmd.Parameters["@retVal"].Direction = ParameterDirection.ReturnValue;
							cmd.ExecuteNonQuery();
							bRtrn = true;
						}
					}
				}
				catch { bRtrn = false; }

			}
			return bRtrn;
		}

		public static int			CreateMNUserPermissions(MNUser user)
		{
			int iRtrn = 0;

			try
			{
				using (SqlConnection conn = new(connString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand("sp_CRUD_UserPermissions", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@userId", user.UserId);

						foreach(string sPerm in user.Permissions.GetGrantedPermissions()) 
						{ cmd.Parameters.AddWithValue("@" + sPerm, 1); }

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

		public static int			CRUDNotebook(Notebook nb, OperationType opType = OperationType.Create)
		{
			int iRtrn = 0;

			using (SqlConnection conn = new(connString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_CRUD_Notebook", conn))	
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@description", nb.Description);
					cmd.Parameters.AddWithValue("@name",		nb.Name);
					cmd.Parameters.AddWithValue("@pin",			nb.PIN);
					cmd.Parameters.AddWithValue("@opType",		opType == OperationType.Delete ? 2 : (int)opType);
					if (opType == OperationType.Create)			cmd.Parameters.AddWithValue("@createdBy", Program.User.UserId);
					if (opType == OperationType.Create)			cmd.Parameters.AddWithValue("@parentId", nb.ParentId);
					if (opType == OperationType.Delete)			cmd.Parameters.AddWithValue("isActive", 0);
					cmd.Parameters.Add("@retVal", SqlDbType.Int);
					cmd.Parameters["@retVal"].Direction = ParameterDirection.ReturnValue;
					cmd.ExecuteNonQuery();
					iRtrn = Convert.ToInt32(cmd.Parameters["@retVal"].Value.ToString());
				}
			}

			return iRtrn;
		}

		public static int			CRUDNotebookEntry(Entry entry, OperationType opType = OperationType.Create)
		{
			int iRtrn = 0;

			using (SqlConnection conn = new(connString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_CRUD_NotebookEntry", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@RTF",			entry.RTF);
					cmd.Parameters.AddWithValue("@text",		entry.Text);
					cmd.Parameters.AddWithValue("@title",		entry.Title);
					cmd.Parameters.AddWithValue("@opType",		opType == OperationType.Delete ? 2: (int)opType);
					if (opType == OperationType.Create)			cmd.Parameters.AddWithValue("@createdBy"	, Program.User.UserId);
					if (opType == OperationType.Create)			cmd.Parameters.AddWithValue("@parentId"		, entry.ParentId);
					if (opType != OperationType.Create)			cmd.Parameters.AddWithValue("@entryId"		, entry.Id);
					if (opType == OperationType.Delete)			cmd.Parameters.AddWithValue("isActive"		, 0);
					cmd.Parameters.Add("@retVal", SqlDbType.Int);
					cmd.Parameters["@retVal"].Direction = ParameterDirection.ReturnValue;
					cmd.ExecuteNonQuery();
					iRtrn = Convert.ToInt32(cmd.Parameters["@retVal"].Value.ToString());
				}
			}

			return iRtrn;
		}

		public static bool			CRUDOrgLevel(int creatorId, string orgLevelDescription
										, frmMain.OrgLevelTypes orgLevelType, string orgLevelName, int parentId, OperationType opType = OperationType.Create)
		{
			bool bRtrn = false;

			try
			{
				using (SqlConnection conn = new(connString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand("sp_CRUD_OrgLevel", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@parentId",			parentId);
						cmd.Parameters.AddWithValue("@createdBy",			creatorId);
						cmd.Parameters.AddWithValue("@orgLevelType",		(int)orgLevelType);
						cmd.Parameters.AddWithValue("@orgLevelName",		orgLevelName.Trim());
						cmd.Parameters.AddWithValue("@orgLevelDescription", orgLevelDescription.Trim());
						cmd.Parameters.AddWithValue("@opType",				(int)opType);
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

		public static string		GetAccessLevelName(int accessLevel)
		{
			string sRtrn = string.Empty;
			using(SqlConnection conn = new(connString)) 
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

		public static List<string>	GetAccessLevels()
		{
			List<string> list = new List<string>();

			using (SqlConnection conn = new(connString))
			{
				conn.Open();
				using (SqlCommand cmd = new("sp_GetAccessLevels", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{ list.Add(reader[1].ToString()); }
					}
				}
				return list;
			}
		}

		public static List<MNLabel> GetLabels(int entryId)
		{
			List<MNLabel> lstRtrn = new List<MNLabel>();

			using (SqlConnection conn = new(connString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetLabels", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@entryId", entryId);

					using(SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							MNLabel lbl = new()
							{
								CreatedBy	= reader.GetInt32	("CreatedBy")
								, CreatedOn = reader.GetDateTime("CreatedOn")
								, EditedOn	= reader.GetDateTime("EditedOn")
								, LabelText = reader.GetString	("LabelText")
								, EntryId	= reader.GetInt32	("EntryId")
								, IsActive	= reader.GetBoolean	("IsActive")
							};

							lstRtrn.Add(lbl);
						}
					}
				}
			}

			return lstRtrn;
		}

		public static Entry			GetNBEntryFullTextAndTitle(int entryId, Entry entryToComplete) 
		{
			using (SqlConnection conn = new(connString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetNBEntryFullTextAndTitle", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@entryId", entryId);

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							entryToComplete.Text = reader.GetString("Text");
							entryToComplete.RTF = reader.GetString("RTF");
						}
					}
				}
			}

			return entryToComplete;
		}

		public static Notebook		GetNotebookWithShortEntries(int parentId, string name) 
		{
			Notebook nbRtrn = null;
			DataTable dt = new();

			using (SqlConnection conn = new(connString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetNotebook", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@Id", parentId);
					cmd.Parameters.AddWithValue("@name", name);
					SqlDataAdapter sda = new() { SelectCommand = cmd };
					sda.Fill(dt);
					nbRtrn = new Notebook(dt);

					// get the entries
					dt = new();
					cmd.Parameters.Clear();
					cmd.CommandText = "sp_GetNotebookEntries_ShortText";
					cmd.Parameters.AddWithValue("@notebookId", parentId);
					sda.SelectCommand = cmd;
					sda.Fill(dt);

					for(int i = 0; i < dt.Rows.Count; i++)
					{
						Entry entry = new(dt, i);
						//entry.ParentId = nbRtrn.Id;

						try 
						{ 
							var v = dt.Rows[i].Field<DateTime?>("EditedOn").ToString(); 
							if (v != null) { entry.EditedOn = DateTime.Parse(v); }
						}
						catch(Exception e) 
						{ 
							if(e.GetType() != typeof(System.FormatException))	// 'v' was not a valid datetime
							{
								using (frmMessage frm = new(frmMessage.OperationType.Message, 
									"An error occurred getting shortend Entries. " + e.Message, "Error!")) { frm.ShowDialog(); }
							}
						}

						nbRtrn.Entries.Add(entry);	
					}
				}
			}

			return nbRtrn;
		}

		public static List<Entry>	GetNotebookEntries(int notebookId)
		{
			List<Entry> lstRtrn = new List<Entry>();
			DataTable dt = new DataTable();

			using (SqlConnection conn = new(connString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetNotebookEntries", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@notebookId", notebookId);
					SqlDataAdapter sda = new() { SelectCommand = cmd };
					sda.Fill(dt);
				}
			}

			foreach(DataRow dr in dt.Rows) { lstRtrn.Add(new(dt));	}
			return lstRtrn;
		}

		public static List<Notebook> GetNotebookNamesAndIdsForGroup(int groupId)
		{
			List<Notebook> lstReturn = new List<Notebook>();

			using (SqlConnection conn = new(connString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetNotebookNamesAndIds", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@groupId", groupId);
					
					using(SqlDataReader  reader = cmd.ExecuteReader())
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								Notebook nb = new Notebook() 
								{
									Id	 = reader.GetInt32	("Id"),
									Name = reader.GetString	("Name")
								};

								lstReturn.Add(nb);
							}	
						}
					}
				}
			}

			return lstReturn;
		}

		public static List<ListItem> GetOrgLevelChildren(int orgLevelId, int parentId) 
		{
			List<ListItem> lstRtrn = new List<ListItem>();
			//TreeNode node;
			DataTable dt = new();

			using (SqlConnection conn = new(connString))
			{
				conn.Open();
				using (SqlCommand cmd = new("sp_GetOrgLevelChildren", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@orgLevelId", orgLevelId);
					cmd.Parameters.AddWithValue("parentId", parentId);
					SqlDataAdapter adapter = new () { SelectCommand = cmd };
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

		public static List<ListItem> GetTopLevelItemsForUser(int userId)
		{
			//List<TreeNode> lstRtrn = new List<TreeNode>();	
			//TreeNode node;
			DataTable dt = new();
			List<ListItem> lstRtrn = new List<ListItem>();

			using (SqlConnection conn = new(connString))
			{
				conn.Open();
				using (SqlCommand cmd = new("sp_GetOrgLevelItems", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@userId", userId);

					using (SqlDataAdapter da = new() { SelectCommand = cmd }) { da.Fill(dt); }

					foreach (DataRow row in dt.Rows)
					{
						lstRtrn.Add(new ListItem() { Id = (int)row["Id"], Name = row["Name"].ToString() });
						//node = new() { Tag = row["Id"].ToString(), Text = row["Name"].ToString().Trim(), ToolTipText = row["Description"].ToString() };
						//lstRtrn.Add(node);
					}
				}
			}

			return lstRtrn;
		}

		public static DataSet		GetUserOrgLevels(int userId)
		{
			DataSet ds = new();

			using(SqlConnection conn = new(connString))
			{
				conn.Open();

				using(SqlCommand cmd = new SqlCommand("sp_GetOrgLevelAssignmentsForUser", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@userId", userId);
					using (SqlDataAdapter da = new() { SelectCommand = cmd }) { da.Fill(ds); }
				}
			}

			return ds;
		}

		//public static List<Company> GetCompanies(int userId)
		//{
		//	List<Company> lstReturn = new List<Company>();
		//	DataTable dt = new();

		//	using (SqlConnection conn = new(connString))
		//	{
		//		conn.Open();
		//		using (SqlCommand cmd = new("sp_GetCompanies"))
		//		{
		//			cmd.CommandType = CommandType.StoredProcedure;
		//			cmd.Parameters.AddWithValue("@userId", userId);
		//			using (SqlDataAdapter da = new() { SelectCommand = cmd }) { da.Fill(dt); }
		//			foreach(DataRow row in dt.Rows) { lstReturn.Add(new(row)); }
		//		}
		//	}

		//	return lstReturn;
		//}

		//public static List<Account> GetAccounts(int userId)
		//{
		//	List<Account>lstReturn = new List<Account>();
		//	DataTable dt = new();

		//	using (SqlConnection conn = new(connString))
		//	{
		//		conn.Open();
		//		using(SqlCommand cmd = new("sp_GetAccounts"))
		//		{
		//			cmd.CommandType= CommandType.StoredProcedure;
		//			cmd.Parameters.AddWithValue("@userId", userId);
		//			using (SqlDataAdapter da = new() { SelectCommand = cmd }) { da.Fill(dt); }
		//			foreach (DataRow row in dt.Rows) { lstReturn.Add(new(row)); }
		//		}
		//	}

		//	return lstReturn;
		//}

		//public static List<Department> GetDepartments(int userId)
		//{
		//	List<Department> lstReturn = new List<Department>();
		//	DataTable dt = new();

		//	using (SqlConnection conn = new(connString))
		//	{
		//		conn.Open();
		//		using (SqlCommand cmd = new("sp_GetDepartments"))
		//		{
		//			cmd.CommandType = CommandType.StoredProcedure;
		//			cmd.Parameters.AddWithValue("@userId", userId);
		//			using (SqlDataAdapter da = new() { SelectCommand = cmd }) { da.Fill(dt); }
		//			foreach (DataRow row in dt.Rows) { lstReturn.Add(new(row)); }
		//		}
		//	}

		//	return lstReturn;
		//}

		//public static List<Group> GetGroups(int userId)
		//{
		//	List<Group> lstReturn = new List<Group>();
		//	DataTable dt = new();

		//	using (SqlConnection conn = new(connString))
		//	{
		//		conn.Open();
		//		using (SqlCommand cmd = new("sp_GetGroups"))
		//		{
		//			cmd.CommandType = CommandType.StoredProcedure;
		//			cmd.Parameters.AddWithValue("@userId", userId);
		//			using (SqlDataAdapter da = new() { SelectCommand = cmd }) { da.Fill(dt); }
		//			foreach (DataRow row in dt.Rows) { lstReturn.Add(new(row)); }
		//		}
		//	}

		//	return lstReturn;
		//}

		public static DataSet		GetUser(string userName, string password)
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
					cmd.Parameters.AddWithValue("@password", v);
					SqlDataAdapter adapter = new() { SelectCommand = cmd } ;
					adapter.Fill(ds);
				}
			}
			return ds;
		}
	}
}
