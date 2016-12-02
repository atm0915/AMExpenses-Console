using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses
{
    class Credit
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal moneyAmount { get; set; }

        public static Money newCredit(Money money)
        {
            Credit credit = new Credit();
            credit.Date = DateTime.Now;
            Console.WriteLine("Please enter the description of the credit");
            credit.Description = Console.ReadLine();
            Console.WriteLine("Please enter the credit amount");
            credit.moneyAmount = decimal.Parse(Console.ReadLine());
            money.currentCredit += credit.moneyAmount;
            using (StreamWriter writetext = new StreamWriter("credits.txt", true))
            {
                writetext.WriteLine(String.Format("{0:MM/dd/yyyy} | {1} | {2:C}",
                    credit.Date,
                    credit.Description,
                    credit.moneyAmount));

            }
            return money;
        }
        public static void displayCredits()
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
