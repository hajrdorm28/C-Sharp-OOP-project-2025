using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Classes
{
    /*A savings account that inherits from Account and adds an InterestRate property. 
     *It implements Deposit and Withdraw like the checking account but also includes an ApplyInterest method to 
     *increase the balance based on the interest rate.
     *To represent a savings account that earns interest over time.*/
    public class SavingAccount : Account
    {
        #region Properties
        public decimal InterestRate { get; private set; }
        #endregion

        #region Constructor
        public SavingAccount(int customerId, int accountId, decimal interestRate)
            : base(customerId, accountId)
        {
            InterestRate = interestRate;
        }
        #endregion

        #region Methods
        public override void Deposit(decimal amount)
        {
            ValidateAmount(amount);
            IncreaseBalance(amount);
        }

        public override void Withdraw(decimal amount)
        {
            ValidateWithdrawal(amount);
            DecreaseBalance(amount);
        }

        public void ApplyInterest()
        {
            if (Balance > 0)
                IncreaseBalance(Balance * InterestRate);
        } 
        #endregion

    }
}
