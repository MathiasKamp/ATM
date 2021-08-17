namespace HæveAutomaten
{
    /// <summary>
    /// Class i used as a business layer between gui and database
    /// </summary>
    public class BankManager
    {
        public static bool CreateAccount(string name, string lastName, decimal balance)
        {
            return DatabaseManager.CreateAccount(name, lastName, balance);
        }

        public static Account GetAccount(string name, string lastName)
        {
            return DatabaseManager.GetAccount(name, lastName);
        }

        public static Account WithDrawMoney(string name, string lastName, decimal amount)
        {
            return DatabaseManager.WithdrawMoney(name,lastName,amount);
        }
        
        public static Account DepositMoney(string name, string lastName, decimal amount)
        {
            return DatabaseManager.DepositMoney(name,lastName,amount);
        }
    }
}