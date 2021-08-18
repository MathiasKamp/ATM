using System;
using System.Threading;

namespace HæveAutomaten
{
    internal static class Program
    {
        #region Main program to be runned when using a database

        /*
        public static void Main()
        {
            Gui gui = new Gui();

            gui.Menu();

            bool start = false;

            while (!start)
            {
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        gui.AlreadyHaveAccount();
                        userInput = int.Parse(Console.ReadLine());
                        switch (userInput)
                        {
                            case 1:
                                Console.Write("first name:");
                                string fName = Console.ReadLine();
                                Console.Write("last name :");
                                string lName = Console.ReadLine();
                                Account acc = BankManagerWithDatabase.GetAccount(fName, lName);
                                Console.WriteLine("your balance :" + acc.Balance);
                                Thread.Sleep(2000);
                                Console.Clear();
                                gui.Menu();
                                break;
                            case 2:
                                Console.Clear();
                                Console.Write("first name :");
                                string fname = Console.ReadLine();
                                Console.Write("LastName :");
                                string lastname = Console.ReadLine();
                                Console.Write("amunt to withdraw : ");
                                decimal amount = decimal.Parse(Console.ReadLine() ?? string.Empty);
                                Account account1 = BankManagerWithDatabase.WithDrawMoney(fname, lastname, amount);
                                Console.Clear();
                                Console.WriteLine("new balance :" + account1.Balance);
                                Thread.Sleep(3000);
                                Console.Clear();
                                gui.Menu();
                                break;
                            case 3:
                                Console.Clear();
                                Console.Write("first name :");
                                string firstname = Console.ReadLine();
                                Console.Write("LastName :");
                                string lname = Console.ReadLine();
                                Console.Write("amunt to withdraw : ");
                                decimal amountToDeposit = decimal.Parse(Console.ReadLine() ?? string.Empty);
                                Account account2 = BankManagerWithDatabase.DepositMoney(firstname, lname, amountToDeposit);
                                Console.Clear();
                                Console.WriteLine("new balance :" + account2.Balance);
                                Thread.Sleep(3000);
                                Console.Clear();
                                gui.Menu();
                                break;
                            default:
                                Console.WriteLine("not valid number");
                                Console.Clear();
                                gui.Menu();
                                break;
                        }

                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("name :");
                        string name = Console.ReadLine();
                        Console.Write("lastname :");
                        string lastName = Console.ReadLine();
                        Console.Write("balance :");
                        decimal balance = decimal.Parse(Console.ReadLine() ?? string.Empty);
                        bool accountAdded = BankManagerWithDatabase.CreateAccount(name, lastName, balance);
                        if (accountAdded)
                        {
                            Console.Clear();
                            Console.WriteLine("account added");
                            Account acc = BankManagerWithDatabase.GetAccount(name, lastName);
                            Console.WriteLine("your account is : ");
                            Console.WriteLine(acc.ToString());
                            Thread.Sleep(3000);
                            Console.Clear();
                            gui.Menu();
                        }

                        break;
                    default:
                        Console.WriteLine("not valid number");
                        Console.Clear();
                        gui.Menu();
                        break;
                }
            }
        }
        */

        #endregion

        public static void Main()
        {
            Gui gui = new Gui();
            
            gui.Menu();

            bool start = false;

           

            while (!start)
            {
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1: // already have an account
                        Console.Clear();
                        gui.AlreadyHaveAccount();
                        userInput = int.Parse(Console.ReadLine());
                        switch (userInput)
                        {
                            case 1:
                                Console.Clear();
                                Console.Write("reading creditCard...");
                                Thread.Sleep(1000);
                                Console.Clear();
                                Console.WriteLine("pinCode :");
                                string pinCode  = Console.ReadLine();
                                Console.Write("first name :");
                                string fName = Console.ReadLine();
                                Console.Write("last name :");
                                string lName = Console.ReadLine();
                                Account account1 = BankManagerWithFile.GetValidatedAccount(fName, lName, pinCode);
                                Console.WriteLine("your balance :" + account1.Balance);
                                Thread.Sleep(2000);
                                Console.Clear();
                                gui.Menu();
                                break;
                            case 2:
                                Console.Clear();
                                Console.Write("reading creditCard...");
                                Thread.Sleep(1000);
                                Console.Clear();
                                Console.WriteLine("pinCode :");
                                pinCode  = Console.ReadLine();
                                Console.Write("first name :");
                                fName = Console.ReadLine();
                                Console.Write("last name :");
                                lName = Console.ReadLine();
                                Account account2 = BankManagerWithFile.GetValidatedAccount(fName, lName, pinCode);
                                Console.Clear();
                                Console.WriteLine("your current balance is :" + account2.Balance);
                                Console.Write("Amount to withdraw :");
                                decimal amount = decimal.Parse(Console.ReadLine() ?? string.Empty);
                                BankManagerWithFile.WithDrawMoney(fName, lName, amount);
                                Console.WriteLine("Heres your money .. ");
                                Thread.Sleep(1000);
                                Console.Clear();
                                gui.Menu();
                                break;
                            case 3:
                                Console.Clear();
                                Console.Write("reading creditCard...");
                                Thread.Sleep(1000);
                                Console.Clear();
                                Console.Write("pinCode :");
                                pinCode  = Console.ReadLine();
                                Console.Write("first name :");
                                fName = Console.ReadLine();
                                Console.Write("last name :");
                                lName = Console.ReadLine();
                                Account account3 = BankManagerWithFile.GetValidatedAccount(fName, lName, pinCode);
                                Console.Clear();
                                Console.WriteLine("your current balance is :" + account3.Balance);
                                Console.Write("Amount to deposit :");
                                amount = decimal.Parse(Console.ReadLine() ?? string.Empty);
                                BankManagerWithFile.DepositMoney(fName, lName, amount);
                                Console.WriteLine("Your money has been deposit..");
                                Thread.Sleep(1000);
                                Console.Clear();
                                gui.Menu();
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("name :");
                        string name = Console.ReadLine();
                        Console.Write("lastname :");
                        string lastName = Console.ReadLine();
                        Console.Write("balance :");
                        decimal balance = decimal.Parse(Console.ReadLine() ?? string.Empty);
                        Console.Write("pinCode :");
                        string pCode = Console.ReadLine();
                        Account account = BankManagerWithFile.CreateAccount(name, lastName, balance, pCode);
                        Thread.Sleep(2000);
                        Console.Clear();
                        BankManagerWithFile.AddNewAccount(account);
                        Console.WriteLine("account added");
                        Thread.Sleep(2000);
                        Console.Clear();
                        gui.Menu();
                        break;
                }
                
            }

        }
        
    }
}
