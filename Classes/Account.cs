using BankManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Classes
{
    /*An abstract base class that represents the common foundation for all bank accounts. 
     *It stores shared data (AccountId, CustomerId, Balance) and provides protected methods for balance manipulation and validation. 
     *It also declares abstract methods (Deposit, Withdraw) that must be implemented by derived classes.
     *To centralize shared logic and enforce a consistent structure across all account types.*/
    public abstract class Account : IAccount
        {
        #region Properties
        public int AccountId { get; }
        public int CustomerId { get; }

        private decimal _balance;
        public decimal Balance => _balance;

        protected Account(int customerId, int accountId)
        {
            CustomerId = customerId;
            AccountId = accountId;
            _balance = 0;
        }
        #endregion

        #region Concrete Methods
        protected void IncreaseBalance(decimal amount) => _balance += amount;
        protected void DecreaseBalance(decimal amount) => _balance -= amount;

        protected void ValidateAmount(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be positive");
        }

        protected void ValidateWithdrawal(decimal amount)
        {
            ValidateAmount(amount);
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds");
        }
        #endregion

        #region Abstract Methods
        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount); 
        #endregion
    }

}
