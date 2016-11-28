using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses
{
    class Money
    {
        public decimal currentMoney { get; set; }
        public decimal currentCredit { get; set; }

        public Money()
        {
            currentMoney = Properties.Settings.Default.currentMoney;
            currentCredit = Properties.Settings.Default.currentCredit;

        }
        public void displayMoney(Money money)
        {
            Console.WriteLine("Current Money: {0:C}", money.currentMoney);
            Console.WriteLine("Current Credit: {0:C}", money.currentCredit);
        }

    }
}
