using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruteCoctail
{
    class Program
    {
        static void Main(string[] args)
        {
            string frut = Console.ReadLine();
            string size = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            decimal mony = 0m;
            decimal dinia = 0m;
            decimal mango = 0m;
            decimal ananas = 0m;
            decimal malina = 0m;

            if (size == "small")
            {
                dinia = 2 * 56m;
                mango =  2 * 36.66m;
                ananas = 2 * 42.10m;
                malina = 2 * 20m;
            }
            else
            {
                dinia =  5 * 28.70m;
                mango =  5 * 19.60m;
                ananas = 5 * 24.80m;
                malina = 5 * 15.20m;
            }

            if (frut == "Watermelon")
            {
                mony = dinia;
            }
            else if ( frut == "Mango")
            {
                mony = mango;
            }
            else if (frut == "Pineapple")
            {
                mony = ananas;
            }
            else if (frut == "Raspberry")
            {
                mony = malina;
            }

            mony = mony * number;

            if (mony >= 400 && mony <= 1000)
            {
                mony = mony - (mony * 15 / 100);
            }
            else if (mony > 1000)
            {
                mony = mony - (mony * 50 / 100);
            }

            Console.WriteLine($"{mony:f2} lv.");
        }
    }
}
