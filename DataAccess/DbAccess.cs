/* Handle Db access.
 * created 07/12/23
 * - jsr
 */
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using Encryption;
using Microsoft.Data.SqlClient;
using MyNotebooks.objects;
using MyNotebooks.subforms;

namespace MyNotebooks.DataAccess
{
	public enum OperationType
	{ Create = 1, Update = 2, Delete = 3 }

	internal class DbAccess
	{
		//private static string connString = "Server=mynotebooksserver.database.windows.net;Database=MyNotebooks;user id=mydb_admin;password=cloud_Bringer1!";
		//private static string connString = "Server=FORRESTSTNW;Database=MyNotebooks;Trusted_Connection = true";
		//private static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\js_ru\\source\\repos\\MyNotebooks\\localMyNotebooksDb.mdf;Integrated Security=True";

		public static SQLResult		CRUDLabel(MNLabel label, OperationType opType = OperationType.Create)
		{
			SQLResult rtrn = new();

			try
			{
				using (SqlConnection conn = new(Program.ConnectionString))
				{
					conn.Open();
					using (SqlCommand cmd = new("sp_CRUD_Label", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@labelText",label.LabelText);
						cmd.Parameters.AddWithValue("@parentId", label.ParentId);
						cmd.Parameters.AddWithValue("@opType",	opType == OperationType.Delete ? 2 : (int)opType);
						if (opType == OperationType.Create)		cmd.Parameters.AddWithValue("@createdBy",	Program.User.Id);
						if (opType != OperationType.Create)		cmd.Parameters.AddWithValue("@labelId",		label.Id);
						if (opType == OperationType.Delete)		cmd.Parameters.AddWithValue("isActive",		0);
						GetSqlReturn(ref rtrn, cmd);
					}
				}
			}
			catch { }

			return rtrn;
		}

		public static SQLResult		CRUDMNUser(MNUser user, OperationType opType = OperationType.Create)
		{
			SQLResult rtrn = new();

			try
			{
				using (SqlConnection conn = new(Program.ConnectionString))
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
						if (opType == OperationType.Create) cmd.Parameters.AddWithValue("@createdBy", Program.User.Id);
						if (opType != OperationType.Create) cmd.Parameters.AddWithValue("@userId", Program.User.Id);
						if (opType == OperationType.Delete) cmd.Parameters.AddWithValue("isActive", 0);
						GetSqlReturn(ref rtrn, cmd);
					}
				}
			}
			catch (Exception ex) { var v = ex.Message; }

			return rtrn;
		}

		public static bool			CreateMNUserAssignments(MNUser user)
		{
			var bRtrn = false;

			using (SqlConnection conn = new(Program.ConnectionString))
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
				using (SqlConnection conn = new(Program.ConnectionString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand("sp_CRUD_UserPermissions", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@userId", user.Id);

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

		public static SQLResult		CRUDNotebook(Notebook nb, OperationType opType = OperationType.Create)
		{
			SQLResult rtrn = new();

			using (SqlConnection conn = new(Program.ConnectionString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_CRUD_Notebook", conn))	
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@description", nb.Description);
					cmd.Parameters.AddWithValue("@name",		nb.Name);
					cmd.Parameters.AddWithValue("@pin",			nb.PIN.Length > 0 ? nb.PIN : null);
					cmd.Parameters.AddWithValue("@opType",		opType == OperationType.Delete ? 2 : (int)opType);
					if (opType == OperationType.Create)			cmd.Parameters.AddWithValue("@createdBy", Program.User.Id);
					if (opType == OperationType.Create)			cmd.Parameters.AddWithValue("@parentId", nb.ParentId);
					if (opType != OperationType.Create)			cmd.Parameters.AddWithValue("@notebookId", nb.Id);
					if (opType == OperationType.Delete)			cmd.Parameters.AddWithValue("isActive", 0);
					GetSqlReturn(ref rtrn, cmd);
				}

				if(opType == OperationType.Create && nb.Entries.Count > 0)	// Creating a restored notebook. See enhancement 011b.
				{
					foreach (var entry in nb.Entries)
					{
						entry.ParentId = rtrn.intValue;
						CRUDNotebookEntry(entry, OperationType.Create);
					}
				}
			}

			return rtrn;
		}

		public static SQLResult		CRUDNotebookEntry(Entry entry, OperationType opType = OperationType.Create)
		{
			SQLResult rtrn = new();

			using (SqlConnection conn = new(Program.ConnectionString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_CRUD_NotebookEntry", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					if(entry.LabelsToRemove != null)
					{ cmd.Parameters.AddWithValue("@labelsToRemove", entry.LabelsToRemove); }
					else
					{
						cmd.Parameters.AddWithValue("@RTF",		entry.RTF);
						cmd.Parameters.AddWithValue("@text",	entry.Text);
						cmd.Parameters.AddWithValue("@title",	entry.Title);
						cmd.Parameters.AddWithValue("@opType",	opType == OperationType.Delete ? 2: (int)opType);
					}

					if (opType == OperationType.Create)			cmd.Parameters.AddWithValue("@createdBy",	Program.User.Id);
					if (opType == OperationType.Create)			cmd.Parameters.AddWithValue("@parentId"		, entry.ParentId);
					if (opType != OperationType.Create)			cmd.Parameters.AddWithValue("@entryId"		, entry.Id);
					if (opType == OperationType.Delete)			cmd.Parameters.AddWithValue("isActive"		, 0);
					GetSqlReturn(ref rtrn, cmd);
				}
			}

			return rtrn;
		}

		public static SQLResult		CRUDOrgLevel(OrgLevel orgLevel, OperationType opType = OperationType.Create)
		{
			SQLResult rtrn = new();

			try
			{
				using (SqlConnection conn = new(Program.ConnectionString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand("sp_CRUD_OrgLevel", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@parentId", orgLevel.ParentId);
						cmd.Parameters.AddWithValue("@createdBy", orgLevel.CreatedBy);
						cmd.Parameters.AddWithValue("@orgLevelType", (int)orgLevel.OrgLevelType);
						cmd.Parameters.AddWithValue("@orgLevelName", orgLevel.Name.Trim());
						cmd.Parameters.AddWithValue("@orgLevelDescription", orgLevel.Description.Trim());
						if (opType != OperationType.Create) cmd.Parameters.AddWithValue("orgId", orgLevel.Id);
						GetSqlReturn(ref rtrn, cmd);
					}
				}
			}
			catch (Exception ex) { var v = ex.Message; }

			return rtrn;
		}

		public static List<string>	GetAccessLevels()
		{
			List<string> list = new();

			using (SqlConnection conn = new(Program.ConnectionString))
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

		public static Entry			GetEntry(int entryId)
		{
			Entry entryRtrn = new();
			DataSet ds = new();
			DataTable dt = new();

			using (SqlConnection conn = new(Program.ConnectionString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetEntry", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@entryId", entryId);
					SqlDataAdapter sda = new() { SelectCommand = cmd };
					sda.Fill(ds);
					entryRtrn = new(ds.Tables[0]);
					DataTable tblLabels = ds.Tables[1];

					for (int i2 = 0; i2 < tblLabels.Rows.Count; i2++)
					{ entryRtrn.AllLabels.Add(new(tblLabels, i2)); }

				}
			}

			return entryRtrn;
		}

		public static List<KeyValuePair<int, string>> GetEntryParentTree(int entryId)
		{
			List<KeyValuePair<int, string>> lstRtrn = new();
			DataSet ds = new();

			using (SqlConnection conn = new(Program.ConnectionString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetEntryParents", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@entryId", entryId);
					SqlDataAdapter sda = new() { SelectCommand = cmd };
					sda.Fill(ds);
					foreach(DataTable dt in ds.Tables)
					{
						lstRtrn.Add(new(Convert.ToInt32(dt.Rows[0]["Id"].ToString()), dt.Rows[0]["Name"].ToString()));
					}
				}
			}

			return lstRtrn;
		}

		//public static List<Entry>	GetEntriesCreatedByUser()
		//{
		//	try
		//	{
		//		List<Entry> entries = new();
		//		DataTable dt = new();

		//		using (SqlConnection conn = new(Program.ConnectionString))
		//		{
		//			conn.Open();

		//			using (SqlCommand cmd = new("sp_GetEntriesCreatedByUser", conn))
		//			{
		//				cmd.CommandType = CommandType.StoredProcedure;
		//				cmd.Parameters.AddWithValue("@userId", Program.User.Id);
		//				SqlDataAdapter sda = new() { SelectCommand = cmd };
		//				sda.Fill(dt);

		//				for (int i = 0; i < dt.Rows.Count; i++)
		//				{
		//					entries.Add(new(dt, i));
		//				}
		//			}
		//		}
		//		return entries;
		//	}
		//	catch { return null; }
		//}

		public static List<Entry>	GetEntriesInNotebook(int notebookId)
		{
			try
			{
				List<Entry> entries = new();
				DataSet ds = new();
				Entry entry = null;

				using (SqlConnection conn = new(Program.ConnectionString))
				{
					conn.Open();
					 
					using (SqlCommand cmd = new("sp_GetEntriesForNotebook", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@notebookId", notebookId);
						SqlDataAdapter sda = new() { SelectCommand = cmd };
						sda.Fill(ds);
						DataTable tblEntries = ds.Tables[0];
						DataTable tblLabels = ds.Tables[1];
						//List<MNLabel> labels = new();

						for (int i = 0; i < tblEntries.Rows.Count; i++)
						{
							entry = new(tblEntries, i);

							for (int i2 = 0; i2 < tblLabels.Rows.Count; i2++)
							{ entry.AllLabels.Add(new(tblLabels, i2)); }

							entries.Add(entry);
						}
					}
				}
				return entries;
			}
			catch { return null; }
		}

		public static List<Entry>	GetEntriesWithLabel(MNLabel label)
		{
			List<Entry> entries = new();
			DataTable dt = new();

			using (SqlConnection conn = new(Program.ConnectionString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetEntriesWithLabel", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@labelText", label.LabelText);
					SqlDataAdapter sda = new() { SelectCommand = cmd };
					sda.Fill(dt);

					for(int i = 0; i < dt.Rows.Count; i++)
					{
						entries.Add(new(dt, i));
					}
				}
			}

			return entries;
		}

		public static KeyValuePair<MNLabel, MNUser> GetLabel(int labelId)
		{
			KeyValuePair<MNLabel, MNUser>  kvpRtrn = new();
			DataSet dataSet = new();

			using (SqlConnection conn = new(Program.ConnectionString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetLabelAndUser", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@labelId", labelId);
					SqlDataAdapter sda = new() { SelectCommand = cmd };
					sda.Fill(dataSet);

					kvpRtrn = new KeyValuePair<MNLabel, MNUser>(new(dataSet.Tables[0], 0), new(dataSet.Tables[1], 0));
				}
			}

			return kvpRtrn;
		}

		public static void			PopulateLabelsInAllNotebooks()
		{
			//DataTable dt = new DataTable();
			Program.LblsInAllNotebooks.Clear();

			try
			{
				using (SqlConnection conn = new(Program.ConnectionString))
				{
					conn.Open();
					using (SqlCommand cmd = new("sp_GetAllLabels", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						using SqlDataReader reader = cmd.ExecuteReader();
						{
							while (reader.Read())
							{ Program.LblsInAllNotebooks.Add(reader.GetString(0)); }
						}
					}
				}

			}
			catch (Exception ex) { }
		}

		public static List<MNLabel> GetLabelsForEntry(int entryId)
		{
			List<MNLabel> lstRtrn = new();
			DataTable dataTable = new();

			using (SqlConnection conn = new(Program.ConnectionString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetLabelsForEntry", conn))	// THIS IS WHERE TO ADD PARENTPATH FOR SHORT ENTRY DISPLAY ON frmMain !1!
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@entryId", entryId);

					SqlDataAdapter sda = new() { SelectCommand = cmd };
					sda.Fill(dataTable);

					for(int i = 0; i < dataTable.Rows.Count; i++)
					{
						lstRtrn.Add(new(dataTable, i));
					}
				}
			}

			return lstRtrn;
		}

		public static List<string> GetLabelsForNotebook(int notebookId)
		{
			List<string> lstRtrn = new();

			try
			{
				using (SqlConnection conn = new(Program.ConnectionString))
				{
					conn.Open();
					using (SqlCommand cmd = new("sp_GetLabelsForNotebook", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@notebookId", notebookId);

						using SqlDataReader reader = cmd.ExecuteReader();
						{
							while (reader.Read())
							{ lstRtrn.Add(reader.GetString(0)); }
						}
					}
				}

			}
			catch (Exception ex) { }

			return lstRtrn;
		}

		public static List<MNLabel> GetLabelsUnderOrgLevel(int entryId, int orgLevel, string[] currentLabels = null)
		{
			List<MNLabel> lstRtrn = new();
			DataTable dataTable = new();

			using (SqlConnection conn = new(Program.ConnectionString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetLabelsUnderOrgLevel", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@entryId", entryId);
					cmd.Parameters.AddWithValue("@orgLevel", orgLevel);

					SqlDataAdapter sda = new() { SelectCommand = cmd };
					sda.Fill(dataTable);

					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						if (currentLabels != null)
						{
							var value = dataTable.Rows[i][0];

							if (!currentLabels.Contains(dataTable.Rows[i][0].ToString()))
							{
								lstRtrn.Add(new(dataTable, i));
							}
						}
						else { lstRtrn.Add(new(dataTable, i)); }
					}
				}
			}

			return lstRtrn;
		}

		public static List<Notebook> GetNotebooksUnderOrgLevel(frmMain.OrgLevelTypes orgLevel, string orgLevelIds)
		{
			try
			{
				List<Notebook> notebooks = new();
				DataTable dt = new();

				using (SqlConnection conn = new(Program.ConnectionString))
				{
					conn.Open();

					using (SqlCommand cmd = new("sp_GetNotebooksUnderOrgLevel", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@orgLevel", (int)orgLevel);
						cmd.Parameters.AddWithValue("@orgLevelIds", orgLevelIds);
						SqlDataAdapter sda = new() { SelectCommand = cmd };
						sda.Fill(dt);

						for (int i = 0; i < dt.Rows.Count; i++)
						{
							notebooks.Add(new(dt, i));
						}
					}
				}
				return notebooks;
			}
			catch { return null; }
		}

		public static Notebook		GetNotebook_OptionalEntries(int notebookId, bool getEntries = true) 
		{
			Notebook nbRtrn = null;
			DataTable dt = new();

			using (SqlConnection conn = new(Program.ConnectionString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetNotebook", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@Id", notebookId);
					SqlDataAdapter sda = new() { SelectCommand = cmd };
					sda.Fill(dt);
					nbRtrn = new Notebook(dt);

					// get the entries
					if (getEntries)
					{
						PopulateNotebookEntries(ref nbRtrn);
					}
				}
			}

			return nbRtrn;
		}

		public static void			PopulateNotebooksByUserAndDescendants(bool getEntries)
		{
			List<OrgLevel> lstRtrn = new();
			DataTable dt = new();

			try
			{
				using (SqlConnection conn = new(Program.ConnectionString))
				{
					conn.Open();
					using (SqlCommand cmd = new("sp_GetNotebooksCreatedByUser", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@userId", Program.User.Id);
						SqlDataAdapter adapter = new() { SelectCommand = cmd };
						adapter.Fill(dt);

						foreach (DataRow dr in dt.Rows)
						{
							Notebook nb = new(dt);
							if (getEntries) { PopulateNotebookEntries(ref nb); }
							Program.User.Notebooks.Add(nb);
						}
					}
				}

			}
			catch (Exception ex) { }
		}

		public static void			PopulateNotebookEntries(ref Notebook notebook)	// also populates Program.LblsUnderNotebook!
		{
			DataTable dt = new();
			DataSet ds = new();
			Entry entry = null;
			notebook.Entries.Clear();
			Program.LblsUnderNotebook.Clear();

			using (SqlConnection conn = new(Program.ConnectionString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetEntriesForNotebook", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@notebookId", notebook.Id);
					SqlDataAdapter sda = new() { SelectCommand = cmd };
					sda.Fill(ds);
					DataTable tblEntries = ds.Tables[0];

					for (int i = 0; i < tblEntries.Rows.Count; i++)
					{
						entry = new(tblEntries, i);
						notebook.Entries.Add(entry);
						Program.LblsUnderNotebook.AddRange(entry.AllLabels.Where(l => !Program.LblsUnderNotebook.Select(l => l.LabelText).ToList().Contains(l.LabelText)));
					}
				}
			}
		}

		public static List<Notebook> GetNotebookNamesAndIdsForGroup(int groupId)
		{
			List<Notebook> lstReturn = new List<Notebook>();

			using (SqlConnection conn = new(Program.ConnectionString))
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

		public static List<Notebook> GetAllNotebookNamesAndIds()
		{
			List<Notebook> lstReturn = new List<Notebook>();

			using (SqlConnection conn = new(Program.ConnectionString))
			{
				conn.Open();

				using (SqlCommand cmd = new("sp_GetAllNotebookNamesAndIds", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								Notebook nb = new Notebook()
								{
									Id = reader.GetInt32("Id"),
									Name = reader.GetString("Name")
								};

								lstReturn.Add(nb);
							}
						}
					}
				}
			}

			return lstReturn;
		}

		public static List<ListItem> GetOrgLevels()
		{
			List<ListItem> list = new();

			using (SqlConnection conn = new(Program.ConnectionString))
			{
				conn.Open();
				using (SqlCommand cmd = new("sp_GetOrgLevels", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{ list.Add(new() { Id = Convert.ToInt32(reader["Id"]), Name = reader["Name"].ToString() }); }
					}
				}
				return list;
			}
		}

		public static List<OrgLevel> GetOrgLevelItemsAvailableToUser(frmMain.OrgLevelTypes orgLevelType) 
		{ 
			List<OrgLevel> lstRtrn = new();
			DataTable dt = new();

			using (SqlConnection conn = new(Program.ConnectionString))
			{
				conn.Open();
				using (SqlCommand cmd = new("sp_GetOrgLevelItemsAvailableToUser", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@orgLevelType", (int)orgLevelType);
					cmd.Parameters.AddWithValue("@userId", Program.User.Id);
					SqlDataAdapter adapter = new() { SelectCommand = cmd };
					adapter.Fill(dt);

					foreach (DataRow row in dt.Rows)
					{
						OrgLevel ol = new() { OrgLevelType = orgLevelType, Name = row["Name"].ToString(), Id = Convert.ToInt32(row["Id"].ToString()),
							Description = row["description"].ToString(), CreatedBy = Convert.ToInt32(row["CreatedBy"].ToString()),
							CreatedOn = DateTime.Parse(row["CreatedOn"].ToString())};

						try { ol.EditedOn = DateTime.Parse(row["EditedOn"].ToString()); }
						catch { }

						lstRtrn.Add(ol);

						//lstRtrn.Add(new ListItem() { Id = (int)row["Id"], Name = row["Name"].ToString() });

						//node = new() { Tag = row["Id"].ToString(), Text = row["Name"].ToString().Trim(), Name = row["Name"].ToString().Trim(), ToolTipText = row["Description"].ToString() };
						//lblRtrn.Add(node);
					}
				}
			}

			return lstRtrn;
		}

		public static List<ListItem> GetOrgLevelChildren(int orgLevelId, int parentId) 
		{
			List<ListItem> lstRtrn = new List<ListItem>();
			//TreeNode node;
			DataTable dt = new();

			using (SqlConnection conn = new(Program.ConnectionString))
			{
				conn.Open();
				using (SqlCommand cmd = new("sp_GetOrgLevelChildren", conn))
				{  
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@orgLevelId", orgLevelId);
					cmd.Parameters.AddWithValue("@parentId", parentId);
					cmd.Parameters.AddWithValue("@userId", Program.User.Id);
					SqlDataAdapter adapter = new () { SelectCommand = cmd };
					adapter.Fill(dt);
					foreach (DataRow row in dt.Rows)
					{
						lstRtrn.Add(new ListItem() { Id = (int)row["Id"], Name = row["Name"].ToString()});

						//node = new() { Tag = row["Id"].ToString(), Text = row["Name"].ToString().Trim(), Name = row["Name"].ToString().Trim(), ToolTipText = row["Description"].ToString() };
						//lblRtrn.Add(node);
					}
				}
			}

			return lstRtrn;
		}

		private static void			 GetSqlReturn(ref SQLResult sqlReturn, SqlCommand cmd)
		{
			using (SqlDataReader rdr = cmd.ExecuteReader())
			{
				if (rdr.HasRows)
				{
					rdr.Read();

					sqlReturn.intValue = Convert.ToInt32(rdr.GetValue(0).ToString());
					sqlReturn.strValue = rdr.GetValue(1).ToString();
				}
			}
		}

		public static List<ListItem> GetTopLevelItemsForUser(int userId)
		{
			//List<TreeNode> lblRtrn = new List<TreeNode>();	
			//TreeNode node;
			DataTable dt = new();
			List<ListItem> lstRtrn = new List<ListItem>();

			using (SqlConnection conn = new(Program.ConnectionString))
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
						//lblRtrn.Add(node);
					}
				}
			}

			return lstRtrn;
		}

		//public static DataSet		GetUserOrgLevels(int userId)
		//{
		//	DataSet ds = new();

		//	using(SqlConnection conn = new(Program.ConnectionString))
		//	{
		//		conn.Open();

		//		using(SqlCommand cmd = new SqlCommand("sp_GetOrgLevelAssignmentsForUser", conn))
		//		{
		//			cmd.CommandType = CommandType.StoredProcedure;
		//			cmd.Parameters.AddWithValue("@userId", userId);
		//			using (SqlDataAdapter da = new() { SelectCommand = cmd }) { da.Fill(ds); }
		//		}
		//	}

		//	return ds;
		//}

		//public static List<SelectedCompanyName> GetCompanies(int userId)
		//{
		//	List<SelectedCompanyName> lstReturn = new List<SelectedCompanyName>();
		//	DataTable dt = new();

		//	using (SqlConnection conn = new(Program.ConnectionString))
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

		//	using (SqlConnection conn = new(Program.ConnectionString))
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

		//	using (SqlConnection conn = new(Program.ConnectionString))
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

		//	using (SqlConnection conn = new(Program.ConnectionString))
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

		public static DataSet		 GetUser(string userName, string password)
		{
			DataSet ds = new();

			using(SqlConnection conn = new(Program.ConnectionString))
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

	public struct SQLResult
	{
		public int intValue;
		public string strValue;
	}
}
