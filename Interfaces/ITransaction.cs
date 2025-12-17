using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Interfaces
{
    /*Represents the required structure of any financial transaction in the system. 
     *It defines the basic information that every transaction must contain, such as ID, account, amount, date, and type.
     *To ensure consistency in how transactions are recorded and represented.*/
    public interface ITransaction
    {
        #region Properties
        int TransactionId { get; }
        int AccountId { get; }
        decimal Amount { get; }
        DateTime Date { get; }
        string Type { get; } 
        #endregion
    }
}
