/* 
 * Main user class. Guessing that ...
 * created 05/25/23
 * - jsr
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using myNotebooks.DataAccess;
using myNotebooks.subforms;
using Newtonsoft.Json.Linq;

namespace myNotebooks.objects
{
	public class MNUser
	{
		public int				AccessLevel { get; set; }
		public string			Email { get; set; }
		public bool				IsOriginator { get; private set; }
		public bool				IsActive { get; private set; }
		public string			Name { get; set; }
		public string			Password { get; set; }
		public int				UserId { get; set; }
		public int				CreatedBy { get; set; }
		public DateTime			CreatedOn { get; set; }
		public DateTime?		EditedOn { get; set; }

		public List<Group>		Groups = new();
		public List<Department> Departments = new();
		public List<Account>	Accounts = new();
		public List<Company>	Companies = new();
		public List<MNUser>		Children = new();

		public List<UserAssignments> Assignments { get; set; } = new();
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
						else if (dt.Columns[sPropertyName.Name].DataType == typeof(bool))
						{
							bool b = dt.Rows[0].Field< bool>(sPropertyName.Name);
							this.GetType().GetProperty(sPropertyName.Name).SetValue(this, b.ToString() == "1");
							setProp = false;
						}

						if (setProp) { this.GetType().GetProperty(sPropertyName.Name).SetValue(this, value); }
						setProp = true;
					}

					//this.GetGroups();
					//this.GetAccounts();
					//this.GetDepartments();
					//this.GetCompanies();
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

			if(dt.Rows.Count > 1) { AddChildUsers(dt); }
		}

		//public void CreateSimpleUser() { this.UserId = DbAccess.CreateMNUser(this); }

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
							using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "The error '" + ex.Message + "' occurred while processing the " +
								"property '" + sPropertyName + "'.", "Error Occurred")) { frm.ShowDialog(); }
						}
					}	
				}
				this.Children.Add(usr);
			}
		}

		public bool ContainsChild(MNUser child)
		{
			var v = this.Children.Where(e => e.UserId == child.UserId).FirstOrDefault();
			return v != null;
		}

		public void Delete() { DbAccess.DeleteUser(this.UserId); }

		public bool Equals(MNUser userToCompare) { return this.UserId == userToCompare.UserId; }

		private void GetGroups() { this.Groups = DbAccess.GetGroups(this.UserId); }

		private void GetDepartments() { this.Departments = DbAccess.GetDepartments(this.UserId); }

		private void GetAccounts() { this.Accounts = DbAccess.GetAccounts(this.UserId); }

		private void GetCompanies() { this.Companies = DbAccess.GetCompanies(this.UserId); }

		public void SaveAssignments() { DbAccess.CreateMNUserAssignments(this); }

		public void SavePermissions() { DbAccess.CreateMNUserPermissions(this);  }
	}
}
