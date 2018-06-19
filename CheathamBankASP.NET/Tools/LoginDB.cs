using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CheathamBankASP.NET.Tools
{
    public class LoginDB
    {
        private static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CheathamCustomer"].ConnectionString);
            return connection;
        }
        public static int? authenticateUser (string user)
        {
            SqlConnection c = GetConnection();

            string selectStatement = "SELECT CustID " +
                "FROM Login WHERE Username = @User";

            SqlCommand selectCommand = new SqlCommand(selectStatement, c);

            selectCommand.Parameters.AddWithValue("@User", user);

            try
            {
                c.Open();
                SqlDataReader loginReader = selectCommand.ExecuteReader();
                int? custID;

                if (loginReader.Read())
                {
                    custID = Convert.ToInt32(loginReader["CustID"]);
                }
                else
                {
                    custID = null;
                }

                return custID;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }
        }

        public static bool authenticatePassword(int custID, string password)
        {
            SqlConnection c = GetConnection();

            string selectStatement = "SELECT password " +
                "FROM Login WHERE CustID = @CustID";

            SqlCommand selectCommand = new SqlCommand(selectStatement, c);

            selectCommand.Parameters.AddWithValue("@CustID", custID);

            try
            {
                c.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                if (reader.Read())
                {
                   string storedPassword = reader["password"].ToString();

                    if (storedPassword == password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch  (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }
        }
    }
}