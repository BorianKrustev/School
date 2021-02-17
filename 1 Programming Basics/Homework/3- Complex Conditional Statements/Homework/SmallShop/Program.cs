using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string prodact = Console.ReadLine();
            string city = Console.ReadLine();
            double quantaty = double.Parse(Console.ReadLine());

            string coffee = "coffee";
            string water = "water";
            string beer = "beer";
            string sweets = "sweets";
            string peanuts = "peanuts";

            if (city == "Sofia")
            {
                double coffeeP = 0.50;
                double waterP = 0.80;
                double beerP = 1.20;
                double sweetsP = 1.45;
                double peanutsP = 1.60;

                if (prodact == coffee)
                {
                    Console.WriteLine("{0}", coffeeP * quantaty);
                }
                else if (prodact == water)
                {
                    Console.WriteLine("{0}", waterP * quantaty);
                }
                else if (prodact == beer)
                {
                    Console.WriteLine("{0}", beerP * quantaty);
                }
                else if (prodact == sweets)
                {
                    Console.WriteLine("{0}", sweetsP * quantaty);
                }
                else if (prodact == peanuts)
                {
                    Console.WriteLine("{0}", peanutsP * quantaty);
                }
            }

            else if (city == "Plovdiv")
            {
                double coffeeP = 0.40;
                double waterP = 0.70;
                double beerP = 1.15;
                double sweetsP = 1.30;
                double peanutsP = 1.50;

                if (prodact == coffee)
                {
                    Console.WriteLine("{0}", coffeeP * quantaty);
                }
                else if (prodact == water)
                {
                    Console.WriteLine("{0}", waterP * quantaty);
                }
                else if (prodact == beer)
                {
                    Console.WriteLine("{0}", beerP * quantaty);
                }
                else if (prodact == sweets)
                {
                    Console.WriteLine("{0}", sweetsP * quantaty);
                }
                else if (prodact == peanuts)
                {
                    Console.WriteLine("{0}", peanutsP * quantaty);
                }
            }

            else if (city == "Varna")
            {
                double coffeeP = 0.45;
                double waterP = 0.70;
                double beerP = 1.10;
                double sweetsP = 1.35;
                double peanutsP = 1.55;

                if (prodact == coffee)
                {
                    Console.WriteLine("{0}", coffeeP * quantaty);
                }
                else if (prodact == water)
                {
                    Console.WriteLine("{0}", waterP * quantaty);
                }
                else if (prodact == beer)
                {
                    Console.WriteLine("{0}", beerP * quantaty);
                }
                else if (prodact == sweets)
                {
                    Console.WriteLine("{0}", sweetsP * quantaty);
                }
                else if (prodact == peanuts)
                {
                    Console.WriteLine("{0}", peanutsP * quantaty);
                }
            }
        }
    }
}
