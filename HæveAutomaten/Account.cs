namespace HæveAutomaten
{
    public class Account
    {
        public Account(string name, string lastName, string accountNumber, string creditCardNumber, string pinCode, decimal balance)
        {
            Name = name;
            LastName = lastName;
            AccountNumber = accountNumber;
            CreditCardNumber = creditCardNumber;
            PinCode = pinCode;
            Balance = balance;
        }

        public override string ToString()
        {
            return Name + "," + LastName + "," + AccountNumber + "," + CreditCardNumber + "," + PinCode + "," + Balance;
        }

        public decimal Balance { get; set; }
        public string PinCode { get;  set; }
        public string Name { get;  set; }

        public string LastName { get;  set; }

        public string AccountNumber { get;  set; }

        public string CreditCardNumber { get;  set; }
    }
}