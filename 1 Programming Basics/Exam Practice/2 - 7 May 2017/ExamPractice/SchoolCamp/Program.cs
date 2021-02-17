using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string seson = Console.ReadLine();
            string gender = Console.ReadLine();
            decimal students = decimal.Parse(Console.ReadLine());
            decimal nights = decimal.Parse(Console.ReadLine());

            decimal prise = students * nights;
            decimal pWinter = 9.60m;
            decimal pProlet = 7.20m;
            decimal pSumer = 15m;
            string sport = "asd";

            if (gender == "mixed")
            {
                pWinter = 10m;
                pProlet = 9.50m;
                pSumer = 20m;
            }

            if (seson == "Winter")
            {
                prise *= pWinter;
            }
            if (seson == "Spring")
            {
                prise *= pProlet;
            }
            if (seson == "Summer")
            {
                prise *= pSumer;
            }

            if (students >= 50)
            {
                prise -= prise * 50 / 100;
            }
            if (students >= 20 && students < 50)
            {
                prise -= prise * 15 / 100;
            }
            if (students >= 10 && students < 20)
            {
                prise -= prise * 5 / 100;
            }

            if (gender == "boys")
            {
                if (seson == "Winter")
                {
                    sport = "Judo";
                }
                else if (seson == "Spring")
                {
                    sport = "Tennis";
                }
                else
                {
                    sport = "Football";
                }
            }
            if (gender == "girls")
            {
                if (seson == "Winter")
                {
                    sport = "Gymnastics";
                }
                else if (seson == "Spring")
                {
                    sport = "Athletics";
                }
                else
                {
                    sport = "Volleyball";
                }
            }
            if (gender == "mixed")
            {
                if (seson == "Winter")
                {
                    sport = "Ski";
                }
                else if (seson == "Spring")
                {
                    sport = "Cycling";
                }
                else
                {
                    sport = "Swimming";
                }
            }

            Console.WriteLine($"{sport} {prise:f2} lv.");
        }
    }
}
