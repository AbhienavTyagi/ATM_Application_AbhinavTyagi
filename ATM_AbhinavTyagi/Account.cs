using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_AbhinavTyagi
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public double Balance { get; private set; }
        public double InterestRate { get; set; }
        public string AccHolderName { get; set; }
        public List<string> Transactions { get; private set; }

        public Account(int accNum, double initBal, double ROI, string accHolderName)
        {
            AccountNumber = accNum;
            Balance = initBal;
            InterestRate = ROI;
            AccHolderName = accHolderName;
            Transactions = new List<string>();
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            Transactions.Add("Deposited: " + amount.ToString());
        }

        public void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Transactions.Add("Withdrew: " +amount.ToString());
            }
            else
            {
                Transactions.Add("Failed Withdrawal Attempt: " + amount.ToString());
            }
        }

        public void DisplayTransactions()
        {
            foreach (var transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}