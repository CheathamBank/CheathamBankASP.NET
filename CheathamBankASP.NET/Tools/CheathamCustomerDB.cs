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

        public static Objects.Customer GetCustomer(int primaryKey)
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

        public static bool AddDeposit(Objects.Deposit newDeposit)
        {
            SqlConnection c = GetConnection();

            string insertStatement = "INSERT INTO [Transaction] " +
                "(TransactionNumber, CustAccountNumber, TransactionType, " +
                "Date, TransactionAmount) " +
                "VALUES (@TransactionNumber, @CustAccountNumber, @TransactionType, @Date, @TransactionAmount)";


            SqlCommand insertCommand = new SqlCommand(insertStatement, c);

            insertCommand.Parameters.AddWithValue("@TransactionNumber", newDeposit.TransNumber);
            insertCommand.Parameters.AddWithValue("@CustAccountNumber", newDeposit.CustAccountNumber);
            insertCommand.Parameters.AddWithValue("@TransactionType", newDeposit.TransType);
            insertCommand.Parameters.AddWithValue("@Date", newDeposit.Date);
            insertCommand.Parameters.AddWithValue("@TransactionAmount", newDeposit.Amount);

            try
            {
                c.Open();

                int count = insertCommand.ExecuteNonQuery();
                
                if(count > 0)
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

        public static DataTable GetTransactions(string monthID, int custID)
        {

            SqlConnection c = GetConnection();

            string selectStatement = "SELECT * " +
                "FROM [Transaction] " +
                "WHERE [Date] >= @upperBoundDate AND [Date] < @lowerBoundDate AND CustAccountNumber = @custID";

            SqlCommand selectCommand = new SqlCommand(selectStatement, c);
            DateTime date = new DateTime();
                date = System.DateTime.Today;
            
            int lowerBoundMonth = Convert.ToInt32(monthID);
            lowerBoundMonth++;


            string upperBoundDate = monthID.ToString() + "/" + "01" + "/" + date.Year.ToString();
            string lowerBoundDate = lowerBoundMonth.ToString() + "/" + "01" + "/" + date.Year.ToString();

            selectCommand.Parameters.AddWithValue("@upperBoundDate", upperBoundDate);
            selectCommand.Parameters.AddWithValue("@lowerBoundDate", lowerBoundDate);
            selectCommand.Parameters.AddWithValue("@custID", custID);

            try
            {
                c.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
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

        public static string GetMonthID(string month)
        {
            SqlConnection c = GetConnection();

            string selectStatement = "SELECT MonthID " +
                "FROM Months " +
                "WHERE MonthName = @month";

            SqlCommand selectCommand = new SqlCommand(selectStatement, c);

            selectCommand.Parameters.AddWithValue("@month", month);

            try
            {
                c.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                if (reader.Read())
                {
                    string monthID = reader["MonthID"].ToString();
                    return monthID;
                }
                return null;
            }
            catch(SqlException ex)
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