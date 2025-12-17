using BankManagementSystem.Classes;

public class Program
{
    /*The main program and the entry point of the system. 
     *First, we created an object from BankService Class. 
     *Then, we applied the Methods created on it according to the required task.*/
    static void Main()
    {
        BankService bank = new BankService();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("   WELCOME TO BANK SYSTEM!");
        Console.WriteLine("-----------------------------");
        while (true)
        {
            #region User Menu
            Console.WriteLine("Choose your desired service from the following list...\nNote that you have to be a customer to create any of the following Accounts..");
            Console.WriteLine("\n1. Add Customer" +
                "\n2. Create Checking Account" +
                "\n3. Create Saving Account" +
                "\n4. Apply Interest" +
                "\n5. Display All Customers" +
                "\n6. Update Customer" +
                "\n7. Deposit" +
                "\n8. Withdraw" +
                "\n9. Get Balance" +
                "\n10. Transfer" +
                "\n11. Transaction History" +
                "\n12. Exit\n");
            Console.WriteLine("-----------------------------");
            Console.Write("Enter A Choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine("-----------------------------"); 
            #endregion

            try
            {
                switch (choice)
                {
                    #region Case 1
                    case "1":
                        string name;
                        Console.Write("Name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("-----------------------------");

                        if (!Customer.ValidateName(name))
                        {
                            Console.WriteLine("ERROR: Enter your full name.");
                            Console.WriteLine("-----------------------------");
                            Console.Write("Name: ");
                            name = Console.ReadLine();
                            Console.WriteLine("-----------------------------");
                            //break;
                        }
                        string email;
                        Console.Write("Email: ");
                        email = Console.ReadLine();
                        Console.WriteLine("-----------------------------");

                        if (!Customer.ValidateEmail(email))
                        {
                            Console.WriteLine("ERROR: Invalid email format.");
                            Console.WriteLine("-----------------------------");
                            Console.Write("Email: ");
                            email = Console.ReadLine();
                            Console.WriteLine("-----------------------------");
                            //break;
                        }
                        string phone;
                        Console.Write("Phone: ");
                        phone = Console.ReadLine();
                        Console.WriteLine("-----------------------------");

                        if (!Customer.ValidatePhone(phone))
                        {
                            Console.WriteLine("ERROR: Phone number must contain digits only.");
                            Console.WriteLine("-----------------------------");
                            Console.Write("Phone: ");
                            phone = Console.ReadLine();
                            Console.WriteLine("-----------------------------");
                            //break;
                        }

                        Console.Write("Address: ");
                        string address = Console.ReadLine();
                        Console.WriteLine("-----------------------------");

                        var newCustomer = bank.AddCustomer(name, email, phone, address);
                        Console.WriteLine($"Customer Added. ID = {newCustomer.CustomerId}");
                        Console.WriteLine("-----------------------------");
                        break;
                    #endregion

                    #region Case 2
                    case "2":
                        Console.Write("Customer ID: ");
                        int id2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("-----------------------------");

                        bank.CreateCheckingAccount(id2);
                        Console.WriteLine("Checking Account Created.");
                        Console.WriteLine("-----------------------------");
                        break;
                    #endregion

                    #region Case 3
                    case "3":
                        Console.Write("Customer ID: ");
                        int id3 = int.Parse(Console.ReadLine());
                        Console.WriteLine("-----------------------------");

                        Console.Write("Interest Rate: ");
                        decimal rate = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("-----------------------------");

                        bank.CreateSavingAccount(id3, rate);
                        Console.WriteLine("Saving Account Created.");
                        Console.WriteLine("-----------------------------");
                        break;
                    #endregion

                    #region Case 4
                    case "4":
                        bank.ApplyInterestToAllSavings();
                        Console.WriteLine("-----------------------------");
                        break; 
                    #endregion

                    #region Case 5
                    case "5":
                        bank.DisplayAllCustomers();
                        Console.WriteLine("-----------------------------");
                        break; 
                    #endregion

                    #region Case 6
                    case "6":
                        Console.Write("Customer ID: ");
                        int id4 = int.Parse(Console.ReadLine());
                        Console.WriteLine("-----------------------------");

                        string name2;
                        Console.Write("Name: ");
                        name2 = Console.ReadLine();
                        Console.WriteLine("-----------------------------");

                        if (!Customer.ValidateName(name2))
                        {
                            Console.WriteLine("ERROR: Enter your full name.");
                            Console.WriteLine("-----------------------------");
                            Console.Write("Name: ");
                            name2 = Console.ReadLine();
                            Console.WriteLine("-----------------------------");
                            //break;
                        }

                        string email2;
                        Console.Write("Email: ");
                        email2 = Console.ReadLine();
                        Console.WriteLine("-----------------------------");

                        if (!Customer.ValidateEmail(email2))
                        {
                            Console.WriteLine("ERROR: Invalid email format.");
                            Console.WriteLine("-----------------------------");
                            Console.Write("Email: ");
                            email2 = Console.ReadLine();
                            Console.WriteLine("-----------------------------");
                            //break;
                        }

                        string phone2;
                        Console.Write("Phone: ");
                        phone2 = Console.ReadLine();
                        Console.WriteLine("-----------------------------");

                        if (!Customer.ValidatePhone(phone2))
                        {
                            Console.WriteLine("ERROR: Phone number must contain digits only.");
                            Console.WriteLine("-----------------------------");
                            Console.Write("Phone: ");
                            phone2 = Console.ReadLine();
                            Console.WriteLine("-----------------------------");
                            //break;
                        }

                        Console.Write("Address: ");
                        string address2 = Console.ReadLine();
                        Console.WriteLine("-----------------------------");

                        bank.UpdateCustomer(id4, name2, email2, phone2, address2);
                        Console.WriteLine("Customer Updated.");
                        Console.WriteLine("-----------------------------");
                        break;
                    #endregion

                    #region Case 7
                    case "7":
                        Console.Write("Account ID: ");
                        int acc1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("-----------------------------");

                        Console.Write("Amount: ");
                        decimal dep = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("-----------------------------");

                        bank.Deposit(acc1, dep);
                        Console.WriteLine("Deposit Successful.");
                        Console.WriteLine("-----------------------------");
                        break;
                    #endregion

                    #region Case 8
                    case "8":
                        Console.Write("Account ID: ");
                        int acc2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("-----------------------------");

                        Console.Write("Amount: ");
                        decimal withdraw = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("-----------------------------");

                        bank.Withdraw(acc2, withdraw);
                        Console.WriteLine("Withdraw Successful.");
                        Console.WriteLine("-----------------------------");
                        break;
                    #endregion

                    #region Case 9
                    case "9":
                        Console.Write("Account ID: ");
                        int acc3 = int.Parse(Console.ReadLine());
                        Console.WriteLine("-----------------------------");

                        decimal bal = bank.GetBalance(acc3);
                        Console.WriteLine($"Balance: {bal:F2}");
                        Console.WriteLine("-----------------------------");
                        break;
                    #endregion

                    #region Case 10
                    case "10":
                        Console.Write("From Account ID: ");
                        int fromId = int.Parse(Console.ReadLine());
                        Console.WriteLine("-----------------------------");

                        Console.Write("To Account ID: ");
                        int toId = int.Parse(Console.ReadLine());
                        Console.WriteLine("-----------------------------");

                        Console.Write("Amount: ");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("-----------------------------");

                        bank.Transfer(fromId, toId, amount);
                        Console.WriteLine("Transfer Successful.");
                        Console.WriteLine("-----------------------------");
                        break;
                    #endregion

                    #region Case 11
                    case "11":
                        Console.Write("Account ID: ");
                        int acc4 = int.Parse(Console.ReadLine());
                        Console.WriteLine("-----------------------------");

                        var history = bank.GetHistory(acc4);

                        foreach (var t in history)
                        {
                            Console.WriteLine($"{t.Date} | {t.Type} | {t.Amount:F2}");
                        }
                        Console.WriteLine("-----------------------------");
                        break;
                    #endregion

                    #region Case 12
                    case "12":
                        return;
                    #endregion

                    #region Default Case
                    default:
                        Console.WriteLine("Invalid Option.");
                        Console.WriteLine("-----------------------------");
                        break; 
                        #endregion
                }
            }
            catch (Exception ex)
            {
                #region Exception
                // Console.WriteLine("-----------------------------");
                Console.WriteLine($"ERROR: Please Enter Valid Values!");
                Console.WriteLine("-----------------------------"); 
                #endregion
            }
        }
    }
}