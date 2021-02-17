using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            double days = double.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());
            double dogFood = double.Parse(Console.ReadLine());
            double catFood = double.Parse(Console.ReadLine());
            double turtelFood = double.Parse(Console.ReadLine());

            dogFood *= days;
            catFood *= days;
            turtelFood /= 1000;
            turtelFood *= days;

            double all = dogFood + catFood + turtelFood;

            if (food >= all)
            {
                Console.WriteLine($"{Math.Floor(food - all)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(all - food)} more kilos of food are needed.");
            }
        }
    }
}
