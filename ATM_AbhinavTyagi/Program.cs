using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_AbhinavTyagi
{
    class AtmApplication
    {
        private Bank bank;
        private Account selectedAccount;

        public AtmApplication()
        {
            bank = new Bank();
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("======== Welcome to the ATM Application ========");
                Console.Write("Choose the following options by the number associated with the option");
                Console.WriteLine("\n 1. Create Account");
                Console.WriteLine("\n 2. Select Account");
                Console.WriteLine("\n 3. Exit");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        SelectAccount();
                        break;
                    //case "3":
                        //running = false;
                        //break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void CreateAccount()
        {
            Console.Write("Enter account holder's name: ");
            string accHolderName = Console.ReadLine();
            Console.Write("Enter account number \n (Account number must be between 100 and 1000)");
            int accNum = int.Parse(Console.ReadLine());
            Console.Write("Enter annual interest rate \n (Must be less than 3.00)");
            double ROI = double.Parse(Console.ReadLine()) / 100;
            Console.Write("Enter initial balance: ");
            double initBal = double.Parse(Console.ReadLine());
            
            

            Account newAccount = new Account(accNum, initBal, ROI, accHolderName);
            bank.AddAccount(newAccount);

            Console.WriteLine("Account created successfully!");
            
        }

        private void SelectAccount()
        {
            Console.Write("Enter account number: ");
            int accNum = int.Parse(Console.ReadLine());
            Account selectedAccount = bank.RetrieveAccount(accNum);

            if (selectedAccount != null)
            {
                Console.WriteLine("Welcome " + selectedAccount.AccHolderName);
                AccountMenu(selectedAccount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        private void AccountMenu(Account selectedAccount)
        {
            while (true)
            {
                Console.WriteLine("Account Menu:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Display Transactions");
                Console.WriteLine("5. Exit Account");
                Console.Write("Select an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Balance: " + selectedAccount.Balance.ToString());
                        break;
                    case 2:
                        Console.Write("Enter deposit amount: ");
                        double depositAmount = double.Parse(Console.ReadLine());
                        selectedAccount.Deposit(depositAmount);
                        Console.WriteLine("Deposit successful!");
                        break;
                    case 3:
                        Console.Write("Enter withdrawal amount: ");
                        double withdrawAmount = double.Parse(Console.ReadLine());
                        selectedAccount.Withdraw(withdrawAmount);
                        Console.WriteLine("Withdrawal successful!");
                        break;
                    case 4:
                        selectedAccount.DisplayTransactions();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        //private void SelectAccount()
        //{
        //    Console.Write("Enter account number: ");
        //    int accNum = int.Parse(Console.ReadLine());
        //    selectedAccount = bank.RetrieveAccount(accNum);

        //    if (selectedAccount != null)
        //    {
        //        Console.WriteLine("Welcome " + selectedAccount.AccHolderName);
        //        bool accountMenuRunning = true;
        //        while (accountMenuRunning)
        //        {
        //            //Console.Clear();
        //            Console.WriteLine("Choose the following options");
        //            Console.WriteLine("1. Check Balance");
        //            Console.WriteLine("2. Deposit");
        //            Console.WriteLine("3. Withdraw");
        //            Console.WriteLine("4. Display Transactions");
        //            Console.WriteLine("5. Exit Account");
        //            Console.Write("Select an option: ");
        //            switch (Console.ReadLine())
        //            {
        //                case "1":
        //                    Console.WriteLine("Balance: " + selectedAccount.Balance.ToString());                         
        //                    break;
        //                case "2":
        //                    Console.Write("Enter deposit amount: ");
        //                    double depositAmount = double.Parse(Console.ReadLine());
        //                    selectedAccount.Deposit(depositAmount);
        //                    Console.WriteLine("Deposit successful!");
        //                    break;
        //                case "3":
        //                    Console.Write("Enter withdrawal amount: ");
        //                    double withdrawalAmount = double.Parse(Console.ReadLine());
        //                    selectedAccount.Withdraw(withdrawalAmount);
        //                    Console.WriteLine("Withdrawal successful!");
        //                    break;
        //                case "4":
        //                    Console.WriteLine("Transactions:");
        //                    selectedAccount.DisplayTransactions();
        //                    break;
        //                case "5":
        //                    accountMenuRunning = false;
        //                    break;
        //                default:
        //                    Console.WriteLine("Invalid option. Please try again.");
        //                    break;
        //            }
        //            //Console.WriteLine("Press any key to continue...");
        //            //Console.ReadKey();
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Account not found.");
        //        Console.WriteLine("Press any key to return to the main menu...");
        //        Console.ReadKey();
        //    }
        //}

        static void Main(string[] args)
        {
            AtmApplication atmApp = new AtmApplication();
            atmApp.Run();
        }
    }
}
