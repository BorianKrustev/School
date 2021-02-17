using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.MilesToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal mile = decimal.Parse(Console.ReadLine());
            decimal km = 1.60934m;

            Console.WriteLine($"{mile * km:f2}");
        }
    }
}
