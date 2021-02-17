using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string catagori = Console.ReadLine();
            decimal pepol = decimal.Parse(Console.ReadLine());

            decimal transport = 0m;
            decimal ticket = 0m;

            if (pepol <= 4)
            {
                transport =budget - (budget * 75 / 100);
            }
            else if (pepol >= 5 && pepol <= 9)
            {
                transport = budget - (budget * 60 / 100);
            }
            else if (pepol >= 10 && pepol <= 24)
            {
                transport = budget - (budget * 50 / 100);
            }
            else if (pepol >= 25 && pepol <= 49)
            {
                transport = budget - (budget * 40 / 100);
            }
            else if (pepol >= 50)
            {
                transport = budget - (budget * 25 / 100);
            }

            if (catagori == "VIP")
            {
                ticket = 499.99m;
            }
            else
            {
                ticket = 249.99m;
            }
            ticket *= pepol;

            if (transport >= ticket)
            {
                Console.WriteLine($"Yes! You have {transport - ticket:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {ticket - transport:f2} leva.");
            }
        }
    }
}
