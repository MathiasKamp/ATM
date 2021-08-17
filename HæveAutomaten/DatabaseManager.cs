using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace HæveAutomaten
{
    /// <summary>
    /// class is used to get information from database
    /// </summary>
    public class DatabaseManager
    {
        private static StringBuilder sb;
        private static Random r;
        private static readonly string Con = DbConnection.dbCon();
        private static SqlDataReader rdr;

        /// <summary>
        /// method returns a random number
        /// </summary>
        /// <param name="max"></param>
        /// <returns>string</returns>
        public static string GenerateRandomNumber(int max)
        {
            sb = new StringBuilder();
            r = new Random();

            while (sb.Length < max)
            {
                sb.Append(r.Next(10).ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// method withdraws a specific amount from the clients account
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="amount"></param>
        /// <returns>Account</returns>
        public static Account WithdrawMoney(string name, string lastName, decimal amount)
        {
            Account account = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(Con))
                {
                    try
                    {
                        connection.Open();

                        SqlCommand sql = new SqlCommand("sp_WithDrawMoney", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };


                        sql.Parameters.Add(new SqlParameter("@name", name));
                        sql.Parameters.Add(new SqlParameter("@lastName", lastName));
                        sql.Parameters.Add(new SqlParameter("@amount", amount));

                        sql.ExecuteNonQuery();

                        account = GetAccount(name, lastName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    finally
                    {
                        connection?.Close();

                        rdr?.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return account;
        }


        /// <summary>
        /// Method adds a specific amount to the clients Account
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Account DepositMoney(string name, string lastName, decimal amount)
        {
            Account account = null;
            try
            {
                // update db
                using (SqlConnection connection = new SqlConnection(Con))
                {
                    try
                    {
                        connection.Open();

                        SqlCommand sql = new SqlCommand("sp_DepositMoney", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };


                        sql.Parameters.Add(new SqlParameter("@name", name));
                        sql.Parameters.Add(new SqlParameter("@lastName", lastName));
                        sql.Parameters.Add(new SqlParameter("@amount", amount));

                        sql.ExecuteNonQuery();

                        account = GetAccount(name, lastName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    finally
                    {
                        connection?.Close();

                        rdr?.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return account;
        }

        /// <summary>
        /// Method returns a specific account from the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <returns>Account</returns>
        public static Account GetAccount(string name, string lastName)
        {
            Account account = null;

            using (SqlConnection connection = new SqlConnection(Con))
            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand("sp_GetAccount", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    sql.Parameters.Add(new SqlParameter("@name", name));
                    sql.Parameters.Add(new SqlParameter("@lastName", lastName));


                    rdr = sql.ExecuteReader();

                    while (rdr.Read())
                    {
                        string fName = (string)rdr["name"];
                        string lName = (string)rdr["lastName"];
                        string accountNumber = (string)rdr["accountNumber"];
                        string cardNumber = (string)rdr["cardNumber"];
                        string pinCode = (string)rdr["pinCode"];
                        decimal balance = (decimal)rdr["balance"];

                        account = new Account(fName, lName, accountNumber, cardNumber, pinCode, balance);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                finally
                {
                    connection?.Close();

                    rdr?.Close();
                }
            }

            return account;
        }

        /// <summary>
        /// Method creates an account in the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="balance"></param>
        /// <returns>Bool</returns>
        public static bool CreateAccount(string name, string lastName, decimal balance)
        {
            bool accountAdded = false;
            using (SqlConnection connection = new SqlConnection(Con))
            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand("sp_CreateAccount", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    string accountNumber = GenerateRandomNumber(10);
                    string cardNumber = GenerateRandomNumber(16);
                    string pinCode = GenerateRandomNumber(4);


                    sql.Parameters.Add(new SqlParameter("@name", name));
                    sql.Parameters.Add(new SqlParameter("@lastName", lastName));
                    sql.Parameters.Add(new SqlParameter("@accountNumber", accountNumber));
                    sql.Parameters.Add(new SqlParameter("@cardNumber", cardNumber));
                    sql.Parameters.Add(new SqlParameter("@pinCode", pinCode));
                    sql.Parameters.Add(new SqlParameter("@balance", balance));

                    sql.ExecuteNonQuery();
                    accountAdded = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                finally
                {
                    connection?.Close();
                }
            }

            return accountAdded;
        }
    }
}