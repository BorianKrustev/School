using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string clas = "a";
            string car = "a";
            decimal prise = 0m;

            if (budget <= 100)
            {
                clas = "Economy class";
                if (season == "Summer")
                {
                    car = "Cabrio";
                    prise = budget * 35 / 100;
                }
                else
                {
                    car = "Jeep";
                    prise = budget * 65 / 100;
                }
            }
            else if (budget > 100 && budget <= 500)
            {
                clas = "Compact class";
                if (season == "Summer")
                {
                    car = "Cabrio";
                    prise = budget * 45 / 100;
                }
                else
                {
                    car = "Jeep";
                    prise = budget * 80 / 100;
                }
            }
            else if (budget > 500)
            {
                clas = "Luxury class";
                if (season == "Summer")
                {
                    car = "Jeep";
                    prise = budget * 90 / 100;
                }
                else
                {
                    car = "Jeep";
                    prise = budget * 90 / 100;
                }
            }

            Console.WriteLine($"{clas}");
            Console.WriteLine($"{car} - {prise:f2}");
        }
    }
}
