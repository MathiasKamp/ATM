using System;
using System.Collections.Generic;
using Xunit;

namespace HæveAutomaten.Tests
{
    /// <summary>
    /// this class holds all the tests done on DatabaseManagerWithFile.cs class
    /// </summary>
    public class DatabaseManagerTests
    {
        // checks the randomNumberGenerator
        [Theory]
        [InlineData(10, "1234567890")]
        [InlineData(11, "12345678901")]
        [InlineData(3, "123")]
        public void GenerateRandomNumber_ShouldWork(int max, string expected)
        {
            string actual = DatabaseManagerWithFile.GenerateRandomNumber(max);
            Assert.True(expected.Length == max && actual.Length == max);
        }

        // check if the account gets created correctly
        [Theory]
        [InlineData("mathias", "kamp", 2000)]
        public void CreateAccount_ShouldWork(string name, string lastname, decimal balance)
        {
            Account acc = DatabaseManagerWithFile.CreateAccount(name, lastname, balance);

            Assert.True(acc.Name.Length > 0 && acc.AccountNumber.Length > 0 && acc.LastName.Length > 0 &&
                        acc.PinCode.Length > 0 && acc.LastName.Length > 0);
        }

        // checks if there is a missing parameter when creating the account
        [Theory]
        [InlineData("", "kamp", 1000, "name")]
        [InlineData("mathias", "", 1000, "lastName")]
        [InlineData("mathias", "kamp", 0, "balance")]
        public void CreateAccount_ShouldFail(string name, string lastName, decimal balance, string param)
        {
            Assert.Throws<ArgumentException>(param,
                () => DatabaseManagerWithFile.CreateAccount(name, lastName, balance));
        }

        // checks if there is a missing parameter when adding the account to a List
        [Theory]
        [InlineData("mathias", "", 1000, "1234567890", "1234567890123456", "1337", "LastName")]
        [InlineData("", "kamp", 1000, "1234567890", "1234567890123456", "1337", "Name")]
        [InlineData("mathias", "kamp", 0, "1234567890", "1234567890123456", "1337", "Balance")]
        public void AddAccountToList_ShouldFail(string name, string lastname, decimal balance, string accountNumber,
            string cardNumber, string pinCode, string param)
        {
            Account newAcc = new Account(name, lastname, accountNumber, cardNumber, pinCode, balance);
            List<Account> accounts = new List<Account>();

            Assert.Throws<ArgumentException>(param, () => DatabaseManagerWithFile.AddAccountToList(accounts, newAcc));
        }
        
    }
}