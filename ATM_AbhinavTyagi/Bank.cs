using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_AbhinavTyagi
{
    public class Bank
    {
        private List<Account> accounts;

        public Bank()
        {
            accounts = new List<Account>();
            for (int i = 0; i < 10; i++)
            {
                accounts.Add(new Account(100 + i, 100, 0.03, "Default User " + (i + 1).ToString()));
                // Create a new Account object with the following parameters:
                // - Account ID: 100 + i (Unique ID for each account, starting from 100)
                // - Balance: 100 (Initial balance for each account)
                // - Interest Rate: 0.03 (Interest rate for each account)
                // - Account Holder's Name: "Default User " followed by the number (i + 1)
                // Add the newly created Account object to the accounts list
            }
        }

        public Account RetrieveAccount(int accNum) // Method to retrieve an account based on its account number
        {
            return accounts.Find(account => account.AccountNumber == accNum);
            // Search the accounts list for an account
            // The Find method returns the first account that matches
        }

        public void AddAccount(Account account) // Method to add a new account to the accounts list
        {
            accounts.Add(account);
        }
    }
}
