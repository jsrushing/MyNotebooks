using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Org.BouncyCastle.Crypto.Agreement;
using Encryption;

namespace MyNotebooks.objects
{
	internal class AzureDbManager
	{
		private string _ConnectionString = ConfigurationManager.AppSettings["azconnstring"];

		public AzureDbManager() { }

		public bool CreateAccount(string companyName, string accountName, string accountPIN)
		{
			bool bRtrn;

			using(SqlConnection conn = new SqlConnection(_ConnectionString))
			{
				conn.Open();
				using (SqlCommand cmd = new SqlCommand("sp_CreateAccount", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@CompanyName", EncryptDecrypt.Encrypt(companyName, accountPIN));
					cmd.Parameters.AddWithValue("@AccountName", EncryptDecrypt.Encrypt(accountName, accountPIN));
					cmd.Parameters.AddWithValue("@AccountPIN", EncryptDecrypt.Encrypt(accountPIN, accountPIN));
					cmd.Parameters.Add(new SqlParameter("@return", SqlDbType.Bit));
					cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;
					cmd.ExecuteNonQuery();
					bRtrn = cmd.Parameters["@return"].Value.ToString() == "1";
				}
			}

			return bRtrn;
		}

		public bool CreateCompany(string name, string PIN)
		{
			bool bRtrn;

			using (SqlConnection conn = new SqlConnection(_ConnectionString))
			{
				conn.Open();
				using (SqlCommand cmd = new SqlCommand("sp_CreateCompany", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@CompanyName", EncryptDecrypt.Encrypt(name, PIN));
					cmd.Parameters.Add(new SqlParameter("@return", SqlDbType.Bit));
					cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;
					cmd.ExecuteNonQuery();
					bRtrn = cmd.Parameters["@return"].Value.ToString() == "1";
				}
			}

			return bRtrn;
		}
		public bool CreateGroup(string groupName, string accountName, string companyName, string accountPIN, string companyPIN, string groupPIN)
		{
			bool bRtrn;

			using (SqlConnection conn = new SqlConnection(_ConnectionString))
			{
				conn.Open();
				using (SqlCommand cmd = new SqlCommand("sp_CreateGroup", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@CompanyName", EncryptDecrypt.Encrypt(companyName, companyPIN));
					cmd.Parameters.AddWithValue("@AccountName", EncryptDecrypt.Encrypt(accountName, accountPIN));
					cmd.Parameters.AddWithValue("@GroupName", EncryptDecrypt.Encrypt(groupName, groupPIN));
					cmd.Parameters.Add(new SqlParameter("@return", SqlDbType.Bit));
					cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;
					cmd.ExecuteNonQuery();
					bRtrn = cmd.Parameters["@return"].Value.ToString() == "1";
				}
			}

			return bRtrn;
		}

		public bool CreateUser(string userName, string PIN)
		{
			bool bRtrn = false;

			using (SqlConnection conn = new SqlConnection(_ConnectionString))
			{
				conn.Open();
				using (SqlCommand cmd = new SqlCommand("sp_CreateUser", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@UserName", EncryptDecrypt.Encrypt(userName, PIN));
					cmd.Parameters.Add(new SqlParameter("@return", SqlDbType.Bit));
					cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;
					cmd.ExecuteNonQuery();
					bRtrn = cmd.Parameters["@return"].Value.ToString() == "1";
				}
			}

			return bRtrn;
		}

		public bool GetCompany(string companyName, string PIN)
		{
			bool bRtrn = false;

			using (SqlConnection conn = new SqlConnection(_ConnectionString))
			{
				using (SqlCommand cmd = new SqlCommand("sp_GetCompany", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@CompanyName", EncryptDecrypt.Encrypt(companyName, PIN));
					cmd.Parameters.Add("@return", SqlDbType.Bit);
					cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;
					bRtrn = cmd.Parameters["@return"].Value.ToString().Length > 0;
				}
			}

			return bRtrn;
		}

		public User GetUser(string userName, string PIN)
		{
			User user = null;

			using(SqlConnection conn = new SqlConnection(_ConnectionString))
			{
				using(SqlCommand cmd = new SqlCommand("sp_GetUser", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@UserName", EncryptDecrypt.Encrypt(userName, PIN));
					cmd.Parameters.Add("@return", SqlDbType.Bit);
					cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;
					user = cmd.Parameters["@return"].Value.ToString().Length > 0 ? new User(userName) : null;
				}
			}

			return user;
		}


	}
}
