using System;
using System.Collections.Generic;
using System.Globalization;
using System.Transactions;

namespace BankingApp
{
    public class user
    {
        public string name { get; set; }
        public string password { get; set; }
        public List<account> AccountList { get; set; } = new List<account>();

        public user(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
    }
    public class account
    {
        private static int acNo = 1;
        public int id { get; private set; }
        public string type { get; set; }
        public double balance { get; set; }
        public List<Transaction> transactions { get; set; } = new List<Transaction>();

        public account(string type, double balance) {
            id = acNo++;
            this.type = type;
            this.balance = balance;
            transactions.Add(new Transaction(Transaction.GenerateId(), "Deposite", 5000, 5000));
        }
    }

    public class Transaction
    {
        private static int tCounter = 1;
        public int tid { get; private set; }
        public DateTime Date { get; private set; }
        public string type { get; set; }
        public double amount { get; set; }
        public double balance { get; private set; }

        public Transaction(int tid, string type, double amount, double balance)
        {
            this .tid = tid;    
            Date = DateTime.Now;
            this .type = type;
            this .amount = amount;
            this .balance = balance;
        }
        public static int GenerateId() => tCounter++;

    }
    public class Bank
    {
         static List<user> UsersList = new List<user>();
        public static void ShowMenu()
        {
            
            Console.WriteLine("Banking Application");
            Console.WriteLine("Already a user y/n?");
            string userOrNot = Console.ReadLine().Trim();

            if (userOrNot == "y" || userOrNot == "Y")
            {
                Login();
            }
            else if (userOrNot == "n" || userOrNot == "N")
            {
                Registration();
            }
            else
            {
                Console.WriteLine("Invalid Input");
                ShowMenu();
            }
        }

        public static void Registration()
        {
            Console.WriteLine("!!Welcome!!");
            Console.WriteLine("Enter Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string pwd = Console.ReadLine();
            var newUser = new user(username, pwd);
            UsersList.Add(newUser);

            Console.WriteLine("Logged in succesfully");
            CreateAccount(newUser);
        }
        public static void CreateAccount(user curr)
        {
            Console.WriteLine("Account Type:s/c ? (savings or checking)");
            string type = Console.ReadLine().Trim();
            string acType = (type == "s" || type == "S") ? "savings" : "checking";
            Console.WriteLine("Initial deposite amount is 5000");
            var newAccount = new account(acType, 5000);
            curr.AccountList.Add(newAccount);

            Console.WriteLine($"Your new Account Number : {newAccount.id}");

            ShowOptions(curr);
        }

        public static void Login()
        {
            Console.WriteLine("!!!Welcome Back!!!");
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password");
            string pwd = Console.ReadLine();
            bool userExists = false;
            user currUser = null;

            foreach (var u in UsersList)
            {
                if(u.name == username)
                {
                    userExists = true;
                    if(u.password == pwd)
                    {
                        currUser = u;
                        Console.WriteLine("Logged in Successfully");
                        ShowOptions(currUser);
                    }
                    else
                    {
                        Console.WriteLine("Wrong Password");
                        ShowMenu();
                    }
                    break;
                }
            }

            if (!userExists)
            {
                Console.WriteLine("User not found. Please register.");
                Registration();
            }
            
        }

        public static void ShowOptions(user currUser)
        {
            int op;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Choose one option:");
                Console.WriteLine("1. Create a new account");
                Console.WriteLine("2. Transaction ");
                Console.WriteLine("3. Generate Statement");
                Console.WriteLine("4. Balance Check");
                Console.WriteLine("5. Logout");
                Console.WriteLine("Choose one: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out op) && op >= 1 && op <= 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                }
            } while (true);


            switch (op)
            {
                case 1:
                    CreateAccount(currUser);
                    break;
                case 2:Transactions(currUser);
                    break;
                case 3:GenerateStatement(currUser);
                    break;
                case 4: CheckBalance(currUser);
                    break;
                case 5:
                    Console.WriteLine("Logging out...");
                    ShowMenu();
                    break;
                default: 
                    Console.WriteLine("Invalid Choice");
                    ShowOptions(currUser);
                    break;

            }
        }

        public static void  Transactions(user currUser)
        {
            Console.WriteLine("Enter account number");
            int acNum = Convert.ToInt32(Console.ReadLine());
            var currAccount = currUser.AccountList.Find(a => a.id == acNum);

            if (currAccount != null)
            {
                Console.WriteLine("1. Deposite 2.Withdrawal");
                int op = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter amount");
                double amount = Convert.ToDouble(Console.ReadLine());

                //deposite
                if (op == 1)
                {
                    currAccount.balance += amount;
                    currAccount.transactions.Add(new Transaction(Transaction.GenerateId(), "Deposite", amount, currAccount.balance));
                    Console.WriteLine("Deposited Successfully");
                    ShowOptions(currUser);
                }

                //withdrawal
                else if (op == 2 && currAccount.balance >= amount)
                {
                    currAccount.balance -= amount;
                    currAccount.transactions.Add(new Transaction(Transaction.GenerateId(), "Withdrawal", amount, currAccount.balance));
                    Console.WriteLine("Withdrawal Succesful");
                    ShowOptions(currUser);
                }
                else if (op == 2 && currAccount.balance < amount)
                {
                    Console.WriteLine("Insufficient funds");
                    ShowOptions(currUser);
                }
                else
                {
                    Console.WriteLine("Invalid transaction.");
                    ShowOptions(currUser);
                }

            }
            else
            {
                Console.WriteLine("Account not found.");
            }

        }

        public static void GenerateStatement(user currUser)
        {
            Console.WriteLine("Enter Account Number");
            int acNum = Convert.ToInt32(Console.ReadLine());
            var currAcc = currUser.AccountList.Find(a => a.id == acNum);
            if (currAcc != null && currAcc.transactions.Count > 0)
            {
                Console.WriteLine($"Statement for Account ID: {currAcc.id}");
                foreach (var t in currAcc.transactions)
                {
                    Console.WriteLine($"{t.Date}  -  {t.type}:  {t.amount},  Balance:  {t.balance}");
                }
            }
            else if(currAcc.transactions.Count == 0)
            {
                Console.WriteLine("No Transaction");
            }
            else
            {
                Console.WriteLine("No account found");
            }
            ShowOptions(currUser);
        }

        public static void CheckBalance(user currUser)
        {
            var acList = currUser.AccountList;
            Console.WriteLine("Account Number and Balance");
            foreach (var ac in acList) {
                Console.WriteLine($"{ac.id} : {ac.balance}");
            }
            Console.WriteLine("To go back press 1 or to exit 0");
            int op = Convert.ToInt32(Console.ReadLine());
            if (op == 1)
            {
                ShowOptions(currUser);
            }
            else if (op == 0)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }
    }
    

    class Program
    {
        public static void Main(string[] args)
        {
        
            Bank.ShowMenu();
        }
    }

}
