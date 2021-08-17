using System;
using System.Diagnostics;
using System.Threading;

namespace HæveAutomaten
{
    internal static class Program
    {
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
                                Account acc = BankManager.GetAccount(fName, lName);
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
                                Account account1 = BankManager.WithDrawMoney(fname, lastname, amount);
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
                                Account account2 = BankManager.DepositMoney(firstname, lname, amountToDeposit);
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
                        bool accountAdded = BankManager.CreateAccount(name, lastName, balance);
                        if (accountAdded)
                        {
                            Console.Clear();
                            Console.WriteLine("account added");
                            Account acc = BankManager.GetAccount(name, lastName);
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
    }
}