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
                Console.WriteLine("======== Welcome to the ATM Application ========");
                Console.Write("Choose the following options by the number associated with the option");
                Console.WriteLine("\n 1. Create Account");
                Console.WriteLine("\n 2. Select Account");
                Console.WriteLine("\n 3. Exit");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        CreateAccount(); //create new account
                        break;
                    case "2":
                        SelectAccount(); //Select an existing account
                        break;
                    case "3":
                        running = false; // Exit option
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void CreateAccount()
        {
            Console.Write("Enter account holder's name: "); //read accont holder name
            string accHolderName = Console.ReadLine();
            Console.Write("Enter account number \n (Account number must be between 100 and 1000)"); //read account number
            int accNum = int.Parse(Console.ReadLine());
            Console.Write("Enter annual interest rate \n (Must be less than 3.00)"); //Read the ROI 
            double ROI = double.Parse(Console.ReadLine()) / 100;
            Console.Write("Enter initial balance: "); //Read the initial balance
            double initBal = double.Parse(Console.ReadLine());
            
            

            Account newAccount = new Account(accNum, initBal, ROI, accHolderName); //new account creation
            bank.AddAccount(newAccount); //add acount to bank

            Console.WriteLine("Account created successfully!");
            
        }

        private void SelectAccount()
        {
            Console.Write("Enter account number: ");
            int accNum = int.Parse(Console.ReadLine()); //read account number
            Account selectedAccount = bank.RetrieveAccount(accNum); //Retrieve account from bank

            if (selectedAccount != null)
            {
                Console.WriteLine("Welcome " + selectedAccount.AccHolderName); //Matching the account number with account name and greeting the user.
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

                switch (choice) //read user choice and save the value in choice
                {
                    case 1:
                        Console.WriteLine("Balance: " + selectedAccount.Balance.ToString()); //balance display
                        break;
                    case 2:
                        Console.Write("Enter deposit amount: ");
                        double depositAmount = double.Parse(Console.ReadLine()); //read deposit amount
                        selectedAccount.Deposit(depositAmount); //increment to account balance
                        Console.WriteLine("Deposit successful!");
                        break;
                    case 3:
                        Console.Write("Enter withdrawal amount: ");
                        double withdrawAmount = double.Parse(Console.ReadLine()); //read withdrawal amount
                        selectedAccount.Withdraw(withdrawAmount); //withdraw from account
                        Console.WriteLine("Withdrawal successful!");
                        break;
                    case 4:
                        selectedAccount.DisplayTransactions(); //display transaction made to account
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            AtmApplication atmApp = new AtmApplication();
            atmApp.Run(); //running the application
        }
    }
}
