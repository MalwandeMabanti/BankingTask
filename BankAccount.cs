using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealBank
{
    internal class BankAccount
    {
        private int accountNumber;
        private double balance;
        private  List<Transaction> transactions;

        public BankAccount(int accountNumber, double initialBalance)
        {
            this.accountNumber = accountNumber;
            this.balance = initialBalance;
            
        }

        public int AccountNumber 
        { 
            get { return accountNumber; } 
        }

        

        public double Balance
        { 
            get { return balance; } 
        }

        public List<Transaction> Transactions 
        { 
            get { return transactions; } 
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Value must be positive");
            }
            balance += amount;
            transactions.Add(new Transaction(amount, TransactionType.Deposit));
        } 

        public void Withdraw(double amount)
        {
            if(balance < amount) 
            {
                throw new ArgumentException("Amount must be positive");

            }

            if(balance > amount) 
            {
                throw new InvalidOperationException("Not enoug funds");
            }

            balance -= amount;
            transactions.Add(new Transaction(amount, TransactionType.Withdrawal));

        }
    }
}
