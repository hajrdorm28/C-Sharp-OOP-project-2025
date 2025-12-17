using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Interfaces
{
    /*Defines the essential structure and behavior that every bank account must follow. 
     *It ensures that all account types share the same basic properties (AccountId, CustomerId, Balance), 
     *and implement the core operations (Deposit and Withdraw).
     *To provide a unified contract for all account types and enable polymorphism in the system.*/
    public interface IAccount
    {
        #region Properties
        int AccountId { get; }
        int CustomerId { get; }
        decimal Balance { get; }
        #endregion

        #region Methods
        void Deposit(decimal amount);
        void Withdraw(decimal amount); 
        #endregion
    
    }
}
