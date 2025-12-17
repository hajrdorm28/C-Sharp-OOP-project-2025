using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BankManagementSystem.Classes
{
    /*Represents a bank customer and stores personal information such as name, email, phone, and address. 
     *It includes validation inside property setters to ensure data integrity.
     *To model customer data in a clean, encapsulated way.*/
    public class Customer
    {
        #region Attributes
        private string _name;
        private string _email;
        private string _phone;
        private string _address;
        #endregion

        #region Properties
        public int CustomerId { get; }

        public string Name
        {
            get => _name;
            set
            {
                if (!ValidateName(value))
                    throw new ArgumentException("Name must contain at least 3 words.");
                _name = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (!ValidateEmail(value))
                    throw new ArgumentException("Invalid email format.");
                _email = value;
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (!ValidatePhone(value))
                    throw new ArgumentException("Phone must contain digits only.");
                _phone = value;
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Address cannot be empty.");
                _address = value;
            }
        }
        #endregion

        #region Constructor
        public Customer(int id, string name, string email, string phone, string address)
        {
            CustomerId = id;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }
        #endregion

        #region Validation Methods
        public static bool ValidateName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) &&
                   name.Trim().Split(' ').Length >= 2;
        }

        public static bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"); //New way to check on the email
        }

        public static bool ValidatePhone(string phone)
        {
            return !string.IsNullOrWhiteSpace(phone) &&
                   phone.All(char.IsDigit);
        }
        #endregion

    }
}
