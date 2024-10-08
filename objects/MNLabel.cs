﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MyNotebooks;
using MyNotebooks.DataAccess;
using MyNotebooks.objects;
using MyNotebooks.subforms;
using Newtonsoft.Json.Linq;

namespace MyNotebooks.objects
{
	public class MNLabel
	{
		public int		CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? EditedOn { get; set; }
		public int		ParentId { get; set; }
		public int		NotebookId { get; set; }
		//public int		DepartmentId { get; set; }
		//public int		GroupId { get; set; }
		//public int		AccountId { get; set; }

		public int		Id { get; set; }
		public string	LabelText { get; set; }
		public bool		IsActive { get; set; }

		public MNLabel() { }	

		public MNLabel(DataTable dt, int rowIndex = 0)
		{
			var value = "";
			var setProp = true;

			if(dt.Rows.Count > 0)
			{
				foreach (PropertyInfo sPropertyName in typeof(MNLabel).GetProperties())
				{
					if(sPropertyName.Name != "ParentId" & sPropertyName.Name != "NotebookId")
					{
						try
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
								bool b = dt.Rows[rowIndex].Field<bool>(sPropertyName.Name);
								this.GetType().GetProperty(sPropertyName.Name).SetValue(this, b.ToString() == "1");
								setProp = false;
							}

							if (setProp) { this.GetType().GetProperty(sPropertyName.Name).SetValue(this, value); }
							setProp = true;
						}
						catch (Exception ex)
						{
							if (ex.GetType() != typeof(InvalidCastException))
							{
								//if (sPropertyName.Name != "EditedOn" && sPropertyName.Name != "Id")
								//{
								//	using (frmMessage frm = new frmMessage(frmMessage.OperationType.Message, "The error '" + ex.Message + "' occurred while processing the " +
								//		"Label property '" + sPropertyName + "'.", "Error Occurred")) { frm.ShowDialog(); }
								//}
							}
						}
					}

					this.ParentId = this.Id;
					this.NotebookId = this.Id;
				}
			}
		}

		public SQLResult Create() { return GetOperationResult(DbAccess.CRUDLabel(this), true); }
		public SQLResult Update() { return GetOperationResult(DbAccess.CRUDLabel(this, OperationType.Update)); }
		public SQLResult Delete() { return GetOperationResult(DbAccess.CRUDLabel(this, OperationType.Delete)); }

		private SQLResult GetOperationResult(SQLResult result, bool isCreate = false)
		{
			if(isCreate)
			{
				if(result.strValue.Length == 0) { this.Id = result.intValue; }
			}
			else
			{
				if (result.strValue.Length > 0)
				{
					using (frmMessage frm = new(frmMessage.OperationType.Message, "An error occurred. '" + result.strValue + "'", "Error"))
					{ frm.ShowDialog(); }
				}
			}
			return result;
		}
	}
}
