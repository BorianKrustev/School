using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.BeverageLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double voulm = double.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double suger = double.Parse(Console.ReadLine());

            Console.WriteLine($"{voulm}ml {name}:");
            Console.WriteLine($"{voulm * energy / 100}kcal, {voulm * suger / 100}g sugars");
        }
    }
}
