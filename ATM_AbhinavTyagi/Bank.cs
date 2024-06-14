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
            }
        }

        public Account RetrieveAccount(int accNum)
        {
            return accounts.Find(account => account.AccountNumber == accNum);
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }
    }
}
