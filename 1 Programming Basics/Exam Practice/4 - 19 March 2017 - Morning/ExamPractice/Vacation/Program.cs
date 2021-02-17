using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string liv = "asd";
            string plase = "asd";

            if (budget <= 1000)
            {
                liv = "Camp";
                if (season == "Summer")
                {
                    plase = "Alaska";
                    budget = budget * 65 / 100;
                }
                else
                {
                    plase = "Morocco";
                    budget = budget * 45 / 100;
                }
            }

            else if (budget > 1000 && budget <= 3000)
            {
                liv = "Hut";
                if (season == "Summer")
                {
                    plase = "Alaska";
                    budget = budget * 80 / 100;
                }
                else
                {
                    plase = "Morocco";
                    budget = budget * 60 / 100;
                }
            }

            else if (budget > 3000)
            {
                liv = "Hotel";
                if (season == "Summer")
                {
                    plase = "Alaska";
                    budget = budget * 90 / 100;
                }
                else
                {
                    plase = "Morocco";
                    budget = budget * 90 / 100;
                }
            }

            Console.WriteLine($"{plase} - {liv} - {budget:f2}");
        }
    }
}
