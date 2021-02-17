using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string stay = "asd";
            string plase = "asd";
            decimal spent = 0m;

            if (budget <= 100)
            {
                plase = "Bulgaria";

                if (season == "summer")
                {
                    spent = budget * 30 / 100;
                    stay = "Camp";
                }
                else
                {
                    spent = budget * 70 / 100;
                    stay = "Hotel";
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                plase = "Balkans";

                if (season == "summer")
                {
                    spent = budget * 40 / 100;
                    stay = "Camp";
                }
                else
                {
                    spent = budget * 80 / 100;
                    stay = "Hotel";
                }
            }
            else if (budget > 1000)
            {
                plase = "Europe";

                spent = budget * 90 / 100;
                stay = "Hotel";
            }

            Console.WriteLine($"Somewhere in {plase}");
            Console.WriteLine($"{stay} - {spent:f2}");
        }
    }
}
