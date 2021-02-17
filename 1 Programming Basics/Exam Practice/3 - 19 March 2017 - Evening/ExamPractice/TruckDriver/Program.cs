using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            decimal km = decimal.Parse(Console.ReadLine());

            decimal mony = 0m;

            if (km <= 5000)
            {
                if (season == "Summer")
                {
                    mony = 0.90m;
                }
                else if (season == "Winter")
                {
                    mony = 1.05m;
                }
                else
                {
                    mony = 0.75m;
                }
            }
            else if (km > 5000 && km <= 10000)
            {
                if (season == "Summer")
                {
                    mony = 1.10m;
                }
                else if (season == "Winter")
                {
                    mony = 1.25m;
                }
                else
                {
                    mony = 0.95m;
                }
            }
            else
            {
                mony = 1.45m;
            }

            mony *= km;
            mony *= 4;
            mony -= mony * 10 / 100;

            Console.WriteLine($"{mony:f2}");
        }
    }
}
