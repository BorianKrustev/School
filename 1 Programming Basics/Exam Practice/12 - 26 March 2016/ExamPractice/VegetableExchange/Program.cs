using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pKgZ = decimal.Parse(Console.ReadLine());
            decimal pKgP = decimal.Parse(Console.ReadLine());
            decimal kgZ = decimal.Parse(Console.ReadLine());
            decimal kgP = decimal.Parse(Console.ReadLine());

            pKgZ *= kgZ;
            pKgP *= kgP;
            decimal all = (pKgP + pKgZ) / 1.94m;

            Console.WriteLine($"{all:f2}");
        }
    }
}
