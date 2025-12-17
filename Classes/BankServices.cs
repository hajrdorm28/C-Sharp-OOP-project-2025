using BankManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Classes
{
    /*The central manager of the entire banking system. 
     *It handles customers, accounts, transactions, deposits, withdrawals, transfers, and interest application. 
     *It also generates unique IDs and provides methods to retrieve data.
     *To organize and control all business logic in one place, making the system easy to use and maintain.*/
    public class BankService
    {
        #region Attributes
        private readonly List<Customer> _customers = new();
        private readonly List<IAccount> _accounts = new();
        private readonly List<Transaction> _transactions = new();

        private int _nextCustomerId = 1;
        private int _nextAccountId = 1;
        private int _nextTransactionId = 1;
        #endregion

        #region Get Account
        public IAccount GetAccount(int id)
        {
            foreach (var a in _accounts)
            {
                if (a.AccountId == id)
                {
                    return a;
                }
            }
            return null;
        }
        #endregion

        #region Get Customer
        public Customer GetCustomer(int id)
        {
            foreach (var c in _customers)
            {
                if (c.CustomerId == id)
                {
                    return c;
                }
            }
            return null;
        }
        #endregion

        #region Require Account
        private IAccount RequireAccount(int id)
        {
            var acc = GetAccount(id);
            if (acc == null)
                throw new Exception("Account not found");
            return acc;
        }
        #endregion

        #region Record Transactions
        private void Record(string type, IAccount acc, decimal amount)
        {
            _transactions.Add(new Transaction(_nextTransactionId++, acc.AccountId, amount, type));
        }
        #endregion

        #region Add Customer
        public Customer AddCustomer(string name, string email, string phone, string address)
        {
            var customer = new Customer(_nextCustomerId++, name, email, phone, address);
            _customers.Add(customer);
            return customer;
        }
        #endregion

        #region Update Customer
        public void UpdateCustomer(int id, string name, string email, string phone, string address)
        {
            var customer = GetCustomer(id);
            if (customer == null)
                throw new Exception("Customer not found");

            customer.Name = name;
            customer.Email = email;
            customer.Phone = phone;
            customer.Address = address;
        }
        #endregion

        #region Display Customers
        public void DisplayAllCustomers()
        {
            if (_customers.Count == 0)
            {
                Console.WriteLine("No customers available.");
                return;
            }

            foreach (var c in _customers)
                Console.WriteLine($"ID: {c.CustomerId}, Name: {c.Name}, Email: {c.Email}, Phone: {c.Phone}, Address: {c.Address}");
        }
        #endregion

        #region CCheckingAccount
        public CheckingAccount CreateCheckingAccount(int customerId)
        {
            if (GetCustomer(customerId) == null)
                throw new Exception("Customer not found");

            var acc = new CheckingAccount(customerId, _nextAccountId++);
            _accounts.Add(acc);
            return acc;
        }
        #endregion

        #region CSavingAccount
        public SavingAccount CreateSavingAccount(int customerId, decimal interestRate)
        {
            if (GetCustomer(customerId) == null)
                throw new Exception("Customer not found");

            var acc = new SavingAccount(customerId, _nextAccountId++, interestRate);
            _accounts.Add(acc);
            return acc;
        }
        #endregion

        #region Deposit
        public void Deposit(int accountId, decimal amount)
        {
            var acc = RequireAccount(accountId);
            acc.Deposit(amount);
            Record("Deposit", acc, amount);
        }
        #endregion

        #region Withdraw
        public void Withdraw(int accountId, decimal amount)
        {
            var acc = RequireAccount(accountId);
            acc.Withdraw(amount);
            Record("Withdraw", acc, -amount);
        }
        #endregion

        #region Get Balance
        public decimal GetBalance(int accountId)
        {
            var acc = RequireAccount(accountId);
            return acc.Balance;
        }
        #endregion

        #region Tranfer
        public void Transfer(int fromId, int toId, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Transfer amount must be positive");

            var fromAcc = RequireAccount(fromId);
            var toAcc = RequireAccount(toId);

            fromAcc.Withdraw(amount);
            Record($"Transfer to {toId}", fromAcc, -amount);

            toAcc.Deposit(amount);
            Record($"Transfer from {fromId}", toAcc, amount);
        }
        #endregion

        #region Get History
        public List<Transaction> GetHistory(int accountId)
        {
            List<Transaction> result = new List<Transaction>();

            foreach (var t in _transactions)
            {
                if (t.AccountId == accountId)
                {
                    result.Add(t);
                }
            }
            return result;
        }
        #endregion

        #region Interest to Saving
        public void ApplyInterestToAllSavings()
        {
            foreach (var acc in _accounts.OfType<SavingAccount>())
            {
                decimal before = acc.Balance;
                acc.ApplyInterest();
                Record("Interest", acc, acc.Balance - before);
            }
            Console.WriteLine("Interest Applied.");
        }
        #endregion

    }
}

