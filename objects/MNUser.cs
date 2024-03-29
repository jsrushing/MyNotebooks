﻿/* 
 * Main user class. Guessing that ...
 * created 05/25/23
 * - jsr
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyNotebooks.DataAccess;
using MyNotebooks.subforms;
using MyNotebooks.objects;
using Newtonsoft.Json.Linq;

namespace MyNotebooks.objects
{
	public class MNUser
	{
		public int				AccessLevel { get; set; }
		public string			Email { get; set; }
		public bool				IsOriginator { get; private set; }
		public bool				IsActive { get; private set; }
		public string			Name { get; set; }
		public string			Password { get; set; }
		public int				Id { get; set; }
		public int				CreatedBy { get; set; }
		public DateTime			CreatedOn { get; set; }
		public DateTime?		EditedOn { get; set; }

		public List<Group>		Groups = new();
		public List<Department> Departments = new();
		public List<Account>	Accounts = new();
		public List<Company>	Companies = new();
		public List<OrgLevel>	OrgLevels = new();
		public List<MNUser>		Children = new();
		public List<Notebook>	Notebooks = new();

		public List<UserAssignments> Assignments { get; set; } = new();
		public UserPermissions		Permissions { get; set; } = new();

		public MNUser() { }

		public MNUser(int accessLevel, string name, string password, int userId, DateTime createdOn, DateTime? editedOn = null, bool isEnterprise = false)
		{
			AccessLevel = accessLevel;
			Id = userId;
			Name = name;
			//Password = password;
			//IsEnterprise = isEnterprise;
			CreatedOn = createdOn;
			EditedOn = editedOn;
		}

		public MNUser(DataTable dt, int rowIndex = 0)
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
							value = dt.Rows[rowIndex].Field<string>(sPropertyName.Name).ToString();
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(Int32))
						{
							int iVal = dt.Rows[rowIndex].Field<Int32>(sPropertyName.Name);
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, iVal);
							setProp = false;
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(DateTime))
						{
							DateTime dtime = Convert.ToDateTime(dt.Rows[rowIndex].Field<DateTime>(sPropertyName.Name));
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, dtime);
							setProp = false;
						}
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(bool))
						{
							bool b = dt.Rows[rowIndex].Field< bool>(sPropertyName.Name);
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, b.ToString() == "1");
							setProp = false;
						}

						if (setProp) { this.GetType().GetProperty(sPropertyName.Name).SetValue(this, value); }
						setProp = true;
					}
				}
				catch (Exception ex) 
				{
					if (ex.GetType() != typeof(InvalidCastException))
					{
						using(frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "The error '" + ex.Message + "' occurred while processing the " +
							"User property '" + sPropertyName + "'.", "Error Occurred")) { frm.ShowDialog(); }
					}
				}
			}

			//this.GetAllOrgLevels();
			if(dt.Rows.Count > 1) { AddChildUsers(dt); }
		}

		public async Task Create() { GetOperationResult(DbAccess.CRUDMNUser(this), true); }
		public async Task Update() { GetOperationResult(DbAccess.CRUDMNUser(this, OperationType.Update)); }
		public async Task Delete() { GetOperationResult(DbAccess.CRUDMNUser(this, OperationType.Delete)); }

		private void GetOperationResult(SQLResult result, bool isCreate = false)
		{
			if (isCreate)
			{
				if (result.strValue.Length == 0) { this.Id = result.intValue; }
			}
			else
			{
				if (result.strValue.Length > 0)
				{
					using (frmMessage frm = new(frmMessage.OperationType.Message, "An error occurred. '" + result.strValue + "'", "Error"))
					{ frm.ShowDialog(); }
				}
			}
		}

		private void AddChildUsers(DataTable dt)
		{
			var value = "";
			var setProp = false;

			for (int i = 1;i < dt.Rows.Count;i++)
			{
				MNUser usr = new MNUser();

				foreach (PropertyInfo sPropertyName in typeof(MNUser).GetProperties())
				{
					try
					{
						if (sPropertyName.Name != "Assignments" & sPropertyName.Name != "Permissions" & dt.Columns[sPropertyName.Name] != null)
						{
							if (dt.Columns[sPropertyName.Name].DataType == typeof(string))
							{
								value = dt.Rows[i].Field<string>(sPropertyName.Name).ToString();
							}
							else if (dt.Columns[sPropertyName.Name].DataType == typeof(Int32))
							{
								int iVal = dt.Rows[i].Field<Int32>(sPropertyName.Name);
								usr.GetType().GetProperty(sPropertyName.Name).SetValue(usr, iVal);
								setProp = false;
							}
							else if (dt.Columns[sPropertyName.Name].DataType == typeof(DateTime))
							{
								DateTime dtime = Convert.ToDateTime(dt.Rows[i].Field<DateTime>(sPropertyName.Name));
								usr.GetType().GetProperty(sPropertyName.Name).SetValue(usr, dtime);
								setProp = false;
							}
							else if (dt.Columns[sPropertyName.Name].DataType == typeof(bool))
							{
								bool b = dt.Rows[i].Field<bool>(sPropertyName.Name);
								usr.GetType().GetProperty(sPropertyName.Name).SetValue(usr, b.ToString() == "1");
								setProp = false;
							}

							if (setProp) { usr.GetType().GetProperty(sPropertyName.Name).SetValue(usr, value); }
							setProp = true;
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
				this.Children.Add(usr);
			}
		}

		public bool ContainsChild(MNUser child)
		{
			var v = this.Children.Where(e => e.Id == child.Id).FirstOrDefault();
			return v != null;
		}

		public bool Equals(MNUser userToCompare) { return this.Id == userToCompare.Id; }

		//public void GetAllOrgLevels()
		//{
		//	DataSet dataSet = DbAccess.GetUserOrgLevels(this.Id);

		//	for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		//	{ this.OrgLevels.Add(new(frmMain.OrgLevelTypes.Company, dataSet.Tables[0], i)); }	//  this.Companies.Add(new(dataSet.Tables[0], i)); }

		//	for (int i = 0; i < dataSet.Tables[1].Rows.Count; i++)
		//	{ this.OrgLevels.Add(new(frmMain.OrgLevelTypes.Account, dataSet.Tables[1], i)); }   // this.Accounts.Add(new(dataSet.Tables[1], i)); }

		//	for (int i = 0; i < dataSet.Tables[2].Rows.Count; i++)
		//	{ this.OrgLevels.Add(new(frmMain.OrgLevelTypes.Department, dataSet.Tables[2], i)); }   // this.Departments.Add(new(dataSet.Tables[2], i)); }

		//	for (int i = 0; i < dataSet.Tables[3].Rows.Count; i++)
		//	{ this.OrgLevels.Add(new(frmMain.OrgLevelTypes.Group, dataSet.Tables[3], i)); }   // this.Groups.Add(new(dataSet.Tables[3], i)); }
		//}

		public bool HasPermission(UserPermissions.Permissions permission)
		{
			return Convert.ToBoolean(this.Permissions.GetType().GetProperty(permission.ToString()).GetValue(this.Permissions, null));
		}

		public void SaveAssignments() { DbAccess.CreateMNUserAssignments(this); }

		public void SavePermissions() { DbAccess.CreateMNUserPermissions(this);  }

		
	}
}
