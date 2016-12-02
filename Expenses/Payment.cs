using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses
{
    class Payment
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal moneyAmount { get; set; }

        public static Money newPayment(Money money)
        {
            Payment payment = new Payment();
            payment.Date = DateTime.Now;
            Console.WriteLine("Please enter the description of the payment");
            payment.Description = Console.ReadLine();
            Console.WriteLine("Please enter the payment amount");
            payment.moneyAmount = decimal.Parse(Console.ReadLine());
            if (money.currentCredit > 0 && money.currentCredit > payment.moneyAmount)
            {
                money.currentCredit -= payment.moneyAmount;
            }
            else if (money.currentCredit > 0 && money.currentCredit < payment.moneyAmount)
            {
                money.currentCredit -= payment.moneyAmount;
                decimal newAmount = money.currentCredit * -1;
                money.currentMoney -= newAmount;
                money.currentCredit = 0;
            }
            else if (money.currentCredit == 0)
            {
                money.currentMoney -= payment.moneyAmount;
            }




            using (StreamWriter writetext = new StreamWriter("payments.txt", true))
            {
                writetext.WriteLine(String.Format("{0:MM/dd/yyyy} | {1} | {2:C}", 
                    payment.Date, 
                    payment.Description, 
                    payment.moneyAmount));

            }



            return money;

        }
        public static void displayPayments()
        {
            using (StreamReader sr = new StreamReader("payments.txt"))
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
