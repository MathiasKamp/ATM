using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace HæveAutomaten
{
    /// <summary>
    /// this class is used together with the class library "HæveAutomaten.Tests" because i could't test on my database
    /// </summary>
    public class DataManagerWithFile
    {
        private static StringBuilder sb;

        private static Random r;

        private  const string Path = @".\outPut";
        private const string PathAndFile = Path + @"\accounts.csv";


        /// <summary>
        /// This method returns a random number
        /// </summary>
        /// <param name="max"></param>
        /// <returns>String</returns>
        public static string GenerateRandomNumber(int max)
        {
            sb = new StringBuilder();
            r = new Random();


            bool isInt = max % 1 == 0;

            if (isInt)
            {
                while (sb.Length < max)
                {
                    sb.Append(r.Next(10).ToString());
                }
            }


            return sb.ToString();
        }

        /// <summary>
        /// this method creates a file directory and a file within that directory
        /// </summary>
        private static void CreateFile()
        {
            if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);
            File.Create(PathAndFile).Close();
        }
        
        /// <summary>
        /// This Method Withdraws money from the clients Account
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="amount"></param>
        public static void WithdrawMoney(string name, string lastName, decimal amount)
        {
            List<Account> accounts = GetAllAccounts();
            Account acc = GetSpecificAccount(name, lastName);
            decimal newBalance = acc.Balance - amount;
            acc.Balance = newBalance;
            AddAccountToList(accounts, acc);
            List<string> str = ConvertAccountListToCsvFormat(accounts);
            File.WriteAllLines(PathAndFile, str);
        }

        /// <summary>
        /// this method adds money to the clients account
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="amount"></param>
        public static void DepositMoney(string name, string lastName, decimal amount)
        {
            List<Account> accounts = GetAllAccounts();
            Account acc = GetSpecificAccount(name, lastName);
            decimal newBalance = acc.Balance + amount;
            acc.Balance = newBalance;
            AddAccountToList(accounts, acc);
            List<string> str = ConvertAccountListToCsvFormat(accounts);
            File.WriteAllLines(PathAndFile, str);
        }

        /// <summary>
        /// this method adds a new account to the file
        /// </summary>
        /// <param name="account"></param>
        public static void AddNewAccount(Account account)
        {
            CreateFile();
            List<Account> accounts = GetAllAccounts();
            AddAccountToList(accounts, account);
            List<string> str = ConvertAccountListToCsvFormat(accounts);
            File.WriteAllLines(PathAndFile, str);
        }


        /// <summary>
        /// this method Creates a new Account
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="balance"></param>
        /// <returns>Account</returns>
        /// <exception cref="ArgumentException"></exception>
        public static Account CreateAccount(string name, string lastName, decimal balance, string pinCode)
        {
            string accountNumber = GenerateRandomNumber(10);
            string cardNumber = GenerateRandomNumber(16);


            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("You passed in an invalid parameter", "name");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("You passed in an invalid parameter", "lastName");
            }

            if (balance <= 0)
            {
                throw new ArgumentException("balance can't be less than 0", "balance");
            }


            Account acc = new Account(name, lastName, accountNumber, cardNumber, pinCode, balance);

            return acc;
        }

        /// <summary>
        /// this method adds the new account to the List
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="account"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void AddAccountToList(List<Account> accounts, Account account)
        {
            if (string.IsNullOrWhiteSpace(account.Name))
            {
                throw new ArgumentException("You passed in an invalid parameter", nameof(account.Name));
            }

            if (string.IsNullOrWhiteSpace(account.LastName))
            {
                throw new ArgumentException("You passed in an invalid parameter", nameof(account.LastName));
            }

            if (account.Balance <= 0)
            {
                throw new ArgumentException("You passed in an invalid parameter", nameof(account.Balance));
            }

            accounts.Add(account);
        }

        /// <summary>
        /// this method Converts a List<Account> to a List<string>
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public static List<string> ConvertAccountListToCsvFormat(List<Account> accounts)
        {
            List<string> output = new List<string>();
            foreach (Account acc in accounts)
            {
                output.Add($"{acc}");
            }

            return output;
        }

        /// <summary>
        /// this method returns a specific account to the client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <returns>Account</returns>
        private static Account GetSpecificAccount(string name, string lastName)
        {
            List<Account> accounts = GetAllAccounts();
            Account tmpAcc = null;
            foreach (Account account in accounts)
            {
                if (account.Name == name && account.LastName == lastName)
                {
                    tmpAcc = account;
                }
            }

            return tmpAcc;
        }

        public static Account ValidatedAccountReturned(string name, string lastName, string pinCode)
        {
            Account acc = GetSpecificAccount(name, lastName);

            if (!ValidatePinCode(acc, pinCode))
            {
                throw new ArgumentException("The pinCode is incorrect", "pinCode");
            }

            return acc;
            
        }

        public static bool ValidatePinCode(Account account, string pinCode)
        {
            bool isCorrect = account.PinCode == pinCode;

            return isCorrect;
        }

        /// <summary>
        /// this method Gets all accounts from the file and return them 
        /// </summary>
        /// <returns>List<Account></returns>
        public static List<Account> GetAllAccounts()
        {
            List<Account> output = new List<Account>();
            string[] content = File.ReadAllLines(PathAndFile);

            foreach (string str in content)
            {
                string[] data = str.Split(',');

                output.Add(new Account(data[0], data[1], data[2], data[3], data[4], decimal.Parse(data[5])));
            }

            return output;
        }
    }
}