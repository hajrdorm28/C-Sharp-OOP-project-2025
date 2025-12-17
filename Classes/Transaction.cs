using BankManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Classes
{
    /*Represents a financial transaction performed on an account. 
     *It stores the transaction ID, account ID, amount, date, and type. 
     *All values are set at creation time, making the object immutable.
     *To record and track all financial operations in a consistent and reliable format.*/
    public class Transaction : ITransaction
    {
        #region Properties
        public int TransactionId { get; }
        public int AccountId { get; }
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Type { get; }
        #endregion

        #region Constructor
        public Transaction(int transactionId, int accountId, decimal amount, string type)
        {
            TransactionId = transactionId;
            AccountId = accountId;
            Amount = amount;
            Type = type;
            Date = DateTime.Now;
        } 
        #endregion

    }
}
