using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Expenses
{
    class Program
    {
        public static bool shutdown { get; set; }

        static void Main(string[] args)
        {

            Money money = Startup();

            mainMenu(money);






        }
        static void firstLaunch()
        {
            Console.WriteLine("First time setup initiated...");
            Console.Write("Please enter your current amount of money: ");
            decimal currentMoney = decimal.Parse(Console.ReadLine());
            Console.Write("Please enter your current amount of credit: ");
            decimal currentCredit = decimal.Parse(Console.ReadLine());

            Properties.Settings.Default.currentMoney = currentMoney;
            Properties.Settings.Default.currentCredit = currentCredit;
            Properties.Settings.Default.Save();
        }
        static Money Startup()
        {
            bool firstTimeSetup = Properties.Settings.Default.firstTimeSetup;
            if (firstTimeSetup == true)
            {
                firstLaunch();
                firstTimeSetup = false;
                Properties.Settings.Default.firstTimeSetup = firstTimeSetup;


            }
            Money money = new Money();
            return money;

        }
        static void mainMenu(Money money)
        {
            bool exit = false;

            while (exit == false)
            {
                Console.Clear();
                money.displayMoney(money);
                Console.WriteLine("Please choose an option: ");
                Console.WriteLine("1) New Payment");
                Console.WriteLine("2) New Credit");
                Console.WriteLine("3) New Income");
                Console.WriteLine("4) View Previous Inputs");
                Console.WriteLine("5) Exit");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    money = Payment.newPayment(money);
                }
                else if (option == 2)
                {
                    money = Credit.newCredit(money);
                }
                else if (option == 3)
                {
                    money = Income.newIncome(money);
                }

                else if (option == 4)
                {
                    displayPreviousInput();
                }
                else if (option == 5)
                {
                    exit = true;

                }
                else
                {
                    Console.WriteLine("Invalid input, please type in only the numbers 1-6");
                }


                
            }
            Shutdown(money);



        }
        static void displayPreviousInput()
        {
            bool goBack = false;
            while (goBack == false)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) See previous payments");
                Console.WriteLine("2) See previous credits");
                Console.WriteLine("3) See previous incomes");
                Console.WriteLine("4) Return to main menu");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    Payment.displayPayments();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
                else if (option == 2)
                {
                    Credit.displayCredits();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
                else if (option == 3)
                {
                    Income.displayIncomes();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
                else if (option == 4)
                {
                    goBack = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, please type in only the numbers 1-4");
                }
            }



        }
        static void Shutdown(Money money)
        {
            Properties.Settings.Default.currentCredit = money.currentCredit;
            Properties.Settings.Default.currentMoney = money.currentMoney;
            Properties.Settings.Default.Save();
            Console.WriteLine("Closing Program... \nPress any key to quit...");
            Console.ReadLine();
        }
        static void Shutdown()
        {
            Properties.Settings.Default.Save();
            Console.WriteLine("Please Restart the Program: ");
            Console.WriteLine("Closing Program... \nPress any key to quit...");
            Console.ReadLine();


        }
    }



}
