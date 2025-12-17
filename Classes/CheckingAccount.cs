using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Classes
{
    /*A specific type of bank account that inherits from Account. 
     *It implements the Deposit and Withdraw methods using the base class validation rules, without adding extra conditions.
     *To represent a simple checking account with standard deposit and withdrawal behavior.*/
    public class CheckingAccount : Account
    {
        #region Constructor
        public CheckingAccount(int customerId, int accountId)
                : base(customerId, accountId) { }
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
        #endregion

    }
}
