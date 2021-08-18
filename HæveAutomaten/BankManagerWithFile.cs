namespace HæveAutomaten
{
    /// <summary>
    /// Class is used as a business layer between gui and the DataManagerWithFile.cs
    /// </summary>
    public class BankManagerWithFile
    {
        public static Account CreateAccount(string name, string lastName, decimal balance, string pinCode)
        {
            return DataManagerWithFile.CreateAccount(name, lastName, balance, pinCode);
        }

        public static void AddNewAccount(Account account)
        {
            DataManagerWithFile.AddNewAccount(account);
        }
        

        public static Account GetValidatedAccount (string name, string lastName, string pinCode)
        {
            return DataManagerWithFile.ValidatedAccountReturned(name, lastName, pinCode);
        }

        public static void WithDrawMoney(string name, string lastName, decimal amount)
        {
            DataManagerWithFile.WithdrawMoney(name, lastName, amount);
        }

        public static void DepositMoney(string name, string lastName, decimal amount)
        {
            DataManagerWithFile.DepositMoney(name, lastName, amount);
        }
    }
}