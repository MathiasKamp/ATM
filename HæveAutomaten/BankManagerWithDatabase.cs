namespace HæveAutomaten
{
    /// <summary>
    /// Class is used as a business layer between gui and database
    /// </summary>
    public class BankManagerWithDatabase
    {
        public static bool CreateAccount(string name, string lastName, decimal balance)
        {
            return DataManagerWithDatabase.CreateAccount(name, lastName, balance);
        }

        public static Account GetAccount(string name, string lastName)
        {
            return BankManagerWithDatabase.GetAccount(name, lastName);
        }

        public static Account WithDrawMoney(string name, string lastName, decimal amount)
        {
            return DataManagerWithDatabase.WithdrawMoney(name,lastName,amount);
        }
        
        public static Account DepositMoney(string name, string lastName, decimal amount)
        {
            return DataManagerWithDatabase.DepositMoney(name,lastName,amount);
        }
    }
}