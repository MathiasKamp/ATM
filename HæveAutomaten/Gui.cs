using System;

namespace HæveAutomaten
{
    
    public class Gui
    {
        public void Menu()
        {
            Console.WriteLine("welcome to the ATM machine");
            Console.WriteLine("1. already have an account");
            Console.WriteLine("2. create an account");
        }

        public void AlreadyHaveAccount()
        {
            Console.WriteLine("1. show balance :");
            Console.WriteLine("2. withdraw money :");
            Console.WriteLine("3. deposit money :");
        }
    }
}