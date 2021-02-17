using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.RestaurantDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal group = decimal.Parse(Console.ReadLine());
            string package = Console.ReadLine();

            decimal discount = 0m;
            decimal price = 0m;
            decimal hallPrice = 0m;
            decimal finalPrice = 0m;
            string hallName = "";

            if (group <= 50)
            {
                hallPrice = 2500m;
                hallName = "Small Hall";

            }
            else if (group > 5 & group <= 100)
            {
                hallPrice = 5000m;
                hallName = "Terrace";
            }
            else if (group > 100 && group <= 120)
            {
                hallPrice = 7500m;
                hallName = "Great Hall";
            }

            if (package == "Normal")
            {
                discount = 5m;
                price = 500m;
            }
            else if (package == "Gold")
            {
                discount = 10m;
                price = 750m;
            }
            else
            {
                discount = 15m;
                price = 1000m;
            }

            if (group > 120)
            {
                Console.WriteLine($"We do not have an appropriate hall.");
            }
            else
            {
                finalPrice = hallPrice + price;
                finalPrice -= finalPrice * discount / 100;

                Console.WriteLine($"We can offer you the {hallName}");
                Console.WriteLine($"The price per person is {finalPrice / group:f2}$");
            }
        }
    }
}
