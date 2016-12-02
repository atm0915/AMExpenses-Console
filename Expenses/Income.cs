using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses
{
    class Income
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal moneyAmount { get; set; }

        public static Money newIncome(Money money)
        {
            Income income = new Income();
            income.Date = DateTime.Now;
            Console.WriteLine("Please enter the description of the income");
            income.Description = Console.ReadLine();
            Console.WriteLine("Please enter the income amount");
            income.moneyAmount = decimal.Parse(Console.ReadLine());
            money.currentMoney += income.moneyAmount;

            using (StreamWriter writetext = new StreamWriter("incomes.txt", true))
            {
                writetext.WriteLine(String.Format("{0:MM/dd/yyyy} | {1} | {2:C}",
                    income.Date,
                    income.Description,
                    income.moneyAmount));

            }
            return money;

        }
        public static void displayIncomes()
        {
            using (StreamReader sr = new StreamReader("incomes.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
