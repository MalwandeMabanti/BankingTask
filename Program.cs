using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();
            
            while(true)
            {
                Console.WriteLine("Enter 1 to add a new account.");
                Console.WriteLine("Enter 2 to view an account.");
                Console.WriteLine("Enter 3 to deposit.");
                Console.WriteLine("Enter 4 to withdraw.");
                Console.WriteLine("Enter 5 to list all accounts");
                Console.WriteLine("Enter 6 to exit.");

                int option = int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                        AddAccount(accounts);
                        break;
                    case 2:
                        ViewAccount(accounts); 
                        break;
                    case 3:
                        Deposit(accounts); 
                        break;
                    case 4:
                        Withdraw(accounts);
                        break;
                    case 5:
                        ListAllAccounts(accounts); 
                        break;
                    case 6:
                        Console.WriteLine("Goodbye!!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid number");
                        break;
                }
            }
        }

        static void AddAccount(List<BankAccount> accounts)
        {
            bool verify = false;

            Console.Write("Enter account number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            verify = accounts.Exists(a => a.AccountNumber == accountNumber);


            if (verify)
            {
                Console.WriteLine("Account exists.");
            }
            else
            {

                Console.WriteLine("Enter initial balance: ");
                double initialBalance = double.Parse(Console.ReadLine());

                BankAccount account = new BankAccount(accountNumber, initialBalance);
                accounts.Add(account);

                Console.WriteLine("Account has been created.");
            }
                
        }

        static void ViewAccount(List<BankAccount> accounts)
        {
            Console.WriteLine("Enter account number: ");
            var accountNumber = int.Parse(Console.ReadLine());
            var usersBankAcount = accounts.FirstOrDefault(_ => _.AccountNumber == accountNumber);

            if (usersBankAcount is null) 
            {
                Console.WriteLine("Account not found.");
            } else
            {
                Console.WriteLine("Account number: " + usersBankAcount.AccountNumber);
                Console.WriteLine("Balance: " + usersBankAcount.Balance);

                Console.WriteLine("Transaction History:");

                foreach (Transaction transaction in usersBankAcount.Transactions)
                {
                    Console.WriteLine(transaction.Type.ToString() + " " + transaction.Amount + " " + transaction.Date);

                }
            }
        }
        

        static void Deposit(List<BankAccount> accounts)
        {
            Console.Write("Enter account number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            BankAccount account = accounts.Find(a => a.AccountNumber == accountNumber);

            Console.Write("Enter amount to deposit: ");
            double amount = double.Parse(Console.ReadLine());

            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }else
            {
                account.Deposit(amount);
                Console.WriteLine("Funds have been successful.");

            }

            

        }

        static void Withdraw(List<BankAccount> accounts)
        {
            int comparer = 0;
            Console.Write("Enter account number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            

            foreach(BankAccount account1 in accounts)
            {
                Console.WriteLine(account1.AccountNumber);
                if (accountNumber == account1.AccountNumber)
                {
                    comparer = account1.AccountNumber;
                }
            }



            Console.Write("Enter amount to withdraw: ");
            double amount = double.Parse(Console.ReadLine());

            if (comparer <= 0)
            {
                Console.WriteLine("Account not found.");
                return;
            }
            else
            {
                Console.Write("What is your balance: ");
                double balance = double.Parse(Console.ReadLine());
                BankAccount account = new BankAccount(comparer, balance);
                account.Withdraw(amount);
                Console.WriteLine("Succcess");
            }

          

        }

        static void ListAllAccounts(List<BankAccount> accounts)
        {
            foreach(BankAccount account in accounts)
            {
                Console.WriteLine("Account Number is {0}", account.AccountNumber);
                Console.WriteLine("Balance is {0}", account.Balance);  
            }
        }
    }
}
