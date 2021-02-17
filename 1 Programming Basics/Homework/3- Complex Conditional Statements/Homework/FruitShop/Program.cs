using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string frut = Console.ReadLine();
            string day = Console.ReadLine();
            double number = double.Parse(Console.ReadLine());

            if (day == "Saturday" || day == "Sunday")
            {
                double banana = 2.70;
                double apple = 1.25;
                double orange = 0.90;
                double grapefruit = 1.60;
                double kiwi = 3.00;
                double pineapple = 5.60;
                double grapes = 4.20;

                if (frut == "banana")
                {
                    Console.WriteLine($"{number * banana:f2}");
                }
                else if (frut == "apple")
                {
                    Console.WriteLine($"{number * apple:f2}");
                }
                else if (frut == "orange")
                {
                    Console.WriteLine($"{number * orange:f2}");
                }
                else if (frut == "grapefruit")
                {
                    Console.WriteLine($"{number * grapefruit:f2}");
                }
                else if (frut == "kiwi")
                {
                    Console.WriteLine($"{number * kiwi:f2}");
                }
                else if (frut == "pineapple")
                {
                    Console.WriteLine($"{number * pineapple:f2}");
                }
                else if (frut == "grapes")
                {
                    Console.WriteLine($"{number * grapes:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                double banana = 2.50;
                double apple = 1.20;
                double orange = 0.85;
                double grapefruit = 1.45;
                double kiwi = 2.70;
                double pineapple = 5.50;
                double grapes = 3.85;

                if (frut == "banana")
                {
                    Console.WriteLine($"{number * banana:f2}");
                }
                else if (frut == "apple")
                {
                    Console.WriteLine($"{number * apple:f2}");
                }
                else if (frut == "orange")
                {
                    Console.WriteLine($"{number * orange:f2}");
                }
                else if (frut == "grapefruit")
                {
                    Console.WriteLine($"{number * grapefruit:f2}");
                }
                else if (frut == "kiwi")
                {
                    Console.WriteLine($"{number * kiwi:f2}");
                }
                else if (frut == "pineapple")
                {
                    Console.WriteLine($"{number * pineapple:f2}");
                }
                else if (frut == "grapes")
                {
                    Console.WriteLine($"{number * grapes:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
                }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
