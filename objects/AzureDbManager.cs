using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Text;
using Azure.ResourceManager.Sql;
using System.Data;
using System.Data.SqlClient;
using Org.BouncyCastle.Crypto.Agreement;

namespace MyNotebooks.objects
{
	internal class AzureDbManager
	{
		private string _ConnectionString = ConfigurationManager.AppSettings["azconnstring"];

		public AzureDbManager() { }

		public bool CreateAccount(string companyName)
		{
			bool bRtrn;

			using(SqlConnection conn = new SqlConnection(_ConnectionString))
			{
				conn.Open();
				using (SqlCommand cmd = new SqlCommand("sp_CreateAccount", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@companyName",  companyName);
					cmd.Parameters.Add(new SqlParameter("@return", SqlDbType.TinyInt));
					cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;
					cmd.ExecuteNonQuery();
					bRtrn = cmd.Parameters["@return"].Value.ToString() == "1";
				}
			}

			return bRtrn;
		}
	}
}
