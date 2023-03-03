using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealBank
{
    internal class Transaction
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public TransactionType Type { get; set; }

        public Transaction(double amount, TransactionType type)
        {
            Amount = amount;
            Type = type;
            Date= DateTime.Now;
        }

        
       

        
    }

    public enum TransactionType 
    {
        Deposit,
        Withdrawal
    }
    
   
       
}
