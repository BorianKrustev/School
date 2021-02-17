using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ChooseADrink
{
    class Program
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            decimal quantity = decimal.Parse(Console.ReadLine());

            decimal totalPrice = 0m;

            if (profession == "Athlete")
            {
                totalPrice = 0.70m;
                Console.WriteLine($"The {profession} has to pay {totalPrice * quantity:f2}.");
            }
            else if (profession == "Businessman" || profession == "Businesswoman")
            {
                totalPrice = 1.00m;
                Console.WriteLine($"The {profession} has to pay {totalPrice * quantity:f2}.");
            }
            else if (profession == "SoftUni Student")
            {
                totalPrice = 1.70m;
                Console.WriteLine($"The {profession} has to pay {totalPrice * quantity:f2}.");
            }
            else
            {
                totalPrice = 1.20m;
                Console.WriteLine($"The {profession} has to pay {totalPrice * quantity:f2}.");
            }
        }
    }
}
