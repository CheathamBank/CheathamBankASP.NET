using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CheathamBankASP.NET.Tools
{
    public class CheathamCustomerDB
    {
        private static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CheathamCustomer"].ConnectionString);

            return connection;
        }

        public static Objects.Customer GetCustomer(string primaryKey)
        {
            SqlConnection c = GetConnection();

            string selectStatement = "SELECT CustName, CustPhone, CustAddress, CustCity, CustState, CustZip " +
                "FROM CheathamCustomer " +
                "WHERE CustAccountNumber = @CustAccountNumber";

            SqlCommand selectCommand = new SqlCommand(selectStatement, c);

            selectCommand.Parameters.AddWithValue("@CustAccountNumber", primaryKey);

            try
            {
                c.Open();

                SqlDataReader customerReader = selectCommand.ExecuteReader();

                if (customerReader.Read())
                {
                    Objects.Customer customer = new Objects.Customer();

                    customer.AccountNumber = Convert.ToInt32(primaryKey);
                    customer.Name = customerReader["CustName"].ToString();
                    customer.PhoneNumber = customerReader["CustPhone"].ToString();
                    customer.Address = customerReader["CustAddress"].ToString();
                    customer.City = customerReader["CustCity"].ToString();
                    customer.State = customerReader["CustState"].ToString();
                    customer.Zip = Convert.ToInt32(customerReader["CustZip"]);

                    return customer;
                }
                else
                {
                    return null;
                }

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

        public static bool  UpdateCustomer(Objects.Customer customer)
        {
            SqlConnection c = GetConnection();

            string updateStatement = "UPDATE CheathamCustomer SET CustName = @CustName, CustPhone = @CustPhone, CustAddress = @CustAddress, " +
                "CustCity = @CustCity, CustZip = @CustZip WHERE CustAccountNumber = @CustAccountNumber";

            SqlCommand updateCommand = new SqlCommand(updateStatement, c);

            updateCommand.Parameters.AddWithValue("@CustName", customer.Name);
            updateCommand.Parameters.AddWithValue("@CustPhone", customer.PhoneNumber);
            updateCommand.Parameters.AddWithValue("@CustAddress", customer.Address);
            updateCommand.Parameters.AddWithValue("@CustCity", customer.City);
            updateCommand.Parameters.AddWithValue("@CustZip", customer.Zip);

            updateCommand.Parameters.AddWithValue("@CustAccountNumber", customer.AccountNumber);

            try
            {
                c.Open();

               int count = updateCommand.ExecuteNonQuery();

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
    }
}