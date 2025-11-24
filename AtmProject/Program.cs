using System.ComponentModel.Design;

namespace AtmProject
{
    internal class Program
    {
        static double balance = 2500.00;
        static void Main(string[] args)
        {
            string password = "1235";
            int attempts = 3;
            bool isLoginSuccess = false;
            while (attempts > 0)
            {
                Console.Clear();
                Console.WriteLine("\t--- Welcome to Global Bank ---\t");
                Console.Write("Please Enter Your PIN: ");
                string inputPassword = Console.ReadLine();

                if (inputPassword == password)
                {
                    Console.WriteLine("Login Successful!");
                    isLoginSuccess = true;
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
                else
                {
                    attempts--;
                    Console.WriteLine("Wrong PIN! Remaining Attempts: " + attempts);
                    Console.ReadKey();
                }
            }

            if (isLoginSuccess == false)
            {
                Console.WriteLine("\nACCOUNT BLOCKED! TOO MANY FAILED ATTEMPTS!");
                return;
            }

            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();
                Console.WriteLine("\t--- Global Bank Atm ---\t");
                Console.WriteLine("Current Balance: " + balance);
                Console.WriteLine("\nPlease Select a Procedure.");
                Console.WriteLine("1) Deposit Money");
                Console.WriteLine("2) Withdraw Money");
                Console.WriteLine("3) Exit");
                Console.Write("\nYour Choice: ");
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        Deposit();
                        break;
                    case "2":
                        Withdraw();
                        break;
                    case "3":
                        Console.WriteLine("Thank You for Using Global Bank. GoodBye!");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice! Please Try Again!");
                        Console.ReadLine();
                        break;
                }
            }
        }
        static void Deposit()
        {
            Console.Write("\nEnter Amount to Deposit: ");
            if (double.TryParse(Console.ReadLine(), out double amount))
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Please Enter a Valid Amount!");
                }
                else
                {
                    balance += amount;
                    Console.WriteLine("Success! You Deposited " + amount + ". New Balance: " + balance);
                }
            }
            else
            {
                Console.WriteLine("Error: Please Enter a Valid Number!");
            }
            Console.WriteLine("\nPress Any Key to Return to Menu...");
            Console.ReadKey();
        }
        static void Withdraw()
        {
            Console.Write("\nEnter Amount to Withdraw: ");
            if (double.TryParse(Console.ReadLine(), out double amount))
            {
                if (amount > balance)
                {
                    Console.WriteLine("Insufficient Funds!");
                }
                else if (amount <= 0)
                {
                    Console.WriteLine("Please Enter a Valid Number!");
                }
                else
                {
                    balance -= amount;
                    Console.WriteLine("Success! You Withdraw " + amount + ". New Balance: " + balance);
                }
            }
            else
            {
                Console.WriteLine("Error: Please Enter a Valid Number!");
            }
            Console.WriteLine("\nPress Any Key to Return to Menu...");
            Console.ReadKey();
        }
    }
}
